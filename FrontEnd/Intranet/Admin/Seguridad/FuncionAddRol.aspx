<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Seguridad.Admin.Seguridad.FuncionAddRol" CodeFile="FuncionAddRol.aspx.cs" %>
<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Funciones por Rol</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<TABLE height="668" cellSpacing="0" cellPadding="0" width="263" border="0">
			<TR vAlign="top">
				<TD width="263">
					<form method="post" runat="server">
						<TABLE cellSpacing="0" cellPadding="0" width="656" border="0">
							<TR vAlign="top">
								<TD width="10" height="10"></TD>
								<TD width="646"></TD>
							</TR>
							<TR vAlign="top">
								<TD></TD>
								<TD>
									<TABLE cellSpacing="0" cellPadding="0" width="645" border="0">
										<TR vAlign="top">
											<TD width="10"></TD>
											<TD width="1192"></TD>
										</TR>
										<TR vAlign="top">
											<TD></TD>
											<TD>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="text" vAlign="top" width="5"></td>
														<td class="text">
															<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																<tr>
																	<td class="text">
																		<strong>Asignación de Funciónes al Rol:</strong><br>
																		<asp:Label ID="lblNombreRol" Runat="server" CssClass="title"></asp:Label>
																		<HR><br>
																	</td>
																</tr>
																<tr>
																	<td>
																		<table width="100%" border="0" cellpadding="0" cellspacing="0">
																			<tr>
																				<td class="text" align="left" width="300">
																					Funciones en el Rol:<br>
																					<asp:ListBox id="lstFuncionesRol" runat="server" Width="300px" Rows="10"></asp:ListBox>
																				</td>
																				<td valign="middle" class="text" align="center">
																					<asp:Button ID="btnAddFuncion" Runat="server" Text="<<" ToolTip="Agregar funcion al Rol"></asp:Button>
																					<br>
																					<br>
																					<asp:Button ID="btnRemoveFuncion" Runat="server" Text=">>" ToolTip="Quitar Funcion del Rol"></asp:Button>
																				</td>
																				<td class="text" align="left" width="300">
																					Funciones disponibles:<br>
																					<asp:ListBox id="lstFunciones" runat="server" Width="300px" Rows="10"></asp:ListBox>
																				</td>
																			</tr>
																		</table>
																	</td>
																</tr>
																<tr>
																	<td class="text" height="38" align="right">
																		<asp:Button id="btnAceptar" runat="server" Text="Aceptar"></asp:Button>&nbsp;<asp:Button id="btnCancelar" runat="server" Text="Cancelar" CausesValidation="False"></asp:Button>
																	</td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
	</body>
</HTML>
