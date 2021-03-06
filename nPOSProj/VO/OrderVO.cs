﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nPOSProj.VO
{
    class OrderVO
    {
        #region Order Class Accessors Core
        private Int32 order_no;
        public Int32 Order_no
        {
            get { return order_no; }
            set { order_no = value; }
        }
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
        private Int32 pos_orno;
        public Int32 Pos_orno
        {
            get { return pos_orno; }
            set { pos_orno = value; }
        }
        private String pos_terminal;
        public String Pos_terminal
        {
            get { return pos_terminal; }
            set { pos_terminal = value; }
        }
        private Double pos_vatable;
        public Double Pos_vatable
        {
            get { return pos_vatable; }
            set { pos_vatable = value; }
        }
        private Double pos_vex;
        public Double Pos_vex
        {
            get { return pos_vex; }
            set { pos_vex = value; }
        }
        private Double pos_vatz;
        public Double Pos_vatz
        {
            get { return pos_vatz; }
            set { pos_vatz = value; }
        }
        private Double pos_tax_perc;
        public Double Pos_tax_perc
        {
            get { return pos_tax_perc; }
            set { pos_tax_perc = value; }
        }
        private Double pos_tax_amt;
        public Double Pos_tax_amt
        {
            get { return pos_tax_amt; }
            set { pos_tax_amt = value; }
        }
        private Double pos_total_amt;
        public Double Pos_total_amt
        {
            get { return pos_total_amt; }
            set { pos_total_amt = value; }
        }
        #endregion
        #region Quotation Accessors Core
        private String company;

        public String Company
        {
            get { return company; }
            set { company = value; }
        }

        private String quote_custcode;

        public String Quote_custcode
        {
            get { return quote_custcode; }
            set { quote_custcode = value; }
        }

        private String quote_customer;

        public String Quote_customer
        {
            get { return quote_customer; }
            set { quote_customer = value; }
        }

        private String quote_address;

        public String Quote_address
        {
            get { return quote_address; }
            set { quote_address = value; }
        }
        private Int32 quotation_no;

        public Int32 Quotation_no
        {
            get { return quotation_no; }
            set { quotation_no = value; }
        }
        private Double quote_total;

        public Double Quote_total
        {
            get { return quote_total; }
            set { quote_total = value; }
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
        public Int32 askQty()
        {
            Int32 qty = 0;
            orderdao = new DAO.OrderDAO();
            qty = orderdao.getQty(Ean);
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
        public void UpdateTotalQuote()
        {
            orderdao = new DAO.OrderDAO();
            orderdao.TotalAmtUpdateQuote(Order_total_amt, Quotation_no);
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
        #endregion
        #region History Value
        private String targetdate;

        public String Targetdate
        {
            get { return targetdate; }
            set { targetdate = value; }
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
        //
        public Int32 getQN()
        {
            Int32 qn = 0;
            orderdao = new DAO.OrderDAO();
            qn = orderdao.askQuoteNo();
            return qn;
        }
        public void NewQuotation()
        {
            orderdao = new DAO.OrderDAO();
            orderdao.newQuote(Quote_custcode, Quote_customer, Quote_address);
        }
        #endregion
        #region Quotation Entry VO
        public void addQuote()
        {
            orderdao = new DAO.OrderDAO();
            orderdao.addItemQuote(Quotation_no, Ean, Pos_qty, Order_item_amount, Quote_total);
        }
        public void updateQuote()
        {
            orderdao = new DAO.OrderDAO();
            orderdao.updateItemQuote(Quotation_no, Ean, Pos_qty, Order_item_amount, Quote_total);
        }
        public void voidQuote()
        {
            orderdao = new DAO.OrderDAO();
            orderdao.voidItemQuote(Quotation_no, Ean);
        }
        public void cancelQ()
        {
            orderdao = new DAO.OrderDAO();
            orderdao.cancelQuote(Quotation_no);
        }
        #endregion
        #region Quotation Data Retrieveal VO
        public String[,] ReadParkedQuote()
        {
            orderdao = new DAO.OrderDAO();
            Int32 cunt = orderdao.QuoteParkCount();
            String[,] talib = new String[5, cunt];
            talib = orderdao.ReadQuotePark();
            return talib;
        }
        public String[,] ReadParkQuoteSearch()
        {
            orderdao = new DAO.OrderDAO();
            Int32 cunt = orderdao.QuoteParkCountSearch(Quotation_no);
            String[,] talib = new String[5, cunt];
            talib = orderdao.ReadQuoteParkSearch(Quotation_no);
            return talib;
        }
        #endregion
        #region Quotation Item Retrieval VO
        public String[,] ReadItemQuote()
        {
            orderdao = new DAO.OrderDAO();
            Int32 cunt = orderdao.QuoteLoadItemCount(Quotation_no);
            String[,] talib = new String[5, cunt];
            talib = orderdao.QuoteLoadItem(Quotation_no);
            return talib;
        }
        #endregion
        #region Quote History Display VO
        public String[,] ReadQuoteHistoryDateVO()
        {
            orderdao = new DAO.OrderDAO();
            Int32 cunt = orderdao.countByDate(Targetdate);
            String[,] grab = new String[7, cunt];
            grab = orderdao.ReadQuoteHistoryDate(Targetdate);
            return grab;
        }
        public String[,] ReadQuoteHistoryQuoteVO()
        {
            orderdao = new DAO.OrderDAO();
            Int32 cunt = orderdao.countByQuoteNo(Quotation_no);
            String[,] grab = new String[7, cunt];
            grab = orderdao.ReadQuoteHistoryQuote_no(Quotation_no);
            return grab;
        }
        #endregion
        //
        #region Linking Quotation to Order
        public void Linked()
        {
            Int32 on = 0;
            orderdao = new DAO.OrderDAO();
            orderdao.newOrderLinked(Quotation_no);
            on = orderdao.getOrderN(Quotation_no);
            orderdao.LinkedQuote(on, Quotation_no);
        }
        public Boolean checkFlag()
        {
            orderdao = new DAO.OrderDAO();
            return orderdao.checkIfLinked(Quotation_no);
        }
        public Int32 getOrderNo()
        {
            orderdao = new DAO.OrderDAO();
            return orderdao.getOrderN(Quotation_no);
        }
        #endregion
        #region Send Quotation to Order
        public void SendQuotationToOrder()
        {
            orderdao = new DAO.OrderDAO();
            orderdao.sendQuoteOrder(Order_no, Quotation_no, Ean, Pos_qty, Order_item_amount, Pos_amt);
            this.updateOrderTotalAmt();
        }
        private void updateOrderTotalAmt()
        {
            orderdao = new DAO.OrderDAO();
            orderdao.updateTotalAmt(Order_no);
        }
        public void quoteDone()
        {
            orderdao = new DAO.OrderDAO();
            orderdao.TriggerQuoteDone(Quotation_no);
        }
        #endregion
        #region Quote to Order VO
        public void OrderToPOS()
        {
            orderdao = new DAO.OrderDAO();
            orderdao.TransferOrderToPOS(Pos_orno, Pos_orderno);
        }
        public void OrderPOSDone()
        {
            orderdao = new DAO.OrderDAO();
            orderdao.TriggerOrderPOSDone(Pos_vatable, Pos_vex, Pos_vatz, Pos_tax_perc, Pos_tax_amt, Pos_total_amt, Pos_orno, Pos_terminal);
        }
        #endregion
        #region Attribute Quotation VO
        public String askCustomerCodeR()
        {
            String custcode;
            orderdao = new DAO.OrderDAO();
            custcode = orderdao.getCustomerCode(Quotation_no);
            return custcode;
        }
        public String askCustomer()
        {
            String customer;
            orderdao = new DAO.OrderDAO();
            customer = orderdao.getCustomer(Quotation_no);
            return customer;
        }
        public String askAddressR()
        {
            String address;
            orderdao = new DAO.OrderDAO();
            address = orderdao.getAddress(Quotation_no);
            return address;
        }
        #endregion
    }
}