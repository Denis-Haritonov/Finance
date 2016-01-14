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
    }
}
