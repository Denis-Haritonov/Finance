CREATE TABLE [dbo].[Deposit] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [StartDate]     SMALLDATETIME NOT NULL,
    [Balance]       MONEY         NOT NULL,
    [DepositTypeId] INT           NOT NULL,
    [RequestId] INT NULL, 
    [EndDate] SMALLDATETIME NOT NULL, 
    CONSTRAINT [PK_Deposit] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Deposit_DepositType] FOREIGN KEY ([DepositTypeId]) REFERENCES [DepositType]([Id]), 
    CONSTRAINT [FK_Deposit_Request] FOREIGN KEY ([RequestId]) REFERENCES [Request]([Id])
);

