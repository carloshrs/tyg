<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.inspeccionAmbientalBancor.verInforme" CodeFile="VerInforme.aspx.cs" %>
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
					ToggleImg(name, 'Cerrar.gif', 'Cerrar M�s Info');
				} 
				else 
				{
					masInfo.style.display = "none";
					ToggleImg(name, 'Arrow.gif', 'M�s Info');
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
		<!---
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td align="right">
						<div id="panel2">
							<asp:Label ID="lblTools" Runat="server"></asp:Label>
						</div>
					</td>
				</tr>
			</TABLE>--->
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" class="tablaInforme">
				<TR>
								<td><IMG alt="" src="/img/logo-20-anios.png" width="264"></td>
								<TD class="title" width="100%" align="center">
									<table width="340" cellpadding="0" cellspacing="0" border="0">
<tr>
<td width="16"><img src="/Img/rounded1.gif" width="16" height="16" border="0"></td>
<td width="168" style="background-image: url('/Img/back1.gif');"><img src="/Img/shim.gif" width="1" height="16" border="0"/></td>
<td width="16"><img src="/Img/rounded2.gif" width="16" height="16" border="0"></td>
</tr>

<tr>
<td style="background-image: url('/Img/back4.gif');"><img src="/Img/shim.gif" width="16" height="1" border="0" /></td>
<td class="title" width="100%" align="center">Entrevista de Relevamiento Habitacional</td>
<td style="background-image: url('/Img/back2.gif');"><img src="/Img/shim.gif" width="16" height="1" border="0"/></td>
</tr>

<tr>
<td><img src="/Img/rounded3.gif" width="16" height="16" border="0"></td>
<td style="background-image: url('/Img/back3.gif');"><img src="/Img/shim.gif" width="1" height="16" border="0" /></td>
<td><img src="/Img/rounded4.gif" width="16" height="16" border="0"></td>
</tr>
</table>

									</TD>
									<td><div id="panel" style="text-align:right"><asp:ImageButton ID="GenerarPDF" 
                                            runat="server" ImageUrl="/img/imprimir-2.gif" title="Generar PDF" 
                                            onclick="GenerarPDF_Click" /><input onclick="imprimir();" type="image" src="/img/imprimir-2.gif" title="Imprimir"><input onclick="window.close();" type="image" src="/img/log_off.gif" title="Cerrar">
						</div><IMG alt="" src="/img/bancor.jpg" width="175"></td>
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
												<asp:label id="lblSolicitante" runat="server" Font-Size="10" Font-Bold="True"></asp:label>
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
				<tr>
					<td class="title" width="100%" colSpan="3">
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
                      <TD width="99%" colSpan=2>
                        <TABLE id=Table4 cellSpacing=0 cellPadding=0 
                        width="100%" border=0>
                          <TR>
                            <TD class="title" width="100%" height="30" style="text-align: center">&nbsp;&nbsp; PERSONA 
                                F�SICA</TD></TR></TABLE></TD>
                    <TR>
                      <TD vAlign=top width="50%"><STRONG>Apellido y 
                        nombre:</STRONG>&nbsp;<BR>
<asp:label id=lblApellido runat="server"></asp:label>, 
<asp:label id=lblNombre runat="server"></asp:label></TD>
                      <TD class=text vAlign=top width="50%"><STRONG>Tipo y n� 
                        documento:&nbsp;</STRONG> 
<asp:label id=lblTipoDocumento runat="server"></asp:label>&nbsp; 
<asp:label id=lblDocumento runat="server"></asp:label></TD>
                    </TABLE>
                  <TABLE class=text id=Table7 style="BORDER-COLLAPSE: collapse" 
                  borderColor=#111111 cellSpacing=0 cellPadding=3 width="100%" 
                  border=1>
                    <TR>
                      <TD width="100%" colSpan=4>
                        <TABLE id=Table5 cellSpacing=0 cellPadding=0 
                        width="100%" border=0>
                          <TR>
                            <TD class="title" width="100%" height="30" style="text-align: center">&nbsp;&nbsp; DOMICILIO A 
                                VERIFICAR</TD></TR></TABLE></TD></TR>
                    <TR>
                      <TD class=text width="50%" 
                        colSpan=2><STRONG>Calle:</STRONG> 
<asp:label id=lblCalle runat="server"></asp:label></TD>
                      <TD class=text width="25%"><STRONG>Lote:</STRONG> 
<asp:label id=lblLote runat="server"></asp:label></TD>
                      <TD class=text width="25%"><STRONG>Manzana:</STRONG> 
<asp:label id=lblManzana runat="server"></asp:label></TD>

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
                        colSpan=2><STRONG>Tel�fono:&nbsp;&nbsp; </STRONG>
<asp:label id=lblTelefono runat="server"></asp:label></TD></TR>

                    <TR>
                      <TD class=text width="50%" 
                        colSpan=2><STRONG>Provincia:&nbsp; </STRONG>
<asp:label id=lblProvincia runat="server"></asp:label></TD>
                      <TD class=text width="50%" 
                        colSpan=2><STRONG>Localidad:&nbsp; </STRONG>
<asp:label id=lblLocalidad runat="server"></asp:label></TD></TR>
                      </TABLE>
												</asp:panel>
											</TD>
										</TR>
									</TABLE>
									
								</TD>
							</TR>
							<TR>
								<TD class="text" width="100%" colSpan="4">
								<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0" style="border-left:1px; border-left-color:#111111; border-left-style:solid; border-right:1px; border-right-color:#111111; border-right-style:solid;">
										<TR>
											<TD class="title" width="100%" colSpan="3" height="30" style="text-align: center">&nbsp;&nbsp; 
                                                GESTI�N SOBRE LA INSPECCI�N</TD>
										</TR>
									</TABLE>
									<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
										cellPadding="3" width="100%" border="1">
										<TR>
											<TD class="text" width="89"><STRONG>Fecha:</STRONG>
												<BR>
												<asp:label id="lblFecha" runat="server"></asp:label></TD>
											<TD class="text" width="157"><STRONG>Habita en lugar declarado:</STRONG>
												<BR>
												<asp:label id="lblHabita" runat="server"></asp:label></TD>
											<TD class="text" width="190"><STRONG>Cantidad de personas que integran el grupo 
                                                familiar:</STRONG>
												<BR>
												<asp:label id="lblCantidad" runat="server"></asp:label></TD>
											<TD class="text" width="25%"><STRONG>Habita el inmueble:</STRONG>
												<BR>
												<asp:label id="lblQuienHabita" runat="server" Style="text-transform: lowercase;"></asp:label></TD>
										</TR>

                                        <TR>
											<TD class="text" width="89"><STRONG>En calidad de:</STRONG>
												<BR>
												<asp:label id="lblCalidadDe" runat="server"></asp:label></TD>
											<TD class="text" width="157"><STRONG>Ampliaciones o mejoras:</STRONG>
												<BR>
												<asp:label id="lblAmpliaciones" runat="server"></asp:label></TD>
											<TD class="text" width="190"><STRONG>Cuales?:</STRONG>
												<BR>
												<asp:label id="lblCualesAmpliaciones" runat="server"></asp:label></TD>
											<TD class="text" width="25%">
												<BR>
												</TD>
										</TR>

                                        <TR>
											<TD class="text" width="50%" colspan="2"><STRONG>Forma de trabajo:</STRONG>
												<BR>
												<asp:label id="lblDepeIndepe" runat="server"></asp:label></TD>
											
											<TD class="text" width="190" colspan="2">
                                                
                                                </TD>
											
										</TR>

                                        <TR>

                                            <TD class="text" width="25%"><STRONG>Empresa:</STRONG>
												<BR>
												<asp:label id="lblEmpresa" runat="server"></asp:label>
												
												</TD>
											<TD class="text" width="89"><STRONG>Direcci�n:</STRONG>
												<BR>
												<asp:label id="lblDireccion" runat="server"></asp:label>
                                                
                                                </TD>
											<TD class="text" width="157"><STRONG>Ingresos mensuales:</STRONG>
												<BR>
												<asp:label id="lblIngresosMensuales" runat="server"></asp:label></TD>
											<TD class="text" width="190"><STRONG>Banco donde acreditan:</STRONG>
												<BR>
												<asp:label id="lblBanco" runat="server"></asp:label>
                                                </TD>
											
										</TR>

                                         <TR>
											<TD class="text" width="50%" colspan="2"><STRONG>Actividad independiente:</STRONG>
												<BR>
												<asp:label id="lblActividad" runat="server"></asp:label></TD>
											
											<TD class="text" width="190" colspan="2">
                                                <STRONG>Desarrolla en:</STRONG>
												<BR>
												<asp:label id="lblDesarrolla" runat="server"></asp:label>
                                                </TD>
											
										</TR>
										
                                        <TR>
											<TD class="text" width="50%" colspan="2"><STRONG>Ingresos netos familiares:</STRONG>
												<BR>
												<asp:label id="lblIngresosFamiliares" runat="server"></asp:label></TD>
											
											<TD class="text" width="190" colspan="2">
                                                <STRONG>Impuestos a su nombre:</STRONG>
												<BR>
												<asp:label id="lblImpuestos" runat="server"></asp:label>
                                                </TD>
											
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="text" width="100%" colSpan="4">
									<TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
										cellPadding="3" width="100%" border="1">
										
										
                                        <tr>
                                            <td colspan="4">
                                                <TABLE class="text" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0"
										cellPadding="3" width="100%" border="1">
										           <TR>
											        <TD class="text" width="50%"><STRONG>Inform�:&nbsp;</STRONG><BR>
												        <asp:label id="lblInformo" runat="server"></asp:label></TD>
											        <TD class="text" width="50%" colSpan="2"><STRONG>Relaci�n:&nbsp;<BR></STRONG>
												        <asp:label id="lblRelacion" runat="server"></asp:label></TD>
                                                   </tr>
                                                </TABLE>
                                            </td>
                                        </tr>
										<TR>
											<TD colSpan="4">
												<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="title" width="100%" colSpan="3" height="30" style="text-align: center">&nbsp;&nbsp; 
															REFERENCIA VECINAL 1</TD>
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
														<TD class="title" width="100%" colSpan="3" height="30" style="text-align: center">&nbsp;&nbsp; 
															REFERENCIA VECINAL 2</TD>
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
											<TD class="text" width="100%" colSpan="4" valign="top"><STRONG>Observaciones:</STRONG> <BR>
												<asp:label id="lblObservaciones" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="text" colSpan="4">&nbsp;<BR>
												<STRONG>Plano de&nbsp;ubicaci�n:</STRONG></TD>
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
														<TD>Ubicaci�n <B>A:</B></TD>
														<TD><asp:label id="lblPlanoA" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD>Ubicaci�n <B>B:</B></TD>
														<TD><asp:label id="lblPlanoB" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD>Ubicaci�n <B>C:</B></TD>
														<TD><asp:label id="lblPlanoC" runat="server"></asp:label></TD>
													</TR>
													<TR>
														<TD>Ubicaci�n <B>D:</B></TD>
														<TD><asp:label id="lblPlanoD" runat="server"></asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										
										   <tr>
                                                        <td class="text" width="100%" colspan="4">
                                                            <table width="260" align="right">
                                                                <tr>
                                                                    <td>
                                                                        <img src="/Img/firma_sariago.jpg" width="110" /></td>
                                                                    <td width="100%" align="center" >
                                                                    <FONT style="font-size:9px">
                                                                        ALEJANDRO SARIAGO<br />
                                                                        SOCIO GERENTE<br />
                                                                        TIEMPO &amp; GESTION S.R.L.<br />
                                                                        Mat. Jud. M.P. 01-1376</FONT></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
									</TABLE>
								</TD>
							</TR>
							
						</TABLE>
					</td>
				</tr>
							<TR>
								<td width="100%" colSpan="4"><div style="font-size:9px; margin-top:10px; line-height:1.5">
									Este informe es confidencial y solo puede ser usado para la 
										evaluaci�n y otorgamiento de cr�ditos o celebraci�n de negocios. Esta prohibida 
										su reproducci�n, divulgaci�n y entrega a terceros.<BR>
										No significa emitir juicio de valor sobre las personas ni sobre su 
										solvencia. Las <U>decisiones a las que arribe el usuario son de su exclusiva 
											responsabilidad.</U><br />
											www.tiempoygestion.com.ar &nbsp;&nbsp;//&nbsp;&nbsp; informes@tiempoygestion.com.ar
											</div></TD>
							</TR>
			</TABLE>
			<input id="idEncabezado" type="hidden" name="idEncabezado" runat="server"> <input id="idReferencia" type="hidden" name="idReferencia" runat="server">
            <asp:Panel ID="pnFotos" runat="server">
        <hr style="page-break-after:always; border:0px; height:0px; visibility:hidden;" />
        			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" class="tablaInforme">
				<TR>
								<td><IMG alt="" src="/img/logo-20-anios.png" width="264"></td>
								<TD class="title" width="100%" align="center">
									<table width="340" cellpadding="0" cellspacing="0" border="0">
<tr>
<td width="16"><img src="/Img/rounded1.gif" width="16" height="16" border="0"></td>
<td width="168" style="background-image: url('/Img/back1.gif');"><img src="/Img/shim.gif" width="1" height="16" border="0"/></td>
<td width="16"><img src="/Img/rounded2.gif" width="16" height="16" border="0"></td>
</tr>

<tr>
<td style="background-image: url('/Img/back4.gif');"><img src="/Img/shim.gif" width="16" height="1" border="0" /></td>
<td class="title" width="100%" align="center">Entrevista de Relevamiento Habitacional</td>
<td style="background-image: url('/Img/back2.gif');"><img src="/Img/shim.gif" width="16" height="1" border="0"/></td>
</tr>

<tr>
<td><img src="/Img/rounded3.gif" width="16" height="16" border="0"></td>
<td style="background-image: url('/Img/back3.gif');"><img src="/Img/shim.gif" width="1" height="16" border="0" /></td>
<td><img src="/Img/rounded4.gif" width="16" height="16" border="0"></td>
</tr>
</table>

									</TD>
									<td><IMG alt="" src="/img/bancor.jpg" width="175"></td>
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
                            <tr><td colspan="2">
            <table width="100%" cellpadding="0" cellspacing="0">
        							<tr>
								<td class="text" align="center">
									<asp:Image id="imgFoto" runat="server" Height="370" style="margin:15px"></asp:Image>
                                    <asp:Image id="imgFoto2" runat="server" Height="370" style="margin:15px"></asp:Image>
								</td>
					        </tr>
            </table></td></tr>
						</TABLE>
					</td>
				</tr>
                
							<TR>
								<TD width="100%" colspan="3" ><div style="font-size:9px; margin-top:10px; line-height:1.5">
									Este informe es confidencial y solo puede ser usado para la 
										evaluaci�n y otorgamiento de cr�ditos o celebraci�n de negocios. Esta prohibida 
										su reproducci�n, divulgaci�n y entrega a terceros.<BR>
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
