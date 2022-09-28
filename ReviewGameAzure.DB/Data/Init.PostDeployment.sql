
SET IDENTITY_INSERT [Category] ON;

INSERT INTO Category ([Id], [Name], [Description])
 VALUES (1, 'Action', NULL),
		(2, 'Roque Like', NULL),
		(3, 'RPG', 'Jeu de role'),
		(4, 'Simulation', 'Comme dans la réalité, mais en mieux :o');


SET IDENTITY_INSERT [Category] OFF;