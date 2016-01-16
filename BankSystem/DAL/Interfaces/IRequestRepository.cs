using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRequestRepository
    {
        void CreateRequest(Request request);

        void UpdateRequest(Request request);

        List<Request> GetClientRequests(int clientId);

        Request GetRequestById(int requestId);

        List<Request> GetUnassignedAndPersonalRequests(int employeeId, int state);

        List<Request> GetSecurityChechedRequests(int employeeId);
    }
}
