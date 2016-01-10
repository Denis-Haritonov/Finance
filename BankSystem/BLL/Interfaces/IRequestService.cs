using System;
using System.Collections.Generic;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IRequestService
    {
        String CreateRequest(RequestModel requestModel, String passportNumber);

        List<RequestModel> GetRequestsByClient(int clientId);

        RequestModel GetRequestDetails(int requestId);
    }
}
