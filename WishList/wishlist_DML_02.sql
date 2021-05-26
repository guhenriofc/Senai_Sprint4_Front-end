USE WishList;
GO

INSERT INTO Usuarios(email, senha)
VALUES		('mauro@hotmail.com', '12345')
			,('lucas@gmail.com', '12345')
			,('eduardo@outlook.com', '12345')
			,('gustavo@terra.com', '12345')
GO

INSERT INTO Desejos(IdUsuario, Descricao)
VALUES		(1, 'PC GAMER novo, com luzes')
			,(2, 'Touro mecânico')
			,(3, 'Playstation 5')
			,(4, 'Carteira de habilitação')
GO


