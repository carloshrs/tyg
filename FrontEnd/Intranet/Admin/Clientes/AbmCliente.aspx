<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Clientes.AbmCliente" CodeFile="AbmCliente.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Alta de Cliente</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
			<script src="/Includes/Funciones.js" type="text/javascript"></script>
	</HEAD>
	<body lefmargin="0" topmargin="0">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<TABLE cellSpacing="0" cellPadding="0" width="421" border="0">
			<TR vAlign="top">
				<TD width="421">
					<form id="Form1" method="post" runat="server">
						<TABLE cellSpacing="0" cellPadding="0" border="0">
							<TR vAlign="top">
								<TD width="10" height="15"></TD>
								<TD ></TD>
							</TR>
							<TR vAlign="top">
								<TD height="389"></TD>
								<TD>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0" height="388">
										<tr>
											<td width="30">&nbsp;&nbsp;&nbsp;&nbsp;</td>
											<td width="100%">
												<table cellSpacing="0" cellPadding="0" width="480" border="0">
													<TR>
														<TD class="title" width="60%" colSpan="4">Administración de Clientes
															<hr>
															<br>															
														</TD>
													</TR>
													<TR>
														<TD class="title" bgColor="lightgrey" colSpan="4" height="10">&nbsp;&nbsp;Datos del 
															Cliente</TD>
													</TR>
                                                    <TR>
														<TD class="text" width="60%" colSpan="4">Razón Social en Fox: <asp:Label ID="lblRazonSocialFox" runat="server" Text="" Font-Bold="true"></asp:Label></TD>
													</TR>
													<TR>
														<TD class="text" width="60%" colSpan="4">Razón Social
															<asp:requiredfieldvalidator id="reqRazonSocial" runat="server" ControlToValidate="txtRazonSocial" ErrorMessage="Ingrese Raz&amp;oacute;n Social">*</asp:requiredfieldvalidator></TD>
													</TR>
													<TR>
														<TD class="text" width="100%" colSpan="4"><asp:textbox id="txtRazonSocial" onKeyPress="return validarString(event);" runat="server" Width="100%"
																MaxLength="255" style="text-transform: uppercase;"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="text" width="60%" colSpan="4">Nombre de fantasia</TD>
													</TR>
													<TR>
														<TD class="text" width="100%" colSpan="4"><asp:textbox id="txtNombreFantasia" onKeyPress="return validarString(event);" runat="server" Width="100%"
																MaxLength="255" style="text-transform: uppercase;"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="text" width="60%" colSpan="4">Sucursal</TD>
													</TR>
													<TR>
														<TD class="text" width="100%" colSpan="4"><asp:textbox id="txtSucursal" onKeyPress="return validarString(event);" runat="server" Width="100%"
																MaxLength="255" style="text-transform: uppercase;"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="text" colSpan="4" height="10"></TD>
													</TR>
													<TR>
														<TD class="text" width="141">CUIT</TD>
														<TD class="text" width="141" colSpan="3">Ingresos Brutos</TD>
													</TR>
													<TR>
														<TD class="text" width="100%"><asp:textbox id="txtCUIT" onKeyPress="return validarString(event);" runat="server" Width="98%"
																MaxLength="13"></asp:textbox></TD>
														<TD class="text" width="100%" colSpan="3"><asp:textbox id="txtIngBrutos" onKeyPress="return validarString(event);" runat="server" Width="100%"
																MaxLength="15"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="text" colSpan="4" height="10"></TD>
													</TR>
													<TR>
														<TD class="text" width="141">Teléfono</TD>
														<TD class="text" width="141" colSpan="3">Fax</TD>
													</TR>
													<TR>
														<TD class="text" width="100%"><asp:textbox id="txtTelefono" onKeyPress="return validarString(event);" runat="server" Width="98%"
																MaxLength="32"></asp:textbox></TD>
														<TD class="text" width="100%" colSpan="3"><asp:textbox id="txtFax" onKeyPress="return validarString(event);" runat="server" Width="100%"
																MaxLength="32"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="text" colSpan="4" height="10"></TD>
													</TR>
													<TR>
														<TD class="text" width="60%" colSpan="4">Dirección de Correo Electrónico
															<asp:requiredfieldvalidator id="reqEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Ingrese Direcci&amp;oacute;n de Correo Electr&amp;oacute;nico">*</asp:requiredfieldvalidator></TD>
													</TR>
													<TR>
														<TD class="text" width="100%" colSpan="4"><asp:textbox id="txtEmail" onKeyPress="return validarString(event);" runat="server" Width="100%"
																MaxLength="255"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="text" width="50%" >Encargado</TD>
														<TD class="text" width="60%" colSpan="3">Cargo</TD>
													</TR>
													<TR>
														<TD class="text" width="50%" ><asp:textbox id="txtEncargado" runat="server" Width="98%"
																MaxLength="255"></asp:textbox></TD>
                                                        <TD class="text" width="100%" colSpan="3"><asp:textbox id="txtCargo" runat="server" Width="100%"
																MaxLength="255"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="text" width="60%" colSpan="4">Observaciones</TD>
													</TR>
													<TR>
														<TD class="text" width="100%" colSpan="4"><asp:textbox id="txtObservaciones" Rows="4" runat="server" Width="100%" MaxLength="255"  TextMode="MultiLine"></asp:textbox></TD>
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
																	<TD class="text" width="70%"><asp:textbox id="txtCalle" onKeyPress="return validarString(event);" runat="server" Width="320px"
																			MaxLength="255"></asp:textbox></TD>
																	<TD class="text" width="10%"><asp:textbox id="txtNro" onKeyPress="return validarString(event);" runat="server" Width="46px"
																			MaxLength="10"></asp:textbox></TD>
																	<TD class="text" width="10%"><asp:textbox id="txtPiso" onKeyPress="return validarString(event);" runat="server" Width="47px"
																			MaxLength="4"></asp:textbox></TD>
																	<TD class="text" width="10%"><asp:textbox id="txtDpto" onKeyPress="return validarString(event);" runat="server" Width="46px"
																			MaxLength="4"></asp:textbox></TD>
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
																	<TD class="text" width="50%"><asp:textbox id="txtBarrio" onKeyPress="return validarString(event);" runat="server" Width="320px"
																			MaxLength="128"></asp:textbox></TD>
																	<TD class="text" width="10%"><asp:textbox id="txtCodPos" onKeyPress="return validarString(event);" runat="server" Width="144px"
																			MaxLength="8"></asp:textbox></TD>
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
														<TD class="text" width="10%" height="20">
															<asp:DropDownList id="ddlProvincia" runat="server" AutoPostBack="True" onselectedindexchanged="ddlProvincia_SelectedIndexChanged">
																<asp:ListItem Value="1">Córdoba</asp:ListItem>
															</asp:DropDownList>&nbsp;</TD>
														<TD class="text" width="50%" height="20">
															&nbsp;<asp:DropDownList id="ddlLocalidad" runat="server">
																<asp:ListItem Value="1">Córdoba</asp:ListItem>
															</asp:DropDownList></TD>
													</TR>
													<TR>
														<TD class="text" colSpan="4" height="10"></TD>
													</TR>
													<TR>
														<td colSpan="4">
															<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="text" align="right" width="100%">
																		<asp:button id="btnAceptar" runat="server" style="CURSOR:hand" Width="48px" 
                                                                            Text="Aceptar" ToolTip="Aceptar los Cambios" onclick="btnAceptar_Click"></asp:button>&nbsp;&nbsp;
																		<asp:button id="btnCancelar" runat="server" style="CURSOR:hand" Width="56px" Text="Cancelar"
																			ToolTip="Cancelar los Cambios" CausesValidation="False" onclick="btnCancelar_Click"></asp:button>&nbsp;&nbsp;
																		<asp:button id="btnUsuarios" runat="server" style="CURSOR:hand" Width="110px" Text="Administrar Usuarios"
																			ToolTip="Administrar Usuarios del Cliente" onclick="btnUsuarios_Click"></asp:button></TD>
																</TR>
															</table>
															<asp:ValidationSummary id="ValidationSummary1" runat="server" CssClass="text"></asp:ValidationSummary>
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
				</TD>
			</TR>
		</TABLE>
	</body>
</HTML>
