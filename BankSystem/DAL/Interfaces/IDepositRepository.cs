using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IDepositRepository
    {
        void CreateDeposit(Deposit deposit);

        void UpdateDeposit(Deposit deposit);

        Deposit FindByRequestId(int requestId);

        Deposit GetDepositById(int depositId);

        List<Deposit> GetClientDeposits(int clientId);

        void Percents();
    }
}
