<%
'option explicit
'response.buffer=true
%>
<!-- #include virtual="/inc/funcionesmail.asp" -->
<%
dim mensaje, temp
mensaje=formahtml()
'request.Form("Email")
'; carhu@inmocarhu.com.ar
'temp=enviarmailhtml("info@lacasadelsilenciador.com", "info@lacasadelsilenciador.com", "Contacto www.lacasadelsilenciador.com", mensaje)
temp=enviarmailhtml("info@laboratorioproust.com", "carloshrs@gmail.com", "Contacto desde laboratorioproust.com", mensaje)
'response.redirect("/contactofin.asp")
%>