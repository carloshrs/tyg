<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada.inhibicion_registro" CodeFile="inhibicion_registro.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="menu" Src="../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD id="HEAD1" runat="server">
		<title>Bandeja de Entrada</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
			<script type="text/javascript">
		
		function cambiarEstado(id)
		{
		    if (confirm('¿Informe con problemas?')) {
		        window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=16&idInforme=' + id + '','','dialogWidth:400px;dialogHeight:250px');
		        document.location.href='/BandejaEntrada/Principal.aspx?idTipo=16';
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
	<body leftMargin="0" topMargin="0"> <!--  onload="javascript:mostrarFiltro(true, '');"-->
		<uc1:menu id="Menu1" runat="server"></uc1:menu>
		<FORM id="Tipos" method="post" runat="server">
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
                            
  
                <div style="margin-top:10px;">Informes de inhibición <b>En Espera</b> en codiciones para generar el formulario de taza.</div>
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
                                                <asp:BoundColumn DataField="DescripcionInf" HeaderText="Descripción"></asp:BoundColumn>
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
                                            <asp:BoundColumn DataField="DescripcionInf" HeaderText="Descripción"></asp:BoundColumn>
                                        </Columns>
									</asp:datagrid>
                                        </asp:Panel>
                            <div style="text-align:right">
						<asp:button id="btnImpresiones" runat="server" Width="150px" Text="Impresiones anteriores" 
                                        onclick="btnImpresiones_Click"></asp:button>
                                        &nbsp;<asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
						&nbsp;<asp:button id="btnAceptar" runat="server" Width="100px" Text="Aceptar e imprimir" 
                                        OnClick="btnAceptar_Click"></asp:button>
                                        </div>

                           <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="8"
                                        Visible="False" style="margin-top:25px;"></asp:Label>

                        &nbsp;&nbsp;
                    </TD>
					<TD width="5%">&nbsp;</TD>
				</tr>
			</TABLE>
		</FORM>
		<DIV id="divDateControl" style="Z-INDEX: 102; LEFT: -35px; VISIBILITY: hidden; POSITION: absolute; TOP: -150px"><IFRAME name="popFrame" src="../inc/calendar/calendar.htm" frameBorder="0" width="160" scrolling="no"
				height="160"></IFRAME></DIV>
	</body>
</HTML>
