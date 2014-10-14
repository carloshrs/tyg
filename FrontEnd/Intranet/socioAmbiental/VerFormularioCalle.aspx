<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.socioAmbiental.VerFormularioCalle" CodeFile="VerFormularioCalle.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Formulario de calle - Ambiental</title>
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
							<input type="image" src="/img/imprimir-2.gif" onclick="panel.style.visibility='hidden';window.print();panel.style.visibility='visible';">
							<input type="image" src="/img/log_off.gif" onclick="window.close();">
						</div>
					</td>
				</tr>
			</TABLE>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<td><IMG alt="" src="/img/logo-20-anios-impr.png" height"69></td>
					<TD class="title" width="100%"><P align="center"><FONT color="gray">Informe Socio Ambiental/Preocupacional</FONT></P></TD>
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
								<td class="text" align="right" width="15%">
									N&uacute;mero&nbsp;<br>
									<asp:label id="lblNum" runat="server" Font-Bold="True"></asp:label>&nbsp;
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
								<TD class="text" width="100%" colSpan="4">&nbsp;</TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="4">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="text" width="100%" colspan="4">
												<TABLE class="text" id="Table3" style="BORDER-COLLAPSE: collapse" borderColor="#111111"
													cellSpacing="0" cellPadding="3" width="100%" border="1">
													<TR>
														<TD width="99%" colSpan="3">
															<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR bgColor="lightgrey">
																	<TD class="title" width="100%" colSpan="3" height="10">&nbsp;&nbsp;<FONT color="gray">Datos personales</FONT></TD>
																</TR>
															</TABLE>
														</TD>
													<TR>
														<TD vAlign="top" width="25%"><STRONG>Apellido y nombre:</STRONG><br />
															<asp:label id="lblApellido" runat="server"></asp:label>,
															<asp:label id="lblNombre" runat="server"></asp:label></TD>
														<TD class="text" vAlign="top" width="25%"><STRONG>Tipo y nº documento:</STRONG><br />
															<asp:label id="lblTipoDocumento" runat="server"></asp:label>&nbsp;
															<asp:label id="lblDocumento" runat="server"></asp:label></TD>
														<TD class="text" vAlign="top" width="25%"><STRONG>Estado civil:</STRONG><br />
															<asp:label id="lblEstadoCivil" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD vAlign="top" width="100%" colSpan="3"><STRONG>Observaciones:</STRONG>
															<asp:label id="lblObsSolic" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD width="99%" colSpan="3">&nbsp;</TD>
													</TR>
												</TABLE>
												<TABLE class="text" id="Table7" style="BORDER-COLLAPSE: collapse" borderColor="#111111"
													cellSpacing="0" cellPadding="3" width="100%" border="1">
													<TR>
														<TD width="100%" colSpan="4">
															<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR bgColor="lightgrey">
																	<TD class="title" width="100%" colSpan="3" height="10">&nbsp;&nbsp;
																		<FONT color="gray">Domicilio particular</FONT></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="text" width="50%" colSpan="2"><STRONG>Calle:</STRONG>
															<asp:label id="lblCalle" runat="server"></asp:label></TD>
														<TD class="text" width="50%" colSpan="2"><STRONG>Barrio:</STRONG>&nbsp;
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
														<TD class="text" width="50%" colSpan="2"><STRONG>Teléfono:&nbsp;&nbsp; </STRONG>
															<asp:label id="lblTelefono" runat="server"></asp:label></TD>
														<TD class="text" width="50%" colSpan="2"><STRONG>Localidad:&nbsp; </STRONG>
															<asp:label id="lblLocalidad" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD class="text" width="535" colSpan="4">&nbsp;<asp:Label ID="lblObsEMail" runat="server"></asp:Label></TD>
													</TR>
													<TR>
														<TD colSpan="4" style="height: 26px"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<tr>
											<td colspan="4" style="height: 38px">
												<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR bgColor="lightgrey">
														<TD class="title" width="100%" colSpan="3" height="10">&nbsp;&nbsp;
															<FONT color="gray">Estructura familiar (Constituci&oacute;n y ambiente)</FONT></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<tr>
											<td colspan="4">
											<table width="100%" style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3">
											<tr>
											    <td class="text" width="20%" bgColor="lightgrey"><b>Tiene hijos</b></td>
											    <td class="text" width="30%">
                                                    <asp:Label ID="lblTieneHijos" runat="server"></asp:Label></td>
											    <td class="text" width="20%" bgColor="lightgrey"><b>Personas a cargo</b></td>
											    <td class="text" width="30%">
                                                    <asp:Label ID="lblPersACargo" runat="server"></asp:Label></td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table width="100%" style="BORDER-COLLAPSE: collapse" cellSpacing="0" cellPadding="3" borderColor="#111111" border="1">
											<tr bgColor="lightgrey">
											    <td colspan="3" class="text" align="center"><b>Datos de la/las personas</b></td>
											</tr>
											<tr bgColor="lightgrey">
											    <td class="text" align="center"><b>Nombre y Apellido</b></td>
											    <td class="text" align="center" width="200px"><b>Parentezco</b></td>
											    <td class="text" align="center" width="60px"><b>Edad</b></td>
											</tr>
											<tr>
											    <td>&nbsp;<asp:Label ID="lblPersApe1" runat="server"></asp:Label></td>
											    <td>&nbsp;<asp:Label ID="lblPersPar1" runat="server"></asp:Label></td>
											    <td>&nbsp;<asp:Label ID="lblPersEdad1" runat="server"></asp:Label></td>
											</tr>
											<tr>
											    <td>&nbsp;<asp:Label ID="lblPersApe2" runat="server"></asp:Label></td>
											    <td>&nbsp;<asp:Label ID="lblPersPar2" runat="server"></asp:Label></td>
											    <td>&nbsp;<asp:Label ID="lblPersEdad2" runat="server"></asp:Label></td>
											</tr>
											<tr>
											    <td>&nbsp;<asp:Label ID="lblPersApe3" runat="server"></asp:Label></td>
											    <td>&nbsp;<asp:Label ID="lblPersPar3" runat="server"></asp:Label></td>
											    <td>&nbsp;<asp:Label ID="lblPersEdad3" runat="server"></asp:Label></td>
											</tr>
											<tr>
											    <td>&nbsp;<asp:Label ID="lblPersApe4" runat="server"></asp:Label></td>
											    <td>&nbsp;<asp:Label ID="lblPersPar4" runat="server"></asp:Label></td>
											    <td>&nbsp;<asp:Label ID="lblPersEdad4" runat="server"></asp:Label></td>
											</tr>
											<tr>
											    <td>&nbsp;<asp:Label ID="lblPersApe5" runat="server"></asp:Label></td>
											    <td>&nbsp;<asp:Label ID="lblPersPar5" runat="server"></asp:Label></td>
											    <td>&nbsp;<asp:Label ID="lblPersEdad5" runat="server"></asp:Label></td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table width="100%" style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3">
											<tr>
											    <td class="text"><b>Observaciones:&nbsp;</b><asp:Label ID="lblObsPersonales" runat="server"></asp:Label></td>
											</tr>
											<tr>
											    <td class="text">&nbsp</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr>
											<td colspan="4" style="height: 38px">
												<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR bgColor="lightgrey">
														<TD class="title" width="100%" colSpan="3" height="10">&nbsp;&nbsp;
															<FONT color="gray">Movilidad</FONT></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<tr>
											<td colspan="4">
											<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3">
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Propia?&nbsp;&nbsp;</b></td>
											    <td class="text" width="20px" align="center">SI</td>
											    <td class="text" width="20px" align="center">NO</td>
											    <td class="text" bgColor="lightgrey"><b>Multas?&nbsp;&nbsp;</b></td>
											    <td class="text" width="20px" align="center">SI</td>
											    <td class="text" width="20px" align="center">NO</td>
											    <td class="text" bgColor="lightgrey"><b>Cuantas?&nbsp;&nbsp;</b></td>
											    <td class="text" width="30px">&nbsp</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table width="100%" style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3">
											<tr>
											    <td class="text" width="100px" bgColor="lightgrey"><b>Automovil/Moto&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="5" width="20px" align="center">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Estado&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="5" width="20px" align="center">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Modelo&nbsp;&nbsp;</b></td>
											    <td class="text" align="center">&nbsp;</td>
											    <td class="text" width="70px" bgColor="lightgrey"><b>A&ntilde;o&nbsp;&nbsp;</b></td>
											    <td class="text" align="center">&nbsp;</td>
											    <td class="text" width="70px" bgColor="lightgrey"><b>Patente&nbsp;&nbsp;</b></td>
											    <td class="text" align="center">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Seguro&nbsp;&nbsp;</b></td>
											    <td class="text" align="center">&nbsp;</td>
											    <td class="text" bgColor="lightgrey"><b>Compa&ntilde;ia&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="3">&nbsp;</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table width="100%" style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3">
											<tr>
											    <td class="text" width="100px" bgColor="lightgrey"><b>Otros medios&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="5" align="center">&nbsp;</td>
											    <td class="text" width="120px" bgColor="lightgrey"><b>Calidad del servicio&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="5" align="center">&nbsp;</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr>
											<td colspan="4" style="height: 38px">
												<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;
															<FONT color="gray">Estudios cursados</FONT></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<tr>
											<td colspan="4">
											<table width="100%" style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3">
											<tr>
											    <td class="text" width="100px" bgColor="lightgrey"><b>Primarios&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="5" align="center">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Escuela&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="5" align="center">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>T&iacute;tulo&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="5" align="center">&nbsp;</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table width="100%" style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3">
											<tr>
											    <td class="text" width="100px" bgColor="lightgrey"><b>Secundarios&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="5" align="center">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Instituci&oacute;n&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="5" align="center">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>T&iacute;tulo&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="5" align="center">&nbsp;</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table width="100%" style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3">
											<tr>
											    <td class="text" width="100px" bgColor="lightgrey"><b>Terciarios&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="5" align="center">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Instituci&oacute;n&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="5" align="center">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>T&iacute;tulo&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="5" align="center">&nbsp;</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table width="100%" style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3">
											<tr>
											    <td class="text" width="100px" bgColor="lightgrey"><b>Universiarios&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="5" align="center">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Instituci&oacute;n&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="5" align="center">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>T&iacute;tulo&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="5" align="center">&nbsp;</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table width="100%" style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3">
											<tr>
											    <td class="text" width="100px" bgColor="lightgrey"><b>Otros cursos&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="5" align="center">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Idiomas&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="5" align="center">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Computaci&oacute;n&nbsp;&nbsp;</b></td>
											    <td class="text" colspan="5" align="center">&nbsp;</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr>
											<td colspan="4" style="height: 38px">
												<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;
															<FONT color="gray">Trabajos realizados</FONT></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<tr>
											<td colspan="4">
											<table width="100%" style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3">
											<tr>
											    <td class="text" width="100px" bgColor="lightgrey"><b>Empresa&nbsp;&nbsp;</b></td>
											    <td class="text" align="center" colspan="5">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Domicilio&nbsp;&nbsp;</b></td>
											    <td class="text" align="center" colspan="5">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Tel&eacute;fonos&nbsp;&nbsp;</b></td>
											    <td class="text" align="center">&nbsp;</td>
											    <td class="text" bgColor="lightgrey" width="75px"><b>Ingreso&nbsp;&nbsp;</b></td>
											    <td class="text" align="center">&nbsp;</td>
											    <td class="text" bgColor="lightgrey" width="100px"><b>Egreso&nbsp;&nbsp;</b></td>
											    <td class="text" align="center">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Cargo&nbsp;&nbsp;</b></td>
											    <td class="text" align="center" colspan="3">&nbsp;</td>
											    <td class="text" bgColor="lightgrey"><b>U. recibo sueldo&nbsp;&nbsp;</b></td>
											    <td class="text" align="center">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" width="100px" bgColor="lightgrey"><b>Motivo desv.</b></td>
											    <td class="text" align="center" colspan="5">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Contacto&nbsp;&nbsp;</b></td>
											    <td class="text" align="center" colspan="5">&nbsp;</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table width="100%" style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3">
											<tr>
											    <td class="text" width="100px" bgColor="lightgrey"><b>Empresa&nbsp;&nbsp;</b></td>
											    <td class="text" align="center" colspan="5">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Domicilio&nbsp;&nbsp;</b></td>
											    <td class="text" align="center" colspan="5">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Tel&eacute;fonos&nbsp;&nbsp;</b></td>
											    <td class="text" align="center">&nbsp;</td>
											    <td class="text" bgColor="lightgrey" width="75px"><b>Ingreso&nbsp;&nbsp;</b></td>
											    <td class="text" align="center">&nbsp;</td>
											    <td class="text" bgColor="lightgrey" width="100px"><b>Egreso&nbsp;&nbsp;</b></td>
											    <td class="text" align="center">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Cargo&nbsp;&nbsp;</b></td>
											    <td class="text" align="center" colspan="3">&nbsp;</td>
											    <td class="text" bgColor="lightgrey"><b>U. recibo sueldo&nbsp;&nbsp;</b></td>
											    <td class="text" align="center">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" width="100px" bgColor="lightgrey"><b>Motivo desv.</b></td>
											    <td class="text" align="center" colspan="5">&nbsp;</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Contacto&nbsp;&nbsp;</b></td>
											    <td class="text" align="center" colspan="5">&nbsp;</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table width="100%" style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3">
											<tr>
											    <td class="text"><b>Referencias obtenidas:&nbsp;</b></td>
											</tr>
											<tr>
											    <td class="text">&nbsp</td>
											</tr>
											<tr>
											    <td class="text">&nbsp</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr>
											<td colspan="4" style="height: 38px">
												<TABLE id="Table14" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;
															<FONT color="gray">Aspectos generales de la persona</FONT></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<tr>
											<td colspan="4">
											<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3" width="100%">
											<tr>
											    <td class="text" bgColor="lightgrey" width="110px"><b>Miembro de club?&nbsp;&nbsp;</b></td>
											    <td class="text" width="20px" align="center">SI</td>
											    <td class="text" width="20px" align="center">NO</td>
											    <td class="text" bgColor="lightgrey" width="90px"><b>Nombre Club&nbsp;&nbsp;</b></td>
											    <td class="text">&nbsp</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3" width="100%">
											<tr>
											    <td class="text" bgColor="lightgrey" width="130px"><b>Deportes que practica</b></td>
											    <td class="text">&nbsp</td>
											    <td class="text" bgColor="lightgrey" width="110px"><b>Constantemente?&nbsp;&nbsp;</b></td>
											    <td class="text" width="20px" align="center">SI</td>
											    <td class="text" width="20px" align="center">NO</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3" width="100%">
											<tr>
											    <td class="text" bgColor="lightgrey" width="110px"><b>Ideolog&iacute;a Pol&iacute;tica</b></td>
											    <td class="text">&nbsp</td>
											    <td class="text" bgColor="lightgrey" width="110px"><b>Ideolog&iacute;a Religiosa</b></td>
											    <td class="text">&nbsp</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3" width="100%">
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Miembro G. Social?&nbsp;&nbsp;</b></td>
											    <td class="text" width="20px" align="center">SI</td>
											    <td class="text" width="20px" align="center">NO</td>
											    <td class="text" bgColor="lightgrey"><b>Fuma?&nbsp;&nbsp;</b></td>
											    <td class="text" width="20px" align="center">SI</td>
											    <td class="text" width="20px" align="center">NO</td>
											    <td class="text" bgColor="lightgrey"><b>Bebe?&nbsp;&nbsp;</b></td>
											    <td class="text" width="20px" align="center">SI</td>
											    <td class="text" width="20px" align="center">NO</td>
											    <td class="text" bgColor="lightgrey"><b>Medicamento Fijo?&nbsp;&nbsp;</b></td>
											    <td class="text" width="20px" align="center">SI</td>
											    <td class="text" width="20px" align="center">NO</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3" width="100%">
											<tr>
											    <td class="text" bgColor="lightgrey" width="100px"><b>Enfermedades</b></td>
											    <td class="text">&nbsp</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3" width="100%">
											<tr>
											    <td class="text" bgColor="lightgrey"><b>Qu&eacute; tipo de empresa busca?&nbsp;&nbsp;</b></td>
											    <td class="text" width="80px" align="center">Familiar</td>
											    <td class="text" width="80px" align="center">Vertical</td>
											    <td class="text" width="80px" align="center">Horizontal</td>
											    <td class="text" width="80px" align="center">En equipo</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table width="100%" style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3">
											<tr>
											    <td class="text"><b>Antecedentes policiales:&nbsp;</b></td>
											</tr>
											<tr>
											    <td class="text">&nbsp</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table width="100%" style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3">
											<tr>
											    <td class="text"><b>Comentario final:&nbsp;</b></td>
											</tr>
											<tr>
											    <td class="text">&nbsp</td>
											</tr>
											<tr>
											    <td class="text">&nbsp</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr>
											<td colspan="4" style="height: 38px">
												<TABLE id="Table15" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;
															<FONT color="gray">Gesti&oacute;n de tiempo extra laboral</FONT></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<tr>
											<td colspan="4">
											<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3" width="100%">
											<tr>
											    <td class="text" bgColor="lightgrey" width="100px"><b>Ve televisi&oacute;n?&nbsp;&nbsp;</b></td>
											    <td class="text" width="20px" align="center">SI</td>
											    <td class="text" width="20px" align="center">NO</td>
											    <td class="text" bgColor="lightgrey" width="100px"><b>Qu&eacute; programa?&nbsp;&nbsp;</b></td>
											    <td class="text">&nbsp</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3" width="100%">
											<tr>
											    <td class="text" bgColor="lightgrey" width="100px"><b>Lee?&nbsp;&nbsp;</b></td>
											    <td class="text" width="20px" align="center">SI</td>
											    <td class="text" width="20px" align="center">NO</td>
											    <td class="text" bgColor="lightgrey" width="100px"><b>Qu&eacute; lee?&nbsp;&nbsp;</b></td>
											    <td class="text">&nbsp</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table width="100%" style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3">
											<tr>
											    <td class="text"><b>Qu&eacute; haces en tus tiempos libres?:&nbsp;</b></td>
											</tr>
											<tr>
											    <td class="text">&nbsp</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3">
											<tr>
											    <td class="text" bgColor="lightgrey" width="220px"><b>Comparte tiempo con su familia?&nbsp;&nbsp;</b></td>
											    <td class="text" width="20px" align="center">SI</td>
											    <td class="text" width="20px" align="center">NO</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table width="100%" style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3">
											<tr>
											    <td class="text"><b>Actividades con su familia:&nbsp;</b></td>
											</tr>
											<tr>
											    <td class="text">&nbsp</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr>
											<td colspan="4" style="height: 38px">
												<TABLE id="Table16" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;
															<FONT color="gray">Datos de la vivienda y el entorno</FONT></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<tr>
											<td colspan="4">
											<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3" width="100%">
											<tr>
											    <td class="text" bgColor="lightgrey" width="80px"><b>Antiguedad</b></td>
											    <td class="text" width="80px">&nbsp</td>
											    <td class="text" bgColor="lightgrey" width="90px"><b>M. Alquiler</b></td>
											    <td class="text">&nbsp</td>
											    <td class="text" bgColor="lightgrey" width="110px"><b>Venc. de contrato</b></td>
											    <td class="text">&nbsp</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3" width="100%">
											<tr>
											    <td class="text" bgColor="lightgrey" width="100px"><b>Tel. Alternativo</b></td>
											    <td class="text" width="140px">&nbsp</td>
											    <td class="text" bgColor="lightgrey" width="110px"><b>Acceso al domicilio</b></td>
											    <td class="text">&nbsp</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3" width="100%">
											<tr>
											    <td class="text" bgColor="lightgrey" width="100px"><b>Vive en caracter de</b></td>
											    <td class="text">&nbsp</td>
											    <td class="text" bgColor="lightgrey" width="100px"><b>Tipo de vivienda</b></td>
											    <td class="text">&nbsp</td>
											    <td class="text" bgColor="lightgrey" width="105px"><b>Estado de conservaci&oacute;n</b></td>
											    <td class="text">&nbsp</td>
											</tr>
											<tr>
											    <td class="text" bgColor="lightgrey" width="100px"><b>Tipo de construcci&oacute;n</b></td>
											    <td class="text">&nbsp</td>
											    <td class="text" bgColor="lightgrey" width="100px"><b>Tipo de zona</b></td>
											    <td class="text">&nbsp</td>
											    <td class="text" bgColor="lightgrey" width="100px"><b>Tipo de calle</b></td>
											    <td class="text">&nbsp</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3" width="100%">
											<tr>
											    <td class="text" bgColor="lightgrey" width="70px"><b>Cant. Tel.?</b></td>
											    <td class="text" width="70px">&nbsp</td>
											    <td class="text" bgColor="lightgrey" width="65px"><b>Televisi&oacute;n</b></td>
											    <td class="text" align="center" width="40px">Aire</td>
											    <td class="text" align="center" width="40px">Cable&nbsp;<b>&gt;</b></td>
											    <td class="text" bgColor="lightgrey" width="40px"><b>Cual?</b></td>
											    <td class="text">&nbsp</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3" width="100%">
											<tr>
											    <td class="text" bgColor="lightgrey" width="80px"><b>Computadora</b></td>
											    <td class="text" align="center" width="20px">SI</td>
											    <td class="text" align="center" width="20px">NO</td>
											    <td class="text" bgColor="lightgrey" width="50px"><b>Internet</b></td>
											    <td class="text" align="center" width="25px">NO</td>
											    <td class="text" align="center" width="25px">SI&nbsp;<b>&gt;</b></td>
											    <td class="text" bgColor="lightgrey" width="40px"><b>Cual?</b></td>
											    <td class="text">&nbsp</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr>
											<td colspan="4" style="height: 38px">
												<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;
															<FONT color="gray">Referencia vecinal</FONT></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<tr>
											<td colspan="4">
											<table width="100%" style="BORDER-COLLAPSE: collapse" cellSpacing="0" cellPadding="3" borderColor="#111111" border="1">
											<tr bgColor="lightgrey">
											    <td class="text" align="center" width="300px"><b>Nombre y Apellido</b></td>
											    <td class="text" align="center" width="200px"><b>Domicilio</b></td>
											    <td class="text" align="center"><b>Conoce a la persona</b></td>
											</tr>
											<tr>
											    <td>&nbsp;</td>
											    <td>&nbsp;</td>
											    <td>&nbsp;</td>
											</tr>
											<tr>
											    <td>&nbsp;</td>
											    <td>&nbsp;</td>
											    <td>&nbsp;</td>
											</tr>
											<tr>
											    <td>&nbsp;</td>
											    <td>&nbsp;</td>
											    <td>&nbsp;</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table width="100%" style="BORDER-COLLAPSE: collapse" borderColor="#111111" border="1" cellSpacing="0" cellPadding="3">
											<tr>
											    <td class="text"><b>Observaciones:&nbsp;</b><asp:Label ID="Label2" runat="server"></asp:Label></td>
											</tr>
											<tr>
											    <td class="text">&nbsp</td>
											</tr>
											</table>
											</td>
										</tr>
										<tr><td height="5px"></td></tr>
										<tr>
											<td colspan="4">
											<table width="100%">
										    <TR>
											    <TD class="text" colSpan="4">&nbsp;<BR>
												    <STRONG>Plano de&nbsp;ubicación:</STRONG></TD>
										    </TR>
										    <TR>
											    <TD class="text" align="center">
												    <P align="center"><IMG height="140" src="/img/plano_chico.gif" width="140" border="1">
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
										    </td>
									    </tr>
									</TABLE>
								</TD>
							</TR>
									<!--	-->
									
							<TR>
								<TD width="100%" colSpan="4"><div style="font-size:10px; margin-top:10px; line-height:1.5">
									Este informe es confidencial y solo puede ser usado para la 
										evaluación y otorgamiento de créditos o celebración de negocios. Esta prohibida 
										su reproducción, divulgación y entrega a terceros.<BR>
										No significa emitir juicio de valor sobre las personas ni sobre su 
										solvencia. Las <U>decisiones a las que arribe el usuario son de su exclusiva 
											responsabilidad.</U><br />
											www.tiempoygestion.com.ar &nbsp;&nbsp;//&nbsp;&nbsp; informes@tiempoygestion.com.ar
											</div></TD>
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
