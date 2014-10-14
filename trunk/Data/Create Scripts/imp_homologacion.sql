D/*
MySQL Data Transfer
Source Host: localhost
Source Database: tiempoygestion
Target Host: localhost
Target Database: tiempoygestion
Date: 12/02/2009 19:17:14
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Creación campo en bandejaentrada
-- ----------------------------

ALTER TABLE bandejaentrada ADD idFox int unsigned null;

-- ----------------------------
-- Table structure for imp_homologacion
-- ----------------------------
CREATE TABLE `imp_homologacion` (
  `tipo` varchar(10) NOT NULL default '',
  `id_fox` varchar(15) NOT NULL default '',
  `id_web` varchar(15) default NULL,
  `descripcion` varchar(100) default NULL,
  FULLTEXT KEY `fox` (`id_fox`)
) TYPE=MyISAM;

-- ----------------------------
-- Table structure for imp_registro
-- ----------------------------
CREATE TABLE `imp_registro` (
  `fecha` timestamp(14) NOT NULL,
  `resultado` varchar(255) default NULL,
  `id_solicitudes` int(11) default NULL,
  `cant_solicitudes` int(11) default NULL,
  PRIMARY KEY  (`fecha`)
) TYPE=MyISAM;

-- ----------------------------
-- Records 
-- ----------------------------
INSERT INTO `imp_homologacion` VALUES ('T_INF', 'IP', '1', 'INFORME DE PROPIEDAD');
INSERT INTO `imp_homologacion` VALUES ('T_INF', 'VDP', '5', 'VERIFICA. DOMICILIO PARTICULAR');
INSERT INTO `imp_homologacion` VALUES ('T_INF', 'VDL', '6', 'VERIFICACION DE DOMICILIO LABORAL');
INSERT INTO `imp_homologacion` VALUES ('T_INF', 'IM', null, 'INFORME DE MOROSIDAD');
INSERT INTO `imp_homologacion` VALUES ('T_INF', 'IA', '2', 'INFORME DE AUTOMOTOR');
INSERT INTO `imp_homologacion` VALUES ('T_INF', 'IRB', null, 'INFORME DE REFERENCIAS BANCARIAS');
INSERT INTO `imp_homologacion` VALUES ('T_INF', 'IRI', null, 'INFORME DE REFERENCIAS COMO INQUILINO');
INSERT INTO `imp_homologacion` VALUES ('T_INF', 'BDP', '13', 'BUSQUEDA DE PROPIEDAD');
INSERT INTO `imp_homologacion` VALUES ('T_INF', 'INPE', null, 'INFORME PERSONAL');
INSERT INTO `imp_homologacion` VALUES ('T_INF', 'INAM', '4', 'INFORME AMBIENTAL');
INSERT INTO `imp_homologacion` VALUES ('T_INF', 'VDC', '7', 'VERIFICACION DOMICILIO COMERCIAL');
INSERT INTO `imp_homologacion` VALUES ('T_INF', 'VDS', null, 'VERIFICACION DE SINIESTROS');
INSERT INTO `imp_homologacion` VALUES ('E_INF', '0', '3', 'EN ESPERA (FORZADO FINALIZADO)');
INSERT INTO `imp_homologacion` VALUES ('E_INF', '1', '3', 'EN PROCESO (FORZADO FINALIZADO)');
INSERT INTO `imp_homologacion` VALUES ('E_INF', '2', '3', 'FINALIZADO');
INSERT INTO `imp_homologacion` VALUES ('T_DOC', 'LC', '2', 'LIBRETA CIVICA');
INSERT INTO `imp_homologacion` VALUES ('T_DOC', 'DNI', '1', 'DOC. NACIONAL DE IDENTIDA');
INSERT INTO `imp_homologacion` VALUES ('T_DOC', 'LE', '3', 'LIBRETA DE ENRROLAMIENTO');
INSERT INTO `imp_homologacion` VALUES ('T_DOC', 'CIP', '5', 'CEDULA DE IDENT.PROV');
INSERT INTO `imp_homologacion` VALUES ('T_DOC', 'CIF', '4', 'CEDULA DE IDENT. FEDERAL');
INSERT INTO `imp_homologacion` VALUES ('T_DOC', 'PTE', '6', 'PASAPORTE');
INSERT INTO `imp_homologacion` VALUES ('T_DOC', 'CUI', '7', 'C.U.I.T.');
