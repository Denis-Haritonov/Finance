using System.Web.Mvc;
using BLL.Interfaces;

namespace BankSystem.Controllers
{
    public class CreditTypeController : BaseController
    {
        private ICreditTypeService creditTypeService;

        public CreditTypeController(ICreditTypeService creditTypeService, IUserService userService) : base(userService)
        {
            this.creditTypeService = creditTypeService;
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
    }
}
