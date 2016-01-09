using System;
using DAL;

namespace BLL.Models
{
    public class UserModel
    {
        public UserModel()
        {
        }

        public UserModel(UserProfile userProfile)
        {
            Id = userProfile.UserId;
            Name = userProfile.UserName;
            Surname = userProfile.UserSurname;
            PassportNumber = userProfile.UserPassportSerialNumber;
        }

        public int Id { get; set; }

        public String Name { get; set; }

        public String Surname { get; set; }

        public String PassportNumber { get; set; }
    }
}
