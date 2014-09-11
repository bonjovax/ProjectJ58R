using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nPOSProj.VO
{
    class OrderVO
    {
        #region Order Class Accessors Core
        private String description;
        public String Description
        {
            get { return description; }
            set { description = value; }
        }
        private String ean;
        public String Ean
        {
            get { return ean; }
            set { ean = value; }
        }
        private Boolean wholesale;
        public Boolean Wholesale
        {
            get { return wholesale; }
            set { wholesale = value; }
        }
        private DAO.OrderDAO orderdao;
        private Int32 pos_orderno;
        public Int32 Pos_orderno
        {
            get { return pos_orderno; }
            set { pos_orderno = value; }
        }
        private Int32 pos_qty;
        public Int32 Pos_qty
        {
            get { return pos_qty; }
            set { pos_qty = value; }
        }
        private Double order_item_amount;
        public Double Order_item_amount
        {
            get { return order_item_amount; }
            set { order_item_amount = value; }
        }
        private Double pos_amt;
        public Double Pos_amt
        {
            get { return pos_amt; }
            set { pos_amt = value; }
        }
        private Double order_total_amt;
        public Double Order_total_amt
        {
            get { return order_total_amt; }
            set { order_total_amt = value; }
        }
        #endregion
        #region Quotation Accessors Core
        private String company;

        public String Company
        {
            get { return company; }
            set { company = value; }
        }
        #endregion

        public OrderVO() { }

        #region Ordering Information VO
        public void NewOrder()
        {
            orderdao = new DAO.OrderDAO();
            orderdao.newOrder();
        }
        public Int32 getON()
        {
            Int32 orderno = 0;
            orderdao = new DAO.OrderDAO();
            orderno = orderdao.askOrderNo();
            return orderno;
        }
        public String askEan()
        {
            String EAN = "";
            orderdao = new DAO.OrderDAO();
            EAN = orderdao.getEan(Description);
            return EAN;
        }
        public String askDescription()
        {
            String Description = "";
            orderdao = new DAO.OrderDAO();
            Description = orderdao.getDescription(Ean);
            return Description;
        }
        public Double askPriceByName()
        {
            Double Price = 0;
            orderdao = new DAO.OrderDAO();
            Price = orderdao.getPriceByName(Description, Wholesale);
            return Price;
        }
        public Double askPriceByEan()
        {
            Double Price = 0;
            orderdao = new DAO.OrderDAO();
            Price = orderdao.getPriceByEan(Ean, Wholesale);
            return Price;
        }
        //
        public String askEanKit()
        {
            String EAN = "";
            orderdao = new DAO.OrderDAO();
            EAN = orderdao.getEanKits(Description);
            return EAN;
        }
        public String askKitName()
        {
            String Kitname = "";
            orderdao = new DAO.OrderDAO();
            Kitname = orderdao.getKitname(Ean);
            return Kitname;
        }
        public Double askPriceByKitName()
        {
            Double Price = 0;
            orderdao = new DAO.OrderDAO();
            Price = orderdao.getPriceByKitName(Description, Wholesale);
            return Price;
        }
        public Double askPriceByEanKit()
        {
            Double Price = 0;
            orderdao = new DAO.OrderDAO();
            Price = orderdao.getPriceByEanKit(Ean, Wholesale);
            return Price;
        }
        //
        public Int32 askQtyByDescription()
        {
            Int32 qty = 0;
            orderdao = new DAO.OrderDAO();
            qty = orderdao.getQtyByDescription(Description);
            return qty;
        }
        public Int32 askQtyByEAN()
        {
            Int32 qty = 0;
            orderdao = new DAO.OrderDAO();
            qty = orderdao.getQtyByEAN(Ean);
            return qty;
        }
        public Int32 askQtyByKitName()
        {
            Int32 qty = 0;
            orderdao = new DAO.OrderDAO();
            qty = orderdao.getQtyByDescriptionKit(Description);
            return qty;
        }
        public Int32 askQtyEANKit()
        {
            Int32 qty = 0;
            orderdao = new DAO.OrderDAO();
            qty = orderdao.getQtyByEANKit(Ean);
            return qty;
        }
        //
        public Boolean askItemDescription()
        {
            Boolean check = false;
            orderdao = new DAO.OrderDAO();
            check = orderdao.checkingItemDescription(Description, Ean);
            return check;
        }
        public Boolean askItemEan()
        {
            Boolean check = false;
            orderdao = new DAO.OrderDAO();
            check = orderdao.checkingItemEan(Ean, Description);
            return check;
        }
        public Boolean askItemDescriptionKit()
        {
            Boolean check = false;
            orderdao = new DAO.OrderDAO();
            check = orderdao.checkItemDescriptionKit(Description, Ean);
            return check;
        }
        public Boolean askItemEanKit()
        {
            Boolean check = false;
            orderdao = new DAO.OrderDAO();
            check = orderdao.checkItemDescriptionKit(Description, Ean);
            return check;
        }
        #endregion
        #region Ordering Core VO
        public void Add()
        {
            orderdao = new DAO.OrderDAO();
            orderdao.ParkItem_Add(Pos_orderno, Ean, Pos_qty, Order_item_amount, Pos_amt);
        }
        public void UpdateSameItem()
        {
            orderdao = new DAO.OrderDAO();
            orderdao.ParkItem_Update(Pos_orderno, Ean, Pos_qty, Order_item_amount, Pos_amt);
        }
        public void VoidItem()
        {
            orderdao = new DAO.OrderDAO();
            orderdao.ParkItem_Void(Pos_qty, Pos_orderno, Ean);
        }
        public void UpdateTotal()
        {
            orderdao = new DAO.OrderDAO();
            orderdao.TotalAmtUpdate(Order_total_amt, Pos_orderno);
        }
        public void ReturnAndDeleteTrans()
        {
            orderdao = new DAO.OrderDAO();
            orderdao.ReturnAndDeleteItems(Pos_orderno, Ean, Pos_qty);
        }
        public void CancelTrans()
        {
            orderdao = new DAO.OrderDAO();
            orderdao.Cancel(Pos_orderno);
        }
        #endregion
        #region Ordering Retrieve Data VO
        public String[,] ReadParkedOrder()
        {
            orderdao = new DAO.OrderDAO();
            Int32 cunt = orderdao.OrderParkCount();
            String[,] bilat = new String[5, cunt];
            bilat = orderdao.ReadOrderPark();
            return bilat;
        }
        public String[,] ReadParkedOrderSearch()
        {
            orderdao = new DAO.OrderDAO();
            Int32 cunt = orderdao.OrderParkCountSearch(Pos_orderno);
            String[,] bilat = new String[5, cunt];
            bilat = orderdao.ReadOrderParkSearch(Pos_orderno);
            return bilat;
        }
        #endregion
        #region Ordering Park Retrieval VO
        public String[,] ReadParkItem()
        {
            orderdao = new DAO.OrderDAO();
            Int32 cunt = orderdao.ParkCount(Pos_orderno);
            String[,] tablit = new String[5, cunt];
            tablit = orderdao.ReadPark(Pos_orderno);
            return tablit;
        }
        public String[,] ReadParkItemKit()
        {
            orderdao = new DAO.OrderDAO();
            Int32 cunt = orderdao.ParkCountKit(Pos_orderno);
            String[,] tablit = new String[5, cunt];
            tablit = orderdao.ReadParkKit(Pos_orderno);
            return tablit;
        }
        #endregion
        // Quotation
        #region Quotation Core VO
        public String[,] ReadCompanySearchQuotex()
        {
            orderdao = new DAO.OrderDAO();
            Int32 cunt = orderdao.QuoteCompanyCount();
            String[,] tablit = new String[1, cunt];
            tablit = orderdao.ReadCompanyNameQuote();
            return tablit;
        }
        public String askCustomerCode()
        {
            String custcode;
            orderdao = new DAO.OrderDAO();
            custcode = orderdao.getCustomerCode(Company);
            return custcode;
        }
        public String askAddress()
        {
            String address;
            orderdao = new DAO.OrderDAO();
            address = orderdao.getAddress(Company);
            return address;
        }
        #endregion
    }
}