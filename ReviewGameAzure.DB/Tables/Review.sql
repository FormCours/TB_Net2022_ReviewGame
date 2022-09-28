CREATE TABLE [dbo].[Review]
(
	[Id] BIGINT NOT NULL IDENTITY,
	[Pseudo] NVARCHAR(50) NOT NULL,
	[Rating] INT NOT NULL,
	[Comment] NVARCHAR(2000) NOT NULL,
	[Status] INT NOT NULL,
	[GameId] BIGINT NOT NULL,

	CONSTRAINT PK_Review PRIMARY KEY ([Id]),
	CONSTRAINT CK_Review__Rating CHECK ([Rating] >= 0 AND [Rating] <= 5),
	CONSTRAINT FK_Review__Game FOREIGN KEY ([GameId]) REFERENCES [Game]([Id])
);
