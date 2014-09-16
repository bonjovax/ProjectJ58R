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
    public partial class mdiQuotationHistory : Form
    {
        private VO.OrderVO ordervo = new VO.OrderVO();
        private String presetDate;
        public mdiQuotationHistory()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                dataGridView1.Focus();
                return true;
            }
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void LoadQuoteDataItem(String date)
        {
            ordervo = new VO.OrderVO();
            ordervo.Targetdate = presetDate;
            String[,] grabData = ordervo.ReadQuoteHistoryDateVO();
            try
            {
                for (int o = 0; o < grabData.GetLength(1); o++)
                {
                    dataGridView1.Rows.Add(grabData[0, o].ToString(), Convert.ToDateTime(grabData[1, o]).ToString("MM/dd/yyyy"), Convert.ToDateTime(grabData[2, o]).ToString("hh:mm:ss tt"), grabData[3, o].ToString(), grabData[4, o].ToString(), Convert.ToDouble(grabData[5, o]).ToString("#,###,##0.00"), grabData[6, o].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadQuoteDataItemQuote(Int32 quote_no)
        {
            ordervo = new VO.OrderVO();
            ordervo.Quotation_no = quote_no;
            String[,] grabData = ordervo.ReadQuoteHistoryQuoteVO();
            try
            {
                for (int o = 0; o < grabData.GetLength(1); o++)
                {
                    dataGridView1.Rows.Add(grabData[0, o].ToString(), Convert.ToDateTime(grabData[1, o]).ToString("MM/dd/yyyy"), Convert.ToDateTime(grabData[2, o]).ToString("hh:mm:ss tt"), grabData[3, o].ToString(), grabData[4, o].ToString(), Convert.ToDouble(grabData[5, o]).ToString("#,###,##0.00"), grabData[6, o].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mdiQuotationHistory_Load(object sender, EventArgs e)
        {
            presetDate = DateTime.Now.ToString("yyyy-MM-dd");
            this.LoadQuoteDataItem(presetDate);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            presetDate = Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy-MM-dd");
            this.LoadQuoteDataItem(presetDate);
        }

        private void txtBoxQuotation_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxQuotation.Text != "")
            {
                dataGridView1.Rows.Clear();
                ordervo.Quotation_no = Convert.ToInt32(txtBoxQuotation.Text);
                this.LoadQuoteDataItemQuote(Convert.ToInt32(txtBoxQuotation.Text));
            }
            else
            {
                dataGridView1.Rows.Clear();
                presetDate = DateTime.Now.ToString("yyyy-MM-dd");
                this.LoadQuoteDataItem(presetDate);
            }
        }

        private void txtBoxQuotation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
    }
}