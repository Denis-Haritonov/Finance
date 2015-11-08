CREATE TABLE [dbo].[ClientCredit] (
    [ClientId] INT NOT NULL,
    [CreditId] INT NOT NULL,
    CONSTRAINT [PK_ClientCredit] PRIMARY KEY CLUSTERED ([ClientId] ASC, [CreditId] ASC),
    CONSTRAINT [FK_ClientCredit_Client] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]),
    CONSTRAINT [FK_ClientCredit_Credit] FOREIGN KEY ([CreditId]) REFERENCES [dbo].[Credit] ([Id])
);

