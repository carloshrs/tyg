<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Seguridad.Admin.Seguridad.ABMFuncion" CodeFile="ABMFuncion.aspx.cs" %>
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
							<table cellSpacing="0" cellPadding="0" width="480" border="0">
								<TBODY>
									<TR>
										<TD class="title" width="60%">
											Administración de&nbsp;Funciones
											<hr>
										</TD>
									</TR>
									<TR>
										<TD class="title" bgColor="lightgrey" height="10">&nbsp;&nbsp;Datos de la Función</TD>
									</TR>
									<TR>
										<TD class="text" width="60%">
											Nombre&nbsp;
											<asp:requiredfieldvalidator id="reqNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="*" Font-Size="12px"></asp:requiredfieldvalidator></TD>
									</TR>
									<TR>
										<TD class="text" width="100%"><asp:textbox id="txtNombre" runat="server" Width="100%"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="text" height="10"></TD>
									</TR>
									<TR>
										<TD class="text" width="60%">
											Clave URL&nbsp;
											<asp:requiredfieldvalidator id="reqUrl" runat="server" Font-Size="12px" ErrorMessage="*" ControlToValidate="txtNombre"></asp:requiredfieldvalidator></TD>
									</TR>
									<TR>
										<TD class="text" width="100%"><asp:textbox id="txtUrl" runat="server" Width="100%" Rows="3"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="text" height="10"></TD>
									</TR>
									<TR>
										<TD class="text" height="10"></TD>
									</TR>
									<TR>
										<td>
											<table cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD class="text" align="right" width="100%">
														<asp:button id="btnAceptar" runat="server" Width="48px" Text="Aceptar" ToolTip="Aceptar los Cambios" onclick="btnAceptar_Click"></asp:button>&nbsp;&nbsp;
														<asp:button id="btnCancelar" runat="server" Width="56px" Text="Cancelar" ToolTip="Cancelar los Cambios"
															CausesValidation="False" onclick="btnCancelar_Click"></asp:button>
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
