<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Informes.MatriculaCheck" CodeFile="MatriculaCheck.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Verificación de matrículas solicitadas</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
			<base target="_self">
			<script language="javascript">
		<!--
			function descargarDatos(Nom, Ape)
			{
				//opener.document.forms[0].txtNombre.value = Nom;
				//opener.document.forms[0].txtApellido.value = Ape;
				window.returnValue = new Array(Nom,Ape);
				//window.close();
			
			}
		//-->
			</script>
</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Personas" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="615" border="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="title" height="38">&nbsp; <STRONG>
										<asp:label id="txtTipo" runat="server" CssClass="title"></asp:label>&nbsp;solicitada 
										anteriormente</STRONG>&nbsp;
									<HR>
								</td>
							</tr>
							<tr>
								<td class="text"><br>
									<font class="Title">
										<asp:label id="lblFiltro" runat="server"></asp:label></font><br>
									<asp:datagrid id="dgMatriculas" runat="server" AutoGenerateColumns="False" GridLines="Vertical"
										BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#3657A6" CellPadding="3"
										PageSize="20" Font-Size="8pt" Width="100%" onprerender="dgMatriculas_PreRender">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="Fecha" HeaderText="Fecha">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Fecha">
												<HeaderStyle Width="24px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblFecha" runat="server"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="Cliente" HeaderText="Solicitada por"></asp:BoundColumn>
											<asp:TemplateColumn Visible="False">
												<HeaderStyle Width="24px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="ibutVer" runat="server" Width="16px" CausesValidation="False" ImageUrl="/img/Lupita.gif" 
 CommandName="Ver" ToolTip="Visualizar"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999"></PagerStyle>
									</asp:datagrid></td>
							</tr>
							<tr>
								<td align="right"><br>
									<hr>
									<asp:button id="btnCerrar" runat="server" CausesValidation="False" Text="Cerrar" onclick="btnCerrar_Click"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
