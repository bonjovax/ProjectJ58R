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
    public partial class frmRptQuotation : Form
    {
        public frmRptQuotation()
        {
            InitializeComponent();
        }

        private Int32 quote_no;

        public Int32 Quote_no
        {
            get { return quote_no; }
            set { quote_no = value; }
        }

        private void frmRptQuotation_Load(object sender, EventArgs e)
        {
            Quotation rep = new Quotation();
            npos_dbDataSet ds = new npos_dbDataSet();
            quotation_storeTableAdapter adp = new quotation_storeTableAdapter();
            quotation_parkTableAdapter adp1 = new quotation_parkTableAdapter();
            adp.Fill(ds.quotation_store);
            adp1.Fill(ds.quotation_park);
            rep.SetDataSource(ds);
            rep.SetParameterValue("quotationParams", Quote_no);
            crystalReportViewer1.ReportSource = rep;
        }
    }
}