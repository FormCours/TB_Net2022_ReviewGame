CREATE TABLE [dbo].[Game_Category]
(
	[Id] BIGINT NOT NULL IDENTITY,
	[GameId] BIGINT NOT NULL,
	[CategoryId] BIGINT NOT NULL,

	CONSTRAINT PK_Game_Category PRIMARY KEY ([Id]),
	CONSTRAINT UK_Game_Category UNIQUE ([GameId], [CategoryId]),

	CONSTRAINT FK_Game_Category__Game FOREIGN KEY ([GameId]) REFERENCES [Game]([Id]),
	CONSTRAINT FK_Game_Category__Category FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id])
);
