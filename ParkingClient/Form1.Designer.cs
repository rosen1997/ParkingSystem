
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
            ((System.ComponentModel.ISupportInitialize)(this.CameraVideo)).BeginInit();
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 640);
            this.Controls.Add(this.BtnStartCamera);
            this.Controls.Add(this.CmbCameras);
            this.Controls.Add(this.CameraVideo);
            this.Name = "Form1";
            this.Text = "Parking System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.CameraVideo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox CameraVideo;
        private System.Windows.Forms.ComboBox CmbCameras;
        private System.Windows.Forms.Button BtnStartCamera;
    }
}

