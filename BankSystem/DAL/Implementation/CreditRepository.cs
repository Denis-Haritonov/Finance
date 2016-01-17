using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public void UpdateCredit(Credit credit)
        {
            using (var context = new FinanceEntities())
            {
                context.Credit.Attach(credit);
                context.Entry(credit).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Credit GetCreditById(int creditId)
        {
            using (var context = new FinanceEntities())
            {
                return context.Credit.Include(item => item.CreditType)
                    .Include(item => item.CreditPayment)
                    .Include(item => item.UserProfile)
                    .FirstOrDefault(item => item.Id == creditId);
            }
        }

        public Credit FindByRequestId(int requestId)
        {
            using (var context = new FinanceEntities())
            {
                return
                    context.Credit.Include(item => item.CreditType)
                        .Include(item => item.UserProfile)
                        .Include(item => item.CreditPayment)
                        .FirstOrDefault(item => item.RequestId == requestId);
            }
        }

        public List<Credit> GetClientCredits(int clientId)
        {
            using (var context = new FinanceEntities())
            {
                return
                    context.Credit.Include(item => item.CreditType)
                        .Include(item => item.UserProfile)
                        .Include(item => item.CreditPayment)
                        .Where(item => item.ClientId == clientId && item.IsClosed == false)
                        .ToList();
            }
        }

        public void Percents()
        {
            using (var context = new FinanceEntities())
            {
                context.Database.ExecuteSqlCommand("exec CreditOvercharge");
            }
        }

        public List<Credit> GetOverdueCredits(DateTime date)
        {
            using (var context = new FinanceEntities())
            {
                return context.Credit
                    .Include(item => item.CreditType)
                    .Include(item => item.UserProfile)
                    .Include(item => item.CreditPayment)
                    .Where(item => item.EndDate < date && item.MainDebt > 0 && item.IsClosed == false).ToList();
            }
        }
    }
}
