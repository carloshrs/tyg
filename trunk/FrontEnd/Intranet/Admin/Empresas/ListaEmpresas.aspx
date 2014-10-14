<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Contratos.ListaEmpresas" CodeFile="ListaEmpresas.aspx.cs" %>
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
		<FORM id="Tipos" method="post" runat="server">
		<uc1:menu id="Menu1" runat="server"></uc1:menu>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%" colspan="2">Listado de Empresas<BR>
						<HR>
						<BR>
					</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>
						<cf:webfiltroalfabetico id="FiltroEmpresas" runat="server" Estilo="title" MostrarOtros="True" Izquierda="5"
							Arriba="0" MensajeAyuda="Empresas cuya Razón Social"></cf:webfiltroalfabetico>
					</td>
					<td class="text">
						&nbsp;Filtrar Por
                        <asp:RadioButton ID="raTipoFiltro1" runat="server" Checked="True" 
                            GroupName="raTipoFiltro" Text="Razon social" />
                        <asp:RadioButton ID="raTipoFiltro2" runat="server" GroupName="raTipoFiltro" 
                            Text="Dirección" />
                        :
						<asp:textbox id="TxtFiltro" MaxLength="100" onKeyPress="return validarString(event);" runat="server"
							Width="150px" CssClass="planotext"></asp:textbox>
						&nbsp;
						<asp:button id="btnBuscar" style="CURSOR:hand" title="Realizar Búsqueda" runat="server" Width="58px"
							Text="Buscar"></asp:button>
					</td>
				</tr>
				<tr>
					<TD width="2%">&nbsp;</TD>
					<TD class="text" align="right" width="93%" colspan="2">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<TD class="text" width="100%">&nbsp;</TD>
							</tr>
							<tr>
								<TD width="100%">
									<asp:datagrid id="dgridEmpresas" runat="server" Width="100%" Font-Size="8pt" PageSize="12" CellPadding="3"
										BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" AllowPaging="True">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="idEmpresa" HeaderText="C&#243;digo">
												<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RazonSocial" HeaderText="Raz&#243;n Social">
												<HeaderStyle Width="200px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Direccion" HeaderText="Dirección"></asp:BoundColumn>
											<asp:BoundColumn DataField="Cuit" HeaderText="Cuit">
												<HeaderStyle Width="200px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
                                            <asp:BoundColumn DataField="telefono" HeaderText="Tel&#233;fono"></asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="10px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Editar" runat="server" Width="16px" ImageUrl="/img/modificar_general.gif" CommandName="Editar" 
 ToolTip="Editar Empresa"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="10px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Eliminar" runat="server" Width="16px" ImageUrl="\Img\Cruz.gif" CommandName="Eliminar" 
 ToolTip="Eliminar Empresa"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999" Mode="NumericPages"></PagerStyle>
									</asp:datagrid>
								</TD>
							</tr>
						</TABLE>
						<BR>
						<asp:button id="btnEmpresas" style="CURSOR:hand" title="Registrar Nueva Empresa" runat="server"
							Width="155px" Text="Nueva Empresa"></asp:button>
					</TD>
					<TD width="5%">&nbsp;</TD>
				</tr>
			</TABLE>
		</FORM>
	</body>
</HTML>
