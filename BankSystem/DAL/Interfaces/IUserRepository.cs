using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        List<UserProfile> GetUsers();

        UserProfile GetUserByPassportNumber(String passportNumber);

        UserProfile GetUserByLogin(String login);
    }
}
