﻿CREATE TABLE [dbo].[Category]
(
	[Id] BIGINT NOT NULL IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(1000),

	CONSTRAINT PK_Category PRIMARY KEY ([Id]),
	CONSTRAINT UK_Category__Name UNIQUE ([Name])
)
