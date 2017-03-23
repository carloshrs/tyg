<%@ Page language="c#" AutoEventWireup="true" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas.imprimirdeudadetalle" CodeFile="imprimirDeudaDetalle.aspx.cs" %>
<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html>
	<head id="Head1" runat="server">
		<title>Administración de Precios</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
        <link href="/CSS/ext-all.css" type="text/css" rel="stylesheet" />
        <link href="/CSS/ext-ux-wiz.css" type="text/css" rel="stylesheet" />
        <link href="/CSS/fancy.css" type="text/css" rel="stylesheet" />
        <link href="/CSS/MainV2110.css" type="text/css" rel="stylesheet" />
	</head>
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


        function addAdicional(valor) {
            alert(valor);
        }
        /*
        $(document).ready(function () {

        $("#addAdicional").click(function () {

        // Opción 1 
        var n = $('tr:last td', $("#ctl00_mainArea_ti1")).length;

        var tds = '<tr>';
        for (var i = 0; i < n; i++) {
        tds += '<td>nuevo</td>';
        }
        tds += '</tr>';

        $("#ctl00_mainArea_ti1").append(tds);
        });

        $("#addServicio").click(function () {

        // Opción 1 
        var n = $('tr:last td', $("#ctl00_mainArea_Servicios")).length;

        var tds = '<tr>';
        for (var i = 0; i < n; i++) {
        tds += '<td>Serv</td>';
        }
        tds += '</tr>';

        $("#ctl00_mainArea_Servicios").append(tds);
        });
            
        });
        */

        $(document).ready(function () {

        });



        function recalcular(tipo, campo) {
            nombre = campo.name;
            arrName = nombre.split("$");

            cantidad = eval("document.forms[0].lvAdicionales$" + arrName[1] + "$txtCantidad");
            precioUnitario = eval("document.forms[0].lvAdicionales$" + arrName[1] + "$txtPrecioUnitario");
            precio = eval("document.forms[0].lvAdicionales$" + arrName[1] + "$txtPrecio");

            if (isNaN(parseInt(cantidad.value))) {
                alert("La cantidad debe ser numérico");
                return false;
            }

            if (isNaN(parseFloat(precioUnitario.value))) {
                alert("El precio debe ser numérico");
                return false;
            }

            precio.value = (cantidad.value * precioUnitario.value);





        }

        function printPage() { print(); }

    </script>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
                            EnablePartialRendering="true" EnableScriptGlobalization="True">
         </asp:ScriptManager>
         <div>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="text" vAlign="top" width="5"></td>
					<td class="text" height="38">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
                                <td class="title" height="38">
                                    <div style="float:right; text-align:right; width:160px; font-size:12px;">FECHA: <asp:Label ID="lblFecha" runat="server"></asp:Label></div>
                                    <div style="float:left"><IMG alt="" src="/img/logo-20-anios-impr.png" height"69></div>
                                    <div style="float:left; margin-top:10px; width:100%; text-align:center" class="title"><asp:Label ID="lblTipoPeriodo" runat="server" Text=""></asp:Label> desde el <asp:Label ID="lblFechaDesde" runat="server" /> hasta el <asp:Label ID="lblFechaHasta" runat="server" /></div>
							    </td>
							</tr>
							
							
							<tr>
								<td>
                                    <asp:Panel ID="pnListadoDeudaPendiente" runat="server">
                                    <div style="overflow:auto"><table class="generalTable text" cellspacing="0" cellpadding="3" border="0" id="Table1" style="border-collapse:collapse;">
			                            <tr class="rowTop" style="font-weight: bold; color: #3756A6; background-color: #DFE7F4;">
				                            <th scope="col" style="width:1%;white-space:nowrap;">&nbsp;</th>
                                            <th scope="col" style="white-space:nowrap; width:60px; font-weight:bold; font-size:14px;">Cantidad</th>
                                            <th scope="col" style="width:80%; font-weight:bold; font-size:14px;">Cliente</th>
                                            <th scope="col" style="width:160px; font-weight:bold; font-size:14px;" align="right">Subtotal</th>
			                            </tr>

                                        <asp:ListView ID="lvListadoClientes" runat="server" OnItemDataBound="InformeDataBound" OnPreRender="lvListadoClientes_PreRender">
                                            <ItemTemplate>
                                            <tr>
				                                <td><asp:HiddenField ID="hdIdCliente" runat="server" Value='<%# Eval("idCliente") %>'></asp:HiddenField></td>
                                                <td class="big" align="center" style="font-weight:bold; font-size:14px;"><asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("cantidad") %>'></asp:Label></td>
                                                <td style="font-weight:bold; font-size:14px;"><asp:Label ID="lblCliente" runat="server" Text='<%# Eval("cliente") %>'></asp:Label></td>
                                                <td style="font-weight:bold; font-size:14px;"><asp:Label ID="lblSubtotal" runat="server" Font-Bold="true" Text='<%# Eval("monto") %>'></asp:Label></td>
			                                </tr>
                                        
                                        <tr >
				                            <td colspan="5">
                                                <div class="expandedList">
                                                    <div>
								                        <table class="generalTable text" cellspacing="0" cellpadding="3" border="0" id="ctl00_mainArea_ti1" style="border-collapse:collapse; width:80%" align="right">
									                        <tr class="headRow" style="font-weight: bold; color: #3756A6; background-color: #DFE7F4;">
										                        <th scope="col" style="width:1%; font-weight:bold;"></th>
                                                                <th scope="col"style="font-weight:bold;">Fecha</th>
                                                                <th scope="col"style="font-weight:bold;">Concepto</th>
                                                                <th scope="col" style="font-weight:bold;" align="center">Monto</th>
									                        </tr>
                                                            <asp:ListView ID="lvInformes" runat="server">
                                                            <ItemTemplate>
                                                            <tr class="rowDone" >
                                                                <td style="color:#888888;" style="border-bottom: solid 1px #D5D5D5"><asp:HiddenField ID="hdNroMovimiento" runat="server" Value='<%# Eval("NroMovimiento") %>'></asp:HiddenField></td>
                                                                <td style="border-bottom: solid 1px #D5D5D5"><asp:Label ID="lblFecha" runat="server" Text='<%# Eval("fecha") %>'></asp:Label></td>
                                                                <td style="border-bottom: solid 1px #D5D5D5"><asp:Label ID="lblConcepto" runat="server" Text='<%# Eval("concepto") %>'></asp:Label></td>
                                                                <td style="border-bottom: solid 1px #D5D5D5" align="center"><asp:Label ID="lblMonto" runat="server" Text='<%# Eval("monto") %>'></asp:Label></td>
									                        </tr>
                                                            </ItemTemplate>
                                                            </asp:ListView>

                                                            <tbody id="tbDetalle">
		                                                    </tbody>
								                        </table>
							                        </div>
                        						</div>
					                        </div>
                        				</div>
                                        </td>
                                       </tr>
                                       <tr><td><br /><br /></td></tr>
                                            </ItemTemplate>
                                        </asp:ListView>


                                        </table>
                                <div style="text-align:right; margin-top:10px; font-weight:bold; font-size:18px;">TOTAL: <asp:Label ID="lblTotal" runat="server" Font-Bold="true"></asp:Label></div>
                                </div>
                                </asp:Panel>
                                </td>
							</tr>
                                <tr><td class="text">
                                    
                                    </td></tr>
						</table>
					</td>
				</tr>
			</table>
            
            </div>
            
		</form>
	</body>
</html>
