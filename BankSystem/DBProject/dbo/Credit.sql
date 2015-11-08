CREATE TABLE [dbo].[Credit] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [StartDate]    SMALLDATETIME NOT NULL,
    [StartAmount]  MONEY         NOT NULL,
    [Debt]         MONEY         NOT NULL,
    [CreditTypeId] INT           NOT NULL,
    CONSTRAINT [PK_Credit] PRIMARY KEY CLUSTERED ([Id] ASC)
);

