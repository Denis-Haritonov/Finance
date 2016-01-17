using System;
using System.Runtime.Caching;
using System.Web.Mvc;
using BankSystem.Models;
using BLL.Interfaces;
using BLL.Models;
using BLL.Models.ViewModel;
using Common.Common;

namespace BankSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        private IUserService userService;

        private ICreditTypeService creditTypeService;

        private ICreditService creditService;

        public AdminController(IUserService userService, ICreditTypeService creditTypeService,
            ICreditService creditService)
        {
            this.userService = userService;
            this.creditTypeService = creditTypeService;
            this.creditService = creditService;
        }

        #region users

        public ActionResult Index(int page = 1, string columnName = "UserId")
        {
            var gridUsers = userService.GetUsers(page, columnName, Url.Action("CreateEditUser"));
            var model = new UserGridModel();
            model.users = gridUsers;
            return View(model);
        }

        public ActionResult CreateEditUser(int userId = 0)
        {
            CutRegisterModel model = userService.GetRegisterModelUserById(userId);
            return View(model);
        }

        public ActionResult DeleteUser(int userId)
        {
            this.userService.RemoveUser(userId);
            return RedirectToAction("Index");
        }

        public ActionResult SaveUser(CutRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                RegisterModel regModel = (RegisterModel)model;
                this.userService.AdminSaveUser(regModel);
                return RedirectToAction("Index");
            }
            else
            {
                return View("CreateEditUser", model);
            }          
        }

        #endregion

        #region Currency

        [HttpGet]
        public ActionResult Currency()
        {
            var cache = MemoryCache.Default;
            var currencyModel = cache.Get("Currency");
            if (currencyModel == null)
            {
                currencyModel = new CurrencyModel();
                ;
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

        #endregion

        #region refreshCode

        [HttpGet]
        public ActionResult RefreshCode()
        {
            var cache = MemoryCache.Default;
            var currencyModel = cache.Get("RefreshCode");
            if (currencyModel == null)
            {
                currencyModel = new RefreshCodeModel();
                ;
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

        #endregion

        #region crediType

        public ActionResult CreditTypeGrid(int page = 1)
        {
            var creditTypes = creditTypeService.GetGridCreditTypes();
            foreach (var creditType in creditTypes)
            {
                if (creditType.IsActive)
                {
                    creditType.Name = "<a href='" + Url.Action("SaveEditCreditType", new { creditTypeId = creditType.Id }) + "'>" + creditType.Name + "</a>";
                }
            }
            var model = new CreditTypeGridModel
            {
                CreditTypes = new PagingCollection<object>(creditTypes, creditTypes.Count, creditTypes.Count)
            };

            return View(model);          
        }

        [HttpGet]
        public ActionResult SaveEditCreditType(int creditTypeId = 0)
        {
            var model = creditTypeService.GetCreditTypeEditModelById(creditTypeId);
            if(model == null)
            { model = new CreditTypeEditModel();}
            
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveCreditType(CreditTypeEditModel model)
        {
            if (ModelState.IsValid)
            {
                creditTypeService.SaveEditCreditType(model);
                return RedirectToAction("CreditTypeGrid");
            }
            else
            {
                return RedirectToAction("SaveCreditType");
            }
        }

        [HttpGet]
        public ActionResult DeleteCreditType(int creditTypeId)
        {
            creditTypeService.DeleteCreditType(creditTypeId);
            return RedirectToAction("CreditTypeGrid");
        }
        #endregion

#region credits

        public ActionResult CreditGrids()
        {
            var creditTypes = creditService.GetCreditGrid();
            foreach (var credit in creditTypes)
            {
                    credit.Id = "<a href='" + Url.Action("SaveEditCredit", new { creditTypeId = credit.Id }) + "'>" + credit.Id + "</a>";
            }
            var model = new CreditGridModel
            {
                CreditTypes = new PagingCollection<object>(creditTypes, creditTypes.Count, creditTypes.Count)
            };

            return View(model);
        }

        public ActionResult SaveEditCredit(int creditId = 0)
        {
            return null;
        }

        #endregion

    }
}

