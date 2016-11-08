<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.VerifDomParticular.verInformeCalle" CodeFile="VerInformeCalle.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Relevamiento Ambiental BANCOR</title>
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

			function imprimir() {
			    panel.style.visibility = 'hidden';
			    window.print();
			    panel.style.visibility = 'visible';
			}

			</script>
</HEAD>
	<body onload="imprimir();">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td align="right">
						<div id="panel">
							<input type="image" src="/img/imprimir-2.gif" title="Imprimir" onclick="panel.style.visibility='hidden';window.print();panel.style.visibility='visible';">
							<input type="image" src="/img/log_off.gif" title="Cerrar" onclick="window.close();window.opener.location.href=window.opener.location;">
						</div>
					</td>
				</tr>
			</TABLE>
			<TABLE class="tablaInforme" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<td colspan="2">
					<TABLE class="tablaInforme" cellSpacing="0" cellPadding="0" width="738" border="0">
					<TR>
					<td><IMG alt="" src="/img/logo_fondo_blanco.gif" width="175"></td>
					<TD class="title" width="100%"><FONT color="#ffffff">
							<P align="center">
						</FONT><FONT color="gray">Inspección Socio Ambiental</FONT></P></TD>
						<td><IMG alt="" src="/img/bancor.jpg" width="175"></td>
						</TR>
					</TABLE>
						</td>
				</TR>

				<tr>
					<td colspan="2" width=738>
						<TABLE cellSpacing="0" cellPadding="0" style="BORDER-COLLAPSE: collapse" borderColor="#000000"
							width="100%" border="1">
							<tr>
								<td class="text" align="left" width="85%">
									<table cellpadding="0" cellspacing="0" border="0" width="100%">
										<tr>
											<td class="text">
												&nbsp; Solicitado por:
												<asp:label id="lblSolicitante" runat="server" Font-Bold="True"></asp:label>
											</td>
											<td class="text">
												Fecha:
												<asp:label id="lblFec" runat="server" Font-Bold="True"></asp:label>
											</td>
										</tr>
										<tr>
											<td colspan="2" class="text">
												&nbsp; Referencia:
												<asp:label id="lblRef" runat="server" Font-Bold="True"></asp:label>
											</td>
										</tr>
									</table>
								</td>
								<td class="text" align="left" width="15%">
									&nbsp; Numero:
									<asp:label id="lblNum" runat="server" Font-Bold="True"></asp:label>
								</td>
							</tr>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td class="title" width="746" colSpan="2">
						<HR>
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="text" width="100%" colSpan="4">&nbsp;</TD>
							</TR>
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
                      <TD width="99%" colSpan=2>
                        <TABLE id=Table4 cellSpacing=0 cellPadding=0 
                        width="100%" border=0>
                          <TR>
                            <TD class=title width="100%" bgColor=lightgrey height=10>&nbsp;&nbsp; <FONT 
                              color=gray>Datos de persona</FONT></TD></TR></TABLE></TD>
                    <TR>
                      <TD vAlign=top width="50%"><STRONG>Apellido y 
                        nombre:</STRONG>&nbsp; 
<asp:label id=lblApellido runat="server"></asp:label>, 
<asp:label id=lblNombre runat="server"></asp:label></TD>
                      <TD class=text vAlign=top width="50%"><STRONG>Tipo y Nº 
                        documento:&nbsp;</STRONG> 
<asp:label id=lblTipoDocumento runat="server"></asp:label>&nbsp; 
<asp:label id=lblDocumento runat="server"></asp:label></TD></TR>
                    <TR>
                      <TD vAlign=top width="100%" 
                        colSpan=2><STRONG>Observaciones:</STRONG> 
<asp:label id=Label1 runat="server"></asp:label></TD></TR>
                    <TR>
                      <TD width="99%" colSpan=2>&nbsp;</TD></TR></TABLE>
                  <TABLE class=text id=Table7 style="BORDER-COLLAPSE: collapse" 
                  borderColor=#111111 cellSpacing=0 cellPadding=3 width="100%" 
                  border=1>
                    <TR>
                      <TD width="100%" colSpan=4>
                        <TABLE id=Table5 cellSpacing=0 cellPadding=0 
                        width="100%" border=0>
                          <TR>
                            <TD class=title width="100%" bgColor=lightgrey height=10>&nbsp;&nbsp; <FONT 
                              color=gray>Domicilio a 
                          verificar</FONT></TD></TR></TABLE></TD></TR>
                    <TR>
                      <TD class=text width="50%" 
                        colSpan=2><STRONG>Calle:</STRONG> 
<asp:label id="lblCalle" runat="server"></asp:label></TD>
                      <TD class=text width="25%"><STRONG>Lote:</STRONG> 
<asp:label id="lblLote" runat="server"></asp:label></TD>
                      <TD class=text width="25%"><STRONG>Manzana:</STRONG> 
<asp:label id="lblManzana" runat="server"></asp:label></TD>
</TR>
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
                        colSpan=2><STRONG>Complejo:</STRONG>&nbsp; 
<asp:label id=lblComplejo runat="server"></asp:label></TD>
                      <TD class=text width="50%" 
                        colSpan=2><STRONG>Torre:&nbsp;&nbsp; </STRONG>
<asp:label id=lblTorre runat="server"></asp:label></TD></TR>
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
												<FONT color="gray">Gestión sobre la inspección</FONT></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="text" width="100%" colSpan="4">
									<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
										cellPadding="3" width="100%" border="1">
										
										<TR>
											<TD class="text" style="font-size:14px"><br /><STRONG>¿Habita el inmueble?: SI / NO (tachar lo que no corresponda)</STRONG>
                                            <br /><br />
                                            Por SI<br />
                                            - ¿Cuantas personas integran el grupo familiar?
												<BR />
                                                <br />
                                                <BR />
                                                Por NO: <br />
                                                - ¿Quien habita el inmueble?
                                                <br />
                                                <br />
                                                <br />
                                                - ¿En calidad de qué? (alquila, vendió, etc)
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <STRONG>¿Han realizado ampliaciones o mejoras?: SI / NO (tachar lo que no corresponda)</STRONG>
                                            <br />
                                            Por SI<br />
                                            - ¿Cuales?<br /><br />
                                                <br />
                                                <br />
                                            <STRONG>¿Trabaja de forma dependiente o independiente?: </STRONG>
                                            <br />
                                            Dependiente:<br />
                                            - Lugar de trabajo:
                                            <br />
                                            - Empresa: <br />
                                            <br />
                                            - Dirección: <br />
                                            - Ingresos netos mensuales: <br />
                                            - Banco donde le acreditan los haberes: <br />
                                                <br />
                                                <br />
                                            Independiente:<br />
                                            - ¿Que actividad tiene?:<br />
                                            - ¿Donde la desarrolla?:<br /><br /><br /><br />
                                            <STRONG>Indique la suma de ingresos netos familiares: 
                                                <br /><br />
                                                <br />
                                                ¿Servicios o impuestos a su nombre? (sacar foto)</STRONG><br /><br />
                                            </TD>
											
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="text" width="100%" colSpan="4">
									<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
										cellPadding="3" width="100%" border="1">
										<TR>
											<TD colSpan="4">
												<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;
															<FONT color="gray">Referencia vecinal 1</FONT></TD>
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
											<TD colSpan="4">
												<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;
															<FONT color="gray">Referencia vecinal 2</FONT></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD class="text"><STRONG>Apellido y nombre:</STRONG>
												<BR>
												<asp:label id="lblNombreVecino2" runat="server"></asp:label></TD>
											<TD class="text"><STRONG>Domicilio:</STRONG>
												<BR>
												<asp:label id="lblDomicilioVecino2" runat="server"></asp:label></TD>
											<TD class="text" colSpan="2"><STRONG>Conoce a la persona:</STRONG>
												<BR>
												<asp:label id="lblConoceVecino2" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="text" width="100%" colSpan="2">Fuimos atendidos por:<br /><STRONG>Informante:</STRONG>
												<BR>
												<asp:label id="lblInformante" runat="server"></asp:label></TD>
                                                <TD class="text" width="100%" colSpan="2"><STRONG>Relación:</STRONG>
												<BR>
												<asp:label id="lblRelacion" runat="server"></asp:label></TD>
										</TR>
                                        <TR>
											<TD class="text" width="100%" colSpan="4"><STRONG>Observaciones:</STRONG>
												<BR>
												<asp:label id="Label2" runat="server"></asp:label></TD>
										</TR>
                                        <TR>
											<TD class="text" width="50%" colSpan="4"><STRONG>Testimonial:</STRONG>
												<BR>
												
                                                Firma:<br />Aclaración: <br />DNI:
												<BR>
												<asp:label id="Label3" runat="server"></asp:label>
                                                
                                                
                                                <br />
                                                
                                                
                                                </TD>
										</TR>
										<TR>
											<TD class="text" colSpan="4">
												<br>
												<STRONG>Plano de&nbsp;ubicación:</STRONG>												
											</TD>
										</TR>
										<TR>
											<TD class="text" align="center" width="240">
												<IMG height="310" src="/img/plano_chico.gif" width="310" border="1">
											</TD>
											<TD vAlign="top" width="80%" colSpan="3">
												<TABLE class="text" id="Table13" cellSpacing="1" cellPadding="2" width="80%">
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
												<P align="center">
													<BR><BR><BR><BR>
													<asp:Label id="lblConFoto" runat="server" Font-Bold="True" Visible="False" Font-Italic="True">Sacar fotos a la propiedad</asp:Label></P>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<!---<TR>
								<TD width="100%" colSpan="4"><BR>
									<FONT size="1">Este informe es confidencial y solo puede ser usado para la 
										evaluación y otorgamiento de créditos o celebración de negocios. Esta prohibida 
										su reproducción, divulgación y entrega a terceros.<BR>
										No significa emitir juicio de valor sobre las personas ni sobre su solvencia. 
										Las <U>decisiones a las que arribe el usuario son de su exclusiva responsabilidad.</U></FONT>
									<HR>
								</TD>
							</TR>--->
						</TABLE>						
					</td>
				</tr>
				<!---<tr>
					<td width="100%" colSpan="2"></td>
				</tr>--->
			</TABLE>
			<input id="idEncabezado" type="hidden" name="idEncabezado" runat="server">
			<input id="idReferencia" type="hidden" name="idReferencia" runat="server">
		</form>
	</body>
</HTML>
