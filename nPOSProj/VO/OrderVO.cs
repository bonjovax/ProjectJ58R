using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nPOSProj.VO
{
    class OrderVO
    {
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
    }
}