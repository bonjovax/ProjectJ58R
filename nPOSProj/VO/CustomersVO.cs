using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nPOSProj.VO
{
    class CustomersVO
    {
        private DAO.CustomersDAO customers;
        private String custcode;

        #region Values
        public String Custcode
        {
            get { return custcode; }
            set { custcode = value; }
        }
        private String companyname;

        public String Companyname
        {
            get { return companyname; }
            set { companyname = value; }
        }
        private String firstname;

        public String Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        private String middlename;

        public String Middlename
        {
            get { return middlename; }
            set { middlename = value; }
        }
        private String lastname;

        public String Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        private String email;

        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        private String phone_no;

        public String Phone_no
        {
            get { return phone_no; }
            set { phone_no = value; }
        }
        private String address;

        public String Address
        {
            get { return address; }
            set { address = value; }
        }
        private String city;

        public String City
        {
            get { return city; }
            set { city = value; }
        }
        private String province;

        public String Province
        {
            get { return province; }
            set { province = value; }
        }
        private String zip_code;

        public String Zip_code
        {
            get { return zip_code; }
            set { zip_code = value; }
        }
        private Double balance;

        public Double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        private Double payable;

        public Double Payable
        {
            get { return payable; }
            set { payable = value; }
        }
        //
        private DateTime today;

        public DateTime Today
        {
            get { return today; }
            set { today = value; }
        }

        private DateTime from;

        public DateTime From
        {
            get { return from; }
            set { from = value; }
        }

        private DateTime to;

        public DateTime To
        {
            get { return to; }
            set { to = value; }
        }

        private Double amountPaid;

        public Double AmountPaid
        {
            get { return amountPaid; }
            set { amountPaid = value; }
        }

        private String sss;

        public String Sss
        {
            get { return sss; }
            set { sss = value; }
        }
        private String tin;

        public String Tin
        {
            get { return tin; }
            set { tin = value; }
        }
        private Double creditlimit;

        public Double Creditlimit
        {
            get { return creditlimit; }
            set { creditlimit = value; }
        }
        private Int32 netdays;

        public Int32 Netdays
        {
            get { return netdays; }
            set { netdays = value; }
        }
        private Int32 is_suspended;

        public Int32 Is_suspended
        {
            get { return is_suspended; }
            set { is_suspended = value; }
        }
        private Int32 has_summary;

        public Int32 Has_summary
        {
            get { return has_summary; }
            set { has_summary = value; }
        }
        private Double interest_rate;

        public Double Interest_rate
        {
            get { return interest_rate; }
            set { interest_rate = value; }
        }
        private String due_date;

        public String Due_date
        {
            get { return due_date; }
            set { due_date = value; }
        }
        #endregion
        #region POSValues
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
        private String pos_user;

        public String Pos_user
        {
            get { return pos_user; }
            set { pos_user = value; }
        }
        private String customer;

        public String Customer
        {
            get { return customer; }
            set { customer = value; }
        }
        private Double vatable;

        public Double Vatable
        {
            get { return vatable; }
            set { vatable = value; }
        }
        #endregion
        public CustomersVO() { }

        #region Core
        public String[,] ReadCustomers()
        {
            customers = new DAO.CustomersDAO();
            Int32 count = customers.PositionCount();
            String[,] xxx = new String[7, count];
            customers.ReadCustomer();
            xxx = customers.ReadCustomer();
            return xxx;
        }
        public String[,] SearchReadCustomers()
        {
            customers = new DAO.CustomersDAO();
            Int32 count = customers.PositionCountSearch(Companyname);
            String[,] xxx = new String[7, count];
            customers.ReadCustomerSearch(Companyname);
            xxx = customers.ReadCustomerSearch(Companyname);
            return xxx;
        }
        public String[,] ReadCustomersPayment()
        {
            customers = new DAO.CustomersDAO();
            Int32 count = customers.PositionCount();
            String[,] yyy = new String[5, count];
            customers.ReadCustomerForPayment();
            yyy = customers.ReadCustomerForPayment();
            return yyy;
        }
        public String[,] ReadCustomersFilts()
        {
            customers = new DAO.CustomersDAO();
            Int32 count = customers.PositionCountFilter(Balance);
            String[,] xxx = new String[6, count];
            customers.ReadCustomerFilter(Balance);
            xxx = customers.ReadCustomerFilter(Balance);
            return xxx;
        }
        public String[] ReadEdits()
        {
            customers = new DAO.CustomersDAO();
            String[] jefreak = new String[19];
            customers.ReadEdit(Custcode);
            jefreak = customers.ReadEdit(Custcode);
            return jefreak;
        }
        public String[,] ReadAged() //New
        {
            customers = new DAO.CustomersDAO();
            Int32 yyy = customers.countSummary();
            String[,] xxx = new String[4, yyy];
            xxx = customers.ReadSummary();
            return xxx;
        }
        public String[] ReadCheckoutInfo()
        {
            customers = new DAO.CustomersDAO();
            String[] luuya = new String[2];
            luuya = customers.ReadData(Custcode, Companyname);
            return luuya;
        }
        public void AddCustomers()
        {
            customers = new DAO.CustomersDAO();
            customers.Add(Custcode, Companyname, Firstname, Middlename, Lastname, Email, Phone_no, Address, City, Province, Zip_code, Tin, Sss, Creditlimit, Netdays, Interest_rate);
        }
        public void UpdateCustomers()
        {
            customers = new DAO.CustomersDAO();
            customers.Update(Custcode, Companyname, Firstname, Middlename, Lastname, Email, Phone_no, Address, City, Province, Zip_code, Tin, Sss, Creditlimit, Netdays, Is_suspended, Has_summary, Interest_rate, Due_date);
        }
        public void DeleteCustomers()
        {
            customers = new DAO.CustomersDAO();
            customers.Delete(Custcode);
        }
        public bool CheckCustCode()
        {
            bool check;
            customers = new DAO.CustomersDAO();
            check = customers.checkCustcode(Custcode);
            return check;
        }
        public Double getIR()
        {
            Double ir = 0;
            customers = new DAO.CustomersDAO();
            ir = customers.grabInterestRate(Custcode);
            return ir;
        }
        public void PingInterest()
        {
            customers = new DAO.CustomersDAO();
            customers.PingIR(Balance, Custcode);
        }
        #endregion
        #region Payments
        public String[,] ReadPaymentsDefualt()
        {
            customers = new DAO.CustomersDAO();
            Int32 count = customers.PositionCountCRM(Custcode, Today);
            String[,] xxx = new String[3, count];
            customers.ReadCRMToday(Custcode, Today);
            xxx = customers.ReadCRMToday(Custcode, Today);
            return xxx;
        }
        public String[,] ReadPaymentsDateFilter()
        {
            customers = new DAO.CustomersDAO();
            Int32 count = customers.PositionCountCRMFilter(Custcode, From, To);
            String[,] yyy = new String[3, count];
            customers.ReadCRMFilterDate(Custcode, From, To);
            yyy = customers.ReadCRMFilterDate(Custcode, From, To);
            return yyy;
        }
        public String[,] ReadPaymentsAll()
        {
            customers = new DAO.CustomersDAO();
            Int32 cunt = customers.PositionCountCRMAll(Custcode);
            String[,] zzz = new String[3, cunt];
            customers.ReadCRMAll(Custcode);
            zzz = customers.ReadCRMAll(Custcode);
            return zzz;
        }
        #endregion
        #region Miscellaneous
        public String DisplayCompany()
        {
            String compN;
            customers = new DAO.CustomersDAO();
            customers.DisplayCmp(Custcode);
            compN = customers.DisplayCmp(Custcode);
            return compN;
        }
        public String DisplayCustomerCode()
        {
            String Custc;
            customers = new DAO.CustomersDAO();
            customers.DisplayCustC(Companyname);
            Custc = customers.DisplayCustC(Companyname);
            return Custc;
        }
        public bool Correct()
        {
            Boolean Korek;
            customers = new DAO.CustomersDAO();
            customers.correct(Custcode, Companyname);
            Korek = customers.correct(Custcode, Companyname);
            return Korek;
        }
        #endregion
        #region Checkout Section and Account Payments
        public void CreditToAccount()
        {
            customers = new DAO.CustomersDAO();
            customers.CreditAccount(Balance, Payable, Custcode);
        }
        public void DebitToAccount()
        {
            customers = new DAO.CustomersDAO();
            customers.DebitAccount(Balance, AmountPaid, Custcode);
        }
        public void PayToSale()
        {
            Double init_amount = 0;
            Double fin_amount = 0;
            customers = new DAO.CustomersDAO();
            init_amount = AmountPaid / 1.12;
            fin_amount = init_amount * customers.askTax();
            customers.PaymentToSales(Pos_orno, Pos_terminal, Custcode, Customer, Pos_user, fin_amount, Vatable, AmountPaid, AmountPaid);
        }
        public Boolean JustCheckVat()
        {
            Boolean check = false;
            customers = new DAO.CustomersDAO();
            check = customers.checkVat();
            return check;
        }
        #endregion
        #region Etc
        public String first()
        {
            customers = new DAO.CustomersDAO();
            return customers.fname();
        }
        public String middle()
        {
            customers = new DAO.CustomersDAO();
            String axe = customers.mname();
            return customers.middleName(axe);
        }
        public String last()
        {
            customers = new DAO.CustomersDAO();
            return customers.lname();
        }
        #endregion
    }
}