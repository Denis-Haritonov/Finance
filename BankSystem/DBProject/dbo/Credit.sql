CREATE TABLE [dbo].[Credit] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [StartDate]    SMALLDATETIME NOT NULL,
    [StartAmount]  MONEY         NOT NULL,
    [MainDebt]         MONEY         NOT NULL,
    [CreditTypeId] INT           NOT NULL,
    [RequestId] INT NULL, 
    [ClientId] INT NOT NULL, 
    [PercentageDebt] MONEY NOT NULL, 
    [EndDate] SMALLDATETIME NOT NULL, 
    CONSTRAINT [PK_Credit] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Credit_CreditType] FOREIGN KEY ([CreditTypeId]) REFERENCES [CreditType]([Id]), 
    CONSTRAINT [FK_Credit_Request] FOREIGN KEY ([RequestId]) REFERENCES [Request]([Id]), 
    CONSTRAINT [FK_Credit_Client] FOREIGN KEY ([ClientId]) REFERENCES [UserProfile]([UserId])
);

