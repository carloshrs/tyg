<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.verifContrato.ListaPersonas" CodeFile="ListaPersonas.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Personas</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
			<script>
			function ToggleImg(name, src, alt)
			{
				name.src = "/img/" + src;
				name.alt = alt
			}

			function mostrarFiltro(First, name)
			{
				if (masInfo.style.display == "none") 
				{
					masInfo.style.display = "list-item";
					ToggleImg(name, 'Cerrar.gif', 'Cerrar Más Info');
				} 
				else 
				{
					masInfo.style.display = "none";
					ToggleImg(name, 'Arrow.gif', 'Más Info');
				}
			}

			</script>
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="text" vAlign="top" colspan="2"><img src="/img/shim.gif" width="1" height="10"></td>
				</tr>
				<tr>
					<td class="text" vAlign="top"><img src="/img/shim.gif" width="5" height="1"></td>
					<td class="title" width="100%">Informe Contractual<BR>
						<HR>
						<BR>
					</td>
				</tr>
				<tr>
					<td class="text" vAlign="top"><img src="/img/shim.gif" width="5" height="1"></td>
					<td width="100%">
						<table cellSpacing="0" cellPadding="0" width="528" border="0">
							<TR>
								<TD class="text" width="100%">
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="title" width="535" bgColor="lightgrey" colSpan="4" height="10">&nbsp;&nbsp;Datos 
												Contrato</TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4" height="5"></TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4" height="15">Tipo Contrato:
												<asp:Label id="txtTipoContrato" runat="server" Font-Bold="True"></asp:Label></TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4"></TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4" height="15">Número Contrato:&nbsp;
												<asp:Label id="txtNumero" runat="server" Font-Bold="True"></asp:Label></TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4"></TD>
										</TR>
										<TR>
											<TD class="text" width="150">Fecha Inicio:
												<asp:Label id="txtFechaInicio" runat="server" Font-Bold="True"></asp:Label></TD>
											<TD class="text" width="150">Fecha Fin:
												<asp:Label id="txtFechaFin" runat="server" Font-Bold="True"></asp:Label></TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4"></TD>
										</TR>
										<TR>
											<td class="text" width="535" colSpan="4">Descripción:&nbsp;&nbsp;
												<asp:Label id="txtDescripcion" runat="server" Font-Bold="True"></asp:Label></td>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4" height="20"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<td width="535" colSpan="4">
									<asp:datagrid id="dgridContratos" runat="server" Width="560px" Font-Size="8pt" PageSize="20" CellPadding="3"
										BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="dgridContratos_PreRender_1">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="idPersona" HeaderText="C&#243;digo">
												<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Tipo" HeaderText="Tipo">
												<HeaderStyle Width="80px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Actor"></asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="Nombre" HeaderText="Nombre">
												<HeaderStyle Width="200px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Apellido" HeaderText="Apellido">
												<HeaderStyle Width="200px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Cuit" HeaderText="Cuit"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="RazonSocial" HeaderText="RazonSocial"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="idTipoPersona" HeaderText="idTipoPersona"></asp:BoundColumn>
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999"></PagerStyle>
									</asp:datagrid>
								</td>
							</TR>
							<TR>
								<TD class="text" width="535" colSpan="4" height="5"></TD>
							</TR>
							<tr>
								<td align="right"></td>
							</tr>
							<TR>
								<TD class="text" width="620" colSpan="5" height="20"><BR>
									<HR>
								</TD>
							</TR>
							<TR>
								<td width="536" colSpan="4">
									<table cellSpacing="0" cellPadding="0" width="560" border="0" height="19">
										<TR>
											<TD class="text" width="60%">&nbsp;</TD>
											<TD class="text" align="right" width="20%"></TD>
											<TD class="text" align="right" width="20%">
												<input id="Cancelar" onclick="javascript:window.close();" type="button" size="20" value="  Cerrar  "></TD>
										</TR>
									</table>
								</td>
							</TR>
						</table>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
