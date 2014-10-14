<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.VerifDomLaboral.verInformeCalle" CodeFile="VerInformeCalle.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Verificación de Domicilio Laboral</title>
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
							<input type="image" src="/img/imprimir-2.gif" onclick="panel.style.visibility='hidden';window.print();panel.style.visibility='visible';" title="Imprimir">
							<input type="image" src="/img/log_off.gif" onclick="window.close();window.opener.location.href=window.opener.location;" title="Cerrar">
						</div>
					</td>
				</tr>
			</TABLE>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<td><IMG alt="" src="/img/logo-20-anios-impr.png" height"69></td>
					<TD class="title" width="100%">
						<P align="center"><FONT color=gray>Verificación de 
      Domicilio Laboral</FONT></P>
					</TD>
				</TR>
				<tr>
					<td colspan="2">
						<TABLE cellSpacing="0" cellPadding="0" style="BORDER-COLLAPSE: collapse" borderColor="#000000" width="100%" border="1">
							<tr>
								<td class="text" align="left" width="85%">
									<table cellpadding="0" cellspacing="0" border="0" width="100%">
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
											<td colspan="2" class="text">
												&nbsp;Referencia:
												<asp:label id="lblRef" runat="server" Font-Bold="True"></asp:label>
											</td>
										</tr>
									</table>
								</td>
								<td class="text" align="left" width="15%">
									&nbsp;Numero:
<asp:label id=lblNum runat="server" Font-Bold="True"></asp:label>
								</td>
							</tr>
						</TABLE>
					</td>
				</tr>
  <TR>
					<td class="title" width="100%" colSpan="2">
						<HR>
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="100%">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="text" width="100%">
												<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD width="99%" colspan="3">
															<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;<FONT color=gray>&nbsp; 
                              Datos Personales</FONT></TD>
																</TR>
															</TABLE>
														</TD>
													<TR>
														<TD width="33%" vAlign=top><STRONG>Apellido y nombre:</STRONG>&nbsp;<BR>
															<asp:label id="lblApellido" runat="server"></asp:label>,
															<asp:label id="lblNombre" runat="server"></asp:label></TD>
														<TD class="text" width="33%" vAlign=top><STRONG>Tipo y nº documento:&nbsp;</STRONG>
															<BR>
															<asp:label id="lblTipoDocumento" runat="server"></asp:label>&nbsp;
															<asp:label id="lblDocumento" runat="server"></asp:label></TD>
														<TD class="text" width="33%" vAlign=top><STRONG>Estado civil:</STRONG>
															<BR>
															<asp:label id="lblEstadoCivil" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD width="99%" colspan="3">&nbsp;</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD class="text" width="100%">
												<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD width="100%" colSpan="4">
															<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; <FONT 
                              color=gray>Datos de la 
                        empresa</FONT></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="text" width="360" colSpan="2"><STRONG>Razón Social:</STRONG>
															<BR>
															<asp:label id="lblRazonSocial" runat="server"></asp:label></TD>
														<TD class="text" width="50%" colSpan="2"><STRONG>Nombre de fantasia:</STRONG>&nbsp;<BR>
															<asp:label id="lblNombreFantasia" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="360" colSpan="2"><STRONG>Rubro:&nbsp;</STRONG>
															<BR>
															<asp:label id="lblRubro" runat="server"></asp:label></TD>
														<TD class="text" width="50%" colSpan="2"><STRONG>CUIT:&nbsp;</STRONG>
															<BR>
															<asp:label id="lblCUIT" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="360" colSpan="2"><STRONG>Calle:&nbsp;</STRONG>
															<BR>
															<asp:label id="lblCalle" runat="server"></asp:label></TD>
														<TD class="text" width="50%" colSpan="2"><STRONG>Barrio:&nbsp;</STRONG>
															<BR>
															<asp:label id="lblBarrio" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="160"><STRONG>Nro:</STRONG>
															<asp:label id="lblNro" runat="server"></asp:label></TD>
														<TD class="text" width="209"><STRONG>Piso:</STRONG>
															<asp:label id="lblPiso" runat="server"></asp:label></TD>
														<TD class="text" width="25%"><STRONG>Depto.:</STRONG>
															<asp:label id="lblDpto" runat="server"></asp:label></TD>
														<TD class="text" width="25%"><STRONG>C.P.:</STRONG>
															<asp:label id="lblCP" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="360" colSpan="2"><STRONG>Teléfono:&nbsp;</STRONG>
															<asp:label id="lblTelefono" runat="server"></asp:label></TD>
														<TD class="text" width="50%" colSpan="2"><STRONG>Localidad:&nbsp;</STRONG>
															<asp:label id="lblLocalidad" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="100%" colSpan="4">&nbsp;
														</TD>
													</TR>
													<tr>
														<td colSpan="4">
															<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; <FONT 
                              color=gray> Empresa donde 
                          trabaja</FONT></TD>
																</TR>
															</TABLE>
														</td>
													</tr>
													<tr>
														<td width="359" colSpan="2"><STRONG>Fecha:</STRONG><BR>
<asp:Label id=lblFecha runat="server"></asp:Label></td>
														<td width="50%" colSpan="2"><STRONG>Trabaja en lugar 
                        declarado:</STRONG><BR>
<asp:label id=lblLugarDeclarado runat="server"></asp:label></td>
													</tr>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD>
												<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD width="33%"><STRONG>Ocupación:&nbsp;</STRONG> 
                        <BR>
<asp:label id=lblOcupacion runat="server"></asp:label>
														<TD class="text" width="33%"><STRONG>Cargo:&nbsp;&nbsp; 
                        </STRONG>&nbsp;<BR>
<asp:label id=lblCargo runat="server"></asp:label></TD>
														<TD class="text" width="33%"><STRONG>Antiguedad:</STRONG><BR>
<asp:Label id=lblAntiguedad runat="server"></asp:Label></TD>
													</TR>
													<TR>
														<TD class="text" width="33%"><STRONG>Empleado permanente:<BR>
															</STRONG>
															<asp:label id="lblPermanente" runat="server"></asp:label></TD>
														<TD class="text" width="33%"><STRONG>Empleado contratado:<BR>
															</STRONG>
															<asp:label id="lblContratado" runat="server"></asp:label></TD>
														<TD class="text" width="33%"><STRONG>Fecha 
                        finalización:</STRONG><BR>
<asp:Label id=lblFechaFinalizacion runat="server"></asp:Label></TD>
													</TR>
													<TR>
														<TD class="text" width="33%"><STRONG>Sueldo:<BR>
															</STRONG>
															<asp:label id="lblSueldo" runat="server"></asp:label></TD>
														<TD class="text" width="33%"><STRONG>Embargos en el 
                        sueldo:</STRONG><BR>
<asp:label id=lblEmbargos runat="server"></asp:label></TD>
														<TD class="text" width="33%"><STRONG>A favor de:</STRONG><BR>
<asp:label id=lblAFavor runat="server"></asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<tr>
											<td>
												<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD width="50%"><STRONG>Informó:&nbsp; </STRONG>
															<BR>
															<asp:Label id="lblInformo" runat="server"></asp:Label></TD>
														<TD width="50%"><STRONG>Cargo o relación:&nbsp; </STRONG>
															<BR>
															<asp:Label id="lblCargoInformo" runat="server"></asp:Label></TD>
													</TR>
													<tr>
														<TD width="50%" vAlign=top><STRONG>Ubicación:</STRONG><BR>
<asp:Label id=lblUbicacion runat="server"></asp:Label></TD>
														<td width="50%" vAlign=top><STRONG>Zona:&nbsp;</STRONG>
															<BR>
<asp:Label id=lblCaractZona runat="server"></asp:Label></td>
													</tr>
												</TABLE>
											</td>
										</tr>
										<tr>
											<td>
												<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<tr>
														<td colSpan="3">
															<TABLE id="Table13" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; <FONT 
                              color=gray>Referencia 
                        vecinal</FONT></TD>
																</TR>
															</TABLE>
														</td>
													</tr>
													<TR>
														<TD class="text" width="33%" vAlign=top height=40><STRONG>Apellido y nombre:<BR>
															</STRONG>
															<asp:label id="lblNombreVecino" runat="server"></asp:label></TD>
														<TD class="text" width="33%" vAlign=top height=40><STRONG>Domicilio:<BR>
															</STRONG>
															<asp:label id="lblDomicilioVecino" runat="server"></asp:label></TD>
														<TD class="text" width="33%" vAlign=top height=40><STRONG>Conoce:<BR>
															</STRONG>
															<asp:label id="lblConoceVecino" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<td colSpan="3" vAlign=top height=60><STRONG>Observaciones:</STRONG>
															<BR>
															<asp:label id="lblObservaciones" runat="server"></asp:label></td>
													</TR>
												</TABLE>
                  <P align=center>
<asp:Label id=lblConFoto runat="server" Font-Bold="True" Font-Italic="True" Visible="False" Font-Size="X-Small">Sacar fotos al domicilio laboral</asp:Label></P>
											</td>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD width="100%">
									<HR>
								</TD>
							</TR>
						</TABLE>
						<BR>
					</td></TR>
				<tr>
					<td width="100%" colSpan="2"></td>
				</tr>
			</TABLE>
			<input id="idEncabezado" type="hidden" name="idEncabezado" runat="server"> <input id="idReferencia" type="hidden" name="idReferencia" runat="server">
		</form>
	</body>
</HTML>
