CREATE TABLE [dbo].[Employee] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [AccountId]      INT NOT NULL,
    [EmployeeTypeId] INT NOT NULL,
    [IsActive]       BIT CONSTRAINT [DF_Employee_IsActive] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Employee_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([Id]),
    CONSTRAINT [FK_Employee_EmployeeType] FOREIGN KEY ([EmployeeTypeId]) REFERENCES [dbo].[EmployeeType] ([Id])
);

