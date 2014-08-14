namespace nPOSProj
{
    partial class mdiFrmOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdiFrmOrder));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsEmail = new System.Windows.Forms.ToolStripButton();
            this.tsExit = new System.Windows.Forms.ToolStripButton();
            this.tsAbout = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsOnline = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsOffline = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsToday = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tsQuotation = new System.Windows.Forms.ToolStripButton();
            this.tsOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(13)))));
            this.toolStrip1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOrder,
            this.tsQuotation,
            this.toolStripButton1,
            this.tsEmail,
            this.tsExit,
            this.tsAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(902, 72);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsEmail
            // 
            this.tsEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsEmail.ForeColor = System.Drawing.Color.White;
            this.tsEmail.Image = ((System.Drawing.Image)(resources.GetObject("tsEmail.Image")));
            this.tsEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEmail.Name = "tsEmail";
            this.tsEmail.Size = new System.Drawing.Size(102, 69);
            this.tsEmail.Text = "&E-Mail Support";
            this.tsEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsEmail.Click += new System.EventHandler(this.tsEmail_Click);
            // 
            // tsExit
            // 
            this.tsExit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsExit.ForeColor = System.Drawing.Color.White;
            this.tsExit.Image = ((System.Drawing.Image)(resources.GetObject("tsExit.Image")));
            this.tsExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(52, 69);
            this.tsExit.Text = "Exit";
            this.tsExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // tsAbout
            // 
            this.tsAbout.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsAbout.ForeColor = System.Drawing.Color.White;
            this.tsAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsAbout.Image")));
            this.tsAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAbout.Name = "tsAbout";
            this.tsAbout.Size = new System.Drawing.Size(52, 69);
            this.tsAbout.Text = "&About";
            this.tsAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsAbout.Click += new System.EventHandler(this.tsAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(13)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOnline,
            this.tsOffline,
            this.tsToday,
            this.tsUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(902, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsOnline
            // 
            this.tsOnline.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsOnline.ForeColor = System.Drawing.Color.White;
            this.tsOnline.Image = ((System.Drawing.Image)(resources.GetObject("tsOnline.Image")));
            this.tsOnline.Name = "tsOnline";
            this.tsOnline.Size = new System.Drawing.Size(58, 17);
            this.tsOnline.Text = "Online";
            // 
            // tsOffline
            // 
            this.tsOffline.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsOffline.ForeColor = System.Drawing.Color.White;
            this.tsOffline.Image = ((System.Drawing.Image)(resources.GetObject("tsOffline.Image")));
            this.tsOffline.Name = "tsOffline";
            this.tsOffline.Size = new System.Drawing.Size(59, 17);
            this.tsOffline.Text = "Offline";
            this.tsOffline.Visible = false;
            // 
            // tsToday
            // 
            this.tsToday.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsToday.ForeColor = System.Drawing.Color.White;
            this.tsToday.Name = "tsToday";
            this.tsToday.Size = new System.Drawing.Size(752, 17);
            this.tsToday.Spring = true;
            this.tsToday.Text = "clocks";
            // 
            // tsUser
            // 
            this.tsUser.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsUser.ForeColor = System.Drawing.Color.White;
            this.tsUser.Image = ((System.Drawing.Image)(resources.GetObject("tsUser.Image")));
            this.tsUser.Name = "tsUser";
            this.tsUser.Size = new System.Drawing.Size(77, 17);
            this.tsUser.Text = "userName";
            this.tsUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tsQuotation
            // 
            this.tsQuotation.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsQuotation.ForeColor = System.Drawing.Color.White;
            this.tsQuotation.Image = ((System.Drawing.Image)(resources.GetObject("tsQuotation.Image")));
            this.tsQuotation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsQuotation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsQuotation.Name = "tsQuotation";
            this.tsQuotation.Size = new System.Drawing.Size(74, 69);
            this.tsQuotation.Text = "&Quotation";
            this.tsQuotation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsOrder
            // 
            this.tsOrder.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsOrder.ForeColor = System.Drawing.Color.White;
            this.tsOrder.Image = ((System.Drawing.Image)(resources.GetObject("tsOrder.Image")));
            this.tsOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsOrder.Name = "tsOrder";
            this.tsOrder.Size = new System.Drawing.Size(52, 69);
            this.tsOrder.Text = "&Order";
            this.tsOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(123, 69);
            this.toolStripButton1.Text = "Quotation &History";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // mdiFrmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(902, 441);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mdiFrmOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mdiFrmOrder_FormClosing);
            this.Load += new System.EventHandler(this.mdiFrmOrder_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsEmail;
        private System.Windows.Forms.ToolStripButton tsExit;
        private System.Windows.Forms.ToolStripButton tsAbout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsOnline;
        private System.Windows.Forms.ToolStripStatusLabel tsOffline;
        private System.Windows.Forms.ToolStripStatusLabel tsToday;
        private System.Windows.Forms.ToolStripStatusLabel tsUser;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton tsQuotation;
        private System.Windows.Forms.ToolStripButton tsOrder;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}