using System;

namespace BankSystem.Models
{
    public class PostCommentVM
    {
        public String Text { get; set; }

        public int requestId { get; set; }

        public String IsInternal { get; set; }
    }
}