namespace nPOSProj
{
    partial class mdiItems
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdiItems));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.itemquantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemeanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stocknameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemretailpriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemwholepriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catdescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_tax_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoryitemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.npos_dbDataSet = new nPOSProj.npos_dbDataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPatch = new System.Windows.Forms.Button();
            this.rdZ = new System.Windows.Forms.RadioButton();
            this.rdE = new System.Windows.Forms.RadioButton();
            this.rdVatable = new System.Windows.Forms.RadioButton();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.txtBoxWholesalePrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxRPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBonxEAN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.barcode = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bcSave = new System.Windows.Forms.Button();
            this.btnXML = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.inventory_itemsTableAdapter = new nPOSProj.npos_dbDataSetTableAdapters.inventory_itemsTableAdapter();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearchEan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryitemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npos_dbDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barcode)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemquantityDataGridViewTextBoxColumn,
            this.stockcodeDataGridViewTextBoxColumn,
            this.itemeanDataGridViewTextBoxColumn,
            this.stocknameDataGridViewTextBoxColumn,
            this.itemretailpriceDataGridViewTextBoxColumn,
            this.itemwholepriceDataGridViewTextBoxColumn,
            this.catdescriptionDataGridViewTextBoxColumn,
            this.item_tax_type});
            this.dataGridView1.DataSource = this.inventoryitemsBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Brown;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(1, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(829, 307);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // itemquantityDataGridViewTextBoxColumn
            // 
            this.itemquantityDataGridViewTextBoxColumn.DataPropertyName = "item_quantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.itemquantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.itemquantityDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.itemquantityDataGridViewTextBoxColumn.Name = "itemquantityDataGridViewTextBoxColumn";
            this.itemquantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemquantityDataGridViewTextBoxColumn.Width = 50;
            // 
            // stockcodeDataGridViewTextBoxColumn
            // 
            this.stockcodeDataGridViewTextBoxColumn.DataPropertyName = "stock_code";
            this.stockcodeDataGridViewTextBoxColumn.HeaderText = "Stock Code";
            this.stockcodeDataGridViewTextBoxColumn.Name = "stockcodeDataGridViewTextBoxColumn";
            this.stockcodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemeanDataGridViewTextBoxColumn
            // 
            this.itemeanDataGridViewTextBoxColumn.DataPropertyName = "item_ean";
            this.itemeanDataGridViewTextBoxColumn.HeaderText = "EAN";
            this.itemeanDataGridViewTextBoxColumn.Name = "itemeanDataGridViewTextBoxColumn";
            this.itemeanDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemeanDataGridViewTextBoxColumn.Width = 230;
            // 
            // stocknameDataGridViewTextBoxColumn
            // 
            this.stocknameDataGridViewTextBoxColumn.DataPropertyName = "stock_name";
            this.stocknameDataGridViewTextBoxColumn.HeaderText = "Description";
            this.stocknameDataGridViewTextBoxColumn.Name = "stocknameDataGridViewTextBoxColumn";
            this.stocknameDataGridViewTextBoxColumn.ReadOnly = true;
            this.stocknameDataGridViewTextBoxColumn.Width = 330;
            // 
            // itemretailpriceDataGridViewTextBoxColumn
            // 
            this.itemretailpriceDataGridViewTextBoxColumn.DataPropertyName = "item_retail_price";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.itemretailpriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.itemretailpriceDataGridViewTextBoxColumn.HeaderText = "Retail Price";
            this.itemretailpriceDataGridViewTextBoxColumn.Name = "itemretailpriceDataGridViewTextBoxColumn";
            this.itemretailpriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemretailpriceDataGridViewTextBoxColumn.Width = 115;
            // 
            // itemwholepriceDataGridViewTextBoxColumn
            // 
            this.itemwholepriceDataGridViewTextBoxColumn.DataPropertyName = "item_whole_price";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.itemwholepriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.itemwholepriceDataGridViewTextBoxColumn.HeaderText = "Wholesale Price";
            this.itemwholepriceDataGridViewTextBoxColumn.Name = "itemwholepriceDataGridViewTextBoxColumn";
            this.itemwholepriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemwholepriceDataGridViewTextBoxColumn.Width = 123;
            // 
            // catdescriptionDataGridViewTextBoxColumn
            // 
            this.catdescriptionDataGridViewTextBoxColumn.DataPropertyName = "cat_description";
            this.catdescriptionDataGridViewTextBoxColumn.HeaderText = "Category";
            this.catdescriptionDataGridViewTextBoxColumn.Name = "catdescriptionDataGridViewTextBoxColumn";
            this.catdescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.catdescriptionDataGridViewTextBoxColumn.Width = 175;
            // 
            // item_tax_type
            // 
            this.item_tax_type.DataPropertyName = "item_tax_type";
            this.item_tax_type.HeaderText = "Tax Type";
            this.item_tax_type.MaxInputLength = 1;
            this.item_tax_type.Name = "item_tax_type";
            this.item_tax_type.ReadOnly = true;
            this.item_tax_type.Width = 85;
            // 
            // inventoryitemsBindingSource
            // 
            this.inventoryitemsBindingSource.DataMember = "inventory_items";
            this.inventoryitemsBindingSource.DataSource = this.npos_dbDataSet;
            // 
            // npos_dbDataSet
            // 
            this.npos_dbDataSet.DataSetName = "npos_dbDataSet";
            this.npos_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPatch);
            this.groupBox1.Controls.Add(this.rdZ);
            this.groupBox1.Controls.Add(this.rdE);
            this.groupBox1.Controls.Add(this.rdVatable);
            this.groupBox1.Controls.Add(this.btnReturn);
            this.groupBox1.Controls.Add(this.btnUp);
            this.groupBox1.Controls.Add(this.txtBoxWholesalePrice);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtBoxRPrice);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBonxEAN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBoxQty);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(7, 312);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 168);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Information";
            // 
            // btnPatch
            // 
            this.btnPatch.BackColor = System.Drawing.Color.DarkRed;
            this.btnPatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPatch.Enabled = false;
            this.btnPatch.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnPatch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnPatch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btnPatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatch.Image = ((System.Drawing.Image)(resources.GetObject("btnPatch.Image")));
            this.btnPatch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPatch.Location = new System.Drawing.Point(391, 13);
            this.btnPatch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPatch.Name = "btnPatch";
            this.btnPatch.Size = new System.Drawing.Size(107, 32);
            this.btnPatch.TabIndex = 104;
            this.btnPatch.Text = "&Patch Code";
            this.btnPatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPatch.UseVisualStyleBackColor = false;
            this.btnPatch.Click += new System.EventHandler(this.btnPatch_Click);
            // 
            // rdZ
            // 
            this.rdZ.AutoSize = true;
            this.rdZ.Location = new System.Drawing.Point(242, 122);
            this.rdZ.Name = "rdZ";
            this.rdZ.Size = new System.Drawing.Size(119, 21);
            this.rdZ.TabIndex = 12;
            this.rdZ.TabStop = true;
            this.rdZ.Text = "VAT Zero-Rated";
            this.rdZ.UseVisualStyleBackColor = true;
            // 
            // rdE
            // 
            this.rdE.AutoSize = true;
            this.rdE.Location = new System.Drawing.Point(242, 103);
            this.rdE.Name = "rdE";
            this.rdE.Size = new System.Drawing.Size(96, 21);
            this.rdE.TabIndex = 11;
            this.rdE.TabStop = true;
            this.rdE.Text = "VAT Exempt";
            this.rdE.UseVisualStyleBackColor = true;
            // 
            // rdVatable
            // 
            this.rdVatable.AutoSize = true;
            this.rdVatable.Location = new System.Drawing.Point(242, 84);
            this.rdVatable.Name = "rdVatable";
            this.rdVatable.Size = new System.Drawing.Size(74, 21);
            this.rdVatable.TabIndex = 10;
            this.rdVatable.TabStop = true;
            this.rdVatable.Text = "VATable";
            this.rdVatable.UseVisualStyleBackColor = true;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.DarkOrange;
            this.btnReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturn.Enabled = false;
            this.btnReturn.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnReturn.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.btnReturn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnReturn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Image = ((System.Drawing.Image)(resources.GetObject("btnReturn.Image")));
            this.btnReturn.Location = new System.Drawing.Point(374, 92);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(62, 70);
            this.btnReturn.TabIndex = 9;
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.ForestGreen;
            this.btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUp.Enabled = false;
            this.btnUp.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnUp.FlatAppearance.CheckedBackColor = System.Drawing.Color.MidnightBlue;
            this.btnUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(436, 92);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(62, 70);
            this.btnUp.TabIndex = 8;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // txtBoxWholesalePrice
            // 
            this.txtBoxWholesalePrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxWholesalePrice.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxWholesalePrice.Location = new System.Drawing.Point(119, 106);
            this.txtBoxWholesalePrice.MaxLength = 10;
            this.txtBoxWholesalePrice.Name = "txtBoxWholesalePrice";
            this.txtBoxWholesalePrice.ReadOnly = true;
            this.txtBoxWholesalePrice.Size = new System.Drawing.Size(96, 26);
            this.txtBoxWholesalePrice.TabIndex = 7;
            this.txtBoxWholesalePrice.Text = "0.00";
            this.txtBoxWholesalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxWholesalePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxWholesalePrice_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Wholesale Price";
            // 
            // txtBoxRPrice
            // 
            this.txtBoxRPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxRPrice.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxRPrice.Location = new System.Drawing.Point(119, 77);
            this.txtBoxRPrice.MaxLength = 10;
            this.txtBoxRPrice.Name = "txtBoxRPrice";
            this.txtBoxRPrice.ReadOnly = true;
            this.txtBoxRPrice.Size = new System.Drawing.Size(96, 26);
            this.txtBoxRPrice.TabIndex = 5;
            this.txtBoxRPrice.Text = "0.00";
            this.txtBoxRPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxRPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxRPrice_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Retail Price";
            // 
            // txtBonxEAN
            // 
            this.txtBonxEAN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBonxEAN.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBonxEAN.Location = new System.Drawing.Point(119, 48);
            this.txtBonxEAN.MaxLength = 13;
            this.txtBonxEAN.Name = "txtBonxEAN";
            this.txtBonxEAN.ReadOnly = true;
            this.txtBonxEAN.Size = new System.Drawing.Size(378, 26);
            this.txtBonxEAN.TabIndex = 3;
            this.txtBonxEAN.TextChanged += new System.EventHandler(this.txtBonxEAN_TextChanged);
            this.txtBonxEAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBonxEAN_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "EAN/Code";
            // 
            // txtBoxQty
            // 
            this.txtBoxQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxQty.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxQty.Location = new System.Drawing.Point(119, 19);
            this.txtBoxQty.MaxLength = 6;
            this.txtBoxQty.Name = "txtBoxQty";
            this.txtBoxQty.ReadOnly = true;
            this.txtBoxQty.Size = new System.Drawing.Size(52, 26);
            this.txtBoxQty.TabIndex = 1;
            this.txtBoxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxQty_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Qty";
            // 
            // barcode
            // 
            this.barcode.BackColor = System.Drawing.Color.Transparent;
            this.barcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barcode.Location = new System.Drawing.Point(11, 21);
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(250, 103);
            this.barcode.TabIndex = 14;
            this.barcode.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bcSave);
            this.groupBox2.Controls.Add(this.barcode);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(516, 312);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 135);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Barcode Section";
            // 
            // bcSave
            // 
            this.bcSave.BackColor = System.Drawing.Color.Gray;
            this.bcSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcSave.Enabled = false;
            this.bcSave.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.bcSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.bcSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.bcSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bcSave.Image = ((System.Drawing.Image)(resources.GetObject("bcSave.Image")));
            this.bcSave.Location = new System.Drawing.Point(265, 21);
            this.bcSave.Name = "bcSave";
            this.bcSave.Size = new System.Drawing.Size(37, 106);
            this.bcSave.TabIndex = 15;
            this.bcSave.UseVisualStyleBackColor = false;
            this.bcSave.Click += new System.EventHandler(this.bcSave_Click);
            // 
            // btnXML
            // 
            this.btnXML.BackColor = System.Drawing.Color.Chocolate;
            this.btnXML.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXML.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnXML.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnXML.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btnXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXML.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXML.Image = ((System.Drawing.Image)(resources.GetObject("btnXML.Image")));
            this.btnXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXML.Location = new System.Drawing.Point(714, 449);
            this.btnXML.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXML.Name = "btnXML";
            this.btnXML.Size = new System.Drawing.Size(110, 32);
            this.btnXML.TabIndex = 103;
            this.btnXML.Text = "&XML Export";
            this.btnXML.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXML.UseVisualStyleBackColor = false;
            this.btnXML.Click += new System.EventHandler(this.btnXML_Click);
            // 
            // inventory_itemsTableAdapter
            // 
            this.inventory_itemsTableAdapter.ClearBeforeFill = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.DarkCyan;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(615, 449);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(98, 32);
            this.btnRefresh.TabIndex = 104;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearchEan
            // 
            this.txtSearchEan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchEan.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchEan.Location = new System.Drawing.Point(91, 483);
            this.txtSearchEan.MaxLength = 13;
            this.txtSearchEan.Name = "txtSearchEan";
            this.txtSearchEan.Size = new System.Drawing.Size(254, 26);
            this.txtSearchEan.TabIndex = 106;
            this.txtSearchEan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchEan_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 487);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 105;
            this.label5.Text = "Search EAN";
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxSearch.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSearch.Location = new System.Drawing.Point(468, 483);
            this.txtBoxSearch.MaxLength = 13;
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(354, 26);
            this.txtBoxSearch.TabIndex = 108;
            this.txtBoxSearch.TextChanged += new System.EventHandler(this.txtBoxSearch_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(348, 487);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 107;
            this.label6.Text = "Search Description";
            // 
            // mdiItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(831, 513);
            this.Controls.Add(this.txtBoxSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSearchEan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnXML);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mdiItems";
            this.Text = "Items";
            this.Load += new System.EventHandler(this.mdiItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryitemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npos_dbDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barcode)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private npos_dbDataSet npos_dbDataSet;
        private System.Windows.Forms.BindingSource inventoryitemsBindingSource;
        private npos_dbDataSetTableAdapters.inventory_itemsTableAdapter inventory_itemsTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox barcode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.TextBox txtBoxWholesalePrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxRPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBonxEAN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bcSave;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnXML;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemquantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemeanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stocknameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemretailpriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemwholepriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn catdescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_tax_type;
        private System.Windows.Forms.RadioButton rdZ;
        private System.Windows.Forms.RadioButton rdE;
        private System.Windows.Forms.RadioButton rdVatable;
        private System.Windows.Forms.Button btnPatch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearchEan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.Label label6;
    }
}