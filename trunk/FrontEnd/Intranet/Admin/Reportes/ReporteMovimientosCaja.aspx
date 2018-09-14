<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Reportes.ReMovimientosCuentas" CodeFile="ReporteMovimientosCaja.aspx.cs" Culture="Auto" UICulture="Auto" %>
<%@ Register assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<HTML>
	<HEAD runat="server">
		<title>Lista de Caja</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	    <style type="text/css">
            .style1
            {
                font-family: Arial, Verdana, Helvetica, Sans-Serif;
                font-size: 8pt;
                TEXT-DECORATION: none;
                COLOR: #000000;
                width: 30%;
            }
            .style2
            {
                font-family: Arial, Verdana, Helvetica, Sans-Serif;
                font-size: 8pt;
                TEXT-DECORATION: none;
                COLOR: #000000;
                height: 30px;
            }
        </style>
	</HEAD>
	<body leftmargin="0" topmargin="0">
		<form method="post" runat="server">
			<asp:ScriptManager ID="ScriptManager1" runat="server" 
                EnableScriptGlobalization="True">
            </asp:ScriptManager>
		<mnu:menu id="Menu" runat="server"></mnu:menu>
			<table cellSpacing="0" cellPadding="2" width="98%" border="0">
				<tr>
					<td class="text" vAlign="top" width="5"></td>
					<td class="text" height="38">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="title" height="38">&nbsp; <STRONG>REPORTE DE MOVIMIENTOS EN CAJA</STRONG>
									<HR>
									<BR>
								</td>
							</tr>
                            <tr>
                            <td>
                                <table cellSpacing="0" cellPadding="0" width="50%" border="0">
                        
										<tr>
											<TD class="style1" align="left">&nbsp;Fecha Desde:&nbsp;
											</TD>
											<TD class="text" align="left" width="30%">&nbsp;Fecha Hasta:&nbsp;
											</TD>
                                            <td></td>
										</tr>
										<tr>
											<TD class="style2" align="left">&nbsp;<asp:textbox id="txtFechaInicio" runat="server" Width="77px" AutoComplete="false"></asp:textbox>
                                                
                                               <cc1:CalendarExtender ID="ceTxtFechaInicio" runat="server" TargetControlID="txtFechaInicio" Format="dd/MM/yyyy" ></cc1:CalendarExtender>
                                                &nbsp;&nbsp;
											</TD>
											<TD class="text" align="left" width="10%" style="height: 30px">&nbsp;&nbsp;<asp:textbox id="txtFechaFinal" runat="server" Width="88px" AutoComplete="false"></asp:textbox>
                                                <cc1:CalendarExtender ID="ceTxtFechaFinal" runat="server"  TargetControlID="txtFechaFinal" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                                &nbsp;&nbsp;
											</TD>
										<td>&nbsp;</td></tr>

										<tr>
											
											<TD class="style2" align="left">
                                                <asp:RadioButton ID="raSalida" runat="server" Text="Salida" GroupName="raEntradaSalida" Checked="true" AutoPostBack="true" />
                                                <asp:RadioButton ID="raEntrada" runat="server" Text="Entrada" GroupName="raEntradaSalida" AutoPostBack="true" />
                                            </TD>
                                            <TD class="text" align="left" width="10%" style="height: 30px">
                                                <br />
                                            </TD>
										<td>&nbsp;</td></tr>

										<tr>
											
											<TD class="style2" align="left">
                                                <asp:RadioButton ID="rbInformes" runat="server" AutoPostBack="True" 
                                                    Checked="True" GroupName="conceptos" 
                                                    oncheckedchanged="rbInformes_CheckedChanged" onprerender="rbInformes_PreRender" 
                                                    Text="Todos los informes" />
                                            </TD>
                                            <TD class="text" align="left" width="10%" style="height: 30px">
                                                <asp:RadioButton ID="rbConceptos" runat="server" AutoPostBack="True" 
                                                    GroupName="conceptos" oncheckedchanged="rbConceptos_CheckedChanged" 
                                                    Text="Otros conceptos" />
                                                :<br />
                                                <br />
                                                <asp:DropDownList ID="cmbConcepto" runat="server" 
                                                    onselectedindexchanged="cmbConcepto_SelectedIndexChanged">
                                            </asp:DropDownList></TD>
										<td><asp:Button ID="btnBuscar" runat="server" Text="Buscar" onclick="btnBuscar_Click" /></td></tr>

									</TABLE>
                            
                            </td>
                            <tr><td>&nbsp;<br /></td></tr>
                            </tr>
							<tr style="margin-top:30px;">
								<td>
									<asp:datagrid id="dgCajaDiariaDetalle" runat="server" Font-Size="8pt" 
                                        PageSize="20" CellPadding="3" BorderColor="#3657A6"
										BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False"
										Width="90%" onprerender="dgCajaDiariaDetalle_PreRender1">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="idCajaDetalle">
												<HeaderStyle HorizontalAlign="Left" Width="100px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                
											</asp:BoundColumn>
                                            <asp:BoundColumn DataField="fecha" HeaderText="Fecha">
												<ItemStyle HorizontalAlign="Left"  Width="100px"></ItemStyle>
											</asp:BoundColumn>

                                            <asp:BoundColumn DataField="entradasalida" HeaderText="Ingreso / Egreso" Visible="false">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
                                            <asp:TemplateColumn>
                                            <HeaderStyle Width="100px"></HeaderStyle>
												<ItemTemplate>
													<asp:Label id="lblEntrada" runat="server"></asp:Label>
												</ItemTemplate>
                                            </asp:TemplateColumn>

											<asp:BoundColumn DataField="concepto" HeaderText="Concepto">
												<ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
											</asp:BoundColumn>
                                            <asp:BoundColumn DataField="formapago" HeaderText="Forma de pago" Visible="false">
												<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
											</asp:BoundColumn>
                                            <asp:BoundColumn DataField="montoTotal" HeaderText="Monto">
												<ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
											</asp:BoundColumn>
                                            
                                            
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999"></PagerStyle>
									</asp:datagrid>

                                    <div style="text-align:right; margin-top:10px; font-weight:bold; width:90%">SUBTOTAL: <asp:Label ID="lblTotal" runat="server" Font-Bold="true"></asp:Label></div>
								</td>
							</tr>
							<tr>
								<td class="text" height="38" align="right">
                                <asp:HiddenField ID="hdIdCaja" Value="" runat="server" />
									<asp:Button id="btnVolver" runat="server" Text="Volver" OnClientClick="javascript:history.back();"></asp:Button> 
                                    
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
