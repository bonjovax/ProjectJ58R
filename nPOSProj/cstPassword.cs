using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace nPOSProj
{
    public partial class cstPassword : Form
    {
        private VO.PosVO posvo = new VO.PosVO();
        public cstPassword()
        {
            InitializeComponent();
            Approved = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private Boolean approved;

        public Boolean Approved
        {
            get { return approved; }
            set { approved = value; }
        }
        private String pos_username;

        public String Pos_username
        {
            get { return pos_username; }
            set { pos_username = value; }
        }

        private void InvalidTrigger()
        {
            timer1.Start();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 250;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (lblAlert.ForeColor == Color.White)
            {
                lblAlert.ForeColor = Color.Red;
            }
            else
            {
                lblAlert.ForeColor = Color.White;
            }
        }

        private void cstPassword_Load(object sender, EventArgs e)
        {
            txtBoxPassword.Focus();
            InvalidTrigger();
        }

        private void txtBoxPassword_TextChanged(object sender, EventArgs e)
        {
            lblAlert.Visible = false;
        }

        private void txtBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtBoxPassword.Text == "")
                    {
                        lblAlert.Text = "Please Key-in Your Password Correctly!";
                        lblAlert.Visible = true;
                    }
                    else
                    {
                        lblAlert.Text = "Invalid Password";
                        posvo.Pos_user = Pos_username;
                        posvo.Pos_password = txtBoxPassword.Text;
                        if (posvo.canExit() == true)
                        {
                            lblAlert.Visible = false;
                            Approved = true;
                            this.Close();
                        }
                        else
                        {
                            lblAlert.Visible = true;
                            Approved = false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Database Error!\nCheck Database Server Immediately!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}