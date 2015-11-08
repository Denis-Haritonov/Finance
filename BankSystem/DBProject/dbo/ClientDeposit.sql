CREATE TABLE [dbo].[ClientDeposit] (
    [ClientId]  INT NOT NULL,
    [DepositId] INT NOT NULL,
    CONSTRAINT [PK_ClientDeposit] PRIMARY KEY CLUSTERED ([ClientId] ASC, [DepositId] ASC),
    CONSTRAINT [FK_ClientDeposit_Client] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]),
    CONSTRAINT [FK_ClientDeposit_Deposit] FOREIGN KEY ([DepositId]) REFERENCES [dbo].[Deposit] ([Id])
);

