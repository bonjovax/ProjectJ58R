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
    public partial class mdiFrmOrder : Form
    {
        private static String cmd = "mailto:DLG.alfel@gmail.com?subject=Ordering Module Support&cc=jarmonilla892@gmail.com";
        private DAO.LoginDAO login;
        private mdiOrdering ordering = new mdiOrdering();
        public mdiFrmOrder()
        {
            InitializeComponent();
        }

        private void tsAbout_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }

        private void tsEmail_Click(object sender, EventArgs e)
        {
            Process.Start(cmd);
        }

        private void mdiFrmOrder_Load(object sender, EventArgs e)
        {
            login = new DAO.LoginDAO();
            String userName = frmLogin.User.user_name;
            tsUser.Text = userName.ToString();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            String Date = DateTime.Now.ToLongDateString();
            String Time = DateTime.Now.ToLongTimeString();
            tsToday.Text = Date + " at " + Time;
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

        private void tsExit_Click(object sender, EventArgs e)
        {
            onFormClose();
        }

        private void mdiFrmOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            onFormClose();
        }

        private void tsOrder_Click(object sender, EventArgs e)
        {
            if (ActivateThisChild("mdiOrdering") == false)
            {
                ordering = new mdiOrdering();
                ordering.MdiParent = this;
                ordering.Show();
            }
        }
    }
}