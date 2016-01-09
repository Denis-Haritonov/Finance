using System;
using DAL;

namespace BLL.Models
{
    public class DepositTypeModel
    {
        public DepositTypeModel()
        {
        }

        public DepositTypeModel(DepositType depositType)
        {
            Id = depositType.Id;
            Name = depositType.Name;
        }

        public int Id { get; set; }

        public String Name { get; set; }
    }
}
