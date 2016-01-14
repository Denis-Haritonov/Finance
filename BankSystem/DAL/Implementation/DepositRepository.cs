using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces;

namespace DAL.Implementation
{
    public class DepositRepository : IDepositRepository
    {
        public void CreateDeposit(Deposit deposit)
        {
            using (var context = new FinanceEntities())
            {
                context.Deposit.Add(deposit);
                context.SaveChanges();
            }
        }

        public void UpdateDeposit(Deposit deposit)
        {
            using (var context = new FinanceEntities())
            {
                context.Deposit.Attach(deposit);
                context.Entry(deposit).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Deposit FindByRequestId(int requestId)
        {
            using (var context = new FinanceEntities())
            {
                return
                    context.Deposit.Include(item => item.DepositType)
                        .Include(item => item.UserProfile)
                        .Include(item => item.DepositPayment)
                        .FirstOrDefault(item => item.RequestId == requestId);
            }
        }

        public Deposit GetDepositById(int depositId)
        {
            using (var context = new FinanceEntities())
            {
                return
                    context.Deposit.Include(item => item.DepositType)
                        .Include(item => item.UserProfile)
                        .Include(item => item.DepositPayment)
                        .FirstOrDefault(item => item.Id == depositId);
            }
        }


        public List<Deposit> GetClientDeposits(int clientId)
        {
            using (var context = new FinanceEntities())
            {
                return
                    context.Deposit.Include(item => item.DepositType)
                        .Include(item => item.UserProfile)
                        .Include(item => item.DepositPayment)
                        .Where(item => item.ClientId == clientId)
                        .ToList();
            }
        }
    }
}
