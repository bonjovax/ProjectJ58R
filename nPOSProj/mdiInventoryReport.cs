using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace nPOSProj
{
    public partial class mdiInventoryReport : Form
    {
        public mdiInventoryReport()
        {
            InitializeComponent();
        }

        private void btnPrintSR_Click(object sender, EventArgs e)
        {
            frmRptStocksR stockr = new frmRptStocksR();
            stockr.ShowDialog();
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            frmRptItem rptitem = new frmRptItem();
            rptitem.ShowDialog();
        }

        private void btnKits_Click(object sender, EventArgs e)
        {
            frmRptIkits ikits = new frmRptIkits();
            ikits.ShowDialog();
        }

        private void btnStocks_Click(object sender, EventArgs e)
        {
            frmRptStocks stocks = new frmRptStocks();
            stocks.ShowDialog();
        }
    }
}