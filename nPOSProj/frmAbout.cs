using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;

namespace nPOSProj
{
    public partial class frmAbout : Form
    {
        private Conf.BIR bir = new Conf.BIR();
        private String machine_no;
        private MySqlConnection con = new MySqlConnection();
        Conf.dbs dbcon = new Conf.dbs();
        public frmAbout()
        {
            InitializeComponent();
        }
        private void ConfigCheck()
        {
            con.ConnectionString = dbcon.getConnectionString();
            String query = "SELECT * FROM system_config";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteScalar();
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    machine_no = rdr["machine_no"].ToString();
                }
                con.Close();
            }
            catch (Exception)
            {
                label11.Text = "Error!";
            }
        }
        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
        private void frmAbout_Load(object sender, EventArgs e)
        {
            frmLogin fl = new frmLogin();
            ConfigCheck();
            String nows;
            if (DateTime.Now.Year.ToString() == "2014")
            {
                nows = "";
            }
            else
            {
                nows = DateTime.Now.Year.ToString();
            }
            label1.Text = AssemblyProduct;
            label2.Text = String.Format("Version {0}", AssemblyVersion);
            label3.Text = AssemblyCopyright + " - " + nows;
            label4.Text = AssemblyCompany;
            label11.Text = "Machine Code: " + machine_no + fl.tN;
            label6.Text = "Alfel Benvic (Bon) G. Go";
            label7.Text = "Abel L. Jarmonilla";
            label9.Text = "Accreditation No. " + bir.AccreditationNo();
            label10.Text = "Serial No. " + bir.SerialNo();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("nPOS.pdf");
            }
            catch (Exception)
            {
                MessageBox.Show("Adobe Reader Is Required or File Not Found", "Help", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}