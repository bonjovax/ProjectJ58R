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
    public partial class mdiResetPassword : Form
    {
        private MySqlConnection con;
        private Conf.dbs dbcon;
        AutoCompleteStringCollection collect = new AutoCompleteStringCollection();
        private VO.UserAccountVO uavo;
        private String username;
        public mdiResetPassword()
        {
            InitializeComponent();
        }

        private void loadUsername()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT DISTINCT user_name FROM user_account ORDER BY user_name ASC";
            try
            {
                cBoxUserName.Items.Clear();
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cBoxUserName.BeginUpdate();
                    cBoxUserName.Items.Add(rdr["user_name"].ToString());
                    cBoxUserName.EndUpdate();
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }

        private void mdiResetPassword_Load(object sender, EventArgs e)
        {
            username = frmLogin.User.user_name;
            loadUsername();
        }

        private void cBoxUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (username == cBoxUserName.Text)
            {
                btnReset.Enabled = false;
            }
            if (cBoxUserName.Text != "" && cBoxUserName.Text != username)
            {
                btnReset.Enabled = true;
            }
            else
                btnReset.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            uavo = new VO.UserAccountVO();
            DialogResult dlgResult = MessageBox.Show("Do You Wish To Reset this Account?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    uavo.user_name = cBoxUserName.Text;
                    uavo.Reset();
                    btnReset.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}