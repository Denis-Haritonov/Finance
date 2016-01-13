using System;
using System.Collections.Generic;
using BLL.Models.ViewModel;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> GetUserViewModels();

        void AddClientUser(UserViewModel userModel);

        UserViewModel GetUserByLogin(String login);

        UserViewModel FindClientByPassportNumber(String searchTerm);

        UserViewModel GetUserById(int userId);
    }
}
