CREATE TABLE [dbo].[Request]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ClientId] INT NOT NULL, 
    [RequestType] INT NOT NULL, 
    [Amount] MONEY NOT NULL, 
    [Status] INT NOT NULL, 
    CONSTRAINT [FK_Request_Client] FOREIGN KEY ([ClientId]) REFERENCES [Client]([Id])
)
