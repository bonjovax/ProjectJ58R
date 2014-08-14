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
    public partial class cstDlgAlert : Form
    {
        private String msgDiri;

        public String MsgDiri
        {
            get { return msgDiri; }
            set { msgDiri = value; }
        }
        public cstDlgAlert()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void cstDlgAlert_Load(object sender, EventArgs e)
        {
            msgX.Text = msgDiri;
            timer1.Start();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 250;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (msgX.BackColor == Color.Red && lblCmd.BackColor == Color.Red)
            {
                msgX.BackColor = Color.White;
                lblCmd.BackColor = Color.White;
                msgX.ForeColor = Color.Black;
                lblCmd.ForeColor = Color.Black;
            }
            else
            {
                msgX.BackColor = Color.Red;
                lblCmd.BackColor = Color.Red;
                msgX.ForeColor = Color.White;
                lblCmd.ForeColor = Color.White;
            }
        }
    }
}
