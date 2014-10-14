<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Contratos.AbmPersonas" CodeFile="AbmPersonas.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Alta Personas</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="title" width="100%">Edición&nbsp;de Contrato<BR>
						<HR>
						<BR>
					</td>
				</tr>
				<TR>
					<TD class="text" width="535" colSpan="4">Actúa en caracter de...</TD>
				</TR>
				<TR>
					<TD class="text" width="100%" colSpan="4"><asp:dropdownlist id="cmbTipoPersona" runat="server" AutoPostBack="True" Width="528px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD class="text" width="535" colSpan="4" height="10"></TD>
				</TR>
				<TR>
					<TD class="text" width="535" colSpan="4">
						<TABLE cellSpacing="0" cellPadding="0" width="535" border="0">
							<TR>
								<TD class="text" width="100%" colSpan="4">Tipo Persona:</TD>
							</TR>
							<TR>
								<TD class="text" width="100%" colSpan="3">
									<asp:DropDownList id="cmbTipo" runat="server" AutoPostBack="True" Width="528" onselectedindexchanged="cmbTipo_SelectedIndexChanged">
										<asp:ListItem Value="1">Persona F&#237;sica</asp:ListItem>
										<asp:ListItem Value="2">Persona Jur&#237;dica</asp:ListItem>
									</asp:DropDownList></TD>
							</TR>
							<TR>
								<TD class="text" width="535" colSpan="4" height="10"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td width="100%">
						<table cellSpacing="0" cellPadding="0" width="528" border="0">
							<TR>
								<TD class="text" width="100%">
									<asp:panel id="pnlPersona" runat="server">
										<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="title" width="535" bgColor="lightgrey" colSpan="4" height="10">&nbsp;&nbsp;Datos 
													Personales</TD>
											</TR>
											<TR>
												<TD class="text" width="535" colSpan="4">Apellido
													<asp:requiredfieldvalidator id="reqApellido" runat="server" ErrorMessage="*" ControlToValidate="Apellido"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD class="text" width="535" colSpan="4"><asp:textbox id="Apellido" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="text" width="535" colSpan="4">Nombre
													<asp:requiredfieldvalidator id="reqNombre" runat="server" ErrorMessage="*" ControlToValidate="Nombre"></asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD class="text" width="535" colSpan="4"><asp:textbox id="Nombre" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="text" width="161">Estado Civil</TD>
												<TD class="text" width="240"><IMG height="1" src="/img/shim.gif" width="20">Tipo 
													Documento</TD>
												<TD class="text" width="235" colSpan="2"><IMG height="1" src="/img/shim.gif" width="30">Documento&nbsp;
													<asp:requiredfieldvalidator id="reqDNI" runat="server" ErrorMessage="*" ControlToValidate="Documento"></asp:requiredfieldvalidator></TD>
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
												<TD class="text" align="left" width="235" colSpan="2">&nbsp;&nbsp; <IMG height="1" src="/img/shim.gif" width="20"><asp:textbox id="Documento" runat="server" Width="150px"></asp:textbox></TD>
											</TR>
										</TABLE></TD>
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
															Domicilio (Opcional)</TD>
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
														<TD class="text" width="70%"><asp:textbox id="Calle" runat="server" Width="320px"></asp:textbox></TD>
														<TD class="text" width="10%"><asp:textbox id="Nro" runat="server" Width="46px"></asp:textbox></TD>
														<TD class="text" width="10%"><asp:textbox id="Dpto" runat="server" Width="46px"></asp:textbox></TD>
														<TD class="text" width="10%"><asp:textbox id="Piso" runat="server" Width="47px"></asp:textbox></TD>
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
														<TD class="text" width="70%"><asp:textbox id="barrio" runat="server" Width="320px"></asp:textbox></TD>
														<TD class="text" width="30%"><asp:textbox id="CP" runat="server" Width="153px"></asp:textbox></TD>
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
									</asp:panel>
									<asp:panel id="pnlJuridico" runat="server">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD width="536" colSpan="4">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;
																<asp:Label class="title" id="lblInforme" runat="server">Persona Jurídica</asp:Label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="text" width="100%">Razón Social&nbsp;
													<asp:RequiredFieldValidator id="RequiredFieldValidator8" runat="server" ControlToValidate="RazonSocial" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
											</TR>
											<TR>
												<TD class="text" width="100%">
													<asp:TextBox id="RazonSocial" runat="server" Width="100%"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD colSpan="4">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="text" width="50%">Nombre de Fantasía</TD>
															<TD class="text" width="10%">Teléfono</TD>
														</TR>
														<TR>
															<TD class="text" width="50%">
																<asp:TextBox id="NombreFantasia" runat="server" Width="320px"></asp:TextBox></TD>
															<TD class="text" width="10%">
																<asp:TextBox id="Telefono" runat="server" Width="160px"></asp:TextBox></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD colSpan="4">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="text" width="50%">Rubro</TD>
															<TD class="text" width="10%">Cuit&nbsp;
																<asp:RequiredFieldValidator id="RequiredFieldValidator9" runat="server" ControlToValidate="Cuit" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
														</TR>
														<TR>
															<TD class="text" width="50%">
																<asp:TextBox id="Rubro" runat="server" Width="320px"></asp:TextBox></TD>
															<TD class="text" width="10%">
																<asp:TextBox id="Cuit" runat="server" Width="160px"></asp:TextBox></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD colSpan="4">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="text" width="70%">Calle&nbsp;
																<asp:RequiredFieldValidator id="RequiredFieldValidator10" runat="server" ControlToValidate="CalleEmpresa" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
															<TD class="text" width="10%">Nro.&nbsp;
																<asp:RequiredFieldValidator id="RequiredFieldValidator11" runat="server" ControlToValidate="NroEmpresa" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
															<TD class="text" width="10%">Dpto.</TD>
															<TD class="text" width="10%">Piso</TD>
														</TR>
														<TR>
															<TD class="text" width="70%">
																<asp:TextBox id="CalleEmpresa" runat="server" Width="320px"></asp:TextBox></TD>
															<TD class="text" width="10%">
																<asp:TextBox id="NroEmpresa" runat="server" Width="50px"></asp:TextBox></TD>
															<TD class="text" width="10%">
																<asp:TextBox id="DptoEmpresa" runat="server" Width="50px"></asp:TextBox></TD>
															<TD class="text" width="10%">
																<asp:TextBox id="PisoEmpresa" runat="server" Width="50px"></asp:TextBox></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD colSpan="4">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="text" width="50%">Barrio&nbsp;
																<asp:RequiredFieldValidator id="RequiredFieldValidator12" runat="server" ControlToValidate="BarrioEmpresa" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
															<TD class="text" width="10%">Código Postal&nbsp;
																<asp:RequiredFieldValidator id="RequiredFieldValidator15" runat="server" ControlToValidate="CPEmpresa" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
														</TR>
														<TR>
															<TD class="text" width="50%">
																<asp:TextBox id="BarrioEmpresa" runat="server" Width="320px"></asp:TextBox></TD>
															<TD class="text" width="10%">
																<asp:TextBox id="CPEmpresa" runat="server" Width="160px"></asp:TextBox></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD colSpan="4">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="text" width="50%" height="14">Provincia
															</TD>
															<TD class="text" width="10%" height="14">Localidad&nbsp;
															</TD>
														</TR>
														<TR>
															<TD class="text" width="10%">
																<asp:dropdownlist id="cmbProvinciaEmpresas" runat="server" Width="265px" AutoPostBack="True" onselectedindexchanged="cmbProvinciaEmpresas_SelectedIndexChanged"></asp:dropdownlist></TD>
															<TD class="text" width="50%">
																<asp:dropdownlist id="cmbLocalidadEmpresas" runat="server" Width="265px"></asp:dropdownlist></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="text" colSpan="4">&nbsp;&nbsp;</TD>
											</TR>
										</TABLE>
									</asp:panel>
								</TD>
							</TR>
							<TR>
								<td width="536" colSpan="4">
									<HR>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="text" width="60%">&nbsp;</TD>
											<TD class="text" align="right" width="20%"><asp:button id="Aceptar" runat="server" Width="80px" Text="Aceptar" onclick="Aceptar_Click"></asp:button></TD>
											<TD class="text" align="right" width="20%"><input id="Cancelar" onclick="javascript:history.back();" type="button" size="20" value="  Cancelar  "></TD>
										</TR>
									</table>
								</td>
							</TR>
						</table>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
