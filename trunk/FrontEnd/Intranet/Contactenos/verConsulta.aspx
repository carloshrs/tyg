<%@ Register TagPrefix="mnu" TagName="menu" Src="../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Contactenos.VerConsulta" CodeFile="verConsulta.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Alta de Cliente</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
			<script src="/Includes/Funciones.js" type="text/javascript"></script>
	    <style type="text/css">
            .style1
            {
                font-family: Arial, Verdana, Helvetica, Sans-Serif;
                font-size: 8pt;
                TEXT-DECORATION: none;
                COLOR: #000000;
                font-weight: bold;
            }
        </style>
	</HEAD>
	<body lefmargin="0" topmargin="0">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<TABLE cellSpacing="0" cellPadding="0" width="600" border="0">
			<TR vAlign="top">
				<TD>
					<form id="Form1" method="post" runat="server">
						<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
							<TR vAlign="top">
								<TD width="10" height="15"></TD>
								<TD ></TD>
							</TR>
                            													<TR>
														<TD class="title" width="60%" colSpan="4">Consulta
															<hr>
															<br>															
														</TD>
													</TR>
							<TR vAlign="top">
								<TD></TD>
								<TD>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td width="30">&nbsp;&nbsp;&nbsp;&nbsp;</td>
											<td width="100%">
												<table cellSpacing="0" cellPadding="3" width="100%" border="0">
                                                    <TR>
														<TD class="text" width="60%" colSpan="4" align="right"><b>Fecha:</b> 
                                                            <asp:Label ID="lblFecha" runat="server" Font-Italic="true"></asp:Label></TD>
													</TR>
													<TR>
														<TD class="text" width="60%" colSpan="4"><b>Nombre:</b> 
                                                            <asp:Label ID="lblNombre" runat="server"></asp:Label></TD>
													</TR>
													
													<TR>
														<TD class="text" width="60%" colSpan="4"><b>Empresa:</b> <asp:Label ID="lblEmpresa" runat="server"></asp:Label></TD>
													</TR>
													
													
													<TR>
														<TD class="text"><b>Telefono:</b> 
                                                            <asp:Label ID="lblTelefono" runat="server"></asp:Label> </TD>
														<TD class="text" colSpan="3"><b>Email:</b> 
                                                            <asp:Label ID="lblEmail" runat="server"></asp:Label> </TD>
													</TR>
													
													
													<TR>
														<TD class="text" width="60%" colSpan="4"><b>Asunto:</b> <asp:Label ID="lblAsunto" runat="server" CssClass="text"></asp:Label></TD>
													</TR>
													
													<TR>
														<TD class="style1" width="60%" colSpan="4">Consulta:</TD>
													</TR>
													<TR>
														<TD class="text" width="100%" colSpan="4">&nbsp;<asp:Label ID="lblConsulta" runat="server"></asp:Label></TD>
													</TR>

													<TR>
														<TD class="text" colSpan="4" height="10"></TD>
													</TR>
													
													<TR>
														<TD class="text" colSpan="4" height="10"><i>leido por </i>
                                                            <asp:Label ID="lblUsuarioIntra" runat="server" Font-Italic="true"></asp:Label></TD>
													</TR>
													<TR>
														<td colSpan="4">
															<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="text" align="right" width="100%">
																		&nbsp;&nbsp;
																		<asp:button id="btnVolver" runat="server" style="CURSOR:hand" Width="56px" Text="Cancelar"
																			ToolTip="Volver" CausesValidation="False" onclick="btnCancelar_Click"></asp:button>&nbsp;&nbsp;
                                                                            <input type="button" value="Imprimir" onclick="window.print();" name="Imprimir" />
																		</TD>
																</TR>
															</table>
														</td>
													</TR>
												</table>
											</td>
										</tr>
									</table>
								</TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
	</body>
</HTML>
