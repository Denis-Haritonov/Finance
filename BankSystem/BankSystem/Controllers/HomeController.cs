using System.Web.Mvc;
using BLL.Interfaces;
using WebMatrix.WebData;

namespace BankSystem.Controllers
{
    public class HomeController : Controller
    {
        private IUserService service;

        public HomeController(IUserService _userService)
        {
            this.service = _userService;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            //WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            //WebSecurity.CreateUserAndAccount("Client", "123456");
            //var a = User.IsInRole("Client");
            //var b = User.IsInRole("Operator");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
