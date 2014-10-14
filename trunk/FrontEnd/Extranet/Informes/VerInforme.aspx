<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Informes.verInforme" CodeFile="VerInforme.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Alta de Informe</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
			<script>
			function ToggleImg(name, src, alt)
			{
				name.src = "/img/" + src;
				name.alt = alt
			}

			function mostrarFiltro(First, name)
			{
				if (masInfo.style.display == "none") 
				{
					masInfo.style.display = "list-item";
					ToggleImg(name, 'Cerrar.gif', 'Cerrar Más Info');
				} 
				else 
				{
					masInfo.style.display = "none";
					ToggleImg(name, 'Arrow.gif', 'Más Info');
				}
			}

			</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="title" width="100%">Ver Encabezado de Informe<BR>
						<HR>
						<BR>
					</td>
				</tr>
				<tr>
					<td width="100%">
						<table cellSpacing="0" cellPadding="0" width="480" border="0">
							<TR>
								<TD class="text" width="535" colSpan="4">Tipo Informe</TD>
							</TR>
							<TR>
								<TD class="text" width="535" colSpan="4"><asp:dropdownlist id="cmbTipoInforme" runat="server" Width="479px" AutoPostBack="True" Enabled="False"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="text" width="535" colSpan="4" height="10"></TD>
							</TR>
							<TR>
								<TD class="text" width="100%">
									<asp:panel id="pnlTipoPersona" runat="server">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="text" width="535">Tipo Persona:</TD>
											</TR>
											<TR>
												<TD class="text" width="100%">
													<asp:DropDownList id="cmbTipoPersona" runat="server" Enabled="False" AutoPostBack="True" Width="100%">
														<asp:ListItem Value="1">Persona F&#237;sica</asp:ListItem>
														<asp:ListItem Value="2">Persona Jur&#237;dica</asp:ListItem>
													</asp:DropDownList></TD>
											</TR>
											<TR>
												<TD class="text" width="535" height="10"></TD>
											</TR>
										</TABLE>
									</asp:panel>
								</TD>
							</TR>
							<TR>
								<TD class="text" width="100%">
									<asp:panel id="pnlParticulares" runat="server">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="title" width="535" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;Datos 
													Personales</TD>
											</TR>
											<TR>
												<TD class="text" width="535" colSpan="3">
													<asp:Image id="Image23" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
											</TR>
											<TR>
												<TD class="text" width="535" colSpan="3">Apellido:&nbsp;
													<asp:Label id="txtApellido" runat="server" Font-Bold="True">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD class="text" width="535" colSpan="3">
													<asp:Image id="Image4" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
											</TR>
											<TR>
												<TD class="text" width="535" colSpan="3">Nombre:
													<asp:Label id="txtNombre" runat="server" Font-Bold="True">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD class="text" width="535" colSpan="3">
													<asp:Image id="Image3" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
											</TR>
											<TR>
												<TD class="text" width="33%">Estado Civil:
													<asp:Label id="txtEstadoCivil" runat="server" Font-Bold="True">Label</asp:Label></TD>
												<TD class="text" width="33%">Tipo Documento:
													<asp:Label id="txtTipoDoc" runat="server" Font-Bold="True">Label</asp:Label></TD>
												<TD class="text" width="33%">&nbsp;&nbsp;&nbsp;Documento:&nbsp;
													<asp:Label id="txtDocumento" runat="server" Font-Bold="True">Label</asp:Label></TD>
											</TR>
											<TR>
												<TD class="text" width="535" colSpan="3" height="10"></TD>
											</TR>
											<TR>
												<TD class="text" width="535" colSpan="3" height="10"></TD>
											</TR>
										</TABLE>
									</asp:panel>
								</TD>
							</TR>
							<TR>
								<td width="536" colSpan="4">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="text" width="50%">
												<asp:panel id="pnlAutomotor" runat="server">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="536">
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="title" width="100%" bgColor="lightgrey" height="10">&nbsp;&nbsp; 
																			Informe de Automotor</TD>
																		<TD class="title" height="10">
                                                                            <a href="#" 
                                                            onclick="javascript:mostrarFiltro(false, imgMasInfo);">
                                                                            <img id="imgMasInfo" 
                                                            alt="Más Info" border="0" src="/img/Arrow.gif"></img></a></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="text" width="535">
																<asp:Image id="Image22" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
														</TR>
														<TR>
															<TD class="text" width="100%">Dominio&nbsp;
																<asp:Label id="txtDominio" runat="server" Font-Bold="True">Label</asp:Label></TD>
														</TR>
														<TR>
															<TD class="text" width="100%"></TD>
														</TR>
														<TR id="masInfo" style="DISPLAY: none">
															<TD class="text" width="100%">
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="text" width="100%">
																			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																				<TR>
																					<TD class="text" width="100%" colSpan="4">Registro donde está Inscripto:
																						<asp:Label id="txtRegistro" runat="server" Font-Bold="True">Label</asp:Label></TD>
																				</TR>
																				<TR>
																					<TD class="text" width="535" colSpan="4">
																						<asp:Image id="Image10" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
																				</TR>
																				<TR>
																					<TD class="text" width="311" height="14">Calle:
																						<asp:Label id="txtCalleRegistro" runat="server" Font-Bold="True">Label</asp:Label></TD>
																					<TD class="text" width="15%" height="14">Nro.:
																						<asp:Label id="txtNroRegistro" runat="server" Font-Bold="True">Label</asp:Label></TD>
																					<TD class="text" width="15%" height="14">Dpto.:
																						<asp:Label id="txtDptoRegistro" runat="server" Font-Bold="True">Label</asp:Label></TD>
																					<TD class="text" width="15%" height="14">Piso:
																						<asp:Label id="txtPisoRegistro" runat="server" Font-Bold="True">Label</asp:Label></TD>
																				</TR>
																				<TR>
																					<TD class="text" width="535" colSpan="4">
																						<asp:Image id="Image11" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
																				</TR>
																				<TR>
																					<TD class="text" width="311"></TD>
																					<TD class="text" width="10%"></TD>
																					<TD class="text" width="10%"></TD>
																					<TD class="text" width="10%"></TD>
																				</TR>
																				<TR>
																					<TD colSpan="4">
																						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																							<TR>
																								<TD class="text" width="266">Barrio:
																									<asp:Label id="txtBarrioRegistro" runat="server" Font-Bold="True">Label</asp:Label></TD>
																								<TD class="text" width="45%">Código Postal:
																									<asp:Label id="txtCPRegistro" runat="server" Font-Bold="True">Label</asp:Label></TD>
																							</TR>
																							<TR>
																								<TD class="text" width="266"></TD>
																								<TD class="text" width="10%"></TD>
																							</TR>
																						</TABLE>
																					</TD>
																				</TR>
																				<TR>
																					<TD class="text" width="535" colSpan="4">
																						<asp:Image id="Image12" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
																				</TR>
																				<TR>
																					<TD colSpan="4">
																						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																							<TR>
																								<TD class="text" width="55%">Provincia:
																									<asp:Label id="txtProvinciaRegistro" runat="server" Font-Bold="True">Label</asp:Label></TD>
																								<TD class="text" width="35%">Localidad:
																									<asp:Label id="txtLocalidadRegistro" runat="server" Font-Bold="True">Label</asp:Label></TD>
																							</TR>
																							<TR>
																								<TD class="text" width="271"></TD>
																								<TD class="text" width="50%"></TD>
																							</TR>
																						</TABLE>
																					</TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
													</TABLE>
												</asp:panel><asp:panel id="pnlDomicilioParticular" runat="server">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="536" colSpan="4">
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="title" width="100%" bgColor="lightgrey" height="10">&nbsp;&nbsp; 
																			Verificación Domicilio Particular</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														
														<TR>
                      <TD class=text width="50%" 
                        colSpan=2><STRONG>Calle:</STRONG> 
<asp:label id="txtCalle" runat="server"></asp:label></TD>
                      <TD class=text width="25%"><STRONG>Lote:</STRONG> 
<asp:label id="txtLote" runat="server"></asp:label></TD>
                      <TD class=text width="25%"><STRONG>Manzana:</STRONG> 
<asp:label id="txtManzana" runat="server"></asp:label></TD>
</TR>
                    <TR>
                      <TD class=text width="25%"><STRONG>Nro:</STRONG> 
<asp:label id=txtNro runat="server"></asp:label></TD>
                      <TD class=text width="25%"><STRONG>Piso:</STRONG> 
<asp:label id=txtPiso runat="server"></asp:label></TD>
                      <TD class=text width="25%"><STRONG>Depto.:</STRONG> 
<asp:label id=txtDepto runat="server"></asp:label></TD>
                      <TD class=text width="25%"><STRONG>C.P.:</STRONG> 
<asp:label id=txtCP runat="server"></asp:label></TD></TR>
                    <TR>
                      <TD class=text width="50%" 
                        colSpan=2><STRONG>Complejo:</STRONG>&nbsp; 
<asp:label id=txtComplejo runat="server"></asp:label></TD>
                      <TD class=text width="50%" 
                        colSpan=2><STRONG>Torre:&nbsp;&nbsp; </STRONG>
<asp:label id=txtTorre runat="server"></asp:label></TD></TR>
                    <TR>
                      <TD class=text width="50%" 
                        colSpan=2><STRONG>Barrio:</STRONG>&nbsp; 
<asp:label id=txtBarrio runat="server"></asp:label></TD>
                      <TD class=text width="50%" 
                        colSpan=2><STRONG>Teléfono:&nbsp;&nbsp; </STRONG>
<asp:label id=txtTelefono2 runat="server"></asp:label></TD></TR>
														<TR>
															<TD width="536" colSpan="4">
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="text" width="50%" height="13">Provincia:
																			<asp:Label id="txtProvincia" runat="server" Font-Bold="True">Label</asp:Label></TD>
																		<TD class="text" width="10%" height="13">Localidad:&nbsp;
																			<asp:Label id="txtLocalidad" runat="server" Font-Bold="True">Label</asp:Label></TD>
																	</TR>
																	<TR>
																		<TD class="text" width="10%"></TD>
																		<TD class="text" width="50%"></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="text" width="535" colSpan="4" height="10"></TD>
														</TR>
													</TABLE>
												</asp:panel>
												<asp:panel id="pnlPropiedad" runat="server">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="536">
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="title" width="100%" bgColor="lightgrey" height="10">&nbsp;&nbsp; 
																			<asp:Label ID="lblInformePropiedad" runat="server" >Informe de la Propiedad</asp:Label></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="text" width="535">
																<asp:Image id="Image24" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image>
                                                                <asp:Panel ID="pnlInformePropiedadProvincias" runat="server">
                                                                    <table style="width: 100%;" class="text" cellpadding="0" cellspacing="2">
                                                                        <tr>
                                                                            <td>
                                                                                Provincia: 
                                                                                <asp:Label ID="txtProvinciaOtra" runat="server" Font-Bold="true"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                Localidad: 
                                                                                <asp:Label ID="txtLocalidadOtra" runat="server" Font-Bold="true"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
																
																</TD>
														</TR>
														<TR>
															<TD class="text" width="100%">Datos sobre la Propiedad:
																<asp:Label id="txtTipoPropiedad" runat="server" Font-Bold="True">Label</asp:Label></TD>
														</TR>
														<TR>
															<TD class="text" width="535">
																<asp:Image id="Image14" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
														</TR>
														<TR>
															<TD class="text" width="175">
																<asp:Label id="lblTipoPropiedad" runat="server" Font-Bold="True">Nro de Matricula</asp:Label>
                                                                <STRONG>:</STRONG>
																<asp:Label id="txtLegajo" runat="server" Font-Bold="True">Label</asp:Label></TD>
														</TR>
														<TR>
															<TD class="text" width="535">
																<asp:Image id="Image15" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
														</TR>
														<asp:panel id="pnlDominioLegEspecial" runat="server" Width="100%">
															<TR>
																<TD class="text" width="175">Folio:
																	<asp:Label id="txtFolio" runat="server" Font-Bold="True">Label</asp:Label></TD>
																<TD class="text" width="33%">Tomo:
																	<asp:Label id="txtTomo" runat="server" Font-Bold="True">Label</asp:Label></TD>
																<TD class="text" width="33%">Año:
																	<asp:Label id="txtAno" runat="server" Font-Bold="True">Label</asp:Label></TD>
															</TR>
															<TR>
																<TD class="text" width="175"></TD>
																<TD class="text" width="33%"></TD>
																<TD class="text" align="left" width="33%"></TD>
															</TR>
														</asp:panel></TABLE>
												</asp:panel>
												<asp:panel id="pnlCatastral" runat="server" Width="100%">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="536">
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="title" width="100%" bgColor="lightgrey" height="10">&nbsp;&nbsp; 
																			Informe Catastral</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="text" width="535">
																<asp:Image id="Image25" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
														</TR>
														<TR>
															<TD class="text" width="100%">Tipo Informe:
																<asp:Label id="txtTipoCatastro" runat="server" Font-Bold="True">Label</asp:Label></TD>
														</TR>
														<TR>
															<TD class="text" width="535">
																<asp:Image id="Image26" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
														</TR>
														<TR>
															<TD class="text" width="100%"></TD>
														</TR>
														<TR>
															<TD class="text" width="100%">Número:
																<asp:Label id="numeroCatastro" runat="server" Font-Bold="True">Label</asp:Label></TD>
														</TR>
														<TR>
														<TR>
															<TD width="536">
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="text" width="55%">Provincia:
																			<asp:Label id="txtProvinciaCatastro" runat="server" Font-Bold="True">Label</asp:Label></TD>
																		<TD class="text" width="10%">Localidad:
																			<asp:Label id="txtLocalidadCatastro" runat="server" Font-Bold="True">Label</asp:Label></TD>
																	</TR>
																	<TR>
																		<TD class="text" width="10%"></TD>
																		<TD class="text" width="50%"></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<asp:panel id="pnlCatastralDireccion" runat="server">
															<TR>
																<TD class="text" width="100%" colSpan="3">
																	<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																		<TR>
																			<TD class="text" width="55%" height="14">Calle:
																				<asp:Label id="txtCalleCatastro" runat="server" Font-Bold="True">Label</asp:Label></TD>
																			<TD class="text" width="15%" height="14">Nro.:
																				<asp:Label id="txtNroCatastro" runat="server" Font-Bold="True">Label</asp:Label></TD>
																			<TD class="text" width="15%" height="14">Dpto.:
																				<asp:Label id="txtDptoCatastro" runat="server" Font-Bold="True">Label</asp:Label></TD>
																			<TD class="text" width="25%" height="14">Piso:
																				<asp:Label id="txtPisoCatastro" runat="server" Font-Bold="True">Label</asp:Label></TD>
																		</TR>
																	</TABLE>
																</TD>
															</TR>
															<TR>
																<TD width="536" colSpan="4">
																	<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																		<TR>
																			<TD class="text" width="55%">Barrio:&nbsp;
																				<asp:Label id="txtBarrioCatastro" runat="server" Font-Bold="True">Label</asp:Label></TD>
																			<TD class="text" width="45%">Código Postal:
																				<asp:Label id="txtCPCatastro" runat="server" Font-Bold="True">Label</asp:Label></TD>
																		</TR>
																		<TR>
																			<TD class="text" width="50%"></TD>
																			<TD class="text" width="10%"></TD>
																		</TR>
																	</TABLE>
																</TD>
															</TR>
														</asp:panel></TABLE></asp:panel><asp:panel id="pnlAmbiental" runat="server">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="536" colSpan="2">
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                        
																	<TR>
																		<TD class="title" width="100%" bgColor="lightgrey" height="10">&nbsp;&nbsp; 
																			Informe Ambiental</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="text" width="535" colSpan="2">
																<asp:Image id="Image17" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
                                                        
														</TR>
														<TR>
															<TD class="text" width="100%" colSpan="2">Apellido del Cónyugue / Concubino:
																<asp:Label id="txtApellidoAmb" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
														</TR>
														<TR>
															<TD class="text" width="535" colSpan="2">
																<asp:Image id="Image19" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
                                                        
														</TR>
														<TR>
															<TD class="text" width="100%" colSpan="2">Nombre del Cónyugue / Concubino:
																<asp:Label id="txtNombreAmb" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
														</TR>
														<TR>
															<TD class="text" width="535" colSpan="2">
																<asp:Image id="Image18" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
                                                        
														</TR>
														<TR>
															<TD class="text" width="50%">Tipo Documento:
																<asp:Label id="txtTipoDocumentoAmb" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
															<TD class="text" width="50%">Documento:
																<asp:Label id="txtDocumentoAmb" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
														</TR>
														<TR>
															<TD class="text" width="535" colSpan="2">
																<asp:Image id="Image20" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
                                                        
														</TR>
													</TABLE>
												</asp:panel><asp:panel id="pnlDomComercial" runat="server">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="536">
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                        
																	<TR>
																		<TD class="title" width="100%" bgColor="lightgrey" height="10">&nbsp;&nbsp;
																			<asp:label id="lblInforme" runat="server" CssClass="Title">Persona Jurídica</asp:label></TD>
                                                        
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="text" width="535">
																<asp:Image id="Image21" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
                                                        
														</TR>
														<TR>
															<TD class="text" width="100%">Razón Social:
																<asp:Label id="txtRazonSocial" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
														</TR>
														<TR>
															<TD class="text" width="535">
																<asp:Image id="Image5" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
                                                        
														</TR>
														<TR>
															<TD>
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                        
																	<TR>
																		<TD class="text" width="55%">Nombre de Fantasía:
																			<asp:Label id="txtFantasia" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
																		<TD class="text" width="45%">Teléfono:
																			<asp:Label id="txtTelefono" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="text" width="535">
																<asp:Image id="Image6" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
                                                        
														</TR>
														<TR>
															<TD>
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                        
																	<TR>
																		<TD class="text" width="55%" height="14">Rubro:
																			<asp:Label id="txtRubro" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
																		<TD class="text" width="45%" height="14">Cuit:
																			<asp:Label id="txtCuit" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="text" width="535">
																<asp:Image id="Image7" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
                                                        
														</TR>
														<TR>
															<TD>
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                        
																	<TR>
																		<TD class="text" width="55%">Calle:
																			<asp:Label id="txtCalleEmpresa" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
																		<TD class="text" width="15%">Nro.&nbsp;
																			<asp:Label id="txtNroEmpresa" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
																		<TD class="text" width="15%">Dpto.
																			<asp:Label id="txtDptoEmpresa" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
																		<TD class="text" width="20%">Piso
																			<asp:Label id="txtPisoEmpresa" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="text" width="535">
																<asp:Image id="Image8" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
                                                        
														</TR>
														<TR>
															<TD>
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                        
																	<TR>
																		<TD class="text" width="55%">Barrio&nbsp;
																			<asp:Label id="txtBarrioEmpresa" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
																		<TD class="text" width="45%">Código Postal:
																			<asp:Label id="txtCPEmpresa" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="text" width="535">
																<asp:Image id="Image9" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
                                                        
														</TR>
														<TR>
															<TD>
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                        
																	<TR>
																		<TD class="text" width="55%" height="14">Provincia:
																			<asp:Label id="txtProvinciaEmpresa" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
																		<TD class="text" width="40%" height="14">Localidad:
																			<asp:Label id="txtLocalidadEmpresa" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
																	</TR>
																	<TR>
																		<TD class="text" width="10%"></TD>
																		<TD class="text" width="50%"></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="text">&nbsp;&nbsp;</TD>
														</TR>
													</TABLE>
												</asp:panel>
												<asp:panel id="pnlGravamenes" runat="server">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="536" colSpan="3">
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                        
																	<TR>
																		<TD class="title" width="100%" bgColor="lightgrey" height="10">&nbsp;&nbsp; 
																			Informe de Gravámenes</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="text" width="535" colSpan="3">
																<asp:Image id="Image16" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
                                                        
														</TR>
														<TR>
															<TD class="text" width="100%" colSpan="3">Tipo de Gravamen:
																<asp:Label id="txtTipoGravamen" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
														</TR>
														<TR>
															<TD class="text" width="535" colSpan="3">
																<asp:Image id="Image13" runat="server" Height="5px" ImageUrl="/img/shim.gif"></asp:Image></TD>
                                                        
														</TR>
														<TR>
															<TD class="text" width="33%">Folio:
																<asp:Label id="txtFolioGravamen" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
															<TD class="text" width="33%">Tomo:
																<asp:Label id="txtTomoGravamen" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
															<TD class="text" width="33%">Año:
																<asp:Label id="txtAnoGravamen" runat="server" Font-Bold="True">Label</asp:Label></TD>
                                                        
														</TR>
													</TABLE>
												</asp:panel>
											</TD>
										</TR>
									</table>
								</td>
							</TR>
							<TR>
								<TD>
									<asp:panel id="pnlTitulo" runat="server">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD width="536">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                            
														<TR>
															<TD class="title" width="100%" bgColor="lightgrey" height="10">&nbsp;&nbsp;
																<asp:label id="lblTitulo" runat="server" CssClass="Title">Domicilio Comercial</asp:label></TD>
                                            
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</asp:panel>
								</TD>
							</TR>
							<TR>
								<TD>
									<asp:panel id="pnlFoto" runat="server">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="text">&nbsp;&nbsp;</TD>
											</TR>
											<TR>
												<TD class="text">
													<asp:CheckBox id="chkFoto" runat="server" Enabled="False" Font-Bold="True" Text="      Informe Con Foto"></asp:CheckBox></TD>
                                            
											</TR>
										</TABLE>
									</asp:panel>
								</TD>
							</TR>
							<TR>
								<TD>
									<asp:panel id="pnlUrgencia" runat="server">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="text"><STRONG>Carácter</STRONG></TD>
											</TR>
											<TR>
												<TD class="text">
													<asp:DropDownList id="cmbCaracter" runat="server" Enabled="False">
														<asp:ListItem Value="0">Normal</asp:ListItem>
														<asp:ListItem Value="1">Urgente</asp:ListItem>
														<asp:ListItem Value="2">Super Urgente</asp:ListItem>
													</asp:DropDownList></TD>
											</TR>
										</TABLE>
									</asp:panel>
								</TD>
							</TR>
							<tr>
								<td width="535" colSpan="4">&nbsp;</td></tr>
						    <TR>
								<td class="text" width="535" colSpan="4">Observaciones&nbsp;</td></TR><TR>
								<td colSpan="4">
									<table cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<td class="text" colSpan="4">
												&nbsp;&nbsp;<asp:Label id="lblObservaciones" runat="server" CssClass="txtlabel">Label</asp:Label></td></TR></table></td></TR><TR>
								<td width="535" colSpan="4">
									<hr>
								</td>
							</TR>
							<tr>
								<td width="535" colSpan="4">&nbsp;<asp:Label ID="lblFechaFin" runat="server" CssClass="txtlabel"></asp:Label></td></tr>
							<TR>
								<td width="536" colSpan="4">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="text" width="60%">&nbsp;</TD><TD class="text" align="right" width="20%"></TD>
											<TD class="text" align="right" width="20%"><asp:button id="Cerrar" runat="server" Width="80px" Text="Cerrar" onclick="Cancelar_Click"></asp:button></TD>
										</TR>
									</table>
								</td>
							</TR>
						</table>
					</td>
				</tr>
			</TABLE>
			<input type="hidden" id="idEncabezado" runat="server" NAME="idEncabezado"> <input type="hidden" id="idReferencia" runat="server" NAME="idReferencia">
		</form>
	</body>
</HTML>
