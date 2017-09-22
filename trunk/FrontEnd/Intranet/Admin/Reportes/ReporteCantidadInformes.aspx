<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Reportes.ReCantidadInformes" CodeFile="ReporteCantidadInformes.aspx.cs" %>
<%@ Register assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<HTML>
	<HEAD runat="server">
		<title>Lista de Caja</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0">
		<form method="post" runat="server">
			<asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
		<mnu:menu id="Menu" runat="server"></mnu:menu>
			<table cellSpacing="0" cellPadding="2" width="98%" border="0">
				<tr>
					<td class="text" vAlign="top" width="5"></td>
					<td class="text" height="38">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="title" height="38">&nbsp; <STRONG>REPORTE DE </STRONG>CANTIDAD DE 
                                    INFORMES<HR>
									<BR>
								</td>
							</tr>
                            <tr>
                            <td>
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
                                                
                                               <cc1:CalendarExtender ID="ceTxtFechaInicio" runat="server" TargetControlID="txtFechaInicio" Format="dd/MM/yyyy" ></cc1:CalendarExtender>
                                                &nbsp;&nbsp;
											    <asp:RequiredFieldValidator ID="reqFechaDesde" runat="server" 
                                                    ErrorMessage="Ingrese fecha desde" Text="*" ControlToValidate="txtFechaInicio"></asp:RequiredFieldValidator>
											</TD>
											<TD class="text" align="left" width="10%" style="height: 30px">&nbsp;&nbsp;<asp:textbox id="txtFechaFinal" runat="server" Width="88px"></asp:textbox>
                                                <cc1:CalendarExtender ID="ceTxtFechaFinal" runat="server"  TargetControlID="txtFechaFinal" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                                &nbsp;&nbsp;
											    <asp:RequiredFieldValidator ID="reqFechaHasta" runat="server" 
                                                    ErrorMessage="Ingrese fecha hasta" Text="*" ControlToValidate="txtFechaFinal"></asp:RequiredFieldValidator>
											</TD>
										<td>&nbsp;</td></tr>

										<tr>
											<TD class="text" align="left" colspan="3" style="height: 30px">&nbsp;
                                                &nbsp;<asp:CheckBoxList ID="chkInformes" runat="server" RepeatColumns="3" 
                                                    RepeatDirection="Horizontal" Font-Size="Small">
                                                </asp:CheckBoxList>
                                            </td></tr>

										<tr>
											<TD class="text" align="left" colspan="3" style="height: 30px">&nbsp;</td></tr>

										<tr>
											<TD class="text" align="left" colspan="2" style="height: 30px">En el período de
                                                <asp:DropDownList ID="cmbCantidad" runat="server" Width="38px">
                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                <asp:ListItem Value="5">5</asp:ListItem>
                                                </asp:DropDownList>
                                            
                                             &nbsp;
                                                <asp:DropDownList ID="cmbPeriodo" runat="server"  Width="63px">
                                                <asp:ListItem Value="1">Meses</asp:ListItem>
                                                <asp:ListItem Value="2">Años</asp:ListItem>
                                                
                                                </asp:DropDownList>
                                            &nbsp;anteriores en estado <asp:DropDownList ID="cmbEstado" runat="server"  Width="120px">
                                                <asp:ListItem Value="1">En espera</asp:ListItem>
                                                <asp:ListItem Value="2">En proceso</asp:ListItem>
                                                <asp:ListItem Value="3" Selected>Finalizados</asp:ListItem>
                                                <asp:ListItem Value="4">Cancelados</asp:ListItem>
                                                
                                                </asp:DropDownList>
                                            </TD>
										<td><asp:Button ID="btnBuscar" runat="server" Text="Buscar" onclick="btnBuscar_Click" /></td></tr>

									</TABLE>
                            
                            </td>
                            <tr><td>&nbsp;<br /></td></tr>
                            </tr>
							<tr style="margin-top:30px;">
								<td>
                                <asp:Panel runat="server" ID="pnPanel1">
                                <asp:Label runat="server" ID="lblCantidadInformes1" Font-Bold="true" Font-Size="16px"></asp:Label>
									<asp:datagrid id="dgCantidadInformes1" runat="server" Font-Size="8pt" 
                                        PageSize="20" CellPadding="3" BorderColor="#3657A6"
										BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False"
										Width="40%" >
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="idTipoInforme">
												<HeaderStyle HorizontalAlign="Left" Width="100px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                
											</asp:BoundColumn>
                                         

											<asp:BoundColumn DataField="TipoInforme" HeaderText="Tipo de informe">
												<ItemStyle HorizontalAlign="Left" Width="80%"></ItemStyle>
											</asp:BoundColumn>

                                            <asp:BoundColumn DataField="Cantidad" HeaderText="Cantidad">
												<ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
											</asp:BoundColumn>
                                            
                                            
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999"></PagerStyle>
									</asp:datagrid>

                                    <div style="text-align:right; margin-top:10px; font-weight:bold; width:60%"><asp:Label ID="lblTotal1" runat="server" Font-Bold="true"></asp:Label>
                                    
                                    </asp:Panel>
                                    <br /><br /><br />
                                    <asp:Panel runat="server" ID="pnPanel2" Visible="false">
                                <asp:Label runat="server" ID="lblCantidadInformes2" Font-Bold="true" Font-Size="16px"></asp:Label>
									<asp:datagrid id="dgCantidadInformes2" runat="server" Font-Size="8pt" 
                                        PageSize="20" CellPadding="3" BorderColor="#3657A6"
										BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False"
										Width="40%" >
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="idTipoInforme">
												<HeaderStyle HorizontalAlign="Left" Width="100px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                
											</asp:BoundColumn>
                                         

											<asp:BoundColumn DataField="TipoInforme" HeaderText="Tipo de informe">
												<ItemStyle HorizontalAlign="Left" Width="80%"></ItemStyle>
											</asp:BoundColumn>

                                            <asp:BoundColumn DataField="Cantidad" HeaderText="Cantidad">
												<ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
											</asp:BoundColumn>
                                            
                                            
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999"></PagerStyle>
									</asp:datagrid>

                                    <div style="text-align:right; margin-top:10px; font-weight:bold; width:60%"><asp:Label ID="lblTotal2" runat="server" Font-Bold="true"></asp:Label>
                                    </div>
                                    </asp:Panel>
                                    <br /><br /><br />
                                    <asp:Panel runat="server" ID="pnPanel3" Visible="false">
                                <asp:Label runat="server" ID="lblCantidadInformes3" Font-Bold="true" Font-Size="16px"></asp:Label>
									<asp:datagrid id="dgCantidadInformes3" runat="server" Font-Size="8pt" 
                                        PageSize="20" CellPadding="3" BorderColor="#3657A6"
										BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False"
										Width="40%" >
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="idTipoInforme">
												<HeaderStyle HorizontalAlign="Left" Width="100px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                
											</asp:BoundColumn>
                                         

											<asp:BoundColumn DataField="TipoInforme" HeaderText="Tipo de informe">
												<ItemStyle HorizontalAlign="Left" Width="80%"></ItemStyle>
											</asp:BoundColumn>

                                            <asp:BoundColumn DataField="Cantidad" HeaderText="Cantidad">
												<ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
											</asp:BoundColumn>
                                            
                                            
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999"></PagerStyle>
									</asp:datagrid>

                                    <div style="text-align:right; margin-top:10px; font-weight:bold; width:60%"><asp:Label ID="lblTotal3" runat="server" Font-Bold="true"></asp:Label>
                                    </div>
                                    </asp:Panel>
                                    <br /><br /><br />
                                    <asp:Panel runat="server" ID="pnPanel4" Visible="false">
                                <asp:Label runat="server" ID="lblCantidadInformes4" Font-Bold="true" Font-Size="16px"></asp:Label>
									<asp:datagrid id="dgCantidadInformes4" runat="server" Font-Size="8pt" 
                                        PageSize="20" CellPadding="3" BorderColor="#3657A6"
										BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False"
										Width="40%" >
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="idTipoInforme">
												<HeaderStyle HorizontalAlign="Left" Width="100px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                
											</asp:BoundColumn>
                                         

											<asp:BoundColumn DataField="TipoInforme" HeaderText="Tipo de informe">
												<ItemStyle HorizontalAlign="Left" Width="80%"></ItemStyle>
											</asp:BoundColumn>

                                            <asp:BoundColumn DataField="Cantidad" HeaderText="Cantidad">
												<ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
											</asp:BoundColumn>
                                            
                                            
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999"></PagerStyle>
									</asp:datagrid>

                                    <div style="text-align:right; margin-top:10px; font-weight:bold; width:60%"><asp:Label ID="lblTotal4" runat="server" Font-Bold="true"></asp:Label>
                                    
                                    </asp:Panel>
                                    <br /><br /><br />

                                    <asp:Panel runat="server" ID="pnPanel5" Visible="false">
                                <asp:Label runat="server" ID="lblCantidadInformes5" Font-Bold="true" Font-Size="16px"></asp:Label>
									<asp:datagrid id="dgCantidadInformes5" runat="server" Font-Size="8pt" 
                                        PageSize="20" CellPadding="3" BorderColor="#3657A6"
										BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False"
										Width="40%" >
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="idTipoInforme">
												<HeaderStyle HorizontalAlign="Left" Width="100px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                
											</asp:BoundColumn>
                                         

											<asp:BoundColumn DataField="TipoInforme" HeaderText="Tipo de informe">
												<ItemStyle HorizontalAlign="Left" Width="80%"></ItemStyle>
											</asp:BoundColumn>

                                            <asp:BoundColumn DataField="Cantidad" HeaderText="Cantidad">
												<ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
											</asp:BoundColumn>
                                            
                                            
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999"></PagerStyle>
									</asp:datagrid>

                                    <div style="text-align:right; margin-top:10px; font-weight:bold; width:60%"><asp:Label ID="lblTotal5" runat="server" Font-Bold="true"></asp:Label>
                                    
                                    </asp:Panel>
								</td>
							</tr>
							<tr>
								<td class="text" height="38" align="right">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                        ShowMessageBox="True" ShowSummary="False" />
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
