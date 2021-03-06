/*
   martes, 04 de septiembre de 201206:33:33 p.m.
   User: 
   Server: desarrollo-pc\sqlexpress
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
ALTER TABLE dbo.remitos ADD
	estado int NOT NULL CONSTRAINT DF_remitos_estado DEFAULT 1,
	periodoCobranza int NOT NULL CONSTRAINT DF_remitos_periodoCobranza DEFAULT 1
GO
COMMIT
