using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace nPOSProj
{
    public partial class frmDlgRefund : Form
    {
        private DAO.LoginDAO login;
        private VO.PosVO pos;
        private VO.ConfigVO config = new VO.ConfigVO();
        frmLogin fl = new frmLogin();
        private Double Price = 0;
        private String taxTypes;
        private String terminalSelect;

        public String TaxTypes
        {
            get { return taxTypes; }
            set { taxTypes = value; }
        }
        private Int32 allItemsTax;

        public Int32 AllItemsTax
        {
            get { return allItemsTax; }
            set { allItemsTax = value; }
        }
        private String taxDisplay;

        public String TaxDisplay
        {
            get { return taxDisplay; }
            set { taxDisplay = value; }
        }
        private Double taxP;

        public Double TaxP
        {
            get { return taxP; }
            set { taxP = value; }
        }
        public frmDlgRefund()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void closeDlg_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getData()
        {
            pos = new VO.PosVO();
            pos.Pos_orno = Convert.ToInt32(txtBoxOR.Text);
            pos.Pos_terminal = fl.tN;
            try
            {
                String[,] grabData = pos.ReadRefunData();
                dataGridView1.Rows.Clear();
                for (int x = 0; x < grabData.GetLength(1); x++)
                {
                    Double priceDetect = 0;
                    if (pos.checkWS() == true) //If Wholesale
                    {
                        priceDetect = Convert.ToDouble(grabData[4, x]);
                    }
                    else
                        priceDetect = Convert.ToDouble(grabData[3, x]);
                    dataGridView1.Rows.Add(grabData[0, x].ToString(), grabData[1, x].ToString(), grabData[2, x].ToString(), priceDetect, Convert.ToDouble(grabData[5, x]), Convert.ToDouble(grabData[6, x]), grabData[7, x].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void getDataSelect()
        {
            pos = new VO.PosVO();
            pos.Pos_orno = Convert.ToInt32(txtBoxOR.Text);
            pos.Pos_terminal = cBTerminal.Text;
            try
            {
                String[,] grabData = pos.ReadRefunData();
                dataGridView1.Rows.Clear();
                for (int x = 0; x < grabData.GetLength(1); x++)
                {
                    Double priceDetect = 0;
                    if (pos.checkWS() == true) //If Wholesale
                    {
                        priceDetect = Convert.ToDouble(grabData[4, x]);
                    }
                    else
                        priceDetect = Convert.ToDouble(grabData[3, x]);
                    dataGridView1.Rows.Add(grabData[0, x].ToString(), grabData[1, x].ToString(), grabData[2, x].ToString(), priceDetect, Convert.ToDouble(grabData[5, x]), Convert.ToDouble(grabData[6, x]), grabData[7, x].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void getTerminal()
        {
            try
            {
                config = new VO.ConfigVO();
                cBTerminal.Items.Clear();
                String[,] grabData = config.ReadTerminal();
                for (int x = 0; x < grabData.GetLength(1); x++)
                {
                    cBTerminal.Items.Add(grabData[0, x].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmDlgRefund_Load(object sender, EventArgs e)
        {
            terminalSelect = fl.tN;
            login = new DAO.LoginDAO();
            String userName = frmLogin.User.user_name;
            login.catchUsername(userName);
            rdVAT.Text = TaxDisplay;
            if (login.hasUser_Accounts())
            {
                lbl1.Visible = true;
                cBTerminal.Visible = true;
            }
        }

        private void txtBoxOR_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    getData();
                    cBTerminal.Enabled = true;
                    getTerminal();
                    if (TaxTypes == "V")
                    {
                        if (allItemsTax == 1)
                        {
                            SumV();
                            SumE();
                            SumZ();
                            txtBoxVatable.Text = SumV().ToString("#,###,##0.00");
                            txtBoxVAMT.Text = CompiyutVatAmount().ToString("#,###,##0.00");
                            txtBoxVATE.Text = SumE().ToString("#,###,##0.00");
                            txtBoxZero.Text = SumZ().ToString("#,###,##0.00");
                            rdTotalAmount.Text = CellSum().ToString("#,###,##0.00");
                        }
                        else
                        {
                            Double lapulapu = 0;
                            txtBoxVatable.Text = SumV().ToString("#,###,##0.00");
                            txtBoxVAMT.Text = CompiyutVatAmount().ToString("#,###,##0.00");
                            txtBoxVATE.Text = SumE().ToString("#,###,##0.00");
                            txtBoxZero.Text = SumZ().ToString("#,###,##0.00");
                            lapulapu = SumV() + CompiyutVatAmount() + SumE() + SumZ();
                            rdTotalAmount.Text = lapulapu.ToString("#,###,##0.00");
                        }
                    }
                    else
                    {
                        rdTotalAmount.Text = CellSum().ToString("#,###,##0.00");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtBoxOR_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            txtBoxVatable.Text = "0.00";
            txtBoxVAMT.Text = "0.00";
            txtBoxVATE.Text = "0.00";
            txtBoxZero.Text = "0.00";
            rdTotalAmount.Text = "0.00";
            cBTerminal.Enabled = false;
        }

        private void cBTerminal_SelectedIndexChanged(object sender, EventArgs e)
        {
            terminalSelect = cBTerminal.Text;
            getDataSelect();
            if (allItemsTax == 1)
            {
                SumV();
                SumE();
                SumZ();
                txtBoxVatable.Text = SumV().ToString("#,###,##0.00");
                txtBoxVAMT.Text = CompiyutVatAmount().ToString("#,###,##0.00");
                txtBoxVATE.Text = SumE().ToString("#,###,##0.00");
                txtBoxZero.Text = SumZ().ToString("#,###,##0.00");
                rdTotalAmount.Text = CellSum().ToString("#,###,##0.00");
            }
            else
            {
                Double lapulapu = 0;
                lapulapu = SumV() + CompiyutVatAmount() + SumE() + SumZ();
                rdTotalAmount.Text = lapulapu.ToString("#,###,##0.00");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Cells[1].Value.ToString() != "0")
            {
                txtBoxQty.ReadOnly = false;
                txtBoxQty.Focus();
                txtBoxQty.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }
        }

        private void txtBoxOR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBoxQty_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxQty.Text == "")
            {
                btnRefund.Enabled = false;
            }
            try
            {
                if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value) >= Convert.ToInt32(txtBoxQty.Text))
                {
                    btnRefund.Enabled = true;
                }
                else
                    btnRefund.Enabled = false;
            }
            catch (Exception)
            {
            }
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            try
            {
                pos.Pos_orno = Convert.ToInt32(txtBoxOR.Text);
                pos.Pos_terminal = terminalSelect;
                pos.Pos_ean = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                pos.Pos_discount_amt = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value);
                DialogResult dr = MessageBox.Show("Do You Wish To Continue?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    Int32 compute = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value) - Convert.ToInt32(txtBoxQty.Text);
                    pos.Pos_quantity = compute;
                    dataGridView1.SelectedRows[0].Cells[1].Value = compute;
                    Double computePre = Price * Convert.ToDouble(txtBoxQty.Text);
                    Double finale = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[5].Value) - computePre;
                    pos.Pos_amt = finale;
                    dataGridView1.SelectedRows[0].Cells[5].Value = finale;
                    if (Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[1].Value) == Convert.ToDouble(0))
                    {
                        dataGridView1.SelectedRows[0].Cells[5].Value = Convert.ToDouble(0);
                    }
                    txtBoxQty.Clear();
                    btnRefund.Enabled = false;
                    Double fin = 0;
                    if (TaxTypes == "V")
                    {
                        if (AllItemsTax == 1)
                        {
                            if (dataGridView1.SelectedRows[0].Cells[6].Value.ToString() == "V")
                            {
                                pos.Pos_vatable = SumV();
                                txtBoxVatable.Text = SumV().ToString("#,###,##0.00");
                                fin = Convert.ToDouble(txtBoxVatable.Text) * TaxP;
                                pos.Pos_tax_perc = TaxP;
                                pos.Pos_tax_amt = fin;
                                txtBoxVAMT.Text = fin.ToString("#,###,##0.00");
                            }
                            if (dataGridView1.SelectedRows[0].Cells[6].Value.ToString() == "E")
                            {
                                txtBoxVATE.Text = SumE().ToString("#,###,##0.00");
                            }
                            if (dataGridView1.SelectedRows[0].Cells[6].Value.ToString() == "Z")
                            {
                                txtBoxZero.Text = SumZ().ToString("#,###,##0.00");
                            }
                            pos.Pos_vatz = SumZ();
                            pos.Pos_vex = SumE();
                            pos.Pos_total_amt = CellSum();
                            rdTotalAmount.Text = CellSum().ToString("#,###,##0.00");
                            pos.ParkItemUpdate();
                            pos.UpdateTrunk();
                            
                        }
                        if (dataGridView1.SelectedRows[0].Cells[6].Value.ToString() == "V")
                        {
                            pos.Pos_vatable = SumV();
                            txtBoxVatable.Text = SumV().ToString("#,###,##0.00");
                            fin = Convert.ToDouble(txtBoxVatable.Text) * TaxP;
                            pos.Pos_tax_perc = TaxP;
                            pos.Pos_tax_amt = fin;
                            txtBoxVAMT.Text = fin.ToString("#,###,##0.00");
                        }
                        if (dataGridView1.SelectedRows[0].Cells[6].Value.ToString() == "E")
                        {
                            txtBoxVATE.Text = SumE().ToString("#,###,##0.00");
                        }
                        if (dataGridView1.SelectedRows[0].Cells[6].Value.ToString() == "Z")
                        {
                            txtBoxZero.Text = SumZ().ToString("#,###,##0.00");
                        }
                        pos.Pos_vatz = SumZ();
                        pos.Pos_vex = SumE();
                        Double lapulapu = 0;
                        if (AllItemsTax == 1)
                        {
                            pos.Pos_total_amt = CellSum();
                            rdTotalAmount.Text = CellSum().ToString("#,###,##0.00");
                        }
                        else
                        {
                            lapulapu = SumV() + CompiyutVatAmount() + SumE() + SumZ();
                            pos.Pos_total_amt = lapulapu;
                            rdTotalAmount.Text = lapulapu.ToString("#,###,##0.00");
                        }
                        pos.Total_pos_disc_amt = DiscountSum();
                        pos.Pos_amt = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[5].Value);
                        pos.ParkItemUpdate();
                        pos.UpdateTrunk();
                    }
                    else
                    {
                        pos.Total_pos_disc_amt = DiscountSum();
                        pos.Pos_vatable = 0;
                        pos.Pos_vex = 0;
                        pos.Pos_vatz = 0;
                        pos.Pos_tax_amt = 0;
                        pos.Pos_tax_perc = 0;
                        pos.Pos_total_amt = CellSum();
                        rdTotalAmount.Text = CellSum().ToString("#,###,##0.00");
                        pos.ParkItemUpdate();
                        pos.UpdateTrunk();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private Double CellSum()
        {
            Double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                Double d = 0;
                Double.TryParse(dataGridView1.Rows[i].Cells[5].Value.ToString(), out d);
                sum += d;
            }
            return sum;
        }
        private Double DiscountSum()
        {
            Double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                Double d = 0;
                Double.TryParse(dataGridView1.Rows[i].Cells[4].Value.ToString(), out d);
                sum += d;
            }
            return sum;
        }

        private Double SumV()
        {
            Double sumV = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                Double d = 0;
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "V")
                {
                    Double.TryParse(dataGridView1.Rows[i].Cells[5].Value.ToString(), out d);
                    sumV += d;
                }
            }
            return sumV;
        }
        private Double SumE()
        {
            Double sumE = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                Double d = 0;
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "E")
                {
                    Double.TryParse(dataGridView1.Rows[i].Cells[5].Value.ToString(), out d);
                    sumE += d;
                }
            }
            return sumE;
        }
        private Double SumZ()
        {
            Double sumZ = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                Double d = 0;
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "Z")
                {
                    Double.TryParse(dataGridView1.Rows[i].Cells[5].Value.ToString(), out d);
                    sumZ += d;
                }
            }
            return sumZ;
        }
        private Double CompiyutVatAmount()
        {
            Double fin = 0;
            fin = Convert.ToDouble(txtBoxVatable.Text) * TaxP;
            return fin;
        }

        private void txtBoxQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRefund.Focus();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Price = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[5].Value) / Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[1].Value);
        }
    }
}