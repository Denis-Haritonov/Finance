CREATE TABLE [dbo].[Account] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Username]  NVARCHAR (MAX) NOT NULL,
    [Password]  NVARCHAR (50)  NOT NULL,
    [Name]      NVARCHAR (MAX) NOT NULL,
    [Surname]   NVARCHAR (MAX) NOT NULL,
    [OtherName] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([Id] ASC)
);

