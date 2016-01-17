using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface ICreditTypeReporsitory
    {
        List<CreditType> GetActiveCreditTypes();

        List<CreditType> GetCreditTypes();

        CreditType GetCreditTypeById(int creditTypeId);

        void SaveUpdateCreditType(CreditType model);

        void DeleteCreditType(int creditTypeId);
    }
}
