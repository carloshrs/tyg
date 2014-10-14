<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.InformePropiedadOtrasProvincias.propiedad_registro" CodeFile="propiedad_registro.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="menu" Src="../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD id="HEAD1" runat="server">
		<title>Bandeja de Entrada</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
			<script type="text/javascript">
		function marcarMenu()
		{
		    document.getElementById("td_menu_"+menu+"_1").style.backgroundColor = '#3557A1';
		}
		
		
		function cambiarEstado(id)
		{
		    if (confirm('�Informe con problemas?')) {
		        window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=1&idInforme=' + id + '&Problema=1','','dialogWidth:400px;dialogHeight:250px');
		        document.location.href='propiedad_registro.aspx?idTipo=1&Tab=1';
		    } 
	        //return false;
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
		        width: 160px;
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
		</style>
</HEAD>
	<body leftMargin="0" topMargin="0" onload="marcarMenu();"> 
		<FORM id="Tipos" method="post" runat="server">
            <!--  onload="javascript:mostrarFiltro(true, '');"-->
		<uc1:menu id="Menu1" runat="server"></uc1:menu>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%">
                        Registro&nbsp;de la Propiedad
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
							<asp:Menu ID="menuTab" runat="server" Orientation="Horizontal" StaticHoverStyle-CssClass="itemMenuHover" StaticMenuItemStyle-CssClass="itemMenu" StaticSelectedStyle-CssClass="itemSelected" StaticMenuStyle-BackColor="#D3D3D3" Width="480" OnMenuItemClick="menuTab_MenuItemClick">
                                <Items>
                                    <asp:MenuItem Text="En espera" Value="0" Selectable="true"></asp:MenuItem>
                                    <asp:MenuItem Text="En proceso" Value="1" Selectable="true"></asp:MenuItem>
                                    <asp:MenuItem Text="Con problemas" Value="2" Selectable="true"></asp:MenuItem>
                                </Items>
                            </asp:Menu>
                            <table cellpadding="0" cellspacing="0" width="480px">
                                <tr>
                                    <td id="td_menu_0_1" height="2px"></td>
                                    <td id="td_menu_1_1" height="2px"></td>
                                    <td id="td_menu_2_1" height="2px"></td>
                                </tr>
                            </table>
                            
                         <asp:MultiView ID="contenedor" runat="server" ActiveViewIndex="0">
                <asp:View ID="enEspera" runat="server">   
                <div style="margin-top:10px;">Informes de propiedad <b>En Espera</b> en codiciones para generar el formulario de taza.</div>
                                    <asp:Panel ID="pnEnEsperaSUrgentes" runat="server" style="margin-top:20px;">
                                    <asp:Label ID="lblTitEnEsperaSUrgentes" runat="server" Text="Super Urgentes" Font-Bold="true" Font-Size="8"></asp:Label><br />
                                        <asp:datagrid id="dgridEnEsperaSUrgentes" runat="server" Width="50%" Font-Size="8pt" PageSize="20"
										CellPadding="3" BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="dgridEnEsperaSUrgentes_PreRender">
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
                                                <asp:BoundColumn DataField="PROPTipo" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPMatricula" HeaderText="mat" Visible="False">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Width="120px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPFolio" HeaderText="folio" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPtomo" HeaderText="tomo" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPano" HeaderText="ano" Visible="False"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Descripci&#243;n">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
                                        </asp:datagrid>
                                    </asp:Panel>
                                    <asp:Panel ID="pnEnEsperaUrgentes" runat="server" style="margin-top:10px;margin-bottom:10px;">
                                        <asp:Label ID="lblTitEnEsperaUrgentes" runat="server" Text="Urgentes" Font-Bold="true" Font-Size="8"></asp:Label><br />
                                        <asp:datagrid id="dgridEnEsperaUrgentes" runat="server" Width="50%" Font-Size="8pt" PageSize="20"
										CellPadding="3" BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="dgridEnEsperaUrgentes_PreRender">
                                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                            <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            <AlternatingItemStyle BackColor="#FBFBFB" />
                                            <ItemStyle BackColor="#F3F3F3" Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                            <HeaderStyle BackColor="#DFE7F4" Font-Bold="True" Font-Names="Arial" ForeColor="#3756A6" />
                                            <Columns>
                                                <asp:BoundColumn DataField="idEncabezado" HeaderText="id" Visible="False"></asp:BoundColumn>
                                                <asp:TemplateColumn>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="CheckAll" OnClick="javascript: return select_deselectAll (this.checked, this.id, 'chkUrgente');" runat="server" Checked="true" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkUrgente" runat="server" Checked="True" />
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
                                                <asp:BoundColumn DataField="PROPTipo" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPMatricula" HeaderText="mat" Visible="False">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Width="120px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPFolio" HeaderText="folio" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPtomo" HeaderText="tomo" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPano" HeaderText="ano" Visible="False"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Descripci&#243;n">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
                                        </asp:datagrid>
                                        </asp:Panel>
                                    <asp:Panel ID="pnEnEsperaNormales" runat="server">
                                        <asp:Label ID="lblTitEnEsperaNormal" runat="server" Text="Normales" Font-Bold="true" Font-Size="8"></asp:Label><br />
                                    <asp:datagrid id="dgridEnEsperaNormales" runat="server" Width="50%" Font-Size="8pt" PageSize="20"
										CellPadding="3" BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="dgridEnEsperaNormales_PreRender">
                                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                        <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                        <AlternatingItemStyle BackColor="#FBFBFB" />
                                        <ItemStyle BackColor="#F3F3F3" Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                        <HeaderStyle BackColor="#DFE7F4" Font-Bold="True" Font-Names="Arial" ForeColor="#3756A6" />
                                        <Columns>
                                            <asp:BoundColumn DataField="idEncabezado" HeaderText="id" Visible="False"></asp:BoundColumn>
                                            <asp:TemplateColumn>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="CheckAll" OnClick="javascript: return select_deselectAll (this.checked, this.id, 'chkNormal');" runat="server" Checked="true" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkNormal" runat="server" Checked="True" />
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
                                            <asp:BoundColumn DataField="PROPTipo" Visible="False"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="PROPMatricula" HeaderText="mat" Visible="False">
                                                <ItemStyle HorizontalAlign="Left" />
</asp:BoundColumn>
    <asp:BoundColumn DataField="PROPFolio" HeaderText="folio" Visible="False"></asp:BoundColumn>
    <asp:BoundColumn DataField="PROPtomo" HeaderText="tomo" Visible="False"></asp:BoundColumn>
    <asp:BoundColumn DataField="PROPano" HeaderText="ano" Visible="False"></asp:BoundColumn>
    <asp:TemplateColumn HeaderText="Descripci&#243;n">
        <ItemTemplate>
            <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
        </ItemTemplate>
    </asp:TemplateColumn>
</Columns>
									</asp:datagrid>
                                        </asp:Panel>
                            <div style="text-align:right">
                                    <asp:Button ID="btnImpresiones" runat="server" OnClick="btnImpresiones_Click" 
                                        Text="Impresiones anteriores" Width="150px" />
						            &nbsp;<asp:button id="btnCancelar" runat="server" Text="Cancelar" 
                                        OnClick="btnCancelar_Click"></asp:button>
                                        &nbsp;<asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" 
                                        Text="Aceptar e imprimir listado taza" Width="200px" />
                                        </div>
						</asp:View>
						<asp:View ID="EnProceso" runat="server">   
						    <div style="margin-top:10px;">Informes de propiedad <b>En Proceso</b> en codiciones para ser ingresados al Registro de la Propiedad.</div>
						                                        <asp:Panel ID="pnEnProcesoSUrgentes" runat="server" style="margin-top:20px;">
                                    <asp:Label ID="lblTitEnProcesoSUrgentes" runat="server" Text="Super Urgentes" Font-Bold="true" Font-Size="8"></asp:Label><br />
                                        <asp:datagrid id="dgridEnProcesoSUrgentes" runat="server" Width="50%" Font-Size="8pt" PageSize="20"
										CellPadding="3" BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="dgridEnProcesoSUrgentes_PreRender">
                                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                            <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            <AlternatingItemStyle BackColor="#FBFBFB" />
                                            <ItemStyle BackColor="#F3F3F3" Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                            <HeaderStyle BackColor="#DFE7F4" Font-Bold="True" Font-Names="Arial" ForeColor="#3756A6" />
                                            <Columns>
                                                <asp:BoundColumn DataField="idEncabezado" HeaderText="id" Visible="False"></asp:BoundColumn>
                                                <asp:TemplateColumn>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="CheckAll" OnClick="javascript: return select_deselectAll (this.checked, this.id, 'chkNormal');" runat="server" Checked="true" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        &nbsp;<asp:CheckBox ID="chkSUrgente" runat="server" Checked="True" />
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
                                                <asp:BoundColumn DataField="PROPTipo" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPMatricula" HeaderText="mat" Visible="False">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Width="120px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPFolio" HeaderText="folio" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPtomo" HeaderText="tomo" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPano" HeaderText="ano" Visible="False"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Descripci&#243;n">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn>
                                                <HeaderStyle Width="25px">
                                                </HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center">
                                                </ItemStyle>
                                                <ItemTemplate>
                                                    <asp:ImageButton id="Problema" runat="server" Width="16px" ToolTip="Con problemas" CommandName="Problema" ImageUrl="/img/Estado9.gif"></asp:ImageButton>
                                                </ItemTemplate>
                                                </asp:TemplateColumn>

                                            </Columns>
                                        </asp:DataGrid>
                                    </asp:Panel>
                                    <asp:Panel ID="pnEnProcesoUrgentes" runat="server" style="margin-top:10px;margin-bottom:10px;">
                                        <asp:Label ID="lblTitEnProcesoUrgentes" runat="server" Text="Urgentes" Font-Bold="true" Font-Size="8"></asp:Label><br />
                                        <asp:datagrid id="dgridEnProcesoUrgentes" runat="server" Width="50%" Font-Size="8pt" PageSize="20"
										CellPadding="3" BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="dgridEnProcesoUrgentes_PreRender">
                                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                            <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            <AlternatingItemStyle BackColor="#FBFBFB" />
                                            <ItemStyle BackColor="#F3F3F3" Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                            <HeaderStyle BackColor="#DFE7F4" Font-Bold="True" Font-Names="Arial" ForeColor="#3756A6" />
                                            <Columns>
                                                <asp:BoundColumn DataField="idEncabezado" HeaderText="id" Visible="False"></asp:BoundColumn>
                                                <asp:TemplateColumn>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="CheckAll" OnClick="javascript: return select_deselectAll (this.checked, this.id, 'chkNormal');" runat="server" Checked="true" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        &nbsp;<asp:CheckBox ID="chkUrgente" runat="server" Checked="True" />
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
                                                <asp:BoundColumn DataField="PROPTipo" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPMatricula" HeaderText="mat" Visible="False">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Width="120px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPFolio" HeaderText="folio" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPtomo" HeaderText="tomo" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPano" HeaderText="ano" Visible="False"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Descripci&#243;n">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn>
                                                <HeaderStyle Width="25px">
                                                </HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center">
                                                </ItemStyle>
                                                <ItemTemplate>
                                                    <asp:ImageButton id="Problema" runat="server" Width="16px" ToolTip="Con problemas" CommandName="Problema" ImageUrl="/img/Estado9.gif"></asp:ImageButton>
                                                </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
                                        </asp:datagrid>
                                        </asp:Panel>
                                    <asp:Panel ID="pnEnProcesoNormales" runat="server">
                                        <asp:Label ID="lblTitEnProcesoNormal" runat="server" Text="Normales" Font-Bold="true" Font-Size="8"></asp:Label><br />
                                    <asp:datagrid id="dgridEnProcesoNormales" runat="server" Width="50%" Font-Size="8pt" PageSize="20"
										CellPadding="3" BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="dgridEnProcesoNormales_PreRender">
                                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                        <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                        <AlternatingItemStyle BackColor="#FBFBFB" />
                                        <ItemStyle BackColor="#F3F3F3" Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                        <HeaderStyle BackColor="#DFE7F4" Font-Bold="True" Font-Names="Arial" ForeColor="#3756A6" />
                                        <Columns>
                                            <asp:BoundColumn DataField="idEncabezado" HeaderText="id" Visible="False"></asp:BoundColumn>
                                            <asp:TemplateColumn>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="CheckAll" OnClick="javascript: return select_deselectAll (this.checked, this.id, 'chkNormal');" runat="server" Checked="true" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkNormal" runat="server" Checked="True" />&nbsp;
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
                                            <asp:BoundColumn DataField="PROPTipo" Visible="False"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="PROPMatricula" HeaderText="mat" Visible="False">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle Width="120px" />
                                            </asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPFolio" HeaderText="folio" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPtomo" HeaderText="tomo" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPano" HeaderText="ano" Visible="False"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Descripci&#243;n">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn>
                                                <HeaderStyle Width="25px">
                                                </HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center">
                                                </ItemStyle>
                                                <ItemTemplate>
                                                    <asp:ImageButton id="Problema" runat="server" Width="16px" ToolTip="Con problemas" CommandName="Problema" ImageUrl="/img/Estado9.gif"></asp:ImageButton>
                                                </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
									</asp:datagrid>
                                        </asp:Panel>
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="8"
                                        Visible="False"></asp:Label>
                            <div style="text-align:right">
                                    <asp:Button ID="btnCancelar2" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
						<asp:button id="btnAceptar2" runat="server" Width="200px" Text="Enviar al registro de la propiedad" 
                                        OnClick="btnAceptar2_Click"></asp:button>
                                        </div>
						</asp:View>
						<asp:View ID="Problemas" runat="server">   
						<div style="margin-top:10px;">Informes de propiedad con <b>Problemas</b>, informar al cliente el estado particular.</div>
                                    <asp:Panel ID="pnProblemaSUrgentes" runat="server" style="margin-top:20px;">
                                    <asp:Label ID="lblTitProblemaSUrgentes" runat="server" Text="Super Urgentes" Font-Bold="true" Font-Size="8"></asp:Label><br />
                                        <asp:datagrid id="dgridProblemaSUrgentes" runat="server" Width="50%" 
                                            Font-Size="8pt" PageSize="20"
										CellPadding="3" BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="dgridProblemaSUrgentes_PreRender" 
                                            onitemcommand="dgridProblemaSUrgentes_ItemCommand">
                                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                            <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            <AlternatingItemStyle BackColor="#FBFBFB" />
                                            <ItemStyle BackColor="#F3F3F3" Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                            <HeaderStyle BackColor="#DFE7F4" Font-Bold="True" Font-Names="Arial" ForeColor="#3756A6" />
                                            <Columns>
                                                <asp:BoundColumn DataField="idEncabezado" HeaderText="id" Visible="False"></asp:BoundColumn>
                                                <asp:TemplateColumn>
                                                    <ItemTemplate>
                                                        &nbsp;<asp:CheckBox ID="chkSUrgente" runat="server" Checked="True" />
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
                                                <asp:BoundColumn DataField="PROPTipo" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPMatricula" HeaderText="mat" Visible="False">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Width="120px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPFolio" HeaderText="folio" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPtomo" HeaderText="tomo" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPano" HeaderText="ano" Visible="False"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Descripci&#243;n">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn>
                                                    <HeaderStyle Width="25px">
                                                    </HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center">
                                                    </ItemStyle>
                                                    <ItemTemplate>
                                                    <asp:ImageButton id="Editar" runat="server" Width="16px" ToolTip="Editar" CommandName="Editar" ImageUrl="/img/modificar_general.gif"></asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
                                        </asp:datagrid>
                                    </asp:Panel>
                                    <asp:Panel ID="pnProblemaUrgentes" runat="server" style="margin-top:10px;margin-bottom:10px;">
                                        <asp:Label ID="lblTitProblemaUrgentes" runat="server" Text="Urgentes" Font-Bold="true" Font-Size="8"></asp:Label><br />
                                        <asp:datagrid id="dgridProblemaUrgentes" runat="server" Width="50%" 
                                            Font-Size="8pt" PageSize="20"
										CellPadding="3" BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="dgridProblemaUrgentes_PreRender" 
                                            onitemcommand="dgridProblemaUrgentes_ItemCommand">
                                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                            <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            <AlternatingItemStyle BackColor="#FBFBFB" />
                                            <ItemStyle BackColor="#F3F3F3" Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                            <HeaderStyle BackColor="#DFE7F4" Font-Bold="True" Font-Names="Arial" ForeColor="#3756A6" />
                                            <Columns>
                                                <asp:BoundColumn DataField="idEncabezado" HeaderText="id" Visible="False"></asp:BoundColumn>
                                                <asp:TemplateColumn>
                                                    <ItemTemplate>
                                                        &nbsp;<asp:CheckBox ID="chkUrgente" runat="server" Checked="True" />
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
                                                <asp:BoundColumn DataField="PROPTipo" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPMatricula" HeaderText="mat" Visible="False">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Width="120px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPFolio" HeaderText="folio" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPtomo" HeaderText="tomo" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPano" HeaderText="ano" Visible="False"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Descripci&#243;n">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn>
                                                    <HeaderStyle Width="25px">
                                                    </HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center">
                                                    </ItemStyle>
                                                    <ItemTemplate>
                                                    <asp:ImageButton id="Editar" runat="server" Width="16px" ToolTip="Editar" CommandName="Editar" ImageUrl="/img/modificar_general.gif"></asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
                                        </asp:datagrid>
                                        </asp:Panel>
                                    <asp:Panel ID="pnProblemaNormales" runat="server">
                                        <asp:Label ID="lblTitProblemaNormal" runat="server" Text="Normales" Font-Bold="true" Font-Size="8"></asp:Label><br />
                                    <asp:datagrid id="dgridProblemaNormales" runat="server" Width="50%" Font-Size="8pt" PageSize="20"
										CellPadding="3" BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="dgridProblemaNormales_PreRender" 
                                            onitemcommand="dgridProblemaNormales_ItemCommand">
                                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                        <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                        <AlternatingItemStyle BackColor="#FBFBFB" />
                                        <ItemStyle BackColor="#F3F3F3" Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                        <HeaderStyle BackColor="#DFE7F4" Font-Bold="True" Font-Names="Arial" ForeColor="#3756A6" />
                                        <Columns>
                                            <asp:BoundColumn DataField="idEncabezado" HeaderText="id" Visible="False"></asp:BoundColumn>
                                            <asp:TemplateColumn>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkNormal" runat="server" Checked="True" />&nbsp;
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
                                            <asp:BoundColumn DataField="PROPTipo" Visible="False"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="PROPMatricula" HeaderText="mat" Visible="False">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle Width="120px" />
                                            </asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPFolio" HeaderText="folio" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPtomo" HeaderText="tomo" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PROPano" HeaderText="ano" Visible="False"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Descripci&#243;n">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn>
                                                    <HeaderStyle Width="25px">
                                                    </HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center">
                                                    </ItemStyle>
                                                    <ItemTemplate>
                                                    <asp:ImageButton id="Editar" runat="server" Width="16px" ToolTip="Editar" CommandName="Editar" ImageUrl="/img/modificar_general.gif"></asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
									</asp:datagrid>
                                        </asp:Panel>
                            <div style="text-align:right">
                                    <asp:Button ID="Cancelar2" runat="server" OnClick="btnCancelar_Click" Text="Volver al listado de informes" />
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
		<DIV id="divDateControl" style="Z-INDEX: 102; LEFT: -35px; VISIBILITY: hidden; POSITION: absolute; TOP: -150px"><IFRAME name="popFrame" src="../inc/calendar/calendar.htm" frameBorder="0" width="160" scrolling="no"
				height="160"></IFRAME></DIV>
		</FORM>
		</body>
</HTML>
