using System;
using System.Linq;
using DAL.Interfaces;

namespace DAL.Implementation
{
    public class DateRepository: IDateRepository
    {
        public DateTime GetCurrentDate()
        {
            using (var context = new FinanceEntities())
            {
                var globalDate = context.GlobalDate.FirstOrDefault();
                if (globalDate != null)
                {
                    return globalDate.Date.Date.Add(DateTime.Now.TimeOfDay);
                }
                return DateTime.Now;
            }
        }

        public void AddDay()
        {
            using (var context = new FinanceEntities())
            {
                var date = context.GlobalDate.FirstOrDefault();
                if (date == null)
                {
                    return;
                }
                date.Date = date.Date.AddDays(1);
                context.SaveChanges();
                try
                {
                    context.Database.ExecuteSqlCommand("exec DepositOvercharge");
                    context.Database.ExecuteSqlCommand("exec CreditOvercharge");
                }
                catch (Exception)
                {
                }
            }
        }

        public void ResetDate()
        {
            using (var context = new FinanceEntities())
            {
                var date = context.GlobalDate.FirstOrDefault();
                if (date == null)
                {
                    return;
                }
                date.Date = DateTime.Today;
                context.SaveChanges();
            }
        }
    }
}
