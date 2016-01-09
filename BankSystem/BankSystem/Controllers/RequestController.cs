using System;
using System.Linq;
using System.Web.Mvc;
using BankSystem.Models;
using BLL;
using BLL.Models;
using BLL.Models.Enums;

namespace BankSystem.Controllers
{
    public class RequestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateCreditRequest()
        {
            var creditTypeService = new CreditTypeService();
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
                var requestService = new RequestService();
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
            var depositTypeService = new DepositTypeService();
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
                var requestService = new RequestService();
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
            var requestService = new RequestService();
            var userService = new UserService();
            var user = userService.GetUserByLogin(User.Identity.Name);
            var clientRequests = requestService.GetRequestsByClient(user.Id);
            return View(clientRequests);
        }

        public ActionResult ClientDetails(int requestId)
        {
            var requsetService = new RequestService();
            var request = requsetService
        }
    }
}