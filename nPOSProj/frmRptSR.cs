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
    public partial class frmRptSR : Form
    {
        public frmRptSR()
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

        private void frmRptSR_Load(object sender, EventArgs e)
        {
            rptSR rep = new rptSR();
            npos_dbDataSet ds = new npos_dbDataSet();
            pos_storeTableAdapter adp = new pos_storeTableAdapter();
            adp.Fill(ds.pos_store);
            rep.SetDataSource(ds);
            rep.SetParameterValue("dateParam", Convert.ToDateTime(DateParam).ToString("yyyy-MM-dd"));
            rep.SetParameterValue("terminalParam", TerminalParam);
            crystalReportViewer1.ReportSource = rep;
        }
    }
}