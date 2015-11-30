CREATE TABLE [dbo].[UserProfile] (
    [UserId]   INT           IDENTITY (1, 1) NOT NULL,
    [UserName] NVARCHAR (56) NOT NULL DEFAULT '',
    [UserSurname] NVARCHAR(56) NOT NULL DEFAULT '', 
    [UserLastName] NVARCHAR(56) NOT NULL DEFAULT '', 
    [UserBirthDate] DATE NULL , 
    [UserPassportSerialNumber] NVARCHAR(9) NOT NULL DEFAULT '', 
    PRIMARY KEY CLUSTERED ([UserId] ASC),
    UNIQUE NONCLUSTERED ([UserName] ASC)
);

