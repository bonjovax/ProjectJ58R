﻿namespace nPOSProj
{
    partial class mdiQuotation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdiQuotation));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnF1 = new System.Windows.Forms.Button();
            this.btnESC = new System.Windows.Forms.Button();
            this.btnF5 = new System.Windows.Forms.Button();
            this.btnF4 = new System.Windows.Forms.Button();
            this.btnF3 = new System.Windows.Forms.Button();
            this.btnF2B = new System.Windows.Forms.Button();
            this.btnF2A = new System.Windows.Forms.Button();
            this.lblQN = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cBoxKits = new System.Windows.Forms.CheckBox();
            this.btnClearController = new System.Windows.Forms.Button();
            this.btnAddToQuote = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rdTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rdPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxQuantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxEAN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ean = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnF6 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdAddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rdCompany = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdCustomerCode = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnSendToOrder = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.rdQty = new System.Windows.Forms.TextBox();
            this.btnLink = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnF1
            // 
            this.btnF1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnF1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnF1.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF1.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF1.ForeColor = System.Drawing.Color.White;
            this.btnF1.Image = ((System.Drawing.Image)(resources.GetObject("btnF1.Image")));
            this.btnF1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnF1.Location = new System.Drawing.Point(0, -1);
            this.btnF1.Name = "btnF1";
            this.btnF1.Size = new System.Drawing.Size(143, 35);
            this.btnF1.TabIndex = 1;
            this.btnF1.Text = "(F1) New Quote";
            this.btnF1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnF1.UseVisualStyleBackColor = false;
            this.btnF1.Click += new System.EventHandler(this.btnF1_Click);
            // 
            // btnESC
            // 
            this.btnESC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnESC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnESC.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.btnESC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnESC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnESC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnESC.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnESC.ForeColor = System.Drawing.Color.White;
            this.btnESC.Image = ((System.Drawing.Image)(resources.GetObject("btnESC.Image")));
            this.btnESC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnESC.Location = new System.Drawing.Point(730, 0);
            this.btnESC.Name = "btnESC";
            this.btnESC.Size = new System.Drawing.Size(104, 34);
            this.btnESC.TabIndex = 7;
            this.btnESC.Text = "(Esc) Exit";
            this.btnESC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnESC.UseVisualStyleBackColor = false;
            this.btnESC.Click += new System.EventHandler(this.btnESC_Click);
            // 
            // btnF5
            // 
            this.btnF5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnF5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnF5.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF5.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF5.ForeColor = System.Drawing.Color.White;
            this.btnF5.Image = ((System.Drawing.Image)(resources.GetObject("btnF5.Image")));
            this.btnF5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnF5.Location = new System.Drawing.Point(582, 0);
            this.btnF5.Name = "btnF5";
            this.btnF5.Size = new System.Drawing.Size(148, 34);
            this.btnF5.TabIndex = 6;
            this.btnF5.Text = "(F5) Park Quote";
            this.btnF5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnF5.UseVisualStyleBackColor = false;
            this.btnF5.Click += new System.EventHandler(this.btnF5_Click);
            // 
            // btnF4
            // 
            this.btnF4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnF4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnF4.Enabled = false;
            this.btnF4.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF4.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF4.ForeColor = System.Drawing.Color.White;
            this.btnF4.Image = ((System.Drawing.Image)(resources.GetObject("btnF4.Image")));
            this.btnF4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnF4.Location = new System.Drawing.Point(424, 0);
            this.btnF4.Name = "btnF4";
            this.btnF4.Size = new System.Drawing.Size(158, 34);
            this.btnF4.TabIndex = 5;
            this.btnF4.Text = "(F4) Cancel Quote";
            this.btnF4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnF4.UseVisualStyleBackColor = false;
            this.btnF4.Click += new System.EventHandler(this.btnF4_Click);
            // 
            // btnF3
            // 
            this.btnF3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnF3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnF3.Enabled = false;
            this.btnF3.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF3.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF3.ForeColor = System.Drawing.Color.White;
            this.btnF3.Image = ((System.Drawing.Image)(resources.GetObject("btnF3.Image")));
            this.btnF3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnF3.Location = new System.Drawing.Point(286, 0);
            this.btnF3.Name = "btnF3";
            this.btnF3.Size = new System.Drawing.Size(138, 34);
            this.btnF3.TabIndex = 4;
            this.btnF3.Text = "(F3) Void Item";
            this.btnF3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnF3.UseVisualStyleBackColor = false;
            this.btnF3.Click += new System.EventHandler(this.btnF3_Click);
            // 
            // btnF2B
            // 
            this.btnF2B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnF2B.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnF2B.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF2B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF2B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF2B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF2B.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF2B.ForeColor = System.Drawing.Color.White;
            this.btnF2B.Image = ((System.Drawing.Image)(resources.GetObject("btnF2B.Image")));
            this.btnF2B.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnF2B.Location = new System.Drawing.Point(143, 0);
            this.btnF2B.Name = "btnF2B";
            this.btnF2B.Size = new System.Drawing.Size(143, 34);
            this.btnF2B.TabIndex = 2;
            this.btnF2B.Text = "(F2) Retail Tran";
            this.btnF2B.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnF2B.UseVisualStyleBackColor = false;
            this.btnF2B.Visible = false;
            this.btnF2B.Click += new System.EventHandler(this.btnF2B_Click);
            // 
            // btnF2A
            // 
            this.btnF2A.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnF2A.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnF2A.Enabled = false;
            this.btnF2A.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF2A.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF2A.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF2A.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF2A.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF2A.ForeColor = System.Drawing.Color.White;
            this.btnF2A.Image = ((System.Drawing.Image)(resources.GetObject("btnF2A.Image")));
            this.btnF2A.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnF2A.Location = new System.Drawing.Point(143, 0);
            this.btnF2A.Name = "btnF2A";
            this.btnF2A.Size = new System.Drawing.Size(143, 34);
            this.btnF2A.TabIndex = 3;
            this.btnF2A.Text = "(F2) Wholesale";
            this.btnF2A.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnF2A.UseVisualStyleBackColor = false;
            this.btnF2A.Click += new System.EventHandler(this.btnF2A_Click);
            // 
            // lblQN
            // 
            this.lblQN.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQN.ForeColor = System.Drawing.Color.Red;
            this.lblQN.Location = new System.Drawing.Point(89, 44);
            this.lblQN.Name = "lblQN";
            this.lblQN.Size = new System.Drawing.Size(147, 23);
            this.lblQN.TabIndex = 24;
            this.lblQN.Text = "0";
            this.lblQN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 21);
            this.label1.TabIndex = 23;
            this.label1.Text = "Quote No.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBoxKits);
            this.groupBox1.Controls.Add(this.btnClearController);
            this.groupBox1.Controls.Add(this.btnAddToQuote);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.rdTotal);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.rdPrice);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtBoxQuantity);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBoxDescription);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtBoxEAN);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(9, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(815, 126);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Controller";
            // 
            // cBoxKits
            // 
            this.cBoxKits.AutoSize = true;
            this.cBoxKits.Enabled = false;
            this.cBoxKits.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxKits.Location = new System.Drawing.Point(406, 91);
            this.cBoxKits.Name = "cBoxKits";
            this.cBoxKits.Size = new System.Drawing.Size(82, 21);
            this.cBoxKits.TabIndex = 16;
            this.cBoxKits.Text = "Kit Select";
            this.cBoxKits.UseVisualStyleBackColor = true;
            this.cBoxKits.CheckedChanged += new System.EventHandler(this.cBoxKits_CheckedChanged);
            // 
            // btnClearController
            // 
            this.btnClearController.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnClearController.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearController.Enabled = false;
            this.btnClearController.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClearController.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClearController.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClearController.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearController.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearController.ForeColor = System.Drawing.Color.White;
            this.btnClearController.Image = ((System.Drawing.Image)(resources.GetObject("btnClearController.Image")));
            this.btnClearController.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearController.Location = new System.Drawing.Point(647, 77);
            this.btnClearController.Name = "btnClearController";
            this.btnClearController.Size = new System.Drawing.Size(148, 34);
            this.btnClearController.TabIndex = 18;
            this.btnClearController.Text = "Clear Controller";
            this.btnClearController.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearController.UseVisualStyleBackColor = false;
            this.btnClearController.Click += new System.EventHandler(this.btnClearController_Click);
            // 
            // btnAddToQuote
            // 
            this.btnAddToQuote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(169)))), ((int)(((byte)(23)))));
            this.btnAddToQuote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddToQuote.Enabled = false;
            this.btnAddToQuote.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.btnAddToQuote.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnAddToQuote.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnAddToQuote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToQuote.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToQuote.ForeColor = System.Drawing.Color.White;
            this.btnAddToQuote.Image = ((System.Drawing.Image)(resources.GetObject("btnAddToQuote.Image")));
            this.btnAddToQuote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddToQuote.Location = new System.Drawing.Point(500, 77);
            this.btnAddToQuote.Name = "btnAddToQuote";
            this.btnAddToQuote.Size = new System.Drawing.Size(142, 34);
            this.btnAddToQuote.TabIndex = 17;
            this.btnAddToQuote.Text = "Add to Quote";
            this.btnAddToQuote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddToQuote.UseVisualStyleBackColor = false;
            this.btnAddToQuote.Click += new System.EventHandler(this.btnAddToQuote_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(195, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 17);
            this.label9.TabIndex = 36;
            this.label9.Text = "=";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(83, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 17);
            this.label8.TabIndex = 35;
            this.label8.Text = "x";
            // 
            // rdTotal
            // 
            this.rdTotal.BackColor = System.Drawing.Color.Black;
            this.rdTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rdTotal.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTotal.ForeColor = System.Drawing.Color.Lime;
            this.rdTotal.Location = new System.Drawing.Point(214, 89);
            this.rdTotal.MaxLength = 10;
            this.rdTotal.Name = "rdTotal";
            this.rdTotal.ReadOnly = true;
            this.rdTotal.Size = new System.Drawing.Size(105, 22);
            this.rdTotal.TabIndex = 15;
            this.rdTotal.Text = "0.00";
            this.rdTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(211, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 34;
            this.label7.Text = "Total ";
            // 
            // rdPrice
            // 
            this.rdPrice.BackColor = System.Drawing.Color.Black;
            this.rdPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rdPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPrice.ForeColor = System.Drawing.Color.Lime;
            this.rdPrice.Location = new System.Drawing.Point(100, 89);
            this.rdPrice.MaxLength = 10;
            this.rdPrice.Name = "rdPrice";
            this.rdPrice.ReadOnly = true;
            this.rdPrice.Size = new System.Drawing.Size(93, 22);
            this.rdPrice.TabIndex = 14;
            this.rdPrice.Text = "0.00";
            this.rdPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(97, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 17);
            this.label6.TabIndex = 33;
            this.label6.Text = "Price";
            // 
            // txtBoxQuantity
            // 
            this.txtBoxQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxQuantity.Location = new System.Drawing.Point(22, 89);
            this.txtBoxQuantity.MaxLength = 5;
            this.txtBoxQuantity.Name = "txtBoxQuantity";
            this.txtBoxQuantity.ReadOnly = true;
            this.txtBoxQuantity.Size = new System.Drawing.Size(58, 22);
            this.txtBoxQuantity.TabIndex = 13;
            this.txtBoxQuantity.Text = "0";
            this.txtBoxQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxQuantity.TextChanged += new System.EventHandler(this.txtBoxQuantity_TextChanged);
            this.txtBoxQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxQuantity_KeyDown);
            this.txtBoxQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxQuantity_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 32;
            this.label5.Text = "Quantity";
            // 
            // txtBoxDescription
            // 
            this.txtBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxDescription.Location = new System.Drawing.Point(264, 42);
            this.txtBoxDescription.MaxLength = 75;
            this.txtBoxDescription.Name = "txtBoxDescription";
            this.txtBoxDescription.ReadOnly = true;
            this.txtBoxDescription.Size = new System.Drawing.Size(530, 22);
            this.txtBoxDescription.TabIndex = 12;
            this.txtBoxDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxDescription_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(261, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 31;
            this.label4.Text = "Description";
            // 
            // txtBoxEAN
            // 
            this.txtBoxEAN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxEAN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxEAN.Location = new System.Drawing.Point(22, 42);
            this.txtBoxEAN.MaxLength = 25;
            this.txtBoxEAN.Name = "txtBoxEAN";
            this.txtBoxEAN.ReadOnly = true;
            this.txtBoxEAN.Size = new System.Drawing.Size(231, 22);
            this.txtBoxEAN.TabIndex = 11;
            this.txtBoxEAN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxEAN_KeyDown);
            this.txtBoxEAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxEAN_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 30;
            this.label3.Text = "EAN";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Khaki;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkSlateBlue;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ean,
            this.quantity,
            this.description,
            this.price,
            this.total});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(10, 288);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(814, 261);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // ean
            // 
            this.ean.HeaderText = "EAN";
            this.ean.Name = "ean";
            this.ean.ReadOnly = true;
            this.ean.Width = 165;
            // 
            // quantity
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.quantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.quantity.HeaderText = "Quantity";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Width = 65;
            // 
            // description
            // 
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Width = 302;
            // 
            // price
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.price.DefaultCellStyle = dataGridViewCellStyle3;
            this.price.HeaderText = "Price";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 120;
            // 
            // total
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.total.DefaultCellStyle = dataGridViewCellStyle4;
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 120;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(709, 566);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(120, 23);
            this.lblTotal.TabIndex = 22;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(589, 568);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 21);
            this.label11.TabIndex = 21;
            this.label11.Text = "Total Amount";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnF6
            // 
            this.btnF6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnF6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnF6.Enabled = false;
            this.btnF6.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnF6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF6.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF6.ForeColor = System.Drawing.Color.White;
            this.btnF6.Image = ((System.Drawing.Image)(resources.GetObject("btnF6.Image")));
            this.btnF6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnF6.Location = new System.Drawing.Point(0, 564);
            this.btnF6.Name = "btnF6";
            this.btnF6.Size = new System.Drawing.Size(173, 34);
            this.btnF6.TabIndex = 20;
            this.btnF6.Text = "(F6) Print Quotation";
            this.btnF6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnF6.UseVisualStyleBackColor = false;
            this.btnF6.Click += new System.EventHandler(this.btnF6_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdAddress);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.rdCompany);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.rdCustomerCode);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(10, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(815, 78);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer Information";
            // 
            // rdAddress
            // 
            this.rdAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rdAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAddress.Location = new System.Drawing.Point(483, 42);
            this.rdAddress.MaxLength = 50;
            this.rdAddress.Name = "rdAddress";
            this.rdAddress.ReadOnly = true;
            this.rdAddress.Size = new System.Drawing.Size(314, 22);
            this.rdAddress.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(480, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 17);
            this.label10.TabIndex = 28;
            this.label10.Text = "Address";
            // 
            // rdCompany
            // 
            this.rdCompany.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rdCompany.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdCompany.Location = new System.Drawing.Point(139, 42);
            this.rdCompany.MaxLength = 30;
            this.rdCompany.Name = "rdCompany";
            this.rdCompany.ReadOnly = true;
            this.rdCompany.Size = new System.Drawing.Size(337, 22);
            this.rdCompany.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(136, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Company/Name";
            // 
            // rdCustomerCode
            // 
            this.rdCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rdCustomerCode.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdCustomerCode.Location = new System.Drawing.Point(9, 42);
            this.rdCustomerCode.MaxLength = 25;
            this.rdCustomerCode.Name = "rdCustomerCode";
            this.rdCustomerCode.ReadOnly = true;
            this.rdCustomerCode.Size = new System.Drawing.Size(122, 22);
            this.rdCustomerCode.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 17);
            this.label16.TabIndex = 26;
            this.label16.Text = "Customer Code";
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnDone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDone.Enabled = false;
            this.btnDone.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.btnDone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnDone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.ForeColor = System.Drawing.Color.White;
            this.btnDone.Image = ((System.Drawing.Image)(resources.GetObject("btnDone.Image")));
            this.btnDone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDone.Location = new System.Drawing.Point(173, 564);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(108, 34);
            this.btnDone.TabIndex = 35;
            this.btnDone.Text = "(F7) Done";
            this.btnDone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnSendToOrder
            // 
            this.btnSendToOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnSendToOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendToOrder.Enabled = false;
            this.btnSendToOrder.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSendToOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSendToOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSendToOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendToOrder.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendToOrder.ForeColor = System.Drawing.Color.White;
            this.btnSendToOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnSendToOrder.Image")));
            this.btnSendToOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendToOrder.Location = new System.Drawing.Point(281, 564);
            this.btnSendToOrder.Name = "btnSendToOrder";
            this.btnSendToOrder.Size = new System.Drawing.Size(178, 34);
            this.btnSendToOrder.TabIndex = 36;
            this.btnSendToOrder.Text = "(F8) Send to Order";
            this.btnSendToOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSendToOrder.UseVisualStyleBackColor = false;
            this.btnSendToOrder.Click += new System.EventHandler(this.btnSendToOrder_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(517, 557);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "Qty Available";
            // 
            // rdQty
            // 
            this.rdQty.BackColor = System.Drawing.Color.Black;
            this.rdQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rdQty.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdQty.ForeColor = System.Drawing.Color.Crimson;
            this.rdQty.Location = new System.Drawing.Point(520, 572);
            this.rdQty.MaxLength = 10;
            this.rdQty.Name = "rdQty";
            this.rdQty.ReadOnly = true;
            this.rdQty.Size = new System.Drawing.Size(66, 22);
            this.rdQty.TabIndex = 37;
            this.rdQty.Text = "0";
            this.rdQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLink
            // 
            this.btnLink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLink.Enabled = false;
            this.btnLink.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.btnLink.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnLink.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLink.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLink.ForeColor = System.Drawing.Color.White;
            this.btnLink.Image = ((System.Drawing.Image)(resources.GetObject("btnLink.Image")));
            this.btnLink.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLink.Location = new System.Drawing.Point(459, 564);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(58, 34);
            this.btnLink.TabIndex = 39;
            this.btnLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLink.UseVisualStyleBackColor = false;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // mdiQuotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(834, 599);
            this.ControlBox = false;
            this.Controls.Add(this.btnLink);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.rdQty);
            this.Controls.Add(this.btnSendToOrder);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnF6);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblQN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnF1);
            this.Controls.Add(this.btnESC);
            this.Controls.Add(this.btnF5);
            this.Controls.Add(this.btnF4);
            this.Controls.Add(this.btnF3);
            this.Controls.Add(this.btnF2B);
            this.Controls.Add(this.btnF2A);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "mdiQuotation";
            this.Text = "Quotation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnF1;
        private System.Windows.Forms.Button btnESC;
        private System.Windows.Forms.Button btnF5;
        private System.Windows.Forms.Button btnF4;
        private System.Windows.Forms.Button btnF3;
        private System.Windows.Forms.Button btnF2B;
        private System.Windows.Forms.Button btnF2A;
        private System.Windows.Forms.Label lblQN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cBoxKits;
        private System.Windows.Forms.Button btnClearController;
        private System.Windows.Forms.Button btnAddToQuote;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox rdTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox rdPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxEAN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ean;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnF6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox rdCompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rdCustomerCode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox rdAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnSendToOrder;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox rdQty;
        private System.Windows.Forms.Button btnLink;
    }
}