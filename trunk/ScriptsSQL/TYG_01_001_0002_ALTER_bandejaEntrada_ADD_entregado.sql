select top 10 * from bandejaentrada

alter table bandejaentrada
add entregado tinyint default 0

update bandejaentrada
set entregado=0


select * from 
tiposinformes