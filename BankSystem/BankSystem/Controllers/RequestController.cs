using System;
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

        public RequestController(IRequestService requestService, IDepositTypeService depositTypeService,
            ICreditTypeService creditTypeService, IUserService userService) : base (userService)
        {
            this.requestService = requestService;
            this.depositTypeService = depositTypeService;
            this.creditTypeService = creditTypeService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateCreditRequest()
        {
            var creditTypes = creditTypeService.GetCreditTypes();
            var creditRequestModel = new CreditRequestVM
            {
                CreditTypes =
                    creditTypes.Select(item => new SelectListItem {Text = item.Name, Value = item.Id.ToString()})
                        .ToList(),
                RequestModel = new RequestModel()
            };
            var firstCreditType = creditRequestModel.CreditTypes.FirstOrDefault();
            if (firstCreditType != null)
            {
                firstCreditType.Selected = true;
            }
            return View(creditRequestModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCreditRequest(CreditRequestVM model)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;
                model.RequestModel.State = RequestState.Pending;
                model.RequestModel.Type = RequestType.Credit;
                var message = requestService.CreateRequest(model.RequestModel, userName);
                if (String.IsNullOrEmpty(message))
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(String.Empty, message);
            }
            return View(model);
        }

        public ActionResult CreateDepositRequest()
        {
            var depositTypes = depositTypeService.GetDepositTypes();
            var depositRequestModel = new DepositRequestVM
            {
                DepositTypes =
                    depositTypes.Select(item => new SelectListItem {Text = item.Name, Value = item.Id.ToString()})
                        .ToList(),
                RequestModel = new RequestModel()
            };
            var firstDepositType = depositRequestModel.DepositTypes.FirstOrDefault();
            if (firstDepositType != null)
            {
                firstDepositType.Selected = true;
            }
            return View(depositRequestModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDepositRequest(DepositRequestVM model)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;
                model.RequestModel.State = RequestState.Pending;
                model.RequestModel.Type = RequestType.Deposit;
                var message = requestService.CreateRequest(model.RequestModel, userName);
                if (String.IsNullOrEmpty(message))
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(String.Empty, message);
            }
            return View(model);
        }

        public ActionResult ClientViewRequests()
        {
            var user = userService.GetUserByLogin(User.Identity.Name);
            var clientRequests = requestService.GetRequestsByClient(user.UserId);
            return View(clientRequests);
        }

        public ActionResult ClientDetails(int requestId)
        {
            var requestModel = requestService.GetRequestDetails(requestId);
            return View(requestModel);
        }

        public ActionResult EmployeeDetails(int requestId)
        {
            var requestModel = requestService.GetRequestDetails(requestId);
            var viewModel = new EmployeeRequestDetailsVM
            {
                RequestModel = requestModel,
                IsAssignedToCurrent = CurrentUser.UserId == requestModel.AssignedEmployeeId
            };
            return View(viewModel);
        }

        public ActionResult RequestsQue()
        {
            var user = userService.GetUserByLogin(User.Identity.Name);
            var requests = requestService.GetRequestQueForEmployee(user.UserId);
            return View(requests);
        }

        public ActionResult AssignRequest(int requestId)
        {
            requestService.AssignRequestToEmployee(requestId, CurrentUser.UserId);
            return RedirectToAction("EmployeeDetails", new {requestId = requestId});
        }

        public ActionResult ApproveRequest(int requestId)
        {
            var request = requestService.GetRequestDetails(requestId);
            if (request.AssignedEmployeeId == CurrentUser.UserId)
            {
                requestService.ChangeRequestState(requestId, RequestState.Approved);
            }
            return RedirectToAction("RequestsQue");
        }

        public ActionResult RejectRequest(int requestId)
        {
            var request = requestService.GetRequestDetails(requestId);
            if (request.AssignedEmployeeId == CurrentUser.UserId)
            {
                requestService.ChangeRequestState(requestId, RequestState.Rejected);
            }
            return RedirectToAction("RequestsQue");
        }

    }
}