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
    public partial class mdiDirectory : Form
    {
        private VO.CustomersVO customer;
        public mdiDirectory()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            customer = new VO.CustomersVO();
            String[,] grabData = customer.ReadCustomers();
            try
            {
                dataGridView1.Rows.Clear();
                for (int x = 0; x < grabData.GetLength(1); x++)
                {
                    dataGridView1.Rows.Add(grabData[0, x].ToString(), grabData[1, x].ToString(), grabData[2, x].ToString(), grabData[3, x].ToString(), grabData[4, x].ToString(), Convert.ToDouble(grabData[5, x].ToString()));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mdiDirectory_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (mNewDirectory newdir = new mNewDirectory())
            {
                newdir.ShowDialog();
                if (newdir.Activity == true)
                {
                    LoadData();
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (mEditDirectory editdir = new mEditDirectory())
                {
                    editdir.Custcode = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    editdir.ShowDialog();
                    if (editdir.Activity == true)
                    {
                        dataGridView1.SelectedRows[0].Cells[1].Value = editdir.Company;
                        dataGridView1.SelectedRows[0].Cells[2].Value = editdir.First;
                        dataGridView1.SelectedRows[0].Cells[3].Value = editdir.Middle;
                        dataGridView1.SelectedRows[0].Cells[4].Value = editdir.Last;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to Delete Your Selected Record?\nAll Trasactions Under your Selected Customer Code will be Wiped Out!\nThis Can't be Undo!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            customer = new VO.CustomersVO();
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                customer.Custcode = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                customer.DeleteCustomers();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                btnDelete.Enabled = false;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            using (mFilterDir fildir = new mFilterDir())
            {
                fildir.ShowDialog();
                if (fildir.Searched == true)
                {
                    try
                    {
                        customer = new VO.CustomersVO();
                        customer.Balance = fildir.FilterAmount;
                        String[,] grabData = customer.ReadCustomersFilts();
                        dataGridView1.Rows.Clear();
                        for (int x = 0; x < grabData.GetLength(1); x++)
                        {
                            dataGridView1.Rows.Add(grabData[0, x].ToString(), grabData[1, x].ToString(), grabData[2, x].ToString(), grabData[3, x].ToString(), grabData[4, x].ToString(), Convert.ToDouble(grabData[5, x].ToString()));
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("CustomerDirectory");
            saveFileDialog1.DefaultExt = ".xml";
            saveFileDialog1.FileName = "Export";
            saveFileDialog1.Filter = "Extensible Markup Language (*.xml)|*.xml";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dt.Columns.Add(dataGridView1.Columns[i].Name, typeof(System.String));
                }

                DataRow dickrow;
                int cols = dataGridView1.Columns.Count;
                foreach (DataGridViewRow drow in this.dataGridView1.Rows)
                {
                    dickrow = dt.NewRow();
                    for (int i = 0; i <= cols - 1; i++)
                    {
                        dickrow[i] = drow.Cells[i].Value;
                    }
                    dt.Rows.Add(dickrow);
                }
                dt.WriteXml(saveFileDialog1.FileName);
            }
        }
    }
}