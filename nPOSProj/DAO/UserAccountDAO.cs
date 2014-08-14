using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text;
using System.Text.RegularExpressions;

namespace nPOSProj.DAO
{
    public class UserAccountDAO
    {
        private MySqlConnection con;
        private Conf.Crypto crypts;
        private Conf.dbs dbcon;
        private String passcrypt = "";
        private static String defaultPassword = "12345654321";
        private Int32 UserID = 0;
        private Int32 catchUserID = 0;

        public UserAccountDAO()
        {

        }

        public static bool Validate(String inString)
        {
            Regex r = new Regex("^[A-Za-z0-9]{5}$");
            return r.IsMatch(inString);
        }
        public void logs(String user_name)
        {
            String now = DateTime.Now.ToString();
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE user_account SET last_login = ?last_login";
            query += " WHERE user_name = ?user_name";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?last_login", now);
                cmd.Parameters.AddWithValue("?user_name", user_name);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        public void resetPassword(String user_name)
        {
            crypts = new Conf.Crypto();
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE user_account SET user_password = ?user_password";
            query += " WHERE user_name = ?user_name";
            try
            {
                con.Open();
                crypts.Hashed(defaultPassword);
                passcrypt = crypts.retreiveHash();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?user_password", passcrypt);
                cmd.Parameters.AddWithValue("?user_name", user_name);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public Int32 catchUserIDFromUserName(String user_name)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT user_id FROM user_account ";
            query += "WHERE user_name = ?user_name";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?user_name", user_name);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    catchUserID = Convert.ToInt32(rdr["user_id"]);
                    sendCatchUserID();
                }
                else
                {
                    catchUserID = 0;
                    sendCatchUserID();
                }
            }
            finally
            {
                con.Close();
            }
            return catchUserID;
        }

        public Int32 sendCatchUserID()
        {
            return catchUserID;
        }

        public Int32 postUserID()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT COUNT(*) AS get FROM user_account;";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    UserID = Convert.ToInt32(rdr["get"]);
                    sendUserID();
                }
                else
                {
                    UserID = 0;
                    sendUserID();
                }
            }
            finally
            {
                con.Close();
            }
            return UserID;
        }
        private Int32 sendUserID()
        {
            return UserID;
        }

        public void Add(Int32 user_id, String user_name, String user_password, String first_name, String middle_name, String last_name)
        {
            crypts = new Conf.Crypto();
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query1 = "INSERT INTO user_account (user_id, user_name, user_password, date_created) VALUES";
            query1 += "(?user_id, ?user_name, ?user_password, ?date_created)";
            String query2 = "INSERT INTO user_information (user_id, first_name, middle_name, last_name) VALUES";
            query2 += "(?user_id, ?first_name, ?middle_name, ?last_name)";
            String query3 = "INSERT INTO user_access_restrictions (user_id) VALUES";
            query3 += "(?user_id)";
            try
            {
                con.Open();
                crypts.Hashed(user_password);
                passcrypt = crypts.retreiveHash();
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                MySqlCommand cmd2 = new MySqlCommand(query2, con);
                MySqlCommand cmd3 = new MySqlCommand(query3, con);
                cmd1.Parameters.AddWithValue("?user_id", user_id);
                cmd1.Parameters.AddWithValue("?user_name", user_name);
                cmd1.Parameters.AddWithValue("?user_password", passcrypt);
                cmd1.Parameters.AddWithValue("?date_created", DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToLongTimeString());
                cmd2.Parameters.AddWithValue("?user_id", user_id);
                cmd2.Parameters.AddWithValue("?first_name", first_name);
                cmd2.Parameters.AddWithValue("?middle_name", middle_name);
                cmd2.Parameters.AddWithValue("?last_name", last_name);
                cmd3.Parameters.AddWithValue("?user_id", user_id);
                cmd1.ExecuteNonQuery();
                cmd1.Dispose();
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();
                cmd3.ExecuteNonQuery();
                cmd3.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void Update(Int32 user_id, String user_name, String first_name, String middle_name, String last_name)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query1 = "UPDATE user_account SET user_name = ?user_name ";
            query1 += "WHERE user_id = ?user_id";
            String query2 = "UPDATE user_information SET first_name = ?first_name, middle_name = ?middle_name, last_name = ?last_name ";
            query2 += "WHERE user_id = ?user_id";
            try
            {
                con.Open();
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                MySqlCommand cmd2 = new MySqlCommand(query2, con);
                cmd1.Parameters.AddWithValue("?user_name", user_name);
                cmd1.Parameters.AddWithValue("?user_id", user_id);
                cmd2.Parameters.AddWithValue("?first_name", first_name);
                cmd2.Parameters.AddWithValue("?middle_name", middle_name);
                cmd2.Parameters.AddWithValue("?last_name", last_name);
                cmd2.Parameters.AddWithValue("?user_id", user_id);
                cmd1.ExecuteNonQuery();
                cmd1.Dispose();
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateRestrictions(Int32 can_access, Int32 has_sales, Int32 has_customers, Int32 has_inventory, Int32 has_reports, Int32 has_gc, Int32 has_user_accounts, Int32 has_conf, Int32 user_id)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE user_access_restrictions SET ";
            query += "can_access = ?can_access, has_sales = ?has_sales, has_customers = ?has_customers, has_inventory = ?has_inventory, has_reports = ?has_reports, has_gc = ?has_gc, has_user_accounts = ?has_user_accounts, has_conf = ?has_conf ";
            query += "WHERE user_id = ?user_id";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?can_access", can_access);
                cmd.Parameters.AddWithValue("?has_sales", has_sales);
                cmd.Parameters.AddWithValue("?has_customers", has_customers);
                cmd.Parameters.AddWithValue("?has_inventory", has_inventory);
                cmd.Parameters.AddWithValue("?has_reports", has_reports);
                cmd.Parameters.AddWithValue("?has_gc", has_gc);
                cmd.Parameters.AddWithValue("?has_user_accounts", has_user_accounts);
                cmd.Parameters.AddWithValue("?has_conf", has_conf);
                cmd.Parameters.AddWithValue("?user_id", user_id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void Delete(Int32 user_id, String user_name)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query1 = "DELETE FROM user_account ";
            query1 += "WHERE user_id = ?user_id AND user_name = ?user_name";
            String query2 = "DELETE FROM user_information ";
            query2 += "WHERE user_id = ?user_id";
            String query3 = "DELETE FROM user_access_restrictions ";
            query3 += "WHERE user_id = ?user_id";
            try
            {
                con.Open();
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                MySqlCommand cmd2 = new MySqlCommand(query2, con);
                MySqlCommand cmd3 = new MySqlCommand(query3, con);
                cmd1.Parameters.AddWithValue("?user_id", user_id);
                cmd1.Parameters.AddWithValue("?user_name", user_name);
                cmd2.Parameters.AddWithValue("?user_id", user_id);
                cmd3.Parameters.AddWithValue("?user_id", user_id);
                cmd1.ExecuteNonQuery();
                cmd1.Dispose();
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();
                cmd3.ExecuteNonQuery();
                cmd3.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
    }
}