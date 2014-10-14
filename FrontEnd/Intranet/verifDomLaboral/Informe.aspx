<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.verifDomLaboral.Informe" CodeFile="Informe.aspx.cs" %>
<%@ Register TagPrefix="mnu" TagName="menu" Src="../Inc/menu.ascx" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
  <HEAD>
		<title>Alta de Informe</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
		<script src="../Includes/entertab.js" type="text/javascript"></script>
		<script src="../Inc/divBusqueda.js" type="text/javascript"></script>
        <script src="../Inc/padron.js" type="text/javascript"></script>

    <script type="text/javascript">
    
            function GetServerTime(valor)
            {
                limpiar();
                document.getElementById("divProcesando").style.display='';
                Samples.AspNet.ServerTime.GetServerTime(valor,OnSucceeded);
            }

            // This is the callback function that
            // processes the Web Service return value.
            
            
            function OnSucceeded(result)
            {

                var tempPer = new Array();
                tempPer = result.split('|');
                //alert(tempPer.length)
                //alert(tempPer[0])
                //alert(tempPer[1])
                if(tempPer.length == 1)
                    parserTexto(result);
                else
                {
                    document.getElementById("DivNombre1").innerHTML = "";
                    document.getElementById("DivNombre2").innerHTML = "";
                    document.getElementById("DivNombres").style.display = "";

                    var temp3 = new Array();
                    temp3 = tempPer[0].split(',');
                    var RsltElemNom1 = document.getElementById("DivNombre1");
                    RsltElemNom1.innerHTML = temp3[1];

                    var temp4 = new Array();
                    temp4 = tempPer[1].split(',');
                    var RsltElemNom2 = document.getElementById("DivNombre2");
                    RsltElemNom2.innerHTML = temp4[1];

                    parserTexto(tempPer[0]);
                }
            }

        function seleccionarPersona2(valor)
        {
           if(valor.id == 'DivNombre1')
           {
                var RsltElemNom1 = document.getElementById("DivNombre1");
                parserTexto("1,"+RsltElemNom1.innerHTML);
           }
           else
           {
                var RsltElemNom2 = document.getElementById("DivNombre2");
                parserTexto("1,"+RsltElemNom2.innerHTML);
           }
        }
        
            
			function ToggleImg(name, src, alt)
			{
				name.src = "/img/" + src;
				name.alt = alt
			}

		function mostrarFiltro(name)
		{
			if (dv_solicitud.style.display == "none") 
			{
				dv_solicitud.style.display = "list-item";
				ToggleImg(name, 'Cerrar.gif', 'Ocultar datos de la solicitud');
				document.getElementById('hdEncAbierto').value = '1';
			} 
			else 
			{
				dv_solicitud.style.display = "none";
				ToggleImg(name, 'Arrow.gif', 'Mostrar datos de la solicitud');
				document.getElementById('hdEncAbierto').value = '0';
			}
		}

			function mostrarInfoAdicional()
			{
			    if(document.Form1.lblEncObservaciones.value != '')
			        mostrarFiltro(document.getElementById('imgSolicitud'));
			}


			function mostrarImagenes(lUrl)
			{
				window.showModalDialog(lUrl, '', 'dialogWidth:640px;dialogHeight:480px');
				document.forms[0].submit();
			}
			
			function ChequearPersona()
			{
				retval = window.showModalDialog('/Admin/Personas/PersonasCheck.aspx?Numero=' + document.forms[0].txtDocumento.value, '', 'dialogWidth:640px;dialogHeight:480px');
				if (retval!=null)
				{
					Form1.txtNombre.value = retval[0].toString();
					Form1.txtApellido.value = retval[1].toString();
				}
			}
			
			function nuevaEmpresa()
			{
				window.showModalDialog('/Admin/Empresas/AltaEmpresaPopup.aspx', '', 'dialogWidth:570px;dialogHeight:390px;');
			}

			
			function AJAX_buscar( textRef, valor )
            {
	            HTTP_response = request();
	            if( HTTP_response == null )
		            return;
	            HTTP_response.onreadystatechange = tomarRespuesta;
	            if( textRef.name == 'txtRazonSocial' )
	                HTTP_response.open('GET', 'a_empresas.aspx?query='+valor, true);
	            else
	                HTTP_response.open('GET', 'a_empresas.aspx?queryF='+valor, true);
	            HTTP_response.send(null);
            }
            
            function setRetornoBusqueda( textRef, valor )
            {
                document.getElementById("hEmpresas").value = valor;
                if( textRef.name == 'txtRazonSocial' )
                    document.getElementById("txtRazonSocial").value = '';
                else
                    document.getElementById("txtNombreFantasia").value = '';
                setTimeout('__doPostBack(\'hEmpresas\',\'\')', 0);
            }
            function vuelveValor( text, idValor )
            {
                text.value = document.getElementById(idValor).value;
                cerrarBusqueda();
            }
            
            function IAmSelected( source, eventArgs ) {
                //alert( " Key : "+ eventArgs.get_text() +"  Value :  "+eventArgs.get_value()); 
                valor = eventArgs.get_value();
                setRetornoBusqueda( document.getElementById("txtRazonSocial"), valor )
            }
            
			</script>
</HEAD>
	<body leftmargin="0" topmargin="0" onload="mostrarInfoAdicional();">
					<form id="Form1" method="post" runat="server" submitdisabledcontrols="true">
		<DIV id="divDateControl" style="Z-INDEX: 102; LEFT: -35px; VISIBILITY: hidden; POSITION: absolute; TOP: -150px">
			<IFRAME name="popFrame" src="/inc/calendar/calendar.htm" frameBorder="0" width="160" scrolling="no"
				height="160"></IFRAME>
		</DIV>
		<div id="divBusqueda" style="top: 50px; left: 420px; width:auto; height: 100px; overflow-y:scroll; position:absolute; border-style:solid; border-width:1px; display:none; background-color: #F5F5F5;">
	    <table style="width:390px" cellpadding="1" cellspacing="0" onMouseOut="limpiarBSQ();"><tbody id="bsqCuerpo" style="font-family: Arial, Verdana, Helvetica, Sans-Serif; font-size:8pt;"></tbody></table>
	    </div>
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<table cellpadding="0" cellspacing="0" border="0">
			<tr>
				<td width="20">&nbsp;</td>
				<td>
					<br>
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="title" width="100%">Verificación de Domicilio Laboral
								</td>
							</tr>
							<tr>
					    <td>
					        <table width="100%" class="text" cellpadding="1" cellspacing="1">
					            <tr bgColor="#F3F3F3" class="text">
					                <td>
					                    <table cellpadding="0" cellspacing="0">
					                    <tr>
					                        <td><a href="javascript:mostrarFiltro(document.getElementById('imgSolicitud'));"><asp:Image ID="imgSolicitud" runat="server" ImageUrl="/img/Arrow.gif" Height="14" Width="14" BorderWidth="0"  /></a><b>
                                                </b></td>
					                        <td style="font-family: Arial; font-size: 10pt; color: #3557A1">&nbsp;&nbsp;Informaci&oacute;n adicional de la solicitud</td>
					                    </tr>
					                    </table>
					                </td>
					            </tr>
					            <tr bgColor="#FBFBFB" id="dv_solicitud" style="display: none;">
					                <td colspan="2">
					                <table class="text">
					                    <tr>
					                        <td colspan="2"><b>Datos de contacto<asp:HiddenField ID="hdEncAbierto" runat="server" Value="0" Visible="true" /></b></td>
					                    </tr>
					                    <tr>
					                        <td><i>Tel&eacute;fono:</i></td>
					                        <td><b><asp:Label ID="lblEncTelefono" runat="server"></asp:Label></b></td>
					                    </tr>
					                    <tr>
					                        <td><i>e-mail:</i></td>
					                        <td><b><asp:Label ID="lblEncMail" runat="server"></asp:Label></b></td>
					                    </tr>
					                    <tr>
					                        <td colspan="2"><b>Datos C&oacute;nyuge/Concubino</b></td>
					                    </tr>
					                    <tr>
					                        <td><i>Apellido y Nombre:</i></td>
					                        <td><b><asp:Label ID="lblEncApeCon" runat="server"></asp:Label>&nbsp;<asp:Label ID="lblEncNomCon" runat="server"></asp:Label></b></td>
					                    </tr>
					                    <tr>
					                        <td><i>Tipo y Nro Documento:</i></td>
					                        <td><b><asp:Label ID="lblEncTipoDocCon" runat="server"></asp:Label>&nbsp;<asp:Label ID="lblEncNroDocCon" runat="server"></asp:Label></b></td>
					                    </tr>
					                    <tr>
					                        <td colspan="2"><b>Observaciones</b></td>
					                    </tr>
					                    <tr>
					                        <td colspan="2">
                                                <asp:TextBox ID="lblEncObservaciones" runat="server" Width="450px" TextMode="MultiLine" Rows="5" CssClass="Plano" ReadOnly="true"></asp:TextBox>
                                            </td>
					                    </tr>
					                </table>
					                </td>
					            </tr>
					        </table>
					    </td>
					</tr>
							<tr>
								<td width="100%">
									<table cellSpacing="0" cellPadding="0" width="480" border="0">
										<TR>
											<TD class="text" height="14">&nbsp;</TD>
										</TR>
										<TR>
											<td width="536" colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="text" width="50%" height="246">
															<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD width="536" colSpan="4">
																		<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<TR>
																				<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; 
																					Datos Personales</TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD class="text" width="50%" colSpan="2">Nombre&nbsp;
																		<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ControlToValidate="txtNombre" ErrorMessage="Ingrese Nombre">*</asp:requiredfieldvalidator></TD>
																	<TD class="text" width="50%" colSpan="2">Apellido&nbsp;
																		<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" ControlToValidate="txtApellido" ErrorMessage="Ingrese Apellido">*</asp:requiredfieldvalidator></TD>
																</TR>
																<TR>
																	<TD class="text" width="50%" colSpan="2"><asp:textbox id="txtNombre" runat="server" Width="230px" MaxLength="200" style="text-transform:uppercase"></asp:textbox></TD>
																	<TD class="text" width="50%" colSpan="2"><asp:textbox id="txtApellido" runat="server" Width="100%" MaxLength="200" style="text-transform:uppercase"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="text" width="50%" colSpan="2">Tipo de documento</TD>
																	<TD class="text" width="50%" colSpan="2">Documento<asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" ControlToValidate="txtDocumento" ErrorMessage="Ingrese Documento">*</asp:requiredfieldvalidator></TD>
																</TR>
																<TR>
																	<TD class="text" width="50%" colSpan="2"><asp:dropdownlist id="cmbTipoDocumento" runat="server" Width="230px"></asp:dropdownlist></TD>
																	<TD class="text" width="50%" colSpan="2"><asp:TextBox ID="txtDocumento" runat="server" MaxLength="20" Width="210px" 
                                                                            style="text-transform: uppercase"></asp:TextBox><asp:Button ID="btnObtener" runat="server" Text="?" onprerender="btnObtener_PreRender" ToolTip="Consultar persona en Padrón" />
                                                                        <cc1:ModalPopupExtender ID="imgCheckPersona_ModalPopupExtender" runat="server" 
                                                                            TargetControlID="btnObtener" DropShadow="True" BackgroundCssClass="FondoAplicacion" CancelControlID="btnCancelar" 
                                                                            PopupControlID="pnlPersonaPadron" OkControlID="btnCancelar">
                                                                        </cc1:ModalPopupExtender>
                                                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                                            <Services>
                                                                                <asp:ServiceReference  Path="../services/ServerTime.asmx" />
                                                                            </Services>
                                                                        </asp:ScriptManager></TD>
																</TR>
																<TR>
																	<TD class="text" width="50%" colSpan="2">Estado civil</TD>
																	<TD class="text" width="50%" colSpan="2"></TD>
																</TR>
																<TR>
																	<TD class="text" width="50%" colSpan="2"><asp:dropdownlist id="cmbEstadoCivil" runat="server" Width="230px"></asp:dropdownlist></TD>
																	<TD class="text" width="50%" colSpan="2"></TD>
																</TR>
																<TR>
																	<TD class="text" width="50%" colSpan="2">&nbsp;</TD>
																	<TD class="text" width="50%" colSpan="2"></TD>
																</TR>
																<!-- LOS DATOS DE LA EMPRESA -->
																<TR>
																	<TD width="536" colSpan="4">
																		<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<TR>
																				<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">
																					&nbsp;&nbsp;
																					<asp:Label id="lblEmpresa" runat="server" CssClass="title">Datos de la empresa</asp:Label>
																					<asp:HiddenField ID="hEmpresas" Value="0" runat="server" OnValueChanged="hEmpresas_ValueChanged" />
                                                                                    <asp:HiddenField ID="hEmpresasNombre" runat="server" />
                                                                                    <asp:HiddenField ID="hEmpresasFantasia" runat="server" />
																				</TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
																<!--<TR>
																	<TD class="text" colSpan="4">
																		Empresa:&nbsp;
																	</TD>
																</TR>-->
																<!--<TR>
																	<TD width="50%" colSpan="2">
                                                                        <input style="width: 230px;text-transform:uppercase;" id="txtBusqueda" name="txtBusqueda" type="text" onKeyUp="bsq_buscar_text(this);" onKeyDown="return bsq_tomarTecla(event);" /></TD>
																	<TD colSpan="2">&nbsp;
																		<asp:ImageButton id="ImgbtnEmpresa" title="Registrar Nueva Empresa" runat="server" ImageUrl="/img/Nuevo.gif"
																			CausesValidation="False"></asp:ImageButton>
																	</TD>
																</TR>-->
																<TR>
																	<TD class="text" width="50%" colSpan="2">Razón Social</TD>
																	<TD class="text" width="50%" colSpan="2">Nombre de fantasia&nbsp;</TD>
																</TR>
																<TR>
																	<TD class="text" width="50%" colSpan="2"><asp:textbox id="txtRazonSocial" runat="server" Width="230px" MaxLength="200" style="text-transform:uppercase;" onblur="vuelveValor(this,'hEmpresasNombre');"></asp:textbox>
																	<cc1:AutoCompleteExtender ID="txtRazonSocial_AutoCompleteExtender" runat="server" Enabled="true" 
                                                                            ServiceMethod="BuscarEmpresa" ServicePath="../services/empresas.asmx" 
                                                                            MinimumPrefixLength="2" enablecaching="true"  TargetControlID="txtRazonSocial" UseContextKey="true" CompletionSetCount="10" 
                                                                            CompletionInterval="200" CompletionListCssClass="completionList" CompletionListHighlightedItemCssClass="itemHighlighted" CompletionListItemCssClass="listItem" OnClientItemSelected="IAmSelected">
                                                                        </cc1:AutoCompleteExtender>
																	</TD>
																	<TD class="text" width="50%" colSpan="2"><asp:textbox id="txtNombreFantasia" runat="server" Width="90%" MaxLength="200" onKeyUp="bsq_buscar_text(this);" onKeyDown="return bsq_tomarTecla(event);" style="text-transform:uppercase;" onblur="vuelveValor(this,'hEmpresasFantasia');"></asp:textbox>&nbsp;<a href="#" onclick="nuevaEmpresa();"><img src="/Img/Nuevo2.gif" border="0" title="Nueva empresa" width="16" /></a></TD>
																</TR>
																<TR>
																	<TD class="text" width="50%" colSpan="2">Rubro&nbsp;</TD>
																	<TD class="text" width="50%" colSpan="2">CUIT&nbsp;</TD>
																</TR>
																<TR>
																	<TD class="text" width="50%" colSpan="2"><asp:textbox id="txtRubro" runat="server" Width="230px" MaxLength="200" Enabled="False"></asp:textbox></TD>
																	<TD class="text" width="50%" colSpan="2"><asp:textbox id="txtCuit" runat="server" Width="100%" MaxLength="200" Enabled="False"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="text" width="50%" colSpan="2">Calle&nbsp;</TD>
																	<TD class="text" width="50%" colSpan="2">Barrio&nbsp;</TD>
																</TR>
																<TR>
																	<TD class="text" width="50%" colSpan="2"><asp:textbox id="txtCalle" runat="server" Width="230px" MaxLength="250" Enabled="False"></asp:textbox></TD>
																	<TD class="text" width="50%" colSpan="2"><asp:textbox id="txtBarrio" runat="server" Width="100%" MaxLength="250" Enabled="False"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="text" width="25%">Nro</TD>
																	<TD class="text" width="25%">Piso</TD>
																	<TD class="text" width="25%">Depto.</TD>
																	<TD class="text" width="25%">C.P.</TD>
																</TR>
																<TR>
																	<TD class="text" width="25%" height="22"><asp:textbox id="txtNro" runat="server" Width="92%" MaxLength="20" Enabled="False"></asp:textbox></TD>
																	<TD class="text" width="25%"><asp:textbox id="txtPiso" runat="server" Width="92%" MaxLength="10" Enabled="False"></asp:textbox></TD>
																	<TD class="text" align="left" width="25%"><asp:textbox id="txtDepto" runat="server" Width="92%" MaxLength="10" Enabled="False"></asp:textbox></TD>
																	<TD class="text" align="left" width="25%"><asp:textbox id="txtCP" runat="server" Width="100%" MaxLength="10" Enabled="False"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD class="text" width="50%" colSpan="2">Teléfono&nbsp;
																	</TD>
																	<TD class="text" width="50%" colSpan="2">Localidad&nbsp;
																	</TD>
																</TR>
																<TR>
																	<TD class="text" width="50%" colSpan="2"><asp:textbox id="txtTelefono" runat="server" Width="230px" MaxLength="10" Enabled="False"></asp:textbox></TD>
																	<TD class="text" width="50%" colSpan="2"><asp:dropdownlist id="cmbLocalidad" runat="server" Enabled="False"></asp:dropdownlist></TD>
																</TR>
																<!-- FIN DATOS DE LA EMPRESA -->
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
											<TD colSpan="4">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">
															&nbsp;&nbsp; Empresa donde trabaja</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD class="text" width="261" colSpan="2">&nbsp;Fecha
											</TD>
											<TD class="text" width="50%" colSpan="2">Trabaja en lugar declarado
											</TD>
										</TR>
										<TR>
											<TD class="text" width="261" colSpan="2">
<asp:textbox id=txtFecha runat="server" Width="100px" style="text-transform:uppercase" disabled="true"></asp:textbox>&nbsp;<IMG 
                  id=imgFecha style="CURSOR: hand" 
                  onclick="popFrame.fPopCalendar(imgFecha, txtFecha, divDateControl);" 
                  alt="Abrir Calendario" src="/img/fecha.gif"></TD>
											<TD class="text" width="50%" colSpan="2">
<asp:radiobuttonlist id=raTrabajaLugar runat="server" CssClass="text" RepeatDirection="Horizontal">
																<asp:ListItem Value="1"> Si</asp:ListItem>
																<asp:ListItem Value="0"> No</asp:ListItem>
															</asp:radiobuttonlist></TD>
										</TR>
										<TR>
											<td class="text" width="535" colSpan="4"></td>
										</TR>
										<TR>
											<td class="text" width="100%" colSpan="4">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="text" width="33%">Ocupación&nbsp;</TD>
														<TD class="text" width="33%">Cargo&nbsp;</TD>
														<TD class="text" width="34%">Antiguedad</TD>
													</TR>
													<TR>
														<TD class="text"><asp:textbox id="txtOcupacion" runat="server" Width="95%" MaxLength="200" style="text-transform:uppercase"></asp:textbox></TD>
														<TD class="text"><asp:textbox id="txtCargo" runat="server" Width="95%" MaxLength="200" style="text-transform:uppercase"></asp:textbox></TD>
														<TD class="text">
															<asp:textbox id="txtAntiguedad" runat="server" Width="100%" MaxLength="200" style="text-transform:uppercase"></asp:textbox></TD>
													</TR>
												</TABLE>
												&nbsp;</td>
										</TR>
										<TR>
											<td class="text" width="535" colSpan="4">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="text" width="33%">Empleado permanente</TD>
														<TD class="text" width="33%">Empleado contratado</TD>
														<TD class="text" width="33%">Fecha finalización</TD>
													</TR>
													<TR>
														<TD class="text"><asp:radiobuttonlist id="raPermanente" runat="server" CssClass="text" RepeatDirection="Horizontal">
																<asp:ListItem Value="1"> Si</asp:ListItem>
																<asp:ListItem Value="0"> No</asp:ListItem>
															</asp:radiobuttonlist></TD>
														<TD class="text"><asp:radiobuttonlist id="raContratado" runat="server" CssClass="text" RepeatDirection="Horizontal">
																<asp:ListItem Value="1"> Si</asp:ListItem>
																<asp:ListItem Value="0"> No</asp:ListItem>
															</asp:radiobuttonlist></TD>
														<TD class="text">
<asp:textbox id=txtFechaFinalizacion runat="server" Width="100px" disabled="true"></asp:textbox>&nbsp;<IMG 
                        id=imgFechaFin style="CURSOR: hand" 
                        onclick="popFrame.fPopCalendar(imgFechaFin, txtFechaFinalizacion, divDateControl);" 
                        alt="Abrir Calendario" 
                    src="/img/fecha.gif"></TD>
													</TR>
												</TABLE>
												&nbsp;</td>
										</TR>
										<TR>
											<td class="text" width="535" colSpan="4">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="text" width="33%">Sueldo</TD>
														<TD class="text" width="33%">Embargos 
                        en el sueldo</TD>
														<TD class="text" width="33%">A favor de</TD>
													</TR>
													<TR>
														<TD class="text"><asp:textbox id="txtSueldo" runat="server" Width="95%" MaxLength="200" style="text-transform:uppercase"></asp:textbox>&nbsp;
															</TD>
														<TD class="text">
<asp:radiobuttonlist id=raEmbargos runat="server" CssClass="text" RepeatDirection="Horizontal">
																<asp:ListItem Value="1"> Si</asp:ListItem>
																<asp:ListItem Value="0"> No</asp:ListItem>
															</asp:radiobuttonlist></TD>
														<TD class="text">
															<asp:textbox id="txtAFavor" runat="server" Width="100%" MaxLength="200" style="text-transform:uppercase"></asp:textbox></TD>
													</TR>
												</TABLE>
											</td>
										</TR>
										<TR>
											<td class="text" width="535" colSpan="4"></td>
										</TR>
										<TR>
											<TD class="text" width="261" colSpan="2">Informó&nbsp;
											</TD>
											<TD class="text" width="50%" colSpan="2">Cargo o relación&nbsp;
											</TD>
										</TR>
										<TR>
											<TD class="text" width="261" colSpan="2"><asp:textbox id="txtInformo" runat="server" Width="230px" MaxLength="250" style="text-transform:uppercase"></asp:textbox></TD>
											<TD class="text" width="50%" colSpan="2"><asp:textbox id="txtCargoInformo" runat="server" Width="100%" MaxLength="250" style="text-transform:uppercase"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="text" width="261" colSpan="2">&nbsp;</TD>
											<TD class="text" width="50%" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="text" width="261" colSpan="2">Ubicación&nbsp;
											</TD>
											<TD class="text" width="50%" colSpan="2">Zona&nbsp;
											</TD>
										</TR>
										<TR>
											<TD class="text" width="261" colSpan="2">
												<asp:radiobuttonlist id="raUbicacion" runat="server" CssClass="text"></asp:radiobuttonlist></TD>
											<TD class="text" width="50%" colSpan="2">
												<asp:radiobuttonlist id="raCaractZona" runat="server" CssClass="text"></asp:radiobuttonlist></TD>
										</TR>
										<TR>
											<TD class="text" width="261" colSpan="2">&nbsp;</TD>
											<TD class="text" width="50%" colSpan="2"></TD>
										</TR>
										<TR>
											<TD colSpan="4">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp; 
															Referencia vecinal</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<tr>
											<td colSpan="4">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="text" width="34%">Apellido y nombre</TD>
														<TD class="text" width="34%">Domicilio</TD>
														<TD class="text" width="32%">Conoce</TD>
													</TR>
													<TR>
														<TD class="text"><asp:textbox id="txtNombreVecino" runat="server" Width="95%" MaxLength="250" style="text-transform:uppercase"></asp:textbox></TD>
														<TD class="text"><asp:textbox id="txtDomicilioVecino" runat="server" Width="95%" MaxLength="250" style="text-transform:uppercase"></asp:textbox></TD>
														<TD class="text"><asp:textbox id="txtConoceVecino" runat="server" Width="100%" MaxLength="250" style="text-transform:uppercase"></asp:textbox></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
                                    <tr>
                                        <td class="text" colspan="4">Informes Anteriores</td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535" colspan="4">
                                            <asp:TextBox ID="txtInformesAnteriores" runat="server" MaxLength="255" Width="100%"
                                                TextMode="MultiLine" Rows="5" Height="79px" CssClass="Plano"></asp:TextBox></td>
                                    </tr>

										<TR>
											<TD class="text" width="175" colSpan="4"><asp:label id="Label5" runat="server">Observaciones</asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD class="text" width="100%" colSpan="4"><asp:textbox id="txtObservaciones" runat="server" Width="100%" CssClass="Plano" Rows="5" TextMode="MultiLine" style="text-transform:uppercase">NOS INFORMÓ QUE EL TITULAR PRESTA SERVICIO CON TOTAL NORMALIDAD Y QUE NO REGISTRA NINGUN TIPO DE IRREGULARIDAD EN EL COBRO DE SUS HABERES.</asp:textbox></TD>
										</TR>
										<TR>
											<td class="text" colSpan="4"></td>
										</TR>
										<TR>
											<td class="text" align="center" width="50%" colSpan="2">
												<P align="left">&nbsp;</P>
											</td>
											<td vAlign="top" width="50%" colSpan="2"></td>
										</TR>
										<TR>
											<TD class="text" align="left" colSpan="5">
												<asp:Panel ID="pnlImagenes" Runat="server">
<asp:Image id="imgFoto" runat="server" ImageUrl="/img/shim.gif" BorderWidth="1px" Width="250px"></asp:Image><BR>
<asp:HyperLink id="hypMasFotos" runat="server" CssClass="text" NavigateUrl="#">Agregar Imágenes...</asp:HyperLink>
												</asp:Panel></TD></TR><TR>
											<td width="535" colSpan="4">
												<hr>
												<asp:Label id="lblMessage" runat="server" Visible="False" ForeColor="Red" Font-Bold="True">Debe agregar imágenes para finalizar...</asp:Label></td></TR><TR>
											<TD width="535" colSpan="4">
												<asp:ValidationSummary id="VSVerifDomParticular" runat="server" CssClass="text" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></TD>
										</TR>
										<TR>
											<td width="536" colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="text" align="right" style="height: 24px">
														<asp:button id="Rechazar" runat="server" Width="96px" Text="Rechazar" 
                                                                onclick="Rechazar_Click"></asp:button>&nbsp;&nbsp;
														<asp:button id="Aceptar" runat="server" Width="80px" Text="Aceptar" onclick="Aceptar_Click"></asp:button>&nbsp;&nbsp;
															<asp:button id="AceptarFinalizar" runat="server" Width="96px" Text="Aceptar y Finalizar" onclick="AceptarFinalizar_Click"></asp:button>&nbsp;&nbsp;
															<asp:button id="Cancelar" runat="server" Width="80px" Text="Cancelar" CausesValidation="False" onclick="Cancelar_Click"></asp:button>
														</TD>
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
				</td>
			</tr>
		</table>
		
    <asp:Panel ID="pnlPersonaPadron" runat="server" Width="500" Height="215" 
        CssClass="CajaDialogo" EnableViewState="false">
    <div style="padding: 4px; background-color: #32528E; color: #FFFFFF; font-family: Arial, Helvetica, sans-serif; ">
        <asp:Label ID="lblTitulo" runat="server" Text="Nombre de persona" />
    </div>
	<div style="top:40px; height:80px; text-align: center;" id="divProcesando">
		<img src="/img/ajax-loader.gif" style="vertical-align: middle" 
            alt="Procesando" />
		Procesando ...
	</div>
    <div id="DivNombres" style="padding-left: 2px; text-align:left; display:none;">
        Se encontraron mas de una persona con el número de DNI, seleccione:
        <div id="DivNombre1" class="caja2" onmouseover="seleccionar(this);" onmouseout="deseleccionar2(this);" onclick="seleccionarPersona2(this);">
            <span id="ResultsNombre1" style="font-weight:bold; text-align:left;"></span>
        </div>
        <div id="DivNombre2" class="caja2" onmouseover="seleccionar(this);" onmouseout="deseleccionar2(this);" onclick="seleccionarPersona2(this);">
            <span id="ResultsNombre2" style="font-weight:bold; text-align:left;"></span>
        </div>
    </div>
    <div style="height:80px; padding-left: 20px; text-align:left;">
        <div id="idDiv1" class="caja" style="display:none;" onmouseover="seleccionar(this);" onmouseout="deseleccionar(this);" onclick="seleccionarPersona(this, 1);">
        <span style="font-weight:normal">Apellidos: </span><span id="Results11" style="font-weight:bold"></span>&nbsp;&nbsp;&nbsp;
        <span style="font-weight:normal">Nombres: </span><span id="Results12" style="font-weight:bold"></span>
        </div>
        <div id="idDiv2" class="caja" style="display:none;" onmouseover="seleccionar(this);" onmouseout="deseleccionar(this);" onclick="seleccionarPersona(this, 2);">
        <span style="font-weight:normal">Apellidos: </span><span id="Results21" style="font-weight:bold"></span>&nbsp;&nbsp;&nbsp;
        <span style="font-weight:normal">Nombres: </span><span id="Results22" style="font-weight:bold"></span>
        </div>
        <div id="idDivError" class="caja" style="display:none;" onmouseover="seleccionar(this);" onmouseout="deseleccionar(this);">
            <span style="color:Red"><strong>La persona no existe en la base de datos</strong></span>
        </div>
    </div>
    <div align="center" style="height:30px; padding-top:10px;">
        &nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cerrar" 
            CausesValidation="False" /></div>
    </asp:Panel>
    </form>
	</body>
</HTML>
