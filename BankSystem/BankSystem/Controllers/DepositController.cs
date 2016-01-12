using System.Net;
using System.Web.Mvc;
using BankSystem.Models;
using BLL.Interfaces;
using BLL.Models.Enums;

namespace BankSystem.Controllers
{
    public class DepositController : BaseController
    {
        private IDepositService depositService;

        private IRequestService requestService;

        public DepositController(IDepositService depositService, IUserService userService, IRequestService requestService) : base(userService)
        {
            this.depositService = depositService;
            this.requestService = requestService;
        }

        [System.Web.Http.Authorize(Roles = "Admin, Operator, SecurityWorker")]
        public ActionResult OpenDeposit(int requestId)
        {
            var request = requestService.GetRequestDetails(requestId);
            if (request == null)
            {
                return new HttpNotFoundResult();
            }
            if (request.Type != RequestType.Deposit)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = new OpenDepositModel
            {
                RequestModel = request,
                Amount = request.Amount
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [System.Web.Http.Authorize(Roles = "Admin, Operator, SecurityWorker")]
        public ActionResult OpenDeposit(int requestId, OpenDepositModel model)
        {
            var request = requestService.GetRequestDetails(requestId);
            if (request == null)
            {
                return new HttpNotFoundResult();
            }
            if (request.Type != RequestType.Deposit)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValidField("Amount"))
            {
                request.Amount = model.Amount;
                depositService.OpenDeposit(request);
                var deposit = depositService.FindByRequestId(requestId);
                if (deposit != null)
                {
                    return RedirectToAction("EmployeeDetails", new {depositId = deposit.Id});
                }
                return RedirectToAction("Index", "Home");
            }
            model.RequestModel = request;
            return View(model);
        }

        [System.Web.Http.Authorize(Roles = "Admin, Operator, SecurityWorker")]
        public ActionResult EmployeeDetails(int depositId)
        {
            var deposit = depositService.GetDepositById(depositId);
            if (deposit == null)
            {
                return new HttpNotFoundResult();
            }
            return View(deposit);
        }
    }
}
