using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nPOSProj.VO
{
    class ConfigVO
    {
        private String _company_name;
        private String _company_address;
        private String _company_address1;
        private String _tin_number;
        private String _tax_type;
        private Double _vat_rate;
        private String _contact_number;
        private Int16 _allITax;
        private String _operators;
        private String _permitno;
        private DAO.ConfigDAO confdao;
        
        public ConfigVO()
        {

        }

        public String company_name
        {
            get { return _company_name; }
            set { _company_name = value; }
        }
        public String company_address
        {
            get { return _company_address; }
            set { _company_address = value; }
        }
        public String company_address1
        {
            get { return _company_address1; }
            set { _company_address1 = value; }
        }
        public String tin_number
        {
            get { return _tin_number; }
            set { _tin_number = value; }
        }
        public String tax_type
        {
            get { return _tax_type; }
            set { _tax_type = value; }
        }
        public Double vat_rate
        {
            get { return _vat_rate; }
            set { _vat_rate = value; }
        }
        public String contact_number
        {
            get { return _contact_number; }
            set { _contact_number = value; }
        }
        public Int16 allITax
        {
            get { return _allITax; }
            set { _allITax = value; }
        }
        public String operators
        {
            get { return _operators; }
            set { _operators = value; }
        }
        public String permitno
        {
            get { return _permitno; }
            set { _permitno = value; }
        }

        public String askCompanyName()
        {
            String companyName;
            confdao = new DAO.ConfigDAO();
            confdao.readCompany_Name();
            companyName = confdao.readCompany_Name();
            return companyName;
        }
        public String askCompanyAddress()
        {
            String companyAddress;
            confdao = new DAO.ConfigDAO();
            confdao.readCompany_Address();
            companyAddress = confdao.readCompany_Address();
            return companyAddress;
        }
        public String askCompanyAddress1()
        {
            String companyAddress;
            confdao = new DAO.ConfigDAO();
            confdao.address1();
            companyAddress = confdao.address1();
            return companyAddress;
        }
        public String askTIN()
        {
            String TIN;
            confdao = new DAO.ConfigDAO();
            confdao.readTin_Number();
            TIN = confdao.readTin_Number();
            return TIN;
        }
        public String askTaxType()
        {
            String TT;
            confdao = new DAO.ConfigDAO();
            confdao.readTax_Type();
            TT = confdao.readTax_Type();
            return TT;
        }
        public Double askVATRate()
        {
            Double VR = 0.0;
            confdao = new DAO.ConfigDAO();
            confdao.readVat_Rate();
            VR = confdao.readVat_Rate();
            return VR;
        }
        public String askContactNumber()
        {
            String Cn;
            confdao = new DAO.ConfigDAO();
            confdao.readContact_Number();
            Cn = confdao.readContact_Number();
            return Cn;
        }
        public Int16 askAllItem()
        {
            Int16 switchs = 0;
            confdao = new DAO.ConfigDAO();
            confdao.allItemTax();
            switchs = confdao.allItemTax();
            return switchs;
        }
        public String askOperator()
        {
            String op;
            confdao = new DAO.ConfigDAO();
            confdao.operators();
            op = confdao.operators();
            return op;
        }
        public String askPermitno()
        {
            String pn;
            confdao = new DAO.ConfigDAO();
            confdao.permitNo();
            pn = confdao.permitNo();
            return pn;
        }
        public void Patch()
        {
            confdao = new DAO.ConfigDAO();
            confdao.PatchInfo(company_name, company_address, tin_number, tax_type, vat_rate, allITax, contact_number, operators, permitno, company_address1);
        }
        public String[,] ReadTerminal()
        {
            confdao = new DAO.ConfigDAO();
            Int32 count = confdao.CountTerminal();
            String[,] xxx = new String[1, count];
            confdao.ReadTerminal();
            xxx = confdao.ReadTerminal();
            return xxx;
        }
    }
}