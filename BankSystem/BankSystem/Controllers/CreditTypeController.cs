using System;
using System.Web.Mvc;
using BankSystem.Models;
using BLL.Interfaces;
using BLL.Models;

namespace BankSystem.Controllers
{
    public class CreditTypeController : BaseController
    {
        private ICreditTypeService creditTypeService;

        private ICreditService creditService;

        public CreditTypeController(ICreditTypeService creditTypeService, IUserService userService, ICreditService creditService) : base(userService)
        {
            this.creditTypeService = creditTypeService;
            this.creditService = creditService;
        }

        public ActionResult ViewCreditTypes()
        {
            var creditTypes = creditTypeService.GetCreditTypes();
            return View(creditTypes);
        }

        public ActionResult Details(int creditTypeId)
        {
            var creditType = creditTypeService.GetCreditTypeById(creditTypeId);
            if (creditType == null)
            {
                return new HttpNotFoundResult();
            }
            return View(creditType);
        }

        public ActionResult Calculate(int creditTypeId)
        {
            var creditType = creditTypeService.GetCreditTypeById(creditTypeId);
            if (creditType == null)
            {
                return new HttpNotFoundResult();
            }
            var calculateModel = new CalculationModel
            {
                CreditType = creditType
            };
            return View(calculateModel);
        }

        [HttpPost]
        public ActionResult Calculate(int creditTypeId, CalculationModel model)
        {
            var creditType = creditTypeService.GetCreditTypeById(creditTypeId);
            if (creditType == null)
            {
                return new HttpNotFoundResult();
            }
            if (ModelState.IsValidField("Amount"))
            {
                try
                {
                    model.Result = creditService.CalculateMonthPayment(model.Amount, creditType.ReturnTerm,
                        creditType.Percent);
                }
                catch (Exception)
                {
                    model.Result = -1;
                }
            }
            else
            {
                ModelState.Clear();
                ModelState.AddModelError("", "Проверьте коректность данных");
            }
            model.CreditType = creditType;
            return View(model);
        }
    }
}
