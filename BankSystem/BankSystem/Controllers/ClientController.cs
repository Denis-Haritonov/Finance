using System.Web.Mvc;
using BLL.Interfaces;

namespace BankSystem.Controllers
{
    [Authorize(Roles = "Client")]
    public class ClientController : BaseController
    {
        public ClientController(IUserService userService) : base(userService)
        {
        }

        public ActionResult Personal()
        {
            return View();
        }
    }
}
