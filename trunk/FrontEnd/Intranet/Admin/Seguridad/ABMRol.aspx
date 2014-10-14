<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Seguridad.Admin.Seguridad.ABMRol" CodeFile="ABMRol.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administración de Roles</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<form id="frmABMRol" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" border="0">
				<TBODY>
					<tr>
						<td width="30">&nbsp;&nbsp;&nbsp;&nbsp;</td>
						<td width="100%">
							<table cellSpacing="0" cellPadding="0" width="480" border="0">
								<TBODY>
									<TR>
										<TD class="title" width="60%">Administración de&nbsp;Roles
											<hr>
										</TD>
									</TR>
									<TR>
										<TD class="title" bgColor="lightgrey" height="10">&nbsp;&nbsp;Datos del Rol</TD>
									</TR>
									<TR>
										<TD class="text" width="60%">Nombre&nbsp;
											<asp:requiredfieldvalidator id="reqNombre" runat="server" Font-Size="12px" ErrorMessage="*" ControlToValidate="txtNombre"></asp:requiredfieldvalidator></TD>
									</TR>
									<TR>
										<TD class="text" width="100%"><asp:textbox id="txtNombre" runat="server" Width="100%"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="text" height="10"></TD>
									</TR>
									<TR>
										<TD class="text" width="60%">Descripción&nbsp;</TD>
									</TR>
									<TR>
										<TD class="text" width="100%"><asp:textbox id="txtDescripcion" runat="server" Width="100%" Rows="3" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="text" height="10"></TD>
									</TR>
									<TR>
										<TD width="100%"><asp:checkbox id="chkAutomatico" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
												runat="server" text="Asignación Automática" value="Auto"></asp:checkbox><br>
											<asp:checkbox id="chkExtranet" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
												runat="server" text="Solo para usuarios de Extranet" value="Extra"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD class="text" height="10"></TD>
									</TR>
									<TR>
										<td>
											<table cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD class="text" align="right" width="100%"><asp:button id="btnAceptar" runat="server" Width="48px" ToolTip="Aceptar los Cambios" Text="Aceptar" onclick="btnAceptar_Click"></asp:button>&nbsp;&nbsp;
														<asp:button id="btnCancelar" runat="server" Width="56px" ToolTip="Cancelar los Cambios" Text="Cancelar"
															CausesValidation="False" onclick="btnCancelar_Click"></asp:button>&nbsp;&nbsp;&nbsp;
														<asp:Button id="btnFunciones" runat="server" Width="103px" Text="Asignar Funciones" onclick="btnAceptar_Click"></asp:Button></TD>
												</TR>
											</table>
										</td>
									</TR>
								</TBODY></table>
						</td>
					</tr>
				</TBODY></table>
		</form>
	</body>
</HTML>
