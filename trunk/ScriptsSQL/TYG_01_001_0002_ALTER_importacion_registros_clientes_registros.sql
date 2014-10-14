insert into imp_homologacion
(tipo, id_fox, descripcion)
values
('T_INF', 'C','CLIENTES')


update imp_registro
set id_cliente = 2824,
cant_cliente=0
where fecha = (select top 1 fecha from imp_registro
order by fecha desc)


select top 10 * from imp_registro
order by fecha desc
