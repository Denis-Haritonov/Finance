using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.ViewModel
{
    public class RefreshCodeModel
    {
        public RefreshCodeModel()
        {
            Code = String.Empty;;
        }

        [Required]
        [Display(Name = "Код отменны платежа")]
        [MinLength(6,ErrorMessage = "Код должен состоять из шести или более символов")]
        public String Code { get; set; }
    }
}
