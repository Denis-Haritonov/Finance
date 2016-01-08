CREATE TABLE [dbo].[DepositType] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50)  NOT NULL,
    [ReturnTerm] BIGINT         NOT NULL,
    [Percent]    FLOAT (53)     NOT NULL,
    [TermInfo]   NVARCHAR (MAX) NULL,
    [RulesInfo]  NVARCHAR (MAX) NULL,
    [IsActive] BIT NOT NULL, 
    CONSTRAINT [PK_DepositType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

