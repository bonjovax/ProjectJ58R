using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace nPOSProj.DAO
{
    class ChangePasswordDAO
    {
        private MySqlConnection con;
        private Conf.dbs dbcon;
        private Conf.Crypto ecr;

        public ChangePasswordDAO()
        {

        }

        public String catchUserID()
        {
            String userName = frmLogin.User.user_name;
            dbcon = new Conf.dbs();
            con = new MySqlConnection(dbcon.getConnectionString());
            String query = "SELECT user_id FROM user_account ";
            query += "WHERE user_name = ?user_name";
            String catchID = "";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add("?user_name", MySqlDbType.VarChar, 48).Value = userName;
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    catchID = rdr["user_id"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return catchID;
        }
        public void ChangeThePassword(String newPass)
        {
            dbcon = new Conf.dbs();
            ecr = new Conf.Crypto();
            con = new MySqlConnection(dbcon.getConnectionString());
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE user_account SET user_password = ?user_password ";
            query += "WHERE user_id = ?user_id";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                ecr.Hashed(newPass);
                String hashpass = ecr.retreiveHash();
                cmd.Parameters.AddWithValue("?user_password", hashpass);
                cmd.Parameters.AddWithValue("?user_id", this.catchUserID());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
    }
}
