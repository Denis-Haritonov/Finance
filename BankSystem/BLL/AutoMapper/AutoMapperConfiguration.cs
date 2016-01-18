using System;
using BankSystem.Models;
using BLL.Models;
using BLL.Models.GridModels;
using BLL.Models.GridModels.Credit;
using BLL.Models.GridModels.CreditType;
using BLL.Models.GridModels.DepositType;
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
            Mapper.CreateMap<CreditType, CreditTypeRowViewModel>()
                .ForMember(ct => ct.Percent, opt => opt.MapFrom(ct => ct.Percent * 100))
                .ForMember(ct => ct.OverduePercent, opt => opt.MapFrom(ct => ct.OverduePercent * 100))
                .ForMember(ct => ct.ReturnTerm, opt => opt.MapFrom(ct => new TimeSpan(ct.ReturnTerm).Days));
            Mapper.CreateMap<CreditTypeRowViewModel, CreditType>()
                .ForMember(ct => ct.Percent, opt => opt.MapFrom(ct => ct.Percent / 100))
                .ForMember(ct => ct.OverduePercent, opt => opt.MapFrom(ct => ct.OverduePercent / 100))
                .ForMember(ct => ct.ReturnTerm, opt => opt.MapFrom(ct => new TimeSpan(ct.ReturnTerm,0,0,0).Ticks));
            Mapper.CreateMap<CreditType, CreditTypeEditModel>()
               .ForMember(ct => ct.Percent, opt => opt.MapFrom(ct => ct.Percent * 100))
               .ForMember(ct => ct.OverduePercent, opt => opt.MapFrom(ct => ct.OverduePercent * 100))
               .ForMember(ct => ct.ReturnTerm, opt => opt.MapFrom(ct => new TimeSpan(ct.ReturnTerm).Days));
            Mapper.CreateMap<CreditTypeEditModel, CreditType>()
                .ForMember(ct => ct.Percent, opt => opt.MapFrom(ct => ct.Percent / 100))
                .ForMember(ct => ct.OverduePercent, opt => opt.MapFrom(ct => ct.OverduePercent / 100))
                .ForMember(ct => ct.ReturnTerm, opt => opt.MapFrom(ct => new TimeSpan(ct.ReturnTerm, 0, 0, 0).Ticks));
            Mapper.CreateMap<Credit, CreditRowModel>()
                .ForMember(ct => ct.ClientName, opt => opt.MapFrom(ct => ct.UserProfile.UserName + " " + ct.UserProfile.UserSurname + " " + ct.UserProfile.UserLastName + " "))
                .ForMember(ct => ct.CreditTypeName, opt => opt.MapFrom(ct => ct.CreditType.Name));
            Mapper.CreateMap<DepositType, DepositTypeRowModel>()
                .ForMember(ct => ct.Percent, opt => opt.MapFrom(ct => ct.Percent * 100))
                .ForMember(ct => ct.ReturnTerm, opt => opt.MapFrom(ct => new TimeSpan(ct.ReturnTerm).Days));
            Mapper.CreateMap<DepositTypeRowModel, DepositType>()
                .ForMember(ct => ct.Percent, opt => opt.MapFrom(ct => ct.Percent / 100))
                .ForMember(ct => ct.ReturnTerm, opt => opt.MapFrom(ct => new TimeSpan(ct.ReturnTerm, 0, 0, 0).Ticks));
            Mapper.CreateMap<DepositTypeEditModel, DepositType>()
                .ForMember(ct => ct.Percent, opt => opt.MapFrom(ct => ct.Percent / 100))
                .ForMember(ct => ct.ReturnTerm, opt => opt.MapFrom(ct => new TimeSpan(ct.ReturnTerm, 0, 0, 0).Ticks));
            Mapper.CreateMap<DepositType, DepositTypeEditModel>()
                .ForMember(ct => ct.Percent, opt => opt.MapFrom(ct => ct.Percent * 100))
                .ForMember(ct => ct.ReturnTerm, opt => opt.MapFrom(ct => new TimeSpan(ct.ReturnTerm).Days));
           
        }
    }
}
