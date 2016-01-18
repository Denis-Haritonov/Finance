using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CreditTypeEditModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название типа кредита")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Процент кредита")]
        public double Percent { get; set; }

        [Required]
        [Display(Name = "Штрафной процент")]
        public double OverduePercent { get; set; }

        [Required]
        [Display(Name ="Срок возврата в днях")]
        public int ReturnTerm { get; set; }

        [Display(Name = "Активен?")]
        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Валюта кредита")]

        public string CurrencyShort { get; set; }
    }
}
