namespace nPOSProj
{
    partial class frmDlgGlobalDisc
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
            this.txtBoxAmount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBoxAmount
            // 
            this.txtBoxAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxAmount.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxAmount.Location = new System.Drawing.Point(0, 0);
            this.txtBoxAmount.MaxLength = 15;
            this.txtBoxAmount.Name = "txtBoxAmount";
            this.txtBoxAmount.Size = new System.Drawing.Size(449, 43);
            this.txtBoxAmount.TabIndex = 0;
            this.txtBoxAmount.Text = "0.00";
            this.txtBoxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxAmount_KeyDown);
            this.txtBoxAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxAmount_KeyPress);
            // 
            // frmDlgGlobalDisc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 44);
            this.Controls.Add(this.txtBoxAmount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDlgGlobalDisc";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Global Discount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxAmount;
    }
}