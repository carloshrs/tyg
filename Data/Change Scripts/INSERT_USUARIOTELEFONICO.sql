INSERT INTO usuarios (LoginName,Nombre,Apellido,email,Password,IdCliente)
SELECT 'defaultUser'+IdCliente,'','Solicitud Telefónica','','',IdCliente
FROM clientes;