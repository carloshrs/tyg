<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Automotores.verInforme" CodeFile="VerInforme.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Informe Automotores y Motovehículos</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
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
					<td><IMG alt="" src="/img/logo-20-anios.png" width="264"></td>
					<TD class="title" width="100%"><FONT color="#ffffff">
							<P align="center"><FONT color="#32528e">Informe Automotores y Motovehículos</FONT>
						</FONT></P></TD>
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
														<TD colSpan="4">
															<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; 
																		Gestión sobre la verificación</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD width="99%" colspan="4">&nbsp;</TD>
													</TR>
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
											<TD class="text" width="100%" colspan="4">
												<asp:panel id="pnlFisica" runat="server">
													<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
														cellPadding="3" width="100%" border="1">
														<TR>
															<TD width="99%" colSpan="4">
																<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; 
																			Datos Titular</TD>
																	</TR>
																</TABLE>
															</TD>
														<TR>
															<TD width="33%" colSpan="2"><STRONG>Apellido y nombre:</STRONG>&nbsp;
																<asp:label id="lblApellido" runat="server"></asp:label>,
																<asp:label id="lblNombre" runat="server"></asp:label></TD>
															<TD class="text" width="33%"><STRONG>Tipo y nº documento:&nbsp;</STRONG>
																<asp:label id="lblTipoDocumento" runat="server"></asp:label>&nbsp;
																<asp:label id="lblDocumento" runat="server"></asp:label></TD>
															<TD class="text" width="33%"><STRONG>Estado civil:</STRONG>
																<asp:label id="lblEstadoCivil" runat="server"></asp:label></TD>
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
															<TD class="text" width="50%" colSpan="2"><STRONG>Provincia:&nbsp;&nbsp; </STRONG>
																<asp:label id="lblProvincia" runat="server"></asp:label></TD>
															<TD class="text" width="50%" colSpan="2"><STRONG>Localidad:&nbsp; </STRONG>
																<asp:label id="lblLocalidad" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="text" width="535" colSpan="4">&nbsp;</TD>
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
											<TD class="text" width="100%" colspan="4">
												<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD width="99%" colspan="4">
															<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
									&nbsp;</TD>
							</TR>
							<TR>
								<TD class="text" width="100%">
									<asp:datagrid id="dgTitulares" runat="server" Width="100%" BorderColor="#CCCCCC" BorderStyle="None"
										BorderWidth="1px" BackColor="White" CellPadding="3" AutoGenerateColumns="False" Font-Size="8pt" onprerender="dgTitulares_PreRender">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
										<ItemStyle ForeColor="#000066"></ItemStyle>
										<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
										<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="idTitular"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="idTipoPersona" HeaderText="Tipo">
												<HeaderStyle Width="5px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="Tipo">
												<HeaderStyle HorizontalAlign="Center" Width="5px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Nombre" HeaderText="Nombre y Apellido &lt;br&gt; Nombre Fantasia">
												<HeaderStyle Width="35%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroDoc" HeaderText="Documento&lt;br&gt;CUIT">
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="EstadoCivil" HeaderText="Estado Civil&lt;br&gt;Rubro">
												<HeaderStyle Width="65px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Porcentaje" HeaderText="Porc.">
												<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Porcentaje" HeaderText="Porcentaje"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="NombreFantasia" HeaderText="NombreFantasia"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="RazonSocial" HeaderText="RazonSocial"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Rubro" HeaderText="Rubro"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Cuit" HeaderText="Cuit"></asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
							<TR>
								<TD class="text" width="100%">&nbsp;</TD>
							</TR>
							<TR>
								<TD class="text" width="100%"></TD>
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
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="4"><BR>
									<FONT size="1">Este informe es confidencial y solo puede ser usado para la 
										evaluación y otorgamiento de créditos o celebración de negocios. Esta prohibida 
										su reproducción, divulgación y entrega a terceros.<BR>
										No significa emitir juicio de valor sobre las personas ni sobre su solvencia. 
										Las <U>decisiones a las que arribe el usuario son de su exclusiva responsabilidad.</U></FONT>
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
