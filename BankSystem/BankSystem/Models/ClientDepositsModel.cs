using System.Collections.Generic;
using BLL.Models;
using BLL.Models.ViewModel;

namespace BankSystem.Models
{
    public class ClientDepositsModel
    {
        public List<DepositModel> Deposits { get; set; }

        public UserViewModel Client { get; set; }
    }
}