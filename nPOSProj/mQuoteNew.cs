using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace nPOSProj
{
    public partial class mQuoteNew : Form
    {
        private VO.OrderVO ordervo = new VO.OrderVO();
        AutoCompleteStringCollection collect = new AutoCompleteStringCollection();
        private String custcode;

        public String Custcode
        {
            get { return custcode; }
            set { custcode = value; }
        }
        private Boolean newQuote;

        public Boolean NewQuote
        {
            get { return newQuote; }
            set { newQuote = value; }
        }
        private String address;

        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        private String company;

        public String Company
        {
            get { return company; }
            set { company = value; }
        }
        public mQuoteNew()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            if (keyData == Keys.F10 && btnProceed.Enabled == true)
            {
                trigger();
            }
            if (keyData == Keys.F1)
            {
                LoadData();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void LoadData()
        {
            ordervo = new VO.OrderVO();
            String[,] getData = ordervo.ReadCompanySearchQuotex();
            try
            {
                collect.Clear();
                for (int n = 0; n < getData.GetLength(1); n++)
                {
                    collect.Add(getData[0, n].ToString());
                }
                txtBoxCompany.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBoxCompany.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBoxCompany.AutoCompleteCustomSource = collect;
                txtBoxCompany.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }

        private void trigger()
        {
            DialogResult dlg = MessageBox.Show("Do you wish to Proceed for Quotation?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                Company = txtBoxCompany.Text;
                Address = txtBoxAddress.Text;
                NewQuote = true;
                ordervo.Quote_custcode = Custcode;
                ordervo.Quote_customer = Company;
                ordervo.Quote_address = Address;
                ordervo.NewQuotation();
                this.Close();
            }
        }

        private void btnEscape_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mQuoteNew_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            trigger();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtBoxCompany_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ordervo.Company = txtBoxCompany.Text;
                    txtBoxAddress.Text = ordervo.askAddress();
                    Custcode = ordervo.askCustomerCode();
                    txtBoxAddress.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error 4621", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBoxCompany_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCompany.Text == "")
            {
                txtBoxAddress.Clear();
            }
            if (txtBoxCompany.Text != "" && txtBoxAddress.Text != "")
            {
                btnProceed.Enabled = true;
            }
            else
                btnProceed.Enabled = false;
        }

        private void txtBoxAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCompany.Text != "" && txtBoxAddress.Text != "")
            {
                btnProceed.Enabled = true;
            }
            else
                btnProceed.Enabled = false;
        }
    }
}