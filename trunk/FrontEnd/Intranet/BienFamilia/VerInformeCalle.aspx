<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.BienFamilia.verInformeCalle" CodeFile="VerInformeCalle.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Ver Informe</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
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
							<P align="center"><FONT color="#32528e">Informe de Gravámenes - Bien de Familia</FONT>
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
																		Datos Bien de Familia</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="text" width="33%"><STRONG>Folio:</STRONG>&nbsp;
															<asp:label id="lblFolio" runat="server"></asp:label></TD>
														<TD class="text" width="33%"><STRONG>Tomo:</STRONG>
															<asp:label id="lblTomo" runat="server"></asp:label></TD>
														<td class="text" width="33%" colSpan="2"><STRONG>Año: </STRONG>
															<asp:label id="lblAnio" runat="server"></asp:label></td>
													</TR>
												</TABLE>
												<BR>
											</TD>
										</TR>
										<TR>
											<TD class="text" width="100%">
												<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
													cellPadding="3" width="100%" border="1" height="400">
													<TR>
														<TD valign="top"><STRONG>&nbsp;Observaciones:</STRONG>&nbsp;&nbsp;</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD class="text" width="100%"><IMG height="15" src="/img/shim.gif" width="1"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="text" width="100%" colSpan="4"><BR>
									<BR>
									<BR>
									<BR>
									<BR>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
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
			</TD></TR><tr>
				<td colSpan="2" width="100%"></td>
			</tr>
			</TABLE><input id="idEncabezado" type="hidden" name="idEncabezado" runat="server">
			<input id="idReferencia" type="hidden" name="idReferencia" runat="server">
		</form>
	</body>
</HTML>
