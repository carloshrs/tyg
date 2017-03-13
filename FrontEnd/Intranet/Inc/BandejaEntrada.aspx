<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Inc.BandejaEntrada" CodeFile="BandejaEntrada.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Menu</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
			<script language="JavaScript">
				function expandTab(div) {
					var el = document.getElementById(div);
					if (!el) return;
					if (el.style.display == "none")
					{
						el.style.display = "block";
						if (document.getElementById(div + "Sign"))
							document.getElementById(div + "Sign").src = "/img/folderOpen.gif";
					}
					else
					{
						el.style.display = "none";
						if (document.getElementById(div + "Sign"))
							document.getElementById(div + "Sign").src = "/img/folderClosed.gif";
					}
				}
				var sURL = unescape(window.location.pathname);
				function doLoad()
				{
					// the timeout value should be the same as in the "refresh" meta-tag
					setTimeout( "refresh()", 600*1000 );
				}

				function refresh()
				{
					window.location.href = sURL;
				}

			</script>
	</HEAD>
	<body onload="doLoad();">
		<form id="Form1" method="post" runat="server">
			<TABLE align="center" cellSpacing="0" width="100%" cellPadding="0" border="0" ms_2d_layout="TRUE">
				<TR>
					<td bgcolor="#d0dfe3" class="Encabezado" width="100%">
						<table cellpadding="0" cellspacing="0" border="1" style="BORDER-COLLAPSE:collapse">
							<tr>
								<td bgcolor="#d4d0c8">
									<table cellpadding="0" cellspacing="0" border="0">
										<tr>
											<td bgcolor="#d4d0c8">
												&nbsp;<IMG src="/Img/outbox.gif" border="0" width="16" height="16"></td>
											<td class="Encabezado" bgcolor="#d4d0c8" width="100%" height="23">
												&nbsp;&nbsp;<a href="/Default.aspx" Target="Main" class="Encabezado">Bandeja de 
													Entrada</a>&nbsp;
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</TR>
				<TR>
					<td valign="top">
                        <asp:Panel ID="pnReferencias" runat="server">
                            <table>
                                <tr>
								    <td width="16"><img ID="Img5" Runat="server" src="/Img/Nuevo.gif" height="16"></td>
								    <td><asp:hyperlink Runat="server" CssClass="linkt" NavigateUrl="/BandejaEntrada/altaInforme.aspx?IdTipo=1"
										    Target="Main" ID="Hyperlink28">Nuevo informe</asp:hyperlink></td>
							    </tr>

							    <tr>
								    <td width="16"><img ID="Img1" Runat="server" src="/Img/Referencia.gif" height="16"></td>
								    <td><asp:hyperlink Runat="server" CssClass="linkt" NavigateUrl="/BandejaEntrada/Referencias/ListaReferencias.aspx"
										    Target="Main" ID="Hyperlink4">Grupos de informes</asp:hyperlink></td>
							    </tr>
						    </table>
                        </asp:Panel>
						<table>
							<tr>
								<td width="150">
									
								</td>
							</tr>
							<TR>
								<TD width="100%">
									<TABLE id="Table4" border="0">
										<TR>
											<TD width="16"><IMG id="informesSign" src="/img/folderClosed.gif" Runat="server"></TD>
											<TD>
												<asp:hyperlink id="Hyperlink2" Runat="server" CssClass="linkt" NAME="Hyperlink1" NavigateUrl="javascript:expandTab('informes');"> Informes</asp:hyperlink></TD>
										</TR>
									</TABLE>
									<DIV id="informes" runat="server">
										<TABLE id="Table7" cellSpacing="0" cellPadding="0" align="left">
											<TBODY>
												<tr>
													<td align="right" width="20"><img src="/img/treeArrow.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="Automotores"> Automotores</asp:HyperLink></td>
												</tr>
												<tr>
													<td align="right" width="20"><img src="/img/treeArrow.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="BusquedaAuto"> Búsq. Automotor</asp:HyperLink></td>
												</tr>
												<tr>
													<td align="right" width="20"><img src="/img/treeArrow.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="Propiedad"> Propiedad</asp:HyperLink></td>
												</tr>
												<tr>
													<td align="right" width="20"><img src="/img/treeArrow.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="PropiedadProvincias"> Propiedad Prov.</asp:HyperLink></td>
												</tr>
												<tr>
													<td align="right" width="20"><img src="/img/treeArrow.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="BusquedaPropiedad"> Búsq. Propiedad</asp:HyperLink></td>
												</tr>
												<tr>
													<td align="right" width="20"><img src="/img/treeArrow.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="Catastral"> Catastral</asp:HyperLink></td>
												</tr>
												<tr>
													<td align="right" width="20"><img src="/img/treeArrow.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="Gravamenes"> Gravámenes</asp:HyperLink></td>
												</tr>
                                                <tr>
													<td align="right" width="20"><img src="/img/treeArrow.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="GravamenesDIR"> Gravámenes DIR</asp:HyperLink></td>
												</tr>
												<tr>
													<td align="right" width="20"><img src="/img/treeArrow.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="Inhibicion"> Inhibición</asp:HyperLink></td>
												</tr>
												<tr>
													<td align="right" width="20"><img src="/img/treeArrow.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="Morosidad"> Morosidad</asp:HyperLink></td>
												</tr>
												<tr>
													<td align="right" width="20"><img src="/img/treeArrow.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="RegPublicoComercio"> Registro</asp:HyperLink></td>
												</tr>
												<tr>
													<td align="right" width="20"><img src="/img/treeArrow.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="Ambientales"> Ambientales</asp:HyperLink></td>
												</tr>
												<tr>
													<td align="right" width="20"><img src="/img/treeArrow.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="AmbientalBancor"> Relevamiento ambiental BANCOR</asp:HyperLink></td>
												</tr>
                                                <tr>
													<td align="right" width="20"><img src="/img/treeArrow.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="InspeccionAmbientalBancor"> Inspección socio ambiental BANCOR</asp:HyperLink></td>
												</tr>
												<tr>
													<td align="right" width="20"><img src="/img/arrowLast.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="contractuales"> Contractuales</asp:HyperLink></td>
												</tr>
                                                <tr>
													<td align="right" width="20"><img src="/img/arrowLast.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="partidas"> Partidas de defunción</asp:HyperLink></td>
												</tr>
											</TBODY>
										</TABLE>
									</DIV>
								</TD>
							</TR>
							<tr>
								<td>
									<table>
										<tr>
											<td width="16"><img ID="verificacionesSign" Runat="server" src="/img/folderClosed.gif"></td>
											<td><asp:hyperlink Runat="server" CssClass="linkt" NavigateUrl="javascript:expandTab('verificaciones');"
													ID="Hyperlink1" NAME="Hyperlink1">Verificaciones</asp:hyperlink></td>
										</tr>
									</table>
									<div id="verificaciones" runat="server">
										<table align="left" cellpadding="0" cellspacing="0">
											<TBODY>
												<tr>
													<td align="right" width="20"><img src="/img/treeArrow.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="DomicilioParticular"> Domicilio Particular</asp:HyperLink></td>
												</tr>
												<tr>
													<td align="right" width="20"><img src="/img/treeArrow.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="Laboral"> Domicilio Laboral</asp:HyperLink></td>
												</tr>
												<tr>
													<td align="right" width="20"><img src="/img/treeArrow.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="DomicilioComercial"> Domicilio Comercial</asp:HyperLink></td>
												</tr>
												<tr>
													<td align="right" width="20"><img src="/img/arrowLast.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="Especial"> Especial</asp:HyperLink></td>
												</tr>
                                                <tr>
													<td align="right" width="20"><img src="/img/arrowLast.gif"></td>
													<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="defuncion"> Defunción</asp:HyperLink></td>
												</tr>
											</TBODY>
										</table>
									</div>
								</td>
							</tr>
							<tr>
								<td width="150">
									<table>
										<tr>
											<td width="16"><img ID="busquedasSign" Runat="server" src="/img/lupita.gif"></td>
											<td><asp:hyperlink Runat="server" CssClass="linkt" NavigateUrl="/BandejaEntrada/Principal.aspx?bsqrapida=1" ID="Hyperlink3"
													Target="_blank">Busqueda Rápida</asp:hyperlink></td>
										</tr>
									</table>
									<div id="busquedas" style="DISPLAY: none;TEXT-ALIGN: center" runat="server">
										<table align="left" cellpadding="0" cellspacing="0">
										</table>
									</div>
								</td>
							</tr>
							<tr>
								<td width="150">
									<table width="150">
										<tr>
											<td width="16"><img ID="contratosSign" Runat="server" src="/img/folderClosed.gif"></td>
											<td><asp:hyperlink Runat="server" CssClass="linkt" NavigateUrl="javascript:expandTab('contratos');"
													ID="Hyperlink5" NAME="Hyperlink5">Archivo Contratos</asp:hyperlink></td>
										</tr>
									</table>
									<div id="contratos" runat="server">
										<table width="150" cellpadding="0" cellspacing="0">
											<tr>
												<td align="right" width="20"><img src="/img/treeArrow.gif"></td>
												<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="Nuevoscontratos" NavigateUrl="/Contratos/altaContrato.aspx"> Nuevos Contratos</asp:HyperLink></td>
											</tr>
											<tr>
												<td align="right" width="20"><img src="/img/treeArrow.gif"></td>
												<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="Hyperlink7" NavigateUrl="/Contratos/ListaContratos.aspx"> Ver Contratos</asp:HyperLink></td>
											</tr>
											<tr>
												<td align="right" width="20"><img src="/img/arrowLast.gif"></td>
												<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="Hyperlink6" NavigateUrl="/Contratos/ListaContratos.aspx"> Mod. de comportamientos y vigencia de contratos</asp:HyperLink></td>
											</tr>
										</table>
									</div>
								</td>
							</tr>
							<tr>
								<td width="150">
									<table width="150">
										<tr>
											<td width="16"><img ID="Img4" Runat="server" src="/img/folderClosed.gif"></td>
											<td><asp:hyperlink Runat="server" CssClass="linkt" NavigateUrl="javascript:expandTab('perfil');"
													ID="Hyperlink10" NAME="Hyperlink5">Perfil</asp:hyperlink></td>
										</tr>
									</table>
									<div id="perfil" runat="server" style="display: none;">
										<table width="150" cellpadding="0" cellspacing="0">
											<tr>
												<td align="right" width="20"><img src="/img/arrowLast.gif"></td>
												<td><asp:HyperLink Runat="server" CssClass="link" Target="Main" ID="HyperLink11" NavigateUrl="/Admin/Clientes/AbmUsuario.aspx"> Info. del Usuario</asp:HyperLink></td>
											</tr>
										</table>
									</div>
								</td>
							</tr>
							<tr>
								<td width="150">
									<table width="150">
										<tr>
											<td width="16"><img ID="Img2" Runat="server" src="/img/folderClosed.gif"></td>
											<td><asp:hyperlink Runat="server" CssClass="linkt" Target="Main" NavigateUrl="/Contactenos/ListaContactos.aspx"
													ID="Consulta">Consultas</asp:hyperlink></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td width="150">
									<table width="150">
										<tr>
											<td width="16"><img ID="Img3" Runat="server" src="/img/ico_world.jpg"></td>
											<td><asp:hyperlink Runat="server" CssClass="linkt" Target="Main" NavigateUrl="gmaps_cba.htm"
													ID="Hyperlink9" NAME="Hyperlink5">Google Maps</asp:hyperlink></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
