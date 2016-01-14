CREATE TABLE [dbo].[CreditPayment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [CreditId] INT NOT NULL, 
    [MainAmount] MONEY NOT NULL, 
    [Type] INT NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [PercentsAmount] MONEY NOT NULL, 
    CONSTRAINT [FK_CreditPayment_Credit] FOREIGN KEY ([CreditId]) REFERENCES [Credit]([Id])
)
