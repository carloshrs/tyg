<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Seguridad.Admin.Cuentas.ListaCobranzasPendientes" CodeFile="ListaCobranzasPendientes.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD runat="server">
		<title>Lista de Cheques en Cartera</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>


    <script src="/jquery/jquery-1.7.2.min.js" type="text/javascript"></script>

    

    <script type="text/javascript">


        function select_deselectAll(chkVal, idVal, grupo) {
            var frm = document.forms[0];
            // Loop through all elements
            for (i = 0; i < frm.length; i++) {
                // Look for our Header Template's Checkbox
                if (idVal.indexOf('CheckAll') != -1) {
                    // Check if main checkbox is checked, then
                    //select or deselect datagrid checkboxes
                    if (frm.elements[i].name.indexOf(grupo) != -1) {
                        if (chkVal == true) {
                            frm.elements[i].checked = true;
                        }
                        else {
                            frm.elements[i].checked = false;
                        }
                    }
                    // Work here with the Item Template's multiple checkboxes
                }
                else if (idVal.indexOf('DeleteThis') != -1) {
                    // Check if any of the checkboxes are not
                    //checked, and then uncheck top select all checkbox
                    if (frm.elements[i].checked == false) {
                        frm.elements[1].checked = false; //Uncheck
                        //main select all checkbox
                    }
                }
            }
        }


        function ShowIcon() {
            var e = document.getElementById("processing1");
            e.style.visibility = (e.style.visibility == 'visible') ? 'hidden' : 'visible';
        }

        function IAmSelected(source, eventArgs) {
            //alert( " Key : "+ eventArgs.get_text() +"  Value :  "+eventArgs.get_value()); 
            valor = eventArgs.get_value();
            document.getElementById("hdSoloClientes").value = valor;
        }


        function imprimir() {
            document.getElementById("divBotones").style.display = 'none';
            window.print();
            document.getElementById("divBotones").style.display = 'block';
        }


        function printIframe() {
            id = 'idImprimirDeudaDetalle';

            var iframe = document.frames ? document.frames[id] : document.getElementById(id);
            var ifWin = iframe.contentWindow || iframe;

            
            iframe.src = "imprimirDeudaDetalle.aspx?tipoPeriodo=" + (document.getElementById("raDiario").checked ? "1" : "2") + "&fechaDesde=" + document.getElementById("txtFechaInicio").value + "&fechaHasta=" + document.getElementById("txtFechaFinal").value;
            alert(iframe.src)
            iframe.focus();
            ifWin.printPage();
            return false;
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
								<td class="title" height="38">&nbsp; <STRONG>LISTA COBRANZAS PENDIENTES POR CLIENTES</STRONG><HR>
									<BR>
								</td>
							</tr>
                            <tr><td>
                            
                            <div style="width:94%; margin-bottom:20px; border:1px solid #ccc; background-color:#eee; margin:20px; padding:10px;" id="divBusqueda">
                        <TABLE class="text" cellSpacing="3"cellPadding="1" width="100%" border="0">
				            <TR>
					            <TD>&nbsp;&nbsp;
						            Fecha desde&nbsp;<asp:textbox id="txtFechaInicio" runat="server" Width="78px"></asp:textbox><cc1:CalendarExtender ID="txtFechaInicio_CalendarExtender" runat="server" 
                                        TargetControlID="txtFechaInicio" Enabled="True"></cc1:CalendarExtender>
                                    &nbsp; 
                                    Fecha hasta <asp:textbox id="txtFechaFinal" runat="server" Width="78px"></asp:textbox>
                                    <cc1:CalendarExtender ID="txtFechaFinal_CalendarExtender" runat="server" TargetControlID="txtFechaFinal" Enabled="True"></cc1:CalendarExtender>

                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="raDiario" runat="server" GroupName="raTipoPeriodo" Text="Diario" />
                                    <asp:RadioButton ID="raMensual" runat="server" GroupName="raTipoPeriodo" Text="Mensual" />&nbsp;
                                    <asp:CheckBox ID="chkMostrarSubTotal" Checked="false" runat="server" Text="Mostrar Subtotal" />
						            <asp:button id="btnBuscar" runat="server" Width="80px" Text="Buscar" 
                                        onclick="btnBuscar_Click" style="margin-left:20px;" re></asp:button>

                                    &nbsp;</TD>
				            </TR>
                            <tr><td><asp:RadioButtonList runat="server" ID="raTipoMorosidad" CssClass="text" RepeatDirection="Horizontal">
                                                                    <asp:listitem Text="Normal" Value="1" Selected="True"></asp:listitem>
                                                                    <asp:listitem Text="Tto especial" Value="2"></asp:listitem>
                                                                    <asp:listitem Text="Incobrable" Value="3"></asp:listitem>
                                                                    <asp:listitem Text="Abogado" Value="4"></asp:listitem>
                                                                    </asp:RadioButtonList></td></tr>
			            </TABLE>
            
                    </div>
                            </td></tr>
							<tr style="margin-top:30px;">
								<td>
									<asp:datagrid id="dgPendientesCobrosClientes" runat="server" Font-Size="8pt" 
                                        PageSize="20" CellPadding="3" BorderColor="#3657A6"
										BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False"
										Width="60%" onitemcommand="dgPendientesCobrosClientes_ItemCommand">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:TemplateColumn>
                                                <HeaderTemplate>
                                                        <asp:CheckBox ID="CheckAll" OnClick="javascript: return select_deselectAll (this.checked, this.id, 'chkCliente');" runat="server" Checked="true" />
                                                    </HeaderTemplate>
												<HeaderStyle Width="20px"></HeaderStyle>
												<ItemTemplate>
													<asp:CheckBox id="chkCliente" runat="server" Checked="true" />
												</ItemTemplate>
											</asp:TemplateColumn>
                                            <asp:BoundColumn DataField="idCliente" HeaderText="Cliente" Visible="false">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="cliente" HeaderText="Cliente">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>


                                            <asp:BoundColumn DataField="monto" HeaderText="Subtotal">
                                                <HeaderStyle Width="80px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
                                            
                                            <asp:TemplateColumn>
												<HeaderStyle Width="20px"></HeaderStyle>
												<ItemTemplate>
													<asp:ImageButton id="Detalle" runat="server" Width="16px" ToolTip="Detalle" CommandName="Detalle" ImageUrl="/img/ico-detalles.gif"
														CausesValidation="False"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
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
                                        <asp:Button ID="idImprimir" runat="server" Text="Imprimir" 
                                            onclick="idImprimir_Click" />
                                    
                                    &nbsp; 
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
