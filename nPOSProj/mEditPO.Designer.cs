namespace nPOSProj
{
    partial class mEditPO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mEditPO));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lAddress = new System.Windows.Forms.Label();
            this.txtBoxSupplierName = new System.Windows.Forms.TextBox();
            this.txtBoxSupplierCode = new System.Windows.Forms.TextBox();
            this.rdPOno = new System.Windows.Forms.TextBox();
            this.dt = new System.Windows.Forms.DateTimePicker();
            this.txtBoxRemarks = new System.Windows.Forms.TextBox();
            this.rdOrderedBy = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtBoxUQTY = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.rdTotal = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtBoxUnitPrice = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBoxUOM = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBoxQty = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBoxParticulars = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBoxStockCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cBoxCourier = new System.Windows.Forms.ComboBox();
            this.cBoxWarehouse = new System.Windows.Forms.ComboBox();
            this.inventorywarehouseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.npos_dbDataSet = new nPOSProj.npos_dbDataSet();
            this.inventory_warehouseTableAdapter = new nPOSProj.npos_dbDataSetTableAdapters.inventory_warehouseTableAdapter();
            this.dgQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventorywarehouseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npos_dbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(417, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Courier:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(417, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Warehouse:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(417, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Ordered by:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Remarks:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Supplier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "P.O No.:";
            // 
            // lAddress
            // 
            this.lAddress.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAddress.Location = new System.Drawing.Point(70, 61);
            this.lAddress.Name = "lAddress";
            this.lAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lAddress.Size = new System.Drawing.Size(543, 24);
            this.lAddress.TabIndex = 25;
            // 
            // txtBoxSupplierName
            // 
            this.txtBoxSupplierName.BackColor = System.Drawing.Color.White;
            this.txtBoxSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxSupplierName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSupplierName.Location = new System.Drawing.Point(210, 32);
            this.txtBoxSupplierName.MaxLength = 100;
            this.txtBoxSupplierName.Name = "txtBoxSupplierName";
            this.txtBoxSupplierName.ReadOnly = true;
            this.txtBoxSupplierName.Size = new System.Drawing.Size(317, 22);
            this.txtBoxSupplierName.TabIndex = 23;
            // 
            // txtBoxSupplierCode
            // 
            this.txtBoxSupplierCode.BackColor = System.Drawing.Color.White;
            this.txtBoxSupplierCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxSupplierCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSupplierCode.Location = new System.Drawing.Point(70, 32);
            this.txtBoxSupplierCode.MaxLength = 9;
            this.txtBoxSupplierCode.Name = "txtBoxSupplierCode";
            this.txtBoxSupplierCode.ReadOnly = true;
            this.txtBoxSupplierCode.Size = new System.Drawing.Size(136, 22);
            this.txtBoxSupplierCode.TabIndex = 22;
            this.txtBoxSupplierCode.TextChanged += new System.EventHandler(this.txtBoxSupplierCode_TextChanged);
            // 
            // rdPOno
            // 
            this.rdPOno.BackColor = System.Drawing.Color.Khaki;
            this.rdPOno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rdPOno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPOno.Location = new System.Drawing.Point(70, 6);
            this.rdPOno.MaxLength = 10;
            this.rdPOno.Name = "rdPOno";
            this.rdPOno.ReadOnly = true;
            this.rdPOno.Size = new System.Drawing.Size(100, 22);
            this.rdPOno.TabIndex = 26;
            this.rdPOno.TextChanged += new System.EventHandler(this.rdPOno_TextChanged);
            // 
            // dt
            // 
            this.dt.CustomFormat = "";
            this.dt.Enabled = false;
            this.dt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt.Location = new System.Drawing.Point(70, 92);
            this.dt.Name = "dt";
            this.dt.Size = new System.Drawing.Size(100, 27);
            this.dt.TabIndex = 27;
            // 
            // txtBoxRemarks
            // 
            this.txtBoxRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxRemarks.Location = new System.Drawing.Point(11, 146);
            this.txtBoxRemarks.Multiline = true;
            this.txtBoxRemarks.Name = "txtBoxRemarks";
            this.txtBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxRemarks.Size = new System.Drawing.Size(399, 79);
            this.txtBoxRemarks.TabIndex = 28;
            // 
            // rdOrderedBy
            // 
            this.rdOrderedBy.BackColor = System.Drawing.Color.Black;
            this.rdOrderedBy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rdOrderedBy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdOrderedBy.ForeColor = System.Drawing.Color.White;
            this.rdOrderedBy.Location = new System.Drawing.Point(497, 90);
            this.rdOrderedBy.MaxLength = 20;
            this.rdOrderedBy.Name = "rdOrderedBy";
            this.rdOrderedBy.ReadOnly = true;
            this.rdOrderedBy.Size = new System.Drawing.Size(166, 22);
            this.rdOrderedBy.TabIndex = 29;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnCancel.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGreen;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.Location = new System.Drawing.Point(612, 172);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(52, 57);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "&Exit";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGreen;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(558, 172);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(52, 57);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.txtBoxUQTY);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.rdTotal);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.txtBoxUnitPrice);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtBoxUOM);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtBoxQty);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtBoxParticulars);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtBoxStockCode);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(11, 231);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 84);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Controller";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Orange;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnReset.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGreen;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Location = new System.Drawing.Point(599, 47);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(51, 35);
            this.btnReset.TabIndex = 20;
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Visible = false;
            // 
            // txtBoxUQTY
            // 
            this.txtBoxUQTY.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxUQTY.Location = new System.Drawing.Point(232, 17);
            this.txtBoxUQTY.MaxLength = 8;
            this.txtBoxUQTY.Name = "txtBoxUQTY";
            this.txtBoxUQTY.ReadOnly = true;
            this.txtBoxUQTY.Size = new System.Drawing.Size(43, 25);
            this.txtBoxUQTY.TabIndex = 19;
            this.txtBoxUQTY.Text = "0";
            this.txtBoxUQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxUQTY.Visible = false;
            this.txtBoxUQTY.TextChanged += new System.EventHandler(this.txtBoxUQTY_TextChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Teal;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnUpdate.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGreen;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(547, 47);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(51, 35);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LawnGreen;
            this.btnAdd.Enabled = false;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnAdd.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGreen;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(547, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(51, 35);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // rdTotal
            // 
            this.rdTotal.BackColor = System.Drawing.Color.Black;
            this.rdTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTotal.ForeColor = System.Drawing.Color.Lime;
            this.rdTotal.Location = new System.Drawing.Point(442, 17);
            this.rdTotal.Name = "rdTotal";
            this.rdTotal.ReadOnly = true;
            this.rdTotal.Size = new System.Drawing.Size(99, 23);
            this.rdTotal.TabIndex = 16;
            this.rdTotal.Text = "0.00";
            this.rdTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Black;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnDelete.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGreen;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(599, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(51, 35);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtBoxUnitPrice
            // 
            this.txtBoxUnitPrice.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxUnitPrice.Location = new System.Drawing.Point(341, 17);
            this.txtBoxUnitPrice.Name = "txtBoxUnitPrice";
            this.txtBoxUnitPrice.ReadOnly = true;
            this.txtBoxUnitPrice.Size = new System.Drawing.Size(99, 22);
            this.txtBoxUnitPrice.TabIndex = 14;
            this.txtBoxUnitPrice.Text = "0.00";
            this.txtBoxUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(276, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 16);
            this.label13.TabIndex = 8;
            this.label13.Text = "Unit Price";
            // 
            // txtBoxUOM
            // 
            this.txtBoxUOM.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxUOM.Location = new System.Drawing.Point(387, 47);
            this.txtBoxUOM.Name = "txtBoxUOM";
            this.txtBoxUOM.ReadOnly = true;
            this.txtBoxUOM.Size = new System.Drawing.Size(155, 22);
            this.txtBoxUOM.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(352, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 16);
            this.label12.TabIndex = 6;
            this.label12.Text = "UOM";
            // 
            // txtBoxQty
            // 
            this.txtBoxQty.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxQty.Location = new System.Drawing.Point(232, 17);
            this.txtBoxQty.MaxLength = 8;
            this.txtBoxQty.Name = "txtBoxQty";
            this.txtBoxQty.ReadOnly = true;
            this.txtBoxQty.Size = new System.Drawing.Size(43, 25);
            this.txtBoxQty.TabIndex = 11;
            this.txtBoxQty.Text = "0";
            this.txtBoxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxQty.TextChanged += new System.EventHandler(this.txtBoxQty_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(203, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 16);
            this.label11.TabIndex = 4;
            this.label11.Text = "Qty";
            // 
            // txtBoxParticulars
            // 
            this.txtBoxParticulars.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxParticulars.Location = new System.Drawing.Point(84, 47);
            this.txtBoxParticulars.Name = "txtBoxParticulars";
            this.txtBoxParticulars.ReadOnly = true;
            this.txtBoxParticulars.Size = new System.Drawing.Size(263, 22);
            this.txtBoxParticulars.TabIndex = 13;
            this.txtBoxParticulars.TextChanged += new System.EventHandler(this.txtBoxParticulars_TextChanged);
            this.txtBoxParticulars.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxParticulars_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "Particulars";
            // 
            // txtBoxStockCode
            // 
            this.txtBoxStockCode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxStockCode.Location = new System.Drawing.Point(84, 18);
            this.txtBoxStockCode.Name = "txtBoxStockCode";
            this.txtBoxStockCode.ReadOnly = true;
            this.txtBoxStockCode.Size = new System.Drawing.Size(117, 22);
            this.txtBoxStockCode.TabIndex = 10;
            this.txtBoxStockCode.TextChanged += new System.EventHandler(this.txtBoxStockCode_TextChanged);
            this.txtBoxStockCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxStockCode_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Stock Code";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.MidnightBlue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgQTY,
            this.stock_code,
            this.Unit,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(0, 318);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(673, 224);
            this.dataGridView1.TabIndex = 35;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // cBoxCourier
            // 
            this.cBoxCourier.BackColor = System.Drawing.Color.White;
            this.cBoxCourier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCourier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cBoxCourier.FormattingEnabled = true;
            this.cBoxCourier.Items.AddRange(new object[] {
            "LBC",
            "JRS Express",
            "2GO",
            "Lite Ferries",
            "DHL",
            "FedEx",
            "Mersk",
            "FJP Shipping",
            "Oceanjet",
            "Cokaliong Shipping Lines",
            "Trans-Asia Shipping Lines",
            "Philippine Span Asia Carrier Corp"});
            this.cBoxCourier.Location = new System.Drawing.Point(497, 143);
            this.cBoxCourier.Name = "cBoxCourier";
            this.cBoxCourier.Size = new System.Drawing.Size(166, 25);
            this.cBoxCourier.TabIndex = 37;
            // 
            // cBoxWarehouse
            // 
            this.cBoxWarehouse.BackColor = System.Drawing.Color.White;
            this.cBoxWarehouse.DataSource = this.inventorywarehouseBindingSource;
            this.cBoxWarehouse.DisplayMember = "warehouse_name";
            this.cBoxWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cBoxWarehouse.FormattingEnabled = true;
            this.cBoxWarehouse.Location = new System.Drawing.Point(497, 115);
            this.cBoxWarehouse.Name = "cBoxWarehouse";
            this.cBoxWarehouse.Size = new System.Drawing.Size(166, 25);
            this.cBoxWarehouse.TabIndex = 36;
            // 
            // inventorywarehouseBindingSource
            // 
            this.inventorywarehouseBindingSource.DataMember = "inventory_warehouse";
            this.inventorywarehouseBindingSource.DataSource = this.npos_dbDataSet;
            // 
            // npos_dbDataSet
            // 
            this.npos_dbDataSet.DataSetName = "npos_dbDataSet";
            this.npos_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inventory_warehouseTableAdapter
            // 
            this.inventory_warehouseTableAdapter.ClearBeforeFill = true;
            // 
            // dgQTY
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgQTY.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgQTY.HeaderText = "Qty";
            this.dgQTY.Name = "dgQTY";
            this.dgQTY.ReadOnly = true;
            this.dgQTY.Width = 40;
            // 
            // stock_code
            // 
            this.stock_code.HeaderText = "Stock Code";
            this.stock_code.Name = "stock_code";
            this.stock_code.ReadOnly = true;
            // 
            // Unit
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Unit.DefaultCellStyle = dataGridViewCellStyle15;
            this.Unit.HeaderText = "UOM";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Particulars";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 300;
            // 
            // Column4
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.Format = "N2";
            dataGridViewCellStyle16.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle16;
            this.Column4.HeaderText = "Unit Price";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 90;
            // 
            // Column5
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.Format = "N2";
            dataGridViewCellStyle17.NullValue = null;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle17;
            this.Column5.HeaderText = "Amount";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 90;
            // 
            // mEditPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(673, 542);
            this.Controls.Add(this.cBoxCourier);
            this.Controls.Add(this.cBoxWarehouse);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rdOrderedBy);
            this.Controls.Add(this.txtBoxRemarks);
            this.Controls.Add(this.dt);
            this.Controls.Add(this.lAddress);
            this.Controls.Add(this.txtBoxSupplierName);
            this.Controls.Add(this.txtBoxSupplierCode);
            this.Controls.Add(this.rdPOno);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "mEditPO";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Order";
            this.Load += new System.EventHandler(this.mEditPO_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventorywarehouseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npos_dbDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lAddress;
        private System.Windows.Forms.TextBox txtBoxSupplierName;
        private System.Windows.Forms.TextBox txtBoxSupplierCode;
        private System.Windows.Forms.TextBox rdPOno;
        private System.Windows.Forms.DateTimePicker dt;
        private System.Windows.Forms.TextBox txtBoxRemarks;
        private System.Windows.Forms.TextBox rdOrderedBy;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtBoxUQTY;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox rdTotal;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtBoxUnitPrice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBoxUOM;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBoxQty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBoxParticulars;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBoxStockCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cBoxCourier;
        private System.Windows.Forms.ComboBox cBoxWarehouse;
        private npos_dbDataSet npos_dbDataSet;
        private System.Windows.Forms.BindingSource inventorywarehouseBindingSource;
        private npos_dbDataSetTableAdapters.inventory_warehouseTableAdapter inventory_warehouseTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}