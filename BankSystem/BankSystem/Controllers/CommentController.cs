using System.Web.Mvc;
using BankSystem.Models;
using BLL.Interfaces;
using BLL.Models;

namespace BankSystem.Controllers
{
    public class CommentController : BaseController
    {
        private ICommentService commentService;

        public CommentController(IUserService userService, ICommentService commentService) : base (userService)
        {
            this.commentService = commentService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LeaveComment(int requestId, PostCommentVM commentVM)
        {
            var currentUserId = CurrentUser.UserId;
            var commentModel = new CommentModel
            {
                AuthorId = currentUserId,
                IsInternal = false,
                Text = commentVM.Text,
                RequestId = commentVM.requestId
            };
            commentService.AddComment(commentModel);
            if (User.IsInRole("Client"))
            {
                return RedirectToAction("ClientDetails", "Request", new {requestId = commentModel.RequestId});
            }
            return RedirectToAction("EmployeeDetails", "Request", new {requestId = commentModel.RequestId});
        }
        
    }
}