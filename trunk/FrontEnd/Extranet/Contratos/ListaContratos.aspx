<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Contratos.ListaContratos" CodeFile="ListaContratos.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListaInformes</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="title" width="100%">Contratos<BR>
						<HR>
						<BR>
					</td>
				</tr>
				<tr>
					<td width="100%">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="text" vAlign="top" width="5"></td>
								<td class="text" height="38">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="text" align="center" height="38">
												&nbsp;&nbsp;Que contenga :
												<asp:textbox id="TxtContengan" runat="server" CssClass="planotext" Width="207px"></asp:textbox>
												&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:dropdownlist id="cmbTipo" runat="server" Width="205px"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:button id="btnBuscar" runat="server" Width="58px" Text="Buscar" onclick="btnBuscar_Click"></asp:button></td>
										</tr>
										<tr>
											<td><asp:datagrid id="dgridEncabezados" runat="server" Width="100%" Font-Size="8pt" PageSize="20"
													CellPadding="3" BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White"
													GridLines="Vertical" AutoGenerateColumns="False" onprerender="dgridEncabezados_PreRender">
													<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
													<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
													<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
													<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
													<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="idContrato" HeaderText="C&#243;digo">
															<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="TIDescripcion" HeaderText="Tipo">
															<HeaderStyle Width="80px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Numero" HeaderText="N&#250;mero">
															<HeaderStyle Width="40px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Descripcion" HeaderText="Descripci&#243;n">
															<HeaderStyle Width="350px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Fecha Inicio"></asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="FechaInicio" HeaderText="Inicio">
															<HeaderStyle Width="20px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Fecha Fin"></asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="FechaFin" HeaderText="Fin">
															<HeaderStyle Width="20px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="10px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Editar" runat="server" Width="16px" ToolTip="Editar Contrato" CommandName="Editar"
																	ImageUrl="/img/modificar_general.gif"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="10px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Cancelar" runat="server" Width="16px" ToolTip="Eliminar Contrato" CommandName="Cancelar"
																	ImageUrl="\Img\Cruz.gif"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="10px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Ver" runat="server" Width="16px" ToolTip="Visualizar Contrato" CommandName="Ver"
																	ImageUrl="\Img\Lupita.gif"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="idCliente" HeaderText="idCliente"></asp:BoundColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="25px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Historico" runat="server" Width="16px" ToolTip="Ver Historial..." CommandName="Historico"
																	Height="16px" ImageUrl="..\Img\reloj.jpg"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
														BackColor="#999999"></PagerStyle>
												</asp:datagrid></td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<td align="right"><asp:button id="btnInforme" runat="server" Width="155px" Text="Nuevo Contrato" onclick="btnInforme_Click"></asp:button></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
