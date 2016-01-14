using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using BankSystem.Models;
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

        public List<RegisterModel> GetUserViewModels()
        {
            return this._userRepository.GetUsers().Select(U => Mapper.Map<UserProfile, RegisterModel>(U)).ToList();
        }

        public void AddClientUser(RegisterModel userModel)
        {
            var dalUser = Mapper.Map<RegisterModel, UserProfile>(userModel);
            dalUser.webpages_Roles.Add(new webpages_Roles(){ RoleId = (int)Common.Enum.Roles.Client, });
            this._userRepository.AddOrUpdateUser(dalUser);
        }

        public UserViewModel GetUserByLogin(String login)
        {
            var user = _userRepository.GetUserByLogin(login);
            if (user != null)
            {
                return new UserViewModel(user);
            }
            return null;
        }

        public UserViewModel FindClientByPassportNumber(String searchTerm)
        {
            var user = _userRepository.GetUserByPassportNumber(searchTerm);
            if (user != null)
            {
                return new UserViewModel(user);
            }
            return null;
        }

        public UserViewModel GetUserById(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user != null)
            {
                return new UserViewModel(user);
            }
            return null;
        }
    }
}
