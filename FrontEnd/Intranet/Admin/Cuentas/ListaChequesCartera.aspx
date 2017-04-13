<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Seguridad.Admin.Cuentas.ListaChequesCartera" CodeFile="ListaChequesCartera.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Lista de Cheques en Cartera</title>
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
								<td class="title" height="38">&nbsp; <STRONG>LISTADO DE CHEQUES</STRONG>
									<HR>
									<BR>
								</td>
							</tr>

							<tr style="margin-top:30px;">
								<td>
									<asp:datagrid id="dgChequesCartera" runat="server" Font-Size="8pt" 
                                        PageSize="20" CellPadding="3" BorderColor="#3657A6"
										BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False"
										Width="80%" OnPreRender="dgChequesCartera_PreRender" onitemcommand="dgChequesCartera_ItemCommand">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="idChequeCartera">
												<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>

                                            <asp:BoundColumn DataField="ch_fechaCobro" HeaderText="Fecha cobro" Visible="false">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>

                                            <asp:TemplateColumn  HeaderText="Fecha cobro">
												<HeaderStyle Width="150px"></HeaderStyle>
												<ItemTemplate>
													<asp:Label id="lblFechaCobro" runat="server"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>

											<asp:BoundColumn DataField="ch_banco" HeaderText="Banco">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>

                                            <asp:BoundColumn DataField="ch_numero" HeaderText="Nro. Cheque">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>

                                            <asp:BoundColumn DataField="monto" HeaderText="Monto">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
                                            
                                            <asp:TemplateColumn>
												<HeaderStyle Width="20px"></HeaderStyle>
												<ItemTemplate>
													<asp:ImageButton id="Detalle" runat="server" Width="16px" ToolTip="Detalle" CommandName="Detalle" ImageUrl="/img/ico-detalles.gif"
														CausesValidation="False"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999"></PagerStyle>
									</asp:datagrid>
                                     <div style="text-align:right; margin-top:10px; font-weight:bold; width:75%;">TOTAL: <asp:Label ID="lblTotal" runat="server" Font-Bold="true"></asp:Label></div>
								</td>
							</tr>
							<tr>
								<td class="text" height="38" align="right">
                                
									<asp:Button id="btnVolver" runat="server" Text="Volver" OnClientClick="javascript:history.back();"></asp:Button> 
                                    
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
