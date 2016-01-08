using System.Collections.Generic;
using DAL.Entities;
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
    }
}
