<%@ Page language="c#" AutoEventWireup="true" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas.Admin_Cuentas_remitos" CodeFile="AbmMovimiento.aspx.cs" %>
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

function select_deselectAll(chkVal, idVal) {
    var frm = document.forms[0];
    // Loop through all elements
    for (i = 0; i < frm.length; i++) {
        // Look for our Header Template's Checkbox
        if (idVal.indexOf('CheckAll') != -1) {
            // Check if main checkbox is checked, then
            //select or deselect datagrid checkboxes
            if (chkVal == true) {
                frm.elements[i].checked = true;
            }
            else {
                frm.elements[i].checked = false;
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


    </script>
	<body leftMargin="0" topMargin="0">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
        
		<form id="Form1" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
                            EnablePartialRendering="true" EnableScriptGlobalization="True">
         </asp:ScriptManager>
             <asp:HiddenField ID="tipoDocumentacion" runat="server" />
             <input type="hidden" id="num_campos" name="num_campos" value="0" />
            <input type="hidden" id="cant_campos" name="cant_campos" value="0" />
			<table cellSpacing="0" cellPadding="0" width="98%" border="0">
				<tr>
					<td class="text" vAlign="top" width="5"></td>
					<td class="text" height="38">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="title" height="38">&nbsp;Alta de Movimiento <asp:Label ID="lblTipo" runat="server" Text=""></asp:Label>
									<HR>
									<BR>
								</td>
							</tr>
							<tr>
								<td class="text" height="38">
									<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#3657a6" cellSpacing="3"
										cellPadding="1" width="100%" border="1">
										<TR>
											<TD><asp:label id="lblEstado" runat="server" Font-Bold="True"> Filtro</asp:label><BR>
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
                                                </cc1:AutoCompleteExtender><asp:HiddenField ID="hIdCliente" runat="server" /><asp:HiddenField ID="hNroMovimiento" runat="server" />
                                                &nbsp;&nbsp;
												Fecha desde&nbsp;<asp:textbox id="txtFechaInicio" runat="server" Width="78px"></asp:textbox>
                                                <cc1:CalendarExtender ID="txtFechaInicio_CalendarExtender" runat="server" 
                                                    TargetControlID="txtFechaInicio">
                                                </cc1:CalendarExtender>
                                                &nbsp; 
                                                Fecha hasta <asp:textbox id="txtFechaFinal" runat="server" Width="78px"></asp:textbox>
                                                <cc1:CalendarExtender ID="txtFechaFinal_CalendarExtender" runat="server" 
                                                    TargetControlID="txtFechaFinal">
                                                </cc1:CalendarExtender>
                                                &nbsp;&nbsp;
												<asp:button id="btnBuscar" runat="server" Width="80px" Text="Buscar" 
                                                    onclick="btnBuscar_Click"></asp:button>&nbsp;
												<INPUT id="hidFecha" type="hidden" size="1" name="hidFecha" runat="server">
												<BR>
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td class="text" height="38">
                                    <asp:Panel ID="pnCliente" runat="server">
                                <br />
            			<span style="color: #AAA; font-size: 14px; font-weight: bold">Cliente</span> <a href='javascript:void(0);' id='projectSelectionLink' class='projectSelectionLink'>
                            <asp:Label ID="lblCliente" runat="server"></asp:Label>&nbsp;</a> 
		
                                &nbsp;<BR><BR>
								
                                    </asp:Panel></td>
							</tr>
							<tr>
								<td>
                                    <asp:Panel ID="pnListadoInformes" runat="server">
                                    <div style="height:120px; overflow:auto"><asp:datagrid id="dgridEncabezados" 
                                        runat="server" Width="100%" 
                                        Font-Size="8pt" PageSize="15" CellPadding="3" BorderColor="#3657A6" 
                                        BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="dgridEncabezados_PreRender" >
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
                                        <asp:BoundColumn DataField="idEncabezado" HeaderText="C&#243;digo">
                                        <HeaderStyle HorizontalAlign="Center" Width="15px">
                                        </HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center">
                                        </ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn Visible="False" DataField="FechaCarga" HeaderText="Fecha"></asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="Fecha">
                                        <HeaderStyle Width="50px">
                                        </HeaderStyle>

                                        <ItemTemplate>
                                        <asp:Label id="lblFecha" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateColumn>
                                        
                                       <asp:BoundColumn DataField="descripcion" HeaderText="Tipo de informe">
                                        <HeaderStyle Width="120px">
                                        </HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left">
                                        </ItemStyle>
                                        </asp:BoundColumn>

                                        <asp:BoundColumn DataField="DescripcionInf" HeaderText="Descripci&#243;n">
                                        <HeaderStyle Width="120px">
                                        </HeaderStyle>

                                        <ItemStyle HorizontalAlign="Left">
                                        </ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn Visible="False" DataField="Comentarios" HeaderText="Observaciones">
                                        <ItemStyle HorizontalAlign="Left">
                                        </ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:TemplateColumn>
                                        <HeaderStyle Width="25px">
                                        </HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center">
                                        </ItemStyle>

                                        <ItemTemplate>
                                            <asp:ImageButton id="VerEncabezado" runat="server" Width="16px" ImageUrl="/Img/lupita.gif" CommandName="VerEncabezado" ToolTip="Ver Informe" Height="16px" BorderWidth="0"></asp:ImageButton>
                                        </ItemTemplate>
                                        </asp:TemplateColumn>

                                        <asp:TemplateColumn>
                                        <HeaderStyle Width="25px">
                                        </HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center">
                                        </ItemStyle>

                                        <ItemTemplate>
                                            <asp:ImageButton id="addServicio" runat="server" Width="16px" ToolTip="Seleccionar" CommandName="Seleccionar" ImageUrl="/img/down.jpg" BorderWidth="0" OnClientClick="agregarFila(1, document.getElementById('cant_campos')); return false;"></asp:ImageButton>
                                        </ItemTemplate>
                                        </asp:TemplateColumn>
                                   </Columns>
                                </asp:datagrid>
                                </div>
                                </asp:Panel>
                                </td>
							</tr>
                                <tr><td class="text">
                                    <asp:Panel ID="pnRemito" runat="server">
                                    
                                        <asp:UpdatePanel ID="UpdatePanel1" 
                                                            UpdateMode="Conditional"
                                                            runat="server">
                                            <ContentTemplate>
                                                <fieldset>
                                
                                <asp:datagrid id="dgridRemitos" 
                                        runat="server" Width="50%" 
                                        Font-Size="8pt" PageSize="15" CellPadding="3" BorderColor="#3657A6" 
                                        BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="dgridRemitos_PreRender" onitemcommand="dgridRemitos_ItemCommand" >
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
                                        <asp:TemplateColumn HeaderText="">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="CheckAll" OnClick="javascript: return select_deselectAll (this.checked, this.id);" runat="server" Checked="true" />
                                        </HeaderTemplate>
                                        <HeaderStyle Width="50px" HorizontalAlign="Center">
                                        </HeaderStyle>

                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkEstado" runat="server" CssClass="text" Checked="true" />
                                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center">
                                        </ItemStyle>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn DataField="nroRemito" HeaderText="Remito">
                                        <HeaderStyle HorizontalAlign="Center" Width="15px">
                                        </HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center">
                                        </ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn Visible="False" DataField="fecha" HeaderText="Fecha"></asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="Fecha">
                                        <HeaderStyle Width="50px">
                                        </HeaderStyle>

                                        <ItemTemplate>
                                        <asp:Label id="lblFecha" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateColumn>
                                        
                                       <asp:BoundColumn DataField="cantInformes" HeaderText="Cantidad de informes">
                                        <HeaderStyle Width="120px">
                                        </HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center">
                                        </ItemStyle>
                                        </asp:BoundColumn>

                                        <asp:BoundColumn DataField="cantAdicionales" HeaderText="Cantidad adicionales">
                                        <HeaderStyle Width="120px">
                                        </HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center">
                                        </ItemStyle>
                                        </asp:BoundColumn>

                                        <asp:TemplateColumn>
                                        <HeaderStyle Width="25px">
                                        </HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center">
                                        </ItemStyle>

                                        <ItemTemplate>
                                            <asp:ImageButton id="Ver" runat="server" Width="16px" ImageUrl="/Img/lupita.gif" CommandName="Ver" ToolTip="Ver remito" Height="16px" BorderWidth="0"></asp:ImageButton>
                                        </ItemTemplate>
                                        </asp:TemplateColumn>

                                        <asp:TemplateColumn>
                                        <HeaderStyle Width="25px">
                                        </HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center">
                                        </ItemStyle>

                                        <ItemTemplate>
                                            <asp:ImageButton id="Eliminar" runat="server" Width="16px" ToolTip="Eliminar" CommandName="Eliminar" ImageUrl="/Img/cruz.gif" BorderWidth="0"></asp:ImageButton>
                                        </ItemTemplate>
                                        </asp:TemplateColumn>

                                   </Columns>
                                </asp:datagrid>
                                                
                                            
                                                </fieldset>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <br /><br />

                                        <input name="ctl00$mainArea$iterationsList$doUpdate" type="hidden" id="ctl00_mainArea_iterationsList_doUpdate" />
                                           <!--- Fin grilla--->
                                </asp:Panel>
                                    </td></tr>
							<tr>
								<td align="center">
									<asp:ValidationSummary ID="valSumary" runat="server" ShowMessageBox="True" ShowSummary="False"/>
                                </td>
							</tr>
							<tr>
								<td align="right">
									<asp:Button id="btnCerrar" runat="server" Text="Cerrar" CausesValidation="False" onclick="btnCerrar_Click"></asp:Button>
								&nbsp;<asp:Button id="btnAceptar" runat="server" Text="Finalizar movimiento" 
                                        CausesValidation="False" onclick="btnAceptar_Click"></asp:Button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
