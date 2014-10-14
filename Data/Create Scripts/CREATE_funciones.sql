/*
MySQL Data Transfer
Source Host: localhost
Source Database: tiempoygestion
Target Host: localhost
Target Database: tiempoygestion
Date: 22/01/2009 13:04:20
*/

SET FOREIGN_KEY_CHECKS=0;

-- ELIMINO LA TABLA
DROP TABLE `funciones`;

-- ----------------------------
-- Table structure for funciones
-- ----------------------------
CREATE TABLE `funciones` (
  `IdFuncion` int(6) unsigned NOT NULL auto_increment,
  `Nombre` varchar(128) NOT NULL default '',
  `UrlKey` text NOT NULL,
  PRIMARY KEY  (`IdFuncion`),
  FULLTEXT KEY `UrlKey` (`UrlKey`)
) TYPE=MyISAM;

-- ----------------------------
-- Records 
-- ----------------------------
INSERT INTO `funciones` VALUES ('1', 'Administrar Usuarios', 'ListaUsuarios.aspx');
INSERT INTO `funciones` VALUES ('2', 'Modificar Usuario', 'ABMUsuario.aspx');
INSERT INTO `funciones` VALUES ('3', 'Administrar Clientes', 'ListaClientes.aspx');
INSERT INTO `funciones` VALUES ('4', 'Asignar Roles', 'UsuarioAddRol.aspx');
INSERT INTO `funciones` VALUES ('5', 'Modificar Cliente', 'ABMCliente.aspx');
INSERT INTO `funciones` VALUES ('6', 'Administrar Roles', 'ListaRoles.aspx');
INSERT INTO `funciones` VALUES ('7', 'Administrar Funciones', 'ListaFunciones.aspx');
INSERT INTO `funciones` VALUES ('8', 'Modificar Rol', 'ABMRol.aspx');
INSERT INTO `funciones` VALUES ('9', 'Modificar Funcion', 'ABMFuncion.aspx');
INSERT INTO `funciones` VALUES ('10', 'Asignar Funciones', 'FuncionAddRol.aspx');
INSERT INTO `funciones` VALUES ('11', 'Inicio Intranet', 'Intranet.aspx;BandejaEntrada.aspx;Principal.aspx;Default.aspx');
