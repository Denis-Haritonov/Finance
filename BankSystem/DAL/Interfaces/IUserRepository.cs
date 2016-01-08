using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Interfaces
{
    interface IUserRepository
    {
        List<UserProfile> GetUsers();
    }
}
