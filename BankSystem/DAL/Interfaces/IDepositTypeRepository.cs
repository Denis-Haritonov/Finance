using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IDepositTypeRepository
    {
        List<DepositType> GetActiveDepositTypes();

        DepositType GetDepositTypeById(int depositTypeId);
    }
}
