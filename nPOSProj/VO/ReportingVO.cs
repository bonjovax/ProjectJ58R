using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nPOSProj.VO
{
    class ReportingVO
    {
        private DAO.ReportingDAO reportdao;
        private String pos_date;

        public String Pos_date
        {
            get { return pos_date; }
            set { pos_date = value; }
        }
        private String pos_terminal;

        public String Pos_terminal
        {
            get { return pos_terminal; }
            set { pos_terminal = value; }
        }
        public ReportingVO()
        {

        }

        public Double GrossAmount()
        {
            Double Gross = 0;
            reportdao = new DAO.ReportingDAO();
            reportdao.ReadGrossAmount(Pos_date, Pos_terminal);
            Gross = reportdao.ReadGrossAmount(Pos_date, Pos_terminal);
            return Gross;
        }
        public Double Discounts()
        {
            Double Discount = 0;
            reportdao = new DAO.ReportingDAO();
            reportdao.ReadDiscounts(Pos_date, Pos_terminal);
            Discount = reportdao.ReadDiscounts(Pos_date, Pos_terminal);
            return Discount;
        }
        public Double TaxAmount()
        {
            Double Amount = 0;
            reportdao = new DAO.ReportingDAO();
            reportdao.ReadTaxAmt(Pos_date, Pos_terminal);
            Amount = reportdao.ReadTaxAmt(Pos_date, Pos_terminal);
            return Amount;
        }
        public Int32 SeriesStart()
        {
            Int32 start = 0;
            reportdao = new DAO.ReportingDAO();
            reportdao.CounterStart(Pos_date, Pos_terminal);
            start = reportdao.CounterStart(Pos_date, Pos_terminal);
            return start;
        }
        public Int32 SeriesEnd()
        {
            Int32 end = 0;
            reportdao = new DAO.ReportingDAO();
            reportdao.CounterEnd(Pos_date, Pos_terminal);
            end = reportdao.CounterEnd(Pos_date, Pos_terminal);
            return end;
        }
        public Int32 CountCancel()
        {
            Int32 count = 0;
            reportdao = new DAO.ReportingDAO();
            reportdao.countCancel(Pos_date, Pos_terminal);
            count = reportdao.countCancel(Pos_date, Pos_terminal);
            return count;
        }
        public Int32 NumberOfTrans()
        {
            Int32 count = 0;
            reportdao = new DAO.ReportingDAO();
            reportdao.NoOfTrans(Pos_date, Pos_terminal);
            count = reportdao.NoOfTrans(Pos_date, Pos_terminal);
            return count;
        }
        public Int32 NumberOfEan()
        {
            Int32 count = 0;
            reportdao = new DAO.ReportingDAO();
            reportdao.NoOfEAN(Pos_date, Pos_terminal);
            count = reportdao.NoOfEAN(Pos_date, Pos_terminal);
            return count;
        }
        public Int32 OverallQty()
        {
            Int32 Qty = 0;
            reportdao = new DAO.ReportingDAO();
            reportdao.TotalQty(Pos_date, Pos_terminal);
            Qty = reportdao.TotalQty(Pos_date, Pos_terminal);
            return Qty;
        }
        public Double PreviousNETAmt()
        {
            Double Amount = 0;
            String minusdate = Convert.ToDateTime(Pos_date).AddDays(-1).ToString("yyyy-MM-dd");
            reportdao = new DAO.ReportingDAO();
            reportdao.PreviousNET(minusdate, Pos_terminal);
            Amount = reportdao.PreviousNET(minusdate, Pos_terminal);
            return Amount;
        }
    }
}