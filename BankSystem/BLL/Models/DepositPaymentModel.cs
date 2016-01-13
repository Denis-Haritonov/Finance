using BLL.Models.Enums;
using DAL;

namespace BLL.Models
{
    public class DepositPaymentModel
    {
        public DepositPaymentModel(DepositPayment payment)
        {
            Id = payment.Id;
            DepositId = payment.DepositId;
            Type = (DepositPaymentType) payment.Type;
            Amount = payment.Amount;
            if (payment.Deposit != null)
            {
                DepositModel = new DepositModel(payment.Deposit);
            }
        }

        public int Id { get; set; }
        
        public int DepositId { get; set; }
        
        public DepositPaymentType Type { get; set; }
        
        public int Amount { get; set; }
    
        public DepositModel DepositModel { get; set; }
    }
}
