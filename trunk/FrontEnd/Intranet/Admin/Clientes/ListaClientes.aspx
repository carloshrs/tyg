<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Clientes.ListaClientes" CodeFile="ListaClientes.aspx.cs" %>
<%@ Register TagPrefix="cf" Namespace="WebCustomControls.Controls" Assembly="WebCustomControls" %>
<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Lista de Clientes</title>
		<script src="/Includes/Funciones.js" type="text/javascript"></script>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="2" width="98%" border="0">
				<tr>
					<td class="text" vAlign="top" width="5">&nbsp;</td>
					<td class="text" height="38">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<TD>&nbsp;</TD>
								<td class="title" width="100%" colSpan="2">Listado de Clientes
									<hr>
								</td>
							</tr>
							<!-- FILTRO DE GERMAN -->
							<tr>
								<td>&nbsp;</td>
								<td><cf:webfiltroalfabetico id="FiltroClientes" runat="server" MensajeAyuda="Clientes cuya Razón social" Arriba="0"
										Izquierda="5" MostrarOtros="False" Estilo="title"></cf:webfiltroalfabetico></td>
								<td class="text">&nbsp;Filtrar Por razón social o dirección:
									<asp:textbox id="TxtFiltro" runat="server" onKeyPress="return validarString(event);" CssClass="planotext" Width="150px" MaxLength="100"></asp:textbox>&nbsp;
									<asp:button id="btnBuscar" title="Realizar Búsqueda" style="CURSOR: hand" runat="server" Width="58px"
										Text="Buscar" onclick="btnBuscar_Click"></asp:button></td>
							</tr>
							<tr>
								<td colspan="3">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="3"><asp:datagrid id="dgridClientes" runat="server" Width="100%" AllowPaging="True" Font-Size="8pt"
										PageSize="12" CellPadding="3" BorderColor="#3657A6" BorderStyle="Solid" BorderWidth="1px" BackColor="White"
										GridLines="Vertical" AutoGenerateColumns="False" onprerender="dgridClientes_PreRender">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="IdCliente" HeaderText="C&#243;digo">
												<HeaderStyle HorizontalAlign="Center" Width="45px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RazonSocial" HeaderText="Raz&oacute;n Social">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreFantasia" HeaderText="Nombre Fantasia">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Sucursal" HeaderText="Sucursal">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Telefono" HeaderText="Tel&#233;fono">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Fax" HeaderText="Fax">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="CUIT" HeaderText="CUIT">
												<HeaderStyle Width="45px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Email" HeaderText="Correo Electr&#243;nico">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Direccion" HeaderText="Dirección">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="20px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Editar" runat="server" Width="16px" ImageUrl="/img/modificar_general.gif" CommandName="Editar"
														ToolTip="Editar Cliente"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="20px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Eliminar" runat="server" Width="16px" ToolTip="Eliminar Cliente" CommandName="Eliminar"
														ImageUrl="/Img/Cruz.gif"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="20px"></HeaderStyle>
												<ItemTemplate>
													<asp:ImageButton id="ibutUsuarios" runat="server" Width="16px" ToolTip="Ver Usuarios" CommandName="VerUsuarios"
														ImageUrl="/Img/menu/icon_acces.gif"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
                                            <asp:BoundColumn DataField="RazonSocialFox" Visible="false" >
											</asp:BoundColumn>
                                            <asp:TemplateColumn>
												<HeaderStyle Width="20px"></HeaderStyle>
												<ItemTemplate>
													<asp:ImageButton id="idCuentaCliente" runat="server" Width="16px" ToolTip="Ver Cuenta Corriente Cliente" CommandName="verCCCliente"
														ImageUrl="/Img/Precios.gif"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999" PageButtonCount="8" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
							<tr>
								<td colspan="3">&nbsp;</td>
							</tr>
							<tr>
								<td align="right" colspan="3">
									<asp:button id="btnNewCliente" style="CURSOR:hand" title="Registrar Nuevo Cliente" runat="server"
										Width="155px" Text="Nuevo Cliente" onclick="btnNewCliente_Click"></asp:button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
