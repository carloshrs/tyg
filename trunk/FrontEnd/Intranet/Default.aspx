<%@ Register TagPrefix="uc1" TagName="menu" Src="Inc/menu.ascx" %>
<%@ Page Language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet._Default" Trace="False" CodeFile="Default.aspx.cs" Culture="Auto" UICulture="Auto" %>
<%@ Register assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<HTML>
	<HEAD runat="server">
		<title>Tiempo y Gestión</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet" />
		
	<style type="text/css">
	.list {
	    border: 1px solid #000;
	    list-style-type: none;
	    margin: 0px;
	    padding:3px;
	    padding-top:4px;
	    padding-bottom:4px;
	    background-color: #333333;
    }

	ul.list li {
		padding: 0px;
		margin:3px;
	}

	.listitem {
		color: #DDDDDD;
		font-size:14px;
		font-weight:bold;
		border-bottom: 1px dashed #CCCCCC;
		padding: 3px;
		margin:0px;
	}

	.hoverlistitem {
		background-color: #F0FFF8;
		font-size:14px;
		font-weight:bold;
	}

    .list2 {
	    border: 1px solid #009;
	    list-style-type: none;
	    margin: 0px;
	    background-color: #FFF;
	    text-align: right;
    }

	ul.list2 li {
		padding: 2px 5px;
	}

	.listitem2 {
		color: #00A;
	}

	.hoverlistitem2 {
		background-color: #F0F8FF;
	}
	
	.listempresa {
	}
	
	.listsucursal 
	{
		font-size:12px;
	}
	
	.listdireccion 	
	{
		float:left;
		font-size:12px;
	}
	
	</style>

	<script type="text/javascript">
	    function mostrarFiltro(First, name) {
	        if (masFiltros.style.display == "none") {
	            masFiltros.style.display = "list-item";
	            ToggleImg(name, 'Cerrar.gif', 'Cerrar Filtro Avanzado');
	            //btnBuscar.style.display = "none";
	        }
	        else {
	            //Tipos.txtFechaInicio.value = "";
	            //Tipos.txtFechaFinal.value = "";
	            masFiltros.style.display = "none";
	            ToggleImg(name, 'Arrow.gif', 'Filtro Avanzado');
	            //btnBuscar.style.display = "list-item";
	        }
	    }

	    function ToggleImg(name, src, alt) {
	        name.src = "/img/" + src;
	        name.alt = alt
	    }
	    

        function ShowIcon() {
         
            var e = document.getElementById("processing");
         
            e.style.visibility =  (e.style.visibility == 'visible') ? 'hidden' : 'visible';
         
        }
        
       function IAmSelected( source, eventArgs ) {
            //alert( " Key : "+ eventArgs.get_text() +"  Value :  "+eventArgs.get_value()); 
            valor = eventArgs.get_value();
            document.getElementById("hIdCliente").value = valor;
        }
        
		function cambioEstado(idTipo, idInforme)
		{
		    window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo='+idTipo+'&idInforme='+idInforme+'&Finalizar=1','','dialogWidth:400px;dialogHeight:250px'); 
		}
 
	</script>
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="<% if( !bsqRapida ){ %>javascript:mostrarFiltro(true, '');<%} %>">
		<form id="Tipos" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu>
                        <asp:ScriptManager ID="ScriptManager1" runat="server" 
                            EnablePartialRendering="true" EnableScriptGlobalization="True">
                        </asp:ScriptManager>
									<asp:Literal id="litGrupos" runat="server"></asp:Literal></TD>
				</TR>
				<TR>
					<TD width="100%" class="text" colspan="2" align="center" height="400">&nbsp;
					<table class="text"><tr><td>
						Búsqueda de referencias e informes por cliente:</td></tr>
						<tr><td>
                        <asp:TextBox ID="txtBuscar" runat="server" Width="335px" Style="text-transform: uppercase;"></asp:TextBox>&nbsp;<img id="processing" style="visibility:hidden" src="/img/ajaxloader-thumb.gif"  />&nbsp;&nbsp;<asp:Button ID="btnBuscar" runat="server" Text="Buscar Informes" 
                            onclick="btnBuscar_Click" />
                         <cc1:AutoCompleteExtender ID="txtBuscar_AutoCompleteExtender" runat="server" 
                            TargetControlID="txtBuscar"
                            ServicePath="~/services/clientes.asmx" 
                            UseContextKey="True"
                            ServiceMethod="getClientes" 
                            MinimumPrefixLength="3" 
                            CompletionSetCount="12" 
                            CompletionInterval="1000"
                            onclientpopulating="ShowIcon"
                            onclientpopulated="ShowIcon"
                            OnClientItemSelected="IAmSelected" 
                            CompletionListCssClass="list" 
	                        CompletionListItemCssClass="listitem" 
	                        CompletionListHighlightedItemCssClass="hoverlistitem">
                        </cc1:AutoCompleteExtender>
                        
					    &nbsp;<a onclick="javascript:mostrarFiltro(false, imgFiltro);" href="#"><img alt="Filtro Avanzado" border="0" height="14" name="imgFiltro" 
                            src="../../../../../../../img/Arrow.gif" width="14" /></a>
                            <asp:HiddenField ID="hIdCliente" runat="server" />
                             
                            </td></tr>
                        <tr id="masFiltros">
								<td class="text" align="left" width="100%">
									<table cellSpacing="0" cellPadding="0" width="70%" border="0">
										<tr>
											<TD class="text" align="left" width="10%">&nbsp;Fecha Desde:&nbsp;
											</TD>
											<TD class="text" align="left" width="10%">&nbsp;Fecha Hasta:&nbsp;
											</TD>
										</tr>
										<tr>
											<TD class="text" align="left" width="10%" style="height: 30px">&nbsp;<asp:textbox id="txtFechaInicio" runat="server" Width="77px"></asp:textbox>
                                                <cc1:CalendarExtender ID="txtFechaInicio_CalendarExtender" runat="server" 
                                                    TargetControlID="txtFechaInicio" PopupButtonID="imgFechaInicio" 
                                                    PopupPosition="BottomRight" Format="dd/MM/yyyy">
                                                </cc1:CalendarExtender>
                                                &nbsp;
												<IMG id="imgFechaInicio" style="CURSOR: hand" 
													alt="Abrir Calendario" src="/img/fecha.gif">
											</TD>
											<TD class="text" align="left" width="10%" style="height: 30px">&nbsp;&nbsp;<asp:textbox id="txtFechaFinal" runat="server" Width="88px"></asp:textbox>
                                                <cc1:CalendarExtender ID="txtFechaFinal_CalendarExtender" runat="server" 
                                                    TargetControlID="txtFechaFinal"
                                                    PopupButtonID="imgFechaFinal" 
                                                    PopupPosition="BottomRight"
                                                    Format="dd/MM/yyyy">
                                                </cc1:CalendarExtender>
                                                &nbsp;
												<IMG id="imgFechaFinal" style="CURSOR: hand" 
													alt="Abrir Calendario" src="/img/fecha.gif">
											</TD>
										</tr>
									</TABLE>
								</TD>
							</TR>
                        </table>
					   
                        &nbsp;&nbsp;<br />
                        <br />
                        <asp:UpdatePanel ID="upListadoInformes" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                <fieldset style="border:0px">
                    <asp:DataGrid ID="dgridEncabezados" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#3657A6" BorderStyle="Solid" BorderWidth="1px" 
                        CellPadding="3" Font-Size="8pt" GridLines="Vertical" 
                        OnPageIndexChanged="dgridEncabezados_PageIndexChanged" 
                        onprerender="dgridEncabezados_PreRender" 
                        onselectedindexchanged="dgridEncabezados_SelectedIndexChanged" PageSize="15" 
                        Width="95%" onitemcommand="dgridEncabezados_ItemCommand">
                        <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <AlternatingItemStyle BackColor="#FBFBFB" />
                        <ItemStyle BackColor="#F3F3F3" Font-Names="Arial" Font-Size="8pt" 
                            ForeColor="Black" />
                        <HeaderStyle BackColor="#DFE7F4" Font-Bold="True" Font-Names="Arial" 
                            ForeColor="#3756A6" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <Columns>
                            <asp:BoundColumn DataField="idEncabezado" HeaderText="Código">
                                <HeaderStyle HorizontalAlign="Center" Width="15px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="FechaCarga" HeaderText="Fecha" Visible="False">
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Fecha">
                                <HeaderStyle Width="50px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Cliente">
                            <HeaderStyle Width="80px">
                            </HeaderStyle>
                            <ItemTemplate>
                            <asp:Label id="lblEmpresa" runat="server"></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="Descripcion" HeaderText="Tipo de informe">
                                <HeaderStyle Width="120px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DescripcionInf" HeaderText="Descripción">
                                <HeaderStyle Width="120px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Comentarios" HeaderText="Observaciones" 
                                Visible="False">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="NombreEstado" HeaderText="Estado" Visible="False">
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Estado"></asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderStyle Width="25px" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="Editar" runat="server" CommandName="Editar" 
                                        ImageUrl="/img/modificar_general.gif" ToolTip="Editar" Width="16px" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderStyle Width="25px" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="Borrar" runat="server" CommandName="Borrar" 
                                        ImageUrl="/img/Cruz.gif" Width="16px" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderStyle Width="25px" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="VerEncabezado" runat="server" CommandName="VerEncabezado" 
                                        Height="16px" ImageUrl="/img/lupita.gif" ToolTip="Ver Informe" Width="16px" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderStyle Width="25px" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgHistorico" runat="server" CommandName="Historico" 
                                        Height="16px" ImageUrl="/img/reloj.jpg" ToolTip="Ver Historial..." 
                                        Width="16px" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="idEstado" HeaderText="idEstado" Visible="False">
                            </asp:BoundColumn>
                            <asp:TemplateColumn>
                                <HeaderStyle Width="25px" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="realizar" runat="server" CommandName="Realizar" 
                                        ImageUrl="/img/btn-realizar2.gif" ToolTip="Confección del informe" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="idTipoInforme" Visible="False"></asp:BoundColumn>
                            <asp:BoundColumn DataField="GRAVidTipoGravamen" Visible="False">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="leido" Visible="False"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="DescripcionEstado"  HeaderText="DescripcionEstado"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="FechaCondicional"  HeaderText="FechaCondicional"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="RazonSocial1"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="NombreFantasia"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="sucursal"></asp:BoundColumn>
                        </Columns>
                    </asp:DataGrid>
                 </fieldset>

                            <br />
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnBuscar"/>
                        </Triggers>
                        </asp:UpdatePanel>
					</TD>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>
