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
    public partial class mKits : Form
    {
        private Conf.dbs dbcon = new Conf.dbs();
        private MySqlConnection con = new MySqlConnection();
        private String uom;
        private String description;
        private String _ean;
        private VO.ItemVO itemvo = new VO.ItemVO();
        public mKits()
        {
            InitializeComponent();
        }

        public String Ean
        {
            get { return _ean; }
            set { _ean = value; }
        }

        private void getDataTableKits()
        {
            dbcon = new Conf.dbs();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            String connectionString = dbcon.getConnectionString();
            String query = "SELECT inventory_items_kit.kit_qty AS aa, inventory_stocks.stock_code AS a, inventory_stocks.stock_name AS b, inventory_stocks.stock_uom AS c, inventory_stocks.stock_selling_price AS d ";
            query += "FROM inventory_items_kit INNER JOIN inventory_stocks ON inventory_items_kit.stock_code = inventory_stocks.stock_code INNER JOIN inventory_items ON inventory_items_kit.item_ean = inventory_items.item_ean ";
            query += "WHERE (inventory_items_kit.item_ean = ?ean)";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, con))
                {
                    try
                    {
                        DataTable dataTable = new DataTable();
                        adapter.SelectCommand.Parameters.AddWithValue("?ean", Ean);
                        adapter.Fill(dataTable);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add(dataTable.Rows[i][0], dataTable.Rows[i][1], dataTable.Rows[i][2], dataTable.Rows[i][3], dataTable.Rows[i][4]);
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error" + ex);
                    }
                }
            } // end using
        }
        private void getDataTableItems()
        {
            dbcon = new Conf.dbs();
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            String connectionString = dbcon.getConnectionString();
            String query = "SELECT inventory_stocks.stock_code AS a, inventory_items.item_ean AS b, inventory_stocks.stock_name AS c, ";
            query += "inventory_items.item_retail_price AS d, inventory_category.cat_description AS e ";
            query += "FROM inventory_items ";
            query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "INNER JOIN inventory_category ON inventory_stocks.stock_cat_code = inventory_category.cat_code ";
            query += "WHERE (inventory_items.is_kit = 0)";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, con))
                {
                    try
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            dataGridView2.Rows.Add(dataTable.Rows[i][0], dataTable.Rows[i][1], dataTable.Rows[i][2], dataTable.Rows[i][3], dataTable.Rows[i][4]);
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error" + ex);
                    }
                }
            } // end using
        }

        private void mKits_Load(object sender, EventArgs e)
        {
            getDataTableKits();
            getDataTableItems();
        }

        private void fetchUnitAndSelling()
        {
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT stock_uom AS a, stock_name AS b FROM inventory_stocks ";
            query += "WHERE stock_code = ?stock_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?stock_code", dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    uom = rdr["a"].ToString();
                    description = rdr["b"].ToString();
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database Server", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    for (int col = 0; col < dataGridView1.Columns.Count; col++)
                    {
                        if (dataGridView1.Rows[row].Cells[col].Value != null && dataGridView1.Rows[row].Cells[col].Value.Equals(dataGridView2.SelectedRows[0].Cells[0].Value.ToString()))
                        {
                            MessageBox.Show("List is already Existed!", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
                fetchUnitAndSelling();
                itemvo.item_quantity = 0;
                itemvo.item_ean = Ean;
                itemvo.stock_code = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                itemvo.PushKit();
                dataGridView1.Rows.Add("0", dataGridView2.SelectedRows[0].Cells[0].Value.ToString(), description, uom, Convert.ToDouble(dataGridView2.SelectedRows[0].Cells[3].Value).ToString("#,###,##0.00"));
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database Server", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Do You Wish To Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            itemvo.item_ean = Ean;
                            itemvo.stock_code = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                            itemvo.PullKit();
                            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                            btnDelete.Enabled = false;
                            btnUpdate.Enabled = false;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Check Database Server", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                itemvo.item_quantity = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                itemvo.item_ean = Ean;
                itemvo.stock_code = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                itemvo.PatchKit();
                btnUpdate.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database Server", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }
    }
}