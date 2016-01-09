using System.Collections.Generic;
using System.Linq;
using BLL.Models;
using DAL.Interfaces;

namespace BLL
{
    public class DepositTypeService
    {
        private IDepositTypeRepository depositTypeRepository;

        public List<DepositTypeModel> GetDepositTypes()
        {
            return depositTypeRepository.GetActiveDepositTypes().Select(item => new DepositTypeModel(item)).ToList();
        }
    }
}
