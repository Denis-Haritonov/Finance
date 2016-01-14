using System;
using System.Web.Mvc;
using BLL.Interfaces;
using RestSharp;

namespace BankSystem.Controllers
{
    [Authorize(Roles = "Client")]
    public class ClientController : BaseController
    {
        private const String ApiUrl = @"http://mammonwebapi.azurewebsites.net";

        public ClientController(IUserService userService) : base(userService)
        {
        }

        public ActionResult Personal()
        {
            RestClient restClient = new RestClient(ApiUrl);
            var request = new RestRequest(@"scoringsystem/getscores", Method.GET);
            request.AddParameter("clientId", CurrentUser.UserId);
            var response = restClient.Execute(request);
            var content = response.Content.Replace("\"", "").Replace(".", ",");
            float score;
            var result = Single.TryParse(content, out score);
            if (result)
            {
                ViewBag.Score = score;
            }
            return View(CurrentUser);
        }
    }
}
