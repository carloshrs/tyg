<%@ Page language="c#" AutoEventWireup="true" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas.Admin_Cuentas_remitos" CodeFile="AbmRemitos.aspx.cs" %>
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

        function eliminarFilaInforme(oId) {
            $("#rowInforme_" + oId).remove();
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
								<td class="title" height="38">&nbsp;Alta de remito / parte de entrega<asp:Label ID="lblTipo" runat="server"></asp:Label>
									<HR>
									<BR>
								</td>
							</tr>
							<tr>
								<td class="text" height="38">
                                <fieldset>
                                <legend>1 - Búsqueda de cliente</legend>
									<table class="text" style="BORDER-COLLAPSE: collapse" cellSpacing="3"
										cellPadding="1" width="100%" >
										<tr>
											<td>
												Cliente:
												<asp:RequiredFieldValidator ID="rqCliente" runat="server" 
                                                   ValidationGroup="Final" ErrorMessage="Seleccione cliente" ControlToValidate="txtCliente">*</asp:RequiredFieldValidator>
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
                                                </cc1:AutoCompleteExtender><asp:HiddenField ID="hIdCliente" runat="server" /><asp:HiddenField ID="hNroRemito" runat="server" />
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
												<br>
											</td>
										</tr>
									</table>
                                    </fieldset>
								</td>
							</tr>
                            <tr>
								<td>
                                    <asp:Panel ID="Panel1TipoDoc" runat="server">
                                    </asp:Panel>
                                <asp:Panel ID="pnlTipoDocumento" runat="server">
                                    <fieldset>
                                    <legend class="text">2 - Tipo de documento</legend>
                                    <div style="width:180px; font-size:12px; ">
                                        <table>
                                            <tr><td><asp:RadioButtonList ID="raTipoDocumento" runat="server" CssClass="text" RepeatDirection="Horizontal" style="width:200px;">
                                                <asp:ListItem Value="1"> Remito</asp:ListItem>
                                                <asp:ListItem Value="2"> Parte de entrega</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                                <td><asp:RequiredFieldValidator ID="valTipoDocumento" runat="server" ErrorMessage="Seleccione tipo de documento" ControlToValidate="raTipoDocumento" ValidationGroup="Final">*</asp:RequiredFieldValidator></td>
                                             </tr>
                                        </table>
                                    </div>
                                    </fieldset>
                                </asp:Panel>
                            </td>
							</tr>
                            <tr>
								<td>
                                <asp:Panel ID="pnlTipoPeriodo" runat="server">
                                    <fieldset>
                                    <legend class="text">3 - Tipo de período</legend>
                                    <div style="width:180px; font-size:12px; ">
                                        <table>
                                            <tr><td><asp:RadioButtonList ID="raTipoPeriodo" runat="server" CssClass="text" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1"> Diario</asp:ListItem>
                                                <asp:ListItem Value="2"> Mensual</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                                <td><asp:RequiredFieldValidator ID="valTipoPeriodo" runat="server" ErrorMessage="Seleccione periodo" ControlToValidate="raTipoPeriodo" ValidationGroup="Final">*</asp:RequiredFieldValidator></td>
                                             </tr>
                                        </table>
                                    </div>
                                    </fieldset>
                                </asp:Panel>
                            </td>
							<tr>
								<td class="text" height="38">
                                    <asp:Panel ID="pnCliente" runat="server">
                                <br />
            			<span style="color: #AAA; font-size: 14px; font-weight: bold">Cliente</span> <a href='javascript:void(0);' id='projectSelectionLink' class='projectSelectionLink'>
                            <asp:Label ID="lblCliente" runat="server"></asp:Label>&nbsp;</a> 
		
                                &nbsp;<BR>
                                <b><span style="color: #AAA; font-size: 14px; font-weight: bold">Dirección: </span><asp:Label ID="lblDireccion" runat="server"></asp:Label></b>
                                <BR><BR>
								
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
                                <tr><td class="text"><br /><br />
                                    <asp:Panel ID="pnRemito" runat="server">
                                    <fieldset>
                                    <legend>4 - Selección de informes y adicionales</legend>
                                    <table class="generalTable text" cellspacing="0" cellpadding="3" border="0" id="Table1" style="border-collapse:collapse;">
			                            <tr class="rowTop" style="font-weight: bold; color: #3756A6; background-color: #DFE7F4;">
				                            <th scope="col" style="width:1%;white-space:nowrap;">&nbsp;</th>
                                            <th scope="col" style="white-space:nowrap; width:60px">Cantidad</th>
                                            <th scope="col" style="width:80%">Tipo de Informe</th>
                                            <th scope="col" style="width:160px;" align="right">Importe</th>
			                            </tr>

                                        <asp:ListView ID="lvTiposInformes" runat="server" OnItemDataBound="InformeDataBound">
                                            <ItemTemplate>
                                            <tr>
				                                <td><img src="/img/plus.gif" style="cursor:pointer;" onclick="toggleRowVisibility('ctl00_mainArea_iterationsList_iterationsGrid_ct<%# Eval("idtipoInforme") %>', this);" /></td>
                                                <td class="big" align="center"><asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("cantidad") %>'></asp:Label></td>
                                                <td><asp:Label ID="lblTipoInforme" runat="server" Text='<%# Eval("tipoInforme") %>'></asp:Label></td>
                                                <td><asp:Label ID="lblPrecioTotal" runat="server" Text='<%# "$" + Eval("precioTotal") %>'></asp:Label></td>
                                                <td><asp:HiddenField ID="hdTipoInforme" runat="server" Value='<%# Eval("idtipoInforme") %>'></asp:HiddenField></td>
			                                </tr>
                                        
                                        <tr id="ctl00_mainArea_iterationsList_iterationsGrid_ct<%# Eval("idtipoInforme") %>" style="display:none;">
				                            <td colspan="5"><div id="ctl00_mainArea_iterationsList_iterationsGrid_ctl05_ct<%# Eval("idtipoInforme") %>">
					                        <div>
                                                <div class="expandedList">
                                                    <div>
								                        <table class="generalTable text" cellspacing="0" cellpadding="3" border="0" id="ctl00_mainArea_ti1" style="border-collapse:collapse; width:90%">
									                        <tr class="headRow" style="font-weight: bold; color: #3756A6; background-color: #DFE7F4;">
										                        <th scope="col" style="width:1%;"></th>
                                                                <th scope="col" style="width:1%;">ID</th>
                                                                <th scope="col" style="width:15%">Fecha</th>
                                                                <th scope="col">Descripción</th>
                                                                <th scope="col" style="width:10%" align="center">Precio unitario</th>
                                                                <th scope="col" style="width:80px; white-space:nowrap;">&nbsp;</th>
									                        </tr>
                                                            <asp:ListView ID="lvInformes" runat="server">
                                                            <ItemTemplate>
                                                            <tr class="rowDone" id='rowInforme_<%# Eval("idEncabezado") %>'>
                                                                <td style="color:#888888;" style="border-bottom: solid 1px #D5D5D5"><asp:CheckBox ID="chkIdEncabezado" runat="server" /></td>
                                                                <td style="color:#888888;" style="border-bottom: solid 1px #D5D5D5"><asp:HiddenField ID="hdIdEncabezado" runat="server" Value='<%# Eval("idEncabezado") %>'></asp:HiddenField><asp:Label ID="lblIdEncabezado" runat="server" Text='<%# Eval("idEncabezado") %>'></asp:Label></td>
                                                                <td style="border-bottom: solid 1px #D5D5D5"><asp:Label ID="lblFecha" runat="server" Text='<%# Eval("fechaCarga") %>'></asp:Label></td>
                                                                <td style="border-bottom: solid 1px #D5D5D5"><asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("descripcioninf") %>'></asp:Label></td>
                                                                <td style="border-bottom: solid 1px #D5D5D5" align="center"><asp:TextBox ID="txtPrecio" runat="server" Width="30" Text='<%# Eval("Precio") %>'></asp:TextBox></td>
                                                                <td class="big" align="right" style="white-space:nowrap;" style="border-bottom: solid 1px #D5D5D5">&nbsp;<a onclick="if (confirm('Desea quitar el informe del remito?')) {__doPostBack('ctl00$DeleteManager','Delinf_<%# Eval("idEncabezado") %>'); } return false;" id="ctl00_mainArea_iterationsList_iterationsGrid_ctl05_ctl02_ctl01_grdUserStories_ctl02_ved_lnkDelete" title="Delete" href="javascript:;"><img src="/Img/cruz.gif" style="border-width:0px;" /></a>&nbsp;</td>
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
                                            </ItemTemplate>
                                        </asp:ListView>


                                        </table><br /><br />
                                        <asp:UpdatePanel ID="UpdatePanel1" 
                                                            UpdateMode="Conditional"
                                                            runat="server">
                                            <ContentTemplate>
                                                <fieldset>
                                <asp:Panel ID="pnAdicionales" runat="server">
                            Servicios adicionales&nbsp;&nbsp;<asp:DropDownList id="ddAdicional" runat="server">
												</asp:DropDownList>&nbsp;<asp:Button ID="btn" runat="server" 
                                        Text="Agregar" CssClass="text" onclick="btn_Click" /><!---<input type="button" id="addAdicional" value="Agregar" onclick="agregarFila(2, document.getElementById('cant_campos'));" onclick="return addAdicional_onclick()" />--->
								<br /><br />
                                    </asp:Panel>

                                                <legend>Servicios adicionales</legend>
                                                <!-- Other content in the panel. -->
                                            <table class="generalTable text" cellspacing="0" cellpadding="3" border="0" id="Table2" style="border-collapse:collapse;">
			                                    <tr class="rowTop" style="font-weight: bold; color: #3756A6; background-color: #DFE7F4;">
                                                    <th scope="col" style="white-space:nowrap; width:60px">Cantidad</th>
                                                    <th scope="col" style="width:80%">Servicio adicional</th>
                                                    <th scope="col" style="width:160px;" align="right">Precio unitario</th>
                                                    <th scope="col" style="width:160px;" align="right">Importe</th>
                                                    <th scope="col" style="width:160px;" align="right"></th>
			                                    </tr>
                                                <asp:ListView ID="lvAdicionales" runat="server">
                                            <ItemTemplate>
                                            <tr>
                                                <td class="big" align="center" style="border-bottom: solid 1px #D5D5D5"><asp:HiddenField ID="hdIdAdicional" runat="server" Value='<%# Eval("idAdicional") %>' /><asp:TextBox ID="txtCantidad" runat="server" Text='<%# Eval("cantidad") %>' Width="20" onBlur="recalcular(1, this);"></asp:TextBox></td>
                                                <td style="border-bottom: solid 1px #D5D5D5"><asp:Label ID="lblAdicional" runat="server" Text='<%# Eval("Adicional") %>'></asp:Label></td>
                                                <td style="border-bottom: solid 1px #D5D5D5">$<asp:TextBox ID="txtPrecioUnitario" Width="40" runat="server" Text='<%# Eval("PrecioUnitario") %>' onBlur="recalcular(1, this);"></asp:TextBox></td>
                                                <td style="border-bottom: solid 1px #D5D5D5">$<asp:TextBox ID="txtPrecio" runat="server" Width="40" Text='<%# Eval("Precio") %>' ReadOnly="true" style="background-color:#FFF; border:0px;"></asp:TextBox></td>
                                                <td class="big" align="right" style="white-space:nowrap; border-bottom: solid 1px #D5D5D5">&nbsp;<a onclick="if (confirm('Desea quitar el servicio adicional del remito?')) {__doPostBack('ctl00$DeleteManager','Deladi_<%# Eval("idAdicional") %>'); } return false;" id="ctl00_mainArea_iterationsList_iterationsGrid_ctl05_ctl02_ctl01_grdUserStories_ctl02_ved_lnkDelete" title="Delete" href="javascript:;"><img src="/Img/cruz.gif" style="border-width:0px;" /></a>&nbsp;</td>
			                                </tr>
                                        
                                            </ItemTemplate>
                                        </asp:ListView>
                                        </table>
                                                </fieldset>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <br /><br />

                                        <input name="ctl00$mainArea$iterationsList$doUpdate" type="hidden" id="ctl00_mainArea_iterationsList_doUpdate" />
                                           <!--- Fin grilla--->
                                      </fieldset>
                                </asp:Panel>
                                    </td></tr>
							<tr>
								<td align="center">
									<asp:ValidationSummary ID="valSumary" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Final"/>
                                </td>
							</tr>
							<tr>
								<td align="right"><br /><br />
									<asp:Button id="btnCerrar" runat="server" Text="Cerrar" CausesValidation="False" onclick="btnCerrar_Click"></asp:Button>
								&nbsp;<asp:Button id="btnAceptar" runat="server" Text="Finalizar" CausesValidation="true" onclick="btnAceptar_Click" ValidationGroup="Final"></asp:Button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
