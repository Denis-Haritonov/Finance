using System.Collections.Generic;
using System.Linq;
using BLL.Models;
using DAL.Interfaces;

namespace BLL
{
    public class CreditTypeService
    {
        private ICreditTypeReporsitory creditTypeReporsitory;

        public List<CreditTypeModel> GetCreditTypes()
        {
            return creditTypeReporsitory.GetActiveCreditTypes().Select(item => new CreditTypeModel(item)).ToList();
        } 
    }
}
