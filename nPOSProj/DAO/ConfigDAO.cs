using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace nPOSProj.DAO
{
    class ConfigDAO
    {
        private Conf.dbs dbcon;
        private MySqlConnection con;
        private String Company_Name;
        private String Company_Address;
        private String Company_Address1;
        private String Tin_Number;
        private String Tax_Type;
        private Double Vat_Rate;
        private String Contact_Number;
        private Int16 allIT;
        private String oper;
        private String permitno;

        public ConfigDAO()
        {

        }

        public void PatchInfo(String company_name, String company_address, String tin_number, String tax_type, Double vat_rate, Int16 all_items_tax, String contact_number, String owner, String permit, String company_address1)
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "UPDATE system_config SET company_name = ?company_name, ";
            query += "company_address = ?company_address, tin_number = ?tin_number, tax_type = ?tax_type, vat_rate = ?vat_rate, all_items_tax = ?all_items_tax, ";
            query += "company_contact = ?company_contact, company_operator = ?company_operator, permit_no = ?permit_no, company_address2 = ?address1";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?company_name", company_name);
                cmd.Parameters.AddWithValue("?company_address", company_address);
                cmd.Parameters.AddWithValue("?tin_number", tin_number);
                cmd.Parameters.AddWithValue("?tax_type", tax_type);
                cmd.Parameters.AddWithValue("?vat_rate", vat_rate);
                cmd.Parameters.AddWithValue("?all_items_tax", all_items_tax);
                cmd.Parameters.AddWithValue("?company_contact", contact_number);
                cmd.Parameters.AddWithValue("?company_operator", owner);
                cmd.Parameters.AddWithValue("?permit_no", permit);
                cmd.Parameters.AddWithValue("?address1", company_address1);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public String readCompany_Name()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT company_name FROM system_config";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Company_Name = rdr["company_name"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return Company_Name;
        }
        public String readCompany_Address()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT company_address FROM system_config";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Company_Address = rdr["company_address"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return Company_Address;
        }
        public String readTin_Number()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT tin_number FROM system_config";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Tin_Number = rdr["tin_number"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return Tin_Number;
        }
        public String readTax_Type()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT tax_type FROM system_config";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Tax_Type = rdr["tax_type"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return Tax_Type;
        }
        public Double readVat_Rate()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT vat_rate FROM system_config";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Vat_Rate = Convert.ToDouble(rdr["vat_rate"]);
                }
            }
            finally
            {
                con.Close();
            }
            return Vat_Rate;
        }
        public String readContact_Number()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT company_contact FROM system_config";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Contact_Number = rdr["company_contact"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return Contact_Number;
        }

        public Int16 allItemTax()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT all_items_tax FROM system_config";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    allIT = Convert.ToInt16(rdr["all_items_tax"]);
                }
            }
            finally
            {
                con.Close();
            }
            return allIT;
        }
        public String operators()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT company_operator FROM system_config";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    oper = rdr["company_operator"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return oper;
        }
        public String permitNo()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT permit_no FROM system_config";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    permitno = rdr["permit_no"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return permitno;
        }
        public String address1()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT company_address2 FROM system_config";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Company_Address1 = rdr["company_address2"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
            return Company_Address1;
        }

        //
        public Int32 CountTerminal()
        {
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT COUNT(*) AS a ";
            query += "FROM system_terminal";
            Int32 count = 0;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    count = Convert.ToInt32(rdr["a"]);
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
        public String[,] ReadTerminal()
        {
            Int32 count = this.CountTerminal();
            String[,] xxx = new String[1, count];
            con = new MySqlConnection();
            dbcon = new Conf.dbs();
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT identify AS a FROM system_terminal";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                int counts = 0;
                while (rdr.Read())
                {
                    xxx[0, counts] = rdr["a"].ToString();
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
    }
}