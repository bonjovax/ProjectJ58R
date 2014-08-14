using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace nPOSProj
{
    public partial class mdiPO : Form
    {
        public String DatePass { get; set; }
        
        public mdiPO()
        {
            InitializeComponent();
        }

        private void mdiPO_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'npos_dbDataSet.po_order' table. You can move, or remove it, as needed.
            this.po_orderTableAdapter.Fill(this.npos_dbDataSet.po_order, Convert.ToDateTime(dateTimePicker1.Text));
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (mPOrder newPO = new mPOrder())
            {
                newPO.ShowDialog();
                var poDate = newPO.PurchaseOrderDate;
                this.po_orderTableAdapter.Fill(this.npos_dbDataSet.po_order, Convert.ToDateTime(poDate));
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.po_orderTableAdapter.Fill(this.npos_dbDataSet.po_order, Convert.ToDateTime(dateTimePicker1.Text));
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            using (mEditPO edit = new mEditPO())
            {
                try
                {
                    edit.orderPO(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                    edit.ShowDialog();
                    var poDate = edit.PurchaseOrderDate;
                    this.po_orderTableAdapter.Fill(this.npos_dbDataSet.po_order, Convert.ToDateTime(poDate));
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            using (mFilter filter = new mFilter())
            {
                try
                {
                    filter.ShowDialog();
                    var Warehouse = filter.Warehouse;
                    var Supplier = filter.Supplier;
                    this.po_orderTableAdapter.FillByFilter(this.npos_dbDataSet.po_order, Supplier, Warehouse);
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (mSearch search = new mSearch())
            {
                try
                {
                    search.ShowDialog();
                    var supcode = search.supcode;
                    this.po_orderTableAdapter.FillBySupplier(this.npos_dbDataSet.po_order, supcode);
                }
                catch (Exception)
                {

                }
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            btnPrint.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Do You Want to Delete This P.O?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlgResult == DialogResult.Yes)
            {
                this.po_orderTableAdapter.DeleteQueryMainPO(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value), dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                this.po_orderTableAdapter.DeleteQueryFromPOList(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                btnDelete.Enabled = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (frmRptPO PO = new frmRptPO())
            {
                VO.PurchaseOrderVO pov = new VO.PurchaseOrderVO();
                try
                {
                    DateTime raw = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[1].Value);
                    Int32 po_no = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    PO.Dates = raw.ToString("yyyy-MM-dd");
                    PO.po_no = po_no;
                    PO.ShowDialog();
                    pov.po_no = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    pov.po_date = raw.ToString("yyyy-MM-dd");
                    pov.TogglePrint();
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    btnPrint.Enabled = false;
                }
                catch (Exception)
                {
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }
    }
}