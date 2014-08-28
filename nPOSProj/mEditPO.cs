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
    public partial class mEditPO : Form
    {
        private MySqlConnection con = new MySqlConnection();
        private Conf.dbs dbcon = new Conf.dbs();
        private VO.PurchaseOrderVO po = new VO.PurchaseOrderVO();
        public String DatePass { get; set; }
        AutoCompleteStringCollection collect2 = new AutoCompleteStringCollection();
        AutoCompleteStringCollection collect3 = new AutoCompleteStringCollection();
        private String supplier_code;
        private String old_stock_code;
        public DateTime PurchaseOrderDate
        {
            get { return dt.Value; }  // your PO date picker control
        }
        public mEditPO()
        {
            InitializeComponent();
        }
        private void getDataTable()
        {
            dbcon = new Conf.dbs();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            String connectionString = dbcon.getConnectionString();
            String query = "SELECT order_quantity AS a, order_suppliers_itemno AS b, order_uom AS c, order_description AS d, ";
            query += "order_unitcost AS e, order_amount AS f FROM po_order_list ";
            query += "WHERE po_no = ?po_no";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, con))
                {
                    try
                    {
                        DataTable dataTable = new DataTable();
                        adapter.SelectCommand.Parameters.AddWithValue("?po_no", rdPOno.Text);
                        adapter.Fill(dataTable);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add(dataTable.Rows[i][0], dataTable.Rows[i][1], dataTable.Rows[i][2], dataTable.Rows[i][3], dataTable.Rows[i][4], dataTable.Rows[i][5]);
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error" + ex);
                    }
                }
            } // end using
        }

        public void orderPO(Int32 po_no)
        {
            rdPOno.Text = po_no.ToString();
        }

        public void displayDataUpper()
        {
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT supplier_code AS a, po_date AS b, user_name AS c, po_warehouse AS d, po_carrier AS e, po_remarks AS f FROM po_order ";
            query += "WHERE po_no = ?po_no";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?po_no", rdPOno.Text);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtBoxSupplierCode.Text = rdr["a"].ToString();
                    dt.Text = rdr["b"].ToString();
                    rdOrderedBy.Text = rdr["c"].ToString();
                    cBoxWarehouse.Text = rdr["d"].ToString();
                    cBoxCourier.Text = rdr["e"].ToString();
                    txtBoxRemarks.Text = rdr["f"].ToString();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error Reading: " + ex.ToString(), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                lAddress.Text = "";
            }
        }

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

        private void txtBoxSupplierCode_TextChanged(object sender, EventArgs e)
        {
            po.supplier_code = txtBoxSupplierCode.Text;
            txtBoxSupplierName.Text = po.askSupplierName();
            toAddress();
        }

        private void rdPOno_TextChanged(object sender, EventArgs e)
        {
            displayDataUpper();
        }

        private void mEditPO_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'npos_dbDataSet.inventory_warehouse' table. You can move, or remove it, as needed.
            this.inventory_warehouseTableAdapter.Fill(this.npos_dbDataSet.inventory_warehouse);
            groupBox1.Enabled = true;
            txtBoxStockCode.ReadOnly = false;
            txtBoxParticulars.ReadOnly = false;
            txtBoxStockCode.Focus();
            autoCompleteStockCode();
            autoCompleteStockName();
            getDataTable();
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

        private void txtBoxParticulars_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                po.stock_name = txtBoxParticulars.Text;
                po.supplier_code = txtBoxSupplierCode.Text;
                txtBoxStockCode.Text = po.askStockCode();
                po.stock_code = txtBoxStockCode.Text;
                txtBoxUnitPrice.Text = po.askStockPriceStockName().ToString("#,###,##0.00");
                txtBoxUOM.Text = po.askUOM_N();
                txtBoxQty.Focus();
                txtBoxUQTY.ReadOnly = false;
                txtBoxUQTY.Focus();
            }
        }

        private void txtBoxQty_TextChanged(object sender, EventArgs e)
        {
            Double totalPrice;
            if (txtBoxStockCode.Text == "" || txtBoxStockCode.Text == null)
            {
                btnAdd.Enabled = false;
            }
            else
                btnAdd.Enabled = true;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CheckIfStockCodePrevent();
                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    for (int col = 0; col < dataGridView1.Columns.Count; col++)
                    {
                        if (dataGridView1.Rows[row].Cells[col].Value != null && dataGridView1.Rows[row].Cells[col].Value.Equals(txtBoxStockCode.Text))
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
                    po.po_no = Convert.ToInt32(rdPOno.Text);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}