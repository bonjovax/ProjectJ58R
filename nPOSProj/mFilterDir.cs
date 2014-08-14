using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace nPOSProj
{
    public partial class mFilterDir : Form
    {
        private bool searched;
        private Conf.Rgx r = new Conf.Rgx();

        public bool Searched
        {
            get { return searched; }
            set { searched = value; }
        }
        private Double filterAmount;

        public Double FilterAmount
        {
            get { return filterAmount; }
            set { filterAmount = value; }
        }
        public mFilterDir()
        {
            InitializeComponent();
        }

        private void txtBoxAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Regex.IsMatch(txtBoxAmount.Text, r.Amount()))
                {
                    Searched = true;
                    FilterAmount = Convert.ToDouble(txtBoxAmount.Text);
                    this.Close();
                }
                else
                    MessageBox.Show("Please Enter the Amount Correctly!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mFilterDir_Load(object sender, EventArgs e)
        {
            Searched = false;
        }

        private void txtBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
    }
}