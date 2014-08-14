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
    public partial class mCrmBasic : Form
    {
        private VO.CustomersVO customer;
        public mCrmBasic()
        {
            InitializeComponent();
        }
        private String custcode;

        public String Custcode
        {
            get { return custcode; }
            set { custcode = value; }
        }

        private void LoadDefualt()
        {
            try
            {
                customer = new VO.CustomersVO();
                customer.Custcode = Custcode;
                customer.Today = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                String[,] grabData = customer.ReadPaymentsDefualt();
                dataGridView1.Rows.Clear();
                for (int x = 0; x < grabData.GetLength(1); x++)
                {
                    dataGridView1.Rows.Add(Convert.ToDateTime(grabData[0, x]).ToString("M/dd/yyyy"), Convert.ToDateTime(grabData[1, x]).ToString("h:mm:ss tt"), Convert.ToDouble(grabData[2, x]));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mCrmBasic_Load(object sender, EventArgs e)
        {
            LoadDefualt();
        }

        private void chkBoxLoadAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxLoadAll.Checked == true)
            {
                try
                {
                    customer = new VO.CustomersVO();
                    customer.Custcode = Custcode;
                    String[,] grabData = customer.ReadPaymentsAll();
                    dataGridView1.Rows.Clear();
                    for (int x = 0; x < grabData.GetLength(1); x++)
                    {
                        dataGridView1.Rows.Add(Convert.ToDateTime(grabData[0, x]).ToString("M/dd/yyyy"), Convert.ToDateTime(grabData[1, x]).ToString("h:mm:ss tt"), Convert.ToDouble(grabData[2, x]));
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                LoadDefualt();
            }
        }

        private void from_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                customer = new VO.CustomersVO();
                customer.Custcode = Custcode;
                String a = Convert.ToDateTime(dfrom.Text).ToString("yyyy-MM-dd");
                String b = Convert.ToDateTime(dto.Text).ToString("yyyy-MM-dd");
                customer.From = Convert.ToDateTime(a);
                customer.To = Convert.ToDateTime(b);
                String[,] grabData = customer.ReadPaymentsDateFilter();
                dataGridView1.Rows.Clear();
                for (int x = 0; x < grabData.GetLength(1); x++)
                {
                    dataGridView1.Rows.Add(Convert.ToDateTime(grabData[0, x]).ToString("M/dd/yyyy"), Convert.ToDateTime(grabData[1, x]).ToString("h:mm:ss tt"), Convert.ToDouble(grabData[2, x]));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void to_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                customer = new VO.CustomersVO();
                customer.Custcode = Custcode;
                String a = Convert.ToDateTime(dfrom.Text).ToString("yyyy-MM-dd");
                String b = Convert.ToDateTime(dto.Text).ToString("yyyy-MM-dd");
                customer.From = Convert.ToDateTime(a);
                customer.To = Convert.ToDateTime(b);
                String[,] grabData = customer.ReadPaymentsDateFilter();
                dataGridView1.Rows.Clear();
                for (int x = 0; x < grabData.GetLength(1); x++)
                {
                    dataGridView1.Rows.Add(Convert.ToDateTime(grabData[0, x]).ToString("M/dd/yyyy"), Convert.ToDateTime(grabData[1, x]).ToString("h:mm:ss tt"), Convert.ToDouble(grabData[2, x]));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}