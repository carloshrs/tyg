<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.BusquedaPropiedad.verInforme" CodeFile="VerInforme.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Busqueda de Propiedad</title>
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
							<P align="center"><FONT color="#32528e">B�squeda de Propiedad</FONT>
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
								<td class="text" align="right" width="15%">N�mero:
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
															<TD width="99%" colSpan="4">
																<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; 
																			Persona F�sica</TD>
																	</TR>
																</TABLE>
															</TD>
														<TR>
															<TD vAlign="top" width="25%"><STRONG>Apellido y nombre:</STRONG>&nbsp;<BR>
																<asp:label id="lblApellido" runat="server"></asp:label>,
																<asp:label id="lblNombre" runat="server"></asp:label></TD>
															<TD class="text" vAlign="top" width="25%"><STRONG>Tipo y n� documento:&nbsp;</STRONG>
																<asp:label id="lblTipoDocumento" runat="server"></asp:label>&nbsp;
																<asp:label id="lblDocumento" runat="server"></asp:label></TD>
															<TD class="text" vAlign="top" width="25%" colSpan="2"><STRONG>Estado civil:</STRONG>
																<asp:label id="lblEstadoCivil" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD width="99%" colSpan="4">&nbsp;</TD>
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
																			Persona Jur�dica</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD class="text" width="360" colSpan="2"><STRONG>Raz�n Social:</STRONG>
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
																<asp:label id="lblCalle" runat="server"></asp:label></TD>
															<TD class="text" width="50%" colSpan="2"><STRONG>Barrio:&nbsp;</STRONG>
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
															<TD class="text" width="360" colSpan="2"><STRONG>Tel�fono:&nbsp;</STRONG>
																<asp:label id="lblTelefono" runat="server"></asp:label></TD>
															<TD class="text" width="50%" colSpan="2"><STRONG>Localidad:&nbsp;</STRONG>
																<asp:label id="lblLocalidad" runat="server"></asp:label></TD>
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
											<td colSpan="4">
												<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD width="100%" colSpan="4">
															<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">
																		&nbsp;&nbsp; Gesti�n sobre la verificaci�n</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD width="100%" colSpan="4">
															<STRONG>Resultado: </STRONG>
															<asp:label id="lblResultado" runat="server"></asp:label>
														</TD>
													</TR>
													<TR>
														<TD vAlign="top" width="100%" colSpan="4"><STRONG>Observaciones: </STRONG>
															<asp:label id="lblObservaciones" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD width="99%" colSpan="4">&nbsp;</TD>
													</TR>
													<TR>
														<TD class="text" width="100%" colSpan="2">
															<asp:datagrid id="dgDominios" runat="server" AutoGenerateColumns="False" BackColor="White" BorderStyle="None"
																BorderColor="#CCCCCC" CellPadding="3" Font-Size="8pt" BorderWidth="1px" Width="100%">
																<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
																<ItemStyle ForeColor="#000066"></ItemStyle>
																<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
																<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
																<Columns>
																	<asp:BoundColumn Visible="False" DataField="idDominio"></asp:BoundColumn>
																	<asp:BoundColumn DataField="Dominio" HeaderText="Dominio">
																		<HeaderStyle Width="150px"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="Registro" HeaderText="Registro donde esta radicado">
																		<HeaderStyle Width="80%"></HeaderStyle>
																	</asp:BoundColumn>
																</Columns>
																<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
															</asp:datagrid></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
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
										evaluaci�n y otorgamiento de cr�ditos o celebraci�n de negocios. Esta prohibida 
										su reproducci�n, divulgaci�n y entrega a terceros.<BR>
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
