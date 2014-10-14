<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada.PopUpCambioEstado" CodeFile="PopUpCambioEstado.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Cambio de Estado</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
		<base target="_self">
  </HEAD>
	<body leftmargin="0" topmargin="0">
		<form method="post" runat="server">
			<table cellpadding="0" cellspacing="0" border="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td width="349">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td colspan="3" height="10">&nbsp;</td>
							</tr>
							<TR>
								<TD class="text" width="60%">
								&nbsp;Estado:
								<TD class="text" align="right" width="20%" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="text" width="60%"><asp:DropDownList id="cmbEstados" runat="server" Width="280px"></asp:DropDownList></TD>
								<TD class="text" align="right" width="20%" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="text" width="60%">
								Observaciones:
								<TD class="text" align="right" width="20%" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="text" width="60%" colSpan="3"><asp:TextBox id="txtObservaciones" runat="server" Width="350" Height="88px" CssClass="Plano"
										TextMode="MultiLine"></asp:TextBox>
								</TD>
							</TR>
							<TR>
								<TD class="text" width="60%" colSpan="3">&nbsp;</TD>
							</TR>
							<tr>
								<TD class="text" align="right" colspan="3"><asp:Button id="btnCambioEstado" runat="server" Width="56px" Text="Aceptar"></asp:Button>&nbsp;&nbsp;
									<asp:button id="Cerrar" runat="server" Width="56px" Text="Cerrar"></asp:button>
								</TD>
							</tr>
						</TABLE>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
