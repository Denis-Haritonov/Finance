using BLL.Models;

namespace BankSystem.Models
{
    public class CalculationModel
    {
        public CreditTypeModel CreditType { get; set; }

        public decimal Amount { get; set; }

        public decimal Result { get; set; }
    }
}