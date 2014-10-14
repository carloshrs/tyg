<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Contratos.abmHistorico" CodeFile="abmHistorico.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Alta de Informe</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="100%">
						<table cellSpacing="0" cellPadding="0" width="480" border="0">
							<TR>
								<TD class="title" width="535" bgColor="lightgrey" colSpan="4" height="10">&nbsp;&nbsp;Datos 
									Histórico</TD>
							</TR>
							<TR>
								<TD class="text" width="535" colSpan="4"><img src="/img/shim.gif" width="1" height="8"></TD>
							</TR>
							<TR>
								<TD class="text" width="5"><img src="/img/shim.gif" width="5" height="1"></TD>
								<TD class="text" width="535" colSpan="3">Fecha:&nbsp;&nbsp;
									<asp:Label id="lblFecha" runat="server" Font-Bold="True">Label</asp:Label></TD>
							</TR>
							<TR>
								<TD class="text" width="535" colSpan="4"><img src="/img/shim.gif" width="1" height="8"></TD>
							</TR>
							<TR>
								<TD class="text" width="5"><img src="/img/shim.gif" width="5" height="1"></TD>
								<td class="text" width="535" colSpan="3">Descripción
									<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="Observaciones"></asp:RequiredFieldValidator></td>
							</TR>
							<TR>
								<TD class="text" width="5"><img src="/img/shim.gif" width="5" height="1"></TD>
								<td class="text" width="535" colSpan="3"><asp:textbox id="Observaciones" runat="server" Width="480px" CssClass="Plano" Height="79px" Rows="5"
										MaxLength="255" TextMode="MultiLine"></asp:textbox></td>
							</TR>
							<TR>
								<td width="535" colSpan="4">
									<hr>
								</td>
							</TR>
							<TR>
								<td width="536" colSpan="4">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="text" width="60%">&nbsp;</TD>
											<TD class="text" align="right" width="20%">
												<asp:button id="Aceptar" runat="server" Width="80px" Text="Aceptar" onclick="Aceptar_Click"></asp:button></TD>
											<TD class="text" align="right" width="20%"><input id="Cancelar" onclick="javascript:window.close();" type="button" value="  Cancelar  "></TD>
										</TR>
									</table>
								</td>
							</TR>
						</table>
					</td>
				</tr>
			</TABLE>
		</form>
		<DIV id="divDateControl" style="Z-INDEX: 102; LEFT: -35px; VISIBILITY: hidden; POSITION: absolute; TOP: -150px"><IFRAME name="popFrame" src="../inc/calendar/calendar.htm" frameBorder="0" width="160" scrolling="no"
				height="160"></IFRAME></DIV>
	</body>
</HTML>
