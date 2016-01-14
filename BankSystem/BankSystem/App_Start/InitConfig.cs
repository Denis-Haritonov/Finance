using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Web.WebPages.OAuth;
using BankSystem.Models;
using BLL.Interfaces;
using Common.Enum;
using WebMatrix.WebData;
using Roles = System.Web.Security.Roles;

namespace BankSystem
{
    public  class InitConfig
    {

        public static void Config()
        {
            CultureInfo cultureInfo = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            WebSecurity.InitializeDatabaseConnection("DefaultConnection","UserProfile","UserId","Login",false);
        }
    }
}
