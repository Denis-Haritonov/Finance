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

        public Deposit FindByRequestId(int requestId)
        {
            using (var context = new FinanceEntities())
            {
                return
                    context.Deposit.Include(item => item.DepositType)
                        .Include(item => item.UserProfile)
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
                        .FirstOrDefault(item => item.Id == depositId);
            }
        }
    }
}
