using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
            mskTIN.Text = getScam[11].ToString();
            mskSSS.Text = getScam[12].ToString();
            txtBoxCreditLimit.Text = Convert.ToDouble(getScam[13]).ToString("#,###,##0.00");
            if (getScam[14].ToString() == "30")
            {
                cBoxNetDays.Text = "1-30";
            }
            if (getScam[14].ToString() == "60")
            {
                cBoxNetDays.Text = "31-60";
            }
            if (getScam[14].ToString() == "90")
            {
                cBoxNetDays.Text = "61-90";
            }
            if (getScam[14].ToString() == "120")
            {
                cBoxNetDays.Text = "91+";
            }
            if (getScam[15].ToString() == "1")
            {
                cBoxSuspended.Checked = true;
            }
            else
            {
                cBoxSuspended.Checked = false;
            }
            String x = Convert.ToDouble(getScam[16]).ToString("#0.##%");
            txtBoxIR.Text = x.Replace("%", "");
            dateTimePicker1.Text = Convert.ToDateTime(getScam[17]).ToString("MM/dd/yyyy");
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
            try
            {
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
                    customers.Tin = mskTIN.Text;
                    customers.Sss = mskSSS.Text;
                    if (txtBoxCreditLimit.Text != "")
                    {
                        customers.Creditlimit = Convert.ToDouble(txtBoxCreditLimit.Text);
                    }
                    else
                    {
                        customers.Creditlimit = 0;
                    }
                    if (cBoxNetDays.Text == "1-30")
                    {
                        customers.Netdays = 30;
                    }
                    if (cBoxNetDays.Text == "31-60")
                    {
                        customers.Netdays = 60;
                    }
                    if (cBoxNetDays.Text == "61-90")
                    {
                        customers.Netdays = 90;
                    }
                    if (cBoxNetDays.Text == "91+")
                    {
                        customers.Netdays = 120;
                    }
                    if (cBoxSuspended.Checked == true)
                    {
                        customers.Is_suspended = 1;
                    }
                    else
                    {
                        customers.Is_suspended = 0;
                    }
                    if (txtBoxIR.Text != "")
                    {
                        customers.Interest_rate = Convert.ToDouble(txtBoxIR.Text);
                    }
                    else
                    {
                        customers.Interest_rate = 0;
                    }
                    customers.Due_date = dateTimePicker1.Text;
                    customers.Custcode = txtBoxCustomerCode.Text;
                    Company = txtBoxCompany.Text;
                    First = txtBoxFirst.Text;
                    Middle = txtBoxMiddle.Text;
                    Last = txtBoxLast.Text;
                    customers.UpdateCustomers();
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check your Input and Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Activity = false;
            this.Close();
        }

        private void txtBoxCreditLimit_TextChanged(object sender, EventArgs e)
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

        private void cBoxNetDays_SelectedIndexChanged(object sender, EventArgs e)
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

        private void txtBoxIR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}