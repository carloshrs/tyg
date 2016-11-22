<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada.partidas_importar" CodeFile="importar.aspx.cs"%>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="uc1" TagName="menu" Src="../Inc/menu.ascx" %>
<!---  validateRequest="false" enableEventValidation="false"--->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD id="HEAD1" runat="server">
		<title>Bandeja de Entrada</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
		
		<link rel="stylesheet" href="../jquery/themes/base/jquery.ui.all.css"/>
	    <script src="../jquery/jquery-1.4.4.js" type="text/javascript"></script>
	    <script src="../jquery/external/jquery.bgiframe-2.1.2.js" type="text/javascript"></script>
	    <script src="../jquery/ui/jquery.ui.core.js" type="text/javascript"></script>
	    <script src="../jquery/ui/jquery.ui.widget.js" type="text/javascript"></script>
	    <script src="../jquery/ui/jquery.ui.mouse.js" type="text/javascript"></script>
	    <script src="../jquery/ui/jquery.ui.draggable.js" type="text/javascript"></script>
	    <script src="../jquery/ui/jquery.ui.position.js" type="text/javascript"></script>
	    <script src="../jquery/ui/jquery.ui.resizable.js" type="text/javascript"></script>
	    <script src="../jquery/ui/jquery.ui.dialog.js" type="text/javascript"></script>
	    
			<script type="text/javascript">
		function marcarMenu()
		{
		    document.getElementById("td_menu_"+menu+"_1").style.backgroundColor = '#3557A1';
		}
		
		
		function cambiarEstado(tipo, id) {

		    if (tipo == 1) {
		        if (confirm('¿Informe con problemas?')) {
		            window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=1&idInforme=' + id + '&Problema=1', '', 'dialogWidth:400px;dialogHeight:250px');
		            document.location.href = 'propiedad_registro.aspx?idTipo=1&Tab=1';
		        }
		    }

		    if (tipo == 2) {
		        if (confirm('¿Desea transferir el informe?')) {
		            document.location.href = '/BandejaEntrada/altaInforme.aspx?idTransferido=' + id;
		        }
		    }
		    
		    if (tipo == 3) {
		        if (confirm('¿Informe condicional?')) {
		            window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=1&idInforme=' + id + '&Condicional=1', '', 'dialogWidth:400px;dialogHeight:250px');
		            document.location.href = 'propiedad_registro.aspx?idTipo=1&Tab=1';
		        }
		    }
		    
		}

			/*
			function ToggleImg(name, src, alt)
			{
				name.src = "/img/" + src;
				name.alt = alt
			}

			function mostrarFiltro(First, name)
			{
				if (masFiltros.style.display == "none") 
				{
					masFiltros.style.display = "list-item";
					ToggleImg(name, 'Cerrar.gif', 'Cerrar Filtro Avanzado');
					BotonBuscar.style.display = "none";
				} 
				else 
				{
					Tipos.txtFechaInicio.value="";
					Tipos.txtFechaFinal.value="";
					masFiltros.style.display = "none";
					ToggleImg(name, 'Arrow.gif', 'Filtro Avanzado');
					BotonBuscar.style.display = "list-item";
				}
			}
*/

            function select_deselectAll(chkVal, idVal, grupo)
            {
                var frm = document.forms[0];
                // Loop through all elements
                for (i=0; i<frm.length; i++)
                {
                    // Look for our Header Template's Checkbox
                    if (idVal.indexOf('CheckAll') != -1)
                    {
                    // Check if main checkbox is checked, then
                    //select or deselect datagrid checkboxes
                        if(frm.elements[i].name.indexOf(grupo) != -1)
                        {
                            if(chkVal == true)
                            {
                                frm.elements[i].checked = true;
                            }
                            else
                            {
                                frm.elements[i].checked = false;
                            }
                        }
                        // Work here with the Item Template's multiple checkboxes
                    }
                    else if (idVal.indexOf ('DeleteThis') != -1)
                    {
                        // Check if any of the checkboxes are not
                        //checked, and then uncheck top select all checkbox
                        if(frm.elements[i].checked == false)
                        {
                            frm.elements[1].checked = false; //Uncheck
                        //main select all checkbox
                        }
                    }
                }
            }
            
function TransferirInforme(idEncabezado) {
    if (idEncabezado != "") {
        document.getElementById("lnkNuevoTransferido").href = "../BandejaEntrada/altaInforme.aspx?idTransferido=" + idEncabezado;
        document.getElementById("lnkExistenteTransferido").href = "javascript:abrirInformesExistentes(" + idEncabezado + ");";
        $('#dialog-confirm-transferido').dialog('open');
        return true;
    }
}

function abrirInformesExistentes(idEncabezado) {
    if (idEncabezado != "") {
        $('#dialog-confirm-transferido').dialog('close');
        $('#dialog-confirm-transferido-existente').dialog('open');
        informeExistente.listarInformesExistentes(idEncabezado, OnSucceeded);
        //alert("Hola")
        //aqui vamos a llamar a un WS para listar las mat existentes con este cliente.
        
        //document.getElementById("hdInformeSeleccionado").value = idEncabezado;
    }
}

function MostrarAyuda(tipo) {
    if (tipo == "infprop") {
        $('#dialog-alert').dialog('open');
        return true;
    }
}

$(document).ready(function() {
    $("#dialog:ui-dialog").dialog("destroy");

    $("#dialog-confirm-transferido").dialog({
        modal: true,
        autoOpen: false,
        width: 350,
        height: 345,
        buttons: {
        /*
            "Nuevo": function() {
                $(this).dialog("close");
            },
            "Existente": function() {
                $(this).dialog("close");
            },*/
            Cancel: function() {
                $(this).dialog("close");
                //habilitarBotones("Aceptar");
                return false;
                }
        }
    });

    $("#dialog-confirm-transferido-existente").dialog({
        modal: false,
        autoOpen: false,
        width: 600,
        height: 345,
        buttons: {
            /*
            "Nuevo": function() {
            $(this).dialog("close");
            },
            "Existente": function() {
            $(this).dialog("close");
            },*/
            Cancel: function() {
                $(this).dialog("close");
                //habilitarBotones("Aceptar");
                return false;
            }
        }
    });
});



function OnSucceeded(result) {

    var tempP = new Array();
    tempP = result.split('_');
    alert(tempP[0]);
    alert(tempP[1]);
    alert(tempP[2]);
    idEnca = tempP[0];
    var tempPer = new Array();
    tempPer = tempP[1].split('|');

    if (tempPer.length > 0) {
        if (tempPer[0] != "") {
            varMessage = "Seleccione un informe existente a transferir: <br>";
            for (i = 0; i < tempPer.length; i++) {
                var tempSolDetalle = new Array();
                tempSolDetalle = tempPer[i].split(',');
                varMessage = varMessage + "<div class='cajaTransferir'><a href='../BandejaEntrada/abmInforme.aspx?id=" + tempSolDetalle[0] + "&idTransferido=" + idEnca + "' class='link2'><b>" + tempSolDetalle[2] + "</b> el dia " + tempSolDetalle[1] + " (" + tempSolDetalle[3] + ")</div>";

            }
            document.getElementById("lblInformesExistentes").innerHTML = varMessage;
        }
        else {
            document.getElementById("lblInformesExistentes").innerHTML = "";
            return false;
        }
    }
}


			</script>
			<style>
		    .itemMenu 
		    {
		        background-color: #D3D3D3;
		        text-align: center;
		        color: #3557A1;
		        font-family: Arial, Verdana, Helvetica, Sans-Serif; 
		        font-size:10pt;
		        font-weight: bold;
		        width: 140px;
		    }
		    .itemMenuSelected
		    {
		        background-color: #FFFFFF;
		        font-style: italic;
		    }
		    .itemMenuHover
		    {
		        background-color: #EAEAEA;
		    }
		    .cajaTransferir
		    {
		    	background-color:#F3F3F3;
		    	padding:3px;
		    	margin-bottom:2px;
		    	border: 1px solid #3657A6;
		    	text-align:left;
		    }
		</style>
</HEAD>
	<body leftMargin="0" topMargin="0" onload="marcarMenu();"> 
		<FORM id="Tipos" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference  Path="../services/informeExistente.asmx" />
            </Services>
        </asp:ScriptManager>
            <!--  onload="javascript:mostrarFiltro(true, '');"-->
		<uc1:menu id="Menu1" runat="server"></uc1:menu>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%">
                        Partidas de defunción
						<BR>
						<HR>
						<BR>
					</td>
				</tr>
				<tr>
					<TD width="2%">&nbsp;</TD>
					<TD class="text" width="93%" colSpan="4">
				                <div style="margin-top:10px; margin-bottom:20px;">
                <table cellSpacing="0" cellPadding="0" width="500" border="0">
					<tr>
						<td class="text" align="left" width="100%" colSpan="4">&nbsp;Solicitudes&nbsp;que 
							contenga:
						</td>
					</tr>
					<tr>
						<td class="text" align="left" width="50%">&nbsp;<asp:textbox id="txtContengan" runat="server" Width="258px" CssClass="planotext"></asp:textbox>&nbsp;&nbsp;&nbsp;
						</td>
						<td class="text" align="left" width="105">&nbsp;</td>
						<td class="text" align="left" width="188"><asp:checkbox id="chkSoloMias" runat="server" Width="120px" Text="&nbsp;Solo mis Solicitudes"></asp:checkbox></td>
						<td class="text" align="right" width="28%">
							<table cellspacing="0" cellpadding="0" width="100%" border="0">
								<tr>
									<td class="text" id="BotonBuscar" align="right" width="100%" colspan="4"><asp:button id="btnBuscar" runat="server" Width="58px" Text="Buscar" onclick="btnBuscar_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
									</td>

								</tr>
							</table>
						</td>
					</tr>
				</table>
				</div>
				</td></tr>
				<tr>
					<TD width="2%">&nbsp;</TD>
					<TD class="text" width="93%" colSpan="4">
							<asp:Menu ID="menuTab" runat="server" Orientation="Horizontal" StaticHoverStyle-CssClass="itemMenuHover" StaticMenuItemStyle-CssClass="itemMenu" StaticSelectedStyle-CssClass="itemSelected" StaticMenuStyle-BackColor="#D3D3D3" Width="700" OnMenuItemClick="menuTab_MenuItemClick">
                                <Items>
                                    <asp:MenuItem Text="Importar" Value="0" Selectable="true"></asp:MenuItem>
                                    <asp:MenuItem Text="En espera" Value="1" Selectable="true"></asp:MenuItem>
                                    <asp:MenuItem Text="Finalizados" Value="2" Selectable="true"></asp:MenuItem>
                                    
                                    
                                </Items>
                            </asp:Menu>
                            <table cellpadding="0" cellspacing="0" width="700px">
                                <tr>
                                    <td id="td_menu_0_1" height="2px"></td>
                                    <td id="td_menu_1_1" height="2px"></td>
                                    <td id="td_menu_2_1" height="2px"></td>
                                    
                                </tr>
                            </table>
                            
                         <asp:MultiView ID="contenedor" runat="server" ActiveViewIndex="0">
                         <asp:View ID="vwExaminar" runat="server">   
						    <div style="margin-top:10px;">Importar verificaciones de defunción desde excel.</div>
						                                        
                                    
                                    <asp:Panel runat="server" ID="pnExaminar" Visible="true">
                                        <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="8"
                                        Visible="False"></asp:Label>
                                        Seleccione un archivo de excel para importar las personas en un proceso masivo.<br /><br /><br />
                            <asp:FileUpload ID="fuExcel" runat="server" />
                            <asp:RegularExpressionValidator ID="REGEXFileUploadLogo" runat="server" ErrorMessage="Solo archivos Excel" ControlToValidate="fuExcel" ValidationExpression= "(.*).(.xls|.XLS|.xlsx|.XLSX)$" />

                            <div style="text-align:right; margin-top:20px;">
                                    <asp:Button ID="Button1" runat="server" OnClick="btnCancelar_Click" Text="Volver al listado" Visible="true"/>
						<asp:button id="btnProcesar" runat="server" Width="100px" Text="Procesar" Visible="true" 
                                        onclick="btnProcesar_Click"></asp:button>
                                        </div>
                                        </asp:Panel>
                                        <asp:Panel runat="server" ID="pnObtener" Visible="false">
                                        <br /><br />
                                        <fieldset style="width:400px;">
                                            <legend>1 - ¿La primera fila es el encabezado?</legend>
                                                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                        <asp:RadioButtonList ID="rbHDR" runat="server" CssClass="text">
                                            <asp:ListItem Text = "Si" Value = "Yes" Selected = "True" ></asp:ListItem>
                                            <asp:ListItem Text = "No" Value = "No"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        </fieldset>
                            <br /><br />
                            <fieldset style="width:400px;">
                                            <legend>2 - Orden de columnas</legend>
                                            DNI: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:dropdownlist id="cmbColDNI" runat="server" Width="161px">
                                                <asp:ListItem Value="0" Selected="True">Seleccione Orden</asp:ListItem>
						                        <asp:ListItem Value="1">Columna Nº1</asp:ListItem>
						                        <asp:ListItem Value="2">Columna Nº2</asp:ListItem>
                                                <asp:ListItem Value="3">Columna Nº3</asp:ListItem>
                                                <asp:ListItem Value="4">Columna Nº4</asp:ListItem>
                                                <asp:ListItem Value="5">Columna Nº5</asp:ListItem>
					                          </asp:dropdownlist><br />
                                              Apellido: <asp:dropdownlist id="cmbColApellido" runat="server" Width="161px">
                                                <asp:ListItem Value="0" Selected="True">Seleccione Orden</asp:ListItem>
						                        <asp:ListItem Value="1">Columna Nº1</asp:ListItem>
						                        <asp:ListItem Value="2">Columna Nº2</asp:ListItem>
                                                <asp:ListItem Value="3">Columna Nº3</asp:ListItem>
                                                <asp:ListItem Value="4">Columna Nº4</asp:ListItem>
                                                <asp:ListItem Value="5">Columna Nº5</asp:ListItem>
					                          </asp:dropdownlist>
                                              <br />
                                              
                                              Nombre: <asp:dropdownlist id="cmbColNombre" runat="server" Width="161px">
                                                <asp:ListItem Value="0" Selected="True">Seleccione Orden</asp:ListItem>
						                        <asp:ListItem Value="1">Columna Nº1</asp:ListItem>
						                        <asp:ListItem Value="2">Columna Nº2</asp:ListItem>
                                                <asp:ListItem Value="3">Columna Nº3</asp:ListItem>
                                                <asp:ListItem Value="4">Columna Nº4</asp:ListItem>
                                                <asp:ListItem Value="5">Columna Nº5</asp:ListItem>
					                          </asp:dropdownlist><br />
                                              Sexo:&nbsp;&nbsp;&nbsp; <asp:dropdownlist id="cmbColSexo" runat="server" Width="161px">
                                                <asp:ListItem Value="0" Selected="True">Seleccione Orden</asp:ListItem>
						                        <asp:ListItem Value="1">Columna Nº1</asp:ListItem>
						                        <asp:ListItem Value="2">Columna Nº2</asp:ListItem>
                                                <asp:ListItem Value="3">Columna Nº3</asp:ListItem>
                                                <asp:ListItem Value="4">Columna Nº4</asp:ListItem>
                                                <asp:ListItem Value="5">Columna Nº5</asp:ListItem>
					                          </asp:dropdownlist><br />
                                              CUIT:&nbsp;&nbsp;&nbsp; <asp:dropdownlist id="cmbColCUIT" runat="server" Width="161px">
                                                <asp:ListItem Value="0" Selected="True">Seleccione Orden</asp:ListItem>
						                        <asp:ListItem Value="1">Columna Nº1</asp:ListItem>
						                        <asp:ListItem Value="2">Columna Nº2</asp:ListItem>
                                                <asp:ListItem Value="3">Columna Nº3</asp:ListItem>
                                                <asp:ListItem Value="4">Columna Nº4</asp:ListItem>
                                                <asp:ListItem Value="5">Columna Nº5</asp:ListItem>
					                          </asp:dropdownlist>
                                              </fieldset>
                                              <br /><br />

                                              <asp:Label ID="lblCantidad" runat="server" Text="Label" Font-Bold="true" Font-Size="Large"></asp:Label><br /><br />
                                            <fieldset style="width:800px;">
                                            <legend>3 - Registros a importar</legend>
                                            <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging = "PageIndexChanging" AllowPaging = "true"  
                                            Width="95%" Font-Size="8pt" PageSize="20" CellPadding="3" BorderColor="#3657A6" BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical">
                                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="#FBFBFB" />
                                            <RowStyle BackColor="#F3F3F3" Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                            <HeaderStyle BackColor="#DFE7F4" Font-Bold="True" Font-Names="Arial" ForeColor="#3756A6" />
                                            </asp:GridView>
                                            </fieldset>
                                            <br />
                                            
                                            <div style="text-align:right; margin-top:20px;">
                                                
                                    <asp:Button ID="btnCancelar2" runat="server" OnClick="btnCancelar_Click" Text="Volver" Visible="true"/>
						            <asp:button id="btnFinalizar" Width="100px"  runat="server" Text="Finalizar" Visible="true" 
                                                    onclick="btnFinalizar_Click"></asp:button>
                                        </div>
                                        </asp:Panel>

                                        <asp:Panel runat="server" ID="pnProcesoFinalizado" Visible="false">
                                        <br /><br /><br /><br />
                                            <asp:Label ID="lblMsjProcesoFinalizado" runat="server" Text="Proceso de importación finalizado con éxito." Font-Size="X-Large" Font-Bold="true"></asp:Label>
                                        </asp:Panel>
						</asp:View>

                        <asp:View ID="vwEspera" runat="server">   
                              <div style="margin-top:10px;">Verificaciones de defunción <b>En Espera</b> en codiciones para solicitar en tribunales federales.</div>
                                    <asp:Panel ID="pnEnEspera" runat="server" style="margin-top:20px;">
                                        <br />
                                        <asp:datagrid id="dgridEnEspera" runat="server" Width="50%" Font-Size="8pt" PageSize="20"
										CellPadding="3" BorderColor="#3657A6" BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="dgridEnEspera_PreRender">
                                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                            <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            <AlternatingItemStyle BackColor="#FBFBFB" />
                                            <ItemStyle BackColor="#F3F3F3" Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                            <HeaderStyle BackColor="#DFE7F4" Font-Bold="True" Font-Names="Arial" ForeColor="#3756A6" />
                                            <Columns>
                                                <asp:BoundColumn DataField="idEncabezado" HeaderText="id" Visible="False"></asp:BoundColumn>
                                                <asp:TemplateColumn>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="CheckAll" OnClick="javascript: return select_deselectAll (this.checked, this.id, 'chkSUrgente');" runat="server" Checked="true" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSUrgente" runat="server" Checked="True" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="25px" />
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn Visible="False" DataField="FechaCarga" HeaderText="Fecha"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Fecha">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFecha" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="50px" />
                                                </asp:TemplateColumn>
                                                
                                                <asp:BoundColumn DataField="DescripcionInf" HeaderText="Descripción"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Descripci&#243;n" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
                                        </asp:datagrid>
                                    </asp:Panel>
                                    
                                    
                            <div style="text-align:right">
                                    <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
						            &nbsp;<asp:button id="btnImpresiones" runat="server" Width="150px" 
                                        Text="Impresiones anteriores" onclick="btnImpresiones_Click"></asp:button>
                                        &nbsp;<asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" 
                                        Text="Aceptar e imprimir por sexo" Width="200px" />
                                        </div>
						</asp:View>
						
						
						<asp:View ID="vwFinalizados" runat="server">   
                                    <asp:Panel ID="Panel1" runat="server" style="margin-top:20px;">
                                        Historial de verificaciones de defunción <b>finalizadas</b> para imprimir.
						<BR>
						<HR>
						<BR>
                        <asp:Repeater ID="rpHistorial" runat="server">
                         <ItemTemplate>
                         <div style="margin:16px;"><div style="float:left;">
                             <img src="/Img/left.jpg" width="14" height="14" border="0" /></div>
                             <div style="width:700px; margin-top:5px;">
                                 <a href="impresionfinalizados.aspx?estado=-1&idGrupo=<%#Eval("id")%>" class="link">
                               <%#Eval("fecha")%> generado por <%#Eval("nombre")%> <%#Eval("apellido")%> (total <%#Eval("total")%>)
                              </a></div>
                              </div>
                         </ItemTemplate>
                        </asp:Repeater>
                                    </asp:Panel>
                                    
                                    
                            <div style="text-align:right">
                                    <asp:Button ID="Button3" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
						            &nbsp;<asp:button id="Button4" runat="server" Width="150px" 
                                        Text="Impresiones anteriores" onclick="btnImpresiones_Click" Visible="false"></asp:button>
                                        &nbsp;<asp:Button ID="Button5" runat="server" OnClick="btnAceptar_Click" 
                                        Text="Aceptar e imprimir listado" Width="200px" Visible="false" />
                                        </div>
						</asp:View>
						
											
                </asp:MultiView>
                           <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="8"
                                        Visible="False" style="margin-top:25px;"></asp:Label>

                        &nbsp;&nbsp;
                    </TD>
					<TD width="5%">&nbsp;</TD>
				</tr>
			</TABLE>
		<div id="divDateControl" style="Z-INDEX: 102; LEFT: -35px; VISIBILITY: hidden; POSITION: absolute; TOP: -150px"><IFRAME name="popFrame" src="../inc/calendar/calendar.htm" frameBorder="0" width="160" scrolling="no"
				height="160"></IFRAME></div>
				
    
    
    
    
    
		</FORM>
		</body>
</HTML>
