using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface ICreditTypeReporsitory
    {
        List<CreditType> GetActiveCreditTypes();

        CreditType GetCreditTypeById(int creditTypeId);
    }
}
