using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface ICreditRepository
    {
        void CreateCredit(Credit credit);

        Credit GetCreditById(int creditId);

        void UpdateCredit(Credit credit);

        Credit FindByRequestId(int requestId);

        List<Credit> GetClientCredits(int clientId);

        void Percents();

        List<Credit> GetOverdueCredits(DateTime date);
    }
}
