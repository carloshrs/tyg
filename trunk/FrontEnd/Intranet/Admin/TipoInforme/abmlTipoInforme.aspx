<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Extranet.TipoInforme.ListaTipoInforme" CodeFile="abmlTipoInforme.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Listado de tipos de informes</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<form id="lstTiposInforme" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="98%" border="0">
				<tr>
					<td class="text" valign="top" width="5">
					</td>
					<td class="text" height="38">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="title" height="38">&nbsp; <STRONG>Listado de Tipos de Informe</STRONG>
									<HR>
									<BR>
								</td>
							</tr>
							<tr>
								<td><asp:datagrid id="dgTipoInforme" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="Vertical"
										BackColor="White" BorderWidth="1px" BorderStyle="Solid" BorderColor="#3657A6" CellPadding="3"
										PageSize="20" Font-Size="8pt">
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="idTipoInforme" HeaderText="id">
												<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Descripcion" HeaderText="Descripci&#243;n">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="20px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Editar" runat="server" Width="16px" CausesValidation="False" ToolTip="Precios"
														CommandName="Precios" ImageUrl="/Img/Precios.gif"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999"></PagerStyle>
									</asp:datagrid>&nbsp;</td>
							</tr>
							<tr>
								<td align="right">
									<asp:Button id="btnCerrar" runat="server" Text="Cerrar" onclick="btnCerrar_Click"></asp:Button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
