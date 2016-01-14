using System.Web.Mvc;
using System.Web.Security;
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
            //WebSecurity.CreateUserAndAccount("Employee2", "123456");
            //var a = User.IsInRole("Client");
            //var b = User.IsInRole("Operator");
            //var c = Roles.IsUserInRole("Client");
            //var d = Roles.IsUserInRole("Operator");
            return View();
        }

        public ActionResult Currency()
        {
            return View();
        }
    }
}
