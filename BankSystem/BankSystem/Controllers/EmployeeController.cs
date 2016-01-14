using System;
using System.Web.Mvc;
using BankSystem.Models;
using BLL.Interfaces;
using RestSharp;

namespace BankSystem.Controllers
{
    [Authorize(Roles = "Admin, Operator, SecurityWorker")]
    public class EmployeeController : BaseController
    {
        private const String ApiUrl = @"http://mammonwebapi.azurewebsites.net";

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
                RestClient restClient = new RestClient(ApiUrl);
                var request = new RestRequest(@"scoringsystem/getscores", Method.GET);
                request.AddParameter("clientId", client.UserId);
                var response = restClient.Execute(request);
                var content = response.Content.Replace("\"", "").Replace(".", ",");
                float score;
                var result = Single.TryParse(content, out score);
                if (result)
                {
                    client.ScoringMark = score;
                }
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
