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

        private IDepositService depositService;

        private ICreditService creditService;

        public HomeController(IUserService _userService, ICreditService creditService, IDepositService depositService)
        {
            this.service = _userService;
            this.creditService = creditService;
            this.depositService = depositService;
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
            return View();
        }

        public ActionResult CreditPercent()
        {
            try
            {
                creditService.Percents();
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Maintain");
        }

        public ActionResult DepositPercent()
        {
            try
            {
                depositService.Percents();
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Maintain");
        }
    }
}
