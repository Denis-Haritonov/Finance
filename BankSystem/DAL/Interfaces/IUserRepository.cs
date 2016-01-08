using System.Collections.Generic;

namespace DAL.Interfaces
{
    interface IUserRepository
    {
        List<UserProfile> GetUsers();
    }
}
