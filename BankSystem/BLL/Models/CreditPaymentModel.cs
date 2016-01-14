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
            MainAmount = payment.MainAmount;
            PercentAmount = payment.PercentsAmount;
            Type = (CreditPaymentType) payment.Type;
            Date = payment.Date;
            CreditId = payment.CreditId;
            if (payment.Credit != null)
            {
                CreditModel = new CreditModel(payment.Credit, takePayments: false);
            }
        }

        public int Id { get; set; }
        
        public int CreditId { get; set; }
        
        public decimal MainAmount { get; set; }

        public decimal PercentAmount { get; set; }
        
        public CreditPaymentType Type { get; set; }
        
        public DateTime Date { get; set; }

        public CreditModel CreditModel { get; set; }

        public String TypeName
        {
            get
            {
                switch (Type)
                {
                    case CreditPaymentType.Payment:
                        return "Платеж";
                    case CreditPaymentType.AutomaticPercents:
                        return "Проценты";
                }
                return String.Empty;
            }
        }

        public String FormattedDate
        {
            get
            {
                return Date.ToString("dd.MM.yyyy hh:mm");
            }
        }
    }
}
