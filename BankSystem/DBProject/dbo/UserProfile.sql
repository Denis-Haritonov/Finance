CREATE TABLE [dbo].[UserProfile] (
    [UserId]   INT  primary key IDENTITY (1, 1) NOT NULL,
    [UserName] NVARCHAR (56) NOT NULL DEFAULT '',
    [UserSurname] NVARCHAR(56) NOT NULL DEFAULT '', 
    [UserLastName] NVARCHAR(56) NOT NULL DEFAULT '', 
    [UserBirthDate] DATE NULL , 
    [UserPassportSerialNumber] NVARCHAR(9) NOT NULL DEFAULT '', 
    [MobilePhone] NVARCHAR(20) NOT NULL DEFAULT '', 
    [Email] NVARCHAR(50) NOT NULL DEFAULT '', 
    [PassportIdentificationNumber] NVARCHAR(50) NOT NULL DEFAULT '', 
    [PassportApprovel] NVARCHAR(100) NOT NULL DEFAULT '', 
    [PassportEndDate] DATE NULL DEFAULT null, 
    [RegistrationAddress] NVARCHAR(100) NOT NULL DEFAULT '', 
    [SecretPhrase] NVARCHAR(100) NOT NULL DEFAULT '', 
    [Login] NVARCHAR(50) NOT NULL DEFAULT ''
);

