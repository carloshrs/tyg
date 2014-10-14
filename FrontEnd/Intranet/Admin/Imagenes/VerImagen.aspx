<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Imagenes.VerImagen" CodeFile="VerImagen.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Visualización de Imágenes</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td align="right">
						<div id="panel">
							<asp:Label ID="lblTools" Runat="server"></asp:Label>
						</div>
					</td>
				</tr>
			</TABLE>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<td><IMG alt="" src="/img/logo-20-anios.png" width="264"></td>
					<TD class="title">
							<P align="center">
							<FONT color="#32528e">Visualizacion de Imágenes </FONT></P></TD>
				</TR>
				<tr>
					<td colspan="2" align="left" vAlign=top>
						<br>&nbsp;&nbsp;&nbsp;
						<asp:Image id="imgFoto" runat="server"></asp:Image>
					</td>
				</tr></TR>
			</TABLE>
			<BR></TD></TR></TABLE>
		</form>
	</body>
</HTML>
