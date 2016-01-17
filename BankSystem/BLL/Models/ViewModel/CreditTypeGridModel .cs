using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Common;

namespace BLL.Models.ViewModel
{
    public class CreditTypeGridModel
    {
        public PagingCollection<object> CreditTypes { get; set; } 
    }
}
