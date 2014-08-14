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
    public partial class frmRptCDrawer : Form
    {
        public frmRptCDrawer()
        {
            InitializeComponent();
        }
        private String dateParam;
        public String DateParam
        {
            get { return dateParam; }
            set { dateParam = value; }
        }
        private String terminalParam;

        public String TerminalParam
        {
            get { return terminalParam; }
            set { terminalParam = value; }
        }

        private void frmRptCDrawer_Load(object sender, EventArgs e)
        {
            rptCDrawer rep = new rptCDrawer();
            npos_dbDataSet ds = new npos_dbDataSet();
            pos_cdlogTableAdapter adp = new pos_cdlogTableAdapter();
            adp.Fill(ds.pos_cdlog);
            rep.SetDataSource(ds);
            rep.SetParameterValue("dateParam", Convert.ToDateTime(DateParam).ToString("yyyy-MM-dd"));
            rep.SetParameterValue("terminalParam", TerminalParam);
            crystalReportViewer1.ReportSource = rep;
        }
    }
}