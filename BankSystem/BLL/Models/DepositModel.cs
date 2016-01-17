using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Models.ViewModel;
using DAL;

namespace BLL.Models
{
    public class DepositModel
    {
        public DepositModel()
        {
        }

        public DepositModel(Deposit deposit, bool takePayments = true)
        {
            Id = deposit.Id;
            StartDate = deposit.StartDate;
            Balance = deposit.Balance;
            DepositTypeId = deposit.DepositTypeId;
            RequestId = deposit.RequestId;
            EndDate = deposit.EndDate;
            ClientId = deposit.ClientId;
            if (deposit.DepositType != null)
            {
                DepositType = new DepositTypeModel(deposit.DepositType);
            }
            if (deposit.UserProfile != null)
            {
                ClientModel = new UserViewModel(deposit.UserProfile);
            }
            if (takePayments && deposit.DepositPayment != null)
            {
                PaymentModels =
                    deposit.DepositPayment.Select(item => new DepositPaymentModel(item))
                        .OrderByDescending(item => item.Date)
                        .ToList();
            }
        }

        public RefreshCodeModel ReturnCodeModel { get; set; }

        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public decimal Balance { get; set; }

        public int DepositTypeId { get; set; }

        public int? RequestId { get; set; }

        public DateTime EndDate { get; set; }

        public DepositTypeModel DepositType { get; set; }

        public int ClientId { get; set; }

        public UserViewModel ClientModel { get; set; }

        public List<DepositPaymentModel> PaymentModels { get; set; } 

        public String FormattedStartDate
        {
            get
            {
                return StartDate.ToString("dd.MM.yyyy hh:mm");
            }
        }
    }
}
