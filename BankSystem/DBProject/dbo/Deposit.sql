CREATE TABLE [dbo].[Deposit] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [StartDate]     SMALLDATETIME NOT NULL,
    [Balance]       MONEY         NOT NULL,
    [DepositTypeId] INT           NOT NULL,
    CONSTRAINT [PK_Deposit] PRIMARY KEY CLUSTERED ([Id] ASC)
);

