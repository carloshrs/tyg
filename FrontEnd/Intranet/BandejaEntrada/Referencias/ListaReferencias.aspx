<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada.Referencias.ListaReferencias" CodeFile="ListaReferencias.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="menu" Src="../../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListaInformes</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript">
		    function paginadorIrA(pagina) {
		        document.getElementById("hPagina").value = pagina;
		        __doPostBack('hEmpresas', pagina);
		    }
		    function mostrarPaginador() {
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
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<uc1:menu id="Menu1" runat="server"></uc1:menu>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="2%" class="title">&nbsp;</td>
					<td width="98%" class="title"><BR>
						Grupos de informes<BR>
						<HR>
					</td>
					<td width="2%" class="title">&nbsp;</td>
				</tr>
				<tr>
					<td width="2%" class="title">&nbsp;</td>
					<td width="98%">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="text" valign="top" width="5">
								</td>
								<td class="text" height="38">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
										<td align="center">
										<table>
										<tr>
											<td class="text" height="38" align="center">&nbsp;&nbsp;Grupos de informes&nbsp;que contengan :</td>
												<td><asp:textbox id="TxtContengan" runat="server" Width="207px" CssClass="planotext"></asp:textbox></td>
												<td><asp:dropdownlist id="cmbEstados" runat="server" Width="160px"></asp:dropdownlist></td>
												<td><asp:button id="btnBuscar" runat="server" Width="58px" Text="Buscar"></asp:button></td>
												</tr>
										</table>
</td>
										</tr>
										<tr>
											<td><asp:datagrid id="dgridReferencias" runat="server" Width="100%" AutoGenerateColumns="False" GridLines="Vertical"
													BackColor="White" BorderWidth="1px" BorderStyle="Solid" BorderColor="#3657A6" CellPadding="3"
													PageSize="20" Font-Size="8pt">
													<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
													<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
													<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
													<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
													<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="idReferencia" HeaderText="C&#243;digo">
															<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FechaCarga" HeaderText="Fecha"></asp:BoundColumn>
														<asp:BoundColumn DataField="RazonSocial" HeaderText="Cliente">
															<HeaderStyle Width="80px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Descripcion" HeaderText="Descripci&#243;n">
															<HeaderStyle Width="80px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Observaciones" HeaderText="Observaciones">
															<HeaderStyle Width="120px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="NombreEstado" HeaderText="Estado">
															<HeaderStyle Width="15px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Estado"></asp:TemplateColumn>
														<asp:TemplateColumn>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Editar" runat="server" Width="16px" ImageUrl="/img/modificar_general.gif" CommandName="Editar"
																	ToolTip="Editar"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="VerHistorial" runat="server" Width="16px" ToolTip="Ver Historial" CommandName="VerHistorial"
																	ImageUrl="\Img\Reloj.jpg"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="Estado" HeaderText="Estado"></asp:BoundColumn>
														<asp:TemplateColumn>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Down" runat="server" Width="16px" ImageUrl="\Img\Down.gif" CommandName="Down"
																	ToolTip="Bajar Archivo"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="isFile" HeaderText="isFile"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="Path" HeaderText="Path"></asp:BoundColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
										<tr>
											<td><asp:HiddenField ID="hPagina" runat="server" OnValueChanged="hPagina_ValueChanged" Value="1" />
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
										<tr>
											<td align="right"><asp:button id="btnReferencia" runat="server" Width="155px" Text="Nuevo grupo de informes"></asp:button></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
					<td width="2%" class="title">&nbsp;</td>
				</tr>
				
			</TABLE>
		</form>
	</body>
</HTML>
