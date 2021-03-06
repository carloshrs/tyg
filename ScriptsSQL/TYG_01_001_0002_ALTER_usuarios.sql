/*
   miércoles, 10 de marzo de 20109:59:11
   User: 
   Server: servidor
   Database: tiempoygestion
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.usuarios
	DROP CONSTRAINT DF_usuarios_estado
GO
CREATE TABLE dbo.Tmp_usuarios
	(
	IdUsuario int NOT NULL IDENTITY (1, 1),
	LoginName varchar(65) NOT NULL,
	Nombre varchar(129) NOT NULL,
	Apellido varchar(129) NOT NULL,
	Calle varchar(256) NULL,
	Numero varchar(11) NULL,
	Piso varchar(3) NULL,
	Office varchar(3) NULL,
	Barrio varchar(129) NULL,
	CodPos varchar(9) NULL,
	IdLocalidad int NULL,
	IdProvincia int NULL,
	Email varchar(256) NOT NULL,
	Telefono varchar(33) NULL,
	Celular varchar(33) NULL,
	Password varchar(129) NOT NULL,
	IdCliente int NOT NULL,
	FecCreacion datetime NOT NULL,
	UltimoIngreso datetime NOT NULL,
	Intranet tinyint NOT NULL,
	estado tinyint NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_usuarios ADD CONSTRAINT
	DF_usuarios_UltimoIngreso DEFAULT getdate() FOR UltimoIngreso
GO
ALTER TABLE dbo.Tmp_usuarios ADD CONSTRAINT
	DF_usuarios_estado DEFAULT ((1)) FOR estado
GO
SET IDENTITY_INSERT dbo.Tmp_usuarios ON
GO
IF EXISTS(SELECT * FROM dbo.usuarios)
	 EXEC('INSERT INTO dbo.Tmp_usuarios (IdUsuario, LoginName, Nombre, Apellido, Calle, Numero, Piso, Office, Barrio, CodPos, IdLocalidad, IdProvincia, Email, Telefono, Celular, Password, IdCliente, FecCreacion, UltimoIngreso, Intranet, estado)
		SELECT IdUsuario, LoginName, Nombre, Apellido, Calle, Numero, Piso, Office, Barrio, CodPos, IdLocalidad, IdProvincia, Email, Telefono, Celular, Password, IdCliente, FecCreacion, UltimoIngreso, Intranet, estado FROM dbo.usuarios WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_usuarios OFF
GO
ALTER TABLE dbo.bandejaentrada
	DROP CONSTRAINT FK_bandejaentrada_usuarios
GO
ALTER TABLE dbo.historicoacciones
	DROP CONSTRAINT FK_historicoacciones_usuarios
GO
ALTER TABLE dbo.referencias
	DROP CONSTRAINT FK_referencias_usuarios
GO
ALTER TABLE dbo.contratos
	DROP CONSTRAINT FK_contratos_usuarios
GO
ALTER TABLE dbo.usuariosroles
	DROP CONSTRAINT FK_usuariosroles_usuarios
GO
DROP TABLE dbo.usuarios
GO
EXECUTE sp_rename N'dbo.Tmp_usuarios', N'usuarios', 'OBJECT' 
GO
ALTER TABLE dbo.usuarios ADD CONSTRAINT
	PK_usuarios PRIMARY KEY CLUSTERED 
	(
	IdUsuario
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.usuariosroles ADD CONSTRAINT
	FK_usuariosroles_usuarios FOREIGN KEY
	(
	IdUsuario
	) REFERENCES dbo.usuarios
	(
	IdUsuario
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.contratos ADD CONSTRAINT
	FK_contratos_usuarios FOREIGN KEY
	(
	idUsuario
	) REFERENCES dbo.usuarios
	(
	IdUsuario
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.referencias ADD CONSTRAINT
	FK_referencias_usuarios FOREIGN KEY
	(
	idUsuario
	) REFERENCES dbo.usuarios
	(
	IdUsuario
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.historicoacciones ADD CONSTRAINT
	FK_historicoacciones_usuarios FOREIGN KEY
	(
	idUsuario
	) REFERENCES dbo.usuarios
	(
	IdUsuario
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.bandejaentrada ADD CONSTRAINT
	FK_bandejaentrada_usuarios FOREIGN KEY
	(
	idUsuario
	) REFERENCES dbo.usuarios
	(
	IdUsuario
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
