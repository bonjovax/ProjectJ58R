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
    public partial class frmDlgDiscount : Form
    {
        public frmDlgDiscount()
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
        public Double Percentage
        {
            get 
            { 
                return Convert.ToDouble("." + txtBoxPerc.Text); 
            }
        }

        private void txtBoxPerc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtBoxPerc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

        private void txtBoxPerc_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxPerc.Text != "")
            {
            }
            else
                txtBoxPerc.Text = "0";
        }
    }
}