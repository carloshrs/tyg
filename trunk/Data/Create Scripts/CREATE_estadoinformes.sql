/*
MySQL Data Transfer
Source Host: localhost
Source Database: tiempoygestion
Target Host: localhost
Target Database: tiempoygestion
Date: 30/01/2009 10:29:54
*/

SET FOREIGN_KEY_CHECKS=0;

-- ELIMINO LA TABLA
DROP TABLE `estadoinformes`;

-- ----------------------------
-- Table structure for estadoinformes
-- ----------------------------
CREATE TABLE `estadoinformes` (
  `idEstado` int(10) unsigned NOT NULL auto_increment,
  `NombreEstado` varchar(45) NOT NULL default '',
  `DescripcionEstado` text NOT NULL,
  `NombreEstadoExtra` varchar(45) default NULL,
  `Activo` tinyint(3) NOT NULL default '1',
  PRIMARY KEY  (`idEstado`)
) TYPE=MyISAM;

-- ----------------------------
-- Records 
-- ----------------------------
INSERT INTO `estadoinformes` VALUES ('1', 'En espera', '', 'En espera', '1');
INSERT INTO `estadoinformes` VALUES ('2', 'En proceso', '', 'En proceso', '1');
INSERT INTO `estadoinformes` VALUES ('3', 'Finalizado', '', 'Finalizado', '1');
INSERT INTO `estadoinformes` VALUES ('4', 'Cancelado', '', 'Cancelado', '1');
INSERT INTO `estadoinformes` VALUES ('5', 'Modificado', 'Informe Modificado', 'Modificado', '1');
INSERT INTO `estadoinformes` VALUES ('6', 'Ingresó al Registro', '', 'Ingresó al Registro', '1');
