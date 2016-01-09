CREATE TABLE [dbo].[UserProfile] (
    [UserId]   INT  primary key IDENTITY (1, 1) NOT NULL,
    [UserName] NVARCHAR (56) NOT NULL DEFAULT '',
    [UserSurname] NVARCHAR(56) NOT NULL DEFAULT '', 
    [UserLastName] NVARCHAR(56) NOT NULL DEFAULT '', 
    [UserBirthDate] DATE NULL , 
    [UserPassportSerialNumber] NVARCHAR(9) NOT NULL DEFAULT '', 
    UNIQUE NONCLUSTERED ([UserName] ASC)
);

