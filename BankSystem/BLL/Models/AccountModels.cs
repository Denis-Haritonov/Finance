using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using Common.Enum;
using DAL;

namespace BankSystem.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [DataType(DataType.Password)]
        [Display(Name = "Текущий пароль")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [StringLength(100, ErrorMessage = "Пароль {0} должен быть не меньше {2} символов.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повторите пароль")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        public int? UserId { get; set; }

        public Roles UserRole { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Фамилия пользователя")]
        public string UserSurName { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Отчество пользователя")]
        public string UserLastName { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime UserBirthDate { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Мобильный телефон")]
        [RegularExpression("\\+375(\\d){2}-?(\\d){3}-?(\\d){2}-?(\\d){2}", ErrorMessage = "Неверный формат телефона")]
        public String MobilePhone { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Емейл адресс")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Не правильный email аддресс")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Номер паспорта")]
        [RegularExpression("(ab|AB|BM|bm|HB|hb|KH|kh|MP|mp|MC|mc|KB|kb|pp|PP)(\\d){7}", ErrorMessage = "Недействительный номер паспорта")]
        public String UserPassportSerialNumber { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Идентификационный номер")]
        [RegularExpression("(\\d){7}[A-Z](\\d){3}[A-Z]{2}\\d", ErrorMessage = "Недействительный Идентификационный номер")]
        public String PassportIdentificationNumber { get; set; }
        
        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Кем выдан")]
        public String PassportApprovel { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [DataType(DataType.Date)]
        [Display(Name = "Выдан до")]       
        public DateTime PassportEndDate { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Адресс регистрации")] 
        public String RegistrationAddress { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [Display(Name = "Ceкретная фраза")]
        public String SecretPhrase { get; set; }

        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        [StringLength(100, ErrorMessage = "Пароль {0} должен быть не меньше {2} символов.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Поле {0} нужно заполнить")]
        public string Login { get; set; }


    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
