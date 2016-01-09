CREATE TABLE [dbo].[Roles] (
    [RoleId]   INT  primary key IDENTITY (1, 1) NOT NULL,
    [RoleName] NVARCHAR (256) NOT NULL,
    UNIQUE NONCLUSTERED ([RoleName] ASC)
);

