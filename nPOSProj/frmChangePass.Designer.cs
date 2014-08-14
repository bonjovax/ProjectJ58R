namespace nPOSProj
{
    partial class frmChangePass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePass));
            this.btn_change = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxNewPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxConfirmPass = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_change
            // 
            this.btn_change.BackColor = System.Drawing.Color.Gold;
            this.btn_change.Enabled = false;
            this.btn_change.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btn_change.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btn_change.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btn_change.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_change.ForeColor = System.Drawing.Color.White;
            this.btn_change.Image = ((System.Drawing.Image)(resources.GetObject("btn_change.Image")));
            this.btn_change.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_change.Location = new System.Drawing.Point(243, 74);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(92, 34);
            this.btn_change.TabIndex = 2;
            this.btn_change.Text = "&Change";
            this.btn_change.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_change.UseVisualStyleBackColor = false;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Password";
            // 
            // txtBoxNewPass
            // 
            this.txtBoxNewPass.BackColor = System.Drawing.Color.SteelBlue;
            this.txtBoxNewPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxNewPass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxNewPass.ForeColor = System.Drawing.Color.White;
            this.txtBoxNewPass.Location = new System.Drawing.Point(130, 22);
            this.txtBoxNewPass.Name = "txtBoxNewPass";
            this.txtBoxNewPass.Size = new System.Drawing.Size(205, 22);
            this.txtBoxNewPass.TabIndex = 0;
            this.txtBoxNewPass.UseSystemPasswordChar = true;
            this.txtBoxNewPass.TextChanged += new System.EventHandler(this.txtBoxNewPass_TextChanged);
            this.txtBoxNewPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxNewPass_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Confirm Password";
            // 
            // txtBoxConfirmPass
            // 
            this.txtBoxConfirmPass.BackColor = System.Drawing.Color.SteelBlue;
            this.txtBoxConfirmPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxConfirmPass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxConfirmPass.ForeColor = System.Drawing.Color.White;
            this.txtBoxConfirmPass.Location = new System.Drawing.Point(130, 47);
            this.txtBoxConfirmPass.Name = "txtBoxConfirmPass";
            this.txtBoxConfirmPass.Size = new System.Drawing.Size(205, 22);
            this.txtBoxConfirmPass.TabIndex = 1;
            this.txtBoxConfirmPass.UseSystemPasswordChar = true;
            this.txtBoxConfirmPass.TextChanged += new System.EventHandler(this.txtBoxConfirmPass_TextChanged);
            this.txtBoxConfirmPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxConfirmPass_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_change);
            this.groupBox1.Controls.Add(this.txtBoxConfirmPass);
            this.groupBox1.Controls.Add(this.txtBoxNewPass);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Snow;
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 114);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change Password Information";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Crimson;
            this.btnBack.Enabled = false;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Indigo;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Indigo;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(167, 74);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(73, 34);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "&Back";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(353, 126);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePass";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.frmChangePass_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_change;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxNewPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxConfirmPass;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBack;
    }
}