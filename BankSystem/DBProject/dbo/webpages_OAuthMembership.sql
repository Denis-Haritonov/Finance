CREATE TABLE [dbo].[webpages_OAuthMembership] (
	[Id] int primary key identity,
    [Provider]       NVARCHAR (30)  NOT NULL,
    [ProviderUserId] NVARCHAR (100) NOT NULL,
    [UserId]         INT            NOT NULL,

);

