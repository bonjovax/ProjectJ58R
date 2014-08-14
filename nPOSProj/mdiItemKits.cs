using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BarcodeLib;

namespace nPOSProj
{
    public partial class mdiItemKits : Form
    {
        private Barcode b = new Barcode();
        public mdiItemKits()
        {
            InitializeComponent();
        }

        private void mditemKits_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'npos_dbDataSet.inventory_items1' table. You can move, or remove it, as needed.
                this.inventory_items1TableAdapter.Fill(this.npos_dbDataSet.inventory_items1);
                b.Alignment = AlignmentPositions.CENTER;
                b.Width = 165;
                b.Height = 53;
                TYPE t = TYPE.CODE39;
                b.IncludeLabel = true;
                b.LabelPosition = LabelPositions.BOTTOMCENTER;
                barcode.Image = b.Encode(t, "0");
            }
            catch (Exception)
            {
                MessageBox.Show("Check Server!", "Database Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtBoxQty.Text) >= 0 && Convert.ToDouble(txtBoxRetailPrice.Text) >= 0 && Convert.ToDouble(txtBoxWholesalePrice.Text) >= 0)
                {
                    this.inventory_items1TableAdapter.InsertQueryKit(Convert.ToInt32(txtBoxQty.Text), txtBoxEAN.Text, txtBoxDescription.Text, Convert.ToDecimal(txtBoxRetailPrice.Text), Convert.ToDecimal(txtBoxWholesalePrice.Text));
                    this.inventory_items1TableAdapter.Fill(this.npos_dbDataSet.inventory_items1);
                    txtBoxRetailPrice.Text = "0.00";
                    txtBoxWholesalePrice.Text = "0.00";
                    txtBoxQty.Clear();
                    txtBoxEAN.Clear();
                    txtBoxDescription.Clear();
                    btnAdd.Enabled = false;
                    b.Alignment = AlignmentPositions.CENTER;
                    TYPE t = TYPE.CODE39;
                    b.IncludeLabel = true;
                    b.LabelPosition = LabelPositions.BOTTOMCENTER;
                    barcode.Image = b.Encode(t, "0");
                }
                else
                    MessageBox.Show("Negative Value will not consider", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Check Server or Check Input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBoxQty_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxQty.Text != "" && txtBoxEAN.Text != "" && txtBoxDescription.Text != "" && txtBoxRetailPrice.Text != "0.00" && txtBoxWholesalePrice.Text != "0.00" && txtBoxRetailPrice.Text != "" && txtBoxWholesalePrice.Text != "")
            {
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }

        private void txtBoxEAN_TextChanged(object sender, EventArgs e)
        {
            try
            {
                b.Alignment = AlignmentPositions.CENTER;
                b.Width = 165;
                b.Height = 53;
                TYPE t = TYPE.EAN13;
                b.IncludeLabel = true;
                b.LabelPosition = LabelPositions.BOTTOMCENTER;
                barcode.Image = b.Encode(t, txtBoxEAN.Text);
            }
            catch (Exception)
            {
                b.Alignment = AlignmentPositions.CENTER;
                TYPE t = TYPE.CODE39;
                b.IncludeLabel = true;
                b.LabelPosition = LabelPositions.BOTTOMCENTER;
                try
                {
                    barcode.Image = b.Encode(t, txtBoxEAN.Text);
                }
                catch (Exception)
                {
                    barcode.Image = b.Encode(t, "0");
                }
            }
            if (txtBoxQty.Text != "" && txtBoxEAN.Text != "" && txtBoxDescription.Text != "" && txtBoxRetailPrice.Text != "0.00" && txtBoxWholesalePrice.Text != "0.00" && txtBoxRetailPrice.Text != "" && txtBoxWholesalePrice.Text != "")
            {
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }

        private void txtBoxDescription_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxQty.Text != "" && txtBoxEAN.Text != "" && txtBoxDescription.Text != "" && txtBoxRetailPrice.Text != "0.00" && txtBoxWholesalePrice.Text != "0.00" && txtBoxRetailPrice.Text != "" && txtBoxWholesalePrice.Text != "")
            {
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }

        private void txtBoxRetailPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxQty.Text != "" && txtBoxEAN.Text != "" && txtBoxDescription.Text != "" && txtBoxRetailPrice.Text != "0.00" && txtBoxWholesalePrice.Text != "0.00" && txtBoxRetailPrice.Text != "" && txtBoxWholesalePrice.Text != "")
            {
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }

        private void txtBoxWholesalePrice_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxQty.Text != "" && txtBoxEAN.Text != "" && txtBoxDescription.Text != "" && txtBoxRetailPrice.Text != "0.00" && txtBoxWholesalePrice.Text != "0.00" && txtBoxRetailPrice.Text != "" && txtBoxWholesalePrice.Text != "")
            {
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            try
            {
                b.Alignment = AlignmentPositions.CENTER;
                b.Width = 165;
                b.Height = 53;
                TYPE t = TYPE.EAN13;
                b.IncludeLabel = true;
                b.LabelPosition = LabelPositions.BOTTOMCENTER;
                barcode.Image = b.Encode(t, dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            }
            catch (Exception)
            {
                b.Alignment = AlignmentPositions.CENTER;
                TYPE t = TYPE.CODE39;
                b.IncludeLabel = true;
                b.LabelPosition = LabelPositions.BOTTOMCENTER;
                try
                {
                    barcode.Image = b.Encode(t, dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                }
                catch (Exception)
                {
                    barcode.Image = b.Encode(t, "0");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value) >= 0 && Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[3].Value) >= 0 && Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value) >= 0)
                {
                    this.inventory_items1TableAdapter.UpdateQueryKit(dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value), Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[3].Value), Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[4].Value), dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    b.Alignment = AlignmentPositions.CENTER;
                    TYPE t = TYPE.CODE39;
                    b.IncludeLabel = true;
                    b.LabelPosition = LabelPositions.BOTTOMCENTER;
                    barcode.Image = b.Encode(t, "0");
                }
                else
                    MessageBox.Show("Negative Value will not consider", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Check Server or Check Input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Do You Want to Delete This Item Kit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            try
            {
                if (dlgResult == DialogResult.Yes)
                {
                    foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            this.inventory_items1TableAdapter.DeleteQueryKit(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                            this.inventory_items1TableAdapter.DeleteQueryItemsList(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                            btnDelete.Enabled = false;
                            btnUpdate.Enabled = false;
                            b.Alignment = AlignmentPositions.CENTER;
                            TYPE t = TYPE.CODE39;
                            b.IncludeLabel = true;
                            b.LabelPosition = LabelPositions.BOTTOMCENTER;
                            barcode.Image = b.Encode(t, "0");
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check Server or Check Input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            mKits kits = new mKits();
            kits.Ean = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            kits.ShowDialog();
        }

        private void txtBoxEAN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtBoxQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtBoxRetailPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtBoxWholesalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void bcSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIFF (*.tif)|*.tif";
            sv.FilterIndex = 4;
            sv.AddExtension = true;
            if (sv.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SaveTypes st = SaveTypes.UNSPECIFIED;
                switch (sv.FilterIndex)
                {
                    case 1: /* BMP */  st = BarcodeLib.SaveTypes.BMP; break;
                    case 2: /* GIF */  st = BarcodeLib.SaveTypes.GIF; break;
                    case 3: /* JPG */  st = BarcodeLib.SaveTypes.JPG; break;
                    case 4: /* PNG */  st = BarcodeLib.SaveTypes.PNG; break;
                    case 5: /* TIFF */ st = BarcodeLib.SaveTypes.TIFF; break;
                    default: break;
                }
                b.SaveImage(sv.FileName, st);
            }
        }
    }
}