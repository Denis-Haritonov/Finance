using System.Collections.Generic;
using BankSystem.Models;
using BLL.Models.ViewModel;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        List<RegisterModel> GetUserViewModels();

        void AddClientUser(RegisterModel userModel);
    }
}
