using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankSystem.Controllers
{
    public class InfoController : Controller
    {
      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Individuals()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Comercial()
        {
            return View();
        }

    }
}
