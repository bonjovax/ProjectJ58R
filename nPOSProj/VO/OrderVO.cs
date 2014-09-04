using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nPOSProj.VO
{
    class OrderVO
    {
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
        public OrderVO() { }

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
    }
}