namespace nPOSProj
{
    partial class mdiItemKits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdiItemKits));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.itemquantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemeanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kitnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemretailpriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemwholepriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoryitems1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.npos_dbDataSet = new nPOSProj.npos_dbDataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bcSave = new System.Windows.Forms.Button();
            this.barcode = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtBoxWholesalePrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxRetailPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxEAN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inventory_items1TableAdapter = new nPOSProj.npos_dbDataSetTableAdapters.inventory_items1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryitems1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npos_dbDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barcode)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Crimson;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemquantityDataGridViewTextBoxColumn,
            this.itemeanDataGridViewTextBoxColumn,
            this.kitnameDataGridViewTextBoxColumn,
            this.itemretailpriceDataGridViewTextBoxColumn,
            this.itemwholepriceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.inventoryitems1BindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(1, 1);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(738, 175);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // itemquantityDataGridViewTextBoxColumn
            // 
            this.itemquantityDataGridViewTextBoxColumn.DataPropertyName = "item_quantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.itemquantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.itemquantityDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.itemquantityDataGridViewTextBoxColumn.MaxInputLength = 6;
            this.itemquantityDataGridViewTextBoxColumn.Name = "itemquantityDataGridViewTextBoxColumn";
            this.itemquantityDataGridViewTextBoxColumn.Width = 50;
            // 
            // itemeanDataGridViewTextBoxColumn
            // 
            this.itemeanDataGridViewTextBoxColumn.DataPropertyName = "item_ean";
            this.itemeanDataGridViewTextBoxColumn.HeaderText = "EAN";
            this.itemeanDataGridViewTextBoxColumn.MaxInputLength = 13;
            this.itemeanDataGridViewTextBoxColumn.Name = "itemeanDataGridViewTextBoxColumn";
            this.itemeanDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemeanDataGridViewTextBoxColumn.Width = 130;
            // 
            // kitnameDataGridViewTextBoxColumn
            // 
            this.kitnameDataGridViewTextBoxColumn.DataPropertyName = "kit_name";
            this.kitnameDataGridViewTextBoxColumn.HeaderText = "Description";
            this.kitnameDataGridViewTextBoxColumn.MaxInputLength = 30;
            this.kitnameDataGridViewTextBoxColumn.Name = "kitnameDataGridViewTextBoxColumn";
            this.kitnameDataGridViewTextBoxColumn.Width = 295;
            // 
            // itemretailpriceDataGridViewTextBoxColumn
            // 
            this.itemretailpriceDataGridViewTextBoxColumn.DataPropertyName = "item_retail_price";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.itemretailpriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.itemretailpriceDataGridViewTextBoxColumn.HeaderText = "Retail Price";
            this.itemretailpriceDataGridViewTextBoxColumn.MaxInputLength = 15;
            this.itemretailpriceDataGridViewTextBoxColumn.Name = "itemretailpriceDataGridViewTextBoxColumn";
            // 
            // itemwholepriceDataGridViewTextBoxColumn
            // 
            this.itemwholepriceDataGridViewTextBoxColumn.DataPropertyName = "item_whole_price";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.itemwholepriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.itemwholepriceDataGridViewTextBoxColumn.HeaderText = "Wholesale Price";
            this.itemwholepriceDataGridViewTextBoxColumn.MaxInputLength = 15;
            this.itemwholepriceDataGridViewTextBoxColumn.Name = "itemwholepriceDataGridViewTextBoxColumn";
            this.itemwholepriceDataGridViewTextBoxColumn.Width = 122;
            // 
            // inventoryitems1BindingSource
            // 
            this.inventoryitems1BindingSource.DataMember = "inventory_items1";
            this.inventoryitems1BindingSource.DataSource = this.npos_dbDataSet;
            // 
            // npos_dbDataSet
            // 
            this.npos_dbDataSet.DataSetName = "npos_dbDataSet";
            this.npos_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bcSave);
            this.groupBox1.Controls.Add(this.barcode);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtBoxWholesalePrice);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBoxRetailPrice);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtBoxDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBoxEAN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBoxQty);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(733, 110);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Kits";
            // 
            // bcSave
            // 
            this.bcSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.bcSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bcSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.bcSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateGray;
            this.bcSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.bcSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bcSave.Image = ((System.Drawing.Image)(resources.GetObject("bcSave.Image")));
            this.bcSave.Location = new System.Drawing.Point(695, 53);
            this.bcSave.Name = "bcSave";
            this.bcSave.Size = new System.Drawing.Size(35, 53);
            this.bcSave.TabIndex = 15;
            this.bcSave.UseVisualStyleBackColor = false;
            this.bcSave.Click += new System.EventHandler(this.bcSave_Click);
            // 
            // barcode
            // 
            this.barcode.BackColor = System.Drawing.Color.White;
            this.barcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barcode.Location = new System.Drawing.Point(531, 53);
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(165, 53);
            this.barcode.TabIndex = 14;
            this.barcode.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnDelete.Location = new System.Drawing.Point(632, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 36);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.YellowGreen;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(531, 15);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 36);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Gold;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Enabled = false;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(416, 65);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(113, 41);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add Item";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtBoxWholesalePrice
            // 
            this.txtBoxWholesalePrice.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtBoxWholesalePrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxWholesalePrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxWholesalePrice.Location = new System.Drawing.Point(417, 40);
            this.txtBoxWholesalePrice.MaxLength = 15;
            this.txtBoxWholesalePrice.Name = "txtBoxWholesalePrice";
            this.txtBoxWholesalePrice.Size = new System.Drawing.Size(111, 22);
            this.txtBoxWholesalePrice.TabIndex = 9;
            this.txtBoxWholesalePrice.Text = "0.00";
            this.txtBoxWholesalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxWholesalePrice.TextChanged += new System.EventHandler(this.txtBoxWholesalePrice_TextChanged);
            this.txtBoxWholesalePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxWholesalePrice_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Wholesale Price";
            // 
            // txtBoxRetailPrice
            // 
            this.txtBoxRetailPrice.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtBoxRetailPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxRetailPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxRetailPrice.Location = new System.Drawing.Point(417, 15);
            this.txtBoxRetailPrice.MaxLength = 15;
            this.txtBoxRetailPrice.Name = "txtBoxRetailPrice";
            this.txtBoxRetailPrice.Size = new System.Drawing.Size(111, 22);
            this.txtBoxRetailPrice.TabIndex = 7;
            this.txtBoxRetailPrice.Text = "0.00";
            this.txtBoxRetailPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxRetailPrice.TextChanged += new System.EventHandler(this.txtBoxRetailPrice_TextChanged);
            this.txtBoxRetailPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxRetailPrice_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Retail Price";
            // 
            // txtBoxDescription
            // 
            this.txtBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxDescription.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxDescription.Location = new System.Drawing.Point(77, 78);
            this.txtBoxDescription.MaxLength = 25;
            this.txtBoxDescription.Name = "txtBoxDescription";
            this.txtBoxDescription.Size = new System.Drawing.Size(328, 26);
            this.txtBoxDescription.TabIndex = 5;
            this.txtBoxDescription.TextChanged += new System.EventHandler(this.txtBoxDescription_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Description";
            // 
            // txtBoxEAN
            // 
            this.txtBoxEAN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxEAN.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxEAN.Location = new System.Drawing.Point(77, 49);
            this.txtBoxEAN.MaxLength = 13;
            this.txtBoxEAN.Name = "txtBoxEAN";
            this.txtBoxEAN.Size = new System.Drawing.Size(232, 26);
            this.txtBoxEAN.TabIndex = 3;
            this.txtBoxEAN.TextChanged += new System.EventHandler(this.txtBoxEAN_TextChanged);
            this.txtBoxEAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxEAN_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "EAN";
            // 
            // txtBoxQty
            // 
            this.txtBoxQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxQty.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxQty.Location = new System.Drawing.Point(77, 20);
            this.txtBoxQty.MaxLength = 6;
            this.txtBoxQty.Name = "txtBoxQty";
            this.txtBoxQty.Size = new System.Drawing.Size(58, 26);
            this.txtBoxQty.TabIndex = 1;
            this.txtBoxQty.TextChanged += new System.EventHandler(this.txtBoxQty_TextChanged);
            this.txtBoxQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxQty_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Qty";
            // 
            // inventory_items1TableAdapter
            // 
            this.inventory_items1TableAdapter.ClearBeforeFill = true;
            // 
            // mdiItemKits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(739, 297);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mdiItemKits";
            this.Text = "Item Kits";
            this.Load += new System.EventHandler(this.mditemKits_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryitems1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npos_dbDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barcode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private npos_dbDataSet npos_dbDataSet;
        private System.Windows.Forms.BindingSource inventoryitems1BindingSource;
        private npos_dbDataSetTableAdapters.inventory_items1TableAdapter inventory_items1TableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxRetailPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxEAN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtBoxWholesalePrice;
        private System.Windows.Forms.Button bcSave;
        private System.Windows.Forms.PictureBox barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemquantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemeanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kitnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemretailpriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemwholepriceDataGridViewTextBoxColumn;

    }
}