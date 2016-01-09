using System.Collections.Generic;
using System.Linq;

namespace DAL.Implementation
{
    public class CreditTypeRepository
    {
        public List<CreditType> GetActiveCreditTypes()
        {
            using (var context = new FinanceEntities())
            {
                return context.CreditType.Where(ct => ct.IsActive).ToList();
            }
        } 
    }
}
