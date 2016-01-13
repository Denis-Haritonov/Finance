using System.Collections.Generic;
using BLL.Models;
using BLL.Models.Enums;

namespace BLL.Interfaces
{
    public interface IRequestService
    {
        void CreateRequest(RequestModel requestModel);

        List<RequestModel> GetRequestsByClient(int clientId);

        RequestModel GetRequestDetails(int requestId);

        List<RequestModel> GetRequestQueForEmployee(int employeeId);

        void AssignRequestToEmployee(int requestId, int employeeId);

        void ChangeRequestState(int requsetId, RequestState state);
    }
}
