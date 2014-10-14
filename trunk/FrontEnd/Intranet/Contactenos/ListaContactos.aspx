<%@ Register TagPrefix="uc1" TagName="menu" Src="../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Contactenos.ListaContactos" CodeFile="ListaContactos.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListaInformes</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
        <style type="text/css">
			#pagination-digg-bandeja li{
		        border:0; margin:0; padding:0;
		        font-size:11px;
		        list-style:none;
		        float:left;
	        }
	        #pagination-digg-bandeja a{
		        border:solid 1px #C6C6B7;
		        margin-right:2px;
		        float:left;
	        }
	        #pagination-digg-bandeja .previous-off,
	        #pagination-digg-bandeja .next-off {
		        border:solid 1px #DEDEDE;
		        color:#888888;
		        display:block;
		        float:left;
		        font-weight:bold;
		        margin-right:2px;
		        padding:3px 4px;
	        }
	        #pagination-digg-bandeja .next a,
	        #pagination-digg-bandeja .previous a {
	         font-weight:bold;
	         float:left;
	        }
	        .previous-bandeja {
	         font-weight:bold;
	         float:left;
	        }
	        .next-bandeja {
	         font-weight:bold;
	         float:left;
	        }
	        #pagination-digg-bandeja .active-bandeja{
		        background:#4C4C4C;
		        color:#FFFFFF;
		        font-weight:bold;
		        display:block;
		        float:left;
		        padding:4px 6px;
	        }
	        #pagination-digg-bandeja a:link, 
	        #pagination-digg-bandeja a:visited {
		        color:#4C4C4C;
		        display:block;
		        float:left;
		        padding:3px 6px;
		        text-decoration:none;
	        }
	        #pagination-digg-bandeja a:hover{
		        border:solid 1px #98987C;
	        }
			div{font-family:Arial, Helvetica, sans-serif; font-size:12px;}
            ul{border:0; margin:0; padding:0;}
			</style>

            <script language="javascript">
                function paginadorIrA(pagina) {
                    document.getElementById("hPagina").value = pagina;
                    __doPostBack('hEmpresas', pagina);
                }
            </script>
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<uc1:menu id="Menu1" runat="server"></uc1:menu><BR>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
            <tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%">Listado de Consultas
						<BR>
						<hr noshade style="height:1px; border:0px;">
					</td>
				</tr>
				<tr>
					<td class="text" valign="top" width="5">&nbsp;</td>
					<td class="text" height="38">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="text" height="38" align="center">
									&nbsp;&nbsp;Comentarios&nbsp;que contengan :
									<asp:textbox id="TxtContengan" runat="server" Width="207px" CssClass="planotext"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="btnBuscar" runat="server" Width="58px" Text="Buscar"></asp:button></td>
							</tr>
							<tr>
								<td><asp:datagrid id="dgridContacto" runat="server" Width="100%" 
                                        AutoGenerateColumns="False" GridLines="Vertical"
										BackColor="White" BorderWidth="1px" BorderStyle="Solid" BorderColor="#3657A6" CellPadding="3"
										PageSize="20" Font-Size="8pt" onitemcommand="dgridContacto_ItemCommand" 
                                        onprerender="dgridContacto_PreRender">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="idConsulta" HeaderText="C&#243;digo">
												<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="FechaCarga" HeaderText="Fecha"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Fecha">
                                                <HeaderStyle Width="80px"></HeaderStyle>
												<ItemTemplate>
													<asp:Label id="lblFecha" runat="server"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
                                            <asp:BoundColumn Visible="False" DataField="Origen" HeaderText="Origen"></asp:BoundColumn>
                                            <asp:TemplateColumn HeaderText="Origen">
												    <HeaderStyle Width="100px"></HeaderStyle>
                                                    <ItemTemplate>
													<asp:Label id="lblOrigen" runat="server"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="empresa" HeaderText="Cliente">
												<HeaderStyle Width="120px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="servicio" HeaderText="Tipo Comentario"></asp:BoundColumn>
											<asp:TemplateColumn>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Ver" runat="server" Width="16px" ImageUrl="/img/lupita1.gif" CommandName="Ver"
														ToolTip="Ver consulta"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
                                            <asp:BoundColumn Visible="False" DataField="leido"></asp:BoundColumn>
										</Columns>
									</asp:datagrid></td>
							</tr>
                            <tr>
											<td>
                                                <asp:HiddenField ID="hPagina" runat="server" OnValueChanged="hPagina_ValueChanged"
                                                    Value="1" /><asp:HiddenField ID="hTipoBusqueda" runat="server" Value="0" />
                                                &nbsp;<table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="center" style="height: 50px">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Literal ID="litPaginador" runat="server" Mode="PassThrough"></asp:Literal></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
										</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td align="right"><asp:button id="btnVolver" runat="server" Width="155px" Text="Volver"></asp:button></td>
							</tr>
						</table>
					</td>
					<td class="text" valign="top" width="5">&nbsp;&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
