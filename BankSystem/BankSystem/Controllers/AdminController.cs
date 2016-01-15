using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankSystem.Models;
using BLL.Interfaces;
using BLL.Models.GridModels;
using BLL.Models.ViewModel;
using WebMatrix.WebData;

namespace BankSystem.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        private IUserService userService;

        public AdminController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index(int page = 1,string columnName = "UserId" )
        {
            var gridUsers = userService.GetUsers(page, columnName, Url.Action("CreateEditUser"));
            var model = new UserGridModel();
            model.users = gridUsers;
            return View(model);
        }

        public ActionResult CreateEditUser(int userId = 0)
        {
            return View("Index");
        }

        public ActionResult DeleteUser(int userId)
        {
            return View("Index");
        }

        [CaptchaValidator]
        public ActionResult SaveUser(RegisterModel model,bool captchaValid)
        {
            return View("Index");
        }
    }
}
