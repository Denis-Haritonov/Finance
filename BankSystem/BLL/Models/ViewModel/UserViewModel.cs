using System;
using System.Collections.Generic;
using DAL;

namespace BLL.Models.ViewModel
{
    public class UserViewModel
    {
        public UserViewModel()
        {
        }

        public UserViewModel(UserProfile userProfile)
        {
            UserId = userProfile.UserId;
            UserName = userProfile.UserName;
            UserSurname = userProfile.UserSurname;
            UserPassportSerialNumber = userProfile.UserPassportSerialNumber;
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserLastName { get; set; }
        public DateTime? UserBirthDate { get; set; }
        public string UserPassportSerialNumber { get; set; }
    }
}
