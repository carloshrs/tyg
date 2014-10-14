<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Extranet.TipoGravamenes.ListaTipoGravamenes" CodeFile="abmlTipoGravamenes.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Listado de tipos de gravámenes</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="text" vAlign="top" width="5"></td>
					<td class="text" height="38">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="text" height="38">&nbsp;<BR>
									<STRONG>Listado de tipos de gravámenes</STRONG>
								</td>
							</tr>
							<tr>
								<td><asp:datagrid id="dgTipoGravamenes" runat="server" Font-Size="8pt" PageSize="20" CellPadding="3"
										BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" Width="100%">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="idTipoGravamen" HeaderText="id">
												<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Descripcion" HeaderText="Descripci&#243;n">
												<HeaderStyle Width="95%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="25px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Editar" runat="server" Width="16px" CausesValidation="False" ImageUrl="/img/modificar_general.gif"
														CommandName="Editar" ToolTip="Editar"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="25px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Cancelar" runat="server" Width="16px" CausesValidation="False" ImageUrl="\Img\Cruz.gif"
														CommandName="Cancelar" ToolTip="Cancelar Informe"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999"></PagerStyle>
									</asp:datagrid>&nbsp;</td>
							</tr>
							<tr>
								<td class="text" height="38">
									<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#3657a6" cellSpacing="3"
										cellPadding="1" width="100%" border="1">
										<TR>
											<TD><asp:label id="lblEstado" runat="server" Font-Bold="True">Alta de tipo de gravamen</asp:label><BR>
												&nbsp;<BR>
												Descripción:
												<asp:textbox id="TxtTipoGravamen" runat="server" Width="207px" CssClass="planotext"></asp:textbox>&nbsp;&nbsp;&nbsp;
												<asp:button id="btnAceptar" runat="server" Width="80px" Text="Aceptar"></asp:button>&nbsp;
												<asp:button id="btnCancelar" runat="server" Width="80px" Text="Cancelar" CausesValidation="False"></asp:button><INPUT id="hidTipoGravamen" type="hidden" size="1" name="hidTipoGravamen" runat="server">
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td>
									<P align="center"><BR>
										<asp:requiredfieldvalidator id="valDescripcion" runat="server" CssClass="text" ErrorMessage="*" ControlToValidate="TxtTipoGravamen">Ingrese la descripción</asp:requiredfieldvalidator></P>
								</td>
							</tr>
							<tr>
								<td align="right"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
