<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.BusquedaPropiedad.Informe" CodeFile="Informe.aspx.cs" %>
<%@ Register TagPrefix="mnu" TagName="menu" Src="../Inc/menu.ascx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
  <HEAD>
		<title>Alta de Busqueda</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
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
				dv_solicitud.style.display = "";
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
		
			function ToggleImg(name, src, alt)
			{
				name.src = "/img/" + src;
				name.alt = alt
			}

            /*
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
            */

			function mostrarInfoAdicional() {
			    if (document.Form1.lblEncObservaciones.value != '')
			        mostrarFiltro(document.getElementById('imgSolicitud'));
			}

			function NuevaMatricula()
			{
				//window.open('abmTitular.aspx?idInforme=' + document.Form1.idInformePropiedad.value + '&porc=' + document.Form1.totalPorcentaje.value,'','dialogWidth:510px;dialogHeight:250px');
				window.showModalDialog('abmMatricula.aspx?idInforme=' + document.Form1.idInforme.value ,'','dialogWidth:510px;dialogHeight:250px');
		
				//Page_ValidationActive = false;
				//__doPostBack('','');
				document.location.reload();
			}


			</script>
</HEAD>
	<body leftmargin="0" topmargin="0" onload="mostrarInfoAdicional();">
					<form id="Form1" method="post" runat="server">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<table cellpadding="0" cellspacing="0" border="0">
			<tr>
				<td width="10">&nbsp;</td>
				<td>
					<br>
						<TABLE cellSpacing="0" cellPadding="0" width="640" border="0">
							<tr>
								<td class="title" width="100%">Búsqueda de Propiedad</td>
							</tr>
							<tr>
								<td width="100%" colspan="4">
							<table cellSpacing="0" cellPadding="0" width="580" border="0">
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
					                <td colspan="4">
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
										<TR>
											<td width="536" colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="576" border="0" height="176">
													<TR>
														<TD class="text" width="50%">
															<asp:panel id="pnlFisica" runat="server">
                        <TABLE height=152 cellSpacing=0 cellPadding=0 width=536 
                        border=0>
                          <TR>
                            <TD width=536 colSpan=2>
                              <TABLE height=18 cellSpacing=0 cellPadding=0 
                              width=536 border=0>
                                <TR>
                                <TD class=title width="100%" bgColor=lightgrey height=10>&nbsp;&nbsp; Datos 
                                personales</TD></TR></TABLE>&nbsp; </TD></TR>
                          <TR>
                            <TD class=text width="50%">Nombre&nbsp;</TD>
                            <TD class=text width="50%">Apellido&nbsp;</TD></TR>
                          <TR>
                            <TD class=text width="50%">
<asp:textbox id=txtNombre runat="server" Width="230px"></asp:textbox></TD>
                            <TD class=text width="50%">
<asp:textbox id=txtApellido runat="server" Width="100%"></asp:textbox></TD></TR>
                          <TR>
                            <TD class=text width="50%">Tipo de 
                              documento</TD>
                            <TD class=text width="50%">Documento 
<asp:requiredfieldvalidator id=Requiredfieldvalidator4 runat="server" ErrorMessage="Ingrese el nro de documento" ControlToValidate="txtDocumento">*</asp:requiredfieldvalidator>
<asp:CompareValidator id=CompareValidator1 runat="server" ErrorMessage="El valor del documento debe ser numérico" ControlToValidate="txtDocumento" Operator="DataTypeCheck" Type="Double">*</asp:CompareValidator></TD></TR>
                          <TR>
                            <TD class=text width="50%">
<asp:dropdownlist id=cmbTipoDocumento runat="server" Width="230px"></asp:dropdownlist></TD>
                            <TD class=text width="50%">
                                                                        <asp:TextBox ID="txtDocumento" runat="server" Width="196px" MaxLength="20" Style="text-transform: uppercase;"></asp:TextBox><asp:Button ID="btnObtener" runat="server" Text="?" onprerender="btnObtener_PreRender"  ToolTip="Consultar persona en Padrón"/>
                                                                        <cc1:ModalPopupExtender ID="imgCheckPersona_ModalPopupExtender" runat="server" 
                                                                            TargetControlID="btnObtener" DropShadow="True" BackgroundCssClass="FondoAplicacion" CancelControlID="btnCancelar" 
                                                                            PopupControlID="pnlPersonaPadron" OkControlID="btnCancelar">
                                                                        </cc1:ModalPopupExtender>
                                                                        <asp:ScriptManager ID="ScriptManager2" runat="server">
                                                                            <Services>
                                                                                <asp:ServiceReference  Path="../services/ServerTime.asmx" />
                                                                            </Services>
                                                                    </asp:ScriptManager>
</TD></TR>
</TABLE>
															</asp:panel>
															<asp:panel id="pnlDomComercial" runat="server">
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD width=536>
                              <TABLE cellSpacing=0 cellPadding=0 width="100%" 
                              border=0>
                                <TR>
                                <TD class=title width="100%" bgColor=lightgrey height=10>&nbsp;&nbsp; 
<asp:label id=lblInforme runat="server" CssClass="Title">Persona Jurídica</asp:label></TD></TR></TABLE></TD></TR>
                          <TR>
                            <TD class=text width=536>
                              <TABLE cellSpacing=0 cellPadding=0 width="100%" 
                              border=0>
                                <TR>
                                <TD class=text width="50%">Razón Social&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator8 runat="server" ErrorMessage="Ingrese la razón social" ControlToValidate="RazonSocial">*</asp:RequiredFieldValidator></TD>
                                <TD class=text width="50%">Cuit&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator9 runat="server" ErrorMessage="Ingrese el CUIT" ControlToValidate="Cuit">*</asp:RequiredFieldValidator></TD></TR>
                                <TR>
                            <TD class=text width="50%">
<asp:TextBox id=RazonSocial runat="server" Width="97%"></asp:TextBox></TD>
                                <TD class=text width="50%">
<asp:TextBox id=Cuit runat="server" Width="200px"></asp:TextBox></TD></TR></TABLE></TD></TR>
                          <TR>
                            <TD class=text width=536>
                              <TABLE cellSpacing=0 cellPadding=0 width="100%" 
                              border=0>
                                <TR>
                                <TD class=text width="100%" height=14>Provincia 
                                </TD>
                                </TR>
                                <TR>
                                <TD class=text width="100%">
<asp:dropdownlist id="cmbProvinciaEmpresas" runat="server" Width="268px"></asp:dropdownlist></TD>
                                </TR></TABLE></TD></TR>
</TABLE>
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
												<asp:textbox id="txtObservaciones" runat="server" Width="500px" TextMode="MultiLine" Rows="4">SE REALIZÓ LA BUSQUEDA DE PROPIEDADES EN TODA LA PROVINCIA DE CÓRDOBA, ARROJANDO COMO RESULTADO.</asp:textbox></TD>
										</TR>
										<TR>
											<TD class="text" width="50%" colSpan="2"><IMG height="10" src="/img/shim.gif" width="1"></TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4">
												<asp:datagrid id="dgMatriculas" runat="server" Width="100%" 
                                                    AutoGenerateColumns="False" BackColor="White"
													BorderStyle="None" BorderColor="#CCCCCC" CellPadding="3" Font-Size="8pt" BorderWidth="1px" 
                                                    onprerender="dgMatriculas_PreRender" onitemcommand="dgMatriculas_ItemCommand">
													<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
													<ItemStyle ForeColor="#000066"></ItemStyle>
													<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
													<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="idMatricula"></asp:BoundColumn>
														<asp:BoundColumn DataField="Matricula" HeaderText="Matricula">
															<HeaderStyle Width="150px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Dominio" HeaderText="Dominio">
															<HeaderStyle Width="150px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Folio" HeaderText="Folio">
															<HeaderStyle Width="80px"></HeaderStyle>
														</asp:BoundColumn>

														<asp:BoundColumn DataField="Tomo" HeaderText="Tomo">
															<HeaderStyle Width="80px"></HeaderStyle>
														</asp:BoundColumn>

														<asp:BoundColumn DataField="Ano" HeaderText="Año">
															<HeaderStyle Width="80px"></HeaderStyle>
														</asp:BoundColumn>
														
														<asp:BoundColumn DataField="Legajo" HeaderText="Legajo">
															<HeaderStyle Width="150px"></HeaderStyle>
														</asp:BoundColumn>
														
														<asp:BoundColumn DataField="FolioLegajo" HeaderText="Folio">
															<HeaderStyle Width="80px"></HeaderStyle>
														</asp:BoundColumn>
														
														<asp:BoundColumn DataField="AnoLegajo" HeaderText="Año">
															<HeaderStyle Width="80px"></HeaderStyle>
														</asp:BoundColumn>


														<asp:TemplateColumn>
															<HeaderStyle Width="20px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Editar" runat="server" ImageUrl="/img/modificar_general.gif" CausesValidation="False" Width="16px" ToolTip="Editar titular" CommandName="Editar"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="20px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="Borrar" runat="server" ImageUrl="\Img\Cruz.gif" CausesValidation="False" Width="16px" ToolTip="Borrar titular" CommandName="Borrar"></asp:ImageButton>
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
												<P align="right"><INPUT onclick="NuevaMatricula();" type="button" value="Nuevo"></P>
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
<asp:ValidationSummary id=VSBusquedaPropiedad runat="server" CssClass="text" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
											</TD>
										</TR>
									</table>
								</td>
							</tr>
						</TABLE>
						<input id="idInforme" type="hidden" name="idInforme" runat="server"> <input id="idReferencia" type="hidden" name="idReferencia" runat="server">
						<INPUT id="idTipoProp" type="hidden" name="idTipoProp" runat="server"> <INPUT id="idTipoPersona" type="hidden" name="idTipoPersona" runat="server">
				</td>
			</tr>
		</table>
<asp:Panel ID="pnlPersonaPadron" runat="server" Width="500" Height="215" 
        CssClass="CajaDialogo" EnableViewState="false" style="display:none;">
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
            CausesValidation="False" />
            </div>
    </asp:Panel>
					</form>
				</body>
</HTML>
