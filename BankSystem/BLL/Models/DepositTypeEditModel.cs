using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class DepositTypeEditModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название типа депозита")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Процент по депозиту")]
        public double Percent { get; set; }

        [Required]
        [Display(Name = "Срок вклада в годах")]
        public int ReturnTerm { get; set; }

        [Display(Name = "Активен?")]
        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Валюта кредита")]
        [RegularExpression("(BYR)|(USD)|(EUR)", ErrorMessage = "Валюта должнна быть одна из  BYR|USD|EUR")]
        public string CurrencyShort { get; set; }
    }
}
