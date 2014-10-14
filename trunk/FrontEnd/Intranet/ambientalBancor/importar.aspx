<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.ambientalBancor.importar" CodeFile="importar.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="menu" Src="../Inc/menu.ascx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD id="HEAD1" runat="server">
		<title>Bandeja de Entrada</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
		
			<script type="text/javascript">

			function marcarMenu() {
			    document.getElementById("td_menu_" + menu + "_1").style.backgroundColor = '#3557A1';
			}

			function printPendientes(idGrupo)
			{
			    window.printPendientes.src = 'impresionpendientes.aspx?imprimir=1&idGrupo='+idGrupo;
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
		        width: 125px;
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
            <!--  onload="javascript:mostrarFiltro(true, '');"-->
		<uc1:menu id="Menu1" runat="server"></uc1:menu>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" EnableScriptGlobalization="True">
        </asp:ScriptManager>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%">
                        Entrevista de Relevamiento Habitacional&nbsp;
						<BR>
						<HR>
                        <br />
					</td>
				</tr>
                
				<tr>
					<TD width="2%">&nbsp;</TD>
					<TD class="text" width="93%" colSpan="4">

                    <asp:Menu ID="menuTab" runat="server" Orientation="Horizontal" StaticHoverStyle-CssClass="itemMenuHover" StaticMenuItemStyle-CssClass="itemMenu" StaticSelectedStyle-CssClass="itemSelected" StaticMenuStyle-BackColor="#D3D3D3" Width="250" OnMenuItemClick="menuTab_MenuItemClick">
                                <Items>
                                    <asp:MenuItem Text="Generar excel" Value="0" Selectable="true"></asp:MenuItem>
                                    <asp:MenuItem Text="Importar" Value="1" Selectable="true"></asp:MenuItem>
                                </Items>
                            </asp:Menu>
                            <table cellpadding="0" cellspacing="0" width="250px">
                                <tr>
                                    <td id="td_menu_0_1" height="2px"></td>
                                    <td id="td_menu_1_1" height="2px"></td>
                                </tr>
                            </table>
                            
                         <asp:MultiView ID="contenedor" runat="server" ActiveViewIndex="0">
                         <asp:View ID="vExportar" runat="server">   
                            <div class="text">
                             Filtrar por:<br /> Fecha desde:&nbsp;<asp:TextBox ID="txtFechaDesde" runat="server" Width="70" 
                                    MaxLength="10"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtFechaDesde_CalendarExtender" runat="server" 
                                    TargetControlID="txtFechaDesde">
                                </cc1:CalendarExtender>
                                &nbsp;Fecha hasta:&nbsp;<asp:TextBox ID="txtFechaHasta" runat="server" MaxLength="10" Width="70"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtFechaHasta_CalendarExtender" runat="server" 
                                    TargetControlID="txtFechaHasta">
                                </cc1:CalendarExtender>
                                &nbsp;
                                <asp:CheckBox ID="chkEntregado" runat="server" Text="Entregados" />
                                &nbsp;<asp:Button ID="btnAplicar" runat="server" onclick="btnAplicar_Click" 
                                    Text="Aplicar" />
                             </div><br />
                        <asp:Label ID="Label1" runat="server" CssClass="text"></asp:Label>
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<TD class="text" width="100%">

                                        <asp:datagrid id="dgExportar" runat="server" Width="97%" 
                                        Font-Size="8pt" PageSize="20"
										CellPadding="3" BorderColor="#3657A6" BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="dgInformesExportar_PreRender">
                                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                            <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            <AlternatingItemStyle BackColor="#FBFBFB" />
                                            <ItemStyle BackColor="#F3F3F3" Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                            <HeaderStyle BackColor="#DFE7F4" Font-Bold="True" Font-Names="Arial" ForeColor="#3756A6" />
                                            <Columns>
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
                                                <asp:BoundColumn Visible="False" DataField="idEncabezado" HeaderText="Encabezado"></asp:BoundColumn>
                                                <asp:BoundColumn Visible="False" DataField="FechaCarga" HeaderText="Fecha"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Fecha">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFecha" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="50px" />
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="nombre" HeaderText="Apellido y nombre">
                                                    <HeaderStyle Width="120px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Documento" HeaderText="Nro de Documento">
                                                    <HeaderStyle Width="50px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="TipoVivienda" HeaderText="Tipo de vivienda">
                                                    <HeaderStyle Width="80px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="DestinoVivienda" HeaderText="Destino del inmueble">
                                                    <HeaderStyle Width="80px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="EstadoConservacion" HeaderText="Estado de conservacion">
                                                    <HeaderStyle Width="80px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="HabitaVive" HeaderText="Habita/vive en caracter de">
                                                    <HeaderStyle Width="80px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Resultado" HeaderText="Resultado">
                                                    <HeaderStyle Width="30px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Observaciones" HeaderText="Observaciones">
                                                </asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    <br />
                                    &nbsp;<asp:Label ID="lblDescargar" runat="server" Visible="False"></asp:Label> <asp:HyperLink ID="hlDescargar" runat="server" Visible="false" CssClass="text" Font-Bold="true"></asp:HyperLink>
                                        <iframe frameborder="0" width="50" height="50" id="Iframe1"></iframe>
                                        </TD>
							</tr>
						</TABLE>

                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="height: 24px" width="50%">
                                    &nbsp;</td>
                                <td style="height: 24px; text-align: right" width="50%">
                                        &nbsp;<asp:Button ID="btnImpresiones0" runat="server" 
                                            onclick="btnImpresiones_Click" Text="Impresiones anteriores" Width="150px" />
                                        &nbsp; <asp:Button ID="Button3" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
                                    &nbsp;&nbsp;<asp:button id="btnGenerarExcel" runat="server" Width="120px" 
                                            Text="Generar excel" onclick="btnGenerarExcel_Click"></asp:button></td>
                            </tr>
                        </table>
                        </asp:View>
                <asp:View ID="vImportar" runat="server">   
                <BR><asp:FileUpload ID="fuImportar" runat="server" Width="400" />&nbsp;&nbsp;
					    <asp:Button ID="btnImportar" runat="server" Text="Importar" 
                            onclick="btnImportar_Click" />
					    <br />
                        <br />
                        <asp:Label ID="lblMensajeImportacion" runat="server" CssClass="text"></asp:Label>
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<TD class="text" width="100%">

                                        <asp:datagrid id="dgInformesImportados" runat="server" Width="97%" 
                                        Font-Size="8pt" PageSize="20"
										CellPadding="3" BorderColor="#3657A6" BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="dgInformesImportados_PreRender">
                                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                            <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            <AlternatingItemStyle BackColor="#FBFBFB" />
                                            <ItemStyle BackColor="#F3F3F3" Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                            <HeaderStyle BackColor="#DFE7F4" Font-Bold="True" Font-Names="Arial" ForeColor="#3756A6" />
                                            <Columns>
                                                <asp:TemplateColumn>
                                                    <ItemTemplate>
                                                        &nbsp;<asp:CheckBox ID="chkPersona" runat="server" Checked="True" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="25px" />
                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" HorizontalAlign="Center" />
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="Column1" HeaderText="Nombre y Apellido">
                                                    <HeaderStyle Width="120px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Column2" HeaderText="Nº de Documento">
                                                    <HeaderStyle Width="30px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Column6" HeaderText="Domicilio">
                                                    <HeaderStyle Width="120px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Column7" HeaderText="Nº">
                                                    <HeaderStyle Width="40px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Column8" HeaderText="CP">
                                                    <HeaderStyle Width="40px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Column9" HeaderText="Localidad">
                                                    <HeaderStyle Width="120px" />
                                                </asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    <br />
                                    &nbsp;<asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red"
                                        Visible="False"></asp:Label>
                                        <iframe frameborder="0" width="50" height="50" id="printPendientes"></iframe>
                                        </TD>
							</tr>
						</TABLE>

                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="height: 24px" width="50%">
                                    &nbsp;</td>
                                <td style="height: 24px; text-align: right" width="50%">
						<asp:button id="btnImpresiones" runat="server" Width="150px" Text="Impresiones anteriores" 
                                        onclick="btnImpresiones_Click"></asp:button>
                                        &nbsp;<asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
                                    &nbsp;&nbsp;<asp:button id="btnAceptar" runat="server" Width="120px" Text="Aceptar" OnClick="btnAceptar_Click"></asp:button></td>
                            </tr>
                        </table>
                        </asp:View>
                </asp:MultiView>
                        &nbsp;&nbsp;
                    </TD>
					<TD width="5%">&nbsp;</TD>
				</tr>
			</TABLE>
		<DIV id="divDateControl" style="Z-INDEX: 102; LEFT: -35px; VISIBILITY: hidden; POSITION: absolute; TOP: -150px"><IFRAME name="popFrame" src="../inc/calendar/calendar.htm" frameBorder="0" width="160" scrolling="no"
				height="160"></IFRAME></DIV>
		</FORM>
		</body>
</HTML>
