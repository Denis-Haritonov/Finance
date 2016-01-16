using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BankSystem.Models;
using BLL.Interfaces;
using BLL.Models;
using BLL.Models.Enums;

namespace BankSystem.Controllers
{
    public class RequestController : BaseController
    {
        private IRequestService requestService;

        private IDepositTypeService depositTypeService;

        private ICreditTypeService creditTypeService;

        private IDepositService depositService;

        private ICreditService creditService;

        public RequestController(IRequestService requestService, IDepositTypeService depositTypeService,
            ICreditTypeService creditTypeService, IUserService userService, ICreditService creditService, IDepositService depositService) : base (userService)
        {
            this.requestService = requestService;
            this.depositTypeService = depositTypeService;
            this.creditTypeService = creditTypeService;
            this.creditService = creditService;
            this.depositService = depositService;
        }

        [Authorize(Roles = "Client")]
        public ActionResult CreateCreditRequest()
        {
            var creditRequestModel = new CreditRequestVM
            {
                CreditTypes = GetCreditTypesListItems(),
                RequestModel = new RequestModel()
            };
            var firstCreditType = creditRequestModel.CreditTypes.FirstOrDefault();
            if (firstCreditType != null)
            {
                firstCreditType.Selected = true;
            }
            return View(creditRequestModel);
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCreditRequest(CreditRequestVM model)
        {
            if (ModelState.IsValid)
            {
                model.RequestModel.ClientId = CurrentUser.UserId;
                model.RequestModel.State = RequestState.Pending;
                model.RequestModel.Type = RequestType.Credit;
                requestService.CreateRequest(model.RequestModel);
                return RedirectToAction("ClientViewRequests");
            }
            model.CreditTypes = GetCreditTypesListItems();
            return View(model);
        }

        [Authorize(Roles = "Client")]
        public ActionResult CreateDepositRequest()
        {
            
            var depositRequestModel = new DepositRequestVM
            {
                DepositTypes = GetDepositTypesListItems(),
                RequestModel = new RequestModel()
            };
            var firstDepositType = depositRequestModel.DepositTypes.FirstOrDefault();
            if (firstDepositType != null)
            {
                firstDepositType.Selected = true;
            }
            return View(depositRequestModel);
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDepositRequest(DepositRequestVM model)
        {
            if (ModelState.IsValid)
            {
                model.RequestModel.ClientId = CurrentUser.UserId;
                model.RequestModel.State = RequestState.Pending;
                model.RequestModel.Type = RequestType.Deposit;
                requestService.CreateRequest(model.RequestModel);
                return RedirectToAction("ClientViewRequests");
            }
            model.DepositTypes = GetDepositTypesListItems();
            return View(model);
        }

        [Authorize(Roles = "Client")]
        public ActionResult ClientViewRequests()
        {
            var userId = CurrentUser.UserId;
            var clientRequests = requestService.GetRequestsByClient(userId);
            return View(clientRequests);
        }

        [Authorize(Roles = "Client")]
        public ActionResult ClientDetails(int requestId)
        {
            var requestModel = requestService.GetRequestDetails(requestId);
            return View(requestModel);
        }

        [Authorize(Roles = "Admin, Operator, SecurityWorker")]
        public ActionResult EmployeeDetails(int requestId)
        {
            var requestModel = requestService.GetRequestDetails(requestId);
            if (requestModel == null)
            {
                return new HttpNotFoundResult();
            }
            var deposit = depositService.FindByRequestId(requestId);
            var credit = creditService.FindByRequestId(requestId);
            var viewModel = new EmployeeRequestDetailsVM
            {
                RequestModel = requestModel,
                IsAssignedToCurrent = CurrentUser.UserId == requestModel.AssignedOperatorId || CurrentUser.UserId == requestModel.AssignedSecurityWorkerId,
                DepositModel = deposit,
                CreditModel = credit
            };
            return View(viewModel);
        }

        [Authorize(Roles = "Admin, Operator, SecurityWorker")]
        public ActionResult RequestsQue()
        {
            var userId = CurrentUser.UserId;
            var requests = requestService.GetRequestQueForEmployee(userId);
            var requestsQueModel = new RequestsQueVM
            {
                Requests = requests,
                CurrentUser = CurrentUser
            };
            return View(requestsQueModel);
        }

        [Authorize(Roles = "Operator")]
        public ActionResult ToApprove()
        {
            var userId = CurrentUser.UserId;
            var requests =
                requestService.GetCheckedRequestQueForEmployee(userId).ToList();
            var requestsQueModel = new RequestsQueVM
            {
                Requests = requests,
                CurrentUser = CurrentUser
            };
            return View(requestsQueModel);
        }

        [Authorize(Roles = "Admin, Operator, SecurityWorker")]
        public ActionResult AssignRequest(int requestId)
        {
            requestService.AssignRequestToOperator(requestId, CurrentUser.UserId);
            return RedirectToAction("EmployeeDetails", new {requestId = requestId});
        }

        [Authorize(Roles = "Operator, SecurityWorker")]
        public ActionResult ApproveRequest(int requestId)
        {
            var request = requestService.GetRequestDetails(requestId);
            if (request.AssignedOperatorId == CurrentUser.UserId)
            {
                requestService.ChangeRequestState(requestId, RequestState.Approved);
            }
            if (request.AssignedSecurityWorkerId == CurrentUser.UserId)
            {
                requestService.ChangeRequestState(requestId, RequestState.SecurityApproved);
            }
            if (User.IsInRole("Operator"))
            {
                return RedirectToAction("RequestsQue");
            }
            return RedirectToAction("ApproveQue", "SecurityWorker");
        }

        [Authorize(Roles = "Operator, SecurityWorker")]
        public ActionResult RejectRequest(int requestId)
        {
            var request = requestService.GetRequestDetails(requestId);
            if (request.AssignedOperatorId == CurrentUser.UserId)
            {
                requestService.ChangeRequestState(requestId, RequestState.Rejected);
            }
            if (request.AssignedSecurityWorkerId == CurrentUser.UserId)
            {
                requestService.ChangeRequestState(requestId, RequestState.SecurityRejected);
            }
            if (User.IsInRole("Operator"))
            {
                return RedirectToAction("RequestsQue");
            }
            return RedirectToAction("ApproveQue", "SecurityWorker");
        }

        [Authorize(Roles = "Operator")]
        public ActionResult ToSecurityWorker(int requestId)
        {
            var request = requestService.GetRequestDetails(requestId);
            requestService.ChangeRequestState(requestId, RequestState.SecurityCheck);
            return RedirectToAction("RequestsQue", "Request");
        }

        private List<SelectListItem> GetDepositTypesListItems()
        {
            var depositTypes = depositTypeService.GetDepositTypes();
            return
                depositTypes.Select(item => new SelectListItem { Text = String.Format("{0} {1}", item.Name, item.CurrencyShort), Value = item.Id.ToString() }).ToList();
        }

        private List<SelectListItem> GetCreditTypesListItems()
        {
            var creditTypes = creditTypeService.GetCreditTypes();
            return
                creditTypes.Select(item => new SelectListItem { Text = String.Format("{0} {1}", item.Name, item.CurrencyShort), Value = item.Id.ToString() }).ToList();
        } 
    }
}