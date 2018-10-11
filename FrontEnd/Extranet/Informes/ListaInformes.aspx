<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Informes.ListaInformes" CodeFile="ListaInformes.aspx.cs" Culture="Auto" UICulture="Auto"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head id="Head1" runat="server">
		<title>ListaInformes</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">

  <script type="text/javascript" src="/jquery/jquery.min.js"></script>

  <link rel="stylesheet" type="text/css" href="/jquery/lightbox/themes/default/jquery.lightbox.css" />
  <!--[if IE 6]><link rel="stylesheet" type="text/css" href="javascript/lightbox/themes/default/jquery.lightbox.ie6.css" /><![endif]-->
  <script type="text/javascript" src="/jquery/lightbox/jquery.lightbox.js"></script>

    <!-- / fim dos arquivos utilizados pelo jQuery lightBox plugin -->
     <script type="text/javascript">
         
    </script>
		<style type="text/css">
			#pagination-digg-bandeja li{
		        border:0; margin:0; padding:0;
		        font-size:11px;
		        list-style:none;
		        float:left;
	        }
	        #pagination-digg-bandeja a{
		        border:solid 1px #C6C6B7;
		        margin-right:2px;
		        float:left;
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
	         float:left;
	        }
	        .previous-bandeja {
	         font-weight:bold;
	         float:left;
	        }
	        .next-bandeja {
	         font-weight:bold;
	         float:left;
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
			
			function paginadorIrA( pagina )
			{
			    document.getElementById("hPagina").value = pagina;
			    __doPostBack('hEmpresas',pagina);
			}
			function mostrarPaginador()
			{
			    //document.getElementById("divPaginador").innerHTML = paginadorCode;
			}


			function MostrarAviso() {

			    var randomnumber = Math.floor(Math.random() * 2);
			    randomnumber = 1;
			    var imagen = "";
			    var ancho = "";
			    var alto = "";

			    if (randomnumber == 0) {
			        imagen = "/Res/banners/cpcpi.png";
			        document.getElementById("lnkBanner").src = "/Res/banners/cpcpi.png";
			        document.getElementById("lnkBanner").href = "http://www.cpcpi.org.ar/";
			        ancho = "650";
			        alto = "384";
			    }

			    if (randomnumber == 1) {
			        imagen = "/Res/banners/banner-mundoinmobiliario-extra.png";
			        document.getElementById("lnkBanner").src = "/Res/banners/banner-mundoinmobiliario-extra.png";
			        document.getElementById("lnkBanner").href = "http://www.tiempoygestion.com/";
			        ancho = "400";
			        alto = "568";
			    }

			    jQuery(document).ready(function () {

			        jQuery("#lbsingle").show(function (ev) {
			            jQuery.lightbox(imagen, {
			                'width': ancho,
			                'height': alto,
			                'autoresize': false
			            });
			            //ev.preventDefault();
			        });

			    });

			    return false;
			 }

             /*
			$(document).ready(function () {
			    $("#dialog:ui-dialog").dialog("destroy");

			    $("#dialog-alert").dialog({
			        modal: true,
			        autoOpen: false,
			        width: 700,
			        height: 390,
			        buttons: {
			            Cerrar: function () {
			                $(this).dialog("close");
			            }
			        }
			    });
			});
            */
			</script>
	</HEAD>
	<body>
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
    </asp:ScriptManager>

		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="title" width="100%">Informes<BR>
						<HR>
						<BR>
					</td>
				</tr>
				<tr>
					<td width="100%">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="text" vAlign="top" width="5"></td>
								<td class="text" height="38">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="text" align="center" height="38">
                                            <table width="70%" class="text" cellpadding="3" style="margin-bottom:10px">
                                                <tr><td>
                                                <div style="float:left; width:600px">
                                                <div style="float:left; margin:5px;" class="text">
												Busqueda de informes solicitados:<br />
												<asp:textbox id="TxtContengan" runat="server" CssClass="planotext" Width="207px"></asp:textbox></div>
                                                <div style="float:left; margin:5px;"  class="text">
                                                &nbsp;Fecha desde<br />
<asp:textbox id="txtFechaInicio" runat="server" Width="60px"></asp:textbox>
                                                    <cc1:CalendarExtender ID="txtFechaInicio_CalendarExtender" runat="server" 
                                                        TargetControlID="txtFechaInicio">
                                                    </cc1:CalendarExtender></div>
                                                    <div style="float:left; margin:5px;" class="text">Fecha 
                                                hasta<br />
                                                <asp:textbox id="txtFechaFinal" runat="server" Width="60px"></asp:textbox>
                                                <cc1:CalendarExtender ID="txtFechaFinal_CalendarExtender" runat="server" 
                                                    TargetControlID="txtFechaFinal">
                                                </cc1:CalendarExtender>
                                                </div>
                                                <div style="float:left; margin:5px; margin-top:15px;" > <asp:checkbox id="chkSoloMias" runat="server" Width="140px" Text="&nbsp;Solo mis Solicitudes" CssClass="text"></asp:checkbox></div>
                                                </div>
												<div style="float:left; width:500px">
                                                <div style="float:left; margin:5px;">
												<asp:dropdownlist id="cmbTipoInforme" runat="server" Width="205px"></asp:dropdownlist></div>
                                                <div style="float:left; margin:5px;">
												<asp:dropdownlist id="cmbEstados" runat="server" Width="146px"></asp:dropdownlist></div>
												<div style="float:left; margin:5px;"><asp:button id="btnBuscar" runat="server" Width="58px" Text="Buscar" onclick="btnBuscar_Click"></asp:button>
												</div>
                                                </div>
                                                </td></tr></table>
                                                </td>
										</tr>
										<tr>
											<td><asp:datagrid id="dgridEncabezados" runat="server" Width="100%" Font-Size="8pt" PageSize="20"
													CellPadding="3" BorderColor="#3657A6" BorderStyle="Solid" BorderWidth="1px" BackColor="White"
													GridLines="Vertical" AutoGenerateColumns="False" onprerender="dgridEncabezados_PreRender" onselectedindexchanged="dgridEncabezados_SelectedIndexChanged">
													<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
													<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
													<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
													<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
													<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="idEncabezado" HeaderText="C&#243;digo">
															<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="FechaCarga" HeaderText="Fecha"></asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Fecha">
                                                            <HeaderStyle Width="80px"></HeaderStyle>
															<ItemTemplate>
																<asp:Label id="lblFecha" runat="server"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="Descripcion" HeaderText="Tipo Informe">
															<HeaderStyle Width="180px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="DescripcionInf" HeaderText="Descripci&#243;n">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="Comentarios" HeaderText="Observaciones">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="NombreEstadoExtra" HeaderText="Estado">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Estado">
														    <HeaderStyle Width="100px"></HeaderStyle>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="22px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Editar" runat="server" Width="16px" ImageUrl="/img/modificar_general.gif" CommandName="Editar"
																	ToolTip="Editar" BorderWidth="0"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="22px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Cancelar" runat="server" Width="16px" ImageUrl="/Img/Cruz.gif" CommandName="Cancelar"
																	ToolTip="Cancelar Informe" BorderWidth="0"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="Estado"></asp:BoundColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="22px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Ver" runat="server" Width="16px" ImageUrl="/Img/Lupita.gif" CommandName="Ver"
																	ToolTip="Visualizar Informe" BorderWidth="0"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="idTipoInforme"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="GRAVidTipoGravamen"></asp:BoundColumn>
                                                        <asp:BoundColumn Visible="False" DataField="pagado"></asp:BoundColumn>
                                                        <asp:TemplateColumn>
															<HeaderStyle Width="22px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="pdf" runat="server" Width="16px" ImageUrl="/Img/pdf.png" CommandName="Pdf"
																	ToolTip="Descargar PDF" BorderWidth="0"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
                                                        <asp:BoundColumn Visible="False" DataField="pathfilepdf"></asp:BoundColumn>
													</Columns>
													<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
														BackColor="#999999"></PagerStyle>
												</asp:datagrid></td>
										</tr>
										<tr>
											<td>
                                                <asp:HiddenField ID="hPagina" runat="server" OnValueChanged="hPagina_ValueChanged"
                                                    Value="1" /><asp:HiddenField ID="hTipoBusqueda" runat="server" Value="0" />
                                                &nbsp;<table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="center" style="height: 50px">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Literal ID="litPaginador" runat="server" Mode="PassThrough"></asp:Literal></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
										</tr>
										<tr>
											<td align="right"><asp:button id="btnInforme" runat="server" Width="155px" Text="Nuevo Informe" onclick="btnInforme_Click"></asp:button></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</TABLE>
	            <div id="lblAyuda" style="margin-left:0px;padding:5px; line-height:1.2; font-size:12px;"></div>
                <div>
  	                    <a href="/img/shim.gif" target="_blank" id="lnkBanner"><img id="lbsingle" src="/img/shim.gif" width="1"  border="0" alt="http://www.google.com"/></a>
                </div>
           
		</form>
	</body>
</HTML>
