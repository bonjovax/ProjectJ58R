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
    public partial class mdiSalesReport : Form
    {
        private MySqlConnection con = new MySqlConnection();
        private Conf.dbs dbcon = new Conf.dbs();
        private DAO.LoginDAO login;
        private Conf.BIR bir = new Conf.BIR(); //Bureau of Internal Revenue - PH
        private VO.ReportingVO reports = new VO.ReportingVO();
        private VO.ConfigVO config;
        private VO.PosVO vo = new VO.PosVO();
        private String userName = frmLogin.User.user_name;
        private String terminalSelect;
        private String terminalSelectZ;
        private String terminalSelectSR;
        private String terminalSelectSDR;
        private String terminalSelectCBR;
        private String terminalSelectCC;
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
        #region Variable CC
        Double thousand = 0;
        Double fiveh = 0;
        Double twoh = 0;
        Double oneh = 0;
        Double fifty = 0;
        Double twenty = 0;
        Double ten = 0;
        Double five = 0;
        Double one = 0;
        Double twentyfivec = 0;
        #endregion
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
                
            }
        }
        public mdiSalesReport()
        {
            InitializeComponent();
        }

        private void checkRes()
        {
            login = new DAO.LoginDAO();
            String userName = frmLogin.User.user_name;
            login.catchUsername(userName);
            if (login.hasUser_Accounts())
            {
                lblX.Visible = true;
                cBTerminalX.Visible = true;
                lblZ.Visible = true;
                cBTerminalZ.Visible = true;
                lblSR.Visible = true;
                cBTerminalSR.Visible = true;
                lblSDR.Visible = true;
                cBTerminalSDR.Visible = true;
                lblCDR.Visible = true;
                cBTerminalCDR.Visible = true;
            }
        }
        private void getTerminal()
        {
            try
            {
                config = new VO.ConfigVO();
                cBTerminalX.Items.Clear();
                cBTerminalZ.Items.Clear();
                cBTerminalSR.Items.Clear();
                cBTerminalSDR.Items.Clear();
                String[,] grabData = config.ReadTerminal();
                for (int x = 0; x < grabData.GetLength(1); x++)
                {
                    cBTerminalX.Items.Add(grabData[0, x].ToString());
                    cBTerminalZ.Items.Add(grabData[0, x].ToString());
                    cBTerminalSR.Items.Add(grabData[0, x].ToString());
                    cBTerminalSDR.Items.Add(grabData[0, x].ToString());
                    cBTerminalCDR.Items.Add(grabData[0, x].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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

        private void PrintXTicket()
        {
            printX.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printX_PrintPage);
            printX.Print();
        }
        private void PrintZTicket()
        {
            printZ.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printZ_PrintPage);
            printZ.Print();
        }
        private void PrintCashCount()
        {
            printCashCount.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printCashCount_PrintPage);
            printCashCount.Print();
        }

        void printCashCount_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            frmLogin fl = new frmLogin();
            Graphics graphic = e.Graphics;
            Font font = new Font("FontA11", 9.0f);

            float fontHeight = font.GetHeight();
            int startX = 32;
            int startY = 10;

            #region Header
            graphic.DrawString(compName, new Font("FontA11", 9.0f, FontStyle.Bold), Brushes.Black, startX, startY);
            graphic.DrawString(address1, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 45, 30);
            graphic.DrawString(address2, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 38, 45);
            //graphic.DrawString(contact, new Font("Tahoma", 11), new SolidBrush(Color.Black), 53, 60);
            //graphic.DrawString("Owned & Operated By: " + store_op, new Font("Tahoma", 11), new SolidBrush(Color.Black), 5, 75);
            graphic.DrawString("Permit No: " + permit_no, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 63, 60);
            graphic.DrawString("TIN: " + TIN + "" + TaxT, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 63, 75);
            graphic.DrawString("Accreditation No: " + bir.AccreditationNo(), new Font("FontA11", 7.8f), new SolidBrush(Color.Black), 4, 92);
            graphic.DrawString("Serial No: " + bir.SerialNo(), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 81, 105);
            graphic.DrawString("Machine Code: " + machine_no, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 63, 120);
            graphic.DrawString("***************************************************", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 3, 135);
            graphic.DrawString(DateTime.Now.ToString("MMM dd, yyyy") + " " + "(" + DateTime.Now.ToString("ddd") + ")", font, new SolidBrush(Color.Black), 5, 150);
            graphic.DrawString(DateTime.Now.ToString("hh:mm tt"), font, new SolidBrush(Color.Black), 175, 150);
            graphic.DrawString("Cash Count", new Font("FontA11", 9.0f, FontStyle.Bold), Brushes.Black, 95, 170);
            #endregion
            #region Content Cash Count
            graphic.DrawString("Bills", new Font("FontA11", 9.0f, FontStyle.Bold), new SolidBrush(Color.Black), 15, 195);
            graphic.DrawString("1,000", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 220);
            graphic.DrawString("x     " + txtBoxThousand.Text, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 75, 220);
            graphic.DrawString(rdThousand.Text.PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 170, 220);
            graphic.DrawString("500", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 235);
            graphic.DrawString("x     " + txtBoxFiveH.Text, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 75, 235);
            graphic.DrawString(rdFiveH.Text.PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 170, 235);
            graphic.DrawString("200", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 250);
            graphic.DrawString("x     " + txtBoxTwoH.Text, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 75, 250);
            graphic.DrawString(rdTwoH.Text.PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 170, 250);
            graphic.DrawString("100", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 265);
            graphic.DrawString("x     " + txtBoxOneH.Text, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 75, 265);
            graphic.DrawString(rdOneH.Text.PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 170, 265);
            graphic.DrawString("50", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 280);
            graphic.DrawString("x     " + txtBoxFifty.Text, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 75, 280);
            graphic.DrawString(rdFifty.Text.PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 170, 280);
            graphic.DrawString("20", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 295);
            graphic.DrawString("x     " + txtBoxTwenty.Text, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 75, 295);
            graphic.DrawString(rdTwenty.Text.PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 170, 295);
            graphic.DrawString("Total Bills", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 75, 313);
            graphic.DrawString(rdTotalBills.Text.PadLeft(10), new Font("FontA11", 9.0f, FontStyle.Bold), new SolidBrush(Color.Black), 167, 313);
            //
            graphic.DrawString("Coins", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 15, 330);
            graphic.DrawString("10", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 355);
            graphic.DrawString("x     " + txtBoxTen.Text, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 75, 355);
            graphic.DrawString(rdTen.Text.PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 170, 355);
            graphic.DrawString("5", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 370);
            graphic.DrawString("x     " + txtBoxFive.Text, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 75, 370);
            graphic.DrawString(rdFive.Text.PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 170, 370);
            graphic.DrawString("1", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 385);
            graphic.DrawString("x     " + txtBoxOne.Text, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 75, 385);
            graphic.DrawString(rdOne.Text.PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 170, 385);
            graphic.DrawString(".25", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 400);
            graphic.DrawString("x     " + txtBoxTwentyFC.Text, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 75, 400);
            graphic.DrawString(rdTwentyFC.Text.PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 170, 400);
            graphic.DrawString("Total Coins", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 75, 418);
            graphic.DrawString(rdTotalCoins.Text.PadLeft(10), new Font("FontA11", 9.0f, FontStyle.Bold), new SolidBrush(Color.Black), 167, 418);
            //
            graphic.DrawString("Overall Total", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 15, 443);
            graphic.DrawString(rdFinale.Text.PadLeft(10), new Font("FontA11", 9.0f, FontStyle.Bold), new SolidBrush(Color.Black), 155, 443);
            //
            graphic.DrawString("(I hereby this Ticket TRUE and CORRECT)", new Font("Tahoma", 8), new SolidBrush(Color.Black), 18, 468);
            graphic.DrawString("*Signature*", new Font("Tahoma", 7), new SolidBrush(Color.Black), 98, 508);
            #endregion
            #region Footer
            graphic.DrawString("***************************************************", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 3, 520);
            graphic.DrawString("End of Cash Count", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 55, 530);
            #endregion
        }
        void printZ_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                reports.Pos_date = Convert.ToDateTime(dtZ.Text).ToString("yyyy-MM-dd");
                reports.Pos_terminal = terminalSelectZ;

                Double Gross = reports.GrossAmount();
                Double CDrawerBal = reports.CashDrawBal();
                Double Charges = reports.ReadChargeT();
                Double COut = reports.ReadCOut();
                Double Discounts = reports.Discounts();
                Double FinGross = Gross + Charges;
                Double VATAMT = reports.TaxAmount();
                Double Net = FinGross - Charges - COut - Discounts;
                Double V = 0;
                Double NV = 0;
                Int32 CtrStart = reports.SeriesStart();
                Int32 CtrEnd = reports.SeriesEnd();
                Int32 CancelledTxn = reports.CountCancel();
                Int32 NOTrans = reports.NumberOfTrans();
                Int32 NoOfEAN = reports.NumberOfEan();
                Int32 OverallQ = reports.OverallQty();
                Double Beginning = reports.ReadBeg();
                Double PreviousNET = reports.PreviousNETAmt();
                Double Running = PreviousNET + Net;
                //
                Double Difference = CDrawerBal - Net;
                //
                
                frmLogin fl = new frmLogin();
                Graphics graphic = e.Graphics;
                Font font = new Font("FontA11", 9.0f);

                float fontHeight = font.GetHeight();
                int startX = 32;
                int startY = 10;

                #region Header
                graphic.DrawString(compName, new Font("FontA11", 9.0f, FontStyle.Bold), Brushes.Black, startX, startY);
                graphic.DrawString(address1, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 45, 30);
                graphic.DrawString(address2, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 38, 45);
                //graphic.DrawString(contact, new Font("Tahoma", 11), new SolidBrush(Color.Black), 53, 60);
                //graphic.DrawString("Owned & Operated By: " + store_op, new Font("Tahoma", 11), new SolidBrush(Color.Black), 5, 75);
                graphic.DrawString("Permit No: " + permit_no, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 63, 60);
                graphic.DrawString("TIN: " + TIN + "" + TaxT, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 63, 75);
                graphic.DrawString("Accreditation No: " + bir.AccreditationNo(), new Font("FontA11", 7.8f), new SolidBrush(Color.Black), 4, 92);
                graphic.DrawString("Serial No: " + bir.SerialNo(), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 81, 105);
                graphic.DrawString("Machine Code: " + machine_no, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 63, 120);
                graphic.DrawString("Z Reports", new Font("FontA11", 9.0f, FontStyle.Bold), new SolidBrush(Color.Black), 105, 135);
                graphic.DrawString(dtZ.Text, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 5, 150);
                graphic.DrawString(userName + " at Terminal: " + terminalSelectZ, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 5, 165);
                graphic.DrawString("***************************************************", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 3, 180);
                #endregion
                #region Content Reading
                graphic.DrawString("Beginning Balance:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 200);
                graphic.DrawString(Beginning.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 200);
                graphic.DrawString("Gross Sales:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 220);
                graphic.DrawString(FinGross.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 220);
                graphic.DrawString("Charges Amount:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 240);
                graphic.DrawString(Charges.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 240);
                graphic.DrawString("Cash Out Amount:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 260);
                graphic.DrawString(COut.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 260);
                graphic.DrawString("Discounts:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 280);
                graphic.DrawString(Discounts.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 280);
                graphic.DrawString("Net Sales:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 300);
                graphic.DrawString(Net.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 300);
                //
                //Space
                //
                graphic.DrawString("Difference: ".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 330);
                graphic.DrawString(Difference.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 330);
                //
                //Space
                //
                if (TaxT == "V")
                {
                    V = Net;
                }
                else
                {
                    NV = Net;
                }
                graphic.DrawString("Non-VAT Sales:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 360);
                graphic.DrawString(NV.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 360);
                graphic.DrawString("VAT Sales:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 380);
                graphic.DrawString(V.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 380);
                graphic.DrawString("VAT:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 400);
                graphic.DrawString(VATAMT.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 400);
                //
                //Space
                //
                graphic.DrawString("Counter # Start:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 430);
                graphic.DrawString(CtrStart.ToString().PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 430);
                graphic.DrawString("Counter # End:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 450);
                graphic.DrawString(CtrEnd.ToString().PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 450);
                //
                //Space
                //
                graphic.DrawString("Cancelled Txn:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 480);
                graphic.DrawString(CancelledTxn.ToString().PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 480);
                //
                //Space
                //
                graphic.DrawString("No of Transactions:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 510);
                graphic.DrawString(NOTrans.ToString().PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 510);
                graphic.DrawString("No of EAN:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 530);
                graphic.DrawString(NoOfEAN.ToString().PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 530);
                graphic.DrawString("Total Quantity:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 550);
                graphic.DrawString(OverallQ.ToString().PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 550);
                //
                //Space
                //
                graphic.DrawString("Previous Reading:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 580);
                graphic.DrawString(PreviousNET.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 580);
                graphic.DrawString("Net Sales:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 600);
                graphic.DrawString(Net.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 600);
                graphic.DrawString("Running Total:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 620);
                graphic.DrawString(Running.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 620);
                #endregion
                #region Footer
                graphic.DrawString("***************************************************", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 3, 650);
                graphic.DrawString("End of Z Reports", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 80, 660);
                #endregion
            }
            catch (Exception)
            {
                MessageBox.Show("Contact Developer!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void printX_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                reports.Pos_date = Convert.ToDateTime(dtX.Text).ToString("yyyy-MM-dd");
                reports.Pos_terminal = terminalSelect;
                Double Gross = reports.GrossAmount();
                Double Discounts = reports.Discounts();
                Double VATAMT = reports.TaxAmount();
                Double Net = Gross - Discounts;
                Double V = 0;
                Double NV = 0;
                Int32 CtrStart = reports.SeriesStart();
                Int32 CtrEnd = reports.SeriesEnd();
                Int32 CancelledTxn = reports.CountCancel();
                Int32 NOTrans = reports.NumberOfTrans();
                Int32 NoOfEAN = reports.NumberOfEan();
                Int32 OverallQ = reports.OverallQty();
                Double PreviousNET = reports.PreviousNETAmt();
                Double Running = PreviousNET + Net;

                frmLogin fl = new frmLogin();
                Graphics graphic = e.Graphics;
                Font font = new Font("FontA11", 9.0f);

                float fontHeight = font.GetHeight();
                int startX = 32;
                int startY = 10;

                #region Header
                graphic.DrawString(compName, new Font("FontA11", 9.0f, FontStyle.Bold), Brushes.Black, startX, startY);
                graphic.DrawString(address1, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 45, 30);
                graphic.DrawString(address2, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 38, 45);
                //graphic.DrawString(contact, new Font("Tahoma", 11), new SolidBrush(Color.Black), 53, 60);
                //graphic.DrawString("Owned & Operated By: " + store_op, new Font("Tahoma", 11), new SolidBrush(Color.Black), 5, 75);
                graphic.DrawString("Permit No: " + permit_no, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 63, 60);
                graphic.DrawString("TIN: " + TIN + "" + TaxT, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 63, 75);
                graphic.DrawString("Accreditation No: " + bir.AccreditationNo(), new Font("FontA11", 7.8f), new SolidBrush(Color.Black), 4, 92);
                graphic.DrawString("Serial No: " + bir.SerialNo(), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 81, 105);
                graphic.DrawString("Machine Code: " + machine_no, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 63, 120);
                graphic.DrawString("X Reports", new Font("FontA11", 9.0f, FontStyle.Bold), new SolidBrush(Color.Black), 105, 135);
                graphic.DrawString(dtX.Text, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 5, 150);
                graphic.DrawString(userName + " at Terminal: " + terminalSelect, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 5, 165);
                graphic.DrawString("***************************************************", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 3, 180);
                #endregion
                #region Content Reading
                graphic.DrawString("Gross Sales:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 200);
                graphic.DrawString(Gross.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 200);
                graphic.DrawString("Discounts:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 220);
                graphic.DrawString(Discounts.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 220);
                graphic.DrawString("Net Sales:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 240);
                graphic.DrawString(Net.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 240);
                //
                //Space
                //
                if (TaxT == "V")
                {
                    V = Net;
                }
                else
                {
                    NV = Net;
                }
                graphic.DrawString("Non-VAT Sales:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 270);
                graphic.DrawString(NV.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 270);
                graphic.DrawString("VAT Sales:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 290);
                graphic.DrawString(V.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 290);
                graphic.DrawString("VAT:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 310);
                graphic.DrawString(VATAMT.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 310);
                //
                //Space
                //
                graphic.DrawString("Counter # Start:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 340);
                graphic.DrawString(CtrStart.ToString().PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 340);
                graphic.DrawString("Counter # End:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 360);
                graphic.DrawString(CtrEnd.ToString().PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 360);
                //
                //Space
                //
                graphic.DrawString("Cancelled Txn:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 390);
                graphic.DrawString(CancelledTxn.ToString().PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 390);
                //
                //Space
                //
                graphic.DrawString("No of Transactions:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 420);
                graphic.DrawString(NOTrans.ToString().PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 420);
                graphic.DrawString("No of EAN:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 440);
                graphic.DrawString(NoOfEAN.ToString().PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 440);
                graphic.DrawString("Total Quantity:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 460);
                graphic.DrawString(OverallQ.ToString().PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 460);
                //
                //Space
                //
                graphic.DrawString("Previous Reading:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 490);
                graphic.DrawString(PreviousNET.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 490);
                graphic.DrawString("Net Sales:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 510);
                graphic.DrawString(Net.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 510);
                graphic.DrawString("Running Total:".PadRight(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 25, 530);
                graphic.DrawString(Running.ToString("#,###,##0.00").PadLeft(10), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 166, 530);
                #endregion
                #region Footer
                graphic.DrawString("***************************************************", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 3, 550);
                graphic.DrawString("End of X Reports", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 80, 560);
                #endregion
            }
            catch (Exception)
            {
                MessageBox.Show("Contact Developer!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintX_Click(object sender, EventArgs e)
        {
            PrintXTicket();
        }

        private void mdiSalesReport_Load(object sender, EventArgs e)
        {
            frmLogin fl = new frmLogin();
            VO.ReportingVO rep = new VO.ReportingVO();
            ConfigCheck();
            getTerminal();
            checkRes();
            terminalSelect = fl.tN;
            terminalSelectZ = fl.tN;
            terminalSelectSR = fl.tN;
            terminalSelectSDR = fl.tN;
            terminalSelectCBR = fl.tN;
            terminalSelectCC = fl.tN; //New
            vo.Pos_terminal = fl.tN; //New
            //New Added Feature
            txtBoxSetBalance.Text = rep.ReadBeg().ToString("#,###,##0.00");
        }

        private void btnPrintZ_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Do You Wish Proceed?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                vo.Pos_terminal = terminalSelectZ;
                //
                //DrawerPing();
                PrintZTicket();
            }
        }

        private void cBTerminalX_SelectedIndexChanged(object sender, EventArgs e)
        {
            terminalSelect = cBTerminalX.Text;
        }

        private void cBTerminalZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            terminalSelectZ = cBTerminalZ.Text;
        }

        private void btnPrintSummarySR_Click(object sender, EventArgs e)
        {
            using (frmRptSR sr = new frmRptSR())
            {
                sr.DateParam = dtSR.Text;
                sr.TerminalParam = terminalSelectSR;
                sr.ShowDialog();
            }
        }

        private void cBTerminalSR_SelectedIndexChanged(object sender, EventArgs e)
        {
            terminalSelectSR = cBTerminalSR.Text;
        }

        private void btnPrintSummarySDR_Click(object sender, EventArgs e)
        {
            using (frmRptSDR sdr = new frmRptSDR())
            {
                sdr.DateParam = dtSDR.Text;
                sdr.TerminalParam = terminalSelectSDR;
                sdr.ShowDialog();
            }
        }

        private void cBTerminalSDR_SelectedIndexChanged(object sender, EventArgs e)
        {
            terminalSelectSDR = cBTerminalSDR.Text;
        }

        private void btnPrintKits_Click(object sender, EventArgs e)
        {
            using (frmRptKit sdrkit = new frmRptKit())
            {
                sdrkit.DateParam = dtSDR.Text;
                sdrkit.TerminalParam = terminalSelectSDR;
                sdrkit.ShowDialog();
            }
        }

        private void cBTerminalCDR_SelectedIndexChanged(object sender, EventArgs e)
        {
            terminalSelectCBR = cBTerminalCDR.Text;
        }

        private void btnCDR_Click(object sender, EventArgs e)
        {
            using (frmRptCDrawer cdr = new frmRptCDrawer())
            {
                cdr.DateParam = dtCDR.Text;
                cdr.TerminalParam = terminalSelectCBR;
                cdr.ShowDialog();
            }
        }

        private void txtBoxThousand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxFiveH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxTwoH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxOneH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxFifty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxTwenty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxFive_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxOne_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxTwentyFC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cBCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtBoxThousand_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double calc = Convert.ToDouble(txtBoxThousand.Text) * Convert.ToDouble(lblThousand.Text);
                rdThousand.Text = calc.ToString("#,###,##0.00");
                if (txtBoxThousand.Text == "")
                {
                    thousand = 0;
                }
                else
                    thousand = calc;
            }
            catch (Exception)
            {
                rdThousand.Text = "0.00";
            }
        }

        private void txtBoxFiveH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double calc = Convert.ToDouble(txtBoxFiveH.Text) * Convert.ToDouble(lblFiveH.Text);
                rdFiveH.Text = calc.ToString("#,###,##0.00");
                if (txtBoxFiveH.Text == "")
                {
                    fiveh = 0;
                }
                else
                    fiveh = calc;
            }
            catch (Exception)
            {
                rdFiveH.Text = "0.00";
            }
        }

        private void txtBoxTwoH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double calc = Convert.ToDouble(txtBoxTwoH.Text) * Convert.ToDouble(lblTwoH.Text);
                rdTwoH.Text = calc.ToString("#,###,##0.00");
                if (txtBoxTwoH.Text == "")
                {
                    twoh = 0;
                }
                else
                    twoh = calc;
            }
            catch (Exception)
            {
                rdTwoH.Text = "0.00";
            }
        }

        private void txtBoxOneH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double calc = Convert.ToDouble(txtBoxOneH.Text) * Convert.ToDouble(lblOneH.Text);
                rdOneH.Text = calc.ToString("#,###,##0.00");
                if (txtBoxOneH.Text == "")
                {
                    oneh = 0;
                }
                else
                    oneh = calc;
            }
            catch (Exception)
            {
                rdOneH.Text = "0.00";
            }
        }

        private void txtBoxFifty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double calc = Convert.ToDouble(txtBoxFifty.Text) * Convert.ToDouble(lblFifty.Text);
                rdFifty.Text = calc.ToString("#,###,##0.00");
                if (txtBoxFifty.Text == "")
                {
                    fifty = 0;
                }
                else
                    fifty = calc;
            }
            catch (Exception)
            {
                rdFifty.Text = "0.00";
            }
        }

        private void txtBoxTwenty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double calc = Convert.ToDouble(txtBoxTwenty.Text) * Convert.ToDouble(lblTwenty.Text);
                rdTwenty.Text = calc.ToString("#,###,##0.00");
                if (txtBoxTwenty.Text == "")
                {
                    twenty = 0;
                }
                else
                    twenty = calc;
            }
            catch (Exception)
            {
                rdTwenty.Text = "0.00";
            }
        }

        private void txtBoxThousand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxFiveH.Focus();
            }
        }

        private void txtBoxFiveH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxTwoH.Focus();
            }
        }

        private void txtBoxTwoH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxOneH.Focus();
            }
        }

        private void txtBoxOneH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxFifty.Focus();
            }
        }

        private void txtBoxFifty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxTwenty.Focus();
            }
        }

        private void txtBoxTwenty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCalcBills.Focus();
            }
        }

        private void btnCalcBills_Click(object sender, EventArgs e)
        {
            txtBoxThousand.ReadOnly = true;
            txtBoxFiveH.ReadOnly = true;
            txtBoxTwoH.ReadOnly = true;
            txtBoxOneH.ReadOnly = true;
            txtBoxFifty.ReadOnly = true;
            txtBoxTwenty.ReadOnly = true;
            Double comp = Convert.ToDouble(rdThousand.Text) + Convert.ToDouble(rdFiveH.Text) + Convert.ToDouble(rdTwoH.Text) + Convert.ToDouble(rdOneH.Text) + Convert.ToDouble(rdFifty.Text) + Convert.ToDouble(rdTwenty.Text);
            rdTotalBills.Text = comp.ToString("#,###,##0.00");
            btnCalcBills.Enabled = false;
            btnCalcCoins.Enabled = true;
            txtBoxTen.Focus();
        }

        private void txtBoxTen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double calc = Convert.ToDouble(txtBoxTen.Text) * Convert.ToDouble(lblTen.Text);
                rdTen.Text = calc.ToString("#,###,##0.00");
                if (txtBoxTen.Text == "")
                {
                    ten = 0;
                }
                else
                    ten = calc;
            }
            catch (Exception)
            {
                rdTen.Text = "0.00";
            }
        }

        private void txtBoxFive_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double calc = Convert.ToDouble(txtBoxFive.Text) * Convert.ToDouble(lblFive.Text);
                rdFive.Text = calc.ToString("#,###,##0.00");
                if (txtBoxFive.Text == "")
                {
                    five = 0;
                }
                else
                    five = calc;
            }
            catch (Exception)
            {
                rdFive.Text = "0.00";
            }
        }

        private void txtBoxOne_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double calc = Convert.ToDouble(txtBoxOne.Text) * Convert.ToDouble(lblOne.Text);
                rdOne.Text = calc.ToString("#,###,##0.00");
                if (txtBoxOne.Text == "")
                {
                    one = 0;
                }
                else
                    one = calc;
            }
            catch (Exception)
            {
                rdOne.Text = "0.00";
            }
        }

        private void txtBoxTwentyFC_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double calc = Convert.ToDouble(txtBoxTwentyFC.Text) * Convert.ToDouble(lblTwentyFC.Text);
                rdTwentyFC.Text = calc.ToString("#,###,##0.00");
                if (txtBoxTwentyFC.Text == "")
                {
                    twentyfivec = 0;
                }
                else
                    twentyfivec = calc;
            }
            catch (Exception)
            {
                rdTwentyFC.Text = "0.00";
            }
        }

        private void txtBoxTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxFive.Focus();
            }
        }

        private void txtBoxFive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxOne.Focus();
            }
        }

        private void txtBoxOne_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxTwentyFC.Focus();
            }
        }

        private void txtBoxTwentyFC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCalcCoins.Focus();
            }
        }

        private void btnCalcCoins_Click(object sender, EventArgs e)
        {
            txtBoxTen.ReadOnly = true;
            txtBoxFive.ReadOnly = true;
            txtBoxOne.ReadOnly = true;
            txtBoxTwentyFC.ReadOnly = true;
            Double calc = Convert.ToDouble(rdTen.Text) + Convert.ToDouble(rdFive.Text) + Convert.ToDouble(rdOne.Text) + Convert.ToDouble(rdTwentyFC.Text);
            rdTotalCoins.Text = calc.ToString("#,###,##0.00");
            btnCalcCoins.Enabled = false;
            btnFinale.Enabled = true;
            btnFinale.Focus();
        }

        private void btnFinale_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Printing Cash Count Ticket\nDo You Wish To Proceed?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                Double tar = Convert.ToDouble(rdTotalBills.Text) + Convert.ToDouble(rdTotalCoins.Text);
                rdFinale.Text = tar.ToString("#,###,##0.00");
                btnFinale.Enabled = false;
                vo.Thousand = Convert.ToDouble(rdThousand.Text);
                vo.Fiveh = Convert.ToDouble(rdFiveH.Text);
                vo.Twoh = Convert.ToDouble(rdTwoH.Text);
                vo.Oneh = Convert.ToDouble(rdOneH.Text);
                vo.Fifty = Convert.ToDouble(rdFifty.Text);
                vo.Twenty = Convert.ToDouble(rdTwenty.Text);
                vo.Ten = Convert.ToDouble(rdTen.Text);
                vo.Five = Convert.ToDouble(rdFive.Text);
                vo.One = Convert.ToDouble(rdOne.Text);
                vo.Ctwentyfive = Convert.ToDouble(rdTwentyFC.Text);
                vo.Pos_terminal = terminalSelectCC;
                vo.Pos_user = frmLogin.User.user_name;
                vo.LogCashCount();
                PrintCashCount();
            }
        }

        private void txtBoxSetBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtBoxSetBalance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (txtBoxSetBalance.Text == "" || txtBoxSetBalance.Text == null)
                    {
                        txtBoxSetBalance.Text = "0.00";
                    }
                    else
                    {
                        VO.ReportingVO rep = new VO.ReportingVO();
                        rep.Begbal = Convert.ToDouble(txtBoxSetBalance.Text);
                        rep.UpdateBeg();
                        txtBoxSetBalance.Text = rep.ReadBeg().ToString("#,###,##0.00");
                        DialogResult dr = MessageBox.Show("Do you wish to Update this on your Drawer Balance?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            vo.CashAmount = Convert.ToDouble(txtBoxSetBalance.Text);
                            vo.DrawerPurpose = "Set Beginning Balance";
                            vo.Pos_terminal = terminalSelect;
                            vo.Pos_user = userName;
                            vo.CreditD();
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error: Please Check Database Server!", "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult dkg = MessageBox.Show("Do you Want to Reset the Drawer Balance?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dkg == System.Windows.Forms.DialogResult.Yes)
            {
                vo.ResetD();
                vo.CashAmount = 0;
                vo.DrawerPurpose = "Z Reading";
                vo.Pos_user = userName;
                vo.DebitD();
            }
        }
    }
}