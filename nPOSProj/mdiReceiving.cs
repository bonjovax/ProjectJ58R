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
    public partial class mdiReceiving : Form
    {
        private Conf.dbs dbcon = new Conf.dbs();
        private MySqlConnection con = new MySqlConnection();
        private DAO.LoginDAO login = new DAO.LoginDAO();
        private VO.ReceivingVO rvo = new VO.ReceivingVO();
        private VO.PurchaseOrderVO povo = new VO.PurchaseOrderVO();
        public mdiReceiving()
        {
            InitializeComponent();
        }
        private void getRefNo()
        {
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT po_ref FROM po_order ";
            query += "WHERE po_no = ?po_no";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?po_no", rdPONo.Text);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtBoxRef.Text = rdr["po_ref"].ToString();
                }
            }
            catch (Exception)
            {
                txtBoxRef.Text = "Error 22";
            }
            finally
            {
                con.Close();
            }
        }

        private void getDataTable()
        {
            dbcon = new Conf.dbs();
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            String connectionString = dbcon.getConnectionString();
            String query = "SELECT order_quantity AS a, order_suppliers_itemno AS b, order_uom AS c, order_description AS d, ";
            query += "order_unitcost AS e, order_amount AS f FROM po_order_list ";
            query += "WHERE po_no = ?po_no AND order_quantity != 0";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, con))
                {
                    try
                    {
                        DataTable dataTable = new DataTable();
                        adapter.SelectCommand.Parameters.AddWithValue("?po_no", dataGridView1.SelectedRows[0].Cells[0].Value);
                        adapter.Fill(dataTable);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            dataGridView2.Rows.Add(dataTable.Rows[i][0], dataTable.Rows[i][1], dataTable.Rows[i][2], dataTable.Rows[i][3], dataTable.Rows[i][4], dataTable.Rows[i][5]);
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error" + ex);
                    }
                }
            } // end using
        }

        private void mdiReceiving_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'npos_dbDataSet.po_order' table. You can move, or remove it, as needed.
            this.po_orderTableAdapter.FillByPending(this.npos_dbDataSet.po_order, Convert.ToDateTime(dateTimePicker1.Text));
            String userName = frmLogin.User.user_name;
            login.catchUsername(userName);
            if (login.hasUser_Accounts())
            {
                btnR.Visible = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rdPONo.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            rdSupplierCode.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            rdSupplierName.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            getDataTable();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            rdPONo.Clear();
            rdSupplierCode.Clear();
            rdSupplierName.Clear();
            rdStockCode.Clear();
            rdParticulars.Clear();
            txtBoxQty.Clear();
            txtBoxQty.ReadOnly = true;
            // TODO: This line of code loads data into the 'npos_dbDataSet.po_order' table. You can move, or remove it, as needed.
            this.po_orderTableAdapter.FillByPending(this.npos_dbDataSet.po_order, Convert.ToDateTime(dateTimePicker1.Text));
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtBoxQty.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                rdStockCode.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                rdParticulars.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
                txtBoxQty.ReadOnly = false;
            }
            catch (Exception)
            {

            }
        }

        private void rdPONo_TextChanged(object sender, EventArgs e)
        {
            if (rdPONo.Text != "" && rdStockCode.Text != "" && txtBoxQty.Text != "" && txtBoxQty.Text != "0" && txtBoxQty.Text != "00" && txtBoxQty.Text != "000" && txtBoxQty.Text != "0000" && txtBoxQty.Text != "00000" && txtBoxQty.Text != "000000" && txtBoxQty.Text != "0000000" && txtBoxQty.Text != "00000000")
            {
                btnImport.Enabled = true;
            }
            else
                btnImport.Enabled = false;
        }

        private void rdStockCode_TextChanged(object sender, EventArgs e)
        {
            if (rdPONo.Text != "" && rdStockCode.Text != "" && txtBoxQty.Text != "" && txtBoxQty.Text != "0" && txtBoxQty.Text != "00" && txtBoxQty.Text != "000" && txtBoxQty.Text != "0000" && txtBoxQty.Text != "00000" && txtBoxQty.Text != "000000" && txtBoxQty.Text != "0000000" && txtBoxQty.Text != "00000000")
            {
                btnImport.Enabled = true;
            }
            else
                btnImport.Enabled = false;
        }

        private void txtBoxQty_TextChanged(object sender, EventArgs e)
        {
            if (rdPONo.Text != "" && rdStockCode.Text != "" && txtBoxQty.Text != "" && txtBoxQty.Text != "0" && txtBoxQty.Text != "00" && txtBoxQty.Text != "000" && txtBoxQty.Text != "0000" && txtBoxQty.Text != "00000" && txtBoxQty.Text != "000000" && txtBoxQty.Text != "0000000" && txtBoxQty.Text != "00000000")
            {
                btnImport.Enabled = true;
            }
            else
                btnImport.Enabled = false;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value.ToString()) >= Convert.ToInt32(txtBoxQty.Text))
                {
                    if (Convert.ToInt32(txtBoxQty.Text) >= 0)
                    {
                        rvo.po_no = Convert.ToInt32(rdPONo.Text);
                        rvo.stock_code = rdStockCode.Text;
                        rvo.quantity = Convert.ToInt32(txtBoxQty.Text);
                        rvo.ReceiveStocks();
                        rvo.askQty();
                        dataGridView2.SelectedRows[0].Cells[0].Value = rvo.askQty();
                        if (dataGridView2.SelectedRows[0].Cells[0].Value.ToString() == "0")
                        {
                            dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                            rdStockCode.Clear();
                            rdParticulars.Clear();
                            txtBoxQty.Clear();
                        }
                        txtBoxQty.Clear();
                        if (dataGridView2.Rows.Count == 0)
                        {
                            rdPONo.Clear();
                            rdSupplierCode.Clear();
                            rdSupplierName.Clear();
                            rvo.TriggerStatus();
                            txtBoxRef.ReadOnly = true;
                            this.po_orderTableAdapter.FillByPending(this.npos_dbDataSet.po_order, Convert.ToDateTime(dateTimePicker1.Text));
                            btnR.Enabled = false;
                        }
                    }
                    else
                        MessageBox.Show("Negative Value Will Not Be Considered!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Your Input Quantity must be equal or less than your Available Ordered Quantity!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Check Server!", "Database Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBoxRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rvo.po_ref = txtBoxRef.Text;
                rvo.po_no = Convert.ToInt32(rdPONo.Text);
                rvo.UpdateReferenceNo();
                txtBoxRef.ReadOnly = true;
            }
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Do You Wish To Redo Your Purchase Order?", "Administration", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                DateTime raw = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[1].Value);
                povo.po_no = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                povo.po_date = raw.ToString("yyyy-MM-dd");
                povo.ReversePrint();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                btnR.Enabled = false;
                dataGridView2.Rows.Clear();
                rdPONo.Clear();
                rdSupplierCode.Clear();
                rdSupplierName.Clear();
                rdStockCode.Clear();
                rdParticulars.Clear();
                txtBoxQty.Clear();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rdPONo.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                rdSupplierCode.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                rdSupplierName.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                getDataTable();
                e.Handled = true;
            }
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }
    }
}