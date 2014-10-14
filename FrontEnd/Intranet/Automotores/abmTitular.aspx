<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Automotores.abmTitular" smartNavigation="False" CodeFile="abmTitular.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Titular del inmueble</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
		<base target="_self">
		<script src="../Includes/entertab.js" type="text/javascript"></script>
		<script>
		function validaTotalPorcentaje(source, args)
		{
//			try
			{
	   			if(isNaN(args.Value))
			    {
				  args.IsValid = false;
//   				  popMensaje.fPopMensaje(source,"Valor inválido",divMensaje);
   				}
				else if(100 >= ((parseFloat(Form1.totalPorcentaje.value)-parseFloat(Form1.itemPorcentaje.value))+parseFloat(args.Value)))
				{
				  args.IsValid = true;
				}
			    else
			    {
				  args.IsValid = false;
				  alert("La suma de los porcentajes no debe superar el 100%");
  // 				  popMensaje.fPopMensaje(source,"Valor inválido",divMensaje);
   				}

			}
//			catch(er)
			{
			//	args.IsValid = false;
	//			popMensaje.fPopMensaje(source,"Valor inválido",divMensaje);
			}
		}
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD width="100%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="480" border="0">
							<TR>
								<TD class="text" width="100%">
									<asp:panel id="pnlTipoPersona" runat="server">
										<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="text" width="535" colSpan="4">Tipo Persona:</TD>
											</TR>
											<TR>
												<TD class="text" width="100%" colSpan="3">
													<asp:DropDownList id="cmbTipoPersona" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="cmbTipoPersona_SelectedIndexChanged">
														<asp:ListItem Value="1">Persona F&#237;sica</asp:ListItem>
														<asp:ListItem Value="2">Persona Jur&#237;dica</asp:ListItem>
													</asp:DropDownList></TD>
											</TR>
											<TR>
												<TD class="text" width="535" colSpan="4" height="10"></TD>
											</TR>
										</TABLE>
									</asp:panel><BR>
									<asp:Panel id="pnlFisica" runat="server">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="text" width="50%">
													<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="536" colSpan="4">
																<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&#160;&#160; Titular persona fisica del automotor</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="text" width="50%" colSpan="2">Nombre&nbsp;
																<asp:requiredfieldvalidator id="RequiredFieldValidator16" runat="server" ErrorMessage="Ingrese el nombre" ControlToValidate="txtNombre">*</asp:requiredfieldvalidator></TD>
															<TD class="text" width="50%" colSpan="2">Apellido&nbsp;
																<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ErrorMessage="Ingrese el apellido" ControlToValidate="txtApellido">*</asp:requiredfieldvalidator></TD>
														</TR>
														<TR>
															<TD class="text" width="50%" colSpan="2">
																<asp:textbox id="txtNombre" runat="server" Width="97%"></asp:textbox></TD>
															<TD class="text" width="50%" colSpan="2">
																<asp:textbox id="txtApellido" runat="server" Width="100%"></asp:textbox></TD>
														</TR>

														<TR>
															<TD class="text" width="50%" colSpan="2">Tipo de documento</TD>
															<TD class="text" width="50%" colSpan="2">Documento
																<asp:requiredfieldvalidator id="Requiredfieldvalidator6" runat="server" ErrorMessage="Ingrese el nro de documento"
																	ControlToValidate="txtDocumento">*</asp:requiredfieldvalidator></TD>
														</TR>
														<TR>
															<TD class="text" width="50%" colSpan="2">
																<asp:dropdownlist id="cmbTipoDocumento" runat="server" Width="97%"></asp:dropdownlist></TD>
															<TD class="text" width="50%" colSpan="2">
																<asp:textbox id="txtDocumento" runat="server" Width="100%"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="text" width="50%" colSpan="2">Estado&nbsp;civil&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
															<TD class="text" width="50%" colSpan="2"></TD>
														</TR>
														<TR>
															<TD class="text" width="50%" colSpan="2">
																<asp:dropdownlist id="cmbEstadoCivil" runat="server" Width="97%"></asp:dropdownlist></TD>
															<TD class="text" width="50%" colSpan="2"></TD>
														</TR>
														<TR>
															<TD class="text" width="50%" colSpan="2">Calle&nbsp;</TD>
															<TD class="text" width="50%" colSpan="2">Barrio&nbsp;</TD>
														</TR>
														<TR>
															<TD class="text" width="50%" colSpan="2">
																<asp:textbox id="txtCalle" runat="server" Width="230px"></asp:textbox></TD>
															<TD class="text" width="50%" colSpan="2">
																<asp:textbox id="txtBarrio" runat="server" Width="100%"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="text" width="25%">Nro</TD>
															<TD class="text" width="25%">Piso</TD>
															<TD class="text" width="25%">Depto.</TD>
															<TD class="text" width="25%">C.P.</TD>
														</TR>
														<TR>
															<TD class="text" width="25%">
																<asp:textbox id="txtNro" runat="server" Width="100px"></asp:textbox></TD>
															<TD class="text" width="25%">
																<asp:textbox id="txtPiso" runat="server" Width="100px"></asp:textbox></TD>
															<TD class="text" align="left" width="25%">
																<asp:textbox id="txtDepto" runat="server" Width="100px"></asp:textbox></TD>
															<TD class="text" align="left" width="25%">
																<asp:textbox id="txtCP" runat="server" Width="100px"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="text" width="50%" colSpan="2">Provincia&nbsp;</TD>
															<TD class="text" width="50%" colSpan="2">Localidad&nbsp;</TD>
														</TR>
														<TR>
															<TD class="text" width="50%" colSpan="2">
																<asp:dropdownlist id="cmbProvincia" runat="server" AutoPostBack="True" onselectedindexchanged="cmbProvincia_SelectedIndexChanged"></asp:dropdownlist></TD>
															<TD class="text" width="50%" colSpan="2">
																<asp:dropdownlist id="cmbLocalidad" runat="server"></asp:dropdownlist></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</asp:Panel>
									<asp:Panel id="pnlJuridico" runat="server">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="text" width="50%">
													<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="536" colSpan="4">
																<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&#160;&#160; Titular persona jurídica del automotor</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="text" width="175" colSpan="4">Razón&nbsp;social&nbsp;
																<asp:requiredfieldvalidator id="Requiredfieldvalidator7" runat="server" ErrorMessage="Ingrese la razón social"
																	ControlToValidate="txtRazonSocial">*</asp:requiredfieldvalidator></TD>
														</TR>
														<TR>
															<TD class="text" width="100%" colSpan="4">
																<asp:textbox id="txtRazonSocial" runat="server" Width="100%"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="text" width="175" colSpan="4">Nombre fantasia&nbsp;
																<asp:requiredfieldvalidator id="Requiredfieldvalidator5" runat="server" ErrorMessage="Ingrese nombre de fantasia"
																	ControlToValidate="txtNombreFantasia">*</asp:requiredfieldvalidator></TD>
														</TR>
														<TR>
															<TD class="text" width="100%" colSpan="4">
																<asp:textbox id="txtNombreFantasia" runat="server" Width="100%"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="text" width="50%" colSpan="2">Rubro</TD>
															<TD class="text" width="50%" colSpan="2">CUIT
																<asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" ErrorMessage="Ingrese el nro de CUIT"
																	ControlToValidate="txtCUIT">*</asp:requiredfieldvalidator></TD>
														</TR>
														<TR>
															<TD class="text" width="50%" colSpan="2">
																<asp:textbox id="txtRubro" runat="server" Width="97%"></asp:textbox></TD>
															<TD class="text" width="50%" colSpan="2">
																<asp:textbox id="txtCUIT" runat="server" Width="100%"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="text" width="50%" colspan="2">Calle&nbsp;</TD>
															<TD class="text" width="50%" colspan="2">Barrio&nbsp;</TD>
														</TR>
														<TR>
															<TD class="text" width="50%" colspan="2">
																<asp:TextBox id="CalleEmpresa" runat="server" Width="97%"></asp:TextBox></TD>
															<TD class="text" width="50%" colspan="2">
																<asp:TextBox id="BarrioEmpresa" runat="server" Width="100%"></asp:TextBox></TD>
															
														</TR>
														<TR>
															<TD class="text" width="25%">Nro.&nbsp;</TD>
															<TD class="text" width="25%">Dpto.</TD>
															<TD class="text" width="25%">Piso</TD>
															<TD class="text" width="25%" colspan="2">Código Postal&nbsp;</TD>
														</TR>
														<TR>
															<TD class="text" width="25%">
																<asp:TextBox id="NroEmpresa" runat="server" Width="92%"></asp:TextBox></TD>
															<TD class="text" width="25%">
																<asp:TextBox id="DptoEmpresa" runat="server" Width="92%"></asp:TextBox></TD>
															<TD class="text" width="25%">
																<asp:TextBox id="PisoEmpresa" runat="server" Width="92%"></asp:TextBox></TD>
															<TD class="text" width="25%">
																<asp:TextBox id="CPEmpresa" runat="server" Width="92%"></asp:TextBox></TD>
														</TR>
														<TR>
															<TD class="text" width="50%" height="14" colspan="2">Provincia</TD>
															<TD class="text" width="50%" height="14" colspan="2">Localidad&nbsp;</TD>
														</TR>
														<TR>
															<TD class="text" width="50%" colspan="2">
																<asp:dropdownlist id="cmbProvinciaEmpresas" runat="server" Width="240px" AutoPostBack="True" onselectedindexchanged="cmbProvinciaEmpresas_SelectedIndexChanged"></asp:dropdownlist></TD>
															<TD class="text" width="50%" colspan="2">
																<asp:dropdownlist id="cmbLocalidadEmpresas" runat="server" Width="240px"></asp:dropdownlist></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</asp:Panel></TD>
							</TR>
							<TR>
								<TD class="text" width="536" colSpan="4">&nbsp;Porcentaje</TD>
							</TR>
							<TR>
								<TD width="536" colSpan="4">
									<asp:textbox id="txtPorcentaje" runat="server" Width="100px"></asp:textbox>
									<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtPorcentaje" ErrorMessage="*"></asp:requiredfieldvalidator>
									</TD>
							</TR>
							<TR>
								<TD width="536" colSpan="4"></TD>
							</TR>
							<TR>
								<TD width="536" colSpan="4">
									<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="text" width="60%">&nbsp;<INPUT id="totalPorcentaje" type="hidden" name="totalPorcentaje" runat="server"><INPUT id="itemPorcentaje" type="hidden" name="itemPorcentaje" runat="server"></TD>
											<TD class="text" align="right" width="20%"><asp:button id="Aceptar" runat="server" Width="80px" Text="Aceptar" onclick="Aceptar_Click"></asp:button></TD>
											<TD class="text" align="right" width="20%"><asp:button id="Cancelar" runat="server" Width="80px" Text="Cancelar" CausesValidation="False" onclick="Cancelar_Click"></asp:button></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<INPUT id="idTitularAutomotor" type="hidden" name="idTitularAutomotor" runat="server">
						<INPUT id="idInforme" type="hidden" name="idInforme" runat="server">
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
