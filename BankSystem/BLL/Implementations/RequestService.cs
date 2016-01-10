using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using BLL.Models;
using DAL;
using DAL.Interfaces;
using RequestState = BLL.Models.Enums.RequestState;

namespace BLL.Implementations
{
    public class RequestService : IRequestService
    {
        private IUserRepository userRepository;

        private IRequestRepository requestRepository;

        public RequestService(IRequestRepository requestRepository, IUserRepository userRepository)
        {
            this.requestRepository = requestRepository;
            this.userRepository = userRepository;
        }

        public String CreateRequest(RequestModel requestModel, String passportNumber)
        {
            var user = userRepository.GetUserByPassportNumber(passportNumber);
            if (user == null)
            {
                return "Error: cannot find user";
            }
            var request = new Request
            {
                ClientId = user.UserId,
                RequestType = (int) requestModel.Type,
                State = (int) requestModel.State,
                Amount = requestModel.Amount,
                CreditTypeId = requestModel.CreditTypeId,
                DepositTypeId = requestModel.DepositTypeId,
                Date = DateTime.Now
            };
            requestRepository.CreateRequest(request);
            return null;
        }

        public List<RequestModel> GetRequestsByClient(int clientId)
        {
            var requests = requestRepository.GetClientRequests(clientId);
            return requests.Select(item => new RequestModel(item)).OrderBy(item => item.Date).ToList();
        }

        public RequestModel GetRequestDetails(int requestId)
        {
            var request = requestRepository.GetRequestById(requestId);
            if (request != null)
            {
                return new RequestModel(request);
            }
            return null;
        }

        public List<RequestModel> GetRequestQueForEmployee(int employeeId)
        {
            var requests = requestRepository.GetUnassignedAndPersonalRequests(employeeId);
            return requests.Select(item => new RequestModel(item)).OrderBy(item => item.Date).ToList();
        }

        public void AssignRequestToEmployee(int requestId, int employeeId)
        {
            var request = requestRepository.GetRequestById(requestId);
            request.AssignedEmployeeId = employeeId;
            requestRepository.UpdateRequest(request);
        }

        public void ChangeRequestState(int requsetId, RequestState state)
        {
            var request = requestRepository.GetRequestById(requsetId);
            request.State = (int)state;
            requestRepository.UpdateRequest(request);
        }
    }
}
