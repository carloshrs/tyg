<%@ Page Language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.InformePropiedad.abmTitular"
    SmartNavigation="False" CodeFile="abmTitular.aspx.cs" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>Titular del inmueble</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
    <base target="_self">
    <script src="../Includes/entertab.js" type="text/javascript"></script>
    <script src="../Inc/padron.js" type="text/javascript"></script>

    <script type="text/javascript">
    
            function GetServerTime(valor)
            {
                if(valor == "") {
                    alert('Ingrese número de documento'); 
                }
                else{
                    limpiar();
                    document.getElementById("divProcesando").style.display='';
                    Samples.AspNet.ServerTime.GetServerTime(valor,OnSucceeded);
                }
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
        
		function validaTotalPorcentaje(source, args)
		{
//			try
/*			{
	   			if(isNaN(args.Value))
			    {
				  args.IsValid = false;
//   				  popMensaje.fPopMensaje(source,"Valor inválido",divMensaje);
   				}
				else if(100 >= ((parseFloat(Form1.totalPorcentaje.value)-parseFloat(Form1.itemPorcentaje.value))+parseFloat(args.Value)))
				{
				  args.IsValid = true;
				}
			    else
			    {
				  args.IsValid = false;
				  alert("La suma de los porcentajes no debe superar el 100%");
  // 				  popMensaje.fPopMensaje(source,"Valor inválido",divMensaje);
   				}

			}
//			catch(er)
			{
			//	args.IsValid = false;
	//			popMensaje.fPopMensaje(source,"Valor inválido",divMensaje);
			}*/
		}
    </script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
        <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td width="100%">
                    <table id="Table2" cellspacing="0" cellpadding="0" width="480" border="0">
                        <tr>
                            <td class="text" width="100%">
                                <asp:Panel ID="pnlTipoPersona" runat="server">
                                    <table id="Table10" cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td class="text" width="535">
                                                Tipo Persona:</td>
                                        </tr>
                                        <tr>
                                            <td class="text" width="100%">
                                                <asp:DropDownList ID="cmbTipoPersona" runat="server" AutoPostBack="True" Width="100%"
                                                    OnSelectedIndexChanged="cmbTipoPersona_SelectedIndexChanged">
                                                    <asp:ListItem Value="1">Persona F&#237;sica</asp:ListItem>
                                                    <asp:ListItem Value="2">Persona Jur&#237;dica</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td class="text" width="535" height="10">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <br>
                                <asp:Panel ID="pnlFisica" runat="server">
                                    <table id="Table3" cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td class="text" width="50%">
                                                <table id="Table4" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td width="536" colspan="2">
                                                            <table id="Table5" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td class="title" width="100%" bgcolor="lightgrey" height="10">
                                                                        &nbsp;&nbsp; Titular persona fisica del inmueble</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" style="width: 50%">
                                                            Tipo de documento
                                                            <asp:RequiredFieldValidator ID="Requiredfieldvalidator1" runat="server" ControlToValidate="txtApellido"
                                                                ErrorMessage="Ingrese el apellido">*</asp:RequiredFieldValidator></td>
                                                        <td class="text" width="50%">
                                                            Documento&nbsp;
                                                            <asp:Label ID="lblResultado" runat="server" ForeColor="Red"></asp:Label>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtNombre"
                                                                ErrorMessage="Ingrese el nombre">*</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" style="width: 50%">
                                                            <asp:DropDownList ID="cmbTipoDocumento" runat="server" Width="97%">
                                                            </asp:DropDownList></td>
                                                        <td class="text" width="50%">
                                                            <asp:TextBox ID="txtDocumento" runat="server" Width="80%" MaxLength="20" style="text-transform: uppercase;" AutoPostBack="True" OnTextChanged="txtDocumento_TextChanged"></asp:TextBox><asp:Button ID="btnObtener" runat="server" Text="?" onprerender="btnObtener_PreRender"  ToolTip="Consultar persona en Padrón" CausesValidation="False" />
                                                                        <cc1:ModalPopupExtender ID="imgCheckPersona_ModalPopupExtender" runat="server" 
                                                                            TargetControlID="btnObtener" DropShadow="True" BackgroundCssClass="FondoAplicacion" CancelControlID="btnCancelar" 
                                                                            PopupControlID="pnlPersonaPadron" OkControlID="btnCancelar" >
                                                                        </cc1:ModalPopupExtender>
                                                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                                            <Services>
                                                                                <asp:ServiceReference  Path="../services/ServerTime.asmx" />
                                                                            </Services>
                                                                        </asp:ScriptManager>
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="175" colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="100%" colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" style="width: 50%">
                                                            Apellido</td>
                                                        <td class="text" width="50%">
                                                            Nombre
                                                            <asp:RequiredFieldValidator ID="Requiredfieldvalidator6" runat="server" ControlToValidate="txtDocumento"
                                                                ErrorMessage="Ingrese el nro de documento" EnableClientScript="False" Enabled="False"
                                                                EnableViewState="False" Visible="False">*</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" style="width: 50%">
                                                            <asp:TextBox ID="txtApellido" runat="server" Width="97%" MaxLength="200" style="text-transform: uppercase;"></asp:TextBox></td>
                                                        <td class="text" width="50%">
                                                            <asp:TextBox ID="txtNombre" runat="server" Width="100%" MaxLength="200" style="text-transform: uppercase;"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" style="width: 50%; height: 19px">
                                                            Estado&nbsp;civil&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                        <td class="text" width="50%" style="height: 19px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" style="width: 50%">
                                                            <asp:DropDownList ID="cmbEstadoCivil" runat="server" Width="97%">
                                                            </asp:DropDownList></td>
                                                        <td class="text" width="50%">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlJuridico" runat="server">
                                    <table id="Table6" cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td class="text" width="50%">
                                                <table id="Table7" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td width="536" colspan="2">
                                                            <table id="Table8" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td class="title" width="100%" bgcolor="lightgrey" height="10">
                                                                        &nbsp;&nbsp; Titular persona jurídica del inmueble</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="175" colspan="2">
                                                            Razón&nbsp;social&nbsp;
                                                            <asp:RequiredFieldValidator ID="Requiredfieldvalidator7" runat="server" ControlToValidate="txtRazonSocial"
                                                                ErrorMessage="Ingrese la razón social">*</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="100%" colspan="2">
                                                            <asp:TextBox ID="txtRazonSocial" runat="server" Width="100%" MaxLength="255" style="text-transform: uppercase;"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="175" colspan="2">
                                                            Nombre fantasia&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="100%" colspan="2">
                                                            <asp:TextBox ID="txtNombreFantasia" runat="server" Width="100%" MaxLength="255" style="text-transform: uppercase;"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="50%">
                                                            Rubro</td>
                                                        <td class="text" width="50%">
                                                            CUIT
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="50%">
                                                            <asp:TextBox ID="txtRubro" runat="server" Width="97%" MaxLength="255" style="text-transform: uppercase;"></asp:TextBox></td>
                                                        <td class="text" width="50%">
                                                            <asp:TextBox ID="txtCUIT" runat="server" Width="100%" MaxLength="45" style="text-transform: uppercase;"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="text" width="536" colspan="4">
                                &nbsp;Proporción</td>
                        </tr>
                        <tr>
                            <td width="536" colspan="4">
                                <asp:TextBox ID="txtPorcentaje" runat="server" Width="200px" 
                                    style="text-transform: uppercase;" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPorcentaje"
                                    ErrorMessage="Ingrese el Porcentaje">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtPorcentaje"
                                    ErrorMessage="El valor debe ser numérico" Operator="DataTypeCheck" Enabled="False"
                                    Visible="False">*</asp:CompareValidator>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtPorcentaje"
                                    ErrorMessage="El porcentaje total no debe superar el 100%" ClientValidationFunction="validaTotalPorcentaje">*</asp:CustomValidator></td>
                        </tr>
                        <tr>
                            <td width="536" colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td width="536" colspan="4">
                                <table id="Table9" cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td class="text" width="60%">
                                            &nbsp;<input id="totalPorcentaje" type="hidden" name="totalPorcentaje" runat="server"><input
                                                id="itemPorcentaje" type="hidden" name="itemPorcentaje" runat="server"></td>
                                        <td class="text" align="right" width="20%">
                                            <asp:Button ID="Aceptar" runat="server" Width="80px" Text="Aceptar" OnClick="Aceptar_Click">
                                            </asp:Button></td>
                                        <td class="text" align="right" width="20%">
                                            <asp:Button ID="Cancelar" runat="server" Width="80px" Text="Cancelar" CausesValidation="False"
                                                OnClick="Cancelar_Click"></asp:Button></td>
                                    </tr>
                                </table>
                                <asp:ValidationSummary ID="VSVerifDomParticularTitulares" runat="server" ShowSummary="False"
                                    ShowMessageBox="True" CssClass="text"></asp:ValidationSummary>
                            </td>
                        </tr>
                    </table>
                    <input id="idTitularInmueble" type="hidden" name="idTitularInmueble" runat="server">
                    <input id="idInforme" type="hidden" name="idInforme" runat="server">
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
</html>
