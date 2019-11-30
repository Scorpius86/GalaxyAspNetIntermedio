CREATE TABLE [dbo].[Cliente]
(
	ClienteId INT NOT NULL IDENTITY,
	Nombre VARCHAR(200) NOT NULL,
	ApellidoPaterno VARCHAR(200) NOT NULL,
	ApellidoMaterno VARCHAR(200),
	Edad INT,
	SexoId INT,

	CONSTRAINT PK_Cliente PRIMARY KEY (ClienteId),
	CONSTRAINT FK_Cliente_Sexo FOREIGN KEY (SexoId) REFERENCES Sexo(SexoId)
)
