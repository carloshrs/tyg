<%@ Page Language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Extranet" CodeFile="Extranet.aspx.cs" %>
<html>

<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
<title>Tiempo y Gestión - Extranet</title>
</head>

<frameset rows="87,*" framespacing="0" frameborder="no" id="outfr">
	<frame name="encabezado" src="/Inc/Encabezado.aspx" marginwidth="0" marginheight="0" scrolling="no"  frameborder="no" noresize>
	<frameset cols="159,*" framespacing="0" frameborder="0" id="infr">
		  <frame name="Menu" src="Menu.aspx" target="main" marginwidth="0" marginheight="0" scrolling="auto"  style="border-left: 2 outset #BBDAFF; border-top: 2 outset #BBDAFF">
		  <frame name="Main" src="Informes/ListaInformes.aspx" scrolling="yes" style="border-left: 2 outset #BBDAFF; border-top: 2 outset #BBDAFF">
	</frameset>
	
</frameset>

 
</html>