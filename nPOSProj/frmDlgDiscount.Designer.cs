namespace nPOSProj
{
    partial class frmDlgDiscount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDlgDiscount));
            this.txtBoxPerc = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBoxPerc
            // 
            this.txtBoxPerc.BackColor = System.Drawing.Color.Black;
            this.txtBoxPerc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxPerc.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPerc.ForeColor = System.Drawing.Color.White;
            this.txtBoxPerc.Location = new System.Drawing.Point(66, 7);
            this.txtBoxPerc.MaxLength = 3;
            this.txtBoxPerc.Multiline = true;
            this.txtBoxPerc.Name = "txtBoxPerc";
            this.txtBoxPerc.ShortcutsEnabled = false;
            this.txtBoxPerc.Size = new System.Drawing.Size(79, 45);
            this.txtBoxPerc.TabIndex = 1;
            this.txtBoxPerc.Text = "0";
            this.txtBoxPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxPerc.TextChanged += new System.EventHandler(this.txtBoxPerc_TextChanged);
            this.txtBoxPerc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxPerc_KeyDown);
            this.txtBoxPerc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxPerc_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 49);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmDlgDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(153, 61);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtBoxPerc);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDlgDiscount";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discount";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxPerc;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}