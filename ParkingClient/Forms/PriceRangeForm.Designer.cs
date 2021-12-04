
namespace ParkingClient.Forms
{
    partial class PriceRangeForm
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
            this.dgvPriceRanges = new System.Windows.Forms.DataGridView();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddPrice = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceRanges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Price Ranges";
            // 
            // dgvPriceRanges
            // 
            this.dgvPriceRanges.AllowUserToAddRows = false;
            this.dgvPriceRanges.AllowUserToDeleteRows = false;
            this.dgvPriceRanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPriceRanges.Location = new System.Drawing.Point(12, 53);
            this.dgvPriceRanges.Name = "dgvPriceRanges";
            this.dgvPriceRanges.ReadOnly = true;
            this.dgvPriceRanges.Size = new System.Drawing.Size(326, 207);
            this.dgvPriceRanges.TabIndex = 1;
            // 
            // numPrice
            // 
            this.numPrice.Location = new System.Drawing.Point(452, 94);
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(120, 20);
            this.numPrice.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(449, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "New Price";
            // 
            // btnAddPrice
            // 
            this.btnAddPrice.Location = new System.Drawing.Point(452, 120);
            this.btnAddPrice.Name = "btnAddPrice";
            this.btnAddPrice.Size = new System.Drawing.Size(120, 23);
            this.btnAddPrice.TabIndex = 4;
            this.btnAddPrice.Text = "Add Price";
            this.btnAddPrice.UseVisualStyleBackColor = true;
            this.btnAddPrice.Click += new System.EventHandler(this.btnAddPrice_Click);
            // 
            // PriceRangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 324);
            this.Controls.Add(this.btnAddPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.dgvPriceRanges);
            this.Controls.Add(this.label1);
            this.Name = "PriceRangeForm";
            this.Text = "PriceRangeForm";
            this.Load += new System.EventHandler(this.PriceRangeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceRanges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPriceRanges;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddPrice;
    }
}