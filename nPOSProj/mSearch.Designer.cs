namespace nPOSProj
{
    partial class mSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mSearch));
            this.cBoxSupplier = new System.Windows.Forms.ComboBox();
            this.inventorysupplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.npos_dbDataSet = new nPOSProj.npos_dbDataSet();
            this.txtBoxSupplierCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.inventory_supplierTableAdapter = new nPOSProj.npos_dbDataSetTableAdapters.inventory_supplierTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.inventorysupplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npos_dbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // cBoxSupplier
            // 
            this.cBoxSupplier.BackColor = System.Drawing.Color.DarkOrange;
            this.cBoxSupplier.DataSource = this.inventorysupplierBindingSource;
            this.cBoxSupplier.DisplayMember = "supplier_name";
            this.cBoxSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cBoxSupplier.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxSupplier.ForeColor = System.Drawing.Color.White;
            this.cBoxSupplier.FormattingEnabled = true;
            this.cBoxSupplier.Location = new System.Drawing.Point(64, 36);
            this.cBoxSupplier.Name = "cBoxSupplier";
            this.cBoxSupplier.Size = new System.Drawing.Size(297, 28);
            this.cBoxSupplier.TabIndex = 2;
            this.cBoxSupplier.SelectedIndexChanged += new System.EventHandler(this.cBoxSupplier_SelectedIndexChanged);
            this.cBoxSupplier.TextChanged += new System.EventHandler(this.cBoxSupplier_TextChanged);
            this.cBoxSupplier.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cBoxSupplier_MouseDown);
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
            // txtBoxSupplierCode
            // 
            this.txtBoxSupplierCode.BackColor = System.Drawing.Color.DarkOrange;
            this.txtBoxSupplierCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxSupplierCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBoxSupplierCode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSupplierCode.ForeColor = System.Drawing.Color.White;
            this.txtBoxSupplierCode.Location = new System.Drawing.Point(64, 7);
            this.txtBoxSupplierCode.MaxLength = 9;
            this.txtBoxSupplierCode.Name = "txtBoxSupplierCode";
            this.txtBoxSupplierCode.Size = new System.Drawing.Size(202, 26);
            this.txtBoxSupplierCode.TabIndex = 1;
            this.txtBoxSupplierCode.TextChanged += new System.EventHandler(this.txtBoxSupplierCode_TextChanged);
            this.txtBoxSupplierCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxSupplierCode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Supplier";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSearch.Enabled = false;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(268, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 28);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // inventory_supplierTableAdapter
            // 
            this.inventory_supplierTableAdapter.ClearBeforeFill = true;
            // 
            // mSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(365, 72);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBoxSupplierCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cBoxSupplier);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mSearch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.mSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inventorysupplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npos_dbDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBoxSupplier;
        private System.Windows.Forms.TextBox txtBoxSupplierCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private npos_dbDataSet npos_dbDataSet;
        private System.Windows.Forms.BindingSource inventorysupplierBindingSource;
        private npos_dbDataSetTableAdapters.inventory_supplierTableAdapter inventory_supplierTableAdapter;
    }
}