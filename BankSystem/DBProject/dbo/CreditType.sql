CREATE TABLE [dbo].[CreditType] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50)  NOT NULL,
    [Percent]         FLOAT (53)     NOT NULL,
    [OverduePercent]  FLOAT (53)     NOT NULL,
    [ReturnTerm]      BIGINT         NOT NULL,
    [StartAmountInfo] NVARCHAR (MAX) NULL,
    [RulesInfo]       NVARCHAR (MAX) NULL,
    [IsActive] BIT NOT NULL, 
    CONSTRAINT [PK_CreditType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

