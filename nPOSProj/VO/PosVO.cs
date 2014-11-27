using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nPOSProj.VO
{
    class PosVO
    {
        #region Value Stuffs
        private DAO.PosDAO POSDAO;
        private Conf.Crypto crypt;
        private Int32 pos_orno;

        public Int32 Pos_orno
        {
            get { return pos_orno; }
            set { pos_orno = value; }
        }
        private DateTime pos_date;

        public DateTime Pos_date
        {
            get { return pos_date; }
            set { pos_date = value; }
        }
        private DateTime pos_time;

        public DateTime Pos_time
        {
            get { return pos_time; }
            set { pos_time = value; }
        }
        private String crm_custcode;

        public String Crm_custcode
        {
            get { return crm_custcode; }
            set { crm_custcode = value; }
        }
        private String pos_customer;

        public String Pos_customer
        {
            get { return pos_customer; }
            set { pos_customer = value; }
        }
        private String pos_user;

        public String Pos_user
        {
            get { return pos_user; }
            set { pos_user = value; }
        }
        private String pos_password;

        public String Pos_password
        {
            get { return pos_password; }
            set { pos_password = value; }
        }
        private Int32 pos_iswholesale;

        public Int32 Pos_iswholesale
        {
            get { return pos_iswholesale; }
            set { pos_iswholesale = value; }
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
        private String pos_paymethod;

        public String Pos_paymethod
        {
            get { return pos_paymethod; }
            set { pos_paymethod = value; }
        }
        private Double pos_change;

        public Double Pos_change
        {
            get { return pos_change; }
            set { pos_change = value; }
        }
        private Int32 pos_park;

        public Int32 Pos_park
        {
            get { return pos_park; }
            set { pos_park = value; }
        }

        private String pos_terminal;

        public String Pos_terminal
        {
            get { return pos_terminal; }
            set { pos_terminal = value; }
        }

        private Int32 pos_quantity;

        public Int32 Pos_quantity
        {
            get { return pos_quantity; }
            set { pos_quantity = value; }
        }

        private Double pos_discount;

        public Double Pos_discount
        {
            get { return pos_discount; }
            set { pos_discount = value; }
        }

        private Double pos_discount_amt;

        public Double Pos_discount_amt
        {
            get { return pos_discount_amt; }
            set { pos_discount_amt = value; }
        }

        private String pos_ean;

        public String Pos_ean
        {
            get { return pos_ean; }
            set { pos_ean = value; }
        }

        private Double pos_item_amount;

        public Double Pos_item_amount
        {
            get { return pos_item_amount; }
            set { pos_item_amount = value; }
        }

        private Double pos_amt;

        public Double Pos_amt
        {
            get { return pos_amt; }
            set { pos_amt = value; }
        }

        private Double total_pos_disc_amt;

        public Double Total_pos_disc_amt
        {
            get { return total_pos_disc_amt; }
            set { total_pos_disc_amt = value; }
        }
        #endregion
        #region Checkout Value Stuffs
        private Double pos_tender;

        public Double Pos_tender
        {
            get { return pos_tender; }
            set { pos_tender = value; }
        }

        private String card_data;

        public String Card_data
        {
            get { return card_data; }
            set { card_data = value; }
        }

        private String card_type;

        public String Card_type
        {
            get { return card_type; }
            set { card_type = value; }
        }

        private String card_lastfour;

        public String Card_lastfour
        {
            get { return card_lastfour; }
            set { card_lastfour = value; }
        }

        private Double tx_amount;

        public Double Tx_amount
        {
            get { return tx_amount; }
            set { tx_amount = value; }
        }

        private String bc_checkno;

        public String Bc_checkno
        {
            get { return bc_checkno; }
            set { bc_checkno = value; }
        }

        private String bc_banknbranch;

        public String Bc_banknbranch
        {
            get { return bc_banknbranch; }
            set { bc_banknbranch = value; }
        }

        private String bc_refcode;

        public String Bc_refcode
        {
            get { return bc_refcode; }
            set { bc_refcode = value; }
        }

        private String gc_cardo;

        public String Gc_cardo
        {
            get { return gc_cardo; }
            set { gc_cardo = value; }
        }

        //New Stuff
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
        //
        #endregion
        #region CashInOut
        private Double cashAmount;

        public Double CashAmount
        {
            get { return cashAmount; }
            set { cashAmount = value; }
        }
        private String drawerPurpose;

        public String DrawerPurpose
        {
            get { return drawerPurpose; }
            set { drawerPurpose = value; }
        }
        private Double incAmt;

        public Double IncAmt
        {
            get { return incAmt; }
            set { incAmt = value; }
        }
        private Double decAmt;

        public Double DecAmt
        {
            get { return decAmt; }
            set { decAmt = value; }
        }
        #endregion
        #region Cash Count Value
        private Double thousand;

        public Double Thousand
        {
            get { return thousand; }
            set { thousand = value; }
        }
        private Double fiveh;

        public Double Fiveh
        {
            get { return fiveh; }
            set { fiveh = value; }
        }
        private Double twoh;

        public Double Twoh
        {
            get { return twoh; }
            set { twoh = value; }
        }
        private Double oneh;

        public Double Oneh
        {
            get { return oneh; }
            set { oneh = value; }
        }
        private Double fifty;

        public Double Fifty
        {
            get { return fifty; }
            set { fifty = value; }
        }
        private Double twenty;

        public Double Twenty
        {
            get { return twenty; }
            set { twenty = value; }
        }
        private Double ten;

        public Double Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        private Double five;

        public Double Five
        {
            get { return five; }
            set { five = value; }
        }
        private Double one;

        public Double One
        {
            get { return one; }
            set { one = value; }
        }
        private Double ctwentyfive;

        public Double Ctwentyfive
        {
            get { return ctwentyfive; }
            set { ctwentyfive = value; }
        }
        #endregion

        #region POS Main Course Classes
        public Int32 GetOrNo()
        {
            Int32 Or;
            POSDAO = new DAO.PosDAO();
            POSDAO.GenerateOR(Pos_terminal);
            Or = POSDAO.GenerateOR(Pos_terminal);
            return Or + 1;
        }

        public void BeginTransaction()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.Begin(Pos_orno, Pos_terminal, Pos_date, Pos_time, Pos_user);
        }

        public void SwitchToWholeSale()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.SwitchWS(Pos_orno);
        }
        public void SwitchToRetail()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.SwitchRT(Pos_orno);
        }
        public void ParkItem()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.Park_I(Pos_orno, Pos_terminal, Pos_ean, Pos_quantity, Pos_item_amount, Pos_amt);
        }
        public void ParkItemSameUpdate()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.Park_I_Update(Pos_orno, Pos_terminal, Pos_ean, Pos_quantity, Pos_item_amount, Pos_amt);
        }

        public void ParkItemUpdate()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.ParkU_I(Pos_orno, Pos_terminal, Pos_ean, Pos_discount, Pos_discount_amt, Pos_quantity, Pos_item_amount, Pos_amt);
        }

        public void ParkDiscountItemUpdate()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.ParkUwD_I(Pos_orno, Pos_terminal, Pos_ean, Pos_discount, Pos_discount_amt, Pos_item_amount, Pos_amt);
        }

        public void ParkVoidItem()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.ParkVoid_I(Pos_orno, Pos_terminal, Pos_ean, Pos_quantity);
        }

        public void ReturnCancelItems()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.ReturnCancelI(Pos_ean, Pos_quantity, Pos_orno, Pos_terminal);
        }

        public void CancelSale()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.CancelT(Pos_orno, Pos_terminal);
        }

        public void UpdateTrunk()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.UpdateTrunkSales(Pos_vatable, Pos_vex, Pos_vatz, Pos_tax_perc, Pos_tax_amt, Total_pos_disc_amt, Pos_total_amt, Pos_orno, Pos_terminal);
        }
        #endregion
        #region POS Checkout Stuffs
        public void CashCheckout()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.Cash(Pos_tender, Pos_change, Pos_orno, Pos_terminal);
        }
        public void DCCardCheckout()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.DBCCard(Pos_tender, Pos_orno, Pos_terminal, Card_data, Card_lastfour, card_type, Tx_amount);
        }
        public void BankCheckout()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.BCheck(Pos_tender, Pos_orno, Pos_terminal, Bc_checkno, Bc_banknbranch, Bc_refcode, Tx_amount);
        }
        public void GiftCardCheckout()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.GiftDick(Pos_tender, Pos_orno, Pos_terminal, Gc_cardo, Tx_amount);
        }
        public void ARBasicCheckout()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.AR_Basic(Pos_customer, Pos_tender, Pos_orno, Pos_terminal, Crm_custcode, Tx_amount);
        }
        public void NoSale()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.NoSalesTrans(Pos_orno, Pos_terminal);
        }
        #endregion
        #region Refund Section
        public String[,] ReadRefunData()
        {
            POSDAO = new DAO.PosDAO();
            Int32 count = POSDAO.CountRefund(Pos_orno, Pos_terminal);
            String[,] xxx = new String[8, count];
            POSDAO.ReadRefund(Pos_orno, Pos_terminal);
            xxx = POSDAO.ReadRefund(Pos_orno, Pos_terminal);
            return xxx;
        }
        public bool checkWS()
        {
            bool isFound;
            POSDAO = new DAO.PosDAO();
            POSDAO.CheckWholeSale(Pos_orno, Pos_terminal);
            isFound = POSDAO.CheckWholeSale(Pos_orno, Pos_terminal);
            return isFound;
        }
        #endregion
        #region Cash Drawer Section
        public Double DrawerBalance()
        {
            POSDAO = new DAO.PosDAO();
            Double bal = 0;
            bal = POSDAO.CashDrawerBalance(Pos_terminal);
            return bal;
        }
        public void CreditD()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.CreditDrawerLog(CashAmount, DrawerPurpose, Pos_terminal, Pos_user);
        }
        public void DebitD()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.DebitDrawerLog(CashAmount, DrawerPurpose, Pos_terminal, Pos_user);
        }
        public void ResetD()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.ResetDrawer(Pos_terminal);
        }
        public void IncD()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.IncDrawer(IncAmt, Pos_terminal);
        }
        public void DecD()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.DecDrawer(DecAmt, Pos_terminal);
        }
        #endregion
        #region Cash Count Section
        public void LogCashCount()
        {
            POSDAO = new DAO.PosDAO();
            POSDAO.LogCC(Thousand, Fiveh, Twoh, Oneh, Fifty, Twenty, Ten, Five, One, Ctwentyfive, Pos_terminal, Pos_user);
        }
        #endregion
        #region Security VO
        public Boolean canExit()
        {
            Boolean yes = false;
            String hashed = "";
            POSDAO = new DAO.PosDAO();
            crypt = new Conf.Crypto();
            crypt.Hashed(Pos_password);
            hashed = crypt.RefretreiveHash();
            yes = POSDAO.canPass(Pos_user, hashed);
            return yes;
        }
        #endregion
    }
}