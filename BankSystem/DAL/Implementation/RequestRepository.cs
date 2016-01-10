using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces;

namespace DAL.Implementation
{
    public class RequestRepository : IRequestRepository
    {
        public void CreateRequest(Request request)
        {
            using (var context = new FinanceEntities())
            {
                context.Request.Add(request);
                context.SaveChanges();
            }
        }

        public void UpdateRequest(Request request)
        {
            using (var context = new FinanceEntities())
            {
                context.Request.Attach(request);
                context.Entry(request).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<Request> GetClientRequests(int clientId)
        {
            using (var context = new FinanceEntities())
            {
                return
                    context.Request.Include(item => item.DepositType)
                        .Include(item => item.CreditType)
                        .Where(item => item.ClientId == clientId)
                        .ToList();
            }
        }

        public Request GetRequestById(int requestId)
        {
            using (var context = new FinanceEntities())
            {
                return
                    context.Request.Include(item => item.CreditType)
                        .Include(item => item.DepositType)
                        .FirstOrDefault(item => item.Id == requestId);
            }
        }

        public List<Request> GetUnassignedAndPersonal(int employeeId)
        {
            using (var context = new FinanceEntities())
            {
                return null;
            }
        }
    }
}
