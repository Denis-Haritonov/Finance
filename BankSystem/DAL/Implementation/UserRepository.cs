using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces;

namespace DAL.Implementation
{
    public class UserRepository:IUserRepository
    {
        public List<UserProfile> GetUsers()
        {
            using (var context = new FinanceEntity())
            {
                return context.UserProfiles.ToList();
            }
        }

        public void AddOrUpdateUser(UserProfile user)
        {
            using (var context = new FinanceEntity())
            {
                if (user.UserId == 0)
                {
                    context.UserProfiles.Add(user);
                }
                else
                {
                    context.Entry(user).State = EntityState.Modified;
                }

                context.SaveChanges();
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
