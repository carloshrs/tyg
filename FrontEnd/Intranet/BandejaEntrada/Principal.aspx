<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada.Principal" CodeFile="Principal.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="menu" Src="../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
  		<title>Bandeja de Entrada</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
			<script>
			
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
					//Tipos.txtFechaInicio.value="";
					//Tipos.txtFechaFinal.value="";
					masFiltros.style.display = "none";
					ToggleImg(name, 'Arrow.gif', 'Filtro Avanzado');
					BotonBuscar.style.display = "list-item";
				}
			}
			
			function cambioEstado(idTipo, idInforme)
			{
			    window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo='+idTipo+'&idInforme='+idInforme+'&Finalizar=1','','dialogWidth:400px;dialogHeight:250px'); 
			}
			
			
			function paginadorIrA( pagina )
			{
			    document.getElementById("hPagina").value = pagina;
			    __doPostBack('hEmpresas',pagina);
			}
			function mostrarPaginador()
			{
			    //document.getElementById("divPaginador").innerHTML = paginadorCode;
			}
			</script>
			<style type="text/css">
			#pagination-digg-bandeja li{
		        border:0; margin:0; padding:0;
		        font-size:11px;
		        list-style:none;
	        }
	        #pagination-digg-bandeja a{
		        border:solid 1px #C6C6B7;
		        margin-right:2px;
	        }
	        #pagination-digg-bandeja .previous-off,
	        #pagination-digg-bandeja .next-off {
		        border:solid 1px #DEDEDE;
		        color:#888888;
		        display:block;
		        float:left;
		        font-weight:bold;
		        margin-right:2px;
		        padding:3px 4px;
	        }
	        #pagination-digg-bandeja .next a,
	        #pagination-digg-bandeja .previous a {
	         font-weight:bold;
	        }	
	        #pagination-digg-bandeja .active-bandeja{
		        background:#4C4C4C;
		        color:#FFFFFF;
		        font-weight:bold;
		        display:block;
		        float:left;
		        padding:4px 6px;
	        }
	        #pagination-digg-bandeja a:link, 
	        #pagination-digg-bandeja a:visited {
		        color:#4C4C4C;
		        display:block;
		        float:left;
		        padding:3px 6px;
		        text-decoration:none;
	        }
	        #pagination-digg-bandeja a:hover{
		        border:solid 1px #98987C;
	        }
			div{font-family:Arial, Helvetica, sans-serif; font-size:12px;}
            ul{border:0; margin:0; padding:0;}
			</style>
</HEAD>
	<body leftMargin="0" topMargin="0" onload="<% if( !bsqRapida ){ %>javascript:mostrarFiltro(true, '');<%} %> mostrarPaginador();">
		<FORM id="Tipos" method="post" runat="server">
		<% if( !bsqRapida ){ %><uc1:menu id="Menu1" runat="server"></uc1:menu><%} %>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%">Listado de Informes
						<asp:Label id="lblTipo" runat="server" CssClass="title" Font-Size="12pt"></asp:Label>
						<BR>
						<hr noshade style="height:1px; border:0px;">
					</td>
				</tr>
				<tr>
					<TD width="2%">&nbsp;</TD>
					<TD class="text" align="right" width="93%" colSpan="4">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="text" align="left" width="100%">
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<TD class="text" align="left" width="98%" colSpan="4">&nbsp;Solicitudes&nbsp;que 
												contenga:
											</TD>
											<TD class="text" align="right" width="2%"><A onclick="javascript:mostrarFiltro(false, imgFiltro);" href="#"><IMG height="14" alt="Filtro Avanzado" src="/img/Arrow.gif" width="14" border="0" name="imgFiltro"></A></TD>
										</tr>
										<tr>
											<TD class="text" align="left" width="50%">&nbsp;<asp:textbox id="txtContengan" runat="server" Width="458px" CssClass="planotext"></asp:textbox>&nbsp;&nbsp;&nbsp;
											</TD>
											<TD class="text" align="left" width="105">&nbsp;</TD>
											<TD class="text" align="left" width="188"><asp:checkbox id="chkSoloMias" runat="server" Width="120px" Text="&nbsp;Solo mis Solicitudes"></asp:checkbox></TD>
											<TD class="text" align="right" width="28%">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<TD class="text" id="BotonBuscar" align="right" width="100%" colSpan="4"><asp:button id="btnBuscar" runat="server" Width="58px" Text="Buscar" onclick="btnBuscar_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
														</TD>
														<TD class="text" align="left" width="100%" colSpan="4"></TD>
													</tr>
												</TABLE>
											</TD>
											<TD class="text" align="right" width="2%">&nbsp;</TD>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<tr>
								<TD class="text" width="100%">&nbsp;</TD>
							</tr>
							<TR id="masFiltros">
								<TD class="text" align="left" width="100%">
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<TD class="text" align="left" width="25%">&nbsp;Filtro por Clientes:
											</TD>
											<TD class="text" align="left" width="25%">&nbsp;Filtro por Tipo Informe:
											</TD>
											<TD class="text" align="left" width="20%">&nbsp;Filtro por Estados:
											</TD>
											<TD class="text" align="left" width="10%">&nbsp;Fecha Desde:&nbsp;
											</TD>
											<TD class="text" align="left" width="10%">&nbsp;Fecha Hasta:&nbsp;
											</TD>
											<TD class="text" align="left" width="20%">&nbsp;&nbsp;
											</TD>
										</tr>
										<tr>
											<TD class="text" align="left" width="25%" style="height: 35px">&nbsp;<asp:dropdownlist id="cmbClientes" runat="server" Width="216px"></asp:dropdownlist>
											</TD>
											<TD class="text" align="left" width="25%" style="height: 35px"><asp:dropdownlist id="cmbTipoInforme" runat="server" Width="224px"></asp:dropdownlist></TD>
											<TD class="text" align="left" width="20%" style="height: 35px">&nbsp;<asp:dropdownlist id="cmbEstados" runat="server" Width="160px"></asp:dropdownlist>
											</TD>
											<TD class="text" align="left" width="10%" style="height: 35px">&nbsp;<asp:textbox id="txtFechaInicio" runat="server" Width="77px"></asp:textbox>&nbsp;
												<IMG id="imgFechaInicio" style="CURSOR: hand" onclick="popFrame.fPopCalendar(imgFechaInicio, txtFechaInicio, divDateControl);"
													alt="Abrir Calendario" src="/img/fecha.gif">
											</TD>
											<TD class="text" align="left" width="10%" style="height: 35px">&nbsp;&nbsp;<asp:textbox id="txtFechaFinal" runat="server" Width="88px"></asp:textbox>&nbsp;
												<IMG id="imgFechaFinal" style="CURSOR: hand" onclick="popFrame.fPopCalendar(imgFechaFinal, txtFechaFinal, divDateControl);"
													alt="Abrir Calendario" src="/img/fecha.gif">
											</TD>
											<TD class="text" align="right" width="20%" style="height: 35px">&nbsp;
												<asp:button id="btnFiltro" runat="server" Text="Aplicar Filtro" onclick="btnFiltro_Click"></asp:button></TD>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<tr>
								<TD class="text" width="100%">&nbsp;</TD>
							</tr>
							<tr>
								<td width="100%"><asp:datagrid id="dgridEncabezados" runat="server" Width="100%" 
                                        Font-Size="8pt" PageSize="15"
										CellPadding="3" BorderColor="#3657A6" BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="dgridEncabezados_PreRender" 
                                        onselectedindexchanged="dgridEncabezados_SelectedIndexChanged" 
                                        OnPageIndexChanged="dgridEncabezados_PageIndexChanged">
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
                                        
                                        <asp:TemplateColumn HeaderText="Cliente">
                                        <HeaderStyle Width="80px">
                                        </HeaderStyle>
                                        <ItemTemplate>
                                        <asp:Label id="lblEmpresa" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateColumn>
                                        
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
                                        <asp:BoundColumn Visible="False" DataField="NombreEstado" HeaderText="Estado"></asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="Estado">
	                                        <HeaderStyle Width="100px">
	                                        </HeaderStyle>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn>
                                        <HeaderStyle Width="25px">
                                        </HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center">
                                        </ItemStyle>

                                        <ItemTemplate>
                                            <asp:ImageButton id="Editar" runat="server" Width="16px" ToolTip="Editar" CommandName="Editar" ImageUrl="/img/modificar_general.gif" BorderWidth="0"></asp:ImageButton>
                                        </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn>
                                        <HeaderStyle Width="25px">
                                        </HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center">
                                        </ItemStyle>

                                        <ItemTemplate>
                                            <asp:ImageButton id="Borrar" runat="server" Width="16px" CommandName="Borrar" ImageUrl="..\Img\Cruz.gif" BorderWidth="0"></asp:ImageButton>
                                        </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn>
                                        <HeaderStyle Width="25px">
                                        </HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center">
                                        </ItemStyle>

                                        <ItemTemplate>
                                            <asp:ImageButton id="VerEncabezado" runat="server" Width="16px" ImageUrl="..\Img\lupita.gif" CommandName="VerEncabezado" ToolTip="Ver Informe" Height="16px" BorderWidth="0"></asp:ImageButton>
                                        </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn>
                                        <HeaderStyle Width="25px">
                                        </HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center">
                                        </ItemStyle>

                                        <ItemTemplate>
                                            <asp:ImageButton id="imgHistorico" runat="server" Width="16px" ImageUrl="..\Img\reloj.jpg" CommandName="Historico" ToolTip="Ver Historial..." Height="16px" BorderWidth="0"></asp:ImageButton>
                                        </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn Visible="False" DataField="idEstado" HeaderText="idEstado"></asp:BoundColumn>
                                        <asp:TemplateColumn>
                                        <HeaderStyle Width="25px">
                                        </HeaderStyle>

                                        <ItemStyle HorizontalAlign="Center">
                                        </ItemStyle>

                                        <ItemTemplate>
                                            <asp:ImageButton id="realizar" runat="server" ToolTip="Confección del informe" CommandName="Realizar" ImageUrl="/img/btn-realizar2.gif" BorderWidth="0"></asp:ImageButton>
                                        </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn Visible="False" DataField="idTipoInforme"></asp:BoundColumn>
                                        <asp:BoundColumn Visible="False" DataField="GRAVidTipoGravamen"></asp:BoundColumn>
                                        <asp:BoundColumn Visible="False" DataField="leido"></asp:BoundColumn>
                                        <asp:BoundColumn Visible="False" DataField="DescripcionEstado"  HeaderText="DescripcionEstado"></asp:BoundColumn>
                                        <asp:BoundColumn Visible="False" DataField="FechaCondicional"  HeaderText="FechaCondicional"></asp:BoundColumn>
                                        <asp:BoundColumn Visible="False" DataField="RazonSocial1"></asp:BoundColumn>
                                        <asp:BoundColumn Visible="False" DataField="NombreFantasia"></asp:BoundColumn>
                                        <asp:BoundColumn Visible="False" DataField="sucursal"></asp:BoundColumn>
                                        
                                   </Columns>
                                </asp:datagrid>
                                </TD>
							</tr>
							<tr>
							<td style="height: 5px"><asp:HiddenField ID="hPagina" runat="server" OnValueChanged="hPagina_ValueChanged" Value="1" />
                                <asp:HiddenField ID="hTipoBusqueda" runat="server" Value="0" />
                            </td>
							</tr>
							<tr>
							    <td align="center" style="height: 50px">
							    <table>
							        <tr>
							            <td><asp:Literal ID="litPaginador" runat="server" Mode="PassThrough"></asp:Literal></td>
							        </tr>
							    </table>
							            
							    </td>
							</tr>
							<tr>
							<td style="height: 5px"></td>
							</tr>
							
						</TABLE>
                        <asp:Button ID="btnImprimir" runat="server" OnClick="btnImprimir_Click"
                            Text="Generar listado" Visible="False" />
                        <asp:Button ID="btnPropiedadRegistro" runat="server" OnClick="btnPropiedadRegistro_Click"
                            Text="Registro de la Propiedad" Visible="False" />
						<asp:button id="btnInforme" runat="server" Width="155px" Text="Nuevo Informe" onclick="btnInforme_Click"></asp:button></TD>
					<TD width="5%">&nbsp;</TD>
				</tr>
			</TABLE>
		<DIV id="divDateControl" style="Z-INDEX: 102; LEFT: -35px; VISIBILITY: hidden; POSITION: absolute; TOP: -150px"><IFRAME name="popFrame" src="../inc/calendar/calendar.htm" frameBorder="0" width="160" scrolling="no"
				height="160"></IFRAME></DIV>
		</FORM>
		</body>
</HTML>