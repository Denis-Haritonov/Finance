using System;
using System.Collections.Generic;
using BLL.Models;
using BLL.Models.Enums;

namespace BLL.Interfaces
{
    public interface IRequestService
    {
        String CreateRequest(RequestModel requestModel, String passportNumber);

        List<RequestModel> GetRequestsByClient(int clientId);

        RequestModel GetRequestDetails(int requestId);

        List<RequestModel> GetRequestQueForEmployee(int employeeId);

        void AssignRequestToEmployee(int requestId, int employeeId);

        void ChangeRequestState(int requsetId, RequestState state);
    }
}
