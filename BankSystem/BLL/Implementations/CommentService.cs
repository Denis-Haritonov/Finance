using System;
using BLL.Interfaces;
using BLL.Models;
using DAL;
using DAL.Interfaces;

namespace BLL.Implementations
{
    public class CommentService : ICommentService
    {
        private ICommentRepository commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public void AddComment(CommentModel commentModel)
        {
            var comment = new Comment
            {
                Date = DateTime.Now,
                IsInternal = commentModel.IsInternal,
                RequestId = commentModel.RequestId,
                Text = commentModel.Text,
                UserProfileId = commentModel.AuthorId
            };
            commentRepository.CreateComment(comment);
        }
    }
}
