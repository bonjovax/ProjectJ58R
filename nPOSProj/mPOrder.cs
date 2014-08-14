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
    public partial class mPOrder : Form
    {
        private MySqlConnection con = new MySqlConnection();
        private Conf.dbs dbcon = new Conf.dbs();
        private VO.PurchaseOrderVO po = new VO.PurchaseOrderVO();
        AutoCompleteStringCollection collect = new AutoCompleteStringCollection();
        AutoCompleteStringCollection collect1 = new AutoCompleteStringCollection();
        //
        AutoCompleteStringCollection collect2 = new AutoCompleteStringCollection();
        AutoCompleteStringCollection collect3 = new AutoCompleteStringCollection();
        private String supplier_code;
        private String old_stock_code;
        public mPOrder()
        {
            InitializeComponent();
        }
        public DateTime PurchaseOrderDate
        {
            get { return dt.Value; }  // your PO date picker control
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
                txtBoxSupplierName.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBoxSupplierName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBoxSupplierName.AutoCompleteCustomSource = collect1;
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }
        //
        private void autoCompleteStockCode()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT stock_code FROM inventory_stocks WHERE supplier_code = ?supplier_code ORDER BY stock_code ASC";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("?supplier_code", txtBoxSupplierCode.Text);
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                        collect2.Add(rdr["stock_code"].ToString());
                }
                rdr.Close();
                txtBoxStockCode.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBoxStockCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBoxStockCode.AutoCompleteCustomSource = collect2;
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }
        private void autoCompleteStockName()
        {
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT stock_name FROM inventory_stocks WHERE supplier_code = ?supplier_code ORDER BY stock_code ASC";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("?supplier_code", txtBoxSupplierCode.Text);
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                        collect3.Add(rdr["stock_name"].ToString());
                }
                rdr.Close();
                txtBoxParticulars.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBoxParticulars.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBoxParticulars.AutoCompleteCustomSource = collect3;
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }
        private void CheckIfStockCodePrevent()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT DISTINCT order_suppliers_itemno FROM po_order_list WHERE order_suppliers_itemno = ?a AND po_no = ?b";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", txtBoxStockCode.Text);
                cmd.Parameters.AddWithValue("?b", rdPOno.Text);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    supplier_code = rdr["order_suppliers_itemno"].ToString();
                }
                else
                {
                    supplier_code = "";
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }
        
        private void mPOrder_Load(object sender, EventArgs e)
        {
            String userName = frmLogin.User.user_name;
            rdOrderedBy.Text = userName;
            rdPOno.Text = po.askPOno().ToString();
            txtBoxSupplierCode.Focus();
            autoCompleteSupplierCode();
            autoCompleteSupplierName();
        }

        private void unlockBox()
        {
            txtBoxRemarks.ReadOnly = false;
            cBoxWarehouse.Enabled = true;
            cBoxCourier.Enabled = true;
            //
            txtBoxStockCode.ReadOnly = false;
            txtBoxParticulars.ReadOnly = false;
        }
        private void lockBox()
        {
            txtBoxRemarks.ReadOnly = true;
            cBoxWarehouse.Enabled = false;
            cBoxCourier.Enabled = false;
            //
            txtBoxStockCode.ReadOnly = true;
            txtBoxParticulars.ReadOnly = true;
        }

        private void txtBoxSupplierCode_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxSupplierCode.Text == "")
            {
                txtBoxSupplierName.Clear();
                btnProceed.Enabled = false;
                lAddress.Text = "";
            }
            else
            {
                btnProceed.Enabled = false;
            }
        }

        private void txtBoxSupplierName_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxSupplierName.Text == "")
            {
                txtBoxSupplierCode.Clear();
                btnProceed.Enabled = false;
            }
            else
            {
                btnProceed.Enabled = false;
            }
        }

        public void checkifTheSame()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT * FROM inventory_supplier ";
            query += "WHERE supplier_code = ?supplier_code AND supplier_name = ?supplier_name";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?supplier_name", txtBoxSupplierName.Text);
                cmd.Parameters.AddWithValue("?supplier_code", txtBoxSupplierCode.Text);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    btnProceed.Enabled = true;
                }
                else
                {
                    btnProceed.Enabled = false;
                    txtBoxQty.Clear();
                }
            }
            catch (Exception)
            {
                btnProceed.Enabled = false;
                txtBoxQty.Clear();
            }
        }
        public void checkifTheSameStockToQty()
        {
            Double stock_cost_price;
            String UOM;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT * FROM inventory_stocks ";
            query += "WHERE stock_code = ?stock_code AND stock_name = ?stock_name";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?stock_code", txtBoxStockCode.Text);
                cmd.Parameters.AddWithValue("?stock_name", txtBoxParticulars.Text);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    stock_cost_price = Convert.ToDouble(rdr["stock_cost_price"]);
                    UOM = rdr["stock_uom"].ToString();
                    txtBoxUnitPrice.Text = stock_cost_price.ToString("#,###,##0.00");
                    txtBoxUOM.Text = UOM;
                    txtBoxQty.ReadOnly = false;
                }
                else
                {
                    txtBoxQty.ReadOnly = true;
                    txtBoxQty.Text = "0";
                    txtBoxUnitPrice.Text = "0.00";
                    txtBoxUOM.Clear();
                }
                con.Close();
            }
            catch (Exception)
            {
                txtBoxQty.ReadOnly = true;
                txtBoxQty.Text = "0";
                txtBoxUnitPrice.Text = "0.00";
                txtBoxUOM.Clear();
            }
        }
        public void toAddress()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT supplier_address FROM inventory_supplier ";
            query += "WHERE supplier_code = ?supplier_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?supplier_code", txtBoxSupplierCode.Text);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    lAddress.Text = rdr["supplier_address"].ToString();
                }
                else
                    lAddress.Text = "";
            }
            catch (Exception)
            {
                btnProceed.Enabled = false;
            }
        }

        private void txtBoxSupplierCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                po.supplier_code = txtBoxSupplierCode.Text;
                txtBoxSupplierName.Text = po.askSupplierName();
                checkifTheSame();
                toAddress();
            }
        }

        private void txtBoxSupplierName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                po.supplier_name = txtBoxSupplierName.Text;
                txtBoxSupplierCode.Text = po.askSupplierCode();
                checkifTheSame();
            }
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Do You Wish To Proceed?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                po.po_no = Convert.ToInt32(rdPOno.Text);
                po.po_date = Convert.ToDateTime(dt.Text).ToString("yyyy-MM-dd");
                po.po_time = DateTime.Now.ToLongTimeString();
                po.supplier_code = txtBoxSupplierCode.Text;
                po.user_name = rdOrderedBy.Text;
                po.PO_Issue();
                btnProceed.Visible = false;
                unlockBox();
                btnCancel.Enabled = true;
                txtBoxStockCode.Focus();
                txtBoxSupplierCode.ReadOnly = true;
                txtBoxSupplierName.ReadOnly = true;
                dt.Enabled = false;
                //
                autoCompleteStockCode();
                autoCompleteStockName();
                // TODO: This line of code loads data into the 'npos_dbDataSet.inventory_warehouse' table. You can move, or remove it, as needed.
                this.inventory_warehouseTableAdapter.Fill(this.npos_dbDataSet.inventory_warehouse);
            }
        }

        private void mPOrder_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void txtBoxStockCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                po.stock_code = txtBoxStockCode.Text;
                po.supplier_code = txtBoxSupplierCode.Text;
                txtBoxParticulars.Text = po.askStockName();
                txtBoxUnitPrice.Text = po.askStockPriceStockCode().ToString("#,###,##0.00");
                txtBoxUOM.Text = po.askUOM();
                txtBoxQty.Focus();
                txtBoxUQTY.ReadOnly = false;
                txtBoxUQTY.Focus();
            }
        }

        private void txtBoxParticulars_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                po.stock_name = txtBoxParticulars.Text;
                po.supplier_code = txtBoxSupplierCode.Text;
                txtBoxStockCode.Text = po.askStockCode();
                txtBoxUnitPrice.Text = po.askStockPriceStockName().ToString("#,###,##0.00");
                txtBoxUOM.Text = po.askUOM_N();
                txtBoxQty.Focus();
                txtBoxUQTY.ReadOnly = false;
                txtBoxUQTY.Focus();
            }
        }

        private void txtBoxStockCode_TextChanged(object sender, EventArgs e)
        {
            checkifTheSameStockToQty();
            CheckIfStockCodePrevent();
            if (txtBoxStockCode.Text == "")
            {
                txtBoxQty.Text = "0";
                txtBoxUnitPrice.Text = "0.00";
                txtBoxParticulars.Clear();
                txtBoxUOM.Clear();
                txtBoxStockCode.Focus();
            }
            btnAdd.Enabled = false;
        }

        private void txtBoxParticulars_TextChanged(object sender, EventArgs e)
        {
            checkifTheSameStockToQty();
            if (txtBoxParticulars.Text == "")
            {
                txtBoxQty.Text = "0";
                txtBoxUnitPrice.Text = "0.00";
                txtBoxUOM.Clear();
                txtBoxStockCode.Clear();
                txtBoxStockCode.Focus();
            }
            btnAdd.Enabled = false;
        }

        private void txtBoxQty_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxStockCode.Text == supplier_code && txtBoxStockCode.Text == dataGridView1.Rows[0].Cells[1].Value.ToString())
            {
                btnAdd.Enabled = false;
            }
            else
                btnAdd.Enabled = true;
            Double totalPrice;
            try
            {
                totalPrice = Convert.ToDouble(txtBoxUnitPrice.Text) * Convert.ToDouble(txtBoxQty.Text);
                rdTotal.Text = totalPrice.ToString("#,###,##0.00");
            }
            catch (Exception)
            {
                txtBoxQty.Text = "0";
                rdTotal.Text = "0.00";
                btnAdd.Enabled = false;
            }
        }

        private void txtBoxUnitPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxUnitPrice.Text == "0.00")
                rdTotal.Text = "0.00";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CheckIfStockCodePrevent();
                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    for (int col = 0; col < dataGridView1.Columns.Count; col++)
                    {
                        if (dataGridView1.Rows[row].Cells[col].Value != null &&
                          dataGridView1.Rows[row].Cells[col].Value.Equals(txtBoxStockCode.Text))
                        {
                            MessageBox.Show("Stock is already Existed in the List!", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
                if (txtBoxStockCode.Text == supplier_code && txtBoxStockCode.Text == dataGridView1.SelectedRows[0].Cells[1].Value.ToString())
                {
                    MessageBox.Show("Stock is already Existed in the List!", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    po.order_quantity = Convert.ToInt32(txtBoxQty.Text);
                    po.stock_code = txtBoxStockCode.Text;
                    po.order_uom = txtBoxUOM.Text;
                    po.stock_name = txtBoxParticulars.Text;
                    po.order_unitcost = Convert.ToDouble(txtBoxUnitPrice.Text);
                    po.order_amount = Convert.ToDouble(rdTotal.Text);
                    po.OrderItemsToPO();
                    dataGridView1.Rows.Add(txtBoxQty.Text, txtBoxStockCode.Text, txtBoxUOM.Text, txtBoxParticulars.Text, txtBoxUnitPrice.Text, rdTotal.Text);
                    txtBoxParticulars.Clear();
                    txtBoxStockCode.Clear();
                    txtBoxStockCode.Focus();
                    btnAdd.Enabled = false;
                    Double sum = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {
                        sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                    }
                    po.po_total_amt = sum;
                    po.updateTotalAmountMain();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check Server If Active", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cBoxWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxWarehouse.Text != "" && cBoxCourier.Text != "")
            {
                btnSave.Enabled = true;
            }
            else
                btnSave.Enabled = false;
        }

        private void cBoxCourier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxWarehouse.Text != "" && cBoxCourier.Text != "")
            {
                btnSave.Enabled = true;
            }
            else
                btnSave.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CheckIfStockCodePrevent();
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            txtBoxStockCode.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            old_stock_code = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtBoxUOM.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtBoxParticulars.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtBoxUQTY.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            btnAdd.Enabled = false;
            txtBoxQty.Visible = false;
            txtBoxUQTY.Visible = true;
            txtBoxUQTY.ReadOnly = false;
            //New
            txtBoxStockCode.ReadOnly = true;
            txtBoxParticulars.ReadOnly = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //New
                txtBoxStockCode.ReadOnly = false;
                txtBoxParticulars.ReadOnly = false;
                CheckIfStockCodePrevent();
                dataGridView1.SelectedRows[0].Cells[0].Value = txtBoxUQTY.Text;
                dataGridView1.SelectedRows[0].Cells[1].Value = txtBoxStockCode.Text;
                dataGridView1.SelectedRows[0].Cells[2].Value = txtBoxUOM.Text;
                dataGridView1.SelectedRows[0].Cells[3].Value = txtBoxParticulars.Text;
                dataGridView1.SelectedRows[0].Cells[4].Value = txtBoxUnitPrice.Text;
                dataGridView1.SelectedRows[0].Cells[5].Value = rdTotal.Text;
                po.po_no = Convert.ToInt32(rdPOno.Text);
                po.order_quantity = Convert.ToInt32(txtBoxUQTY.Text);
                po.order_uom = txtBoxUOM.Text;
                po.stock_code = txtBoxStockCode.Text;
                po.old_stock_code = old_stock_code;
                po.stock_name = txtBoxParticulars.Text;
                po.order_unitcost = Convert.ToDouble(txtBoxUnitPrice.Text);
                po.order_amount = Convert.ToDouble(rdTotal.Text);
                po.supplier_code = txtBoxSupplierCode.Text;
                po.UpdateOrderItemsToPO();
                Double sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                }
                po.po_total_amt = sum;
                po.updateTotalAmountMain();
                btnAdd.Enabled = false;
                txtBoxParticulars.Clear();
                txtBoxStockCode.Clear();
                txtBoxStockCode.Focus();
                txtBoxUQTY.Visible = false;
                txtBoxQty.Visible = true;
                txtBoxUQTY.Text = "0";
                txtBoxUQTY.ReadOnly = true;
                btnUpdate.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("You have no available Data on the DataView for update. Or Check Server If Active", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            po.po_no = Convert.ToInt32(rdPOno.Text);
            po.supplier_code = txtBoxSupplierCode.Text;
            po.stock_code = txtBoxStockCode.Text;
            po.RemoveOrderItemsInPO();
            po.updateTotalAmountMain();
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            Double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
            }
            po.po_total_amt = sum;
            po.updateTotalAmountMain();
            btnDelete.Enabled = false;
        }

        private void txtBoxUQTY_TextChanged(object sender, EventArgs e)
        {
            Double totalPrice;
            try
            {
                if (txtBoxUQTY.Text != "")
                {
                    btnUpdate.Enabled = true;
                    totalPrice = Convert.ToDouble(txtBoxUnitPrice.Text) * Convert.ToDouble(txtBoxUQTY.Text);
                    rdTotal.Text = totalPrice.ToString("#,###,##0.00");
                }
                else
                {
                    btnUpdate.Enabled = false;
                    txtBoxUQTY.Text = "0";
                }
            }
            catch (Exception)
            {
                txtBoxUQTY.Text = "0";
                rdTotal.Text = "0.00";
                btnUpdate.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                po.po_no = Convert.ToInt32(rdPOno.Text);
                po.supplier_code = txtBoxSupplierCode.Text;
                po.po_warehouse = cBoxWarehouse.Text;
                po.po_carrier = cBoxCourier.Text;
                po.po_remarks = txtBoxRemarks.Text;
                po.user_name = rdOrderedBy.Text;
                po.PO_Update();
                btnSave.Enabled = false;
                //Controls
                groupBox1.Enabled = false;
                txtBoxRemarks.ReadOnly = true;
                cBoxWarehouse.Enabled = false;
                cBoxCourier.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Check Server If Active", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}