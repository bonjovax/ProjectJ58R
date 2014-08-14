using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;

namespace nPOSProj.DAO
{
    class PurchaseOrderDAO
    {
        private MySqlConnection con;
        private Conf.dbs dbcon;
        private Int32 PONumber = 0;
        private String supplier_name;
        private String supplier_code;
        private String stock_name;
        private String stock_code;
        private Double stock_cost_price;
        private String stock_uom;
        private Double order_amount = 0;

        public PurchaseOrderDAO()
        {

        }

        public Int32 postPONumber()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT COUNT(*) AS gayminerva FROM po_order;";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    PONumber = Convert.ToInt32(rdr["gayminerva"]);
                    sendPONumber();
                }
                else
                {
                    PONumber = 0;
                    sendPONumber();
                }
            }
            finally
            {
                con.Close();
            }
            return PONumber;
        }
        private Int32 sendPONumber()
        {
            return PONumber;
        }

        public String katsSupplierName(String supplier_code)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT supplier_name AS gay FROM inventory_supplier ";
            query += "WHERE supplier_code = ?supplier_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?supplier_code", supplier_code);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    supplier_name = rdr["gay"].ToString();
                    sendSupplierName();
                }
            }
            finally
            {
                con.Close();
            }
            return supplier_name;
        }
        public String sendSupplierName()
        {
            return supplier_name;
        }
        //
        public String katsSupplierCode(String supplier_name)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT supplier_code AS glennisgay FROM inventory_supplier ";
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
                    supplier_code = rdr["glennisgay"].ToString();
                    sendSupplierCode();
                }
            }
            finally
            {
                con.Close();
            }
            return supplier_code;
        }
        public String sendSupplierCode()
        {
            return supplier_code;
        }
        public String katsStockName(String stock_code, String supplier_code)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT stock_name AS glennisgay FROM inventory_stocks ";
            query += "WHERE stock_code = ?stock_code AND supplier_code = ?supplier_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?stock_code", stock_code);
                cmd.Parameters.AddWithValue("?supplier_code", supplier_code);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    stock_name = rdr["glennisgay"].ToString();
                    sendStockName();
                }
            }
            finally
            {
                con.Close();
            }
            return stock_name;
        }
        public String sendStockName()
        {
            return stock_name;
        }
        public String katsStockCode(String stock_name, String supplier_code)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT stock_code AS glennisgay FROM inventory_stocks ";
            query += "WHERE stock_name = ?stock_name AND supplier_code = ?supplier_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?stock_name", stock_name);
                cmd.Parameters.AddWithValue("?supplier_code", supplier_code);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    stock_code = rdr["glennisgay"].ToString();
                    sendStockCode();
                }
            }
            finally
            {
                con.Close();
            }
            return stock_code;
        }
        public String sendStockCode()
        {
            return stock_code;
        }
        //
        public Double katsStockPrice(String stock_code, String supplier_code)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT stock_cost_price AS glennisgay FROM inventory_stocks ";
            query += "WHERE stock_code = ?stock_code AND supplier_code = ?supplier_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?stock_code", stock_code);
                cmd.Parameters.AddWithValue("?supplier_code", supplier_code);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    stock_cost_price = Convert.ToDouble(rdr["glennisgay"]);
                    sendStockName();
                }
            }
            finally
            {
                con.Close();
            }
            return stock_cost_price;
        }
        public Double sendStockPrice()
        {
            return stock_cost_price;
        }
        public Double katsStockPriceN(String stock_name, String supplier_code)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT stock_cost_price AS glennisgay FROM inventory_stocks ";
            query += "WHERE stock_code = ?stock_name AND supplier_code = ?supplier_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?stock_name", stock_name);
                cmd.Parameters.AddWithValue("?supplier_code", supplier_code);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    stock_cost_price = Convert.ToDouble(rdr["glennisgay"]);
                    sendStockName();
                }
            }
            finally
            {
                con.Close();
            }
            return stock_cost_price;
        }
        public Double sendStockPriceN()
        {
            return stock_cost_price;
        }
        //
        public String katsUOM(String stock_code, String supplier_code)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT stock_uom AS glennisgay FROM inventory_stocks ";
            query += "WHERE stock_code = ?stock_code AND supplier_code = ?supplier_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?stock_code", stock_code);
                cmd.Parameters.AddWithValue("?supplier_code", supplier_code);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    stock_uom = rdr["glennisgay"].ToString();
                    sendStockCode();
                }
            }
            finally
            {
                con.Close();
            }
            return stock_uom;
        }
        public String sendStockUOM()
        {
            return stock_uom;
        }
        public String katsUOM_N(String stock_name, String supplier_code)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT stock_uom AS glennisgay FROM inventory_stocks ";
            query += "WHERE stock_name = ?stock_name AND supplier_code = ?supplier_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?stock_name", stock_name);
                cmd.Parameters.AddWithValue("?supplier_code", supplier_code);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    stock_uom = rdr["glennisgay"].ToString();
                    sendStockCode();
                }
            }
            finally
            {
                con.Close();
            }
            return stock_uom;
        }
        public String sendStockUOM_N()
        {
            return stock_uom;
        }
        public void IssuePO(Int32 po_no, String po_date, String po_time, String supplier_code, String po_remarks, String user_name)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "INSERT INTO po_order (po_no, po_date, po_time, supplier_code, po_remarks, user_name) VALUES";
            query += "(?po_no, ?po_date, ?po_time, ?supplier_code, ?po_remarks, ?user_name)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?po_no", po_no);
                cmd.Parameters.AddWithValue("?po_date", po_date);
                cmd.Parameters.AddWithValue("?po_time", po_time);
                cmd.Parameters.AddWithValue("?po_remarks", po_remarks);
                cmd.Parameters.AddWithValue("?user_name", user_name);
                cmd.Parameters.AddWithValue("?supplier_code", supplier_code);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdatePO(Int32 po_no, String supplier_code, String po_warehouse, String po_carrier, String po_remarks, String user_name)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE po_order SET po_warehouse = ?po_warehouse, po_carrier = ?po_carrier, po_remarks = ?po_remarks, user_name = ?user_name ";
            query += "WHERE po_no = ?po_no AND supplier_code = ?supplier_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?po_warehouse", po_warehouse);
                cmd.Parameters.AddWithValue("?po_carrier", po_carrier);
                cmd.Parameters.AddWithValue("?po_remarks", po_remarks);
                cmd.Parameters.AddWithValue("?user_name", user_name);
                cmd.Parameters.AddWithValue("?po_no", po_no);
                cmd.Parameters.AddWithValue("?supplier_code", supplier_code);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void DeletePO(Int32 po_no, String supplier_code)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "DELETE FROM po_order WHERE po_no = ?po_no AND supplier_code = ?supplier_code";
            String query1 = "DELETE FROM po_order_list WHERE po_no = ?po_no";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                cmd.Parameters.AddWithValue("?po_no", po_no);
                cmd.Parameters.AddWithValue("?supplier_code", supplier_code);
                cmd1.Parameters.AddWithValue("?po_no", po_no);
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
        public void OrderPO(Int32 po_no, Int32 order_quantity, String order_uom, String order_suppliers_itemno, String order_description, Double order_unitcost, Double order_amount)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "INSERT INTO po_order_list VALUES";
            query += "(?po_no, ?order_quantity, ?order_uom, ?order_suppliers_itemno, ?order_description, ?order_unitcost, ?order_amount)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?po_no", po_no);
                cmd.Parameters.AddWithValue("?order_quantity", order_quantity);
                cmd.Parameters.AddWithValue("?order_uom", order_uom);
                cmd.Parameters.AddWithValue("?order_suppliers_itemno", order_suppliers_itemno);
                cmd.Parameters.AddWithValue("?order_description", order_description);
                cmd.Parameters.AddWithValue("?order_unitcost", order_unitcost);
                cmd.Parameters.AddWithValue("?order_amount", order_amount);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        
        //Update Amount to Main Table
        public void UpdateAmountToMainTable(Int32 po_no, String supplier_code, Double po_total_amt)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE po_order SET po_total_amt = ?po_total_amt ";
            query += "WHERE po_no = ?po_no AND supplier_code = ?supplier_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?po_total_amt", po_total_amt);
                cmd.Parameters.AddWithValue("?po_no", po_no);
                cmd.Parameters.AddWithValue("?supplier_code", supplier_code);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public Double sendAmount()
        {
            return order_amount;
        }
        //
        public void UpdateOrderPO(Int32 po_no, Int32 order_quantity, String order_uom, String order_suppliers_itemno, String old_stock_code, String order_description, Double order_unitcost, Double order_amount)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE po_order_list SET ";
            query += "order_quantity = ?order_quantity, order_uom = ?order_uom, order_suppliers_itemno = ?order_suppliers_itemno, order_description = ?order_description, order_unitcost = ?order_unitcost, order_amount = ?order_amount ";
            query += "WHERE po_no = ?po_no AND order_suppliers_itemno = ?old_stock_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?po_no", po_no);
                cmd.Parameters.AddWithValue("?order_quantity", order_quantity);
                cmd.Parameters.AddWithValue("?order_uom", order_uom);
                cmd.Parameters.AddWithValue("?order_suppliers_itemno", order_suppliers_itemno);
                cmd.Parameters.AddWithValue("?order_description", order_description);
                cmd.Parameters.AddWithValue("?order_unitcost", order_unitcost);
                cmd.Parameters.AddWithValue("?order_amount", order_amount);
                cmd.Parameters.AddWithValue("?old_stock_code", old_stock_code);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        //
        public void DeleteOrderPO(Int32 po_no, String order_suppliers_itemno)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "DELETE FROM po_order_list ";
            query += "WHERE po_no = ?po_no AND order_suppliers_itemno = ?order_suppliers_itemno";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?po_no", po_no);
                cmd.Parameters.AddWithValue("?order_suppliers_itemno", order_suppliers_itemno);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void TriggerPrint(Int32 po_no, String po_date)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE po_order SET po_printed = 'Yes', po_status = 'Pending' ";
            query += "WHERE po_no = ?po_no AND po_date = ?po_date";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?po_no", po_no);
                cmd.Parameters.AddWithValue("?po_date", po_date);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void UndoPrint(Int32 po_no, String po_date)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE po_order SET po_printed = 'No', po_status = 'Unfinish' ";
            query += "WHERE po_no = ?po_no AND po_date = ?po_date";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?po_no", po_no);
                cmd.Parameters.AddWithValue("?po_date", po_date);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
    }
}