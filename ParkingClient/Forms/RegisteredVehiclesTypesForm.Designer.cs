
namespace ParkingClient.Forms
{
    partial class RegisteredVehiclesTypesForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.dgvVehicleTypes = new System.Windows.Forms.DataGridView();
            this.txtVehicleType = new System.Windows.Forms.TextBox();
            this.btnAddType = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vehicle Types";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(497, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "New Vehicle Type";
            // 
            // dgvVehicleTypes
            // 
            this.dgvVehicleTypes.AllowUserToAddRows = false;
            this.dgvVehicleTypes.AllowUserToDeleteRows = false;
            this.dgvVehicleTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicleTypes.Location = new System.Drawing.Point(15, 69);
            this.dgvVehicleTypes.Name = "dgvVehicleTypes";
            this.dgvVehicleTypes.ReadOnly = true;
            this.dgvVehicleTypes.Size = new System.Drawing.Size(333, 318);
            this.dgvVehicleTypes.TabIndex = 2;
            // 
            // txtVehicleType
            // 
            this.txtVehicleType.Location = new System.Drawing.Point(500, 95);
            this.txtVehicleType.Name = "txtVehicleType";
            this.txtVehicleType.Size = new System.Drawing.Size(182, 20);
            this.txtVehicleType.TabIndex = 3;
            // 
            // btnAddType
            // 
            this.btnAddType.Location = new System.Drawing.Point(500, 133);
            this.btnAddType.Name = "btnAddType";
            this.btnAddType.Size = new System.Drawing.Size(108, 23);
            this.btnAddType.TabIndex = 4;
            this.btnAddType.Text = "Add";
            this.btnAddType.UseVisualStyleBackColor = true;
            this.btnAddType.Click += new System.EventHandler(this.btnAddType_Click);
            // 
            // RegisteredVehiclesTypesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 422);
            this.Controls.Add(this.btnAddType);
            this.Controls.Add(this.txtVehicleType);
            this.Controls.Add(this.dgvVehicleTypes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegisteredVehiclesTypesForm";
            this.Text = "RegisteredVehiclesTypesForm";
            this.Load += new System.EventHandler(this.RegisteredVehiclesTypesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvVehicleTypes;
        private System.Windows.Forms.TextBox txtVehicleType;
        private System.Windows.Forms.Button btnAddType;
    }
}