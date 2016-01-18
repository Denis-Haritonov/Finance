using System.Collections.Generic;
using System.Data.Entity;
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


        public List<DepositType> GetDepositRows()
        {
            using (var context = new FinanceEntities())
            {
                return context.DepositType
                    .ToList();
            }
        }

        public void SaveOrUpdate(DepositType model)
        {
            using (var context = new FinanceEntities())
            {
                if (model.Id == 0)
                {
                    context.DepositType.Add(model);
                }
                else
                {
                    context.Entry(model).State = EntityState.Modified;
                }

                context.SaveChanges();
            }
        }
    }
}
