<!-- #include virtual="/inc/funciones.asp" -->


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Type" content="text/html; iso-8859-1">
<title>Tiempo & Gesti&oacute;n</title>
<meta name="description" content="Tiempo y Gestión, Gestión Registro de la propiedad, Gestión Talento Humano, Gestión Registro del Automotor, Gestión Desarrollo de Software">
<meta name="keywords" content="Informe de propiedad, Verificación Comercial, Verificación Particular, Verificación Laboral">
<meta name="google-site-verification" content="qKnIm_Lv4rdHACwG7PQ9npagIUbP-NGBecTsA1G1XWI" />

<script type="text/javascript" src="inc/jquery.min.js"></script>

<style type="text/css">

#myreel{ /*sample CSS for demo*/
border:0px solid black;
}

.paginate{
	width: 170px;
	margin-top:5px;
	font:bold 12px Arial;
	text-align:center;
}

</style>

<script src="inc/reelslideshow.js" type="text/javascript"></script>

<script type="text/javascript">

var firstreel=new reelslideshow({
	wrapperid: "myreel", //ID of blank DIV on page to house Slideshow
	dimensions: [170, 140], //width/height of gallery in pixels. Should reflect dimensions of largest image
	imagearray: [
		["img/banerhomeinmobiliaria.png"], //["image_path", "optional_link", "optional_target"]
		["img/banerhomecredito.png"],
		["img/banerhomeautomotor.png"],
		["img/banerhomerecursos.png"],
		["img/banerhomemensajeria.png","mensajeria.asp","_self"],
		["img/banerhomesoft.png"] //<--no trailing comma after very last image element!
	],
	displaymode: {type:'auto', pause:3000, cycles:2, pauseonmouseover:true},
	orientation: "h", //Valid values: "h" or "v"
	persist: true, //remember last viewed slide and recall within same session?
	slideduration: 300 //transition duration (milliseconds)
})

</script>

<link href="css/estilos.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/includes.js"></script>
<link rel="stylesheet" type="text/css" href="css/contentslider.css" />
<script type="text/javascript" src="js/contentslider.js"></script>
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
<style type="text/css">
<!--
#apDiv1 {
	position:absolute;
	left:25px;
	top:233px;
	width:165px;
	height:126px;
	z-index:1;
}
-->
</style>
</head>

<body onload="MM_preloadImages('http://www.tiempoygestion.com:83/Res/banners/cpcpi.png');">
<div class="cajaGeneral">
<%=BannerLeft%>
  <div class="topFlash">
    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0" width="867" height="238">
      <param name="movie" value="swf/01.swf" />
      <param name="quality" value="high" />
      <param name="wmode" value="opaque" />
      <embed src="swf/01.swf" quality="high" wmode="opaque" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" width="867" height="238"></embed>
    </object>
  </div>

  <div class="botonesTop"><%=MenuTop(0)%></div>
  <div id="rotorIzq">
      </div>
  <div class="fondoContenido">
      <%'=BannerTop%>
      
    <div class="menuIzquierdo">
		<%=AccesoIntranet%>
    </div>


  <div class="contenido">
    <div class="contenidoHome">
      <p><strong><span class="textoLogo">Tiempo &amp; Gesti&oacute;n</span></strong> le brinda un servicio ideal para estar prevenido y minimizar el riesgo en sus negocios, de los cuales nos sentimos parte, con el consecuente compromiso que ello implica.<br />
        Son ya m&aacute;s de 15 a&ntilde;os de trayectoria donde seguimos conservando los n&uacute;meros telef&oacute;nicos de aquel inicio.<br />
        El aval m&aacute;s importante es la cosecha de todas las empresas que nos motivan a superarnos.<br />
        Ya no buscamos imponernos en el medio sino escuchar y crear soluciones a sus necesidades. <br />
        En la din&aacute;mica general del planeta y la del mundo inmobiliario en particular, necesariamente nuestra empresa debe estar al mismo ritmo de evoluci&oacute;n y rapidez que la realidad de los negocios, hoy requiere.<br />
        A trav&eacute;s de <span class="textoLogo">Tiempo &amp; Gesti&oacute;n</span>, usted ya puede tomar decisiones en sus negocios financieros, comerciales, o contractuales bajo un marco de total de veracidad.</p>
</div>
    
    	<%
			Set oConn = Server.CreateObject("ADODB.Connection")
'			response.write Application("ConnectionString")
			oConn.open Application("ConnectionString")
			SQL = "Select idNota, fecha, titulo, brief "
			SQL = SQL & "FROM notas WHERE habilitado=1 AND idTipoNota=1 AND privado=0 "
			SQL = SQL & "ORDER BY orden"
            'response.write sql
            'response.end
			Set Novedades = oConn.execute(SQL)
		%>
    <div class="novedadesHome">
      <p><span class="tituloNovedades">Novedades</span><br />
			<% 
			i=0
			If Not Novedades.EOF Then
					While Not Novedades.EOF 
						Response.write "<span class=""tituloNovedad"">" & Novedades("titulo") & "</span><br>"
						Response.write Novedades("brief")
                        Response.write "<br />"
                        Response.write left(Novedades("fecha"),10) & " | <a href=""articulo.asp?idNota=" & Novedades("idNota") & """ class=""novedadesLink"">Ver más</a><br /><br />"
						Novedades.MoveNext
					Wend
				Else
					Response.Write("No hay novedades")
				End If
			%>
      </p>
</div>
    <div class="listadoClientes">Nuestros clientes
      <br />
<div class="listadoClientesLogos"><img src="clientes/logo_bancor.png" width="145" height="52" style="margin:5px;" /><img src="clientes/banco-frances.gif" width="150" style="margin:5px; margin-bottom:20px;" /><img src="clientes/banco-roela.png" width="150" style="margin:5px; margin-bottom:10px;"/><img src="clientes/foto25_shoppings_76.jpg" width="120" height="59"  style="margin:4px;"/><img src="clientes/agd.png" width="80" height="41"  style="margin:10px; margin-bottom:12px;"/><img src="clientes/cacic.png" width="140" height="54" style="margin:4px;" /><br />
  <img src="clientes/riesgoonline.png" width="130" height="27" style="margin:4px; margin-bottom:12px;" /><img src="clientes/edisur.png" width="140" height="44"  style="margin:4px;"/><img src="clientes/sertear.png" width="170" height="24"  style="margin:4px; margin-bottom:12px;"/></div>
    </div>
  </div>
  </div>
  <div class="pie"><%=PiePagina%></div>
  
</div>

</body>
</html>