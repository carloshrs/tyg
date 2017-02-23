<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Seguridad.Admin.Cuentas.ListaCobranzasPendientesDetalle" CodeFile="ListaCobranzasPendientesDetalle.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD runat="server">
		<title>Lista de Cheques en Cartera</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>

    <script type="text/javascript">
        function imprimir() {
            document.getElementById("divBotones").style.display = 'none';
            window.print();
            document.getElementById("divBotones").style.display = 'block';
        }
    </script>

	<body leftmargin="0" topmargin="0">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<form method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>

			<table cellSpacing="0" cellPadding="2" width="98%" border="0">
				<tr>
					<td class="text" vAlign="top" width="5"></td>
					<td class="text" height="38">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="title" height="38">&nbsp; <STRONG>LISTA COBRANZAS PENDIENTES POR CLIENTE</STRONG><HR>
									<BR>
								</td>
							</tr>
                            <tr><td>
                            
                            <div style="width:94%; margin-bottom:20px; border:1px solid #ccc; background-color:#eee; margin:20px; padding:10px;" id="divBusqueda">
                        <TABLE class="text" cellSpacing="3"cellPadding="1" width="100%" border="0">
				            <TR>
					            <TD>&nbsp;&nbsp;
                                Cliente: <asp:Label runat="server" ID="lblCliente" Font-Bold="true"></asp:Label><br />
						            Fecha desde&nbsp;<asp:Label id="lblFechaInicio" runat="server"  Font-Bold="true"></asp:Label>
                                    &nbsp; 
                                    Fecha hasta <asp:Label id="lblFechaFinal" runat="server"  Font-Bold="true"></asp:Label>
                                   

                                    &nbsp;</TD>
				            </TR>
			            </TABLE>
            
                    </div>
                            </td></tr>
							<tr style="margin-top:30px;">
								<td>
									<asp:datagrid id="dgPendientesCobrosClienteDetalle" runat="server" Font-Size="8pt" 
                                        PageSize="20" CellPadding="3" BorderColor="#3657A6"
										BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False"
										Width="80%">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											
                                            <asp:BoundColumn DataField="ID" HeaderText="Nro" />
                                            <asp:BoundColumn DataField="Fecha" HeaderText="Fecha">
                                            <HeaderStyle Width="160px" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Documento" HeaderText="Concepto" />
                                            <asp:BoundColumn DataField="monto" HeaderText="Precio Unitario" />
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999"></PagerStyle>
									</asp:datagrid>
								</td>
							</tr>
							<tr>
								<td class="text" height="38" align="right">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                                    <div id="divBotones" style="text-align:right">
                                    <input id="Button1" type="button" value="Imprimir" onclick="imprimir();" />&nbsp; 
									<asp:Button id="btnVolver" runat="server" Text="Volver" OnClientClick="javascript:history.back();"></asp:Button> 
                                    </div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
