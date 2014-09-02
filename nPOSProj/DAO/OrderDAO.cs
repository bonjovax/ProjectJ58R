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
        public String getEan(String description)
        {
            String ean = "";
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT inventory_items.item_ean AS x FROM inventory_items ";
            query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (inventory_stocks.stock_name = ?stock_name)";
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
            query += "WHERE (inventory_items.item_ean = ?ean)";
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
        public String getEAN(String stock_name)
        {
            String ean = "";
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT inventory_items.item_ean AS ean FROM inventory_items ";
            query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (inventory_stocks.stock_name = ?stock_name)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?stock_ean", stock_name);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    ean = rdr["ean"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return ean;
        }
        public Double getPriceByName(String description, Boolean wholesale)
        {
            Double price = 0;
            con = new MySqlConnection();
            db = new Conf.dbs();
            con.ConnectionString = db.getConnectionString();
            String query = "SELECT inventory_items.item_retail_price AS x, inventory_items.item_whole_price AS y FROM inventory_items ";
            query += "INNER JOIN inventory_stocks ON inventory_items.stock_code = inventory_stocks.stock_code ";
            query += "WHERE (inventory_stocks.stock_name = ?stock_name)";
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
            query += "WHERE item_ean = ?item_ean";
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
    }
}