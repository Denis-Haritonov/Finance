using System.Web.Mvc;
using BLL;

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
            var requestService = new RequestService();
            
            return View();
        }

        public ActionResult CreateDepositRequest()
        {
            return View();
        }
    }
}