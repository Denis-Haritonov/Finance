using System;
using System.Net;
using System.Web.Mvc;
using BankSystem.Models;
using BLL.Interfaces;

namespace BankSystem.Controllers
{
    [Authorize(Roles = "Admin, Operator, SecurityWorker")]
    public class EmployeeController : BaseController
    {
        private IRequestService requestService;

        public EmployeeController(IUserService userService, IRequestService requestService) : base(userService)
        {
            this.requestService = requestService;
        }

        public ActionResult FindClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindClient(ClientSearchModel model)
        {
            if (!String.IsNullOrWhiteSpace(model.SearchTerm))
            {
                var user = userService.GetUserByLogin(model.SearchTerm);
                if (user != null)
                {
                    return RedirectToAction("ClientDetails", new {clientId = user.UserId});
                }
            }
            ModelState.AddModelError("", "Пользователь не найден");
            return View(model);
        }

        public ActionResult ClientDetails(int clientId)
        {
            var client = userService.GetUserById(clientId);
            if (client != null)
            {
                return View(client);
            }
            return RedirectToAction("FindClient");
        }

        public ActionResult ClientRequests(int clientId)
        {
            var client = userService.GetUserById(clientId);
            if (client == null)
            {
                return new HttpNotFoundResult();
            }
            var requests = requestService.GetRequestsByClient(clientId);
            var model = new ClientInfoModel
            {
                UserModel = client,
                Requests = requests
            };
            return View(model);
        }
    }
}
