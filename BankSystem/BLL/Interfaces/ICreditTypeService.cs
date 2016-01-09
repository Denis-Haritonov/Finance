using System.Collections.Generic;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface ICreditTypeService
    {
        List<CreditTypeModel> GetCreditTypes();
    }
}
