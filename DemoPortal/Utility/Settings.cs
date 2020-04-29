using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DemoPortal.Utility
{
    public class Settings
    {
        public static string ApiUrl { get; set; } = GetApiUrl();

        private static string GetApiUrl()
        {
            return ConfigurationManager.AppSettings["ApiUrl"];
        }
    }
}