using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models.ViewModel;
using DAL;
using DAL.Interfaces;
using Roles = Common.Enum.Roles;

namespace BLL.Implementations
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public List<UserViewModel> GetUserViewModels()
        {
            return this._userRepository.GetUsers().Select(U => Mapper.Map<UserProfile, UserViewModel>(U)).ToList();
        }

        public void AddClientUser(UserViewModel userModel)
        {
            var dalUser = Mapper.Map<UserViewModel, UserProfile>(userModel);
            dalUser.UsersInRoles.Add(new UsersInRoles(){ RoleId = (int)Roles.Client, UserId  = dalUser.UserId });
            this._userRepository.AddOrUpdateUser(dalUser);
        }

        public UserViewModel GetUserByLogin(String login)
        {
            var user = _userRepository.GetUserByLogin(login);
            if (user != null)
            {
                return Mapper.Map<UserProfile, UserViewModel>(user);
            }
            return null;
        }
    }
}
