using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using BankSystem.Models;
using BLL.Interfaces;
using BLL.Models.GridModels;
using BLL.Models.ViewModel;
using Common.Common;
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

        public PagingCollection<object> GetUsers(int page, string columnName, string link)
        {
            var dalUsers = _userRepository.GetUsers(page, columnName);
            var usersCount = _userRepository.GetUsers().Count;
            List<UserGridRowViewModel> gridUsers = new List<UserGridRowViewModel>();

            foreach (var dalUser in dalUsers)
            {
                var gridUser = Mapper.Map<UserProfile, UserGridRowViewModel>(dalUser);
                var role = dalUser.webpages_Roles.FirstOrDefault();
                gridUser.Login = "<a href=" + link + ">" + gridUser.Login + "</a>";
                if (role == null)
                {
                    gridUser.Role = "Client";
                }
                else
                {
                    gridUser.Role = role.RoleName;
                }
                gridUsers.Add(gridUser);
            }

            return new PagingCollection<object>(gridUsers, usersCount);
        }
    }
}
