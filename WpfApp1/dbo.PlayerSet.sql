CREATE TABLE [dbo].[PlayerSet] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NOT NULL,
    [Position] NVARCHAR (MAX) NOT NULL,
    [Age]      INT            NOT NULL,
    [TeamId] INT NULL, 
    CONSTRAINT [PK_PlayerSet] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_PlayerSet_ToTable] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[TeamSet] ([Id])
);

