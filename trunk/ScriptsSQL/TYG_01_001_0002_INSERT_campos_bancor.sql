select * from campo
where idGrupo = 17

select * from grupo

-- Tipo de propiedad
insert into campo
(idGrupo, descripcion)
values (14, 'Construcción antigua')

insert into campo
(idGrupo, descripcion)
values (14, 'Construcción con mejoras')

insert into campo
(idGrupo, descripcion)
values (14, 'Construcción sin terminar')

insert into campo
(idGrupo, descripcion)
values (14, 'En Construcción')


-- Resultado

insert into campo
(idGrupo, descripcion)
values (17, 'Alquilado')


insert into campo
(idGrupo, descripcion)
values (17, 'No atendido')


insert into campo
(idGrupo, descripcion)
values (17, 'Domicilio erróneo')


-- Se amplia el campo antiguedad

alter table ambientalBancor
alter column antiguedad varchar (200)