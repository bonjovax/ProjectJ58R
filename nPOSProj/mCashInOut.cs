using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace nPOSProj
{
    public partial class mCashInOut : Form
    {
        VO.PosVO vo = new VO.PosVO();
        Conf.Rgx r = new Conf.Rgx();
        private Conf.Drawer drawers;
        private String CashStatus;
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
        private MySqlConnection con = new MySqlConnection();
        Conf.dbs dbcon = new Conf.dbs();
        private Conf.BIR bir = new Conf.BIR(); //Bureau of Internal Revenue - PH
        #endregion
        public mCashInOut()
        {
            InitializeComponent();
        }

        private void mCashInOut_Load(object sender, EventArgs e)
        {
            txtBoxAmount.Focus();
            frmLogin fl = new frmLogin();
            vo.Pos_terminal = fl.tN;
            lblCID.Text = vo.DrawerBalance().ToString("#,###,##0.00");
            lblTerminal.Text = fl.tN;
            ConfigCheck();
        }

        private void mCashInOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtBoxAmount_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtBoxAmount.Text, r.Amount()))
            {
                txtBoxPurpose.ReadOnly = false;
            }
            else
                txtBoxPurpose.ReadOnly = true;
            if (Regex.IsMatch(txtBoxAmount.Text, r.Amount()) && txtBoxPurpose.Text != "")
            {
                btnIn.Enabled = true;
            }
            else
            {
                btnIn.Enabled = false;
                btnOut.Enabled = false;
            }
        }

        private void txtBoxPurpose_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtBoxAmount.Text, r.Amount()) && txtBoxPurpose.Text != "")
            {
                btnIn.Enabled = true;
            }
            else
            {
                btnIn.Enabled = false;
                btnOut.Enabled = false;
            }
            if (Convert.ToDouble(txtBoxAmount.Text) > Convert.ToDouble(lblCID.Text))
            {
                btnOut.Enabled = false;
            }
            else
            {
                btnOut.Enabled = true;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            String userName = frmLogin.User.user_name;
            DialogResult dr = MessageBox.Show("Do You Wish to Continue?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                CashStatus = "In";
                try
                {
                    vo.CashAmount = Convert.ToDouble(txtBoxAmount.Text);
                    vo.DrawerPurpose = txtBoxPurpose.Text;
                    vo.Pos_terminal = lblTerminal.Text;
                    vo.Pos_user = userName;
                    vo.CreditD();
                    lblCID.Text = vo.DrawerBalance().ToString("#,###,##0.00");
                    drawers = new Conf.Drawer();
                    drawers.Open();
                    PrintTicket();
                    txtBoxPurpose.Clear();
                    txtBoxAmount.Clear();
                    txtBoxAmount.Focus();
                }
                catch (Exception)
                {
                    MessageBox.Show("Check Database Server!", "Database Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            String userName = frmLogin.User.user_name;
            DialogResult dr = MessageBox.Show("Do You Wish to Continue?", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                CashStatus = "Out";
                if (txtBoxPurpose.Text != "")
                {
                    vo.CashAmount = Convert.ToDouble(txtBoxAmount.Text);
                    vo.DrawerPurpose = txtBoxPurpose.Text;
                    vo.Pos_terminal = lblTerminal.Text;
                    vo.Pos_user = userName;
                    vo.DebitD();
                    lblCID.Text = vo.DrawerBalance().ToString("#,###,##0.00");
                    drawers = new Conf.Drawer();
                    drawers.Open();
                    PrintTicket();
                    txtBoxPurpose.Clear();
                    txtBoxAmount.Clear();
                    txtBoxAmount.Focus();
                }
                else
                {
                    MessageBox.Show("Please State Your Purpose!", "Cash In Drawer Management", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBoxPurpose.Focus();
                }
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
                    }
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintTicket()
        {
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.Print();
        }

        void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
            graphic.DrawString("Cash Status: ", font, new SolidBrush(Color.Black), 5, 175);
            graphic.DrawString(CashStatus, font, new SolidBrush(Color.Black), 85, 175);
            //
            graphic.DrawString("Purpose: ", font, new SolidBrush(Color.Black), 5, 190);
            graphic.DrawString(txtBoxPurpose.Text, font, new SolidBrush(Color.Black), 85, 190);
            //
            graphic.DrawString("Amount ", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 5, 205);
            graphic.DrawString(Convert.ToDouble(txtBoxAmount.Text).ToString("#,###,##0.00"), new Font("FontA11", 9.0f, FontStyle.Bold), new SolidBrush(Color.Black), 85, 205);
            //
            graphic.DrawString("Drawer Bal.", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 5, 230);
            graphic.DrawString(Convert.ToDouble(lblCID.Text).ToString("#,###,##0.00"), new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 85, 230);
            //
            graphic.DrawString("***************************************************", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 3, 245);
            graphic.DrawString("CASHIER: ", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 3, 260);
            graphic.DrawString(frmLogin.User.user_name, new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 60, 260);
            graphic.DrawString("___________________", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 50, 290);
            graphic.DrawString("Signature", new Font("FontA11", 9.0f), new SolidBrush(Color.Black), 90, 305);
            #endregion
        }
    }
}