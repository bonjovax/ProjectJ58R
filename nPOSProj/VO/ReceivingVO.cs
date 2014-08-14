using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nPOSProj.VO
{
    class ReceivingVO
    {
        private Int32 _po_no;
        private String _stock_code;
        private Int32 _quantity;
        private String _po_ref;
        private DAO.ReceivingDAO rdao;

        public ReceivingVO()
        {

        }

        public Int32 po_no
        {
            get { return _po_no; }
            set { _po_no = value; }
        }
        public String stock_code
        {
            get { return _stock_code; }
            set { _stock_code = value; }
        }
        public Int32 quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public String po_ref
        {
            get { return _po_ref; }
            set { _po_ref = value; }
        }

        public void ReceiveStocks()
        {
            rdao = new DAO.ReceivingDAO();
            rdao.Receive(po_no, stock_code, quantity);
        }
        public Int32 askQty()
        {
            Int32 qty;
            rdao = new DAO.ReceivingDAO();
            rdao.aQuantity(stock_code, po_no);
            qty = rdao.aQuantity(stock_code, po_no);
            return qty;
        }
        public void TriggerStatus()
        {
            rdao = new DAO.ReceivingDAO();
            rdao.Trigger(po_no);
        }
        public void UpdateReferenceNo()
        {
            rdao = new DAO.ReceivingDAO();
            rdao.UpdateR(po_ref, po_no);
        }
    }
}