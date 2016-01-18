using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Models.GridModels.DepositType;
using BLL.Models.ViewModel;
using DAL;
using DAL.Interfaces;

namespace BLL.Implementations
{
    public class DepositTypeService : IDepositTypeService
    {
        private IDepositTypeRepository depositTypeRepository;

        public DepositTypeService(IDepositTypeRepository depositTypeRepository)
        {
            this.depositTypeRepository = depositTypeRepository;
        }

        public List<DepositTypeModel> GetDepositTypes()
        {
            return depositTypeRepository.GetActiveDepositTypes().Select(item => new DepositTypeModel(item)).ToList();
        }

        public DepositTypeModel GetDepositTypeById(int depositTypeId)
        {
            var depositType = depositTypeRepository.GetDepositTypeById(depositTypeId);
            if (depositType != null)
            {
                return new DepositTypeModel(depositType);
            }
            return null;
        }

        public List<DepositTypeRowModel> GetDepositRows()
        {
            return this.depositTypeRepository.GetDepositRows().Select(dt => Mapper.Map<DepositTypeRowModel>(dt)).ToList();
        }

        public DepositTypeEditModel GetDepositTypeEditModel(int depositTypeId)
        {
            return Mapper.Map<DepositTypeEditModel>(depositTypeRepository.GetDepositTypeById(depositTypeId));
        }

        public void SaveOrUpdate(DepositTypeEditModel model)
        {
            depositTypeRepository.SaveOrUpdate(Mapper.Map<DepositType>(model));
        }
    }
}
