<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Morosidad.pendientes" CodeFile="pendientes.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="menu" Src="../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Bandeja de Entrada</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
		
			<script type="text/javascript">
			function printPendientes(idGrupo)
			{
			    window.printPendientes.src = 'impresionpendientes.aspx?imprimir=1&idGrupo='+idGrupo;
			}
			/*
			function ToggleImg(name, src, alt)
			{
				name.src = "/img/" + src;
				name.alt = alt
			}

			function mostrarFiltro(First, name)
			{
				if (masFiltros.style.display == "none") 
				{
					masFiltros.style.display = "list-item";
					ToggleImg(name, 'Cerrar.gif', 'Cerrar Filtro Avanzado');
					BotonBuscar.style.display = "none";
				} 
				else 
				{
					Tipos.txtFechaInicio.value="";
					Tipos.txtFechaFinal.value="";
					masFiltros.style.display = "none";
					ToggleImg(name, 'Arrow.gif', 'Filtro Avanzado');
					BotonBuscar.style.display = "list-item";
				}
			}
*/
			</script>
			

</HEAD>
	<body leftMargin="0" topMargin="0"> 
		<FORM id="Tipos" method="post" runat="server">
            <!--  onload="javascript:mostrarFiltro(true, '');"-->
		<uc1:menu id="Menu1" runat="server"></uc1:menu>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%">
                        Listados de informes de morosidad pendientes&nbsp;
						<BR>
						<HR>
						<BR>
					</td>
				</tr>
				<tr>
					<TD width="2%">&nbsp;</TD>
					<TD class="text" align="right" width="93%" colSpan="4">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<TD class="text" width="100%">

                                        <asp:datagrid id="dgMorosidadPendientes" runat="server" Width="95%" 
                                        Font-Size="8pt" PageSize="20"
										CellPadding="3" BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="dgMorosidadPendientes_PreRender">
                                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                            <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            <AlternatingItemStyle BackColor="#FBFBFB" />
                                            <ItemStyle BackColor="#F3F3F3" Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                            <HeaderStyle BackColor="#DFE7F4" Font-Bold="True" Font-Names="Arial" ForeColor="#3756A6" />
                                            <Columns>
                                                <asp:BoundColumn Visible="False" DataField="idEncabezado" HeaderText="id"></asp:BoundColumn>
                                                <asp:TemplateColumn>
                                                    <ItemTemplate>
                                                        &nbsp;<asp:CheckBox ID="chkSUrgente" runat="server" Checked="True" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="25px" />
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="FechaCarga" Visible="False" HeaderText="Fecha"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Fecha">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFecha" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="50px" />
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="RazonSocial1" HeaderText="Razón Social">
                                                    <HeaderStyle Width="105px"/>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="DescripcionInf" HeaderText="Descripción"></asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    <br />
                                    &nbsp;<asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red"
                                        Visible="False"></asp:Label>
                                        <iframe frameborder="0" width="50" height="50" id="printPendientes"></iframe>
                                        </TD>
							</tr>
						</TABLE>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="height: 24px" width="50%">
                                    &nbsp;</td>
                                <td style="height: 24px; text-align: right" width="50%">
						<asp:button id="btnImpresiones" runat="server" Width="150px" Text="Impresiones anteriores" 
                                        onclick="btnImpresiones_Click"></asp:button>
                                        &nbsp;<asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
                                    &nbsp;&nbsp;<asp:button id="btnAceptar" runat="server" Width="120px" Text="Aceptar" OnClick="btnAceptar_Click"></asp:button></td>
                            </tr>
                        </table>
                        &nbsp;&nbsp;
                    </TD>
					<TD width="5%">&nbsp;</TD>
				</tr>
			</TABLE>
		<DIV id="divDateControl" style="Z-INDEX: 102; LEFT: -35px; VISIBILITY: hidden; POSITION: absolute; TOP: -150px"><IFRAME name="popFrame" src="../inc/calendar/calendar.htm" frameBorder="0" width="160" scrolling="no"
				height="160"></IFRAME></DIV>
		</FORM>
		</body>
</HTML>
