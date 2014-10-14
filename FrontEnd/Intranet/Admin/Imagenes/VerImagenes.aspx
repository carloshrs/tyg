<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Imagenes.VerImagenes" CodeFile="VerImagenes.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Imágenes</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
			<base target="_self">
			<script language="javascript">
		<!--
			function Mostrar(lUrl)
			{
				window.open(lUrl, '', 'tools=no,width=580,height=450,menus=no,scrollbars=yes');
			}
		-->
			</script>
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Imagenes" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="615" border="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="title" height="38">&nbsp; <STRONG>Administración de Imágenes</STRONG>
									<HR>
								</td>
							</tr>
							<tr>
								<td class="text"><br>
									<font class="Title">Imagenes del Formulario:</font><br>
									<asp:datagrid id="dgImagenes" runat="server" Width="100%" Font-Size="8pt" PageSize="20" CellPadding="3"
										BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False">
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="NroImagen" HeaderText="Nro.">
												<HeaderStyle Width="65px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Descripcion" HeaderText="Descripci&#243;n"></asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="24px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="ibutPredeterminar" runat="server" Width="16px" ToolTip="Predeterminar esta imagen"
														CommandName="Predeterminar" ImageUrl="/img/Predeterminar.gif" CausesValidation="False"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="24px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="ibutVer" runat="server" Width="16px" ToolTip="Visualizar" CommandName="Ver"
														ImageUrl="/img/Lupita.gif" CausesValidation="False"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="Path">
												<HeaderStyle Width="24px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Predeterminada"></asp:BoundColumn>
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999"></PagerStyle>
									</asp:datagrid></td>
							</tr>
							<tr>
								<td align="right">
									<br>
									<hr>
									<asp:Button id="btnCerrar" runat="server" Text="Cerrar" CausesValidation="False"></asp:Button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
