<%@ Page Language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.InformePropiedad.Informe"
    CodeFile="Informe.aspx.cs" 
    EnableEventValidation="false" %>

<%@ Register TagPrefix="mnu" TagName="menu" Src="../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Alta de Informe</title>
    <link href="/CSS/Estilos.css" type="text/css" rel="stylesheet">

    <script src="../Inc/divBusqueda.js" type="text/javascript"></script>
    <script src="../Includes/entertab.js" type="text/javascript"></script>
    <script>
            function ToggleImg(name, src, alt)
			{
				name.src = "/img/" + src;
				name.alt = alt;
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
			
			function NuevoTitular()
			{
				window.showModalDialog('abmTitular.aspx?idInforme=' + document.Form1.idInformePropiedad.value + '&porc=0&porcTotal=' + document.Form1.totalPorcentaje.value,'','dialogWidth:510px;dialogHeight:300px');
				Page_ValidationActive = false;
				document.getElementById('hAccion').value = 1;
				__doPostBack('hAccion','');
			}
			
			function EditarTitular(titular)
			{
				window.showModalDialog('abmTitular.aspx?idInforme=' + document.Form1.idInformePropiedad.value + '&porc=0&porcTotal=' + document.Form1.totalPorcentaje.value + '&IdTitular=' + titular,'','dialogWidth:510px;dialogHeight:300px');
				Page_ValidationActive = false;
				document.getElementById('hAccion').value = 1;
				__doPostBack('hAccion','');
			}
			
			function validarPorcTotal()
			{
				/*if(document.Form1.totalPorcentaje.value >=100)
					{
						alert('La suma de los porcentajes no debe superar el 100%')
						return false;
					}*/
			}
			
			function ChequearMatricula()
			{
				argumentos = "";
				vId = document.forms[0].idInformePropiedad.value;
				vTipoInforme = 1;
				vProvincia = 2;
				vLegajo = document.forms[0].txtLegajo.value;
				
				argumentos = "id=" + vId + "&idProvincia=" + vProvincia + "&tipoInforme=" + vTipoInforme + "&tipo=" + document.forms[0].idTipoProp.value + "&legajo=" + vLegajo;
				if(document.forms[0].idTipoProp.value == 2 || document.forms[0].idTipoProp.value == 3)
				{
					vFolio = document.forms[0].txtFolio.value;
					vAno = document.forms[0].txtAno.value;
					vTomo = document.forms[0].txtTomo.value;
					argumentos = argumentos + "&folio=" + vFolio + "&ano=" + vAno + "&tomo=" + vTomo;
				}
				window.showModalDialog('/Admin/Informes/MatriculaCheck.aspx?' + argumentos, '', 'dialogWidth:640px;dialogHeight:480px');
			}
		    function AJAX_buscar( textRef, valor )
            {
                HTTP_response = request();
                if( HTTP_response == null )
	                return;
                HTTP_response.onreadystatechange = tomarRespuesta;
                HTTP_response.open('GET', '../Inc/a_barrios.aspx?query='+valor+"&localidad="+document.Form1.cmbLocalidad.value, true);
                HTTP_response.send(null);
            }
            
            function setRetornoBusqueda( textRef, valor )
            {
                textRef.value = valor;
                cerrarBusqueda();
            }
            
            function actualizarBarrio()
            {
                document.Form1.txtBarrio.value = '';
                bsq_criterio = null;
            }
    </script>

</head>
<body leftmargin="0" topmargin="0" onload="mostrarInfoAdicional();">
                <form id="Form1" method="post" runat="server">
    <div id="divBusqueda" style="top: 50px; left: 420px; width: auto; height: 100px;
        overflow-y: scroll; position: absolute; border-style: solid; border-width: 1px;
        display: none; background-color: #F5F5F5;">
        <table style="width: 390px" cellpadding="1" cellspacing="0" onmouseout="limpiarBSQ();">
            <tbody id="bsqCuerpo" style="font-family: Arial, Verdana, Helvetica, Sans-Serif;
                font-size: 8pt;">
            </tbody>
        </table>
    </div>
    <mnu:menu ID="Menu" runat="server"></mnu:menu>
    <table cellspacing="0" cellpadding="0" border="0">
        <tr>
            <td width="20">
                &nbsp;</td>
            <td>
                <br>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td class="title" width="100%">
                                Solicitud de Informe de propiedad<br>
                            </td>
                        </tr>
                        <tr><td>
                            <table cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td class="text">Solicitado por:
										<asp:label id="lblSolicitante" runat="server" Font-Bold="True"></asp:label></td>
								</tr>
								<tr>
									<td class="text" colSpan="2">Referencia:
										<asp:label id="lblRef" runat="server" Font-Bold="True"></asp:label></td>
								</tr>
							</table><br />
                        </td></tr>
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
                                <table cellspacing="0" cellpadding="0" width="480" border="0">
                                    <tr>
                                        <td class="text" width="100%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="536" colspan="4">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="text" width="50%">
                                                        
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td width="536" colspan="4">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td class="title" width="100%" bgcolor="lightgrey" colspan="3" height="10">
                                                                                &nbsp;&nbsp; 
                                                                                <asp:Label ID="lblTitUbicacion" runat="server" Text="Identificación y ubicación del inmueble"></asp:Label></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" width="175" colspan="4">
                                                                    <asp:Label ID="lblTipoPropiedad" runat="server" Font-Bold="True">Nro de Matricula</asp:Label>&nbsp;
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Ingrese el nro de matricula"
                                                                        ControlToValidate="txtLegajo">*</asp:RequiredFieldValidator><!--<asp:ImageButton ID="imgCheckMatricula"
                                                                            runat="server" CausesValidation="False" ImageUrl="/Img/getinfo.gif"></asp:ImageButton>---></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" width="100%" colspan="4">
                                                                    <asp:TextBox ID="txtLegajo" runat="server" MaxLength="45" Width="100%"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" width="175">
                                                                    <asp:Label ID="lblFolio" runat="server">Folio</asp:Label>&nbsp;</td>
                                                                <td class="text" width="133">
                                                                    <asp:Label ID="lblTomo" runat="server">Tomo</asp:Label></td>
                                                                <td class="text" width="33%">
                                                                    <asp:Label ID="lblAno" runat="server">Año</asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" width="175">
                                                                    <asp:TextBox ID="txtFolio" runat="server" MaxLength="20" Width="100px"></asp:TextBox></td>
                                                                <td class="text" width="133">
                                                                    <asp:TextBox ID="txtTomo" runat="server" MaxLength="20" Width="100px"></asp:TextBox></td>
                                                                <td class="text" align="left" width="33%">
                                                                    <asp:TextBox ID="txtAno" runat="server" MaxLength="20" Width="100px"></asp:TextBox></td>
                                                            </tr>
                                                            </table>
                                                        <asp:Panel ID="pnPlanilla" runat="server">
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td class="text" width="175" colspan="4">
                                                                    <asp:Label ID="Label5" runat="server">Propiedad de:</asp:Label>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" width="100%" colspan="4">
                                                                    <asp:TextBox ID="txtPropiedadDe" runat="server" MaxLength="255" Width="100%" 
                                                                        Style="text-transform: uppercase;"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" width="175" colspan="4">
                                                                    <asp:Label ID="Label6" runat="server">Ubicada en:</asp:Label>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" width="100%" colspan="4">
                                                                    <asp:TextBox ID="txtUbicadaEn" runat="server" MaxLength="255" Width="100%" 
                                                                        Style="text-transform: uppercase;"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" width="175" colspan="4">
                                                                    <asp:Label ID="Label9" runat="server">Dominio antecedente:</asp:Label>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" width="100%" colspan="4">
                                                                    <asp:TextBox ID="txtDominioAntecedente" runat="server" MaxLength="255" Width="100%" 
                                                                        Style="text-transform: uppercase;"></asp:TextBox></td>
                                                            </tr>
                                                            </table>
                                                        </asp:Panel>
                                                            <asp:Panel ID="pnUbicacion" runat="server">
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td class="text" width="175" colspan="4">
                                                                    <asp:Label ID="Label1" runat="server">Barrio</asp:Label>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" width="100%" colspan="4">
                                                                    <asp:TextBox ID="txtBarrio" runat="server" MaxLength="255" Width="100%" onKeyUp="bsq_buscar_text(this);"
                                                                        onKeyDown="return bsq_tomarTecla(event);" Style="text-transform: uppercase;"
                                                                        onBlur="cerrarBusqueda();"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" width="270" colspan="2">
                                                                    <asp:Label ID="Label3" runat="server">Pedanía</asp:Label>&nbsp;</td>
                                                                <td class="text" width="50%" colspan="2">
                                                                    <asp:Label ID="Label4" runat="server">Localidad</asp:Label>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" width="270" colspan="2">
                                                                    <asp:TextBox ID="txtPedania" runat="server" MaxLength="255" Width="215px"></asp:TextBox></td>
                                                                <td class="text" width="50%" colspan="2">
                                                                    <asp:DropDownList ID="cmbLocalidad" runat="server" Width="100%">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" width="270" colspan="2" height="4">
                                                                    <asp:Label ID="Label2" runat="server">Departamento</asp:Label>&nbsp;</td>
                                                                <td class="text" width="50%" colspan="2" height="4">
                                                                    <asp:Label ID="Label8" runat="server">Provincia</asp:Label>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" width="270" colspan="2" height="10">
                                                                     <asp:TextBox ID="txtDepartamento" runat="server" MaxLength="255" Width="215px"></asp:TextBox></td>
                                                                    
                                                                <td class="text" width="50%" colspan="2" height="10">
                                                                    <asp:DropDownList ID="cmbProvincia" runat="server" Width="100%" AutoPostBack="True"
                                                                        OnSelectedIndexChanged="cmbProvincia_SelectedIndexChanged">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" width="25%">
                                                                    PH</td>
                                                                <td class="text" width="25%">
                                                                    Lote</td>
                                                                <td class="text" width="25%">
                                                                    Manzana</td>
                                                                <td class="text" width="25%">
                                                                    Superficie</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="text" width="25%">
                                                                    <asp:TextBox ID="txtPH" runat="server" MaxLength="10" Width="100px"></asp:TextBox></td>
                                                                <td class="text" width="133">
                                                                    <asp:TextBox ID="txtLote" runat="server" MaxLength="100" Width="100px"></asp:TextBox></td>
                                                                <td class="text" align="left" width="25%">
                                                                    <asp:TextBox ID="txtManzana" runat="server" MaxLength="10" Width="100px"></asp:TextBox></td>
                                                                <td class="text" align="left" width="25%">
                                                                    <asp:TextBox ID="txtSuperficie" runat="server" MaxLength="30" Width="100px"></asp:TextBox></td>
                                                            </tr>
                                                            </table>
                                                            </asp:Panel>
                                                        
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535" colspan="4">
                                            &nbsp;</td>
                                    </tr>
                                    </table>
                                    <asp:Panel ID="pnTitulares" runat="server">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td colspan="4">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="title" width="100%" bgcolor="lightgrey" colspan="3" height="10">
                                                        &nbsp;&nbsp; Titulares del inmueble</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535" colspan="4">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="text" colspan="4">
                                            <asp:DataGrid ID="dgTitulares" runat="server" Width="100%" Font-Size="8pt" AutoGenerateColumns="False"
                                                CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CCCCCC"
                                                OnPreRender="dgTitulares_PreRender">
                                                <SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
                                                <ItemStyle ForeColor="#000066"></ItemStyle>
                                                <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
                                                <FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
                                                <Columns>
                                                    <asp:BoundColumn Visible="False" DataField="idTitular"></asp:BoundColumn>
                                                    <asp:BoundColumn Visible="False" DataField="IdTipoPersona" HeaderText="Tipo">
                                                        <HeaderStyle Width="5px"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Nombre" HeaderText="Apellido y Nombre&lt;br&gt; Raz&oacute;n Social">
                                                        <HeaderStyle Width="35%"></HeaderStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="NroDoc" HeaderText="Documento&lt;br&gt;CUIT">
                                                        <HeaderStyle Width="20%"></HeaderStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="EstadoCivil" HeaderText="Estado Civil">
                                                        <HeaderStyle Width="65px"></HeaderStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Porcentaje" HeaderText="Proporci&#243;n">
                                                        <HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <FooterStyle HorizontalAlign="Center"></FooterStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn Visible="False" DataField="Porcentaje" HeaderText="Porcentaje">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn Visible="False" DataField="NombreFantasia" HeaderText="Nombre Fantasia">
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn Visible="False" DataField="RazonSocial" HeaderText="Razon Social"></asp:BoundColumn>
                                                    <asp:BoundColumn Visible="False" DataField="Rubro" HeaderText="Rubro"></asp:BoundColumn>
                                                    <asp:BoundColumn Visible="False" DataField="Cuit" HeaderText="Cuit"></asp:BoundColumn>
                                                    <asp:TemplateColumn>
                                                        <HeaderStyle Width="20px"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Editar" runat="server" ImageUrl="/img/modificar_general.gif"
                                                                CausesValidation="False" Width="16px" ToolTip="Editar titular" CommandName="Editar">
                                                            </asp:ImageButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn>
                                                        <HeaderStyle Width="20px"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Borrar" runat="server" ImageUrl="/Img/Cruz.gif" Width="16px"
                                                                ToolTip="Borrar titular" CommandName="Borrar" CausesValidation="false"></asp:ImageButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                                <PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages">
                                                </PagerStyle>
                                            </asp:DataGrid></td>
                                    </tr>
                                    <tr>
                                        <td class="text" colspan="4">
                                            <p align="right">
                                                
                                                &nbsp;<input id="totalPorcentaje" type="hidden" name="totalPorcentaje" runat="server"><asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClientClick="NuevoTitular();" /></p>
                                        </td>
                                    </tr> 
                                    <tr>
                                        <td class="text" width="535" colspan="4">
                                            &nbsp;</td>
                                    </tr>
                                    </table>
                                    </asp:Panel>
                                   
                                    <asp:Panel ID="pnGravamenes" runat="server">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td>
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="title" width="100%" bgcolor="lightgrey" height="10">
                                                        &nbsp;&nbsp; Gravámenes y restricciones</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535">
                                            <asp:TextBox ID="txtGravamenes" runat="server" MaxLength="255" Width="100%" TextMode="MultiLine"
                                                Rows="5" Height="79px" CssClass="Plano"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535">
                                            &nbsp;</td>
                                    </tr>
                                    </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnInformesAnteriores" runat="server">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td>
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="title" width="100%" bgcolor="lightgrey" height="10">
                                                        &nbsp;&nbsp; Informes Anteriores</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535">
                                            <asp:TextBox ID="txtInformesAnteriores" runat="server" MaxLength="255" Width="100%"
                                                TextMode="MultiLine" Rows="5" Height="79px" CssClass="Plano"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535">
                                            &nbsp;</td>
                                    </tr>
                                    </table>
                                    </asp:Panel>
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td colspan="4">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="title" width="100%" bgcolor="lightgrey" colspan="3" height="10">
                                                        &nbsp;&nbsp; Observaciones</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535" colspan="4">
                                            <asp:TextBox ID="txtObservaciones" runat="server" MaxLength="255" Width="100%" TextMode="MultiLine"
                                                Rows="5" Height="79px" CssClass="Plano"></asp:TextBox></td>
                                    </tr>
                                    </table>
                                    <asp:Panel ID="pnResultado" runat="server">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td class="text" width="175">
                                            <asp:Label ID="Label7" runat="server">Resultado</asp:Label>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="100%">
                                            <asp:TextBox ID="txtResultado" runat="server" MaxLength="255" Width="100%"></asp:TextBox></td>
                                    </tr>

                                    <TR>
											<TD class="text" align="left" colSpan="2">
                                                <br />
                                                Adjuntar PDF de Registro de la Propiedad (matricula, folio, legajo)<br />
                                                <asp:FileUpload ID="txtArchivo" runat="server" /><br />
                                                <asp:RequiredFieldValidator ID="reqArchivo" runat="server" ErrorMessage="Adjuntar PDF de Registro de Propiedad" ValidationGroup="principal" ControlToValidate="txtArchivo" Text="*"></asp:RequiredFieldValidator>
                                                <br /><br />
                                                <asp:Image ID="imgArchivo" runat="server" ImageUrl="~/Img/shim.gif" />&nbsp;<asp:HyperLink ID="hlArchivo" runat="server" CssClass="text" Target="_blank"><asp:Label ID="lblArchivo" runat="server" Text=""></asp:Label></asp:HyperLink>
                                                <br /><br />
                                            </TD></TR>

                                            <tr>
                                        <td class="text" width="100%">
                                            Tipo de envío: <asp:Label ID="lblTipoEnvio" runat="server" Font-Bold="true" Font-Size="Larger" ></asp:Label></td>
                                        </tr>
										<TR>
											<td width="100%" colSpan="4">
												<hr SIZE="2">
											</td>
										</TR>

                                    <tr>
                                        <td width="535">
                                            <hr>
                                        </td>
                                    </tr>
                                    </table>
                                    </asp:Panel>
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td width="535" colspan="4">
                                            <asp:ValidationSummary ID="VSVerifDomParticular" runat="server" CssClass="text" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="principal"></asp:ValidationSummary>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="536" colspan="4">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="text" align="right" width="50%">
                                                        <asp:Button ID="btnImprimir" runat="server" OnClick="btnImprimir_Click" Text="Imprimir vista previa" />&nbsp;
														<asp:button id="Rechazar" runat="server" Width="96px" Text="Rechazar" 
                                                            onclick="Rechazar_Click"></asp:button>&nbsp;
                                                        <asp:Button ID="Aceptar" runat="server" Width="96px" Text="Revisión" OnClick="Aceptar_Click">
                                                        </asp:Button>&nbsp;&nbsp;
                                                        <asp:Button ID="AceptarFinalizar" runat="server" Width="" Text="Aceptar y Finalizar"
                                                            OnClick="AceptarFinalizar_Click"></asp:Button>&nbsp;&nbsp;
                                                        <asp:Button ID="Cancelar" runat="server" CausesValidation="False" Width="" Text="Cancelar"
                                                            OnClick="Cancelar_Click"></asp:Button></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <input id="idInformePropiedad" type="hidden" name="idInformePropiedad" runat="server">
                    <input id="idReferencia" type="hidden" name="idReferencia" runat="server">
                    <input id="idTipoProp" type="hidden" name="idTipoProp" runat="server">
                    <asp:HiddenField ID="hAccion" runat="server" OnValueChanged="hAccion_ValueChanged" Value="0" />
            </td>
        </tr>
    </table>
                </form>
            </body>
</html>
