using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoPortal.Models;

namespace DemoPortal.Utility
{
    public class UserSetting
    {
        private UserLoginModel user = null;
        private int _UserId = 0;
        private int _UserType = -1;
        private string _UserName = null;
        private string _UserLoginType = null;

        public UserSetting()
        {
            if (user == null)
                user = HttpContext.Current.Session["UserDetail"] as UserLoginModel;
        }
        public int UserId
        {
            get
            {
                if (_UserId <= 0)
                    _UserId = user.UserId;
                return _UserId;
            }
        }
        public int UserType
        {
            get
            {
                if (_UserType <= 0)
                    _UserType = user.RoleId;
                return _UserType;
            }
        }
        public string UserName
        {
            get
            {
                if (_UserName == null)
                    _UserName = user.FullName;
                return _UserName;
            }
        }
        public string UserLoginType
        {
            get
            {
                if (_UserLoginType == null)
                {
                    if (this.UserType == (int)UserTypeEnum.Admin)
                        _UserLoginType = UserTypeEnum.Admin.ToString();
                    else if (this.UserType == (int)UserTypeEnum.Supervisor)
                        _UserLoginType = UserTypeEnum.Supervisor.ToString();
                    else if (this.UserType == (int)UserTypeEnum.Agent)
                        _UserLoginType = UserTypeEnum.Agent.ToString();

                }
                return _UserLoginType;
            }
        }

    }

    
}