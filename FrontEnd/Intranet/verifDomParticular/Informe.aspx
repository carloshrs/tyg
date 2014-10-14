<%@ Page Language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.verifDomParticular.Informe" CodeFile="Informe.aspx.cs" %>

<%@ Register TagPrefix="mnu" TagName="menu" Src="../Inc/menu.ascx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
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
                                Verificación de Domicilio Particular
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
                                                        <ContentTemplate >
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
                                                                        <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                                                            ControlToValidate="txtDocumento" 
                                                                            ErrorMessage="El documento debe ser un valor numérico" Operator="DataTypeCheck" 
                                                                            Type="Integer">*</asp:CompareValidator>
                                                                        </td>
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
                                                                        Estado civil</td>
                                                                    <td class="text" width="50%" colspan="2">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        <asp:DropDownList ID="cmbEstadoCivil" runat="server" Width="230px">
                                                                        </asp:DropDownList></td>
                                                                    <td class="text" width="50%" colspan="2">
                                                                    </td>
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
                                                                    <td class="text" width="50%" colspan="2">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="50%" colspan="4">
                                                                        <asp:TextBox ID="txtCalle" runat="server" Width="496px" MaxLength="250" Style="text-transform: uppercase;"></asp:TextBox></td>
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
                                                                    <td class="text" width="25%">
                                                                        Lote
                                                                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator4" runat="server" ControlToValidate="txtLote"
                                                                            ErrorMessage="Ingrese el Lote">*</asp:RequiredFieldValidator></td>
                                                                    <td class="text" width="25%">
                                                                        Manzana</td>
                                                                    <td class="text" width="25%">
                                                                        Complejo</td>
                                                                    <td class="text" width="25%">
                                                                        Torre</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="25%">
                                                                        <asp:TextBox ID="txtLote" runat="server" Width="100px" MaxLength="20" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    <td class="text" width="25%">
                                                                        <asp:TextBox ID="txtManzana" runat="server" Width="100px" MaxLength="10" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    <td class="text" align="left" width="25%">
                                                                        <asp:TextBox ID="txtComplejo" runat="server" Width="100px" MaxLength="10" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    <td class="text" align="left" width="25%">
                                                                        <asp:TextBox ID="txtTorre" runat="server" Width="100px" MaxLength="10" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
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
                                                                        <asp:TextBox ID="txtTelefono" runat="server" Width="230px" MaxLength="10" Style="text-transform: uppercase;"></asp:TextBox></td>
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
                                            <asp:Panel ID="pnlDomComercial" runat="server">
                                                <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td width="536">
                                                            <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td class="title" width="100%" bgcolor="lightgrey" height="10">
                                                                        &nbsp;&nbsp;
                                                                        <asp:Label ID="lblInforme" runat="server" CssClass="Title">Persona Jurídica</asp:Label></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="536">
                                                            Razón Social&nbsp;
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="RazonSocial"
                                                                ErrorMessage="Ingrese la razón social">*</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="536">
                                                            <asp:TextBox ID="RazonSocial" runat="server" Width="100%" MaxLength="255" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="536">
                                                            <table id="Table3" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td class="text" width="50%">
                                                                        Nombre de Fantasía</td>
                                                                    <td class="text" width="10%">
                                                                        Teléfono</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="50%">
                                                                        <asp:TextBox ID="NombreFantasia" runat="server" Width="320px" MaxLength="255" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    <td class="text" width="10%">
                                                                        <asp:TextBox ID="Telefono" runat="server" Width="200px" MaxLength="45" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="536">
                                                            <table id="Table4" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td class="text" width="50%">
                                                                        Rubro</td>
                                                                    <td class="text" width="10%">
                                                                        Cuit&nbsp;
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="Cuit"
                                                                            ErrorMessage="Ingrese el CUIT">*</asp:RequiredFieldValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="50%">
                                                                        <asp:TextBox ID="Rubro" runat="server" Width="320px" MaxLength="255" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    <td class="text" width="10%">
                                                                        <asp:TextBox ID="Cuit" runat="server" Width="200px" MaxLength="45" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="536">
                                                            <table id="Table5" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td class="text" width="70%">
                                                                        Calle&nbsp;
                                                                    </td>
                                                                    <td class="text" width="10%">
                                                                        Nro.&nbsp;
                                                                    </td>
                                                                    <td class="text" width="10%">
                                                                        Dpto.</td>
                                                                    <td class="text" width="10%">
                                                                        &nbsp;&nbsp;Piso</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="70%">
                                                                        <asp:TextBox ID="CalleEmpresa" runat="server" Width="320px" MaxLength="255" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    <td class="text" width="10%">
                                                                        <asp:TextBox ID="NroEmpresa" runat="server" Width="46px" MaxLength="10" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    <td class="text" width="10%">
                                                                        <asp:TextBox ID="DptoEmpresa" runat="server" Width="46px" MaxLength="10" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    <td class="text" align="right" width="10%">
                                                                        <asp:TextBox ID="PisoEmpresa" runat="server" Width="47px" MaxLength="10" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="536">
                                                            <table id="Table6" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td class="text" width="50%">
                                                                        Barrio&nbsp;
                                                                    </td>
                                                                    <td class="text" width="10%">
                                                                        Código Postal&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="50%">
                                                                        <asp:TextBox ID="BarrioEmpresa" runat="server" Width="320px" MaxLength="255" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    <td class="text" width="10%">
                                                                        <asp:TextBox ID="CPEmpresa" runat="server" Width="200px" MaxLength="45" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="536">
                                                            <table id="Table7" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td class="text" width="50%" height="14">
                                                                        Provincia
                                                                    </td>
                                                                    <td class="text" width="10%" height="14">
                                                                        Localidad&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="50%">
                                                                        <asp:DropDownList ID="cmbProvinciaEmpresas" runat="server" Width="268px" AutoPostBack="True"
                                                                            OnSelectedIndexChanged="cmbProvinciaEmpresas_SelectedIndexChanged">
                                                                        </asp:DropDownList></td>
                                                                    <td class="text" width="50%">
                                                                        <asp:DropDownList ID="cmbLocalidadEmpresas" runat="server" Width="268px">
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text">
                                                            &nbsp;&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
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
                                                        &nbsp;&nbsp; Gestión sobre la verificación</td>
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
                                                        Antiguedad</td>
                                                    <td class="text" width="25%">
                                                        Tel. alternativo</td>
                                                </tr>
                                                <tr>
                                                    <td class="text">
                                                        <asp:TextBox ID="txtFecha" runat="server" Width="80px" ReadOnly="True" Style="text-transform: uppercase;"></asp:TextBox>&nbsp;<img
                                                            id="imgFecha" style="cursor: hand" onclick="popFrame.fPopCalendar(imgFecha, txtFecha, divDateControl);"
                                                            alt="Abrir Calendario" src="/img/fecha.gif"></td>
                                                    <td class="text">
                                                        <asp:TextBox ID="txtHabita" runat="server" Width="100px" MaxLength="10" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                    <td class="text">
                                                        <asp:TextBox ID="txtAntiguedad" runat="server" Width="100px" MaxLength="10" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                    <td class="text">
                                                        <asp:TextBox ID="txtTelAlternativo" runat="server" Width="100px" MaxLength="10" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535" colspan="4">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="text" width="33%">
                                                        <p>
                                                            Monto alquiler</p>
                                                    </td>
                                                    <td class="text" width="33%">
                                                        Vencimiento de contrato</td>
                                                    <td class="text" width="33%">
                                                        Enviar correspondencia a</td>
                                                </tr>
                                                <tr>
                                                    <td class="text">
                                                        <asp:TextBox ID="txtMontoAlquiler" runat="server" Width="140px" Style="text-transform: uppercase;"></asp:TextBox>&nbsp;
                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtMontoAlquiler"
                                                            ErrorMessage="El monto debe ser numérico" ToolTip="El monto debe ser numérico"
                                                            Operator="DataTypeCheck" Type="Currency">*</asp:CompareValidator></td>
                                                    <td class="text">
                                                        <asp:TextBox ID="txtVencimiento" runat="server" Width="100px" ReadOnly="True" Style="text-transform: uppercase;"></asp:TextBox>&nbsp;<img
                                                            id="imgFechaVence" style="cursor: hand" onclick="popFrame.fPopCalendar(imgFechaVence, txtVencimiento, divDateControl);"
                                                            alt="Abrir Calendario" src="/img/fecha.gif"></td>
                                                    <td class="text">
                                                        <asp:TextBox ID="txtEnviar" runat="server" Width="140px" MaxLength="40" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" colspan="4">
                                            <table class="text" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td width="33%">
                                                        &nbsp;</td>
                                                    <td width="33%">
                                                    </td>
                                                    <td width="33%">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Tipo de vivienda</td>
                                                    <td>
                                                        Estado de conservación</td>
                                                    <td>
                                                        Tipo de construcción</td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <asp:RadioButtonList ID="raTipoVivienda" runat="server" CssClass="text">
                                                        </asp:RadioButtonList></td>
                                                    <td valign="top">
                                                        <asp:RadioButtonList ID="raEstadoCons" runat="server" CssClass="text">
                                                        </asp:RadioButtonList></td>
                                                    <td valign="top">
                                                        <asp:RadioButtonList ID="raTipoConstruccion" runat="server" CssClass="text">
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr>
                                                    <td height="14">
                                                    </td>
                                                    <td height="14">
                                                    </td>
                                                    <td height="14">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="14">
                                                        Tipo de Zona</td>
                                                    <td height="14">
                                                        Tipo de calle</td>
                                                    <td height="14">
                                                        Vive en caracter de</td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <asp:RadioButtonList ID="raTipoZona" runat="server" CssClass="text">
                                                        </asp:RadioButtonList></td>
                                                    <td valign="top">
                                                        <asp:RadioButtonList ID="raTipoCalle" runat="server" CssClass="text">
                                                        </asp:RadioButtonList></td>
                                                    <td valign="top">
                                                        <asp:RadioButtonList ID="raInteresado" runat="server" CssClass="text">
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="text" width="33%">
                                                        Acceso al domicilio&nbsp;</td>
                                                    <td class="text" width="33%">
                                                        Informó&nbsp;</td>
                                                    <td class="text" width="33%">
                                                        Relación&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text">
                                                        <asp:TextBox ID="txtAccesoDomicilio" runat="server" Width="150px" MaxLength="250"
                                                            Style="text-transform: uppercase;"></asp:TextBox></td>
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
                                            &nbsp;</td>
                                        <td class="text" width="50%" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="title" width="100%" bgcolor="lightgrey" colspan="3" height="10">
                                                        &nbsp;&nbsp; Referencia vecinal</td>
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
                                        <td class="text" width="175" colspan="4">
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
                                            Plano de&nbsp;ubicación</td>
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
                                                <asp:Image ID="imgFoto" runat="server" ImageUrl="/img/shim.gif" BorderWidth="1px" Width="250px"></asp:Image><br>
                                                <asp:HyperLink ID="hypMasFotos" runat="server" CssClass="text" NavigateUrl="#">Agregar Imágenes...</asp:HyperLink>
                                            </asp:Panel>
                                        </td>
                                    </tr>
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
                                                       <asp:button id="Rechazar" runat="server" Width="96px" Text="Rechazar" 
                                                            onclick="Rechazar_Click"></asp:button>&nbsp;&nbsp;
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
