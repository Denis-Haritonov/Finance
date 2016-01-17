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

        private IDateService dateService;

        public CommentService(ICommentRepository commentRepository, IDateService dateService)
        {
            this.commentRepository = commentRepository;
            this.dateService = dateService;
        }

        public void AddComment(CommentModel commentModel)
        {
            var date = dateService.GetCurrentDate();
            var comment = new Comment
            {
                Date = date,
                IsInternal = commentModel.IsInternal,
                RequestId = commentModel.RequestId,
                Text = commentModel.Text,
                UserProfileId = commentModel.AuthorId
            };
            commentRepository.CreateComment(comment);
        }
    }
}
