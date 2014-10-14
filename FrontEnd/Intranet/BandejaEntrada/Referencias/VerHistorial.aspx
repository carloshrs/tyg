<%@ Register TagPrefix="uc1" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada.Referencia.VerHistorialReferencias" CodeFile="VerHistorial.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>VerHistorial</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form2" method="post" runat="server">
			<uc1:menu id="Menu1" runat="server"></uc1:menu>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%" colSpan="2"><BR>
						Histórico Acciones Referencias<BR>
						<HR>
						<BR>
					</td>
					<TD width="2%">&nbsp;</TD>
				</tr>
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td width="98%">
						<asp:datagrid id="dgridHistorico" runat="server" Width="100%" GridLines="Vertical" BackColor="White"
							BorderWidth="1px" BorderStyle="None" BorderColor="#3657A6" CellPadding="3" PageSize="20" Font-Size="8pt"
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
								<asp:BoundColumn Visible="False" DataField="Nombre" HeaderText="Nombre"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="Apellido"></asp:BoundColumn>
							</Columns>
						</asp:datagrid>
					</td>
					<TD width="2%">&nbsp;</TD>
				</tr>
				<tr>
					<TD width="2%" colspan="3">&nbsp;</TD>
				</tr>
				<tr>
					<TD width="2%">&nbsp;</TD>
					<TD width="96%" align="right"><asp:Button id="Cerrar" runat="server" Text="Cerrar" Width="104px"></asp:Button></TD>
					<TD width="2%">&nbsp;</TD>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
