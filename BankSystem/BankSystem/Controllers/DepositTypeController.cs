using System.Web.Mvc;
using BLL.Interfaces;

namespace BankSystem.Controllers
{
    public class DepositTypeController : BaseController
    {
        private IDepositTypeService depositTypeService;

        public DepositTypeController(IDepositTypeService depositTypeService, IUserService userService)
            : base(userService)
        {
            this.depositTypeService = depositTypeService;
        }

        public ActionResult ViewDepositTypes()
        {
            var depositTypes = depositTypeService.GetDepositTypes();
            return View(depositTypes);
        }

        public ActionResult Details(int depositTypeId)
        {
            var depositType = depositTypeService.GetDepositTypeById(depositTypeId);
            if (depositType == null)
            {
                return new HttpNotFoundResult();
            }
            return View(depositType);
        }
    }
}
