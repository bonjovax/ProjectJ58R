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
    public partial class frmRptSalesOrder : Form
    {
        public frmRptSalesOrder()
        {
            InitializeComponent();
        }

        private Int32 order_no;

        public Int32 Order_no
        {
            get { return order_no; }
            set { order_no = value; }
        }

        private void frmRptSalesOrder_Load(object sender, EventArgs e)
        {
            SalesOrder rep = new SalesOrder();
            npos_dbDataSet ds = new npos_dbDataSet();
            pos_parkTableAdapter adp = new pos_parkTableAdapter();
            print_orderTableAdapter adp1 = new print_orderTableAdapter();
            order_storeTableAdapter adp2 = new order_storeTableAdapter();
            adp.Fill(ds.pos_park);
            adp1.Fill(ds.print_order);
            adp2.Fill(ds.order_store);
            rep.SetDataSource(ds);
            rep.SetParameterValue("orderParams", Order_no);
            crystalReportViewer1.ReportSource = rep;
        }

        private void SalesOrder1_InitReport(object sender, EventArgs e)
        {

        }

    }
}
