using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;

namespace BLL.Implementations
{
    public class CreditTypeService : ICreditTypeService
    {
        private ICreditTypeReporsitory creditTypeReporsitory;

        public CreditTypeService(ICreditTypeReporsitory creditTypeReporsitory)
        {
            this.creditTypeReporsitory = creditTypeReporsitory;
        }

        public List<CreditTypeModel> GetCreditTypes()
        {
            return creditTypeReporsitory.GetActiveCreditTypes().Select(item => new CreditTypeModel(item)).ToList();
        } 
    }
}
