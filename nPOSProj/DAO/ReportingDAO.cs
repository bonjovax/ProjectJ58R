using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;

namespace nPOSProj.DAO
{
    class ReportingDAO
    {
        private MySqlConnection con;
        private Conf.dbs dbcon;

        public ReportingDAO()
        {

        }

        public Double ReadGrossAmount(String pos_date, String pos_terminal)
        {
            Double GrossAmount = 0;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT SUM(pos_total_amt) AS x FROM pos_store ";
            query += "WHERE (pos_date = ?pos_date) AND (pos_terminal = ?pos_terminal)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?pos_date", pos_date);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["x"] == DBNull.Value)
                    {
                        GrossAmount = 0;
                    }
                    else
                    {
                        GrossAmount = Convert.ToDouble(rdr["x"]);
                    }
                }
            }
            finally
            {
                con.Close();
            }
            return GrossAmount;
        }
        public Double ReadDiscounts(String pos_date, String pos_terminal)
        {
            Double Discount = 0;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT SUM(pos_disc_amt) AS y FROM pos_store ";
            query += "WHERE (pos_date = ?pos_date) AND (pos_terminal = ?pos_terminal)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?pos_date", pos_date);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["y"] == DBNull.Value)
                    {
                        Discount = 0;
                    }
                    else
                    {
                        Discount = Convert.ToDouble(rdr["y"]);
                    }
                }
            }
            finally
            {
                con.Close();
            }
            return Discount;
        }
        public Double ReadTaxAmt(String pos_date, String pos_terminal)
        {
            Double TaxAmount = 0;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT SUM(pos_tax_amt) AS a FROM pos_store ";
            query += "WHERE (pos_date = ?date) AND (pos_terminal = ?terminal)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?date", pos_date);
                cmd.Parameters.AddWithValue("?terminal", pos_terminal);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["a"] == DBNull.Value)
                    {
                        TaxAmount = 0;
                    }
                    else
                    {
                        TaxAmount = Convert.ToDouble(rdr["a"]);
                    }
                }
            }
            finally
            {
                con.Close();
            }
            return TaxAmount;
        }
        public Int32 CounterStart(String pos_date, String pos_terminal)
        {
            Int32 Ctr = 0;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT pos_orno AS a FROM pos_store ";
            query += "WHERE (pos_date = ?date) AND (pos_terminal = ?terminal) ";
            query += "ORDER BY pos_orno ASC LIMIT 1";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?date", pos_date);
                cmd.Parameters.AddWithValue("?terminal", pos_terminal);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["a"] == DBNull.Value)
                    {
                        Ctr = 0;
                    }
                    else
                    {
                        Ctr = Convert.ToInt32(rdr["a"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
            return Ctr;
        }
        public Int32 CounterEnd(String pos_date, String pos_terminal)
        {
            Int32 Ctr = 0;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT pos_orno AS b FROM pos_store ";
            query += "WHERE (pos_date = ?date) AND (pos_terminal = ?terminal) ";
            query += "ORDER BY pos_orno DESC LIMIT 1";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?date", pos_date);
                cmd.Parameters.AddWithValue("?terminal", pos_terminal);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["b"] == DBNull.Value)
                    {
                        Ctr = 0;
                    }
                    else
                    {
                        Ctr = Convert.ToInt32(rdr["b"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
            return Ctr;
        }
        public Int32 countCancel(String pos_date, String pos_terminal)
        {
            Int32 Count = 0;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT COUNT(*) AS a FROM pos_store ";
            query += "WHERE (pos_date = ?date) AND (pos_terminal = ?terminal) AND (is_cancel = 1)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?date", pos_date);
                cmd.Parameters.AddWithValue("?terminal", pos_terminal);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["a"] == DBNull.Value)
                    {
                        Count = 0;
                    }
                    else
                    {
                        Count = Convert.ToInt32(rdr["a"]);
                    }
                }
            }
            finally
            {
                con.Close();
            }
            return Count;
        }
        public Int32 NoOfTrans(String pos_date, String pos_terminal)
        {
            Int32 Count = 0;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT COUNT(*) AS x FROM pos_store ";
            query += "WHERE (pos_date = ?date) AND (pos_terminal = ?terminal) AND (is_cancel = 0)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?date", pos_date);
                cmd.Parameters.AddWithValue("?terminal", pos_terminal);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["x"] == DBNull.Value)
                    {
                        Count = 0;
                    }
                    else
                    {
                        Count = Convert.ToInt32(rdr["x"]);
                    }
                }
            }
            finally
            {
                con.Close();
            }
            return Count;
        }
        public Int32 NoOfEAN(String pos_date, String pos_terminal)
        {
            Int32 Count = 0;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT COUNT(pos_ean) AS a FROM pos_park ";
            query += "WHERE (pos_parked_date = ?date) AND (pos_terminal = ?terminal)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?date", pos_date);
                cmd.Parameters.AddWithValue("?terminal", pos_terminal);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["a"] == DBNull.Value)
                    {
                        Count = 0;
                    }
                    else
                    {
                        Count = Convert.ToInt32(rdr["a"]);
                    }
                }
            }
            finally
            {
                con.Close();
            }
            return Count;
        }
        public Int32 TotalQty(String pos_date, String pos_terminal)
        {
            Int32 Count = 0;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT SUM(pos_quantity) AS a FROM pos_park ";
            query += "WHERE (pos_parked_date = ?date) AND (pos_terminal = ?terminal)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?date", pos_date);
                cmd.Parameters.AddWithValue("?terminal", pos_terminal);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["a"] == DBNull.Value)
                    {
                        Count = 0;
                    }
                    else
                    {
                        Count = Convert.ToInt32(rdr["a"]);
                    }
                }
            }
            finally
            {
                con.Close();
            }
            return Count;
        }
        public Double PreviousNET(String pos_date, String pos_terminal)
        {
            Double amount = 0;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT SUM(pos_total_amt) AS a FROM pos_store ";
            query += "WHERE (pos_date = ?pos_date) AND (pos_terminal = ?pos_terminal)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?pos_date", pos_date);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["a"] == DBNull.Value)
                    {
                        amount = 0;
                    }
                    else
                    {
                        amount = Convert.ToInt32(rdr["a"]);
                    }
                }
            }
            finally
            {
                con.Close();
            }
            return amount;
        }
    }
}