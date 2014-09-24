namespace nPOSProj
{
    partial class mdiSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdiSummary));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtSelect = new System.Windows.Forms.DateTimePicker();
            this.btnEsc = new System.Windows.Forms.Button();
            this.btnF12 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.terms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outstandingbalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.current = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thirties = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sixties = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nineties = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overninty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl30 = new System.Windows.Forms.Label();
            this.lbl60 = new System.Windows.Forms.Label();
            this.lbl90 = new System.Windows.Forms.Label();
            this.lblOver = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblOutstanding = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtSelect
            // 
            this.dtSelect.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtSelect.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSelect.Location = new System.Drawing.Point(0, 0);
            this.dtSelect.Name = "dtSelect";
            this.dtSelect.Size = new System.Drawing.Size(124, 25);
            this.dtSelect.TabIndex = 0;
            // 
            // btnEsc
            // 
            this.btnEsc.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEsc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEsc.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnEsc.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(0)))), ((int)(((byte)(171)))));
            this.btnEsc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
            this.btnEsc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
            this.btnEsc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEsc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEsc.ForeColor = System.Drawing.Color.White;
            this.btnEsc.Image = ((System.Drawing.Image)(resources.GetObject("btnEsc.Image")));
            this.btnEsc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEsc.Location = new System.Drawing.Point(1124, 1);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Size = new System.Drawing.Size(94, 34);
            this.btnEsc.TabIndex = 13;
            this.btnEsc.Text = "(Esc) Exit";
            this.btnEsc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEsc.UseVisualStyleBackColor = false;
            this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
            // 
            // btnF12
            // 
            this.btnF12.BackColor = System.Drawing.Color.Tan;
            this.btnF12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnF12.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnF12.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(0)))), ((int)(((byte)(171)))));
            this.btnF12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
            this.btnF12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaGreen;
            this.btnF12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF12.ForeColor = System.Drawing.Color.White;
            this.btnF12.Image = ((System.Drawing.Image)(resources.GetObject("btnF12.Image")));
            this.btnF12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnF12.Location = new System.Drawing.Point(956, 1);
            this.btnF12.Name = "btnF12";
            this.btnF12.Size = new System.Drawing.Size(168, 34);
            this.btnF12.TabIndex = 14;
            this.btnF12.Text = "(F12) Print Summary";
            this.btnF12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnF12.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Khaki;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customer,
            this.terms,
            this.duedate,
            this.outstandingbalance,
            this.current,
            this.thirties,
            this.sixties,
            this.nineties,
            this.overninty});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.Location = new System.Drawing.Point(1, 36);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1218, 445);
            this.dataGridView1.TabIndex = 20;
            // 
            // customer
            // 
            this.customer.HeaderText = "Customer";
            this.customer.Name = "customer";
            this.customer.ReadOnly = true;
            this.customer.Width = 260;
            // 
            // terms
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.terms.DefaultCellStyle = dataGridViewCellStyle2;
            this.terms.HeaderText = "Terms";
            this.terms.Name = "terms";
            this.terms.ReadOnly = true;
            this.terms.Width = 50;
            // 
            // duedate
            // 
            this.duedate.HeaderText = "Due Date";
            this.duedate.Name = "duedate";
            this.duedate.ReadOnly = true;
            this.duedate.Width = 115;
            // 
            // outstandingbalance
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.outstandingbalance.DefaultCellStyle = dataGridViewCellStyle3;
            this.outstandingbalance.HeaderText = "Outstanding Balance";
            this.outstandingbalance.Name = "outstandingbalance";
            this.outstandingbalance.ReadOnly = true;
            this.outstandingbalance.Width = 150;
            // 
            // current
            // 
            this.current.HeaderText = "Current";
            this.current.Name = "current";
            this.current.ReadOnly = true;
            this.current.Width = 120;
            // 
            // thirties
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.thirties.DefaultCellStyle = dataGridViewCellStyle4;
            this.thirties.HeaderText = "1-30";
            this.thirties.Name = "thirties";
            this.thirties.ReadOnly = true;
            this.thirties.Width = 120;
            // 
            // sixties
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sixties.DefaultCellStyle = dataGridViewCellStyle5;
            this.sixties.HeaderText = "31-60";
            this.sixties.Name = "sixties";
            this.sixties.ReadOnly = true;
            this.sixties.Width = 120;
            // 
            // nineties
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nineties.DefaultCellStyle = dataGridViewCellStyle6;
            this.nineties.HeaderText = "61-90";
            this.nineties.Name = "nineties";
            this.nineties.ReadOnly = true;
            this.nineties.Width = 120;
            // 
            // overninty
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.overninty.DefaultCellStyle = dataGridViewCellStyle7;
            this.overninty.HeaderText = "91+";
            this.overninty.Name = "overninty";
            this.overninty.ReadOnly = true;
            this.overninty.Width = 120;
            // 
            // lbl30
            // 
            this.lbl30.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl30.ForeColor = System.Drawing.Color.White;
            this.lbl30.Location = new System.Drawing.Point(740, 485);
            this.lbl30.Name = "lbl30";
            this.lbl30.Size = new System.Drawing.Size(114, 18);
            this.lbl30.TabIndex = 21;
            this.lbl30.Text = "0.00";
            this.lbl30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl60
            // 
            this.lbl60.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl60.ForeColor = System.Drawing.Color.White;
            this.lbl60.Location = new System.Drawing.Point(860, 485);
            this.lbl60.Name = "lbl60";
            this.lbl60.Size = new System.Drawing.Size(114, 18);
            this.lbl60.TabIndex = 22;
            this.lbl60.Text = "0.00";
            this.lbl60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl90
            // 
            this.lbl90.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl90.ForeColor = System.Drawing.Color.White;
            this.lbl90.Location = new System.Drawing.Point(978, 485);
            this.lbl90.Name = "lbl90";
            this.lbl90.Size = new System.Drawing.Size(114, 18);
            this.lbl90.TabIndex = 23;
            this.lbl90.Text = "0.00";
            this.lbl90.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOver
            // 
            this.lblOver.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOver.ForeColor = System.Drawing.Color.White;
            this.lblOver.Location = new System.Drawing.Point(1099, 485);
            this.lblOver.Name = "lblOver";
            this.lblOver.Size = new System.Drawing.Size(114, 18);
            this.lblOver.TabIndex = 24;
            this.lblOver.Text = "0.00";
            this.lblOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrent
            // 
            this.lblCurrent.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrent.ForeColor = System.Drawing.Color.White;
            this.lblCurrent.Location = new System.Drawing.Point(620, 485);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(114, 18);
            this.lblCurrent.TabIndex = 25;
            this.lblCurrent.Text = "0.00";
            this.lblCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOutstanding
            // 
            this.lblOutstanding.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutstanding.ForeColor = System.Drawing.Color.White;
            this.lblOutstanding.Location = new System.Drawing.Point(468, 485);
            this.lblOutstanding.Name = "lblOutstanding";
            this.lblOutstanding.Size = new System.Drawing.Size(146, 18);
            this.lblOutstanding.TabIndex = 26;
            this.lblOutstanding.Text = "0.00";
            this.lblOutstanding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(263, 484);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Total Accounts Receivable Aging";
            // 
            // mdiSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(1216, 505);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOutstanding);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.lblOver);
            this.Controls.Add(this.lbl90);
            this.Controls.Add(this.lbl60);
            this.Controls.Add(this.lbl30);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnF12);
            this.Controls.Add(this.btnEsc);
            this.Controls.Add(this.dtSelect);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mdiSummary";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Summary";
            this.Load += new System.EventHandler(this.mdiSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtSelect;
        private System.Windows.Forms.Button btnEsc;
        private System.Windows.Forms.Button btnF12;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn terms;
        private System.Windows.Forms.DataGridViewTextBoxColumn duedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn outstandingbalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn current;
        private System.Windows.Forms.DataGridViewTextBoxColumn thirties;
        private System.Windows.Forms.DataGridViewTextBoxColumn sixties;
        private System.Windows.Forms.DataGridViewTextBoxColumn nineties;
        private System.Windows.Forms.DataGridViewTextBoxColumn overninty;
        private System.Windows.Forms.Label lbl30;
        private System.Windows.Forms.Label lbl60;
        private System.Windows.Forms.Label lbl90;
        private System.Windows.Forms.Label lblOver;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblOutstanding;
        private System.Windows.Forms.Label label1;
    }
}