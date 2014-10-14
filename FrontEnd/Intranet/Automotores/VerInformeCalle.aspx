<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Automotores.verInformeCalle" CodeFile="VerInformeCalle.aspx.cs" %>
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
					<td><IMG alt="" src="/img/logo_impr.gif" 
width=175></td>
					<TD class="title" width="100%"><FONT color="#ffffff">
							<P align="center">
						</FONT><FONT color=gray>Informe 
      Automotores y Motovehículos </FONT></P></TD>
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
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; <FONT 
                              color=gray>Datos 
                      Informe</FONT></TD>
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
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; <FONT 
                              color=gray>Gestión sobre la 
                          verificación</FONT></TD>
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
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; <FONT 
                              color=gray>Información del 
                          Registro</FONT></TD>
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
												<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
													cellPadding="3" width="100%" border="1">
													<TR>
														<TD width="99%" colspan="4">
															<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; <FONT 
                              color=gray>Datos 
                      Titular</FONT></TD>
																</TR>
															</TABLE>
														</TD>
													<TR>
														<TD width="33%" colspan="2"><STRONG>Apellido y nombre:</STRONG>&nbsp;</TD>
														<TD class="text" width="33%"><STRONG>Tipo y nº documento:&nbsp;</STRONG>&nbsp;&nbsp;</TD>
														<TD class="text" width="33%"><STRONG>Estado civil:</STRONG></TD>
													</TR>
													<TR>
														<TD class="text" width="50%" colSpan="2"><STRONG>Calle:</STRONG></TD>
														<TD class="text" width="50%" colSpan="2"><STRONG>Barrio:</STRONG>&nbsp;</TD>
													</TR>
													<TR>
														<TD class="text" width="25%"><STRONG>Nro:</STRONG></TD>
														<TD class="text" width="25%"><STRONG>Piso:</STRONG></TD>
														<TD class="text" width="25%"><STRONG>Depto.:</STRONG></TD>
														<TD class="text" width="25%"><STRONG>C.P.:</STRONG></TD>
													</TR>
													<TR>
														<TD class="text" width="50%" colSpan="2"><STRONG>Provincia:&nbsp;&nbsp; </STRONG>
														</TD>
														<TD class="text" width="50%" colSpan="2"><STRONG>Localidad:&nbsp; </STRONG>
														</TD>
													</TR>
													<TR>
														<TD class="text" width="535" colSpan="4">&nbsp;</TD>
													</TR>
												</TABLE>
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
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; <FONT 
                              color=gray>Datos 
                        Vehículo</FONT></TD>
																</TR>
															</TABLE>
														</TD>
													<TR>
														<TD width="33%"><STRONG>Marca:</STRONG>&nbsp;</TD>
														<TD class="text" width="33%"><STRONG>Modelo:&nbsp;</STRONG></TD>
														<TD class="text" width="33%"><STRONG>Año:</STRONG></TD>
													</TR>
													<TR>
														<TD class="text" width="50%" colSpan="2"><STRONG>Número de Chasis:</STRONG></TD>
														<TD class="text" width="50%" colSpan="2"><STRONG>Número de Motor:</STRONG>&nbsp;</TD>
													</TR>
													<TR>
														<TD class="text" width="535" colSpan="4">&nbsp;</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>&nbsp;
								</TD>
							</TR>
        <TR>
          <TD class=text width="100%">
            <TABLE id=Table7 cellSpacing=0 cellPadding=0 width="100%" 
              border=0>
              <TR>
                <TD class=title width="100%" bgColor=lightgrey colSpan=3 
                height=10>&nbsp;&nbsp; <FONT 
                  color=gray>Titulares del 
          automotor</FONT></TD></TR></TABLE>&nbsp;</TD></TR>
        <TR>
          <TD class=text vAlign=top width="100%" height=170>
<asp:datagrid id=dgTitulares runat="server" Width="100%" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" AutoGenerateColumns="False" Font-Size="8pt">
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
															</asp:datagrid></TD></TR>
        <TR>
          <TD class=text width="100%">&nbsp;</TD></TR>
        <TR>
          <TD class=text width="100%">
            <TABLE class=text id=Table3 style="BORDER-COLLAPSE: collapse" 
            borderColor=#111111 height=80 cellSpacing=0 cellPadding=3 
            width="100%" border=1>
              <TR>
                <TD vAlign=top><STRONG>&nbsp;Gravámenes y 
                  Restricciones:</STRONG>&nbsp;&nbsp;</TD></TR></TABLE></TD></TR>
							<TR>
								<TD class="text" width="100%">&nbsp;
								</TD>
							</TR>
							<TR>
								<TD class="text" width="100%">
									<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
										cellPadding="3" width="100%" border="1" height="80">
										<TR>
											<TD valign="top"><STRONG>&nbsp;Datos Negativos del Titular:</STRONG>&nbsp;&nbsp;</TD>
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
											<TD valign="top"><STRONG>&nbsp;Resultados:</STRONG>&nbsp;&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="4"><div style="font-size:10px; margin-top:10px; line-height:1.5">
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
