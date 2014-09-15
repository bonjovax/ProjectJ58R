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
    public partial class mQuotePark : Form
    {
        private VO.OrderVO order = new VO.OrderVO();
        private Int32 quotation_no;

        public Int32 Quotation_no
        {
            get { return quotation_no; }
            set { quotation_no = value; }
        }
        public mQuotePark()
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
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void LoadData()
        {
            order = new VO.OrderVO();
            String[,] grabData = order.ReadParkedQuote();
            try
            {
                dataGridView1.Rows.Clear();
                for (int o = 0; o < grabData.GetLength(1); o++)
                {
                    dataGridView1.Rows.Add(grabData[0, o].ToString(), Convert.ToDateTime(grabData[1, o].ToString()).ToString("MM/dd/yyyy"), Convert.ToDateTime(grabData[2, o].ToString()).ToString("hh:mm:ss tt"), Convert.ToDouble(grabData[3, o].ToString()).ToString("#,###,##0.00"), grabData[4, o].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mQuotePark_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Quotation_no = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            this.Close();
        }

        private void txtBoxQuotationNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtBoxQuotationNo_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxQuotationNo.Text != "")
            {
                order = new VO.OrderVO();
                order.Quotation_no = Convert.ToInt32(txtBoxQuotationNo.Text);
                String[,] grabData = order.ReadParkQuoteSearch();
                try
                {
                    dataGridView1.Rows.Clear();
                    for (int o = 0; o < grabData.GetLength(1); o++)
                    {
                        dataGridView1.Rows.Add(grabData[0, o].ToString(), Convert.ToDateTime(grabData[1, o].ToString()).ToString("MM/dd/yyyy"), Convert.ToDateTime(grabData[2, o].ToString()).ToString("hh:mm:ss tt"), Convert.ToDouble(grabData[3, o].ToString()).ToString("#,###,##0.00"), grabData[4, o].ToString());
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                LoadData();
        }
    }
}