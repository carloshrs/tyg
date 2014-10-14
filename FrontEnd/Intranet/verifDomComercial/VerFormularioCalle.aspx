<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.VerifDomComercial.VerFormularioCalle" CodeFile="VerFormularioCalle.aspx.cs" %>
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
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td align="right">
						<div id="panel"><input onclick="panel.style.visibility='hidden';window.print();panel.style.visibility='visible';"
								type="image" src="/img/imprimir-2.gif"> <input onclick="window.close();" type="image" src="/img/log_off.gif">
						</div>
					</td>
				</tr>
			</TABLE>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<td><IMG alt="" src="/img/logo_impr.gif" 
width=175></td>
					<TD class="title" width="100%"><FONT color="#ffffff">
							<P align="center"><FONT color=gray>Verificación de 
      Domicilio Comercial</FONT>
						</FONT></P></TD>
				</TR>
			</TABLE>
			<TABLE class="text" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TBODY>
					<tr>
						<td class="title" width="100%"><BR>
							<HR>
							<TABLE cellSpacing="0" cellPadding="0" style="BORDER-COLLAPSE: collapse" borderColor="#000000" width="100%" border="1">
								<tr>
									<td class="text" align="left" width="85%">
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr>
												<td class="text">Solicitado por:
													<asp:label id="lblSolicitante" runat="server" Font-Bold="True"></asp:label></td>
												<td class="text">Fecha:
													<asp:label id="lblFec" runat="server" Font-Bold="True"></asp:label></td>
											</tr>
											<tr>
												<td class="text" colSpan="2">Referencia:
													<asp:label id="lblRef" runat="server" Font-Bold="True"></asp:label></td>
											</tr>
										</table>
									</td>
									<td class="text" align="right" width="15%">Numero:<br>
										<asp:label id="lblNum" runat="server" Font-Bold="True"></asp:label></td>
								</tr>
							</TABLE>
							<TABLE id="Table2" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
								cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="text" width="100%">
										<TABLE id="Table3" style="BORDER-COLLAPSE: collapse" borderColor="#000000" cellSpacing="0"
											cellPadding="3" width="100%" border="1">
											<TR>
												<TD width="100%" colSpan="4">
													<TABLE id="Table4" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
														cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; <FONT 
                        color=gray>Datos 
                Comerciales</FONT></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="text" width="50%" colSpan="2"><STRONG><STRONG>Apellido</STRONG>&nbsp;y 
														nombre:</STRONG>&nbsp;
													<BR>
													<asp:label id="lblApellido" runat="server"></asp:label>,
													<asp:label id="lblNombre" runat="server"></asp:label></TD>
												<TD class="text" width="50%" colSpan="2"><STRONG>Tipo y nº documento:</STRONG><BR>
													<asp:label id="lblTipoDocumento" runat="server"></asp:label>&nbsp;
													<asp:label id="lblDocumento" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="text" width="50%" colSpan="2"><STRONG>Nombre de fantasia:</STRONG>
													<BR>
													<asp:label id="lblNombreFantasia" runat="server"></asp:label></TD>
												<TD class="text" width="50%" colSpan="2"><STRONG>Razón Social:&nbsp; </STRONG>
													<BR>
													<asp:label id="lblRazonSocial" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="text" width="50%" colSpan="2"><STRONG>Rubro:&nbsp; </STRONG>
													<BR>
													<asp:label id="lblRubro" runat="server"></asp:label></TD>
												<TD class="text" width="50%" colSpan="2"><STRONG>CUIT:&nbsp; </STRONG>
													<BR>
													<asp:label id="lblCuit" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="text" width="50%" colSpan="2">&nbsp;</TD>
												<TD class="text" width="50%" colSpan="2"></TD>
											</TR>
											<TR>
												<TD width="100%" colSpan="4">
													<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; <FONT 
                        color=gray>Domicilio</FONT></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="text" width="50%" colSpan="2"><STRONG>Calle:&nbsp; </STRONG>
													<BR>
													<asp:label id="lblCalle" runat="server"></asp:label></TD>
												<TD class="text" width="50%" colSpan="2"><STRONG>Barrio:</STRONG>&nbsp;
													<BR>
													<asp:label id="lblBarrio" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="text" width="25%"><STRONG>Nro:</STRONG>
													<asp:label id="lblNro" runat="server"></asp:label></TD>
												<TD class="text" width="25%"><STRONG>Piso:</STRONG>
													<asp:label id="lblPiso" runat="server"></asp:label></TD>
												<TD class="text" width="25%"><STRONG>Depto.:</STRONG>
													<asp:label id="lblDepto" runat="server"></asp:label></TD>
												<TD class="text" width="25%"><STRONG>C.P.:</STRONG>
													<asp:label id="lblCP" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="text" width="50%" colSpan="2"><STRONG>Teléfono:</STRONG>&nbsp;
													<asp:label id="lblTelefono" runat="server"></asp:label></TD>
												<TD class="text" width="50%" colSpan="2"><STRONG>Localidad:</STRONG>&nbsp;
													<asp:label id="lblLocalidad" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="text" width="50%" colSpan="4">&nbsp;</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
							<TABLE class="text" id="Table16" style="BORDER-COLLAPSE: collapse" borderColor="#111111"
								cellSpacing="0" cellPadding="3" width="100%" border="1">
								<TR>
									<td colSpan="3">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; <FONT 
                  color=gray>Gestión sobre la 
            verificación</FONT></TD>
											</TR>
										</TABLE>
									</td>
								</TR>
								<tr>
									<TD class="text" width="33%" height="19"><STRONG>Fecha:</STRONG>
										<BR>
										<asp:label id="lblFecha" runat="server"></asp:label></TD>
									<TD class="text" width="33%" height="19"><STRONG>Ocupación:</STRONG><BR>
										<asp:label id="lblOcupacion" runat="server"></asp:label></TD>
									<TD class="text" width="33%" height="19"><STRONG>Categoría de autonomo:<BR>
										</STRONG>
										<asp:label id="lblCategoria" runat="server"></asp:label></TD>
								</tr>
								<TR>
									<TD class="text" width="33%"><STRONG>Mov. comercial observado:<BR>
										</STRONG>
										<asp:label id="lblMovComercial" runat="server"></asp:label></TD>
									<TD class="text" width="33%"><STRONG>Actividad principal:<BR>
										</STRONG>
										<asp:label id="lblActividad" runat="server"></asp:label></TD>
									<TD class="text" width="33%"><STRONG>Rubros adicionales:<BR>
										</STRONG>
										<asp:label id="lblRubros" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD class="text" width="33%"><STRONG>Horario de atención:</STRONG><BR>
										<asp:label id="lblHorario" runat="server"></asp:label></TD>
									<TD class="text" width="33%"><STRONG>Antiguedad en el domicilio:<BR>
										</STRONG>
										<asp:label id="lblAntiguedad" runat="server"></asp:label></TD>
									<TD class="text" width="33%"><STRONG>Cantidad de personal:<BR>
										</STRONG>
										<asp:label id="lblCantidad" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD><STRONG>Caracteristica zona:<BR>
										</STRONG>
										<asp:label id="lblCaractZona" runat="server"></asp:label></TD>
									<TD><STRONG>Documento verificado:</STRONG><BR>
										<asp:label id="lblDocVerificado" runat="server"></asp:label></TD>
									<TD><STRONG>Ubicación:<BR>
										</STRONG>
										<asp:label id="lblUbicacion" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD height="14"><STRONG>Tamaño de local:<BR>
										</STRONG>
										<asp:label id="lblTamLocal" runat="server"></asp:label></TD>
									<TD height="14"><STRONG>Inmueble:</STRONG><BR>
										<asp:label id="lblInmueble" runat="server"></asp:label></TD>
									<TD height="14"><STRONG>Estado de conservación:</STRONG><BR>
										<asp:label id="lblEstadoCons" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<td>&nbsp;</td>
									<td>&nbsp;</td>
									<TD class="text" width="100%">&nbsp;
									</TD>
								</TR>
							</TABLE>
							<TABLE class="text" id="Table17" style="BORDER-COLLAPSE: collapse" borderColor="#111111"
								cellSpacing="0" cellPadding="3" width="100%" border="1">
								<tr>
									<TD class="text" width="25%"><STRONG>Cartel de publicidad:<BR>
										</STRONG>
										<asp:label id="lblPublicidad" runat="server"></asp:label></TD>
									<TD class="text" width="25%"><STRONG>Personal de vigilancia:</STRONG>
										<asp:label id="lblVigilancia" runat="server"></asp:label></TD>
									<TD class="text" width="25%"><STRONG>Inicio de actividades:</STRONG>
										<asp:label id="lblInicioActividades" runat="server"></asp:label></TD>
									<TD class="text" width="25%"><STRONG>Categoria ante el IVA:</STRONG><BR>
										<asp:label id="lblIVA" runat="server"></asp:label></TD>
								</tr>
								<TR>
									<td width="50%" colSpan="2"><STRONG>Informó:</STRONG>&nbsp;
										<BR>
										<asp:label id="lblInformo" runat="server"></asp:label></td>
									<td width="50%" colSpan="2"><STRONG>Cargo o relación:<BR>
										</STRONG>
										<asp:label id="lblCargo" runat="server"></asp:label></td>
								</TR>
								<TR>
									<TD class="text" width="25%" colSpan="2">&nbsp;</TD>
									<td width="25%" colSpan="2">&nbsp;</td>
								</TR>
							</TABLE>
							<TABLE class="text" id="Table1" style="BORDER-COLLAPSE: collapse" borderColor="#111111"
								cellSpacing="0" cellPadding="3" width="100%" border="1">
								<TR>
									<td colSpan="3">
										<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; <FONT 
                  color=gray>Referencia vecinal</FONT></TD>
											</TR>
										</TABLE>
									</td>
								</TR>
								<tr>
									<TD class="text" width="33%"><STRONG>Apellido y nombre:</STRONG><BR>
										<asp:label id="lblNombreVecino" runat="server"></asp:label></TD>
									<TD class="text" width="33%"><STRONG>Domicilio:<BR>
										</STRONG>
										<asp:label id="lblDomicilioVecino" runat="server"></asp:label></TD>
									<TD class="text" width="33%"><STRONG>Conoce del funcionamiento:</STRONG><BR>
										<asp:label id="lblConoce" runat="server"></asp:label></TD>
								</tr>
								<TR>
									<TD width="100%" colSpan="3"><STRONG><asp:label id="Label5" runat="server">Observaciones</asp:label>:<BR>
										</STRONG>
										<asp:label id="lblObservaciones" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD width="33%" colSpan="3">&nbsp;<BR>
										<B>&nbsp;Plano de&nbsp;ubicación:</B></TD>
								</TR>
								<TR>
									<TD class="text" align="center" width="33%" >
            <P align=center><IMG height=140 src="/img/plano_chico.gif" width=140 
            border=1>&nbsp;</P>
									</TD>
									<TD vAlign="top" colSpan=3>&nbsp;
										<TABLE class="text" id="Table14" cellSpacing="1" cellPadding="2">
											<TR>
												<TD>Ubicación <B>A:</B></TD>
												<TD><asp:label id="lblPlanoA" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD>Ubicación <B>B:</B></TD>
												<TD><asp:label id="lblPlanoB" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD>Ubicación <B>C:</B></TD>
												<TD><asp:label id="lblPlanoC" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD>Ubicación <B>D:</B></TD>
												<TD><asp:label id="lblPlanoD" runat="server"></asp:label></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
							<INPUT id="idEncabezado" type="hidden" name="idEncabezado" runat="server"> <INPUT id="idReferencia" type="hidden" name="idReferencia" runat="server">
						</td>
					</tr>
				</TBODY></TABLE>
		</form>
	</body>
</HTML>
