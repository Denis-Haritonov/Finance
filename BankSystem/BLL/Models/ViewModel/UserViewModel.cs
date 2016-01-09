using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Models.ViewModel
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            this.UserInRoles = new List<UsersInRole>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserLastName { get; set; }
        public DateTime? UserBirthDate { get; set; }
        public string UserPassportSerialNumber { get; set; }

        public List<UsersInRole> UserInRoles { get; set; } 
    }
}
