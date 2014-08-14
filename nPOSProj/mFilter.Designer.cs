namespace nPOSProj
{
    partial class mFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mFilter));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cBoxWarehouse = new System.Windows.Forms.ComboBox();
            this.inventorywarehouseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.npos_dbDataSet = new nPOSProj.npos_dbDataSet();
            this.cBoxSupplier = new System.Windows.Forms.ComboBox();
            this.inventorysupplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.inventory_supplierTableAdapter = new nPOSProj.npos_dbDataSetTableAdapters.inventory_supplierTableAdapter();
            this.inventory_warehouseTableAdapter = new nPOSProj.npos_dbDataSetTableAdapters.inventory_warehouseTableAdapter();
            this.btnGo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventorywarehouseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npos_dbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventorysupplierBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBoxWarehouse);
            this.groupBox1.Controls.Add(this.cBoxSupplier);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cBoxWarehouse
            // 
            this.cBoxWarehouse.BackColor = System.Drawing.Color.DarkSlateGray;
            this.cBoxWarehouse.DataSource = this.inventorywarehouseBindingSource;
            this.cBoxWarehouse.DisplayMember = "warehouse_name";
            this.cBoxWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cBoxWarehouse.ForeColor = System.Drawing.Color.White;
            this.cBoxWarehouse.FormattingEnabled = true;
            this.cBoxWarehouse.Location = new System.Drawing.Point(83, 42);
            this.cBoxWarehouse.Name = "cBoxWarehouse";
            this.cBoxWarehouse.Size = new System.Drawing.Size(190, 25);
            this.cBoxWarehouse.TabIndex = 3;
            this.cBoxWarehouse.SelectedIndexChanged += new System.EventHandler(this.cBoxWarehouse_SelectedIndexChanged);
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
            // cBoxSupplier
            // 
            this.cBoxSupplier.BackColor = System.Drawing.Color.DarkSlateGray;
            this.cBoxSupplier.DataSource = this.inventorysupplierBindingSource;
            this.cBoxSupplier.DisplayMember = "supplier_name";
            this.cBoxSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cBoxSupplier.ForeColor = System.Drawing.Color.White;
            this.cBoxSupplier.FormattingEnabled = true;
            this.cBoxSupplier.Location = new System.Drawing.Point(83, 13);
            this.cBoxSupplier.Name = "cBoxSupplier";
            this.cBoxSupplier.Size = new System.Drawing.Size(190, 25);
            this.cBoxSupplier.TabIndex = 2;
            this.cBoxSupplier.SelectedIndexChanged += new System.EventHandler(this.cBoxSupplier_SelectedIndexChanged);
            // 
            // inventorysupplierBindingSource
            // 
            this.inventorysupplierBindingSource.DataMember = "inventory_supplier";
            this.inventorysupplierBindingSource.DataSource = this.npos_dbDataSet;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Warehouse";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier";
            // 
            // inventory_supplierTableAdapter
            // 
            this.inventory_supplierTableAdapter.ClearBeforeFill = true;
            // 
            // inventory_warehouseTableAdapter
            // 
            this.inventory_warehouseTableAdapter.ClearBeforeFill = true;
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.DarkOrange;
            this.btnGo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGo.Enabled = false;
            this.btnGo.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnGo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnGo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Image = ((System.Drawing.Image)(resources.GetObject("btnGo.Image")));
            this.btnGo.Location = new System.Drawing.Point(232, 76);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(51, 58);
            this.btnGo.TabIndex = 1;
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // mFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(286, 136);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mFilter";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filter";
            this.Load += new System.EventHandler(this.mFilter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventorywarehouseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npos_dbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventorysupplierBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cBoxWarehouse;
        private System.Windows.Forms.ComboBox cBoxSupplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private npos_dbDataSet npos_dbDataSet;
        private System.Windows.Forms.BindingSource inventorysupplierBindingSource;
        private npos_dbDataSetTableAdapters.inventory_supplierTableAdapter inventory_supplierTableAdapter;
        private System.Windows.Forms.BindingSource inventorywarehouseBindingSource;
        private npos_dbDataSetTableAdapters.inventory_warehouseTableAdapter inventory_warehouseTableAdapter;
        private System.Windows.Forms.Button btnGo;
    }
}