<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.VerifDomComercial.verInformeCalle" CodeFile="VerInformeCalle.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Verificación de Domicilio Comercial</title>
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
					<td align="right">
						<div id="panel">
							<input onclick="panel.style.visibility='hidden';window.print();panel.style.visibility='visible';"
								type="image" src="/img/imprimir-2.gif" title="Imprimir"> <input onclick="window.close();window.opener.location.href=window.opener.location;" type="image" src="/img/log_off.gif" title="Cerrar">
						</div>
					</td>
				</tr>
			</TABLE>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<td><IMG alt="" src="/img/logo-20-anios-impr.png" height"69></td>
					<TD class="title" width="100%">
						<FONT color="#ffffff">
							<P align="center"><FONT color="gray">Verificación de Domicilio Comercial</FONT>
						</FONT></P>
					</TD>
				</TR>
			</TABLE>
			<TABLE class="text" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TBODY>
					<tr>
						<td class="title" width="100%">
							<HR>
							<TABLE cellSpacing="0" cellPadding="0" style="BORDER-COLLAPSE: collapse" borderColor="#000000"
								width="100%" border="1">
								<tr>
									<td class="text" align="left" width="85%">
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr>
												<td class="text">
													&nbsp;Solicitado por:
													<asp:label id="lblSolicitante" runat="server" Font-Bold="True"></asp:label>
												</td>
												<td class="text">
													Fecha:
													<asp:label id="lblFec" runat="server" Font-Bold="True"></asp:label>
												</td>
											</tr>
											<tr>
												<td class="text" colSpan="2">
													&nbsp;Referencia:
													<asp:label id="lblRef" runat="server" Font-Bold="True"></asp:label>
												</td>
											</tr>
										</table>
									</td>
									<td class="text" align="left" width="15%">
										&nbsp;Numero:
										<asp:label id="lblNum" runat="server" Font-Bold="True"></asp:label>
									</td>
								</tr>
							</TABLE>
							<!--- FIN ENCABEZADO --->
							<TABLE id="Table2" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
								cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="text" width="100%">
										<!---INICIO DATOS PERSONA FISICA --->
										<asp:Panel id="pnlFisica" runat="server">
											<TABLE id="Table3" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="0"
												cellPadding="3" width="100%" border="1">
												<TR>
													<TD width="100%" colSpan="4"><!--- DATOS COMERCIALES --->
														<TABLE id="Table4" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
															cellPadding="0" width="100%" border="0">
															<TR>
																<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;
																	<FONT color="gray">Datos Comerciales</FONT>
																</TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD class="text" width="50%" colSpan="2"><STRONG><STRONG>Apellido</STRONG>&nbsp;y 
															nombre:</STRONG>&nbsp;
														<asp:label id="lblApellido" runat="server"></asp:label>,
														<asp:label id="lblNombre" runat="server"></asp:label></TD>
													<TD class="text" width="50%" colSpan="2"><STRONG>Tipo y nº documento:</STRONG>
														<asp:label id="lblTipoDocumento" runat="server"></asp:label>&nbsp;
														<asp:label id="lblDocumento" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD class="text" width="50%" colSpan="2"><STRONG>Nombre de fantasía:</STRONG>
														<asp:label id="lblNombreFantasia" runat="server"></asp:label></TD>
													<TD class="text" width="50%" colSpan="2"><STRONG>Razón Social:&nbsp; </STRONG>
														<asp:label id="lblRazonSocial" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD class="text" width="50%" colSpan="2"><STRONG>Rubro:&nbsp;</STRONG>
														<asp:label id="lblRubro" runat="server"></asp:label></TD>
													<TD class="text" width="50%" colSpan="2"><STRONG>CUIT:&nbsp;</STRONG>
														<asp:label id="lblCuit" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD width="100%" colSpan="4"><!--- DOMICILIO --->
														<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
															<TR>
																<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;
																	<FONT color="gray">Domicilio</FONT>
																</TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD class="text" width="50%" colSpan="2"><STRONG>Calle:&nbsp;</STRONG>
														<asp:label id="lblCalle" runat="server"></asp:label></TD>
													<TD class="text" width="25%" colSpan="1"><STRONG>Barrio:</STRONG>&nbsp;
														<asp:label id="lblBarrio" runat="server"></asp:label></TD>
													<TD class="text" width="25%" colSpan="1"><STRONG>Teléfono:</STRONG>&nbsp;
														<asp:label id="lblTelefono" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD class="text" width="25%"><STRONG>Nro:</STRONG>
														<asp:label id="lblNro" runat="server"></asp:label></TD>
													<TD class="text" width="25%"><STRONG>Piso:</STRONG>
														<asp:label id="lblPiso" runat="server"></asp:label></TD>
													<TD class="text" width="25%"><STRONG>Depto.:</STRONG>
														<asp:label id="lblDepto" runat="server"></asp:label></TD>
													<TD class="text" width="25%"><STRONG>C.P.:</STRONG>
														<asp:label id="lblCP" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD class="text" width="50%" colSpan="2"><STRONG>Provincia:</STRONG>&nbsp;
														<asp:label id="lblProvincia" runat="server"></asp:label></TD>
													<TD class="text" width="50%" colSpan="2"><STRONG>Localidad:</STRONG>&nbsp;
														<asp:label id="lblLocalidad" runat="server"></asp:label></TD>
												</TR>
											</TABLE>
										</asp:Panel>
										<!--- FIN DATOS PERSONA FISICA --->
										<!--- INICIO DATOS PERSONA JURIDICA --->
										<asp:panel id="pnlDomComercial" runat="server">
											<TABLE id="Table8" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="0"
												cellPadding="3" width="100%" border="1">
												<TR>
													<TD width="100%" colSpan="4">
														<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
															<TR>
																<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;
																	<FONT color="gray">
																		<asp:label id="lblInforme" runat="server">Persona Jurídica</asp:label></FONT></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD class="text" width="45%" colSpan="2"><STRONG>Razón Social:&nbsp;</STRONG>
														<asp:label id="lblRazonSocialEmp" runat="server"></asp:label></TD>
													<TD class="text" width="55%" colSpan="2"><STRONG>Nombre de fantasía:</STRONG>
														<asp:label id="lblNombreFantasiaEmp" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD class="text" width="45%" colSpan="2"><STRONG>Rubro:&nbsp;</STRONG>
														<asp:label id="lblRubroEmp" runat="server"></asp:label></TD>
													<TD class="text" width="25%" colSpan="1"><STRONG>Teléfono:</STRONG>
														<asp:label id="lblTelefonoEmp" runat="server"></asp:label></TD>
													<TD class="text" width="30%" colSpan="1"><STRONG>CUIT:&nbsp; </STRONG>
														<asp:label id="lblCuitEmp" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD class="text" width="45%" colSpan="2"><STRONG>Calle:&nbsp;</STRONG><BR>
														<asp:label id="lblCalleEmp" runat="server"></asp:label></TD>
													<TD class="text" width="55%" colSpan="2"><STRONG>Barrio:</STRONG>&nbsp;
														<BR>
														<asp:label id="lblBarrioEmp" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD class="text" width="30%"><STRONG>C.P.:</STRONG>
														<asp:label id="lblCPEmp" runat="server"></asp:label></TD>
													<TD class="text" width="15%"><STRONG>Nro:</STRONG>
														<asp:label id="lblNroEmp" runat="server"></asp:label></TD>
													<TD class="text" width="25%"><STRONG>Depto.:</STRONG>
														<asp:label id="lblDeptoEmp" runat="server"></asp:label></TD>
													<TD class="text" width="30%"><STRONG>Piso:</STRONG>
														<asp:label id="lblPisoEmp" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD class="text" width="50%" colSpan="2" height="14"><STRONG>Provincia:</STRONG>&nbsp;
														<asp:label id="lblProvinciaEmp" runat="server"></asp:label></TD>
													<TD class="text" width="50%" colSpan="2" height="14"><STRONG>Localidad:</STRONG>&nbsp;
														<asp:label id="lblLocalidadEmp" runat="server"></asp:label></TD>
												</TR>
											</TABLE>
										</asp:panel>
										<!--- FIN DATOS PERSONA JURIDICA --->
									</TD>
								</TR>
							</TABLE>
							<TABLE class="text" id="Table16" style="BORDER-COLLAPSE: collapse" borderColor="#111111"
								cellSpacing="0" cellPadding="3" width="100%" border="1">
								<TR>
									<td colSpan="3">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">
													&nbsp;&nbsp; <FONT color="gray">Gestión sobre la verificación</FONT>
												</TD>
											</TR>
										</TABLE>
									</td>
								</TR>
								<tr>
									<TD class="text" width="33%" height="19">
										<STRONG>Fecha:</STRONG>
										<BR>
										<asp:label id="lblFecha" runat="server"></asp:label>
									</TD>
									<TD class="text" width="33%" height="19">
										<STRONG>Ocupación:</STRONG><BR>
										<asp:label id="lblOcupacion" runat="server"></asp:label>
									</TD>
									<TD class="text" width="33%" height="19">
										<STRONG>Categoría de autonomo:<BR>
										</STRONG>
										<asp:label id="lblCategoria" runat="server"></asp:label>
									</TD>
								</tr>
								<TR>
									<TD class="text" width="33%">
										<STRONG>Mov. comercial observado:<BR>
										</STRONG>
										<asp:label id="lblMovComercial" runat="server"></asp:label>
									</TD>
									<TD class="text" width="33%">
										<STRONG>Actividad principal:<BR>
										</STRONG>
										<asp:label id="lblActividad" runat="server"></asp:label>
									</TD>
									<TD class="text" width="33%">
										<STRONG>Rubros adicionales:<BR>
										</STRONG>
										<asp:label id="lblRubros" runat="server"></asp:label>
									</TD>
								</TR>
								<TR>
									<TD class="text" width="33%">
										<STRONG>Horario de atención:</STRONG><BR>
										<asp:label id="lblHorario" runat="server"></asp:label>
									</TD>
									<TD class="text" width="33%">
										<STRONG>Antiguedad en el domicilio:<BR>
										</STRONG>
										<asp:label id="lblAntiguedad" runat="server"></asp:label>
									</TD>
									<TD class="text" width="33%">
										<STRONG>Cantidad de personal:<BR>
										</STRONG>
										<asp:label id="lblCantidad" runat="server"></asp:label>
									</TD>
								</TR>
								<TR>
									<TD vAlign="top">
										<STRONG>Caracteristica zona:<BR>
										</STRONG>
										<asp:Label id="lblCaractZona" runat="server"></asp:Label>
									</TD>
									<TD vAlign="top">
										<STRONG>Documento verificado:</STRONG><BR>
										<asp:Label id="lblDocumentoVerificado" runat="server"></asp:Label>
									</TD>
									<TD vAlign="top">
										<STRONG>Ubicación:<BR>
										</STRONG>
										<asp:Label id="lblUbicacion" runat="server"></asp:Label>
									</TD>
								</TR>
								<TR>
									<TD height="14" vAlign="top">
										<STRONG>Tamaño de local:<BR>
										</STRONG>
										<asp:Label id="lblTamanio" runat="server"></asp:Label>
									</TD>
									<TD height="14" vAlign="top">
										<STRONG>Inmueble:</STRONG><BR>
										<asp:Label id="lblInmueble" runat="server"></asp:Label>
									</TD>
									<TD height="14" vAlign="top">
										<STRONG>Estado de conservación:</STRONG><BR>
										<asp:Label id="lblEstado" runat="server"></asp:Label>
									</TD>
								</TR>
							</TABLE>
							<TABLE class="text" id="Table17" style="BORDER-COLLAPSE: collapse" borderColor="#111111"
								cellSpacing="0" cellPadding="3" width="100%" border="1">
								<TR>
									<td width="25%" colSpan="2"><STRONG>Cartel de publicidad: </STRONG>
										<asp:label id="lblPublicidad" runat="server"></asp:label>
									</td>
									<td width="25%" colSpan="2"><STRONG>Personal de vigilancia:</STRONG>
										<asp:label id="lblVigilancia" runat="server"></asp:label>
									</td>
								</TR>
								<TR>
									<TD width="25%" colSpan="2"><STRONG>Inicio de actividades:</STRONG>
										<asp:label id="lblInicioActividades" runat="server"></asp:label></TD>
									<TD width="25%" colSpan="2"><STRONG>Categoria ante el IVA: </STRONG>
										<asp:label id="lblIVA" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD width="25%" colSpan="2"><STRONG>Informó:</STRONG>&nbsp;
										<asp:label id="lblInformo" runat="server"></asp:label></TD>
									<TD width="25%" colSpan="2"><STRONG>Cargo o relación: </STRONG>
										<asp:label id="lblCargo" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="text" width="100%" colSpan="4">&nbsp;</TD>
								</TR>
							</TABLE>
							<TABLE class="text" id="Table1" style="BORDER-COLLAPSE: collapse" borderColor="#111111"
								cellSpacing="0" cellPadding="3" width="100%" border="1">
								<TR>
									<td colSpan="3">
										<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">
													&nbsp;&nbsp; <FONT color="gray">Referencia vecinal</FONT>
												</TD>
											</TR>
										</TABLE>
									</td>
								</TR>
								<tr>
									<TD class="text" width="33%">
										<STRONG>Apellido y nombre:</STRONG><BR>
										<asp:label id="lblNombreVecino" runat="server"></asp:label>
									</TD>
									<TD class="text" width="33%">
										<STRONG>Domicilio:<BR>
										</STRONG>
										<asp:label id="lblDomicilioVecino" runat="server"></asp:label>
									</TD>
									<TD class="text" width="33%">
										<STRONG>Conoce del funcionamiento:</STRONG><BR>
										<asp:label id="lblConoce" runat="server"></asp:label>
									</TD>
								</tr>
								<TR>
									<TD width="100%" colSpan="3">
										<STRONG>
											<asp:label id="Label5" runat="server">Observaciones</asp:label>:<BR>
										</STRONG>
										<asp:label id="lblObservaciones" runat="server"></asp:label>
									</TD>
								</TR>
								<TR>
									<TD width="33%" colSpan="3">
										<B>Plano de ubicación:</B>
									</TD>
								</TR>
								<TR>
									<TD class="text" align="center">
										<IMG height="115" src="/img/plano_chico.gif" width="115" border="1">
									</TD>
									<TD vAlign="top" width="33%" colspan="2">&nbsp;
										<TABLE class="text" id="Table14" cellSpacing="1" cellPadding="2">
											<TR>
												<TD>Ubicación <B>A:</B></TD>
												<TD><asp:label id="lblPlanoA" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD>Ubicación <B>B:</B></TD>
												<TD><asp:label id="lblPlanoB" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD>Ubicación <B>C:</B></TD>
												<TD><asp:label id="lblPlanoC" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD>Ubicación <B>D:</B></TD>
												<TD><asp:label id="lblPlanoD" runat="server"></asp:label></TD>
											</TR>
										</TABLE>
										<P align="center">
											<asp:Label id="lblConFoto" runat="server" Font-Bold="True" Visible="False" Font-Italic="True">Sacar fotos al comercio</asp:Label>
										</P>
									</TD>
								</TR>
							</TABLE>
							<INPUT id="idEncabezado" type="hidden" name="idEncabezado" runat="server"> <INPUT id="idReferencia" type="hidden" name="idReferencia" runat="server">
						</td>
					</tr>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
