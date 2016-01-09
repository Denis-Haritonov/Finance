using System;
using BLL.Models.Enums;
using DAL;
using RequestState = BLL.Models.Enums.RequestState;

namespace BLL.Models
{
    public class RequestModel
    {
        public RequestModel()
        {
        }


        public RequestModel(Request request)
        {
            Type = (RequestType)request.Type;
            State = (RequestState) request.State;
            Amount = request.Amount;
            Date = request.Date;
            if (Type == RequestType.Credit && request.CreditTypeId.HasValue)
            {
                CreditTypeId = request.CreditTypeId.Value;
                if (request.CreditType != null)
                {
                    TypeName = request.CreditType.Name;
                }
            }
            else if (Type == RequestType.Credit && request.DepositTypeId.HasValue)
            {
                CreditTypeId = request.DepositTypeId.Value;
                if (request.DepositType != null)
                {
                    TypeName = request.DepositType.Name;
                }
            }
        }

        public RequestType Type { get; set; }

        public RequestState State { get; set; }

        public decimal Amount { get; set; }

        public int CreditTypeId { get; set; }

        public int DepositTypeId { get; set; }

        public DateTime Date { get; set; }

        public String TypeName { get; set; }
    }
}
