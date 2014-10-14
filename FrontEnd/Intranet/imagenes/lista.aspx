<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.imagenes.lista" CodeFile="lista.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Listado de imágenes</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%" colSpan="2"><BR>
						Alta de Imágenes<BR>
						<HR>
					</td>
				</tr>
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%">
						<table cellSpacing="0" cellPadding="0" width="480" border="0">
							<TR>
								<TD class="text" colSpan="4" height="10"></TD>
							</TR>
							<TR>
								<TD class="text" width="60%" colSpan="4">
									<asp:Literal id="ltThumbnails" runat="server"></asp:Literal></TD>
							</TR>
							<TR>
								<TD class="text" width="100%" colSpan="4"></TD>
							</TR>
							<TR>
								<TD class="text" width="282" colSpan="4"></TD>
							</TR>
							<TR>
								<TD class="text" width="100%" colSpan="2">Nueva imagen</TD>
							</TR>
							<TR>
								<TD class="text" width="282" colSpan="4">&nbsp;</TD>
							</TR>
							<TR>
								<TD class="text" vAlign="middle" width="70%"><INPUT class="plano" id="txtArchivo" title="Buscar" style="WIDTH: 270pt" type="file" name="txtArchivo"
										runat="server">&nbsp;
									<asp:Label id="lblFile" runat="server">Label</asp:Label></SPAN></TD>
							</TR>
						</table>
					</td>
				</tr>
				<TR>
					<td colSpan="4">
						<table cellSpacing="0" cellPadding="0" width="480" border="0">
							<TR>
								<TD class="text" width="60%">&nbsp;</TD>
								<TD class="text" align="right" width="20%"><input type="button" onclick="javascript:location='ListaReferencias.aspx';" value="Cancelar"></TD>
								<TD class="text" align="right" width="20%"><asp:button id="Aceptar" runat="server" Width="80px" Text="Aceptar" onclick="Aceptar_Click"></asp:button></TD>
							</TR>
						</table>
					</td>
				</TR>
			</table>
		</form>
	</body>
</HTML>
