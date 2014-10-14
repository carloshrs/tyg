<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.TipoInforme.abmPreciosTipoInforme" CodeFile="abmClientesCuentaCorriente.aspx.cs" %>
<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administración de Precios</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
        <script type="text/javascript" src="/jquery/jquery-1.4.4.js"></script>

    <script type="text/javascript">

        function ShowIcon() {

            var e = document.getElementById("processing");

            e.style.visibility = (e.style.visibility == 'visible') ? 'hidden' : 'visible';

        }
        function IAmSelected(source, eventArgs) {
            //alert( " Key : "+ eventArgs.get_text() +"  Value :  "+eventArgs.get_value()); 
            valor = eventArgs.get_value();
            document.getElementById("hIdCliente").value = valor;
        }

        var expandedRows = {};
        function toggleRowVisibility(rowID, button) {
            var doUpdate = document.getElementById('ctl00_mainArea_iterationsList_doUpdate');
            var row = document.getElementById(rowID);
            var src = button.src;
            var display = row.style.display;
            if (display == 'none') {
                row.style.display = '';
                if (src.indexOf('plus') > -1) {
                    button.src = src.replace('plus', 'minus');
                }
                if (expandedRows[rowID]) {
                    doUpdate.value = '';
                }
                else {
                    doUpdate.value = 'update';
                }
            }
            else {
                row.style.display = 'none';
                if (src.indexOf('minus') > -1) {
                    button.src = src.replace('minus', 'plus');
                }
                expandedRows[rowID] = true;
                doUpdate.value = '';
            }
        }
        </script>

	</HEAD>
	<body leftMargin="0" topMargin="0">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<form method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
                            EnablePartialRendering="true" EnableScriptGlobalization="True">
         </asp:ScriptManager>
			<table cellSpacing="0" cellPadding="0" width="98%" border="0">
				<tr>
					<td class="text" vAlign="top" width="5"></td>
					<td class="text" height="38">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="title" height="38">&nbsp; <STRONG>Cuentas Corrientes - Administración de Clientes</STRONG>
									<HR>
									<BR>
								</td>
							</tr>
							<tr>
								<td class="text" height="38">
									<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#3657a6" cellSpacing="3"
										cellPadding="1" width="100%" border="1">
										<TR>
											<TD><asp:label id="lblEstado" runat="server" Font-Bold="True"> Alta de Cliente</asp:label><BR>
												&nbsp;<BR>
												Cliente:
												<asp:RequiredFieldValidator ID="rqCliente" runat="server" 
                                                    ErrorMessage="Seleccione cliente" ControlToValidate="txtCliente">*</asp:RequiredFieldValidator>
												<asp:textbox id="txtCliente" runat="server" Width="207px" CssClass="planotext"></asp:textbox> <img id="processing" style="visibility:hidden" src="/img/ajaxloader-thumb.gif"  />
                                                <cc1:AutoCompleteExtender ID="txtCliente_AutoCompleteExtender" runat="server" 
                                                    TargetControlID="txtCliente"
                                                    ServicePath="~/services/clientes.asmx" 
                                                    UseContextKey="True"
                                                    ServiceMethod="getClientes" 
                                                    MinimumPrefixLength="3" 
                                                    CompletionSetCount="12" 
                                                    CompletionInterval="1000"
                                                    onclientpopulating="ShowIcon"
                                                    onclientpopulated="ShowIcon"
                                                    OnClientItemSelected="IAmSelected">
                                                </cc1:AutoCompleteExtender><asp:HiddenField ID="hIdCliente" runat="server" />
                                                &nbsp;&nbsp;&nbsp;
                                                
												<asp:button id="btnAceptar" runat="server" Width="80px" Text="Agregar" onclick="btnAceptar_Click"></asp:button>&nbsp;
												<asp:button id="btnCancelar" runat="server" Width="80px" Text="Cancelar" CausesValidation="False" onclick="btnCancelar_Click"></asp:button><INPUT id="hidFecha" type="hidden" size="1" name="hidFecha" runat="server">
												<BR>
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td class="text" height="38">&nbsp;<BR>
									<STRONG>Listado de Clientes con cuenta corriente</STRONG></td>
							</tr>
							<tr>
								<td><asp:datagrid id="dgridClientes" runat="server" Width="100%" AllowPaging="True" Font-Size="8pt"
										PageSize="12" CellPadding="3" BorderColor="#3657A6" BorderStyle="Solid" BorderWidth="1px" BackColor="White"
										GridLines="Vertical" AutoGenerateColumns="False" onitemcommand="dgridClientes_ItemCommand">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="IdCliente" HeaderText="C&#243;digo">
												<HeaderStyle HorizontalAlign="Center" Width="45px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RazonSocial" HeaderText="Raz&oacute;n Social">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreFantasia" HeaderText="Nombre Fantasia">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Sucursal" HeaderText="Sucursal">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Telefono" HeaderText="Tel&#233;fono">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Fax" HeaderText="Fax">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="CUIT" HeaderText="CUIT">
												<HeaderStyle Width="45px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Email" HeaderText="Correo Electr&#243;nico">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Direccion" HeaderText="Dirección">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="20px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Eliminar" runat="server" Width="16px" ToolTip="Cancelar Cliente" CommandName="Eliminar"
														ImageUrl="/Img/Cruz.gif" CausesValidation="false" OnClientClick="if (!confirm('Desea quitar el cliente de la cuenta corriente?')) { return false;}"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999" PageButtonCount="8" Mode="NumericPages"></PagerStyle>
									</asp:datagrid>&nbsp;</td>
							</tr>
							<tr>
								<td align="center">
									&nbsp;</td>
							</tr>
							<tr>
								<td align="right">
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
