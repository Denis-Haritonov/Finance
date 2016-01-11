using System.Collections.Generic;
using BLL.Models;
using BLL.Models.ViewModel;

namespace BankSystem.Models
{
    public class ClientInfoModel
    {
        public UserViewModel UserModel { get; set; }

        public List<RequestModel> Requests { get; set; } 
    }
}