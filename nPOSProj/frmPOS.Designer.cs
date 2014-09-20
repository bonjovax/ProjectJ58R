namespace nPOSProj
{
    partial class frmPOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOS));
            this.rdDescription = new System.Windows.Forms.TextBox();
            this.txtBoxQty = new System.Windows.Forms.TextBox();
            this.rdPrice = new System.Windows.Forms.TextBox();
            this.rdTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxEAN = new System.Windows.Forms.TextBox();
            this.btnCancelSale = new System.Windows.Forms.Button();
            this.btnParkSale = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnVoid = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnWholesale = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblChangeDue = new System.Windows.Forms.Label();
            this.lblVatable = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblUserAccount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblSeriesNo = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.lblProgversion = new System.Windows.Forms.Label();
            this.btnRefund = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.proceed = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblVATe = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblVATz = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTAXamt = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lviewPOS = new System.Windows.Forms.ListView();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRetail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdDescription
            // 
            this.rdDescription.BackColor = System.Drawing.Color.Black;
            this.rdDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rdDescription.Font = new System.Drawing.Font("Courier New", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdDescription.ForeColor = System.Drawing.Color.Lime;
            this.rdDescription.Location = new System.Drawing.Point(0, 0);
            this.rdDescription.Name = "rdDescription";
            this.rdDescription.ReadOnly = true;
            this.rdDescription.ShortcutsEnabled = false;
            this.rdDescription.Size = new System.Drawing.Size(1253, 55);
            this.rdDescription.TabIndex = 30;
            // 
            // txtBoxQty
            // 
            this.txtBoxQty.BackColor = System.Drawing.Color.MidnightBlue;
            this.txtBoxQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxQty.Font = new System.Drawing.Font("Courier New", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxQty.ForeColor = System.Drawing.Color.Lime;
            this.txtBoxQty.Location = new System.Drawing.Point(0, 55);
            this.txtBoxQty.MaxLength = 6;
            this.txtBoxQty.Name = "txtBoxQty";
            this.txtBoxQty.ReadOnly = true;
            this.txtBoxQty.ShortcutsEnabled = false;
            this.txtBoxQty.Size = new System.Drawing.Size(143, 55);
            this.txtBoxQty.TabIndex = 1;
            this.txtBoxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxQty_KeyPress);
            // 
            // rdPrice
            // 
            this.rdPrice.BackColor = System.Drawing.Color.MidnightBlue;
            this.rdPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rdPrice.Font = new System.Drawing.Font("Courier New", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPrice.ForeColor = System.Drawing.Color.Lime;
            this.rdPrice.Location = new System.Drawing.Point(195, 55);
            this.rdPrice.Name = "rdPrice";
            this.rdPrice.ReadOnly = true;
            this.rdPrice.ShortcutsEnabled = false;
            this.rdPrice.Size = new System.Drawing.Size(329, 55);
            this.rdPrice.TabIndex = 29;
            this.rdPrice.Text = "0.00";
            this.rdPrice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdPrice_MouseDown);
            this.rdPrice.MouseHover += new System.EventHandler(this.rdPrice_MouseHover);
            // 
            // rdTotal
            // 
            this.rdTotal.BackColor = System.Drawing.Color.MidnightBlue;
            this.rdTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rdTotal.Font = new System.Drawing.Font("Courier New", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTotal.ForeColor = System.Drawing.Color.Lime;
            this.rdTotal.Location = new System.Drawing.Point(524, 55);
            this.rdTotal.Name = "rdTotal";
            this.rdTotal.ReadOnly = true;
            this.rdTotal.ShortcutsEnabled = false;
            this.rdTotal.Size = new System.Drawing.Size(729, 55);
            this.rdTotal.TabIndex = 31;
            this.rdTotal.Text = "0.00";
            this.rdTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rdTotal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rdTotal_MouseDown);
            this.rdTotal.MouseHover += new System.EventHandler(this.rdTotal_MouseHover);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.MidnightBlue;
            this.label1.Font = new System.Drawing.Font("Courier New", 38.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(143, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 55);
            this.label1.TabIndex = 28;
            this.label1.Text = "@";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBoxEAN
            // 
            this.txtBoxEAN.BackColor = System.Drawing.Color.MidnightBlue;
            this.txtBoxEAN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxEAN.Font = new System.Drawing.Font("Courier New", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxEAN.ForeColor = System.Drawing.Color.White;
            this.txtBoxEAN.Location = new System.Drawing.Point(0, 201);
            this.txtBoxEAN.MaxLength = 25;
            this.txtBoxEAN.Name = "txtBoxEAN";
            this.txtBoxEAN.ReadOnly = true;
            this.txtBoxEAN.ShortcutsEnabled = false;
            this.txtBoxEAN.Size = new System.Drawing.Size(297, 42);
            this.txtBoxEAN.TabIndex = 0;
            this.txtBoxEAN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxEAN_KeyDown);
            this.txtBoxEAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxEAN_KeyPress);
            // 
            // btnCancelSale
            // 
            this.btnCancelSale.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancelSale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelSale.Enabled = false;
            this.btnCancelSale.FlatAppearance.BorderColor = System.Drawing.Color.LightCoral;
            this.btnCancelSale.FlatAppearance.BorderSize = 0;
            this.btnCancelSale.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancelSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelSale.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelSale.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelSale.Image")));
            this.btnCancelSale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelSale.Location = new System.Drawing.Point(628, 112);
            this.btnCancelSale.Name = "btnCancelSale";
            this.btnCancelSale.Size = new System.Drawing.Size(138, 37);
            this.btnCancelSale.TabIndex = 8;
            this.btnCancelSale.Text = "(F6) Cancel Sale";
            this.btnCancelSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelSale.UseVisualStyleBackColor = false;
            this.btnCancelSale.Click += new System.EventHandler(this.btnCancelSale_Click);
            // 
            // btnParkSale
            // 
            this.btnParkSale.BackColor = System.Drawing.Color.PaleGreen;
            this.btnParkSale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnParkSale.FlatAppearance.BorderColor = System.Drawing.Color.PaleGreen;
            this.btnParkSale.FlatAppearance.BorderSize = 0;
            this.btnParkSale.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnParkSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParkSale.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnParkSale.Image = ((System.Drawing.Image)(resources.GetObject("btnParkSale.Image")));
            this.btnParkSale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParkSale.Location = new System.Drawing.Point(768, 112);
            this.btnParkSale.Name = "btnParkSale";
            this.btnParkSale.Size = new System.Drawing.Size(123, 37);
            this.btnParkSale.TabIndex = 9;
            this.btnParkSale.Text = "(F7) Park Sale";
            this.btnParkSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnParkSale.UseVisualStyleBackColor = false;
            this.btnParkSale.Click += new System.EventHandler(this.btnParkSale_Click);
            // 
            // btnCheckout
            // 
            this.btnCheckout.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckout.Enabled = false;
            this.btnCheckout.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            this.btnCheckout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckout.Image")));
            this.btnCheckout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckout.Location = new System.Drawing.Point(893, 112);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(124, 37);
            this.btnCheckout.TabIndex = 10;
            this.btnCheckout.Text = "(F8) Checkout";
            this.btnCheckout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // btnVoid
            // 
            this.btnVoid.BackColor = System.Drawing.Color.PowderBlue;
            this.btnVoid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoid.Enabled = false;
            this.btnVoid.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btnVoid.FlatAppearance.BorderSize = 0;
            this.btnVoid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnVoid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoid.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnVoid.Image = ((System.Drawing.Image)(resources.GetObject("btnVoid.Image")));
            this.btnVoid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoid.Location = new System.Drawing.Point(436, 112);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(96, 37);
            this.btnVoid.TabIndex = 6;
            this.btnVoid.Text = "(F4) Void";
            this.btnVoid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVoid.UseVisualStyleBackColor = false;
            this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.LightCyan;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(534, 112);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(92, 37);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "(F5) Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnWholesale
            // 
            this.btnWholesale.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnWholesale.Enabled = false;
            this.btnWholesale.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btnWholesale.FlatAppearance.BorderSize = 0;
            this.btnWholesale.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnWholesale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWholesale.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWholesale.ForeColor = System.Drawing.Color.Black;
            this.btnWholesale.Image = ((System.Drawing.Image)(resources.GetObject("btnWholesale.Image")));
            this.btnWholesale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWholesale.Location = new System.Drawing.Point(298, 112);
            this.btnWholesale.Name = "btnWholesale";
            this.btnWholesale.Size = new System.Drawing.Size(136, 37);
            this.btnWholesale.TabIndex = 5;
            this.btnWholesale.Text = "(F3) Wholesale";
            this.btnWholesale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWholesale.UseVisualStyleBackColor = false;
            this.btnWholesale.Click += new System.EventHandler(this.btnWholesale_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.MidnightBlue;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 564);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(297, 29);
            this.label5.TabIndex = 24;
            this.label5.Text = "Total Amount";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.MidnightBlue;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 642);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(297, 30);
            this.label6.TabIndex = 26;
            this.label6.Text = "Change Due";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.BackColor = System.Drawing.Color.Black;
            this.lblTotalAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalAmount.Font = new System.Drawing.Font("Courier New", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Lime;
            this.lblTotalAmount.Location = new System.Drawing.Point(0, 593);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(297, 49);
            this.lblTotalAmount.TabIndex = 25;
            this.lblTotalAmount.Text = "0.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChangeDue
            // 
            this.lblChangeDue.BackColor = System.Drawing.Color.Black;
            this.lblChangeDue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblChangeDue.Font = new System.Drawing.Font("Courier New", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeDue.ForeColor = System.Drawing.Color.Lime;
            this.lblChangeDue.Location = new System.Drawing.Point(0, 672);
            this.lblChangeDue.Name = "lblChangeDue";
            this.lblChangeDue.Size = new System.Drawing.Size(297, 49);
            this.lblChangeDue.TabIndex = 27;
            this.lblChangeDue.Text = "0.00";
            this.lblChangeDue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVatable
            // 
            this.lblVatable.BackColor = System.Drawing.Color.Black;
            this.lblVatable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblVatable.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVatable.ForeColor = System.Drawing.Color.Lime;
            this.lblVatable.Location = new System.Drawing.Point(0, 458);
            this.lblVatable.Name = "lblVatable";
            this.lblVatable.Size = new System.Drawing.Size(91, 26);
            this.lblVatable.TabIndex = 21;
            this.lblVatable.Text = "0.00";
            this.lblVatable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.MidnightBlue;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 429);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 29);
            this.label4.TabIndex = 20;
            this.label4.Text = "VATable";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTax
            // 
            this.lblTax.BackColor = System.Drawing.Color.Black;
            this.lblTax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTax.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.ForeColor = System.Drawing.Color.Lime;
            this.lblTax.Location = new System.Drawing.Point(0, 526);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(143, 26);
            this.lblTax.TabIndex = 23;
            this.lblTax.Text = "0%";
            this.lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.MidnightBlue;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 497);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 29);
            this.label9.TabIndex = 22;
            this.label9.Text = "Tax";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Crimson;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1144, 112);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 37);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "(F10) Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblUserAccount
            // 
            this.lblUserAccount.BackColor = System.Drawing.Color.Black;
            this.lblUserAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUserAccount.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserAccount.ForeColor = System.Drawing.Color.Gold;
            this.lblUserAccount.Location = new System.Drawing.Point(0, 390);
            this.lblUserAccount.Name = "lblUserAccount";
            this.lblUserAccount.Size = new System.Drawing.Size(297, 26);
            this.lblUserAccount.TabIndex = 19;
            this.lblUserAccount.Text = "Username";
            this.lblUserAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.MidnightBlue;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(0, 361);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(297, 29);
            this.label11.TabIndex = 18;
            this.label11.Text = "User";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Black;
            this.lblDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDate.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(0, 243);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(297, 26);
            this.lblDate.TabIndex = 14;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.Black;
            this.lblTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTime.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(0, 269);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(297, 26);
            this.lblTime.TabIndex = 15;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblSeriesNo
            // 
            this.lblSeriesNo.BackColor = System.Drawing.Color.Black;
            this.lblSeriesNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSeriesNo.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeriesNo.ForeColor = System.Drawing.Color.Red;
            this.lblSeriesNo.Location = new System.Drawing.Point(0, 329);
            this.lblSeriesNo.Name = "lblSeriesNo";
            this.lblSeriesNo.Size = new System.Drawing.Size(297, 26);
            this.lblSeriesNo.TabIndex = 17;
            this.lblSeriesNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.MidnightBlue;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(0, 300);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(297, 29);
            this.label13.TabIndex = 16;
            this.label13.Text = "No";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDiscount
            // 
            this.btnDiscount.BackColor = System.Drawing.Color.Tomato;
            this.btnDiscount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiscount.Enabled = false;
            this.btnDiscount.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.btnDiscount.FlatAppearance.BorderSize = 0;
            this.btnDiscount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PeachPuff;
            this.btnDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscount.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnDiscount.Image = ((System.Drawing.Image)(resources.GetObject("btnDiscount.Image")));
            this.btnDiscount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiscount.Location = new System.Drawing.Point(1019, 112);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(123, 37);
            this.btnDiscount.TabIndex = 11;
            this.btnDiscount.Text = "(F9) Discount";
            this.btnDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDiscount.UseVisualStyleBackColor = false;
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // lblProgversion
            // 
            this.lblProgversion.AutoSize = true;
            this.lblProgversion.BackColor = System.Drawing.Color.Transparent;
            this.lblProgversion.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgversion.ForeColor = System.Drawing.Color.Black;
            this.lblProgversion.Location = new System.Drawing.Point(2, 721);
            this.lblProgversion.Name = "lblProgversion";
            this.lblProgversion.Size = new System.Drawing.Size(108, 15);
            this.lblProgversion.TabIndex = 33;
            this.lblProgversion.Text = "nPOS System vX.x.x.x";
            // 
            // btnRefund
            // 
            this.btnRefund.BackColor = System.Drawing.Color.Moccasin;
            this.btnRefund.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefund.FlatAppearance.BorderColor = System.Drawing.Color.Moccasin;
            this.btnRefund.FlatAppearance.BorderSize = 0;
            this.btnRefund.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnRefund.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefund.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefund.Image = ((System.Drawing.Image)(resources.GetObject("btnRefund.Image")));
            this.btnRefund.Location = new System.Drawing.Point(150, 111);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(147, 89);
            this.btnRefund.TabIndex = 4;
            this.btnRefund.Text = "(F2) Refund";
            this.btnRefund.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefund.UseVisualStyleBackColor = false;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.GhostWhite;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Enabled = false;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(1, 111);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(149, 89);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "(F1) Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // proceed
            // 
            this.proceed.BackColor = System.Drawing.Color.White;
            this.proceed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.proceed.Font = new System.Drawing.Font("Courier New", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proceed.Location = new System.Drawing.Point(486, 394);
            this.proceed.Name = "proceed";
            this.proceed.Size = new System.Drawing.Size(613, 116);
            this.proceed.TabIndex = 32;
            this.proceed.Text = "Press F12 to Proceed";
            this.proceed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVATe
            // 
            this.lblVATe.BackColor = System.Drawing.Color.Black;
            this.lblVATe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblVATe.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVATe.ForeColor = System.Drawing.Color.Lime;
            this.lblVATe.Location = new System.Drawing.Point(91, 458);
            this.lblVATe.Name = "lblVATe";
            this.lblVATe.Size = new System.Drawing.Size(110, 26);
            this.lblVATe.TabIndex = 35;
            this.lblVATe.Text = "0.00";
            this.lblVATe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.MidnightBlue;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(91, 429);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 29);
            this.label3.TabIndex = 34;
            this.label3.Text = "VAT Exempt";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVATz
            // 
            this.lblVATz.BackColor = System.Drawing.Color.Black;
            this.lblVATz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblVATz.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVATz.ForeColor = System.Drawing.Color.Lime;
            this.lblVATz.Location = new System.Drawing.Point(201, 458);
            this.lblVATz.Name = "lblVATz";
            this.lblVATz.Size = new System.Drawing.Size(96, 26);
            this.lblVATz.TabIndex = 37;
            this.lblVATz.Text = "0.00";
            this.lblVATz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.MidnightBlue;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(201, 429);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 29);
            this.label8.TabIndex = 36;
            this.label8.Text = "VAT Z-Rated";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTAXamt
            // 
            this.lblTAXamt.BackColor = System.Drawing.Color.Black;
            this.lblTAXamt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTAXamt.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTAXamt.ForeColor = System.Drawing.Color.Lime;
            this.lblTAXamt.Location = new System.Drawing.Point(143, 526);
            this.lblTAXamt.Name = "lblTAXamt";
            this.lblTAXamt.Size = new System.Drawing.Size(154, 26);
            this.lblTAXamt.TabIndex = 39;
            this.lblTAXamt.Text = "0.00";
            this.lblTAXamt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.MidnightBlue;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(144, 497);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(153, 29);
            this.label12.TabIndex = 38;
            this.label12.Text = "TAX Amount";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "EAN";
            this.columnHeader1.Width = 172;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Qty";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 54;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 349;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Price";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 114;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Discount";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 97;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Total";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 133;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "*";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 34;
            // 
            // lviewPOS
            // 
            this.lviewPOS.BackColor = System.Drawing.Color.White;
            this.lviewPOS.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lviewPOS.BackgroundImage")));
            this.lviewPOS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lviewPOS.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lviewPOS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lviewPOS.FullRowSelect = true;
            this.lviewPOS.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lviewPOS.Location = new System.Drawing.Point(298, 156);
            this.lviewPOS.MultiSelect = false;
            this.lviewPOS.Name = "lviewPOS";
            this.lviewPOS.Size = new System.Drawing.Size(955, 565);
            this.lviewPOS.TabIndex = 13;
            this.lviewPOS.UseCompatibleStateImageBehavior = false;
            this.lviewPOS.View = System.Windows.Forms.View.Details;
            this.lviewPOS.SelectedIndexChanged += new System.EventHandler(this.lviewPOS_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(298, 725);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(955, 15);
            this.label2.TabIndex = 40;
            this.label2.Text = "Q - Go to Quantity | A - Go to EAN  | S - Go To List | W - Cash Controller | [O] " +
    "- Open Cash Drawer | N - No Sale";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRetail
            // 
            this.btnRetail.BackColor = System.Drawing.Color.Plum;
            this.btnRetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetail.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btnRetail.FlatAppearance.BorderSize = 0;
            this.btnRetail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetail.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetail.ForeColor = System.Drawing.Color.Black;
            this.btnRetail.Image = ((System.Drawing.Image)(resources.GetObject("btnRetail.Image")));
            this.btnRetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRetail.Location = new System.Drawing.Point(298, 112);
            this.btnRetail.Name = "btnRetail";
            this.btnRetail.Size = new System.Drawing.Size(136, 37);
            this.btnRetail.TabIndex = 42;
            this.btnRetail.Text = "(F3) Retail Trans";
            this.btnRetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRetail.UseVisualStyleBackColor = false;
            this.btnRetail.Visible = false;
            this.btnRetail.Click += new System.EventHandler(this.btnRetail_Click);
            // 
            // frmPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1274, 748);
            this.ControlBox = false;
            this.Controls.Add(this.btnRetail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTAXamt);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblVATz);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblVATe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.proceed);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRefund);
            this.Controls.Add(this.lblProgversion);
            this.Controls.Add(this.btnDiscount);
            this.Controls.Add(this.lblSeriesNo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblUserAccount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblVatable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblChangeDue);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnWholesale);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnVoid);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.btnParkSale);
            this.Controls.Add(this.btnCancelSale);
            this.Controls.Add(this.txtBoxEAN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdTotal);
            this.Controls.Add(this.rdPrice);
            this.Controls.Add(this.txtBoxQty);
            this.Controls.Add(this.rdDescription);
            this.Controls.Add(this.lviewPOS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPOS";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPOS_FormClosing);
            this.Load += new System.EventHandler(this.frmPOS_Load);
            this.Click += new System.EventHandler(this.frmPOS_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rdDescription;
        private System.Windows.Forms.TextBox txtBoxQty;
        private System.Windows.Forms.TextBox rdPrice;
        private System.Windows.Forms.TextBox rdTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxEAN;
        private System.Windows.Forms.Button btnParkSale;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnVoid;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnWholesale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblChangeDue;
        private System.Windows.Forms.Label lblVatable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblUserAccount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblSeriesNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnCancelSale;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.Label lblProgversion;
        private System.Windows.Forms.Button btnRefund;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label proceed;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lblVATe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblVATz;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTAXamt;
        private System.Windows.Forms.Label label12;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ListView lviewPOS;
        private System.Drawing.Printing.PrintDocument printDocument2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRetail;
    }
}