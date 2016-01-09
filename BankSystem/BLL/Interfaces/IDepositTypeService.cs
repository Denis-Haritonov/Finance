using System.Collections.Generic;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IDepositTypeService
    {
        List<DepositTypeModel> GetDepositTypes();
    }
}
