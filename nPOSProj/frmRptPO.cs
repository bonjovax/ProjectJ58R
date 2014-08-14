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
    public partial class frmRptPO : Form
    {
        private Int32 _po_no;
        private String _Dates;
        public frmRptPO()
        {
            InitializeComponent();
        }
        public Int32 po_no
        {
            get { return _po_no; }
            set { _po_no = value; }
        }
        public String Dates
        {
            get { return _Dates; }
            set { _Dates = value; }
        }

        private void frmRptPO_Load(object sender, EventArgs e)
        {
            PO rep = new PO();
            npos_dbDataSet ds = new npos_dbDataSet();
            po_order_listTableAdapter adp = new po_order_listTableAdapter();
            po_orderTableAdapter adp1 = new po_orderTableAdapter();
            adp.Fill(ds.po_order_list);
            adp1.FillByPO(ds.po_order, Convert.ToDateTime(Dates), po_no);
            rep.SetDataSource(ds);
            rep.SetParameterValue("po_no", po_no);
            crystalReportViewer1.ReportSource = rep;
        }
    }
}