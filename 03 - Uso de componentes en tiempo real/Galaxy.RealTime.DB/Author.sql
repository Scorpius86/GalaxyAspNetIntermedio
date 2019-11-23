CREATE TABLE [dbo].[Author]
(
	Id UniqueIdentifier NOT NULL,
	Name VARCHAR(50),
	Age INT NOT NULL,
	Genre VARCHAR(50),

	CONSTRAINT PK_Author PRIMARY KEY (Id)
)
