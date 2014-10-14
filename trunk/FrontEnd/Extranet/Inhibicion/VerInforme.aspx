<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Inhibicion.verInforme" CodeFile="VerInforme.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Ver Informe</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td align="right">
						<div id="panel"><input onclick="panel.style.visibility='hidden';window.print();panel.style.visibility='visible';"
								type="image" src="/img/imprimir-2.gif"> <input onclick="window.close();" type="image" src="/img/log_off.gif">
						</div>
					</td>
				</tr>
			</TABLE>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<td><IMG alt="" src="/img/logo-20-anios.png" width="264"></td>
					<TD class="title" width="100%"><FONT color="#ffffff">
							<P align="center"><FONT color="#32528e">Informe de Gravámenes - Inhibiciones</FONT>
						</FONT></P></TD>
				</TR>
				<tr>
					<td colSpan="2">
						<TABLE style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="0" cellPadding="0"
							width="100%" border="1">
							<tr>
								<td class="text" align="left" width="85%">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="text">&nbsp;Solicitado por:
												<asp:label id="lblSolicitante" runat="server" Font-Bold="True"></asp:label></td>
											<td class="text">&nbsp;Fecha:
												<asp:label id="lblFec" runat="server" Font-Bold="True"></asp:label></td>
										</tr>
										<tr>
											<td class="text" colSpan="2">&nbsp;Referencia:
												<asp:label id="lblRef" runat="server" Font-Bold="True"></asp:label></td>
										</tr>
									</table>
								</td>
								<td class="text" align="right" width="15%">Número:
									<asp:label id="lblNum" runat="server" Font-Bold="True"></asp:label>&nbsp;</td>
							</tr>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td class="title" width="100%" colSpan="2">
						<HR>
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="text" width="100%" colSpan="4">&nbsp;</TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="4">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="text" width="100%" colSpan="4">
												<asp:panel id="pnlFisica" runat="server">
													<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
														cellPadding="3" width="100%" border="1">
														<TR>
															<TD width="99%" colSpan="3">
																<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;&nbsp;Persona 
																			Física</TD>
																	</TR>
																</TABLE>
															</TD>
														<TR>
															<TD width="33%"><STRONG>Apellido y nombre:</STRONG>&nbsp;
																<asp:label id="lblApellido" runat="server"></asp:label>,
																<asp:label id="lblNombre" runat="server"></asp:label></TD>
															<TD class="text" width="33%"><STRONG>Tipo y nº documento:&nbsp;</STRONG>
																<asp:label id="lblTipoDocumento" runat="server"></asp:label>&nbsp;
																<asp:label id="lblDocumento" runat="server"></asp:label></TD>
															<TD class="text" width="33%"><STRONG>Estado civil:</STRONG>
																<asp:label id="lblEstadoCivil" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="text" width="33%"><STRONG>Folio:</STRONG>&nbsp;
																<asp:label id="lblFolio" runat="server"></asp:label></TD>
															<TD class="text" width="33%"><STRONG>Tomo:</STRONG>
																<asp:label id="lblTomo" runat="server"></asp:label></TD>
															<TD class="text" width="33%"><STRONG>Año: </STRONG>
																<asp:label id="lblAnio" runat="server"></asp:label></TD>
														</TR>
													</TABLE>
												</asp:panel>
												<asp:panel id="pnlJuridica" runat="server">
													<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
														cellPadding="3" width="100%" border="1">
														<TR>
															<TD width="100%" colSpan="4">
																<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; 
																			Persona Jurídica</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="text" width="360" colSpan="2"><STRONG>Razón Social:</STRONG>
																<asp:label id="lblRazonSocial" runat="server"></asp:label></TD>
															<TD class="text" width="50%" colSpan="2"><STRONG>Nombre de fantasia:</STRONG>&nbsp;
																<asp:label id="lblNombreFantasia" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="text" width="360" colSpan="2"><STRONG>Rubro:&nbsp;</STRONG>
																<asp:label id="lblRubro" runat="server"></asp:label></TD>
															<TD class="text" width="50%" colSpan="2"><STRONG>CUIT:&nbsp;</STRONG>
																<asp:label id="lblCUIT" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="text" width="360" colSpan="2"><STRONG>Calle:&nbsp;</STRONG>
																<asp:label id="lblCalleEmpresa" runat="server"></asp:label></TD>
															<TD class="text" width="50%" colSpan="2"><STRONG>Barrio:&nbsp;</STRONG>
																<asp:label id="lblBarrioEmpresa" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="text" width="160"><STRONG>Nro:</STRONG>
																<asp:label id="lblNroEmpresa" runat="server"></asp:label></TD>
															<TD class="text" width="209"><STRONG>Piso:</STRONG>
																<asp:label id="lblPisoEmpresa" runat="server"></asp:label></TD>
															<TD class="text" width="25%"><STRONG>Depto.:</STRONG>
																<asp:label id="lblDeptoEmpresa" runat="server"></asp:label></TD>
															<TD class="text" width="25%"><STRONG>C.P.:</STRONG>
																<asp:label id="lblCPEmpresa" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="text" width="360" colSpan="2"><STRONG>Teléfono:&nbsp;</STRONG>
																<asp:label id="lblTelefono" runat="server"></asp:label></TD>
															<TD class="text" width="50%" colSpan="2"><STRONG>Localidad:&nbsp;</STRONG>
																<asp:label id="lblLocalidadEmpresa" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="text" width="100%" colSpan="4">&nbsp;
															</TD>
														</TR>
													</TABLE>
												</asp:panel>
											</TD>
										</TR>
										<TR>
											<TD class="text" width="100%" colSpan="3"><img src="/img/shim.gif" width="1" height="15"></TD>
										</TR>
										<TR>
											<TD class="text" width="100%">
												<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
													cellPadding="3" width="100%" border="1" height="80">
													<TR>
														<TD valign="top"><STRONG>&nbsp;Observaciones:</STRONG>&nbsp;&nbsp;<asp:label id="lblObservaciones" runat="server"></asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD class="text" width="100%" colSpan="4"><BR>
												<BR>
												<BR>
												<BR>
												<BR>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="4"><BR>
									<FONT size="1">&nbsp;Este informe es confidencial y solo puede ser usado para la 
										evaluación y otorgamiento de créditos o celebración de negocios. Esta prohibida 
										su reproducción, divulgación y entrega a terceros.<BR>
										&nbsp;No significa emitir juicio de valor sobre las personas ni sobre su 
										solvencia. Las <U>decisiones a las que arribe el usuario son de su exclusiva 
											responsabilidad.</U></FONT>
									<HR>
								</TD>
							</TR>
						</TABLE>
						<BR>
					</td>
				</tr>
				<tr>
					<td width="100%" colSpan="2"></td>
				</tr>
			</TABLE>
			<input id="idEncabezado" type="hidden" name="idEncabezado" runat="server"> <input id="idReferencia" type="hidden" name="idReferencia" runat="server">
		</form>
	</body>
</HTML>
