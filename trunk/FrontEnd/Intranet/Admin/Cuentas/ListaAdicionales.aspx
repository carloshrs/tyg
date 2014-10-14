<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Seguridad.Admin.Cuentas.ListaAdicionales" CodeFile="ListaAdicionales.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Lista de Funciones</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<form method="post" runat="server">
			<table cellSpacing="0" cellPadding="2" width="98%" border="0">
				<tr>
					<td class="text" vAlign="top" width="5"></td>
					<td class="text" height="38">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="title" height="38">&nbsp; <STRONG>Listado de servicios adicionales</STRONG>
									<HR>
									<BR>
								</td>
							</tr>
							<tr>
								<td>
									<asp:datagrid id="dgAdicionales" runat="server" Font-Size="8pt" PageSize="20" CellPadding="3" BorderColor="#3657A6"
										BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False"
										Width="100%">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="Id">
												<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Descripcion" HeaderText="Descripcion">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="25px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Editar" runat="server" Width="16px" ToolTip="Editar" CommandName="Editar" ImageUrl="/img/modificar_general.gif"
														CausesValidation="False"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="20px"></HeaderStyle>
												<ItemTemplate>
													<asp:ImageButton id="Borrar" runat="server" Width="16px" ToolTip="Editar" CommandName="Borrar" ImageUrl="/img/cruz.gif"
														CausesValidation="False"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999"></PagerStyle>
									</asp:datagrid>
								</td>
							</tr>
							<tr>
								<td class="text" height="38" align="right">
									<asp:Button id="btnNuevoAdicional" runat="server" Text="Agregar Nuevo" onclick="btnNuevoAdicional_Click"></asp:Button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
