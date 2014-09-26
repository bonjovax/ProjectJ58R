using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace nPOSProj
{
    public partial class frmDlgSearch : Form
    {
        private VO.ItemVO items;
        private bool selected = false;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        private String ean;

        public String Ean
        {
            get { return ean; }
            set { ean = value; }
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
                txtBoxSearch.Focus();
                return true;
            }
            if (keyData == Keys.F3)
            {
                if (chKIKits.Checked == false)
                {
                    chKIKits.Checked = true;
                    getDataTable();
                }
                else
                {
                    chKIKits.Checked = false;
                    getDataTable();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public frmDlgSearch()
        {
            InitializeComponent();
        }

        private void getDataTable()
        {
            items = new VO.ItemVO();
            if (chKIKits.Checked == true)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                String[,] grabData = items.ReadKits();
                try
                {
                    for (int x = 0; x < grabData.GetLength(1); x++)
                    {
                        dataGridView1.Rows.Add(grabData[0, x].ToString(), grabData[1, x].ToString(), Convert.ToDouble(grabData[2, x]), Convert.ToDouble(grabData[3, x]));
                    }
                }
                catch (Exception)
                {
                }
            }
            else
            {
                items = new VO.ItemVO();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                String[,] grabData = items.ReadItems();
                try
                {
                    for (int x = 0; x < grabData.GetLength(1); x++)
                    {
                        dataGridView1.Rows.Add(grabData[0, x].ToString(), grabData[1, x].ToString(), Convert.ToDouble(grabData[2, x]), Convert.ToDouble(grabData[3, x]));
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void getDataTableSearch()
        {
            items = new VO.ItemVO();
            if (chKIKits.Checked == true)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                items.description = txtBoxSearch.Text;
                String[,] grabData = items.ReadKitsSearch();
                try
                {
                    for (int x = 0; x < grabData.GetLength(1); x++)
                    {
                        dataGridView1.Rows.Add(grabData[0, x].ToString(), grabData[1, x].ToString(), Convert.ToDouble(grabData[2, x]), Convert.ToDouble(grabData[3, x]));
                    }
                }
                catch (Exception)
                {
                }
            }
            else
            {
                items = new VO.ItemVO();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                items.description = txtBoxSearch.Text;
                String[,] grabData = items.ReadItemsSearch();
                try
                {
                    for (int x = 0; x < grabData.GetLength(1); x++)
                    {
                        dataGridView1.Rows.Add(grabData[0, x].ToString(), grabData[1, x].ToString(), Convert.ToDouble(grabData[2, x]), Convert.ToDouble(grabData[3, x]));
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void frmDlgSearch_Load(object sender, EventArgs e)
        {
            Selected = false;
            getDataTable();
            txtBoxSearch.Focus();
        }

        private void chKIKits_CheckedChanged(object sender, EventArgs e)
        {
            getDataTable();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Ean = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    Selected = true;
                    this.Close();
                    e.Handled = true;
                }
                catch (Exception)
                {
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Ean = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            Selected = true;
            this.Close();
        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text != "")
            {
                getDataTableSearch();
            }
            else
                getDataTable();
        }
    }
}