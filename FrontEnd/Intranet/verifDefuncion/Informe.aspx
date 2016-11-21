<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.defuncion.Informe" CodeFile="Informe.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="mnu" TagName="menu" Src="../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <head id="Head1" runat="server">
		<title>Alta de Informe</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
  </head>
	<body leftmargin="0" topmargin="0">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<table cellpadding="0" cellspacing="0" border="0">
			<tr>
				<td width="10">&nbsp;</td>
				<td>
					<br>
					<form id="Form1" method="post" runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
						<TABLE cellSpacing="0" cellPadding="0" width="640" border="0">
							<tr>
								<td class="title" width="100%">Informe de Partida de Defunción</td>
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
																				<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;Datos personales</TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD class="text" colSpan="3"><img src="/img/shim.gif" height="10" width="1"></TD>
																</TR>
																<TR>
																	<TD class="text" width="50%">Nombre&nbsp;
																		<asp:RequiredFieldValidator id="rqNombre" runat="server" ErrorMessage="Ingrese el nombre" ControlToValidate="txtNombre">*</asp:RequiredFieldValidator></TD>
																	<TD class="text" width="50%">Apellido&nbsp;
																		<asp:RequiredFieldValidator id="rqApellido" runat="server" ErrorMessage="Ingrese el apellido" ControlToValidate="txtApellido">*</asp:RequiredFieldValidator></TD>
																</TR>
																<TR>
																	<TD class="text" width="50%"><asp:textbox id="txtNombre" runat="server" Width="180px"></asp:textbox></TD>
																	<TD class="text" width="50%"><asp:textbox id="txtApellido" runat="server" Width="180px"></asp:textbox></TD>
																</TR>
                                                                <TR>
																	<TD class="text" width="50%">DNI&nbsp;
																		<asp:RequiredFieldValidator id="rqDNI" runat="server" ErrorMessage="Ingrese el DNI" ControlToValidate="txtDNI">*</asp:RequiredFieldValidator></TD>
																	<TD class="text" width="50%">Sexo&nbsp;
																		<asp:RequiredFieldValidator id="rqSexo" runat="server" ErrorMessage="Seleccione el sexo" ControlToValidate="cmbSexo">*</asp:RequiredFieldValidator></TD>
																</TR>
																<TR>
																	<TD class="text" width="50%"><asp:textbox id="txtDNI" runat="server" Width="180px"></asp:textbox></TD>
																	<TD class="text" width="50%">
                                                                    <asp:dropdownlist id="cmbSexo" runat="server" Width="161px">
                                                                        <asp:ListItem Value="0" Selected="True">Seleccione sexo</asp:ListItem>
						                                                <asp:ListItem Value="1">Masculino</asp:ListItem>
						                                                <asp:ListItem Value="2">Femenino</asp:ListItem>
					                                                </asp:dropdownlist>
                                                                    </TD>
																</TR>
                                                                <TR>
																	<TD class="text" width="50%">CUIT&nbsp;
																		<asp:RequiredFieldValidator id="rqCUIT" runat="server" ErrorMessage="Ingrese el CUIT" ControlToValidate="txtDNI">*</asp:RequiredFieldValidator></TD>
																	<TD class="text" width="50%">
																		</TD>
																</TR>
																<TR>
																	<TD class="text" width="50%"><asp:textbox id="txtCUIT" runat="server" Width="180px"></asp:textbox></TD>
																	<TD class="text" width="50%">
                                                                    </TD>
																</TR>
																<TR>
																	<TD class="text" width="50%" colSpan="3">&nbsp;</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
                                                    <TR>
														<TD class="text" width="50%">
															<TABLE cellSpacing="0" cellPadding="0" width="624" border="0">
																<TR>
																	<TD width="536" colSpan="3">
																		<TABLE cellSpacing="0" cellPadding="0" width="640" border="0">
																			<TR>
																				<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;Resultados</TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD class="text" colSpan="3"><img src="/img/shim.gif" height="10" width="1"></TD>
																</TR>
																<TR>
																	<TD class="text" width="50%">Fallecida/o&nbsp;<asp:RequiredFieldValidator id="rqFallecido" runat="server" ErrorMessage="Seleccione la opción" ControlToValidate="rbFallecido">*</asp:RequiredFieldValidator>
																		<asp:RadioButtonList ID="rbFallecido" runat="server" 
                                                                            RepeatDirection="Horizontal" class="text" AutoPostBack="True">
                                                                            <asp:ListItem Value="1">&#160;Si</asp:ListItem>
                                                                            <asp:ListItem Value="0">&#160;No</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                        </TD>
																	<TD class="text" width="50%">&nbsp;</TD>
																</TR>
																<TR>
																	<TD class="text" width="100%" colspan="2">
                                                                    <asp:Panel CssClass="text" runat="server" ID="pnlDetalle">
                                                                        <table width="100%">
                                                                            <TR>
																	            <TD class="text" width="50%">Fecha fallecimiento&nbsp;
																		            <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese el DNI" ControlToValidate="txtDNI">*</asp:RequiredFieldValidator></TD>
																	            <TD class="text" width="50%">Acta&nbsp;
																		            <asp:RequiredFieldValidator id="rqActa" runat="server" ErrorMessage="Ingrese el acta" ControlToValidate="txtActa">*</asp:RequiredFieldValidator></TD>
																            </TR>
																            <TR>
																	            <TD class="text" width="50%"><asp:textbox id="txtFechaFallece" runat="server" Width="95px"></asp:textbox><cc1:CalendarExtender ID="clFechaFallece" runat="server" TargetControlID="txtFechaFallece"></cc1:CalendarExtender>&nbsp;</TD>
																	            <TD class="text" width="50%">
                                                                                    <asp:textbox id="txtActa" runat="server" Width="180px"></asp:textbox>
                                                                                </TD>
																            </TR>
                                                                            <TR>
																	            <TD class="text" width="50%">Tomo&nbsp;
																		            <asp:RequiredFieldValidator id="rqTomo" runat="server" ErrorMessage="Ingrese el tomo" ControlToValidate="txtTomo">*</asp:RequiredFieldValidator></TD>
																	            <TD class="text" width="50%">Folio&nbsp;
																		            <asp:RequiredFieldValidator id="rqFolio" runat="server" ErrorMessage="Ingrese el folio" ControlToValidate="txtFolio">*</asp:RequiredFieldValidator></TD>
																            </TR>
																            <TR>
																	            <TD class="text" width="50%"><asp:textbox id="txtTomo" runat="server" Width="180px"></asp:textbox>&nbsp;</TD>
																	            <TD class="text" width="50%">
                                                                                    <asp:textbox id="txtFolio" runat="server" Width="180px"></asp:textbox>
                                                                                </TD>
																            </TR>
                                                                            <TR>
																	            <TD class="text" width="50%">Lugar de fallecimiento&nbsp;
																		            <asp:RequiredFieldValidator id="rqLugar" runat="server" ErrorMessage="Ingrese el lugar de fallecimiento" ControlToValidate="txtLugar">*</asp:RequiredFieldValidator></TD>
																	            
																            </TR>
																            <TR>
																	            <TD class="text" width="50%"><asp:textbox id="txtLugar" runat="server" Width="180px"></asp:textbox>&nbsp;</TD>
																	            
																            </TR>
                                                                        </table>
                                                                        </asp:Panel>
                                                                        </TD>
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
                                                            Observaciones</TD>
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
											<td width="100%" colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="624" border="0" height="24">
													<TR>
														<TD class="text" align="right">
															<asp:button id="Aceptar" runat="server" Width="70px" Text="Aceptar" onclick="Aceptar_Click"></asp:button>&nbsp;&nbsp;
															<asp:button id="AceptarFinalizar" runat="server" Width="107px" Text="Aceptar y Finalizar" onclick="AceptarFinalizar_Click"></asp:button>&nbsp;&nbsp;
															<asp:button id="Cancelar" runat="server" CausesValidation="False" Width="60px" Text="  Cancelar  " onclick="Cancelar_Click"></asp:button></TD>
													</TR>
												</table>
<asp:ValidationSummary id=VSUsufructo runat="server" CssClass="text" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
											</td>
										</TR>
									</table>
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
