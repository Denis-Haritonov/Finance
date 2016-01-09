using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BLL.Models;

namespace BankSystem.Models
{
    public class DepositRequestVM
    {
        public RequestModel RequestModel { get; set; }

        public List<SelectListItem> DepositTypes { get; set; } 

        public String Selected 
    }
}