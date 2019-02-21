using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SEFApplicationDashboard.Models;
namespace SEFApplicationDashboard.app
{
   

    public class ConnectionInfo
    {
        public const string user = "_SEF_ADMIN";
        public const string password = "35SAP!!lmv#";

            public Configuration GetSapConfig()
        {
            Configuration configuration = new Configuration();
            configuration.User = user;
            configuration.Password = password;

            return configuration;


        }
    }
}