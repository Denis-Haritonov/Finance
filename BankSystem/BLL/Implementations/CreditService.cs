using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Models.Enums;
using BLL.Models.GridModels.Credit;
using DAL;
using DAL.Interfaces;

namespace BLL.Implementations
{
    public class CreditService : ICreditService
    {
        private ICreditTypeReporsitory creditTypeReporsitory;

        private ICreditRepository creditRepository;

        private IDateService dateService;

        public CreditService(ICreditRepository creditRepository, ICreditTypeReporsitory creditTypeReporsitory, IDateService dateService)
        {
            this.creditRepository = creditRepository;
            this.creditTypeReporsitory = creditTypeReporsitory;
            this.dateService = dateService;
        }

        public void OpenCredit(RequestModel request)
        {
            if (request.Type != RequestType.Credit)
            {
                return;
            }
            var creditType = creditTypeReporsitory.GetCreditTypeById(request.CreditTypeId.Value);
            var date = dateService.GetCurrentDate();
            var credit = new Credit
            {
                ClientId = request.ClientId,
                StartAmount =  request.Amount,
                MainDebt = request.Amount,
                StartDate = date,
                EndDate = date + TimeSpan.FromTicks(creditType.ReturnTerm) + TimeSpan.FromDays(1),
                CreditTypeId = creditType.Id,
                RequestId = request.Id,
                PercentageDebt = 0
            };
            creditRepository.CreateCredit(credit);
        }

        public CreditModel FindByRequestId(int requestId)
        {
            var credit = creditRepository.FindByRequestId(requestId);
            if (credit != null)
            {
                return new CreditModel(credit);
            }
            return null;
        }

        public CreditModel GetCreditById(int creditId)
        {
            var credit = creditRepository.GetCreditById(creditId);
            if (credit != null)
            {
                return new CreditModel(credit);
            }
            return null;
        }

        public List<CreditModel> GetClientCredits(int clientId)
        {
            return
                creditRepository.GetClientCredits(clientId)
                    .OrderByDescending(item => item.StartDate)
                    .Select(item => new CreditModel(item))
                    .ToList();
        }

        public decimal CalculateMonthPayment(decimal amount, TimeSpan returnTerm, double yearPercent)
        {
            var monthCount = 12*returnTerm.TotalDays/360.0;
            return CalculateMonthPayment(amount, (int) monthCount, yearPercent);
        }

        public decimal CalculateMonthPayment(decimal amount, int monthCount, double yearPercent)
        {
            var monthPercent = Math.Pow(1 + yearPercent, 1.0 / 12);
            var k = Math.Pow(monthPercent, monthCount);
            var result = amount*(decimal) (k*(monthPercent - 1)/(k - 1));
            return result;
        }

        public void Percents()
        {
            creditRepository.Percents();
        }

        public List<CreditModel> GetOverdueCredits()
        {
            var date = dateService.GetCurrentDate();
            return
                creditRepository.GetOverdueCredits(date)
                    .Select(item => new CreditModel(item))
                    .OrderByDescending(item => item.StartDate)
                    .ToList();
        }

        public void CloseCredit(int creditId)
        {
            var credit = creditRepository.GetCreditById(creditId);
            credit.IsClosed = true;
            creditRepository.UpdateCredit(credit);
        }

        public List<CreditRowModel> GetCreditGrid()
        {
            return creditRepository.GetCredits().Select( ct => Mapper.Map<CreditRowModel>(ct)).ToList();
        }    }
}
