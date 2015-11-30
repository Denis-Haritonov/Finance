CREATE TABLE [dbo].[Client] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [UserProfileId]            INT           NOT NULL,
    [IdentityNumber]       NVARCHAR (50) NULL,
    [PassportSerialNumber] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Client_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [dbo].[UserProfile] ([UserId])
);

