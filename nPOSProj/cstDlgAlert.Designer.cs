namespace nPOSProj
{
    partial class cstDlgAlert
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
            this.components = new System.ComponentModel.Container();
            this.msgX = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblCmd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // msgX
            // 
            this.msgX.BackColor = System.Drawing.Color.White;
            this.msgX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msgX.Cursor = System.Windows.Forms.Cursors.No;
            this.msgX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgX.Font = new System.Drawing.Font("Courier New", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgX.Location = new System.Drawing.Point(0, 0);
            this.msgX.Name = "msgX";
            this.msgX.Size = new System.Drawing.Size(613, 116);
            this.msgX.TabIndex = 33;
            this.msgX.Text = "(Message)";
            this.msgX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCmd
            // 
            this.lblCmd.AutoSize = true;
            this.lblCmd.BackColor = System.Drawing.Color.Transparent;
            this.lblCmd.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCmd.Location = new System.Drawing.Point(370, 94);
            this.lblCmd.Name = "lblCmd";
            this.lblCmd.Size = new System.Drawing.Size(238, 18);
            this.lblCmd.TabIndex = 34;
            this.lblCmd.Text = "Press Enter To Continue";
            // 
            // cstDlgAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(613, 116);
            this.ControlBox = false;
            this.Controls.Add(this.lblCmd);
            this.Controls.Add(this.msgX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cstDlgAlert";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "cstDlgAlert";
            this.Load += new System.EventHandler(this.cstDlgAlert_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label msgX;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblCmd;
    }
}