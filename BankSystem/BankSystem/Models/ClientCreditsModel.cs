﻿using System.Collections.Generic;
using BLL.Models;
using BLL.Models.ViewModel;

namespace BankSystem.Models
{
    public class ClientCreditsModel
    {
        public List<CreditModel> Credits { get; set; }

        public UserViewModel Client { get; set; }
    }
}