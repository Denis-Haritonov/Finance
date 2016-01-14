using System.Web.Mvc;
using BLL.Interfaces;
using BLL.Models.ViewModel;

namespace BankSystem.Controllers
{
    public class BaseController : Controller
    {
        protected IUserService userService;

        private UserViewModel currentUser;

        public BaseController(IUserService userService)
        {
            this.userService = userService;
        }

        public UserViewModel CurrentUser
        {
            get
            {
                if (currentUser == null)
                {
                    currentUser = userService.GetUserByLogin(User.Identity.Name);
                }
                return currentUser;
            }
        }
    }
}