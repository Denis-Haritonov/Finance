using System.Collections.Generic;
using AutoMapper;
using BLL.Models;
using BLL.Models.GridModels.CreditType;
using BLL.Models.ViewModel;
using DAL;

namespace BLL.Interfaces
{
    public interface ICreditTypeService
    {
        List<CreditTypeModel> GetCreditTypes();

        CreditTypeModel GetCreditTypeById(int creditTypeId);

        CreditTypeEditModel GetCreditTypeEditModelById(int creditTypeId);

        List<CreditTypeRowViewModel> GetGridCreditTypes();

        void SaveEditCreditType(CreditTypeEditModel model);

        void DeleteCreditType(int creditTypeId);

    }
}
