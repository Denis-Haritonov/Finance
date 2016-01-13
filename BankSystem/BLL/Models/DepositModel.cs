using System;
using BLL.Models.ViewModel;
using DAL;

namespace BLL.Models
{
    public class DepositModel
    {
        public DepositModel()
        {
        }

        public DepositModel(Deposit deposit)
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
        }

        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public decimal Balance { get; set; }

        public int DepositTypeId { get; set; }

        public int? RequestId { get; set; }

        public DateTime EndDate { get; set; }

        public DepositTypeModel DepositType { get; set; }

        public int ClientId { get; set; }

        public UserViewModel ClientModel { get; set; }

        public String FormattedStartDate
        {
            get
            {
                return StartDate.ToString("dd.MM.yyyy hh:mm");
            }
        }
    }
}
