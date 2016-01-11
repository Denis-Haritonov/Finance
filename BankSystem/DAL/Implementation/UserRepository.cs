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
            using (var context = new FinanceEntities())
            {
                return context.UserProfile.ToList();
            }
        }

        public void AddOrUpdateUser(UserProfile user)
        {
            using (var context = new FinanceEntities())
            {
                if (user.UserId == 0)
                {
                    context.UserProfile.Add(user);
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
                return context.UserProfile.FirstOrDefault(item => item.UserName == login);
            }
        }

        public UserProfile GetUserByPassportNumber(String passportNumber)
        {
            using (var context = new FinanceEntities())
            {
                return context.UserProfile.FirstOrDefault(user => user.UserPassportSerialNumber == passportNumber);
            }
        }

        public UserProfile GetUserById(int userId)
        {
            using (var context = new FinanceEntities())
            {
                return context.UserProfile.FirstOrDefault(user => user.UserId == userId);
            }
        }
    }
}
