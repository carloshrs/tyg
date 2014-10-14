<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Caracter.ListaCaracter" CodeFile="abmlCaracter.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Listado de caracteres</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="text" valign="top" width="5">
					</td>
					<td class="text" height="38">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="text" height="38">&nbsp;<BR>
									<STRONG>Listado de&nbsp;Carácteres</STRONG>
								</td>
							</tr>
							<tr>
								<td><asp:datagrid id="dgCaracter" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="Vertical"
										BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#3657A6" CellPadding="3"
										PageSize="20" Font-Size="8pt">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="idCaracter" HeaderText="id">
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
									<TABLE cellSpacing="3" cellPadding="1" width="100%" border="1" bordercolor="#3657a6" style="BORDER-COLLAPSE:collapse"
										class="text">
										<TR>
											<TD>
												<asp:Label id="lblEstado" runat="server" Font-Bold="True"> Alta de caracter</asp:Label><BR>
												&nbsp;<BR>
												Descripción:
												<asp:textbox id="TxtCaracter" runat="server" Width="207px" CssClass="planotext"></asp:textbox>&nbsp;&nbsp;&nbsp;
												<asp:button id="btnAceptar" runat="server" Width="80px" Text="Aceptar"></asp:button>&nbsp;
												<asp:button id="btnCancelar" runat="server" Width="80px" Text="Cancelar" CausesValidation="False"></asp:button><INPUT type="hidden" runat="server" size="1" NAME="hidCaracter" id="hidCaracter">
												<BR>
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td>
									<P align="center"><BR>
										&nbsp;
										<asp:RequiredFieldValidator id="valDescripcion" runat="server" CssClass="text" ErrorMessage="*" ControlToValidate="TxtCaracter">Ingrese la descripción</asp:RequiredFieldValidator></P>
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
