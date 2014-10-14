<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.VerifDomParticular.verInforme" CodeFile="VerInforme.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Verificación de Domicilio Particular</title>
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
						<div id="panel">
							<asp:Label ID="lblTools" Runat="server"></asp:Label>
						</div>
					</td>
				</tr>
			</TABLE>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<td><IMG alt="" src="/img/logo-20-anios.png" width="264"></td>
					<TD class="title" width="100%"><FONT color="#ffffff">
							<P align="center"><FONT color="#32528e">Verificación de Domicilio Particular</FONT>
						</FONT></P></TD>
				</TR>
				<tr>
					<td colspan="2">
						<TABLE cellSpacing="0" cellPadding="0" style="BORDER-COLLAPSE: collapse" borderColor="#000000"
							width="100%" border="1">
							<tr>
								<td class="text" align="left" width="85%">
									<table cellpadding="0" cellspacing="0" border="0" width="100%">
										<tr>
											<td class="text">
												&nbsp;Solicitado por:
												<asp:label id="lblSolicitante" runat="server" Font-Bold="True"></asp:label>
											</td>
											<td class="text">
												Fecha:
												<asp:label id="lblFec" runat="server" Font-Bold="True"></asp:label>
											</td>
										</tr>
										<tr>
											<td colspan="2" class="text">
												&nbsp;Referencia:
												<asp:label id="lblRef" runat="server" Font-Bold="True"></asp:label>
											</td>
										</tr>
									</table>
								</td>
								<td class="text" align="left" width="15%">
									&nbsp;Numero:
									<asp:label id="lblNum" runat="server" Font-Bold="True"></asp:label>
								</td>
							</tr>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td class="title" width="100%" colSpan="2">
						<HR>
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="100%" colSpan="4">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="text" width="100%" colspan="4">
												<asp:panel id="pnlFisica" runat="server">
                  <TABLE class=text id=Table3 style="BORDER-COLLAPSE: collapse" 
                  borderColor=#111111 cellSpacing=0 cellPadding=3 width="100%" 
                  border=1>
                    <TR>
                      <TD width="99%" colSpan=4>
                        <TABLE id=Table4 cellSpacing=0 cellPadding=0 
                        width="100%" border=0>
                          <TR>
                            <TD class=title width="100%" bgColor=lightgrey 
                            colSpan=3 height=10>&nbsp;&nbsp; Persona 
                          Física</TD></TR></TABLE></TD>
                    <TR>
                      <TD vAlign=top width="25%"><STRONG>Apellido y 
                        nombre:</STRONG>&nbsp;<BR>
<asp:label id=lblApellido runat="server"></asp:label>, 
<asp:label id=lblNombre runat="server"></asp:label></TD>
                      <TD class=text vAlign=top width="25%"><STRONG>Tipo y nº 
                        documento:&nbsp;</STRONG> 
<asp:label id=lblTipoDocumento runat="server"></asp:label>&nbsp; 
<asp:label id=lblDocumento runat="server"></asp:label></TD>
                      <TD class=text vAlign=top width="25%" 
                        colSpan=2><STRONG>Estado civil:</STRONG> 
<asp:label id=lblEstadoCivil runat="server"></asp:label></TD></TR>
                    <TR>
                      <TD width="99%" colSpan=4>&nbsp;</TD></TR></TABLE>
                  <TABLE class=text id=Table7 style="BORDER-COLLAPSE: collapse" 
                  borderColor=#111111 cellSpacing=0 cellPadding=3 width="100%" 
                  border=1>
                    <TR>
                      <TD width="100%" colSpan=4>
                        <TABLE id=Table5 cellSpacing=0 cellPadding=0 
                        width="100%" border=0>
                          <TR>
                            <TD class=title width="100%" bgColor=lightgrey 
                            colSpan=3 height=10>&nbsp;&nbsp; Domicilio a 
                              verificar</TD></TR></TABLE></TD></TR>
                    <TR>
                      <TD class=text width="100%" 
                        colSpan=4><STRONG>Calle:</STRONG> 
<asp:label id=lblCalle runat="server"></asp:label></TD></TR>
                    <TR>
                      <TD class=text width="25%"><STRONG>Nro:</STRONG> 
<asp:label id=lblNro runat="server"></asp:label></TD>
                      <TD class=text width="25%"><STRONG>Piso:</STRONG> 
<asp:label id=lblPiso runat="server"></asp:label></TD>
                      <TD class=text width="25%"><STRONG>Depto.:</STRONG> 
<asp:label id=lblDepto runat="server"></asp:label></TD>
                      <TD class=text width="25%"><STRONG>C.P.:</STRONG> 
<asp:label id=lblCP runat="server"></asp:label></TD></TR>
                    <TR>
                      <TD class=text width="50%" 
                        colSpan=2><STRONG>Barrio:</STRONG>&nbsp; 
<asp:label id=lblBarrio runat="server"></asp:label></TD>
                      <TD class=text width="50%" 
                        colSpan=2><STRONG>Teléfono:&nbsp;&nbsp; </STRONG>
<asp:label id=lblTelefono runat="server"></asp:label></TD></TR>
                    <TR>
                      <TD class=text width="50%" 
                        colSpan=2><STRONG>Provincia:&nbsp; </STRONG>
<asp:label id=lblProvincia runat="server"></asp:label></TD>
                      <TD class=text width="50%" 
                        colSpan=2><STRONG>Localidad:&nbsp; </STRONG>
<asp:label id=lblLocalidad runat="server"></asp:label></TD></TR>
                    <TR>
                      <TD class=text width=535 
                  colSpan=4>&nbsp;</TD></TR></TABLE>
												</asp:panel>
												<asp:panel id="pnlJuridica" runat="server">
                  <TABLE class=text id=Table8 style="BORDER-COLLAPSE: collapse" 
                  borderColor=#111111 cellSpacing=0 cellPadding=3 width="100%" 
                  border=1>
                    <TR>
                      <TD width="100%" colSpan=4>
                        <TABLE id=Table9 cellSpacing=0 cellPadding=0 
                        width="100%" border=0>
                          <TR>
                            <TD class=title width="100%" bgColor=lightgrey 
                            colSpan=3 height=10>&nbsp;&nbsp; Persona 
                            Jurídica</TD></TR></TABLE></TD></TR>
                    <TR>
                      <TD class=text width=360 colSpan=2><STRONG>Razón 
                        Social:</STRONG> 
<asp:label id=lblRazonSocial runat="server"></asp:label></TD>
                      <TD class=text width="50%" colSpan=2><STRONG>Nombre de 
                        fantas&iacute;a:</STRONG>&nbsp; 
<asp:label id=lblNombreFantasia runat="server"></asp:label></TD></TR>
                    <TR>
                      <TD class=text width=360 
                        colSpan=2><STRONG>Rubro:&nbsp;</STRONG> 
<asp:label id=lblRubro runat="server"></asp:label></TD>
                      <TD class=text width="50%" 
                        colSpan=2><STRONG>CUIT:&nbsp;</STRONG> 
<asp:label id=lblCUIT runat="server"></asp:label></TD></TR>
                    <TR>
                      <TD class=text width="100%" 
                        colSpan=4><STRONG>Calle:&nbsp;</STRONG> 
<asp:label id=lblCalleEmpresa runat="server"></asp:label></TD></TR>
                    <TR>
                      <TD class=text width=160><STRONG>Nro:</STRONG> 
<asp:label id=lblNroEmpresa runat="server"></asp:label></TD>
                      <TD class=text width=209><STRONG>Piso:</STRONG> 
<asp:label id=lblPisoEmpresa runat="server"></asp:label></TD>
                      <TD class=text width="25%"><STRONG>Depto.:</STRONG> 
<asp:label id=lblDeptoEmpresa runat="server"></asp:label></TD>
                      <TD class=text width="25%"><STRONG>C.P.:</STRONG> 
<asp:label id=lblCPEmpresa runat="server"></asp:label></TD></TR>
                    <TR>
                      <TD class=text width=360 
                        colSpan=2><STRONG>Barrio:&nbsp;</STRONG> 
<asp:label id=lblBarrioEmpresa runat="server"></asp:label></TD>
                      <TD class=text width="50%" 
                        colSpan=2><STRONG>Teléfono:&nbsp;</STRONG> 
<asp:label id=lblTelefonoEmpresa runat="server"></asp:label></TD></TR>
                    <TR>
                      <TD class=text width=360 
                        colSpan=2><STRONG>Provincia:&nbsp; </STRONG>
<asp:label id=lblProvinciaEmpresa runat="server"></asp:label></TD>
                      <TD class=text width="50%" 
                        colSpan=2><STRONG>Localidad:&nbsp;</STRONG> 
<asp:label id=lblLocalidadEmpresa runat="server"></asp:label></TD></TR>
                    <TR>
                      <TD class=text width="100%" colSpan=4>&nbsp; 
                    </TD></TR></TABLE>
												</asp:panel>
											</TD>
										</TR>
										<tr>
											<td colspan="4">
											</td>
										</tr>
									</TABLE>
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; 
												Gestión sobre la verificación</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="text" width="100%" colSpan="4">
									<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
										cellPadding="3" width="100%" border="1">
										<TR>
											<TD class="text" width="89"><STRONG>Fecha:</STRONG>
												<BR>
												<asp:label id="lblFecha" runat="server"></asp:label></TD>
											<TD class="text" width="157"><STRONG>Habita en lugar declarado:</STRONG>
												<BR>
												<asp:label id="lblHabita" runat="server"></asp:label></TD>
											<TD class="text" width="190"><STRONG>Antiguedad:</STRONG>
												<BR>
												<asp:label id="lblAntiguedad" runat="server"></asp:label></TD>
											<TD class="text" width="25%"><STRONG>Tel. alternativo:</STRONG>
												<BR>
												<asp:label id="lblTelefonoAlt" runat="server"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="text" width="100%" colSpan="4">
									<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
										cellPadding="3" width="100%" border="1">
										<TR>
											<TD class="text" width="33%">
												<P><STRONG>Monto alquiler:</STRONG><BR>
													<asp:label id="lblMonto" runat="server"></asp:label></P>
											</TD>
											<TD class="text" width="33%"><STRONG>Vencimiento de contrato</STRONG><BR>
												<asp:label id="lblVencimiento" runat="server"></asp:label></TD>
											<TD class="text" width="33%" colSpan="2"><STRONG>Enviar correspondencia a:</STRONG><BR>
												<asp:label id="lblEnviar" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD width="33%"><STRONG>Tipo de vivienda:</STRONG>
												<BR>
												<asp:label id="lblTipoVivienda" runat="server"></asp:label></TD>
											<TD width="33%"><STRONG>Estado de conservación:</STRONG>
												<BR>
												<asp:label id="lblEstadoConservacion" runat="server"></asp:label></TD>
											<TD width="33%" colSpan="2"><STRONG>Tipo de construcción:</STRONG>
												<BR>
												<asp:label id="lblTipoConstruccion" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD height="14"><STRONG>Tipo de Zona:</STRONG>
												<BR>
												<asp:label id="lblTipoZona" runat="server"></asp:label></TD>
											<TD height="14"><STRONG>Tipo de calle:</STRONG>
												<BR>
												<asp:label id="lblTipoCalle" runat="server"></asp:label></TD>
											<TD colSpan="2" height="14"><STRONG>Vive en caracter de:</STRONG>
												<BR>
												<asp:label id="lblInteresado" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="text" width="33%"><STRONG>Acceso al domicilio:&nbsp;</STRONG>
												<BR>
												<asp:label id="lblAccesoDomicilio" runat="server"></asp:label></TD>
											<TD class="text" width="33%"><STRONG>Informó:&nbsp;</STRONG><BR>
												<asp:label id="lblInformo" runat="server"></asp:label></TD>
											<TD class="text" width="33%" colSpan="2"><STRONG>Relación:&nbsp;<BR>
												</STRONG>
												<asp:label id="lblRelacion" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="text" width="33%" colSpan="4">&nbsp;</TD>
										</TR>
										<TR>
											<TD colSpan="4">
												<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; 
															Referencia vecinal</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD class="text"><STRONG>Apellido y nombre:</STRONG>
												<BR>
												<asp:label id="lblNombreVecino" runat="server"></asp:label></TD>
											<TD class="text"><STRONG>Domicilio:</STRONG>
												<BR>
												<asp:label id="lblDomicilioVecino" runat="server"></asp:label></TD>
											<TD class="text" colSpan="2"><STRONG>Conoce a la persona:</STRONG>
												<BR>
												<asp:label id="lblConoceVecino" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="text" width="100%" colSpan="4"><STRONG>Observaciones:</STRONG> <BR>
												<asp:label id="lblObservaciones" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="text" colSpan="4">&nbsp;<BR>
												<STRONG>Plano de&nbsp;ubicación:</STRONG></TD>
										</TR>
										<TR>
											<TD class="text" align="center">
												<P align="center"><IMG height=140 
                  src="/img/plano_chico.gif" width=140 border=1>&nbsp;
												</P>
											</TD>
											<TD vAlign="top" colSpan="3">
												<TABLE class="text" id="Table13" cellSpacing="1" cellPadding="2">
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
								</TD>
							</TR>
							<tr>
								<td colspan="3" class="text" align="center">
									<br>
									<asp:Image id="imgFoto" runat="server"></asp:Image>
								</td>
							</tr>
							<TR>
								<TD width="100%" colSpan="4"><BR>
									<FONT size="1">Este informe es confidencial y solo puede ser usado para la 
										evaluación y otorgamiento de créditos o celebración de negocios. Esta prohibida 
										su reproducción, divulgación y entrega a terceros.<BR>
										No significa emitir juicio de valor sobre las personas ni sobre su solvencia. 
										Las <U>decisiones a las que arribe el usuario son de su exclusiva responsabilidad.</U></FONT>
									<HR>
								</TD>
							</TR>
						</TABLE>
						<BR>
					</td>
				</tr>
				<tr>
					<td width="100%" colSpan="2"></td>
				</tr>
			</TABLE>
			<input id="idEncabezado" type="hidden" name="idEncabezado" runat="server"> <input id="idReferencia" type="hidden" name="idReferencia" runat="server">
		</form>
	</body>
</HTML>
