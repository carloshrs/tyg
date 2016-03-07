<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas.ABMCaja" CodeFile="ABMCaja.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administración de Funciones</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<form id="frmABMFuncion" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" border="0">
				<TBODY>
					<tr>
						<td width="30">&nbsp;&nbsp;&nbsp;&nbsp;</td>
						<td width="100%">
							<table cellSpacing="4" cellPadding="0" width="480" border="0">
								<TBODY>
									<TR>
										<TD class="title" width="100%" colspan="4">
											Apertura / Cierre de Caja
											<hr>
										</TD>
									</TR>
									<TR>
										<TD class="title" bgColor="lightgrey" height="10" colspan="4">&nbsp;&nbsp;Montos de apertura</TD>
									</TR>
									<TR>
										<TD class="text" width="25%">
											Efectivo inicial&nbsp;
											<asp:requiredfieldvalidator id="reqEfectivoInicial" runat="server" ControlToValidate="txtEfectivoInicial" ErrorMessage="*" Font-Size="12px"></asp:requiredfieldvalidator></TD>
										<TD class="text" width="25%"><asp:textbox id="txtEfectivoInicial" runat="server" Width="100%"></asp:textbox></TD>
                                        <TD class="text" width="25%">
											Cheque inicial&nbsp;
											<asp:requiredfieldvalidator id="reqChequeInicial" runat="server" ControlToValidate="txtChequeInicial" ErrorMessage="*" Font-Size="12px"></asp:requiredfieldvalidator></TD>
										<TD class="text" width="25%"><asp:textbox id="txtChequeInicial" runat="server" Width="100%"></asp:textbox></TD>
									</TR>
                                    <TR>
										<TD class="title" bgColor="lightgrey" height="10" colspan="4">&nbsp;&nbsp;Montos de cierre</TD>
									</TR>
									<TR>
										<TD class="text" width="25%">
											Efectivo cierre&nbsp;</TD>
										<TD class="text" width="25%"><asp:textbox id="txtSaldoEfectivo" runat="server" Width="100%"></asp:textbox></TD>
                                        <TD class="text" width="25%">
											Cheque cierre&nbsp;</TD>
										<TD class="text" width="25%"><asp:textbox id="txtSaldoCheque" runat="server" Width="100%"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="text" height="10" colspan="4"></TD>
									</TR>
									
									<TR>
										<td colspan="4">
											<table cellSpacing="2" cellPadding="5" width="100%" border="0">
												<TR>
													<TD class="text" align="right" width="100%">
														<asp:button id="btnCerrar" runat="server" Text="Cerrar caja" onclick="btnCerrar_Click"></asp:button>&nbsp;&nbsp;
                                                        <asp:button id="btnAceptar" runat="server" Text="Abrir caja" onclick="btnAceptar_Click"></asp:button>&nbsp;&nbsp;
														<asp:button id="btnCancelar" runat="server"  Text="Cancelar" CausesValidation="False" onclick="btnCancelar_Click"></asp:button>
													</TD>
												</TR>
											</table>
										</td>
									</TR>
								</TBODY>
							</table>
						</td>
					</tr>
				</TBODY>
			</table>
		</form>
	</body>
</HTML>
