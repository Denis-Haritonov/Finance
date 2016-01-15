using BankSystem.Models;
using BLL.Models.GridModels;
using BLL.Models.ViewModel;
using DAL;

namespace BusinesLogicLayer.Entities
{
    using Common.Interfaces;
    using AutoMapper;

    /// <summary>
    /// Configure mappings for business layer
    /// </summary>
    public class BllAutomapperConfiguration : IAutoMapperConfiguration
    {
        /// <summary>
        /// Configure business layer mappings
        /// </summary>
        public void Configure()
        {
            Mapper.CreateMap<UserProfile, UserViewModel>().ForMember(u => u.UserInRoles,opt => opt.Ignore());
            Mapper.CreateMap<UserViewModel, UserProfile>().ForMember(u => u.webpages_Roles, opt => opt.Ignore());
            Mapper.CreateMap<UserProfile, RegisterModel>();
            Mapper.CreateMap<RegisterModel, UserProfile>();
            Mapper.CreateMap<UserGridRowViewModel, UserProfile>();
            Mapper.CreateMap<UserProfile, UserGridRowViewModel>();
        }
    }
}
