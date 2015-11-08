CREATE TABLE [dbo].[Transaction] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Amount]    MONEY         NOT NULL,
    [Recipient] NVARCHAR (50) NOT NULL,
    [DepositId] INT           NULL,
    [CreditId]  INT           NULL,
    CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Transaction_Credit] FOREIGN KEY ([CreditId]) REFERENCES [dbo].[Credit] ([Id]),
    CONSTRAINT [FK_Transaction_Deposit] FOREIGN KEY ([DepositId]) REFERENCES [dbo].[Deposit] ([Id])
);

