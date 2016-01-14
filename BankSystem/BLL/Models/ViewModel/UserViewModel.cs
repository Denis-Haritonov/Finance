using System;
using System.Collections.Generic;
using DAL;

namespace BLL.Models.ViewModel
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            this.UserInRoles = new List<webpages_Roles>();
        }

        public UserViewModel(UserProfile userProfile)
        {
            UserId = userProfile.UserId;
            UserName = userProfile.UserName;
            UserSurname = userProfile.UserSurname;
            UserLastName = userProfile.UserLastName;
            UserPassportSerialNumber = userProfile.UserPassportSerialNumber;
            PassportIdentificationNumber = userProfile.PassportIdentificationNumber;
            Email = userProfile.Email;
            UserBirthDate = userProfile.UserBirthDate;
        }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserSurname { get; set; }

        public string UserLastName { get; set; }

        public DateTime? UserBirthDate { get; set; }

        public string UserPassportSerialNumber { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public string PassportIdentificationNumber { get; set; }

        public List<webpages_Roles> UserInRoles { get; set; } 

        public float? ScoringMark { get; set; }
    }
}
