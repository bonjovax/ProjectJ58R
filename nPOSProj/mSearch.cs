using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace nPOSProj
{
    public partial class mSearch : Form
    {
        private MySqlConnection con = new MySqlConnection();
        private Conf.dbs dbcon = new Conf.dbs();
        AutoCompleteStringCollection collect = new AutoCompleteStringCollection();
        AutoCompleteStringCollection collect1 = new AutoCompleteStringCollection();
        private VO.PurchaseOrderVO po = new VO.PurchaseOrderVO();
        public mSearch()
        {
            InitializeComponent();
        }
        public String supcode
        {
            get { return txtBoxSupplierCode.Text; }
        }
        private void autoCompleteSupplierCode()
        {
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT supplier_code FROM inventory_supplier ORDER BY supplier_code ASC";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                        collect.Add(rdr["supplier_code"].ToString());
                }
                rdr.Close();
                txtBoxSupplierCode.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBoxSupplierCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBoxSupplierCode.AutoCompleteCustomSource = collect;
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }
        private void autoCompleteSupplierName()
        {
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT supplier_name FROM inventory_supplier ORDER BY supplier_name ASC";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                        collect1.Add(rdr["supplier_name"].ToString());
                }
                rdr.Close();
                cBoxSupplier.AutoCompleteMode = AutoCompleteMode.Suggest;
                cBoxSupplier.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cBoxSupplier.AutoCompleteCustomSource = collect1;
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }

        private void txtBoxSupplierCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                po.supplier_code = txtBoxSupplierCode.Text;
                cBoxSupplier.Text = po.askSupplierName();
            }
        }

        private void mSearch_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'npos_dbDataSet.inventory_supplier' table. You can move, or remove it, as needed.
            this.inventory_supplierTableAdapter.Fill(this.npos_dbDataSet.inventory_supplier);
            autoCompleteSupplierCode();
            autoCompleteSupplierName();
            cBoxSupplier.Text = "";
        }

        private void txtBoxSupplierCode_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxSupplierCode.Text != "" && cBoxSupplier.Text != "")
            {
                btnSearch.Enabled = true;
            }
            else
                btnSearch.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cBoxSupplier_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxSupplierCode.Text != "" && cBoxSupplier.Text != "")
            {
                btnSearch.Enabled = true;
            }
            else
                btnSearch.Enabled = false;
        }

        private void cBoxSupplier_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                po.supplier_name = cBoxSupplier.Text;
                txtBoxSupplierCode.Text = po.askSupplierCode();
            }
        }

        private void cBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            po.supplier_name = cBoxSupplier.Text;
            txtBoxSupplierCode.Text = po.askSupplierCode();
        }
    }
}