INSERT INTO usuarios (LoginName,Nombre,Apellido,email,Password,IdCliente)
SELECT 'defaultUser'+IdCliente,'','Solicitud Telef�nica','','',IdCliente
FROM clientes;