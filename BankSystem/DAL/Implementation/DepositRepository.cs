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

    }
}
