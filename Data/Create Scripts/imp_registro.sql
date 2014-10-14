/*
MySQL Data Transfer
Source Host: localhost
Source Database: tiempoygestion
Target Host: localhost
Target Database: tiempoygestion
Date: 16/03/2009 11:53:03
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for imp_registro
-- ----------------------------
CREATE TABLE `imp_registro` (
  `fecha` timestamp(14) NOT NULL,
  `resultado` varchar(255) default NULL,
  `id_automotor` int(11) default NULL,
  `cant_automotor` int(11) default NULL,
  `id_propiedad` int(11) default NULL,
  `cant_propiedad` int(11) default NULL,
  `id_vLaboral` int(11) default NULL,
  `cant_vLaboral` int(11) default NULL,
  `id_vParticular` int(11) default NULL,
  `cant_vParticular` int(11) default NULL,
  `id_vComercial` int(11) default NULL,
  `cant_vComercial` int(11) default NULL,
  `cant_solicitudes` int(11) default NULL,
  `id_solicitudes` int(11) default NULL,
  `log` text,
  PRIMARY KEY  (`fecha`)
) TYPE=MyISAM;
