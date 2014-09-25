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
            Double current = 0;
            Double thirty = 0;
            Double sixty = 0;
            Double ninty = 0;
            Double over = 0;
            try
            {
                dataGridView1.Rows.Clear();
                for (int otin = 0; otin < grabData.GetLength(1); otin++)
                {
                    TimeSpan ts = Convert.ToDateTime(dtSelect.Value) - Convert.ToDateTime(grabData[2, otin]);
                    if (ts.TotalDays >= 1 && ts.TotalDays < 31)
                    {
                        thirty = Convert.ToDouble(grabData[3, otin]);
                    }
                    else if (ts.TotalDays >= 31 && ts.TotalDays < 61)
                    {
                        sixty = Convert.ToDouble(grabData[3, otin]);
                    }
                    else if (ts.TotalDays >= 61 && ts.TotalDays < 91)
                    {
                        ninty = Convert.ToDouble(grabData[3, otin]);
                    }
                    else if (ts.TotalDays >= 91)
                    {
                        over = Convert.ToDouble(grabData[3, otin]);
                    } 
                    else
                    {
                        current = Convert.ToDouble(grabData[3, otin]);
                    }
                    dataGridView1.Rows.Add(grabData[0, otin], grabData[1, otin], Convert.ToDateTime(grabData[2, otin]).ToString("MM/dd/yyyy"), Convert.ToDouble(grabData[3, otin]).ToString("#,###,##0.00"), current.ToString("#,###,##0.00"), thirty.ToString("#,###,##0.00"), sixty.ToString("#,###,##0.00"), ninty.ToString("#,###,##0.00"), over.ToString("#,###,##0.00"));
                    current = 0;
                    thirty = 0;
                    sixty = 0;
                    ninty = 0;
                    over = 0;
                }
                lblOutstanding.Text = CellSumOutstanding().ToString("#,###,##0.00");
                lblCurrent.Text = CellSumCurrent().ToString("#,###,##0.00");
                lbl30.Text = CellSumThirty().ToString("#,###,##0.00");
                lbl60.Text = CellSumSixty().ToString("#,###,##0.00");
                lbl90.Text = CellSumNinty().ToString("#,###,##0.00");
                lblOver.Text = CellSumOver().ToString("#,###,##0.00");
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintAge()
        {
            label1.Visible = false;
            lblOutstanding.Visible = false;
            lblCurrent.Visible = false;
            lbl30.Visible = false;
            lbl60.Visible = false;
            lbl90.Visible = false;
            lblOver.Visible = false;
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("customer", typeof(String));
                dt.Columns.Add("terms", typeof(Int32));
                dt.Columns.Add("duedate", typeof(String));
                dt.Columns.Add("outstanding", typeof(Double));
                dt.Columns.Add("current", typeof(Double));
                dt.Columns.Add("thirty", typeof(Double));
                dt.Columns.Add("sixty", typeof(Double));
                dt.Columns.Add("ninty", typeof(Double));
                dt.Columns.Add("over", typeof(Double));
                //
                foreach (DataGridViewRow dcoe in dataGridView1.Rows)
                {
                    dt.Rows.Add(dcoe.Cells[0].Value, dcoe.Cells[1].Value, dcoe.Cells[2].Value, dcoe.Cells[3].Value, dcoe.Cells[4].Value, dcoe.Cells[5].Value, dcoe.Cells[6].Value, dcoe.Cells[7].Value, dcoe.Cells[8].Value);
                }
                ds.Tables.Add(dt);
                ds.WriteXmlSchema("aging.xml");
                crystalReportViewer1.Visible = true;
                btnReturn.Visible = true;
                //Execute To CReports
                rptAging aging = new rptAging();
                aging.SetDataSource(ds);
                crystalReportViewer1.ReportSource = aging;
            }
            catch (Exception)
            {

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
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    Double d = 0;
                    Double.TryParse(dataGridView1.Rows[i].Cells[4].Value.ToString(), out d);
                    sum += d;
                }
            }
            catch (Exception)
            {
                sum = 0;
            }
            return sum;
        }
        private Double CellSumThirty()
        {
            Double sum = 0;
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    Double d = 0;
                    Double.TryParse(dataGridView1.Rows[i].Cells[5].Value.ToString(), out d);
                    sum += d;
                }
            }
            catch (Exception)
            {
                sum = 0;
            }
            return sum;
        }
        private Double CellSumSixty()
        {
            Double sum = 0;
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    Double d = 0;
                    Double.TryParse(dataGridView1.Rows[i].Cells[6].Value.ToString(), out d);
                    sum += d;
                }
            }
            catch (Exception)
            {
                sum = 0;
            }
            return sum;
        }
        private Double CellSumNinty()
        {
            Double sum = 0;
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    Double d = 0;
                    Double.TryParse(dataGridView1.Rows[i].Cells[7].Value.ToString(), out d);
                    sum += d;
                }
            }
            catch (Exception)
            {
                sum = 0;
            }
            return sum;
        }
        private Double CellSumOver()
        {
            Double sum = 0;
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    Double d = 0;
                    Double.TryParse(dataGridView1.Rows[i].Cells[8].Value.ToString(), out d);
                    sum += d;
                }
            }
            catch (Exception)
            {
                sum = 0;
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TimeSpan ts = Convert.ToDateTime(dtSelect.Value) - Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[2].Value);
            MessageBox.Show(ts.TotalDays.ToString("###"));
        }

        private void dtSelect_ValueChanged(object sender, EventArgs e)
        {
            LoadSummary();
        }

        private void btnF12_Click(object sender, EventArgs e)
        {
            PrintAge();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.Visible = false;
            label1.Visible = true;
            lblOutstanding.Visible = true;
            lblCurrent.Visible = true;
            lbl30.Visible = true;
            lbl60.Visible = true;
            lbl90.Visible = true;
            lblOver.Visible = true;
            btnReturn.Visible = false;
        }
    }
}