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
    public partial class mdiCategory : Form
    {
        public mdiCategory()
        {
            InitializeComponent();
        }

        private void mdiCategory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'npos_dbDataSet.inventory_category' table. You can move, or remove it, as needed.
            this.inventory_categoryTableAdapter.Fill(this.npos_dbDataSet.inventory_category);
        }

        private void clear()
        {
            txtBoxCatCode.Clear();
            txtBoxDescription.Clear();
            btnAdd.Enabled = false;
        }

        private void txtBoxCatCode_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCatCode.Text != null && txtBoxDescription.Text != null || txtBoxCatCode.Text != "" && txtBoxDescription.Text != "")
            {
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }

        private void txtBoxDescription_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCatCode.Text != null && txtBoxDescription.Text != null || txtBoxCatCode.Text != "" && txtBoxDescription.Text != "")
            {
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Do You Wish To Continue?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    this.inventory_categoryTableAdapter.InsertCategory(txtBoxCatCode.Text, txtBoxDescription.Text);
                    this.inventory_categoryTableAdapter.Fill(this.npos_dbDataSet.inventory_category);
                    clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Category Code Existed! or Check Database Server!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                            this.inventory_categoryTableAdapter.DeleteCategory(dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                            dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
                            btnDelete.Enabled = false;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.ExitThread();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.inventory_categoryTableAdapter.UpdateCategory(dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()), dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                btnUpdate.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }
    }
}