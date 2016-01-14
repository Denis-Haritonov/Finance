using System;
using BLL.Models.Enums;
using DAL;

namespace BLL.Models
{
    public class DepositPaymentModel
    {
        public DepositPaymentModel()
        {
        }

        public DepositPaymentModel(DepositPayment payment)
        {
            Id = payment.Id;
            DepositId = payment.DepositId;
            Type = (DepositPaymentType) payment.Type;
            Amount = payment.Amount;
            Date = payment.Date;
            if (payment.Deposit != null)
            {
                DepositModel = new DepositModel(payment.Deposit, takePayments: false);
            }
        }

        public int Id { get; set; }
        
        public int DepositId { get; set; }
        
        public DepositPaymentType Type { get; set; }
        
        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public DepositModel DepositModel { get; set; }

        public String FormattedDate
        {
            get
            {
                return Date.ToString("dd.MM.yyyy hh:mm");
            }
        }

        public String TypeName
        {
            get
            {
                switch (Type)
                {
                    case DepositPaymentType.Income:
                        return "Зачисление";
                    case DepositPaymentType.Outcome:
                        return "Снятие";
                    case DepositPaymentType.AutomaticIncome:
                        return "Зачисление процентов";
                }
                return String.Empty;
            }
        }
    }
}
