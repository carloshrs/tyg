<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cobranzas.listado.aspx.cs" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas.facturacion_listaClientes" %>
<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>Administración de Precios</title>
	<link href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
    <link href="/CSS/ext-all.css" type="text/css" rel="stylesheet" />
    <link href="/CSS/ext-ux-wiz.css" type="text/css" rel="stylesheet" />
    <link href="/CSS/fancy.css" type="text/css" rel="stylesheet" />
    <link href="/CSS/MainV2110.css" type="text/css" rel="stylesheet" />
    <!--<script type="text/javascript" src="/jquery/jquery-1.4.4.js"></script>-->
    <script src="/jquery/jquery-1.7.2.min.js" type="text/javascript"></script>

    

    <script type="text/javascript">
        function ShowIcon() {
            var e = document.getElementById("processing");
            e.style.visibility = (e.style.visibility == 'visible') ? 'hidden' : 'visible';
        }

        function IAmSelected(source, eventArgs) {
            //alert( " Key : "+ eventArgs.get_text() +"  Value :  "+eventArgs.get_value()); 
            valor = eventArgs.get_value();
            document.getElementById("TabPagos_tbPagosPendientes_WzPagosDocumentos_hIdCliente").value = valor;
        }

        function activar2(valor) {
            nombre = valor.name;
            var res = nombre.split("$");
            nomId = (res[4]);
            valId = (nomId.substring(4));
            //alert(document.forms[0].elements.length)
            //totalElem = (document.forms[0].elements.length - 17) / 2;
            //alert(totalElem)
            valElemCheck = eval("document.forms[0].TabPagos_tbPagosPendientes_WzPagosDocumentos_listaCobrar_ctrl" + valId + "_chkCobro");
            valElemMonto = eval("document.forms[0].TabPagos_tbPagosPendientes_WzPagosDocumentos_listaCobrar_ctrl" + valId + "_txtCobroImporte");
            valElemSubTotal = document.forms[0].TabPagos_tbPagosPendientes_WzPagosDocumentos_txtCobroSubTotal;
            
            //alert(valElemMonto.value);
            
            if (valElemSubTotal.value == "")
                valElemSubTotal.value = 0;
            

            if (valElemCheck.checked) {
                valElemSubTotal.value = parseFloat(valElemSubTotal.value.replace(",", ".")).toFixed(2) + parseFloat(valElemMonto.value.replace(",", ".")).toFixed(2);
                valElemMonto.disabled = false;
                alert(valElemMonto.value + " " + parseFloat(valElemMonto.value));
            }
            else {
                valElemSubTotal.value = parseFloat(valElemSubTotal.value.replace(",", ".")).toFixed(2) - parseFloat(valElemMonto.value.replace(",", ".")).toFixed(2);
                valElemMonto.disabled = true;
            }
            //alert(elemMonto.value)

        }

        function subtotal() {

            //alert(document.forms[0].elements.length)
            totalElem = (document.forms[0].elements.length - 16) / 2;
            //alert(totalElem)
            document.forms[0].TabPagos_tbPagosPendientes_WzPagosDocumentos_txtCobroSubTotal.value = 0;
            valElemSubTotal = 0;

            //alert(eval("document.forms[0].TabPagos_tbPagosPendientes_listaCobrar_ctrl0_lblCobroMonto").value)
            //alert(document.getElementById("TabPagos_tbPagosPendientes_listaCobrar_ctrl0_lblCobroMonto").innerHTML)
            for (i = 0; i < totalElem; i++) {
                valElemLabel = document.getElementById("TabPagos_tbPagosPendientes_WzPagosDocumentos_listaCobrar_ctrl" + i + "_lblCobroMonto").innerHTML;  //eval("document.forms[0].TabPagos_tbPagosPendientes_listaCobrar_ctrl" + i + "_lblCobroMonto");
                valElemCheck = eval("document.forms[0].TabPagos_tbPagosPendientes_WzPagosDocumentos_listaCobrar_ctrl" + i + "_chkCobro");
                valElemMonto = eval("document.forms[0].TabPagos_tbPagosPendientes_WzPagosDocumentos_listaCobrar_ctrl" + i + "_txtCobroImporte");
                //alert(valElemMonto.value)
                if (valElemCheck.checked) {
                    valElemSubTotal = valElemSubTotal + parseFloat(valElemMonto.value);
                    alert(valElemSubTotal);
                    if (parseFloat(valElemLabel) != parseFloat(valElemMonto.value)) {
                        if (parseFloat(valElemLabel) > parseFloat(valElemMonto.value))
                            valElemMonto.style.backgroundColor = '#F5B1B3';
                            //alert("mayor:" + valElemLabel)
                        else
                            valElemMonto.style.backgroundColor = '#90D9F3';
                            //alert("menor:" + valElemLabel)
                      }
                    else
                        valElemMonto.style.backgroundColor = '#F5F5F5';
                }

            }

            document.forms[0].TabPagos_tbPagosPendientes_WzPagosDocumentos_txtCobroSubTotal.value = valElemSubTotal;

        }

    </script>

    
</head>
<body style="margin:0px; padding:0px;">
<script language="javascript" type="text/javascript">

    $(document).ready(function () {

        $("#<%=GVlistaCobrar.ClientID%> [id*='chkItem']").click(function () {

            var calculo = 0;
            var tr = $(this).parent().parent();
            var check = $("td:eq(1)", tr);
            var precio = $("td:eq(4)", tr).html().replace(",", ".");
            //alert($(this).val());

            if ($(this).is(':checked')) {
                calculo = precio * 1;
            } else {
                calculo = precio * 0;
            }

            $("td:eq(5) span", tr).html(calculo);

            CalcularTotal();

        });

    });

    //calculo total grid paginado
    function CalcularTotal() {

        var total = 0;
        $("#<%=GVlistaCobrar.ClientID%> [id*='lblPrecio']").each(function () {

            var coltotal = parseFloat($(this).html());

            if (!isNaN(coltotal)) {
                total += coltotal;
            }

        });


        $("#<%=pnlListadoPendiente.ClientID%> [id*='txtCobroSubTotal']").val(total);
        var valorInput = $("#<%=pnlListadoPendiente.ClientID%> [id*='txtCobroSubTotal']").val();
        $("#<%=GVlistaCobrar.ClientID%> [id*='lblTotal']").html(total);
        //alert(valorInput);
    }

    </script>
    <mnu:menu id="Menu" runat="server"></mnu:menu>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
                            EnablePartialRendering="true" EnableScriptGlobalization="True">
         </asp:ScriptManager>
    <div style="margin:20px;">
    <div style="margin-top:20px; margin-bottom:20px;"><asp:Label ID="lblTitulo" runat="server" Text="Label" Font-Size="16" Font-Bold="true">Cobranzas por cliente</asp:Label>
    <p>Listado de remitos, partes de entrega (diarios/mensuales)</p>
    </div>
        
                
    <cc1:TabContainer ID="TabPagos" runat="server" ActiveTabIndex="0" Width="95%">
            <cc1:TabPanel runat="server" HeaderText="Por clientes" ID="tbPagosPendientes">
                <ContentTemplate>

                <asp:Wizard ID="WzPagosDocumentos" runat="server" BackColor="White" BorderColor="#B5C7DE"
                    BorderWidth="1px" Width="100%" ActiveStepIndex="0"
                        onfinishbuttonclick="WzPagosDocumentos_FinishButtonClick" 
                        onnextbuttonclick="WzPagosDocumentos_NextButtonClick" 
                        OnSideBarButtonClick="WzPagosDocumentos_SideBarButtonClick"
                        FinishCompleteButtonText="Finalizar cobro">
                    <StepStyle Font-Size="0.8em" ForeColor="#333333" />
                    <SideBarStyle BackColor="#EFF3FB" Font-Size="0.9em" 
                    VerticalAlign="Bottom" Width="200px"
                    Wrap="True" />
                    <NavigationButtonStyle BackColor="White" 
                    BorderColor="#507CD1" 
                    BorderStyle="Solid"
                    BorderWidth="1px" Font-Names="Verdana" 
                    Font-Size="0.8em" 
                    ForeColor="#284E98" />
            <WizardSteps>
                <asp:WizardStep ID="Paso1" runat="server" Title="Cobro de documentos" >
                    <div style="width:94%; margin-bottom:20px; border:1px solid #ccc; background-color:#eee; margin:20px; padding:10px;" id="divBusqueda">
                        <TABLE class="text" cellSpacing="3"cellPadding="1" width="100%" border="0">
				            <TR>
					            <TD><asp:label id="lblEstado" runat="server" Font-Bold="True"> Filtro</asp:label>





<BR>
						            &nbsp;<BR>
						            Cliente:
						            <asp:textbox id="txtCliente" runat="server" Width="207px" CssClass="planotext"></asp:textbox>





 <img id="processing" style="visibility:hidden" src="/img/ajaxloader-thumb.gif"  />
                                                <cc1:AutoCompleteExtender 
                            ID="txtCliente_AutoCompleteExtender" runat="server" 
                                                    TargetControlID="txtCliente"
                                                    ServicePath="~/services/clientes.asmx" 
                                                    UseContextKey="True"
                                                    ServiceMethod="getClientes" 
                                                    CompletionSetCount="12"
                                                    onclientpopulating="ShowIcon"
                                                    onclientpopulated="ShowIcon"
                                                    OnClientItemSelected="IAmSelected" 
                            DelimiterCharacters="" Enabled="True"></cc1:AutoCompleteExtender>




<asp:HiddenField ID="hIdCliente" runat="server" />




                                    &nbsp;&nbsp;
						            Fecha desde&nbsp;<asp:textbox id="txtFechaInicio" runat="server" Width="78px"></asp:textbox>




                                    <cc1:CalendarExtender ID="txtFechaInicio_CalendarExtender" runat="server" 
                                        TargetControlID="txtFechaInicio" Enabled="True"></cc1:CalendarExtender>




                                    &nbsp; 
                                    Fecha hasta <asp:textbox id="txtFechaFinal" runat="server" Width="78px"></asp:textbox>




                                    <cc1:CalendarExtender ID="txtFechaFinal_CalendarExtender" runat="server" 
                                        TargetControlID="txtFechaFinal" Enabled="True"></cc1:CalendarExtender>




						            <asp:button id="btnBuscar" runat="server" Width="80px" Text="Buscar" 
                                        onclick="btnBuscar_Click" style="margin-left:20px;"></asp:button>




&nbsp;
						            <input id="hidFecha" runat="server" size="1" type="hidden"></input>
</input>
</input>
</input>
</input>
</input>
                                        </input>
                                        </input>
                                        </input></input>
                                        </input>
                                        </input>
                                        </input>
                                        </input>
                                        </input>
                                        </input>
                                </TD>
				            </TR>
			            </TABLE>
            
                    </div>
                            
                            <asp:panel ID="pnlListadoPendiente" runat="server" Visible="False">

                                <asp:GridView ID="GVlistaCobrar" runat="server" BackColor="#F3F3F3" 
                                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                                    ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" 
                                     onpageindexchanging="GVlistaCobrar_PageIndexChanging" 
                                    ShowFooter="True"  AllowPaging="True" Width="98%" HorizontalAlign="Center">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkItem" runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="20px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ID" HeaderText="Nro" />
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha">
                                        <HeaderStyle Width="160px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Documento" HeaderText="Concepto" />
                                        <asp:BoundField DataField="monto" HeaderText="Precio Unitario">
                                        <HeaderStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Precio">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrecio" runat="server" ></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                              <asp:Label ID="lblTotal" runat="server" ></asp:Label>
                                          </FooterTemplate>
                                            <HeaderStyle Width="90px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#28428B" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <FooterStyle BackColor="#999999" Font-Size="16pt" Font-Bold="True" />
                                </asp:GridView>
                                <asp:HiddenField ID="txtCobroSubTotal" runat="server" />
                            </asp:panel>

                            </asp:WizardStep>
                <asp:WizardStep ID="Paso2" runat="server" Title="Formas de pago">
                <div style="float:left; width:100%; padding-left:20px; padding-top:20px;">Cliente: 
                    <asp:Label ID="lblCliente" 
                        runat="server" Font-Bold="True"></asp:Label>
                        </div>

                <div style="float:left;  width:200px; background-color:#dfdfdf; margin-left:20px; padding:5px; margin-top:10px;">
                    Monto a cobrar: 
                    <asp:Label ID="lblMonto" runat="server" 
                        Font-Size="18pt"></asp:Label>
                </div>
                <div style="float:left;  width:200px; background-color:#dfdfdf; margin-left:20px; padding:5px; margin-top:10px;">
                    Saldo actual: 
                    <asp:Label ID="lblSaldoActual" runat="server" 
                        Font-Size="18pt"></asp:Label><asp:Button ID="btnActualizarSaldo" runat="server" Text="Actualizar" />
                </div>

                <div style="float:left; width:95%; margin-top:30px; border-bottom: 1px solid #B5C7DE; margin-left:20px;"><h2>Forma de pago</h2></div> 
                
                <div style="float:left; width:100%;">
                    <div style="float:left; width:250px; margin-top:10px; margin-left:20px;">
                    <asp:DropDownList ID="DDFormaPago1" runat="server">
                        <asp:ListItem Selected="True" Value="1" Text="Efectivo"/>
                        <asp:ListItem Value="2" Text="Cheque"/>
                        <asp:ListItem Value="3" Text="Transferencia"/>
                        <asp:ListItem Value="4" Text="Depósito"/>
                        <asp:ListItem Value="5" Text="Rapipago"/>
                        </asp:DropDownList>
                    </div>
                    <div style="float:left; width:40%; margin-left:5px; margin-top:10px;"><span style="font-size:14px; margin-top:10px; padding-bottom:15px;">$ </span><asp:TextBox ID="txtMontoaPagar1" runat="server" style="font-size:14px; padding:4px;" Width="70px"></asp:TextBox></h3></div>
                </div>

                <div style="float:left; width:100%;">
                    <div style="float:left; width:250px; margin-top:10px; margin-left:20px;">
                    <asp:DropDownList ID="DDFormaPago2" runat="server">
                        <asp:ListItem Selected="True" Text="Seleccione forma de pago" />
                        <asp:ListItem Value="1" Text="Efectivo"/>
                        <asp:ListItem Value="2" Text="Cheque"/>
                        <asp:ListItem Value="3" Text="Transferencia"/>
                        <asp:ListItem Value="4" Text="Depósito"/>
                        <asp:ListItem Value="5" Text="Rapipago"/>
                        </asp:DropDownList>
                    </div>
                    <div style="float:left; width:40%; margin-left:5px; margin-top:10px;"><span style="font-size:14px; margin-top:10px; padding-bottom:15px;">$ </span><asp:TextBox ID="txtMontoaPagar2" runat="server" style="font-size:14px; padding:4px;" Width="70px"></asp:TextBox></h3></div>
                </div>

                <div style="float:left; width:100%;">
                    <div style="float:left; width:250px; margin-top:10px; margin-left:20px;">
                    <asp:DropDownList ID="DDFormaPago3" runat="server">
                        <asp:ListItem Selected="True" Text="Seleccione forma de pago" />
                        <asp:ListItem Value="1" Text="Efectivo"/>
                        <asp:ListItem Value="2" Text="Cheque"/>
                        <asp:ListItem Value="3" Text="Transferencia"/>
                        <asp:ListItem Value="4" Text="Depósito"/>
                        <asp:ListItem Value="5" Text="Rapipago"/>
                        </asp:DropDownList>
                    </div>
                    <div style="float:left; width:40%; margin-left:5px; margin-top:10px;"><span style="font-size:14px; margin-top:10px; padding-bottom:15px;">$ </span><asp:TextBox ID="txtMontoaPagar3" runat="server" style="font-size:14px; padding:4px;" Width="70px"></asp:TextBox></h3></div>
                </div>
               
                    
                <!--<div style="float:left; width:100%;"><asp:Button ID="btnPagar" Text="PAGAR" runat="server" 
                                    style="font-size:16px; font-weight: bold; padding:5px;" 
                                    onclick="btnPagar_Click" /> </div>-->    
                    
                    <div style="float:left; margin-top:15px;"><asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="16px"></asp:Label></div>
                </asp:WizardStep>
            </WizardSteps>
            
        </asp:Wizard>

        </ContentTemplate>
            </cc1:TabPanel>

            <cc1:TabPanel ID="tbCuentasCliente" runat="server" HeaderText="Por cobradores">
                <ContentTemplate>
                    Grilla de remitos diarios
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    
    </div>
    </form>
</body>
</html>
