<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.socioAmbiental.verInforme" CodeFile="VerInforme.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Informe Socio Ambiental / Preocupacional</title>
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
							<asp:Label ID="lblTools" Runat="server"></asp:Label>
						</div>
					</td>
				</tr>
			</TABLE>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" class="tablaInforme">
				<TR>
					<td><IMG alt="" src="/img/logo-20-anios.png" width="264"></td>
					<TD class="title" width="100%" align="center">
<table width="370" cellpadding="0" cellspacing="0" border="0">
<tr>
<td width="16"><img src="/Img/rounded1.gif" width="16" height="16" border="0"></td>
<td width="168" style="background-image: url('/Img/back1.gif');"><img src="/Img/shim.gif" width="1" height="16" border="0"/></td>
<td width="16"><img src="/Img/rounded2.gif" width="16" height="16" border="0"></td>
</tr>

<tr>
<td style="background-image: url('/Img/back4.gif');"><img src="/Img/shim.gif" width="16" height="1" border="0" /></td>
<td class="title" width="100%" align="center">Informe Socio Ambiental / Preocupacional</td>
<td style="background-image: url('/Img/back2.gif');"><img src="/Img/shim.gif" width="16" height="1" border="0"/></td>
</tr>

<tr>
<td><img src="/Img/rounded3.gif" width="16" height="16" border="0"></td>
<td style="background-image: url('/Img/back3.gif');"><img src="/Img/shim.gif" width="1" height="16" border="0" /></td>
<td><img src="/Img/rounded4.gif" width="16" height="16" border="0"></td>
</tr>
</table></TD>
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
												&nbsp; Solicitado por:
												<asp:label id="lblSolicitante" runat="server" Font-Bold="True"></asp:label><br />
												&nbsp;Dirección: <asp:label id="lblDireccionSolicitante" runat="server" Font-Size="9"></asp:label>
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
									<asp:label id="lblNum" runat="server" Font-Bold="True" Width="10"></asp:label>
								</td>
							</tr>
						</TABLE>
					</td>
				</tr>
				
				</TABLE>
				<%--<tr>
					<td class="title" width="100%" colSpan="2">
						<HR>
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="100%" colSpan="4">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="text" width="100%" colspan="4">
												<asp:panel id="pnlFisica" runat="server">--%>
												  <TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0" bgColor="lightgrey">
									                <TR>
										                <TD class="title" width="100%" colSpan="3" height="10">&nbsp;&nbsp;Datos personales</TD>
									                </TR>
								                  </TABLE>
                                                  <TABLE class="tablaInforme" id=Table3 style="BORDER-COLLAPSE: collapse" borderColor=#111111 cellSpacing=0 cellPadding=3 width="100%" border=1>
                                                    <TR>
                                                      <TD vAlign=top width="25%" class="text">
                                                        <STRONG>Apellido y nombre:</STRONG>&nbsp;<BR>
                                                        <asp:label id=lblApellido runat="server"></asp:label>, <asp:label id=lblNombre runat="server"></asp:label>
                                                      </TD>
                                                      <TD class=text vAlign=top width="25%">
                                                        <STRONG>Tipo y nº documento:&nbsp;</STRONG> 
                                                        <asp:label id=lblTipoDocumento runat="server"></asp:label>&nbsp;<asp:label id=lblDocumento runat="server"></asp:label>
                                                      </TD>
                                                      <TD class=text vAlign=top width="25%" colSpan=2>
                                                        <STRONG>Estado civil:</STRONG> 
                                                        <asp:label id=lblEstadoCivil runat="server"></asp:label>
                                                      </TD>
                                                    </TR>
                                                    <TR>
                                                      <TD width="99%" colSpan=4>&nbsp;</TD>
                                                    </TR>
                                                  </TABLE>
                                                  <TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0" bgColor="lightgrey">
									                <TR>
										                <TD class="title" width="100%" colSpan="3" height="10">&nbsp;&nbsp;Domicilio particular</TD>
									                </TR>
								                  </TABLE>
                                                  <TABLE class="tablaInforme" id=Table7 style="BORDER-COLLAPSE: collapse" borderColor=#111111 cellSpacing=0 cellPadding=3 width="100%" border=1>
                                                    <TR>
                                                      <TD class=text width="100%" colSpan=4>
                                                        <STRONG>Calle:</STRONG> 
                                                        <asp:label id=lblCalle runat="server"></asp:label>
                                                      </TD>
                                                    </TR>
                                                    <TR>
                                                      <TD class=text width="25%">
                                                        <STRONG>Nro:</STRONG> 
                                                        <asp:label id=lblNro runat="server"></asp:label>
                                                      </TD>
                                                      <TD class=text width="25%">
                                                        <STRONG>Piso:</STRONG> 
                                                        <asp:label id=lblPiso runat="server"></asp:label>
                                                      </TD>
                                                      <TD class=text width="25%">
                                                        <STRONG>Depto.:</STRONG> 
                                                        <asp:label id=lblDepto runat="server"></asp:label>
                                                      </TD>
                                                      <TD class=text width="25%">
                                                        <STRONG>C.P.:</STRONG> 
                                                        <asp:label id=lblCP runat="server"></asp:label>
                                                      </TD>
                                                    </TR>
                                                    <TR>
                                                      <TD class=text width="50%" colSpan=2>
                                                        <STRONG>Barrio:</STRONG>&nbsp; 
                                                        <asp:label id=lblBarrio runat="server"></asp:label>
                                                      </TD>
                                                      <TD class=text width="50%" colSpan=2>
                                                        <STRONG>Teléfono:&nbsp;&nbsp; </STRONG>
                                                        <asp:label id=lblTelefono runat="server"></asp:label>
                                                      </TD>
                                                    </TR>
                                                    <TR>
                                                      <TD class=text width="50%" colSpan=2>
                                                        <STRONG>Provincia:&nbsp; </STRONG>
                                                        <asp:label id=lblProvincia runat="server"></asp:label>
                                                      </TD>
                                                      <TD class=text width="50%" colSpan=2>
                                                        <STRONG>Localidad:&nbsp; </STRONG>
                                                        <asp:label id=lblLocalidad runat="server"></asp:label>
                                                      </TD>
                                                    </TR>
                                                    <TR>
                                                      <TD class=text width=535 colSpan=4>&nbsp;</TD>
                                                    </TR>
                                                  </TABLE>
                                                  <TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0" bgColor="lightgrey">
									                <TR>
										                <TD class="title" width="100%" colSpan="3" height="10">&nbsp;&nbsp;Estructura familiar (Constituci&oacute;n y ambiente)</TD>
									                </TR>
								                  </TABLE>
                                                  <TABLE class="tablaInforme" id=Table8 style="BORDER-COLLAPSE: collapse" borderColor=#111111 cellSpacing=0 cellPadding=3 width="100%" border=1>
                                                    <TR>
                                                      <TD class=text width="50%" colSpan=2>
                                                        <STRONG>Tiene hijos:</STRONG> 
                                                        <asp:label id=lblTieneHijos runat="server"></asp:label>
                                                      </TD>
                                                      <TD class=text width="50%" colSpan=2>
                                                        <STRONG>Personas a cargo:</STRONG> 
                                                        <asp:label id=lblPersACargo runat="server"></asp:label>
                                                      </TD>
                                                    </TR>
                                                    <tr><td colspan="4">&nbsp;</td></tr>
                                                    <TR>
                                                      <TD class=text width="50%" colSpan=2 align="center">
                                                        <STRONG>Apellido y Nombre</STRONG> 
                                                      </TD>
                                                      <TD class=text width="25%" align="center">
                                                        <STRONG>Parentezco</STRONG> 
                                                      </TD>
                                                      <TD class=text width="25%" align="center">
                                                        <STRONG>Edad</STRONG> 
                                                      </TD>
                                                    </TR>
                                                    <TR>
                                                      <TD class=text width="50%" colSpan=2>
                                                        <asp:label id=lblPersApe1 runat="server"></asp:label>&nbsp; 
                                                      </TD>
                                                      <TD class=text width="25%">
                                                        <asp:label id=lblPersPar1 runat="server"></asp:label>&nbsp; 
                                                      </TD>
                                                      <TD class=text width="25%">
                                                        <asp:label id=lblPersEdad1 runat="server"></asp:label>&nbsp; 
                                                      </TD>
                                                    </TR>
                                                    <TR>
                                                      <TD class=text width="50%" colSpan=2>
                                                        <asp:label id=lblPersApe2 runat="server"></asp:label>&nbsp; 
                                                      </TD>
                                                      <TD class=text width="25%">
                                                        <asp:label id=lblPersPar2 runat="server"></asp:label>&nbsp; 
                                                      </TD>
                                                      <TD class=text width="25%">
                                                        <asp:label id=lblPersEdad2 runat="server"></asp:label>&nbsp; 
                                                      </TD>
                                                    </TR>
                                                    <TR>
                                                      <TD class=text width="50%" colSpan=2>
                                                        <asp:label id=lblPersApe3 runat="server"></asp:label>&nbsp; 
                                                      </TD>
                                                      <TD class=text width="25%">
                                                        <asp:label id=lblPersPar3 runat="server"></asp:label>&nbsp; 
                                                      </TD>
                                                      <TD class=text width="25%">
                                                        <asp:label id=lblPersEdad3 runat="server"></asp:label>&nbsp; 
                                                      </TD>
                                                    </TR>
                                                    <TR>
                                                      <TD class=text width="50%" colSpan=2>
                                                        <asp:label id=lblPersApe4 runat="server"></asp:label>&nbsp; 
                                                      </TD>
                                                      <TD class=text width="25%">
                                                        <asp:label id=lblPersPar4 runat="server"></asp:label>&nbsp; 
                                                      </TD>
                                                      <TD class=text width="25%">
                                                        <asp:label id=lblPersEdad4 runat="server"></asp:label>&nbsp; 
                                                      </TD>
                                                    </TR>
                                                    <TR>
                                                      <TD class=text width="50%" colSpan=2>
                                                        <asp:label id=lblPersApe5 runat="server"></asp:label>&nbsp; 
                                                      </TD>
                                                      <TD class=text width="25%">
                                                        <asp:label id=lblPersPar5 runat="server"></asp:label>&nbsp; 
                                                      </TD>
                                                      <TD class=text width="25%">
                                                        <asp:label id=lblPersEdad5 runat="server"></asp:label>&nbsp; 
                                                      </TD>
                                                    </TR>
                                                    <tr><td colspan="4" class="text"><strong>Observaciones:</strong><asp:label id=lblObsPersonales runat="server"></asp:label>&nbsp;</td></tr>
                                                    <tr><td colspan="4" class="text">&nbsp;</td></tr>
                                                   </TABLE>
                                                   <TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0" bgColor="lightgrey">
									                <TR>
										                <TD class="title" width="100%" colSpan="3" height="10">&nbsp;&nbsp;Movilidad</TD>
									                </TR>
								                   </TABLE>
								                   <TABLE class="tablaInforme" id=Table12 style="BORDER-COLLAPSE: collapse" borderColor=#111111 cellSpacing=0 cellPadding=3 width="100%" border=1>
								                   <tr>
								                        <td class="text" width="90px"><b>Propia?</b></td>
								                        <td class="text"><asp:label id="lblMovPropia" runat="server">&nbsp;</asp:label></td>
								                        <td class="text" width="60px"><b>Multas?</b></td>
								                        <td class="text"><asp:label id="lblMovMultas" runat="server">&nbsp;</asp:label></td>
								                        <td class="text" width="60px"><b>Cuantas?</b></td>
								                        <td class="text"><asp:label id="lblMovCuantas" runat="server">&nbsp;</asp:label></td>
								                   </tr>								                   
								                   <tr>
								                        <td colspan="6">&nbsp;</td>
								                   </tr>
								                   <tr>
								                        <td class="text"><b>Autom&oacute;vil/Moto</b></td>
								                        <td class="text" colspan="5"><asp:label id="lblAutomoto" runat="server">&nbsp;</asp:label></td>
								                   </tr>
								                   <tr>
								                        <td class="text"><b>Estado</b></td>
								                        <td class="text" colspan="5"><asp:label id="lblEstadoAutomoto" runat="server">&nbsp;</asp:label></td>
								                   </tr>
								                   <tr>
								                        <td class="text"><b>Modelo</b></td>
								                        <td class="text"><asp:label id="lblModeloAuto" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><b>A&ntilde;o</b></td>
								                        <td class="text"><asp:label id="lblAnioAuto" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><b>Patente</b></td>
								                        <td class="text"><asp:label id="lblPatenteAuto" runat="server">&nbsp;</asp:label></td>
								                   </tr>						
								                   <tr>
								                        <td class="text"><b>Seguro</b></td>
								                        <td class="text"><asp:label id="lblSeguroAuto" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><b>Compa&ntilde;ia</b></td>
								                        <td class="text" colspan="3"><asp:label id="lblCompaniaAuto" runat="server">&nbsp;</asp:label></td>
								                   </tr>						
								                   <tr>
								                        <td colspan="6">&nbsp;</td>
								                   </tr>		              
								                   <tr>
								                        <td class="text"><b>Otros medios</b></td>
								                        <td class="text" colspan="2"><asp:label id="lblOtrosMedios" runat="server">&nbsp;</asp:label></td>
								                        <td class="text" width="120px"><b>Calidad del servicio</b></td>
								                        <td class="text" colspan="2"><asp:label id="lblCalidadMedios" runat="server">&nbsp;</asp:label></td>
								                   </tr>	
								                   <tr>
								                        <td colspan="6">&nbsp;</td>
								                   </tr>							                        		                   
								                   </TABLE>
								                   <TABLE id="Table18" cellSpacing="0" cellPadding="0" width="100%" border="0" bgColor="lightgrey">
									                <TR>
										                <TD class="title" width="100%" colSpan="3" height="10">&nbsp;&nbsp;Aspectos generales de la persona</TD>
									                </TR>
								                   </TABLE>
								                   <TABLE class="tablaInforme" id=Table19 style="BORDER-COLLAPSE: collapse; page-break-after: always" borderColor=#111111 cellSpacing=0 cellPadding=3 width="100%" border=1>
								                    <tr>
								                        <td class="text"><b>Miembro de club?</b></td>
								                        <td class="text"><asp:label id="lblParteClub" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><b>Nombre club</b></td>
								                        <td class="text" colspan="5"><asp:label id="lblClub" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><b>Deportes que practica</b></td>
								                        <td class="text" colspan="5"><asp:label id="lblDeportes" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><b>Constantemente?</b></td>
								                        <td class="text"><asp:label id="lblConstante" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><b>Ideolog&iacute;a Pol&iacute;tica</b></td>
								                        <td class="text" colspan="3"><asp:label id="lblIPolitica" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><b>Ideolog&iacute;a Religiosa</b></td>
								                        <td class="text" colspan="3"><asp:label id="lblIReligiosa" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text" width="125px"><b>Miembro G. Social?</b></td>
								                        <td class="text" width="50px"><asp:label id="lblGSocial" runat="server">&nbsp;</asp:label></td>
								                        <td class="text" width="75px"><b>Fuma?</b></td>
								                        <td class="text" width="50px"><asp:label id="lblFuma" runat="server">&nbsp;</asp:label></td>
								                        <td class="text" width="110px"><b>Bebe?</b></td>
								                        <td class="text" width="50px"><asp:label id="lblBebe" runat="server">&nbsp;</asp:label></td>
								                        <td class="text" width="110px"><b>Medicamento Fijo?</b></td>
								                        <td class="text" width="50px"><asp:label id="lblMedFijo" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><b>Enfermedades</b></td>
								                        <td class="text" colspan="7"><asp:label id="lblEnfermedades" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text" colspan="3"><b>Qu&eacute; tipo de empresa busca?</b></td>
								                        <td class="text" colspan="5"><asp:label id="lblTipoEmpresa" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text" colspan="8"><b>Antecedentes policiales:</b><asp:label id="lblPoliciales" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text" colspan="8"><b>Comentario:</b><asp:label id="lblComFinal" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text" colspan="8">&nbsp;</td>
								                    </tr>
								                   </TABLE>
								                   <TABLE id="Table14" cellSpacing="0" cellPadding="0" width="100%" border="0" bgColor="lightgrey">
									                <TR>
										                <TD class="title" width="100%" colSpan="3" height="10">&nbsp;&nbsp;Estudios cursados</TD>
									                </TR>
								                   </TABLE>
								                   <TABLE class="tablaInforme" id=Table15 style="BORDER-COLLAPSE: collapse" borderColor=#111111 cellSpacing=0 cellPadding=3 width="100%" border=1>
								                   <tr>
								                        <td class="text" width="90px"><b>Primarios</b></td>
								                        <td class="text"><asp:label id="lblEstPrimario" runat="server">&nbsp;</asp:label></td>
								                   </tr>
								                   <tr>
								                        <td class="text"><b>Escuela</b></td>
								                        <td class="text"><asp:label id="lblEstabPrimario" runat="server">&nbsp;</asp:label></td>
								                   </tr>
								                   <tr>
								                        <td class="text"><b>T&iacute;tulo</b></td>
								                        <td class="text"><asp:label id="lblTitPrimario" runat="server">&nbsp;</asp:label></td>
								                   </tr>
								                   <tr>
								                        <td colspan="2">&nbsp;</td>
								                   </tr>
								                   <tr>
								                        <td class="text"><b>Secundarios</b></td>
								                        <td class="text"><asp:label id="lblEstSecundario" runat="server">&nbsp;</asp:label></td>
								                   </tr>
								                   <tr>
								                        <td class="text"><b>Instituci&oacute;n</b></td>
								                        <td class="text"><asp:label id="lblEstabSecundario" runat="server">&nbsp;</asp:label></td>
								                   </tr>
								                   <tr>
								                        <td class="text"><b>T&iacute;tulo</b></td>
								                        <td class="text"><asp:label id="lblTitSecundario" runat="server">&nbsp;</asp:label></td>
								                   </tr>
								                   <tr>
								                        <td colspan="2">&nbsp;</td>
								                   </tr>
								                   <tr>
								                        <td class="text"><b>Terciarios</b></td>
								                        <td class="text"><asp:label id="lblEstTerciario" runat="server">&nbsp;</asp:label></td>
								                   </tr>
								                   <tr>
								                        <td class="text"><b>Instituci&oacute;n</b></td>
								                        <td class="text"><asp:label id="lblEstabTerciario" runat="server">&nbsp;</asp:label></td>
								                   </tr>
								                   <tr>
								                        <td class="text"><b>T&iacute;tulo</b></td>
								                        <td class="text"><asp:label id="lblTitTerciario" runat="server">&nbsp;</asp:label></td>
								                   </tr>
								                   <tr>
								                        <td colspan="2">&nbsp;</td>
								                   </tr>
								                   <tr>
								                        <td class="text"><b>Universitarios</b></td>
								                        <td class="text"><asp:label id="lblEstUniversitario" runat="server">&nbsp;</asp:label></td>
								                   </tr>
								                   <tr>
								                        <td class="text"><b>Instituci&oacute;n</b></td>
								                        <td class="text"><asp:label id="lblEstabUniversitario" runat="server">&nbsp;</asp:label></td>
								                   </tr>
								                   <tr>
								                        <td class="text"><b>T&iacute;tulo</b></td>
								                        <td class="text"><asp:label id="lblTitUniversitario" runat="server">&nbsp;</asp:label></td>
								                   </tr>
								                   <tr>
								                        <td colspan="2">&nbsp;</td>
								                   </tr>
								                   <tr>
								                        <td class="text"><b>Otros cursos</b></td>
								                        <td class="text"><asp:label id="lblOtrosCursos" runat="server">&nbsp;</asp:label></td>
								                   </tr>
								                   <tr>
								                        <td class="text"><b>Idiomas</b></td>
								                        <td class="text"><asp:label id="lblIdiomas" runat="server">&nbsp;</asp:label></td>
								                   </tr>
								                   <tr>
								                        <td class="text"><b>Computaci&oacute;n</b></td>
								                        <td class="text"><asp:label id="lblComputacion" runat="server">&nbsp;</asp:label></td>
								                   </tr>
								                   <tr>
								                        <td colspan="2">&nbsp;</td>
								                   </tr>
								                   </TABLE>
								                   <TABLE id="Table16" cellSpacing="0" cellPadding="0" width="100%" border="0" bgColor="lightgrey">
									                <TR>
										                <TD class="title" width="100%" colSpan="3" height="10">&nbsp;&nbsp;Trabajos realizados</TD>
									                </TR>
								                   </TABLE>
								                   <TABLE class="tablaInforme" id=Table17 style="BORDER-COLLAPSE: collapse" borderColor=#111111 cellSpacing=0 cellPadding=3 width="100%" border=1>
								                    <tr>
								                        <td class="text"><b>Empresa</b></td>
								                        <td class="text" colspan="5"><asp:label id="lblEmpresa1" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><b>Domicilio</b></td>
								                        <td class="text" colspan="5"><asp:label id="lblDomEmpresa1" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text" width="80px"><b>Tel&eacute;fonos</b></td>
								                        <td class="text"><asp:label id="lblTelEmpresa1" runat="server">&nbsp;</asp:label></td>
								                        <td class="text" width="60px"><b>Ingreso</b></td>
								                        <td class="text"><asp:label id="lblFecIngEmpresa1" runat="server">&nbsp;</asp:label></td>
								                        <td class="text" width="100px"><b>Egreso</b></td>
								                        <td class="text"><asp:label id="lblFecEgEmpresa1" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><b>Cargo</b></td>
								                        <td class="text" colspan="3"><asp:label id="lblCargoEmpresa1" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><b>U. recibo sueldo</b></td>
								                        <td class="text"><asp:label id="lblUltSueldoEmpresa1" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><b>Motivo desv.</b></td>
								                        <td class="text" colspan="5"><asp:label id="lblDesvEmpresa1" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><b>Contacto</b></td>
								                        <td class="text" colspan="5"><asp:label id="lblContactoEmpresa1" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td colspan="6">&nbsp;</td>								                    
								                    </tr>
								                    <tr>
								                        <td class="text"><b>Empresa</b></td>
								                        <td class="text" colspan="5"><asp:label id="lblEmpresa2" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><b>Domicilio</b></td>
								                        <td class="text" colspan="5"><asp:label id="lblDomEmpresa2" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text" width="80px"><b>Tel&eacute;fonos</b></td>
								                        <td class="text"><asp:label id="lblTelEmpresa2" runat="server">&nbsp;</asp:label></td>
								                        <td class="text" width="60px"><b>Ingreso</b></td>
								                        <td class="text"><asp:label id="lblFecIngEmpresa2" runat="server">&nbsp;</asp:label></td>
								                        <td class="text" width="100px"><b>Egreso</b></td>
								                        <td class="text"><asp:label id="lblFecEgEmpresa2" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><b>Cargo</b></td>
								                        <td class="text" colspan="3"><asp:label id="lblCargoEmpresa2" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><b>U. recibo sueldo</b></td>
								                        <td class="text"><asp:label id="lblUltSueldoEmpresa2" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><b>Motivo desv.</b></td>
								                        <td class="text" colspan="5"><asp:label id="lblDesvEmpresa2" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><b>Contacto</b></td>
								                        <td class="text" colspan="5"><asp:label id="lblContactoEmpresa2" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td colspan="6">&nbsp;</td>								                    
								                    </tr>
								                     <tr>
								                        <td colspan="6" class="text"><b>Referencias obtenidas:</b><asp:label id="lblRefLaborales" runat="server">&nbsp;</asp:label></td>								                    
								                    </tr>
								                    <tr>
								                        <td colspan="6">&nbsp;</td>								                    
								                    </tr>
								                   </TABLE>
								                   <TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%" border="0" bgColor="lightgrey">
									                <TR>
										                <TD class="title" width="100%" colSpan="3" height="10">&nbsp;&nbsp;Gesti&oacute;n de tiempo extra laboral</TD>
									                </TR>
								                   </TABLE>
								                   <TABLE class="tablaInforme" id=Table21 style="BORDER-COLLAPSE: collapse; page-break-after: always" borderColor=#111111 cellSpacing=0 cellPadding=3 width="100%" border=1>
								                    <tr>
								                        <td class="text"><b>Ve televisi&oacute;n?</b></td>
								                        <td class="text" width="50px"><asp:label id="lblTelevision" runat="server">&nbsp;</asp:label></td>
								                        <td class="text" width="100px"><b>Qu&eacute; programa?</b></td>
								                        <td class="text" width="360px"><asp:label id="lblPrograma" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><b>Lee?</b></td>
								                        <td class="text"><asp:label id="lblLee" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><b>Qu&eacute; lee?</b></td>
								                        <td class="text"><asp:label id="lblQLee" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td colspan="4" class="text"><b>Qu&eacute; haces en tus tiempos libres?:</b><asp:label id="lblTiempoLibre" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text" colspan="2"><b>Comparte tiempo con su familia?</b></td>
								                        <td class="text" colspan="2"><asp:label id="lblTiempoFamilia" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td colspan="4" class="text"><b>Actividades con su familia:</b><asp:label id="lblActFamiliar" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td colspan="4" class="text">&nbsp;</td>
								                    </tr>
								                   </TABLE>
								                   <TABLE id="Table22" cellSpacing="0" cellPadding="0" width="100%" border="0" bgColor="lightgrey">
									                <TR>
										                <TD class="title" width="100%" colSpan="3" height="10">&nbsp;&nbsp;Datos de la vivienda y el entorno</TD>
									                </TR>
								                   </TABLE>
								                   <TABLE class="tablaInforme" id=Table23 style="BORDER-COLLAPSE: collapse" borderColor=#111111 cellSpacing=0 cellPadding=3 width="100%" border=1>
								                    <tr>
								                        <td class="text" width="90px"><b>Antiguedad</b></td>
								                        <td class="text" width="120px"><asp:label id="lblAntiguedad" runat="server">&nbsp;</asp:label></td>
								                        <td class="text" width="70px"><b>M. Alquiler</b></td>
								                        <td class="text" width="120px"><asp:label id="lblMontoAlquiler" runat="server">&nbsp;</asp:label></td>
								                        <td class="text" width="100px"><b>Venc. de contrato</b></td>
								                        <td class="text"><asp:label id="lblVencimiento" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><b>Tel. Alternativo</b></td>
								                        <td class="text" colspan="2"><asp:label id="lblTelAlt" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><b>Acceso al domicilio</b></td>
								                        <td class="text" colspan="2"><asp:label id="lblAccesoDomicilio" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><b>Vive en<br />caracter de</b></td>
								                        <td class="text"><asp:label id="lblInteresado" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><b>Tipo de<br />vivienda</b></td>
								                        <td class="text"><asp:label id="lblTipoVivienda" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><b>Estado de<br />conservaci&oacute;n</b></td>
								                        <td class="text"><asp:label id="lblEstadoCons" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><b>Tipo de<br />construcci&oacute;n</b></td>
								                        <td class="text"><asp:label id="lblTipoConstruccion" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><b>Tipo zona</b></td>
								                        <td class="text"><asp:label id="lblTipoZona" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><b>Tipo de calle</b></td>
								                        <td class="text"><asp:label id="lblTipoCalle" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><b>Cant. Tel?</b></td>
								                        <td class="text"><asp:label id="lblCantTel" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><b>Televisi&oacute;n</b></td>
								                        <td class="text"><asp:label id="lblTipoTele" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><b>Cual?</b></td>
								                        <td class="text"><asp:label id="lblEmpresaCable" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><b>Computadora</b></td>
								                        <td class="text"><asp:label id="lblComputadora" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><b>Internet</b></td>
								                        <td class="text"><asp:label id="lblInternet" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><b>Cual?</b></td>
								                        <td class="text"><asp:label id="lblEmpresaInternet" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text" colspan="6">&nbsp;</td>
								                    </tr>
								                   </TABLE>
								                   <TABLE id="Table24" cellSpacing="0" cellPadding="0" width="100%" border="0" bgColor="lightgrey">
									                <TR>
										                <TD class="title" width="100%" colSpan="3" height="10">&nbsp;&nbsp;Referencia vecinal</TD>
									                </TR>
								                   </TABLE>
								                   <TABLE class="tablaInforme" id=Table25 style="BORDER-COLLAPSE: collapse" borderColor=#111111 cellSpacing=0 cellPadding=3 width="100%" border=1>
								                    <tr>
								                        <td class="text" align="center"><b>Nombre y Apellido</b></td>
								                        <td class="text" align="center"><b>Domicilio</b></td>
								                        <td class="text" align="center"><b>Conoce a la persona</b></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><asp:label id="lblNombreVecino1" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><asp:label id="lblDomicilioVecino1" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><asp:label id="lblConoceVecino1" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><asp:label id="lblNombreVecino2" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><asp:label id="lblDomicilioVecino2" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><asp:label id="lblConoceVecino2" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text"><asp:label id="lblNombreVecino3" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><asp:label id="lblDomicilioVecino3" runat="server">&nbsp;</asp:label></td>
								                        <td class="text"><asp:label id="lblConoceVecino3" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <tr>
								                        <td class="text" colspan="3">&nbsp;</td>
								                    </tr>
								                    <tr>
								                        <td class="text" colspan="3"><b>Observaciones:</b><asp:label id="lblObservaciones" runat="server">&nbsp;</asp:label></td>
								                    </tr>
								                    <TR>
											            <TD class="text" colSpan="3"><STRONG>Plano de ubicación:</STRONG></TD>
										            </TR>
										            <TR>
											            <TD class="text" align="center">
												            <P align="center"><IMG height=140 src="/img/plano_chico.gif" width=140 border=1>&nbsp;</P>
											            </TD>
											            <TD vAlign="top" colSpan="2">
												            <TABLE class="text" id="Table26" cellSpacing="1" cellPadding="2">
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
										        <%--</asp:panel>
								</TD>
							</TR>
							<tr>
								<td colspan="3" class="text" align="center">
									<br>
									<asp:Image id="imgFoto" runat="server"></asp:Image>
								</td>
							</tr>--%>
							<TABLE class=text id=Table1 style="BORDER-COLLAPSE: collapse" borderColor=#111111 cellSpacing=0 cellPadding=3 width="100%" border=1>
							<TR>
								<TD width="100%" colSpan="4"><div style="font-size:9px; margin-top:10px; line-height:1.5">
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
					<%--	<BR>
					</td>
				</tr>
				<tr>
					<td width="100%" colSpan="2"></td>
				</tr>
			</TABLE>--%>
			<input id="idEncabezado" type="hidden" name="idEncabezado" runat="server"> <input id="idReferencia" type="hidden" name="idReferencia" runat="server">
            <asp:Panel ID="pnFotos" runat="server">
        <hr style="page-break-after:always; border:0px; height:0px;" />
        			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" class="tablaInforme">
				<TR>
								<td><IMG alt="" src="/img/logo-20-anios.png" width="264"></td>
								<TD class="title" width="100%" align="right">
									<table width="370" cellpadding="0" cellspacing="0" border="0">
<tr>
<td width="16"><img src="/Img/rounded1.gif" width="16" height="16" border="0"></td>
<td width="168" style="background-image: url('/Img/back1.gif');"><img src="/Img/shim.gif" width="1" height="16" border="0"/></td>
<td width="16"><img src="/Img/rounded2.gif" width="16" height="16" border="0"></td>
</tr>

<tr>
<td style="background-image: url('/Img/back4.gif');"><img src="/Img/shim.gif" width="16" height="1" border="0" /></td>
<td class="title" width="100%" align="center"><FONT color="#32528e">Informe Socio Ambiental / Preocupacional</FONT></td>
<td style="background-image: url('/Img/back2.gif');"><img src="/Img/shim.gif" width="16" height="1" border="0"/></td>
</tr>

<tr>
<td><img src="/Img/rounded3.gif" width="16" height="16" border="0"></td>
<td style="background-image: url('/Img/back3.gif');"><img src="/Img/shim.gif" width="1" height="16" border="0" /></td>
<td><img src="/Img/rounded4.gif" width="16" height="16" border="0"></td>
</tr>
</table>

									</TD>
									<td valign="top">&nbsp;</td>
				</TR>
				<tr>
					<td colspan="3">
						<TABLE cellSpacing="0" cellPadding="0" style="BORDER-COLLAPSE: collapse" borderColor="#000000"
							width="100%" border="1">
							<tr>
								<td class="text" align="left" width="85%">
									<table cellpadding="0" cellspacing="0" border="0" width="100%">
										<tr>
											<td class="text">
												&nbsp; Solicitado por:
												<asp:label id="lblSolicitanteCopy" runat="server" Font-Size="10" Font-Bold="True"></asp:label><br />
												&nbsp; Dirección: <asp:label id="lblDireccionSolicitanteCopy" runat="server" Font-Size="9"></asp:label>
											</td>
											<td class="text">
												Fecha:
												<asp:label id="lblFecCopy" runat="server" Font-Bold="True"></asp:label>
											</td>
										</tr>
										<tr>
											<td colspan="2" class="text">
												&nbsp; Referencia:
												<asp:label id="lblRefCopy" runat="server" Font-Bold="True"></asp:label>
											</td>
										</tr>
									</table>
								</td>
								<td class="text" align="left" width="15%">
									&nbsp; Numero:
									<asp:label id="lblNumCopy" runat="server" Font-Bold="True" Width="10"></asp:label><br />
                                    &nbsp; <asp:label id="lblNroPagina2" runat="server" style="text-transform: none;"></asp:label>
								</td>
							</tr>
                            <tr><td colspan="4">
            <table width="100%" cellpadding="0" cellspacing="0">
        							<tr>
								<td class="text" align="center" style="height:800px;">
									<asp:Image id="imgFoto" runat="server" Height="380" style="margin:15px"></asp:Image>
                                    <asp:Image id="imgFoto2" runat="server" Height="380" style="margin:15px"></asp:Image>
								</td>
					        </tr>
            </table></td></tr>
						</TABLE>
					</td>
				</tr>
                
							<TR>
								<TD width="100%" colspan="3" ><div style="font-size:9px; margin-top:10px; line-height:1.5">
									Este informe es confidencial y solo puede ser usado para la 
										evaluación y otorgamiento de créditos o celebración de negocios. Esta prohibida 
										su reproducción, divulgación y entrega a terceros.<BR>
										No significa emitir juicio de valor sobre las personas ni sobre su 
										solvencia. Las <U>decisiones a las que arribe el usuario son de su exclusiva 
											responsabilidad.</U><br />
											www.tiempoygestion.com.ar &nbsp;&nbsp;//&nbsp;&nbsp; informes@tiempoygestion.com.ar</div></TD>
							</TR>
			</TABLE>
        </asp:Panel>
		</form>
	</body>
</HTML>
