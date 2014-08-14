using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using nPOSProj.npos_dbDataSetTableAdapters;

namespace nPOSProj
{
    public partial class frmRptIkits : Form
    {
        public frmRptIkits()
        {
            InitializeComponent();
        }

        private void frmRptIkits_Load(object sender, EventArgs e)
        {
            rptiKits rep = new rptiKits();
            npos_dbDataSet ds = new npos_dbDataSet();
            DisplayKitsTableAdapter adp = new DisplayKitsTableAdapter();
            rep.SetDataSource(ds);
            adp.Fill(ds.DisplayKits);
            crystalReportViewer1.ReportSource = rep;
        }
    }
}