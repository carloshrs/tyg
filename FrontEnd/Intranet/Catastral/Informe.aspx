<%@ Page Language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Catastral.Informe" CodeFile="Informe.aspx.cs" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td width="10">
                &nbsp;</td>
            <td>
                <br>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td class="title" width="100%">
                                Informe Catastral
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
                                        <td width="536" colspan="2">
                                            <table id="Table8" cellspacing="0" cellpadding="0" width="100%" border="0">

                                                                <tr>
                                                                    <td width="536" colspan="4">
                                                                        <table id="Table10" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="title" width="100%" bgcolor="lightgrey" height="10">
                                                                                    &nbsp;&nbsp; Ubicación del inmueble</td>
                                                                            </tr>
                                                                        </table>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="50%" colspan="2">
                                                                        Calle&nbsp;
                                                                        </td>
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
                                                                        </td>
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
                                                                        Complejo&nbsp;
                                                                    </td>
                                                                    <td class="text" width="25%">
                                                                        Torre &nbsp;
                                                                    </td>

                                                                    <td class="text" width="50%" colspan="2">
                                                                        Barrio&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <TR>
                                                                    <TD class=text width="25%"><asp:TextBox ID="txtComplejo" runat="server" Width="100px" MaxLength="20" Style="text-transform: uppercase;"></asp:TextBox></TD>
                                                                    <TD class=text width="25%"><asp:TextBox ID="txtTorre" runat="server" Width="100px" MaxLength="20" Style="text-transform: uppercase;"></asp:TextBox>
                                                                    </TD>
                                                                    <TD class=text width="50%" colSpan=2>                                                                        <asp:TextBox ID="txtBarrio" runat="server" Width="100%" MaxLength="250" Style="width: 230px; text-transform: uppercase;"></asp:TextBox>
                                                                        <cc1:AutoCompleteExtender ID="txtBarrio_AutoCompleteExtender" runat="server" Enabled="true" 
                                                                            ServiceMethod="BuscarBarrio" ServicePath="../services/barrios.asmx" 
                                                                            MinimumPrefixLength="2" enablecaching="true"  TargetControlID="txtBarrio" UseContextKey="true" CompletionSetCount="10" 
                                                                            CompletionInterval="200" CompletionListCssClass="completionList" CompletionListHighlightedItemCssClass="itemHighlighted" CompletionListItemCssClass="listItem" >
                                                                        </cc1:AutoCompleteExtender>
</TD>
                                                                    </TR>
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

                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535" colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="title" width="100%" bgcolor="lightgrey" colspan="3" height="10">
                                                        &nbsp;&nbsp; Identificación</td>
                                                </tr>
                                            </table>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="50%">
                                            Nomenclatura catastral &nbsp;
                                        </td>
                                        <td class="text" width="50%">
                                            Nº de cuenta &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="50%">
                                            <asp:TextBox ID="txtNomenclatura" runat="server" Width="100%" MaxLength="250" Style="width: 230px; text-transform: uppercase;"></asp:TextBox>
                                                </td>
                                        <td class="text" width="50%">
                                            <asp:TextBox ID="txtCuenta" runat="server" Width="230px" MaxLength="12" Style="text-transform: uppercase;"></asp:TextBox></td>
                                    </tr>
                                        <tr>
                                        <td class="text" colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="261">
                                            &nbsp;</td>
                                        <td class="text" width="50%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="title" width="100%" bgcolor="lightgrey" colspan="3" height="10">
                                                        &nbsp;&nbsp; Resultado</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
<asp:Panel ID="pnlPropiedad" runat="server">
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td class="text" width="100%">
                                                                        Nº de inscripción</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="100%">
                                                                        <asp:DropDownList ID="cmbTipoPropiedad" runat="server" Width="100%" AutoPostBack="True"
                                                                            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                                            <asp:ListItem Value="1">Matricula</asp:ListItem>
                                                                            <asp:ListItem Value="2">Dominio</asp:ListItem>
                                                                            <asp:ListItem Value="3">Legajo Especial</asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" >
                                                                        <asp:Label ID="lblTipoPropiedad" runat="server" Font-Bold="True">Nro de Matricula</asp:Label>&nbsp;
                                                                        <asp:RequiredFieldValidator ID="ValMatricula" runat="server" ErrorMessage="Ingrese matricula"
                                                                            ControlToValidate="txtLegajo">*</asp:RequiredFieldValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="100%">
                                                                        <asp:TextBox ID="txtLegajo" runat="server" Width="100%" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                                <asp:Panel ID="pnlDominioLegEspecial" runat="server" Width="100%">
                                                                <tr><td><table width="100%">
                                                                    <tr>
                                                                        <td class="text" width="175">
                                                                            Folio&nbsp;
                                                                            <asp:RequiredFieldValidator ID="ValtxtFolio" runat="server" ErrorMessage="Ingrese folio"
                                                                                ControlToValidate="txtFolio">*</asp:RequiredFieldValidator></td>
                                                                        <td class="text" width="33%">
                                                                            Tomo</td>
                                                                        <td class="text" width="33%">
                                                                            Año
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Ingrese el año"
                                                                                ControlToValidate="txtAno">*</asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="text" width="175">
                                                                            <asp:TextBox ID="txtFolio" runat="server" Width="140px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                        <td class="text" width="33%">
                                                                            <asp:TextBox ID="txtTomo" runat="server" Width="140px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                        <td class="text" align="left" width="33%">
                                                                            <asp:TextBox ID="txtAno" runat="server" Width="140px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    </tr>
                                                                    </table></td></tr>
                                                                </asp:Panel>
                                                            </table>
                                                        </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="175" colspan="2">
                                            <asp:Label ID="Label5" runat="server">Observaciones</asp:Label>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="100%" colspan="2">
                                            <asp:TextBox ID="txtObservaciones" runat="server" Width="100%" TextMode="MultiLine"
                                                Rows="5" CssClass="Plano"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="text" align="center" width="50%">
                                            &nbsp;</td>
                                        <td valign="top" width="50%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="535" colspan="2">
                                            <hr>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="536" colspan="2">
                                            <asp:ValidationSummary ID="VSVerifDomParticular" runat="server" CssClass="text" ShowSummary="False"
                                                ShowMessageBox="True"></asp:ValidationSummary>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="536" colspan="2">
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
                    <asp:HiddenField ID="hdEncAbierto" runat="server" Value="0" Visible="true" />
                    <input id="idReferencia" type="hidden" name="idReferencia" runat="server">
                    <input id="idTipoProp" type="hidden" name="idTipoProp" runat="server"><input id="idTipoPersona"
                        type="hidden" name="idTipoPersona" runat="server">
            </td>
        </tr>
    </table>
    
</form>
</body>
</html>
