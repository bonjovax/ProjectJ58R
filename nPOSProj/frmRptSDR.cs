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
    public partial class frmRptSDR : Form
    {
        public frmRptSDR()
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

        private void frmRptSDR_Load(object sender, EventArgs e)
        {
            rptSDR rep = new rptSDR();
            npos_dbDataSet ds = new npos_dbDataSet();
            pos_parkTableAdapter adp = new pos_parkTableAdapter();
            adp.Fill(ds.pos_park);
            rep.SetDataSource(ds);
            rep.SetParameterValue("dateParam", Convert.ToDateTime(DateParam).ToString("yyyy-MM-dd"));
            rep.SetParameterValue("terminalParam", TerminalParam);
            crystalReportViewer1.ReportSource = rep;
        }
    }
}
