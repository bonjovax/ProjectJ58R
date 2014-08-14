namespace nPOSProj
{
    partial class mdiFrmInv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdiFrmInv));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsCatSetup = new System.Windows.Forms.ToolStripButton();
            this.tsItems = new System.Windows.Forms.ToolStripButton();
            this.tsItemKits = new System.Windows.Forms.ToolStripButton();
            this.tsStocks = new System.Windows.Forms.ToolStripButton();
            this.tsSupplier = new System.Windows.Forms.ToolStripButton();
            this.tsPO = new System.Windows.Forms.ToolStripButton();
            this.tsReceiving = new System.Windows.Forms.ToolStripButton();
            this.tsReporting = new System.Windows.Forms.ToolStripButton();
            this.tsEmail = new System.Windows.Forms.ToolStripButton();
            this.tsExit = new System.Windows.Forms.ToolStripButton();
            this.tsAbout = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsOnline = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsOffline = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsToday = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.toolStrip1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCatSetup,
            this.tsItems,
            this.tsItemKits,
            this.tsStocks,
            this.tsSupplier,
            this.tsPO,
            this.tsReceiving,
            this.tsReporting,
            this.tsEmail,
            this.tsExit,
            this.tsAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(918, 72);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsCatSetup
            // 
            this.tsCatSetup.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsCatSetup.ForeColor = System.Drawing.Color.White;
            this.tsCatSetup.Image = ((System.Drawing.Image)(resources.GetObject("tsCatSetup.Image")));
            this.tsCatSetup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsCatSetup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCatSetup.Name = "tsCatSetup";
            this.tsCatSetup.Size = new System.Drawing.Size(107, 69);
            this.tsCatSetup.Text = "&Category Setup";
            this.tsCatSetup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsCatSetup.Click += new System.EventHandler(this.tsCatSetup_Click);
            // 
            // tsItems
            // 
            this.tsItems.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsItems.ForeColor = System.Drawing.Color.White;
            this.tsItems.Image = ((System.Drawing.Image)(resources.GetObject("tsItems.Image")));
            this.tsItems.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsItems.Name = "tsItems";
            this.tsItems.Size = new System.Drawing.Size(52, 69);
            this.tsItems.Text = "&Items";
            this.tsItems.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsItems.Click += new System.EventHandler(this.tsItems_Click);
            // 
            // tsItemKits
            // 
            this.tsItemKits.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsItemKits.ForeColor = System.Drawing.Color.White;
            this.tsItemKits.Image = ((System.Drawing.Image)(resources.GetObject("tsItemKits.Image")));
            this.tsItemKits.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsItemKits.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsItemKits.Name = "tsItemKits";
            this.tsItemKits.Size = new System.Drawing.Size(66, 69);
            this.tsItemKits.Text = "Item &Kits";
            this.tsItemKits.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsItemKits.Click += new System.EventHandler(this.tsItemKits_Click);
            // 
            // tsStocks
            // 
            this.tsStocks.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsStocks.ForeColor = System.Drawing.Color.White;
            this.tsStocks.Image = ((System.Drawing.Image)(resources.GetObject("tsStocks.Image")));
            this.tsStocks.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsStocks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsStocks.Name = "tsStocks";
            this.tsStocks.Size = new System.Drawing.Size(52, 69);
            this.tsStocks.Text = "&Stocks";
            this.tsStocks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsStocks.Click += new System.EventHandler(this.tsStocks_Click);
            // 
            // tsSupplier
            // 
            this.tsSupplier.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsSupplier.ForeColor = System.Drawing.Color.White;
            this.tsSupplier.Image = ((System.Drawing.Image)(resources.GetObject("tsSupplier.Image")));
            this.tsSupplier.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsSupplier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSupplier.Name = "tsSupplier";
            this.tsSupplier.Size = new System.Drawing.Size(61, 69);
            this.tsSupplier.Text = "&Supplier";
            this.tsSupplier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsSupplier.Click += new System.EventHandler(this.tsSupplier_Click);
            // 
            // tsPO
            // 
            this.tsPO.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPO.ForeColor = System.Drawing.Color.White;
            this.tsPO.Image = ((System.Drawing.Image)(resources.GetObject("tsPO.Image")));
            this.tsPO.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsPO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPO.Name = "tsPO";
            this.tsPO.Size = new System.Drawing.Size(106, 69);
            this.tsPO.Text = "Purchase &Order";
            this.tsPO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsPO.Click += new System.EventHandler(this.tsPO_Click);
            // 
            // tsReceiving
            // 
            this.tsReceiving.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsReceiving.ForeColor = System.Drawing.Color.White;
            this.tsReceiving.Image = ((System.Drawing.Image)(resources.GetObject("tsReceiving.Image")));
            this.tsReceiving.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsReceiving.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsReceiving.Name = "tsReceiving";
            this.tsReceiving.Size = new System.Drawing.Size(69, 69);
            this.tsReceiving.Text = "&Receiving";
            this.tsReceiving.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsReceiving.Click += new System.EventHandler(this.tsReceiving_Click);
            // 
            // tsReporting
            // 
            this.tsReporting.Enabled = false;
            this.tsReporting.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsReporting.ForeColor = System.Drawing.Color.White;
            this.tsReporting.Image = ((System.Drawing.Image)(resources.GetObject("tsReporting.Image")));
            this.tsReporting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsReporting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsReporting.Name = "tsReporting";
            this.tsReporting.Size = new System.Drawing.Size(72, 69);
            this.tsReporting.Text = "R&eporting";
            this.tsReporting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsReporting.Click += new System.EventHandler(this.tsReporting_Click);
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
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOnline,
            this.tsOffline,
            this.tsToday,
            this.tsUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 458);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(918, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
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
            this.tsToday.Size = new System.Drawing.Size(768, 17);
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
            // mdiFrmInv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(918, 480);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mdiFrmInv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mdiFrmInv_FormClosing);
            this.Load += new System.EventHandler(this.mdiFrmInv_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsItems;
        private System.Windows.Forms.ToolStripButton tsItemKits;
        private System.Windows.Forms.ToolStripButton tsSupplier;
        private System.Windows.Forms.ToolStripButton tsReceiving;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripButton tsCatSetup;
        private System.Windows.Forms.ToolStripButton tsReporting;
        private System.Windows.Forms.ToolStripButton tsAbout;
        private System.Windows.Forms.ToolStripButton tsExit;
        private System.Windows.Forms.ToolStripStatusLabel tsUser;
        private System.Windows.Forms.ToolStripStatusLabel tsToday;
        private System.Windows.Forms.ToolStripStatusLabel tsOnline;
        private System.Windows.Forms.ToolStripStatusLabel tsOffline;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton tsEmail;
        private System.Windows.Forms.ToolStripButton tsPO;
        private System.Windows.Forms.ToolStripButton tsStocks;

    }
}