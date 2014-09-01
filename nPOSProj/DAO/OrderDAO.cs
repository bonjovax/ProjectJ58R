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
    }
}