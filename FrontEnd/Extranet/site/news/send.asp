<%
'option explicit
response.buffer=true
%>
<!-- #include file="inc/funcionesmail.asp" -->
<%
dim mensaje, temp
'mensaje=formahtml()

mensaje="<body style='font-family:Arial, Helvetica, sans-serif;	font-size:12px;'>
<p>Institución Cervantes organiza las VII Jornadas de Capacitación en Negocios
  Inmobiliarios, primer Foro Regional Inmobiliario, los próximos 2 y 3 de<br />
Noviembre en el Hotel Portal del Lago, de Villa Carlos Paz.  <br />
  <br />
  <strong>Institución Cervantes presenta el Foro Regional Inmobiliario</strong><br />
  </p>
<ul>
  <li> Las VII Jornadas de Capacitación en Negocios Inmobiliarios se
    presentan como el primer foro regional del sector denominado Real<br />
  Estate.</li>
  <li> El encuentro ofrecerá una visión estratégica de las nuevas
  tendencias y los desafíos del mercado inmobiliario.</li>
  <li> El evento se llevará a cabo en el Hotel Portal del Lago, de Villa
    Carlos Paz, un establecimiento de nivel internacional emplazado en<br />
    las Sierras de Córdoba.<br />
  </li>
</ul>
<p>  Profesionales expertos del sector de los bienes raíces expondrán su visión y
  experiencia acerca de la actualidad del mercado inmobiliario regional y nacional, las
  innovaciones y los desafíos del sector.<br />
  Luego de seis años consecutivos de realización exitosa, las Jornadas de Capacitación
  de Institución Cervantes trascenderán su carácter eminentemente local para
  convertirse en 2012 en el primer Foro Regional Inmobiliario. El objetivo es
  consolidarse como un referente para la región central y atender a las inquietudes de
  un sector profesional activo y exigente.<br />
  El temario de las Jornadas abordará cuestiones como el futuro de las inversiones, la
  dicotomía entre constructor, desarrollista e inversionista y el modelo de concertación
  público privada. Asimismo, se analizará un aspecto clave en la realidad del mercado
  nacional: la repercusión de la pesificación en los desarrollos inmobiliarios, como así
  también el rol del Estado en el sector de la construcción.<br />
  Profesionales del campo de la administración inmobiliaria, corretaje y subasta, así
  como desarrollistas, emprendedores y estudiantes de carreras vinculadas al sector
  inmobiliario están convocados a formar parte de este espacio de reflexión y análisis
  profesional.<br />
  El evento se llevará a cabo en el Hotel Portal del Lago, de Villa Carlos Paz, un
  establecimiento de nivel internacional emplazado en un entorno natural único de las
  Sierras de Córdoba. Así, el Foro Regional Inmobiliario se presenta como una
  oportunidad inmejorable para los asistentes de establecer un intercambio con sus
  pares y colegas, en el marco de un paisaje de belleza natural.<br />
  <br />
  <strong>Fecha: 2 y 3 de Noviembre de 2012<br />
  Lugar: Hotel Portal del Lago. Villa Carlos Paz. Córdoba<br />
  Arancel: clientes de Tiempo &amp; Gestión $150<br />
Inscripción: 25 de mayo 66, 2º piso, of 11</strong><br />
  <br />
  <br />
  <img src='news_cervantes/logo_cervantes.jpg' width='181' height='135'/><img src='news_cervantes/logo.gif' width='208' height='97' style='margin-left:50px;'/><br /><br /></p><br><br>
</body>"


Set Conn = Server.CreateObject("ADODB.Connection")
Conn.Open Application("ConnectionString")
sql= "Select email FROM _email"
'Conn.Execute(sql)
Email = "carloshrs@gmail.com"
temp=enviarmailhtml(Email, "informes@tiempoygestion.com.ar", "Tiempo y Gestión informa: Foro Regional Inmobiliario", mensaje)


'nombre = request.Form("nombre")
'empresa = request.Form("empresa")
'telefono = request.Form("telefono")
'email = request.Form("email")
'servicio = request.Form("servicio")
'mensaje = request.Form("mensaje")

'Dim IP
'IP = Request.ServerVariables("HTTP_X_FORWARDED_FOR") ' se chequea si hay un proxy
'If IP ="" Then IP = Request.ServerVariables("REMOTE_ADDR") ' si no hay proxy se toma la IP original
'response.Write(IP)
'Response.End()

'Set Conn = Server.CreateObject("ADODB.Connection")
'Conn.Open Application("ConnectionString")
'sql= "INSERT into Contacto (nombre, email, servicio, mensaje "
'if (empresa <> "") Then sql = sql & ", empresa "
'if (telefono <> "") Then sql = sql & ", telefono "
'sql = sql & ", ip)" 
'sql = sql & " VALUES('" & nombre &"', '" & email &"', '" & servicio &"', '" & mensaje &"' "
'if (empresa <> "") Then sql = sql & ", '" & empresa & "'"
'if (telefono <> "") Then sql = sql & ", '" & telefono & "'"
'sql = sql & ", '" & IP & "')" 
'Response.write sql
'Conn.Execute(sql)

'if(request.Form("mensajeria") = 1) Then
'	archivoRedir = "mensajeria_contactofin.asp"
'Else
archivoRedir = "send.asp"
'End If

response.redirect(archivoRedir)
%>