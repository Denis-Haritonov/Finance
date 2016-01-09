using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;

namespace DAL.Implementation
{
    public class UserRepository:IUserRepository
    {
        public List<UserProfile> GetUsers()
        {
            using (var context = new FinanceEntities())
            {
                return context.UserProfile.ToList();
            }
        }

        public UserProfile GetUserByLogin(String login)
        {
            using (var context = new FinanceEntities())
            {
                throw new NotImplementedException();
            }
        }

        public UserProfile GetUserByPassportNumber(String passportNumber)
        {
            using (var context = new FinanceEntities())
            {
                return context.UserProfile.FirstOrDefault(user => user.UserPassportSerialNumber == passportNumber);
            }
        }
    }
}
