using System.Web.Mvc;
using BankSystem.Models;
using BLL.Interfaces;

namespace BankSystem.Controllers
{
    [Authorize(Roles = "SecurityWorker")]
    public class SecurityWorkerController : BaseController
    {
        private IRequestService requestService;

        public SecurityWorkerController(IUserService userService, IRequestService requestService) : base(userService)
        {
            this.requestService = requestService;
        }

        public ActionResult ApproveQue()
        {
            var userId = CurrentUser.UserId;
            var requests = requestService.GetRequestsQueForSecurityWorker(userId);
            var requestsQueModel = new RequestsQueVM
            {
                Requests = requests,
                CurrentUser = CurrentUser
            };
            return View(requestsQueModel);
        }

        public ActionResult AssignRequest(int requestId)
        {
            requestService.AssignRequestToSecurityWorker(requestId, CurrentUser.UserId);
            return RedirectToAction("EmployeeDetails", "Request", new { requestId = requestId });
        }
    }
}
