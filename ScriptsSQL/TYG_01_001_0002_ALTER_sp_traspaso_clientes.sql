set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Carlos Rodriguez>
-- Create date: <19/04/2012>
-- Description:	<Traslada informes de un cliente a otro (unifica) y deja al 1er cliente inactivo >
-- =============================================
ALTER PROCEDURE [dbo].[sp_TraspasoInformesdeClienteaOtroCliente] 
	-- Add the parameters for the stored procedure here
	@clienteOrigen	int,
	@clienteDestino	int

AS
BEGIN
	DECLARE @idEncabezado int, @query nvarchar(2000), @queryIns nvarchar(2000), @queryUpd nvarchar(2000), @queryUpdCl nvarchar(2000), @queryUpdRemitos nvarchar(2000), @queryUpdCtaCte nvarchar(2000), @queryUpdCtaCteMov nvarchar(2000)
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE vCursor CURSOR STATIC LOCAL FORWARD_ONLY FOR
		SELECT idEncabezado 
					FROM bandejaentrada
					WHERE idCliente = @clienteOrigen
	
	OPEN vCursor FETCH NEXT FROM vCursor INTO @idEncabezado
        WHILE (@@FETCH_STATUS = 0) BEGIN
                
            print @idEncabezado

			SET @queryIns = 'INSERT INTO informes_traspasados (idinforme, idClienteOrigen, idClienteDestino)
			VALUES ('+str(@idEncabezado)+', '+str(@clienteOrigen)+', '+str(@clienteDestino)+')'
			EXEC sp_executesql @queryIns
			

			SET @queryUpd = 'UPDATE bandejaentrada
			SET idCliente = '+str(@clienteDestino)+'
			WHERE idCliente = '+str(@clienteOrigen)
			EXEC sp_executesql @queryUpd


			SET @queryUpdCl = 'UPDATE clientes
			SET activo = 0
			WHERE idCliente = '+str(@clienteOrigen)
			EXEC sp_executesql @queryUpdCl


			SET @queryUpdRemitos = 'update remitos
			set idcliente='+str(@clienteDestino) +' 
			where idcliente='+str(@clienteOrigen)
			EXEC sp_executesql @queryUpdRemitos

			SET @queryUpdCtaCte = 'update cuentascorrientes
			set idcliente='+str(@clienteDestino) +' 
			where idcliente='+str(@clienteOrigen)
			EXEC sp_executesql @queryUpdCtaCte

			SET @queryUpdCtaCteMov = 'update CtaCteMovimientos
			set idcliente='+str(@clienteDestino) +' 
			where idcliente='+str(@clienteOrigen)
			EXEC sp_executesql @queryUpdCtaCteMov


            FETCH NEXT FROM vCursor INTO @idEncabezado
        END
	CLOSE vCursor
	DEALLOCATE vCursor


END

