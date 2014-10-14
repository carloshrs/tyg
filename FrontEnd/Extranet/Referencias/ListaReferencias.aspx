<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Referencias.ListaReferencias" CodeFile="ListaReferencias.aspx.cs" %>
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
					<td width="100%" class="title">
						Grupos de Informes<BR>
						<HR>
						<BR>
					</td>
				</tr>
				<tr>
					<td width="100%">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="text" valign="top" width="5">
								</td>
								<td class="text" height="38">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="text" height="38" align="center">
												&nbsp;&nbsp;Grupos de informes&nbsp;que contengan :
												<asp:textbox id="TxtContengan" runat="server" Width="207px" CssClass="planotext"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:button id="btnBuscar" runat="server" Width="58px" Text="Buscar" onclick="btnBuscar_Click"></asp:button></td>
										</tr>
										<tr>
											<td><asp:datagrid id="dgridReferencias" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="Vertical"
													BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#3657A6" CellPadding="3"
													PageSize="20" Font-Size="8pt" onprerender="dgridEncabezados_PreRender">
													<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
													<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
													<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
													<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
													<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="idReferencia" HeaderText="C&#243;digo">
															<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FechaCarga" HeaderText="Fecha"></asp:BoundColumn>
														<asp:BoundColumn DataField="Descripcion" HeaderText="Descripci&#243;n">
															<HeaderStyle Width="80px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Observaciones" HeaderText="Observaciones">
															<HeaderStyle Width="120px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="NombreEstado" HeaderText="Estado">
															<HeaderStyle Width="15px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Estado"></asp:TemplateColumn>
														<asp:TemplateColumn>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Editar" runat="server" Width="16px" ImageUrl="/img/modificar_general.gif" CommandName="Editar"
																	ToolTip="Editar"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Cancelar" runat="server" Width="16px" ToolTip="Cancelar grupo de informes" CommandName="Cancelar"
																	ImageUrl="\Img\Cruz.gif"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="Estado" HeaderText="Estado"></asp:BoundColumn>
														<asp:TemplateColumn>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Down" runat="server" Width="16px" ImageUrl="\Img\Down.gif" CommandName="Down"
																	ToolTip="Bajar Archivo"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="isFile" HeaderText="isFile"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="Path" HeaderText="Path"></asp:BoundColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
										<tr>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<td align="right"><asp:button id="btnReferencia" runat="server" Width="205px" Text="Nuevo Grupo de informes" onclick="btnInforme_Click"></asp:button></td>
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
