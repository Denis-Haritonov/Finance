using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using BLL.Models;
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
    }
}
