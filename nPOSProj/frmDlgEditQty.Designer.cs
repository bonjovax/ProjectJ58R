namespace nPOSProj
{
    partial class frmDlgEditQty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDlgEditQty));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtBoxQty = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtBoxQty
            // 
            this.txtBoxQty.BackColor = System.Drawing.Color.Black;
            this.txtBoxQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxQty.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxQty.ForeColor = System.Drawing.Color.White;
            this.txtBoxQty.Location = new System.Drawing.Point(65, 8);
            this.txtBoxQty.MaxLength = 3;
            this.txtBoxQty.Multiline = true;
            this.txtBoxQty.Name = "txtBoxQty";
            this.txtBoxQty.ShortcutsEnabled = false;
            this.txtBoxQty.Size = new System.Drawing.Size(79, 45);
            this.txtBoxQty.TabIndex = 2;
            this.txtBoxQty.Text = "0";
            this.txtBoxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxQty.TextChanged += new System.EventHandler(this.txtBoxQty_TextChanged);
            this.txtBoxQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxQty_KeyDown);
            this.txtBoxQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxQty_KeyPress);
            // 
            // frmDlgEditQty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(153, 61);
            this.Controls.Add(this.txtBoxQty);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDlgEditQty";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Quantity";
            this.Load += new System.EventHandler(this.frmDlgEditQty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtBoxQty;
    }
}