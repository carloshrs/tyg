/*
   lunes, 22 de marzo de 201016:43:44
   Usuario: sa
   Servidor: SERVERTYG
   Base de datos: tiempoygestion
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
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
ALTER TABLE dbo.clientes ADD
	activo tinyint NULL
GO
ALTER TABLE dbo.clientes ADD CONSTRAINT
	DF_clientes_activo DEFAULT 1 FOR activo
GO
COMMIT
