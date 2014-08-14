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
    public partial class frmRptStocksR : Form
    {
        public frmRptStocksR()
        {
            InitializeComponent();
        }

        private void frmRptStocksR_Load(object sender, EventArgs e)
        {
            rptStocksReport rep = new rptStocksReport();
            npos_dbDataSet ds = new npos_dbDataSet();
            itemstockRTableAdapter adp = new itemstockRTableAdapter();
            rep.SetDataSource(ds);
            adp.Fill(ds.itemstockR);
            crystalReportViewer1.ReportSource = rep;
        }
    }
}