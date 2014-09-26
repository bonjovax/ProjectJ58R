using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BarcodeLib;

namespace nPOSProj
{
    public partial class mdiItems : Form
    {
        private Barcode b = new Barcode();
        private VO.ItemVO item = new VO.ItemVO();
        private DAO.LoginDAO login = new DAO.LoginDAO();
        private String eancom;
        private String item_tax_type_select;
        public mdiItems()
        {
            InitializeComponent();
        }
        private void trapDGV()
        {
            if (dataGridView1.RowCount == 0)
            {
                dataGridView1.Enabled = false;
            }
            else
                dataGridView1.Enabled = true;
        }

        private void mdiItems_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'npos_dbDataSet.inventory_items' table. You can move, or remove it, as needed.
                this.inventory_itemsTableAdapter.Fill(this.npos_dbDataSet.inventory_items);
                b.Alignment = AlignmentPositions.CENTER;
                b.Width = 250;
                b.Height = 100;
                TYPE t = TYPE.CODE39;
                b.IncludeLabel = true;
                b.LabelPosition = LabelPositions.BOTTOMCENTER;
                barcode.Image = b.Encode(t, "0");
                txtSearchEan.Focus();
            }
            catch (Exception)
            {
            }
            trapDGV();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBoxQty.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            eancom = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtBonxEAN.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtBoxRPrice.Text = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value).ToString("#,###,##0.00");
            txtBoxWholesalePrice.Text = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[5].Value).ToString("#,###,##0.00");
            if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString() == "")
            {
                btnPatch.Enabled = true;
            }
            if (dataGridView1.SelectedRows[0].Cells[7].Value.ToString() == "V")
            {
                rdVatable.Checked = true;
            }
            if (dataGridView1.SelectedRows[0].Cells[7].Value.ToString() == "E")
            {
                rdE.Checked = true;
            }
            if (dataGridView1.SelectedRows[0].Cells[7].Value.ToString() == "Z")
            {
                rdZ.Checked = true;
            }
            String userName = frmLogin.User.user_name;
            login.catchUsername(userName);
            if (login.hasUser_Accounts())
            {
                btnUp.Enabled = true;
            }
            txtBoxQty.ReadOnly = false;
            txtBonxEAN.ReadOnly = false;
            txtBoxRPrice.ReadOnly = false;
            txtBoxWholesalePrice.ReadOnly = false;
            bcSave.Enabled = true;
            btnReturn.Enabled = false;
            try
            {
                b.Alignment = AlignmentPositions.CENTER;
                b.Width = 250;
                b.Height = 100;
                TYPE t = TYPE.EAN13;
                b.IncludeLabel = true;
                b.LabelPosition = LabelPositions.BOTTOMCENTER;
                barcode.Image = b.Encode(t, dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            }
            catch (Exception)
            {
                b.Alignment = AlignmentPositions.CENTER;
                TYPE t = TYPE.CODE39;
                b.IncludeLabel = true;
                b.LabelPosition = LabelPositions.BOTTOMCENTER;
                try
                {
                    barcode.Image = b.Encode(t, dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                }
                catch (Exception)
                {
                    barcode.Image = b.Encode(t, "0");
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Do You Wish To Update?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    if (Convert.ToInt32(txtBoxQty.Text) >= 0 && Convert.ToDouble(txtBoxRPrice.Text) >= 0 && Convert.ToDouble(txtBoxWholesalePrice.Text) >= 0)
                    {
                        if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString() == "")
                        {
                            MessageBox.Show("EAN Code Is Missing!\nPlease Patch New EAN Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            item.item_quantity = Convert.ToInt32(txtBoxQty.Text);
                            item.item_ean = txtBonxEAN.Text;
                            item.eanTmp = eancom;
                            item.item_retail_price = Convert.ToDouble(txtBoxRPrice.Text);
                            item.item_whole_price = Convert.ToDouble(txtBoxWholesalePrice.Text);
                            if (rdVatable.Checked == true)
                            {
                                item_tax_type_select = "V";
                            }
                            if (rdE.Checked == true)
                            {
                                item_tax_type_select = "E";
                            }
                            if (rdZ.Checked == true)
                            {
                                item_tax_type_select = "Z";
                            }
                            item.item_tax_type = item_tax_type_select;
                            item.stock_code = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                            item.UpdateItem();
                            dataGridView1.SelectedRows[0].Cells[0].Value = txtBoxQty.Text;
                            dataGridView1.SelectedRows[0].Cells[2].Value = txtBonxEAN.Text;
                            dataGridView1.SelectedRows[0].Cells[4].Value = Convert.ToDouble(txtBoxRPrice.Text).ToString("#,###,##0.00");
                            dataGridView1.SelectedRows[0].Cells[5].Value = Convert.ToDouble(txtBoxWholesalePrice.Text).ToString("#,###,##0.00");
                            dataGridView1.SelectedRows[0].Cells[7].Value = item_tax_type_select;
                            txtBoxQty.ReadOnly = true;
                            txtBonxEAN.ReadOnly = true;
                            txtBoxRPrice.ReadOnly = true;
                            txtBoxWholesalePrice.ReadOnly = true;
                            btnUp.Enabled = false;
                            btnReturn.Enabled = false;
                            bcSave.Enabled = false;
                        }
                    }
                    else
                        MessageBox.Show("Negative Value Will Not Be Considered!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception)
                {
                    MessageBox.Show("Duplicate Input Not Allowed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBonxEAN_TextChanged(object sender, EventArgs e)
        {
            try
            {
                b.Alignment = AlignmentPositions.CENTER;
                b.Width = 250;
                b.Height = 100;
                TYPE t = TYPE.EAN13;
                b.IncludeLabel = true;
                b.LabelPosition = LabelPositions.BOTTOMCENTER;
                barcode.Image = b.Encode(t, txtBonxEAN.Text);
            }
            catch (Exception)
            {
                b.Alignment = AlignmentPositions.CENTER;
                TYPE t = TYPE.CODE39;
                b.IncludeLabel = true;
                b.LabelPosition = LabelPositions.BOTTOMCENTER;
                try
                {
                    barcode.Image = b.Encode(t, txtBonxEAN.Text);
                }
                catch (Exception)
                {
                    barcode.Image = b.Encode(t, "0");
                }
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtBoxQty.Text) >= 0)
                {
                    if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value) >= Convert.ToInt32(txtBoxQty.Text))
                    {
                        item.item_quantity = Convert.ToInt32(txtBoxQty.Text);
                        item.stock_code = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                        Int32 final = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value) - Convert.ToInt32(txtBoxQty.Text);
                        item.TrasferItemToStock();
                        dataGridView1.SelectedRows[0].Cells[0].Value = final.ToString();
                        btnReturn.Enabled = false;
                    }
                    else
                        MessageBox.Show("You Have Not Enough Quantity to Transfer Back to Stocks", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show("Negative Value Will Not Be Considered!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check Databse Server! or Check your Input!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnReturn.Enabled = true;
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("InventoryItems");
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

        private void txtBonxEAN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtBoxRPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnPatch_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dlg = MessageBox.Show("Do you wish to Continue?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    if (txtBonxEAN.Text != "")
                    {
                        item.item_ean = txtBonxEAN.Text;
                        item.stock_code = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                        item.eanPatch();
                        dataGridView1.SelectedRows[0].Cells[2].Value = txtBonxEAN.Text;
                        btnPatch.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Input EAN is Missing", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtBonxEAN.Focus();
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Duplicate Input Not Allowed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.inventory_itemsTableAdapter.Fill(this.npos_dbDataSet.inventory_items);
        }

        private void txtSearchEan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.inventory_itemsTableAdapter.FillBy(this.npos_dbDataSet.inventory_items, txtSearchEan.Text);
                txtSearchEan.Clear();
            }
        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text != "")
            {
                this.inventory_itemsTableAdapter.FillBy1(this.npos_dbDataSet.inventory_items, txtBoxSearch.Text);
            }
            else
                this.inventory_itemsTableAdapter.Fill(this.npos_dbDataSet.inventory_items);
        }
    }
}