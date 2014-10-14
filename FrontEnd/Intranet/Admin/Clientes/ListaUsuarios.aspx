<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Clientes.ListaUsuarios" CodeFile="ListaUsuarios.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListaUsuarios</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="2" width="98%" border="0">
				<tr>
					<td class="text" valign="top" width="5">
					</td>
					<td class="text" height="38">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="title" height="38">
									Listado de&nbsp;Usuarios
									<hr>
									<br>
								</td>
							</tr>
							<tr>
								<td class="text" height="38">
									&nbsp;&nbsp;Texto a Filtrar&nbsp;:
									<asp:textbox id="TxtFiltro" runat="server" Width="207px" CssClass="planotext"></asp:textbox>&nbsp;&nbsp; 
									del Cliente:&nbsp;&nbsp;
									<asp:DropDownList id="ddlClientes" runat="server"></asp:DropDownList>
									<asp:Label id="lblCliente" runat="server" Visible="False">Label</asp:Label>
									&nbsp;&nbsp;&nbsp;
									<asp:button id="btnBuscar" runat="server" Width="58px" Text="Buscar" onclick="btnBuscar_Click"></asp:button></td>
							</tr>
							<tr>
								<td>
									<asp:datagrid id="dgridUsuarios" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="Vertical"
										BackColor="White" BorderWidth="1px" BorderStyle="Solid" BorderColor="#3657A6" CellPadding="3"
										PageSize="50" Font-Size="8pt" AllowPaging="True" onprerender="dgridUsuarios_PreRender">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="IdUsuario" HeaderText="N&#250;mero">
												<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Nombre y Apellido">
												<ItemTemplate>
													<asp:Label id="lblNomApe" runat="server">Nombre y Apellido</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="LoginName" HeaderText="Nombre de Usuario">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Email" HeaderText="Correo Electr&#243;nico">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RazonSocial" HeaderText="Cliente"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="UltimoIngreso" HeaderText="Ingres&#243;">
												<HeaderStyle Width="75px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="20px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Editar" runat="server" Width="16px" ImageUrl="/img/modificar_general.gif" CommandName="Editar"
														ToolTip="Editar datos del Usuario"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="20px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Borrar" runat="server" Width="16px" ImageUrl="\Img\Cruz.gif" CommandName="Borrar"
														ToolTip="Borrar el Usuario"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="Nombre"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Apellido"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Intranet"></asp:BoundColumn>
                                            <asp:BoundColumn Visible="False" DataField="Estado"></asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="20px"></HeaderStyle>
												<ItemTemplate>
													<asp:ImageButton id="Roles" runat="server" Width="16px" ImageUrl="\Img\Funciones.gif" CommandName="Roles"
														ToolTip="Asignar Roles al Usuario"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999" PageButtonCount="8" Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td align="right"><asp:button id="btnNewUser" runat="server" Width="155px" Text="Nuevo Usuario" onclick="btnNewUser_Click"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
