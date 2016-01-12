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

        [Authorize(Roles = "Admin, Operator, SecurityWorker")]
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
        [Authorize(Roles = "Admin, Operator, SecurityWorker")]
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

        [Authorize(Roles = "Admin, Operator, SecurityWorker")]
        public ActionResult EmployeeDetails(int depositId)
        {
            var deposit = depositService.GetDepositById(depositId);
            if (deposit == null)
            {
                return new HttpNotFoundResult();
            }
            return View(deposit);
        }

        [Authorize(Roles = "Admin, Operator, SecurityWorker")]
        public ActionResult DepositsByClient(int clientId)
        {
            var deposits = depositService.GetClientDeposits(clientId);
            var client = userService.GetUserById(clientId);
            if (client == null)
            {
                return new HttpNotFoundResult();
            }
            var model = new ClientDepositsModel
            {
                Client = client,
                Deposits = deposits
            };
            return View(model);
        }

        [Authorize(Roles = "Client")]
        public ActionResult DepositsForClient()
        {
            var deposits = depositService.GetClientDeposits(CurrentUser.UserId);
            return View(deposits);
        }

        [Authorize(Roles = "Client")]
        public ActionResult ClientDetails(int depositId)
        {
            var deposit = depositService.GetDepositById(depositId);
            if (deposit == null)
            {
                return new HttpNotFoundResult();
            }
            if (deposit.ClientId != CurrentUser.UserId)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(deposit);
        }
    }
}
