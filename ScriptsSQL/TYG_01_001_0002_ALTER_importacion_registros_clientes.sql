/*
   lunes, 15 de febrero de 201011:26:11
   User: sa
   Server: SERVIDOR
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
ALTER TABLE dbo.imp_registro ADD
	id_cliente int NULL,
	cant_cliente int NULL
GO
COMMIT
