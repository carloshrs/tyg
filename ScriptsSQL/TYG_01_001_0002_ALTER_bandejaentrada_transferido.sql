/*
   jueves, 14 de abril de 201104:48:57 p.m.
   User: 
   Server: DESARROLLO-PC\SQLEXPRESS
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
ALTER TABLE dbo.bandejaentrada ADD
	idEncabezadoTransferido numeric(18, 0) NULL
GO
COMMIT
