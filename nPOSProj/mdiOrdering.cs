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


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                gotoNewOrder();
                return true;
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
            btnF3.Enabled = true;
            btnF4.Enabled = true;
            txtBoxDescription.Focus();
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("123123123123", "5", "Bilat", 100, 500);
            lblTotal.Text = CellSum().ToString("#,###,##0.00");
        }

        private void btnF1_Click(object sender, EventArgs e)
        {
            gotoNewOrder();
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
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                unlockcontrols();
                autoCompleteItem();
                ordervo.NewOrder();
                lblON.Text = ordervo.getON().ToString();
            }
        }
        private void gotoWholesale()
        {
            DialogResult dlg = MessageBox.Show("Do you wish to Select your Transaction to Wholesale?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
            }
        }
        private void gotoRetail()
        {
            DialogResult dlg = MessageBox.Show("Do you wish to Select your Transaction to Retail?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
            }
        }

        private void txtBoxDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cBoxKits.Checked == true)
                {
                    ordervo.Description = txtBoxDescription.Text;
                    txtBoxEAN.Text = ordervo.askEanKit();
                    ordervo.Wholesale = false; //Switch 0
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
                    ordervo.Wholesale = false; //Switch 1
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
        }

        private void txtBoxEAN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cBoxKits.Checked == true)
                {
                    ordervo.Ean = txtBoxEAN.Text;
                    txtBoxDescription.Text = ordervo.askKitName();
                    ordervo.Wholesale = false; //Switch 2
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
                    ordervo.Wholesale = false; //Switch 3
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
        }
    }
}