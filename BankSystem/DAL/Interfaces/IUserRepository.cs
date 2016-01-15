using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        List<UserProfile> GetUsers();

        UserProfile GetUserByPassportNumber(String passportNumber);

        UserProfile GetUserByLogin(String login);

        void AddOrUpdateUser(UserProfile user);

        UserProfile GetUserById(int userId);

        List<UserProfile> GetUsers(int page, string sortColumnName);
    }
}
