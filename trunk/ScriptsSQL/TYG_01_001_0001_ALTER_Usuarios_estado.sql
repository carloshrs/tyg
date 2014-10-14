select * from Usuarios

alter table usuarios
add estado tinyint


update usuarios
set estado=1


ALTER TABLE dbo.usuarios ADD CONSTRAINT
	DF_usuarios_estado DEFAULT 1 FOR estado
GO