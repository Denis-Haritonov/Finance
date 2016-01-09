using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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

        public List<UserViewModel> GetUserViewModels()
        {
            return this._userRepository.GetUsers().Select(U => Mapper.Map<UserProfile, UserViewModel>(U)).ToList();
        }

        public void AddClientUser(UserViewModel userModel)
        {
            var dalUser = Mapper.Map<UserViewModel, UserProfile>(userModel);
            dalUser.UsersInRoles.Add(new UsersInRole(){ RoleId = (int)Common.Enum.Roles.Client, UserId  = dalUser.UserId });
            this._userRepository.AddOrUpdateUser(dalUser);
        }
    }
}
