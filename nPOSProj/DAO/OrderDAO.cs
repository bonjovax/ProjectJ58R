using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;

namespace nPOSProj.DAO
{
    class OrderDAO
    {
        private MySqlConnection con;
        private Conf.dbs db;

        public OrderDAO()
        {
            
        }

        #region Ordering Information DAO
        public void newOrder()
        {
            String user = frmLogin.User.user_name;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "INSERT INTO order_store (order_no, order_date, order_time, order_user) VALUES";
            query += "(?orderno, ?date, ?time, ?user)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?orderno", this.askOrderNo() + 1);
                cmd.Parameters.AddWithValue("?date", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("?time", DateTime.Now.ToString("HH:mm:ss"));
                cmd.Parameters.AddWithValue("?user", user);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public Int32 askOrderNo()
        {
            Int32 orderNo = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT COUNT(order_trn) AS x FROM order_store ";
            query += "WHERE order_park = 1 AND is_cancel = 0";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    orderNo = Convert.ToInt32(rdr["x"].ToString());
                }
            }
            finally
            {
                con.Close();
            }
            return orderNo;
        }
        //
        public String getEan(String description)
        {
            String ean = "";
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT inventory_items.item_ean AS x FROM inventory_items ";
            query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (inventory_stocks.stock_name = ?stock_name) AND (inventory_items.is_kit = 0)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?stock_name", description);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    ean = rdr["x"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return ean;
        }
        public String getDescription(String Ean)
        {
            String description= "";
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT inventory_stocks.stock_name AS description FROM inventory_stocks ";
            query += "INNER JOIN inventory_items ON inventory_stocks.stock_code = inventory_items.stock_code ";
            query += "WHERE (inventory_items.item_ean = ?ean) AND (inventory_items.is_kit = 0)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?ean", Ean);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    description = rdr["description"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return description;
        }
        public Double getPriceByName(String description, Boolean wholesale)
        {
            Double price = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT inventory_items.item_retail_price AS x, inventory_items.item_whole_price AS y FROM inventory_items ";
            query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (inventory_stocks.stock_name = ?stock_name) AND (inventory_items.is_kit = 0)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?stock_name", description);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (wholesale == true)
                    {
                        price = Convert.ToDouble(rdr["y"]);
                    }
                    else
                        price = Convert.ToDouble(rdr["x"]);
                }
            }
            finally
            {
                con.Close();
            }
            return price;
        }
        public Double getPriceByEan(String ean, Boolean wholesale)
        {
            Double price = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT item_retail_price AS x, item_whole_price AS y FROM inventory_items ";
            query += "WHERE item_ean = ?item_ean AND is_kit = 0";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?item_ean", ean);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (wholesale == true)
                    {
                        price = Convert.ToDouble(rdr["y"]);
                    }
                    else
                        price = Convert.ToDouble(rdr["x"]);
                }
            }
            finally
            {
                con.Close();
            }
            return price;
        }
        //
        public String getEanKits(String kitname)
        {
            String kitnames = "";
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT item_ean AS x FROM inventory_items ";
            query += "WHERE kit_name = ?kit_name AND is_kit = 1";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?kit_name", kitname);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    kitnames = rdr["x"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return kitnames;
        }
        public String getKitname(String Ean)
        {
            String kitname = "";
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT kit_name AS x FROM inventory_items ";
            query += "WHERE item_ean = ?item_ean AND is_kit = 1";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?item_ean", Ean);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    kitname = rdr["x"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return kitname;
        }
        public Double getPriceByKitName(String kitname, Boolean wholesale)
        {
            Double Price = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT item_retail_price AS x, item_whole_price AS y FROM inventory_items ";
            query += "WHERE kit_name = ?kitname AND is_kit = 1";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?kitname", kitname);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (wholesale == true)
                    {
                        Price = Convert.ToDouble(rdr["y"]);
                    }
                    else
                        Price = Convert.ToDouble(rdr["x"]);
                }
                else
                    Price = 0;
            }
            finally
            {
                con.Close();
            }
            return Price;
        }
        public Double getPriceByEanKit(String ean, Boolean wholesale)
        {
            Double Price = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT item_retail_price AS x, item_whole_price AS y FROM inventory_items ";
            query += "WHERE item_ean = ?item_ean AND is_kit = 1";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?item_ean", ean);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (wholesale == true)
                    {
                        Price = Convert.ToDouble(rdr["y"]);
                    }
                    else
                        Price = Convert.ToDouble(rdr["x"]);
                }
                else
                    Price = 0;
            }
            finally
            {
                con.Close();
            }
            return Price;
        }
        //
        public Int32 getQtyByDescription(String description)
        {
            Int32 qty = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT inventory_items.item_quantity AS qty FROM inventory_items ";
            query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (inventory_stocks.stock_name = ?stock_name) AND (inventory_items.is_kit = 0)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?stock_name", description);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    qty = Convert.ToInt32(rdr["qty"]);
                }
                else
                    qty = 0;
            }
            finally
            {
                con.Close();
            }
            return qty;
        }
        public Int32 getQtyByEAN(String ean)
        {
            Int32 qty = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT item_quantity AS qty FROM inventory_items ";
            query += "WHERE item_ean = ?item_ean AND is_kit = 0";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?item_ean", ean);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    qty = Convert.ToInt32(rdr["qty"]);
                }
                else
                    qty = 0;
            }
            finally
            {
                con.Close();
            }
            return qty;
        }
        public Int32 getQtyByDescriptionKit(String description)
        {
            Int32 qty = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT item_quantity AS qty FROM inventory_items ";
            query += "WHERE kit_name = ?description AND is_kit = 1";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?description", description);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    qty = Convert.ToInt32(rdr["qty"]);
                }
            }
            finally
            {
                con.Close();
            }
            return qty;
        }
        public Int32 getQtyByEANKit(String ean)
        {
            Int32 qty = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT item_quantity AS qty FROM inventory_items ";
            query += "WHERE item_ean = ?ean AND is_kit = 1";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?ean", ean);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    qty = Convert.ToInt32(rdr["qty"]);
                }
            }
            finally
            {
                con.Close();
            }
            return qty;
        }
        //
        public Boolean checkingItemDescription(String description, String ean)
        {
            Boolean correct = false;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT * FROM inventory_items ";
            query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (inventory_stocks.stock_name = ?stock_name) AND (inventory_items.item_ean = ?item_ean) AND (inventory_items.is_kit = 0)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?stock_name", description);
                cmd.Parameters.AddWithValue("?item_ean", ean);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    correct = true;
                }
                else
                    correct = false;
            }
            finally
            {
                con.Close();
            }
            return correct;
        }
        public Boolean checkingItemEan(String ean, String description)
        {
            Boolean correct = false;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT * FROM inventory_items ";
            query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (inventory_items.item_ean = ?item_ean) AND (inventory_stocks.stock_name = ?stock_name) AND (inventory_items.is_kit = 0)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?item_ean", ean);
                cmd.Parameters.AddWithValue("?stock_name", description);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    correct = true;
                }
                else
                    correct = false;
            }
            finally
            {
                con.Close();
            }
            return correct;
        }
        public Boolean checkItemDescriptionKit(String description, String ean)
        {
            Boolean correct = false;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT * FROM inventory_items ";
            query += "WHERE kit_name = ?description AND item_ean = ?ean AND is_kit = 1";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?description", description);
                cmd.Parameters.AddWithValue("?ean", ean);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    correct = true;
                }
                else
                    correct = false;
            }
            finally
            {
                con.Close();
            }
            return correct;
        }
        public Boolean checkItemEanKit(String ean, String description)
        {
            Boolean correct = false;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT * FROM inventory_items ";
            query += "WHERE item_ean = ?ean AND kit_name = ?description AND is_kit = 1";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?ean", ean);
                cmd.Parameters.AddWithValue("?description", description);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    correct = true;
                }
                else
                    correct = false;
            }
            finally
            {
                con.Close();
            }
            return correct;
        }
        #endregion
        #region Ordering Core
        public void ParkItem_Add(Int32 pos_orderno, String pos_ean, Int32 pos_quantity, Double order_item_amount, Double pos_amt)
        {
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "INSERT INTO pos_park (pos_orderno, pos_ean, pos_quantity, order_item_amount, pos_amt, pos_parked_date) VALUES";
            query += "(?a, ?b, ?c, ?d, ?e, ?f)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", pos_orderno);
                cmd.Parameters.AddWithValue("?b", pos_ean);
                cmd.Parameters.AddWithValue("?c", pos_quantity);
                cmd.Parameters.AddWithValue("?d", order_item_amount);
                cmd.Parameters.AddWithValue("?e", pos_amt);
                cmd.Parameters.AddWithValue("?f", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void ParkItem_Update(Int32 pos_orderno, String pos_ean, Int32 pos_quantity, Double order_item_amount, Double pos_amt)
        {
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "UPDATE pos_park SET pos_quantity = pos_quantity + ?a, order_item_amount = ?b, pos_amt = pos_amt + ?c, pos_parked_date = ?d ";
            query += "WHERE pos_orderno = ?pos_orderno AND pos_ean = ?pos_ean";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", pos_quantity);
                cmd.Parameters.AddWithValue("?b", order_item_amount);
                cmd.Parameters.AddWithValue("?c", pos_amt);
                cmd.Parameters.AddWithValue("?d", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("?pos_orderno", pos_orderno);
                cmd.Parameters.AddWithValue("?pos_ean", pos_ean);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void ParkItem_Void(Int32 qty, Int32 pos_orderno, String pos_ean)
        {
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "UPDATE inventory_items SET item_quantity = item_quantity + ?a ";
            query += "WHERE item_ean = ?item_ean";
            String query1 = "DELETE FROM pos_park ";
            query1 += "WHERE pos_orderno = ?pos_orderno AND pos_ean = ?pos_ean";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", qty);
                cmd.Parameters.AddWithValue("?item_ean", pos_ean);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("?pos_orderno", pos_orderno);
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
        public void TotalAmtUpdate(Double order_total_amt, Int32 order_no)
        {
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "UPDATE order_store SET order_total_amt = ?a ";
            query += "WHERE order_no = ?order_no";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", order_total_amt);
                cmd.Parameters.AddWithValue("?order_no", order_no);
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