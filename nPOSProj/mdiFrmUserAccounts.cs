using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace nPOSProj
{
    public partial class mdiFrmUserAccounts : Form
    {
        private DAO.LoginDAO login;
        private mdiUserAcc uacc = new mdiUserAcc();
        private mdiResetPassword resetpas = new mdiResetPassword();
        private static String cmd = "mailto:DLG.alfel@gmail.com?subject=User Accounts Module Support&cc=jarmonilla892@gmail.com";
        public mdiFrmUserAccounts()
        {
            InitializeComponent();
        }

        private void onFormClose()
        {
            login = new DAO.LoginDAO();
            String userName = frmLogin.User.user_name;
            login.catchUsername(userName);
            frmMenu fm = new frmMenu();
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
            fm.Show();
            this.Hide();
        }

        private Boolean ActivateThisChild(String formName)
        {
            int i;
            Boolean formSetToMdi = false;
            for (i = 0; i < this.MdiChildren.Length; i++)
            // loop for all the mdi children
            {
                if (this.MdiChildren[i].Name == formName)
                // find the Mdi child with the same name as your form
                {
                    // if found just activate it
                    this.MdiChildren[i].Activate();
                    formSetToMdi = true;
                }
            }

            if (i == 0 || formSetToMdi == false)
                // if the given form not found as mdi child return false.
                return false;

            else
                return true;
        }

        private void gotoUserAccount()
        {
            if (ActivateThisChild("mdiUserAcc") == false)
            {
                uacc = new mdiUserAcc();
                uacc.MdiParent = this;
                uacc.Show();
            }
        }

        private void gotoResetPassword()
        {
            if (ActivateThisChild("mdiResetPassword") == false)
            {
                resetpas = new mdiResetPassword();
                resetpas.MdiParent = this;
                resetpas.Show();
            }
        }

        private void mdiFrmUserAccounts_FormClosing(object sender, FormClosingEventArgs e)
        {
            onFormClose();
        }

        private void tsExit_Click(object sender, EventArgs e)
        {
            onFormClose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            String Date = DateTime.Now.ToLongDateString();
            String Time = DateTime.Now.ToLongTimeString();
            tsToday.Text = Date + " at " + Time;
        }

        private void mdiFrmUserAccounts_Load(object sender, EventArgs e)
        {
            String userName = frmLogin.User.user_name;
            tsUser.Text = userName.ToString();
            timer1.Start();
        }

        private void tsAccount_Click(object sender, EventArgs e)
        {
            gotoUserAccount();
        }

        private void tsReset_Click(object sender, EventArgs e)
        {
            gotoResetPassword();
        }

        private void tsEmail_Click(object sender, EventArgs e)
        {
            Process.Start(cmd);
        }

        private void tsAbout_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }
    }
}