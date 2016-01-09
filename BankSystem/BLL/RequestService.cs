using BLL.Models;
using DAL;

namespace BLL
{
    public class RequestService
    {
        public void CreateRequest(RequestModel requestModel)
        {
            var request = new Request()
            {

            };
            using (var context = new FinanceEntities())
            {
                context.Request.Add(request);
            }
        }
    }
}
