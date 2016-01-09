using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            WebSecurity.CreateUserAndAccount("Admin", "Admin");
            Roles.AddUserToRole("Admin", "Admin");
        }
    }
}
