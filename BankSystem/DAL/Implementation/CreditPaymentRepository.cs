using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces;

namespace DAL.Implementation
{
    public class CreditPaymentRepository : ICreditPaymentRepository
    {
        public void CreatePayment(CreditPayment creditPayment)
        {
            using (var context = new FinanceEntities())
            {
                context.CreditPayment.Add(creditPayment);
                context.SaveChanges();
            }
        }

        public void RemovePayment(int id)
        {
            using (var context = new FinanceEntities())
            {
                var payment = context.CreditPayment.Find(id);
                context.CreditPayment.Remove(payment);
                context.SaveChanges();
            }
        }

        public List<CreditPayment> GetPaymentsPerCredit(int creditId)
        {
            using (var context = new FinanceEntities())
            {
                return
                    context.CreditPayment.Include(item => item.Credit).Where(item => item.CreditId == creditId).ToList();
            }
        }

        public CreditPayment GetPaymentById(int creditPaymentId)
        {
            using (var context = new FinanceEntities())
            {
                return
                    context.CreditPayment.Include(item => item.Credit)
                        .Include(item => item.Credit.CreditType)
                        .Include(item => item.Credit.UserProfile)
                        .FirstOrDefault(item => item.Id == creditPaymentId);
            }
        }
    }
}
