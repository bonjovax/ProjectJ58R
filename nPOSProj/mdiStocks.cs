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
    public partial class mdiStocks : Form
    {
        private VO.InventoryVO ivo;
        private Decimal total = 0.0M;
        private VO.ItemVO items = new VO.ItemVO();
        public mdiStocks()
        {
            InitializeComponent();
        }

        private void trapDGV1()
        {
            if (dataGridView1.RowCount == 0)
            {
                dataGridView1.Enabled = false;
            }
            else
                dataGridView1.Enabled = true;
        }
        private void trapDGV2()
        {
            if (dataGridView2.RowCount == 0)
            {
                dataGridView2.Enabled = false;
            }
            else
                dataGridView2.Enabled = true;
        }

        private void mdiStocks_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'npos_dbDataSet1.inventory_warehouse' table. You can move, or remove it, as needed.
            this.inventory_warehouseTableAdapter.Fill(this.npos_dbDataSet1.inventory_warehouse);
            // TODO: This line of code loads data into the 'npos_dbDataSet1.inventory_category' table. You can move, or remove it, as needed.
            this.inventory_categoryTableAdapter.Fill(this.npos_dbDataSet1.inventory_category);
            // TODO: This line of code loads data into the 'npos_dbDataSet1.inventory_supplier' table. You can move, or remove it, as needed.
            this.inventory_supplierTableAdapter.Fill(this.npos_dbDataSet1.inventory_supplier);
            // TODO: This line of code loads data into the 'npos_dbDataSet1.inventory_stocks' table. You can move, or remove it, as needed.
            this.inventory_stocksTableAdapter.Fill(this.npos_dbDataSet1.inventory_stocks);
            // TODO: This line of code loads data into the 'npos_dbDataSet.inventory_warehouse' table. You can move, or remove it, as needed.
            this.inventory_warehouseTableAdapter.Fill(this.npos_dbDataSet.inventory_warehouse);
            trapDGV1();
            trapDGV2();
        }

        private void clear()
        {
            txtBoxWCode.Clear();
            txtBoxWName.Clear();
        }

        private void txtBoxWCode_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxWCode.Text != "" && txtBoxWName.Text != "")
            {
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }

        private void txtBoxWName_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxWCode.Text != "" && txtBoxWName.Text != "")
            {
                btnAdd.Enabled = true;
            }
            else
                btnAdd.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Do You Wish To Add Warehouse?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    this.inventory_warehouseTableAdapter.InsertWarehouse(txtBoxWCode.Text, txtBoxWName.Text);
                    this.inventory_warehouseTableAdapter.Fill(this.npos_dbDataSet.inventory_warehouse);
                    clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Warehouse Code Existed! or Check Database Server!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                trapDGV1();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.inventory_warehouseTableAdapter.UpdateWarehouse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                btnUpdate.Enabled = false;
                this.inventory_warehouseTableAdapter.Fill(this.npos_dbDataSet1.inventory_warehouse);
                cBoxWarehouse.Invalidate();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
            trapDGV1();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Do You Wish To Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            this.inventory_warehouseTableAdapter.DeleteWarehouse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                            dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
                            btnDelete.Enabled = false;
                        }
                    }
                    trapDGV1();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.ExitThread();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void clearStockSection()
        {
            txtBoxStockCode.Clear();
            txtBoxStockName.Clear();
            txtBoxQty.Clear();
            txtBoxUOM.Clear();
            l1.Text = "_";
            l2.Text = "_";
            l3.Text = "_";
            txtBoxQty.Text = "0";
            txtBoxCPrice.Text = "0.00";
            txtBoxSPrice.Text = "0.00";
            txtBoxTPrice.Text = "0.00";
            txtBoxStockCode.Focus();
        }

        private void btnSClear_Click(object sender, EventArgs e)
        {
            clearStockSection();
        }

        private void btnSAdd_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Do You Wish To Add Stocks?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    this.inventory_stocksTableAdapter.InsertStocks(txtBoxStockCode.Text, txtBoxStockName.Text, l1.Text, l2.Text, l3.Text, Convert.ToInt32(txtBoxQty.Text), txtBoxUOM.Text, Convert.ToDecimal(txtBoxCPrice.Text), Convert.ToDecimal(txtBoxSPrice.Text), Convert.ToDecimal(txtBoxTPrice.Text));
                    this.inventory_stocksTableAdapter.InsertAlsoItem(txtBoxStockCode.Text, Convert.ToDecimal(txtBoxSPrice.Text));
                    clearStockSection();
                    this.inventory_stocksTableAdapter.Fill(this.npos_dbDataSet1.inventory_stocks);
                }
                catch (Exception)
                {
                    MessageBox.Show("Stock Code Existed! or Check Database Server!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                trapDGV2();
            }
        }

        private void cBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            ivo = new VO.InventoryVO();
            ivo.supplier_name = cBoxSupplier.Text;
            ivo.patchSupplierCode();
            l1.Text = ivo.patchSupplierCode();
        }

        private void cBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ivo = new VO.InventoryVO();
            ivo.cat_description = cBoxCategory.Text;
            ivo.patchCategoryCode();
            l2.Text = ivo.patchCategoryCode();
        }

        private void cBoxWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            ivo = new VO.InventoryVO();
            ivo.warehouse_name = cBoxWarehouse.Text;
            ivo.patchWarehouseCode();
            l3.Text = ivo.patchWarehouseCode();
        }

        private void txtBoxStockCode_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxStockCode.Text != "" && txtBoxStockName.Text != "" && l1.Text != "_" && l2.Text != "_" && l3.Text != "_" && txtBoxQty.Text != "" && txtBoxUOM.Text != "" && txtBoxCPrice.Text != "0.00" && txtBoxCPrice.Text != "" && txtBoxSPrice.Text != "0.00" && txtBoxSPrice.Text != "" && txtBoxTPrice.Text != "0.00" && txtBoxTPrice.Text != "")
            {
                btnSAdd.Enabled = true;
            }
            else
                btnSAdd.Enabled = false;
        }

        private void txtBoxStockName_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxStockCode.Text != "" && txtBoxStockName.Text != "" && l1.Text != "_" && l2.Text != "_" && l3.Text != "_" && txtBoxQty.Text != "" && txtBoxUOM.Text != "" && txtBoxCPrice.Text != "0.00" && txtBoxCPrice.Text != "" && txtBoxSPrice.Text != "0.00" && txtBoxSPrice.Text != "" && txtBoxTPrice.Text != "0.00" && txtBoxTPrice.Text != "")
            {
                btnSAdd.Enabled = true;
            }
            else
                btnSAdd.Enabled = false;
        }

        private void txtBoxQty_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxStockCode.Text != "" && txtBoxStockName.Text != "" && l1.Text != "_" && l2.Text != "_" && l3.Text != "_" && txtBoxQty.Text != "" && txtBoxUOM.Text != "" && txtBoxCPrice.Text != "0.00" && txtBoxCPrice.Text != "" && txtBoxSPrice.Text != "0.00" && txtBoxSPrice.Text != "" && txtBoxTPrice.Text != "0.00" && txtBoxTPrice.Text != "")
            {
                btnSAdd.Enabled = true;
            }
            else
            {
                btnSAdd.Enabled = false;
            }
            if (txtBoxQty.Text != null && txtBoxQty.Text != "" && txtBoxQty.Text != "0")
            {
                ComputeQtyAndSelling();
            }
            else
            {
                txtBoxTPrice.Text = "0.00";
                txtBoxQty.Text = "0";
            }
        }

        private void txtBoxUOM_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxStockCode.Text != "" && txtBoxStockName.Text != "" && l1.Text != "_" && l2.Text != "_" && l3.Text != "_" && txtBoxQty.Text != "" && txtBoxUOM.Text != "" && txtBoxCPrice.Text != "0.00" && txtBoxCPrice.Text != "" && txtBoxSPrice.Text != "0.00" && txtBoxSPrice.Text != "" && txtBoxTPrice.Text != "0.00" && txtBoxTPrice.Text != "")
            {
                btnSAdd.Enabled = true;
            }
            else
                btnSAdd.Enabled = false;
        }

        private void txtBoxCPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxStockCode.Text != "" && txtBoxStockName.Text != "" && l1.Text != "_" && l2.Text != "_" && l3.Text != "_" && txtBoxQty.Text != "" && txtBoxUOM.Text != "" && txtBoxCPrice.Text != "0.00" && txtBoxCPrice.Text != "" && txtBoxSPrice.Text != "0.00" && txtBoxSPrice.Text != "" && txtBoxTPrice.Text != "0.00" && txtBoxTPrice.Text != "")
            {
                btnSAdd.Enabled = true;
            }
            else
            {
                btnSAdd.Enabled = false;
            }
            if (txtBoxCPrice.Text != null && txtBoxCPrice.Text != "" && txtBoxCPrice.Text != "0.00" && txtBoxCPrice.Text != "0")
            {

            }
            else
                txtBoxCPrice.Text = "0.00";
        }

        private void txtBoxSPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxStockCode.Text != "" && txtBoxStockName.Text != "" && l1.Text != "_" && l2.Text != "_" && l3.Text != "_" && txtBoxQty.Text != "" && txtBoxUOM.Text != "" && txtBoxCPrice.Text != "0.00" && txtBoxCPrice.Text != "" && txtBoxSPrice.Text != "0.00" && txtBoxSPrice.Text != "" && txtBoxTPrice.Text != "0.00" && txtBoxTPrice.Text != "")
            {
                btnSAdd.Enabled = true;
            }
            else
            {
                btnSAdd.Enabled = false;
            }
            if (txtBoxSPrice.Text != "0.00" && txtBoxSPrice.Text != "0" && txtBoxSPrice.Text != "" && txtBoxSPrice.Text != null)
            {
                ComputerSellingQty();
                txtBoxQty.ReadOnly = false;
            }
            else
            {
                txtBoxQty.ReadOnly = true;
                txtBoxQty.Text = "0";
                txtBoxSPrice.Text = "0.00";
                txtBoxTPrice.Text = "0.00";
            }
        }

        private void txtBoxTPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxStockCode.Text != "" && txtBoxStockName.Text != "" && l1.Text != "_" && l2.Text != "_" && l3.Text != "_" && txtBoxQty.Text != "" && txtBoxUOM.Text != "" && txtBoxCPrice.Text != "0.00" && txtBoxCPrice.Text != "" && txtBoxSPrice.Text != "0.00" && txtBoxSPrice.Text != "" && txtBoxTPrice.Text != "0.00" && txtBoxTPrice.Text != "")
            {
                btnSAdd.Enabled = true;
            }
            else
            {
                btnSAdd.Enabled = false;
            }
        }

        private void btnSUpdate_Click(object sender, EventArgs e)
        {
            ivo = new VO.InventoryVO();
            String S;
            String C;
            String W;
            if (Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[1].Value.ToString()) >= 0 && Convert.ToDecimal(dataGridView2.SelectedRows[0].Cells[5].Value.ToString()) >= 0 && Convert.ToDecimal(dataGridView2.SelectedRows[0].Cells[6].Value.ToString()) >= 0 && Convert.ToDecimal(dataGridView2.SelectedRows[0].Cells[7].Value.ToString()) >= 0)
            {
                try
                {
                    ivo.supplier_name = dataGridView2.SelectedRows[0].Cells[8].Value.ToString();
                    ivo.cat_description = dataGridView2.SelectedRows[0].Cells[9].Value.ToString();
                    ivo.warehouse_name = dataGridView2.SelectedRows[0].Cells[10].Value.ToString();
                    S = ivo.patchSupplierCode();
                    C = ivo.patchCategoryCode();
                    W = ivo.patchWarehouseCode();
                    updateCompute();
                    this.inventory_stocksTableAdapter.UpdateStocks(dataGridView2.SelectedRows[0].Cells[3].Value.ToString(), S, C, W, Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[1].Value.ToString()), dataGridView2.SelectedRows[0].Cells[4].Value.ToString(), Convert.ToDecimal(dataGridView2.SelectedRows[0].Cells[5].Value.ToString()), Convert.ToDecimal(dataGridView2.SelectedRows[0].Cells[6].Value.ToString()), total, Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value.ToString()), dataGridView2.SelectedRows[0].Cells[2].Value.ToString());
                    btnSUpdate.Enabled = false;
                    this.inventory_stocksTableAdapter.Fill(this.npos_dbDataSet1.inventory_stocks);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Check Your Encoded Data or Check Database Server is Active!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                trapDGV2();
            }
            else
                MessageBox.Show("Negative Value is not allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void updateCompute()
        {
            if (Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[1].Value.ToString()) >= 0 && Convert.ToDecimal(dataGridView2.SelectedRows[0].Cells[6].Value.ToString()) >= 0)
            {
                try
                {
                    Decimal qty = 0.0M;
                    Decimal selling = 0.0M;
                    qty = Convert.ToDecimal(dataGridView2.SelectedRows[0].Cells[1].Value.ToString());
                    selling = Convert.ToDecimal(dataGridView2.SelectedRows[0].Cells[6].Value.ToString());
                    total = qty * selling;
                }
                catch (Exception)
                {
                    MessageBox.Show("Alphanumericals is not allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSUpdate.Enabled = true;
            btnSDelete.Enabled = true;
        }

        private void ComputeQtyAndSelling()
        {
            try
            {
                Decimal qty = 0.0M;
                Decimal sprice = 0.0M;
                qty = Convert.ToDecimal(txtBoxQty.Text);
                sprice = Convert.ToDecimal(txtBoxSPrice.Text);
                Decimal Total = qty * sprice;
                txtBoxTPrice.Text = Total.ToString("#,###,##0.00");
            }
            catch (Exception)
            {
                MessageBox.Show("Alphanumericals is not allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxQty.Text = "0";
            }
        }
        private void ComputerSellingQty()
        {
            try
            {
                Decimal qty;
                Decimal sprice;
                qty = Convert.ToDecimal(txtBoxQty.Text);
                sprice = Convert.ToDecimal(txtBoxSPrice.Text);
                Decimal Total = sprice * qty;
                txtBoxTPrice.Text = Total.ToString("#,###,##0.00");
            }
            catch (Exception)
            {
                MessageBox.Show("Alphanumericals is not allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxSPrice.Text = "0.00";
            }
        }

        private void btnSDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Do You Wish To Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewCell oneCell in dataGridView2.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            this.inventory_stocksTableAdapter.DeleteStocks(dataGridView2.SelectedRows[0].Cells[2].Value.ToString(), Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value.ToString()));
                            this.inventory_stocksTableAdapter.DeleteAlsoItemQuery(dataGridView2.SelectedRows[0].Cells[2].Value.ToString());
                            dataGridView2.Rows.RemoveAt(oneCell.RowIndex);
                            btnSDelete.Enabled = false;
                        }
                    }
                    trapDGV2();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Check your Database Server Connection", "Database Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.ExitThread();
                }
            }
        }

        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Alphanumeric Values will not be consider!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtBoxTransferQty_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxTransferQty.Text != "")
            {
                btnTransfer.Enabled = true;
            }
            else
                btnTransfer.Enabled = false;
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtBoxTransferQty.Text) >= 0)
                {

                    Int32 finale = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[1].Value) - Convert.ToInt32(txtBoxTransferQty.Text);
                    dataGridView2.SelectedRows[0].Cells[1].Value = finale;
                    Double recal = finale * Convert.ToDouble(dataGridView2.SelectedRows[0].Cells[6].Value);
                    dataGridView2.SelectedRows[0].Cells[7].Value = recal;
                    txtBoxTransferQty.ReadOnly = true;
                    btnTransfer.Enabled = false;
                    items.item_quantity = Convert.ToInt32(txtBoxTransferQty.Text);
                    items.stock_code = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                    items.TrasferStockToItem();
                    txtBoxTransferQty.Clear();
                }
                else
                    MessageBox.Show("Negative Value will not be consider!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Check your Input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBoxTransferQty.ReadOnly = false;
            btnTransfer.Enabled = true;
            txtBoxTransferQty.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Stocks");
            saveFileDialog1.DefaultExt = ".xml";
            saveFileDialog1.FileName = "Export";
            saveFileDialog1.Filter = "Extensible Markup Language (*.xml)|*.xml";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < dataGridView2.ColumnCount; i++)
                {
                    dt.Columns.Add(dataGridView2.Columns[i].Name, typeof(System.String));
                }

                DataRow dickrow;
                int cols = dataGridView2.Columns.Count;
                foreach (DataGridViewRow drow in this.dataGridView2.Rows)
                {
                    dickrow = dt.NewRow();
                    for (int i = 0; i <= cols - 1; i++)
                    {
                        dickrow[i] = drow.Cells[i].Value;
                    }
                    dt.Rows.Add(dickrow);
                }
                dt.WriteXml(saveFileDialog1.FileName);
            }
        }

        private void txtBoxCPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtBoxSPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtBoxQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtBoxTransferQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text != "")
            {
                this.inventory_stocksTableAdapter.FillBy(this.npos_dbDataSet1.inventory_stocks, txtBoxSearch.Text);
            }
            else
                this.inventory_stocksTableAdapter.Fill(this.npos_dbDataSet1.inventory_stocks);
        }
    }
}