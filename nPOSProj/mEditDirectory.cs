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
    public partial class mEditDirectory : Form
    {
        private VO.CustomersVO customers;
        private String custcode;
        private bool activity;

        public bool Activity
        {
            get { return activity; }
            set { activity = value; }
        }

        public String Custcode
        {
            get { return custcode; }
            set { custcode = value; }
        }
        private String company;

        public String Company
        {
            get { return company; }
            set { company = value; }
        }
        private String first;

        public String First
        {
            get { return first; }
            set { first = value; }
        }
        private String middle;

        public String Middle
        {
            get { return middle; }
            set { middle = value; }
        }
        private String last;

        public String Last
        {
            get { return last; }
            set { last = value; }
        }
        public mEditDirectory()
        {
            InitializeComponent();
        }

        private void mEditDirectory_Load(object sender, EventArgs e)
        {
            customers = new VO.CustomersVO();
            customers.Custcode = Custcode;
            String[] getScam = customers.ReadEdits();
            txtBoxCustomerCode.Text = getScam[0].ToString();
            txtBoxCompany.Text = getScam[1].ToString();
            txtBoxFirst.Text = getScam[2].ToString();
            txtBoxMiddle.Text = getScam[3].ToString();
            txtBoxLast.Text = getScam[4].ToString();
            txtBoxEmail.Text = getScam[5].ToString();
            txtBoxPhone.Text = getScam[6].ToString();
            txtBoxAddress.Text = getScam[7].ToString();
            txtBoxCity.Text = getScam[8].ToString();
            txtBoxProv.Text = getScam[9].ToString();
            txtBoxZip.Text = getScam[10].ToString();
        }

        private void txtBoxCompany_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCompany.Text != "")
            {
                this.Text = txtBoxCompany.Text;
            }
            else
            {
                this.Text = "";
            }
            if (txtBoxCompany.Text != "" && txtBoxFirst.Text != "" && txtBoxMiddle.Text != "" && txtBoxLast.Text != "" && txtBoxPhone.Text != "" && txtBoxAddress.Text != "" && txtBoxCity.Text != "" && txtBoxProv.Text != "")
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void txtBoxFirst_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCompany.Text != "" && txtBoxFirst.Text != "" && txtBoxMiddle.Text != "" && txtBoxLast.Text != "" && txtBoxPhone.Text != "" && txtBoxAddress.Text != "" && txtBoxCity.Text != "" && txtBoxProv.Text != "")
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void txtBoxMiddle_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCompany.Text != "" && txtBoxFirst.Text != "" && txtBoxMiddle.Text != "" && txtBoxLast.Text != "" && txtBoxPhone.Text != "" && txtBoxAddress.Text != "" && txtBoxCity.Text != "" && txtBoxProv.Text != "")
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void txtBoxLast_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCompany.Text != "" && txtBoxFirst.Text != "" && txtBoxMiddle.Text != "" && txtBoxLast.Text != "" && txtBoxPhone.Text != "" && txtBoxAddress.Text != "" && txtBoxCity.Text != "" && txtBoxProv.Text != "")
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void txtBoxPhone_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCompany.Text != "" && txtBoxFirst.Text != "" && txtBoxMiddle.Text != "" && txtBoxLast.Text != "" && txtBoxPhone.Text != "" && txtBoxAddress.Text != "" && txtBoxCity.Text != "" && txtBoxProv.Text != "")
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void txtBoxAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCompany.Text != "" && txtBoxFirst.Text != "" && txtBoxMiddle.Text != "" && txtBoxLast.Text != "" && txtBoxPhone.Text != "" && txtBoxAddress.Text != "" && txtBoxCity.Text != "" && txtBoxProv.Text != "")
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void txtBoxCity_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCompany.Text != "" && txtBoxFirst.Text != "" && txtBoxMiddle.Text != "" && txtBoxLast.Text != "" && txtBoxPhone.Text != "" && txtBoxAddress.Text != "" && txtBoxCity.Text != "" && txtBoxProv.Text != "")
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void txtBoxProv_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCompany.Text != "" && txtBoxFirst.Text != "" && txtBoxMiddle.Text != "" && txtBoxLast.Text != "" && txtBoxPhone.Text != "" && txtBoxAddress.Text != "" && txtBoxCity.Text != "" && txtBoxProv.Text != "")
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            customers = new VO.CustomersVO();
            DialogResult dr = MessageBox.Show("Do you wish to Continue Updating?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                Activity = true;
                customers.Companyname = txtBoxCompany.Text;
                customers.Firstname = txtBoxFirst.Text;
                customers.Middlename = txtBoxMiddle.Text;
                customers.Lastname = txtBoxLast.Text;
                customers.Email = txtBoxEmail.Text;
                customers.Phone_no = txtBoxPhone.Text;
                customers.Address = txtBoxAddress.Text;
                customers.City = txtBoxCity.Text;
                customers.Province = txtBoxProv.Text;
                customers.Zip_code = txtBoxZip.Text;
                customers.Custcode = txtBoxCustomerCode.Text;
                Company = txtBoxCompany.Text;
                First = txtBoxFirst.Text;
                Middle = txtBoxMiddle.Text;
                Last = txtBoxLast.Text;
                customers.UpdateCustomers();
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Activity = false;
            this.Close();
        }
    }
}