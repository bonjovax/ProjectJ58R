using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nPOSProj.VO
{
    class ChangePasswordVO
    {
        private String _user_password;
        private DAO.ChangePasswordDAO cpdao;

        public ChangePasswordVO()
        {

        }
        public String user_password
        {
            get { return _user_password; }
            set { _user_password = value; }
        }

        public void Change()
        {
            cpdao = new DAO.ChangePasswordDAO();
            cpdao.ChangeThePassword(user_password);
        }
    }
}