using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.ViewModel
{
    public class CurrencyModel
    {
        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Курс покупки доллара")]
        public int MinDollarPrice { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Курс доллара")]
        public int AvrDollarPrice { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Курс продажи доллара")]
        public int MaxDollarPrice { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Курс покупки евро")]
        public int MinEuroPrice { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Курс евро")]
        public int AvrEuroPrice { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Курс продажи евро")]
        public int MaxEuroPrice { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Курс покупки рубля")]
        public int MinRublePrice { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Курс рубля")]
        public int AvrRublePrice { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Курс продажи рубля")]
        public int MaxRublePrice { get; set; }
    }
}
