<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.VerifDomComercial.verInforme" CodeFile="VerInforme.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
<HEAD>
	<title>Verificación de Domicilio Comercial</title>
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
		
			function imprimir()
			{
			    panel.style.visibility='hidden';
			    window.print();
			    panel.style.visibility='visible';
			}


	</script>
</HEAD>
<body topmargin="0" leftmargin="0" onload="imprimir();">
<form id="Form1" method="post" runat="server">
<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
<TR>
								<td><IMG alt="" src="/img/logo-20-anios.png" width="264"></td>
								<TD class="title" width="100%" align="right">
									<table width="300" cellpadding="0" cellspacing="0" border="0">
<tr>
<td width="16"><img src="/Img/rounded1.gif" width="16" height="16" border="0"></td>
<td width="168" style="background-image: url('/Img/back1.gif');"><img src="/Img/shim.gif" width="1" height="16" border="0"/></td>
<td width="16"><img src="/Img/rounded2.gif" width="16" height="16" border="0"></td>
</tr>

<tr>
<td style="background-image: url('/Img/back4.gif');"><img src="/Img/shim.gif" width="16" height="1" border="0" /></td>
<td class="title" width="100%" align="center"><FONT color="#32528e">Verificación de Domicilio Comercial</FONT>
    </td>
<td style="background-image: url('/Img/back2.gif');"><img src="/Img/shim.gif" width="16" height="1" border="0"/></td>
</tr>

<tr>
<td><img src="/Img/rounded3.gif" width="16" height="16" border="0"></td>
<td style="background-image: url('/Img/back3.gif');"><img src="/Img/shim.gif" width="1" height="16" border="0" /></td>
<td><img src="/Img/rounded4.gif" width="16" height="16" border="0"></td>
</tr>
</table>

									</TD>
									<td valign="top"><div id="panel"><input onclick="window.close();" type="image" src="/img/log_off.gif" title="Cerrar">
								<input onclick="imprimir();" type="image" src="/img/imprimir-2.gif" title="Imprimir">
						</div></td>
				</TR>
</TABLE>
<TABLE class="text" cellSpacing="0" cellPadding="0" width="100%" border="0" class="tablaInforme">
<TBODY>
<tr>
	<td class="title" width="100%">
	<TABLE cellSpacing="0" cellPadding="0" class="tablaInforme" style="BORDER-COLLAPSE: collapse" borderColor="#000000" width="100%" border="1">
	<tr>
		<td class="text" align="left" width="85%">
		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
		<tr>
			<td class="text">
				&nbsp;Solicitado por:
				<asp:label id="lblSolicitante" runat="server" Font-Size="10" Font-Bold="True"></asp:label><br />
												&nbsp;Dirección: <asp:label id="lblDireccionSolicitante" runat="server" Font-Size="9"></asp:label>
			</td>
			<td class="text">
				Fecha:
				<asp:label id="lblFec" runat="server" Font-Bold="True"></asp:label>
			</td>
		</tr>
		<tr>
			<td class="text" colSpan="2">
				&nbsp;Referencia:
				<asp:label id="lblRef" runat="server" Font-Bold="True"></asp:label>
			</td>
		</tr>
		</table>
		</td>
		<td class="text" align="left" width="15%">
			&nbsp;Numero:
			<asp:label id="lblNum" runat="server" Font-Bold="True"></asp:label><br />
            &nbsp; <asp:label id="lblNroPagina1" runat="server" style="text-transform: none;"></asp:label>
		</td>
	</tr>
	</TABLE>
	<!--- FIN ENCABEZADO --->
	<TABLE id="Table2" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0" cellPadding="0" width="100%" border="0" class="tablaInforme">
	<TR>
		<TD class="text" width="100%">
			<!---INICIO DATOS PERSONA FISICA --->
			<asp:Panel id="pnlFisica" runat="server">            
            <TABLE id=Table3 style="BORDER-COLLAPSE: collapse" borderColor=#000000 cellSpacing=0 cellPadding=3 width="100%" border=1 class="tablaInforme">
            <TR>				
				<TD width="100%" colSpan=4>
				<!--- DATOS COMERCIALES --->
                <TABLE id=Table4 style="BORDER-COLLAPSE: collapse" borderColor=#111111 cellSpacing=0 cellPadding=0 width="100%" border=0>
                <TR>
                <TD class="title" width="100%" height="30" style="text-align: center">&nbsp;&nbsp; 
																		DATOS PERSONALES</TD>
				</TR>
				</TABLE>
				</TD>
			</TR>
            <TR>
				<TD class=text width="50%" colSpan=2>
					<STRONG><STRONG>Apellido</STRONG>&nbsp;y nombre:</STRONG>&nbsp; 
					<asp:label id=lblApellido runat="server"></asp:label>, 
					<asp:label id=lblNombre runat="server"></asp:label>
				</TD>
                <TD class=text width="50%" colSpan=2>
					<STRONG>Tipo y nº documento:</STRONG> 
					<asp:label id=lblTipoDocumento runat="server"></asp:label>&nbsp; 
					<asp:label id=lblDocumento runat="server"></asp:label>
				</TD>
			</TR>
            <TR>
				<TD class=text width="50%" colSpan=2>
					<STRONG>Nombre de fantas&iacute;a:</STRONG> <BR>
					<asp:label id=lblNombreFantasia runat="server"></asp:label>
				</TD>
                <TD class=text width="50%" colSpan=2>
					<STRONG>Razón Social:&nbsp; </STRONG><BR>
					<asp:label id=lblRazonSocial runat="server"></asp:label>
				</TD>
			</TR>
            <TR>
				<TD class=text width="50%" colSpan=2>
					<STRONG>Rubro:&nbsp;</STRONG><BR>
					<asp:label id=lblRubro runat="server"></asp:label>
				</TD>
                <TD class=text width="50%" colSpan=2>
					<STRONG>CUIT:&nbsp;</STRONG><BR>
					<asp:label id=lblCuit runat="server"></asp:label>
				</TD>
			</TR>
			<TR>
				<TD class="title" width="100%" colSpan="4" height="30" style="text-align: center">&nbsp;&nbsp; 
																		DOMICILIO</TD>
			</TR>				
			<TR>
				<TD class=text width="50%" colSpan=2>
					<STRONG>Calle:&nbsp;</STRONG>
					<asp:label id=lblCalle runat="server"></asp:label>
				</TD>				
				<TD class=text width="25%" colSpan=1>
					<STRONG>Barrio:</STRONG>&nbsp; 
					<asp:label id=lblBarrio runat="server"></asp:label>
				</TD>
				<TD class=text width="25%" colSpan=1>
					<STRONG>Teléfono:</STRONG>&nbsp; 
					<asp:label id=lblTelefono runat="server"></asp:label>
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
					<STRONG>Provincia:</STRONG>&nbsp; 
					<asp:label id=lblProvincia runat="server"></asp:label>
				</TD>
                <TD class=text width="50%" colSpan=2>
					<STRONG>Localidad:</STRONG>&nbsp; 
					<asp:label id=lblLocalidad runat="server"></asp:label>
				</TD>
			</TR>
			</TABLE>
			</asp:Panel>
			<!--- FIN DATOS PERSONA FISICA --->
										
			<!--- INICIO DATOS PERSONA JURIDICA --->
			<asp:panel id="pnlDomComercial" runat="server">
            <TABLE id=Table8 style="BORDER-COLLAPSE: collapse" borderColor=#000000 cellSpacing=0 cellPadding=3 width="100%" border=1 class="tablaInforme">
            <TR>
				<TD class="title" width="100%" colSpan="4" height="30" style="text-align: center">&nbsp;&nbsp; 
																		PERSONA JURÍDICA</TD>
				</TD>
			</TR>
            <TR>
                <TD class=text width="45%" colspan="2">
					<STRONG>Razón Social:&nbsp;</STRONG>
					<asp:label id=lblRazonSocialEmp runat="server"></asp:label>
				</TD>
				<TD class=text width="55%" colspan="2">
					<STRONG>Nombre de fantas&iacute;a:</STRONG>
					<asp:label id="lblNombreFantasiaEmp" runat="server"></asp:label>
				</TD>
			</TR>
            <TR>
				<TD class=text width="45%" colspan="2">
					<STRONG>Rubro:&nbsp;</STRONG>
					<asp:label id="lblRubroEmp" runat="server"></asp:label>
				</TD>
				<TD class=text width="25%" colspan="1">
					<STRONG>Teléfono:</STRONG>
					<asp:label id="lblTelefonoEmp" runat="server"></asp:label>
				</TD> 
				<TD class=text width="30%" colspan="1">
					<STRONG>CUIT:&nbsp; </STRONG>
					<asp:label id="lblCuitEmp" runat="server"></asp:label>
				</TD>               
			</TR>
			<TR>
				<TD class=text width="45%" colspan="2">
					<STRONG>Calle:&nbsp;</STRONG><BR>
					<asp:label id=lblCalleEmp runat="server"></asp:label>
				</TD>
				<TD class=text width="55%" colspan="2">
					<STRONG>Barrio:</STRONG>&nbsp; <BR>
					<asp:label id=lblBarrioEmp runat="server"></asp:label>
				</TD>                														
			</TR>            
            <TR>				
				<TD class=text width="30%" >
					<STRONG>C.P.:</STRONG> 
					<asp:label id=lblCPEmp runat="server"></asp:label>
				</TD>
                <TD class=text width="15%">
					<STRONG>Nro:</STRONG> 
					<asp:label id=lblNroEmp runat="server"></asp:label>
				</TD>
                <TD class=text width="25%">
					<STRONG>Depto.:</STRONG> 
					<asp:label id=lblDeptoEmp runat="server"></asp:label>
				</TD>
                <TD class=text width="30%">
					<STRONG>Piso:</STRONG> 
					<asp:label id=lblPisoEmp runat="server"></asp:label>
				</TD>                                       
			</TR>            
            <TR>
				<TD class=text width="50%" height=14 colspan="2">
					<STRONG>Provincia:</STRONG>&nbsp; 
					<asp:label id=lblProvinciaEmp runat="server"></asp:label>
				</TD>
                <TD class=text width="50%" height=14 colspan="2">
					<STRONG>Localidad:</STRONG>&nbsp; 
					<asp:label id=lblLocalidadEmp runat="server"></asp:label>
				</TD>					                
			</TR>
			</TABLE>
			</asp:panel>
			<!--- FIN DATOS PERSONA JURIDICA --->
		</TD>
	</TR>
	</TABLE>
	<TABLE id="Table16" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0" cellPadding="3" width="100%" border="1" class="tablaInforme">
	<TR>
		<td colSpan="3">
		<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
		<TR>
		<TD class="title" width="100%" colSpan="3" height="30" style="text-align: center">&nbsp;&nbsp; 
																		GESTIÓN SOBRE LA VERIFICACIÓN</TD>
		</TR>
		</TABLE>
		</td>
	</TR>
	<tr>
		<TD class="text" width="33%" height="19">
			<STRONG>Fecha:</STRONG>
			<BR>
			<asp:label id="lblFecha" runat="server"></asp:label>
		</TD>
		<TD class="text" width="33%" height="19">
			<STRONG>Ocupación:</STRONG><BR>
			<asp:label id="lblOcupacion" runat="server"></asp:label>
		</TD>
		<TD class="text" width="33%" height="19">
			<STRONG>Categoría de autonomo:<BR>
			</STRONG>
			<asp:label id="lblCategoria" runat="server"></asp:label>
		</TD>
	</tr>
	<TR>
		<TD class="text" width="33%">
			<STRONG>Mov. comercial observado:<BR>
			</STRONG>
			<asp:label id="lblMovComercial" runat="server"></asp:label>
		</TD>
		<TD class="text" width="33%">
			<STRONG>Actividad principal:<BR>
			</STRONG>
			<asp:label id="lblActividad" runat="server"></asp:label>
		</TD>
		<TD class="text" width="33%">
			<STRONG>Rubros adicionales:<BR>
			</STRONG>
			<asp:label id="lblRubros" runat="server"></asp:label>
		</TD>
	</TR>
	<TR>
		<TD class="text" width="33%">
			<STRONG>Horario de atención:</STRONG><BR>
			<asp:label id="lblHorario" runat="server"></asp:label>
		</TD>
		<TD class="text" width="33%">
			<STRONG>Antiguedad en el domicilio:<BR>
			</STRONG>
			<asp:label id="lblAntiguedad" runat="server"></asp:label>
		</TD>
		<TD class="text" width="33%">
			<STRONG>Cantidad de personal:<BR>
			</STRONG>
			<asp:label id="lblCantidad" runat="server"></asp:label>
		</TD>
	</TR>
	<TR>
		<TD class="text">
			<STRONG>Caracteristica zona:<BR>
			</STRONG>
			<asp:label id="lblCaractZona" runat="server"></asp:label>
		</TD>
		<TD class="text">
			<STRONG>Documento verificado:</STRONG><BR>
			<asp:label id="lblDocVerificado" runat="server"></asp:label>
		</TD>
		<TD class="text">
			<STRONG>Ubicación:<BR>
			</STRONG>
			<asp:label id="lblUbicacion" runat="server"></asp:label>
		</TD>
	</TR>
	<TR>
		<TD height="14" class="text">
			<STRONG>Tamaño de local:<BR>
			</STRONG>
			<asp:label id="lblTamLocal" runat="server"></asp:label>
		</TD>
		<TD height="14" class="text">
			<STRONG>Inmueble:</STRONG><BR>
			<asp:label id="lblInmueble" runat="server"></asp:label>
		</TD>
		<TD height="14" class="text">
			<STRONG>Estado de conservación:</STRONG><BR>
			<asp:label id="lblEstadoCons" runat="server"></asp:label>
		</TD>
	</TR>
	</TABLE>
	<TABLE class="tablaInforme" id="Table17" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0" cellPadding="3" width="100%" border="1">
	<tr>
		<TD class="text" width="25%">
			<STRONG>Cartel de publicidad:<BR>
			</STRONG>
			<asp:label id="lblPublicidad" runat="server"></asp:label>
		</TD>
		<TD class="text" width="25%">
			<STRONG>Personal de vigilancia:</STRONG>
			<asp:label id="lblVigilancia" runat="server"></asp:label>
		</TD>
		<TD class="text" width="25%">
			<STRONG>Inicio de actividades:</STRONG>
			<asp:label id="lblInicioActividades" runat="server"></asp:label>
		</TD>
		<TD class="text" width="25%">
			<STRONG>Categoria ante el IVA:</STRONG><BR>
			<asp:label id="lblIVA" runat="server"></asp:label>
		</TD>
	</tr>
	<TR>
		<td width="25%" colSpan="2" class="text">
			<STRONG>Informó:</STRONG>&nbsp;
			<BR>
			<asp:label id="lblInformo" runat="server"></asp:label>
		</td>
		<td width="25%" colSpan="2" class="text">
			<STRONG>Cargo o relación:<BR>
			</STRONG>
			<asp:label id="lblCargo" runat="server"></asp:label>
		</td>
	</TR>
	</TABLE>
	<TABLE class="tablaInforme" id="Table1" style="BORDER-COLLAPSE: collapse" borderColor="#111111" cellSpacing="0" cellPadding="3" width="100%" border="1">
	<TR>
		<td colSpan="3">
		<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="100%" border="0">
		<TR>
		<TD class="title" width="100%" colSpan="3" height="30" style="text-align: center">&nbsp;&nbsp; 
																		REFERENCIA VECINAL</TD>
		</TR>
		</TABLE>
		</td>
	</TR>
	<tr>
		<TD class="text" width="33%">
			<STRONG>Apellido y nombre:</STRONG><BR>
			<asp:label id="lblNombreVecino" runat="server"></asp:label>
		</TD>
		<TD class="text" width="33%">
			<STRONG>Domicilio:<BR>
			</STRONG>
			<asp:label id="lblDomicilioVecino" runat="server"></asp:label>
		</TD>
		<TD class="text" width="33%">
			<STRONG>Conoce del funcionamiento:</STRONG><BR>
			<asp:label id="lblConoce" runat="server"></asp:label>
		</TD>
	</tr>
	<TR>
		<TD width="100%" colSpan="3"class="text">
			<STRONG><asp:label id="Label5" runat="server">Observaciones</asp:label>:<BR>
			</STRONG>
			<asp:label id="lblObservaciones" runat="server"></asp:label>
		</TD>
	</TR>
	<TR>
		<TD width="33%" colSpan="3" class="text">&nbsp;<BR>
		<B>Plano de ubicación:</B></TD>
	</TR>
	<TR>
		<TD class="text" align="center">
			<IMG height=140 src="/img/plano_chico.gif" width=140 border=1>
		</TD>
		<TD vAlign="top" colspan="2">&nbsp;
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
<tr>
                                                        <td class="text" width="100%" colspan="3">
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
		<INPUT id="idEncabezado" type="hidden" name="idEncabezado" runat="server"> 
		<INPUT id="idReferencia" type="hidden" name="idReferencia" runat="server">
	</td>
</tr>

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

</TBODY>
</TABLE>
<asp:Panel ID="pnFotos" runat="server">
        <hr style="page-break-after:always; border:0px; height:0px;" />
        			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" class="tablaInforme">
				<TR>
								<td><IMG alt="" src="/img/logo-20-anios.png" width="264"></td>
								<TD class="title" width="100%" align="right">
									<table width="300" cellpadding="0" cellspacing="0" border="0">
<tr>
<td width="16"><img src="/Img/rounded1.gif" width="16" height="16" border="0"></td>
<td width="168" style="background-image: url('/Img/back1.gif');"><img src="/Img/shim.gif" width="1" height="16" border="0"/></td>
<td width="16"><img src="/Img/rounded2.gif" width="16" height="16" border="0"></td>
</tr>

<tr>
<td style="background-image: url('/Img/back4.gif');"><img src="/Img/shim.gif" width="16" height="1" border="0" /></td>
<td class="title" width="100%" align="center"><FONT color="#32528e">Verificación de Domicilio Comercial</FONT></td>
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
                            <tr><td colspan="2">
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