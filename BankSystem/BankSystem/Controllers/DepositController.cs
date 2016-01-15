using System.Net;
using System.Web.Mvc;
using BankSystem.Models;
using BLL.Interfaces;
using BLL.Models;
using BLL.Models.Enums;

namespace BankSystem.Controllers
{
    public class DepositController : BaseController
    {
        private IDepositService depositService;

        private IRequestService requestService;

        private IDepositPaymentService depositPaymentService;

        public DepositController(IDepositService depositService, IUserService userService,
            IRequestService requestService, IDepositPaymentService depositPaymentService) : base(userService)
        {
            this.depositService = depositService;
            this.requestService = requestService;
            this.depositPaymentService = depositPaymentService;
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

        [Authorize(Roles = "Admin, Operator, SecurityWorker")]
        public ActionResult CancelPayment(int paymentId)
        {
            var payment = depositPaymentService.GetPaymentById(paymentId);
            if (payment == null)
            {
                return new HttpNotFoundResult();
            }
            depositPaymentService.CancelPayment(paymentId);
            return RedirectToAction("EmployeeDetails", new {depositId = payment.DepositId});
        }

        [Authorize(Roles = "Admin, Operator, SecurityWorker")]
        public ActionResult IncomePayment(int depositId)
        {
            var deposit = depositService.GetDepositById(depositId);
            if (deposit == null)
            {
                return new HttpNotFoundResult();
            }
            var paymentModel = new DepositPaymentModel
            {
                DepositModel = deposit,
                DepositId = depositId
            };
            return View(paymentModel);
        }

        [Authorize(Roles = "Admin, Operator, SecurityWorker")]
        public ActionResult OutcomePayment(int depositId)
        {
            var deposit = depositService.GetDepositById(depositId);
            if (deposit == null)
            {
                return new HttpNotFoundResult();
            }
            var paymentModel = new DepositPaymentModel
            {
                DepositModel = deposit,
                DepositId = depositId
            };
            return View(paymentModel);
        }

        [Authorize(Roles = "Admin, Operator, SecurityWorker")]
        [HttpPost]
        public ActionResult IncomePayment(int depositId, DepositPaymentModel paymentModel)
        {
            var deposit = depositService.GetDepositById(depositId);
            if (deposit == null)
            {
                return new HttpNotFoundResult();
            }
            if (ModelState.IsValid && paymentModel.Amount > 0)
            {
                paymentModel.Type = DepositPaymentType.Income;
                depositPaymentService.AddPayment(paymentModel);
                return RedirectToAction("EmployeeDetails", new {depositId = depositId});
            }
            paymentModel.DepositModel = deposit;
            return View(paymentModel);
        }

        [Authorize(Roles = "Admin, Operator, SecurityWorker")]
        [HttpPost]
        public ActionResult OutcomePayment(int depositId, DepositPaymentModel paymentModel)
        {
            var deposit = depositService.GetDepositById(depositId);
            if (deposit == null)
            {
                return new HttpNotFoundResult();
            }
            if (ModelState.IsValid && paymentModel.Amount > 0 && paymentModel.Amount <= deposit.Balance)
            {
                paymentModel.Type = DepositPaymentType.Outcome;
                depositPaymentService.AddPayment(paymentModel);
                return RedirectToAction("EmployeeDetails", new { depositId = depositId });
            }
            paymentModel.DepositModel = deposit;
            return View(paymentModel);
        }
    }
}
