<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.BusquedaAutomotor.Informe" CodeFile="Informe.aspx.cs" %>
<%@ Register TagPrefix="mnu" TagName="menu" Src="../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Alta de Busqueda</title>
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
			
			function NuevoDominio()
			{
				//window.open('abmTitular.aspx?idInforme=' + document.Form1.idInformePropiedad.value + '&porc=' + document.Form1.totalPorcentaje.value,'','dialogWidth:510px;dialogHeight:250px');
				window.showModalDialog('abmDominio.aspx?idInforme=' + document.Form1.idInforme.value ,'','dialogWidth:510px;dialogHeight:250px');
		
				//Page_ValidationActive = false;
				//__doPostBack('','');
				document.location.reload();
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
									Búsqueda de Automotor
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
												<table cellSpacing="0" cellPadding="0" width="576" border="0" height="176">
													<TR>
														<TD class="text" width="50%">
															<asp:panel id="pnlFisica" runat="server">
                        <TABLE height=152 cellSpacing=0 cellPadding=0 width=536 
                        border=0>
                          <TR>
                            <TD width=536 colSpan=4>
                              <TABLE height=18 cellSpacing=0 cellPadding=0 
                              width=536 border=0>
                                <TR>
                                <TD class=title width="100%" bgColor=lightgrey 
                                colSpan=3 height=10>&nbsp;&nbsp; Datos 
                                personales</TD></TR></TABLE>&nbsp; </TD></TR>
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
<asp:requiredfieldvalidator id=Requiredfieldvalidator4 runat="server" ControlToValidate="txtDocumento" ErrorMessage="*"></asp:requiredfieldvalidator>
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
<asp:RequiredFieldValidator id=RequiredFieldValidator8 runat="server" ControlToValidate="RazonSocial" ErrorMessage="Ingrese la razon social">*</asp:RequiredFieldValidator></TD></TR>
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
<asp:RequiredFieldValidator id=RequiredFieldValidator9 runat="server" ControlToValidate="Cuit" ErrorMessage="Ingrese el CUIT">*</asp:RequiredFieldValidator></TD></TR>
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
											<td class="text" width="535" colSpan="4">&nbsp;</td>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4">
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
											<TD class="text" width="50%" colSpan="3">Resultados</TD>
										</TR>
										<TR>
											<TD class="text" width="50%" colSpan="3">
												<asp:dropdownlist id="cmbResultado" runat="server" Width="230px">
													<asp:ListItem Value="POSITIVO">POSITIVO</asp:ListItem>
													<asp:ListItem Value="NEGATIVO">NEGATIVO</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="text" width="50%" colSpan="2"><IMG height="10" src="/img/shim.gif" width="1"></TD>
										</TR>
										<TR>
											<TD class="text" width="50%" colSpan="2">&nbsp;Observaciones</TD>
											<TD class="text" width="50%" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="text" width="50%" colSpan="4">
												<asp:textbox id="txtObservaciones" runat="server" Width="500px" TextMode="MultiLine" Rows="4">SE REALIZÓ LA BÚSQUEDA DE AUTOMOTORES EN TODO EL PAIS A TRAVÉS DE LA D.N.R.P.A., ARROJANDO COMO RESULTADO</asp:textbox></TD>
										</TR>
										<TR>
											<TD class="text" width="50%" colSpan="2"><IMG height="10" src="/img/shim.gif" width="1"></TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4">
												<asp:datagrid id="dgDominios" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White"
													BorderStyle="None" BorderColor="#CCCCCC" CellPadding="3" Font-Size="8pt" BorderWidth="1px" onprerender="dgDominios_PreRender">
													<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
													<ItemStyle ForeColor="#000066"></ItemStyle>
													<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
													<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="idDominio"></asp:BoundColumn>
														<asp:BoundColumn DataField="Dominio" HeaderText="Dominio">
															<HeaderStyle Width="150px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Registro" HeaderText="Registro donde esta radicado">
															<HeaderStyle Width="80%"></HeaderStyle>
														</asp:BoundColumn>
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
												</asp:datagrid>
											</TD>
										</TR>
										<TR>
											<TD class="text" width="50%" colSpan="2"><img src="/img/shim.gif" width="1" height="10"></TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4">
												<P align="right"><INPUT onclick="NuevoDominio();" type="button" value="Nuevo"></P>
											</TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4">
												<hr SIZE="2">
											</TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0" height="24">
													<TR>
														<TD class="text" align="right" width="100%">
															<asp:button id="Aceptar" runat="server" Width="56px" Text="Aceptar" onclick="Aceptar_Click"></asp:button>&nbsp;&nbsp;
															<asp:button id="AceptarFinalizar" runat="server" Width="104px" Text="Aceptar y Finalizar" onclick="AceptarFinalizar_Click"></asp:button>&nbsp;&nbsp;
															<asp:button id="Cancelar" runat="server" CausesValidation="False" Width="60px" Text="  Cancelar  " onclick="Cancelar_Click"></asp:button></TD>
													</TR>
												</table>
											</TD>
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
