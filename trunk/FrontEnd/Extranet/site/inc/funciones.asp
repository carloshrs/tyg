<%
function MenuTop(tipo)

  Estilo1 = "linkMenu"
  Estilo2 = "linkMenu"
  Estilo3 = "linkMenu"
  Estilo4 = "linkMenu"
  Estilo5 = "linkMenu"
  Estilo6 = "linkMenu"
  
  If (tipo = 1) Then Estilo1 = "linkMenuOn"
  If (tipo = 2) Then Estilo2 = "linkMenuOn"
  If (tipo = 3) Then Estilo3 = "linkMenuOn"
  If (tipo = 4) Then Estilo4 = "linkMenuOn"
  If (tipo = 5) Then Estilo5 = "linkMenuOn"
  If (tipo = 6) Then Estilo6 = "linkMenuOn"
  
  Response.Write "<a href=""index.asp"" class=""" & Estilo1 & """>HOME</a>"
  Response.Write "<a href=""servicios.asp"" class=""" & Estilo4 & """>SERVICIOS</a>"
  Response.Write "<a href=""novedades.asp"" class=""" & Estilo5 & """>NOVEDADES</a>"
  Response.Write "<a href=""clientes.asp"" class=""" & Estilo4 & """>CLIENTES</a>"
  Response.Write "<a href=""elegirnos.asp"" class=""" & Estilo3 & """>PORQUE ELEGIRNOS</a>"
  Response.Write "<a href=""empresa.asp"" class=""" & Estilo2 & """>NUESTRA EMPRESA</a>"
  Response.Write "<a href=""historia.asp"" class=""" & Estilo1 & """>HISTORIA</a>"
  Response.Write "<a href=""contacto.asp"" class=""" & Estilo6 & """>CONTACTO</a>"
End function


function MenuTopMensajeria(tipo)

  Estilo1 = "linkMenu"
  Estilo2 = "linkMenu"
  Estilo3 = "linkMenu"
  Estilo4 = "linkMenu"
  Estilo5 = "linkMenu"
  Estilo6 = "linkMenu"
  
  If (tipo = 1) Then Estilo1 = "linkMenuOn"
  If (tipo = 2) Then Estilo2 = "linkMenuOn"
  If (tipo = 3) Then Estilo3 = "linkMenuOn"
  If (tipo = 4) Then Estilo4 = "linkMenuOn"
  If (tipo = 5) Then Estilo5 = "linkMenuOn"
  If (tipo = 6) Then Estilo6 = "linkMenuOn"
  
  Response.Write "<a href=""mensajeria.asp"" class=""" & Estilo1 & """>HOME</a>"
  Response.Write "<a href=""mensajeria_servicios.asp"" class=""" & Estilo4 & """>NUESTROS SERVICIOS</a>"
'  Response.Write "<a href=""clientes.asp"" class=""" & Estilo4 & """>NUESTROS CLIENTES</a>"
  Response.Write "<a href=""mensajeria_contacto.asp"" class=""" & Estilo6 & """>CONTACTO</a>"
End function

function PiePagina
	Response.write "<div class=""pie""><div style=""float:left; margin-top:10px;""><a href=""http://www.jus.gov.ar/datos-personales.aspx"" target=""_blank""><img src=""img/pdp-renovacion-2014.jpg"" border=""0"" width=""135"" height=""110"" ></a></div><div style=""float:left; margin-left:40px; font-size:12px; width:550px; margin-top:30px; text-align:center;""><a href=""empresa.asp"" class=""linkMenu"">Quienes somos</a>&nbsp;<a href=""contacto.asp"" class=""linkMenu"">Contacto</a>&nbsp;<a href=""sitemap.asp"" class=""linkMenu"">Mapa del sitio</a><br /><br />Copyright 2014 - Todos los derechos reservados<br>25 de mayo 66 - 2&deg; piso - of. 11 - C&oacute;rdoba, Argentina - C. P. 5000 <br>Tel./Fax: 4229475 - 4228466</div><div style=""float:left; text-align:right; width:100px; margin-top:20px;""><a href=""http://qr.afip.gob.ar/?qr=DdOsHlSK0fuKQ6f8gtPTFA,,"" target=""_F960AFIPInfo""><img src=""http://www.afip.gob.ar/images/f960/DATAWEB.jpg"" border=""0"" height=""110""></a></div></div>"
End function


function accesoIntranet
%>

<!--Start of Zopim Live Chat Script-->
<script type="text/javascript">
window.$zopim||(function(d,s){var z=$zopim=function(c){z._.push(c)},$=z.s=
d.createElement(s),e=d.getElementsByTagName(s)[0];z.set=function(o){z.set.
_.push(o)};z._=[];z.set._=[];$.async=!0;$.setAttribute('charset','utf-8');
    $.src = '//cdn.zopim.com/?Z50slueDm0rxghFRABooS7yoSl5Vo18D'; z.t = +new Date; $.
type='text/javascript';e.parentNode.insertBefore($,e)})(document,'script');
</script>
<!--End of Zopim Live Chat Script-->
      <div style="width:185px; float:left; margin-left:8px;">
        <a href="/LoginExtra.aspx?lightbox[width]=500&lightbox[height]=260&lightbox[modal]=true" class="lightbox"><img src="/Img/acceso-clientes.png" width="183" height="221" border="0" /></a>
</div>

	  <%
End function

function bannerLeft
%>
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
    <!--<div class="novedadesHome" style="background-color:#eee; margin-left:10px; margin-right:10px; margin-top:30px; -moz-border-radius:3px; -khtml-border-radius:3px; -webkit-border-radius:3px;	border-radius:3px; border:solid 1px #666; width:130px;">
      <span class="tituloNovedades">Novedades</span><br />
			<% 
			i=0
			If Not Novedades.EOF Then
					While Not Novedades.EOF 
						Response.write "<span class=""tituloNovedad"">" & Novedades("titulo") & "</span><br>"
						Response.write Novedades("brief")
                        Response.write "<br />"
                        Response.write left(Novedades("fecha"),10) & " | <a href=""novedad.asp?idNota=" & Novedades("idNota") & """ class=""novedadesLink"">Ver m&aacute;s</a><br /><br />"
						Novedades.MoveNext
					Wend
				Else
					Response.Write("No hay novedades")
				End If
			%>
      </p>
</div>-->

<div id="fb-root"></div>
<script>(function(d, s, id) {
  var js, fjs = d.getElementsByTagName(s)[0];
  if (d.getElementById(id)) return;
  js = d.createElement(s); js.id = id;
  js.src = "//connect.facebook.net/es_LA/all.js#xfbml=1&appId=262422793815869";
  fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>

<div class="fb-like-box" data-href="https://www.facebook.com/TiempoGestion" data-width="200" data-show-faces="true" data-stream="false" data-header="true" style="margin-left:1px; margin-bottom:20px; background-color:#FFF;"></div>
<!--<div style="float:left; margin-top:20px; margin-left:20px;"><a href="https://www.facebook.com/TiempoGestion" target="_blank"><img src="/site/Img/siguenos-en-facebook.png" width="140" height="57" border="0" /></a></div>-->

<%
end function

function serviciosSoftAbajo(pagina) 

	Response.Write("<div><h5 style=""font-size:14px;"">Otros servicios</h5>")
	
	if (pagina <> "web") then
		Response.Write("<div class=""cajaServicioSoftwareAbajo""><a href=""servicios_desarrollo_software_web.asp"" class=""linkServicios""><span style=""font-size:18px"">Desarrollo Web</span><br />Desarrollamos Sitios creativos, originales y con óptima navegabilidad.</a></div>")
	end if
	
	if (pagina <> "aplicaciones") then
		Response.Write("<div class=""cajaServicioSoftwareAbajo""><a href=""servicios_desarrollo_software_aplicaciones.asp"" class=""linkServicios""><span style=""font-size:18px"">Aplicaciones Web</span><br />Intranet, Administrador de contenidos, Aplicaciones para dispositivos móviles.</a></div>")
	end if
	
	'if (pagina <> "simple") then
		'Response.Write("<div class=""cajaServicioSoftwareAbajo""><a href=""servicios_desarrollo_software_web_simple.asp"" class=""linkServicios""><span style=""font-size:18px"">Tu Web simple!</span><br />Obtenga su sitio web de manera muy simple utilizando nuestras plantillas pre diseñadas.</a></div>")
	'end if
		
	if (pagina <> "seo") then
		Response.Write("<div class=""cajaServicioSoftwareAbajo""><a href=""servicios_desarrollo_software_seo.asp"" class=""linkServicios""><span style=""font-size:18px"">Posicionamiento web</span> (SEO)<br />Su empresa en primeros lugares.</a></div>")
	end if
	
	if (pagina <> "outsourcing") then
	Response.Write("<div class=""cajaServicioSoftwareAbajo""><a href=""servicios_desarrollo_software_outsourcing.asp"" class=""linkServicios""><span style=""font-size:18px"">Outsourcing</span><br />Es una decisión estratégica para su empresa que evita contratar personal fijo.</a></div>")
	end if
	
	Response.Write("</div>")

end function

function BannerTop
%>
<div id="slider1" class="sliderwrapper">

<div class="contentdiv">
<img src="img/banerhomeautomotor.png" width="185" height="153" border="0" />
</div>

<div class="contentdiv">
<img src="img/banerhomecredito.png" width="185" height="153" border="0" />
</div>

<div class="contentdiv">
<img src="img/banerhomeinmobiliaria.png" width="185" height="153" border="0" />
</div>

<div class="contentdiv">
<a href="mensajeria.asp"><img src="img/banerhomemensajeria.png" width="185" height="153" border="0" /></a>
</div>

<div class="contentdiv">
<img src="img/banerhomerecursos.png" width="185" height="153" border="0" />
</div>

<div class="contentdiv">
<img src="img/banerhomesoft.png" width="185" height="153" border="0" />
</div>


<div id="paginate-slider1" class="pagination">
<script type="text/javascript">

featuredcontentslider.init({
	id: "slider1",  //id of main slider DIV
	contentsource: ["inline", ""],  //Valid values: ["inline", ""] or ["ajax", "path_to_file"]
	toc: "#increment",  //Valid values: "#increment", "markup", ["label1", "label2", etc]
	nextprev: ["<", ">"],  //labels for "prev" and "next" links. Set to "" to hide.
	revealtype: "click", //Behavior of pagination links to reveal the slides: "click" or "mouseover"
	enablefade: [true, 0.2],  //[true/false, fadedegree]
	autorotate: [true, 3000],  //[true/false, pausetime]
	onChange: function(previndex, curindex){  //event handler fired whenever script changes slide
		//previndex holds index of last slide viewed b4 current (1=1st slide, 2nd=2nd etc)
		//curindex holds index of currently shown slide (1=1st slide, 2nd=2nd etc)
	}
})

</script>
</div>
</div>


<%
End function
%>


