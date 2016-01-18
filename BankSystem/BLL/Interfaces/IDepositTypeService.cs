using System.Collections.Generic;
using BLL.Models;
using BLL.Models.GridModels.DepositType;
using BLL.Models.ViewModel;

namespace BLL.Interfaces
{
    public interface IDepositTypeService
    {
        List<DepositTypeModel> GetDepositTypes();

        DepositTypeModel GetDepositTypeById(int depositTypeId);

        List<DepositTypeRowModel> GetDepositRows();

        DepositTypeEditModel GetDepositTypeEditModel(int depositTypeId);

        void SaveOrUpdate(DepositTypeEditModel model);
    }
}
