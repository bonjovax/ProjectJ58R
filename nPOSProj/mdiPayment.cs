using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace nPOSProj
{
    public partial class mdiPayment : Form
    {
        #region System Config
        private Conf.Drawer drawer;
        private Double taxP;
        private String taxDisplay;
        private String compName;
        private String address1;
        private String address2;
        private String contact;
        private String store_op;
        private String permit_no;
        private String TIN;
        private String TaxT;
        private String machine_no;
        private MySqlConnection con = new MySqlConnection();
        Conf.dbs dbcon = new Conf.dbs();
        #endregion
        private Conf.Rgx r = new Conf.Rgx();
        private Conf.BIR bir = new Conf.BIR(); //Bureau of Internal Revenue - PH
        private VO.CustomersVO customer;
        public mdiPayment()
        {
            InitializeComponent();
        }
        private void ConfigCheck()
        {
            frmLogin fl = new frmLogin();
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
                    if (rdr["tax_type"].ToString() == "V")
                    {
                        taxP = Convert.ToDouble("." + rdr["vat_rate"]);
                        taxDisplay = rdr["vat_rate"].ToString() + "%";
                        compName = rdr["company_name"].ToString();
                        address1 = rdr["company_address"].ToString();
                        address2 = rdr["company_address2"].ToString();
                        contact = rdr["company_contact"].ToString();
                        store_op = rdr["company_operator"].ToString();
                        permit_no = rdr["permit_no"].ToString();
                        TIN = rdr["tin_number"].ToString();
                        TaxT = rdr["tax_type"].ToString();
                        machine_no = rdr["machine_no"].ToString() + fl.tN;
                    }
                    else
                    {
                        taxP = 0;
                        taxDisplay = "0%";
                        compName = rdr["company_name"].ToString();
                        address1 = rdr["company_address"].ToString();
                        address2 = rdr["company_address2"].ToString();
                        contact = rdr["company_contact"].ToString();
                        store_op = rdr["company_operator"].ToString();
                        permit_no = rdr["permit_no"].ToString();
                        TIN = rdr["tin_number"].ToString();
                        TaxT = rdr["tax_type"].ToString();
                        machine_no = rdr["machine_no"].ToString() + fl.tN;
                    }
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtBoxAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxAmount.Text != "" && txtBoxAmount.Text != "0.00" && txtBoxAmount.Text != "0")
            {
                if (Regex.IsMatch(txtBoxAmount.Text, r.Amount()))
                {
                    if (Convert.ToDouble(txtBoxAmount.Text) <= Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value) && Convert.ToDouble(txtBoxAmount.Text) != 0)
                    {
                        txtBoxAmount.ReadOnly = false;
                        btnPay.Enabled = true;
                    }
                    else
                    {
                        btnPay.Enabled = false;
                        txtBoxAmount.Focus();
                    }
                }
                else
                {
                    btnPay.Enabled = false;
                    txtBoxAmount.Focus();
                }
            }
            else
            {
                txtBoxAmount.Focus();
                btnPay.Enabled = false;
            }
        }

        private void mdiPayment_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigCheck();
                customer = new VO.CustomersVO();
                String[,] grabData = customer.ReadCustomersPayment();
                dataGridView1.Rows.Clear();
                for (int x = 0; x < grabData.GetLength(1); x++)
                {
                    dataGridView1.Rows.Add(grabData[0, x].ToString(), grabData[1, x].ToString(), Convert.ToDouble(grabData[2, x]), Convert.ToDouble(grabData[3, x]), Convert.ToDouble(grabData[4, x]));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check Database!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBoxAmount.ReadOnly = false;
            txtBoxAmount.Text = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value).ToString("#,###,##0.00");
            txtBoxAmount.Focus();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            using (mCrmBasic crm = new mCrmBasic())
            {
                crm.Custcode = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                crm.ShowDialog();
            }
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Payment");
            saveFileDialog1.DefaultExt = ".xml";
            saveFileDialog1.FileName = "Export";
            saveFileDialog1.Filter = "Extensible Markup Language (*.xml)|*.xml";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dt.Columns.Add(dataGridView1.Columns[i].Name, typeof(System.String));
                }

                DataRow dickrow;
                int cols = dataGridView1.Columns.Count;
                foreach (DataGridViewRow drow in this.dataGridView1.Rows)
                {
                    dickrow = dt.NewRow();
                    for (int i = 0; i <= cols - 1; i++)
                    {
                        dickrow[i] = drow.Cells[i].Value;
                    }
                    dt.Rows.Add(dickrow);
                }
                dt.WriteXml(saveFileDialog1.FileName);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            VO.PosVO pos = new VO.PosVO();
            frmLogin fl = new frmLogin();
            try
            {
                DialogResult dlg = MessageBox.Show("Do you wish to Proceed the Payment", "Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    Double prePayable = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[2].Value);
                    Double preBalance = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value);
                    customer = new VO.CustomersVO();
                    pos.Pos_terminal = fl.tN;
                    customer.Pos_terminal = fl.tN;
                    customer.Pos_orno = pos.GetOrNo();
                    customer.Custcode = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    customer.Customer = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    customer.Pos_user = frmLogin.User.user_name;
                    customer.Balance = Convert.ToDouble(txtBoxAmount.Text);
                    if (customer.JustCheckVat() == true)
                    {
                        customer.Vatable = Convert.ToDouble(txtBoxAmount.Text);
                    }
                    else
                        customer.Vatable = 0;
                    customer.AmountPaid = Convert.ToDouble(txtBoxAmount.Text);
                    customer.Custcode = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    customer.DebitToAccount();
                    customer.PayToSale(); //NEW
                    dataGridView1.SelectedRows[0].Cells[3].Value = Convert.ToDouble(txtBoxAmount.Text);
                    dataGridView1.SelectedRows[0].Cells[4].Value = preBalance - Convert.ToDouble(txtBoxAmount.Text);
                    if (Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value) == 0)
                    {
                        dataGridView1.SelectedRows[0].Cells[2].Value = Convert.ToDouble(0);
                    }
                    drawer = new Conf.Drawer();
                    drawer.Open();
                    PrintPayments();
                    txtBoxAmount.Clear();
                    btnPay.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Your Database Server!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtBoxAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DialogResult dlg = MessageBox.Show("Do you wish to Proceed the Payment", "Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == System.Windows.Forms.DialogResult.Yes)
                    {
                        Double prePayable = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[2].Value);
                        Double preBalance = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value);
                        customer = new VO.CustomersVO();
                        customer.Balance = Convert.ToDouble(txtBoxAmount.Text);
                        customer.AmountPaid = Convert.ToDouble(txtBoxAmount.Text);
                        customer.Custcode = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        customer.DebitToAccount();
                        dataGridView1.SelectedRows[0].Cells[3].Value = Convert.ToDouble(txtBoxAmount.Text);
                        dataGridView1.SelectedRows[0].Cells[4].Value = preBalance - Convert.ToDouble(txtBoxAmount.Text);
                        if (Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value) == 0)
                        {
                            dataGridView1.SelectedRows[0].Cells[2].Value = Convert.ToDouble(0);
                        }
                        PrintPayments();
                        txtBoxAmount.Clear();
                        btnPay.Enabled = false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Your Database Server!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PrintPayments()
        {
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.Print();
        }

        private static string Truncate(string source, int length)
        {
            if (source.Length > length)
            {
                source = source.Substring(0, length);
            }
            return source;
        }

        void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            frmLogin fl = new frmLogin();
            Graphics graphic = e.Graphics;
            Font font = new Font("Tahoma", 10);

            float fontHeight = font.GetHeight();
            int startX = 10;
            int startY = 10;

            #region Header
            graphic.DrawString(compName, new Font("Tahoma", 14), new SolidBrush(Color.Black), startX, startY);
            graphic.DrawString(address1, new Font("Tahoma", 11), new SolidBrush(Color.Black), 45, 30);
            graphic.DrawString(address2, new Font("Tahoma", 11), new SolidBrush(Color.Black), 38, 45);
            //graphic.DrawString(contact, new Font("Tahoma", 11), new SolidBrush(Color.Black), 53, 60);
            //graphic.DrawString("Owned & Operated By: " + store_op, new Font("Tahoma", 11), new SolidBrush(Color.Black), 5, 75);
            graphic.DrawString("Permit No: " + permit_no, new Font("Tahoma", 11), new SolidBrush(Color.Black), 47, 60);
            graphic.DrawString("TIN: " + TIN + "" + TaxT, new Font("Tahoma", 11), new SolidBrush(Color.Black), 47, 75);
            graphic.DrawString("Accreditation No: " + bir.AccreditationNo(), new Font("Tahoma", 7), new SolidBrush(Color.Black), 11, 95);
            graphic.DrawString("Serial No: " + bir.SerialNo(), new Font("Tahoma", 11), new SolidBrush(Color.Black), 61, 105);
            graphic.DrawString("Machine Code: " + machine_no, new Font("Tahoma", 11), new SolidBrush(Color.Black), 43, 120);
            graphic.DrawString("-------------------------------------------", new Font("Tahoma", 11), new SolidBrush(Color.Black), 3, 135);
            graphic.DrawString(DateTime.Now.ToString("MMM dd, yyyy") + " " + "(" + DateTime.Now.ToString("ddd") + ")", font, new SolidBrush(Color.Black), 5, 150);
            graphic.DrawString(DateTime.Now.ToString("hh:mm tt"), font, new SolidBrush(Color.Black), 175, 150);
            graphic.DrawString("Customer Code: ", font, new SolidBrush(Color.Black), 5, 175);
            graphic.DrawString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), font, new SolidBrush(Color.Black), 120, 175);
            //
            graphic.DrawString("Company: ", font, new SolidBrush(Color.Black), 5, 190);
            graphic.DrawString(Truncate(dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), 25), font, new SolidBrush(Color.Black), 70, 190);
            //
            graphic.DrawString("Amount Paid ", new Font("Tahoma", 14), new SolidBrush(Color.Black), 5, 205);
            graphic.DrawString(Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[3].Value).ToString("#,###,##0.00"), new Font("Tahoma", 14), new SolidBrush(Color.Black), 125, 205);
            //
            graphic.DrawString("Balance ", new Font("Tahoma", 14), new SolidBrush(Color.Black), 5, 230);
            graphic.DrawString(Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value).ToString("#,###,##0.00"), new Font("Tahoma", 14), new SolidBrush(Color.Black), 125, 230);
            //
            graphic.DrawString("-------------------------------------------", new Font("Tahoma", 11), new SolidBrush(Color.Black), 3, 245);
            graphic.DrawString("CASHIER: ", new Font("Tahoma", 9), new SolidBrush(Color.Black), 3, 260);
            graphic.DrawString(frmLogin.User.user_name, new Font("Tahoma", 9), new SolidBrush(Color.Black), 60, 260);
            #endregion
        }
    }
}