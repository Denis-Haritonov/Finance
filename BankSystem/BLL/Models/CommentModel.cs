using System;
using DAL;

namespace BLL.Models
{
    public class CommentModel
    {
        public CommentModel()
        {
        }

        public CommentModel(Comment comment)
        {
            Id = comment.Id;
            Text = comment.Text;
            AuthorId = comment.UserProfileId;
            IsInternal = comment.IsInternal;
            Date = comment.Date;
            RequestId = comment.RequestId;
            if (comment.UserProfile != null)
            {
                AuthorName = String.Format("{0} {1}", comment.UserProfile.UserName, comment.UserProfile.UserSurname);
            }
        }
        
        public int Id { get; set; }
        
        public string Text { get; set; }
        
        public int AuthorId { get; set; }
        
        public bool IsInternal { get; set; }
        
        public DateTime Date { get; set; }

        public int RequestId { get; set; }

        public String AuthorName { get; set; }
    }
}
