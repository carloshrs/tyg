<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Contratos.AbmPersonas" CodeFile="AbmPersonas.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="menu" Src="../../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Alta Personas</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
		<script src="/Includes/Funciones.js" type="text/javascript"></script>
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<uc1:menu id="Menu1" runat="server"></uc1:menu>
		<FORM id="Tipos" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%">Edición&nbsp;de Personas<BR>
						<HR>
						<BR>
					</td>
				</tr>
				<tr>
					<TD width="2%">&nbsp;</TD>
					<TD class="text" align="right" width="93%" colSpan="4">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<TD class="text" width="100%">&nbsp;</TD>
							</tr>
							<tr>
								<TD width="100%">
									<table cellSpacing="0" cellPadding="0" width="528" border="0">
										<TR>
											<TD class="text" width="100%"><asp:panel id="pnlPersona" runat="server">
													<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="title" width="535" bgColor="lightgrey" colSpan="4" height="10">&nbsp;&nbsp;Datos 
																Personales</TD>
														</TR>
														<TR>
															<TD class="text" width="535" colSpan="4">Apellido
																<asp:requiredfieldvalidator id="reqApellido" runat="server" ErrorMessage="Ingrese Apellido" ControlToValidate="Apellido">*</asp:requiredfieldvalidator></TD>
														</TR>
														<TR>
															<TD class="text" width="535" colSpan="4"><asp:textbox id="Apellido" onKeyPress="return validarString(event);" runat="server" Width="100%" MaxLength="255"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="text" width="535" colSpan="4">Nombre
																<asp:requiredfieldvalidator id="reqNombre" runat="server" ErrorMessage="Ingrese Nombre" ControlToValidate="Nombre">*</asp:requiredfieldvalidator></TD>
														</TR>
														<TR>
															<TD class="text" width="535" colSpan="4"><asp:textbox id="Nombre" onKeyPress="return validarString(event);" runat="server" Width="100%" MaxLength="255"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="text" width="161">Estado Civil</TD>
															<TD class="text" width="240"><IMG height="1" src="/img/shim.gif" width="20">Tipo 
																Documento</TD>
															<TD class="text" width="235" colSpan="2"><IMG height="1" src="/img/shim.gif" width="30">Documento&nbsp;
																<asp:requiredfieldvalidator id="reqDNI" runat="server" ErrorMessage="Ingrese Documento" ControlToValidate="Documento">*</asp:requiredfieldvalidator></TD>
														</TR>
														<TR>
															<TD class="text" width="161"><asp:dropdownlist id="cmbEstadoCivil" runat="server" Width="161px">
																	<asp:ListItem Value="1">Soltero/a</asp:ListItem>
																	<asp:ListItem Value="2">Casado/a</asp:ListItem>
																	<asp:ListItem Value="3">Divorciado/a</asp:ListItem>
																	<asp:ListItem Value="4">Viudo/a</asp:ListItem>
																</asp:dropdownlist></TD>
															<TD class="text" width="240"><IMG height="1" src="/img/shim.gif" width="20"><asp:dropdownlist id="cmbTipoDocumento" runat="server" Width="167px">
																	<asp:ListItem Value="1" Selected="True">DNI</asp:ListItem>
																	<asp:ListItem Value="2">Libreta C&#237;vica</asp:ListItem>
																	<asp:ListItem Value="3">Libreta de enrolamiento</asp:ListItem>
																</asp:dropdownlist></TD>
															<TD class="text" align="left" width="235" colSpan="2">&nbsp;&nbsp; <IMG height="1" src="/img/shim.gif" width="20"><asp:textbox id="Documento" onKeyPress="return validarString(event);" runat="server" Width="150px" MaxLength="45"></asp:textbox></TD>
														</TR>
													</TABLE></asp:panel></TD>
										</TR>
										<TR>
											<TD class="text" width="620" colSpan="5" height="20">
												<HR>
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD width="536" colSpan="4">
															<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp; 
																		Domicilio</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD width="536" colSpan="4">
															<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="text" width="70%">Calle&nbsp;</TD>
																	<TD class="text" width="10%">Nro.</TD>
																	<TD class="text" width="10%">Dpto.</TD>
																	<TD class="text" width="10%">Piso</TD>
																</TR>
																<TR>
																	<TD class="text" width="70%"><asp:textbox id="Calle"  onKeyPress="return validarString(event);" runat="server" Width="320px" MaxLength="255"></asp:textbox></TD>
																	<TD class="text" width="10%"><asp:textbox id="Nro" onKeyPress="return validarString(event);" runat="server" Width="46px" MaxLength="20"></asp:textbox></TD>
																	<TD class="text" width="10%"><asp:textbox id="Dpto" onKeyPress="return validarString(event);" runat="server" Width="46px" MaxLength="20"></asp:textbox></TD>
																	<TD class="text" width="10%"><asp:textbox id="Piso" onKeyPress="return validarString(event);" runat="server" Width="47px" MaxLength="20"></asp:textbox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD width="536" colSpan="4">
															<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="text" width="70%">Barrio&nbsp;</TD>
																	<TD class="text" width="30%">Código Postal&nbsp;</TD>
																</TR>
																<TR>
																	<TD class="text" width="70%"><asp:textbox onKeyPress="return validarString(event);" id="barrio" runat="server" Width="320px" MaxLength="255"></asp:textbox></TD>
																	<TD class="text" width="30%"><asp:textbox onKeyPress="return validarString(event);" id="CP" runat="server" Width="153px" MaxLength="45"></asp:textbox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD width="536" colSpan="4">
															<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="text" width="50%">Provincia&nbsp;
																	</TD>
																	<TD class="text" width="50%"><IMG height="1" src="/img/shim.gif" width="15">Localidad&nbsp;
																	</TD>
																</TR>
																<TR>
																	<TD class="text" width="50%"><asp:dropdownlist id="cmbProvincia" runat="server" AutoPostBack="True" Width="250px" onselectedindexchanged="cmbProvincia_SelectedIndexChanged_1"></asp:dropdownlist></TD>
																	<TD class="text" align="right" width="50%"><asp:dropdownlist id="cmbLocalidad" runat="server" Width="250px"></asp:dropdownlist>&nbsp;</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="text" width="535" colSpan="4" height="10"></TD>
													</TR>
												</TABLE>
												</TD>
										</TR>
										<TR>
											<td width="536" colSpan="4">
												<HR>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="text" width="60%">&nbsp;</TD>
														<TD class="text" align="right" width="20%"><asp:button id="Aceptar" style="CURSOR:hand" runat="server" Width="80px" Text="Aceptar" onclick="Aceptar_Click"></asp:button></TD>
														<TD class="text" align="right" width="20%"><input id="Cancelar" style="CURSOR:hand" onclick="javascript:window.location.href='ListaPersonas.aspx';"
																type="button" size="20" value="  Cancelar  "></TD>
													</TR>
												</table>
												<asp:ValidationSummary id="ValidationSummary1" runat="server" CssClass="text"></asp:ValidationSummary>
											</td>
										</TR>
									</table>
								</TD>
							</tr>
						</TABLE>
					</TD>
					<TD width="5%">&nbsp;</TD>
				</tr>
			</TABLE>
		</FORM>
	</body>
</HTML>
