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
    public partial class frmLogin : Form
    {
        private MySqlConnection con = new MySqlConnection();
        private Conf.dbs dbcon = new Conf.dbs();
        AutoCompleteStringCollection collect = new AutoCompleteStringCollection();
        private DAO.LoginDAO login = new DAO.LoginDAO();
        private VO.UserAccountVO avo = new VO.UserAccountVO();
        
        public static VO.UserAccountVO currentUser;
        public static VO.UserAccountVO User
        {
            get
            {
                return currentUser;
            }
        }
        public static String terminalNo;
        public String tN
        {
            get { return terminalNo; }
        }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void autoComplete()
        {
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT DISTINCT user_name FROM user_account ORDER BY user_name ASC";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                        collect.Add(rdr["user_name"].ToString());
                }
                rdr.Close();
                txtBoxUsername.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBoxUsername.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBoxUsername.AutoCompleteCustomSource = collect;
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }

        private void enterKey()
        {
            avo = new VO.UserAccountVO(txtBoxUsername.Text);
            try
            {
                if (login.isAuth(txtBoxUsername.Text, txtPassword.Text.Trim()))
                {
                    currentUser = avo;
                    txtBoxUsername.Text = avo.user_name;
                    login.catchUsername(txtBoxUsername.Text);
                    if (login.canAccess())
                    {
                        avo.user_name = txtBoxUsername.Text;
                        avo.PushLog();
                        this.Hide();
                        frmMenu fm = new frmMenu();
                        fm.Show();
                        if (login.hasSales())
                        {
                            fm.unlockSales();
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
                    }
                    else
                    {
                        MessageBox.Show("Your Account is Disable!\nContact Account Supervisor to Enable your Account", "Account Security", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtBoxUsername.Text = "";
                        txtBoxUsername.ReadOnly = false;
                        txtBoxUsername.Focus();
                        txtPassword.Text = "";
                        txtPassword.ReadOnly = true;
                    }
                }
                else
                {
                    MessageBox.Show("Username and/or Password is Incorrect or Not Completed", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtBoxUsername.Text = "";
                    txtBoxUsername.ReadOnly = false;
                    txtBoxUsername.Focus();
                    txtPassword.Text = "";
                    txtPassword.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Conf.dbs ds = new Conf.dbs();
            if (ds.GetMACAddress() == login.matchMac(ds.GetMACAddress()))
            {
                terminalNo = login.getIndentifier(ds.GetMACAddress());
                String nows;
                this.autoComplete();
                if (DateTime.Now.Year.ToString() == "2014")
                {
                    nows = "";
                }
                else
                    nows = DateTime.Now.Year.ToString();
                label3.Text = CompanyName.ToString();
                lblProgversion.Text = ProductName + " v" + ProductVersion;
                lblAdlib.Text = "© Copyright 2014 - " + nows;
            }
            else
            {
                MessageBox.Show("System Access Restricted!\nContact Technical Support Immediately", "nPOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.ExitThread();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            enterKey();
        }

        private void txtBoxUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.ReadOnly = false;
                txtBoxUsername.ReadOnly = true;
                txtPassword.Focus();
            }
        }

        private void txtBoxUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxUsername.Text != "" && txtPassword.Text != "")
            {
                btnLogin.Enabled = true;
            }
            else
                btnLogin.Enabled = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxUsername.Text != "" && txtPassword.Text != "")
            {
                btnLogin.Enabled = true;
            }
            else
                btnLogin.Enabled = false;
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                enterKey();
            }
        }

        private void btnTerminate_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
    }
}