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
    public partial class mOrderPark : Form
    {
        private VO.OrderVO order;
        public mOrderPark()
        {
            InitializeComponent();
        }

        private Int32 order_no;

        public Int32 Order_no
        {
            get { return order_no; }
            set { order_no = value; }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            if (keyData == Keys.F1)
            {
                dataGridView1.Focus();
                return true;
            }
            if (keyData == Keys.F2)
            {
                txtBoxOrderNo.Focus();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void LoadData()
        {
            order = new VO.OrderVO();
            String[,] grabData = order.ReadParkedOrder();
            try
            {
                dataGridView1.Rows.Clear();
                for (int o = 0; o < grabData.GetLength(1); o++)
                {
                    dataGridView1.Rows.Add(grabData[0, o].ToString(), Convert.ToDateTime(grabData[1, o].ToString()).ToString("MM/dd/yyyy"), Convert.ToDateTime(grabData[2, o].ToString()).ToString("hh:mm:ss tt"), Convert.ToDouble(grabData[3, o].ToString()).ToString("#,###,##0.00"), grabData[4, o].ToString());
                }
                if (dataGridView1.Rows.Count != 0)
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mOrderPark_Load(object sender, EventArgs e)
        {
            LoadData();
            txtBoxOrderNo.Focus();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Order_no = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            this.Close();
        }

        private void txtBoxOrderNo_TextChanged(object sender, EventArgs e)
        {
            order = new VO.OrderVO();
            try
            {
                if (txtBoxOrderNo.Text != "")
                {
                    order.Pos_orderno = Convert.ToInt32(txtBoxOrderNo.Text);
                    String[,] grabData = order.ReadParkedOrderSearch();
                    dataGridView1.Rows.Clear();
                    for (int o = 0; o < grabData.GetLength(1); o++)
                    {
                        dataGridView1.Rows.Add(grabData[0, o].ToString(), Convert.ToDateTime(grabData[1, o].ToString()).ToString("MM/dd/yyyy"), Convert.ToDateTime(grabData[2, o].ToString()).ToString("hh:mm:ss tt"), Convert.ToDouble(grabData[3, o].ToString()).ToString("#,###,##0.00"), grabData[4, o].ToString());
                    }
                }
                else
                    LoadData();
            }
            catch (Exception)
            {
                
            }
        }

        private void txtBoxOrderNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Order_no = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                this.Close();
            }
        }
    }
}