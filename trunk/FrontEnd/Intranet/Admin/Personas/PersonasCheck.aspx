<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Personas.PersonasCheck" CodeFile="PersonasCheck.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Personas</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
			<base target="_self">
			<script language="javascript">
		<!--
			function descargarDatos(Nom, Ape)
			{
				//opener.document.forms[0].txtNombre.value = Nom;
				//opener.document.forms[0].txtApellido.value = Ape;
				window.returnValue = new Array(Nom,Ape);
				window.close();
			
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
								<td class="title" height="38">&nbsp; <STRONG>Persona existente</STRONG>
									<HR>
								</td>
							</tr>
							<tr>
								<td class="text"><br>
									<font class="Title">Personas que concuerdan con:
										<asp:Label id="lblFiltro" runat="server">Label</asp:Label>
									</font>
									<br>
									<asp:datagrid id="dgPersonas" runat="server" Width="100%" Font-Size="8pt" PageSize="20" CellPadding="3"
										BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="dgPersonas_PreRender">
<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C">
</SelectedItemStyle>

<AlternatingItemStyle BackColor="#FBFBFB">
</AlternatingItemStyle>

<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3">
</ItemStyle>

<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4">
</HeaderStyle>

<FooterStyle ForeColor="Black" BackColor="#CCCCCC">
</FooterStyle>

<Columns>
<asp:BoundColumn DataField="TipoDni" HeaderText="Tipo">
<HeaderStyle Width="50px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="DNI" HeaderText="Nro.Doc.">
<HeaderStyle Width="65px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Nombre" HeaderText="Nombre"></asp:BoundColumn>
<asp:BoundColumn DataField="Apellido" HeaderText="Apellido"></asp:BoundColumn>
<asp:TemplateColumn>
<HeaderStyle Width="24px">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>

<ItemTemplate>
<asp:ImageButton id=ibutPredeterminar runat="server" Width="16px" CausesValidation="False" ImageUrl="/img/Import.gif" CommandName="Predeterminar" ToolTip="Seleccionar persona"></asp:ImageButton>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn Visible="False">
<HeaderStyle Width="24px">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>

<ItemTemplate>
<asp:ImageButton id=ibutVer runat="server" Width="16px" CausesValidation="False" ImageUrl="/img/Lupita.gif" CommandName="Ver" ToolTip="Visualizar"></asp:ImageButton>
</ItemTemplate>
</asp:TemplateColumn>
</Columns>

<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black" BackColor="#999999">
</PagerStyle>
									</asp:datagrid></td>
							</tr>
							<tr>
								<td align="right">
									<br>
									<hr>
									<asp:Button id="btnCerrar" runat="server" Text="Cerrar" CausesValidation="False" onclick="btnCerrar_Click"></asp:Button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
