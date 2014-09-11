using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace nPOSProj
{
    public partial class mdiQuotation : Form
    {
        AutoCompleteStringCollection collect = new AutoCompleteStringCollection();
        AutoCompleteStringCollection collect1 = new AutoCompleteStringCollection();
        private MySqlConnection con = new MySqlConnection();
        private Conf.dbs dbcon = new Conf.dbs();
        public mdiQuotation()
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
            if (keyData == Keys.F1 && btnF1.Enabled == true)
            {
                gotoNewQuote();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void autoCompleteItem()
        {
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT stock_name AS sc FROM inventory_stocks ORDER BY stock_name ASC";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                        collect.Add(rdr["sc"].ToString());
                }
                rdr.Close();
                txtBoxDescription.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBoxDescription.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBoxDescription.AutoCompleteCustomSource = collect;
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }
        private void autoCompleteKits()
        {
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT kit_name AS sc FROM inventory_items WHERE is_kit = 1 ORDER BY kit_name ASC";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                        collect1.Add(rdr["sc"].ToString());
                }
                rdr.Close();
                txtBoxDescription.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBoxDescription.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBoxDescription.AutoCompleteCustomSource = collect1;
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }
        private void lockcontrols()
        {
            txtBoxEAN.ReadOnly = true;
            txtBoxDescription.ReadOnly = true;
            //
            cBoxKits.Enabled = false;
            btnClearController.Enabled = false;
            dataGridView1.Enabled = false;
        }
        private void unlockcontrols()
        {
            txtBoxEAN.ReadOnly = false;
            txtBoxDescription.ReadOnly = false;
            //
            cBoxKits.Enabled = true;
            btnClearController.Enabled = true;
            dataGridView1.Enabled = true;
            btnF1.Enabled = false;
            btnF2A.Enabled = true;
            btnF4.Enabled = true;
            txtBoxDescription.Focus();
        }
        private void checkRowCount()
        {
            if (dataGridView1.Rows.Count != 0)
            {
                btnF5.Enabled = false;
                btnF4.Enabled = true;
            }
            else
            {
                btnF5.Enabled = true;
                btnF4.Enabled = false;
            }
        }
        private void gotoNewQuote()
        {
            using (mQuoteNew newquote = new mQuoteNew())
            {
                newquote.ShowDialog();
                if (newquote.NewQuote != false)
                {
                    rdCustomerCode.Text = newquote.Custcode;
                    rdCompany.Text = newquote.Company;
                    rdAddress.Text = newquote.Address;
                }
            }
        }
        private void btnESC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnF1_Click(object sender, EventArgs e)
        {
            gotoNewQuote();
        }
    }
}