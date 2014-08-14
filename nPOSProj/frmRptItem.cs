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
    public partial class frmRptItem : Form
    {
        public frmRptItem()
        {
            InitializeComponent();
        }

        private void frmRptItem_Load(object sender, EventArgs e)
        {
            rptII rep = new rptII();
            npos_dbDataSet ds = new npos_dbDataSet();
            Display_iiTableAdapter adp = new Display_iiTableAdapter();
            rep.SetDataSource(ds);
            adp.Fill(ds.Display_ii);
            crystalReportViewer1.ReportSource = rep;
        }
    }
}