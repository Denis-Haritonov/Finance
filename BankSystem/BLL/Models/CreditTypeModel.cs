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
        }

        public int Id { get; set; }

        public String Name { get; set; }
    }
}
