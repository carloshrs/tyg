<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Automotores.verInforme" CodeFile="VerInforme.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Informe Automotores y Motovehículos</title>
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
				<TR>
					<TD class="title" width="100%"><TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<td><IMG alt="" src="/img/logo-20-anios.png" width="264"></td>
								<TD class="title" width="100%" align="right">
									<table width="330" cellpadding="0" cellspacing="0" border="0">
<tr>
<td width="16"><img src="/Img/rounded1.gif" width="16" height="16" border="0"></td>
<td width="168" style="background-image: url('/Img/back1.gif');"><img src="/Img/shim.gif" width="1" height="16" border="0"/></td>
<td width="16"><img src="/Img/rounded2.gif" width="16" height="16" border="0"></td>
</tr>

<tr>
<td style="background-image: url('/Img/back4.gif');"><img src="/Img/shim.gif" width="16" height="1" border="0" /></td>
<td class="title" width="100%" align="center"><FONT color="#32528e">Informe Automotores y Motovehículos</FONT></td>
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
						</TD>
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
												<asp:label id="lblSolicitante" runat="server" Font-Bold="True"></asp:label><br />
												&nbsp;Dirección: <asp:label id="lblDireccionSolicitante" runat="server" Font-Size="9"></asp:label>
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
									Numero:
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
								<TD width="100%" colSpan="4"></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="4">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="text" width="100%" colspan="4">
												<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD width="99%" colspan="3">
															<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; 
																		Datos Informe</TD>
																</TR>
															</TABLE>
														</TD>
													<TR>
														<TD width="100%" class="title"><font color="#000000"><STRONG>Dominio:</STRONG>&nbsp;
																<asp:label id="lblDominio" runat="server"></asp:label></font>
														</TD>
													</TR>
													<TR>
														<TD width="99%" colspan="3">&nbsp;</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<tr>
											<td colspan="4">
												<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD width="100%" colSpan="4">
															<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; 
																		Información del Registro</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="text" width="100%" colSpan="4"><STRONG>Registro Número:</STRONG>
															<asp:label id="lblRegistro" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="50%" colSpan="2"><STRONG>Calle:</STRONG>
															<asp:label id="lblCalleRegistro" runat="server"></asp:label></TD>
														<TD class="text" width="50%" colSpan="2"><STRONG>Barrio:</STRONG>&nbsp;
															<asp:label id="lblBarrioRegistro" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="25%"><STRONG>Nro:</STRONG>
															<asp:label id="lblNroRegistro" runat="server"></asp:label></TD>
														<TD class="text" width="25%"><STRONG>Piso:</STRONG>
															<asp:label id="lblpisoRegistro" runat="server"></asp:label></TD>
														<TD class="text" width="25%"><STRONG>Depto.:</STRONG>
															<asp:label id="lblDptoRegistro" runat="server"></asp:label></TD>
														<TD class="text" width="25%"><STRONG>C.P.:</STRONG>
															<asp:label id="lblCPRegistro" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="50%" colSpan="2"><STRONG>Provincia:&nbsp;&nbsp; </STRONG>
															<asp:label id="lblProvinciaRegistro" runat="server"></asp:label></TD>
														<TD class="text" width="50%" colSpan="2"><STRONG>Localidad:&nbsp; </STRONG>
															<asp:label id="lblLocalidadRegistro" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="535" colSpan="4">&nbsp;</TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<TR>
											
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="text" width="100%">
									<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; 
												Titulares del automotor</TD>
										</TR>
									</TABLE>
									</TD>
							</TR>
							<TR>
								<TD class="text" width="100%">
									
									<asp:DataList ID="dlTitulares" runat="server" ShowFooter="False" 
                                        ShowHeader="False"  style="float:left; width:100%;">
                                        <ItemTemplate>
                                        <asp:Label ID="lblTipoPersona" runat="server" Text='<%# Eval("idTipoPersona") %>' Visible="false"></asp:Label>
                                            <asp:panel id="pnlFisica" runat="server">
                                              
                                                    <TABLE class=text style="BORDER-COLLAPSE: collapse; margin-bottom:6px;" 
                                              borderColor=#111111 cellSpacing=0 cellPadding=3 width="100%" 
                                              border=1>
                                                <TR>
                                                  <TD width="33%" colSpan=2><STRONG>Nombre y apellido:</STRONG>&nbsp; 
                            <asp:label id=lblNombre runat="server" Text='<%# Eval("Nombre") %>'></asp:label></TD>
                                                  <TD class=text width="33%"><STRONG>Tipo y nº 
                                                    documento:&nbsp;</STRONG> 
                                                        <asp:label id=lblDocumento runat="server" Text='<%# Eval("NroDoc") %>'></asp:label></TD>
                                                  <TD class=text width="33%"><STRONG>Estado 
                                                    civil:</STRONG> 
                            <asp:label id=lblEstadoCivil runat="server" Text='<%# Eval("EstadoCivil") %>'></asp:label></TD></TR>
                                                <TR>
                                                  <TD class=text width="50%" 
                                                    colSpan=2><STRONG>Calle:</STRONG> 
                            <asp:label id=lblCalle runat="server" Text='<%# Eval("calle") %>'></asp:label></TD>
                                                  <TD class=text width="50%" 
                                                    colSpan=2><STRONG>Barrio:</STRONG>&nbsp; 
                            <asp:label id=lblBarrio runat="server" Text='<%# Eval("barrio") %>'></asp:label></TD></TR>
                                                <TR>
                                                  <TD class=text width="25%"><STRONG>Nro:</STRONG> 
                            <asp:label id=lblNro runat="server" Text='<%# Eval("callenro") %>'></asp:label></TD>
                                                  <TD class=text width="25%"><STRONG>Piso:</STRONG> 
                            <asp:label id=lblPiso runat="server"></asp:label></TD>
                                                  <TD class=text width="25%"><STRONG>Depto.:</STRONG> 
                            <asp:label id=lblDepto runat="server" Text='<%# Eval("depto") %>'></asp:label></TD>
                                                  <TD class=text width="25%"><STRONG>C.P.:</STRONG> 
                            <asp:label id=lblCP runat="server" Text='<%# Eval("cp") %>'></asp:label></TD></TR>
                                                <TR>
                                                  <TD class=text width="50%" 
                                                    colSpan=2><STRONG>Provincia:&nbsp;&nbsp; </STRONG>
                            <asp:label id=lblProvincia runat="server"></asp:label></TD>
                                                  <TD class=text width="50%" 
                                                    colSpan=2><STRONG>Localidad:&nbsp; </STRONG>
                            <asp:label id=lblLocalidad runat="server"></asp:label></TD></TR>
                                                <TR>
                                                  <TD class=text width=535 
                                              colSpan=4>&nbsp;<STRONG>Porcentaje:</STRONG>&nbsp; 
                            <asp:label id=lblPorcentaje runat="server" Text='<%# Eval("Porcentaje") %>'></asp:label></TD></TR></TABLE>
												                            </asp:panel>
												                            <asp:panel id="pnlJuridica" runat="server">
                                                    <TABLE class=text style="BORDER-COLLAPSE: collapse; margin-bottom:6px;" 
                                              borderColor=#111111 cellSpacing=0 cellPadding=3 width="100%" 
                                              border=1>
                                                <TR>
                                                  <TD class=text width=360 colSpan=2><STRONG>Razón 
                                                    Social:</STRONG> 
                            <asp:label id=lblRazonSocial runat="server" Text='<%# Eval("razonsocial") %>'></asp:label></TD>
                                                  <TD class=text width="50%" colSpan=2><STRONG>Nombre de 
                                                    fantasia:</STRONG>&nbsp; 
                            <asp:label id=lblNombreFantasia runat="server" Text='<%# Eval("nombrefantasia") %>'></asp:label></TD></TR>
                                                <TR>
                                                  <TD class=text width=360 
                                                    colSpan=2><STRONG>Rubro:&nbsp;</STRONG> 
                            <asp:label id=lblRubro runat="server" Text='<%# Eval("rubro") %>'></asp:label></TD>
                                                  <TD class=text width="50%" 
                                                    colSpan=2><STRONG>CUIT:&nbsp;</STRONG> 
                            <asp:label id=lblCUIT runat="server" Text='<%# Eval("cuit") %>'></asp:label></TD></TR>
                                                <TR>
                                                  <TD class=text width=360 
                                                    colSpan=2><STRONG>Calle:&nbsp;</STRONG> 
                            <asp:label id=lblCalleEmpresa runat="server" Text='<%# Eval("calleempresa") %>'></asp:label></TD>
                                                  <TD class=text width="50%" 
                                                    colSpan=2><STRONG>Barrio:&nbsp;</STRONG> 
                            <asp:label id=lblBarrioEmpresa runat="server" Text='<%# Eval("barrioempresa") %>'></asp:label></TD></TR>
                                                <TR>
                                                  <TD class=text width=160><STRONG>Nro:</STRONG> 
                            <asp:label id=lblNroEmpresa runat="server" Text='<%# Eval("nroempresa") %>'></asp:label></TD>
                                                  <TD class=text width=209><STRONG>Piso:</STRONG> 
                            <asp:label id=lblPisoEmpresa runat="server" Text='<%# Eval("pisoempresa") %>'></asp:label></TD>
                                                  <TD class=text width="25%"><STRONG>Depto.:</STRONG> 
                            <asp:label id=lblDeptoEmpresa runat="server" Text='<%# Eval("dptoempresa") %>'></asp:label></TD>
                                                  <TD class=text width="25%"><STRONG>C.P.:</STRONG> 
                            <asp:label id=lblCPEmpresa runat="server" Text='<%# Eval("cpempresa") %>'></asp:label></TD></TR>
                                                <TR>
                                                  <TD class=text width=360 
                                                    colSpan=2><STRONG>Teléfono:&nbsp;</STRONG> 
                            <asp:label id=lblTelefono runat="server" Text='<%# Eval("telefonoempresa") %>'></asp:label></TD>
                                                  <TD class=text width="50%" 
                                                    colSpan=2><STRONG>Provincia:&nbsp;</STRONG> 
                            <asp:label id=lblProvinciaEmpresa runat="server"></asp:label></TD></TR>
                                                <TR>
                                                  <TD class=text width="100%" colSpan=4>&nbsp;<STRONG>Porcentaje:</STRONG>&nbsp; 
                            <asp:label id=Label1 runat="server" Text='<%# Eval("Porcentaje") %>'></asp:label>
                                                </TD></TR></TABLE>
							                      </asp:panel>
                                        </ItemTemplate>
                                    </asp:DataList>
									</TD>
							</TR>
							<TR>
								
								
								<TD class="text" width="100%" colspan="4">
												<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD width="99%" colspan="4">
															<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; 
																		Datos Vehículo</TD>
																</TR>
															</TABLE>
														</TD>
													<TR>
														<TD width="33%"><STRONG>Marca:</STRONG>&nbsp;
															<asp:label id="lblMarca" runat="server"></asp:label></TD>
														<TD class="text" width="33%"><STRONG>Modelo:&nbsp;</STRONG>
															<asp:label id="lblModelo" runat="server"></asp:label></TD>
														<TD class="text" width="33%"><STRONG>Año:</STRONG>
															<asp:label id="lblAno" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="50%" colSpan="2"><STRONG>Número de Chasis:</STRONG>
															<asp:label id="lblNroChasis" runat="server"></asp:label></TD>
														<TD class="text" width="50%" colSpan="2"><STRONG>Número de Motor:</STRONG>&nbsp;
															<asp:label id="lblNroMotor" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="535" colSpan="4">&nbsp;</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
								
								

							<TR>
								<TD class="text" width="100%">
									<TABLE class="text" id="Table3" style="BORDER-COLLAPSE: collapse" borderColor="#111111"
										height="80" cellSpacing="0" cellPadding="3" width="100%" border="1">
										<TR>
											<TD vAlign="top"><STRONG>&nbsp;Gravámenes y Restricciones:</STRONG>&nbsp;&nbsp;
												<asp:label id="lblGravamenes" runat="server"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="text" width="100%">
									<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
										cellPadding="3" width="100%" border="1" height="80">
										<TR>
											<TD valign="top"><STRONG>&nbsp;Datos Negativos del Titular:</STRONG>&nbsp;&nbsp;<asp:label id="lblDatosNegativos" runat="server"></asp:label></TD>
										</TR>
									</TABLE>
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
							<TR>
								<TD class="text" width="100%">
									<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
										cellPadding="3" width="100%" border="1" height="80">
										<TR>
											<TD valign="top"><STRONG>&nbsp;Resultados:</STRONG>&nbsp;&nbsp;<asp:label id="lblResultados" runat="server"></asp:label></TD>
										</TR>
										<tr><td>
										<table id="Table16" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="0"
													cellPadding="3" width="100%" border="0">
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
										    </td></tr>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="4"><div style="font-size:10px; margin-top:9px; line-height:1.5">
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
