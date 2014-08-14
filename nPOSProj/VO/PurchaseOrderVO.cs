using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nPOSProj.VO
{
    class PurchaseOrderVO
    {
        private DAO.PurchaseOrderDAO podao;
        private Int32 _po_no;
        private String _po_date;
        private String _po_time;
        private String _supplier_code;
        private String _supplier_name;
        private String _user_name;
        private String _stock_name;
        private String _stock_code;
        private Int32 _order_quantity; 
        private String _order_uom;
        private Double _order_unitcost;
        private Double _order_amount;
        private Double _po_total_amt;
        private String _po_warehouse;
        private String _po_carrier;
        private String _po_remarks;
        //
        private String _old_stock_code; //for item replacement

        public PurchaseOrderVO()
        {
        }

        public Int32 po_no
        {
            get { return _po_no; }
            set { _po_no = value; }
        }
        public String po_date
        {
            get { return _po_date; }
            set { _po_date = value; }
        }
        public String po_time
        {
            get { return _po_time; }
            set { _po_time = value; }
        }
        public String supplier_code
        {
            get { return _supplier_code; }
            set { _supplier_code = value; }
        }
        public String supplier_name
        {
            get { return _supplier_name; }
            set { _supplier_name = value; }
        }
        public String user_name
        {
            get { return _user_name; }
            set { _user_name = value; }
        }
        public String stock_code
        {
            get { return _stock_code; }
            set { _stock_code = value; }
        }
        public String stock_name
        {
            get { return _stock_name; }
            set { _stock_name = value; }
        }
        public Int32 order_quantity
        {
            get { return _order_quantity; }
            set { _order_quantity = value; }
        }
        public String order_uom
        {
            get { return _order_uom; }
            set { _order_uom = value; }
        }
        public Double order_unitcost
        {
            get { return _order_unitcost; }
            set { _order_unitcost = value; }
        }
        public Double order_amount
        {
            get { return _order_amount; }
            set { _order_amount = value; }
        }
        public Double po_total_amt
        {
            get { return _po_total_amt; }
            set { _po_total_amt = value; }
        }
        public String po_warehouse
        {
            get { return _po_warehouse; }
            set { _po_warehouse = value; }
        }
        public String po_carrier
        {
            get { return _po_carrier; }
            set { _po_carrier = value; }
        }
        public String po_remarks
        {
            get { return _po_remarks; }
            set { _po_remarks = value; }
        }
        public String old_stock_code
        {
            get { return _old_stock_code; }
            set { _old_stock_code = value; }
        }
        
        public Int32 askPOno()
        {
            Int32 POno;
            podao = new DAO.PurchaseOrderDAO();
            podao.postPONumber();
            POno = podao.postPONumber();
            return POno + 1;
        }

        public String askSupplierName()
        {
            String supplier_name;
            podao = new DAO.PurchaseOrderDAO();
            podao.katsSupplierName(supplier_code);
            supplier_name = podao.katsSupplierName(supplier_code);
            return supplier_name;
        }
        public String askSupplierCode()
        {
            String supplier_code;
            podao = new DAO.PurchaseOrderDAO();
            podao.katsSupplierCode(supplier_name);
            supplier_code = podao.katsSupplierCode(supplier_name);
            return supplier_code;
        }
        public String askStockCode()
        {
            String stock_code;
            podao = new DAO.PurchaseOrderDAO();
            podao.katsStockCode(stock_name, supplier_code);
            stock_code = podao.katsStockCode(stock_name, supplier_code);
            return stock_code;
        }
        public String askStockName()
        {
            String stock_name;
            podao = new DAO.PurchaseOrderDAO();
            podao.katsStockName(stock_code, supplier_code);
            stock_name = podao.katsStockName(stock_code, supplier_code);
            return stock_name;
        }
        public Double askStockPriceStockCode()
        {
            Double price;
            podao = new DAO.PurchaseOrderDAO();
            podao.katsStockPrice(stock_code, supplier_code);
            price = podao.katsStockPrice(stock_code, supplier_code);
            return price;
        }
        public Double askStockPriceStockName()
        {
            Double price;
            podao = new DAO.PurchaseOrderDAO();
            podao.katsStockPrice(stock_code, supplier_code);
            price = podao.katsStockPriceN(stock_name, supplier_code);
            return price;
        }
        public String askUOM()
        {
            String UOM;
            podao = new DAO.PurchaseOrderDAO();
            podao.katsUOM(stock_code, supplier_code);
            UOM = podao.katsUOM(stock_code, supplier_code);
            return UOM;
        }
        public String askUOM_N()
        {
            String UOM;
            podao = new DAO.PurchaseOrderDAO();
            podao.katsUOM(stock_code, supplier_code);
            UOM = podao.katsUOM_N(stock_name, supplier_code);
            return UOM;
        }
        public void PO_Issue()
        {
            podao = new DAO.PurchaseOrderDAO();
            podao.IssuePO(po_no, po_date, po_time, supplier_code, po_remarks, user_name);
        }
        public void PO_Update()
        {
            podao = new DAO.PurchaseOrderDAO();
            podao.UpdatePO(po_no, supplier_code, po_warehouse, po_carrier, po_remarks, user_name);
        }
        public void PO_Delete()
        {
            podao = new DAO.PurchaseOrderDAO();
            podao.DeletePO(po_no, supplier_code);
        }
        public void OrderItemsToPO()
        {
            podao = new DAO.PurchaseOrderDAO();
            podao.OrderPO(po_no, order_quantity, order_uom, stock_code, stock_name, order_unitcost, order_amount);
        }
        public void UpdateOrderItemsToPO()
        {
            podao = new DAO.PurchaseOrderDAO();
            podao.UpdateOrderPO(po_no, order_quantity, order_uom, stock_code, old_stock_code, stock_name, order_unitcost, order_amount);
        }
        public void RemoveOrderItemsInPO()
        {
            podao = new DAO.PurchaseOrderDAO();
            podao.DeleteOrderPO(po_no, stock_code);
        }

        public void updateTotalAmountMain()
        {
            podao = new DAO.PurchaseOrderDAO();
            podao.UpdateAmountToMainTable(po_no, supplier_code, po_total_amt);
        }
        public void TogglePrint()
        {
            podao = new DAO.PurchaseOrderDAO();
            podao.TriggerPrint(po_no, po_date);
        }
        public void ReversePrint()
        {
            podao = new DAO.PurchaseOrderDAO();
            podao.UndoPrint(po_no, po_date);
        }
    }
}