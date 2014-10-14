<%@ Page language="c#" AutoEventWireup="true" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas.Admin_Cuentas_remitos" CodeFile="VerMovimiento.aspx.cs" %>
<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html>
	<head runat="server">
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

        function agregarFila(tipo, obj) {
            alert(tipo);
            var style = '';
            $("#cant_campos").val(parseInt($("#cant_campos").val()) + 1);
            var oId = $("#cant_campos").val();
            var nombre = "Informe de propiedad"; // $("#txtNombre").val();
            var edad = $("#txtEdad").val();
            var direccion = $("#txtDireccion").val();
            var sexo = $("#selSexo").val();
            var estCivil = $("#selEstCivil").val();
            stlye = 'style="color:#888888;"';
            var strHtml1 = "<td " + style + ">" + nombre + '<input type="hidden" id="hdnNombre_' + oId + '" name="hdnNombre_' + oId + '" value="' + nombre + '"/></td>';
            var strHtml2 = "<td " + style + ">" + edad + '<input type="hidden" id="hdnEdad_' + oId + '" name="hdnEdad_' + oId + '" value="' + edad + '"/></td>';
            var strHtml3 = "<td " + style + ">" + direccion + '<input type="hidden" id="hdnDireccion_' + oId + '" name="hdnDireccion_' + oId + '" value="' + direccion + '"/></td>';
            var strHtml4 = "<td " + style + ">" + sexo + '<input type="hidden" id="hdnSexo_' + oId + '" name="hdnSexo_' + oId + '" value="' + sexo + '"/></td>';
            //var strHtml5 = "<td>" + estCivil + '<input type="hidden" id="hdnEstCivil_' + oId + '" name="hdnEstCivil_' + oId + '" value="' + estCivil + '"/></td>';
            var strHtml5 = '<td class="big" align="right"><img src="/Img/cruz.gif" width="13" height="11" alt="Eliminar" onclick="if(confirm(\'Realmente desea eliminar este detalle?\')){eliminarFila(' + oId + ');}"/>';
            strHtml5 += '<input type="hidden" id="hdnIdCampos_' + oId + '" name="hdnIdCampos[]" value="' + oId + '" /></td>';
            var strHtmlTr = "<tr id='rowDetalle_" + oId + "'></tr>";
            var strHtmlFinal = strHtml1 + strHtml2 + strHtml3 + strHtml4 + strHtml5;
            //tambien se puede agregar todo el HTML de una sola vez.
            //var strHtmlTr = "<tr id='rowDetalle_" + oId + "'>" + strHtml1 + strHtml2 + strHtml3 + strHtml4 + strHtml5 + strHtml6 +"</tr>";
            $("#tbDetalle").append(strHtmlTr);
            //si se agrega el HTML de una sola vez se debe comentar la linea siguiente.
            $("#rowDetalle_" + oId).html(strHtmlFinal);
            return false;
        }
        function eliminarFila(oId) {
            $("#rowDetalle_" + oId).remove();
            return false;
        }
function addAdicional_onclick() {
}

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

function iPrint()
{
    window.idImprimir.focus();
    window.idImprimir.print();
}



    </script>
	<body leftMargin="0" topMargin="0">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
        
		<form id="Form1" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
                            EnablePartialRendering="true" EnableScriptGlobalization="True">
         </asp:ScriptManager>
             <input type="hidden" id="num_campos" name="num_campos" value="0" />
            <input type="hidden" id="cant_campos" name="cant_campos" value="0" />
			<table cellSpacing="0" cellPadding="0" width="98%" border="0">
				<tr>
					<td class="text" vAlign="top" width="5"></td>
					<td class="text" height="38">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="title" height="38"><asp:Label ID="lblTipo" runat="server"></asp:Label> Nº <asp:Label ID="lblnroMovimiento" runat="server"></asp:Label>
									<HR>
									<BR>
								</td>
							</tr>
							
							<tr>
								<td class="text" height="38">
                                    <asp:Panel ID="pnCliente" runat="server">
                                <br />
            			                <span style="color: #AAA; font-size: 14px; font-weight: bold">Cliente</span>
                                        <asp:Label ID="lblCliente" runat="server" Font-Bold="true"></asp:Label>
                                        &nbsp; &nbsp;<asp:HiddenField ID="hIdCliente" runat="server" />
                                        <br>
                                        </br>
                                    </asp:Panel></td>
							</tr>
							<tr>
								<td>
                                    <asp:Panel ID="pnListadoInformes" runat="server">
                                    <div style="height:360px; overflow:auto"><asp:datagrid id="dgridRemitosMovimiento" 
                                        runat="server" Width="100%" 
                                        Font-Size="8pt" PageSize="15" CellPadding="3" BorderColor="#3657A6" 
                                        BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" >
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
                                        <asp:BoundColumn DataField="cantidad" HeaderText="Cantidad">
                                        <HeaderStyle HorizontalAlign="Center" Width="15px">
                                        </HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center">
                                        </ItemStyle>
                                        </asp:BoundColumn>
                                        
                                       <asp:BoundColumn DataField="descripcion" HeaderText="Descripción">
                                        <HeaderStyle Width="120px">
                                        </HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left">
                                        </ItemStyle>
                                        </asp:BoundColumn>

                                        <asp:BoundColumn DataField="precioUnitario" HeaderText="Precio unitario">
                                        <HeaderStyle Width="120px">
                                        </HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left">
                                        </ItemStyle>
                                        </asp:BoundColumn>

                                        <asp:BoundColumn DataField="precioTotal" HeaderText="Importe">
                                        <HeaderStyle Width="120px">
                                        </HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left">
                                        </ItemStyle>
                                        </asp:BoundColumn>
                                   </Columns>
                                </asp:datagrid>
                                <div style="text-align:right"><asp:Label ID="lblTotal" runat="server" Font-Bold="true"></asp:Label></div>
                                </div>
                                </asp:Panel>
                                </td>
							</tr>
                                <tr><td class="text">
                                    
                                    </td></tr>
							<tr>
								<td align="center">
                                </td>
							</tr>
							<tr>
								<td align="right">
									<asp:Button id="btnCerrar" runat="server" Text="Cerrar" 
                                        CausesValidation="False" onclick="btnCerrar_Click" ></asp:Button>
								&nbsp;<input type="button" name="idImprimir" value="Imprimir" onclick="iPrint();" />
                                        <iframe id="idImprimir" runat="server" src="imprimirMovimientos.aspx" width="0" height="0" frameborder="0"></iframe>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
