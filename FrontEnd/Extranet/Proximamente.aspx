<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Proximamente" CodeFile="Proximamente.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Proximamente</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td width="100%" class="title" colspan="2">Proximamente<br/>
						<HR>
					</td>
				</tr>
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td width="100%" class="title" colspan="2">
                    <div style="float:left; width:400px;">
                        <asp:Label ID="lblMensaje" runat="server" Text="Label" CssClass="text"></asp:Label>
                        <div style="text-align:center; margin-top:20px;"><asp:Image ID="imgLogoServicio" runat="server" ImageUrl="/Img/modelo-de-cuestionario-de-satisfaccion-del-inquilino.jpg" Width="300" /></div>
                    </div>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
