<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.VerifDomLaboral.verInforme" CodeFile="VerInforme.aspx.cs" %>
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

			function imprimir()
			{
			    panel.style.visibility='hidden';
			    window.print();
			    panel.style.visibility='visible';
			}

			</script>
	</HEAD>
	<body topmargin="0" leftmargin="0" onload="imprimir();">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td>
					<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<td><IMG alt="" src="/img/logo-20-anios.png" width="264"></td>
								<TD class="title" width="100%" align="right">
									<table width="300" cellpadding="0" cellspacing="0" border="0">
<tr>
<td width="16"><img src="/Img/rounded1.gif" width="16" height="16" border="0"></td>
<td width="168" style="background-image: url('/Img/back1.gif');"><img src="/Img/shim.gif" width="1" height="16" border="0"/></td>
<td width="16"><img src="/Img/rounded2.gif" width="16" height="16" border="0"></td>
</tr>

<tr>
<td style="background-image: url('/Img/back4.gif');"><img src="/Img/shim.gif" width="16" height="1" border="0" /></td>
<td class="title" width="100%" align="center"><FONT color="#32528e">Verificación de Domicilio Laboral</FONT></td>
<td style="background-image: url('/Img/back2.gif');"><img src="/Img/shim.gif" width="16" height="1" border="0"/></td>
</tr>

<tr>
<td><img src="/Img/rounded3.gif" width="16" height="16" border="0"></td>
<td style="background-image: url('/Img/back3.gif');"><img src="/Img/shim.gif" width="1" height="16" border="0" /></td>
<td><img src="/Img/rounded4.gif" width="16" height="16" border="0"></td>
</tr>
</table>

									</TD>
									<td valign="top"><div id="panel"><input onclick="window.close();" type="image" src="/img/log_off.gif" title="Cerrar">
								<input onclick="imprimir();" type="image" src="/img/imprimir-2.gif" title="Imprimir">
						</div></td>
							</TR>
						</TABLE>
						<TABLE cellSpacing="0" cellPadding="0" style="BORDER-COLLAPSE: collapse" borderColor="#000000"
							width="100%" border="1">
							<tr>
								<td class="text" align="left" width="85%">
									<table class="tablaInforme" cellpadding="0" cellspacing="0" border="0" width="100%">
										<tr>
											<td class="text" valign="top">
												&nbsp;Solicitado por:
												<asp:label id="lblSolicitante" runat="server" Font-Size="10" Font-Bold="True"></asp:label><br />
												&nbsp;Dirección: <asp:label id="lblDireccionSolicitante" runat="server" Font-Size="9"></asp:label>
											</td>
											<td class="text" valign="top">
												Fecha:
												<asp:label id="lblFec" runat="server" Font-Bold="True"></asp:label>
											</td>
										</tr>
										<tr>
											<td colspan="2" class="text" valign="top">
												&nbsp;Referencia:
												<asp:label id="lblRef" runat="server" Font-Bold="True"></asp:label>
											</td>
										</tr>
									</table>
								</td>
								<td class="text" align="left" width="15%" valign="top">
									&nbsp;Numero:
									<asp:label id="lblNum" runat="server" Font-Bold="True"></asp:label><br />
                                    &nbsp; <asp:label id="lblNroPagina1" runat="server" style="text-transform: none;"></asp:label>
								</td>
							</tr>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td class="title" width="100%">
						<TABLE class="tablaInforme" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
																	<TD class="title" width="100%" colSpan="3" height="30" style="text-align: center">&nbsp;&nbsp; 
																		DATOS PERSONALES</TD>
																</TR>
															</TABLE>
														</TD>
													<TR>
														<TD width="33%" valign="top"><STRONG>Apellido y nombre:</STRONG>&nbsp;<BR>
															<asp:label id="lblApellido" runat="server"></asp:label>,
															<asp:label id="lblNombre" runat="server"></asp:label></TD>
														<TD class="text" width="33%" valign="top"><STRONG>Tipo y nº documento:&nbsp;</STRONG>
															<BR>
															<asp:label id="lblTipoDocumento" runat="server"></asp:label>&nbsp;
															<asp:label id="lblDocumento" runat="server"></asp:label></TD>
														<TD class="text" width="33%" valign="top"><STRONG>Estado civil:</STRONG>
															<BR>
															<asp:label id="lblEstadoCivil" runat="server"></asp:label></TD>
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
																	<TD class="title" width="100%" colSpan="3" height="30" style="text-align: center">&nbsp;&nbsp; 
																		DATOS DE LA EMPRESA</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="text" width="360" colSpan="2" valign="top"><STRONG>Razón Social:</STRONG>
															<BR>
															<asp:label id="lblRazonSocial" runat="server"></asp:label></TD>
														<TD class="text" width="50%" colSpan="2" valign="top"><STRONG>Nombre de fantasia:</STRONG>&nbsp;<BR>
															<asp:label id="lblNombreFantasia" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="360" colSpan="2" valign="top"><STRONG>Rubro:&nbsp;</STRONG>
															<BR>
															<asp:label id="lblRubro" runat="server"></asp:label></TD>
														<TD class="text" width="50%" colSpan="2" valign="top"><STRONG>CUIT:&nbsp;</STRONG>
															<BR>
															<asp:label id="lblCUIT" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="360" colSpan="2" valign="top"><STRONG>Calle:&nbsp;</STRONG>
															<BR>
															<asp:label id="lblCalle" runat="server"></asp:label></TD>
														<TD class="text" width="50%" colSpan="2" valign="top"><STRONG>Barrio:&nbsp;</STRONG>
															<BR>
															<asp:label id="lblBarrio" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="160" valign="top"><STRONG>Nro:</STRONG>
															<asp:label id="lblNro" runat="server"></asp:label></TD>
														<TD class="text" width="209" valign="top"><STRONG>Piso:</STRONG>
															<asp:label id="lblPiso" runat="server"></asp:label></TD>
														<TD class="text" width="25%" valign="top"><STRONG>Depto.:</STRONG>
															<asp:label id="lblDpto" runat="server"></asp:label></TD>
														<TD class="text" width="25%" valign="top"><STRONG>C.P.:</STRONG>
															<asp:label id="lblCP" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="360" colSpan="2" valign="top"><STRONG>Teléfono:&nbsp;</STRONG>
															<asp:label id="lblTelefono" runat="server"></asp:label></TD>
														<TD class="text" width="50%" colSpan="2" valign="top"><STRONG>Localidad:&nbsp;</STRONG>
															<asp:label id="lblLocalidad" runat="server"></asp:label></TD>
													</TR>
													<tr>
														<td colSpan="4">
															<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" colSpan="3" height="30" style="text-align: center">
																		&nbsp;&nbsp; EMPRESA DONDE TRABAJA</TD>
																</TR>
															</TABLE>
														</td>
													</tr>
													<tr>
														<td width="359" colSpan="2" valign="top"><STRONG>Fecha:</STRONG><BR>
															<asp:Label id="lblFecha" runat="server"></asp:Label></td>
														<td width="50%" colSpan="2" valign="top"><STRONG>Trabaja en lugar declarado:</STRONG><BR>
															<asp:label id="lblLugarDeclarado" runat="server"></asp:label></td>
													</tr>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD>
												<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD width="33%" valign="top"><STRONG>Ocupación:&nbsp;</STRONG>
															<BR>
															<asp:label id="lblOcupacion" runat="server"></asp:label>
														<TD class="text" width="33%" valign="top"><STRONG>Cargo:&nbsp;&nbsp; </STRONG>&nbsp;<BR>
															<asp:label id="lblCargo" runat="server"></asp:label></TD>
														<TD class="text" width="33%" valign="top"><STRONG>Antiguedad:</STRONG><BR>
															<asp:Label id="lblAntiguedad" runat="server"></asp:Label></TD>
													</TR>
													<TR>
														<TD class="text" width="33%" valign="top"><STRONG>Empleado permanente:<BR>
															</STRONG>
															<asp:label id="lblPermanente" runat="server"></asp:label></TD>
														<TD class="text" width="33%" valign="top"><STRONG>Empleado contratado:<BR>
															</STRONG>
															<asp:label id="lblContratado" runat="server"></asp:label></TD>
														<TD class="text" width="33%" valign="top"><STRONG>Fecha finalización:</STRONG><BR>
															<asp:Label id="lblFechaFinalizacion" runat="server"></asp:Label></TD>
													</TR>
													<TR>
														<TD class="text" width="33%" valign="top"><STRONG>Sueldo:<BR>
															</STRONG>
															<asp:label id="lblSueldo" runat="server"></asp:label></TD>
														<TD class="text" width="33%" valign="top"><STRONG>Embargos en el sueldo:</STRONG><BR>
															<asp:label id="lblEmbargos" runat="server"></asp:label></TD>
														<TD class="text" width="33%" valign="top"><STRONG>A favor de:</STRONG><BR>
															<asp:label id="lblAFavor" runat="server"></asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<tr>
											<td>
												<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD width="50%" valign="top"><STRONG>Informó:&nbsp; </STRONG>
															<BR>
															<asp:Label id="lblInformo" runat="server"></asp:Label></TD>
														<TD width="50%" valign="top"><STRONG>Cargo o relación:&nbsp; </STRONG>
															<BR>
															<asp:Label id="lblCargoInformo" runat="server"></asp:Label></TD>
													</TR>
													<tr>
														<TD width="50%" valign="top"><STRONG>Ubicación:</STRONG><BR>
															<asp:Label id="lblUbicacion" runat="server"></asp:Label></TD>
														<td width="50%" valign="top"><STRONG>Zona:&nbsp;</STRONG>
															<BR>
															<asp:label id="lblZona" runat="server"></asp:label></td>
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
																	<TD class="title" width="100%" colSpan="3" height="30" style="text-align: center">&nbsp;&nbsp; 
																		REFERENCIA VECINAL</TD>
																</TR>
															</TABLE>
														</td>
													</tr>
													<TR>
														<TD class="text" width="33%" valign="top"><STRONG>Apellido y nombre:<BR>
															</STRONG>
															<asp:label id="lblNombreVecino" runat="server"></asp:label></TD>
														<TD class="text" width="33%" valign="top"><STRONG>Domicilio:<BR>
															</STRONG>
															<asp:label id="lblDomicilioVecino" runat="server"></asp:label></TD>
														<TD class="text" width="33%" valign="top"><STRONG>Conoce:<BR>
															</STRONG>
															<asp:label id="lblConoceVecino" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<td colSpan="3"><STRONG>Informes anteriores:</STRONG>
															<BR>
															<asp:label id="lblInformesAnteriores" runat="server"></asp:label></td>
													</TR>
													<TR>
														<td colSpan="3"><STRONG>Observaciones:</STRONG>
															<BR>
															<asp:label id="lblObservaciones" runat="server"></asp:label></td>
													</TR>
                                                    <tr>
                                                        <td class="text" width="100%" colspan="3">
                                                            <table width="260" align="right">
                                                                <tr>
                                                                    <td>
                                                                        <img src="/Img/firma_sariago.jpg" width="110" /></td>
                                                                    <td width="100%" align="center" >
                                                                    <FONT style="font-size:9px">
                                                                        ALEJANDRO SARIAGO<br />
                                                                        SOCIO GERENTE<br />
                                                                        TIEMPO &amp; GESTION S.R.L.<br />
                                                                        Mat. Jud. M.P. 01-1376</FONT></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
												</TABLE>
											</td>
										</tr>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
							<TR>
								<TD width="100%" colSpan="4"><div style="font-size:9px; margin-top:10px; line-height:1.5">
									Este informe es confidencial y solo puede ser usado para la 
										evaluación y otorgamiento de créditos o celebración de negocios. Esta prohibida 
										su reproducción, divulgación y entrega a terceros.<BR>
										No significa emitir juicio de valor sobre las personas ni sobre su 
										solvencia. Las <U>decisiones a las que arribe el usuario son de su exclusiva 
											responsabilidad.</U><br />
											www.tiempoygestion.com.ar &nbsp;&nbsp;//&nbsp;&nbsp; informes@tiempoygestion.com.ar
											</div></TD>
							</TR>

			</TABLE>
			<input id="idEncabezado" type="hidden" name="idEncabezado" runat="server"> <input id="idReferencia" type="hidden" name="idReferencia" runat="server">
            <asp:Panel ID="pnFotos" runat="server">
        <hr style="page-break-after:always; border:0px; height:0px;" />
        			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" class="tablaInforme">
				<TR>
								<td><IMG alt="" src="/img/logo-20-anios.png" width="264"></td>
								<TD class="title" width="100%" align="right">
									<table width="300" cellpadding="0" cellspacing="0" border="0">
<tr>
<td width="16"><img src="/Img/rounded1.gif" width="16" height="16" border="0"></td>
<td width="168" style="background-image: url('/Img/back1.gif');"><img src="/Img/shim.gif" width="1" height="16" border="0"/></td>
<td width="16"><img src="/Img/rounded2.gif" width="16" height="16" border="0"></td>
</tr>

<tr>
<td style="background-image: url('/Img/back4.gif');"><img src="/Img/shim.gif" width="16" height="1" border="0" /></td>
<td class="title" width="100%" align="center"><FONT color="#32528e">Verificación de Domicilio Laboral</FONT></td>
<td style="background-image: url('/Img/back2.gif');"><img src="/Img/shim.gif" width="16" height="1" border="0"/></td>
</tr>

<tr>
<td><img src="/Img/rounded3.gif" width="16" height="16" border="0"></td>
<td style="background-image: url('/Img/back3.gif');"><img src="/Img/shim.gif" width="1" height="16" border="0" /></td>
<td><img src="/Img/rounded4.gif" width="16" height="16" border="0"></td>
</tr>
</table>

									</TD>
									<td valign="top">&nbsp;</td>
				</TR>
				<tr>
					<td colspan="3">
						<TABLE cellSpacing="0" cellPadding="0" style="BORDER-COLLAPSE: collapse" borderColor="#000000"
							width="100%" border="1">
							<tr>
								<td class="text" align="left" width="85%">
									<table cellpadding="0" cellspacing="0" border="0" width="100%">
										<tr>
											<td class="text">
												&nbsp; Solicitado por:
												<asp:label id="lblSolicitanteCopy" runat="server" Font-Size="10" Font-Bold="True"></asp:label><br />
												&nbsp; Dirección: <asp:label id="lblDireccionSolicitanteCopy" runat="server" Font-Size="9"></asp:label>
											</td>
											<td class="text">
												Fecha:
												<asp:label id="lblFecCopy" runat="server" Font-Bold="True"></asp:label>
											</td>
										</tr>
										<tr>
											<td colspan="2" class="text">
												&nbsp; Referencia:
												<asp:label id="lblRefCopy" runat="server" Font-Bold="True"></asp:label>
											</td>
										</tr>
									</table>
								</td>
								<td class="text" align="left" width="15%">
									&nbsp; Numero:
									<asp:label id="lblNumCopy" runat="server" Font-Bold="True" Width="10"></asp:label><br />
                                    &nbsp; <asp:label id="lblNroPagina2" runat="server" style="text-transform: none;"></asp:label>
								</td>
							</tr>
                            <tr><td colspan="4">
            <table width="100%" cellpadding="0" cellspacing="0">
        							<tr>
								<td class="text" align="center" style="height:800px;">
									<asp:Image id="imgFoto" runat="server" Height="380" style="margin:15px"></asp:Image>
                                    <asp:Image id="imgFoto2" runat="server" Height="380" style="margin:15px"></asp:Image>
								</td>
					        </tr>
            </table></td></tr>
						</TABLE>
					</td>
				</tr>
                
							<TR>
								<TD width="100%" colspan="3" ><div style="font-size:9px; margin-top:10px; line-height:1.5">
									Este informe es confidencial y solo puede ser usado para la 
										evaluación y otorgamiento de créditos o celebración de negocios. Esta prohibida 
										su reproducción, divulgación y entrega a terceros.<BR>
										No significa emitir juicio de valor sobre las personas ni sobre su 
										solvencia. Las <U>decisiones a las que arribe el usuario son de su exclusiva 
											responsabilidad.</U><br />
											www.tiempoygestion.com.ar &nbsp;&nbsp;//&nbsp;&nbsp; informes@tiempoygestion.com.ar</div></TD>
							</TR>
			</TABLE>
        </asp:Panel>
		</form>
	</body>
</HTML>
