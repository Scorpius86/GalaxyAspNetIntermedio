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
     VALUES(@id,'Axel Vazques Herrera',19,'Masculino');
INSERT INTO [dbo].[Book] ([Id],[AuthorId],[Title],[Description])
     VALUES (NEWID(),@id,'Desarrollo de Web API con Net Core','Libro de Programacion avanzada');


SET @id = NEWID()
INSERT INTO [dbo].[Author]([Id],[Name],[Age],[Genre])
		   VALUES(@id,'Evelyn Melgarejo Gutierrez',23,'Femenino');
INSERT INTO [dbo].[Book] ([Id],[AuthorId],[Title],[Description])
     VALUES (NEWID(),@id,'Desarrollo de Web API con Net Core','Libro de Programacion avanzada');

SET @id = NEWID()
INSERT INTO [dbo].[Author]([Id],[Name],[Age],[Genre])
		   VALUES (@id,'Angel Lucas Huaroto Parra',23,'Masculino');
INSERT INTO [dbo].[Book] ([Id],[AuthorId],[Title],[Description])
     VALUES (NEWID(),@id,'Desarrollo de Web API con Net Core','Libro de Programacion avanzada');

SET @id = NEWID()
INSERT INTO [dbo].[Author]([Id],[Name],[Age],[Genre])
		   VALUES(@id,'Nelly Cortez Sanchez',46,'Femenino');
INSERT INTO [dbo].[Book] ([Id],[AuthorId],[Title],[Description])
     VALUES (NEWID(),@id,'Desarrollo de Web API con Net Core','Libro de Programacion avanzada');
GO



