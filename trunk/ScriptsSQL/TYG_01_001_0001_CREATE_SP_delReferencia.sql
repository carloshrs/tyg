set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_deleteReferencia]
	@idRef	int
AS
BEGIN
	SET NOCOUNT ON;

		DECLARE @cant INT

		SET @cant = (SELECT count(*) FROM bandejaEntrada WHERE idReferencia = @idRef)

		IF (@cant = 0)
		BEGIN
			DELETE referencias WHERE idReferencia = @idRef
		END 

		--SELECT idReferencia FROM BandejaEntrada WHERE idEncabezado=288595

END

