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
            String query = "UPDATE pos_park SET pos_quantity = pos_quantity + ?a, order_item_amount = ?b, pos_amt = pos_amt + ?c, pos_parked_date = ?d ";
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
            String query = "SELECT COUNT(*) AS x FROM pos_park ";
            query += "INNER JOIN inventory_items ON pos_park.pos_ean = inventory_items.item_ean ";
            query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (pos_park.pos_orderno = ?order_no) AND (inventory_items.is_kit = 0)";
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
        public Int32 ParkCountKit(Int32 order_no)
        {
            Int32 cunt = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT COUNT(*) AS x FROM inventory_items ";
            query += "INNER JOIN pos_park ON inventory_items.item_ean = pos_park.pos_ean ";
            query += "WHERE (pos_park.pos_orderno = ?order_no) AND (inventory_items.is_kit = 1)";
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
            String query = "SELECT pos_park.pos_ean AS a, pos_park.pos_quantity AS b, inventory_stocks.stock_name AS c, pos_park.order_item_amount AS d, pos_park.pos_amt AS e FROM pos_park ";
            query += "INNER JOIN inventory_items ON pos_park.pos_ean = inventory_items.item_ean ";
            query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (pos_park.pos_orderno = ?order_no) AND (inventory_items.is_kit = 0)";
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
        public String[,] ReadParkKit(Int32 order_no)
        {
            Int32 cunt = this.ParkCountKit(order_no);
            String[,] bilat = new String[5, cunt];
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT pos_park.pos_ean AS a, pos_park.pos_quantity AS b, inventory_items.kit_name AS c, pos_park.order_item_amount AS d, pos_park.pos_amt AS e FROM inventory_items ";
            query += "INNER JOIN pos_park ON inventory_items.item_ean = pos_park.pos_ean ";
            query += "WHERE (pos_park.pos_orderno = ?order_no) AND (inventory_items.is_kit = 1)";
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
            String query = "SELECT COUNT(*) AS zozo FROM inventory_items ";
            query += "INNER JOIN quotation_park ON inventory_items.item_ean = quotation_park.quote_ean ";
            query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (quotation_park.quote_no = ?quote_no) AND (inventory_items.is_kit = 0) ";
            query += "ORDER BY quotation_park.quote_park_trn";
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
        public Int32 QuoteLoadItemKitCount(Int32 quote_no)
        {
            Int32 cunt = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT COUNT(*) AS xoxo FROM quotation_park ";
            query += "INNER JOIN inventory_items ON quotation_park.quote_ean = inventory_items.item_ean ";
            query += "WHERE (quotation_park.quote_no = ?quote_no) AND (inventory_items.is_kit = 1) ";
            query += "ORDER BY quotation_park.quote_park_trn ASC";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?quote_no", quote_no);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    cunt = Convert.ToInt32(rdr["xoxo"].ToString());
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
        public String[,] QuoteLoadItem(Int32 quote_no)
        {
            Int32 cunt = this.QuoteLoadItemCount(quote_no);
            String[,] bilat = new String[5, cunt];
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT quotation_park.quote_ean AS a, quotation_park.quote_qty AS b, inventory_stocks.stock_name AS c, quotation_park.quote_item_price AS d, quotation_park.quote_total AS e FROM inventory_items ";
            query += "INNER JOIN quotation_park ON inventory_items.item_ean = quotation_park.quote_ean ";
            query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (quotation_park.quote_no = ?quote_no) AND (inventory_items.is_kit = 0) ";
            query += "ORDER BY quotation_park.quote_park_trn";

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
        public String[,] QuoteLoadItemKits(Int32 quote_no)
        {
            Int32 cunt = this.QuoteLoadItemKitCount(quote_no);
            String[,] bilat = new String[5, cunt];
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT quotation_park.quote_ean AS a, quotation_park.quote_qty AS b, inventory_items.kit_name AS c, quotation_park.quote_item_price AS d, quotation_park.quote_total AS e FROM quotation_park ";
            query += "INNER JOIN inventory_items ON quotation_park.quote_ean = inventory_items.item_ean ";
            query += "WHERE (quotation_park.quote_no = ?quote_no) AND (inventory_items.is_kit = 1) ";
            query += "ORDER BY quotation_park.quote_park_trn ASC";
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
    }
}