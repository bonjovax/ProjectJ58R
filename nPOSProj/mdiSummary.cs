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
    public partial class mdiSummary : Form
    {
        private VO.CustomersVO custvo;
        public mdiSummary()
        {
            InitializeComponent();
        }
        private void LoadSummary()
        {
            custvo = new VO.CustomersVO();
            String[,] grabData = custvo.ReadAged();
            try
            {
                dataGridView1.Rows.Clear();
                for (int otin = 0; otin < grabData.GetLength(1); otin++)
                {
                    dataGridView1.Rows.Add(grabData[0, otin], grabData[1, otin], Convert.ToDateTime(grabData[2, otin]).ToString("MM/dd/yyyy"), Convert.ToDouble(grabData[3, otin]).ToString("#,###,##0.00"));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            if (keyData == Keys.F12)
            {
                /* Reserve for Reporting */
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private Double CellSumOutstanding()
        {
            Double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                Double d = 0;
                Double.TryParse(dataGridView1.Rows[i].Cells[3].Value.ToString(), out d);
                sum += d;
            }
            return sum;
        }
        private Double CellSumCurrent()
        {
            Double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                Double d = 0;
                Double.TryParse(dataGridView1.Rows[i].Cells[4].Value.ToString(), out d);
                sum += d;
            }
            return sum;
        }
        private Double CellSumThirty()
        {
            Double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                Double d = 0;
                Double.TryParse(dataGridView1.Rows[i].Cells[5].Value.ToString(), out d);
                sum += d;
            }
            return sum;
        }
        private Double CellSumSixty()
        {
            Double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                Double d = 0;
                Double.TryParse(dataGridView1.Rows[i].Cells[6].Value.ToString(), out d);
                sum += d;
            }
            return sum;
        }
        private Double CellSumNinty()
        {
            Double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                Double d = 0;
                Double.TryParse(dataGridView1.Rows[i].Cells[7].Value.ToString(), out d);
                sum += d;
            }
            return sum;
        }
        private Double CellSumOver()
        {
            Double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                Double d = 0;
                Double.TryParse(dataGridView1.Rows[i].Cells[8].Value.ToString(), out d);
                sum += d;
            }
            return sum;
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mdiSummary_Load(object sender, EventArgs e)
        {
            LoadSummary();
        }
    }
}