using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;

namespace DAL.Implementation
{
    public class DepositPaymentRepository : IDepositPaymentRepository
    {
        public void CreatePayment(DepositPayment depositPayment)
        {
            using (var context = new FinanceEntities())
            {
                context.DepositPayment.Add(depositPayment);
                context.SaveChanges();
            }
        }

        public void RemovePayment(int id)
        {
            using (var context = new FinanceEntities())
            {
                var payment = context.DepositPayment.Find(id);
                context.DepositPayment.Remove(payment);
                context.SaveChanges();
            }
        }

        public List<DepositPayment> GetPaymentsPerDeposit(int depositId)
        {
            using (var context = new FinanceEntities())
            {
                return context.DepositPayment.Where(item => item.DepositId == depositId).ToList();
            }
        } 
    }
}
