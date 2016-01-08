CREATE TABLE [dbo].[Request]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ClientId] INT NOT NULL, 
    [RequestType] INT NOT NULL, 
    [Amount] MONEY NOT NULL, 
    [Status] INT NOT NULL, 
    [Type] INT NOT NULL, 
    CONSTRAINT [FK_Request_UserProfile] FOREIGN KEY ([ClientId]) REFERENCES [UserProfile]([UserId])
)
