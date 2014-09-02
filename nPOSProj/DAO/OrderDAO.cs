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
    }
}