using DAL.Interfaces;

namespace DAL.Implementation
{
    public class CreditRepository : ICreditRepository
    {
        public void CreateCredit(Credit credit)
        {
            using (var context = new FinanceEntities())
            {
                context.Credit.Add(credit);
                context.SaveChanges();
            }
        }
    }
}
