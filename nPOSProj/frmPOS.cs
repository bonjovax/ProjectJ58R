﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace nPOSProj
{
    public partial class frmPOS : Form
    {
        private bool adminDrawer = false;
        private bool reprint = false;
        #region System Config
        private Double taxP;
        private String taxDisplay;
        private String compName;
        private String address1;
        private String address2;
        private String contact;
        private String store_op;
        private String permit_no;
        private String TIN;
        private String TaxT;
        private String machine_no;
        private Int16 all_items_tax;
        #endregion
        private Int16 selector = 0;
        private String itemTT;
        private MySqlConnection con = new MySqlConnection();
        private Conf.dbs dbcon = new Conf.dbs();
        private Conf.Crypto crypt = new Conf.Crypto();
        private Conf.BIR bir = new Conf.BIR(); //Bureau of Internal Revenue - PH
        private DAO.LoginDAO login;
        private VO.ItemVO itemvo = new VO.ItemVO();
        private VO.PosVO pos = new VO.PosVO();
        private VO.CustomersVO customer = new VO.CustomersVO();
        private VO.GiftCardVO gcard = new VO.GiftCardVO();
        private bool wholsale_select = false;
        private bool proceeds = false;
        private bool nosale = true;
        private Double price;
        private Double totalVar = 0;
        //
        private Int32 OrNo;
        //
        private Double computerItemQty;
        private bool found = false;
        private bool found_kit = false;
        private Int32 counted = 0;
        #region Temporary DataReceipt
        private Double getDTotalAmt = 0;
        //Cash
        private Double Tender = 0;
        private Double Change = 0;
        //Debit-Credit Card
        private String cardNo;
        private String cardType;
        private Double cardAmount = 0;
        //Bank Cheque
        private String checkNo;
        private String BankNBranch;
        private Double checkAmount = 0;
        //Accounts
        private String CustCode;
        private String Company;
        private Double arAmount = 0;
        //Gift Cards
        private String gCardno;
        private String validU;
        private Double gAmount = 0;
        //

        #endregion
        #region Discount Variable
        private Double getTotalAmt;
        private bool discountTx = false;
        #endregion
        //
        private Int32 orderNo = 0;
        //Catch
        private String catchEan;
        private Int32 catchQty = 0;
        private Double catchPrice = 0;
        //

        public frmPOS()
        {
            InitializeComponent();
        }
        #region Secretive Override Form
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;
            const int WM_NCLBUTTONDBLCLK = 0x00A3; //double click on a title bar a.k.a. non-client area of the form

            switch (m.Msg)
            {
                case WM_SYSCOMMAND:             //preventing the form from being moved by the mouse.
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            if (m.Msg == WM_NCLBUTTONDBLCLK)       //preventing the form being resized by the mouse double click on the title bar.
            {
                m.Result = IntPtr.Zero;
                return;
            }

            base.WndProc(ref m);
        }
        #endregion
        #region Print Receipt
        private static string Truncate(string source, int length)
        {
            if (source.Length > length)
            {
                source = source.Substring(0, length);
            }
            return source;
        }
        private void getValidUntil(String gc_cardno)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT gc_validuntil AS a FROM gc_core ";
            query += "WHERE (gc_cardno = ?gc_cardno)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?gc_cardno", gc_cardno);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    validU = rdr["a"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                rdDescription.Text = "Cannot Get Get Breakdowns!!";
            }
            finally
            {
                con.Close();
            }
        }
        private void PrintReceipt()
        {
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.Print();
        }
        private void PrintNoSale()
        {
            DrawerPing();    
            printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument2_PrintPage);
            printDocument2.Print();
        }

        void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            frmLogin fl = new frmLogin();
            Graphics graphic = e.Graphics;
            Font font = new Font("FontA11", 9.0f);

            float fontHeight = font.GetHeight();
            int startX = 32;
            int startY = 10;

            #region Header
            graphic.DrawString(compName, new Font("FontA11", 9.0f, FontStyle.Bold), Brushes.Black, startX, startY);
            graphic.DrawString(address2, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 45, 30);
            //graphic.DrawString(address2, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 38, 45);
            //graphic.DrawString(contact, new Font("Tahoma", 11), new SolidBrush(Color.Black), 53, 60);
            //graphic.DrawString("Owned & Operated By: " + store_op, new Font("Tahoma", 11), new SolidBrush(Color.Black), 5, 75);
            graphic.DrawString("Permit No: " + permit_no, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 63, 60);
            graphic.DrawString("TIN: " + TIN + "" + TaxT, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 63, 75);
            graphic.DrawString("Accreditation No: " + bir.AccreditationNo(), new Font("FontA11", 7.8f), new SolidBrush(Color.Black), 4, 92);
            graphic.DrawString("Serial No: " + bir.SerialNo(), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 81, 105);
            graphic.DrawString("Machine Code: " + machine_no, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 63, 120);
            graphic.DrawString("---------------------------------------------------", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 3, 135);
            graphic.DrawString(DateTime.Now.ToString("MMM dd, yyyy") + " " + "(" + DateTime.Now.ToString("ddd") + ")", font, new SolidBrush(Color.Black), 5, 150);
            graphic.DrawString(DateTime.Now.ToString("hh:mm tt"), font, new SolidBrush(Color.Black), 180, 150);
            graphic.DrawString("SI# " + OrNo, font, new SolidBrush(Color.Black), 5, 165);
            #endregion
            graphic.DrawString("N O   S A L E", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 90, 210);
        }

        void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            frmLogin fl = new frmLogin();
            Graphics graphic = e.Graphics;
            Font font = new Font("FontA11", 9.0f);

            float fontHeight = font.GetHeight();
            int startX = 32;
            int startY = 10;
            int offset = 40;

            #region Header
            graphic.DrawString(compName, new Font("FontA11", 9.0f, FontStyle.Bold), Brushes.Black, startX, startY);
            graphic.DrawString(address2, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 45, 30);
            //graphic.DrawString(address2, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 24, 45);
            //graphic.DrawString(contact, new Font("Tahoma", 11), new SolidBrush(Color.Black), 53, 60);
            //graphic.DrawString("Owned & Operated By: " + store_op, new Font("Tahoma", 11), new SolidBrush(Color.Black), 5, 75);
            //graphic.DrawString("Permit No: " + permit_no, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 63, 60);
            graphic.DrawString("TIN: " + TIN + "" + TaxT, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 63, 45);
            //graphic.DrawString("Accreditation No: " + bir.AccreditationNo(), new Font("FontA11", 7.8f), new SolidBrush(Color.Black), 4, 92);
            //graphic.DrawString("Serial No: " + bir.SerialNo(), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 81, 105);
            graphic.DrawString("Machine Code: " + machine_no, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 63, 60);
            graphic.DrawString("---------------------------------------------------", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 3, 75);
            graphic.DrawString(DateTime.Now.ToString("MMM dd, yyyy") + " " + "(" + DateTime.Now.ToString("ddd") + ")", font, new SolidBrush(Color.Black), 5, 90);
            graphic.DrawString(DateTime.Now.ToString("hh:mm tt"), font, new SolidBrush(Color.Black), 180, 90);
            graphic.DrawString("SI# " + OrNo, font, new SolidBrush(Color.Black), 5, 105);
            #endregion

            using (MySqlConnection con = new MySqlConnection(dbcon.getConnectionString()))
            {
                String query = "SELECT a, b, c, d, e, f FROM (SELECT pos_park.trn AS aaa, inventory_stocks.stock_name AS a, pos_park.pos_amt AS b, pos_park.pos_quantity AS c, pos_park.pos_item_amount AS d, inventory_items.item_whole_price AS e, inventory_items.item_tax_type AS f FROM inventory_items ";
                query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
                query += "INNER JOIN pos_park ON inventory_items.item_ean = pos_park.pos_ean ";
                query += "WHERE (pos_park.pos_orno = ?pos_orno) AND (pos_park.pos_terminal = ?pos_terminal) ";
                query += "UNION ALL ";
                query += "SELECT pos_park.trn AS aaa, inventory_items.kit_name AS a, pos_park.pos_amt AS b, pos_park.pos_quantity AS c, pos_park.pos_item_amount AS d, inventory_items.item_whole_price AS e, inventory_items.item_tax_type  AS f FROM inventory_items ";
                query += "INNER JOIN pos_park ON inventory_items.item_ean = pos_park.pos_ean ";
                query += "WHERE (pos_park.pos_orno = ?pos_orno) AND (pos_park.pos_terminal = ?pos_terminal) AND (inventory_items.is_kit = 1)) receipt ";
                query += "ORDER BY aaa";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, con))
                {
                    try
                    {
                        DataTable dataTable = new DataTable();
                        adapter.SelectCommand.Parameters.AddWithValue("?pos_orno", OrNo);
                        adapter.SelectCommand.Parameters.AddWithValue("?pos_terminal", fl.tN);
                        adapter.Fill(dataTable);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            String description = Truncate(dataTable.Rows[i][0].ToString(), 27);
                            Double priceR = Convert.ToDouble(dataTable.Rows[i][3]);
                            graphic.DrawString(description + "  " + "\n" + dataTable.Rows[i][2].ToString() + " @ " + priceR.ToString("#,###,##0.00"), font, new SolidBrush(Color.Black), 10, 115 + offset);
                            graphic.DrawString(Convert.ToDouble(dataTable.Rows[i][1]).ToString("#,###,##0.00").PadLeft(10) + dataTable.Rows[i][5].ToString(), font, new SolidBrush(Color.Black), 165, 115 + offset);
                            offset = offset + (int)fontHeight + 25;
                        }
                        offset = offset + 30;
                        graphic.DrawString("---------------------------------------------------", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 3, 100 + offset);
                        //
                        counted = 0;
                        foreach (ListViewItem lv in lviewPOS.Items)
                        {
                            counted += Int32.Parse(lv.SubItems[1].Text);
                        }
                        graphic.DrawString("Item Count: ", new Font("FontA11", 13.0f), new SolidBrush(Color.Black), 40, 115 + offset);
                        graphic.DrawString(counted.ToString(), new Font("FontA11", 13.0f), new SolidBrush(Color.Black), 160, 115 + offset);
                        //
                        graphic.DrawString("VATable ", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 85, 145 + offset);
                        graphic.DrawString(lblVatable.Text.PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 175, 145 + offset);
                        graphic.DrawString("VAT-Exempt ", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 85, 160 + offset);
                        graphic.DrawString(lblVATe.Text.PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 175, 160 + offset);
                        graphic.DrawString("Zero-Rated ", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 85, 175 + offset);
                        graphic.DrawString(lblVATz.Text.PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 175, 175 + offset);
                        graphic.DrawString("VAT (" + lblTax.Text + ")", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 85, 190 + offset);
                        graphic.DrawString(lblTAXamt.Text.PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 175, 190 + offset);
                        graphic.DrawString("TOTAL ", new Font("FontA11", 12.0f), new SolidBrush(Color.Black), 83, 205 + offset);
                        graphic.DrawString(getDTotalAmt.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 12.0f), new SolidBrush(Color.Black), 158, 205 + offset);
                        if (selector == 0)
                        {
                            graphic.DrawString("Amount Tender  ", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 235 + offset);
                            graphic.DrawString(Tender.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 115, 235 + offset);
                            graphic.DrawString("Change ", new Font("FontA11", 12.0f), new SolidBrush(Color.Black), 8, 250 + offset);
                            graphic.DrawString(Change.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 12.0f), new SolidBrush(Color.Black), 98, 250 + offset);
                            //
                            graphic.DrawString("Transaction #:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 280 + offset);
                            graphic.DrawString(OrNo.ToString(), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 110, 280 + offset);
                            graphic.DrawString("CASHIER:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 295 + offset);
                            graphic.DrawString(lblUserAccount.Text, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 110, 295 + offset);
                            graphic.DrawString("Terminal #:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 310 + offset);
                            graphic.DrawString(fl.tN, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 110, 310 + offset);
                            graphic.DrawString("***************************************************", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 3, 325 + offset);
                            graphic.DrawString("THIS IS NOT YOUR OFFICIAL RECEIPT", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 7, 340 + offset);
                            graphic.DrawString("Thank you for Shopping and Come Again ", new Font("FontA11", 8.0f), new SolidBrush(Color.Black), 25, 355 + offset);
                        }
                        if (selector == 1)
                        {
                            graphic.DrawString("Card No:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 235 + offset);
                            graphic.DrawString("XXXX-XXXX-XXXX-" + cardNo, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 85, 235 + offset);
                            graphic.DrawString("Card Type:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 250 + offset);
                            graphic.DrawString(cardType, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 85, 250 + offset);
                            graphic.DrawString("Amount:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 265 + offset);
                            graphic.DrawString(cardAmount.ToString("#,###,##0.00"), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 85, 265 + offset);

                            graphic.DrawString("Transaction #:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 295 + offset);
                            graphic.DrawString(OrNo.ToString(), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 110, 295 + offset);
                            graphic.DrawString("CASHIER:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 310 + offset);
                            graphic.DrawString(lblUserAccount.Text, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 110, 310 + offset);
                            graphic.DrawString("Terminal #:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 325 + offset);
                            graphic.DrawString(fl.tN, new Font("Tahoma", 10), new SolidBrush(Color.Black), 110, 325 + offset);
                            graphic.DrawString("---------------------------------------------------", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 3, 340 + offset);
                            graphic.DrawString("THIS IS NOT YOUR OFFICIAL RECEIPT", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 7, 355 + offset);
                            graphic.DrawString("Thank you for Shopping and Come Again ", new Font("FontA11", 8.0f), new SolidBrush(Color.Black), 25, 370 + offset);
                        }
                        if (selector == 2)
                        {
                            graphic.DrawString("Check No:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 235 + offset);
                            graphic.DrawString(checkNo, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 105, 235 + offset);
                            graphic.DrawString("Bank & Branch:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 250 + offset);
                            graphic.DrawString(Truncate(BankNBranch, 18), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 105, 250 + offset);
                            graphic.DrawString("Amount:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 265 + offset);
                            graphic.DrawString(checkAmount.ToString("#,###,##0.00"), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 105, 265 + offset);

                            graphic.DrawString("Transaction #:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 295 + offset);
                            graphic.DrawString(OrNo.ToString(), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 110, 295 + offset);
                            graphic.DrawString("CASHIER:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 310 + offset);
                            graphic.DrawString(lblUserAccount.Text, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 110, 310 + offset);
                            graphic.DrawString("Terminal #:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 325 + offset);
                            graphic.DrawString(fl.tN, new Font("Tahoma", 10), new SolidBrush(Color.Black), 110, 325 + offset);
                            graphic.DrawString("---------------------------------------------------", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 3, 340 + offset);
                            graphic.DrawString("THIS IS NOT YOUR OFFICIAL RECIEPT", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 7, 355 + offset);
                            graphic.DrawString("Thank you for Shopping and Come Again ", new Font("FontA11", 8.0f), new SolidBrush(Color.Black), 25, 370 + offset);
                        }
                        if (selector == 3)
                        {
                            graphic.DrawString("Code:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 235 + offset);
                            graphic.DrawString(CustCode, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 85, 235 + offset);
                            graphic.DrawString("Company:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 250 + offset);
                            graphic.DrawString(Truncate(Company, 22), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 85, 250 + offset);
                            graphic.DrawString("Amount:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 265 + offset);
                            graphic.DrawString(arAmount.ToString("#,###,##0.00") + " Cr", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 85, 265 + offset);

                            graphic.DrawString("Transaction #:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 295 + offset);
                            graphic.DrawString(OrNo.ToString(), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 110, 295 + offset);
                            graphic.DrawString("CASHIER:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 310 + offset);
                            graphic.DrawString(lblUserAccount.Text, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 110, 310 + offset);
                            graphic.DrawString("Terminal #:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 325 + offset);
                            graphic.DrawString(fl.tN, new Font("Tahoma", 10), new SolidBrush(Color.Black), 110, 325 + offset);
                            graphic.DrawString("---------------------------------------------------", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 3, 340 + offset);
                            graphic.DrawString("THIS IS NOT YOUR OFFICIAL RECEIPT", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 7, 355 + offset);
                            graphic.DrawString("Thank you for Shopping and Come Again ", new Font("FontA11", 8.0f), new SolidBrush(Color.Black), 25, 370 + offset);
                        }
                        if (selector == 4)
                        {
                            this.getValidUntil(gCardno);
                            graphic.DrawString("Gift Card #:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 235 + offset);
                            graphic.DrawString(gCardno, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 85, 235 + offset);
                            graphic.DrawString("Valid Until:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 250 + offset);
                            graphic.DrawString(Convert.ToDateTime(validU).ToString("MM/dd/yy"), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 85, 250 + offset);
                            graphic.DrawString("Amount:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 265 + offset);
                            graphic.DrawString(gAmount.ToString("#,###,##0.00") + " Dr", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 85, 265 + offset);

                            graphic.DrawString("Transaction #:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 295 + offset);
                            graphic.DrawString(OrNo.ToString(), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 110, 295 + offset);
                            graphic.DrawString("CASHIER:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 310 + offset);
                            graphic.DrawString(lblUserAccount.Text, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 310, 375 + offset);
                            graphic.DrawString("Terminal #:", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 10, 325 + offset);
                            graphic.DrawString(fl.tN, new Font("Tahoma", 10), new SolidBrush(Color.Black), 110, 325 + offset);
                            graphic.DrawString("---------------------------------------------------", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 3, 340 + offset);
                            graphic.DrawString("THIS IS NOT YOUR OFFICIAL RECEIPT", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 7, 355 + offset);
                            graphic.DrawString("Thank you for Shopping and Come Again ", new Font("FontA11", 8.0f), new SolidBrush(Color.Black), 25, 370 + offset);
                        }
                    }
                    catch (MySqlException)
                    {
                        rdDescription.Text = "Check Printer or Check Server!";
                    }
                }
            }
        }
        #endregion
        private void onFormClose()
        {
            using (cstPassword pword = new cstPassword())
            {

                String userName = frmLogin.User.user_name;
                pword.Pos_username = userName;
                pword.ShowDialog();
                if (pword.Approved == true)
                {
                    login = new DAO.LoginDAO();
                    login.catchUsername(userName);
                    frmMenu fm = new frmMenu();
                    if (login.hasSales())
                    {
                        fm.unlockSales();
                    }
                    if (login.hasOrder())
                    {
                        fm.unlockOrder();
                    }
                    if (login.hasCustomers())
                    {
                        fm.unlockCustomers();
                    }
                    if (login.hasInventory())
                    {
                        fm.unlockInventory();
                    }
                    if (login.hasReports())
                    {
                        fm.unlockGeneralReports();
                    }
                    if (login.hasGC())
                    {
                        fm.unlockGiftCards();
                    }
                    if (login.hasUser_Accounts())
                    {
                        fm.unlockUserAccounts();
                    }
                    if (login.hasUserConf())
                    {
                        fm.unlockConfig();
                    }
                    fm.Show();
                    this.Hide();
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1 && btnSearch.Enabled == true)
            {
                gotoSearch();
                return true;
            }
            if (keyData == Keys.F2 && btnRefund.Enabled == true)
            {
                gotoRefund();
                return true;
            }
            if (keyData == Keys.F3 && wholsale_select == false && btnWholesale.Enabled == true)
            {
                gotoWholesale();
                return true;
            }
            if (keyData == Keys.F3 && wholsale_select == true && btnWholesale.Enabled == false)
            {
                gotoRetail();
                return true;
            }
            if (keyData == Keys.F4 && btnVoid.Enabled == true)
            {
                gotoVoid();
                return true;
            }
            if (keyData == Keys.F5 && btnEdit.Enabled == true)
            {
                gotoEdit();
                return true;
            }
            if (keyData == Keys.F6 && btnCancelSale.Enabled == true)
            {
                gotoCancelT();
                return true;
            }
            if (keyData == Keys.F7 && btnParkSale.Enabled == true)
            {
                gotoPark();
                return true;
            }
            if (keyData == Keys.F8 && btnCheckout.Enabled == true)
            {
                gotoCheckout();
            }
            if (keyData == Keys.F9 && btnDiscount.Enabled == true && discountTx == true)
            {
                gotoDiscount();
            }
            if (keyData == Keys.F10)
            {
                onFormClose();
                return true;
            }
            if (keyData == Keys.F11 && reprint == true)
            {
                if (selector == 0)
                {
                    selector = 0;
                    printDocument1.Print();
                }
                if (selector == 1 && reprint == true)
                {
                    selector = 1;
                    printDocument1.Print();
                }
                if (selector == 2 && reprint == true)
                {
                    selector = 2;
                    printDocument1.Print();
                }
                if (selector == 3 && reprint == true)
                {
                    selector = 3;
                    printDocument1.Print();
                }
                if (selector == 4 && reprint == true)
                {
                    selector = 4;
                    printDocument1.Print();
                }
                return true;
            }
            if (keyData == Keys.F12 && proceeds == false)
            {
                try
                {
                    counted = 0;
                    frmLogin lg = new frmLogin(); //we'll use that ^_^
                    //
                    String userName = frmLogin.User.user_name;
                    pos.Pos_terminal = lg.tN;
                    lblSeriesNo.Text = pos.GetOrNo().ToString();
                    OrNo = pos.GetOrNo();
                    pos.Pos_orno = pos.GetOrNo();
                    pos.Pos_date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    pos.Pos_time = Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss"));
                    pos.Pos_user = userName;
                    pos.BeginTransaction();
                    //
                    proceed.Visible = false;
                    proceeds = true; //important
                    //
                    txtBoxQty.ReadOnly = false;
                    txtBoxQty.Text = "1";
                    txtBoxEAN.ReadOnly = false;
                    rdDescription.Clear();
                    //
                    btnSearch.Enabled = true;
                    btnRefund.Enabled = false;
                    btnWholesale.Enabled = true;
                    //btnParkSale.Enabled = false;
                    //
                    wholsale_select = false;
                    found = false;
                    found_kit = false;
                    discountTx = false;
                    nosale = true;
                    //
                    rdDescription.Text = "Ready";
                    rdPrice.Text = "0.00";
                    rdTotal.Text = "0.00";
                    lblTotalAmount.Text = "0.00";
                    lblChangeDue.Text = "0.00";
                    lblVatable.Text = "0.00";
                    lblVATe.Text = "0.00";
                    lblVATz.Text = "0.00";
                    lblTAXamt.Text = "0.00";
                    lviewPOS.Items.Clear();
                    txtBoxEAN.Focus();
                    selector = 0;
                    reprint = false;
                }
                catch (Exception)
                {
                    rdDescription.Text = "Error 10: Network Connection";
                }
                return true;
            }
            if (keyData == Keys.Q)
            {
                txtBoxQty.Focus();
                return true;
            }
            if (keyData == Keys.A)
            {
                txtBoxEAN.Focus();
                return true;
            }
            if (keyData == Keys.Z)
            {
                gotoGlobal();
                return true;
            }
            if (keyData == Keys.S)
            {
                lviewPOS.Focus();
                return true;
            }
            if (keyData == Keys.N && nosale == true)
            {
                frmLogin fl = new frmLogin();
                pos.Pos_orno = OrNo;
                pos.Pos_terminal = fl.tN;
                pos.NoSale();
                PrintNoSale();
                btnSearch.Enabled = false;
                btnRefund.Enabled = true;
                btnWholesale.Enabled = false;
                btnCancelSale.Enabled = false;
                btnParkSale.Enabled = true;
                btnVoid.Enabled = false;
                btnEdit.Enabled = false;
                btnCancelSale.Enabled = false;
                btnCheckout.Enabled = false; //Very Important La
                btnDiscount.Enabled = false;
                txtBoxQty.ReadOnly = true;
                txtBoxEAN.ReadOnly = true;
                txtBoxEAN.Focus();
                proceeds = false; //Important
                nosale = false;
                noSFlash();
            }
            if (keyData == Keys.O && adminDrawer == true)
            {
                DrawerPing();
            }
            if (keyData == Keys.W && proceeds == false)
            {
                mCashInOut controller = new mCashInOut();
                controller.ShowDialog();
            }
            if (keyData == Keys.P && btnParkSale.Enabled == false)
            {
                lviewPOS.Items.Clear();
                btnSearch.Enabled = false;
                btnRefund.Enabled = false;
                btnWholesale.Enabled = false;
                btnRetail.Visible = false;
                btnCancelSale.Enabled = false;
                btnVoid.Enabled = false;
                btnEdit.Enabled = false;
                btnRefund.Enabled = true;
                btnCancelSale.Enabled = false;
                btnCheckout.Enabled = false; //Very Important La
                btnDiscount.Enabled = false;
                txtBoxQty.ReadOnly = true;
                txtBoxEAN.ReadOnly = true;
                txtBoxEAN.Focus();
                proceeds = false; //Important
                //
                proceed.Visible = true;
                txtBoxQty.Text = "1";
                rdDescription.Text = "Transaction Parked!";
                lblVatable.Text = "0.00";
                lblVATe.Text = "0.00";
                lblVATz.Text = "0.00";
                lblTAXamt.Text = "0.00";
                rdPrice.Text = "0.00";
                rdTotal.Text = "0.00";
                lblTotalAmount.Text = "0.00";
                btnParkSale.Enabled = true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmPOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            onFormClose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            counted = 0;
            nosale = false;
            ConfigCheck();
            rdDescription.Text = compName;
            timer1.Start();
            String userName = frmLogin.User.user_name;
            lblUserAccount.Text = userName;
            lblProgversion.Text = ProductName + " v" + ProductVersion;
            //
            timer2.Start();
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Interval = 250;
            //
            lblTax.Text = taxDisplay.ToString();
            login = new DAO.LoginDAO();
            login.catchUsername(userName);
            if (login.hasUserConf())
            {
                adminDrawer = true;
            }
        }
        private void DrawerPing()
        {
            try
            {
                Conf.Drawer drawer = new Conf.Drawer();
                drawer.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Check Cash Drawer Please!", "Drawer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigCheck()
        {
            frmLogin fl = new frmLogin();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT * FROM system_config";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["tax_type"].ToString() == "V")
                    {
                        taxP = Convert.ToDouble("." + rdr["vat_rate"]);
                        taxDisplay = rdr["vat_rate"].ToString() + "%";
                        compName = rdr["company_name"].ToString();
                        address1 = rdr["company_address"].ToString();
                        address2 = rdr["company_address2"].ToString();
                        contact = rdr["company_contact"].ToString();
                        store_op = rdr["company_operator"].ToString();
                        permit_no = rdr["permit_no"].ToString();
                        TIN = rdr["tin_number"].ToString();
                        TaxT = rdr["tax_type"].ToString();
                        machine_no = rdr["machine_no"].ToString() + fl.tN;
                        all_items_tax = Convert.ToInt16(rdr["all_items_tax"]);
                    }
                    else
                    {
                        taxP = 0;
                        taxDisplay = "0%";
                        compName = rdr["company_name"].ToString();
                        address1 = rdr["company_address"].ToString();
                        address2 = rdr["company_address2"].ToString();
                        contact = rdr["company_contact"].ToString();
                        store_op = rdr["company_operator"].ToString();
                        permit_no = rdr["permit_no"].ToString();
                        TIN = rdr["tin_number"].ToString();
                        TaxT = rdr["tax_type"].ToString();
                        machine_no = rdr["machine_no"].ToString() + fl.tN;
                        all_items_tax = Convert.ToInt16(rdr["all_items_tax"]);
                    }
                }
                con.Close();
            }
            catch (Exception)
            {
                rdDescription.Text = "Error 11: Check Database Server";
            }
        }

        void timer2_Tick(object sender, EventArgs e)
        {
            if (proceed.BackColor == Color.Red)
            {
                proceed.BackColor = Color.White;
                proceed.ForeColor = Color.Black;
            }
            else
            {
                proceed.BackColor = Color.Red;
                proceed.ForeColor = Color.White;
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            gotoCheckout();
        }

        private void gotoWholesale()
        {
            try
            {
                using (cstYesNo yesno = new cstYesNo())
                {
                    yesno.Message = "Do You Wish to Set Your Transaction to Wholesale?";
                    yesno.ShowDialog();
                    if (yesno.Selected == true)
                    {
                        pos.Pos_orno = OrNo;
                        pos.SwitchToWholeSale();
                        btnWholesale.Enabled = false;
                        btnRetail.Visible = true;
                        wholsale_select = true;
                    }
                }
            }
            catch (Exception)
            {
                rdDescription.Text = "Error 11: Check Database Server";
            }
        }

        private void gotoRetail()
        {
            try
            {
                using (cstYesNo yesno = new cstYesNo())
                {
                    yesno.Message = "Do You Wish To Set Your Transaction to Retail?";
                    yesno.ShowDialog();
                    if (yesno.Selected == true)
                    {
                        pos.Pos_orno = OrNo;
                        pos.SwitchToRetail();
                        btnWholesale.Enabled = true;
                        btnRetail.Visible = false;
                        wholsale_select = false;
                    }
                }
            }
            catch (Exception)
            {
                rdDescription.Text = "Error 11: Check Database Server";
            }
        }

        private void btnWholesale_Click(object sender, EventArgs e)
        {
            gotoWholesale();
        }

        private void rdPrice_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                txtBoxEAN.Focus();
            }
        }

        private void rdTotal_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                txtBoxEAN.Focus();
            }
        }

        private void rdTotal_MouseHover(object sender, EventArgs e)
        {
            txtBoxEAN.Focus();
        }

        private void rdPrice_MouseHover(object sender, EventArgs e)
        {
            txtBoxEAN.Focus();
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

        private void getInfoItem()
        {
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT inventory_stocks.stock_name AS a , inventory_items.kit_name AS b, ";
            query += "inventory_items.item_retail_price AS c, inventory_items.item_whole_price AS d, inventory_items.item_tax_type AS e ";
            query += "FROM inventory_items ";
            query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (inventory_items.item_ean = ?item_ean) AND (inventory_items.is_kit = 0)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?item_ean", txtBoxEAN.Text);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    rdDescription.Text = rdr["a"].ToString();
                    if (btnWholesale.Enabled == false && wholsale_select == true) //If Teller Select to Wholse
                    {
                        price = Convert.ToDouble(rdr["d"]);
                        rdPrice.Text = Convert.ToDouble(rdr["d"]).ToString("#,###,##0.00");
                        itemTT = rdr["e"].ToString();
                    }
                    else //Others Retail
                    {
                        price = Convert.ToDouble(rdr["c"]);
                        rdPrice.Text = Convert.ToDouble(rdr["c"]).ToString("#,###,##0.00");
                        itemTT = rdr["e"].ToString();
                    }
                    found = true;
                }
                else
                    found = false;
                con.Close();
            }
            catch (Exception)
            {
                rdDescription.Text = "Error 11: Check Database Server";
            }
        }
        private void getInfoItemKit()
        {
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT kit_name AS a, ";
            query += "item_retail_price AS b, item_whole_price AS c, item_tax_type AS d ";
            query += "FROM inventory_items ";
            query += "WHERE (item_ean = ?item_ean) AND (is_kit = 1)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?item_ean", txtBoxEAN.Text);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    rdDescription.Text = rdr["a"].ToString();
                    if (btnWholesale.Enabled == false && wholsale_select == true) //If Teller Select to Wholse
                    {
                        price = Convert.ToDouble(rdr["c"]);
                        rdPrice.Text = Convert.ToDouble(rdr["c"]).ToString("#,###,##0.00");
                        itemTT = rdr["d"].ToString();
                    }
                    else //Others Retail
                    {
                        price = Convert.ToDouble(rdr["b"]);
                        rdPrice.Text = Convert.ToDouble(rdr["b"]).ToString("#,###,##0.00");
                        itemTT = rdr["d"].ToString();
                    }
                    found_kit = true;
                }
                else
                    found_kit = false;
                con.Close();
            }
            catch (Exception)
            {
                rdDescription.Text = "Error 11: Check Database Server";
            }
        }

        private void RecalculateSameItem()
        {
            nosale = false;
            frmLogin fl = new frmLogin();
            computerItemQty = Convert.ToDouble(txtBoxQty.Text) * price;
            rdTotal.Text = computerItemQty.ToString("#,###,##0.00");
            Double total_fin = 0;
            Double total_fins = 0;
            Double a = 0;
            Double b = 0; //To Data Tax Amount
            Double vATable = 0;
            Double v1 = 0;
            Double v2 = 0;
            Double v3 = 1.12;
            Double vExempt = 0;
            Double vZero = 0;
            foreach (ListViewItem lv in lviewPOS.Items)
            {
                total_fin += Double.Parse(lv.SubItems[5].Text);
                total_fins += Double.Parse(lv.SubItems[5].Text);
                if (lv.SubItems[6].Text == "V")
                {
                    if (all_items_tax == 1) //If All Items are Taxable
                    {
                        v1 += Double.Parse(lv.SubItems[5].Text);
                        v2 = (v1 / v3) * taxP;
                        vATable = v1;
                    }
                    else //Otherwise
                    {
                        v1 += Double.Parse(lv.SubItems[5].Text);
                    }
                }
                if (lv.SubItems[6].Text == "E")
                {
                    vExempt += Double.Parse(lv.SubItems[5].Text);
                }
                if (lv.SubItems[6].Text == "Z")
                {
                    vZero += Double.Parse(lv.SubItems[5].Text);
                }
            }
            if (all_items_tax == 1) //If All Items are Taxable
            {
                if (TaxT == "V")
                {
                    pos.Pos_vatable = vATable;
                    pos.Pos_vex = vExempt;
                    pos.Pos_vatz = vZero;
                    lblVatable.Text = vATable.ToString("#,###,##0.00");
                    lblVATe.Text = vExempt.ToString("###,###,##0.00");
                    lblVATz.Text = vZero.ToString("###,###,##0.00");
                }
                else
                {
                    vATable = 0;
                    vExempt = 0;
                    vZero = 0;
                }
                lblTotalAmount.Text = total_fin.ToString("###,###,##0.00");
                if (itemTT == "V")
                {
                    if (TaxT == "V")
                    {
                        //Tax
                        a = (v1 / v3) * taxP;
                        //Please Add Condition if Sale is VAT
                        pos.Pos_tax_amt = v2;
                        lblTAXamt.Text = v2.ToString("#,###,##0.00");
                        b = v1;
                        pos.Pos_tax_amt = b;
                        lblVatable.Text = b.ToString("#,###,##0.00");
                    }
                    else
                    {
                        a = 0;
                        v2 = 0;
                        b = 0;
                    }
                }

            }
            else
            {
                if (TaxT == "V")
                {
                    pos.Pos_vatable = v1;
                    pos.Pos_vex = vExempt;
                    pos.Pos_vatz = vZero;
                    lblVatable.Text = v1.ToString("#,###,##0.00");
                    lblVATe.Text = vExempt.ToString("###,###,##0.00");
                    lblVATz.Text = vZero.ToString("###,###,##0.00");
                }
                if (itemTT == "V")
                {
                    if (TaxT == "V")
                    {
                        a = (v1 / v3) * taxP;
                        pos.Pos_tax_amt = a;
                        lblTAXamt.Text = a.ToString("###,###,##0.00");
                    }
                    else
                    {
                        a = 0;
                    }
                }
                a = (v1 / v3) * taxP;
                totalVar = v1 + vExempt + vZero + a;
                lblTotalAmount.Text = totalVar.ToString("###,###,##0.00");
            }
            pos.Pos_tax_perc = taxP;
            // Trunk Data
            if (all_items_tax == 1)
            {
                pos.Pos_tax_amt = v2;
                pos.Pos_total_amt = total_fin;
            }
            else
            {
                pos.Pos_tax_amt = a;
                pos.Pos_total_amt = totalVar;
            }
            Double discountTotal = 0;
            foreach (ListViewItem lv in lviewPOS.Items)
            {
                discountTotal += Double.Parse(lv.SubItems[4].Text);
            }
            pos.Total_pos_disc_amt = discountTotal; //Butangi
            pos.Pos_orno = OrNo;
            pos.Pos_terminal = fl.tN;
            pos.UpdateTrunk();
            //
            txtBoxEAN.Clear();
            txtBoxEAN.Focus();
            txtBoxQty.Text = "1";
        }

        private void txtBoxEAN_KeyDown(object sender, KeyEventArgs e)
        {
            Int32 getQty = 0;
            frmLogin fl = new frmLogin();
            try
            {
                if (e.KeyCode == Keys.Enter && proceeds == true)
                {
                    if (txtBoxQty.Text != "0" && txtBoxQty.Text != "00" && txtBoxQty.Text != "000" && txtBoxQty.Text != "0000" && txtBoxQty.Text != "00000" && txtBoxQty.Text != "000000")
                    {
                        getInfoItem();
                        getInfoItemKit();
                        if (found == true || found_kit == true)
                        {
                            itemvo.item_ean = txtBoxEAN.Text;
                            itemvo.askQty();
                            getQty = itemvo.askQty();
                            if (Convert.ToInt32(txtBoxQty.Text) <= getQty)
                            {
                                if (getQty <= 5) //Notifier if Item is Almost Exhausted
                                {
                                    using (cstDlgAlert alert = new cstDlgAlert())
                                    {
                                        alert.MsgDiri = getQty + " Item(s) Left in your Item Inventory";
                                        alert.ShowDialog();
                                    }
                                }
                                //
                                if (this.checkEANList(txtBoxEAN.Text, Convert.ToInt32(txtBoxQty.Text)) == false)
                                {
                                    nosale = false;
                                    itemvo.item_quantity = Convert.ToInt32(txtBoxQty.Text);
                                    itemvo.OrderItem();
                                    computerItemQty = Convert.ToDouble(txtBoxQty.Text) * price;
                                    rdTotal.Text = computerItemQty.ToString("#,###,##0.00");
                                    ListViewItem item = new ListViewItem(txtBoxEAN.Text);
                                    item.SubItems.Add(txtBoxQty.Text);
                                    item.SubItems.Add(rdDescription.Text);
                                    item.SubItems.Add(price.ToString("#,###,##0.00"));
                                    item.SubItems.Add("0.00");
                                    item.SubItems.Add(computerItemQty.ToString("#,###,##0.00"));
                                    item.SubItems.Add(itemTT);
                                    lviewPOS.Items.Add(item);
                                    lviewPOS.EnsureVisible(lviewPOS.Items.Count - 1);
                                    //Data
                                    pos.Pos_orno = OrNo;
                                    pos.Pos_terminal = fl.tN;
                                    pos.Pos_ean = txtBoxEAN.Text;
                                    pos.Pos_quantity = Convert.ToInt32(txtBoxQty.Text);
                                    pos.Pos_item_amount = price;
                                    pos.Pos_amt = computerItemQty;
                                    pos.ParkItem();
                                    //
                                    //
                                    Double total_fin = 0;
                                    Double total_fins = 0;
                                    Double a = 0;
                                    Double b = 0; //To Data Tax Amount
                                    Double vATable = 0;
                                    Double v1 = 0;
                                    Double v2 = 0;
                                    Double v3 = 1.12;
                                    Double vExempt = 0;
                                    Double vZero = 0;
                                    foreach (ListViewItem lv in lviewPOS.Items)
                                    {
                                        total_fin += Double.Parse(lv.SubItems[5].Text);
                                        total_fins += Double.Parse(lv.SubItems[5].Text);
                                        if (lv.SubItems[6].Text == "V")
                                        {
                                            if (all_items_tax == 1) //If All Items are Taxable
                                            {
                                                v1 += Double.Parse(lv.SubItems[5].Text);
                                                v2 = (v1 /v3) * taxP;
                                                vATable = v1;
                                            }
                                            else //Otherwise
                                            {
                                                v1 += Double.Parse(lv.SubItems[5].Text);
                                            }
                                        }
                                        if (lv.SubItems[6].Text == "E")
                                        {
                                            vExempt += Double.Parse(lv.SubItems[5].Text);
                                        }
                                        if (lv.SubItems[6].Text == "Z")
                                        {
                                            vZero += Double.Parse(lv.SubItems[5].Text);
                                        }
                                    }
                                    if (all_items_tax == 1) //If All Items are Taxable
                                    {
                                        if (TaxT == "V")
                                        {
                                            pos.Pos_vatable = vATable;
                                            pos.Pos_vex = vExempt;
                                            pos.Pos_vatz = vZero;
                                            lblVatable.Text = vATable.ToString("#,###,##0.00");
                                            lblVATe.Text = vExempt.ToString("###,###,##0.00");
                                            lblVATz.Text = vZero.ToString("###,###,##0.00");
                                        }
                                        else
                                        {
                                            vATable = 0;
                                            vExempt = 0;
                                            vZero = 0;
                                        }
                                        lblTotalAmount.Text = total_fin.ToString("###,###,##0.00");
                                        if (itemTT == "V")
                                        {
                                            if (TaxT == "V")
                                            {
                                                //Tax
                                                a = (v1 / v3) * taxP;
                                                //Please Add Condition if Sale is VAT
                                                pos.Pos_tax_amt = v2;
                                                lblTAXamt.Text = v2.ToString("#,###,##0.00");
                                                b = v1;
                                                pos.Pos_vatable = b;
                                                lblVatable.Text = b.ToString("#,###,##0.00");
                                            }
                                            else
                                            {
                                                a = 0;
                                                v2 = 0;
                                                b = 0;
                                            }
                                        }
                                        
                                    }
                                    else
                                    {
                                        if (TaxT == "V")
                                        {
                                            pos.Pos_vatable = v1;
                                            pos.Pos_vex = vExempt;
                                            pos.Pos_vatz = vZero;
                                            lblVatable.Text = v1.ToString("#,###,##0.00");
                                            lblVATe.Text = vExempt.ToString("###,###,##0.00");
                                            lblVATz.Text = vZero.ToString("###,###,##0.00");
                                        }
                                        if (itemTT == "V")
                                        {
                                            if (TaxT == "V")
                                            {
                                                a = (v1 / v3) * taxP;
                                                pos.Pos_tax_amt = a;
                                                lblTAXamt.Text = a.ToString("###,###,##0.00");
                                            }
                                            else
                                            {
                                                a = 0;
                                            }
                                        }
                                        a = (v1 / v3) * taxP;
                                        totalVar = v1 + vExempt + vZero + a;
                                        lblTotalAmount.Text = totalVar.ToString("###,###,##0.00");
                                    }                                  
                                    pos.Pos_tax_perc = taxP;
                                    // Trunk Data
                                    if (all_items_tax == 1)
                                    {
                                        pos.Pos_tax_amt = v2;
                                        pos.Pos_total_amt = total_fin;
                                    }
                                    else
                                    {
                                        pos.Pos_tax_amt = a;
                                        pos.Pos_total_amt = totalVar;
                                    }
                                    Double discountTotal = 0;
                                    foreach (ListViewItem lv in lviewPOS.Items)
                                    {
                                        discountTotal += Double.Parse(lv.SubItems[4].Text);
                                    }
                                    pos.Total_pos_disc_amt = discountTotal; //Butangi
                                    pos.Pos_orno = OrNo;
                                    pos.UpdateTrunk();
                                    //
                                    if (lviewPOS.Items.Count != 0)
                                    {
                                        btnCheckout.Enabled = true;
                                        btnCancelSale.Enabled = true;
                                        btnParkSale.Enabled = false;
                                    }
                                    else
                                    {
                                        btnCheckout.Enabled = false;
                                        btnCancelSale.Enabled = false;
                                        btnParkSale.Enabled = true;
                                    }
                                    txtBoxEAN.Clear();
                                    txtBoxEAN.Focus();
                                    txtBoxQty.Text = "1";
                                }
                                else
                                {
                                    RecalculateSameItem();
                                }
                            }
                            else
                            {
                                using (cstDlgAlert alert = new cstDlgAlert())
                                {
                                    if (getQty == 0)
                                    {
                                        alert.MsgDiri = "Insufficient Quantity Inventory Item!";
                                        alert.ShowDialog();
                                        txtBoxEAN.Clear();
                                        txtBoxEAN.Focus();
                                    }
                                    else
                                    {
                                        alert.MsgDiri = getQty + " Item Available! Insufficient Quantity Inventory Item";
                                        alert.ShowDialog();
                                        txtBoxEAN.Clear();
                                        txtBoxEAN.Focus();
                                    }
                                }
                            }
                        }
                        else
                        {
                            rdDescription.Text = "Item Not Found!";
                            txtBoxEAN.Clear();
                            txtBoxEAN.Focus();
                        }
                    }
                    else
                    {
                        rdDescription.Text = "Zero [0] Quantity Is Not Allowed!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                txtBoxQty.Focus();
            }
        }
        #region Checking
        private bool checkEANList(String Ean, Int32 qty)
        {
            bool check = false;
            nosale = false;
            Int32 uQTY;
            Double uTotal;
            frmLogin fl = new frmLogin();
            try
            {
                foreach (ListViewItem item in lviewPOS.Items)
                {
                    String _ean = item.SubItems[0].Text;
                    if (_ean.Equals(Ean))
                    {
                        itemvo.item_ean = txtBoxEAN.Text;
                        itemvo.item_quantity = Convert.ToInt32(txtBoxQty.Text);
                        itemvo.OrderItem();
                        computerItemQty = Convert.ToDouble(txtBoxQty.Text) * price;
                        check = true;
                        uQTY = Convert.ToInt32(txtBoxQty.Text) + Convert.ToInt32(item.SubItems[1].Text);
                        uTotal = Convert.ToDouble(item.SubItems[5].Text) + computerItemQty;
                        item.SubItems[1].Text = uQTY.ToString();
                        item.SubItems[5].Text = uTotal.ToString("#,###,##0.00");
                        //Data
                        pos.Pos_orno = OrNo;
                        pos.Pos_terminal = fl.tN;
                        pos.Pos_ean = txtBoxEAN.Text;
                        pos.Pos_quantity = Convert.ToInt32(txtBoxQty.Text);
                        pos.Pos_item_amount = price;
                        pos.Pos_amt = uTotal;
                        pos.ParkItemSameUpdate();
                        //
                    }
                }
            }
            catch (Exception)
            {
                rdDescription.Text = "Error 11: Check Database Server";
            }

            return check;
        }
        #endregion

        private void lviewPOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lviewPOS.SelectedItems.Count > 0)
            {
                ListViewItem item = lviewPOS.SelectedItems[0];
                catchEan = item.Text;
                catchQty = Convert.ToInt32(item.SubItems[1].Text);
                catchPrice = Convert.ToDouble(item.SubItems[3].Text);
                //Discount
                getTotalAmt = Convert.ToDouble(item.SubItems[5].Text);
                btnDiscount.Enabled = true;
                btnVoid.Enabled = true; //Void
                discountTx = true;
                //
                login = new DAO.LoginDAO();
                String userName = frmLogin.User.user_name;
                login.catchUsername(userName);
                if (login.hasUser_Accounts())
                {
                    btnEdit.Enabled = true;
                }   
            }
        }

        #region GotoKing
        private void gotoDiscount()
        {
            frmLogin fl = new frmLogin();
            try
            {
                Double x = 0;
                Double y = 0;
                using (frmDlgDiscount disc = new frmDlgDiscount())
                {
                    ListViewItem item = lviewPOS.SelectedItems[0];
                    disc.ShowDialog();
                    var discp = disc.Percentage;
                    if (disc.Percentage != 0)
                    {
                        x = getTotalAmt * disc.Percentage;
                        y = getTotalAmt - x;
                        item.SubItems[4].Text = x.ToString("#,###,##0.00");
                        item.SubItems[5].Text = y.ToString("#,###,##0.00");
                        Double a = 0;
                        Double b = 0; //To Data Tax Amount
                        Double total_fin = 0;
                        Double vATable = 0;
                        Double v1 = 0;
                        Double v2 = 0;
                        Double v3 = 1.12;
                        Double vExempt = 0;
                        Double vZero = 0;
                        foreach (ListViewItem lv in lviewPOS.Items)
                        {
                            total_fin += Double.Parse(lv.SubItems[5].Text);
                            if (lv.SubItems[6].Text == "V")
                            {
                                if (all_items_tax == 1) //If All Items are Taxable
                                {
                                    v1 += Double.Parse(lv.SubItems[5].Text);
                                    v2 = (v1 / v3) * taxP;
                                    vATable = v1;
                                }
                                else //Otherwise
                                {
                                    v1 += Double.Parse(lv.SubItems[5].Text);
                                }
                            }
                            if (lv.SubItems[6].Text == "E")
                            {
                                vExempt += Double.Parse(lv.SubItems[5].Text);
                            }
                            if (lv.SubItems[6].Text == "Z")
                            {
                                vZero += Double.Parse(lv.SubItems[5].Text);
                            }
                        }
                        if (all_items_tax == 1) //If All Items are Taxable
                        {
                            if (TaxT == "V")
                            {
                                pos.Pos_vatable = vATable;
                                pos.Pos_vex = vExempt;
                                pos.Pos_vatz = vZero;
                                lblVatable.Text = vATable.ToString("#,###,##0.00");
                                lblVATe.Text = vExempt.ToString("###,###,##0.00");
                                lblVATz.Text = vZero.ToString("###,###,##0.00");
                            }
                            else
                            {
                                vATable = 0;
                                vExempt = 0;
                                vZero = 0;
                            }
                            lblTotalAmount.Text = total_fin.ToString("###,###,##0.00");
                            if (itemTT == "V")
                            {
                                if (TaxT == "V")
                                {
                                    //Tax
                                    a = (v1 / v3) * taxP;
                                    //Please Add Condition if Sale is VAT
                                    pos.Pos_tax_amt = v2;
                                    lblTAXamt.Text = v2.ToString("#,###,##0.00");
                                    b = v1;
                                    pos.Pos_vatable = b;
                                    lblVatable.Text = b.ToString("#,###,##0.00");
                                }
                                else
                                {
                                    a = 0;
                                    v2 = 0;
                                    b = 0;
                                }
                            }
                        }
                        else
                        {
                            if (TaxT == "V")
                            {
                                pos.Pos_vatable = v1;
                                pos.Pos_vex = vExempt;
                                pos.Pos_vatz = vZero;
                                lblVatable.Text = v1.ToString("#,###,##0.00");
                                lblVATe.Text = vExempt.ToString("###,###,##0.00");
                                lblVATz.Text = vZero.ToString("###,###,##0.00");
                            }
                            if (itemTT == "V")
                            {
                                if (TaxT == "V")
                                {
                                    a = (v1 / v3) * taxP;
                                    pos.Pos_tax_amt = a;
                                    lblTAXamt.Text = a.ToString("###,###,##0.00");
                                }
                                else
                                {
                                    a = 0;
                                }
                            }
                            a = (v1 / v3) * taxP;
                            totalVar = v1 + vExempt + vZero + a;
                            lblTotalAmount.Text = totalVar.ToString("###,###,##0.00");
                        }
                        pos.Pos_tax_perc = taxP;
                        // Trunk Data
                        if (all_items_tax == 1)
                        {
                            pos.Pos_tax_amt = v2;
                            pos.Pos_total_amt = total_fin;
                            lblTAXamt.Text = v2.ToString("###,###,##0.00");
                        }
                        else
                        {
                            pos.Pos_tax_amt = a;
                            pos.Pos_total_amt = totalVar;
                            lblTAXamt.Text = a.ToString("###,###,##0.00");
                        }
                        // Trunk Data
                        Double discountTotal = 0;
                        foreach (ListViewItem lv in lviewPOS.Items)
                        {
                            discountTotal += Double.Parse(lv.SubItems[4].Text);
                        }
                        pos.Total_pos_disc_amt = discountTotal; //Butangi
                        pos.Pos_tax_perc = taxP;
                        pos.Pos_orno = OrNo;
                        pos.Pos_terminal = fl.tN;
                        pos.UpdateTrunk();
                        //Update Park Item With Discount
                        pos.Pos_ean = catchEan;
                        pos.Pos_discount = disc.Percentage;
                        pos.Pos_discount_amt = x;
                        pos.Pos_item_amount = price;
                        pos.Pos_amt = y;
                        pos.ParkDiscountItemUpdate();
                        //
                        btnDiscount.Enabled = false;
                        btnEdit.Enabled = false;
                        btnVoid.Enabled = false;
                        discountTx = false;
                    }
                    else
                    {
                        btnDiscount.Enabled = false;
                        btnEdit.Enabled = false;
                        btnVoid.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
                rdDescription.Text = "Error 10: Network Connection";
            }
        }

        private void gotoEdit()
        {
            frmLogin fl = new frmLogin();
            try
            {
                Int32 qty = 0;
                Double x = 0;
                using (frmDlgEditQty edit = new frmDlgEditQty())
                {
                    ListViewItem item = lviewPOS.SelectedItems[0];
                    String uEan = item.Text;
                    edit.dQty = Convert.ToInt32(item.SubItems[1].Text); //Display
                    edit.ShowDialog();
                    if (edit.Qty != 0)
                    {
                        item.SubItems[1].Text = edit.Qty.ToString();
                        qty = Convert.ToInt32(item.SubItems[1].Text); //Computation
                        x = qty * Convert.ToDouble(item.SubItems[3].Text); // Get Initial Total
                        item.SubItems[4].Text = "0.00"; //Discount
                        item.SubItems[5].Text = x.ToString("#,###,##0.00"); //Total
                        btnEdit.Enabled = false;
                        btnDiscount.Enabled = false;
                        btnVoid.Enabled = false;
                        Double a = 0;
                        Double b = 0; //To Data Tax Amount
                        Double total_fin = 0;
                        Double vATable = 0;
                        Double v1 = 0;
                        Double v2 = 0;
                        Double v3 = 1.12;
                        Double vExempt = 0;
                        Double vZero = 0;
                        foreach (ListViewItem lv in lviewPOS.Items)
                        {
                            total_fin += Double.Parse(lv.SubItems[5].Text);
                            //total_fins += Double.Parse(lv.SubItems[5].Text);
                            if (lv.SubItems[6].Text == "V")
                            {
                                if (all_items_tax == 1) //If All Items are Taxable
                                {
                                    v1 += Double.Parse(lv.SubItems[5].Text);
                                    v2 = (v1 / v3) * taxP;
                                    vATable = v1;
                                }
                                else //Otherwise
                                {
                                    v1 += Double.Parse(lv.SubItems[5].Text);
                                }
                            }
                            if (lv.SubItems[6].Text == "E")
                            {
                                vExempt += Double.Parse(lv.SubItems[5].Text);
                            }
                            if (lv.SubItems[6].Text == "Z")
                            {
                                vZero += Double.Parse(lv.SubItems[5].Text);
                            }
                        }
                        if (all_items_tax == 1) //If All Items are Taxable
                        {
                            if (TaxT == "V")
                            {
                                pos.Pos_vatable = vATable;
                                pos.Pos_vex = vExempt;
                                pos.Pos_vatz = vZero;
                                lblVatable.Text = vATable.ToString("#,###,##0.00");
                                lblVATe.Text = vExempt.ToString("###,###,##0.00");
                                lblVATz.Text = vZero.ToString("###,###,##0.00");
                            }
                            else
                            {
                                vATable = 0;
                                vExempt = 0;
                                vZero = 0;
                            }
                            lblTotalAmount.Text = total_fin.ToString("###,###,##0.00");
                            if (itemTT == "V")
                            {
                                if (TaxT == "V")
                                {
                                    //Tax
                                    a = (v1 / v3) * taxP;
                                    //Please Add Condition if Sale is VAT
                                    pos.Pos_tax_amt = v2;
                                    lblTAXamt.Text = v2.ToString("#,###,##0.00");
                                    b = v1;
                                    pos.Pos_vatable = b;
                                    lblVatable.Text = b.ToString("#,###,##0.00");
                                }
                                else
                                {
                                    a = 0;
                                    v2 = 0;
                                    b = 0;
                                }
                            }

                        }
                        else
                        {
                            if (TaxT == "V")
                            {
                                pos.Pos_vatable = v1;
                                pos.Pos_vex = vExempt;
                                pos.Pos_vatz = vZero;
                                lblVatable.Text = v1.ToString("#,###,##0.00");
                                lblVATe.Text = vExempt.ToString("###,###,##0.00");
                                lblVATz.Text = vZero.ToString("###,###,##0.00");
                            }
                            if (itemTT == "V")
                            {
                                if (TaxT == "V")
                                {
                                    a = (v1 / v3) * taxP;
                                    pos.Pos_tax_amt = a;
                                    lblTAXamt.Text = a.ToString("###,###,##0.00");
                                }
                                else
                                {
                                    a = 0;
                                }
                            }
                            a = (v1 / v3) * taxP;
                            totalVar = v1 + vExempt + vZero + a;
                            lblTotalAmount.Text = totalVar.ToString("###,###,##0.00");
                        }
                        pos.Pos_tax_perc = taxP;
                        // Trunk Data
                        if (all_items_tax == 1)
                        {
                            pos.Pos_tax_amt = v2;
                            pos.Pos_total_amt = total_fin;
                            pos.Pos_tax_amt = v2;
                            lblTAXamt.Text = v2.ToString("###,###,##0.00");
                        }
                        else
                        {
                            pos.Pos_tax_amt = a;
                            pos.Pos_total_amt = totalVar;
                            pos.Pos_tax_amt = a;
                            lblTAXamt.Text = a.ToString("###,###,##0.00");
                        }
                        //Update Data
                        Double discountTotal = 0;
                        foreach (ListViewItem lv in lviewPOS.Items)
                        {
                            discountTotal += Double.Parse(lv.SubItems[4].Text);
                        }
                        pos.Total_pos_disc_amt = discountTotal; //Butangi
                        pos.Pos_orno = OrNo;
                        pos.Pos_terminal = fl.tN;
                        pos.Pos_ean = uEan;
                        pos.Pos_quantity = qty;
                        pos.Pos_item_amount = Convert.ToDouble(item.SubItems[3].Text);
                        pos.Pos_amt = x;
                        pos.ParkItemUpdate();
                        //
                        // Trunk Data
                        pos.Pos_tax_perc = taxP;
                        pos.Pos_orno = OrNo;
                        pos.UpdateTrunk();
                        //
                    }
                    else
                    {
                        btnDiscount.Enabled = false;
                        btnEdit.Enabled = false;
                        btnVoid.Enabled = false;
                    }
                    txtBoxEAN.Focus();
                }
            }
            catch (Exception)
            {
                rdDescription.Text = "Error 10: Network Connection";
            }
        }

        private void gotoVoid()
        {
            frmLogin fl = new frmLogin();
            using (cstYesNo yesno = new cstYesNo())
            {
                yesno.Message = "Do you wish to VOID your Selected Items?";
                yesno.ShowDialog();
                if (yesno.Selected == true)
                {
                    try
                    {
                        String eanX = catchEan;
                        lviewPOS.SelectedItems[0].Remove();
                        Double total_fin = 0;
                        Double total_fins = 0;
                        Double a = 0;
                        Double b = 0; //To Data Tax Amount
                        Double vATable = 0;
                        Double v1 = 0;
                        Double v2 = 0;
                        Double v3 = 1.12;
                        Double vExempt = 0;
                        Double vZero = 0;
                        foreach (ListViewItem lv in lviewPOS.Items)
                        {
                            total_fin += Double.Parse(lv.SubItems[5].Text);
                            total_fins += Double.Parse(lv.SubItems[5].Text);
                            if (lv.SubItems[6].Text == "V")
                            {
                                if (all_items_tax == 1) //If All Items are Taxable
                                {
                                    v1 += Double.Parse(lv.SubItems[5].Text);
                                    v2 = (v1 / v3) * taxP;
                                    vATable = v1;
                                }
                                else //Otherwise
                                {
                                    v1 += Double.Parse(lv.SubItems[5].Text);
                                }
                            }
                            if (lv.SubItems[6].Text == "E")
                            {
                                vExempt += Double.Parse(lv.SubItems[5].Text);
                            }
                            if (lv.SubItems[6].Text == "Z")
                            {
                                vZero += Double.Parse(lv.SubItems[5].Text);
                            }
                        }
                        if (all_items_tax == 1) //If All Items are Taxable
                        {
                            if (TaxT == "V")
                            {
                                pos.Pos_vatable = vATable;
                                pos.Pos_vex = vExempt;
                                pos.Pos_vatz = vZero;
                                lblVatable.Text = vATable.ToString("#,###,##0.00");
                                lblVATe.Text = vExempt.ToString("###,###,##0.00");
                                lblVATz.Text = vZero.ToString("###,###,##0.00");
                            }
                            else
                            {
                                vATable = 0;
                                vExempt = 0;
                                vZero = 0;
                            }
                            lblTotalAmount.Text = total_fin.ToString("###,###,##0.00");
                            if (itemTT == "V")
                            {
                                if (TaxT == "V")
                                {
                                    //Tax
                                    a = (v1 / v3) * taxP;
                                    //Please Add Condition if Sale is VAT
                                    pos.Pos_tax_amt = v2;
                                    lblTAXamt.Text = v2.ToString("#,###,##0.00");
                                    b = v1;
                                    pos.Pos_vatable = b;
                                    lblVatable.Text = b.ToString("#,###,##0.00");
                                }
                                else
                                {
                                    a = 0;
                                    v2 = 0;
                                    b = 0;
                                }
                            }
                        }
                        else
                        {
                            if (TaxT == "V")
                            {
                                pos.Pos_vatable = v1;
                                pos.Pos_vex = vExempt;
                                pos.Pos_vatz = vZero;
                                lblVatable.Text = v1.ToString("#,###,##0.00");
                                lblVATe.Text = vExempt.ToString("###,###,##0.00");
                                lblVATz.Text = vZero.ToString("###,###,##0.00");
                            }
                            if (itemTT == "V")
                            {
                                if (TaxT == "V")
                                {
                                    a = (v1 / v3) * taxP;
                                    pos.Pos_tax_amt = a;
                                    lblTAXamt.Text = a.ToString("###,###,##0.00");
                                }
                                else
                                {
                                    a = 0;
                                }
                            }
                            a = (v1 / v3) * taxP;
                            totalVar = v1 + vExempt + vZero + a;
                            lblTotalAmount.Text = totalVar.ToString("###,###,##0.00");
                        }
                        pos.Pos_tax_perc = taxP;
                        // Trunk Data
                        if (all_items_tax == 1)
                        {
                            pos.Pos_tax_amt = v2;
                            pos.Pos_total_amt = total_fin;
                            lblTAXamt.Text = v2.ToString("###,###,##0.00");
                        }
                        else
                        {
                            pos.Pos_tax_amt = a;
                            pos.Pos_total_amt = totalVar;
                            lblTAXamt.Text = a.ToString("###,###,##0.00");
                        }
                        Double discountTotal = 0;
                        foreach (ListViewItem lv in lviewPOS.Items)
                        {
                            discountTotal += Double.Parse(lv.SubItems[4].Text);
                        }
                        pos.Total_pos_disc_amt = discountTotal; //Butangi
                        pos.Pos_orno = OrNo;
                        pos.Pos_terminal = fl.tN;
                        pos.UpdateTrunk();
                        //Void Item Data
                        pos.Pos_ean = eanX;
                        pos.Pos_quantity = catchQty;
                        pos.ParkVoidItem();
                        //
                        btnVoid.Enabled = false;
                        if (lviewPOS.Items.Count != 0)
                        {
                            btnCheckout.Enabled = true;
                            btnCancelSale.Enabled = true;
                            btnParkSale.Enabled = false;
                            nosale = false;
                        }
                        else
                        {
                            btnCheckout.Enabled = false;
                            btnCancelSale.Enabled = false;
                            btnParkSale.Enabled = true;
                            nosale = true;
                        }
                        btnDiscount.Enabled = false;
                        btnEdit.Enabled = false;
                        btnVoid.Enabled = false;
                        txtBoxEAN.Focus();
                    }
                    catch (Exception)
                    {
                        rdDescription.Text = "Error 10: Network Connection";
                    }
                }
            }
        }

        private void gotoGlobal()
        {
            try
            {
                frmLogin lg = new frmLogin(); //we'll use that ^_^
                using (frmDlgGlobalDisc global = new frmDlgGlobalDisc())
                {
                    global.GetAmount = Convert.ToDouble(lblTotalAmount.Text);
                    global.ShowDialog();
                    if (global.Amount == 0)
                    {

                    }
                    else
                    {
                        pos = new VO.PosVO();
                        pos.Pos_total_amt = global.Amount;
                        pos.Pos_orno = Convert.ToInt32(lblSeriesNo.Text);
                        pos.Pos_terminal = lg.tN;
                        pos.UpdateGlobalTotal();
                        lblTotalAmount.Text = global.Amount.ToString("#,###,##0.00");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void gotoCheckout()
        {
            try
            {
                frmDlgCheckout checkout = new frmDlgCheckout();
                frmLogin lg = new frmLogin(); //we'll use that ^_^
                getDTotalAmt = Double.Parse(lblTotalAmount.Text);
                checkout.GetAmount = Double.Parse(lblTotalAmount.Text);
                checkout.ShowDialog();
                //For Cash
                if (checkout.IsCashTX == true)
                {
                    lblChangeDue.Text = checkout.ChangeDue.ToString("#,###,##0.00");
                    btnSearch.Enabled = false;
                    btnRefund.Enabled = true;
                    btnWholesale.Enabled = false;
                    btnRetail.Visible = false;
                    btnCancelSale.Enabled = false;
                    btnParkSale.Enabled = true;
                    btnVoid.Enabled = false;
                    btnEdit.Enabled = false;
                    btnCancelSale.Enabled = false;
                    btnCheckout.Enabled = false; //Very Important La
                    btnDiscount.Enabled = false;
                    txtBoxQty.ReadOnly = true;
                    txtBoxEAN.ReadOnly = true;
                    txtBoxEAN.Focus();
                    proceeds = false; //Important
                    //
                    Tender = checkout.TenderAmount;
                    pos.Pos_tender = checkout.TenderAmount;
                    Change = checkout.ChangeDue;
                    pos.Pos_change = checkout.ChangeDue;
                    pos.Pos_orno = OrNo;
                    pos.Pos_terminal = lg.tN;
                    pos.CashCheckout();
                    //
                    newFlash();
                    selector = 0; //CASH
                    using (cstYesNo yesno = new cstYesNo())
                    {
                        yesno.Message = "Do You Wish Print an Receipt?";
                        yesno.ShowDialog();
                        if (yesno.Selected == true)
                        {
                            DrawerPing();
                            PrintReceipt();
                        }
                        else
                        {
                            DrawerPing();
                        }
                    }
                    reprint = true;
                }
                if (checkout.IsDCTX == true) //Debit Credit Card
                {
                    btnSearch.Enabled = false;
                    btnRefund.Enabled = true;
                    btnWholesale.Enabled = false;
                    btnRetail.Visible = false;
                    btnCancelSale.Enabled = false;
                    btnParkSale.Enabled = true;
                    btnVoid.Enabled = false;
                    btnEdit.Enabled = false;
                    btnCancelSale.Enabled = false;
                    btnCheckout.Enabled = false; //Very Important La
                    btnDiscount.Enabled = false;
                    txtBoxQty.ReadOnly = true;
                    txtBoxEAN.ReadOnly = true;
                    txtBoxEAN.Focus();
                    proceeds = false; //Important
                    //
                    pos.Pos_tender = Double.Parse(lblTotalAmount.Text);
                    pos.Pos_orno = OrNo;
                    pos.Pos_terminal = lg.tN;
                    String enx = crypt.EncryptText(checkout.CardNo, lg.tN);
                    pos.Card_data = enx;
                    cardNo = checkout.CardNo.Substring(checkout.CardNo.Length - 4, 4);
                    pos.Card_lastfour = checkout.CardNo.Substring(checkout.CardNo.Length - 4, 4);
                    cardType = checkout.CardType;
                    pos.Card_type = checkout.CardType;
                    cardAmount = Double.Parse(lblTotalAmount.Text);
                    pos.Tx_amount = Double.Parse(lblTotalAmount.Text);
                    pos.DCCardCheckout();
                    //
                    newFlash();
                    selector = 1; //Debit Credit Card
                    using (cstYesNo yesno = new cstYesNo())
                    {
                        yesno.Message = "Do You Wish Print a Receipt?";
                        yesno.ShowDialog();
                        if (yesno.Selected == true)
                        {
                            //DrawerPing();
                            PrintReceipt();
                        }
                        else
                        {
                            //DrawerPing();
                        }
                    }
                    reprint = true;
                }
                if (checkout.IsBCTX == true) //Bank Cheque
                {
                    btnSearch.Enabled = false;
                    btnRefund.Enabled = true;
                    btnWholesale.Enabled = false;
                    btnRetail.Visible = false;
                    btnCancelSale.Enabled = false;
                    btnParkSale.Enabled = true;
                    btnVoid.Enabled = false;
                    btnEdit.Enabled = false;
                    btnCancelSale.Enabled = false;
                    btnCheckout.Enabled = false; //Very Important La
                    btnDiscount.Enabled = false;
                    txtBoxQty.ReadOnly = true;
                    txtBoxEAN.ReadOnly = true;
                    txtBoxEAN.Focus();
                    proceeds = false; //Important
                    //
                    pos.Pos_tender = Double.Parse(lblTotalAmount.Text);
                    pos.Pos_orno = OrNo;
                    pos.Pos_terminal = lg.tN;
                    checkNo = checkout.CheckNo;
                    pos.Bc_checkno = checkout.CheckNo;
                    BankNBranch = checkout.BankNBranch;
                    pos.Bc_banknbranch = checkout.BankNBranch;
                    pos.Bc_refcode = checkout.CRef;
                    checkAmount = Double.Parse(lblTotalAmount.Text);
                    pos.Tx_amount = Double.Parse(lblTotalAmount.Text);
                    pos.BankCheckout();
                    //
                    newFlash();
                    selector = 2; //Check
                    using (cstYesNo yesno = new cstYesNo())
                    {
                        yesno.Message = "Do You Wish Print a Receipt?";
                        yesno.ShowDialog();
                        if (yesno.Selected == true)
                        {
                            //DrawerPing();
                            PrintReceipt();
                        }
                        else
                        {
                            //DrawerPing();
                        }
                    }
                    reprint = true;
                }
                if (checkout.IsGCTX == true)
                {
                    btnSearch.Enabled = false;
                    btnRefund.Enabled = true;
                    btnWholesale.Enabled = false;
                    btnRetail.Visible = false;
                    btnCancelSale.Enabled = false;
                    btnParkSale.Enabled = true;
                    btnVoid.Enabled = false;
                    btnEdit.Enabled = false;
                    btnCancelSale.Enabled = false;
                    btnCheckout.Enabled = false; //Very Important La
                    btnDiscount.Enabled = false;
                    txtBoxQty.ReadOnly = true;
                    txtBoxEAN.ReadOnly = true;
                    txtBoxEAN.Focus();
                    proceeds = false; //Important
                    //
                    pos.Pos_tender = checkout.GetAmount;
                    pos.Pos_orno = OrNo;
                    pos.Pos_terminal = lg.tN;
                    gCardno = checkout.Gc_code;
                    pos.Gc_cardo = checkout.Gc_code;
                    gAmount = checkout.GetAmount;
                    pos.Tx_amount = checkout.GetAmount; //Same
                    pos.GiftCardCheckout();
                    //
                    gcard.Gc_amount = checkout.GetAmount;
                    gcard.Gc_cardno = checkout.Gc_code;
                    gcard.DebitGC();
                    //
                    newFlash();
                    selector = 4; //Gift Card
                    using (cstYesNo yesno = new cstYesNo())
                    {
                        yesno.Message = "Do You Wish Print a Receipt?";
                        yesno.ShowDialog();
                        if (yesno.Selected == true)
                        {
                            //DrawerPing();
                            PrintReceipt();
                        }
                        else
                        {
                            //DrawerPing();
                        }
                    }
                    reprint = true;
                }
                if (checkout.IsARTX == true) //CRM A/R Basic Codes
                {
                    btnSearch.Enabled = false;
                    btnRefund.Enabled = true;
                    btnWholesale.Enabled = false;
                    btnRetail.Visible = false;
                    btnCancelSale.Enabled = false;
                    btnParkSale.Enabled = true;
                    btnVoid.Enabled = false;
                    btnEdit.Enabled = false;
                    btnCancelSale.Enabled = false;
                    btnCheckout.Enabled = false; //Very Important La
                    btnDiscount.Enabled = false;
                    txtBoxQty.ReadOnly = true;
                    txtBoxEAN.ReadOnly = true;
                    txtBoxEAN.Focus();
                    proceeds = false; //Important
                    //
                    Company = checkout.Company;
                    pos.Pos_customer = checkout.Company;
                    pos.Pos_tender = checkout.GetAmount;
                    pos.Pos_orno = OrNo;
                    pos.Pos_terminal = lg.tN;
                    CustCode = checkout.Custcode;
                    pos.Crm_custcode = checkout.Custcode;
                    arAmount = checkout.GetAmount;
                    pos.Tx_amount = checkout.GetAmount; //Same
                    pos.ARBasicCheckout();
                    //
                    customer.Balance = checkout.GetAmount;
                    customer.Payable = checkout.GetAmount;
                    customer.Custcode = checkout.Custcode;
                    customer.CreditToAccount();
                    //
                    newFlash();
                    selector = 3; //AR
                    using (cstYesNo yesno = new cstYesNo())
                    {
                        yesno.Message = "Do You Wish Print a Receipt?";
                        yesno.ShowDialog();
                        if (yesno.Selected == true)
                        {
                            DrawerPing();
                            PrintReceipt();
                        }
                        else
                        {
                            DrawerPing();
                        }
                    }
                    reprint = true;
                }
            }
            catch (Exception)
            {
                rdDescription.Text = "Error 10: Network Connection";
            }
        }

        private void gotoPark()
        {
            frmLogin fl = new frmLogin();
            try
            {
                using (frmDlgPark park = new frmDlgPark())
                {
                    park.ShowDialog();
                    if (park.Selected == true)
                    {
                        orderNo = park.OrderNo;
                        lblSeriesNo.Text = orderNo.ToString();
                        //
                        wholsale_select = false;
                        btnWholesale.Enabled = true;
                        btnRetail.Visible = false;
                        //
                        loadParkedData();
                        OrNo = park.OrderNo;
                        //
                        proceed.Visible = false;
                        proceeds = true; //important
                        //
                        txtBoxQty.ReadOnly = false;
                        txtBoxQty.Text = "1";
                        txtBoxEAN.ReadOnly = false;
                        rdDescription.Clear();
                        rdDescription.Text = "Ready";
                        lblChangeDue.Text = "0.00";
                        //
                        btnSearch.Enabled = true;
                        btnRefund.Enabled = false;
                        btnCancelSale.Enabled = true;
                        //
                        Double total_fin = 0;
                        Double total_fins = 0;
                        Double a = 0;
                        Double b = 0; //To Data Tax Amount
                        Double vATable = 0;
                        Double v1 = 0;
                        Double v2 = 0;
                        Double v3 = 1.12;
                        Double vExempt = 0;
                        Double vZero = 0;
                        
                        foreach (ListViewItem lv in lviewPOS.Items)
                        {
                            total_fin += Double.Parse(lv.SubItems[5].Text);
                            total_fins += Double.Parse(lv.SubItems[5].Text);
                            if (lv.SubItems[6].Text == "V")
                            {
                                if (all_items_tax == 1) //If All Items are Taxable
                                {
                                    itemTT = lv.SubItems[6].Text;
                                    v1 += Double.Parse(lv.SubItems[5].Text);
                                    v2 = (v1 / v3) * taxP;
                                    vATable = v1;
                                }
                                else //Otherwise
                                {
                                    itemTT = lv.SubItems[6].Text;
                                    v1 += Double.Parse(lv.SubItems[5].Text);
                                }
                            }
                            if (lv.SubItems[6].Text == "E")
                            {
                                vExempt += Double.Parse(lv.SubItems[5].Text);
                            }
                            if (lv.SubItems[6].Text == "Z")
                            {
                                vZero += Double.Parse(lv.SubItems[5].Text);
                            }
                        }
                        if (all_items_tax == 1) //If All Items are Taxable
                        {
                            if (TaxT == "V")
                            {
                                lblVatable.Text = vATable.ToString("#,###,##0.00");
                                lblVATe.Text = vExempt.ToString("###,###,##0.00");
                                lblVATz.Text = vZero.ToString("###,###,##0.00");
                            }
                            else
                            {
                                vATable = 0;
                                vExempt = 0;
                                vZero = 0;
                            }
                            lblTotalAmount.Text = total_fin.ToString("###,###,##0.00");
                            if (itemTT == "V")
                            {
                                if (TaxT == "V")
                                {
                                    //Tax
                                    a = (v1 / v3) * taxP;
                                    //Please Add Condition if Sale is VAT
                                    lblTAXamt.Text = v2.ToString("#,###,##0.00");
                                    b = v1;
                                    lblVatable.Text = b.ToString("#,###,##0.00");
                                }
                                else
                                {
                                    a = 0;
                                    v2 = 0;
                                    b = 0;
                                }
                            }

                        }
                        else
                        {
                            if (TaxT == "V")
                            {
                                lblVatable.Text = v1.ToString("#,###,##0.00");
                                lblVATe.Text = vExempt.ToString("###,###,##0.00");
                                lblVATz.Text = vZero.ToString("###,###,##0.00");
                            }
                            if (itemTT == "V")
                            {
                                if (TaxT == "V")
                                {
                                    a = (v1 / v3) * taxP;
                                    lblTAXamt.Text = a.ToString("###,###,##0.00");
                                }
                                else
                                {
                                    a = 0;
                                }
                            }
                            a = (v1 / v3) * taxP;
                            totalVar = v1 + vExempt + vZero + a;
                            lblTotalAmount.Text = totalVar.ToString("###,###,##0.00");
                        }
                        pos.Pos_tax_perc = taxP;
                        if (lviewPOS.Items.Count != 0)
                        {
                            btnCancelSale.Enabled = true;
                            btnCheckout.Enabled = true;
                            btnParkSale.Enabled = false;
                            nosale = false;
                        }
                        else
                        {
                            btnCancelSale.Enabled = false;
                            btnCheckout.Enabled = false;
                            btnParkSale.Enabled = true;
                            nosale = true;
                        }
                        txtBoxEAN.Focus();
                    }
                    //
                    if (park.Order_Selected == true)
                    {
                        //New Code
                        orderNo = park.OrderNo;
                        lblSeriesNo.Text = orderNo.ToString();
                        //
                        wholsale_select = false;
                        btnWholesale.Enabled = true;
                        btnRetail.Visible = false;
                        //
                        loadParkedData();
                        OrNo = park.OrderNo;
                        //
                        proceed.Visible = false;
                        proceeds = true; //important
                        //
                        txtBoxQty.ReadOnly = false;
                        txtBoxQty.Text = "1";
                        txtBoxEAN.ReadOnly = false;
                        rdDescription.Clear();
                        rdDescription.Text = "Ready";
                        lblChangeDue.Text = "0.00";
                        //
                        btnSearch.Enabled = true;
                        btnRefund.Enabled = false;
                        btnCancelSale.Enabled = true;
                        //
                        Double total_fin = 0;
                        Double total_fins = 0;
                        Double a = 0;
                        Double b = 0; //To Data Tax Amount
                        Double vATable = 0;
                        Double v1 = 0;
                        Double v2 = 0;
                        Double v3 = 1.12;
                        Double vExempt = 0;
                        Double vZero = 0;

                        foreach (ListViewItem lv in lviewPOS.Items)
                        {
                            total_fin += Double.Parse(lv.SubItems[5].Text);
                            total_fins += Double.Parse(lv.SubItems[5].Text);
                            if (lv.SubItems[6].Text == "V")
                            {
                                if (all_items_tax == 1) //If All Items are Taxable
                                {
                                    itemTT = lv.SubItems[6].Text;
                                    v1 += Double.Parse(lv.SubItems[5].Text);
                                    v2 = (v1 / v3) * taxP;
                                    vATable = v1;
                                }
                                else //Otherwise
                                {
                                    itemTT = lv.SubItems[6].Text;
                                    v1 += Double.Parse(lv.SubItems[5].Text);
                                }
                            }
                            if (lv.SubItems[6].Text == "E")
                            {
                                vExempt += Double.Parse(lv.SubItems[5].Text);
                            }
                            if (lv.SubItems[6].Text == "Z")
                            {
                                vZero += Double.Parse(lv.SubItems[5].Text);
                            }
                        }
                        if (all_items_tax == 1) //If All Items are Taxable
                        {
                            if (TaxT == "V")
                            {
                                lblVatable.Text = vATable.ToString("#,###,##0.00");
                                lblVATe.Text = vExempt.ToString("###,###,##0.00");
                                lblVATz.Text = vZero.ToString("###,###,##0.00");
                            }
                            else
                            {
                                vATable = 0;
                                vExempt = 0;
                                vZero = 0;
                            }
                            lblTotalAmount.Text = total_fin.ToString("###,###,##0.00");
                            if (itemTT == "V")
                            {
                                if (TaxT == "V")
                                {
                                    //Tax
                                    a = (v1 / v3) * taxP;
                                    //Please Add Condition if Sale is VAT
                                    lblTAXamt.Text = v2.ToString("#,###,##0.00");
                                    b = v1;
                                    lblVatable.Text = b.ToString("#,###,##0.00");
                                }
                                else
                                {
                                    a = 0;
                                    v2 = 0;
                                    b = 0;
                                }
                            }

                        }
                        else
                        {
                            if (TaxT == "V")
                            {
                                lblVatable.Text = v1.ToString("#,###,##0.00");
                                lblVATe.Text = vExempt.ToString("###,###,##0.00");
                                lblVATz.Text = vZero.ToString("###,###,##0.00");
                            }
                            if (itemTT == "V")
                            {
                                if (TaxT == "V")
                                {
                                    a = (v1 / v3) * taxP;
                                    lblTAXamt.Text = a.ToString("###,###,##0.00");
                                }
                                else
                                {
                                    a = 0;
                                }
                            }
                            a = (v1 / v3) * taxP;
                            totalVar = v1 + vExempt + vZero + a;
                            lblTotalAmount.Text = totalVar.ToString("###,###,##0.00");
                        }
                        pos.Pos_tax_perc = taxP;
                        if (lviewPOS.Items.Count != 0)
                        {
                            btnCancelSale.Enabled = true;
                            btnCheckout.Enabled = true;
                            btnParkSale.Enabled = false;
                            nosale = false;
                        }
                        else
                        {
                            btnCancelSale.Enabled = false;
                            btnCheckout.Enabled = false;
                            btnParkSale.Enabled = true;
                            nosale = true;
                        }
                        VO.OrderVO order = new VO.OrderVO();
                        order.Pos_vatable = Convert.ToDouble(lblVatable.Text);
                        order.Pos_vex = Convert.ToDouble(lblVATe.Text);
                        order.Pos_vatz = Convert.ToDouble(lblVATz.Text);
                        order.Pos_tax_perc = taxP;
                        order.Pos_tax_amt = Convert.ToDouble(lblTAXamt.Text);
                        order.Pos_total_amt = Convert.ToDouble(lblTotalAmount.Text);
                        order.Pos_orno = OrNo;
                        order.Pos_terminal = fl.tN;
                        order.OrderPOSDone();
                        txtBoxEAN.Focus();
                    }
                }
            }
            catch (Exception)
            {
                rdDescription.Text = "Error 10: Network Connection";
            }
        }

        private void gotoCancelT()
        {
            frmLogin fl = new frmLogin();
            using (cstYesNo yesno = new cstYesNo())
            {
                yesno.Message = "Do you Wish To Cancel Transaction Made By You?";
                yesno.ShowDialog();
                if (yesno.Selected == true)
                {
                    String query = "SELECT pos_ean, pos_quantity FROM pos_park ";
                    query += "WHERE pos_orno = ?pos_orno AND pos_terminal = ?pos_terminal";
                    using (MySqlConnection con = new MySqlConnection(dbcon.getConnectionString()))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, con))
                        {
                            try
                            {
                                adapter.SelectCommand.Parameters.AddWithValue("?pos_orno", OrNo);
                                adapter.SelectCommand.Parameters.AddWithValue("?pos_terminal", fl.tN);
                                pos.Pos_orno = OrNo;
                                pos.Pos_terminal = fl.tN;
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);
                                for (int i = 0; i < dataTable.Rows.Count; i++)
                                {
                                    String Eans;
                                    Int32 qtys = 0;
                                    Eans = dataTable.Rows[i][0].ToString();
                                    qtys = Convert.ToInt32(dataTable.Rows[i][1]);
                                    //Data Integration Return Sale to Item
                                    pos.Pos_ean = Eans;
                                    pos.Pos_quantity = qtys;
                                    pos.ReturnCancelItems();
                                    //
                                }
                                //Wipe all Park Item and Switch Core Table to Cancelled
                                pos.CancelSale();
                                //
                                //Event
                                lviewPOS.Items.Clear();
                                btnSearch.Enabled = false;
                                btnRefund.Enabled = false;
                                btnWholesale.Enabled = false;
                                btnRetail.Visible = false;
                                btnCancelSale.Enabled = false;
                                btnVoid.Enabled = false;
                                btnEdit.Enabled = false;
                                btnRefund.Enabled = true;
                                btnCancelSale.Enabled = false;
                                btnCheckout.Enabled = false; //Very Important La
                                btnDiscount.Enabled = false;
                                txtBoxQty.ReadOnly = true;
                                txtBoxEAN.ReadOnly = true;
                                txtBoxEAN.Focus();
                                proceeds = false; //Important
                                //
                                proceed.Visible = true;
                                txtBoxQty.Text = "1";
                                rdDescription.Text = "Transaction Cancelled!";
                                lblVatable.Text = "0.00";
                                lblVATe.Text = "0.00";
                                lblVATz.Text = "0.00";
                                lblTAXamt.Text = "0.00";
                                rdPrice.Text = "0.00";
                                rdTotal.Text = "0.00";
                                lblTotalAmount.Text = "0.00";
                                btnParkSale.Enabled = true;
                                //
                            }
                            catch (MySqlException)
                            {
                                rdDescription.Text = "Error 10: Network Connection";
                            }
                        }
                    }
                }
            }
        }

        private void gotoSearch()
        {
            try
            {
                using (frmDlgSearch search = new frmDlgSearch())
                {
                    search.ShowDialog();
                    if (search.Selected == true)
                    {
                        txtBoxEAN.Text = search.Ean;
                        txtBoxEAN.Focus();
                    }
                    else
                        txtBoxEAN.Focus();
                }
            }
            catch (Exception)
            {
                rdDescription.Text = "Error 10: Network Connection";
            }
        }

        private void gotoRefund()
        {
            using (frmDlgRefund refund = new frmDlgRefund())
            {
                refund.TaxTypes = TaxT;
                refund.AllItemsTax = all_items_tax;
                refund.TaxDisplay = taxDisplay;
                refund.TaxP = taxP;
                refund.ShowDialog();
            }
        }

        private void newFlash()
        {
            proceed.Visible = true;
            txtBoxQty.Text = "1";
            rdDescription.Text = "Thank You For Shopping!";
            rdPrice.Text = "0.00";
            rdTotal.Text = "0.00";
        }
        private void noSFlash()
        {
            proceed.Visible = true;
            txtBoxQty.Text = "1";
            rdDescription.Text = "No Sale";
            rdPrice.Text = "0.00";
            rdTotal.Text = "0.00";
        }

        void timer4_Tick(object sender, EventArgs e)
        {
            if (proceed.BackColor == Color.Red)
            {
                proceed.BackColor = Color.White;
                proceed.ForeColor = Color.Black;
            }
            else
            {
                proceed.BackColor = Color.Red;
                proceed.ForeColor = Color.White;
            }
        }

        #endregion
        private void loadParkedData()
        {
            frmLogin fl = new frmLogin();
            try
            {
                lviewPOS.Items.Clear();
                con.ConnectionString = dbcon.getConnectionString();
                con.Open();
                String query = "SELECT a, b, c, d, e, f, g, h FROM ";
                query += "(SELECT pos_park_2.trn AS aaa, pos_park_2.pos_ean AS a, pos_park_2.pos_quantity AS b, inventory_stocks.stock_name AS c, pos_park_2.pos_item_amount AS d, inventory_items.item_whole_price AS e, pos_park_2.pos_discount_amt AS f, pos_park_2.pos_amt AS g, inventory_items.item_tax_type AS h ";
                query += "FROM pos_park pos_park_2 ";
                query += "INNER JOIN inventory_items ON pos_park_2.pos_ean = inventory_items.item_ean ";
                query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
                query += "WHERE (pos_park_2.pos_orno = ?pos_orno) AND (pos_park_2.pos_terminal = ?pos_terminal) ";
                query += "UNION ALL ";
                query += "SELECT pos_park_1.trn AS aaa, pos_park_1.pos_ean AS a, pos_park_1.pos_quantity AS b, inventory_items_1.kit_name AS c, pos_park_1.pos_item_amount AS d, inventory_items_1.item_whole_price AS e, pos_park_1.pos_discount_amt AS f, pos_park_1.pos_amt AS g, inventory_items_1.item_tax_type AS h ";
                query += "FROM pos_park pos_park_1 ";
                query += "INNER JOIN inventory_items inventory_items_1 ON pos_park_1.pos_ean = inventory_items_1.item_ean ";
                query += "WHERE (pos_park_1.pos_orno = ?pos_orno) AND (inventory_items_1.is_kit = 1) AND (pos_park_1.pos_terminal = ?pos_terminal)) pos_park ";
                query += "ORDER BY aaa";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?pos_orno", orderNo);
                cmd.Parameters.AddWithValue("?pos_terminal", fl.tN);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lviewPOS.BeginUpdate();
                    ListViewItem lv = new ListViewItem(rdr["a"].ToString());
                    lv.SubItems.Add(rdr["b"].ToString());
                    lv.SubItems.Add(rdr["c"].ToString());
                    if (wholsale_select == true && btnWholesale.Enabled == false)
                    {
                        lv.SubItems.Add(Convert.ToDouble(rdr["e"]).ToString("#,###,##0.00")); // Wholesale
                    }
                    else
                    {
                        lv.SubItems.Add(Convert.ToDouble(rdr["d"]).ToString("#,###,##0.00")); // Retail
                    }
                    lv.SubItems.Add(Convert.ToDouble(rdr["f"]).ToString("#,###,##0.00"));
                    lv.SubItems.Add(Convert.ToDouble(rdr["g"]).ToString("#,###,##0.00"));
                    lv.SubItems.Add(rdr["h"].ToString());
                    lviewPOS.Items.Add(lv);
                    lviewPOS.EndUpdate();
                }
                con.Close();
            }
            catch (Exception)
            {
                rdDescription.Text = "Error 10: Network Connection";
            }
        }
        
        private void btnDiscount_Click(object sender, EventArgs e)
        {
            gotoDiscount();
        }

        private void frmPOS_Click(object sender, EventArgs e)
        {
            btnDiscount.Enabled = false;
            discountTx = false;
            btnVoid.Enabled = false;
            //
            btnEdit.Enabled = false;
            //
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            gotoVoid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            gotoEdit();
        }

        private void btnParkSale_Click(object sender, EventArgs e)
        {
            gotoPark();
        }

        private void btnCancelSale_Click(object sender, EventArgs e)
        {
            gotoCancelT();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            gotoSearch();
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            gotoRefund();
        }

        private void btnRetail_Click(object sender, EventArgs e)
        {
            gotoRetail();
        }

        private void lviewPOS_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = lviewPOS.SelectedItems[0];
            catchEan = item.Text;
            catchQty = Convert.ToInt32(item.SubItems[1].Text);
            catchPrice = Convert.ToDouble(item.SubItems[3].Text);
            //Discount
            getTotalAmt = Convert.ToDouble(item.SubItems[5].Text);
            btnDiscount.Enabled = true;
            btnVoid.Enabled = true; //Void
            discountTx = true;
            //
            login = new DAO.LoginDAO();
            String userName = frmLogin.User.user_name;
            login.catchUsername(userName);
            if (login.hasUser_Accounts())
            {
                btnEdit.Enabled = true;
            }
        }
    }
}