<%@ Page Language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.InspeccionAmbientalBancor.Informe" CodeFile="Informe.aspx.cs" %>

<%@ Register TagPrefix="mnu" TagName="menu" Src="../Inc/menu.ascx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<HEAD id="HEAD1" runat="server">
    <title>Alta de Informe</title>
    <link href="/CSS/Estilos.css" type="text/css" rel="stylesheet">

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
		
	
/*
        // This is the callback function that
        // processes the Web Service return value.
        function OnSucceeded(result)
        {
            var RsltElem = document.Form1.txtBarrio.value;
            RsltElem.innerHTML = result;
        }
*/
		
    </script>

</head>
<body leftmargin="0" topmargin="0" onload=" mostrarInfoAdicional();">
<form id="Form1" method="post" runat="server">
    <div id="divDateControl" style="z-index: 102; left: -35px; visibility: hidden; position: absolute;
        top: -150px">
        <iframe name="popFrame" src="/inc/calendar/calendar.htm" frameborder="0" width="160"
            scrolling="no" height="160"></iframe>
    </div>
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
    <table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td width="10">
                &nbsp;</td>
            <td>
                <br>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td class="title" width="100%">
                                Entrevista de Relevamiento Habitacional
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
					                        <td><i>E-mail:</i></td>
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
                                        <td class="text" width="260">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="536" colspan="4">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="text" width="50%">
                                                        <asp:Panel ID="pnlFisica" runat="server">
					                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                        <fieldset style="border: none;">
                                                            <table id="Table8" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td width="536" colspan="4">
                                                                        <table id="Table9" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="title" width="100%" bgcolor="lightgrey" height="10">
                                                                                    &nbsp;&nbsp; Datos personales</td>
                                                                            </tr>
                                                                        </table>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        Tipo de documento</td>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        Documento
                                                                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator4" runat="server" ControlToValidate="txtDocumento"
                                                                            ErrorMessage="Ingrese el nro de documento">*</asp:RequiredFieldValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        <asp:DropDownList ID="cmbTipoDocumento" runat="server" Width="230px">
                                                                        </asp:DropDownList></td>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        <asp:TextBox ID="txtDocumento" runat="server" Width="196px" MaxLength="20" Style="text-transform: uppercase;"></asp:TextBox><asp:Button ID="btnObtener" runat="server" Text="?" onprerender="btnObtener_PreRender"  ToolTip="Consultar persona en Padrón"/>
                                                                        <cc1:ModalPopupExtender ID="imgCheckPersona_ModalPopupExtender" runat="server" 
                                                                            TargetControlID="btnObtener" DropShadow="True" BackgroundCssClass="FondoAplicacion" CancelControlID="btnCancelar" 
                                                                            PopupControlID="pnlPersonaPadron" OkControlID="btnCancelar">
                                                                        </cc1:ModalPopupExtender>
                                                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                                            <Services>
                                                                                <asp:ServiceReference  Path="../services/ServerTime.asmx" />
                                                                            </Services>
                                                                        </asp:ScriptManager>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        Nombre&nbsp;
                                                                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="server" ControlToValidate="txtNombre"
                                                                            ErrorMessage="Ingrese el nombre">*</asp:RequiredFieldValidator></td>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        Apellido&nbsp;
                                                                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator3" runat="server" ControlToValidate="txtApellido"
                                                                            ErrorMessage="Ingrese el apellido">*</asp:RequiredFieldValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        <asp:TextBox ID="txtNombre" runat="server" Width="230px" MaxLength="200" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        <asp:TextBox ID="txtApellido" runat="server" Width="100%" MaxLength="200" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        &nbsp;</td>
                                                                    <td class="text" width="50%" colspan="2">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="536" colspan="4">
                                                                        <table id="Table10" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="title" width="100%" bgcolor="lightgrey" height="10">
                                                                                    &nbsp;&nbsp; Domicilio a verificar</td>
                                                                            </tr>
                                                                        </table>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        Calle&nbsp;
                                                                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator1" runat="server" ControlToValidate="txtCalle"
                                                                            ErrorMessage="Ingrese la calle">*</asp:RequiredFieldValidator></td>
                                                                    <td class="text" width="25%">
                                                                        Lote</td>
                                                                    <td class="text" width="25%">
                                                                        Manzana</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        <asp:TextBox ID="txtCalle" runat="server" Width="230px" MaxLength="250" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    <td class="text" align="left" width="25%">
                                                                        <asp:TextBox ID="txtLote" runat="server" Width="100px" MaxLength="10" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    <td class="text" align="left" width="25%">
                                                                        <asp:TextBox ID="txtManzana" runat="server" Width="100px" MaxLength="10" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="25%">
                                                                        Nro
                                                                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator11" runat="server" ControlToValidate="txtNro"
                                                                            ErrorMessage="Ingrese el Nro">*</asp:RequiredFieldValidator></td>
                                                                    <td class="text" width="25%">
                                                                        Piso</td>
                                                                    <td class="text" width="25%">
                                                                        Depto.</td>
                                                                    <td class="text" width="25%">
                                                                        C.P.</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="25%">
                                                                        <asp:TextBox ID="txtNro" runat="server" Width="100px" MaxLength="20" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    <td class="text" width="25%">
                                                                        <asp:TextBox ID="txtPiso" runat="server" Width="100px" MaxLength="10" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    <td class="text" align="left" width="25%">
                                                                        <asp:TextBox ID="txtDepto" runat="server" Width="100px" MaxLength="10" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    <td class="text" align="left" width="25%">
                                                                        <asp:TextBox ID="txtCP" runat="server" Width="100px" MaxLength="10" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        Complejo&nbsp;
                                                                    </td>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        Torre&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <TR>
                                                                    <TD class=text width="50%" colSpan=2><asp:TextBox ID="txtComplejo" runat="server" Width="230px" MaxLength="20" Style="text-transform: uppercase;"></asp:TextBox></TD>
                                                                    <TD class=text width="50%" colSpan=2><asp:TextBox ID="txtTorre" runat="server" Width="230px" MaxLength="20" Style="text-transform: uppercase;"></asp:TextBox>
                                                                    </TD></TR>
                                                                <tr>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        Barrio&nbsp;
                                                                    </td>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        Teléfono&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        <asp:TextBox ID="txtBarrio" runat="server" Width="100%" MaxLength="250" Style="width: 230px; text-transform: uppercase;"></asp:TextBox>
                                                                        <cc1:AutoCompleteExtender ID="txtBarrio_AutoCompleteExtender" runat="server" Enabled="true" 
                                                                            ServiceMethod="BuscarBarrio" ServicePath="../services/barrios.asmx" 
                                                                            MinimumPrefixLength="2" enablecaching="true"  TargetControlID="txtBarrio" UseContextKey="true" CompletionSetCount="10" 
                                                                            CompletionInterval="200" CompletionListCssClass="completionList" CompletionListHighlightedItemCssClass="itemHighlighted" CompletionListItemCssClass="listItem" >
                                                                        </cc1:AutoCompleteExtender>
                                                                            </td>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        <asp:TextBox ID="txtTelefono" runat="server" Width="230px" MaxLength="18" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        Provincia
                                                                    </td>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        Localidad&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        <asp:DropDownList ID="cmbProvincia" runat="server" Width="268px" AutoPostBack="True"
                                                                            OnSelectedIndexChanged="cmbProvincia_SelectedIndexChanged">
                                                                        </asp:DropDownList></td>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        <asp:DropDownList ID="cmbLocalidad" runat="server" onchange='actualizarBarrio();'>
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                            </table>
                                                      </fieldset>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>

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
                                    <tr>
                                        <td colspan="4">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="title" width="100%" bgcolor="lightgrey" colspan="3" height="10">
                                                        &nbsp;&nbsp; Gestión sobre la inspección</td>
                                                </tr>
                                            </table>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535" colspan="4">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="text" width="25%">
                                                        Fecha</td>
                                                    <td class="text" width="30%">
                                                        Habita en lugar declarado</td>
                                                    <td class="text" width="25%">
                                                        &nbsp;</td>
                                                    <td class="text" width="25%">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="text">
                                                        <asp:TextBox ID="txtFecha" runat="server" Width="80px" Style="text-transform: uppercase;"></asp:TextBox>&nbsp;
                                                        <cc1:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" 
                                                    TargetControlID="txtFecha"
                                                    PopupButtonID="imgFecha" 
                                                    PopupPosition="BottomRight"
                                                    Format="dd/MM/yyyy">
                                                </cc1:CalendarExtender>
                                                        <img
                                                            id="imgFecha" style="CURSOR: hand" 
                                                            alt="Abrir Calendario" src="/img/fecha.gif"></td>
                                                    <td class="text">
                                                        <asp:RadioButton ID="raHabitaSI" runat="server" GroupName="habita" Text="SI" />
                                                        <asp:RadioButton ID="raHabitaNO" runat="server" GroupName="habita" Text="NO" />
                                                    </td>
                                                    <td class="text">
                                                        &nbsp;</td>
                                                    <td class="text">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr><tr><td><strong>
                                        <br />
                                        Por Si</strong></td></tr>
                                                <tr>
                                                    <td class="text" width="50%" colspan="2">
                                                        ¿Cuantas personas integran el grupo famiilar?</td>
                                                    <td class="text" width="50%" colspan="2">
                                                        &nbsp;</td>
                                                </tr>
                                                <TR>
                                                    <TD class=text width="50%" colSpan=2><asp:TextBox ID="txtCantidadIntegran" runat="server" Width="230px" MaxLength="20" Style="text-transform: uppercase;"></asp:TextBox></TD>
                                                    <TD class=text width="50%" colSpan=2></TD></TR>
                                                    
                                                    
                                                    <tr><td><strong>
                                                        <br />
                                                        Por No</strong></td></tr>
                                                     <tr>
                                                    <td class="text" width="50%" colspan="2">
                                                        ¿Quien habita el inmueble?</td>
                                                    <td class="text" width="50%" colspan="2">
                                                        ¿En calidad de qué? (alquila, vendió)&nbsp;
                                                    </td>
                                                </tr>
                                                <TR>
                                                    <TD class=text width="50%" colSpan=2><asp:TextBox ID="txtQuienHabita" runat="server" Width="230px" MaxLength="20" Style="text-transform: uppercase;"></asp:TextBox></TD>
                                                    <TD class=text width="50%" colSpan=2><asp:TextBox ID="txtCalidadDe" runat="server" Width="230px" MaxLength="20" Style="text-transform: uppercase;"></asp:TextBox>
                                                    </TD></TR>
                                                    <tr><td></td></tr>

                                                    <tr><td colspan="2"><strong>
                                                        <br />
                                                        ¿Han realizado ampliaciones o mejoras?</strong></td><td class="text">
                                                        <asp:RadioButton ID="raAmpliacionesSI" runat="server" GroupName="ampliaciones" Text="SI" />
                                                        <asp:RadioButton ID="raAmpliacionesNO" runat="server" GroupName="ampliaciones" Text="NO" />
                                                    </td></tr>
                                                     <tr>
                                                    <td class="text" width="50%" colspan="2">
                                                        <br />
                                                        ¿Cuales?</td>
                                                    <td class="text" width="50%" colspan="2">
                                                    </td>
                                                </tr>

                                                <TR>
                                                    <TD class=text width="50%" colSpan=4><asp:TextBox ID="txtAmpliacionesCuales" runat="server" Width="450px" MaxLength="20" Style="text-transform: uppercase;"></asp:TextBox></TD>
                                                    </TR>


                                                <tr><td>&nbsp;</td></tr>

                                                    <tr><td colspan="2"><strong>¿Trabaja de forma dependiente o independiente?</strong></td><td class="text">
                                                        <asp:RadioButton ID="raDependiente" runat="server" GroupName="dependiente" Text="Dependiente" />
                                                        <asp:RadioButton ID="raIndependiente" runat="server" GroupName="dependiente" Text="Independiente" />
                                                    </td></tr>
                                                    <tr>
                                                    <td class="text" width="50%" colspan="2"><br />
                                                        Dependiente:&nbsp;</td>
                                                    <td class="text" width="50%" colspan="2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                    <tr>
                                                    <td class="text" width="50%" colspan="2">
                                                        Empresa&nbsp;</td>
                                                    <td class="text" width="50%" colspan="2">
                                                        Dirección&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text" colspan="2">
                                                        <asp:TextBox ID="txtEmpresa" runat="server" Width="150px" MaxLength="250" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                    <td class="text" colspan="2">
                                                        <asp:TextBox ID="txtDireccion" runat="server" Width="150px" MaxLength="250" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                </tr>

                                                <tr><td colspan="4">&nbsp;</td></tr>
                                                <tr>
                                                    <td class="text" width="50%" colspan="2">
                                                        Ingresos netos mensuales&nbsp;</td>
                                                    <td class="text" width="50%" colspan="2">
                                                        Banco donde le acreditan los haberes&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text" colspan="2">
                                                        <asp:TextBox ID="txtIngresosMensuales" runat="server" Width="150px" MaxLength="250" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                    <td class="text" colspan="2">
                                                        <asp:TextBox ID="txtBanco" runat="server" Width="150px" MaxLength="250" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="text" width="50%" colspan="2"><br />
                                                        Independiente:&nbsp;</td>
                                                    <td class="text" width="50%" colspan="2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                
                                                    <td class="text" width="50%" colspan="2"><br />
                                                        Dependiente:&nbsp;</td>
                                                    <td class="text" width="50%" colspan="2">
                                                        &nbsp;
                                                    </td>
                                                <tr>
                                                    <td class="text" width="50%" colspan="2">
                                                        ¿Que actividad tiene?&nbsp;</td>
                                                    <td class="text" width="50%" colspan="2">
                                                        ¿Donde la desarrolla?&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text" colspan="2">
                                                        <asp:TextBox ID="txtActividad" runat="server" Width="150px" MaxLength="250" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                    <td class="text" colspan="2">
                                                        <asp:TextBox ID="txtDondeDesarrolla" runat="server" Width="150px" MaxLength="250" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                </tr>

                                                <tr><td>&nbsp;</td></tr>

                                                    <tr><td colspan="2"><strong>Indique la suma de ingresos netos familiares:</strong></td><td class="text" colspan="2">
                                                        <asp:TextBox ID="txtIngresosNetosFamiliares" runat="server" Width="150px" MaxLength="250" Style="text-transform: uppercase;"></asp:TextBox>
                                                    </td></tr>
                                                    <tr><td>&nbsp;</td></tr>

                                                    <tr><td colspan="2"><strong>¿Servicios o impuestos a su nombre?</strong></td><td class="text">
                                                        <asp:RadioButton ID="raImpuestosSI" runat="server" GroupName="impuestos" Text="SI" />
                                                        <asp:RadioButton ID="raImpuestosNO" runat="server" GroupName="impuestos" Text="NO" />
                                                    </td></tr>

                                                </tr>
                                    <tr>
                                        <td class="text" colspan="4">
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="text" width="50%">
                                                        Informó&nbsp;</td>
                                                    <td class="text" width="50%">
                                                        Relación&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text">
                                                        <asp:TextBox ID="txtInformo" runat="server" Width="150px" MaxLength="250" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                    <td class="text">
                                                        <asp:TextBox ID="txtRelacion" runat="server" Width="150px" MaxLength="250" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="261" colspan="2">
                                            &nbsp;&nbsp;</td>
                                        <td class="text" width="50%" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="title" width="100%" bgcolor="lightgrey" colspan="3" height="10">
                                                        &nbsp;&nbsp; Referencia vecinal 1</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="text">
                                                        Apellido y nombre</td>
                                                    <td class="text">
                                                        Domicilio</td>
                                                    <td class="text">
                                                        Conoce a la persona</td>
                                                </tr>
                                                <tr>
                                                    <td class="text">
                                                        <asp:TextBox ID="txtNombreVecino" runat="server" Width="150px" MaxLength="250" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                    <td class="text">
                                                        <asp:TextBox ID="txtDomicilioVecino" runat="server" Width="150px" MaxLength="250"
                                                            Style="text-transform: uppercase;"></asp:TextBox></td>
                                                    <td class="text">
                                                        <asp:TextBox ID="txtConoceVecino" runat="server" Width="150px" MaxLength="250" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="title" width="100%" bgcolor="lightgrey" colspan="3" height="10">
                                                        &nbsp;&nbsp; Referencia vecinal 2</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="text">
                                                        Apellido y nombre</td>
                                                    <td class="text">
                                                        Domicilio</td>
                                                    <td class="text">
                                                        Conoce a la persona</td>
                                                </tr>
                                                <tr>
                                                    <td class="text">
                                                        <asp:TextBox ID="txtNombreVecino2" runat="server" Width="150px" MaxLength="250" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                    <td class="text">
                                                        <asp:TextBox ID="txtDomicilioVecino2" runat="server" Width="150px" MaxLength="250"
                                                            Style="text-transform: uppercase;"></asp:TextBox></td>
                                                    <td class="text">
                                                        <asp:TextBox ID="txtConoceVecino2" runat="server" Width="150px" MaxLength="250" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="175" colspan="4">
                                            <br />
                                            <asp:Label ID="Label5" runat="server">Observaciones</asp:Label>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="100%" colspan="4">
                                            <asp:TextBox ID="txtObservaciones" runat="server" Width="100%" TextMode="MultiLine"
                                                Rows="5" CssClass="Plano"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="text" align="center" width="50%" colspan="2">
                                            &nbsp;</td>
                                        <td valign="top" width="50%" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="50%" colspan="2">
                                            Plano de&nbsp;ubicación del inmueble</td>
                                        <td class="text" valign="top" width="50%" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" align="center" width="50%" colspan="2">
                                            <p align="left">
                                                <img height="200" src="/img/plano.gif" width="200" border="1">&nbsp;<br>
                                            </p>
                                        </td>
                                        <td valign="top" width="50%">
                                            <table class="text" cellspacing="1" cellpadding="2">
                                                <tr>
                                                    <td>
                                                        Ubicación <b>A</b></td>
                                                    <td>
                                                        <asp:TextBox ID="txtPlanoA" runat="server" Width="150px" MaxLength="200" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Ubicación <b>B</b></td>
                                                    <td>
                                                        <asp:TextBox ID="txtPlanoB" runat="server" Width="150px" MaxLength="200" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Ubicación <b>C</b></td>
                                                    <td>
                                                        <asp:TextBox ID="txtPlanoC" runat="server" Width="150px" MaxLength="200" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Ubicación <b>D</b></td>
                                                    <td>
                                                        <asp:TextBox ID="txtPlanoD" runat="server" Width="150px" MaxLength="200" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" align="left" colspan="5">
                                            <asp:Panel ID="pnlImagenes" runat="server">
                                                <asp:Image ID="imgFoto" runat="server" ImageUrl="/img/shim.gif" BorderWidth="1px" Width="250"></asp:Image><br>
                                                <asp:HyperLink ID="hypMasFotos" runat="server" CssClass="text" NavigateUrl="#">Agregar Imágenes...</asp:HyperLink>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr><td colspan="5">
                                    
                                    <tr>
                                        <td width="535" colspan="4">
                                            <hr>
                                            <asp:Label ID="lblMessage" runat="server" Visible="False" ForeColor="Red" Font-Bold="True">Debe agregar imágenes para finalizar...</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="536" colspan="4">
                                            <asp:ValidationSummary ID="VSVerifDomParticular" runat="server" CssClass="text" ShowSummary="False"
                                                ShowMessageBox="True"></asp:ValidationSummary>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="536" colspan="4">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="text" align="right">
                                                        <asp:Button ID="Aceptar" runat="server" Width="48px" Text="Aceptar" OnClick="Aceptar_Click">
                                                        </asp:Button>&nbsp;&nbsp;
                                                        <asp:Button ID="AceptarFinalizar" runat="server" Width="96px" Text="Aceptar y Finalizar"
                                                            OnClick="AceptarFinalizar_Click"></asp:Button>&nbsp;&nbsp;
                                                        <asp:Button ID="Cancelar" runat="server" CausesValidation="False" Width="48px" Text="Cancelar"
                                                            OnClick="Cancelar_Click"></asp:Button></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <input id="idInforme" type="hidden" name="idInforme" runat="server">
                    <input id="idReferencia" type="hidden" name="idReferencia" runat="server">
                    <input id="idTipoProp" type="hidden" name="idTipoProp" runat="server"><input id="idTipoPersona"
                        type="hidden" name="idTipoPersona" runat="server">
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
            CausesValidation="False" />
            </div>
    </asp:Panel>
</form>
</body>
</html>
