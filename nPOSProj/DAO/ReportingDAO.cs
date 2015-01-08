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

        #region Beginning Balance Data Access Entry
        public Double ReadBeginningBal()
        {
            Double BeginningBalance = 0;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT balance AS baltairepig FROM beg_bal";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["baltairepig"] == DBNull.Value)
                    {
                        BeginningBalance = 0;
                    }
                    else
                    {
                        BeginningBalance = Convert.ToDouble(rdr["baltairepig"]);
                    }
                }

            }
            finally
            {
                con.Close();
            }
            return BeginningBalance;
        }

        public void UpdateBeginningBal(Double amount)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE beg_bal SET balance = ?a";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", amount);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }

        }
        #endregion

        public Double ReadCashOut(String cd_date, String cd_terminal)
        {
            Double CashOutTotal = 0;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT SUM(cd_debit) AS anq FROM pos_cdlog";
            query += " WHERE cd_date = ?cd_date AND cd_terminal = ?cd_terminal";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?cd_date", cd_date);
                cmd.Parameters.AddWithValue("?cd_terminal", cd_terminal);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["anq"] == DBNull.Value)
                    {
                        CashOutTotal = 0;
                    }
                    else
                    {
                        CashOutTotal = Convert.ToDouble(rdr["anq"]);
                    }
                }
            }
            finally
            {
                con.Close();
            }
            return CashOutTotal;
        }
        public Double ReadCashTotal(String pos_date, String pos_terminal)
        {
            Double CASH = 0;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT SUM(pos_total_amt) AS x FROM pos_store WHERE pos_paymethod = 'Cash' AND pos_date = ?pos_date AND pos_terminal = ?pos_terminal AND pos_park = 0 AND is_cancel = 0";
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
                        CASH = 0;
                    }
                    else
                    {
                        CASH = Convert.ToDouble(rdr["x"]);
                    }
                }
            }
            finally
            {
                con.Close();
            }
            return CASH;
        }
        public Double ReadChequeTotal(String pos_date, String pos_terminal)
        {
            Double CHEKE = 0;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT SUM(pos_total_amt) AS x FROM pos_store WHERE pos_paymethod = 'Bank Cheque' AND pos_date = ?pos_date AND pos_terminal = ?pos_terminal AND pos_park = 0 AND is_cancel = 0";
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
                        CHEKE = 0;
                    }
                    else
                    {
                        CHEKE = Convert.ToDouble(rdr["x"]);
                    }
                }
            }
            finally
            {
                con.Close();
            }
            return CHEKE;
        }
        //
        public Double ReadChargeTotal(String pos_date, String pos_terminal)
        {
            Double UTANG = 0;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT SUM(pos_total_amt) AS x FROM pos_store WHERE pos_paymethod = 'Charge to Accounts' AND pos_date = ?pos_date AND pos_terminal = ?pos_terminal AND pos_park = 0 AND is_cancel = 0";
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
                        UTANG = 0;
                    }
                    else
                    {
                        UTANG = Convert.ToDouble(rdr["x"]);
                    }
                }
            }
            finally
            {
                con.Close();
            }
            return UTANG;
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