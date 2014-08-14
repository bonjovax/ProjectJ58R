namespace nPOSProj
{
    partial class frmDlgCheckout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDlgCheckout));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxTender = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pMaster = new System.Windows.Forms.PictureBox();
            this.pVisa = new System.Windows.Forms.PictureBox();
            this.mskCC = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalAmountDC = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblRefNo = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBoxBankNBranch = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBoxCheckNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotalAmountBC = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnAProceed = new System.Windows.Forms.Button();
            this.txtBoxCompany = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBoxCustCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalAmountAR = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnProceed = new System.Windows.Forms.Button();
            this.lblNotif = new System.Windows.Forms.Label();
            this.txtBoxGCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalAmountGC = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pVisa)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(503, 261);
            this.tabControl1.TabIndex = 55;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Black;
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtBoxTender);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lblTotalAmount);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(495, 223);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cash";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.MidnightBlue;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Courier New", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(495, 40);
            this.label5.TabIndex = 15;
            this.label5.Text = "Total Amount";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBoxTender
            // 
            this.txtBoxTender.BackColor = System.Drawing.Color.Black;
            this.txtBoxTender.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxTender.Font = new System.Drawing.Font("Courier New", 51.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxTender.ForeColor = System.Drawing.Color.Lime;
            this.txtBoxTender.Location = new System.Drawing.Point(0, 147);
            this.txtBoxTender.MaxLength = 10;
            this.txtBoxTender.Name = "txtBoxTender";
            this.txtBoxTender.ShortcutsEnabled = false;
            this.txtBoxTender.Size = new System.Drawing.Size(495, 79);
            this.txtBoxTender.TabIndex = 0;
            this.txtBoxTender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxTender.TextChanged += new System.EventHandler(this.txtBoxTender_TextChanged);
            this.txtBoxTender.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxTender_KeyDown);
            this.txtBoxTender.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxTender_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.MidnightBlue;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Courier New", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(495, 40);
            this.label1.TabIndex = 17;
            this.label1.Text = "Amount Tender";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.BackColor = System.Drawing.Color.Black;
            this.lblTotalAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalAmount.Font = new System.Drawing.Font("Courier New", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Lime;
            this.lblTotalAmount.Location = new System.Drawing.Point(0, 41);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(495, 66);
            this.lblTotalAmount.TabIndex = 16;
            this.lblTotalAmount.Text = "0.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Black;
            this.tabPage2.Controls.Add(this.pMaster);
            this.tabPage2.Controls.Add(this.pVisa);
            this.tabPage2.Controls.Add(this.mskCC);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.lblTotalAmountDC);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(496, 223);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Debit/Credit Card";
            // 
            // pMaster
            // 
            this.pMaster.Image = ((System.Drawing.Image)(resources.GetObject("pMaster.Image")));
            this.pMaster.Location = new System.Drawing.Point(426, 139);
            this.pMaster.Name = "pMaster";
            this.pMaster.Size = new System.Drawing.Size(56, 32);
            this.pMaster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pMaster.TabIndex = 38;
            this.pMaster.TabStop = false;
            this.pMaster.Visible = false;
            // 
            // pVisa
            // 
            this.pVisa.Image = ((System.Drawing.Image)(resources.GetObject("pVisa.Image")));
            this.pVisa.Location = new System.Drawing.Point(417, 143);
            this.pVisa.Name = "pVisa";
            this.pVisa.Size = new System.Drawing.Size(73, 25);
            this.pVisa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pVisa.TabIndex = 37;
            this.pVisa.TabStop = false;
            this.pVisa.Visible = false;
            // 
            // mskCC
            // 
            this.mskCC.BackColor = System.Drawing.Color.Black;
            this.mskCC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mskCC.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskCC.ForeColor = System.Drawing.Color.Lime;
            this.mskCC.Location = new System.Drawing.Point(0, 136);
            this.mskCC.Mask = "0000 0000 0000 0000";
            this.mskCC.Name = "mskCC";
            this.mskCC.ShortcutsEnabled = false;
            this.mskCC.Size = new System.Drawing.Size(495, 33);
            this.mskCC.TabIndex = 1;
            this.mskCC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskCC.TextChanged += new System.EventHandler(this.mskCC_TextChanged);
            this.mskCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskCC_KeyDown);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.MidnightBlue;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(495, 29);
            this.label9.TabIndex = 20;
            this.label9.Text = "Card No";
            // 
            // lblTotalAmountDC
            // 
            this.lblTotalAmountDC.BackColor = System.Drawing.Color.Black;
            this.lblTotalAmountDC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalAmountDC.Font = new System.Drawing.Font("Courier New", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmountDC.ForeColor = System.Drawing.Color.Lime;
            this.lblTotalAmountDC.Location = new System.Drawing.Point(0, 41);
            this.lblTotalAmountDC.Name = "lblTotalAmountDC";
            this.lblTotalAmountDC.Size = new System.Drawing.Size(495, 66);
            this.lblTotalAmountDC.TabIndex = 19;
            this.lblTotalAmountDC.Text = "0.00";
            this.lblTotalAmountDC.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.MidnightBlue;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Courier New", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(495, 40);
            this.label3.TabIndex = 18;
            this.label3.Text = "Total Amount";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Black;
            this.tabPage3.Controls.Add(this.lblRefNo);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.txtBoxBankNBranch);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.txtBoxCheckNo);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.lblTotalAmountBC);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(496, 223);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Bank Cheque";
            // 
            // lblRefNo
            // 
            this.lblRefNo.BackColor = System.Drawing.Color.Black;
            this.lblRefNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRefNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRefNo.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefNo.ForeColor = System.Drawing.Color.Lime;
            this.lblRefNo.Location = new System.Drawing.Point(193, 197);
            this.lblRefNo.Name = "lblRefNo";
            this.lblRefNo.Size = new System.Drawing.Size(301, 25);
            this.lblRefNo.TabIndex = 5;
            this.lblRefNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.MidnightBlue;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(0, 197);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(193, 25);
            this.label12.TabIndex = 25;
            this.label12.Text = "Reference Code";
            // 
            // txtBoxBankNBranch
            // 
            this.txtBoxBankNBranch.BackColor = System.Drawing.Color.Black;
            this.txtBoxBankNBranch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxBankNBranch.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxBankNBranch.ForeColor = System.Drawing.Color.Lime;
            this.txtBoxBankNBranch.Location = new System.Drawing.Point(1, 173);
            this.txtBoxBankNBranch.MaxLength = 35;
            this.txtBoxBankNBranch.Name = "txtBoxBankNBranch";
            this.txtBoxBankNBranch.ShortcutsEnabled = false;
            this.txtBoxBankNBranch.Size = new System.Drawing.Size(494, 24);
            this.txtBoxBankNBranch.TabIndex = 4;
            this.txtBoxBankNBranch.TextChanged += new System.EventHandler(this.txtBoxBankNBranch_TextChanged);
            this.txtBoxBankNBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxBankNBranch_KeyDown);
            this.txtBoxBankNBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxBankNBranch_KeyPress);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.MidnightBlue;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(0, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(495, 21);
            this.label11.TabIndex = 24;
            this.label11.Text = "Bank and Branch";
            // 
            // txtBoxCheckNo
            // 
            this.txtBoxCheckNo.BackColor = System.Drawing.Color.Black;
            this.txtBoxCheckNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxCheckNo.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxCheckNo.ForeColor = System.Drawing.Color.Lime;
            this.txtBoxCheckNo.Location = new System.Drawing.Point(1, 128);
            this.txtBoxCheckNo.MaxLength = 15;
            this.txtBoxCheckNo.Name = "txtBoxCheckNo";
            this.txtBoxCheckNo.ShortcutsEnabled = false;
            this.txtBoxCheckNo.Size = new System.Drawing.Size(494, 24);
            this.txtBoxCheckNo.TabIndex = 3;
            this.txtBoxCheckNo.TextChanged += new System.EventHandler(this.txtBoxCheckNo_TextChanged);
            this.txtBoxCheckNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxCheckNo_KeyDown);
            this.txtBoxCheckNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxCheckNo_KeyPress);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.MidnightBlue;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(0, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(495, 21);
            this.label10.TabIndex = 23;
            this.label10.Text = "Check No";
            // 
            // lblTotalAmountBC
            // 
            this.lblTotalAmountBC.BackColor = System.Drawing.Color.Black;
            this.lblTotalAmountBC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalAmountBC.Font = new System.Drawing.Font("Courier New", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmountBC.ForeColor = System.Drawing.Color.Lime;
            this.lblTotalAmountBC.Location = new System.Drawing.Point(0, 41);
            this.lblTotalAmountBC.Name = "lblTotalAmountBC";
            this.lblTotalAmountBC.Size = new System.Drawing.Size(495, 66);
            this.lblTotalAmountBC.TabIndex = 22;
            this.lblTotalAmountBC.Text = "0.00";
            this.lblTotalAmountBC.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.MidnightBlue;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Courier New", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(495, 40);
            this.label6.TabIndex = 21;
            this.label6.Text = "Total Amount";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Black;
            this.tabPage4.Controls.Add(this.btnAProceed);
            this.tabPage4.Controls.Add(this.txtBoxCompany);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.txtBoxCustCode);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.lblTotalAmountAR);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.ImageIndex = 3;
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage4.Size = new System.Drawing.Size(496, 223);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Accounts";
            // 
            // btnAProceed
            // 
            this.btnAProceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAProceed.ForeColor = System.Drawing.Color.White;
            this.btnAProceed.Location = new System.Drawing.Point(2, 200);
            this.btnAProceed.Name = "btnAProceed";
            this.btnAProceed.Size = new System.Drawing.Size(491, 22);
            this.btnAProceed.TabIndex = 34;
            this.btnAProceed.Text = "Proceed";
            this.btnAProceed.UseVisualStyleBackColor = true;
            this.btnAProceed.Visible = false;
            this.btnAProceed.Click += new System.EventHandler(this.btnAProceed_Click);
            // 
            // txtBoxCompany
            // 
            this.txtBoxCompany.BackColor = System.Drawing.Color.Black;
            this.txtBoxCompany.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxCompany.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxCompany.ForeColor = System.Drawing.Color.Lime;
            this.txtBoxCompany.Location = new System.Drawing.Point(1, 175);
            this.txtBoxCompany.MaxLength = 35;
            this.txtBoxCompany.Name = "txtBoxCompany";
            this.txtBoxCompany.ShortcutsEnabled = false;
            this.txtBoxCompany.Size = new System.Drawing.Size(494, 24);
            this.txtBoxCompany.TabIndex = 30;
            this.txtBoxCompany.TextChanged += new System.EventHandler(this.txtBoxCompany_TextChanged);
            this.txtBoxCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxCompany_KeyDown);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.MidnightBlue;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(0, 154);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(495, 21);
            this.label13.TabIndex = 31;
            this.label13.Text = "Company";
            // 
            // txtBoxCustCode
            // 
            this.txtBoxCustCode.BackColor = System.Drawing.Color.Black;
            this.txtBoxCustCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxCustCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBoxCustCode.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxCustCode.ForeColor = System.Drawing.Color.Lime;
            this.txtBoxCustCode.Location = new System.Drawing.Point(1, 128);
            this.txtBoxCustCode.MaxLength = 35;
            this.txtBoxCustCode.Name = "txtBoxCustCode";
            this.txtBoxCustCode.ShortcutsEnabled = false;
            this.txtBoxCustCode.Size = new System.Drawing.Size(494, 24);
            this.txtBoxCustCode.TabIndex = 28;
            this.txtBoxCustCode.TextChanged += new System.EventHandler(this.txtBoxCustCode_TextChanged);
            this.txtBoxCustCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxCustCode_KeyDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.MidnightBlue;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(495, 21);
            this.label2.TabIndex = 29;
            this.label2.Text = "Customer Code";
            // 
            // lblTotalAmountAR
            // 
            this.lblTotalAmountAR.BackColor = System.Drawing.Color.Black;
            this.lblTotalAmountAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalAmountAR.Font = new System.Drawing.Font("Courier New", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmountAR.ForeColor = System.Drawing.Color.Lime;
            this.lblTotalAmountAR.Location = new System.Drawing.Point(0, 41);
            this.lblTotalAmountAR.Name = "lblTotalAmountAR";
            this.lblTotalAmountAR.Size = new System.Drawing.Size(495, 66);
            this.lblTotalAmountAR.TabIndex = 27;
            this.lblTotalAmountAR.Text = "0.00";
            this.lblTotalAmountAR.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.MidnightBlue;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Courier New", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(495, 40);
            this.label8.TabIndex = 26;
            this.label8.Text = "Total Amount";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.Black;
            this.tabPage5.Controls.Add(this.btnProceed);
            this.tabPage5.Controls.Add(this.lblNotif);
            this.tabPage5.Controls.Add(this.txtBoxGCode);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.lblTotalAmountGC);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.ImageIndex = 4;
            this.tabPage5.Location = new System.Drawing.Point(4, 34);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(496, 223);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Gift Card";
            // 
            // btnProceed
            // 
            this.btnProceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProceed.ForeColor = System.Drawing.Color.White;
            this.btnProceed.Location = new System.Drawing.Point(1, 189);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(491, 32);
            this.btnProceed.TabIndex = 33;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Visible = false;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // lblNotif
            // 
            this.lblNotif.BackColor = System.Drawing.Color.Black;
            this.lblNotif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNotif.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotif.ForeColor = System.Drawing.Color.Red;
            this.lblNotif.Location = new System.Drawing.Point(0, 160);
            this.lblNotif.Name = "lblNotif";
            this.lblNotif.Size = new System.Drawing.Size(492, 26);
            this.lblNotif.TabIndex = 32;
            this.lblNotif.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtBoxGCode
            // 
            this.txtBoxGCode.BackColor = System.Drawing.Color.Black;
            this.txtBoxGCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxGCode.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxGCode.ForeColor = System.Drawing.Color.Lime;
            this.txtBoxGCode.Location = new System.Drawing.Point(1, 127);
            this.txtBoxGCode.MaxLength = 38;
            this.txtBoxGCode.Name = "txtBoxGCode";
            this.txtBoxGCode.ShortcutsEnabled = false;
            this.txtBoxGCode.Size = new System.Drawing.Size(494, 24);
            this.txtBoxGCode.TabIndex = 30;
            this.txtBoxGCode.TextChanged += new System.EventHandler(this.txtBoxGCode_TextChanged);
            this.txtBoxGCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxGCode_KeyDown);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.MidnightBlue;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(495, 21);
            this.label4.TabIndex = 31;
            this.label4.Text = "Gift Card No";
            // 
            // lblTotalAmountGC
            // 
            this.lblTotalAmountGC.BackColor = System.Drawing.Color.Black;
            this.lblTotalAmountGC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalAmountGC.Font = new System.Drawing.Font("Courier New", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmountGC.ForeColor = System.Drawing.Color.Lime;
            this.lblTotalAmountGC.Location = new System.Drawing.Point(0, 41);
            this.lblTotalAmountGC.Name = "lblTotalAmountGC";
            this.lblTotalAmountGC.Size = new System.Drawing.Size(495, 66);
            this.lblTotalAmountGC.TabIndex = 29;
            this.lblTotalAmountGC.Text = "0.00";
            this.lblTotalAmountGC.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.MidnightBlue;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Courier New", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(0, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(495, 40);
            this.label7.TabIndex = 28;
            this.label7.Text = "Total Amount";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "cash.png");
            this.imageList1.Images.SetKeyName(1, "creditcard.png");
            this.imageList1.Images.SetKeyName(2, "cheque.png");
            this.imageList1.Images.SetKeyName(3, "account.png");
            this.imageList1.Images.SetKeyName(4, "gift-card-icon.png");
            // 
            // frmDlgCheckout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(503, 261);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDlgCheckout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checkout";
            this.Load += new System.EventHandler(this.frmDlgCheckout_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pVisa)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtBoxTender;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalAmountDC;
        private System.Windows.Forms.Label lblTotalAmountBC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalAmountAR;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox mskCC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pMaster;
        private System.Windows.Forms.PictureBox pVisa;
        private System.Windows.Forms.Label lblRefNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBoxBankNBranch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBoxCheckNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label lblTotalAmountGC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBoxGCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNotif;
        private System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.TextBox txtBoxCompany;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBoxCustCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAProceed;
    }
}