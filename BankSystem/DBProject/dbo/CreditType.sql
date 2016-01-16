CREATE TABLE [dbo].[CreditType] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50)  NOT NULL,
    [Percent]         FLOAT (53)     NOT NULL,
    [OverduePercent]  FLOAT (53)     NOT NULL,
    [ReturnTerm]      BIGINT         NOT NULL,
    [IsActive] BIT NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [CurrencyShort] VARCHAR(3) NOT NULL, 
    CONSTRAINT [PK_CreditType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

