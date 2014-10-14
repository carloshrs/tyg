<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.InformePropiedad.verInformeCalle" CodeFile="VerInformeCalle.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Informe de Propiedad</title>
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
							<input onclick="panel.style.visibility='hidden';window.print();panel.style.visibility='visible';" type="image" src="/img/imprimir-2.gif" title="Imprimir"> 
							<input onclick="window.close();" title="Cerrar" type="image" src="/img/log_off.gif">
						</div>
					</td>
				</tr>
			</TABLE>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="title" width="100%">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<td><IMG alt="" src="/img/logo_impr.gif" 
            width=175></td>
								<TD class="title" width="100%"><FONT color="#ffffff">
										<P align="center"><FONT color=gray>Informe de 
            Propiedad</FONT>
									</FONT></P></TD>
							</TR>
						</TABLE>
						<HR>
						<TABLE cellSpacing="0" cellPadding="0" style="BORDER-COLLAPSE: collapse" borderColor="#000000"
							width="100%" border="1">
							<tr>
								<td class="text" align="left" width="85%">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="text">&nbsp;Solicitado por:
												<asp:label id="lblSolicitante" runat="server" Font-Bold="True"></asp:label></td>
											<td class="text">Fecha:
												<asp:label id="lblFec" runat="server" Font-Bold="True"></asp:label></td>
										</tr>
										<tr>
											<td class="text" colSpan="2">&nbsp;Referencia:
												<asp:label id="lblRef" runat="server" Font-Bold="True"></asp:label></td>
										</tr>
									</table>
								</td>
								<td class="text" align="left" width="15%">&nbsp;Numero:
									<asp:label id="lblNum" runat="server" Font-Bold="True"></asp:label></td>
							</tr>
						</TABLE>
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="text" width="100%"></TD>
							</TR>
							<TR>
								<TD width="100%">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="text" width="50%">
												<TABLE id="Table3" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD width="100%" colSpan="4">
															<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; <FONT 
                              color=gray>Identificación y ubicación del 
                              inmueble</FONT></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="text" width="100%" colSpan="4"><asp:label id="lblTipoPropiedad" runat="server" Font-Bold="True">
                                                            Nro de Matricula</asp:label>:&nbsp;
															<asp:label id="lblMatricula" runat="server"></asp:label></TD>
													</TR>
													<TR id="trMatricula" runat="server">
														<TD class="text" width="175"><STRONG>Folio:</STRONG>&nbsp;
															<asp:label id="lblFolio" runat="server"></asp:label></TD>
														<TD class="text" width="33%"><STRONG>Tomo:</STRONG>
															<asp:label id="lblTomo" runat="server"></asp:label></TD>
														<td class="text" colSpan="2"><STRONG>Año: </STRONG>
															<asp:label id="lblAnio" runat="server"></asp:label></td>
													</TR>
													<TR>
														<TD class="text" width="100%" colSpan="4"><asp:label id="Label1" runat="server" Font-Bold="True">
                                                            Barrio</asp:label>:<BR>
															<asp:label id="lblBarrio" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="50%" colSpan="2"><asp:label id="Label3" runat="server" Font-Bold="True">
                                                            Pedanía</asp:label>:&nbsp;
															<asp:label id="lblPedania" runat="server"></asp:label></TD>
														<TD class="text" width="50%" colSpan="2"><asp:label id="Label4" runat="server" Font-Bold="True">
                                                            Departamento</asp:label>:&nbsp;
															<asp:label id="lblDepartamento" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="50%" colSpan="2"><asp:label id="Label2" runat="server" Font-Bold="True">
                                                            Provincia</asp:label>:&nbsp;
															<asp:label id="lblProvincia" runat="server"></asp:label></TD>
														<TD class="text" width="50%" colSpan="2"><asp:label id="Label8" runat="server" Font-Bold="True">
                                                            Localidad</asp:label>:&nbsp;
															<asp:label id="lblLocalidad" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="25%"><STRONG>PH:
																<BR>
															</STRONG>
															<asp:label id="lblPH" runat="server"></asp:label></TD>
														<TD class="text" width="25%"><STRONG>Lote:
																<BR>
															</STRONG>
															<asp:label id="lblLote" runat="server"></asp:label></TD>
														<TD class="text" width="25%"><STRONG>Manzana:
																<BR>
															</STRONG>
															<asp:label id="lblManzana" runat="server"></asp:label></TD>
														<TD class="text" width="25%"><STRONG>Superficie:<BR>
															</STRONG>
															<asp:label id="lblSuperficie" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="25%" colSpan="4">&nbsp;</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD class="text" width="50%">
												<TABLE id="Table9" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD>
															<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; <FONT 
                              color=gray>Titulares del 
                          inmueble</FONT></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
													</TR>
													<TR>
														<TD class="text" vAlign="top" height="170"><asp:datagrid id="dgTitulares" runat="server" Width="100%" BorderColor="#CCCCCC" BorderStyle="None"
																BorderWidth="1px" BackColor="White" CellPadding="3" AutoGenerateColumns="False" Font-Size="8pt">
<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999">
</SelectedItemStyle>

<ItemStyle ForeColor="#000066">
</ItemStyle>

<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Gray">
</HeaderStyle>

<FooterStyle ForeColor="#000066" BackColor="White">
</FooterStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="idTitular"></asp:BoundColumn>
<asp:BoundColumn DataField="Nombre" HeaderText="Nombre y Apellido &lt;br&gt; Nombre Fantasia">
<HeaderStyle Width="35%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NroDoc" HeaderText="Documento&lt;br&gt;CUIT">
<HeaderStyle Width="20%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="EstadoCivil" HeaderText="Estado Civil&lt;br&gt;Rubro">
<HeaderStyle Width="65px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Porcentaje" HeaderText="Porc.">
<HeaderStyle Width="15px">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages">
</PagerStyle>
															</asp:datagrid></TD>
													</TR>
													<!--<TR>
														<TD class="text" width="100%"><asp:label id="Label5" runat="server" Font-Bold="True">
                                    Proporción</asp:label>:
															<asp:label id="lblProporcion" runat="server"></asp:label></TD>
													</TR>-->
													<TR>
														<TD class="text" width="535">&nbsp;</TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; <FONT 
                              color=gray>Gravámenes y 
                          restricciones</FONT></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="text" width="100%" vAlign="top" height="83">&nbsp;
															<asp:label id="lblGravamenes" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="535">&nbsp;</TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; <FONT 
                              color=gray>Observaciones</FONT></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="text" width="100%" vAlign="top" height="102"><asp:label id="lblObservaciones" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="100%"><asp:label id="Label6" runat="server" Font-Bold="True">Morosidad</asp:label>:&nbsp;
															<asp:label id="lblMorosidad" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="100%"><asp:label id="Label7" runat="server" Font-Bold="True">Resultado</asp:label>:
															<asp:label id="lblResultado" runat="server"></asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td width="100%"></td>
				</tr>
			</TABLE>
			<input id="idEncabezado" type="hidden" name="idEncabezado" runat="server"> <input id="idReferencia" type="hidden" name="idReferencia" runat="server">
		</form>
		<p><BR>
		</p>
	</body>
</HTML>
