<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.verifContrato.Historial" CodeFile="Historial.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListaInformes</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
			<script>
		function popup(url,barra,scroll,w,h) 
			{
				vent=window.open(url,'','screenx=0,screeny=0,toolbar=' + barra + ',width=' + w + ',height=' + h +',directories=no,status=no,scrollbars=' + scroll + ',resize=yes,menubar=no,top=150,left=200');
				vent.focus();
			}
			</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="title" width="100%">Informe Contractual<BR>
						<HR>
						<BR>
					</td>
				</tr>
				<tr>
					<td width="100%">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="title" width="535" bgColor="lightgrey" colSpan="4" height="10">&nbsp;&nbsp;Datos 
									Contrato</TD>
							</TR>
							<TR>
								<TD class="text" width="535" colSpan="4" height="5"></TD>
							</TR>
							<TR>
								<TD class="text" width="535" colSpan="4" height="15">Tipo Contrato:
									<asp:label id="txtTipoContrato" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD class="text" width="535" colSpan="4"></TD>
							</TR>
							<TR>
								<TD class="text" width="535" colSpan="4" height="15">Número Contrato:&nbsp;
									<asp:label id="txtNumero" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD class="text" width="535" colSpan="4"></TD>
							</TR>
							<TR>
								<TD class="text" width="150">Fecha Inicio:
									<asp:label id="txtFechaInicio" runat="server" Font-Bold="True"></asp:label></TD>
								<TD class="text" width="150">Fecha Fin:
									<asp:Label id="txtFechaFin" runat="server" Font-Bold="True"></asp:Label></TD>
							</TR>
							<TR>
								<TD class="text" width="535" colSpan="4"></TD>
							</TR>
							<TR>
								<td class="text" width="535" colSpan="4">Descripción:&nbsp;&nbsp;
									<asp:Label id="txtDescripcion" runat="server" Font-Bold="True"></asp:Label></td>
							</TR>
							<TR>
								<TD class="text" width="535" colSpan="4" height="20"></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td width="100%">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="title" width="535" bgColor="lightgrey" colSpan="4" height="10">&nbsp;&nbsp;Historial</TD>
							</TR>
							<TR>
								<TD class="text" width="535" colSpan="4" height="5"></TD>
							</TR>
							<tr>
								<td class="text" vAlign="top" width="5"></td>
								<td class="text" height="38">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td><asp:datagrid id="dgridEncabezados" runat="server" Width="100%" Font-Size="8pt" PageSize="20"
													CellPadding="3" BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White"
													GridLines="Vertical" AutoGenerateColumns="False">
													<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
													<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
													<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
													<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
													<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
													<Columns>
														<asp:BoundColumn DataField="id" HeaderText="C&#243;digo">
															<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Fecha" HeaderText="Fecha">
															<HeaderStyle Width="80px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Descripcion" HeaderText="Descripci&#243;n">
															<HeaderStyle Width="80%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
														BackColor="#999999"></PagerStyle>
												</asp:datagrid></td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<td align="right">
												<table cellSpacing="0" cellPadding="0" width="25%" border="0">
													<tr>
														<td></td>
														<td align="right"><input id="Cancelar" onclick="javascript:window.close();" type="button" size="20" value="  Cerrar  "></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
