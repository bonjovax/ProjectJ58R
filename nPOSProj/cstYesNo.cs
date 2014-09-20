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
    public partial class cstYesNo : Form
    {
        public cstYesNo()
        {
            InitializeComponent();
            Selected = false;
        }

        private Boolean selected;

        public Boolean Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        private String message;

        public String Message
        {
            get { return message; }
            set { message = value; }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F11)
            {
                Selected = true;
                this.Close();
                return true;
            }
            if (keyData == Keys.F12)
            {
                Selected = false;
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void cstYesNo_Load(object sender, EventArgs e)
        {
            msgX.Text = Message;
            timer1.Start();
            timer1.Interval = 500;
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (msgX.BackColor == Color.SteelBlue && msgX.ForeColor == Color.White && lblCmd.BackColor == Color.SteelBlue && lblCmd.ForeColor == Color.White)
            {
                msgX.BackColor = Color.White;
                btnYes.BackColor = Color.White;
                btnNo.BackColor = Color.White;
                lblCmd.BackColor = Color.White;
                msgX.ForeColor = Color.Black;
                btnYes.ForeColor = Color.Black;
                btnNo.ForeColor = Color.Black;
                lblCmd.ForeColor = Color.Black;
            }
            else
            {
                msgX.BackColor = Color.SteelBlue;
                lblCmd.BackColor = Color.SteelBlue;
                btnYes.BackColor = Color.SteelBlue;
                btnNo.BackColor = Color.SteelBlue;
                msgX.ForeColor = Color.White;
                btnYes.ForeColor = Color.White;
                btnNo.ForeColor = Color.White;
                lblCmd.ForeColor = Color.White;
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Selected = true;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Selected = false;
            this.Close();
        }
    }
}