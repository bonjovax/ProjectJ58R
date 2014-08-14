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
    public partial class frmChangePass : Form
    {
        private String User;
        private VO.ChangePasswordVO cpvo;
        public frmChangePass()
        {
            InitializeComponent();
        }

        private void clearBoxes()
        {
            txtBoxNewPass.Clear();
            txtBoxConfirmPass.Clear();
        }

        private void toChange()
        {
            cpvo = new VO.ChangePasswordVO();
            if (txtBoxNewPass.Text == txtBoxConfirmPass.Text)
            {
                if (txtBoxNewPass.Text == "" && txtBoxConfirmPass.Text == "")
                {
                    MessageBox.Show("Please Fill Up Completely Your Desired Password.", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtBoxConfirmPass.Focus();
                }
                else
                {
                    cpvo.user_password = txtBoxConfirmPass.Text;
                    cpvo.Change();
                    this.clearBoxes();
                    MessageBox.Show("Your Password has Successfully Changed", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
            }
            else
                MessageBox.Show("Your Password and Confirm Password has not Match", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            txtBoxConfirmPass.Focus();
        }

        private void frmChangePass_Load(object sender, EventArgs e)
        {
            String userName = frmLogin.User.user_name;
            User = userName;
            txtBoxNewPass.Focus();
            btnBack.Enabled = true;
        }

        private void txtBoxNewPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxConfirmPass.Focus();
            }
        }

        private void txtBoxConfirmPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toChange();
            }
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            toChange();
        }

        private void txtBoxNewPass_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxNewPass.Text != "" && txtBoxConfirmPass.Text != "")
            {
                btn_change.Enabled = true;
            }
            else
                btn_change.Enabled = false;
        }

        private void txtBoxConfirmPass_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxNewPass.Text != "" && txtBoxConfirmPass.Text != "")
            {
                btn_change.Enabled = true;
            }
            else
                btn_change.Enabled = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}