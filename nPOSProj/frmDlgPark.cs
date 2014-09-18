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
    public partial class frmDlgPark : Form
    {
        private Conf.dbs dbcon = new Conf.dbs();
        private MySqlConnection con = new MySqlConnection();
        private bool selected = false;
        private VO.OrderVO order;
        private String types = "";

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        private bool order_Selected;

        public bool Order_Selected
        {
            get { return order_Selected; }
            set { order_Selected = value; }
        }

        private Int32 orderNo;

        public Int32 OrderNo
        {
            get { return orderNo; }
            set { orderNo = value; }
        }


        public frmDlgPark()
        {
            InitializeComponent();
        }

        private void getDataTable()
        {
            frmLogin fs = new frmLogin();
            dbcon = new Conf.dbs();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            String connectionString = dbcon.getConnectionString();
            String query = "SELECT pos_orno AS a, pos_tax_perc AS b, pos_tax_amt AS c, ";
            query += "pos_total_amt AS d, pos_date AS e, pos_time AS f, pos_user AS g, pos_iswholesale AS h ";
            query += "FROM pos_store ";
            query += "WHERE pos_terminal = ?pos_terminal AND (pos_park = 1) AND (is_cancel = 0)";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, con))
                {
                    try
                    {
                        DataTable dataTable = new DataTable();
                        adapter.SelectCommand.Parameters.AddWithValue("?pos_terminal", fs.tN);
                        adapter.Fill(dataTable);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            if (dataTable.Rows[i][7].ToString() == "1")
                            {
                                types = "Wholesale";
                            }
                            else
                                types = "Retail";
                            DateTime dates = DateTime.Parse(dataTable.Rows[i][5].ToString());
                            dataGridView1.Rows.Add(dataTable.Rows[i][0], dataTable.Rows[i][1], dataTable.Rows[i][2], dataTable.Rows[i][3], dataTable.Rows[i][4], dates.ToString("hh:mm:ss tt"), dataTable.Rows[i][6], types);
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error" + ex);
                    }
                }
            } // end using
        }

        private void LoadDataOrder()
        {
            order = new VO.OrderVO();
            String[,] grabData = order.ReadParkedOrder();
            try
            {
                dataGridView2.Rows.Clear();
                for (int o = 0; o < grabData.GetLength(1); o++)
                {
                    dataGridView2.Rows.Add(grabData[0, o].ToString(), Convert.ToDateTime(grabData[1, o].ToString()).ToString("MM/dd/yyyy"), Convert.ToDateTime(grabData[2, o].ToString()).ToString("hh:mm:ss tt"), Convert.ToDouble(grabData[3, o].ToString()).ToString("#,###,##0.00"), grabData[4, o].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDlgPark_Load(object sender, EventArgs e)
        {
            Selected = false;
            getDataTable();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                OrderNo = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                Selected = true;
                this.Close();
            }
            catch (Exception)
            {
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    OrderNo = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    Selected = true;
                    this.Close();
                    e.Handled = true;
                }
                catch(Exception)
                {
                }
            }
        }

        private void cBoxOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxOrder.Checked == true)
            {
                this.Text = "Order Park Retrieval";
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;
                LoadDataOrder();
            }
            else
            {
                this.Text = "Park Sale Retrieval";
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;
                getDataTable();
            }
        }
    }
}