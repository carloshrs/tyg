   /* Este cursor deja las contraseñas iguales al nombre de usuario.
  La tabla Cliente tiene estos tres campos: CliCod, CliUser, CliPass */
    -- declaramos las variables
    --    declare @cod as int
    -- declare @user as varchar(50)
	--declare @pass as varchar(50)
	declare @cod as int
	declare @ano as varchar(6)
    -- declaramos un cursor llamado "CURSORITO". El select debe contener sólo los campos a utilizar.
        declare CURSORITO cursor for
		select idEncabezado,propano
		from bandejaentrada
		where 
		propano < 100 --and propano <1000
		and propano is not null
		and propano <> ''
		and propano <> 0
		and propano <> 1
    open CURSORITO
        -- Avanzamos un registro y cargamos en las variables los valores encontrados en el primer registro
  fetch next from CURSORITO
  into @cod, @ano
      while @@fetch_status = 0
    begin
    update bandejaentrada set propano='19'+@ano where idEncabezado=@cod
	--	select '19'+@ano from bandejaentrada where idEncabezado=@cod
    -- Avanzamos otro registro
    fetch next from CURSORITO
    into @cod, @ano
    end
    -- cerramos el cursor
        close CURSORITO
  deallocate CURSORITO



/*

select --count(*)
top 100 idEncabezado, propfolio, proptomo, propano, fechacarga
--delete
from bandejaentrada
where 
--propano like '68        P.H.108'
propano < 100 --and propano <1000
and propano is not null
and propano <> ''
and propano <> 0
and propano <> 1

*/