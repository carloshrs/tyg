select * from campo
where idGrupo = 17

select * from grupo

-- Tipo de propiedad
insert into campo
(idGrupo, descripcion)
values (14, 'Construcci�n antigua')

insert into campo
(idGrupo, descripcion)
values (14, 'Construcci�n con mejoras')

insert into campo
(idGrupo, descripcion)
values (14, 'Construcci�n sin terminar')

insert into campo
(idGrupo, descripcion)
values (14, 'En Construcci�n')


-- Resultado

insert into campo
(idGrupo, descripcion)
values (17, 'Alquilado')


insert into campo
(idGrupo, descripcion)
values (17, 'No atendido')


insert into campo
(idGrupo, descripcion)
values (17, 'Domicilio err�neo')


-- Se amplia el campo antiguedad

alter table ambientalBancor
alter column antiguedad varchar (200)