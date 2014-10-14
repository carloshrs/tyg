<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas.abmlPreciosAdicionales" CodeFile="abmlPreciosAdicionales.aspx.cs" %>
<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administración de Precios</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<form method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="98%" border="0">
				<tr>
					<td class="text" vAlign="top" width="5"></td>
					<td class="text" height="38">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="title" height="38">&nbsp; <STRONG>Administración de servicios adicionales</STRONG>
									<HR>
									<BR>
								</td>
							</tr>
							<tr>
								<td class="text" height="38">
									<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#3657a6" cellSpacing="3"
										cellPadding="1" width="100%" border="1">
										<TR>
											<TD><asp:label id="lblEstado" runat="server" Font-Bold="True"> Alta de precio servicio adicional</asp:label><BR>
												&nbsp;<BR>
												Adicional:
												<asp:DropDownList id="ddAdicional" runat="server">
												</asp:DropDownList>
                                                &nbsp;&nbsp;Precio:
												<asp:textbox id="txtPrecio" runat="server" Width="207px" CssClass="planotext"></asp:textbox>
												
												&nbsp;
												
												<asp:button id="btnAceptar" runat="server" Width="80px" Text="Agregar" onclick="btnAceptar_Click"></asp:button>&nbsp;
												<asp:button id="btnCancelar" runat="server" Width="80px" Text="Cancelar" CausesValidation="False" onclick="btnCancelar_Click"></asp:button><INPUT id="hidPrecioAdicional" type="hidden" size="1" name="hidPrecioAdicional" runat="server">
												<BR>
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td class="text" height="38">&nbsp;<BR>
									<STRONG>Listado de Precios&nbsp;adicionales</STRONG></td>
							</tr>
							<tr>
								<td><asp:datagrid id="dgInformesAdicionales" runat="server" Font-Size="8pt" PageSize="20" CellPadding="3"
										BorderColor="#3657A6" BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" Width="100%" onprerender="dgInformesAdicionales_PreRender">
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="FecDesde" HeaderText="Desde" DataFormatString="{0:dd-MMM-yyyy HH:mm:ss}">
												<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
                                            <asp:BoundColumn DataField="IdServicioAdicional" Visible="false" ></asp:BoundColumn>
                                            <asp:BoundColumn DataField="idServicio" Visible="false" ></asp:BoundColumn>
											<asp:BoundColumn DataField="servicio" HeaderText="Servicio adicional">
												<HeaderStyle Width="185px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Actual" HeaderText="Actual"></asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="25px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Editar" runat="server" Width="16px" CausesValidation="False" ImageUrl="/img/modificar_general.gif"
														CommandName="Editar" ToolTip="Editar"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999"></PagerStyle>
									</asp:datagrid>&nbsp;</td>
							</tr>
							<tr>
								<td align="center">
									<asp:requiredfieldvalidator id="valPrecio" runat="server" CssClass="text" ControlToValidate="txtPrecio" ErrorMessage="*">Ingrese el precio Correctamente</asp:requiredfieldvalidator>
								</td>
							</tr>
							<tr>
								<td align="right">
									<asp:Button id="btnCerrar" runat="server" Text="Cerrar" CausesValidation="False" onclick="btnCerrar_Click"></asp:Button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
