CREATE TABLE [dbo].[UsersInRoles] (
	[Id] INT primary key identity,
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,
    CONSTRAINT [fk_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([RoleId]),
    CONSTRAINT [fk_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserProfile] ([UserId])
);

