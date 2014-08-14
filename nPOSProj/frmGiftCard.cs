using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BarcodeLib;
using System.Text.RegularExpressions;
using System.Data;

namespace nPOSProj
{
    public partial class frmGiftCard : Form
    {
        private Barcode b = new Barcode();
        private VO.GiftCardVO gift;
        private Conf.Rgx r;
        public frmGiftCard()
        {
            InitializeComponent();
        }

        private void frmGiftCard_Load(object sender, EventArgs e)
        {
            b.Alignment = AlignmentPositions.CENTER;
            b.Width = 313;
            b.Height = 57;
            TYPE t = TYPE.CODE39;
            b.IncludeLabel = true;
            b.LabelPosition = LabelPositions.BOTTOMCENTER;
            barcode.Image = b.Encode(t, "0");
            txtBoxCardNo.Focus();
            //
            gift = new VO.GiftCardVO();
            String[,] grabData = gift.ReadGC();
            try
            {
                dataGridView1.Rows.Clear();
                for (int x = 0; x < grabData.GetLength(1); x++)
                {
                    dataGridView1.Rows.Add(grabData[0, x].ToString(), Convert.ToDouble(grabData[1, x]), grabData[2, x].ToString(), Convert.ToDateTime(grabData[3, x]));
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtBoxCardNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBoxCardNo.Text != "")
                {
                    b.Alignment = AlignmentPositions.CENTER;
                    b.Width = 313;
                    b.Height = 57;
                    TYPE t = TYPE.CODE39;
                    b.IncludeLabel = true;
                    b.LabelPosition = LabelPositions.BOTTOMCENTER;
                    barcode.Image = b.Encode(t, txtBoxCardNo.Text);
                    bcSave.Enabled = true;
                }
                else
                {
                    TYPE t = TYPE.CODE39;
                    b.IncludeLabel = true;
                    b.LabelPosition = LabelPositions.BOTTOMCENTER;
                    barcode.Image = b.Encode(t, "0");
                    bcSave.Enabled = false;
                }
                if (txtBoxCardNo.Text != "" && txtBoxAmount.Text != "" && dateTimePicker1.Text != "")
                {
                    btnAdd.Enabled = true;
                }
                else
                    btnAdd.Enabled = false;
            }
            catch (Exception)
            {
            }
        }

        private void txtBoxAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCardNo.Text != "" && txtBoxAmount.Text != "" && dateTimePicker1.Text != "")
            {
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }

        private void txtBoxHolder_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCardNo.Text != "" && txtBoxAmount.Text != "" && dateTimePicker1.Text != "")
            {
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (txtBoxCardNo.Text != "" && txtBoxAmount.Text != "" && dateTimePicker1.Text != "")
            {
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }

        private void txtBoxCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxAmount.Focus();
            }
        }

        private void txtBoxAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxHolder.Focus();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you wish to Continue?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            r = new Conf.Rgx();
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    if (Regex.IsMatch(txtBoxAmount.Text, r.Amount()))
                    {
                        dataGridView1.Rows.Add(txtBoxCardNo.Text, Convert.ToDouble(txtBoxAmount.Text), txtBoxHolder.Text, Convert.ToDateTime(dateTimePicker1.Text).ToString("M/dd/yyy"));
                        //
                        gift = new VO.GiftCardVO();
                        gift.Gc_cardno = txtBoxCardNo.Text;
                        gift.Gc_amount = Convert.ToDouble(txtBoxAmount.Text);
                        gift.Gc_holder = txtBoxHolder.Text;
                        gift.Gc_validuntil = Convert.ToDateTime(dateTimePicker1.Text);
                        gift.AddGC();
                        //Event
                        txtBoxHolder.Clear();
                        txtBoxAmount.Clear();
                        txtBoxCardNo.Clear();
                        txtBoxCardNo.Focus();
                    }
                    else
                        MessageBox.Show("Please Enter the Amount Properly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Check Database Server!", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            gift = new VO.GiftCardVO();
            DialogResult dr = MessageBox.Show("Do you wish to Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            gift.Gc_cardno = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                            gift.DeleteGC();
                            dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
                            btnDelete.Enabled = false;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Check Database Server!", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtBoxCardNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            b.Alignment = AlignmentPositions.CENTER;
            b.Width = 313;
            b.Height = 57;
            TYPE t = TYPE.CODE39;
            b.IncludeLabel = true;
            b.LabelPosition = LabelPositions.BOTTOMCENTER;
            barcode.Image = b.Encode(t, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            bcSave.Enabled = true;
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("GiftCard");
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