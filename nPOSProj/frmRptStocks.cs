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
    public partial class frmRptStocks : Form
    {
        public frmRptStocks()
        {
            InitializeComponent();
        }

        private void frmRptStocks_Load(object sender, EventArgs e)
        {
            rptStocks rep = new rptStocks();
            npos_dbDataSet ds = new npos_dbDataSet();
            DisplayStocksTableAdapter adp = new DisplayStocksTableAdapter();
            rep.SetDataSource(ds);
            adp.Fill(ds.DisplayStocks);
            crystalReportViewer1.ReportSource = rep;
        }
    }
}