namespace nPOSProj
{
    partial class mdiPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdiPayment));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayableAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxAmount = new System.Windows.Forms.TextBox();
            this.btnXML = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Tomato;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerCode,
            this.Company,
            this.PayableAmount,
            this.PaidAmount,
            this.Balance});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(688, 193);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // CustomerCode
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.CustomerCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.CustomerCode.HeaderText = "Code";
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.ReadOnly = true;
            this.CustomerCode.Width = 85;
            // 
            // Company
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Company.DefaultCellStyle = dataGridViewCellStyle3;
            this.Company.HeaderText = "Company";
            this.Company.Name = "Company";
            this.Company.ReadOnly = true;
            this.Company.Width = 200;
            // 
            // PayableAmount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.PayableAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.PayableAmount.HeaderText = "Payable";
            this.PayableAmount.Name = "PayableAmount";
            this.PayableAmount.ReadOnly = true;
            this.PayableAmount.Width = 120;
            // 
            // PaidAmount
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.PaidAmount.DefaultCellStyle = dataGridViewCellStyle5;
            this.PaidAmount.HeaderText = "Paid Amount";
            this.PaidAmount.Name = "PaidAmount";
            this.PaidAmount.ReadOnly = true;
            this.PaidAmount.Width = 120;
            // 
            // Balance
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.Balance.DefaultCellStyle = dataGridViewCellStyle6;
            this.Balance.HeaderText = "Balance";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            this.Balance.Width = 120;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPay);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtBoxAmount);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(4, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 80);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Information";
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.ForestGreen;
            this.btnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPay.Enabled = false;
            this.btnPay.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnPay.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.btnPay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btnPay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Image = ((System.Drawing.Image)(resources.GetObject("btnPay.Image")));
            this.btnPay.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPay.Location = new System.Drawing.Point(202, 15);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(59, 59);
            this.btnPay.TabIndex = 2;
            this.btnPay.Text = "&Pay";
            this.btnPay.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Amount";
            // 
            // txtBoxAmount
            // 
            this.txtBoxAmount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxAmount.Location = new System.Drawing.Point(80, 17);
            this.txtBoxAmount.MaxLength = 10;
            this.txtBoxAmount.Name = "txtBoxAmount";
            this.txtBoxAmount.ReadOnly = true;
            this.txtBoxAmount.Size = new System.Drawing.Size(116, 27);
            this.txtBoxAmount.TabIndex = 0;
            this.txtBoxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxAmount.TextChanged += new System.EventHandler(this.txtBoxAmount_TextChanged);
            this.txtBoxAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxAmount_KeyDown);
            this.txtBoxAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxAmount_KeyPress);
            // 
            // btnXML
            // 
            this.btnXML.BackColor = System.Drawing.Color.OrangeRed;
            this.btnXML.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXML.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnXML.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.btnXML.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btnXML.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXML.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXML.ForeColor = System.Drawing.Color.White;
            this.btnXML.Image = ((System.Drawing.Image)(resources.GetObject("btnXML.Image")));
            this.btnXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXML.Location = new System.Drawing.Point(578, 247);
            this.btnXML.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXML.Name = "btnXML";
            this.btnXML.Size = new System.Drawing.Size(109, 32);
            this.btnXML.TabIndex = 12;
            this.btnXML.Text = "&XML Export";
            this.btnXML.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXML.UseVisualStyleBackColor = false;
            this.btnXML.Click += new System.EventHandler(this.btnXML_Click);
            // 
            // mdiPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(688, 281);
            this.Controls.Add(this.btnXML);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mdiPayment";
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.mdiPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxAmount;
        private System.Windows.Forms.Button btnXML;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayableAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}