using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public RequestModel(Request request, bool withComments = false)
        {
            Id = request.Id;
            Type = (RequestType)request.Type;
            State = (RequestState) request.State;
            Amount = request.Amount;
            Date = request.Date;
            AssignedEmployeeId = request.AssignedEmployeeId;
            ClientId = request.ClientId;
            if (Type == RequestType.Credit && request.CreditTypeId.HasValue)
            {
                CreditTypeId = request.CreditTypeId.Value;
                if (request.CreditType != null)
                {
                    TypeName = request.CreditType.Name;
                }
            }
            else if (Type == RequestType.Deposit && request.DepositTypeId.HasValue)
            {
                DepositTypeId = request.DepositTypeId.Value;
                if (request.DepositType != null)
                {
                    TypeName = request.DepositType.Name;
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

        public int? AssignedEmployeeId { get; set; }

        public int ClientId { get; set; }

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

        public String FormattedDate
        {
            get { return Date.ToString("dd.MM.yyyy hh:mm"); }
        }

        public List<CommentModel> Comments { get; set; }
    }
}
