using System;
using System.Collections.Generic;
using System.Linq;
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
            Id = request.Id;
            Type = (RequestType)request.Type;
            State = (RequestState) request.State;
            Amount = request.Amount;
            Date = request.Date;
            AssignedEmployeeId = request.AssignedEmployeeId;
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
            if (request.Comment != null)
            {
                Comments = request.Comment.Select(item => new CommentModel(item)).OrderBy(item => item.Date).ToList();
            }
        }

        public int Id { get; set; }

        public RequestType Type { get; set; }

        public RequestState State { get; set; }

        public decimal Amount { get; set; }

        public int CreditTypeId { get; set; }

        public int DepositTypeId { get; set; }

        public DateTime Date { get; set; }

        public String TypeName { get; set; }

        public int? AssignedEmployeeId { get; set; }

        public String StatusString
        {
            get
            {
                switch (State)
                {
                    case RequestState.Pending:
                        return "Рассматривается";
                    case RequestState.Approved:
                        return "Подтверждена";
                    case RequestState.Rejected:
                        return "Отклонена";
                    default:
                        return String.Empty;
                }
            }
        }

        public List<CommentModel> Comments { get; set; }
    }
}
