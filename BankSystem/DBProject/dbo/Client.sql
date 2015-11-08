CREATE TABLE [dbo].[Client] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [AccountId]            INT           NOT NULL,
    [IdentityNumber]       NVARCHAR (50) NULL,
    [PassportSerialNumber] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Client_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([Id])
);

