using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BLL.Models;

namespace BankSystem.Models
{
    public class CreditRequestVM
    {
        public RequestModel RequestModel { get; set; }

        public List<SelectListItem> CreditTypes { get; set; }

        public String SelectedCreditType { get; set; }
    }
}