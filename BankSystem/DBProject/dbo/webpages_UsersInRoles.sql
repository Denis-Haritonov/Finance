CREATE TABLE [dbo].[webpages_UsersInRoles] (
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,
    CONSTRAINT [fk_RoleIdk] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[webpages_Roles] ([RoleId]),
    CONSTRAINT [fk_UserIdk] FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserProfile] ([UserId])
);

