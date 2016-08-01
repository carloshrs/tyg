<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Inc.Admin.Clientes.AbmUsuario" CodeFile="AbmUsuario.aspx.cs" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administración de Usuarios</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body topMargin="0" leftMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE height="404" cellSpacing="0" cellPadding="0" border="0" ms_2d_layout="TRUE">
				<TR vAlign="top">
					<TD height="15"></TD>
					<TD>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </TD>
				</TR>
				<TR vAlign="top">
					<TD height="389"></TD>
					<TD>
						<table cellSpacing="0" cellPadding="0" border="0" height="388">
							<tr>
								<td>&nbsp;&nbsp;&nbsp;</td>
								<td width="100%">
									<table cellSpacing="0" cellPadding="0" width="480" border="0">
										<TR>
											<TD class="title" width="60%" colSpan="2">
												Administración de&nbsp;Usuarios
												<hr>
											</TD>
										</TR>
										<TR>
											<TD class="title" bgColor="lightgrey" colSpan="4" height="10">&nbsp;&nbsp;Datos del 
												Usuario</TD>
										</TR>
										<TR>
											<TD class="text" width="60%" colSpan="4">Nombre de Inicio de Sesión&nbsp;
												<asp:requiredfieldvalidator id="reqRazonSocial" runat="server" ControlToValidate="txtLoginName" ErrorMessage="El nombre de inicio de sesión no puede estar vacio...">*</asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD class="text" width="100%" colSpan="4"><asp:textbox id="txtLoginName" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="text" colSpan="4" height="10"></TD>
										</TR>
										<asp:Panel id="panPassword" runat="server">
											<TR>
												<TD class="text" width="60%" colSpan="4">
													<asp:Label id="lblPassword" runat="server">Contraseña</asp:Label>&nbsp;
													<asp:requiredfieldvalidator id="reqPassword" runat="server" ErrorMessage="Debe Ingresar la Contraseña" ControlToValidate="txtPassword">*</asp:requiredfieldvalidator>&nbsp;
													<asp:CompareValidator id="compPassword" runat="server" ErrorMessage="Las Password no coinciden..." ControlToValidate="txtPassword"
														ControlToCompare="txtRePassword" Font-Bold="True">!</asp:CompareValidator></TD>
											</TR>
											<TR>
												<TD class="text" width="100%" colSpan="4"><INPUT class="plano" id="txtPassword" type="password" maxLength="128" size="100" name="txtPassword"
														runat="server">
												</TD>
											</TR>
											<TR>
												<TD class="text" width="60%" colSpan="4">
													<asp:Label id="lblRePassword" runat="server">Reingrese Contraseña</asp:Label>&nbsp;
													<asp:requiredfieldvalidator id="reqRePassword" runat="server" ErrorMessage="Debe Reingresar la Contraseña" ControlToValidate="txtRePassword">*</asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD class="text" width="100%" colSpan="4"><INPUT class="plano" id="txtRePassword" type="password" maxLength="128" size="100" runat="server"></TD>
											</TR>
										</asp:Panel>
										<TR>
											<TD class="text" width="141">Nombre</TD>
											<TD class="text" width="141" colSpan="3">
												Apellido</TD>
										</TR>
										<TR>
											<TD class="text" width="100%" height="20"><asp:textbox id="txtNombre" runat="server" Width="98%"></asp:textbox></TD>
											<TD class="text" width="100%" colSpan="3" height="20"><asp:textbox id="txtApellido" runat="server" Width="100%"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="text" colSpan="4" height="10"></TD>
										</TR>
										<TR>
											<TD class="text" width="141">Telefono</TD>
											<TD class="text" width="141" colSpan="3">
												Celular</TD>
										</TR>
										<TR>
											<TD class="text" width="100%"><asp:textbox id="txtTelefono" runat="server" Width="98%"></asp:textbox></TD>
											<TD class="text" width="100%" colSpan="3"><asp:textbox id="txtCelular" runat="server" Width="100%"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="text" colSpan="4" height="10"></TD>
										</TR>
										<TR>
											<TD class="text" width="60%" colSpan="4">Dirección de Correo Electrónico
												<asp:requiredfieldvalidator id="reqEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD class="text" width="100%" colSpan="4"><asp:textbox id="txtEmail" runat="server" Width="100%"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="text" colSpan="4" height="10"></TD>
										</TR>
										<TR>
											<TD class="title" bgColor="lightgrey" colSpan="4" height="10">&nbsp;&nbsp;Domicilio 
												Particular</TD>
										</TR>
										<TR>
											<td colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<TD class="text" width="70%">Calle</TD>
														<TD class="text" width="10%">Nro.</TD>
														<TD class="text" width="10%">Piso</TD>
														<TD class="text" width="10%">Dpto.</TD>
													</tr>
													<TR>
														<TD class="text" width="70%"><asp:textbox id="txtCalle" runat="server" Width="320px"></asp:textbox></TD>
														<TD class="text" width="10%"><asp:textbox id="txtNro" runat="server" Width="46px"></asp:textbox></TD>
														<TD class="text" width="10%"><asp:textbox id="txtPiso" runat="server" Width="47px"></asp:textbox></TD>
														<TD class="text" width="10%"><asp:textbox id="txtDpto" runat="server" Width="46px"></asp:textbox></TD>
													</TR>
												</table>
											</td>
										</TR>
										<TR>
											<TD class="text" colSpan="4" height="10"></TD>
										</TR>
										<TR>
											<td colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<TD class="text" width="50%">Barrio</TD>
														<TD class="text" width="10%">Código Postal</TD>
													</tr>
													<TR>
														<TD class="text" width="50%"><asp:textbox id="txtBarrio" runat="server" Width="320px"></asp:textbox></TD>
														<TD class="text" width="10%"><asp:textbox id="txtCodPos" runat="server" Width="144px"></asp:textbox></TD>
													</TR>
												</table>
											</td>
										</TR>
										<TR>
											<TD class="text" colSpan="4" height="10"></TD>
										</TR>
										<TR>
											<TD class="text" width="10%">Provincia</TD>
											<TD class="text" width="50%">&nbsp;Localidad</TD>
										</TR>
										<TR>
											<TD class="text" width="10%">
												<asp:DropDownList id="ddlProvincia" runat="server" AutoPostBack="True" onselectedindexchanged="ddlProvincia_SelectedIndexChanged">
													<asp:ListItem Value="1">Córdoba</asp:ListItem>
												</asp:DropDownList>&nbsp;</TD>
											<TD class="text" width="50%">
												&nbsp;<asp:DropDownList id="ddlLocalidad" runat="server">
													<asp:ListItem Value="1">Córdoba</asp:ListItem>
												</asp:DropDownList></TD>
										</TR>
										<TR>
											<TD class="text" colSpan="4" height="10"></TD>
										</TR>
										<TR>
											<TD class="title" bgColor="lightgrey" colSpan="4" height="10">&nbsp;&nbsp;Cambio de contraseña</TD>
										</TR>
										<TR>
											<td colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<TD class="text">Contraseña anterior</TD>
													</tr>
													<TR>
														<TD class="text" style="height: 24px"><asp:textbox id="pwdAnterior" runat="server" Width="320px" TextMode="Password"></asp:textbox></TD>
													</TR>
													<tr>
														<TD class="text">Nueva contraseña</TD>
													</tr>
													<TR>
														<TD class="text"><asp:textbox id="pwdNuevo" runat="server" TextMode="Password" Width="320px" ></asp:textbox>
                                                        </TD>
													</TR>
													<tr>
														<TD class="text">Reingrese nueva contraseña<asp:CompareValidator ID="CVPass" runat="server"
                                                                ErrorMessage="Las claves no coinciden" ControlToCompare="pwdNuevo" ControlToValidate="pwdNuevo2" SetFocusOnError="True">*</asp:CompareValidator></TD>
													</tr>
													<TR>
														<TD class="text" style="height: 24px"><asp:textbox id="pwdNuevo2" runat="server" Width="320px" TextMode="Password"></asp:textbox></TD>
													</TR>
												</table>
											</td>
										</TR>
										<TR>
											<TD class="text" colSpan="4" height="10">
                                                <asp:ValidationSummary ID="VSCambioUsuario" runat="server" CssClass="text" Height="26px"
                                                    ShowMessageBox="True" Width="414px" />
                                            </TD>
										</TR>
										<TR>
											<td colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="text" align="right" width="100%">
															<asp:button id="btnAceptar" runat="server" Width="56px" Text="Aceptar" ToolTip="Aceptar los Cambios" onclick="btnAceptar_Click"></asp:button>&nbsp;&nbsp;
															<asp:button id="btnCancelar" runat="server" Width="56px" Text="Cancelar" ToolTip="Cancelar los Cambios"
																CausesValidation="False" onclick="btnCancelar_Click"></asp:button>&nbsp;&nbsp;
															</TD>
													</TR>
												</table>
											</td>
										</TR>
									</table>
								</td>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
