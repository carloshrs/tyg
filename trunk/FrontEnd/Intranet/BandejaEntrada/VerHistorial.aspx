<%@ Register TagPrefix="uc1" TagName="menu" Src="../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada.VerHistorial" CodeFile="VerHistorial.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>VerHistorial</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<uc1:menu id="Menu1" runat="server"></uc1:menu>
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="2%" class="title">&nbsp;</td>
					<td width="96%" class="title">Histórico Acciones<BR>
						<HR>
						<BR>
					</td>
					<td width="2%" class="title">&nbsp;</td>
				</tr>
				<tr>
					<td width="2%" class="title">&nbsp;</td>
					<td width="100%">
						<asp:datagrid id="dgridHistorico" runat="server" Width="100%" GridLines="Vertical" BackColor="White"
							BorderWidth="1px" BorderStyle="Solid" BorderColor="#3657A6" CellPadding="3" PageSize="20" Font-Size="8pt"
							AutoGenerateColumns="False">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
							<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
							<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
							<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="Instante" HeaderText="Instante"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Usuario"></asp:TemplateColumn>
								<asp:BoundColumn DataField="RazonSocial" HeaderText="Cliente"></asp:BoundColumn>
								<asp:BoundColumn DataField="Descripcion" HeaderText="Tipo Evento"></asp:BoundColumn>
								<asp:BoundColumn DataField="Evento" HeaderText="Evento"></asp:BoundColumn>
								<asp:BoundColumn DataField="Observaciones" HeaderText="Observaciones"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="NombreEstado" HeaderText="Estado Actual"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Estado"></asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="idEstado" HeaderText="Estado"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="Nombre"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="Apellido"></asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
								BackColor="#999999"></PagerStyle>
						</asp:datagrid>
					</td>
					<td width="2%" class="title">&nbsp;</td>
				</tr>
				<tr>
					<TD width="100%" colspan="3">&nbsp;</TD>
				</tr>
				<tr>
					<td width="2%" class="title">&nbsp;</td>
					<TD width="96%" align="right"><input type="button" id="Cerrar" value="Cerrar" onclick="history.back();"></TD>
					<td width="2%" class="title">&nbsp;</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
