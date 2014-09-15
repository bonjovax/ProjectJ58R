using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace nPOSProj
{
    public partial class mdiQuotation : Form
    {
        AutoCompleteStringCollection collect = new AutoCompleteStringCollection();
        AutoCompleteStringCollection collect1 = new AutoCompleteStringCollection();
        private MySqlConnection con = new MySqlConnection();
        private Conf.dbs dbcon = new Conf.dbs();
        private VO.OrderVO ordervo = new VO.OrderVO();
        private Boolean wholesale = false;
        private Boolean start = false;
        public mdiQuotation()
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
            if (keyData == Keys.F1 && btnF1.Enabled == true)
            {
                gotoNewQuote();
                return true;
            }
            if (keyData == Keys.F2 && start == true && wholesale == false)
            {
                gotoWholesale();
                return true;
            }
            if (keyData == Keys.F2 && start == true && wholesale == true)
            {
                gotoRetail();
                return true;
            }
            if (keyData == Keys.F3 && btnF3.Enabled == true)
            {
                gotoVoid();
                return true;
            }
            if (keyData == Keys.F4 && btnF4.Enabled == true)
            {
                gotoCancelQuote();
                return true;
            }
            if (keyData == Keys.F5 && btnF5.Enabled == true)
            {
                gotoQuotePark();
                return true;
            }
            if (keyData == Keys.F7 && btnDone.Enabled == true)
            {
                gotoDone();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private Double CellSum()
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
        private void autoCompleteItem()
        {
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT stock_name AS sc FROM inventory_stocks ORDER BY stock_name ASC";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                        collect.Add(rdr["sc"].ToString());
                }
                rdr.Close();
                txtBoxDescription.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBoxDescription.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBoxDescription.AutoCompleteCustomSource = collect;
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }
        private void autoCompleteKits()
        {
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT kit_name AS sc FROM inventory_items WHERE is_kit = 1 ORDER BY kit_name ASC";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                        collect1.Add(rdr["sc"].ToString());
                }
                rdr.Close();
                txtBoxDescription.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBoxDescription.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBoxDescription.AutoCompleteCustomSource = collect1;
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }
        private void lockcontrols()
        {
            txtBoxEAN.ReadOnly = true;
            txtBoxDescription.ReadOnly = true;
            //
            cBoxKits.Enabled = false;
            btnClearController.Enabled = false;
            dataGridView1.Enabled = false;
        }
        private void unlockcontrols()
        {
            txtBoxEAN.ReadOnly = false;
            txtBoxDescription.ReadOnly = false;
            //
            cBoxKits.Enabled = true;
            btnClearController.Enabled = true;
            dataGridView1.Enabled = true;
            btnF1.Enabled = false;
            btnF2A.Enabled = true;
            btnF4.Enabled = true;
            txtBoxDescription.Focus();
        }
        private void checkRowCount()
        {
            if (dataGridView1.Rows.Count != 0)
            {
                btnF5.Enabled = false;
                btnF4.Enabled = true;
            }
            else
            {
                btnF5.Enabled = true;
                btnF4.Enabled = false;
            }
        }
        private void clearboxes()
        {
            txtBoxQuantity.Text = "0";
            rdPrice.Text = "0.00";
            rdTotal.Text = "0.00";
            txtBoxEAN.Clear();
            txtBoxDescription.Clear();
            txtBoxDescription.Focus();
            txtBoxDescription.ReadOnly = false;
            txtBoxEAN.ReadOnly = false;
            txtBoxQuantity.ReadOnly = true;
            cBoxKits.Checked = false;
        }
        private void clearboxesTrans()
        {
            txtBoxQuantity.Text = "0";
            rdPrice.Text = "0.00";
            rdTotal.Text = "0.00";
            txtBoxEAN.Clear();
            txtBoxDescription.Clear();
            rdCustomerCode.Clear();
            rdCompany.Clear();
            rdAddress.Clear();
        }

        private void gotoNewQuote()
        {
            using (mQuoteNew newquote = new mQuoteNew())
            {
                newquote.ShowDialog();
                if (newquote.NewQuote != false)
                {
                    rdCustomerCode.Text = newquote.Custcode;
                    rdCompany.Text = newquote.Company;
                    rdAddress.Text = newquote.Address;
                    unlockcontrols();
                    autoCompleteItem();
                    lblQN.Text = ordervo.getQN().ToString();
                    checkRowCount();
                    start = true;
                    btnDone.Enabled = true;
                }
            }
        }
        private void gotoWholesale()
        {
            DialogResult dlg = MessageBox.Show("Do you wish to select your Transaction to Wholesale?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                clearboxes();
                wholesale = true;
                btnF2A.Enabled = false;
                btnF2B.Visible = true;
            }
        }

        private void gotoDone()
        {
            DialogResult dlg = MessageBox.Show("Do you wish to Proceed?", "Proceed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                dataGridView1.Rows.Clear();
                //
                lockcontrols();
                clearboxesTrans();
                //
                txtBoxQuantity.Text = "0";
                txtBoxQuantity.ReadOnly = true;
                //
                btnF2B.Visible = false;
                btnF2A.Enabled = false;
                wholesale = false;
                btnF4.Enabled = false;
                btnF5.Enabled = true;
                btnF1.Enabled = true;
                btnDone.Enabled = false;
                lblQN.Text = "0";
                lblTotal.Text = "0.00";
            }
        }

        private void gotoRetail()
        {
            DialogResult dlg = MessageBox.Show("Do you wish to select your Transaction to Retail?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                clearboxes();
                wholesale = false;
                btnF2A.Enabled = true;
                btnF2B.Visible = false;
            }
        }
        private void gotoVoid()
        {
            try
            {
                ordervo.Quotation_no = Convert.ToInt32(lblQN.Text);
                ordervo.Ean = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                ordervo.voidQuote();
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                checkRowCount();
                lblTotal.Text = CellSum().ToString("#,###,##0.00");
                ordervo.Order_total_amt = Convert.ToDouble(lblTotal.Text);
                ordervo.Quotation_no = Convert.ToInt32(lblQN.Text);
                ordervo.UpdateTotalQuote();
                btnF3.Enabled = false;
                clearboxes();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check Database Server Connection", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gotoCancelQuote()
        {
            try
            {
                DialogResult dlg = MessageBox.Show("Do you wish to Cancel all of your Quotation?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    ordervo.Quotation_no = Convert.ToInt32(lblQN.Text);
                    ordervo.cancelQ();
                    dataGridView1.Rows.Clear();
                    //
                    lockcontrols();
                    clearboxesTrans();
                    //
                    txtBoxQuantity.Text = "0";
                    txtBoxQuantity.ReadOnly = true;
                    //
                    btnF2B.Visible = false;
                    btnF2A.Enabled = false;
                    wholesale = false;
                    btnF4.Enabled = false;
                    btnF5.Enabled = true;
                    btnF1.Enabled = true;
                    lblQN.Text = "x";
                    lblTotal.Text = "0.00";
                    btnDone.Enabled = false;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check Database Server Connection", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gotoQuotePark()
        {
            using (mQuotePark park = new mQuotePark())
            {
                park.ShowDialog();
                if (park.Quotation_no == 0)
                {
                    //Wala
                }
                else
                {
                    lblQN.Text = park.Quotation_no.ToString();
                    //dataGridView1.Rows.Clear();
                    //1 Data Load
                    this.LoadQuoteDataItem(park.Quotation_no);
                    //2 Data Load Kit
                    this.LoadQuoteDataItemKit(park.Quotation_no);
                    lblTotal.Text = CellSum().ToString("#,###,##0.00");
                    clearboxes();
                    unlockcontrols();
                    autoCompleteItem();
                    checkRowCount();
                    btnDone.Enabled = true;
                }
            }
        }
        private void btnESC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnF1_Click(object sender, EventArgs e)
        {
            gotoNewQuote();
        }

        private void txtBoxDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (cBoxKits.Checked == true)
                    {
                        ordervo.Description = txtBoxDescription.Text;
                        txtBoxEAN.Text = ordervo.askEanKit();
                        ordervo.Wholesale = wholesale; //Switch 0
                        rdPrice.Text = ordervo.askPriceByKitName().ToString("#,###,##0.00");
                        ordervo.Ean = txtBoxEAN.Text;
                        if (ordervo.askItemDescriptionKit() == true)
                        {
                            txtBoxQuantity.ReadOnly = false;
                            txtBoxQuantity.Focus();
                        }
                        else
                        {
                            txtBoxQuantity.ReadOnly = true;
                            txtBoxQuantity.Text = "0";
                        }
                    }
                    else
                    {
                        ordervo.Description = txtBoxDescription.Text;
                        txtBoxEAN.Text = ordervo.askEan();
                        ordervo.Wholesale = wholesale; //Switch 1
                        rdPrice.Text = ordervo.askPriceByName().ToString("#,###,##0.00");
                        ordervo.Ean = txtBoxEAN.Text;
                        if (ordervo.askItemDescription() == true)
                        {
                            txtBoxEAN.ReadOnly = true;
                            txtBoxDescription.ReadOnly = true;
                            txtBoxQuantity.ReadOnly = false;
                            txtBoxQuantity.Focus();
                        }
                        else
                        {
                            txtBoxEAN.ReadOnly = false;
                            txtBoxDescription.ReadOnly = false;
                            txtBoxQuantity.ReadOnly = true;
                            txtBoxQuantity.Text = "0";
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Check Database Server Connection", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnF2A_Click(object sender, EventArgs e)
        {
            gotoWholesale();
        }

        private void btnF2B_Click(object sender, EventArgs e)
        {
            gotoRetail();
        }

        private void cBoxKits_CheckedChanged(object sender, EventArgs e)
        {
            txtBoxQuantity.Text = "0";
            rdPrice.Text = "0.00";
            rdTotal.Text = "0.00";
            txtBoxEAN.Clear();
            txtBoxDescription.Clear();
            txtBoxDescription.Focus();
            txtBoxDescription.ReadOnly = false;
            txtBoxEAN.ReadOnly = false;
            txtBoxQuantity.ReadOnly = true;
            if (cBoxKits.Checked == true)
            {
                autoCompleteKits();
            }
            else
            {
                autoCompleteItem();
            }
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

        private void txtBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtBoxEAN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (cBoxKits.Checked == true)
                    {
                        ordervo.Ean = txtBoxEAN.Text;
                        txtBoxDescription.Text = ordervo.askKitName();
                        ordervo.Wholesale = wholesale; //Switch 2
                        rdPrice.Text = ordervo.askPriceByEanKit().ToString("#,###,##0.00");
                        ordervo.Description = txtBoxDescription.Text;
                        if (ordervo.askItemEanKit() == true)
                        {
                            txtBoxDescription.ReadOnly = true;
                            txtBoxEAN.ReadOnly = true;
                            txtBoxQuantity.ReadOnly = false;
                            txtBoxQuantity.Focus();
                        }
                        else
                        {
                            txtBoxDescription.ReadOnly = false;
                            txtBoxEAN.ReadOnly = false;
                            txtBoxQuantity.ReadOnly = true;
                            txtBoxQuantity.Text = "0";
                        }
                    }
                    else
                    {
                        ordervo.Ean = txtBoxEAN.Text;
                        txtBoxDescription.Text = ordervo.askDescription();
                        ordervo.Wholesale = wholesale; //Switch 3
                        rdPrice.Text = ordervo.askPriceByEan().ToString("#,###,##0.00");
                        ordervo.Description = txtBoxDescription.Text;
                        if (ordervo.askItemEan() == true)
                        {
                            txtBoxDescription.ReadOnly = true;
                            txtBoxEAN.ReadOnly = true;
                            txtBoxQuantity.ReadOnly = false;
                            txtBoxQuantity.Focus();
                        }
                        else
                        {
                            txtBoxDescription.ReadOnly = false;
                            txtBoxEAN.ReadOnly = false;
                            txtBoxQuantity.ReadOnly = true;
                            txtBoxQuantity.Text = "0";
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Check Database Server Connection", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadQuoteDataItem(Int32 Quotation_no)
        {
            ordervo = new VO.OrderVO();
            ordervo.Quotation_no = Quotation_no;
            String[,] grabData = ordervo.ReadItemQuote();
            try
            {
                for (int o = 0; o < grabData.GetLength(1); o++)
                {
                    dataGridView1.Rows.Add(grabData[0, o].ToString(), grabData[1, o].ToString(), grabData[2, o].ToString(), Convert.ToDouble(grabData[3, o].ToString()).ToString("#,###,##0.00"), Convert.ToDouble(grabData[4, o].ToString()).ToString("#,###,##0.00"));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadQuoteDataItemKit(Int32 Quotation_no)
        {
            ordervo = new VO.OrderVO();
            ordervo.Quotation_no = Quotation_no;
            String[,] grabData = ordervo.ReadItemKitsQuote();
            try
            {
                for (int o = 0; o < grabData.GetLength(1); o++)
                {
                    dataGridView1.Rows.Add(grabData[0, o].ToString(), grabData[1, o].ToString(), grabData[2, o].ToString(), Convert.ToDouble(grabData[3, o].ToString()).ToString("#,###,##0.00"), Convert.ToDouble(grabData[4, o].ToString()).ToString("#,###,##0.00"));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearController_Click(object sender, EventArgs e)
        {
            clearboxes();
        }

        private void txtBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxQuantity.Text != "")
            {
                Double totalAmt = 0;
                totalAmt = Convert.ToDouble(txtBoxQuantity.Text) * Convert.ToDouble(rdPrice.Text);
                rdTotal.Text = totalAmt.ToString("#,###,##0.00");
                if (txtBoxQuantity.Text != "0" && rdTotal.Text != "0.00")
                {
                    btnAddToQuote.Enabled = true;
                }
                else
                    btnAddToQuote.Enabled = false;
            }
            else
            {
                txtBoxQuantity.Text = "0";
            }
        }

        private void txtBoxQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddToQuote.Focus();
            }
        }

        private void btnAddToQuote_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean naa = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString() == txtBoxEAN.Text && row.Cells[2].Value.ToString() == txtBoxDescription.Text)
                    {
                        ordervo.Quotation_no = Convert.ToInt32(lblQN.Text);
                        ordervo.Ean = txtBoxEAN.Text;
                        ordervo.Pos_qty = Convert.ToInt32(txtBoxQuantity.Text);
                        ordervo.Order_item_amount = Convert.ToDouble(rdPrice.Text);
                        ordervo.Quote_total = Convert.ToDouble(rdTotal.Text);
                        ordervo.updateQuote();
                        row.Cells[1].Value = Convert.ToInt32(txtBoxQuantity.Text) + Convert.ToInt32(row.Cells[1].Value);
                        row.Cells[4].Value = Convert.ToDouble(rdTotal.Text) + Convert.ToDouble(row.Cells[4].Value);
                        naa = true;
                    }
                }
                if (!naa)
                {
                    ordervo.Quotation_no = Convert.ToInt32(lblQN.Text);
                    ordervo.Ean = txtBoxEAN.Text;
                    ordervo.Pos_qty = Convert.ToInt32(txtBoxQuantity.Text);
                    ordervo.Order_item_amount = Convert.ToDouble(rdPrice.Text);
                    ordervo.Quote_total = Convert.ToDouble(rdTotal.Text);
                    ordervo.addQuote();
                    dataGridView1.Rows.Add(txtBoxEAN.Text, txtBoxQuantity.Text, txtBoxDescription.Text, rdPrice.Text, rdTotal.Text);
                }
                lblTotal.Text = CellSum().ToString("#,###,##0.00");
                ordervo.Order_total_amt = Convert.ToDouble(lblTotal.Text);
                ordervo.Quotation_no = Convert.ToInt32(lblQN.Text);
                ordervo.UpdateTotalQuote();
                checkRowCount();
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                clearboxes();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check Database Server Connection", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnF3_Click(object sender, EventArgs e)
        {
            gotoVoid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
            }
            else
            {
                btnF3.Enabled = true;
            }
        }

        private void btnF4_Click(object sender, EventArgs e)
        {
            gotoCancelQuote();
        }

        private void btnF5_Click(object sender, EventArgs e)
        {
            gotoQuotePark();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            gotoDone();
        }
    }
}