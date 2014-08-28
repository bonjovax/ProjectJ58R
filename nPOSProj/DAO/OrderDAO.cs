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

        //public Int32 askOrderNo()
        //{
        //    Int32 orderNo = 0;
        //    con = new MySqlConnection();
        //    db = new Conf.dbs();
        //    con.ConnectionString = db.getConnectionString();
        //    String query = "SELECT COUNT(pos_orderno) FROM pos_";
        //}
    }
}