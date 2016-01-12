using BLL.Models;

namespace BankSystem.Models
{
    public class EmployeeRequestDetailsVM
    {
        public RequestModel RequestModel { get; set; }

        public bool IsAssignedToCurrent { get; set; }

        public DepositModel DepositModel { get; set; }
    }
}