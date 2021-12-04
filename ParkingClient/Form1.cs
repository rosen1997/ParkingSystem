using AForge.Video;
using AForge.Video.DirectShow;
using ParkingClient.Models;
using RestSharp;
using SimpleLPR3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingClient
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection CaptureDevice; // list of webcam
        private VideoCaptureDevice FinalFrame;
        private bool cameraStarted = false;
        private bool isCameraEntry = true;

        #region SimpleLpr
        private EngineSetupParms setupP;
        private ISimpleLPR lpr;
        IProcessor proc;
        #endregion

        private string lastPlate = string.Empty;
        public string LastPlate
        {
            get => lastPlate;
            set
            {
                lastPlate = value;
                if (isCameraEntry)
                {
                    VehicleEnter(new ParkingStatusModel { LicensePlate = value, TimeOfArrival = DateTime.Now });
                }
                else
                {
                    var parkingStatus = new ParkingStatusModel { LicensePlate = value, TimeOfLeave = DateTime.Now };
                    var payment = CalculateVehiclePayment(parkingStatus);
                    //TODO: show new form enter payment amount and press OK
                    parkingStatus.Payment = payment;
                    VehicleLeave(parkingStatus);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();

            cmbCameraType.Items.Add("Entry Camera");
            cmbCameraType.Items.Add("Leave Camera");

            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);//constructor
            foreach (FilterInfo Device in CaptureDevice)
            {
                CmbCameras.Items.Add(Device.Name);
            }

            CmbCameras.SelectedIndex = 0; // default
            FinalFrame = new VideoCaptureDevice();

            #region SimpleLPR Initialization
            setupP.cudaDeviceId = -1; // Select CPU
            setupP.enableImageProcessingWithGPU = false;
            setupP.enableClassificationWithGPU = false;
            setupP.maxConcurrentImageProcessingOps = 0;  // Use the default value.  
            lpr = SimpleLPR.Setup(setupP);
            //Bulgaria code is 12
            lpr.set_countryWeight(12, 1.0f);
            proc = lpr.createProcessor();
            #endregion

        }

        private void VehicleEnter(ParkingStatusModel parkingStatusModel)
        {
            var client = new RestClient("https://localhost:44361/ParkingAndPayment/EnterParking");

            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/vnd.api+json");
            request.AddHeader("Accept", "application/vnd.api+json");

            request.AddJsonBody(parkingStatusModel);

            var response = client.Execute<ParkingStatusModel>(request).Data;
        }
        private PaymentModel CalculateVehiclePayment(ParkingStatusModel parkingStatusModel)
        {
            var client = new RestClient("https://localhost:44361/ParkingAndPayment/GetCalculatedPaymentForLicensePlate");

            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/vnd.api+json");
            request.AddHeader("Accept", "application/vnd.api+json");

            request.AddJsonBody(parkingStatusModel);

            var response = client.Execute<PaymentModel>(request).Data;

            return response;
        }
        private PaymentModel VehicleLeave(ParkingStatusModel parkingStatusModel)
        {
            var client = new RestClient("https://localhost:44361/ParkingAndPayment/VehicleLeave");

            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/vnd.api+json");
            request.AddHeader("Accept", "application/vnd.api+json");

            request.AddJsonBody(parkingStatusModel);

            var response = client.Execute<PaymentModel>(request).Data;

            return response;
        }

        private void BtnStartCamera_Click(object sender, EventArgs e)
        {
            if (!cameraStarted)
            {
                FinalFrame = new VideoCaptureDevice(CaptureDevice[CmbCameras.SelectedIndex].MonikerString);// specified web cam and its filter moniker string
                FinalFrame.VideoResolution = FinalFrame.VideoCapabilities[2];
                FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
                FinalFrame.Start();
                BtnStartCamera.Text = "Stop Camera";
                cameraStarted = true;
            }
            else
            {
                FinalFrame.Stop();
                BtnStartCamera.Text = "Start Camera";
                cameraStarted = false;
            }
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = eventArgs.Frame;
            CameraVideo.Image = (Bitmap)bitmap.Clone();
            var candidates = proc.analyze(bitmap);
            if (candidates.Any())
            {
                var bestCandidate = candidates.Aggregate((i1, i2) => i1.matches[0].confidence > i2.matches[0].confidence ? i1 : i2);
                var bestMatch = bestCandidate.matches[0].text;
                string regexPattern = "[A-Z]{1,2}[ ][1-9]{4}[ ][A-Z]{2}";
                Regex regex = new Regex(regexPattern);
                var regMatch = regex.Match(bestMatch);
                if (!regMatch.Success)
                    return;

                if (LastPlate.Equals(bestMatch))
                    return;

                LastPlate = bestMatch;
                drawImage(bestCandidate, bitmap);
            }
        }

        private void drawImage(Candidate cd, Bitmap currentBitmap)
        {
            if (currentBitmap.PixelFormat != System.Drawing.Imaging.PixelFormat.Indexed)
            {
                Bitmap bmp = new Bitmap(currentBitmap);

                using (Graphics gfx = Graphics.FromImage(bmp))
                {
                    gfx.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
                    gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                    Pen skyBluePen = new Pen(Brushes.DeepSkyBlue, 1.0f);
                    Pen springGreenPen = new Pen(Brushes.SpringGreen, 2.0f);
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    sf.FormatFlags = StringFormatFlags.NoClip;

                    if (cd.plateDetectionConfidence > 0)
                    {
                        gfx.DrawPolygon(springGreenPen, cd.plateRegionVertices);
                    }

                    if (cd.matches.Count > 0)
                    {
                        CountryMatch cm = cd.matches[0];

                        foreach (Element e in cm.elements)
                        {
                            gfx.DrawRectangle(skyBluePen, e.bbox);

                            Color c1 = Color.FromKnownColor(KnownColor.Crimson);
                            Color c2 = Color.FromKnownColor(KnownColor.Blue);

                            double fLambda = e.confidence; // Math.Log((double)e.confidence + 1.0) / Math.Log(2.0);
                            double fLambda_1 = 1.0 - fLambda;

                            double fR = (double)c1.R * fLambda + (double)c2.R * fLambda_1;
                            double fG = (double)c1.G * fLambda + (double)c2.G * fLambda_1;
                            double fB = (double)c1.B * fLambda + (double)c2.B * fLambda_1;

                            Color c3 = Color.FromArgb((int)fR, (int)fG, (int)fB);
                            using (Brush brush = new SolidBrush(c3))
                            {
                                using (Font fnt = new Font("Tahoma", (float)e.bbox.Height, GraphicsUnit.Pixel))
                                {
                                    gfx.DrawString(e.glyph.ToString(),
                                                    fnt,
                                                    brush,
                                                    (float)e.bbox.Left + (float)e.bbox.Width / 2.0f,
                                                    (float)e.bbox.Bottom + (float)e.bbox.Height * 1.2f / 2.0f,
                                                    sf);
                                }
                            }
                        }
                    }

                    gfx.Flush();
                }

                RecognizedPlate.Image = bmp;
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalFrame.IsRunning == true) FinalFrame.Stop();
        }

        private void cmbCameraType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCameraType.SelectedItem.Equals("Entry Camera"))
            {
                isCameraEntry = true;
            }
            else
                isCameraEntry = false;
        }
    }
}
