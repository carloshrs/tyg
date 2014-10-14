<!-- #include virtual="/inc/funciones.asp" -->


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Type" content="text/html; iso-8859-1">
<title>Tiempo & Gesti&oacute;n</title>
<meta name="description" content="Proust Laboratorio Químico Biológico, Productos, Novedades, Noticias, Contacto, Pool, Peptonas, Lisadoterapia">
<meta name="keywords" content="hidrolizados, lisadoterapia, peptonas, pool, productos, enzimáticos, proteínas">

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
</head>

<body>
<div class="cajaGeneral">
  <div><img src="img/int-topiz.jpg" width="190" height="181" /><img src="img/int-topinvestigacion.jpg" width="678" height="181" /></div>
  <div class="botonesTop"><%=MenuTop(3)%></div>
  <div>
    <div class="menuIzquierdoInterno">
<%=AccesoIntranet%>
    </div>
  </div>
  <div class="contenidoPrincipalInterno">
    <div class="contenidoInterno">
      <p><img src="img/tit_investigacion.gif" width="169" height="23" /><br />
        <br />
        Nuestro compromiso con la salud y bienestar de las personas nos obliga a encarar en forma permanente planes de investigación, tendientes a:<br />
      </p>
      <ul>
        <li> Dilucidar las características físico-químicas y naturaleza de los péptidos con actividad fisiológica.</li>
        <li> Desarrollo de  nuevos productos a base de péptidos, péptidos con el agregado de otros componentes de naturaleza alimenticia y con derivados vegetales. </li>
        <li> Investigación y desarrollo de nuevas tecnologías para la obtención de peptonas con alta concentración de péptidos de bajo peso molecular.</li>
        <li> Investigación de nuevas enzimas para la incorporación de estas en nuevos procesos enzimáticos. </li>
      </ul>
      <p>Para ello, <strong>PROUST</strong> destina el 30% de nuestro volumen de ventas a estas actividades, por eso decimos que estamos comprometidos en “el ciclo del cuidado de la salud”.<br />
      </p>
      <br />
    </div>
    <div class="imagenDerecha"><br />
      <br />
    <img src="img/int-investigacionimagen.jpg" width="124" height="316" /></div>
  </div>
    <%=PiePagina%>
</div>
</body>
</html>