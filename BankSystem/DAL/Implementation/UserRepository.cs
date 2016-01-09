using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
