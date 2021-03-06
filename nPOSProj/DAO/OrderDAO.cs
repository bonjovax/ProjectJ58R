﻿using System;
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
            String query = "SELECT COUNT(*) AS x FROM order_store";
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
        public Int32 getQty(String ean)
        {
            Int32 qty = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT item_quantity AS qty FROM inventory_items ";
            query += "WHERE item_ean = ?ean";
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
            String query = "INSERT INTO pos_park (pos_orderno, pos_ean, pos_quantity, order_item_amount, pos_item_amount, pos_amt, pos_parked_date) VALUES";
            query += "(?a, ?b, ?c, ?d, ?dd, ?e, ?f)";
            String query1 = "UPDATE inventory_items SET item_quantity = item_quantity - ?a ";
            query1 += "WHERE item_ean = ?item_ean";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                cmd.Parameters.AddWithValue("?a", pos_orderno);
                cmd.Parameters.AddWithValue("?b", pos_ean);
                cmd.Parameters.AddWithValue("?c", pos_quantity);
                cmd.Parameters.AddWithValue("?d", order_item_amount);
                cmd.Parameters.AddWithValue("?dd", order_item_amount);
                cmd.Parameters.AddWithValue("?e", pos_amt);
                cmd.Parameters.AddWithValue("?f", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd1.Parameters.AddWithValue("?a", pos_quantity);
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
        public void ParkItem_Update(Int32 pos_orderno, String pos_ean, Int32 pos_quantity, Double order_item_amount, Double pos_amt)
        {
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "UPDATE pos_park SET pos_quantity = pos_quantity + ?a, order_item_amount = ?b, pos_item_amount = ?bb, pos_amt = pos_amt + ?c, pos_parked_date = ?d ";
            query += "WHERE pos_orderno = ?pos_orderno AND pos_ean = ?pos_ean";
            String query1 = "UPDATE inventory_items SET item_quantity = item_quantity - ?a ";
            query1 += "WHERE item_ean = ?item_ean";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                cmd.Parameters.AddWithValue("?a", pos_quantity);
                cmd.Parameters.AddWithValue("?b", order_item_amount);
                cmd.Parameters.AddWithValue("?bb", order_item_amount);
                cmd.Parameters.AddWithValue("?c", pos_amt);
                cmd.Parameters.AddWithValue("?d", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("?pos_orderno", pos_orderno);
                cmd.Parameters.AddWithValue("?pos_ean", pos_ean);
                cmd1.Parameters.AddWithValue("?a", pos_quantity);
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
        public void ReturnAndDeleteItems(Int32 order_no, String item_ean, Int32 qty)
        {
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "UPDATE inventory_items SET item_quantity = item_quantity + ?a ";
            query += "WHERE item_ean = ?item_ean";
            String query1 = "DELETE FROM pos_park ";
            query1 += "WHERE pos_orderno = ?order_no AND pos_ean = ?pos_ean";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                cmd.Parameters.AddWithValue("?a", qty);
                cmd.Parameters.AddWithValue("?item_ean", item_ean);
                cmd1.Parameters.AddWithValue("?order_no", order_no);
                cmd1.Parameters.AddWithValue("?pos_ean", item_ean);
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
        public void Cancel(Int32 order_no)
        {
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "UPDATE order_store SET order_total_amt = 0, order_park = 0, is_cancel = 1 ";
            query += "WHERE order_no = ?order_no";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
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
        #region Ordering Retrieval DAO
        public Int32 OrderParkCount()
        {
            Int32 cunt = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT COUNT(*) AS x FROM order_store ";
            query += "WHERE order_park = 1 AND is_cancel = 0";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    cunt = Convert.ToInt32(rdr["x"].ToString());
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
            return cunt;
        }
        public Int32 OrderParkCountSearch(Int32 od)
        {
            Int32 cunt = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT COUNT(*) AS x FROM order_store ";
            query += "WHERE order_no = ?od AND order_park = 1 AND is_cancel = 0";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?od", od);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    cunt = Convert.ToInt32(rdr["x"].ToString());
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
            return cunt;
        }
        public String[,] ReadOrderPark()
        {
            Int32 cunt = this.OrderParkCount();
            String[,] bilat = new String[5, cunt];
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT order_no AS a, order_date AS b, order_time AS c, order_total_amt AS d, order_user AS e FROM order_store ";
            query += "WHERE order_park = 1 AND is_cancel = 0 ORDER BY order_no ASC";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                Int32 cunts = 0;
                while (rdr.Read())
                {
                    bilat[0, cunts] = rdr["a"].ToString();
                    bilat[1, cunts] = rdr["b"].ToString();
                    bilat[2, cunts] = rdr["c"].ToString();
                    bilat[3, cunts] = rdr["d"].ToString();
                    bilat[4, cunts] = rdr["e"].ToString();
                    cunts++;
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
            return bilat;
        }
        public String[,] ReadOrderParkSearch(Int32 od)
        {
            Int32 cunt = this.OrderParkCount();
            String[,] bilat = new String[5, cunt];
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT order_no AS a, order_date AS b, order_time AS c, order_total_amt AS d, order_user AS e FROM order_store ";
            query += "WHERE order_no = ?od AND order_park = 1 AND is_cancel = 0 ORDER BY order_no ASC";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?od", od);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                Int32 cunts = 0;
                while (rdr.Read())
                {
                    bilat[0, cunts] = rdr["a"].ToString();
                    bilat[1, cunts] = rdr["b"].ToString();
                    bilat[2, cunts] = rdr["c"].ToString();
                    bilat[3, cunts] = rdr["d"].ToString();
                    bilat[4, cunts] = rdr["e"].ToString();
                    cunts++;
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
            return bilat;
        }
        #endregion
        #region Ordering Park Retrieval DAO
        public Int32 ParkCount(Int32 order_no)
        {
            Int32 cunt = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT COUNT(*) AS x FROM (SELECT pos_park.trn AS xxx, pos_park.pos_ean AS a, pos_park.pos_quantity AS b, inventory_stocks.stock_name AS c, pos_park.order_item_amount AS d, pos_park.pos_amt AS e FROM pos_park ";
            query += "INNER JOIN inventory_items ON pos_park.pos_ean = inventory_items.item_ean ";
            query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (pos_park.pos_orderno = ?order_no) AND (inventory_items.is_kit = 0) ";
            query += "UNION ALL ";
            query += "SELECT pos_park.trn AS xxx, pos_park.pos_ean AS a, pos_park.pos_quantity AS b, inventory_items.kit_name AS c, pos_park.order_item_amount AS d, pos_park.pos_amt AS e FROM inventory_items ";
            query += "INNER JOIN pos_park ON inventory_items.item_ean = pos_park.pos_ean ";
            query += "WHERE (pos_park.pos_orderno = ?order_no) AND (inventory_items.is_kit = 1)) pos_park ORDER BY xxx";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?order_no", order_no);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    cunt = Convert.ToInt32(rdr["x"].ToString());
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
            return cunt;
        }
        public String[,] ReadPark(Int32 order_no)
        {
            Int32 cunt = this.ParkCount(order_no);
            String[,] bilat = new String[5, cunt];
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT a, b, c, d, e FROM (SELECT pos_park.trn AS xxx, pos_park.pos_ean AS a, pos_park.pos_quantity AS b, inventory_stocks.stock_name AS c, pos_park.order_item_amount AS d, pos_park.pos_amt AS e FROM pos_park ";
            query += "INNER JOIN inventory_items ON pos_park.pos_ean = inventory_items.item_ean ";
            query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (pos_park.pos_orderno = ?order_no) AND (inventory_items.is_kit = 0) ";
            query += "UNION ALL ";
            query += "SELECT pos_park.trn AS xxx, pos_park.pos_ean AS a, pos_park.pos_quantity AS b, inventory_items.kit_name AS c, pos_park.order_item_amount AS d, pos_park.pos_amt AS e FROM inventory_items ";
            query += "INNER JOIN pos_park ON inventory_items.item_ean = pos_park.pos_ean ";
            query += "WHERE (pos_park.pos_orderno = ?order_no) AND (inventory_items.is_kit = 1)) pos_park ORDER BY xxx";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?order_no", order_no);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                Int32 cunts = 0;
                while (rdr.Read())
                {
                    bilat[0, cunts] = rdr["a"].ToString();
                    bilat[1, cunts] = rdr["b"].ToString();
                    bilat[2, cunts] = rdr["c"].ToString();
                    bilat[3, cunts] = rdr["d"].ToString();
                    bilat[4, cunts] = rdr["e"].ToString();
                    cunts++;
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
            return bilat;
        }
        #endregion
        #region Quotation Core
        public Int32 QuoteParkCount()
        {
            Int32 cunt = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT COUNT(*) AS y FROM quotation_store ";
            query += "WHERE quote_park = 1 AND is_cancel = 0";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    cunt = Convert.ToInt32(rdr["y"].ToString());
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
            return cunt;
        }
        //
        public Int32 QuoteParkCountSearch(Int32 quote_no)
        {
            Int32 cunt = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT COUNT(*) AS y FROM quotation_store ";
            query += "WHERE quote_no LIKE ?quote_no AND quote_park = 1 AND is_cancel = 0";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?quote_no", quote_no + "%");
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    cunt = Convert.ToInt32(rdr["y"].ToString());
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
            return cunt;
        }
        public Int32 QuoteCompanyCount()
        {
            Int32 cunt = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT COUNT(*) AS z FROM crm_customer";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    cunt = Convert.ToInt32(rdr["z"].ToString());
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
            return cunt;
        }
        public String[,] ReadCompanyNameQuote()
        {
            Int32 cunt = this.QuoteCompanyCount();
            String[,] bilat = new String[1, cunt];
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT crm_companyname AS a FROM crm_customer";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                Int32 cunts = 0;
                while (rdr.Read())
                {
                    bilat[0, cunts] = rdr["a"].ToString();
                    cunts++;
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
            return bilat;
        }
        public String getCustomerCode(String company)
        {
            String custocode;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT crm_custcode AS a FROM crm_customer ";
            query += "WHERE crm_companyname = ?crm_companyname";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?crm_companyname", company);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    custocode = rdr["a"].ToString();
                }
                else
                    custocode = "WALKIN";
            }
            finally
            {
                con.Close();
            }
            return custocode;
        }
        public String getAddress(String company)
        {
            String address;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT crm_address AS a, crm_city AS b, crm_state_province AS c, crm_zip_code AS d FROM crm_customer ";
            query += "WHERE crm_companyname = ?crm_companyname";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?crm_companyname", company);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    address = rdr["a"].ToString() + ", " + rdr["b"].ToString() + ", " + rdr["c"].ToString() + " " + rdr["d"].ToString();
                }
                else
                    address = "";
            }
            finally
            {
                con.Close();
            }
            return address;
        }
        #endregion
        #region Quotation Data
        public Int32 askQuoteNo()
        {
            Int32 quoteNo = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT COUNT(*) AS x FROM quotation_store";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    quoteNo = Convert.ToInt32(rdr["x"].ToString());
                }
            }
            finally
            {
                con.Close();
            }
            return quoteNo;
        }
        public void newQuote(String quote_custcode, String quote_customer, String quote_address)
        {
            String user = frmLogin.User.user_name;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "INSERT INTO quotation_store (quote_no, quote_date, quote_time, quote_user, quote_custcode, quote_customer, quote_address) VALUES";
            query += "(?quote_no, ?quote_date, ?quote_time, ?quote_user, ?quote_custcode, ?quote_customer, ?quote_address)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?quote_no", this.askQuoteNo() + 1);
                cmd.Parameters.AddWithValue("?quote_date", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("?quote_time", DateTime.Now.ToString("HH:mm:ss"));
                cmd.Parameters.AddWithValue("?quote_user", user);
                cmd.Parameters.AddWithValue("?quote_custcode", quote_custcode);
                cmd.Parameters.AddWithValue("?quote_customer", quote_customer);
                cmd.Parameters.AddWithValue("?quote_address", quote_address);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void addItemQuote(Int32 quote_no, String quote_ean, Int32 quote_qty, Double quote_item_price, Double quote_total)
        {
            String user = frmLogin.User.user_name;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "INSERT INTO quotation_park (quote_no, quote_park_date, quote_park_time, quote_ean, quote_qty, quote_item_price, quote_total, quote_by) VALUES";
            query += "(?a, ?b, ?c, ?d, ?e, ?f, ?g, ?h)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", quote_no);
                cmd.Parameters.AddWithValue("?b", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("?c", DateTime.Now.ToString("HH:mm:ss"));
                cmd.Parameters.AddWithValue("?d", quote_ean);
                cmd.Parameters.AddWithValue("?e", quote_qty);
                cmd.Parameters.AddWithValue("?f", quote_item_price);
                cmd.Parameters.AddWithValue("?g", quote_total);
                cmd.Parameters.AddWithValue("?h", user);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void updateItemQuote(Int32 quote_no, String quote_ean, Int32 quote_qty, Double quote_item_price, Double quote_total)
        {
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String user = frmLogin.User.user_name;
            String query = "UPDATE quotation_park SET quote_qty = quote_qty + ?a, quote_item_price = ?b, quote_total = quote_total + ?c, quote_by = ?d ";
            query += "WHERE quote_no = ?quote_no AND quote_ean = ?quote_ean";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", quote_qty);
                cmd.Parameters.AddWithValue("?b", quote_item_price);
                cmd.Parameters.AddWithValue("?c", quote_total);
                cmd.Parameters.AddWithValue("?d", user);
                cmd.Parameters.AddWithValue("?quote_no", quote_no);
                cmd.Parameters.AddWithValue("?quote_ean", quote_ean);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void voidItemQuote(Int32 quote_no, String quote_ean)
        {
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "DELETE FROM quotation_park ";
            query += "WHERE quote_ean = ?a AND quote_no = ?b";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", quote_ean);
                cmd.Parameters.AddWithValue("?b", quote_no);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void TotalAmtUpdateQuote(Double quote_total_amt, Int32 quote_no)
        {
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "UPDATE quotation_store SET quote_total_amt = ?a ";
            query += "WHERE quote_no = ?quote_no";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", quote_total_amt);
                cmd.Parameters.AddWithValue("?quote_no", quote_no);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void cancelQuote(Int32 quote_no)
        {
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "DELETE FROM quotation_park ";
            query += "WHERE quote_no = ?quote_no";
            String query1 = "UPDATE quotation_store SET quote_total_amt = 0, quote_park = 0, is_cancel = 1 ";
            query1 += "WHERE quote_no = ?quote_no";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                cmd.Parameters.AddWithValue("?quote_no", quote_no);
                cmd1.Parameters.AddWithValue("?quote_no", quote_no);
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
        //
        public String[,] ReadQuotePark()
        {
            Int32 cunt = this.QuoteParkCount();
            String[,] bilat = new String[5, cunt];
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT quote_no AS a, quote_date AS b, quote_time AS c, quote_total_amt AS d, quote_user AS e FROM quotation_store ";
            query += "WHERE quote_park = 1 AND is_cancel = 0 ORDER BY quote_no ASC";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                Int32 cunts = 0;
                while (rdr.Read())
                {
                    bilat[0, cunts] = rdr["a"].ToString();
                    bilat[1, cunts] = rdr["b"].ToString();
                    bilat[2, cunts] = rdr["c"].ToString();
                    bilat[3, cunts] = rdr["d"].ToString();
                    bilat[4, cunts] = rdr["e"].ToString();
                    cunts++;
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
            return bilat;
        }
        //
        public String[,] ReadQuoteParkSearch(Int32 quote_no)
        {
            Int32 cunt = this.QuoteParkCountSearch(quote_no);
            String[,] bilat = new String[5, cunt];
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT quote_no AS a, quote_date AS b, quote_time AS c, quote_total_amt AS d, quote_user AS e FROM quotation_store ";
            query += "WHERE quote_no LIKE ?quote_no AND quote_park = 1 AND is_cancel = 0 ORDER BY quote_no ASC";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?quote_no", quote_no + "%");
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                Int32 cunts = 0;
                while (rdr.Read())
                {
                    bilat[0, cunts] = rdr["a"].ToString();
                    bilat[1, cunts] = rdr["b"].ToString();
                    bilat[2, cunts] = rdr["c"].ToString();
                    bilat[3, cunts] = rdr["d"].ToString();
                    bilat[4, cunts] = rdr["e"].ToString();
                    cunts++;
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
            return bilat;
        }
        //
        public Int32 QuoteLoadItemCount(Int32 quote_no)
        {
            Int32 cunt = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT COUNT(*) AS zozo FROM (SELECT quotation_park.quote_park_trn AS abc, quotation_park.quote_ean AS a, quotation_park.quote_qty AS b, inventory_stocks.stock_name AS c, quotation_park.quote_item_price AS d, quotation_park.quote_total AS e ";
            query += "FROM inventory_items ";
            query += "INNER JOIN quotation_park ON inventory_items.item_ean = quotation_park.quote_ean ";
            query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (quotation_park.quote_no = ?quote_no) AND (inventory_items.is_kit = 0) AND (quotation_park.is_send = 0) ";
            query += "UNION ALL ";
            query += "SELECT quotation_park.quote_park_trn AS abc, quotation_park.quote_ean AS a, quotation_park.quote_qty AS b, inventory_items.kit_name AS c, quotation_park.quote_item_price AS d, quotation_park.quote_total AS e FROM quotation_park ";
            query += "INNER JOIN inventory_items ON quotation_park.quote_ean = inventory_items.item_ean ";
            query += "WHERE (quotation_park.quote_no = ?quote_no) AND (inventory_items.is_kit = 1) AND (quotation_park.is_send = 0)) quotation ";
            query += "ORDER BY abc";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?quote_no", quote_no);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    cunt = Convert.ToInt32(rdr["zozo"].ToString());
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
            return cunt;
        }
        public String[,] QuoteLoadItem(Int32 quote_no)
        {
            Int32 cunt = this.QuoteLoadItemCount(quote_no);
            String[,] bilat = new String[5, cunt];
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT a, b, c, d, e FROM (SELECT quotation_park.quote_park_trn AS abc, quotation_park.quote_ean AS a, quotation_park.quote_qty AS b, inventory_stocks.stock_name AS c, quotation_park.quote_item_price AS d, quotation_park.quote_total AS e ";
            query += "FROM inventory_items ";
            query += "INNER JOIN quotation_park ON inventory_items.item_ean = quotation_park.quote_ean ";
            query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (quotation_park.quote_no = ?quote_no) AND (inventory_items.is_kit = 0) AND (quotation_park.is_send = 0) ";
            query += "UNION ALL ";
            query += "SELECT quotation_park.quote_park_trn AS abc, quotation_park.quote_ean AS a, quotation_park.quote_qty AS b, inventory_items.kit_name AS c, quotation_park.quote_item_price AS d, quotation_park.quote_total AS e FROM quotation_park ";
            query += "INNER JOIN inventory_items ON quotation_park.quote_ean = inventory_items.item_ean ";
            query += "WHERE (quotation_park.quote_no = ?quote_no) AND (inventory_items.is_kit = 1) AND (quotation_park.is_send = 0)) quotation ";
            query += "ORDER BY abc";

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?quote_no", quote_no);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                Int32 cunts = 0;
                while (rdr.Read())
                {
                    bilat[0, cunts] = rdr["a"].ToString();
                    bilat[1, cunts] = rdr["b"].ToString();
                    bilat[2, cunts] = rdr["c"].ToString();
                    bilat[3, cunts] = rdr["d"].ToString();
                    bilat[4, cunts] = rdr["e"].ToString();
                    cunts++;
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
            return bilat;
        }
        #endregion
        #region Quotation History
        public Int32 countByDate(String date)
        {
            Int32 count = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT COUNT(*) AS a FROM quotation_store ";
            query += "WHERE quote_date = ?date AND is_cancel = 0";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?date", Convert.ToDateTime(date).ToString("yyyy-MM-dd"));
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    count = Convert.ToInt32(rdr["a"].ToString());
                }
            }
            catch (Exception x)
            {
                Console.WriteLine(x);
            }
            finally
            {
                con.Close();
            }
            return count;
        }
        public Int32 countByQuoteNo(Int32 quote_no)
        {
            Int32 count = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT COUNT(*) AS b FROM quotation_store ";
            query += "WHERE quote_no LIKE ?quote_no AND is_cancel = 0";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?quote_no", quote_no + "%");
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    count = Convert.ToInt32(rdr["b"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                con.Close();
            }
            return count;
        }
        //
        public String[,] ReadQuoteHistoryDate(String date)
        {
            Int32 cunt = this.countByDate(date);
            String[,] bilat = new String[7, cunt];
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT quote_no AS a, quote_date AS b, quote_time AS c, quote_customer AS d, quote_address AS e, quote_total_amt AS f, quote_user AS g FROM quotation_store ";
            query += "WHERE quote_date = ?date AND is_cancel = 0 ORDER BY quote_no ASC";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?date", date);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                Int32 cunts = 0;
                while (rdr.Read())
                {
                    bilat[0, cunts] = rdr["a"].ToString();
                    bilat[1, cunts] = rdr["b"].ToString();
                    bilat[2, cunts] = rdr["c"].ToString();
                    bilat[3, cunts] = rdr["d"].ToString();
                    bilat[4, cunts] = rdr["e"].ToString();
                    bilat[5, cunts] = rdr["f"].ToString();
                    bilat[6, cunts] = rdr["g"].ToString();
                    cunts++;
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
            return bilat;
        }
        public String[,] ReadQuoteHistoryQuote_no(Int32 quote_no)
        {
            Int32 cunt = this.countByQuoteNo(quote_no);
            String[,] bilat = new String[7, cunt];
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT quote_no AS a, quote_date AS b, quote_time AS c, quote_customer AS d, quote_address AS e, quote_total_amt AS f, quote_user AS g FROM quotation_store ";
            query += "WHERE quote_no LIKE ?quote_no AND is_cancel = 0 ORDER BY quote_no ASC";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?quote_no", quote_no + "%");
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                Int32 cunts = 0;
                while (rdr.Read())
                {
                    bilat[0, cunts] = rdr["a"].ToString();
                    bilat[1, cunts] = rdr["b"].ToString();
                    bilat[2, cunts] = rdr["c"].ToString();
                    bilat[3, cunts] = rdr["d"].ToString();
                    bilat[4, cunts] = rdr["e"].ToString();
                    bilat[5, cunts] = rdr["f"].ToString();
                    bilat[6, cunts] = rdr["g"].ToString();
                    cunts++;
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
            return bilat;
        }
        #endregion
        #region Send to Order Module
        public Double SumOrderTotal(Int32 pos_orderno)
        {
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT SUM(pos_amt) AS xxx FROM pos_park ";
            query += "WHERE pos_orderno = ?pos_orderno";
            Double Total = 0;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?pos_orderno", pos_orderno);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Total = Convert.ToDouble(rdr["xxx"]);
                }
            }
            finally
            {
                con.Close();
            }
            return Total;
        }
        public void sendQuoteOrder(Int32 order_no, Int32 quote_no, String ean, Int32 qty, Double order_item_amount, Double pos_amt)
        {
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "UPDATE inventory_items SET item_quantity = item_quantity - ?a ";
            query += "WHERE item_ean = ?item_ean";
            String query1 = "INSERT INTO pos_park (pos_orderno, pos_parked_date, pos_ean, pos_quantity, order_item_amount, pos_item_amount, pos_amt) VALUES";
            query1 += "(?a, ?b, ?c, ?d, ?e, ?ee, ?f)";
            String query3 = "UPDATE quotation_park SET is_send = 1 ";
            query3 += "WHERE quote_no = ?quote_no AND quote_ean = ?quote_ean";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                MySqlCommand cmd3 = new MySqlCommand(query3, con);
                cmd.Parameters.AddWithValue("?a", qty);
                cmd.Parameters.AddWithValue("?item_ean", ean);
                cmd1.Parameters.AddWithValue("?a", order_no);
                cmd1.Parameters.AddWithValue("?b", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd1.Parameters.AddWithValue("?c", ean);
                cmd1.Parameters.AddWithValue("?d", qty);
                cmd1.Parameters.AddWithValue("?e", order_item_amount);
                cmd1.Parameters.AddWithValue("?ee", order_item_amount);
                cmd1.Parameters.AddWithValue("?f", pos_amt);
                cmd3.Parameters.AddWithValue("?quote_no", quote_no);
                cmd3.Parameters.AddWithValue("?quote_ean", ean);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd.Dispose();
                cmd1.Dispose();
                cmd3.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                con.Close();
            }
        }
        public void updateTotalAmt(Int32 order_no)
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
                cmd.Parameters.AddWithValue("?a", this.SumOrderTotal(order_no));
                cmd.Parameters.AddWithValue("?order_no", order_no);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void TriggerQuoteDone(Int32 quote_no)
        {
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "UPDATE quotation_store SET quote_park = 0 ";
            query += "WHERE quote_no = ?quote_no";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?quote_no", quote_no);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Linked Quote to Order
        public void newOrderLinked(Int32 quote_no)
        {
            String user = frmLogin.User.user_name;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "INSERT INTO order_store (order_no, order_date, order_time, order_user, quote_no) VALUES";
            query += "(?orderno, ?date, ?time, ?user, ?qn)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?orderno", this.askOrderNo() + 1);
                cmd.Parameters.AddWithValue("?date", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("?time", DateTime.Now.ToString("HH:mm:ss"));
                cmd.Parameters.AddWithValue("?user", user);
                cmd.Parameters.AddWithValue("?qn", quote_no);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public Int32 getOrderN(Int32 quote_no)
        {
            Int32 on = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT order_no AS a FROM order_store ";
            query += "WHERE quote_no = ?quote_no";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?quote_no", quote_no);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    on = Convert.ToInt32(rdr["a"]);
                }
            }
            finally
            {
                con.Close();
            }
            return on;
        }
        public void LinkedQuote(Int32 order_no, Int32 quote_no)
        {
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "UPDATE quotation_store SET order_no = ?a, is_linked = 1 ";
            query += "WHERE quote_no = ?quote_no";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", order_no);
                cmd.Parameters.AddWithValue("?quote_no", quote_no);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public Boolean checkIfLinked(Int32 quote_no)
        {
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT * FROM quotation_store ";
            query += "WHERE is_linked = 1 AND quote_no = ?qn";
            Boolean found = false;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?qn", quote_no);
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
        #region Order Park Retrieval and Linked to POS
        public void TransferOrderToPOS(Int32 pos_orno, Int32 pos_orderno)
        {
            frmLogin fl = new frmLogin();
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "UPDATE pos_park SET pos_orno = ?pos_orno, pos_terminal = ?pos_terminal ";
            query += "WHERE pos_orderno = ?pos_orderno";
            String query1 = "UPDATE order_store SET order_park = 0 ";
            query1 += "WHERE order_no = ?order_no";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                cmd.Parameters.AddWithValue("?pos_orno", pos_orno);
                cmd.Parameters.AddWithValue("?pos_terminal", fl.tN);
                cmd.Parameters.AddWithValue("?pos_orderno", pos_orderno);
                cmd1.Parameters.AddWithValue("?order_no", pos_orderno);
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
        public void TriggerOrderPOSDone(Double pos_vatable, Double pos_vex, Double pos_vatz, Double pos_tax_perc, Double pos_tax_amt, Double pos_total_amt, Int32 pos_orno, String pos_terminal)
        {
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "UPDATE pos_store SET pos_vatable = ?a, pos_vex = ?b, pos_vatz = ?c, pos_tax_perc = ?d, pos_tax_amt = ?e, pos_total_amt = ?f ";
            query += "WHERE pos_orno = ?pos_orno AND pos_terminal = ?pos_terminal";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", pos_vatable);
                cmd.Parameters.AddWithValue("?b", pos_vex);
                cmd.Parameters.AddWithValue("?c", pos_vatz);
                cmd.Parameters.AddWithValue("?d", pos_tax_perc);
                cmd.Parameters.AddWithValue("?e", pos_tax_amt);
                cmd.Parameters.AddWithValue("?f", pos_total_amt);
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
        #region Quotation Attrib DAO
        public String getCustomerCode(Int32 quote_no)
        {
            String cc = "";
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT quote_custcode AS a FROM quotation_store ";
            query += "WHERE quote_no = ?quote_no";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?quote_no", quote_no);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    cc = rdr["a"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return cc;
        }
        public String getCustomer(Int32 quote_no)
        {
            String c = "";
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT quote_customer AS b FROM quotation_store ";
            query += "WHERE quote_no = ?quote_no";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?quote_no", quote_no);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    c = rdr["b"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return c;
        }
        public String getAddress(Int32 quote_no)
        {
            String a = "";
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT quote_address AS c FROM quotation_store ";
            query += "WHERE quote_no = ?quote_no";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?quote_no", quote_no);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    a = rdr["c"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return a;
        }
        #endregion
    }
}