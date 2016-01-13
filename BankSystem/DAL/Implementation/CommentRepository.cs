using DAL.Interfaces;

namespace DAL.Implementation
{
    public class CommentRepository : ICommentRepository
    {
        public void CreateComment(Comment comment)
        {
            using (var context = new FinanceEntities())
            {
                context.Comment.Add(comment);
                context.SaveChanges();
            }
        }
    }
}
