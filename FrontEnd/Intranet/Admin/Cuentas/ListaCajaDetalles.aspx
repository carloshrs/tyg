<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Seguridad.Admin.Cuentas.ListaCajaDetalles" CodeFile="ListaCajaDetalles.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Lista de Caja</title>
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
								<td class="title" height="38">&nbsp; <STRONG>DETALLES CAJA DIARIA</STRONG>
									<HR>
									<BR>
								</td>
							</tr>
                            <tr>
                            <td>
                                <asp:Panel ID="pnlEncabezado" runat="server">
                                    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
							            <tr>
								            <td class="title" style="width:200px;">Fecha apertura: </td><td class="title"> <asp:Label ID="lblFechaApertura" runat="server" Text="" Font-Size="10"></asp:Label></td>
                                            <td class="title">Fecha cierre: </td><td class="title"> <asp:Label ID="lblFechaCierre" runat="server" Text="" Font-Size="10"></asp:Label></td>
                                        </tr>
                                        <tr>
								            <td class="title">Saldo efectivo: </td><td class="title">$ <asp:Label ID="lblSaldoEfectivo" runat="server" Text="" Font-Bold="true"></asp:Label></td>
                                            <td class="title" style="background:#EEE;">Monto efectivo inicial: </td><td class="title" style="background:#EEE;">$ <asp:Label ID="lblEfectivoInicial" runat="server" Text="" Font-Bold="true"></asp:Label></td>
                                        </tr>
                                        <tr>
                                        <td class="title">Saldo cheque: </td><td class="title">$ <asp:Label ID="lblSaldoCheque" runat="server" Text="" Font-Bold="true"></asp:Label></td>
								            
                                            <td class="title" style="background:#EEE;">Monto cheque inicial: </td><td class="title" style="background:#EEE;">$ <asp:Label ID="lblChequeInicial" runat="server" Text="" Font-Bold="true"></asp:Label></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            
                            </td>
                            <tr><td>&nbsp;</td></tr>
                            </tr>
							<tr style="margin-top:30px;">
								<td>
									<asp:datagrid id="dgCajaDiariaDetalle" runat="server" Font-Size="8pt" PageSize="20" CellPadding="3" BorderColor="#3657A6"
										BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False"
										Width="100%">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="idCajaDetalle">
												<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="concepto" HeaderText="Concepto">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
                                            <asp:BoundColumn DataField="monto" HeaderText="Monto">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
                                            <asp:BoundColumn DataField="entradasalida" HeaderText="Ingreso / Egreso" Visible="false">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
                                            <asp:TemplateColumn>
                                            <HeaderStyle Width="20px"></HeaderStyle>
												<ItemTemplate>
													<asp:Label id="lblEntrada" runat="server"></asp:Label>
												</ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:BoundColumn DataField="fecha" HeaderText="Fecha">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999"></PagerStyle>
									</asp:datagrid>
								</td>
							</tr>
							<tr>
								<td class="text" height="38" align="right">
									<asp:Button id="btnVolver" runat="server" Text="Volver" OnClientClick="javascript:history.back();"></asp:Button> <asp:Button id="btnNuevo" runat="server" Text="Nuevo concepto"></asp:Button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
