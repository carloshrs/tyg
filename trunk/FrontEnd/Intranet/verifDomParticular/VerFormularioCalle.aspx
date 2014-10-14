<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.VerifDomParticular.VerFormularioCalle" CodeFile="VerFormularioCalle.aspx.cs" %>
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
					ToggleImg(name, 'Cerrar.gif', 'Cerrar M�s Info');
				} 
				else 
				{
					masInfo.style.display = "none";
					ToggleImg(name, 'Arrow.gif', 'M�s Info');
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
							<input type="image" src="/img/imprimir-2.gif" onclick="panel.style.visibility='hidden';window.print();panel.style.visibility='visible';">
							<input type="image" src="/img/log_off.gif" onclick="window.close();">
						</div>
					</td>
				</tr>
			</TABLE>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<td><IMG alt="" src="/img/logo-20-anios-impr.png" height"69></td>
					<TD class="title" width="100%"><FONT color="#ffffff">
							<P align="center">
						</FONT><FONT color="gray">Verificaci�n de Domicilio Particular </FONT></P></TD>
				</TR>
				<tr>
					<td colspan="2">
						<TABLE cellSpacing="0" cellPadding="0" style="BORDER-COLLAPSE: collapse" borderColor="#000000"
							width="100%" border="1">
							<tr>
								<td class="text" align="left" width="85%">
									<table cellpadding="0" cellspacing="0" border="0" width="100%">
										<tr>
											<td class="text">
												Solicitado por:
												<asp:label id="lblSolicitante" runat="server" Font-Bold="True"></asp:label>
											</td>
											<td class="text">
												Fecha:
												<asp:label id="lblFec" runat="server" Font-Bold="True"></asp:label>
											</td>
										</tr>
										<tr>
											<td colspan="2" class="text">
												Referencia:
												<asp:label id="lblRef" runat="server" Font-Bold="True"></asp:label>
											</td>
										</tr>
									</table>
								</td>
								<td class="text" align="right" width="15%">
									Numero:<br>
									<asp:label id="lblNum" runat="server" Font-Bold="True"></asp:label>
								</td>
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
											<TD class="text" width="100%" colspan="4">
												<asp:panel id="pnlFisica" runat="server">
													<TABLE class="text" id="Table3" style="BORDER-COLLAPSE: collapse" borderColor="#111111"
														cellSpacing="0" cellPadding="3" width="100%" border="1">
														<TR>
															<TD width="99%" colSpan="4">
																<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;
																			<FONT color="gray">Persona F�sica</FONT></TD>
																	</TR>
																</TABLE>
															</TD>
														<TR>
															<TD vAlign="top" width="25%"><STRONG>Apellido y nombre:</STRONG>&nbsp;
																<asp:label id="lblApellido" runat="server"></asp:label>,
																<asp:label id="lblNombre" runat="server"></asp:label></TD>
															<TD class="text" vAlign="top" width="25%"><STRONG>Tipo y n� documento:&nbsp;</STRONG>
																<asp:label id="lblTipoDocumento" runat="server"></asp:label>&nbsp;
																<asp:label id="lblDocumento" runat="server"></asp:label></TD>
															<TD class="text" vAlign="top" width="25%"><STRONG>Estado civil:</STRONG>
																<asp:label id="lblEstadoCivil" runat="server"></asp:label></TD>
															<TD class="text" vAlign="top" width="25%"><STRONG>Resultado</STRONG>
																<asp:label id="lblResultado" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD vAlign="top" width="100%" colSpan="4"><STRONG>Observaciones:</STRONG>
																<asp:label id="Label1" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD width="99%" colSpan="4">&nbsp;</TD>
														</TR>
													</TABLE>
													<TABLE class="text" id="Table7" style="BORDER-COLLAPSE: collapse" borderColor="#111111"
														cellSpacing="0" cellPadding="3" width="100%" border="1">
														<TR>
															<TD width="100%" colSpan="4">
																<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;
																			<FONT color="gray">Domicilio particular</FONT></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="text" width="50%" colSpan="2"><STRONG>Calle:</STRONG>
																<asp:label id="lblCalle" runat="server"></asp:label></TD>
															<TD class="text" width="50%" colSpan="2"><STRONG>Barrio:</STRONG>&nbsp;
																<asp:label id="lblBarrio" runat="server"></asp:label></TD>
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
															<TD class="text" width="50%" colSpan="2"><STRONG>Tel�fono:&nbsp;&nbsp; </STRONG>
																<asp:label id="lblTelefono" runat="server"></asp:label></TD>
															<TD class="text" width="50%" colSpan="2"><STRONG>Localidad:&nbsp; </STRONG>
																<asp:label id="lblLocalidad" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="text" width="535" colSpan="4">&nbsp;</TD>
														</TR>
														<TR>
															<TD colSpan="4"></TD>
														</TR>
													</TABLE>
												</asp:panel>
												<asp:panel id="pnlJuridica" runat="server">
													<TABLE class="text" id="Table8" style="BORDER-COLLAPSE: collapse" borderColor="#111111"
														cellSpacing="0" cellPadding="3" width="100%" border="1">
														<TR>
															<TD width="100%" colSpan="4">
																<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;
																			<FONT color="gray">Persona Jur�dica</FONT></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="text" width="360" colSpan="2"><STRONG>Raz�n Social:</STRONG>
																<asp:label id="lblRazonSocial" runat="server"></asp:label><BR>
															</TD>
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
																<asp:label id="Label8" runat="server"></asp:label></TD>
															<TD class="text" width="50%" colSpan="2"><STRONG>Barrio:&nbsp;</STRONG>
																<asp:label id="Label7" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="text" width="160"><STRONG>Nro:</STRONG>
																<asp:label id="Label6" runat="server"></asp:label></TD>
															<TD class="text" width="209"><STRONG>Piso:</STRONG>
																<asp:label id="Label5" runat="server"></asp:label></TD>
															<TD class="text" width="25%"><STRONG>Depto.:</STRONG>
																<asp:label id="lblDpto" runat="server"></asp:label></TD>
															<TD class="text" width="25%"><STRONG>C.P.:</STRONG>
																<asp:label id="Label4" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="text" width="360" colSpan="2"><STRONG>Tel�fono:&nbsp;</STRONG>
																<asp:label id="Label3" runat="server"></asp:label></TD>
															<TD class="text" width="50%" colSpan="2"><STRONG>Localidad:&nbsp;</STRONG>
																<asp:label id="Label2" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="text" width="100%" colSpan="4">&nbsp;
															</TD>
														</TR>
													</TABLE>
												</asp:panel>
											</TD>
										</TR>
										<tr>
											<td colspan="4">
												<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;
															<FONT color="gray">Gesti�n sobre la verificaci�n</FONT></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="text" width="100%" colSpan="4">
									<TABLE borderColor="#111111" cellSpacing="0" cellPadding="3" width="100%" border="0">
										<TR>
											<TD class="text" width="25%"><STRONG>Fecha:</STRONG>
												<BR>
												<asp:label id="lblFecha" runat="server"></asp:label></TD>
											<TD class="text" width="30%"><STRONG>Habita en lugar declarado:</STRONG>
												<BR>
												<asp:label id="lblHabita" runat="server"></asp:label></TD>
											<TD class="text" width="25%"><STRONG>Antiguedad:</STRONG>
												<BR>
												<asp:label id="lblAntiguedad" runat="server"></asp:label></TD>
											<TD class="text" width="25%"><STRONG>Tel. alternativo:</STRONG>
												<BR>
												<asp:label id="lblTelefonoAlt" runat="server"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="text" width="100%" colSpan="4">
									<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
										cellPadding="3" width="100%" border="1">
										<TR>
											<TD class="text" width="33%">
												<P><STRONG>Monto alquiler:</STRONG><BR>
													<asp:label id="lblMonto" runat="server"></asp:label></P>
											</TD>
											<TD class="text" width="33%"><STRONG>Vencimiento de contrato</STRONG><BR>
												<asp:label id="lblVencimiento" runat="server"></asp:label></TD>
											<TD class="text" width="33%" colSpan="2"><STRONG>Enviar correspondencia a:</STRONG><BR>
												<asp:label id="lblEnviar" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD width="33%">&nbsp;<STRONG>Tipo de vivienda:</STRONG>
												<BR>
												<asp:label id="lblTipoVivienda" runat="server"></asp:label></TD>
											<TD width="33%"><STRONG>Estado de conservaci�n:</STRONG>
												<BR>
												<asp:label id="lblEstadoConservacion" runat="server"></asp:label></TD>
											<TD width="33%" colSpan="2"><STRONG>Tipo de construcci�n:</STRONG>
												<BR>
												<asp:label id="lblTipoConstruccion" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD height="14"><STRONG>Tipo de Zona:</STRONG>
												<BR>
												<asp:label id="lblTipoZona" runat="server"></asp:label></TD>
											<TD height="14"><STRONG>Tipo de calle:</STRONG>
												<BR>
												<asp:label id="lblTipoCalle" runat="server"></asp:label></TD>
											<TD colSpan="2" height="14"><STRONG>Interesado:</STRONG>
												<BR>
												<asp:label id="lblInteresado" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="text" width="33%"><STRONG>Acceso al domicilio:&nbsp;</STRONG>
												<BR>
												<asp:label id="lblAccesoDomicilio" runat="server"></asp:label></TD>
											<TD class="text" width="33%"><STRONG>Inform�:&nbsp;</STRONG><BR>
												<asp:label id="lblInformo" runat="server"></asp:label></TD>
											<TD class="text" width="33%" colSpan="2"><STRONG>Relaci�n:&nbsp;<BR>
												</STRONG>
												<asp:label id="lblRelacion" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="text" width="33%" colSpan="4">&nbsp;</TD>
										</TR>
										<TR>
											<TD colSpan="4">
												<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;
															<FONT color="gray">Referencia vecinal</FONT></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD class="text"><STRONG>Apellido y nombre:</STRONG>
												<BR>
												<asp:label id="lblNombreVecino" runat="server"></asp:label></TD>
											<TD class="text"><STRONG>Domicilio</STRONG>
												<BR>
												<asp:label id="lblDomicilioVecino" runat="server"></asp:label></TD>
											<TD class="text" colSpan="2"><STRONG>Conoce del funcionamiento</STRONG>
												<BR>
												<asp:label id="lblConoceVecino" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="text" width="100%" colSpan="4"><STRONG>Observaciones:</STRONG>
												<BR>
												<asp:label id="lblObservaciones" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="text" colSpan="4">&nbsp;<BR>
												<STRONG>Plano de&nbsp;ubicaci�n:</STRONG></TD>
										</TR>
										<TR>
											<TD class="text" align="center">
												<P align="center"><IMG height="140" src="/img/plano_chico.gif" width="140" border="1">
												</P>
											</TD>
											<TD vAlign="top" colSpan="3">
												<TABLE class="text" id="Table13" cellSpacing="1" cellPadding="2">
													<TR>
														<TD>Ubicaci�n <B>A:</B></TD>
														<TD><asp:label id="lblPlanoA" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD>Ubicaci�n <B>B:</B></TD>
														<TD><asp:label id="lblPlanoB" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD>Ubicaci�n <B>C:</B></TD>
														<TD><asp:label id="lblPlanoC" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD>Ubicaci�n <B>D:</B></TD>
														<TD><asp:label id="lblPlanoD" runat="server"></asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="4"><div style="font-size:10px; margin-top:10px; line-height:1.5">
									Este informe es confidencial y solo puede ser usado para la 
										evaluaci�n y otorgamiento de cr�ditos o celebraci�n de negocios. Esta prohibida 
										su reproducci�n, divulgaci�n y entrega a terceros.<BR>
										No significa emitir juicio de valor sobre las personas ni sobre su 
										solvencia. Las <U>decisiones a las que arribe el usuario son de su exclusiva 
											responsabilidad.</U><br />
											www.tiempoygestion.com.ar &nbsp;&nbsp;//&nbsp;&nbsp; informes@tiempoygestion.com.ar
											</div></TD>
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
