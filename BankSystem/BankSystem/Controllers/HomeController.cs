using System;
using System.Runtime.Caching;
using System.Web.Mvc;
using BLL.Interfaces;
using BLL.Models.ViewModel;

namespace BankSystem.Controllers
{
    public class HomeController : Controller
    {
        private IUserService service;

        private IDateService dateService;

        public HomeController(IUserService _userService, IDateService dateService)
        {
            this.service = _userService;
            this.dateService = dateService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Currency()
        {
            var cache = MemoryCache.Default;
            var currencyModel = cache.Get("Currency");
            if (currencyModel == null)
            {
                currencyModel = new CurrencyModel();
            }
            return View(currencyModel);
        }

        public ActionResult Maintain()
        {
            ViewBag.CurrentDate = dateService.GetCurrentDate();
            return View();
        }

        public ActionResult DayForward()
        {
            dateService.DayForward();
            return RedirectToAction("Maintain");
        }

        public ActionResult MonthForward()
        {
            dateService.MonthForward();
            return RedirectToAction("Maintain");
        }

        public ActionResult YearForward()
        {
            dateService.YearForward();
            return RedirectToAction("Maintain");
        }

        public ActionResult ResetDate()
        {
            dateService.Reset();
            return RedirectToAction("Maintain");
        }
    }
}
