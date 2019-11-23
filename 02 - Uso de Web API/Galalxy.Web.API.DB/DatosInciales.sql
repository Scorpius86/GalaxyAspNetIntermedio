/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

USE [Library]
GO

DECLARE @id UNIQUEIDENTIFIER

SET @id = NEWID()
INSERT INTO [dbo].[Author]([Id],[Name],[Age],[Genre])
     VALUES(@id,'Hector Ramos Santisteban',27,'Masculino');
INSERT INTO [dbo].[Book] ([Id],[AuthorId],[Title],[Description])
     VALUES (NEWID(),@id,'Desarrollo de Web API con Net Core','Libro de Programacion avanzada');


SET @id = NEWID()
INSERT INTO [dbo].[Author]([Id],[Name],[Age],[Genre])
		   VALUES(@id,'Nilton Mandujano Barrios',28,'Masculino');
INSERT INTO [dbo].[Book] ([Id],[AuthorId],[Title],[Description])
     VALUES (NEWID(),@id,'Desarrollo de Web API con Net Core','Libro de Programacion avanzada');

SET @id = NEWID()
INSERT INTO [dbo].[Author]([Id],[Name],[Age],[Genre])
		   VALUES (@id,'Gianmarco Lopez Jara',42,'Masculino');
INSERT INTO [dbo].[Book] ([Id],[AuthorId],[Title],[Description])
     VALUES (NEWID(),@id,'Desarrollo de Web API con Net Core','Libro de Programacion avanzada');

SET @id = NEWID()
INSERT INTO [dbo].[Author]([Id],[Name],[Age],[Genre])
		   VALUES(@id,'Agusto Azaldegui Cam',29,'Masculino');
INSERT INTO [dbo].[Book] ([Id],[AuthorId],[Title],[Description])
     VALUES (NEWID(),@id,'Desarrollo de Web API con Net Core','Libro de Programacion avanzada');
GO



