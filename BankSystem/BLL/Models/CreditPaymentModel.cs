using System;
using BLL.Models.Enums;
using DAL;

namespace BLL.Models
{
    public class CreditPaymentModel
    {
        public CreditPaymentModel()
        {
        }

        public CreditPaymentModel(CreditPayment payment)
        {
            Id = payment.Id;
            Amount = payment.Amount;
            Type = (CreditPaymentType) payment.Type;
            Date = payment.Date;
            CreditId = payment.CreditId;
            if (payment.Credit != null)
            {
                Credit = new CreditModel(payment.Credit, takePayments: false);
            }
        }

        public int Id { get; set; }
        
        public int CreditId { get; set; }
        
        public int Amount { get; set; }
        
        public CreditPaymentType Type { get; set; }
        
        public DateTime Date { get; set; }

        public CreditModel Credit { get; set; }

        public String TypeName
        {
            get
            {
                switch (Type)
                {
                    case CreditPaymentType.Payment:
                        return "Плата";
                    case CreditPaymentType.AutomaticPercents:
                        return "Проценты";
                }
                return String.Empty;
            }
        }

        public String FormattedStartDate
        {
            get
            {
                return Date.ToString("dd.MM.yyyy hh:mm");
            }
        }
    }
}
