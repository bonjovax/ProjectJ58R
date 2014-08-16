using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nPOSProj.VO
{
    public class UserAccountVO
    {
        private Int32 _user_id;
        private String _user_name;
        private String _user_password;
        private String _date_created;
        private String _first_name;
        private String _middle_name;
        private String _last_name;
        private String _last_login;
        //Restrictions
        private Int32 _can_access;
        private Int32 _has_sales;
        private Int32 _has_order; //New
        private Int32 _has_customers;
        private Int32 _has_inventory;
        private Int32 _has_reports;
        private Int32 _has_gc;
        private Int32 _has_user_accounts;
        private Int32 _has_conf;
        private DAO.UserAccountDAO udao;

        public UserAccountVO()
        {

        }
        #region Main GETSET
        public UserAccountVO(String _user_name)
        {
            this._user_name = _user_name;
        }
        public Int32 user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }
        public String user_name
        {
            get { return _user_name; }
            set { _user_name = value; }
        }
        public String user_password
        {
            get { return _user_password; }
            set { _user_password = value; }
        }
        public String date_created
        {
            get { return _date_created; }
            set { _date_created = value; }
        }
        public String first_name
        {
            get { return _first_name; }
            set { _first_name = value; }
        }
        public String middle_name
        {
            get { return _middle_name; }
            set { _middle_name = value; }
        }
        public String last_name
        {
            get { return _last_name; }
            set { _last_name = value; }
        }
        public String last_login
        {
            get { return _last_login; }
            set { _last_login = value; }
        }
        #endregion
        #region Restrictions GETSET
        public Int32 can_access
        {
            get { return _can_access; }
            set { _can_access = value; }
        }
        public Int32 has_sales
        {
            get { return _has_sales; }
            set { _has_sales = value; }
        }
        public Int32 has_order
        {
            get { return _has_order; }
            set { _has_order = value; }
        }
        public Int32 has_customers
        {
            get { return _has_customers; }
            set { _has_customers = value; }
        }
        public Int32 has_inventory
        {
            get { return _has_inventory; }
            set { _has_inventory = value; }
        }
        public Int32 has_reports
        {
            get { return _has_reports; }
            set { _has_reports = value; }
        }
        public Int32 has_gc
        {
            get { return _has_gc; }
            set { _has_gc = value; }
        }
        public Int32 has_user_accounts
        {
            get { return _has_user_accounts; }
            set { _has_user_accounts = value; }
        }
        public Int32 has_conf
        {
            get { return _has_conf; }
            set { _has_conf = value; }
        }
        #endregion

        public void AddUser()
        {
            udao = new DAO.UserAccountDAO();
            udao.Add(user_id, user_name, user_password, first_name, middle_name, last_name);
        }
        public void UpdateUser()
        {
            udao = new DAO.UserAccountDAO();
            udao.Update(user_id, user_name, first_name, middle_name, last_name);
        }
        public void DeleteUser()
        {
            udao = new DAO.UserAccountDAO();
            udao.Delete(user_id, user_name);
        }

        public void PushLog()
        {
            udao = new DAO.UserAccountDAO();
            udao.logs(user_name);
        }

        public Int32 askUserID()
        {
            Int32 UserID;
            udao = new DAO.UserAccountDAO();
            udao.postUserID();
            UserID = udao.postUserID();
            return UserID + 1;
        }

        public Int32 askCatchUserID()
        {
            Int32 catchedUserID;
            udao = new DAO.UserAccountDAO();
            udao.catchUserIDFromUserName(user_name);
            catchedUserID = udao.catchUserIDFromUserName(user_name);
            return catchedUserID;
        }

        public void SaveRestriction()
        {
            udao = new DAO.UserAccountDAO();
            udao.UpdateRestrictions(can_access, has_sales, has_order, has_customers, has_inventory, has_reports, has_gc, has_user_accounts, has_conf, user_id);
        }

        public void Reset()
        {
            udao = new DAO.UserAccountDAO();
            udao.resetPassword(user_name);
        }
    }
}