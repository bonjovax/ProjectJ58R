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
    }
}