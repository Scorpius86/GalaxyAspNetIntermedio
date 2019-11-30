CREATE TABLE [dbo].[Usuario]
(
	UsuarioId INT NOT NULL IDENTITY,
	NombreUsuario VARCHAR(200) NOT NULL,
	Clave VARCHAR(200) NOT NULL,
	Nombre VARCHAR(200) NOT NULL,
	ApellidoPaterno VARCHAR(200) NOT NULL,
	ApellidoMaterno VARCHAR(200),
	Edad INT,
	SexoId INT,

	CONSTRAINT PK_Usuario PRIMARY KEY (UsuarioId),
	CONSTRAINT FK_Usuario_Sexo FOREIGN KEY (SexoId) REFERENCES Sexo (SexoId),
	CONSTRAINT UC_Usuario UNIQUE (NombreUsuario)
)
