CREATE TABLE [dbo].[DepositPayment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [DepositId] INT NOT NULL, 
    [Type] INT NOT NULL, 
    [Amount] MONEY NOT NULL, 
    [Date] DATETIME NOT NULL, 
    CONSTRAINT [FK_DepositPayment_Deposit] FOREIGN KEY ([DepositId]) REFERENCES [Deposit]([Id])
)
