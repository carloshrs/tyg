<%
'option explicit
response.buffer=true
%>
<!-- #include file="inc/funcionesmail.asp" -->
<%
dim mensaje, temp
mensaje=formahtml()
temp=enviarmailhtml(request.Form("Email"), "informes@tiempoygestion.com.ar", "Consulta desde TiempoyGestion.com.ar", mensaje)

nombre = request.Form("nombre")
empresa = request.Form("empresa")
telefono = request.Form("telefono")
email = request.Form("email")
servicio = request.Form("servicio")
mensaje = request.Form("mensaje")

Dim IP
IP = Request.ServerVariables("HTTP_X_FORWARDED_FOR") ' se chequea si hay un proxy
If IP ="" Then IP = Request.ServerVariables("REMOTE_ADDR") ' si no hay proxy se toma la IP original
'response.Write(IP)
'Response.End()

Set Conn = Server.CreateObject("ADODB.Connection")
Conn.Open Application("ConnectionString")
sql= "INSERT into Contacto (nombre, email, servicio, mensaje "
if (empresa <> "") Then sql = sql & ", empresa "
if (telefono <> "") Then sql = sql & ", telefono "
sql = sql & ", ip)" 
sql = sql & " VALUES('" & nombre &"', '" & email &"', '" & servicio &"', '" & mensaje &"' "
if (empresa <> "") Then sql = sql & ", '" & empresa & "'"
if (telefono <> "") Then sql = sql & ", '" & telefono & "'"
sql = sql & ", '" & IP & "')" 
'Response.write sql
Conn.Execute(sql)

if(request.Form("mensajeria") = 1) Then
	archivoRedir = "mensajeria_contactofin.asp"
Else
	archivoRedir = "contactofin.asp"
End If

response.redirect(archivoRedir)
%>