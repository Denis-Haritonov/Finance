using System.Collections.Generic;
using BLL.Models;
using BLL.Models.ViewModel;

namespace BankSystem.Models
{
    public class RequestsQueVM
    {
        public List<RequestModel> Requests { get; set; }

        public UserViewModel CurrentUser { get; set; }
    }
}