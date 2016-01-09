using System;
using BLL.Models;
using DAL.Interfaces;

namespace BLL
{
    public class UserService
    {
        private IUserRepository userRepository;

        public UserModel GetUserByLogin(String login)
        {
            var user = userRepository.GetUserByLogin(login);
            if (user != null)
            {
                return new UserModel(user);
            }
            return null;
        }
    }
}
