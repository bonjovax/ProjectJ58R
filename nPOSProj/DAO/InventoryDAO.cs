using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace nPOSProj.DAO
{
    class InventoryDAO
    {
        private MySqlConnection con;
        private Conf.dbs dbcon;
        private String SupplierCode;
        private String CategoryCode;
        private String WarehouseCode;

        public InventoryDAO()
        {

        }

        public String grabSupplierCode(String supplier_name)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT supplier_code FROM inventory_supplier ";
            query += "WHERE supplier_name = ?supplier_name";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?supplier_name", supplier_name);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    SupplierCode = rdr["supplier_code"].ToString();
                    sendSupplierCode();
                }
                else
                {
                    SupplierCode = "";
                    sendSupplierCode();
                }
            }
            finally
            {
                con.Close();
            }
            return SupplierCode;
        }
        public String sendSupplierCode()
        {
            return SupplierCode;
        }
        //Cat
        public String grabCategoryCode(String cat_description)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT cat_code FROM inventory_category ";
            query += "WHERE cat_description = ?cat_description";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?cat_description", cat_description);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    CategoryCode = rdr["cat_code"].ToString();
                    sendCategoryCode();
                }
                else
                {
                    CategoryCode = "";
                    sendCategoryCode();
                }
            }
            finally
            {
                con.Close();
            }
            return SupplierCode;
        }
        public String sendCategoryCode()
        {
            return CategoryCode;
        }
        //Warehouse Code
        public String grabWarehouseCode(String warehouse_name)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT warehouse_code FROM inventory_warehouse ";
            query += "WHERE warehouse_name = ?warehouse_name";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?warehouse_name", warehouse_name);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    WarehouseCode = rdr["warehouse_code"].ToString();
                    sendWarehouseCode();
                }
                else
                {
                    WarehouseCode = "";
                    sendWarehouseCode();
                }
            }
            finally
            {
                con.Close();
            }
            return SupplierCode;
        }
        public String sendWarehouseCode()
        {
            return WarehouseCode;
        }
    }
}