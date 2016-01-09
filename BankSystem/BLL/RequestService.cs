using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Models;
using DAL;
using DAL.Interfaces;

namespace BLL
{
    public class RequestService
    {
        private IUserRepository userRepository;

        private IRequestRepository requestRepository;

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
            using (var context = new FinanceEntities())
            {
                context.Request.Add(request);
                context.SaveChanges();
            }
            return null;
        }

        public List<RequestModel> GetRequestsByClient(int clientId)
        {
            var requests = requestRepository.GetClientRequests(clientId);
            return requests.Select(item => new RequestModel(item)).ToList();
        } 
    }
}
