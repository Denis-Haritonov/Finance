using BLL.Models.Enums;

namespace BLL.Models
{
    public class RequestModel
    {
        public RequestType Type { get; set; }

        public RequestState State { get; set; }

        public decimal Amount { get; set; }


    }
}
