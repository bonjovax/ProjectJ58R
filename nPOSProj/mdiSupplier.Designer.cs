namespace nPOSProj
{
    partial class mdiSupplier
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdiSupplier));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.suppliercodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suppliernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplieraddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suppliercitymunicipalityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suppliercountryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierzipcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suppliercontactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suppliercontactpersonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suppliercpersonpositionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventorysupplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.npos_dbDataSet = new nPOSProj.npos_dbDataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnXML = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.rdSC = new System.Windows.Forms.TextBox();
            this.txtBoxCPosition = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBoxCPerson = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBoxContactNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBoxZipPos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxCountry = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxCityMun = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxNameComp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mCode = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inventory_supplierTableAdapter = new nPOSProj.npos_dbDataSetTableAdapters.inventory_supplierTableAdapter();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventorysupplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npos_dbDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.suppliercodeDataGridViewTextBoxColumn,
            this.suppliernameDataGridViewTextBoxColumn,
            this.supplieraddressDataGridViewTextBoxColumn,
            this.suppliercitymunicipalityDataGridViewTextBoxColumn,
            this.suppliercountryDataGridViewTextBoxColumn,
            this.supplierzipcodeDataGridViewTextBoxColumn,
            this.suppliercontactDataGridViewTextBoxColumn,
            this.suppliercontactpersonDataGridViewTextBoxColumn,
            this.suppliercpersonpositionDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.inventorysupplierBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(1, 1);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(894, 248);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // suppliercodeDataGridViewTextBoxColumn
            // 
            this.suppliercodeDataGridViewTextBoxColumn.DataPropertyName = "supplier_code";
            this.suppliercodeDataGridViewTextBoxColumn.HeaderText = "Supplier Code";
            this.suppliercodeDataGridViewTextBoxColumn.Name = "suppliercodeDataGridViewTextBoxColumn";
            this.suppliercodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.suppliercodeDataGridViewTextBoxColumn.Width = 120;
            // 
            // suppliernameDataGridViewTextBoxColumn
            // 
            this.suppliernameDataGridViewTextBoxColumn.DataPropertyName = "supplier_name";
            this.suppliernameDataGridViewTextBoxColumn.HeaderText = "Name/Company";
            this.suppliernameDataGridViewTextBoxColumn.Name = "suppliernameDataGridViewTextBoxColumn";
            this.suppliernameDataGridViewTextBoxColumn.Width = 200;
            // 
            // supplieraddressDataGridViewTextBoxColumn
            // 
            this.supplieraddressDataGridViewTextBoxColumn.DataPropertyName = "supplier_address";
            this.supplieraddressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.supplieraddressDataGridViewTextBoxColumn.Name = "supplieraddressDataGridViewTextBoxColumn";
            this.supplieraddressDataGridViewTextBoxColumn.Width = 250;
            // 
            // suppliercitymunicipalityDataGridViewTextBoxColumn
            // 
            this.suppliercitymunicipalityDataGridViewTextBoxColumn.DataPropertyName = "supplier_city_municipality";
            this.suppliercitymunicipalityDataGridViewTextBoxColumn.HeaderText = "City/Municipality";
            this.suppliercitymunicipalityDataGridViewTextBoxColumn.Name = "suppliercitymunicipalityDataGridViewTextBoxColumn";
            // 
            // suppliercountryDataGridViewTextBoxColumn
            // 
            this.suppliercountryDataGridViewTextBoxColumn.DataPropertyName = "supplier_country";
            this.suppliercountryDataGridViewTextBoxColumn.HeaderText = "Country";
            this.suppliercountryDataGridViewTextBoxColumn.Name = "suppliercountryDataGridViewTextBoxColumn";
            this.suppliercountryDataGridViewTextBoxColumn.Width = 150;
            // 
            // supplierzipcodeDataGridViewTextBoxColumn
            // 
            this.supplierzipcodeDataGridViewTextBoxColumn.DataPropertyName = "supplier_zipcode";
            this.supplierzipcodeDataGridViewTextBoxColumn.HeaderText = "Zip Code";
            this.supplierzipcodeDataGridViewTextBoxColumn.Name = "supplierzipcodeDataGridViewTextBoxColumn";
            // 
            // suppliercontactDataGridViewTextBoxColumn
            // 
            this.suppliercontactDataGridViewTextBoxColumn.DataPropertyName = "supplier_contact";
            this.suppliercontactDataGridViewTextBoxColumn.HeaderText = "Contact No";
            this.suppliercontactDataGridViewTextBoxColumn.Name = "suppliercontactDataGridViewTextBoxColumn";
            this.suppliercontactDataGridViewTextBoxColumn.Width = 175;
            // 
            // suppliercontactpersonDataGridViewTextBoxColumn
            // 
            this.suppliercontactpersonDataGridViewTextBoxColumn.DataPropertyName = "supplier_contact_person";
            this.suppliercontactpersonDataGridViewTextBoxColumn.HeaderText = "Contact Person";
            this.suppliercontactpersonDataGridViewTextBoxColumn.Name = "suppliercontactpersonDataGridViewTextBoxColumn";
            this.suppliercontactpersonDataGridViewTextBoxColumn.Width = 250;
            // 
            // suppliercpersonpositionDataGridViewTextBoxColumn
            // 
            this.suppliercpersonpositionDataGridViewTextBoxColumn.DataPropertyName = "supplier_cperson_position";
            this.suppliercpersonpositionDataGridViewTextBoxColumn.HeaderText = "Position";
            this.suppliercpersonpositionDataGridViewTextBoxColumn.Name = "suppliercpersonpositionDataGridViewTextBoxColumn";
            this.suppliercpersonpositionDataGridViewTextBoxColumn.Width = 200;
            // 
            // inventorysupplierBindingSource
            // 
            this.inventorysupplierBindingSource.DataMember = "inventory_supplier";
            this.inventorysupplierBindingSource.DataSource = this.npos_dbDataSet;
            // 
            // npos_dbDataSet
            // 
            this.npos_dbDataSet.DataSetName = "npos_dbDataSet";
            this.npos_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnXML);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.rdSC);
            this.groupBox1.Controls.Add(this.txtBoxCPosition);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtBoxCPerson);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtBoxContactNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtBoxZipPos);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtBoxCountry);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBoxCityMun);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtBoxAddress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBoxNameComp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.mCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(5, 252);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(887, 170);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Supplier Details";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(771, 106);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 60);
            this.btnDelete.TabIndex = 62;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUpdate.Location = new System.Drawing.Point(827, 44);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(55, 60);
            this.btnUpdate.TabIndex = 62;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnXML
            // 
            this.btnXML.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnXML.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnXML.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnXML.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btnXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXML.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXML.Image = ((System.Drawing.Image)(resources.GetObject("btnXML.Image")));
            this.btnXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXML.Location = new System.Drawing.Point(715, 72);
            this.btnXML.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXML.Name = "btnXML";
            this.btnXML.Size = new System.Drawing.Size(111, 32);
            this.btnXML.TabIndex = 103;
            this.btnXML.Text = "&XML Export";
            this.btnXML.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXML.UseVisualStyleBackColor = false;
            this.btnXML.Click += new System.EventHandler(this.btnXML_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(735, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 15);
            this.label11.TabIndex = 23;
            this.label11.Text = "Required";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Khaki;
            this.panel1.Location = new System.Drawing.Point(715, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(17, 19);
            this.panel1.TabIndex = 22;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.SlateGray;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClear.Location = new System.Drawing.Point(715, 106);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(55, 60);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(13)))));
            this.btnAdd.Enabled = false;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdd.Location = new System.Drawing.Point(827, 106);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 60);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(158, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "-";
            // 
            // rdSC
            // 
            this.rdSC.BackColor = System.Drawing.Color.Khaki;
            this.rdSC.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdSC.Location = new System.Drawing.Point(112, 22);
            this.rdSC.MaxLength = 4;
            this.rdSC.Name = "rdSC";
            this.rdSC.ReadOnly = true;
            this.rdSC.Size = new System.Drawing.Size(44, 23);
            this.rdSC.TabIndex = 18;
            this.rdSC.Text = "2013";
            this.rdSC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rdSC.TextChanged += new System.EventHandler(this.rdSC_TextChanged);
            // 
            // txtBoxCPosition
            // 
            this.txtBoxCPosition.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxCPosition.Location = new System.Drawing.Point(546, 142);
            this.txtBoxCPosition.MaxLength = 50;
            this.txtBoxCPosition.Name = "txtBoxCPosition";
            this.txtBoxCPosition.Size = new System.Drawing.Size(167, 23);
            this.txtBoxCPosition.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(445, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Contact Position";
            // 
            // txtBoxCPerson
            // 
            this.txtBoxCPerson.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxCPerson.Location = new System.Drawing.Point(546, 118);
            this.txtBoxCPerson.MaxLength = 50;
            this.txtBoxCPerson.Name = "txtBoxCPerson";
            this.txtBoxCPerson.Size = new System.Drawing.Size(167, 23);
            this.txtBoxCPerson.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(445, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Contact Person";
            // 
            // txtBoxContactNo
            // 
            this.txtBoxContactNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxContactNo.Location = new System.Drawing.Point(546, 94);
            this.txtBoxContactNo.MaxLength = 50;
            this.txtBoxContactNo.Name = "txtBoxContactNo";
            this.txtBoxContactNo.Size = new System.Drawing.Size(117, 23);
            this.txtBoxContactNo.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(445, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Contact No.";
            // 
            // txtBoxZipPos
            // 
            this.txtBoxZipPos.BackColor = System.Drawing.Color.Khaki;
            this.txtBoxZipPos.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxZipPos.Location = new System.Drawing.Point(546, 70);
            this.txtBoxZipPos.MaxLength = 5;
            this.txtBoxZipPos.Name = "txtBoxZipPos";
            this.txtBoxZipPos.Size = new System.Drawing.Size(68, 23);
            this.txtBoxZipPos.TabIndex = 11;
            this.txtBoxZipPos.TextChanged += new System.EventHandler(this.txtBoxZipPos_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(445, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Zip/Postal Code";
            // 
            // txtBoxCountry
            // 
            this.txtBoxCountry.BackColor = System.Drawing.Color.Khaki;
            this.txtBoxCountry.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxCountry.Location = new System.Drawing.Point(546, 46);
            this.txtBoxCountry.MaxLength = 50;
            this.txtBoxCountry.Name = "txtBoxCountry";
            this.txtBoxCountry.Size = new System.Drawing.Size(148, 23);
            this.txtBoxCountry.TabIndex = 9;
            this.txtBoxCountry.TextChanged += new System.EventHandler(this.txtBoxCountry_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(445, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Country";
            // 
            // txtBoxCityMun
            // 
            this.txtBoxCityMun.BackColor = System.Drawing.Color.Khaki;
            this.txtBoxCityMun.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxCityMun.Location = new System.Drawing.Point(546, 22);
            this.txtBoxCityMun.MaxLength = 50;
            this.txtBoxCityMun.Name = "txtBoxCityMun";
            this.txtBoxCityMun.Size = new System.Drawing.Size(117, 23);
            this.txtBoxCityMun.TabIndex = 7;
            this.txtBoxCityMun.TextChanged += new System.EventHandler(this.txtBoxCityMun_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(445, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "City/Municipality";
            // 
            // txtBoxAddress
            // 
            this.txtBoxAddress.BackColor = System.Drawing.Color.Khaki;
            this.txtBoxAddress.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxAddress.Location = new System.Drawing.Point(112, 70);
            this.txtBoxAddress.MaxLength = 100;
            this.txtBoxAddress.Multiline = true;
            this.txtBoxAddress.Name = "txtBoxAddress";
            this.txtBoxAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxAddress.Size = new System.Drawing.Size(326, 92);
            this.txtBoxAddress.TabIndex = 5;
            this.txtBoxAddress.TextChanged += new System.EventHandler(this.txtBoxAddress_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Address";
            // 
            // txtBoxNameComp
            // 
            this.txtBoxNameComp.BackColor = System.Drawing.Color.Khaki;
            this.txtBoxNameComp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxNameComp.Location = new System.Drawing.Point(112, 46);
            this.txtBoxNameComp.MaxLength = 100;
            this.txtBoxNameComp.Name = "txtBoxNameComp";
            this.txtBoxNameComp.Size = new System.Drawing.Size(326, 23);
            this.txtBoxNameComp.TabIndex = 3;
            this.txtBoxNameComp.TextChanged += new System.EventHandler(this.txtBoxNameComp_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name/Company";
            // 
            // mCode
            // 
            this.mCode.BackColor = System.Drawing.Color.Khaki;
            this.mCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mCode.Location = new System.Drawing.Point(172, 22);
            this.mCode.Mask = "AAAA";
            this.mCode.Name = "mCode";
            this.mCode.Size = new System.Drawing.Size(42, 23);
            this.mCode.TabIndex = 1;
            this.mCode.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mCode_MaskInputRejected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier Code";
            // 
            // inventory_supplierTableAdapter
            // 
            this.inventory_supplierTableAdapter.ClearBeforeFill = true;
            // 
            // mdiSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(896, 426);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mdiSupplier";
            this.Text = "Supplier";
            this.Load += new System.EventHandler(this.mdiSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventorysupplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npos_dbDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBoxAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxNameComp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxCPosition;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBoxCPerson;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBoxContactNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBoxZipPos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxCountry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxCityMun;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox rdSC;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private npos_dbDataSet npos_dbDataSet;
        private System.Windows.Forms.BindingSource inventorysupplierBindingSource;
        private npos_dbDataSetTableAdapters.inventory_supplierTableAdapter inventory_supplierTableAdapter;
        private System.Windows.Forms.Button btnXML;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn suppliercodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suppliernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplieraddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suppliercitymunicipalityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suppliercountryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierzipcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suppliercontactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suppliercontactpersonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suppliercpersonpositionDataGridViewTextBoxColumn;
    }
}