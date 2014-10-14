<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.verifContrato.Informe" CodeFile="Informe.aspx.cs" %>
<%@ Register TagPrefix="mnu" TagName="menu" Src="../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Alta de Informe</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
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

			</script>
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
								<td class="title" width="100%">
									Verificación de&nbsp;Contratos
								</td>
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
															<asp:panel id="pnlFisica" runat="server">
                        <TABLE cellSpacing=0 cellPadding=0 width=536 border=0>
                          <TR>
                            <TD width=536 colSpan=4>
                              <TABLE cellSpacing=0 cellPadding=0 width=536 
                              border=0>
                                <TR>
                                <TD class=title width="100%" bgColor=lightgrey 
                                colSpan=3 height=10>&nbsp;&nbsp; Personales 
                                Física</TD></TR></TABLE></TD></TR>
                          <TR>
                            <TD class=text width="50%" 
                            colSpan=2>Nombre&nbsp;</TD>
                            <TD class=text width="50%" 
                            colSpan=2>Apellido&nbsp;</TD></TR>
                          <TR>
                            <TD class=text width="50%" colSpan=2>
<asp:textbox id=txtNombre runat="server" Width="230px"></asp:textbox></TD>
                            <TD class=text width="50%" colSpan=2>
<asp:textbox id=txtApellido runat="server" Width="100%"></asp:textbox></TD></TR>
                          <TR>
                            <TD class=text width="50%" colSpan=2>Tipo de 
                              documento</TD>
                            <TD class=text width="50%" colSpan=2>Documento 
<asp:requiredfieldvalidator id=Requiredfieldvalidator4 runat="server" ControlToValidate="txtDocumento" ErrorMessage="Ingrese el nro de documento">*</asp:requiredfieldvalidator>
<asp:CompareValidator id=CompareValidator1 runat="server" ControlToValidate="txtDocumento" ErrorMessage="El valor del documento debe ser numérico" Type="Double" Operator="DataTypeCheck">*</asp:CompareValidator></TD></TR>
                          <TR>
                            <TD class=text width="50%" colSpan=2>
<asp:dropdownlist id=cmbTipoDocumento runat="server" Width="230px"></asp:dropdownlist></TD>
                            <TD class=text width="50%" colSpan=2>
<asp:textbox id=txtDocumento runat="server" Width="100%"></asp:textbox></TD></TR>
                          <TR>
                            <TD class=text width="50%" colSpan=2>Estado 
                            civil</TD>
                            <TD class=text width="50%" colSpan=2></TD></TR>
                          <TR>
                            <TD class=text width="50%" colSpan=2>
<asp:dropdownlist id=cmbEstadoCivil runat="server" Width="230px"></asp:dropdownlist></TD>
                            <TD class=text width="50%" 
                        colSpan=2></TD></TR></TABLE>
															</asp:panel>
															<asp:panel id="pnlDomComercial" runat="server">
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD width=536 colSpan=4>
                              <TABLE cellSpacing=0 cellPadding=0 width="100%" 
                              border=0>
                                <TR>
                                <TD class=title width="100%" bgColor=lightgrey 
                                colSpan=3 height=10>&nbsp;&nbsp; 
<asp:label id=lblInforme runat="server" CssClass="Title">Persona Jurídica</asp:label></TD></TR></TABLE></TD></TR>
                          <TR>
                            <TD class=text width=536>Razón Social&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator8 runat="server" ControlToValidate="RazonSocial" ErrorMessage="Ingrese la razón social">*</asp:RequiredFieldValidator></TD></TR>
                          <TR>
                            <TD class=text width=536 colSpan=4>
<asp:TextBox id=RazonSocial runat="server" Width="100%"></asp:TextBox></TD></TR>
                          <TR>
                            <TD class=text width=536 colSpan=4>
                              <TABLE cellSpacing=0 cellPadding=0 width="100%" 
                              border=0>
                                <TR>
                                <TD class=text width="50%">Nombre de 
                                Fantasía</TD>
                                <TD class=text width="10%">Teléfono</TD></TR>
                                <TR>
                                <TD class=text width="50%">
<asp:TextBox id=NombreFantasia runat="server" Width="320px"></asp:TextBox></TD>
                                <TD class=text width="10%">
<asp:TextBox id=Telefono runat="server" Width="200px"></asp:TextBox></TD></TR></TABLE></TD></TR>
                          <TR>
                            <TD class=text width=536 colSpan=4>
                              <TABLE cellSpacing=0 cellPadding=0 width="100%" 
                              border=0>
                                <TR>
                                <TD class=text width="50%">Rubro</TD>
                                <TD class=text width="10%">Cuit&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator9 runat="server" ControlToValidate="Cuit" ErrorMessage="Ingrese el nro de CUIT">*</asp:RequiredFieldValidator></TD></TR>
                                <TR>
                                <TD class=text width="50%">
<asp:TextBox id=Rubro runat="server" Width="320px"></asp:TextBox></TD>
                                <TD class=text width="10%">
<asp:TextBox id=Cuit runat="server" Width="200px"></asp:TextBox></TD></TR></TABLE></TD></TR>
                          <TR>
                            <TD class=text width=536 colSpan=4>
                              <TABLE cellSpacing=0 cellPadding=0 width="100%" 
                              border=0>
                                <TR>
                                <TD class=text width="70%">Calle&nbsp; </TD>
                                <TD class=text width="10%">Nro.&nbsp; </TD>
                                <TD class=text width="10%">Dpto.</TD>
                                <TD class=text 
                                width="10%">&nbsp;&nbsp;Piso</TD></TR>
                                <TR>
                                <TD class=text width="70%">
<asp:TextBox id=CalleEmpresa runat="server" Width="320px"></asp:TextBox></TD>
                                <TD class=text width="10%">
<asp:TextBox id=NroEmpresa runat="server" Width="46px"></asp:TextBox></TD>
                                <TD class=text width="10%">
<asp:TextBox id=DptoEmpresa runat="server" Width="46px"></asp:TextBox></TD>
                                <TD class=text align=right width="10%">
<asp:TextBox id=PisoEmpresa runat="server" Width="47px"></asp:TextBox></TD></TR></TABLE></TD></TR>
                          <TR>
                            <TD class=text width=536 colSpan=4>
                              <TABLE cellSpacing=0 cellPadding=0 width="100%" 
                              border=0>
                                <TR>
                                <TD class=text width="50%">Barrio&nbsp; </TD>
                                <TD class=text width="10%">Código Postal&nbsp; 
                                </TD></TR>
                                <TR>
                                <TD class=text width="50%">
<asp:TextBox id=BarrioEmpresa runat="server" Width="320px"></asp:TextBox></TD>
                                <TD class=text width="10%">
<asp:TextBox id=CPEmpresa runat="server" Width="200px"></asp:TextBox></TD></TR></TABLE></TD></TR>
                          <TR>
                            <TD class=text width=536 colSpan=4>
                              <TABLE cellSpacing=0 cellPadding=0 width="100%" 
                              border=0>
                                <TR>
                                <TD class=text width="50%" height=14>Provincia 
                                </TD>
                                <TD class=text width="10%" 
                                height=14>Localidad&nbsp; </TD></TR>
                                <TR>
                                <TD class=text width="50%">
<asp:dropdownlist id=cmbProvinciaEmpresas runat="server" Width="268px" AutoPostBack="True" onselectedindexchanged="cmbProvinciaEmpresas_SelectedIndexChanged"></asp:dropdownlist></TD>
                                <TD class=text width="50%">
<asp:dropdownlist id=cmbLocalidadEmpresas runat="server" Width="268px"></asp:dropdownlist></TD></TR></TABLE></TD></TR>
                          <TR>
                            <TD class=text 
                        colSpan=4>&nbsp;&nbsp;</TD></TR></TABLE>
															</asp:panel>
														</TD>
													</TR>
												</table>
											</td>
										</TR>
										<TR>
											<TD class="text" width="175" colSpan="4"><asp:label id="Label5" runat="server">Observaciones</asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD class="text" width="100%" colSpan="4"><asp:textbox id="txtObservaciones" runat="server" Width="100%" TextMode="MultiLine" Rows="5"
													CssClass="Plano"></asp:textbox></TD>
										</TR>
										<TR>
											<td class="text" width="535" colSpan="4">&nbsp;</td>
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
												<asp:datagrid id="dgridEncabezados" runat="server" Width="640px" BorderWidth="1px" Font-Size="8pt"
													PageSize="20" CellPadding="3" BorderColor="#3657A6" BorderStyle="None" BackColor="White" GridLines="Vertical"
													AutoGenerateColumns="False" onprerender="dgridEncabezados_PreRender">
													<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
													<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
													<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
													<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
													<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
													<Columns>
														<asp:BoundColumn DataField="idContrato" HeaderText="C&#243;digo">
															<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="TIDescripcion" HeaderText="Tipo Contrato">
															<HeaderStyle Width="150px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Numero" HeaderText="N&#250;mero">
															<HeaderStyle Width="40px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="TipoPersona" HeaderText="En Caracter de...">
															<HeaderStyle Width="150px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Descripcion" HeaderText="Descripci&#243;n">
															<HeaderStyle Width="350px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Fecha Inicio"></asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="FechaInicio" HeaderText="Inicio">
															<HeaderStyle Width="20px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Fecha Fin"></asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="FechaFin" HeaderText="Fin">
															<HeaderStyle Width="20px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="10px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Ver" runat="server" Width="16px" ToolTip="Visualizar Contrato" CommandName="Ver" 
 ImageUrl="\Img\Lupita.gif"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="idCliente" HeaderText="idCliente"></asp:BoundColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="25px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Historico" runat="server" Width="16px" ToolTip="Ver Historial..." CommandName="Historico" 
 Height="16px" ImageUrl="..\Img\reloj.jpg"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
														BackColor="#999999"></PagerStyle>
												</asp:datagrid>
											</td>
										</TR>
										<TR>
											<td width="640" colSpan="4">
												<hr SIZE="2">
											</td>
										</TR>
										<TR>
											<TD width="640" colSpan="4">
												<asp:ValidationSummary id="VSVerifDomParticular" runat="server" CssClass="text" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></TD>
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
								</td>
							</tr>
						</TABLE>
						<input id="idInforme" type="hidden" name="idInforme" runat="server"> <input id="idReferencia" type="hidden" name="idReferencia" runat="server">
						<INPUT id="idTipoProp" type="hidden" name="idTipoProp" runat="server"> <INPUT id="idTipoPersona" type="hidden" name="idTipoPersona" runat="server">
					</form>
				</td>
			</tr>
		</table>
	</body>
</HTML>
