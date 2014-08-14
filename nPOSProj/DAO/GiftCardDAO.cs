using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;

namespace nPOSProj.DAO
{
    class GiftCardDAO
    {
        private MySqlConnection con;
        private Conf.dbs dbcon;

        public GiftCardDAO() { }

        #region Core Data Access
        public Int32 PositionCount()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT COUNT(*) AS a FROM gc_core ORDER BY gc_id";
            Int32 count = 0;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    count = Convert.ToInt32(rdr["a"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error :: ERROR " + ex);
            }
            finally
            {
                con.Close();
            }
            return count;
        }

        public String[,] Read()
        {
            Int32 count = this.PositionCount();
            String[,] xxx = new String[4, count];
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT * FROM gc_core";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                int counts = 0;
                while (rdr.Read())
                {
                    xxx[0, counts] = rdr["gc_cardno"].ToString();
                    xxx[1, counts] = rdr["gc_amount"].ToString();
                    xxx[2, counts] = rdr["gc_holder"].ToString();
                    xxx[3, counts] = rdr["gc_validuntil"].ToString();
                    counts++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Err :: ERROR " + ex);
            }
            finally
            {
                con.Close();
            }
            return xxx;
        }
        public void Add(String gc_cardno, Double gc_amount, String gc_holder, DateTime gc_validuntil)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "INSERT INTO gc_core (gc_cardno, gc_amount, gc_holder, gc_validuntil) VALUES";
            query += "(?a, ?b, ?c, ?d)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", gc_cardno);
                cmd.Parameters.AddWithValue("?b", gc_amount);
                cmd.Parameters.AddWithValue("?c", gc_holder);
                cmd.Parameters.AddWithValue("?d", gc_validuntil);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void Delete(String gc_cardno)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "DELETE FROM gc_core ";
            query += "WHERE gc_cardno = ?a";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", gc_cardno);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public bool expiry(String gc_cardno)
        {
            bool found = false;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT * FROM gc_core ";
            query += "WHERE (gc_cardno = ?gc_cardno) AND (gc_validuntil <= NOW())";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?gc_cardno", gc_cardno);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    found = true;
                }
                else
                    found = false;
            }
            finally
            {
                con.Close();
            }
            return found;
        }
        #endregion
        #region Checkout Section
        public Double catchA(String gc_cardno)
        {
            Double amount = 0;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT gc_amount AS a FROM gc_core ";
            query += "WHERE gc_cardno = ?gc_cardno";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?gc_cardno", gc_cardno);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    amount = Convert.ToDouble(rdr["a"]);
                }
            }
            finally
            {
                con.Close();
            }
            return amount;
        }

        public void Debit(Double amt, String gc_cardno)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE gc_core SET gc_amount = gc_amount - ?gc_amount ";
            query += "WHERE gc_cardno = ?gc_cardno";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?gc_amount", amt);
                cmd.Parameters.AddWithValue("?gc_cardno", gc_cardno);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
    }
}
