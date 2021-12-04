
namespace ParkingClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CameraVideo = new System.Windows.Forms.PictureBox();
            this.CmbCameras = new System.Windows.Forms.ComboBox();
            this.BtnStartCamera = new System.Windows.Forms.Button();
            this.RecognizedPlate = new System.Windows.Forms.PictureBox();
            this.cmbCameraType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CameraVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecognizedPlate)).BeginInit();
            this.SuspendLayout();
            // 
            // CameraVideo
            // 
            this.CameraVideo.Location = new System.Drawing.Point(12, 12);
            this.CameraVideo.Name = "CameraVideo";
            this.CameraVideo.Size = new System.Drawing.Size(626, 414);
            this.CameraVideo.TabIndex = 0;
            this.CameraVideo.TabStop = false;
            // 
            // CmbCameras
            // 
            this.CmbCameras.FormattingEnabled = true;
            this.CmbCameras.Location = new System.Drawing.Point(713, 12);
            this.CmbCameras.Name = "CmbCameras";
            this.CmbCameras.Size = new System.Drawing.Size(232, 21);
            this.CmbCameras.TabIndex = 1;
            // 
            // BtnStartCamera
            // 
            this.BtnStartCamera.Location = new System.Drawing.Point(713, 39);
            this.BtnStartCamera.Name = "BtnStartCamera";
            this.BtnStartCamera.Size = new System.Drawing.Size(145, 23);
            this.BtnStartCamera.TabIndex = 2;
            this.BtnStartCamera.Text = "Start Camera";
            this.BtnStartCamera.UseVisualStyleBackColor = true;
            this.BtnStartCamera.Click += new System.EventHandler(this.BtnStartCamera_Click);
            // 
            // RecognizedPlate
            // 
            this.RecognizedPlate.Location = new System.Drawing.Point(713, 385);
            this.RecognizedPlate.Name = "RecognizedPlate";
            this.RecognizedPlate.Size = new System.Drawing.Size(357, 233);
            this.RecognizedPlate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RecognizedPlate.TabIndex = 3;
            this.RecognizedPlate.TabStop = false;
            // 
            // cmbCameraType
            // 
            this.cmbCameraType.FormattingEnabled = true;
            this.cmbCameraType.Location = new System.Drawing.Point(713, 118);
            this.cmbCameraType.Name = "cmbCameraType";
            this.cmbCameraType.Size = new System.Drawing.Size(178, 21);
            this.cmbCameraType.TabIndex = 4;
            this.cmbCameraType.SelectedIndexChanged += new System.EventHandler(this.cmbCameraType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(710, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Camera Type";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 640);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCameraType);
            this.Controls.Add(this.RecognizedPlate);
            this.Controls.Add(this.BtnStartCamera);
            this.Controls.Add(this.CmbCameras);
            this.Controls.Add(this.CameraVideo);
            this.Name = "Form1";
            this.Text = "Parking System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.CameraVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecognizedPlate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CameraVideo;
        private System.Windows.Forms.ComboBox CmbCameras;
        private System.Windows.Forms.Button BtnStartCamera;
        private System.Windows.Forms.PictureBox RecognizedPlate;
        private System.Windows.Forms.ComboBox cmbCameraType;
        private System.Windows.Forms.Label label1;
    }
}

