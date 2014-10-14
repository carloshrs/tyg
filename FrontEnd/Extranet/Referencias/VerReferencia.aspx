<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Informes.VerReferencia" CodeFile="VerReferencia.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Alta de Informe</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
			<script>
		function Archivo()
		{
			if (chkFile.checked) 
			{
				txtArchivo.style.display = "list-item";
			} else {
				txtArchivo.style.display = "none";
			
			}
		}
			</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%" colSpan="2">Visualizar&nbsp;Referencia<BR>
						<HR>
					</td>
				</tr>
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%">
						<table cellSpacing="0" cellPadding="0" width="480" border="0">
							<TR>
								<TD class="text" colSpan="4" height="10"></TD>
							</TR>
							<TR>
								<TD class="text" width="60%" colSpan="4">&nbsp;Descripción:&nbsp;
									<asp:Label id="lblDescripcion" runat="server" CssClass="txtlabel">Label</asp:Label></TD>
							</TR>
							<TR>
								<TD class="text" width="100%" colSpan="4"></TD>
							</TR>
							<TR>
								<TD class="text" width="282" colSpan="4">&nbsp;Observaciones&nbsp;
									<asp:Label id="lblObservaciones" runat="server" CssClass="txtlabel">Label</asp:Label></TD>
							</TR>
							<TR>
								<TD class="text" width="100%" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="text" width="282" colSpan="4">&nbsp;Archivo:&nbsp;
									<asp:Label id="lblFile" runat="server" CssClass="txtlabel">Label</asp:Label></TD>
							</TR>
							<TR>
								<TD class="text" width="30%" height="8">&nbsp;</TD>
								<TD class="text" vAlign="middle" width="70%" height="8">&nbsp; </SPAN></TD>
							</TR>
						</table>
					</td>
				</tr>
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="98%">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<td colSpan="2"><asp:panel id="pnlInformes" runat="server">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="title" width="100%" colSpan="2">Informes<BR>
													<HR>
												</TD>
											</TR>
											<TR>
												<TD class="text" width="100%">
													<asp:datagrid id="dgridEncabezados" runat="server" Font-Size="8pt" PageSize="20" CellPadding="3"
														BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White" GridLines="Vertical"
														AutoGenerateColumns="False" Width="100%" onprerender="dgridEncabezados_PreRender">
														<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
														<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
														<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
														<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
														<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="idEncabezado" HeaderText="C&#243;digo">
																<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="FechaCarga" HeaderText="Fecha"></asp:BoundColumn>
															<asp:BoundColumn DataField="Descripcion" HeaderText="Tipo Informe">
																<HeaderStyle Width="80px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="DescripcionInf" HeaderText="Descripci&#243;n">
																<HeaderStyle Width="120px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="Comentarios" HeaderText="Observaciones">
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
																	<asp:ImageButton id="Editar" runat="server" Width="16px" ToolTip="Ver Informe" CommandName="VerInforme"
																		ImageUrl="/img/lupita.gif"></asp:ImageButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<asp:ImageButton id="Cancelar" runat="server" Width="16px" ToolTip="Ver Historial" CommandName="VerHistorial"
																		ImageUrl="\Img\Reloj.jpg"></asp:ImageButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn Visible="False" DataField="Estado"></asp:BoundColumn>
														</Columns>
														<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
															BackColor="#999999"></PagerStyle>
													</asp:datagrid>&nbsp;
												</TD>
											</TR>
											<TR>
												<TD align="right" width="100%"></TD>
											</TR>
										</TABLE>
									</asp:panel></td>
							</TR>
							<TR>
								<td colSpan="4"><BR>
									<HR>
								</td>
							</TR>
							<TR>
								<td colSpan="4">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="text" width="60%">&nbsp;</TD>
											<TD class="text" align="right" width="20%"></TD>
											<TD class="text" align="right" width="20%"><input type="button" onclick="javascript:location='ListaReferencias.aspx';" value="Cerrar"
													size="40"></TD>
										</TR>
									</table>
								</td>
							</TR>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
