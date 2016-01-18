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

        void AssignRequestToOperator(int requestId, int employeeId);

        void AssignRequestToSecurityWorker(int requestId, int employeeId);

        void ChangeRequestState(int requsetId, RequestState state);

        List<RequestModel> GetRequestsQueForSecurityWorker(int employeeId);

        List<RequestModel> GetCheckedRequestQueForEmployee(int employeeId);

        void UpdateAmount(int requestId, int amount);
    }
}
