<%@ Register TagPrefix="mnu" TagName="menu" Src="../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Automotores.Informe" CodeFile="Informe.aspx.cs" EnableEventValidation="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Alta de Informe</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
		<script src="../Includes/entertab.js" type="text/javascript"></script>
			<script>
			function ToggleImg(name, src, alt)
			{
				name.src = "/img/" + src;
				name.alt = alt
			}

			function mostrarFiltro(First, name)
			{
				if (masInfo.style.display == "none") 
				{
					masInfo.style.display = "list-item";
					ToggleImg(name, 'Cerrar.gif', 'Cerrar Más Info');
				} 
				else 
				{
					masInfo.style.display = "none";
					ToggleImg(name, 'Arrow.gif', 'Más Info');
				}
			}
			function NuevoTitular()
			{
				window.showModalDialog('abmTitular.aspx?idInforme=' + document.Form1.idInforme.value + '&porc=0&porcTotal=' + document.Form1.totalPorcentaje.value,'','dialogWidth:510px;dialogHeight:400px');
				Page_ValidationActive = false;
				document.getElementById('hAccion').value = 1;
				__doPostBack('hAccion','');
			}
			
			function EditarTitular(titular)
			{
				window.showModalDialog('abmTitular.aspx?idInforme=' + document.Form1.idInforme.value + '&porc=0&porcTotal=' + document.Form1.totalPorcentaje.value + '&IdTitular=' + titular,'','dialogWidth:510px;dialogHeight:400px');
				Page_ValidationActive = false;
				document.getElementById('hAccion').value = 1;
				__doPostBack('hAccion','');
			}
			
			function validarPorcTotal()
			{
				if(document.Form1.totalPorcentaje.value >=100)
					{
						alert('La suma de los porcentajes no debe superar el 100%')
						return false;
					}
			}



			</script>
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<DIV id="divDateControl" style="Z-INDEX: 102; LEFT: -35px; VISIBILITY: hidden; POSITION: absolute; TOP: -150px"><IFRAME name="popFrame" src="/inc/calendar/calendar.htm" frameBorder="0" width="160" scrolling="no"
				height="160"></IFRAME></DIV>
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<table cellSpacing="0" cellPadding="0" border="0">
			<tr>
				<td width="10">&nbsp;</td>
				<td><br>
					<form id="Form1" method="post" runat="server">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="title" width="100%">Informe de&nbsp;Automotores y 
									Motovehículos&nbsp;
								</td>
							</tr>
							<tr>
								<td width="100%">
									<table cellSpacing="0" cellPadding="0" width="480" border="0">

										<TR>
											<td width="536" colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="text" width="50%">
															<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="text" width="100%" colSpan="4"><IMG height="10" src="/img/shim.gif" width="1"></TD>
																</TR>
																<TR>
																	<TD class="text" width="100%" colSpan="4">Dominio&nbsp;
																		<asp:requiredfieldvalidator id="Requiredfieldvalidator5" runat="server" 
                                                                            ErrorMessage="Ingrese el dominio" ControlToValidate="txtDominio">*</asp:requiredfieldvalidator></TD>
																</TR>
																<TR>
																	<TD class="text" width="100%" colSpan="4"><asp:textbox id="txtDominio" runat="server" Width="100%" Style="text-transform: uppercase;"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="text" width="100%" colSpan="4"><IMG height="10" src="/img/shim.gif" width="1"></TD>
																</TR>
																
															</TABLE>
														</TD>
													</TR>
												</table>
											</td>
										</TR>
										<TR>
											<td class="text" width="535" colSpan="4">&nbsp;</td>
										</TR>
										
										<TR>
											<td class="text" width="535" colSpan="4">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD width="536" colSpan="4">
															<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; 
																		Datos del Registro</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="text" width="100%" colSpan="4">Registro&nbsp;
															<asp:requiredfieldvalidator id="Requiredfieldvalidator8" runat="server" 
                                                                ErrorMessage="Ingrese el registro" ControlToValidate="txtRegistro">*</asp:requiredfieldvalidator></TD>
													</TR>
													<TR>
														<TD class="text" width="100%" colSpan="4"><asp:textbox id="txtRegistro" runat="server" Width="100%" Style="text-transform: uppercase;"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="text" width="50%" colSpan="2">Calle&nbsp;</TD>
														<TD class="text" width="50%" colSpan="2">Barrio&nbsp;</TD>
													</TR>
													<TR>
														<TD class="text" width="50%" colSpan="2"><asp:textbox id="txtCalleRegistro" runat="server" Width="230px" Style="text-transform: uppercase;"></asp:textbox></TD>
														<TD class="text" width="50%" colSpan="2"><asp:textbox id="txtBarrioRegistro" runat="server" Width="100%" Style="text-transform: uppercase;"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="text" width="25%">Nro</TD>
														<TD class="text" width="25%">Piso</TD>
														<TD class="text" width="25%">Depto.</TD>
														<TD class="text" width="25%">C.P.</TD>
													</TR>
													<TR>
														<TD class="text" width="25%"><asp:textbox id="txtNroRegistro" runat="server" Width="100px"></asp:textbox></TD>
														<TD class="text" width="25%"><asp:textbox id="txtPisoRegistro" runat="server" Width="100px"></asp:textbox></TD>
														<TD class="text" align="left" width="25%"><asp:textbox id="txtDptoRegistro" runat="server" Width="100px" Style="text-transform: uppercase;"></asp:textbox></TD>
														<TD class="text" align="left" width="25%"><asp:textbox id="txtCPRegistro" runat="server" Width="100px"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="text" width="50%" colSpan="2">Provincia&nbsp;
														</TD>
														<TD class="text" width="50%" colSpan="2">Localidad&nbsp;
														</TD>
													</TR>
													<TR>
														<TD class="text" width="50%" colSpan="2"><asp:dropdownlist id="cmbProvinciaRegistro" runat="server" AutoPostBack="True" onselectedindexchanged="cmbProvinciaRegistro_SelectedIndexChanged"></asp:dropdownlist></TD>
														<TD class="text" width="50%" colSpan="2"><asp:dropdownlist id="cmbLocalidadRegistro" runat="server"></asp:dropdownlist></TD>
													</TR>
												</TABLE>
											</td>
										</TR>
										<TR>
											<td class="text" width="535" colSpan="4">&nbsp;</td>
										</TR>
										
										<TR>
											<TD class="text" width="535" colSpan="4">
												<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">
															<P>&nbsp;&nbsp; Titulares del automotor</P>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4">&nbsp;
											</TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4">
												<asp:datagrid id="dgTitulares" runat="server" Width="100%" Font-Size="8pt" AutoGenerateColumns="False"
													CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CCCCCC" onprerender="dgTitulares_PreRender">
													<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
													<ItemStyle ForeColor="#000066"></ItemStyle>
													<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
													<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="idTitular"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="IdTipoPersona" HeaderText="Tipo">
															<HeaderStyle Width="5px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Nombre" HeaderText="Nombre y Apellido &lt;br&gt; Nombre Fantasia">
															<HeaderStyle Width="35%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NroDoc" HeaderText="Documento&lt;br&gt;CUIT">
															<HeaderStyle Width="20%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="EstadoCivil" HeaderText="Estado Civil&lt;br&gt;Rubro">
															<HeaderStyle Width="65px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Porcentaje" HeaderText="Proporción">
															<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<FooterStyle HorizontalAlign="Center"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="Porcentaje" HeaderText="Porcentaje">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="NombreFantasia" HeaderText="Nombre Fantasia"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="RazonSocial" HeaderText="Razon Social"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="Rubro" HeaderText="Rubro"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="Cuit" HeaderText="Cuit"></asp:BoundColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="20px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Editar" runat="server" ImageUrl="/img/modificar_general.gif" CausesValidation="False"
																	Width="16px" ToolTip="Editar titular" CommandName="Editar"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="20px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Borrar" runat="server" ImageUrl="\Img\Cruz.gif" CausesValidation="False" Width="16px"
																	ToolTip="Borrar titular" CommandName="Borrar"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4">
												<P align="right">
                                                    <INPUT id="totalPorcentaje" type="hidden" name="totalPorcentaje" runat="server"><asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClientClick="NuevoTitular();" /></P>
											</TD>
										</TR>
										<TR>
											<td class="text" width="535" colSpan="4">&nbsp;</td>
										</TR>
<TR>
											<td class="text" width="535" colSpan="4">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD width="536" colSpan="5">
															<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; 
																		Datos del Vehículo</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="text" width="33%">Marca&nbsp;</TD>
														<TD class="text" width="33%">Modelo&nbsp;</TD>
														<TD class="text" width="33%">Año&nbsp;</TD>
													</TR>
													<TR>
														<TD class="text" width="33%"><asp:textbox id="txtMarca" runat="server" Width="98%" Style="text-transform: uppercase;"></asp:textbox></TD>
														<TD class="text" width="33%"><asp:textbox id="txtModelo" runat="server" Width="98%" Style="text-transform: uppercase;"></asp:textbox></TD>
														<TD class="text" align="right" width="33%"><asp:textbox id="txtAno" runat="server" Width="98%"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="text" width="100%" colSpan="3">
															<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="text" width="50%" colSpan="2">Número de Chasis</TD>
																	<TD class="text" width="50%">Número de Motor</TD>
																</TR>
																<TR>
																	<TD class="text" width="50%" colSpan="2"><asp:textbox id="txtNroChasis" runat="server" Width="98%" Style="text-transform: uppercase;"></asp:textbox></TD>
																	<TD class="text" align="right" width="50%"><asp:textbox id="txtNroMotor" runat="server" Width="98%" Style="text-transform: uppercase;"></asp:textbox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</td>
										</TR>
										<TR>
											<td class="text" width="535" colSpan="4">&nbsp;</td>
										</TR>
										<TR>
											<TD class="text" width="175" colSpan="4"><asp:label id="Label1" runat="server">Gravámenes y Restricciones</asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD class="text" width="100%" colSpan="4"><asp:textbox id="txtGravamenes" runat="server" Width="100%" TextMode="MultiLine" Rows="5" CssClass="Plano" Style="text-transform: uppercase;"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="text" width="175" colSpan="4"><asp:label id="Label2" runat="server">Datos Negativos del Titular</asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD class="text" width="100%" colSpan="4"><asp:textbox id="txtDatosNegativos" runat="server" Width="100%" TextMode="MultiLine" Rows="5" Style="text-transform: uppercase;"
													CssClass="Plano"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="text" width="175" colSpan="4"><asp:label id="Label5" runat="server">Observaciones</asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD class="text" width="100%" colSpan="4"><asp:textbox id="txtObservaciones" runat="server" Width="100%" TextMode="MultiLine" Rows="5" Style="text-transform: uppercase;"
													CssClass="Plano"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="text" width="100%" colSpan="4">Resultados</TD>
										</TR>
										<TR>
											<TD class="text" width="100%" colSpan="4"><asp:textbox id="txtResultados" runat="server" Width="100%" Style="text-transform: uppercase;"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="text" width="100%" colSpan="4"><IMG height="10" src="/img/shim.gif" width="1"></TD>
										</TR>
										<TR>
											<td width="535" colSpan="4"><INPUT id="hidConFoto" type="hidden" runat="server">
                                            <asp:ValidationSummary ID="VSAutomotores" runat="server" CssClass="text" ShowSummary="False"
                                                ShowMessageBox="True"></asp:ValidationSummary>
											</td>
										</TR>
										<TR>
											<td width="536" colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="text" align="right"><asp:button id="Aceptar" runat="server" Width="65px" Text="Aceptar" onclick="Aceptar_Click"></asp:button>&nbsp;&nbsp;
															<asp:button id="AceptarFinalizar" runat="server" Width="113px" Text="Aceptar y Finalizar" onclick="AceptarFinalizar_Click"></asp:button>&nbsp;&nbsp;
															<asp:button id="Cancelar" runat="server" Width="65px" Text="Cancelar" CausesValidation="False" onclick="Cancelar_Click"></asp:button></TD>
													</TR>
												</table>
											</td>
										</TR>
									</table>
								</td>
							</tr>
						</TABLE>
						<input id="idInforme" type="hidden" name="idInforme" runat="server"> <input id="idReferencia" type="hidden" name="idReferencia" runat="server">
						<INPUT id="idTipoProp" type="hidden" name="idTipoProp" runat="server">
						<asp:HiddenField ID="hAccion" runat="server" Value="0" OnValueChanged="hAccion_ValueChanged" />
					</form>
				</td>
			</tr>
		</table>
	</body>
</HTML>
