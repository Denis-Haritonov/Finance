CREATE TABLE [dbo].[EmployeeType] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_EmployeeType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

