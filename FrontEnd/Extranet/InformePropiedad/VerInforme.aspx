<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.InformePropiedad.verInforme" CodeFile="VerInforme.aspx.cs" %>
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

			function mostrarFiltro(First, name) {
			    if (masInfo.style.display == "none") {
			        masInfo.style.display = "list-item";
			        ToggleImg(name, 'Cerrar.gif', 'Cerrar Más Info');
			    }
			    else {
			        masInfo.style.display = "none";
			        ToggleImg(name, 'Arrow.gif', 'Más Info');
			    }
			}


            function imprimir() {
                panel.style.visibility = 'hidden';
                window.print();
                panel.style.visibility = 'visible';
            }

            function altoCelda() {
                if (document.Form1.idTipoPropiedad.value == 4)
                    tdObservaciones.style.height = '550';
                else
                    tdObservaciones.style.height = '120';
            }

			</script>
</HEAD>
	<body topmargin="0" leftmargin="0" onload="altoCelda(); imprimir();">
		<form id="Form1" method="post" runat="server">
			
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="title" width="100%">
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
<td class="title" width="100%" align="center"><FONT color="#32528e">Informe de Propiedad</FONT></td>
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
							width="100%" border="1" height="40">
							<tr>
								<td class="text" align="left" width="85%">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="text">&nbsp;Solicitado por:
												<asp:label id="lblSolicitante" runat="server" Font-Size="10" Font-Bold="True"></asp:label><br />
												&nbsp;Dirección: <asp:label id="lblDireccionSolicitante" runat="server" Font-Size="9"></asp:label>
                                                <asp:HiddenField ID="idTipoPropiedad" runat="server" />
                                            </td>
											<td class="text">Fecha:
												<asp:label id="lblFec" runat="server" Font-Bold="True"></asp:label></td>
										</tr>
										<tr>
											<td class="text" colSpan="2">&nbsp;Referencia:
												<asp:label id="lblRef" runat="server" Font-Bold="True"></asp:label></td>
										</tr>
									</table>
								</td>
								<td class="text" align="center" width="15%">&nbsp;Numero: <asp:label id="lblNum" runat="server" Font-Bold="True"></asp:label></td>
							</tr>
						</TABLE>
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
																	<TD class="title" width="100%" colSpan="3" height="30" style="text-align: center">
                                                                        IDENTIFICACIÓN Y UBICACIÓN DEL INMUEBLE</TD>
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
													</table>
													<asp:Panel ID="pnPlanilla" runat="server">
                                                            <table id="Table10" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
                                                            <tr>
                                                                <td class="text" width="100%" colspan="4">
                                                                    <asp:Label ID="Label5" runat="server">Propiedad de:</asp:Label>&nbsp;
                                                                    <asp:label id="lblPropiedadDe" runat="server"></asp:label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" width="100%" colspan="4">
                                                                    <asp:Label ID="Label6" runat="server">Ubicada en:</asp:Label>&nbsp;
                                                                    <asp:label id="lblUbicadaEn" runat="server"></asp:label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" width="100%" colspan="4">
                                                                    <asp:Label ID="Label9" runat="server">Dominio antecedente:</asp:Label>&nbsp;
                                                                    <asp:label id="lblDominioAntecedente" runat="server"></asp:label></td>
                                                            </tr>
                                                            </table>
                                                        </asp:Panel>
                                                            <asp:Panel ID="pnUbicacion" runat="server">
                                                            <table id="Table11" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD class="text" width="100%" colSpan="4"><asp:label id="Label1" runat="server" Font-Bold="True">
                                                            Barrio</asp:label>:
															<asp:label id="lblBarrio" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="50%" colSpan="2"><asp:label id="Label3" runat="server" Font-Bold="True">
                                                            Pedanía</asp:label>:&nbsp;
															<asp:label id="lblPedania" runat="server"></asp:label></TD>
														<TD class="text" width="50%" colSpan="2"><asp:label id="Label8" runat="server" Font-Bold="True">
                                                            Localidad</asp:label>:&nbsp;&nbsp;
															<asp:label id="lblLocalidad" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="50%" colSpan="2"><asp:label id="Label4" runat="server" Font-Bold="True">
                                                            Departamento</asp:label>:&nbsp;
															<asp:label id="lblDepartamento" runat="server"></asp:label></TD>
														<TD class="text" width="50%" colSpan="2"><asp:label id="Label2" runat="server" Font-Bold="True">
                                                            Provincia</asp:label>:&nbsp;
															<asp:label id="lblProvincia" runat="server"></asp:label></TD>
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
												</table>
                                                  </asp:Panel>
                                                  </td></tr>
                                                  </table>
											</TD>
										</TR>
										<TR>
											<TD class="text" width="50%">
											<asp:Panel ID="pnTitulares" runat="server">
												<table id="Table9" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD>
															<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" colSpan="3" height="30" style="text-align: center">
                                                                        TITULARES DEL INMUEBLE</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
													</TR>
													<TR>
														<TD class="text"><asp:datagrid id="dgTitulares" runat="server" Width="100%" BorderColor="#AAAAAA" BorderStyle="None"
																BorderWidth="1px" BackColor="White" CellPadding="3" AutoGenerateColumns="False" Font-Size="8pt" onprerender="dgTitulares_PreRender">
																<SelectedItemStyle Font-Bold="True" ForeColor="black"></SelectedItemStyle>
																<ItemStyle ForeColor="#000000"></ItemStyle>
																<HeaderStyle Font-Bold="True" ForeColor="black" ></HeaderStyle>
																<FooterStyle ForeColor="#000000" BackColor="White"></FooterStyle>
																<Columns>
																	<asp:BoundColumn Visible="False" DataField="idTitular"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="idTipoPersona" HeaderText="Tipo">
																		<HeaderStyle Width="5px"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="Nombre" HeaderText="Nombre y Apellido &lt;br&gt; Raz&oacute;n Social">
																		<HeaderStyle Width="35%"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="NroDoc" HeaderText="Documento&lt;br&gt;CUIT">
																		<HeaderStyle Width="20%"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="EstadoCivil" HeaderText="Estado Civil">
																		<HeaderStyle Width="65px"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="Porcentaje" HeaderText="Proporci&#243;n">
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
													</table>
													</asp:Panel>
                                                  
													<!--<TR>
														<TD class="text" width="175"><asp:label id="Label15" runat="server" Font-Bold="True">
                                    Proporción</asp:label>:
															<asp:label id="lblProporcion" runat="server"></asp:label></TD>
													</TR>-->
													<asp:Panel ID="pnGravamenes" runat="server">
													<table id="Table12" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD>
															<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" colSpan="3" style="height: 30px; text-align: center">
                                                                        GRAVÁMENES Y RESTRICCIONES</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="text" width="100%" height="70" valign="top"><asp:label id="lblGravamenes" runat="server"></asp:label></TD>
													</TR>
													</table>
													</asp:Panel>
                                                    <asp:Panel ID="pnInformesAnteriores" runat="server">
													<table id="Table13" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD>
															<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" colSpan="3" height="30" style="text-align: center">
                                                                        INFORMES ANTERIORES</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="text" width="100%" height="70" valign="top"><asp:label id="lbInformesAnteriores" runat="server"></asp:label></TD>
													</TR>
													</table>
                                                    </asp:Panel>
													
													<table id="Table14" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD>
															<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" colSpan="3" height="30" style="text-align: center">
                                                                        OBSERVACIONES</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD id="tdObservaciones" class="text" width="100%" valign="top"><asp:label id="lblObservaciones" runat="server"></asp:label></TD>
													</TR>
													</table>
													
                                                    <asp:Panel ID="pnResultado" runat="server">
													<table id="Table15" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD class="text" width="100%" height="35" valign="top"><asp:label id="Label7" runat="server" Font-Bold="True">Resultado</asp:label>:
															<asp:label id="lblResultado" runat="server" Font-Bold="true"></asp:label></TD>
													</TR>
													</table>
                                                    </asp:Panel>
													
                                                    
													<table id="Table16" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="0"
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
						</TABLE>
			<input id="idEncabezado" type="hidden" name="idEncabezado" runat="server"> <input id="idReferencia" type="hidden" name="idReferencia" runat="server">
		</form>
		<p><BR>
		</p>
	</body>
</HTML>
