<%@ Page language="c#" AutoEventWireup="true" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas.Admin_Cuentas_remitos" CodeFile="imprimirMovimientos.aspx.cs" %>
<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html>
	<head id="Head1" runat="server">
		<title>Administración de Precios</title>
		<link href="/CSS/Estilos.css" type="text/css" rel="stylesheet" />
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

        function printPage() { print(); }
    </script>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
                            EnablePartialRendering="true" EnableScriptGlobalization="True">
         </asp:ScriptManager>
         <div >
			<table cellSpacing="0" cellPadding="0" width="98%" border="0">
				<tr>
					<td class="text" vAlign="top" width="5"></td>
					<td class="text" height="38">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
                                <td class="title" height="38">
                                <div style="float:left"><img src="../../Img/logo_fondo_blanco.gif" height="99" width="250" /></div>
                                <div style="float:left; margin-top:50px; width:280px; text-align:center" class="title"><asp:Label ID="lblTipo" runat="server"></asp:Label> Nº <asp:Label ID="lblNroMovimiento" runat="server"></asp:Label></div>
                                <div style="float:left; text-align:right; width:160px; font-size:12px;">FECHA: 
                                    <asp:Label ID="lblFecha" runat="server"></asp:Label></div>
								</td>
							</tr>
							
							<tr>
								<td class="text" height="38">
                                    <asp:Panel ID="pnCliente" runat="server">
            			                <div style="color: #000; font-size: 14px; font-weight: bold; margin-top:20px;">CLIENTE: 
                                        <asp:Label ID="lblCliente" runat="server"></asp:Label></div>
                                        <div style="color: #777; font-size: 14px; font-weight: bold">DIRECCIÓN:
                                        <asp:Label ID="lblDireccion" runat="server"></asp:Label><asp:Label ID="lblLocalidad" runat="server"></asp:Label></div>
                                        <div style="color: #777; font-size: 14px; font-weight: bold">TELÉFONO:
                                        <asp:Label ID="lblTelefono" runat="server"></asp:Label><asp:Label ID="lblFax" runat="server"></asp:Label></div>
                                        &nbsp; &nbsp;<asp:HiddenField ID="hIdCliente" runat="server" /><br />
                                        El siguiente resumen corresponde al periodo comprendido entre el <asp:Label ID="lblFechaDesde" runat="server"></asp:Label> hasta el <asp:Label ID="lblFechaHasta" runat="server"></asp:Label>.<br />
                                        Correspondiente a los siguientes parte de entrega Nº: <asp:Label ID="lblResumenes" runat="server"></asp:Label>
                                        <br /><br />
                                    </asp:Panel></td>
							</tr>
							<tr>
								<td>
                                    <asp:Panel ID="pnListadoInformes" runat="server">
                                    <div ><asp:datagrid id="dgridRemitosMovimiento" 
                                        runat="server" Width="100%" Font-Size="8pt" PageSize="15" CellPadding="3" 
                                        BorderColor="#3657A6" BorderStyle="Solid" BorderWidth="1px" BackColor="White" 
                                        GridLines="Vertical" AutoGenerateColumns="False" OnPreRender="dgridRemitosMovimiento_PreRender">
                                        <SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C">
                                        </SelectedItemStyle>

                                        <AlternatingItemStyle BackColor="#FBFBFB" Height="16px">
                                        </AlternatingItemStyle>

                                        <ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3" Height="16px">
                                        </ItemStyle>

                                        <HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4">
                                        </HeaderStyle>

                                        <FooterStyle ForeColor="Black" BackColor="#CCCCCC">
                                        </FooterStyle>

                                        <Columns>
                                        <asp:BoundColumn DataField="cantidad" HeaderText="CANTIDAD">
                                        <HeaderStyle HorizontalAlign="Center" Width="15px">
                                        </HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center">
                                        </ItemStyle>
                                        </asp:BoundColumn>
                                        
                                       <asp:BoundColumn DataField="descripcion" HeaderText="DESCRIPCIÓN">
                                        <HeaderStyle Width="120px">
                                        </HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left">
                                        </ItemStyle>
                                        </asp:BoundColumn>

                                        <asp:BoundColumn DataField="precioUnitario" Visible="false">
                                        </asp:BoundColumn>

                                        <asp:TemplateColumn HeaderText="PRECIO UNITARIO">
                                            <ItemTemplate>
                                            <asp:Label id="lblPrecioUnitario" runat="server"></asp:Label>
                                            </ItemTemplate>
	                                        <HeaderStyle Width="120px">
	                                        </HeaderStyle>
                                            <ItemStyle HorizontalAlign="Right">
                                            </ItemStyle>
                                        </asp:TemplateColumn>

                                        <asp:BoundColumn DataField="precioTotal" Visible="false">
                                        </asp:BoundColumn>

                                        <asp:TemplateColumn HeaderText="IMPORTE">
                                            <ItemTemplate>
                                                <asp:Label id="lblPrecioTotal" runat="server"></asp:Label>
                                            </ItemTemplate>
	                                        <HeaderStyle Width="120px">
	                                        </HeaderStyle>
                                            <ItemStyle HorizontalAlign="Right">
                                            </ItemStyle>
                                        </asp:TemplateColumn>
                                   </Columns>
                                </asp:datagrid>
                                <div style="text-align:right; margin-top:10px; font-weight:bold;">TOTAL: <asp:Label ID="lblTotal" runat="server" Font-Bold="true"></asp:Label></div>
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
