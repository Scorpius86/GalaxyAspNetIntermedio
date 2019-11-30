CREATE TABLE [dbo].[Pedido]
(
	PedidoId INT NOT NULL IDENTITY,
	UsuarioId INT NOT NULL,
	ClienteId INT NOT NULL,
	Fecha DATETIME NOT NULL,

	CONSTRAINT PK_Pedido PRIMARY KEY (PedidoId),
	CONSTRAINT FK_Pedido_Usuario FOREIGN KEY (UsuarioId) REFERENCES Usuario(UsuarioId),
	CONSTRAINT FK_Pedido_Cliente FOREIGN KEY (ClienteId) REFERENCES Cliente(ClienteId) 
)
