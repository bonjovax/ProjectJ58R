using System;
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
    public partial class mdiUserAcc : Form
    {
        private MySqlConnection con;
        private Conf.dbs dbcon;
        private VO.UserAccountVO uavo;
        private String grabID;
        private String username;
        public mdiUserAcc()
        {
            InitializeComponent();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearBoxes();
        }

        private void ClearBoxesU()
        {
            txtBoxUUserName.Clear();
            txtBoxUFirstName.Clear();
            txtBoxUMiddleName.Clear();
            txtBoxULastName.Clear();
        }

        private void getDataTable()
        {
            dbcon = new Conf.dbs();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            String connectionString = dbcon.getConnectionString();
            String query = "SELECT user_account.user_id AS a, user_account.user_name AS b, user_information.first_name AS c, user_information.middle_name AS d, user_information.last_name AS e, user_account.last_login AS f, user_account.date_created AS g ";
            query += "FROM user_account ";
            query += "INNER JOIN user_information ON user_account.user_id = user_information.user_id";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, con))
                {
                    try
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add(dataTable.Rows[i][0], dataTable.Rows[i][1], dataTable.Rows[i][2], dataTable.Rows[i][3], dataTable.Rows[i][4], dataTable.Rows[i][5], dataTable.Rows[i][6]);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex);
                    }
                }
            } // end using
        }

        private void mdiUserAcc_Load(object sender, EventArgs e)
        {
            uavo = new VO.UserAccountVO();
            getDataTable();
            txtBoxUserID.Text = uavo.askUserID().ToString();
            txtBoxFirstName.Focus();
            username = frmLogin.User.user_name;
        }

        private void txtBoxUserID_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxUserID.Text != "" && txtBoxUserName.Text != "" && txtBoxPassword.Text != "" && txtBoxFirstName.Text != "" && txtBoxMiddleName.Text != "" && txtBoxLastName.Text != "")
            {
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }

        private void txtBoxUserName_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxUserID.Text != "" && txtBoxUserName.Text != "" && txtBoxPassword.Text != "" && txtBoxFirstName.Text != "" && txtBoxMiddleName.Text != "" && txtBoxLastName.Text != "")
            {
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }

        private void txtBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxUserID.Text != "" && txtBoxUserName.Text != "" && txtBoxPassword.Text != "" && txtBoxFirstName.Text != "" && txtBoxMiddleName.Text != "" && txtBoxLastName.Text != "")
            {
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }

        private void txtBoxFirstName_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxUserID.Text != "" && txtBoxUserName.Text != "" && txtBoxPassword.Text != "" && txtBoxFirstName.Text != "" && txtBoxMiddleName.Text != "" && txtBoxLastName.Text != "")
            {
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }

        private void txtBoxMiddleName_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxUserID.Text != "" && txtBoxUserName.Text != "" && txtBoxPassword.Text != "" && txtBoxFirstName.Text != "" && txtBoxMiddleName.Text != "" && txtBoxLastName.Text != "")
            {
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }

        private void txtBoxLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxUserID.Text != "" && txtBoxUserName.Text != "" && txtBoxPassword.Text != "" && txtBoxFirstName.Text != "" && txtBoxMiddleName.Text != "" && txtBoxLastName.Text != "")
            {
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            uavo = new VO.UserAccountVO();
            DialogResult dlgResult = MessageBox.Show("Do You Wish To Add Account?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    uavo.user_id = Convert.ToInt32(txtBoxUserID.Text);
                    uavo.user_name = txtBoxUserName.Text;
                    uavo.user_password = txtBoxPassword.Text;
                    uavo.first_name = txtBoxFirstName.Text;
                    uavo.middle_name = txtBoxMiddleName.Text;
                    uavo.last_name = txtBoxLastName.Text;
                    uavo.AddUser();
                    String created = DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToLongTimeString();
                    dataGridView1.Rows.Add(txtBoxUserID.Text, txtBoxUserName.Text, txtBoxFirstName.Text, txtBoxMiddleName.Text, txtBoxLastName.Text, null, created);
                    ClearBoxes();
                    txtBoxUserID.Text = uavo.askUserID().ToString();
                    MessageBox.Show("The Account has been Created", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Account already Exist or Check Database Server!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearBoxes()
        {
            txtBoxUserName.Clear();
            txtBoxPassword.Clear();
            txtBoxFirstName.Clear();
            txtBoxMiddleName.Clear();
            txtBoxLastName.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 catchID = 0;
            uavo = new VO.UserAccountVO();
            txtBoxUUserID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            grabID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtBoxUUserName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtBoxUFirstName.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtBoxUMiddleName.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtBoxULastName.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            getSecurityFlags();
            unlockCheckBox();
            btnSave.Enabled = true;
            uavo.user_name = username;
            uavo.askCatchUserID();
            catchID = uavo.askCatchUserID();
            uavo.user_id = catchID;
            if (catchID == Convert.ToInt32(txtBoxUUserID.Text))
            {
                chkSystemAccess.Enabled = false;
                chkUserAccounts.Enabled = false;
            }
            else
            {
                chkSystemAccess.Enabled = true;
                chkUserAccounts.Enabled = true;
            }
        }

        private void txtBoxUUserID_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxUUserID.Text != "" && txtBoxUUserName.Text != "" && txtBoxUFirstName.Text != "" && txtBoxUMiddleName.Text != "" && txtBoxULastName.Text != "")
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void txtBoxUUserName_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxUUserID.Text != "" && txtBoxUUserName.Text != "" && txtBoxUFirstName.Text != "" && txtBoxUMiddleName.Text != "" && txtBoxULastName.Text != "")
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void txtBoxUFirstName_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxUUserID.Text != "" && txtBoxUUserName.Text != "" && txtBoxUFirstName.Text != "" && txtBoxUMiddleName.Text != "" && txtBoxULastName.Text != "")
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void txtBoxUMiddleName_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxUUserID.Text != "" && txtBoxUUserName.Text != "" && txtBoxUFirstName.Text != "" && txtBoxUMiddleName.Text != "" && txtBoxULastName.Text != "")
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void txtBoxULastName_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxUUserID.Text != "" && txtBoxUUserName.Text != "" && txtBoxUFirstName.Text != "" && txtBoxUMiddleName.Text != "" && txtBoxULastName.Text != "")
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnUClear_Click(object sender, EventArgs e)
        {
            ClearBoxesU();
            //dataGridView1.SelectedRows[0].Cells[1].Value = "Bilat";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            uavo = new VO.UserAccountVO();
            DialogResult dlgResult = MessageBox.Show("Do You Wish To Update an Account You Have Selected?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    uavo.user_id = Convert.ToInt32(txtBoxUUserID.Text);
                    uavo.user_name = txtBoxUUserName.Text;
                    uavo.first_name = txtBoxUFirstName.Text;
                    uavo.middle_name = txtBoxUMiddleName.Text;
                    uavo.last_name = txtBoxULastName.Text;
                    uavo.UpdateUser();
                    dataGridView1.SelectedRows[0].Cells[0].Value = txtBoxUUserID.Text;
                    dataGridView1.SelectedRows[0].Cells[1].Value = txtBoxUUserName.Text;
                    dataGridView1.SelectedRows[0].Cells[2].Value = txtBoxUFirstName.Text;
                    dataGridView1.SelectedRows[0].Cells[3].Value = txtBoxUMiddleName.Text;
                    dataGridView1.SelectedRows[0].Cells[4].Value = txtBoxULastName.Text;
                    ClearBoxesU();
                    MessageBox.Show("The Account has been Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Username already Exist or Check Database Server!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            uavo = new VO.UserAccountVO();
            DialogResult dlgResult = MessageBox.Show("Do You Want to Delete This Account?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlgResult == DialogResult.Yes)
            {
                uavo.user_id = Convert.ToInt32(txtBoxUUserID.Text);
                uavo.user_name = txtBoxUUserName.Text;
                uavo.DeleteUser();
                txtBoxUserID.Text = uavo.askUserID().ToString();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                txtBoxUUserID.Clear();
                ClearBoxesU();
                MessageBox.Show("The Record that you've Selected has already Deleted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void getSecurityFlags()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            try
            {
                con.Open();
                String query = "SELECT can_access AS a, has_sales AS b, has_order AS b1, has_customers AS c, has_inventory AS d, has_reports AS e, has_gc AS f, has_user_accounts AS g, has_conf AS h ";
                query += "FROM user_access_restrictions ";
                query += "WHERE user_id = ?grab";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?grab", grabID);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr["a"].ToString() == "1")
                {
                    chkSystemAccess.Checked = true;
                }
                else
                {
                    chkSystemAccess.Checked = false;
                }
                if (rdr["b"].ToString() == "1")
                {
                    chkSales.Checked = true;
                }
                else
                {
                    chkSales.Checked = false;
                }
                //
                if (rdr["b1"].ToString() == "1")
                {
                    chkOrder.Checked = true;
                }
                else
                {
                    chkOrder.Checked = false;
                }
                //
                if (rdr["c"].ToString() == "1")
                {
                    chkCustomers.Checked = true;
                }
                else
                {
                    chkCustomers.Checked = false;
                }
                if (rdr["d"].ToString() == "1")
                {
                    chkInventory.Checked = true;
                }
                else
                {
                    chkInventory.Checked = false;
                }
                if (rdr["e"].ToString() == "1")
                {
                    chkReports.Checked = true;
                }
                else
                {
                    chkReports.Checked = false;
                }
                if (rdr["f"].ToString() == "1")
                {
                    chkGiftCards.Checked = true;
                }
                else
                {
                    chkGiftCards.Checked = false;
                }
                if (rdr["g"].ToString() == "1")
                {
                    chkUserAccounts.Checked = true;
                }
                else
                {
                    chkUserAccounts.Checked = false;
                }
                if (rdr["h"].ToString() == "1")
                {
                    chkConfiguration.Checked = true;
                }
                else
                {
                    chkConfiguration.Checked = false;
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Int32 can_access = 0;
            Int32 has_sales = 0;
            Int32 has_order = 0;
            Int32 has_customers = 0;
            Int32 has_inventory = 0;
            Int32 has_reports= 0;
            Int32 has_gc = 0;
            Int32 has_user_accounts = 0;
            Int32 has_conf = 0;
            uavo = new VO.UserAccountVO();
            try
            {
                if (chkSystemAccess.Checked)
                {
                    can_access = 1;
                }
                else
                {
                    can_access = 0;
                }
                if (chkSales.Checked)
                {
                    has_sales = 1;
                }
                else
                {
                    has_sales = 0;
                }
                if (chkOrder.Checked)
                {
                    has_order = 1;
                }
                else
                {
                    has_order = 0;
                }
                if (chkCustomers.Checked)
                {
                    has_customers = 1;
                }
                else
                {
                    has_customers = 0;
                }
                if (chkInventory.Checked)
                {
                    has_inventory = 1;
                }
                else
                {
                    has_inventory = 0;
                }
                if (chkReports.Checked)
                {
                    has_reports = 1;
                }
                else
                {
                    has_reports = 0;
                }
                if (chkGiftCards.Checked)
                {
                    has_gc = 1;
                }
                else
                {
                    has_gc = 0;
                }
                if (chkUserAccounts.Checked)
                {
                    has_user_accounts = 1;
                }
                else
                {
                    has_user_accounts = 0;
                }
                if (chkConfiguration.Checked)
                {
                    has_conf = 1;
                }
                else
                {
                    has_conf = 0;
                }
                uavo.can_access = can_access;
                uavo.has_sales = has_sales;
                uavo.has_order = has_order;
                uavo.has_customers = has_customers;
                uavo.has_inventory = has_inventory;
                uavo.has_reports = has_reports;
                uavo.has_gc = has_gc;
                uavo.has_user_accounts = has_user_accounts;
                uavo.has_conf = has_conf;
                uavo.user_id = Convert.ToInt32(txtBoxUUserID.Text);
                uavo.SaveRestriction();
                btnSave.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }

        private void chkSystemAccess_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void chkSales_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void chkCustomers_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void chkInventory_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void chkReports_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void chkGiftCards_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void chkUserAccounts_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void chkConfiguration_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void unlockCheckBox() 
        {
            chkSales.Enabled = true;
            chkOrder.Enabled = true;
            chkCustomers.Enabled = true;
            chkInventory.Enabled = true;
            chkReports.Enabled = true;
            chkGiftCards.Enabled = true;
            chkUserAccounts.Enabled = true;
            chkConfiguration.Enabled = true;
        }
    }
}