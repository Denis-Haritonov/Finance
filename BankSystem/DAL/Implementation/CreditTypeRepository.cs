using System.Collections.Generic;
using System.Data.Entity;
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

        public List<CreditType> GetCreditTypes()
        {
            using (var context = new FinanceEntities())
            {
                return context.CreditType.ToList();
            }
        }


        public void SaveUpdateCreditType(CreditType model)
        {
            using (var context = new FinanceEntities())
            {
                if (model.Id == 0)
                {
                    context.CreditType.Add(model);
                }
                else
                {
                    context.Entry(model).State = EntityState.Modified;;
                }

                context.SaveChanges();
            }
        }

        public CreditType GetCreditTypeById(int creditTypeId)
        {
            using (var context = new FinanceEntities())
            {
                return context.CreditType.FirstOrDefault(ct => ct.Id == creditTypeId);
            }
        }

        public void DeleteCreditType(int creditTypeId)
        {
            using (var context = new FinanceEntities())
            {
                context.CreditType.Remove(context.CreditType.First(ct => ct.Id == creditTypeId));
            }

        }
    }
}
