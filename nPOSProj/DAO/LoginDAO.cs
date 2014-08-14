using System;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;


namespace nPOSProj.DAO
{
    public class LoginDAO
    {
        private Conf.dbs dbcon;
        private MySqlConnection con;
        private Conf.Crypto crypts;
        private String user_name = "";
        private String mac;
        private String terminal;
        public LoginDAO()
        {

        }

        public static bool Validate(String inString)
        {
            Regex r = new Regex("^[A-Za-z0-9]{5}$");
            return r.IsMatch(inString);
        }
        public void catchUsername(String username)
        {
            this.user_name = username;
        }
        #region Authenticate Part
        public bool isAuth(String user_name, String user_password)
        {
            con = new MySqlConnection();
            crypts = new Conf.Crypto();
            dbcon = new Conf.dbs();
            bool isAuth = false;
            String crypt = "";
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT * FROM user_account ";
            sql += "WHERE user_name = ?user_name AND user_password = ?user_password";
            try
            {
                con.Open();
                crypts.Hashed(user_password);
                crypt = crypts.retreiveHash();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add("?user_name", MySqlDbType.VarChar, 35).Value = user_name;
                cmd.Parameters.Add("?user_password", MySqlDbType.VarChar, 45).Value = crypt;
                Validate(user_name);
                Validate(user_password);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    isAuth = true;
                }
                else
                    isAuth = false;
            }
            finally
            {
                con.Close();
            }
            return isAuth;
        }
        private String getUserIDfromDB()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT user_id FROM user_account WHERE user_name = ?user_name";
            String UserID = "";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add("?user_name", MySqlDbType.VarChar, 30).Value = user_name;
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    UserID = rdr["user_id"].ToString();
                }
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return UserID;
        }
        public bool canAccess()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            bool canAccess = true;
            String getUserID = getUserIDfromDB();
            con.Close();
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT can_access FROM user_access_restrictions WHERE user_id = ?user_id";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add("?user_id", MySqlDbType.Int32, 3).Value = getUserIDfromDB();
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["can_access"].ToString() == "0")
                        canAccess = false;
                }
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return canAccess;
        }
        public bool hasSales()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            bool hasSales = true;
            String getUserID = getUserIDfromDB();
            con.Close();
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT has_sales FROM user_access_restrictions WHERE user_id = ?user_id";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add("?user_id", MySqlDbType.Int32, 3).Value = getUserIDfromDB();
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["has_sales"].ToString() == "0")
                        hasSales = false;
                }
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return hasSales;
        }
        public bool hasCustomers()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            bool hasCustomers = true;
            String getUserID = getUserIDfromDB();
            con.Close();
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT has_customers FROM user_access_restrictions WHERE user_id = ?user_id";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add("?user_id", MySqlDbType.Int32, 3).Value = getUserIDfromDB();
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["has_customers"].ToString() == "0")
                        hasCustomers = false;
                }
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return hasCustomers;
        }
        public bool hasInventory()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            bool hasInventory = true;
            String getUserID = getUserIDfromDB();
            con.Close();
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT has_inventory FROM user_access_restrictions WHERE user_id = ?user_id";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add("?user_id", MySqlDbType.Int32, 3).Value = getUserIDfromDB();
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["has_inventory"].ToString() == "0")
                        hasInventory = false;
                }
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return hasInventory;
        }
        public bool hasReports()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            bool hasReports = true;
            String getUserID = getUserIDfromDB();
            con.Close();
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT has_reports FROM user_access_restrictions WHERE user_id = ?user_id";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add("?user_id", MySqlDbType.Int32, 3).Value = getUserIDfromDB();
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["has_reports"].ToString() == "0")
                        hasReports = false;
                }
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return hasReports;
        }
        public bool hasGC()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            bool hasGC = true;
            String getUserID = getUserIDfromDB();
            con.Close();
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT has_gc FROM user_access_restrictions WHERE user_id = ?user_id";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add("?user_id", MySqlDbType.Int32, 3).Value = getUserIDfromDB();
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["has_gc"].ToString() == "0")
                        hasGC = false;
                }
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return hasGC;
        }
        public bool hasUser_Accounts()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            bool hasUser_Accounts = true;
            String getUserID = getUserIDfromDB();
            con.Close();
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT has_user_accounts FROM user_access_restrictions WHERE user_id = ?user_id";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add("?user_id", MySqlDbType.Int32, 3).Value = getUserIDfromDB();
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["has_user_accounts"].ToString() == "0")
                        hasUser_Accounts = false;
                }
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return hasUser_Accounts;
        }
        public bool hasUserConf()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            bool hasConf = true;
            String getUserID = getUserIDfromDB();
            con.Close();
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT has_conf FROM user_access_restrictions WHERE user_id = ?user_id";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add("?user_id", MySqlDbType.Int32, 3).Value = getUserIDfromDB();
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["has_conf"].ToString() == "0")
                        hasConf = false;
                }
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return hasConf;
        }
        #endregion
        public String matchMac(String physicalcode)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT physicalcode AS a FROM system_terminal ";
            query += "WHERE physicalcode = ?physicalcode";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?physicalcode", physicalcode);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    mac = rdr["a"].ToString();
                }
                else
                    mac = null;
            }
            finally
            {
                con.Close();
            }
            return mac;
        }
        public String getIndentifier(String physicalcode)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT identify AS a FROM system_terminal ";
            query += "WHERE physicalcode = ?physicalcode";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?physicalcode", physicalcode);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    terminal = rdr["a"].ToString();
                }
                else
                    terminal = null;
            }
            finally
            {
                con.Close();
            }
            return terminal;
        }
    }
}