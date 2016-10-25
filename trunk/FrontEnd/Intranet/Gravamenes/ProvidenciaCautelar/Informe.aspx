<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Gravamenes.ProvidenciaCautelar.Informe" CodeFile="Informe.aspx.cs" %>
<%@ Register TagPrefix="mnu" TagName="menu" Src="/Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Alta de Informe</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body leftmargin="0" topmargin="0">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<table cellpadding="0" cellspacing="0" border="0">
			<tr>
				<td width="10">&nbsp;</td>
				<td>
					<br>
					<form id="Form1" method="post" runat="server">
						<TABLE cellSpacing="0" cellPadding="0" width="640" border="0">
							<tr>
								<td class="title" width="100%">Informe de Gravámenes - Providencia Cautelar</td>
							</tr>
							<tr>
								<td width="100%">
									<table cellSpacing="0" cellPadding="0" width="580" border="0">
										<TR>
											<TD class="text" width="260">&nbsp;</TD>
										</TR>
										<TR>
											<td width="536" colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="576" border="0">
													<TR>
														<TD class="text" width="50%">
															<TABLE cellSpacing="0" cellPadding="0" width="624" border="0">
																<TR>
																	<TD width="536" colSpan="3">
																		<TABLE cellSpacing="0" cellPadding="0" width="640" border="0">
																			<TR>
																				<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;Datos 
																					Encabezado</TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD class="text" colSpan="3"><img src="/img/shim.gif" height="10" width="1"></TD>
																</TR>
																<TR>
																	<TD class="text" width="33%">Folio&nbsp;
																		<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese el folio" ControlToValidate="txtFolio">*</asp:RequiredFieldValidator></TD>
																	<TD class="text" width="33%">Tomo&nbsp;
																		<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese el tomo" ControlToValidate="txtTomo">*</asp:RequiredFieldValidator></TD>
																	<TD class="text" width="33%">Año&nbsp;
																		<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese el año" ControlToValidate="txtAno">*</asp:RequiredFieldValidator></TD>
																</TR>
																<TR>
																	<TD class="text" width="33%"><asp:textbox id="txtFolio" runat="server" Width="180px"></asp:textbox></TD>
																	<TD class="text" width="33%"><asp:textbox id="txtTomo" runat="server" Width="180px"></asp:textbox></TD>
																	<TD class="text" width="33%"><asp:textbox id="txtAno" runat="server" Width="180px"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="text" width="50%" colSpan="3">&nbsp;</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</table>
											</td>
										</TR>
										<TR>
											<TD colSpan="4">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; 
															Gestión sobre la verificación</TD>
													</TR>
												</TABLE>
												&nbsp;
											</TD>
										</TR>
										<TR>
											<td class="text" width="535" colSpan="4">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
												</TABLE>
												<asp:textbox id="txtObservaciones" runat="server" Width="628px" CssClass="Plano" Rows="10" TextMode="MultiLine"></asp:textbox>
											</td>
										</TR>
										<TR>
											<td width="640" colSpan="4">
												<hr SIZE="2">
											</td>
										</TR>
										<TR>
											<td width="536" colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="624" border="0" height="24">
													<TR>
														<TD class="text" align="right">
															<asp:button id="Aceptar" runat="server" Width="70px" Text="Aceptar" onclick="Aceptar_Click"></asp:button>&nbsp;&nbsp;
															<asp:button id="AceptarFinalizar" runat="server" Width="96px" Text="Aceptar y Finalizar" onclick="AceptarFinalizar_Click"></asp:button>&nbsp;&nbsp;
															<asp:button id="Cancelar" runat="server" CausesValidation="False" Width="60px" Text="  Cancelar  " onclick="Cancelar_Click"></asp:button></TD>
													</TR>
												</table>
											</td>
										</TR>
									</table>
<asp:ValidationSummary id=VSEmbargo runat="server" CssClass="text" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
								</td>
							</tr>
						</TABLE>
						<input id="idInforme" type="hidden" name="idInforme" runat="server"> <input id="idReferencia" type="hidden" name="idReferencia" runat="server">
						<INPUT id="idTipoProp" type="hidden" name="idTipoProp" runat="server">
					</form>
				</td>
			</tr>
		</table>
	</body>
</HTML>
