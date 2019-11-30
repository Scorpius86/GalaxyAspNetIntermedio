CREATE TABLE [dbo].[PedidoProducto]
(
	PedidoProductoId INT NOT NULL IDENTITY,
	PedidoId INT NOT NULL,
	ProductoId INT NOT NULL,
	Cantidad INT DEFAULT 0 NOT NULL,

	CONSTRAINT PK_PedidoProducto PRIMARY KEY (PedidoProductoId),
	CONSTRAINT FK_PedidoProducto_Pedido FOREIGN KEY (PedidoId) REFERENCES Pedido(PedidoId),
	CONSTRAINT FK_PedidoProducto_Producto FOREIGN KEY (ProductoId) REFERENCES Producto(ProductoId),
)
