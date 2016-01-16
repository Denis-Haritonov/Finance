using System;
using System.Runtime.Caching;
using System.Web.Mvc;
using BankSystem.Models;
using BLL.Interfaces;
using BLL.Models.ViewModel;

namespace BankSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        private IUserService userService;

        public AdminController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index(int page = 1, string columnName = "UserId")
        {
            var gridUsers = userService.GetUsers(page, columnName, Url.Action("CreateEditUser"));
            var model = new UserGridModel();
            model.users = gridUsers;
            return View(model);
        }

        public ActionResult CreateEditUser(int userId = 0)
        {
            RegisterModel model = userService.GetRegisterModelUserById(userId);
            return View(model);
        }

        public ActionResult DeleteUser(int userId)
        {
            this.userService.RemoveUser(userId);
            return RedirectToAction("Index");
        }

        public ActionResult SaveUser(RegisterModel model)
        {
            this.userService.AdminSaveUser(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Currency()
        {
            var cache = MemoryCache.Default;
            var currencyModel = cache.Get("Currency");
            if (currencyModel == null)
            {
                currencyModel = new CurrencyModel(); ;
            }
            return View(currencyModel);
        }

        [HttpPost]
        public ActionResult Currency(CurrencyModel model)
        {
            if (ModelState.IsValid)
            {
                var cache = MemoryCache.Default;
                cache.Remove("Currency");
                cache.Add("Currency", model, DateTimeOffset.UtcNow.AddMinutes(8000));
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult RefreshCode()
        {
            var cache = MemoryCache.Default;
            var currencyModel = cache.Get("RefreshCode");
            if (currencyModel == null)
            {
                currencyModel = new RefreshCodeModel(); ;
            }
            return View(currencyModel);
        }

        [HttpPost]
        public ActionResult RefreshCode(RefreshCodeModel model)
        {
            if (ModelState.IsValid)
            {
                var cache = MemoryCache.Default;
                cache.Remove("RefreshCode");
                cache.Add("RefreshCode", model, DateTimeOffset.UtcNow.AddMinutes(8000));
            }
            return View(model);
        }
    }
}

