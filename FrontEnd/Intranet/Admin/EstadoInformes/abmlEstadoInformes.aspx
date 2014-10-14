<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Extranet.EstadoInforme.ListaEstadoInforme" CodeFile="abmlEstadoInformes.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Listado de informes</title>
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
									<STRONG>Listado de estados de informes</STRONG>
								</td>
							</tr>
							<tr>
								<td><asp:datagrid id="dgEstadoInforme" runat="server" Font-Size="8pt" PageSize="20" CellPadding="3"
										BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" Width="100%">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="idEstado" HeaderText="id">
												<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreEstado" HeaderText="Nombre">
												<HeaderStyle Width="250px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DescripcionEstado" HeaderText="Descripci&#243;n">
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
											<TD>
												<TABLE class="text" cellSpacing="1" cellPadding="1" width="400" border="0">
													<TR>
														<TD colSpan="2"><asp:label id="lblEstado" runat="server" Font-Bold="True">Alta de estado de informe</asp:label></TD>
													</TR>
													<TR>
														<TD>Nombre:
														</TD>
														<TD><asp:textbox id="TxtNombre" runat="server" Width="416px" CssClass="planotext"></asp:textbox></TD>
													</TR>
													<TR>
														<TD vAlign="top">Descripción:</TD>
														<TD><asp:textbox id="txtDescripcion" runat="server" Width="416px" CssClass="planotext" TextMode="MultiLine"
																Height="48px"></asp:textbox></TD>
													</TR>
													<TR>
														<TD></TD>
														<TD>
															<P align="right"><INPUT id="hidEstadoInforme" type="hidden" size="1" name="hidEstadoInforme" runat="server">
																<asp:button id="btnAceptar" runat="server" Width="80px" Text="Aceptar"></asp:button>&nbsp;
																<asp:button id="btnCancelar" runat="server" Width="80px" Text="Cancelar" CausesValidation="False"></asp:button></P>
														</TD>
													</TR>
												</TABLE>
												&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<TR>
								<TD>
									<P align="center"><BR>
										<asp:RequiredFieldValidator id="valNombre" runat="server" CssClass="text" ErrorMessage="*" ControlToValidate="TxtNombre">Ingrese el nombre</asp:RequiredFieldValidator></P>
								</TD>
							</TR>
							<TR>
								<TD align="right"></TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
