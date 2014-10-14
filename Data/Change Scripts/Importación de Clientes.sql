/**
Pasos para ejecutar importaciòn:
 - Importar las tablas clientes, barrios, localidades
 - Eliminar barrios con còdigo duplicado.
 - Pasar el campo CUIT de cliente a BIGINT.
 - Correr esta consulta.
**/

DELETE FROM clientes;
INSERT INTO clientes ( IdCliente, RazonSocial, CUIT, NroIngBrutos, TipoIVA, Calle, Numero, Piso, Office, Barrio, CodPos, IdLocalidad, IdProvincia, Email, Telefono, Fax, Fecha, Encargado, Cargo, Observaciones )
SELECT DISTINCT cod_cli, empresa, cuit, ing_bru, null, calle, nro, piso, dto, nom_bar, _cliente.cod_post, _localidades.cod_loc, _localidades.cod_prov, email, tel, fax, fecha, encargado, cargo, obs_cli
FROM _cliente 
LEFT OUTER JOIN _barrio ON _cliente.cod_bar = _barrio.cod_bar
LEFT OUTER JOIN _localidades ON _barrio.cod_loc = _localidades.cod_loc ;