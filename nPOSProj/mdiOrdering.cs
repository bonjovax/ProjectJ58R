﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace nPOSProj
{
    public partial class mdiOrdering : Form
    {
        AutoCompleteStringCollection collect = new AutoCompleteStringCollection();
        AutoCompleteStringCollection collect1 = new AutoCompleteStringCollection();
        private MySqlConnection con = new MySqlConnection();
        private Conf.dbs dbcon = new Conf.dbs();
        private VO.OrderVO ordervo = new VO.OrderVO();
        private Boolean wholesale = false;
        private Boolean start = false;
        public mdiOrdering()
        {
            InitializeComponent();
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

        private void LoadDataItem(Int32 order_no)
        {
            ordervo = new VO.OrderVO();
            ordervo.Pos_orderno = order_no;
            String[,] grabData = ordervo.ReadParkItem();
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1 && btnF1.Enabled == true)
            {
                gotoNewOrder();
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
            }
            if (keyData == Keys.F3 && btnF3.Enabled == true)
            {
                gotoVoid();
                return true;
            }
            if (keyData == Keys.F4 && btnF4.Enabled == true)
            {
                gotoCancelTrans();
                return true;
            }
            if (keyData == Keys.F5 && btnF5.Enabled == true)
            {
                gotoPark();
                return true;
            }
            if (keyData == Keys.F6 && btnDone.Enabled == true)
            {
                gotoDone();
            }
            if (keyData == Keys.F7 && btnPrint.Enabled == true)
            {
                gotoPrintOrder();
                return true;
            }
            if (keyData == Keys.F12)
            {
                txtBoxDescription.Focus();
            }
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void mdiOrdering_Load(object sender, EventArgs e)
        {

        }

        private void gotoPrintOrder()
        {
            using (frmRptSalesOrder so = new frmRptSalesOrder())
            {
                try
                {
                    so.Order_no = Convert.ToInt32(lblON.Text);
                    so.ShowDialog();
                }
                catch (Exception)
                {
                    MessageBox.Show("error", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnF6_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void unlockcustomerinfo()
        {
            txtBoxName.ReadOnly = false;
            txtBoxAdd.ReadOnly = false;
        }

        private void lockcustomerinfo()
        {
            txtBoxName.ReadOnly = true;
            txtBoxAdd.ReadOnly = true;
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean naa = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString() == txtBoxEAN.Text && row.Cells[2].Value.ToString() == txtBoxDescription.Text)
                    {
                        ordervo.Pos_orderno = Convert.ToInt32(lblON.Text);
                        ordervo.Ean = txtBoxEAN.Text;
                        ordervo.Pos_qty = Convert.ToInt32(txtBoxQuantity.Text);
                        ordervo.Order_item_amount = Convert.ToDouble(rdPrice.Text);
                        ordervo.Pos_amt = Convert.ToDouble(rdTotal.Text);
                        ordervo.UpdateSameItem();
                        row.Cells[1].Value = Convert.ToInt32(txtBoxQuantity.Text) + Convert.ToInt32(row.Cells[1].Value);
                        row.Cells[4].Value = Convert.ToDouble(rdTotal.Text) + Convert.ToDouble(row.Cells[4].Value);
                        naa = true;
                    }
                }
                if (!naa)
                {
                    ordervo.Pos_orderno = Convert.ToInt32(lblON.Text);
                    ordervo.Ean = txtBoxEAN.Text;
                    ordervo.Pos_qty = Convert.ToInt32(txtBoxQuantity.Text);
                    ordervo.Order_item_amount = Convert.ToDouble(rdPrice.Text);
                    ordervo.Pos_amt = Convert.ToDouble(rdTotal.Text);
                    ordervo.Add();
                    dataGridView1.Rows.Add(txtBoxEAN.Text, txtBoxQuantity.Text, txtBoxDescription.Text, rdPrice.Text, rdTotal.Text);
                }
                lblTotal.Text = CellSum().ToString("#,###,##0.00");
                ordervo.Order_total_amt = Convert.ToDouble(lblTotal.Text);
                ordervo.Pos_orderno = Convert.ToInt32(lblON.Text);
                ordervo.UpdateTotal();
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                clearboxes();
                txtBoxEAN.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check Database Server Connection", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnF1_Click(object sender, EventArgs e)
        {
            gotoNewOrder();
        }

        private void clearboxes()
        {
            txtBoxQuantity.Text = "0";
            rdPrice.Text = "0.00";
            rdTotal.Text = "0.00";
            rdQtyA.Text = "0";
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
            rdQtyA.Text = "0";
            txtBoxEAN.Clear();
            txtBoxDescription.Clear();
        }

        private void cBoxKits_CheckedChanged(object sender, EventArgs e)
        {
            txtBoxQuantity.Text = "0";
            rdPrice.Text = "0.00";
            rdTotal.Text = "0.00";
            rdQtyA.Text = "0";
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

        private void gotoNewOrder()
        {
            DialogResult dlg = MessageBox.Show("Do you wish to proceed your New Order?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    unlockcustomerinfo();
                    unlockcontrols();
                    autoCompleteItem();
                    ordervo.NewOrder();
                    lblON.Text = ordervo.getON().ToString();
                    checkRowCount();
                    start = true;
                    btnDone.Enabled = true;
                    txtBoxName.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check Database Server Connection", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        rdQtyA.Text = ordervo.askQtyByKitName().ToString();
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
                        rdQtyA.Text = ordervo.askQtyByDescription().ToString();
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
                        rdQtyA.Text = ordervo.askQtyEANKit().ToString();
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
                        rdQtyA.Text = ordervo.askQtyByEAN().ToString();
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

        private void txtBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxQuantity.Text != "")
            {
                Double totalAmt = 0;
                totalAmt = Convert.ToDouble(txtBoxQuantity.Text) * Convert.ToDouble(rdPrice.Text);
                rdTotal.Text = totalAmt.ToString("#,###,##0.00");
                if (Convert.ToInt32(rdQtyA.Text) >= Convert.ToInt32(txtBoxQuantity.Text) && Convert.ToInt32(txtBoxQuantity.Text) != 0)
                {
                    btnAddToOrder.Enabled = true;
                }
                else
                {
                    btnAddToOrder.Enabled = false;
                }
            }
            else
            {
                txtBoxQuantity.Text = "0";
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

        private void btnClearController_Click(object sender, EventArgs e)
        {
            clearboxes();
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

        private void checkRowCount()
        {
            if (dataGridView1.Rows.Count != 0)
            {
                btnF5.Enabled = false;
                btnF4.Enabled = true;
                //btnPrint.Enabled = true;
            }
            else
            {
                btnF5.Enabled = true;
                btnF4.Enabled = false;
                //btnPrint.Enabled = false;
            }
        }

        private void gotoVoid()
        {
            try
            {
                ordervo.Pos_qty = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
                ordervo.Pos_orderno = Convert.ToInt32(lblON.Text);
                ordervo.Ean = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                ordervo.VoidItem();
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                checkRowCount();
                lblTotal.Text = CellSum().ToString("#,###,##0.00");
                ordervo.Order_total_amt = Convert.ToDouble(lblTotal.Text);
                ordervo.Pos_orderno = Convert.ToInt32(lblON.Text);
                ordervo.UpdateTotal();
                btnF3.Enabled = false;
                clearboxes();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check Database Server Connection", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void gotoCancelTrans()
        {
            try
            {
                DialogResult dlg = MessageBox.Show("Do you wish to Cancel all of your Transaction?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        ordervo.Pos_orderno = Convert.ToInt32(lblON.Text);
                        ordervo.Ean = row.Cells[0].Value.ToString();
                        ordervo.Pos_qty = Convert.ToInt32(row.Cells[1].Value);
                        ordervo.ReturnAndDeleteTrans();
                    }
                    ordervo.Pos_orderno = Convert.ToInt32(lblON.Text);
                    ordervo.CancelTrans();
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
                    lblON.Text = "x";
                    lblTotal.Text = "0.00";
                    btnDone.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check Database Server Connection", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                lblON.Text = "0";
                lblTotal.Text = "0.00";
            }
        }

        private void gotoPark()
        {
            using (mOrderPark park = new mOrderPark())
            {
                park.ShowDialog();
                if (park.Order_no == 0)
                {
                    //Wala
                }
                else
                {
                    lblON.Text = park.Order_no.ToString();
                    dataGridView1.Rows.Clear();
                    this.LoadDataItem(park.Order_no);
                    lblTotal.Text = CellSum().ToString("#,###,##0.00");
                    clearboxes();
                    unlockcontrols();
                    autoCompleteItem();
                    checkRowCount();
                    btnDone.Enabled = true;
                    txtBoxEAN.Focus();
                }
            }
        }

        private void btnF3_Click(object sender, EventArgs e)
        {
            gotoVoid();
        }

        private void txtBoxQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToInt32(rdQtyA.Text) >= Convert.ToInt32(txtBoxQuantity.Text) && Convert.ToInt32(txtBoxQuantity.Text) != 0)
                {
                    btnAddToOrder.Focus();
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

        private void btnF4_Click(object sender, EventArgs e)
        {
            gotoCancelTrans();
        }

        private void btnF5_Click(object sender, EventArgs e)
        {
            gotoPark();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            gotoDone();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            gotoPrintOrder();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            Convert.ToInt32(lblON.Text);
            String name = txtBoxName.Text;
            String address = txtBoxAdd.Text;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE order_store SET order_customer = ?customer_name, order_address = ?customer_address ";
            query += "WHERE order_no ='"+ lblON.Text +"'";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?customer_name", name);
                cmd.Parameters.AddWithValue("?customer_address", address);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

    }
}