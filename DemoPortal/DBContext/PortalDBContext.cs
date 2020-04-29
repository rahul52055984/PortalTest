using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoPortal.DBContext
{
    public sealed class PortalDBContext
    {
        public PortalDBContext() { }
        private static readonly object padlock = new object();
        private static PortalDBEntities instance = null;
        public static PortalDBEntities DB_Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        using (PortalDBEntities con = new PortalDBEntities())
                        {
                            instance = new PortalDBEntities();
                        }
                    }
                    return instance;
                }
            }
        }
    }
}