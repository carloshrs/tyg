<%@ Register TagPrefix="mnu" TagName="menu" Src="../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Inhibicion.Informe" CodeFile="Informe.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Alta de Informe</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
		<script type="text/javascript">

		    function ToggleImg(name, src, alt) {
		        name.src = "/img/" + src;
		        name.alt = alt;
		    }

			function NuevoResultado()
			{
				//window.open('abmTitular.aspx?idInforme=' + document.Form1.idInformePropiedad.value + '&porc=' + document.Form1.totalPorcentaje.value,'','dialogWidth:510px;dialogHeight:250px');
				window.showModalDialog('abmResultado.aspx?idInforme=' + document.Form1.idInforme.value ,'','dialogWidth:510px;dialogHeight:350px');
				//Page_ValidationActive = false;
				//__doPostBack('','');
				document.location.reload();
            }

            function mostrarFiltro(name) {
                if (dv_solicitud.style.display == "none") {
                    dv_solicitud.style.display = "list-item";
                    ToggleImg(name, 'Cerrar.gif', 'Ocultar datos de la solicitud');
                    document.getElementById('hdEncAbierto').value = '1';
                }
                else {
                    dv_solicitud.style.display = "none";
                    ToggleImg(name, 'Arrow.gif', 'Mostrar datos de la solicitud');
                    document.getElementById('hdEncAbierto').value = '0';
                }
            }

            function mostrarInfoAdicional() {
                if (document.Form1.lblEncObservaciones.value != '')
                    mostrarFiltro(document.getElementById('imgSolicitud'));
            }

		</script>
  </HEAD>
	<body leftmargin="0" topmargin="0" onload="mostrarInfoAdicional();">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<table cellpadding="0" cellspacing="0" border="0" width="480">
			<tr>
				<td width="10">&nbsp;</td>
				<td>
					<br>
					<form id="Form1" method="post" runat="server">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="title" width="100%">
									Informe de Inhibiciones</td>
							</tr>
                            <tr>
					    <td>
					        <table width="100%" class="text" cellpadding="1" cellspacing="1">
					            <tr bgColor="#F3F3F3" class="text">
					                <td>
					                    <table cellpadding="0" cellspacing="0">
					                    <tr>
					                        <td><a href="javascript:mostrarFiltro(document.getElementById('imgSolicitud'));"><asp:Image ID="imgSolicitud" runat="server" ImageUrl="/img/Arrow.gif" Height="14" Width="14" BorderWidth="0"  /></a><b>
                                                </b></td>
					                        <td style="font-family: Arial; font-size: 10pt; color: #3557A1">&nbsp;&nbsp;Informaci&oacute;n adicional de la solicitud</td>
					                    </tr>
					                    </table>
					                </td>
					            </tr>
					            <tr bgColor="#FBFBFB" id="dv_solicitud" style="display: none;">
					                <td colspan="2">
					                <table class="text">
					                    <tr>
					                        <td colspan="2"><b>Datos de contacto<asp:HiddenField ID="hdEncAbierto" runat="server" Value="0" Visible="true" /></b></td>
					                    </tr>
					                    <tr>
					                        <td><i>Tel&eacute;fono:</i></td>
					                        <td><b><asp:Label ID="lblEncTelefono" runat="server"></asp:Label></b></td>
					                    </tr>
					                    <tr>
					                        <td><i>e-mail:</i></td>
					                        <td><b><asp:Label ID="lblEncMail" runat="server"></asp:Label></b></td>
					                    </tr>
					                    <tr>
					                        <td colspan="2"><b>Datos C&oacute;nyuge/Concubino</b></td>
					                    </tr>
					                    <tr>
					                        <td><i>Apellido y Nombre:</i></td>
					                        <td><b><asp:Label ID="lblEncApeCon" runat="server"></asp:Label>&nbsp;<asp:Label ID="lblEncNomCon" runat="server"></asp:Label></b></td>
					                    </tr>
					                    <tr>
					                        <td><i>Tipo y Nro Documento:</i></td>
					                        <td><b><asp:Label ID="lblEncTipoDocCon" runat="server"></asp:Label>&nbsp;<asp:Label ID="lblEncNroDocCon" runat="server"></asp:Label></b></td>
					                    </tr>
					                    <tr>
					                        <td colspan="2"><b>Observaciones</b></td>
					                    </tr>
					                    <tr>
					                        <td colspan="2">
                                                <asp:TextBox ID="lblEncObservaciones" runat="server" Width="450px" TextMode="MultiLine" Rows="5" CssClass="Plano" ReadOnly="true"></asp:TextBox>
                                            </td>
					                    </tr>
					                </table>
					                </td>
					            </tr>
					        </table>
					    </td>
					</tr>
							<tr>
								<td width="100%">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="text" width="100%">&nbsp;</TD>
										</TR>
										<TR>
											<TD class="text" width="100%" colSpan="4">
												<asp:panel id="pnlTipoPersona" runat="server">
                  <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0>
                    <TR>
                      <TD class=text width="100%">Tipo 
Persona:</TD></TR>
                    <TR>
                      <TD class=text width="100%">
<asp:DropDownList id=cmbTipoPersona runat="server" AutoPostBack="True" Width="100%" onselectedindexchanged="cmbTipoPersona_SelectedIndexChanged">
																	<asp:ListItem Value="1">Persona F&#237;sica</asp:ListItem>
																	<asp:ListItem Value="2">Persona Jur&#237;dica</asp:ListItem>
																</asp:DropDownList></TD></TR>
                    <TR>
                      <TD class=text width="100%" 
                    height=10></TD></TR></TABLE>
												</asp:panel></TD>
										</TR>
										<TR>
											<td width="100%" colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0" height="176">
													<TR>
														<TD class="text" width="50%">
															<asp:panel id="pnlParticulares" runat="server">
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD width="100%" colSpan=2>
                              <TABLE height=18 cellSpacing=0 cellPadding=0 
                              width="100%" border=0>
                                <TR>
                                <TD class=title width="100%" bgColor=lightgrey height=10>&nbsp;&nbsp; Datos 
                                personales</TD></TR></TABLE></TD></TR>
                          <TR>
                            <TD class=text width="50%">Nombre&nbsp;</TD>
                            <TD class=text width="50%">Apellido&nbsp;</TD></TR>
                          <TR>
                            <TD class=text width="50%">
<asp:textbox id=txtNombre runat="server" Width="98%"></asp:textbox></TD>
                            <TD class=text width="50%">
<asp:textbox id=txtApellido runat="server" Width="100%"></asp:textbox></TD></TR>
                          <TR>
                            <TD class=text width="50%">Tipo de documento</TD>
                            <TD class=text width="50%">Documento 
<asp:requiredfieldvalidator id=Requiredfieldvalidator4 runat="server" ErrorMessage="*" ControlToValidate="txtDocumento"></asp:requiredfieldvalidator></TD></TR>
                          <TR>
                            <TD class=text width="50%">
<asp:dropdownlist id=cmbTipoDocumento runat="server" Width="230px"></asp:dropdownlist></TD>
                            <TD class=text width="50%">
<asp:textbox id=txtDocumento runat="server" Width="100%"></asp:textbox></TD></TR>
                          <TR>
                            <TD class=text colSpan=2>
                                <IMG height=15 
                              src="/img/shim.gif" 
                        width=1></TD></TR></TABLE>
															</asp:panel>
															<asp:panel id="pnlDomComercial" runat="server">
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD width=536>
                              <TABLE cellSpacing=0 cellPadding=0 width="100%" 
                              border=0>
                                <TR>
                                <TD class=title width="100%" bgColor=lightgrey height=10>&nbsp;&nbsp; 
<asp:Label class=title id=lblInforme runat="server">Persona Jurídica</asp:Label></TD></TR></TABLE></TD></TR>
                          <TR>
                            <TD>
                              <TABLE cellSpacing=0 cellPadding=0 width="100%" 
                              border=0>
                                <TR>
                                <TD class=text width="50%">Razón Social&nbsp; 
<asp:RequiredFieldValidator id=Requiredfieldvalidator6 runat="server" ErrorMessage="*" ControlToValidate="RazonSocial"></asp:RequiredFieldValidator></TD>
                                <TD class=text width="10%">Cuit</TD></TR>
                                <TR>
                                <TD class=text width="50%">
<asp:TextBox id=RazonSocial runat="server" Width="320px"></asp:TextBox></TD>
                                <TD class=text width="10%">
<asp:TextBox id=Cuit runat="server" Width="144px"></asp:TextBox></TD></TR></TABLE></TD></TR>
<TR><TD class=text width="100%" height=10></TD></TR>
</TABLE>
															</asp:panel>
														</TD>
													</TR>
													<TR>
														<TD width="100%">
															<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" height="18">
																<TBODY>
																	<TR>
																		<TD width="100%" colspan="4">
																			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" height="18">

																						<TR>
																					<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; 
																						Resultados</TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																	<tr><td colspan="4"></td></tr>
										<TR>
											<TD class="text" width="535" colSpan="4">
												<asp:datagrid id="dgResultados" runat="server" Width="100%" 
                                                    AutoGenerateColumns="False" BackColor="White"
													BorderStyle="None" BorderColor="#CCCCCC" CellPadding="3" Font-Size="8pt" BorderWidth="1px" 
                                                    onprerender="dgResultados_PreRender" onitemcommand="dgResultados_ItemCommand">
													<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
													<ItemStyle ForeColor="#000066"></ItemStyle>
													<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
													<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="idResultado"></asp:BoundColumn>
														<asp:BoundColumn DataField="medida" HeaderText="Medida">
															<HeaderStyle Width="150px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="diario" HeaderText="Diario">
															<HeaderStyle Width="150px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="ano" HeaderText="Año">
															<HeaderStyle Width="80px"></HeaderStyle>
														</asp:BoundColumn>

														<asp:BoundColumn DataField="fecha" HeaderText="Fecha">
															<HeaderStyle Width="80px"></HeaderStyle>
														</asp:BoundColumn>


														<asp:TemplateColumn>
															<HeaderStyle Width="20px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Editar" runat="server" ImageUrl="/img/modificar_general.gif" CausesValidation="False" Width="16px" ToolTip="Editar titular" CommandName="Editar"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="20px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Borrar" runat="server" ImageUrl="/Img/Cruz.gif" CausesValidation="False" Width="16px" ToolTip="Borrar titular" CommandName="Borrar"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
												</asp:datagrid>
											</TD>
										</TR>
										<TR>
											<TD class="text" width="50%" colSpan="2"><img src="/img/shim.gif" width="1" height="10"></TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4">
												<P align="right"><INPUT onclick="NuevoResultado();" type="button" value="Nuevo"></P>
											</TD>
										</TR>
																	<TR>
																		<TD class="text" colSpan="3"><img src="/img/shim.gif" height="15" width="1"></TD>
																	</TR>

												</table>
											</td>
										</TR>
										<TR>
											<TD colSpan="4" width="100%" class="text">

											                    Observaciones</TD>
										</TR>
										<TR>
											<td class="text" width="100%" colSpan="4">
												<asp:textbox id="txtObservaciones" runat="server" Width="480px" TextMode="MultiLine" Rows="5"
													CssClass="Plano" Height="176px"></asp:textbox>
											</td>
										</TR>
                                        <TR>
											<TD class="text" align="left" colSpan="2">
                                                <br />
                                                Adjuntar PDF<br />
                                                <asp:FileUpload ID="txtArchivo" runat="server" />
                                                <br />
                                                <asp:RequiredFieldValidator ID="reqArchivo" runat="server" 
                                                    ErrorMessage="Adjuntar archivo de Riesgo Online" Text="*" ControlToValidate="txtArchivo"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:Image ID="imgArchivo" runat="server" ImageUrl="~/Img/shim.gif" />&nbsp;<asp:HyperLink ID="hlArchivo" runat="server" CssClass="text" Target="_blank"><asp:Label ID="lblArchivo" runat="server" Text=""></asp:Label></asp:HyperLink>
                                                <br /><br />
                                            </TD></TR>
										<TR>
											<td width="100%" colSpan="4">
												<hr SIZE="2">
											</td>
										</TR>
										<TR>
											<td width="100%" colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0" height="24">
													<TR>
														<TD class="text" align="right">
															<asp:button id="Aceptar" runat="server" Width="70px" Text="Aceptar" onclick="Aceptar_Click"></asp:button>&nbsp;&nbsp;
															<asp:button id="AceptarFinalizar" runat="server" Width="107px" Text="Aceptar y Finalizar" onclick="AceptarFinalizar_Click"></asp:button>&nbsp;&nbsp;
															<asp:button id="Cancelar" runat="server" CausesValidation="False" Width="60px" Text="  Cancelar  " onclick="Cancelar_Click"></asp:button></TD>
													</TR>
												</table>
											</td>
										</TR>
									</table>
<asp:ValidationSummary id=VSInhibicion runat="server" CssClass="text" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
								</td>
							</tr>
						</TABLE>
						<input id="idInforme" type="hidden" name="idInforme" runat="server"> <input id="idReferencia" type="hidden" name="idReferencia" runat="server">
						<INPUT id="idTipoProp" type="hidden" name="idTipoProp" runat="server">
					</form>
				</td>
			</tr>
		</table><!--</TD></TR></TBODY></TABLE>-->
	</body>
</HTML>
