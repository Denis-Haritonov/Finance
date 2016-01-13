using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using BLL.Models;
using BLL.Models.Enums;
using DAL;
using DAL.Interfaces;

namespace BLL.Implementations
{
    public class DepositService : IDepositService
    {
        private IDepositTypeRepository depositTypeRepository;

        private IDepositRepository depositRepository;

        public DepositService(IDepositTypeRepository depositTypeRepository, IDepositRepository depositRepository)
        {
            this.depositTypeRepository = depositTypeRepository;
            this.depositRepository = depositRepository;
        }

        public void OpenDeposit(RequestModel request)
        {
            if (request.Type != RequestType.Deposit)
            {
                return;
            }
            var depositType = depositTypeRepository.GetDepositTypeById(request.DepositTypeId.Value);
            var deposit = new Deposit
            {
                Balance = request.Amount,
                DepositTypeId = depositType.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now + TimeSpan.FromTicks(depositType.ReturnTerm),
                RequestId = request.Id,
                ClientId = request.ClientId
            };
            depositRepository.CreateDeposit(deposit);
        }

        public DepositModel FindByRequestId(int requestId)
        {
            var deposit = depositRepository.FindByRequestId(requestId);
            if (deposit != null)
            {
                return new DepositModel(deposit);
            }
            return null;
        }

        public DepositModel GetDepositById(int depositId)
        {
            var deposit = depositRepository.GetDepositById(depositId);
            if (deposit != null)
            {
                return new DepositModel(deposit);
            }
            return null;
        }

        public List<DepositModel> GetClientDeposits(int clientId)
        {
            return
                depositRepository.GetClientDeposits(clientId)
                    .OrderByDescending(item => item.StartDate)
                    .Select(item => new DepositModel(item))
                    .ToList();
        } 
    }
}
