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

        public DepositType GetDepositTypeById(int depositTypeId)
        {
            using (var context = new FinanceEntities())
            {
                return context.DepositType.FirstOrDefault(item => item.Id == depositTypeId);
            }
        }
    }
}
