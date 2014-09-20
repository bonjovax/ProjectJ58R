using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nPOSProj.DAO
{
    class PosDAO
    {
        private MySqlConnection con;
        private MySqlConnection con1;
        private Conf.dbs dbcon;
        private Int32 OrNo;

        public PosDAO() { }
        #region Main Course
        public void Begin(Int32 pos_orno, String pos_terminal, DateTime pos_date, DateTime pos_time, String pos_user)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "INSERT INTO pos_store (pos_orno, pos_terminal, pos_date, pos_time, pos_user) VALUES";
            query += "(?pos_orno, ?pos_terminal, ?pos_date, ?pos_time, ?pos_user)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd.Parameters.AddWithValue("?pos_date", pos_date);
                cmd.Parameters.AddWithValue("?pos_time", pos_time);
                cmd.Parameters.AddWithValue("?pos_user", pos_user);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public Int32 GenerateOR(String pos_terminal)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT COUNT(*) AS a FROM pos_store ";
            query += "WHERE pos_terminal = ?pos_terminal";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    OrNo = Convert.ToInt32(rdr["a"]);
                }
            }
            finally
            {
                con.Close();
            }
            return OrNo;
        }
        public void SwitchWS(Int32 pos_orno)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE pos_store SET pos_iswholesale = 1 ";
            query += "WHERE pos_orno = ?pos_orno";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void SwitchRT(Int32 pos_orno)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE pos_store SET pos_iswholesale = 0 ";
            query += "WHERE pos_orno = ?pos_orno";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void Park_I(Int32 pos_orno, String pos_terminal, String pos_ean, Int32 pos_quantity, Double pos_amt)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "INSERT INTO pos_park (pos_orno, pos_terminal, pos_parked_date, pos_ean, pos_quantity, pos_amt) VALUES";
            query += "(?pos_orno, ?pos_terminal, ?pos_parked_date, ?pos_ean, ?pos_quantity, ?pos_amt)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd.Parameters.AddWithValue("?pos_parked_date", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("?pos_ean", pos_ean);
                cmd.Parameters.AddWithValue("?pos_quantity", pos_quantity);
                cmd.Parameters.AddWithValue("?pos_amt", pos_amt);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void Park_I_Update(Int32 pos_orno, String pos_terminal, String pos_ean, Int32 pos_quantity, Double pos_amt)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE pos_park SET pos_quantity = pos_quantity + ?pos_quantity, pos_discount = 0, pos_discount_amt = 0, pos_amt = ?pos_amt, pos_parked_date = ?pos_parked_date ";
            query += "WHERE (pos_orno = ?pos_orno) AND (pos_terminal = ?pos_terminal) AND (pos_ean = ?pos_ean)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?pos_quantity", pos_quantity);
                cmd.Parameters.AddWithValue("?pos_amt", pos_amt);
                cmd.Parameters.AddWithValue("?pos_parked_date", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd.Parameters.AddWithValue("?pos_ean", pos_ean);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void ParkU_I(Int32 pos_orno, String pos_terminal, String pos_ean, Double pos_discount, Double pos_discount_amt, Int32 pos_quantity, Double pos_amt)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE pos_park SET pos_quantity = ?pos_quantity, pos_discount = ?pos_discount, pos_discount_amt = ?pos_discount_amt, pos_amt = ?pos_amt, pos_parked_date = ?pos_parked_date ";
            query += "WHERE (pos_orno = ?pos_orno) AND (pos_terminal = ?pos_terminal) AND (pos_ean = ?pos_ean)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd.Parameters.AddWithValue("?pos_ean", pos_ean);
                cmd.Parameters.AddWithValue("?pos_discount", pos_discount);
                cmd.Parameters.AddWithValue("?pos_discount_amt", pos_discount_amt);
                cmd.Parameters.AddWithValue("?pos_quantity", pos_quantity);
                cmd.Parameters.AddWithValue("?pos_amt", pos_amt);
                cmd.Parameters.AddWithValue("?pos_parked_date", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void ParkUwD_I(Int32 pos_orno, String pos_terminal, String pos_ean, Double pos_discount, Double pos_discount_amt, Double pos_amt)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE pos_park SET pos_discount = ?pos_discount, pos_discount_amt = ?pos_discount_amt, pos_amt = ?pos_amt, pos_parked_date = ?pos_parked_date ";
            query += "WHERE (pos_orno = ?pos_orno) AND (pos_terminal = ?pos_terminal) AND (pos_ean = ?pos_ean)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd.Parameters.AddWithValue("?pos_ean", pos_ean);
                cmd.Parameters.AddWithValue("?pos_discount", pos_discount);
                cmd.Parameters.AddWithValue("?pos_discount_amt", pos_discount_amt);
                cmd.Parameters.AddWithValue("?pos_amt", pos_amt);
                cmd.Parameters.AddWithValue("?pos_parked_date", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void ParkVoid_I(Int32 pos_orno, String pos_terminal, String pos_ean, Int32 pos_quantity)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE inventory_items SET item_quantity = item_quantity + ?item_quantity ";
            query += "WHERE (item_ean = ?item_ean)";
            String query1 = "DELETE FROM pos_park ";
            query1 += "WHERE (pos_orno = ?pos_orno) AND (pos_terminal = ?pos_terminal) AND (pos_ean = ?pos_ean)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                cmd.Parameters.AddWithValue("?item_quantity", pos_quantity);
                cmd.Parameters.AddWithValue("?item_ean", pos_ean);
                cmd1.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd1.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd1.Parameters.AddWithValue("?pos_ean", pos_ean);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd1.ExecuteNonQuery();
                cmd1.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void ReturnCancelI(String pos_ean, Int32 pos_quantity, Int32 pos_orno, String pos_terminal)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE pos_park SET pos_quantity = pos_quantity - ?pos_quantity ";
            query += "WHERE (pos_ean = ?pos_ean) AND (pos_orno = ?pos_orno) AND (pos_terminal = ?pos_terminal)";
            String query1 = "UPDATE inventory_items SET item_quantity = item_quantity + ?item_quantity ";
            query1 += "WHERE (item_ean = ?item_ean)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                cmd.Parameters.AddWithValue("?pos_ean", pos_ean);
                cmd1.Parameters.AddWithValue("?item_quantity", pos_quantity);
                cmd.Parameters.AddWithValue("?pos_quantity", pos_quantity);
                cmd.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd1.Parameters.AddWithValue("?item_ean", pos_ean);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd.Dispose();
                cmd1.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void CancelT(Int32 pos_orno, String pos_terminal)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE pos_store SET is_cancel = 1, pos_park = 0, pos_tax_perc = 0, pos_tax_amt = 0, pos_total_amt = 0, pos_total_amt = 0 ";
            query += "WHERE pos_orno = ?pos_orno AND pos_terminal = ?pos_terminal";
            String query1 = "DELETE FROM pos_park ";
            query1 += "WHERE pos_orno = ?pos_orno AND pos_terminal = ?pos_terminal";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                cmd.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd1.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd1.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd.Dispose();
                cmd1.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Attribute
        public void UpdateTrunkSales(Double pos_vatable, Double pos_vex, Double pos_vatz, Double tax_p, Double tax_amt, Double pos_disc_amt, Double pos_total_amt, Int32 pos_orno, String pos_terminal)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE pos_store SET pos_vatable = ?vatable, pos_vex = ?vex, pos_vatz = ?zero, pos_tax_perc = ?a, pos_tax_amt = ?b, pos_disc_amt = ?disc, pos_total_amt = ?c ";
            query += "WHERE pos_orno = ?pos_orno AND pos_terminal = ?pos_terminal";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?vatable", pos_vatable);
                cmd.Parameters.AddWithValue("?vex", pos_vex);
                cmd.Parameters.AddWithValue("?zero", pos_vatz);
                cmd.Parameters.AddWithValue("?a", tax_p);
                cmd.Parameters.AddWithValue("?b", tax_amt);
                cmd.Parameters.AddWithValue("?disc", pos_disc_amt);
                cmd.Parameters.AddWithValue("?c", pos_total_amt);
                cmd.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Checkout Stuffs
        public void Cash(Double pos_tender, Double pos_change, Int32 pos_orno, String pos_terminal)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE pos_store SET crm_custcode = 'WLKIN', pos_customer = 'Walk-In', pos_paymethod = 'Cash', ";
            query += "pos_tender = ?pos_tender, pos_change = ?pos_change, pos_park = 0 ";
            query += "WHERE (pos_orno = ?pos_orno) AND (pos_terminal = ?pos_terminal)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?pos_tender", pos_tender);
                cmd.Parameters.AddWithValue("?pos_change", pos_change);
                cmd.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void NoSalesTrans(Int32 pos_orno, String pos_terminal)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE pos_store SET crm_custcode = 'NOSLE', pos_customer = 'No Sale', pos_paymethod = 'NoSale', ";
            query += "pos_park = 0 ";
            query += "WHERE (pos_orno = ?pos_orno) AND (pos_terminal = ?pos_terminal)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void DBCCard(Double pos_tender, Int32 pos_orno, String pos_terminal, String card_data, String card_lastfour, String card_type, Double tx_amount)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE pos_store SET crm_custcode = 'WLKIN', pos_customer = 'Walk-In', pos_paymethod = 'Debit/Credit Card', ";
            query += "pos_tender = ?pos_tender, pos_park = 0 ";
            query += "WHERE (pos_orno = ?pos_orno) AND (pos_terminal = ?pos_terminal)";
            String query1 = "INSERT INTO pos_dc_tx (pos_orno, pos_terminal, card_data, card_lastfour, card_type, tx_amount, date_tx, time_tx) VALUES";
            query1 += "(?pos_orno, ?pos_terminal, ?card_data, ?card_lastfour, ?card_type, ?tx_amount, ?date_tx, ?time_tx)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                //
                cmd.Parameters.AddWithValue("?pos_tender", pos_tender);
                cmd.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                //
                cmd1.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd1.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd1.Parameters.AddWithValue("?card_data", card_data);
                cmd1.Parameters.AddWithValue("?card_lastfour", card_lastfour);
                cmd1.Parameters.AddWithValue("?card_type", card_type);
                cmd1.Parameters.AddWithValue("?tx_amount", tx_amount);
                cmd1.Parameters.AddWithValue("?date_tx", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd1.Parameters.AddWithValue("?time_tx", DateTime.Now.ToString("HH:mm:ss"));
                //
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd.Dispose();
                cmd1.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void BCheck(Double pos_tender, Int32 pos_orno, String pos_terminal, String bc_checkno, String bc_banknbranch, String bc_refcode, Double tx_amount)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE pos_store SET crm_custcode = 'WLKIN', pos_customer = 'Walk-In', pos_paymethod = 'Bank Cheque', ";
            query += "pos_tender = ?pos_tender, pos_park = 0 ";
            query += "WHERE (pos_orno = ?pos_orno) AND (pos_terminal = ?pos_terminal)";
            String query1 = "INSERT INTO pos_bc_tx (pos_orno, pos_terminal, bc_checkno, bc_banknbranch, bc_refcode, tx_amount, date_tx, time_tx) VALUES";
            query1 += "(?pos_orno, ?pos_terminal, ?bc_checkno, ?bc_banknbranch, ?bc_refcode, ?tx_amount, ?date_tx, ?time_tx)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                //
                cmd.Parameters.AddWithValue("?pos_tender", pos_tender);
                cmd.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                //
                cmd1.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd1.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd1.Parameters.AddWithValue("?bc_checkno", bc_checkno);
                cmd1.Parameters.AddWithValue("?bc_banknbranch", bc_banknbranch);
                cmd1.Parameters.AddWithValue("?bc_refcode", bc_refcode);
                cmd1.Parameters.AddWithValue("?tx_amount", tx_amount);
                cmd1.Parameters.AddWithValue("?date_tx", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd1.Parameters.AddWithValue("?time_tx", DateTime.Now.ToString("HH:mm:ss"));
                //
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd.Dispose();
                cmd1.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void GiftDick(Double pos_tender, Int32 pos_orno, String pos_terminal, String gc_cardno, Double tx_amount)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE pos_store SET crm_custcode = 'WLKIN', pos_customer = 'Walk-In', pos_paymethod = 'Gift Card', ";
            query += "pos_tender = ?pos_tender, pos_park = 0 ";
            query += "WHERE (pos_orno = ?pos_orno) AND (pos_terminal = ?pos_terminal)";
            String query1 = "INSERT INTO pos_gc_tx (pos_orno, pos_terminal, gc_cardno, tx_amount, date_tx, time_tx) VALUES";
            query1 += "(?pos_orno, ?pos_terminal, ?gc_cardno, ?tx_amount, ?date_tx, ?time_tx)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                //
                cmd.Parameters.AddWithValue("?pos_tender", pos_tender);
                cmd.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                //
                cmd1.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd1.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd1.Parameters.AddWithValue("?gc_cardno", gc_cardno);
                cmd1.Parameters.AddWithValue("?tx_amount", tx_amount);
                cmd1.Parameters.AddWithValue("?date_tx", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd1.Parameters.AddWithValue("?time_tx", DateTime.Now.ToString("HH:mm:ss"));
                //
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd.Dispose();
                cmd1.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void AR_Basic(String customer, Double pos_tender, Int32 pos_orno, String pos_terminal, String crm_custcode, Double tx_amount)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE pos_store SET crm_custcode = ?set_custcode, pos_customer = ?set_customer, pos_paymethod = 'Charge to Accounts', ";
            query += "pos_tender = ?pos_tender, pos_park = 0 ";
            query += "WHERE (pos_orno = ?pos_orno) AND (pos_terminal = ?pos_terminal)";
            String query1 = "INSERT INTO pos_ar_basic_tx (pos_orno, pos_terminal, crm_custcode, tx_amount, date_tx, time_tx) VALUES";
            query1 += "(?pos_orno, ?pos_terminal, ?crm_custcode, ?tx_amount, ?date_tx, ?time_tx)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                //
                cmd.Parameters.AddWithValue("?set_custcode", crm_custcode);
                cmd.Parameters.AddWithValue("?set_customer", customer);
                cmd.Parameters.AddWithValue("?pos_tender", pos_tender);
                cmd.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                //
                cmd1.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd1.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd1.Parameters.AddWithValue("?crm_custcode", crm_custcode);
                cmd1.Parameters.AddWithValue("?tx_amount", tx_amount);
                cmd1.Parameters.AddWithValue("?date_tx", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd1.Parameters.AddWithValue("?time_tx", DateTime.Now.ToString("HH:mm:ss"));
                //
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd.Dispose();
                cmd1.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Refund
        public Int32 CountRefund(Int32 order_no, String pos_terminal)
        {
            con = new MySqlConnection();
            con1 = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            con1.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT COUNT(*) AS a ";
            query += "FROM pos_park INNER JOIN inventory_items ON pos_park.pos_ean = inventory_items.item_ean INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (pos_park.pos_orno = ?pos_orno) AND (pos_park.pos_terminal = ?pos_terminal)";
            String query1 = "SELECT COUNT(*) AS a ";
            query1 += "FROM pos_park INNER JOIN inventory_items ON pos_park.pos_ean = inventory_items.item_ean ";
            query1 += "WHERE (pos_park.pos_orno = ?pos_orno) AND (inventory_items.is_kit = 1) AND (pos_park.pos_terminal = ?pos_terminal)";
            Int32 count = 0;
            Int32 count1 = 0;
            Int32 spit = 0;
            try
            {
                con.Open();
                con1.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con1);
                cmd.Parameters.AddWithValue("?pos_orno", order_no);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd1.Parameters.AddWithValue("?pos_orno", order_no);
                cmd1.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd.ExecuteScalar();
                cmd1.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                MySqlDataReader rdr1 = cmd1.ExecuteReader();
                if (rdr.Read())
                {
                    count = Convert.ToInt32(rdr["a"]);
                }
                if (rdr1.Read())
                {
                    count1 = Convert.ToInt32(rdr1["a"]);
                    rdr.Close();
                }
                spit = count + count1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error :: ERROR " + ex);
            }
            finally
            {
                con.Close();
                con1.Close();
            }
            return spit;
        }
        public String[,] ReadRefund(Int32 order_no, String pos_terminal)
        {
            Int32 count = this.CountRefund(order_no, pos_terminal);
            String[,] xxx = new String[8, count];
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT pos_park.pos_ean AS a, pos_park.pos_quantity AS b, inventory_stocks.stock_name AS c, inventory_items.item_retail_price AS d, inventory_items.item_whole_price AS e, pos_park.pos_discount_amt AS f, pos_park.pos_amt AS g, inventory_items.item_tax_type AS h ";
            query += "FROM pos_park INNER JOIN inventory_items ON pos_park.pos_ean = inventory_items.item_ean INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (pos_park.pos_orno = ?pos_orno) AND (pos_park.pos_terminal = ?pos_terminal) ";
            query += "UNION ALL "; //Thanks to this Clause It Made My Life Easier ^_^
            query += "SELECT pos_park.pos_ean AS a, pos_park.pos_quantity AS b, inventory_items.kit_name AS c, inventory_items.item_retail_price AS d, inventory_items.item_whole_price AS e, pos_park.pos_discount_amt AS f, pos_park.pos_amt AS g, inventory_items.item_tax_type AS h ";
            query += "FROM pos_park INNER JOIN inventory_items ON pos_park.pos_ean = inventory_items.item_ean ";
            query += "WHERE (pos_park.pos_orno = ?pos_orno) AND (inventory_items.is_kit = 1) AND (pos_park.pos_terminal = ?pos_terminal)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?pos_orno", order_no);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                MySqlDataReader rdr = cmd.ExecuteReader();
                int counts = 0;
                while (rdr.Read())
                {
                    xxx[0, counts] = rdr["a"].ToString();
                    xxx[1, counts] = rdr["b"].ToString();
                    xxx[2, counts] = rdr["c"].ToString();
                    xxx[3, counts] = rdr["d"].ToString(); //retail
                    xxx[4, counts] = rdr["e"].ToString(); //wholesale
                    xxx[5, counts] = rdr["f"].ToString();
                    xxx[6, counts] = rdr["g"].ToString();
                    xxx[7, counts] = rdr["h"].ToString();
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
        public bool CheckWholeSale(Int32 order_no, String pos_terminal)
        {
            bool found = false;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT pos_iswholesale AS a FROM pos_store ";
            query += "WHERE (pos_orno = ?pos_orno) AND (pos_terminal = ?pos_terminal) AND (pos_iswholesale = 1)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?pos_orno", order_no);
                cmd.Parameters.AddWithValue("?pos_terminal", pos_terminal);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr["a"].ToString() == "1")
                    {
                        found = true;
                    }
                    else
                        found = false;
                }
            }
            finally
            {
                con.Close();
            }
            return found;
        }
        #endregion
        #region Cash Controller Module
        public Double CashDrawerBalance(String terminal)
        {
            Double amt = 0;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT cash_drawer_amt AS a FROM system_terminal ";
            query += "WHERE identify = ?terminal";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?terminal", terminal);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    amt = Convert.ToDouble(rdr["a"]);
                }
            }
            finally
            {
                con.Close();
            }
            return amt;
        }
        private void CreditDrawer(Double amount, String terminal)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE system_terminal SET cash_drawer_amt = cash_drawer_amt + ?amount ";
            query += "WHERE identify = ?terminal";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?amount", amount);
                cmd.Parameters.AddWithValue("?terminal", terminal);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        public void CreditDrawerLog(Double amount, String purpose, String terminal, String user_name)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "INSERT INTO pos_cdlog (cd_credit, cd_purpose, cd_balance, cd_date, cd_time, cd_terminal, user_name) VALUES";
            query += "(?a, ?b, ?c, ?d, ?e, ?f, ?g)";
            this.CreditDrawer(amount, terminal);
            Double bal = this.CashDrawerBalance(terminal);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", amount);
                cmd.Parameters.AddWithValue("?b", purpose);
                cmd.Parameters.AddWithValue("?c", bal);
                cmd.Parameters.AddWithValue("?d", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("?e", DateTime.Now.ToString("hh:mm:ss tt"));
                cmd.Parameters.AddWithValue("?f", terminal);
                cmd.Parameters.AddWithValue("?g", user_name);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        private void DebitDrawer(Double amount, String terminal)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE system_terminal SET cash_drawer_amt = cash_drawer_amt - ?amount ";
            query += "WHERE identify = ?terminal";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?amount", amount);
                cmd.Parameters.AddWithValue("?terminal", terminal);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void DebitDrawerLog(Double amount, String purpose, String terminal, String user_name)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "INSERT INTO pos_cdlog (cd_debit, cd_purpose, cd_balance, cd_date, cd_time, cd_terminal, user_name) VALUES";
            query += "(?a, ?b, ?c, ?d, ?e, ?f, ?g)";
            this.DebitDrawer(amount, terminal);
            Double bal = this.CashDrawerBalance(terminal);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", amount);
                cmd.Parameters.AddWithValue("?b", purpose);
                cmd.Parameters.AddWithValue("?c", bal);
                cmd.Parameters.AddWithValue("?d", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("?e", DateTime.Now.ToString("hh:mm:ss tt"));
                cmd.Parameters.AddWithValue("?f", terminal);
                cmd.Parameters.AddWithValue("?g", user_name);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void ResetDrawer(String terminal)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE system_terminal SET cash_drawer_amt = 0 ";
            query += "WHERE identify = ?terminal";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?terminal", terminal);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void IncDrawer(Double amount, String terminal)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE system_terminal SET cash_drawer_amt = cash_drawer_amt + ?amt ";
            query += "WHERE identify = ?terminal";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?amt", amount);
                cmd.Parameters.AddWithValue("?terminal", terminal);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void DecDrawer(Double amount, String terminal)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE system_terminal SET cash_drawer_amt = cash_drawer_amt - ?amt ";
            query += "WHERE identify = ?terminal";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?amt", amount);
                cmd.Parameters.AddWithValue("?terminal", terminal);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Cash Count Module
        public void LogCC(Double thousand, Double fiveh, Double twoh, Double oneh, Double fifty, Double twenty, Double ten, Double five, Double one, Double ctwentyfive, String terminal, String cashier)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "INSERT INTO pos_cashcount (thousand, fivehundred, twohundred, onehundred, fifty, twenty, ten, five, one, ctwentyfive, terminal, cashier) VALUES";
            query += "(?thousand, ?fiveh, ?twoh, ?oneh, ?fifty, ?twenty, ?ten, ?five, ?one, ?ctwentyfive, ?terminal, ?cashier)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?thousand", thousand);
                cmd.Parameters.AddWithValue("?fiveh", fiveh);
                cmd.Parameters.AddWithValue("?twoh", twoh);
                cmd.Parameters.AddWithValue("?oneh", oneh);
                cmd.Parameters.AddWithValue("?fifty", fifty);
                cmd.Parameters.AddWithValue("?twenty", twenty);
                cmd.Parameters.AddWithValue("?ten", ten);
                cmd.Parameters.AddWithValue("?five", five);
                cmd.Parameters.AddWithValue("?one", one);
                cmd.Parameters.AddWithValue("?ctwentyfive", ctwentyfive);
                cmd.Parameters.AddWithValue("?terminal", terminal);
                cmd.Parameters.AddWithValue("?cashier", cashier);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Security DAO
        public Boolean canPass(String user_name, String user_password)
        {
            Boolean passed = false;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT * FROM user_account ";
            query += "WHERE user_name = ?user_name AND user_password = ?user_password";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?user_name", user_name);
                cmd.Parameters.AddWithValue("?user_password", user_password);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    passed = true;
                }
            }
            finally
            {
                con.Close();
            }
            return passed;
        }
        #endregion
    }
}