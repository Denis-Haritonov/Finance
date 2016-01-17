using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Models.GridModels.CreditType;
using BLL.Models.ViewModel;
using DAL;
using DAL.Interfaces;

namespace BLL.Implementations
{
    public class CreditTypeService : ICreditTypeService
    {
        private ICreditTypeReporsitory creditTypeReporsitory;

        public CreditTypeService(ICreditTypeReporsitory creditTypeReporsitory)
        {
            this.creditTypeReporsitory = creditTypeReporsitory;
        }

        public List<CreditTypeModel> GetCreditTypes()
        {
            return creditTypeReporsitory.GetActiveCreditTypes().Select(item => new CreditTypeModel(item)).ToList();
        }

        public CreditTypeModel GetCreditTypeById(int creditTypeId)
        {
            var creditType = creditTypeReporsitory.GetCreditTypeById(creditTypeId);
            if (creditType != null)
            {
                return new CreditTypeModel(creditType);
            }
            return null;
        }

        public List<CreditTypeRowViewModel> GetGridCreditTypes()
        {
            return
                this.creditTypeReporsitory.GetCreditTypes()
                    .Select(ct => Mapper.Map<CreditTypeRowViewModel>(ct))
                    .ToList();
        }

        public CreditTypeEditModel GetCreditTypeEditModelById(int creditTypeId)
        {
            return Mapper.Map<CreditTypeEditModel>(creditTypeReporsitory.GetCreditTypeById(creditTypeId));
        }

        public void SaveEditCreditType(CreditTypeEditModel model)
        {
            var dalCreditType = Mapper.Map<CreditType>(model);
            creditTypeReporsitory.SaveUpdateCreditType(dalCreditType);
        }

        public void DeleteCreditType(int creditTypeId)
        {
            this.creditTypeReporsitory.DeleteCreditType(creditTypeId);
        }
    }
}
