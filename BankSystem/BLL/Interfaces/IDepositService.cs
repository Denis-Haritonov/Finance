using BLL.Models;

namespace BLL.Interfaces
{
    public interface IDepositService
    {
        void OpenDeposit(RequestModel request);

        DepositModel FindByRequestId(int requestId);

        DepositModel GetDepositById(int depositId);
    }
}
