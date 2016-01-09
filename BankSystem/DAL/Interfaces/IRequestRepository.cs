using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRequestRepository
    {
        List<Request> GetClientRequests(int clientId);
    }
}
