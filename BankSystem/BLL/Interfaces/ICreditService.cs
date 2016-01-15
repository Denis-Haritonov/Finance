using System;
using System.Collections.Generic;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface ICreditService
    {
        void OpenCredit(RequestModel request);

        CreditModel FindByRequestId(int requestId);

        CreditModel GetCreditById(int depositId);

        List<CreditModel> GetClientCredits(int clientId);

        decimal CalculateMonthPayment(decimal amount, TimeSpan returnTerm, double yearPercent);
    }
}
