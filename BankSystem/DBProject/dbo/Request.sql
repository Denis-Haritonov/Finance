CREATE TABLE [dbo].[Request]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ClientId] INT NOT NULL, 
    [RequestType] INT NOT NULL, 
    [Amount] MONEY NOT NULL, 
    [State] INT NOT NULL, 
    [Type] INT NOT NULL, 
    [CreditTypeId] INT NULL, 
    [DepositTypeId] INT NULL, 
    [Date] DATETIME NOT NULL, 
    CONSTRAINT [FK_Request_UserProfile] FOREIGN KEY ([ClientId]) REFERENCES [UserProfile]([UserId]), 
    CONSTRAINT [FK_Request_CreditType] FOREIGN KEY ([CreditTypeId]) REFERENCES [CreditType]([Id]), 
    CONSTRAINT [FK_Request_DepositType] FOREIGN KEY ([DepositTypeId]) REFERENCES [DepositType]([Id])
)
