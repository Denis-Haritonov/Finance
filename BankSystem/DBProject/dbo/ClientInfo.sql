CREATE TABLE [dbo].[ClientInfo] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Data]     NVARCHAR (MAX) NOT NULL,
    [ClientId] INT            NOT NULL,
    CONSTRAINT [PK_ClientInfo] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ClientInfo_Client] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id])
);

