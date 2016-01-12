using BLL.Models;

namespace BankSystem.Models
{
    public class OpenDepositModel
    {
        public RequestModel RequestModel { get; set; }

        public decimal Amount { get; set; }
    }
}