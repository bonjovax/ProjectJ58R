using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;

namespace nPOSProj.DAO
{
    class ItemsDAO
    {
        private MySqlConnection con;
        private Conf.dbs dbcon;
        private Int32 stockQTY;
        private Double stocktotalAmt;
        private Int32 qty;
        private Double price;
        private Double finale;
        private String kitName;
        private String itemEAN;
        public ItemsDAO() { }

        #region Item Core
        public void Update(Int32 qty, String ean, Double r_price, Double w_price, String item_tax_type, String stock_code, String eantmp)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE inventory_items SET item_quantity = ?item_quantity, item_ean = ?new_ean, item_retail_price = ?item_retail_price, ";
            query += "item_whole_price = ?item_whole_price, item_tax_type = ?item_tax_type ";
            query += "WHERE stock_code = ?stock_code AND item_ean = ?eantmp";
            String query1 = "UPDATE inventory_stocks SET stock_selling_price = ?stock_selling_price, stock_total_price = ?stock_total_price ";
            query1 += "WHERE stock_code = ?stock_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                cmd.Parameters.AddWithValue("?item_quantity", qty);
                cmd.Parameters.AddWithValue("?new_ean", ean);
                cmd.Parameters.AddWithValue("?item_retail_price", r_price);
                cmd.Parameters.AddWithValue("?item_whole_price", w_price);
                cmd.Parameters.AddWithValue("?item_tax_type", item_tax_type);
                cmd.Parameters.AddWithValue("?stock_code", stock_code);
                cmd.Parameters.AddWithValue("?eantmp", eantmp);
                //
                ComputeTotalAmtStocks(r_price, stock_code);
                cmd1.Parameters.AddWithValue("?stock_selling_price", r_price);
                cmd1.Parameters.AddWithValue("?stock_total_price", stocktotalAmt);
                cmd1.Parameters.AddWithValue("?stock_code", stock_code);
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
        private void ComputeTotalAmtStocks(Double retail_price, String stock_code)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT stock_quantity AS gay FROM inventory_stocks ";
            query += "WHERE stock_code = ?stock_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?stock_code", stock_code);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    stockQTY = Convert.ToInt32(rdr["gay"]);
                }
                stocktotalAmt = retail_price * stockQTY;
            }
            finally
            {
                con.Close();
            }
        }
        private void ComputeTotalAmtQty(String stock_code)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT stock_quantity AS a, stock_selling_price AS b FROM inventory_stocks ";
            query += "WHERE stock_code = ?stock_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?stock_code", stock_code);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    qty = Convert.ToInt32(rdr["a"]);
                    price = Convert.ToDouble(rdr["b"]);
                }
                finale = qty * price;
            }
            finally
            {
                con.Close();
            }
        }
        public void ReturnToStocks(Int32 qty, String stock_code)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE inventory_items SET item_quantity = item_quantity - ?item_quantity ";
            query += "WHERE stock_code = ?stock_code";
            String query1 = "UPDATE inventory_stocks SET stock_quantity = stock_quantity + ?stock_quantity ";
            query1 += "WHERE stock_code = ?stock_code1";
            String query2 = "UPDATE inventory_stocks SET stock_total_price = ?stock_total_price ";
            query2 += "WHERE stock_code = ?stock_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                MySqlCommand cmd2 = new MySqlCommand(query2, con);
                cmd.Parameters.AddWithValue("?item_quantity", qty);
                cmd1.Parameters.AddWithValue("?stock_quantity", qty);
                cmd.Parameters.AddWithValue("?stock_code", stock_code);
                cmd1.Parameters.AddWithValue("?stock_code1", stock_code);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd.Dispose();
                cmd1.Dispose();
                this.ComputeTotalAmtQty(stock_code);
                cmd2.Parameters.AddWithValue("?stock_total_price", finale);
                cmd2.Parameters.AddWithValue("?stock_code", stock_code);
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void SendToItem(Int32 qty, String stock_code)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE inventory_items SET item_quantity = item_quantity + ?item_quantity ";
            query += "WHERE stock_code = ?stock_code";
            String query1 = "UPDATE inventory_stocks SET stock_quantity = stock_quantity - ?stock_quantity ";
            query1 += "WHERE stock_code = ?stock_code1";
            String query2 = "UPDATE inventory_stocks SET stock_total_price = ?stock_total_price ";
            query2 += "WHERE stock_code = ?stock_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                MySqlCommand cmd2 = new MySqlCommand(query2, con);
                cmd.Parameters.AddWithValue("?item_quantity", qty);
                cmd1.Parameters.AddWithValue("?stock_quantity", qty);
                cmd.Parameters.AddWithValue("?stock_code", stock_code);
                cmd1.Parameters.AddWithValue("?stock_code1", stock_code);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd.Dispose();
                cmd1.Dispose();
                this.ComputeTotalAmtQty(stock_code);
                cmd2.Parameters.AddWithValue("?stock_total_price", finale);
                cmd2.Parameters.AddWithValue("?stock_code", stock_code);
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();                
            }
            finally
            {
                con.Close();
            }
        }
        public String pushKitName(String item_ean)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT kit_name AS a FROM inventory_items ";
            query += "WHERE item_ean = ?item_ean";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?item_ean", item_ean);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    kitName = rdr["a"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return kitName;
        }
        public String pushEan(String kit_name)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT item_ean AS ean FROM inventory_items ";
            query += "WHERE kit_name = ?kit_name";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?kit_name", kit_name);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    itemEAN = rdr["ean"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return itemEAN;
        }
        public void patchEAN(String stockcode, String eancode)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE inventory_items SET item_ean = ?eancode ";
            query += "WHERE stock_code = ?stockcode";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?eancode", eancode);
                cmd.Parameters.AddWithValue("?stockcode", stockcode);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally 
            {
                con.Close();
            }
        }
        #endregion
        #region Item Kits
        public void InsertKit(Int32 kit_qty, String item_ean, String stock_code)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "INSERT INTO inventory_items_kit (kit_qty, item_ean, stock_code) VALUES";
            query += "(?qty, ?ean, ?stock_code)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?qty", kit_qty);
                cmd.Parameters.AddWithValue("?ean", item_ean);
                cmd.Parameters.AddWithValue("?stock_code", stock_code);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateKit(Int32 kit_qty, String item_ean, String stock_code)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE inventory_items_kit SET kit_qty = ?qty ";
            query += "WHERE item_ean = ?ean AND stock_code = ?stock_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?qty", kit_qty);
                cmd.Parameters.AddWithValue("?ean", item_ean);
                cmd.Parameters.AddWithValue("?stock_code", stock_code);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteKit(String item_ean, String stock_code)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "DELETE FROM inventory_items_kit ";
            query += "WHERE item_ean = ?ean AND stock_code = ?stock_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?ean", item_ean);
                cmd.Parameters.AddWithValue("?stock_code", stock_code);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Item Extended
        public Int32 askQuantity(String ean)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT item_quantity AS a FROM inventory_items ";
            query += "WHERE item_ean = ?item_ean";
            try
            {
                qty = 0;
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?item_ean", ean);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    qty = Convert.ToInt32(rdr["a"]);
                }
            }
            finally
            {
                con.Close();
            }
            return qty;
        }
        public void OrderI(String item_ean, Int32 item_quantity)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE inventory_items SET item_quantity = item_quantity - ?item_quantity ";
            query += "WHERE (item_ean = ?item_ean)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?item_quantity", item_quantity);
                cmd.Parameters.AddWithValue("?item_ean", item_ean);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Data Grabbing
        public Int32 KitCount()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT COUNT(*) AS a FROM inventory_items WHERE (is_kit = 1)";
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
        public Int32 ItemCount()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT COUNT(*) AS a FROM inventory_items INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            sql += "WHERE (inventory_items.is_kit = 0)";
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
        //
        public String[,] ReadKits()
        {
            Int32 count = this.KitCount();
            String[,] xxx = new String[4, count];
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT item_ean, kit_name, item_whole_price, item_retail_price ";
            query += "FROM inventory_items ";
            query += "WHERE (is_kit = 1)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                int counts = 0;
                while (rdr.Read())
                {
                    xxx[0, counts] = rdr["item_ean"].ToString();
                    xxx[1, counts] = rdr["kit_name"].ToString();
                    xxx[2, counts] = rdr["item_whole_price"].ToString();
                    xxx[3, counts] = rdr["item_retail_price"].ToString();
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
        public String[,] ReadItems()
        {
            Int32 count = this.ItemCount();
            String[,] yyy = new String[4, count];
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT inventory_items.item_ean AS a, inventory_stocks.stock_name AS b, inventory_items.item_whole_price AS c, inventory_items.item_retail_price AS d ";
            query += "FROM inventory_items INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (inventory_items.is_kit = 0)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                int counts = 0;
                while (rdr.Read())
                {
                    yyy[0, counts] = rdr["a"].ToString();
                    yyy[1, counts] = rdr["b"].ToString();
                    yyy[2, counts] = rdr["c"].ToString();
                    yyy[3, counts] = rdr["d"].ToString();
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
            return yyy;
        }
        public String[,] ReadItemsSearch(String stock_name)
        {
            Int32 count = this.ItemCount();
            String[,] yyy = new String[4, count];
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT inventory_items.item_ean AS a, inventory_stocks.stock_name AS b, inventory_items.item_whole_price AS c, inventory_items.item_retail_price AS d ";
            query += "FROM inventory_items INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (inventory_stocks.stock_name LIKE ?stock_name) AND (inventory_items.is_kit = 0)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?stock_name", stock_name + "%");
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                int counts = 0;
                while (rdr.Read())
                {
                    yyy[0, counts] = rdr["a"].ToString();
                    yyy[1, counts] = rdr["b"].ToString();
                    yyy[2, counts] = rdr["c"].ToString();
                    yyy[3, counts] = rdr["d"].ToString();
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
            return yyy;
        }
        public String[,] ReadKitsSearch(String kit_name)
        {
            Int32 count = this.KitCount();
            String[,] xxx = new String[4, count];
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT item_ean, kit_name, item_whole_price, item_retail_price ";
            query += "FROM inventory_items ";
            query += "WHERE (kit_name LIKE ?kit_name) AND (is_kit = 1)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?kit_name", kit_name + "%");
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                int counts = 0;
                while (rdr.Read())
                {
                    xxx[0, counts] = rdr["item_ean"].ToString();
                    xxx[1, counts] = rdr["kit_name"].ToString();
                    xxx[2, counts] = rdr["item_whole_price"].ToString();
                    xxx[3, counts] = rdr["item_retail_price"].ToString();
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
        #endregion
    }
}