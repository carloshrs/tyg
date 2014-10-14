<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Contratos.ListaPersonas" CodeFile="ListaPersonas.aspx.cs" %>
<%@ Register TagPrefix="cf" Namespace="WebCustomControls.Controls" Assembly="WebCustomControls" %>
<%@ Register TagPrefix="uc1" TagName="menu" Src="../../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Alta de Informe</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
		<script src="/Includes/Funciones.js" type="text/javascript"></script>
</HEAD>
	<body leftMargin="0" topMargin="0">
		<uc1:menu id="Menu1" runat="server"></uc1:menu>
		<FORM id="Tipos" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TBODY>
					<tr>
						<TD width="2%">&nbsp;</TD>
						<td class="title" width="100%" colspan="2">Listado de Personas<BR>
							<HR>
						</td>
					</tr>
					<!-- FILTRO DE GERMAN -->
					<tr>
						<td>&nbsp;</td>
						<td>
							<cf:webfiltroalfabetico id="FiltroPersonas" runat="server" Estilo="title" MostrarOtros="True" Izquierda="5"
								Arriba="0" MensajeAyuda="Personas cuyo Apellido"></cf:webfiltroalfabetico>
						</td>
						<td class="text">
							&nbsp;Filtrar Por Apellido:
							<asp:textbox id="TxtFiltro" MaxLength="100" onKeyPress="return validarString(event);" runat="server" Width="150px" CssClass="planotext"></asp:textbox>
							&nbsp;
							<asp:button id="btnBuscar" style="CURSOR:hand" title="Realizar Búsqueda" runat="server" Width="58px"
								Text="Buscar" onclick="btnBuscar_Click"></asp:button>
						</td>
					</tr>
					<tr>
						<TD width="2%">&nbsp;</TD>
						<TD class="text" align="right" width="93%" colSpan="2">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<TD class="text" width="100%">&nbsp;</TD>
								</tr>
								<tr>
									<TD width="100%"><asp:datagrid id="dgridPersonas" runat="server" Width="100%" Font-Size="8pt" PageSize="12" CellPadding="3"
											BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False"
											AllowPaging="True" onprerender="dgridContratos_PreRender">
											<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
											<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
											<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
											<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
											<Columns>
												<asp:BoundColumn DataField="idPersona" HeaderText="C&#243;digo">
													<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Apellido" HeaderText="Apellido">
													<HeaderStyle Width="200px"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Nombre" HeaderText="Nombre">
													<HeaderStyle Width="200px"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="descripcion" HeaderText="Tipo Documento">
													<HeaderStyle Width="40px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="DNI" HeaderText="DNI">
													<HeaderStyle Width="40px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="10px"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:ImageButton id="Editar" runat="server" Width="16px" ImageUrl="/img/modificar_general.gif" CommandName="Editar" ToolTip="Editar Persona"></asp:ImageButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="10px"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:ImageButton id="Eliminar" runat="server" Width="16px" ImageUrl="\Img\Cruz.gif" CommandName="Eliminar" ToolTip="Eliminar Persona"></asp:ImageButton>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
												BackColor="#999999" Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
								</tr>
							</TABLE>
							<BR>
							<asp:button id="btnPersonas" style="CURSOR:hand" title="Registrar Nueva Persona" runat="server"
								Width="155px" Text="Nueva Persona" onclick="btnPersonas_Click"></asp:button></TD>
						<TD width="5%">&nbsp;</TD>
					</tr>
				</TBODY></TABLE>
		</FORM><!--</TR></TBODY></TABLE></FORM>-->
	</body>
</HTML>
