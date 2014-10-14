<!-- #include file="inc/funciones.asp" -->


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Type" content="text/html; iso-8859-1">
<title>Tiempo & Gesti&oacute;n</title>
<link rel="SHORTCUT ICON" href="http://www.tiempoygestion.com/site/img/favicon.png">
<meta name="description" content="Tiempo y Gestión, Gestión Registro de la propiedad, Gestión Talento Humano, Gestión Registro del Automotor, Gestión Desarrollo de Software">
<meta name="keywords" content="Informe de propiedad, Verificación Comercial, Verificación Particular, Verificación Laboral">

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
  <div>
    <div><img src="img/homemensajetop1.jpg" width="372" height="184" /><img src="img/homemensajetop2.jpg" alt="" width="495" height="184" /></div>
    <div style="background-color:#5A91E4; width: 867px;">
    <div style="float:left; width:372px;"><img src="img/homemensaje3.jpg" alt="" width="372" height="33" /></div>
      <div style="float:left; width:465px; height:23px; background-color:#5A91E4; text-align:right; padding-top:10px; padding-right:30px"><%=MenuTopMensajeria(0)%></div>
    </div>
    <div>
      <div style="float:left; width:372px; height:336px;"><img src="img/homemensajebajo.jpg" alt="" width="372" height="336" border="0" usemap="#Map" />
        <map name="Map" id="Map">
          <area shape="rect" coords="27,232,143,314" href="/" />
        </map></div>
      <div style="float:left; width:495px; height:336px; background-image: url(img/homemensajebajoder.jpg); background-repeat: no-repeat;">
        <div class="contenidoMensajeria">
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
                                <td valign="top" class="texto"><div align="right">Consulta:&nbsp;</div></td>
                                <td><textarea name="mensaje" rows="4" cols="38"  class="cajaInput"></textarea></td>
                              </tr>
                              <tr>
                                <td class="texto"><div align="right"></div></td>
                                <td><input type="hidden" name="mensajeria" value="1" /><input type="hidden" name="servicio" value="Servicios de cadeteria" /><input type="submit"  name="txtEnviar" value="Enviar"  class="cajaInput"></td>
                              </tr>
							  </form>
                            </table>
</div>
      </div>
    </div>
    <br />
  </div>
</div>
</body>
</html>