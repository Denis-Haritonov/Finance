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
                        .Include(item => item.Comment.Select(c => c.UserProfile))
                        .FirstOrDefault(item => item.Id == requestId);
            }
        }

        public List<Request> GetUnassignedAndPersonalRequests(int employeeId, int state)
        {
            using (var context = new FinanceEntities())
            {
                var query = context.Request.Include(item => item.CreditType).Include(item => item.DepositType);
                query = SetEmployeeCriteria(query, employeeId, state);
                return query.ToList();
            }
        }

        public List<Request> GetSecurityChechedRequests(int employeeId)
        {
            using (var context = new FinanceEntities())
            {
                return
                    context.Request.Include(item => item.CreditType)
                        .Include(item => item.DepositType)
                        .Where(item => item.AssignedOperatorId == employeeId && (item.State == 4 || item.State == 5))
                        .ToList();
            }
        } 

        private IQueryable<Request> SetEmployeeCriteria(IQueryable<Request> query, int employeeId, int state)
        {
            if (state == 0)
            {
                return
                    query.Where(
                        item =>
                            item.State == state &&
                            (!item.AssignedOperatorId.HasValue || item.AssignedOperatorId.Value == employeeId));
            }
            if (state == 3)
            {
                return
                    query.Where(
                        item =>
                            item.State == 3 &&
                            (!item.AssignedSecurityWorkerId.HasValue ||
                             item.AssignedSecurityWorkerId.Value == employeeId));
            }
            return query;
        } 
    }
}
