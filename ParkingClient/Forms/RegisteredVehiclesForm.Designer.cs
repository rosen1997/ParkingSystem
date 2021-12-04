
namespace ParkingClient.Forms
{
    partial class RegisteredVehiclesForm
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
            this.dgvRegisteredVehicles = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.cmbPriceRange = new System.Windows.Forms.ComboBox();
            this.cmbVehicleType = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisteredVehicles)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registered Vehicles";
            // 
            // dgvRegisteredVehicles
            // 
            this.dgvRegisteredVehicles.AllowUserToAddRows = false;
            this.dgvRegisteredVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegisteredVehicles.Location = new System.Drawing.Point(15, 63);
            this.dgvRegisteredVehicles.Name = "dgvRegisteredVehicles";
            this.dgvRegisteredVehicles.ReadOnly = true;
            this.dgvRegisteredVehicles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegisteredVehicles.Size = new System.Drawing.Size(561, 291);
            this.dgvRegisteredVehicles.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(674, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "New Vehicle";
            // 
            // txtPlate
            // 
            this.txtPlate.Location = new System.Drawing.Point(677, 119);
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(143, 20);
            this.txtPlate.TabIndex = 3;
            // 
            // cmbPriceRange
            // 
            this.cmbPriceRange.FormattingEnabled = true;
            this.cmbPriceRange.Location = new System.Drawing.Point(677, 145);
            this.cmbPriceRange.Name = "cmbPriceRange";
            this.cmbPriceRange.Size = new System.Drawing.Size(143, 21);
            this.cmbPriceRange.TabIndex = 4;
            // 
            // cmbVehicleType
            // 
            this.cmbVehicleType.FormattingEnabled = true;
            this.cmbVehicleType.Location = new System.Drawing.Point(677, 172);
            this.cmbVehicleType.Name = "cmbVehicleType";
            this.cmbVehicleType.Size = new System.Drawing.Size(143, 21);
            this.cmbVehicleType.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(745, 218);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(15, 371);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete Selected";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // RegisteredVehiclesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 450);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbVehicleType);
            this.Controls.Add(this.cmbPriceRange);
            this.Controls.Add(this.txtPlate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvRegisteredVehicles);
            this.Controls.Add(this.label1);
            this.Name = "RegisteredVehiclesForm";
            this.Text = "RegisteredVehiclesForm";
            this.Load += new System.EventHandler(this.RegisteredVehiclesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisteredVehicles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRegisteredVehicles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPlate;
        private System.Windows.Forms.ComboBox cmbPriceRange;
        private System.Windows.Forms.ComboBox cmbVehicleType;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
    }
}