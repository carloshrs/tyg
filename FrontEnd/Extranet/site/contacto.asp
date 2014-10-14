<!-- #include file="inc/funciones.asp" -->


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<head>
<meta http-equiv="Content-Type" content="text/html;charset=UTF-8">

<title>Tiempo & Gesti&oacute;n</title>
<link rel="SHORTCUT ICON" href="http://www.tiempoygestion.com/site/img/favicon.png">
<meta name="description" content="Tiempo y Gestión, Gestión Registro de la propiedad, Gestión Talento Humano, Gestión Registro del Automotor, Gestión Desarrollo de Software">
<meta name="keywords" content="Informe de propiedad, Verificación Comercial, Verificación Particular, Verificación Laboral">

  <script type="text/javascript" src="javascripts/jquery.min.js"></script>

  <link rel="stylesheet" type="text/css" href="javascripts/lightbox/themes/default/jquery.lightbox.css" />
  <!--[if IE 6]><link rel="stylesheet" type="text/css" href="javascript/lightbox/themes/default/jquery.lightbox.ie6.css" /><![endif]-->
  <script type="text/javascript" src="javascripts/lightbox/jquery.lightbox.js"></script>
  <script type="text/javascript">
    jQuery(document).ready(function(){
      jQuery('.lightbox').lightbox();
    });
  </script>
  
<!-- Begin Stylesheets -->
		<link rel="stylesheet" href="stylesheets/reset.css" type="text/css" media="screen" />
		<link rel="stylesheet" href="stylesheets/coda-slider-2.0.css" type="text/css" media="screen" />
	<!-- End Stylesheets -->

<style type="text/css">

.paginate{
	width: 170px;
	margin-top:5px;
	font:bold 12px Arial;
	text-align:center;
}

</style>

<link href="css/estilos.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/includes.js"></script>
<script type="text/javascript">
<!--
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}
function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}
//-->
</script>
<script type="text/javascript">

  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'UA-13115240-3']);
  _gaq.push(['_trackPageview']);

  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();

</script>
</head>

<body>
<div class="cajaGeneral">
  <div class="topFlash">
    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0" width="867" height="238">
      <param name="movie" value="swf/02.swf" />
      <param name="quality" value="high" />
      <param name="wmode" value="opaque" />
      <embed src="swf/02.swf" quality="high" wmode="opaque" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" width="867" height="238"></embed>
    </object>
  </div>
  <div class="botonesTop"><%=MenuTop(0)%></div>
  <div class="fondoContenido">
    <div class="menuIzquierdo">
<%=AccesoIntranet%>
<%=BannerLeft%>
    </div>


  <div class="contenido">
    
<div class="contenidoPrincipalInterno">
    <div class="contenidoInterno"><span class="titulo">CONTACTO</span>
      <br>
      <p>Puede comunicarse a nuestros telefonos: <span style="font-size:13px; font-weight:bold;">(0351) 4229475 - 4228466 - 4228578</span><br />
        Tambien, puede hacerlo a través de esta sección enviarnos sus sugerencias, 
							dudas o consultas.<br />
 </p>
      <table width="100%"  border="0" cellpadding="1" cellspacing="2" class="textoProductos">
							<form action="enviar.asp" method="post">
                              <tr>
                                <td width="42%"><div align="right" class="texto">Nombre y Apellido:&nbsp;</div></td>
                                <td width="58%"><input type="text" name="nombre" size="35" class="cajaInput"></td>
                              </tr>
                              <tr>
                                <td><div align="right" class="texto">Empresa:&nbsp;</div></td>
                                <td><input type="text" name="empresa" size="35" class="cajaInput"></td>
                              </tr>
                              <tr>
                                <td><div align="right" class="texto">Tel&eacute;fono:&nbsp;</div></td>
                                <td><input type="text" name="telefono" size="35" class="cajaInput"></td>
                              </tr>
                              <tr>
                                <td class="texto"><div align="right">E-mail:&nbsp;</div></td>
                                <td><input type="text" name="email" size="35" class="cajaInput"></td>
                              </tr>
                              <tr>
                                <td class="texto"><div align="right">Servicios:&nbsp;</div></td>
                                <td>
								<%
								valor = request("id")
								Response.write "<select name=""servicio"" class=""cajaInput"">" & chr(10)
									if (valor = 1) Then
										Response.write "<option selected>Verificación de domicilio particular" & chr(10)
									Else
										Response.write "<option>Verificación de domicilio particular" & chr(10)
									End If
									if (valor = 2) Then
									Response.write "<option selected>Verificación de domicilio laboral" & chr(10)
									Else
									Response.write "<option>Verificación de domicilio laboral" & chr(10)
									End If
									if (valor = 3) Then
									Response.write "<option selected>Verificaciones de comercios" & chr(10)
									Else
									Response.write "<option>Verificaciones de comercios" & chr(10)
									End If
									if (valor = 4) Then
										Response.write "<option selected>Informe ambiental preocuopacional" & chr(10)
									Else
										Response.write "<option>Informe ambiental preocuopacional" & chr(10)
									End If
									if (valor = 5) Then
										Response.write "<option selected>Informes de propiedad" & chr(10)
									Else
										Response.write "<option>Informes de propiedad" & chr(10)
									End If
									if (valor = 6) Then
										Response.write "<option selected>Informes de automotor" & chr(10)
									Else
										Response.write "<option>Informes de automotor" & chr(10)
									End If
									if (valor = 7) Then
										Response.write "<option selected>Búsqueda de propiedad" & chr(10)
									Else
										Response.write "<option>Búsqueda de propiedad" & chr(10)
									End If
									if (valor = 8) Then
										Response.write "<option selected>Búsqueda de dominio" & chr(10)
									Else
										Response.write "<option>Búsqueda de dominio" & chr(10)
									End If
									if (valor = 9) Then
										Response.write "<option selected>Búsqueda de automotores" & chr(10)
									Else
										Response.write "<option>Búsqueda de automotores" & chr(10)
									End If
									if (valor = 10) Then
										Response.write "<option selected>Referencias de inquilinos" & chr(10)
									Else
										Response.write "<option>Referencias de inquilinos" & chr(10)
									End If
									if (valor = 11) Then
										Response.write "<option selected>Referencias bancarias" & chr(10)
									Else
										Response.write "<option>Referencias bancarias" & chr(10)
									End If
									if (valor = 12) Then
										Response.write "<option selected>Servicios de cadetería" & chr(10)
									Else
										Response.write "<option>Servicios de cadetería" & chr(10)
									End If
									if (valor = 13) Then
										Response.write "<option selected>Informes sobre siniestros" & chr(10)
									Else
										Response.write "<option>Informes sobre siniestros" & chr(10)
									End If
								Response.write "<option>Otros" & chr(10)
								Response.write "</select>" & chr(10)
								%>
								</td>
                              </tr>
                              <tr>
                                <td valign="top" class="texto"><div align="right">Mensaje:&nbsp;</div></td>
                                <td><textarea name="mensaje" rows="4" cols="38"  class="cajaInput"></textarea></td>
                              </tr>
                              <tr>
                                <td class="texto"><div align="right"></div></td>
                                <td><input type="hidden" name="mensajeria" value="0" /><input type="submit"  name="txtEnviar" value="Enviar"  class="cajaInput"></td>
                              </tr>
							  </form>
                            </table>
      <p><br /><br />
 </p>
    </div>
    <div class="imagenDerecha"><img src="img/imagenporqueelegirnos.jpg" width="142" height="283" /></div>
  </div>

  </div>
  </div>
  <%=PiePagina%>
  
</div>
</body>
</html>