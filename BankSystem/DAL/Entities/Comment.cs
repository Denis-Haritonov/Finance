using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Comment : BaseEntity
    {
        public String Text { get; set; }

        public int RequestId { get; set; }

        [ForeignKey("RequestId")]
        public Request Request { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public UserProfile Author { get; set; }
    }
}
