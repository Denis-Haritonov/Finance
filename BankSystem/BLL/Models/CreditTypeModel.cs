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
            Percent = creditType.Percent;
            ReturnTerm = TimeSpan.FromTicks(creditType.ReturnTerm);
        }

        public int Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String CurrencyShort { get; set; }

        public double Percent { get; set; }

        public TimeSpan ReturnTerm { get; set; }
    }
}
