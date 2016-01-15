using System;
using System.Collections.Generic;
using BankSystem.Models;
using BLL.Models.GridModels;
using BLL.Models.ViewModel;
using Common.Common;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        List<RegisterModel> GetUserViewModels();

        void AddClientUser(RegisterModel userModel);

        UserViewModel GetUserByLogin(String login);

        UserViewModel FindClientByPassportNumber(String searchTerm);

        UserViewModel GetUserById(int userId);

        PagingCollection<object> GetUsers(int page, string columnName, string link);
    } 
}
