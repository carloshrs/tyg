/*
   jueves, 30 de agosto de 201206:29:49 p.m.
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
ALTER TABLE dbo.verifdomparticular ADD
	complejo varchar(150) NULL,
	torre varchar(150) NULL,
	lote varchar(11) NULL,
	manzana varchar(11) NULL
GO
COMMIT
