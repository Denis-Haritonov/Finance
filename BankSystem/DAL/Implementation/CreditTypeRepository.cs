using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;

namespace DAL.Implementation
{
    public class CreditTypeRepository : ICreditTypeReporsitory
    {
        public List<CreditType> GetActiveCreditTypes()
        {
            using (var context = new FinanceEntities())
            {
                return context.CreditType.Where(ct => ct.IsActive).ToList();
            }
        }

        public CreditType GetCreditTypeById(int creditTypeId)
        {
            using (var context = new FinanceEntities())
            {
                return context.CreditType.FirstOrDefault(ct => ct.Id == creditTypeId);
            }
        }
    }
}
