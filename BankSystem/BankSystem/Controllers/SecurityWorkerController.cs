using System.Web.Mvc;
using BankSystem.Models;
using BLL.Interfaces;

namespace BankSystem.Controllers
{
    [Authorize(Roles = "SecurityWorker")]
    public class SecurityWorkerController : BaseController
    {
        private IRequestService requestService;

        private ICreditService creditService;

        public SecurityWorkerController(IUserService userService, IRequestService requestService, ICreditService creditService) : base(userService)
        {
            this.requestService = requestService;
            this.creditService = creditService;
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

        public ActionResult OverdueCredits()
        {
            var credits = creditService.GetOverdueCredits();
            return View(credits);
        }

        public ActionResult CloseCredit(int creditId)
        {
            creditService.CloseCredit(creditId);
            return RedirectToAction("OverdueCredits");
        }
    }
}
