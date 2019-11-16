CREATE TABLE [dbo].[Book]
(
	Id UniqueIdentifier Not NUll,
	AuthorId UNIQUEIDENTIFIER NOT NULL,
	Title VARCHAR(50),
	Description VARCHAR(50),

	Constraint PK_Book Primary Key (Id),
	Constraint FK_Book_Author Foreign Key (AuthorId) References Author (Id)
)
