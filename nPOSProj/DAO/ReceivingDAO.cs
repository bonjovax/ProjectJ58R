using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;

namespace nPOSProj.DAO
{
    class ReceivingDAO
    {
        private MySqlConnection con;
        private Conf.dbs dbcon;
        private Double qty;
        private Double sellingprice;
        private Double final_computation;
        private Int32 qtyG;

        public ReceivingDAO()
        {

        }

        private Double computerFinal()
        {
            final_computation = qty * sellingprice;
            return final_computation;
        }

        private void updateTotalPrice(String stock_code)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE inventory_stocks SET stock_total_price = ?stock_total_price ";
            query += "WHERE stock_code = ?stock_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?stock_total_price", final_computation);
                cmd.Parameters.AddWithValue("?stock_code", stock_code);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        private void recalculateTotalPrice(String stock_code)
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
                    qty = Convert.ToDouble(rdr["a"]);
                    sellingprice = Convert.ToDouble(rdr["b"]);
                }
                computerFinal();
            }
            finally
            {
                con.Close();
            }
        }
        public Int32 aQuantity(String stock_code, Int32 po_no)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT order_quantity AS a FROM po_order_list ";
            query += "WHERE order_suppliers_itemno = ?order_suppliers_itemno AND po_no = ?po_no";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?order_suppliers_itemno", stock_code);
                cmd.Parameters.AddWithValue("?po_no", po_no);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    qtyG = Convert.ToInt32(rdr["a"]);
                }
            }
            finally
            {
                con.Close();
            }
            return qtyG;
        }

        public void Receive(Int32 po_no, String order_suppliers_itemno, Int32 quantity)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE po_order_list SET order_quantity = order_quantity - ?order_quantity ";
            query += "WHERE po_no = ?po_no AND order_suppliers_itemno = ?order_suppliers_itemno";
            String query1 = "UPDATE inventory_stocks SET stock_quantity = stock_quantity + ?stock_quantity ";
            query1 += "WHERE stock_code = ?stock_code";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                cmd.Parameters.AddWithValue("?order_quantity", quantity);
                cmd.Parameters.AddWithValue("?po_no", po_no);
                cmd.Parameters.AddWithValue("?order_suppliers_itemno", order_suppliers_itemno);
                cmd1.Parameters.AddWithValue("?stock_quantity", quantity);
                cmd1.Parameters.AddWithValue("?stock_code", order_suppliers_itemno);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd.Dispose();
                cmd1.Dispose();
                this.recalculateTotalPrice(order_suppliers_itemno);
                this.updateTotalPrice(order_suppliers_itemno);
            }
            finally
            {
                con.Close();
            }
        }

        public void Trigger(Int32 po_no)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            DateTime dateNow = DateTime.Now.Date;
            String final = dateNow.ToString("yyyy-MM-dd");
            String time = DateTime.Now.ToLongTimeString();
            String userName = frmLogin.User.user_name;
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE po_order SET po_date_r = ?po_date_r, po_time_r = ?po_time_r, po_status = 'Received', po_receive_by = ?po_receive_by ";
            query += "WHERE po_no = ?po_no";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?po_date_r", final);
                cmd.Parameters.AddWithValue("?po_time_r", time);
                cmd.Parameters.AddWithValue("?po_receive_by", userName);
                cmd.Parameters.AddWithValue("?po_no", po_no);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateR(String po_ref, Int32 po_no)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE po_order SET po_ref = ?po_ref ";
            query += "WHERE po_no = ?po_no";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?po_ref", po_ref);
                cmd.Parameters.AddWithValue("?po_no", po_no);
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