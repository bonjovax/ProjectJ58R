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
    public partial class mdiOrdering : Form
    {
        public mdiOrdering()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                MessageBox.Show("Giovanne is Grilled!");
                return true;
            }
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void mdiOrdering_Load(object sender, EventArgs e)
        {

        }

        private void btnF6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}