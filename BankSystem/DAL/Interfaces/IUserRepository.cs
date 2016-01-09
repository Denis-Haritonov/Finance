using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        List<UserProfile> GetUsers();

        void AddOrUpdateUser(UserProfile user);
    }
}
