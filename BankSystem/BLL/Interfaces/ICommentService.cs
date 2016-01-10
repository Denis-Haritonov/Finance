using BLL.Models;

namespace BLL.Interfaces
{
    public interface ICommentService
    {
        void AddComment(CommentModel commentModel);
    }
}
