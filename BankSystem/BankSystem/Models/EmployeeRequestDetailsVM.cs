using BLL.Models;

namespace BankSystem.Models
{
    public class EmployeeRequestDetailsVM
    {
        public RequestModel RequestModel { get; set; }

        public bool IsAssignedToCurrent { get; set; }
    }
}