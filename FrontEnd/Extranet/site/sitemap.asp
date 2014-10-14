<!-- #include file="inc/funciones.asp" -->


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Type" content="text/html; iso-8859-1">
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
    <div class="contenidoInterno"><span class="titulo">Mapa del sitio</span><br><br />

      <ul>
        <li><a href="index.asp" class="linkServicios">Home</a></li>
        <li><a href="servicios.asp" class="linkServicios">Servicios</a>
          <ul>
            <li><a href="servicios_registro_propiedad.asp" class="linkServicios">Gestión Registro de la Propiedad</a></li>
            <li><a href="servicios_talento_humano.asp" class="linkServicios">Gestión Talento Humano</a></li>
            <li><a href="servicios_registro_automotor.asp" class="linkServicios">Gestión Registro del Automotor</a></li>
            <li><a href="servicios_analisis_crediticio.asp" class="linkServicios">Gestión Analisis Crediticio</a></li>
            <li><a href="servicios_mensajeria.asp" class="linkServicios">Gestión Mensajeria Específica</a>
              <ul>
                <li><a href="mensajeria_servicios.asp" class="linkServicios">Nuestros servicios</a></li>
                <li><a href="mensajeria_contacto.asp" class="linkServicios">Contacto</a></li>
                </ul>
            </li>
            <li><a href="servicios_desarrollo_software.asp" class="linkServicios">Gestión Desarrollo de Software</a>
              <ul>
                <li><a href="servicios_desarrollo_software_web.asp" class="linkServicios">Desarrollo web</a></li>
                <li><a href="servicios_desarrollo_software_web_simple.asp" class="linkServicios">Tu web simple!</a></li>
                <li><a href="servicios_desarrollo_software_outsourcing.asp" class="linkServicios">Outsourcing</a></li>
                <li><a href="servicios_desarrollo_software_seo.asp" class="linkServicios">Posicionamiento web</a></li>
                </ul>
            </li>
            </ul>
        </li>
        <li><a href="novedades.asp" class="linkServicios">Novedades</a></li>
        <li><a href="clientes.asp" class="linkServicios">Clientes</a></li>
        <li><a href="elegirnos.asp" class="linkServicios">Porque elegirnos</a></li>
        <li><a href="empresa.asp" class="linkServicios">Nuestra empresa</a></li>
        <li><a href="historia.asp" class="linkServicios">Historia</a></li>
        <li><a href="contacto.asp" class="linkServicios">Contacto</a></li>
        <li><a href="https://www.facebook.com/TiempoGestion" target="_blank" class="linkServicios">Facebook</a></li>
      </ul>
<br />


</div>
    <div class="imagenDerecha"><img src="img/imagenporqueelegirnos.jpg" width="142" height="283" /></div>
  </div>

  </div>
  </div>
  <%=PiePagina%>
  
</div>
</body>
</html>