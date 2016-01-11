using System;
using DAL;

namespace BLL.Models
{
    public class CreditTypeModel
    {
        public CreditTypeModel() { }

        public CreditTypeModel(CreditType creditType)
        {
            Id = creditType.Id;
            Name = creditType.Name;
            Description = creditType.Description;
            CurrencyShort = creditType.CurrencyShort;
        }

        public int Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String CurrencyShort { get; set; }
    }
}
