using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nPOSProj.DAO
{
    class CustomersDAO
    {
        private MySqlConnection con;
        private Conf.dbs dbcon;
        private String userName = frmLogin.User.user_name;
        private Int32 count1 = 0;
        private Int32 count2 = 0;
        private Int32 count3 = 0;
        private String cmpName;
        private String custC;
        private bool korek = false;
        private bool foundZero = false;
        public CustomersDAO()
        {

        }
        #region Customer Core
        public Int32 PositionCount()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT COUNT(*) AS a FROM crm_customer ORDER BY crm_id";
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
        public Int32 PositionCountFilter(Double crm_balance)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT COUNT(*) AS a FROM crm_customer WHERE crm_balance = ?a ORDER BY crm_id";
            Int32 count = 0;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("?a", crm_balance);
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
        public String[,] ReadCustomer()
        {
            Int32 count = this.PositionCount();
            String[,] xxx = new String[7, count];
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT crm_custcode AS a, crm_companyname AS b, crm_firstname AS c, ";
            query += "crm_middlename AS d, crm_lastname AS e, crm_balance AS f, crm_duedate AS g ";
            query += "FROM crm_customer";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                int counts = 0;
                while (rdr.Read())
                {
                    xxx[0, counts] = rdr["a"].ToString();
                    xxx[1, counts] = rdr["b"].ToString();
                    xxx[2, counts] = rdr["c"].ToString();
                    xxx[3, counts] = rdr["d"].ToString();
                    xxx[4, counts] = rdr["e"].ToString();
                    xxx[5, counts] = rdr["f"].ToString();
                    xxx[6, counts] = rdr["g"].ToString();
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
        public String[,] ReadCustomerForPayment()
        {
            Int32 count = this.PositionCount();
            String[,] yyy = new String[5, count];
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT crm_custcode AS a, crm_companyname AS b, crm_payable AS c, crm_paidamt AS d, crm_balance AS e ";
            query += "FROM crm_customer ORDER BY crm_custcode";
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
                    yyy[4, counts] = rdr["e"].ToString();
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
        public String[,] ReadCustomerFilter(Double crm_balance)
        {
            Int32 count = this.PositionCountFilter(crm_balance);
            String[,] xxx = new String[6, count];
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT crm_custcode AS a, crm_companyname AS b, crm_firstname AS c, ";
            query += "crm_middlename AS d, crm_lastname AS e, crm_balance AS f ";
            query += "FROM crm_customer ";
            query += "WHERE crm_balance = ?crm_balance";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?crm_balance", crm_balance);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                int counts = 0;
                while (rdr.Read())
                {
                    xxx[0, counts] = rdr["a"].ToString();
                    xxx[1, counts] = rdr["b"].ToString();
                    xxx[2, counts] = rdr["c"].ToString();
                    xxx[3, counts] = rdr["d"].ToString();
                    xxx[4, counts] = rdr["e"].ToString();
                    xxx[5, counts] = rdr["f"].ToString();
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
        //
        public void Add(String custcode, String companyname, String firstname, String middlename, String lastname, String email, String phone_no, String address, String city, String province, String zip_code, String tin, String sss, Double creditlimit, Int32 netdays, Double interestrate)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "INSERT INTO crm_customer (crm_custcode, crm_companyname, crm_firstname, crm_middlename, crm_lastname, crm_email, crm_phone_no, crm_address, crm_city, crm_state_province, crm_zip_code, encoded, crm_tin, crm_sss, crm_creditlimit, crm_netdays, crm_interest, crm_duedate) VALUES";
            query += "(?a, ?b, ?c, ?d, ?e, ?f, ?g, ?h, ?i, ?j, ?k, ?l, ?m, ?n, ?o, ?p, ?q, ?r)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", custcode);
                cmd.Parameters.AddWithValue("?b", companyname);
                cmd.Parameters.AddWithValue("?c", firstname);
                cmd.Parameters.AddWithValue("?d", middlename);
                cmd.Parameters.AddWithValue("?e", lastname);
                cmd.Parameters.AddWithValue("?f", email);
                cmd.Parameters.AddWithValue("?g", phone_no);
                cmd.Parameters.AddWithValue("?h", address);
                cmd.Parameters.AddWithValue("?i", city);
                cmd.Parameters.AddWithValue("?j", province);
                cmd.Parameters.AddWithValue("?k", zip_code);
                cmd.Parameters.AddWithValue("?l", userName);
                cmd.Parameters.AddWithValue("?m", tin);
                cmd.Parameters.AddWithValue("?n", sss);
                cmd.Parameters.AddWithValue("?o", creditlimit);
                cmd.Parameters.AddWithValue("?p", netdays);
                cmd.Parameters.AddWithValue("?q", interestrate / 100);
                cmd.Parameters.AddWithValue("?r", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void Update(String custcode, String companyname, String firstname, String middlename, String lastname, String email, String phone_no, String address, String city, String province, String zip_code, String tin, String sss, Double creditlimit, Int32 netdays, Int32 is_suspended, Int32 has_summary, Double interest_rate, String duedate)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE crm_customer SET crm_companyname = ?a, crm_firstname = ?b, crm_middlename = ?c, crm_lastname = ?d, crm_email = ?e, ";
            query += "crm_phone_no = ?f, crm_address = ?g, crm_city = ?h, crm_state_province = ?i, crm_zip_code = ?j, crm_tin = ?w, crm_sss = ?x, crm_creditlimit = ?y, crm_netdays = ?z, is_suspended = ?suspend, has_summary = ?summary, crm_interest = ?aa, crm_duedate = ?bb ";
            query += "WHERE crm_custcode = ?k";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con); 
                cmd.Parameters.AddWithValue("?a", companyname);
                cmd.Parameters.AddWithValue("?b", firstname);
                cmd.Parameters.AddWithValue("?c", middlename);
                cmd.Parameters.AddWithValue("?d", lastname);
                cmd.Parameters.AddWithValue("?e", email);
                cmd.Parameters.AddWithValue("?f", phone_no);
                cmd.Parameters.AddWithValue("?g", address);
                cmd.Parameters.AddWithValue("?h", city);
                cmd.Parameters.AddWithValue("?i", province);
                cmd.Parameters.AddWithValue("?j", zip_code);
                cmd.Parameters.AddWithValue("?w", tin);
                cmd.Parameters.AddWithValue("?x", sss);
                cmd.Parameters.AddWithValue("?y", creditlimit);
                cmd.Parameters.AddWithValue("?z", netdays);
                cmd.Parameters.AddWithValue("?aa", interest_rate / 100);
                cmd.Parameters.AddWithValue("?bb", Convert.ToDateTime(duedate).ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("?k", custcode);
                cmd.Parameters.AddWithValue("?suspend", is_suspended);
                cmd.Parameters.AddWithValue("?summary", has_summary);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void Delete(String custcode)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "DELETE FROM crm_customer ";
            query += "WHERE crm_custcode = ?a";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", custcode);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public bool checkCustcode(String custcode)
        {
            bool found = false;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT crm_custcode FROM crm_customer ";
            query += "WHERE crm_custcode = ?a";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", custcode);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    found = true;
                }
            }
            finally
            {
                con.Close();
            }
            return found;
        }
        public String[] ReadEdit(String crm_custcode)
        {
            String[] cabilat = new String[19];
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT crm_custcode AS a, crm_companyname AS b, crm_firstname AS c, crm_middlename AS d, crm_lastname AS e, crm_email AS f, ";
            query += "crm_phone_no AS g, crm_address AS h, crm_city AS i, crm_state_province AS j, crm_zip_code AS k, crm_tin AS l, crm_sss AS m, crm_creditlimit AS n, crm_netdays AS o, is_suspended AS p, crm_interest AS q, crm_duedate AS r, has_summary AS s ";
            query += "FROM crm_customer ";
            query += "WHERE crm_custcode = ?crm_custcode";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?crm_custcode", crm_custcode);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    cabilat[0] = rdr["a"].ToString();
                    cabilat[1] = rdr["b"].ToString();
                    cabilat[2] = rdr["c"].ToString();
                    cabilat[3] = rdr["d"].ToString();
                    cabilat[4] = rdr["e"].ToString();
                    cabilat[5] = rdr["f"].ToString();
                    cabilat[6] = rdr["g"].ToString();
                    cabilat[7] = rdr["h"].ToString();
                    cabilat[8] = rdr["i"].ToString();
                    cabilat[9] = rdr["j"].ToString();
                    cabilat[10] = rdr["k"].ToString();
                    cabilat[11] = rdr["l"].ToString();
                    cabilat[12] = rdr["m"].ToString();
                    cabilat[13] = rdr["n"].ToString();
                    cabilat[14] = rdr["o"].ToString();
                    cabilat[15] = rdr["p"].ToString();
                    cabilat[16] = rdr["q"].ToString();
                    cabilat[17] = rdr["r"].ToString();
                    cabilat[18] = rdr["s"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return cabilat;
        }
        //
        public Int32 countSummary()
        {
            Int32 ihap = 0;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT COUNT(*) AS a FROM crm_customer ";
            query += "WHERE has_summary = 1 ORDER BY crm_companyname";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    ihap = Convert.ToInt32(rdr["a"]);
                }
            }
            finally
            {
                con.Close();
            }
            return ihap;
        }
        public String[,] ReadSummary()
        {
            Int32 count = this.countSummary();
            String[,] ret = new String[4, count];
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT crm_companyname AS customer, crm_netdays AS terms, crm_duedate AS duedate, crm_balance AS outstanding ";
            query += "FROM crm_customer WHERE has_summary = 1 ORDER BY crm_companyname";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                Int32 counts = 0;
                while (rdr.Read())
                {
                    ret[0, counts] = rdr["customer"].ToString();
                    ret[1, counts] = rdr["terms"].ToString();
                    ret[2, counts] = rdr["duedate"].ToString();
                    ret[3, counts] = rdr["outstanding"].ToString();
                    counts++;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            finally
            {
                con.Close();
            }
            return ret;
        }
        //
        public String[] ReadData(String crm_custcode, String crm_companyname)
        {
            String[] cabilat = new String[2];
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT crm_balance AS a, crm_creditlimit AS b ";
            query += "FROM crm_customer ";
            query += "WHERE crm_custcode = ?crm_custcode AND crm_companyname = ?crm_companyname";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?crm_custcode", crm_custcode);
                cmd.Parameters.AddWithValue("?crm_companyname", crm_companyname);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    cabilat[0] = rdr["a"].ToString();
                    cabilat[1] = rdr["b"].ToString();
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
            return cabilat;
        }

        #endregion
        #region CRM Basic
        public Int32 PositionCountCRM(String crm_custcode, DateTime filterToday)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT COUNT(*) AS a FROM crm_basic WHERE crm_custcode = ?a AND crm_paydate = ?b ORDER BY basic_id";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("?a", crm_custcode);
                cmd.Parameters.AddWithValue("?b", filterToday);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    count1 = Convert.ToInt32(rdr["a"].ToString());
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
            return count1;
        }
        public Int32 PositionCountCRMFilter(String crm_custcode, DateTime from, DateTime to)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT COUNT(*) AS a FROM crm_basic WHERE (crm_custcode = ?a) AND ((crm_paydate >= ?from) AND (crm_paydate <= ?to)) ORDER BY basic_id";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("?a", crm_custcode);
                cmd.Parameters.AddWithValue("?from", from);
                cmd.Parameters.AddWithValue("?to", to);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    count2 = Convert.ToInt32(rdr["a"].ToString());
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
            return count2;
        }
        public Int32 PositionCountCRMAll(String crm_custcode)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String sql = "SELECT COUNT(*) AS a FROM crm_basic WHERE (crm_custcode = ?a) ORDER BY basic_id";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("?a", crm_custcode);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    count3 = Convert.ToInt32(rdr["a"].ToString());
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
            return count3;
        }
        public String[,] ReadCRMToday(String crm_custcode, DateTime crm_paydate)
        {
            this.PositionCountCRM(crm_custcode, crm_paydate);
            Int32 count = count1;
            String[,] xxx = new String[3, count];
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT crm_paydate AS a, crm_paytime AS b, crm_payamount AS c ";
            query += "FROM crm_basic ";
            query += "WHERE crm_custcode = ?a AND crm_paydate = ?b ORDER BY crm_paydate";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", crm_custcode);
                cmd.Parameters.AddWithValue("?b", crm_paydate);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                int counts = 0;
                while (rdr.Read())
                {
                    xxx[0, counts] = rdr["a"].ToString();
                    xxx[1, counts] = rdr["b"].ToString();
                    xxx[2, counts] = rdr["c"].ToString();
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
        //
        public String[,] ReadCRMFilterDate(String crm_custcode, DateTime from, DateTime to)
        {
            this.PositionCountCRMFilter(crm_custcode, from, to);
            Int32 count = count2;
            String[,] yyy = new String[3, count];
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT crm_paydate AS a, crm_paytime AS b, crm_payamount AS c ";
            query += "FROM crm_basic ";
            query += "WHERE (crm_custcode = ?a) AND ((crm_paydate >= ?from) AND (crm_paydate <= ?to)) ORDER By crm_paydate";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", crm_custcode);
                cmd.Parameters.AddWithValue("?from", from);
                cmd.Parameters.AddWithValue("?to", to);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                int counts = 0;
                while (rdr.Read())
                {
                    yyy[0, counts] = rdr["a"].ToString();
                    yyy[1, counts] = rdr["b"].ToString();
                    yyy[2, counts] = rdr["c"].ToString();
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
        //
        public String[,] ReadCRMAll(String crm_custcode)
        {
            this.PositionCountCRMAll(crm_custcode);
            Int32 count = count3;
            String[,] zzz = new String[3, count];
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT crm_paydate AS a, crm_paytime AS b, crm_payamount AS c ";
            query += "FROM crm_basic ";
            query += "WHERE (crm_custcode = ?a) ORDER BY crm_paydate";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", crm_custcode);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                int counts = 0;
                while (rdr.Read())
                {
                    zzz[0, counts] = rdr["a"].ToString();
                    zzz[1, counts] = rdr["b"].ToString();
                    zzz[2, counts] = rdr["c"].ToString();
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
            return zzz;
        }
        #endregion
        #region Misc
        public String DisplayCmp(String crm_custcode)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT crm_companyname FROM crm_customer WHERE crm_custcode = ?a AND is_suspended = 0";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", crm_custcode);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    cmpName = rdr["crm_companyname"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return cmpName;
        }
        public String DisplayCustC(String crm_companyname)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT crm_custcode FROM crm_customer WHERE crm_companyname = ?a AND is_suspended = 0";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", crm_companyname);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    custC = rdr["crm_custcode"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return custC;
        }
        public bool correct(String crm_custcode, String crm_companyname)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT * FROM crm_customer ";
            query += "WHERE (crm_custcode = ?a) AND (crm_companyname = ?b)";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", crm_custcode);
                cmd.Parameters.AddWithValue("?b", crm_companyname);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    korek = true;
                }
            }
            finally
            {
                con.Close();
            }
            return korek;
        }
        //
        public Double grabInterestRate(String custcode)
        {
            Double IR = 0;
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT crm_interest AS a FROM crm_customer ";
            query += "WHERE crm_custcode = ?crm_custcode";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?crm_custcode", custcode);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    IR = Convert.ToDouble(rdr["a"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return IR;
        }
        public void PingIR(Double crm_balance, String custcode)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE crm_customer SET crm_balance = ?a ";
            query += "WHERE crm_custcode = ?crm_custcode";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?a", crm_balance);
                cmd.Parameters.AddWithValue("?crm_custcode", custcode);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
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
        #endregion
        #region Checkout Part
        public void CreditAccount(Double crm_balance, Double crm_payable, String crm_custcode)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE crm_customer SET crm_balance = crm_balance + ?crm_balance, crm_payable = crm_payable + ?crm_payable ";
            query += "WHERE crm_custcode = ?crm_custcode";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?crm_balance", crm_balance);
                cmd.Parameters.AddWithValue("?crm_payable", crm_payable);
                cmd.Parameters.AddWithValue("?crm_custcode", crm_custcode);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
        public void DebitAccount(Double crm_balance, Double crm_paidamt, String crm_custcode)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE crm_customer SET crm_balance = crm_balance - ?crm_balance, crm_paidamt = ?crm_paidamt ";
            query += "WHERE crm_custcode = ?crm_custcode";
            String query1 = "INSERT INTO crm_basic (crm_custcode, crm_paydate, crm_paytime, crm_payamount) VALUES";
            query1 += "(?crm_custcode, ?crm_paydate, ?crm_paytime, ?crm_payamount)";
            String query2 = "UPDATE crm_customer SET crm_payable = 0 ";
            query2 += "WHERE crm_custcode = ?crm_custcode";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                MySqlCommand cmd2 = new MySqlCommand(query2, con);
                cmd.Parameters.AddWithValue("?crm_balance", crm_balance);
                cmd.Parameters.AddWithValue("?crm_paidamt", crm_paidamt);
                cmd.Parameters.AddWithValue("?crm_custcode", crm_custcode);
                cmd1.Parameters.AddWithValue("?crm_custcode", crm_custcode);
                cmd1.Parameters.AddWithValue("?crm_paydate", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));
                cmd1.Parameters.AddWithValue("?crm_paytime", Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss")));
                cmd1.Parameters.AddWithValue("?crm_payamount", crm_paidamt);
                cmd2.Parameters.AddWithValue("?crm_custcode", crm_custcode);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd.Dispose();
                cmd1.Dispose();
                if (this.checkZeroAmt(crm_custcode) == true)
                {
                    cmd2.ExecuteNonQuery();
                    cmd2.Dispose();
                }
            }
            finally
            {
                con.Close();
            }
        }
        private bool checkZeroAmt(String crm_custcode)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT crm_balance FROM crm_customer ";
            query += "WHERE crm_balance = 0";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    foundZero = true;
                }
            }
            finally
            {
                con.Close();
            }
            return foundZero;
        }
        #endregion
    }
}