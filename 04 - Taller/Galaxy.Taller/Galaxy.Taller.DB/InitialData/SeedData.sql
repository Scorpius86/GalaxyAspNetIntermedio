/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [dbo].[Sexo] ([Descripcion])
     VALUES ('Masculino'),
			('Femenino');

INSERT INTO [dbo].[Marca] ([Descripcion])
     VALUES ('Nike'),
			('Adidas'),
			('Dior'),
			('Inditex'),
			('H&M');

INSERT INTO [dbo].[Usuario] ([NombreUsuario],[Clave],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[Edad],[SexoId])
     VALUES ('Erick','Password123','Erick','Aróstegui','Cunza',37,1),
			('Robbie','Password123','Robbie','Williams','',45,1),
			('John','Password123','John','Francis','Bongiovi',57,1);
			

INSERT INTO [dbo].[Cliente] ([Nombre],[ApellidoPaterno],[ApellidoMaterno],[Edad],[SexoId])
     VALUES ('Robert','Downey Jr','',54,1),
			('Chris','Evans','',37,1),
			('Chris','Hemsworth','',35,1),
			('Scarlett','Johansson','',34,1),
			('Mark','Ruffalo','',51,1),
			('Jeremy','Renner','',48,1),
			('Gwyneth','Paltrow','',48,1);

INSERT INTO [dbo].[Producto] ([MarcaId] ,[Descripcion],[Precio],[UnidadMedidad])
     VALUES (1 ,'Nike Air Max 720',190,'UND'),
			(1 ,'Nike Air Force 1 07 LV8 2',110,'UND'),
			(1 ,'Nike Sportswear',50,'UND'),

			(2 ,'QUESTAR TND SHOES',90,'UND'),
			(2 ,'ULTRABOOST 19 SHOES',180,'UND'),
			(2 ,'ADIDAS X MISSONI P.H.X. JACKET',300,'UND'),

			(3 ,'"B23" HIGH-TOP DIOR AND SORAYAMA SNEAKER',1050,'UND'),
			(3 ,'COTTON SWEATSHIRT, DIOR AND SORAYAMA PRINT',1200,'UND'),
			(3 ,'COTTON T-SHIRT, DIOR AND SORAYAMA PRINT',550,'UND'),

			(4 ,'WESTERN TRIM FLAT LEATHER SANDALS',90,'UND'),
			(4 ,'BLUE COLLECTION FLAT LEATHER SANDALS',80,'UND'),
			(4 ,'METALLIC MINI SHOPPER',550,'UND'),

			(5 ,'Derby Shoes',40,'UND'),
			(5 ,'Suede Sneakers',50,'UND'),
			(5 ,'Leather Oxford Shoes',60,'UND');


INSERT INTO [dbo].[Pedido] ([UsuarioId],[ClienteId],[Fecha])
     VALUES (1 ,1,GETDATE()),
			(1 ,2,GETDATE()),
			(1 ,3,GETDATE());


INSERT INTO [dbo].[PedidoProducto] ([PedidoId],[ProductoId],[Cantidad])
     VALUES
           (1,1,1),
		   (1,4,1),
		   (1,7,1),

		   (2,2,1),
		   (2,3,1),
		   (2,8,1),

		   (3,3,1),
		   (3,6,1),
		   (3,9,1);
		   