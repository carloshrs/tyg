<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Inhibicion.verInforme" CodeFile="VerInforme.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Ver Informe</title>
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
	<body onload="imprimir();">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<td colspan="2">
					<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<td><IMG alt="" src="/img/logo-20-anios.png" width="264"></td>
								<TD class="title" width="100%" align="right">
									<table width="200" cellpadding="0" cellspacing="0" border="0">
<tr>
<td width="16"><img src="/Img/rounded1.gif" width="16" height="16" border="0"></td>
<td width="168" style="background-image: url('/Img/back1.gif');"><img src="/Img/shim.gif" width="1" height="16" border="0"/></td>
<td width="16"><img src="/Img/rounded2.gif" width="16" height="16" border="0"></td>
</tr>

<tr>
<td style="background-image: url('/Img/back4.gif');"><img src="/Img/shim.gif" width="16" height="1" border="0" /></td>
<td class="title" width="100%" align="center"><FONT color="#32528e">Informe de Inhibición</FONT></td>
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
					</td>
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
								<td class="text" align="center" width="15%">&nbsp;Numero: <asp:label id="lblNum" runat="server" Font-Bold="True"></asp:label><asp:label id="lblTipoDocumentoPeriodo" runat="server"></asp:label></td>
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
															</TR>
														<TR>
															<TD width="33%"><STRONG>Apellido y nombre:</STRONG>&nbsp;
																<asp:label id="lblApellido" runat="server"></asp:label>,
																<asp:label id="lblNombre" runat="server"></asp:label></TD>
															<TD class="text" width="33%"><STRONG>Tipo y nº documento:&nbsp;</STRONG>
																<asp:label id="lblTipoDocumento" runat="server"></asp:label>&nbsp;
																<asp:label id="lblDocumento" runat="server"></asp:label></TD>
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
															<TD class="text" width="50%" colSpan="2"><STRONG>CUIT:&nbsp;</STRONG>
																<asp:label id="lblCUIT" runat="server"></asp:label></TD>
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
											<TD class="text" width="100%" colSpan="3"><br /><br /></TD></TR>
										<TR>
											<TD class="text" width="100%" colSpan="3">
											<TABLE style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="0" cellPadding="0"
							width="100%" border="1">
							<TR>
															<TD width="100%" colSpan="3">
																<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;&nbsp;Resultados</TD>
																	</TR>
																</TABLE>
															</TD>
															</TR>
							<tr>
								<td>
											        <asp:DataList ID="dlResultados" runat="server" ShowFooter="False" 
            ShowHeader="False" Width="100%" OnItemDataBound="Item_Bound" CssClass="text">
            <ItemTemplate>
                <asp:Panel ID="pnResultado" runat="server" 
    style="width:100%; float:left; border-bottom: solid 1px #000000; margin:0px; padding:10px; height:140px;">
                    <div style="width:12%; float:left;">
                        Medida:
                        <asp:Label ID="lblMedida" runat="server" Text='<%# Eval("Medida") %>'></asp:Label>
                        <asp:Label ID="lblRow" runat="server" Text='<%# Eval("row_no") %>' Visible="false"></asp:Label>
                    </div>
                    <div style="width:12%; float:left;">
                        Diario:
                        <asp:Label ID="lblDiario" runat="server" Text='<%# Eval("diario") %>'></asp:Label>
                    </div>
                    <div style="width:12%; float:left;">
                        Año:
                        <asp:Label ID="lblAno" runat="server" Text='<%# Eval("ano") %>'></asp:Label>
                    </div>

                    <div style="width:160; float:left;">
                        Fecha:
                        <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("Fecha", "{0:d}") %>'></asp:Label>
                    </div>
                    <div style="width:100%; float:left;">
                        Tipo Medida:
                        <asp:Label ID="lblTipoMedida" runat="server" Text='<%# Eval("TipoMedida")%>'></asp:Label>
                    </div>
                    <div style="width:100%; float:left;">
                        Ordenado por:
                        <asp:Label ID="lblOrdenadoPor" runat="server" Text='<%# Eval("OrdenadoPor") %>'></asp:Label>
                    </div>
                    <div style="width:100%; float:left;">
                        Secretaria:
                        <asp:Label ID="lblSecretaria" runat="server" Text='<%# Eval("Secretaria") %>'></asp:Label>
                    </div>
                    <div style="width:100%; float:left;">
                        En autos:
                        <asp:Label ID="lblEnAutos" runat="server" Text='<%# Eval("EnAutos") %>'></asp:Label>
                    </div>
                    <div style="width:100%; float:left;">
                        Tipo de búsqueda:
                        <asp:Label ID="lblTipoBusqueda" runat="server" Text='<%# Eval("TipoBusqueda") %>'></asp:Label>
                    </div>
                    <div style="width:100%; float:left;">
                        Inmuebles gravados:
                        <asp:Label ID="lblInmueblesGravados" runat="server" Text='<%# Eval("InmueblesGravados") %>'></asp:Label>
                    </div>
                    <div style="width:100%; float:left;">
                        Anotaciones definitivas:
                        <asp:Label ID="lblAnotacionesDefinitivas" runat="server" Text='<%# Eval("AnotacionesDefinitivas") %>'></asp:Label>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnSaltoPagina" runat="server" Visible="false"><h1 class="SaltoDePagina"></h1></asp:Panel>
            </ItemTemplate>
        </asp:DataList>
        </td></tr></table>
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
								</TD>
							</TR>
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
