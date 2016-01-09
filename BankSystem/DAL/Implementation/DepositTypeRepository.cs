using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;

namespace DAL.Implementation
{
    public class DepositTypeRepository : IDepositTypeRepository
    {
        public List<DepositType> GetActiveDepositTypes()
        {
            using (var context = new FinanceEntities())
            {
                return context.DepositType.Where(dt => dt.IsActive).ToList();
            }
        } 
    }
}
