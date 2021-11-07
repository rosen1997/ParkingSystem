using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingClient
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection CaptureDevice; // list of webcam
        private VideoCaptureDevice FinalFrame;
        private bool cameraStarted = false;

        public Form1()
        {
            InitializeComponent();

            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);//constructor
            foreach (FilterInfo Device in CaptureDevice)
            {
                CmbCameras.Items.Add(Device.Name);
            }

            CmbCameras.SelectedIndex = 0; // default
            FinalFrame = new VideoCaptureDevice();
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
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalFrame.IsRunning == true) FinalFrame.Stop();
        }
    }
}
