<%
function formahtml()
	dim c, f
	c=""
	for each f in request.form
		c=c &"<b>"& f &":</b> "& request.form(f) &"<br>"
	next
	formahtml=c
end function

function enviarmailhtml(de, a, titulo, mensaje)
	de=trim(de) 
	a=trim(a) 
	mensaje=trim(mensaje)
	dim result
	result=""

'on error resume next


		
' Se crean los objetos necesarios para el env�o del correo
Set oMail = Server.CreateObject("CDO.Message")
Set iConf = Server.CreateObject("CDO.Configuration")
Set Flds = iConf.Fields

'' Se configuran los parametros necesarios para el env�o
iConf.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendusing") = 1
iConf.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpserver") = "smtp.tiempoygestion.com.ar"
iConf.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpconnectiontimeout") = 10
iConf.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = 25

' Se completan los datos del usuario y la contrase�a necesarios para el envio
iConf.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendusername") = "informes@tiempoygestion.com.ar"
'iConf.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendusername") = "carlosrodriguez@tiempoygestion.com.ar"
''usuario smtp
'iConf.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "info123456"
iConf.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "Info123456"
'password para STMP
iConf.Fields.Update
' Se asignan las propiedades de configuraci�n al objeto
Set oMail.Configuration = iConf
' Destinatario del correo
oMail.To = "informes@tiempoygestion.com.ar"
' Remitente del correo
oMail.From = de
' Subject o asunto
oMail.Subject = "Contacto de tiempoygestion.com.ar"
' Cuerpo del mensaje
'oMail.TextBody = "Este es un e-mail enviado desde la p�gina de ejemplo de Ferozo Windows Edition"
oMail.HTMLBody  = mensaje
' Se env�a el correo
oMail.Send
' Se destruyen los objetos
Set iConf = Nothing
Set Flds = Nothing



	enviarmailhtml=result
end function



function enviarpostal(de, a, titulo, mensaje)
	de=trim(de) 
	a=trim(a) 
	mensaje=trim(mensaje)
	dim result
	result=""


		
		
' Se crean los objetos necesarios para el env�o del correo
		Set oMail = Server.CreateObject("CDO.Message") 
		Set iConf = Server.CreateObject("CDO.Configuration") 
		Set Flds = iConf.Fields 
		
		' Se configuran los parametros necesarios para el env�o
		iConf.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendusing") = 1 
		iConf.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpserver") = "smtp.iplannetworks.net" 
		iConf.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpconnectiontimeout") = 10 
		iConf.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = 25
		' Se completan los datos del usuario y la contrase�a necesarios para el envio
		iConf.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendusername") = "informes@tiempoygestion.com.ar" 'usuario smtp
		iConf.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "123456"  'password para STMP
		iConf.Fields.Update
		' Se asignan las propiedades de configuraci�n al objeto
		Set oMail.Configuration = iConf 
	
		' Destinatario del correo
		oMail.To = a
		' Remitente del correo
		oMail.From = de
		' Subject o asunto
		oMail.Subject = titulo
		' Cuerpo del mensaje
		'oMail.TextBody = mensaje
		oMail.HTMLBody  = mensaje
		'"Este es un e-mail enviado desde la p�gina de ejemplo de Ferozo Windows Edition"
		' Se env�a el correo
		oMail.Send
		' Se destruyen los objetos
		Set iConf = Nothing 
		Set Flds = Nothing

'response.write mensaje &"<br>"


	enviarpostal=result
end function


function enviarmail(de, a, titulo, mensaje, mismtp)
	enviarmail=enviarmailhtml(de, a, titulo, mensaje)
end function


function enviarmailatodos(de, lista, titulo, mensaje, mismtp, tiempoespera, mostrarmails)
	if right(lista, 1)="," then
		lista=left(lista, len(lista)-1)
	end if
	dim mpara, i, result, r
	result=""
	r=""
	mpara=split(lista, ",")
	for i=0 to ubound(mpara)
		mpara(i)=trim(mpara(i))
'		if left(mpara(i), 1)<>"<" then mpara(i) = "<"& mpara(i) &">"
		r=enviarmail( de, mpara(i), titulo, mensaje, mismtp)
		if r="" or isnull(r) then
			r="OK"
		end if
		result= result & mpara(i) &": "& r & VbCrLf
		if mostrarmails=true then
			response.write(mpara(i) &": "& r &"<br>")
		end if
		call esperar(tiempoespera)
	next
	enviarmailatodos=result
end function

sub esperar(segundos)
	dim ahora
	ahora=now
	while response.isclientconnected and cbyte(datediff("s", ahora, now)) < cbyte(segundos)
	wend
end sub
%>