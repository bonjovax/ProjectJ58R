namespace nPOSProj
{
    partial class cstYesNo
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
            this.lblCmd = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // msgX
            // 
            this.msgX.BackColor = System.Drawing.Color.SteelBlue;
            this.msgX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msgX.Cursor = System.Windows.Forms.Cursors.No;
            this.msgX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgX.Font = new System.Drawing.Font("Courier New", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgX.ForeColor = System.Drawing.Color.White;
            this.msgX.Location = new System.Drawing.Point(0, 0);
            this.msgX.Name = "msgX";
            this.msgX.Size = new System.Drawing.Size(691, 147);
            this.msgX.TabIndex = 34;
            this.msgX.Text = "(Message)";
            this.msgX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCmd
            // 
            this.lblCmd.AutoSize = true;
            this.lblCmd.BackColor = System.Drawing.Color.SteelBlue;
            this.lblCmd.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCmd.ForeColor = System.Drawing.Color.White;
            this.lblCmd.Location = new System.Drawing.Point(5, 123);
            this.lblCmd.Name = "lblCmd";
            this.lblCmd.Size = new System.Drawing.Size(378, 18);
            this.lblCmd.TabIndex = 35;
            this.lblCmd.Text = "Press F11 for Yes or Press F12 for No";
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.SteelBlue;
            this.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.ForeColor = System.Drawing.Color.White;
            this.btnYes.Location = new System.Drawing.Point(519, 113);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 36;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btnNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.ForeColor = System.Drawing.Color.White;
            this.btnNo.Location = new System.Drawing.Point(600, 113);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 37;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // cstYesNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 147);
            this.ControlBox = false;
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.lblCmd);
            this.Controls.Add(this.msgX);
            this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cstYesNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.cstYesNo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label msgX;
        private System.Windows.Forms.Label lblCmd;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;

    }
}