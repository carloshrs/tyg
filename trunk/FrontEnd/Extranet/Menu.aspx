<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Menu1" CodeFile="Menu.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Menu</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
			<SCRIPT>
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
			</SCRIPT>
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" ms_2d_layout="TRUE">
				<TR vAlign="top">
					<TD>
						<TABLE id="Table1" width="156">
							<TR>
								<td width="100%">
									<table cellpadding="0" cellspacing="0" border="0" width="100%" heigth="16">
										<tr>
											<td bgcolor="#d4d0c8">&nbsp;<IMG src="/img/ico_user.gif" border="0" width="16" height="16" id="imgUsuario" Runat="server"></td>
											<td class="Titlesmall" bgcolor="#d4d0c8" width="100%" height="23">&nbsp;&nbsp;&nbsp;<asp:Label id="lblNombre" runat="server"></asp:Label></td>
											<td bgcolor="#d4d0c8">&nbsp;<a href="Logoff.aspx" target="_top"><IMG src="/img/cerrar.gif" border="0" width="16" height="16" id="Img3" Runat="server" alt="Cerrar Sesión"></a></td>
										</tr>
									</table>
								</td>
							</TR>
							<TR>
								<TD width="100%">
									<TABLE id="Table4" border="0">
										<TR>
											<TD width="16"><IMG id="Img4" src="/img/folderClosed.gif" Runat="server"></TD>
											<TD><asp:hyperlink id="Hyperlink9" Runat="server" CssClass="linkt" NAME="Hyperlink1" NavigateUrl="javascript:expandTab('informes');">Informes</asp:hyperlink></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
							    <TD valign="top">
									<DIV id="informes" runat="server">
										<TABLE id="Table7" cellSpacing="0" cellPadding="0" align="left">
											<TR>
												<TD align="right" width="20"><IMG src="/img/treeArrow.gif"></TD>
												<TD><asp:HyperLink id="Hyperlink2" Runat="server" CssClass="link" Target="Main" NavigateUrl="Informes/altaInforme.aspx">Solicitud Nuevo Informe</asp:HyperLink></TD>
											</TR>
											<TR>
												<TD align="right" width="20"><IMG src="/img/treeArrow.gif"></TD>
											    <TD><asp:hyperlink id="Hyperlink10" Runat="server" CssClass="link" Target="Main" NavigateUrl="Informes/ListaInformes.aspx">Ver Informes Solicitados</asp:hyperlink></TD>
											</TR>
											<TR>
												<TD align="right" width="20"><IMG src="/img/treeArrow.gif"></TD>
												<TD><asp:HyperLink id="Hyperlink6" Runat="server" CssClass="link" Target="Main" NavigateUrl="Referencias/altaReferencia.aspx">Solicitud de grupo de informes</asp:HyperLink></TD>
											</TR>
									        <TR>
												<TD align="right" width="20"><IMG src="/img/arrowLast.gif"></TD>
												<TD><asp:hyperlink id="Hyperlink15" Runat="server" CssClass="link" Target="Main" NavigateUrl="Referencias/ListaReferencias.aspx">Ver grupos de informes</asp:hyperlink></TD>
											</TR>
										</TABLE>
									</DIV>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
                <TR>
					<TD width="100%">
						<TABLE id="Table2">
							<TR>
								<TD width="16"><IMG id="ImgContrato" src="/img/folderClosed.gif" Runat="server"></TD>
								<td>
									<asp:hyperlink id="ArchivoContrato" Runat="server" CssClass="linkt" NavigateUrl="/Proximamente.aspx?id=1"
										Target="Main" style="color:#4091f5">Archivo de contratos</asp:hyperlink></td>
							</TR>
						</TABLE>
					</TD>
				</TR>
                <TR>
					<TD width="100%">
						<TABLE id="Table3">
							<TR>
								<TD width="16"><IMG id="ImgInquilino" src="/img/folderClosed.gif" Runat="server"></TD>
								<TD>
									<asp:hyperlink id="InquilinoLeal" Runat="server" CssClass="linkt" NavigateUrl="/Proximamente.aspx?id=2"
										Target="Main" style="color:#4091f5">Inquilino Leal</asp:hyperlink></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<!--<TR>
					<TD width="100%">
						<TABLE id="Table4" border="0">
							<TR>
								<TD width="16"><IMG id="Img6" src="/img/Referencia.gif" Runat="server"></TD>
								<TD>
									<asp:hyperlink id="Hyperlink13" Runat="server" CssClass="linkt" NAME="Hyperlink1" NavigateUrl="javascript:expandTab('referencias');"> Referencias</asp:hyperlink></TD>
							</TR>
						</TABLE>
						<DIV id="referencias" runat="server">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" align="left">
								
							</TABLE>
						</DIV>
					</TD>
				</TR>
				
				--CONTRATOS
				<TR>
					<TD width="100%">
						<TABLE id="Table4" border="0">
							<TR>
								<TD width="16"><IMG id="Img5" src="/img/folderClosed.gif" Runat="server"></TD>
								<TD><asp:hyperlink id="Hyperlink11" Runat="server" CssClass="linkt" NAME="Hyperlink1" NavigateUrl="javascript:expandTab('contratos');">Archivo Contratos</asp:hyperlink></TD>
							</TR>
						</TABLE>
						<DIV id="contratos" runat="server">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" align="left">
								<TR>
									<TD align="right" width="20"><IMG src="/img/treeArrow.gif"></TD>
									<TD><asp:HyperLink id="Hyperlink14" Runat="server" NavigateUrl="Contratos/altaContrato.aspx" CssClass="link" Target="Main">Carga de un Nuevo Contrato</asp:HyperLink></TD>
								</TR>
								<TR>
									<TD align="right" width="20"><IMG src="/img/treeArrow.gif"></TD>
									<TD><asp:hyperlink id="Hyperlink1" Runat="server" Target="Main" CssClass="link" NavigateUrl="Contratos/ListaContratos.aspx">Ver Contratos Archivados</asp:hyperlink></TD>
								</TR>
								<TR>
									<TD align="right" width="20"><IMG src="/img/arrowLast.gif"></TD>
									<TD><asp:hyperlink id="Hyperlink12" Runat="server" Target="Main" CssClass="link" NavigateUrl="Contratos/ListaContratos.aspx">Mod. de comportamientos y vigencia de contratos</asp:hyperlink></TD>
								</TR>
							</TABLE>
						</DIV>
					</TD>
				</TR>
				-->
				<TR>
					<TD width="100%">
						<TABLE id="Table6">
							<TR>
								<TD width="16"><IMG id="busquedasSign" src="/img/folderClosed.gif" Runat="server"></TD>
								<TD>
									<asp:hyperlink id="Hyperlink3" Runat="server" CssClass="linkt" NavigateUrl="javascript:expandTab('busquedas');">Administración</asp:hyperlink></TD>
							</TR>
						</TABLE>
						<DIV id="busquedas" runat="server">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" align="left">
								<TR>
									<TD align="right" width="20"><IMG src="/img/treeArrow.gif"></TD>
									<TD>
										<asp:HyperLink id="Hyperlink4" Runat="server" CssClass="link" Target="Main" NavigateUrl="Admin/Clientes/AbmUsuario.aspx"> Datos del Usuario</asp:HyperLink></TD>
								</TR>
								<TR>
									<TD align="right" width="20"><IMG src="/img/arrowLast.gif"></TD>
									<TD>
										<asp:HyperLink id="BusquedaPropiedadAutomotor" Runat="server" NavigateUrl="Admin/Clientes/AbmCliente.aspx" CssClass="link" Target="Main"> Datos de la Empresa</asp:HyperLink></TD>
								</TR>
                                <TR>
									<TD align="right" width="20"><IMG src="/img/treeArrow.gif"></TD>
									<TD>
										<asp:HyperLink id="hylCambioClave" Runat="server" CssClass="link" Target="Main" NavigateUrl="Admin/Clientes/CambioClave.aspx"> Cambio de clave</asp:HyperLink></TD>
								</TR>
							</TABLE>
						</DIV>
					</TD>
				</TR>
                
                <TR>
					<TD width="100%">
						<TABLE id="Table5">
							<TR>
								<TD width="16"><IMG id="Img1" src="/img/folderClosed.gif" Runat="server"></TD>
								<TD>
									<asp:hyperlink id="Contactenos" Runat="server" CssClass="linkt" NavigateUrl="/Contactenos.aspx"
										Target="Main">Contáctenos</asp:hyperlink></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			</TD></TR></TBODY></TABLE>
		</form>
	</body>
</HTML>
