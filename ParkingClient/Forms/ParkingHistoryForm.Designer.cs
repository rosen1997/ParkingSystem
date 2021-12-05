
namespace ParkingClient.Forms
{
    partial class ParkingHistoryForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvParkingHistory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParkingHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ParkingHistory";
            // 
            // dgvParkingHistory
            // 
            this.dgvParkingHistory.AllowUserToAddRows = false;
            this.dgvParkingHistory.AllowUserToDeleteRows = false;
            this.dgvParkingHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParkingHistory.Location = new System.Drawing.Point(15, 67);
            this.dgvParkingHistory.Name = "dgvParkingHistory";
            this.dgvParkingHistory.ReadOnly = true;
            this.dgvParkingHistory.Size = new System.Drawing.Size(773, 371);
            this.dgvParkingHistory.TabIndex = 1;
            // 
            // ParkingHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvParkingHistory);
            this.Controls.Add(this.label1);
            this.Name = "ParkingHistoryForm";
            this.Text = "ParkingHistoryForm";
            this.Load += new System.EventHandler(this.ParkingHistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParkingHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvParkingHistory;
    }
}