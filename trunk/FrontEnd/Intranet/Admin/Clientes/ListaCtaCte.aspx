<%@ Reference Page="~/Admin/Clientes/ListaClientes.aspx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Clientes.ListaCtaCte" CodeFile="ListaCtaCte.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="menu" Src="../../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Bandeja de Entrada</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
			<script>
			function ToggleImg(name, src, alt)
			{
				name.src = "/img/" + src;
				name.alt = alt
			}

			function mostrarFiltro(First, name)
			{
				if (masFiltros.style.display == "none") 
				{
					masFiltros.style.display = "list-item";
					ToggleImg(name, 'Cerrar.gif', 'Cerrar Filtro Avanzado');
					BotonBuscar.style.display = "none";
				} 
				else 
				{
					CtaCte.txtFechaInicio.value="";
					CtaCte.txtFechaFinal.value="";
					masFiltros.style.display = "none";
					ToggleImg(name, 'Arrow.gif', 'Filtro Avanzado');
					BotonBuscar.style.display = "list-item";
				}
			}

			</script>
</HEAD>
	<body leftMargin="0" topMargin="0" onload="javascript:mostrarFiltro(true, '');">
		<uc1:menu id="Menu1" runat="server"></uc1:menu>
		<FORM id="CtaCte" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%">Listado de Cuenta Corriente<BR>
						<HR>
					</td>
				</tr>
				<tr>
					<TD width="2%">&nbsp;</TD>
					<TD class="text" align="right" width="93%" colSpan="4">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<TD class="text" width="100%" colSpan="4">&nbsp;</TD>
							</tr>
							<TR>
								<TD class="text" align="left" width="100%">
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<TD class="text" align="left" width="98%">
												<table cellSpacing="0" cellPadding="0" border="0">
													<tr>
														<td class="text" width="30%">Cliente:</td>
														<td width="30%">&nbsp;</td>
														<td align="right" width="40%">&nbsp;</td>
													</tr>
													<tr>
														<td class="text"><asp:dropdownlist id="cmbClientes" runat="server"></asp:dropdownlist></td>
														<td class="text"><asp:checkbox id="chkSoloMias" runat="server" Text="&nbsp;Solo No Facurado" Checked="True"></asp:checkbox></td>
														<TD class="text" id="BotonBuscar" align="right"><asp:button class="Boton" id="btnBuscar" runat="server" Text="Buscar" onclick="btnBuscar_Click"></asp:button></TD>
													</tr>
												</table>
											</TD>
											<TD class="text" vAlign="top" align="right" width="2%"><A onclick="javascript:mostrarFiltro(false, imgFiltro);" href="#"><IMG height="14" alt="Filtro Avanzado" src="/img/Arrow.gif" width="14" border="0" name="imgFiltro"
														id="imgFiltro"></A></TD>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<tr>
								<TD class="text" width="100%">&nbsp;</TD>
							</tr>
							<TR id="masFiltros">
								<TD class="text" align="left" width="100%">
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<TD class="text" align="left" width="25%">&nbsp;Filtro por Caracter:
											</TD>
											<TD class="text" align="left" width="25%">&nbsp;Filtro por Tipo Informe:
											</TD>
											<TD class="text" align="left" width="10%">&nbsp;Fecha Desde:&nbsp;
											</TD>
											<TD class="text" align="left" width="10%">&nbsp;Fecha Hasta:&nbsp;
											</TD>
											<TD class="text" align="left" width="20%">&nbsp;&nbsp;
											</TD>
										</tr>
										<tr>
											<TD class="text" align="left" width="25%">&nbsp;<asp:dropdownlist id="cmbCaracter" runat="server" Width="224px"></asp:dropdownlist>
											</TD>
											<TD class="text" align="left" width="25%">&nbsp;<asp:dropdownlist id="cmbTipoInforme" runat="server" Width="224px"></asp:dropdownlist>
											</TD>
											<TD class="text" align="left" width="10%">&nbsp;<asp:textbox id="txtFechaInicio" runat="server" Width="77px" ReadOnly="True"></asp:textbox>&nbsp;
												<IMG id="imgFechaInicio" style="CURSOR: hand" onclick="popFrame.fPopCalendar(imgFechaInicio, txtFechaInicio, divDateControl);"
													alt="Abrir Calendario" src="/img/fecha.gif">
											</TD>
											<TD class="text" align="left" width="10%">&nbsp;&nbsp;<asp:textbox id="txtFechaFinal" runat="server" Width="88px" ReadOnly="True"></asp:textbox>&nbsp;
												<IMG id="imgFechaFinal" style="CURSOR: hand" onclick="popFrame.fPopCalendar(imgFechaFinal, txtFechaFinal, divDateControl);"
													alt="Abrir Calendario" src="/img/fecha.gif">
											</TD>
											<TD class="text" align="right" width="20%">&nbsp;
												<asp:button id="btnFiltro" runat="server" Text="Aplicar Filtro" onclick="btnFiltro_Click"></asp:button></TD>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<tr>
								<TD class="text" width="100%">&nbsp;</TD>
							</tr>
							<tr>
								<TD align="right" width="100%"><asp:datagrid id="dgridEncabezados" runat="server" Width="100%" Font-Size="8pt" PageSize="20"
										CellPadding="3" BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" onprerender="dgridEncabezados_PreRender">
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="NroMovimiento" HeaderText="Nro"></asp:BoundColumn>
											<asp:BoundColumn DataField="FecMovimiento" HeaderText="Fecha">
												<HeaderStyle Width="120px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IdCliente" HeaderText="IdCliente"></asp:BoundColumn>
											<asp:BoundColumn DataField="Cliente" HeaderText="Cliente"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IdTipoInforme" HeaderText="IdTipoInforme"></asp:BoundColumn>
											<asp:BoundColumn DataField="Descripcion" HeaderText="Tipo">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="TipoPrecio" HeaderText="Caracter">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Precio" HeaderText="Precio">
												<HeaderStyle HorizontalAlign="Left" Width="80px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Facturado" HeaderText="Facturado"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IdEncabezado" HeaderText="IdEncabezado"></asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="22px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="ibutVer" runat="server" CommandName="Ver" ImageUrl="/Img/lupita.gif"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:datagrid>
								</TD>
							</tr>
							<tr>
								<td>
									<table cellpadding="0" cellspacing="0" border="0" width="100%">
										<tr>
											<td align="right">
												<asp:label id="lblTituloSaldo" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="#3657A6">Saldo del filtro seleccionado:</asp:label>&nbsp;
												<asp:label id="lblSaldo" runat="server" Font-Size="Small" Font-Bold="True" ForeColor="#3657A6">$ 10.000</asp:label>
											</td>
											<td width="30">&nbsp;</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td align="right">
									<hr>
									<asp:button class="Boton" id="btnCerrar" runat="server" Text="Cerrar" onclick="btnCerrar_Click"></asp:button>
								</td>
							</tr>
						</TABLE>
					</TD>
				</tr>
			</TABLE>
		</FORM>
		<DIV id="divDateControl" style="Z-INDEX: 102; LEFT: -35px; VISIBILITY: hidden; POSITION: absolute; TOP: -150px">
			<IFRAME id="popFrame" name="popFrame" src="/inc/calendar/calendar.htm" frameBorder="0" width="160"
				scrolling="no" height="160"></IFRAME>
		</DIV>
	</body>
</HTML>
