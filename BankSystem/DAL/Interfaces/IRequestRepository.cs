using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRequestRepository
    {
        void CreateRequest(Request request);

        List<Request> GetClientRequests(int clientId);

        Request GetRequestById(int requestId);
    }
}
