<%@ Register TagPrefix="uc1" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Page Language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas.CuentaCorrienteCliente" Trace="False" CodeFile="ListaCuentaCorrienteCliente.aspx.cs" Culture="Auto" UICulture="Auto" %>
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
	
	    .style1
        {
            text-align: left;
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
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
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
					<table class="text" width="700px">
                    <tr><td>
                        <table cellSpacing="0" cellPadding="0" width="100%" border="0" >
                        <tr><td align="center" style="background-color:#EEE; font-size:22px;"><b>ESTADO DE CUENTA DE CLIENTE</b></td></tr>
										<tr>
											<TD class="text" align="left" width="100%">
                                                <br />
                                                <asp:Label ID="lblCliente" runat="server" Text="" Font-Bold="true" Font-Size="16px"></asp:Label>
											</TD></tr>
                                            <tr>
											<TD class="text" align="left" width="100%" style="font-size:16px;">
                                                <br />
                                                Saldo <asp:Label runat="server" ID="lblPendienteFavor" Text="pendiente"></asp:Label>&nbsp;anterior
                                                :&nbsp;<asp:Label ID="lblSaldoAnterior" runat="server" Text="" Font-Bold="true" Font-Size="16px"></asp:Label>
											    <br />
                                                Informes pendientes de cobro:&nbsp;<asp:Label ID="lblSaldoPendienteCobro" runat="server" Text="" 
                                                    Font-Bold="true" Font-Size="16px"></asp:Label>
											    <br />
                                                Total: <asp:Label ID="lblTotal" runat="server" Text="" 
                                                    Font-Bold="true" Font-Size="20px"></asp:Label></TD>
                                            <td></td>
										</tr>
										
									</TABLE>
                        
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                             
                            </td></tr>
						<tr><td>
                       
					    &nbsp;
                            <asp:HiddenField ID="hIdCliente" runat="server" />
                             
                            </td></tr>
                        </table>
					   
                        <div class="style1">
					   
                        &nbsp;&nbsp;<br />
                            
                        <br />
                        </div>

                        <table class="text" width="75%">
                        <tr><td colspan="4"><div style="padding:10px; background-color:#eee;"><strong>ULTIMOS MOVIMIENTOS</strong></div></td></tr>
						<tr><td>
                        <table cellSpacing="0" cellPadding="0" width="50%" border="0">
                        
										<tr>
											<TD class="text" align="left" width="30%">&nbsp;Fecha Desde:&nbsp;
											</TD>
											<TD class="text" align="left" width="30%">&nbsp;Fecha Hasta:&nbsp;
											</TD>
                                            <td></td>
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
										<td><asp:Button ID="btnBuscar" runat="server" Text="Buscar rango" onclick="btnBuscar_Click" /></td></tr>
									</TABLE>
                        
                         
					    &nbsp;
                                                         
                            </td></tr>
                        </table>
                        <asp:UpdatePanel ID="upListadoInformes" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                <fieldset style="border:0px">
                    <asp:DataGrid ID="dgridCCCliente" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#3657A6" BorderStyle="Solid" BorderWidth="1px" 
                        CellPadding="3" Font-Size="8pt" GridLines="Vertical" 
                        OnPageIndexChanged="dgridCCCliente_PageIndexChanged" 
                        onprerender="dgridCCCliente_PreRender" 
                        onselectedindexchanged="dgridCCCliente_SelectedIndexChanged" PageSize="15" 
                        Width="75%" onitemcommand="dgridCCCliente_ItemCommand">
                        <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <AlternatingItemStyle BackColor="#FBFBFB" />
                        <ItemStyle BackColor="#F3F3F3" Font-Names="Arial" Font-Size="8pt" 
                            ForeColor="Black" />
                        <HeaderStyle BackColor="#DFE7F4" Font-Bold="True" Font-Names="Arial" 
                            ForeColor="#3756A6" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <Columns>
                            <asp:BoundColumn DataField="idCuentaCliente" HeaderText="Código" Visible="false">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="FechaIngreso" HeaderText="Fecha" Visible="False">
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Fecha">
                                <HeaderStyle Width="50px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="concepto" HeaderText="Concepto">
                                <ItemStyle HorizontalAlign="Left" Width="70%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Monto" HeaderText="Monto" Visible="false">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="entradasalida" HeaderText="entradasalida" Visible="false">
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Débito">
                                <HeaderStyle Width="50px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDebe" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Crédito">
                                <HeaderStyle Width="50px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblHaber" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>

                            <asp:BoundColumn DataField="Saldo" HeaderText="Saldo">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            
                            <asp:TemplateColumn>
                                <HeaderStyle Width="25px" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="VerEncabezado" runat="server" CommandName="VerEncabezado" 
                                        Height="16px" ImageUrl="/img/lupita.gif" ToolTip="Ver Informe" Width="16px" />
                                </ItemTemplate>
                            </asp:TemplateColumn>

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
                <TR>
					<td colspan="4">
						<table cellSpacing="2" cellPadding="5" width="100%" border="0">
							<TR>
								<TD class="text" align="right" width="100%">
									&nbsp;&nbsp;
                                    <asp:button id="btnAceptar" runat="server" Text="Nuevo concepto" onclick="btnAceptar_Click"></asp:button>&nbsp;&nbsp;
								</TD>
							</TR>
						</table>
					</td>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>
