using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;

namespace DAL.Interfaces
{
    public interface ICreditRepository
    {
        void CreateCredit(Credit credit);

        Credit GetCreditById(int creditId);

        void UpdateCredit(Credit credit);

        Credit FindByRequestId(int requestId);

        List<Credit> GetClientCredits(int clientId);

        List<Credit> GetCredits();

        void Percents();
    }
}
