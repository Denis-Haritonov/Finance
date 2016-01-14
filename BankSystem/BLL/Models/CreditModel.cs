using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Models.ViewModel;
using DAL;

namespace BLL.Models
{
    public class CreditModel
    {
        public CreditModel()
        {
        }

        public CreditModel(Credit credit, bool takePayments = true)
        {
            Id = credit.Id;
            StartDate = credit.StartDate;
            StartAmount = credit.StartAmount;
            MainDebt = credit.MainDebt;
            PercentageDebt = credit.PercentageDebt;
            CreditTypeId = credit.CreditTypeId;
            ClientId = credit.ClientId;
            if (credit.CreditType != null)
            {
                CreditType = new CreditTypeModel(credit.CreditType);
            }
            if (credit.UserProfile != null)
            {
                Client = new UserViewModel(credit.UserProfile);
            }
            if (takePayments && credit.CreditPayment != null)
            {
                PaymentModels =
                    credit.CreditPayment.Select(item => new CreditPaymentModel(item))
                        .OrderByDescending(item => item.Date)
                        .ToList();
            }
        }

        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public decimal StartAmount { get; set; }

        public decimal MainDebt { get; set; }

        public decimal PercentageDebt { get; set; }

        public int CreditTypeId { get; set; }

        public int? RequestId { get; set; }

        public int ClientId { get; set; }

        public  UserViewModel Client { get; set; }
        
        public CreditTypeModel CreditType { get; set; }

        public  List<CreditPaymentModel> PaymentModels { get; set; }

        public String FormattedStartDate
        {
            get
            {
                return StartDate.ToString("dd.MM.yyyy hh:mm");
            }
        }
    }
}
