<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.defuncion.verInforme" CodeFile="VerInforme.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Ver Informe</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
		<script type="text/javascript">
			function imprimir()
			{
			    panel.style.visibility='hidden';
			    window.print();
			    panel.style.visibility='visible';
			}
		</script>

	</HEAD>
	<body onload="imprimir();">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="title" width="100%"><TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<td><IMG alt="" src="/img/logo-20-anios.png" width="264"></td>
								<TD class="title" width="100%" align="right">
									<table width="310" cellpadding="0" cellspacing="0" border="0">
<tr>
<td width="16"><img src="/Img/rounded1.gif" width="16" height="16" border="0"></td>
<td width="168" style="background-image: url('/Img/back1.gif');"><img src="/Img/shim.gif" width="1" height="16" border="0"/></td>
<td width="16"><img src="/Img/rounded2.gif" width="16" height="16" border="0"></td>
</tr>

<tr>
<td style="background-image: url('/Img/back4.gif');"><img src="/Img/shim.gif" width="16" height="1" border="0" /></td>
<td class="title" width="100%" align="center"><FONT color="#32528e">Informe de Partida de Defunción</FONT></td>
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
						</TABLE></TD>
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
												<asp:label id="lblSolicitante" runat="server" Font-Bold="True"></asp:label><br />
												&nbsp;Dirección: <asp:label id="lblDireccionSolicitante" runat="server" Font-Size="9"></asp:label></td>
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
											<TD class="text" width="100%">
												<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD width="99%" colSpan="4">
															<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; 
																		Datos personales</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="text" width="50%"><STRONG>Nombre:</STRONG>&nbsp;
															<asp:label id="lblNombre" runat="server"></asp:label></TD>
														<TD class="text" width="50%"><STRONG>Apellido:</STRONG>
															<asp:label id="lblApellido" runat="server"></asp:label></TD>
													</TR>
                                                    <TR>
														<TD class="text" width="50%"><STRONG>DNI:</STRONG>&nbsp;
															<asp:label id="lblDNI" runat="server"></asp:label></TD>
														<TD class="text" width="50%"><STRONG>Sexo:</STRONG>
															<asp:label id="lblSexo" runat="server"></asp:label></TD>
													</TR>

                                                    <TR>
														<TD width="99%" colSpan="4">
															<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; 
																		Resultado de consulta en Tribunales Federales</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="text" width="50%" colspan="2"><STRONG>Fallecido/a:</STRONG>&nbsp;
															<asp:label id="lblFallecido" runat="server"></asp:label></TD>
													</TR>
                                                    <asp:Panel ID="pnlDetalle" runat="server">
                                                    <TR>
														<TD class="text" width="50%" colspan="2"><STRONG>Lugar de fallecimiento:</STRONG>&nbsp; <asp:label id="lblLugar" runat="server"></asp:label></TD>
													</TR>
                                                    <TR>
														<TD class="text" width="50%"><STRONG>Fecha fallecido:</STRONG>&nbsp;
															<asp:label id="lblFechaFallecido" runat="server"></asp:label></TD>
														<TD class="text" width="50%"><STRONG>Acta:</STRONG>
															<asp:label id="lblActa" runat="server"></asp:label></TD>
													</TR>
                                                    <TR>
														<TD class="text" width="50%"><STRONG>Tomo:</STRONG>&nbsp;
															<asp:label id="lblTomo" runat="server"></asp:label></TD>
														<TD class="text" width="50%"><STRONG>Folio:</STRONG>
															<asp:label id="lblFolio" runat="server"></asp:label></TD>
													</TR>
                                                    </asp:Panel>
												</TABLE>
												<BR>
											</TD>
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
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="text" width="100%" colSpan="4"><table id="Table16" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
                                                    <tr>
                                                        <td class="text" width="100%">
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
												</table>
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
			<BR>
			</TD></TR><tr>
				<td colSpan="2" width="100%"></td>
			</tr>
			</TABLE><input id="idEncabezado" type="hidden" name="idEncabezado" runat="server">
			<input id="idReferencia" type="hidden" name="idReferencia" runat="server">
		</form>
	</body>
</HTML>
