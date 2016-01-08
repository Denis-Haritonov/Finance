using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Request : BaseEntity
    {
        public RequestState State { get; set; }

        public RequestType Type { get; set; }

        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public UserProfile Client { get; set; }

        public int? AssignedEmployeeId { get; set; }

        [ForeignKey("AssignedEmployeeId")]
        public UserProfile AssignedEmployee { get; set; }

        public decimal Amount { get; set; }

        public List<Comment> Comments { get; set; } 
    }
}
