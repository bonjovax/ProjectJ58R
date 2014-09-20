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
    public partial class frmDlgEditQty : Form
    {
        private Int32 qty;
        public frmDlgEditQty()
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
        public Int32 Qty
        {
            get { return Convert.ToInt32(txtBoxQty.Text); }
        }
        public Int32 dQty
        {
            get { return qty; }
            set { qty = value; }
        }

        private void txtBoxQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtBoxQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

        private void txtBoxQty_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxQty.Text != "")
            {
            }
            else
                txtBoxQty.Text = "0";
        }

        private void frmDlgEditQty_Load(object sender, EventArgs e)
        {
            txtBoxQty.Text = qty.ToString();
        }
    }
}