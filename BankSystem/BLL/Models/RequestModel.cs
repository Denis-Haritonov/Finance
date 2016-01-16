using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BLL.Models.Enums;
using DAL;

namespace BLL.Models
{
    public class RequestModel
    {
        public RequestModel()
        {
        }

        public RequestModel(Request request, bool withComments = false)
        {
            Id = request.Id;
            Type = (RequestType)request.Type;
            State = (RequestState) request.State;
            Amount = request.Amount;
            Date = request.Date;
            AssignedOperatorId = request.AssignedOperatorId;
            AssignedSecurityWorkerId = request.AssignedSecurityWorkerId;
            ClientId = request.ClientId;
            if (Type == RequestType.Credit && request.CreditTypeId.HasValue)
            {
                CreditTypeId = request.CreditTypeId.Value;
                if (request.CreditType != null)
                {
                    TypeName = String.Format("{0} {1}", request.CreditType.Name, request.CreditType.CurrencyShort);
                }
            }
            else if (Type == RequestType.Deposit && request.DepositTypeId.HasValue)
            {
                DepositTypeId = request.DepositTypeId.Value;
                if (request.DepositType != null)
                {
                    TypeName = String.Format("{0} {1}", request.DepositType.Name, request.DepositType.CurrencyShort);
                }
            }
            if (withComments)
            {
                Comments = request.Comment.Select(item => new CommentModel(item)).OrderBy(item => item.Date).ToList();
            }
        }

        public int Id { get; set; }

        public RequestType Type { get; set; }

        public RequestState State { get; set; }

        public decimal Amount { get; set; }

        public int? CreditTypeId { get; set; }

        public int? DepositTypeId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        public String TypeName { get; set; }

        public int? AssignedOperatorId { get; set; }

        public int? AssignedSecurityWorkerId { get; set; }

        public int ClientId { get; set; }

        public String StatusString
        {
            get
            {
                switch (State)
                {
                    case RequestState.Pending:
                    case RequestState.SecurityCheck:
                    case RequestState.SecurityApproved:
                    case RequestState.SecurityRejected:
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

        public String FormattedDate
        {
            get { return Date.ToString("dd.MM.yyyy hh:mm"); }
        }

        public List<CommentModel> Comments { get; set; }
    }
}
