<!-- #include virtual="/inc/funciones.asp" -->


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Type" content="text/html; iso-8859-1">
<title>Tiempo & Gesti&oacute;n</title>
<meta name="description" content="Tiempo y Gestión, Gestión Registro de la propiedad, Gestión Talento Humano, Gestión Registro del Automotor, Gestión Desarrollo de Software">
<meta name="keywords" content="Informe de propiedad, Verificación Comercial, Verificación Particular, Verificación Laboral">
<meta name="google-site-verification" content="qKnIm_Lv4rdHACwG7PQ9npagIUbP-NGBecTsA1G1XWI" />

<script type="text/javascript" src="/inc/jquery.min.js"></script>

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

<script src="/inc/reelslideshow.js" type="text/javascript"></script>

<script type="text/javascript">

var firstreel=new reelslideshow({
	wrapperid: "myreel", //ID of blank DIV on page to house Slideshow
	dimensions: [170, 140], //width/height of gallery in pixels. Should reflect dimensions of largest image
	imagearray: [
		["/img/banerhomeinmobiliaria.png"], //["image_path", "optional_link", "optional_target"]
		["/img/banerhomecredito.png"],
		["/img/banerhomeautomotor.png"],
		["/img/banerhomerecursos.png"],
		["/img/banerhomemensajeria.png","mensajeria.asp","_self"],
		["/img/banerhomesoft.png"] //<--no trailing comma after very last image element!
	],
	displaymode: {type:'auto', pause:3000, cycles:2, pauseonmouseover:true},
	orientation: "h", //Valid values: "h" or "v"
	persist: true, //remember last viewed slide and recall within same session?
	slideduration: 300 //transition duration (milliseconds)
})

</script>

<link href="/css/estilos.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/includes.js"></script>
<link rel="stylesheet" type="text/css" href="/css/contentslider.css" />
<script type="text/javascript" src="/js/contentslider.js"></script>
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

<body>
<div class="cajaGeneral">
<%=BannerLeft%>
  <div class="topFlash">
    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0" width="867" height="238">
      <param name="movie" value="/swf/01.swf" />
      <param name="quality" value="high" />
      <param name="wmode" value="opaque" />
      <embed src="/swf/01.swf" quality="high" wmode="opaque" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" width="867" height="238"></embed>
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
    <div class="contenidoHome" style="text-align:center; width:600px">
    <%
			if (Request.form("txtCodigo") <> "" ) Then
				Set oConn = Server.CreateObject("ADODB.Connection")
	'			response.write Application("ConnectionString")
				oConn.open Application("ConnectionString")
				SQL = "Select idTipo "
				SQL = SQL & "FROM premios WHERE activo = 1 AND clave='" & Request.form("txtCodigo") & "'"
				'response.write sql & "<br>"
				
				Set Premio = oConn.execute(SQL)
				
				If (Not Premio.EOF) Then
					Premio =Premio("idTipo")
				Else
					Premio = ""
				End If
				
				'response.Write(Premio)
				'response.end
			End if
			
			if(Premio <> "") Then
				Response.Write("<p><br /><span style='font-weight:bold; font-size:18px'>¡¡Felicitaciones!!</span> <br /><br /><br />Su empresa ha sido beneficiada con importantes descuentos en informes y servicios de mensajeria. <br>Para acceder al beneficio, comunicarse con <strong>Gabriel Caron</strong> a los telefonos: <strong>4229475 - 4228466</strong><br /><br /></p>")
'Response.Write("<ul><li><strong>10</strong> Verificaciones laborales")
'Response.Write("<li><strong>10</strong> Verificaciones particulares</ul>")

Set oConn = Server.CreateObject("ADODB.Connection")
	'			response.write Application("ConnectionString")
				oConn.open Application("ConnectionString")
				SQL2 = "UPDATE premios SET fechaActivacion=getdate() WHERE activo = 1 AND clave='" & Request.form("txtCodigo") & "'"
				'response.write sql & "<br>"
				
				oConn.execute(SQL2)
				else
		%>
      <p><br />
        Ingrese el código del voucher para obtener los beneficios:<br />
      </p>
      <form id="form1" name="form1" method="post" action="index.asp">
        <div style="text-align:center; font-size:18px"><strong>Código </strong>
          <label>
            <input type="text" name="txtCodigo" id="txtCodigo" style="font-size:24px; color:#00F; background-color:#CAEEFF;" maxlength="6" size="8" />
          </label>
          <br />
          <br />
          
            <input type="submit" name="txtBoton" id="txtBoton" value="Enviar"  style="font-size:18px;"/>
          
        </div>
      </form>
      <% 
	  End If
	  %>
      <p>&nbsp; </p>
    </div>
    
  </div>
  </div>
  <div class="pie"><%=PiePagina%></div>
  
</div>

</body>
</html>