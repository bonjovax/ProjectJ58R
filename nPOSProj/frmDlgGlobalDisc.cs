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
    public partial class frmDlgGlobalDisc : Form
    {
        private Double amount;

        public Double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        private Double getAmount;

        public Double GetAmount
        {
            get { return getAmount; }
            set { getAmount = value; }
        }
        public frmDlgGlobalDisc()
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
                    if (txtBoxAmount.Text == "" || txtBoxAmount.Text == null)
                    {
                        txtBoxAmount.Text = "0.00";
                    }
                    else
                    {
                        Amount = GetAmount - Convert.ToDouble(txtBoxAmount.Text);
                        if (Amount <= 0)
                        {
                            MessageBox.Show("You Have Encounter Negative Total Amount!\nPlease Redo.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Amount = GetAmount;
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
