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
            Description = depositType.Description;
            CurrencyShort = depositType.CurrencyShort;
        }

        public int Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String CurrencyShort { get; set; }
    }
}
