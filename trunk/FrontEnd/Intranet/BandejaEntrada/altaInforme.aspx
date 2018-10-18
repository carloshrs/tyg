<%@ Reference Page="~/Inc/Encabezado.aspx" %>

<%@ Page Language="c#" AutoEventWireup="true" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada.altaInformeIntra"
    CodeFile="altaInforme.aspx.cs" %>

<%@ Register TagPrefix="uc1" TagName="menu" Src="../Inc/menu.ascx" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
    <title>Alta de Informe</title>
    <link href="/CSS/Estilos.css" type="text/css" rel="stylesheet"/>


	<link rel="stylesheet" href="../jquery/themes/base/jquery.ui.all.css"/>
	<script src="../jquery/jquery-1.4.4.js" type="text/javascript"></script>
	<script src="../jquery/external/jquery.bgiframe-2.1.2.js" type="text/javascript"></script>
	<script src="../jquery/ui/jquery.ui.core.js" type="text/javascript"></script>
	<script src="../jquery/ui/jquery.ui.widget.js" type="text/javascript"></script>
	<script src="../jquery/ui/jquery.ui.mouse.js" type="text/javascript"></script>
	<script src="../jquery/ui/jquery.ui.draggable.js" type="text/javascript"></script>
	<script src="../jquery/ui/jquery.ui.position.js" type="text/javascript"></script>
	<script src="../jquery/ui/jquery.ui.resizable.js" type="text/javascript"></script>
	<script src="../jquery/ui/jquery.ui.dialog.js" type="text/javascript"></script>



<script language="javascript" type="text/javascript">

	function mostrar()
	{
	    //getter
        //var show = $( ".selector" ).dialog( "option", "show" );
        //setter
        //$( ".selector" ).dialog( "option", "show", 'slide' );
        $( "#dialog-modal" ).dialog({
			height: 140,
			modal: true
		});
	}
    
    function verificarInformeExistente()
    {
        if (document.getElementById("hdIdCliente").value == "") //if(document.getElementById("cmbClientes").value == "")
            return false;
        
        if(document.getElementById("cmbTipoPropiedad").value == 1) // Matricula
        {
            if (document.getElementById("txtLegajo").value != "")
            {
                //valor = document.getElementById("cmbClientes").value + "|" + document.getElementById("cmbTipoInforme").value + "|" + document.getElementById("cmbTipoPropiedad").value + "|" + document.getElementById("txtLegajo").value;
                valor = document.getElementById("hdIdCliente").value + "|" + document.getElementById("cmbTipoInforme").value + "|" + document.getElementById("cmbTipoPropiedad").value + "|" + document.getElementById("txtLegajo").value;
                if(document.getElementById("cmbTipoInforme").value ==11) 
                    valor = valor + "|" + document.getElementById("cmbProvinciaOtra").value;

                informeExistente.verificarInformeExistente(valor,OnSucceeded);
            }
        }
            
        if(document.getElementById("cmbTipoPropiedad").value == 2) //Dominio
        {
           if (document.getElementById("txtFolio").value != "" && document.getElementById("txtAno").value != "")
           {
               //valor = document.getElementById("cmbClientes").value + "|" + document.getElementById("cmbTipoInforme").value + "|" + document.getElementById("cmbTipoPropiedad").value + "|" + document.getElementById("txtFolio").value + "|" + document.getElementById("txtAno").value;
               valor = document.getElementById("hdIdCliente").value + "|" + document.getElementById("cmbTipoInforme").value + "|" + document.getElementById("cmbTipoPropiedad").value + "|" + document.getElementById("txtFolio").value + "|" + document.getElementById("txtAno").value;
                if(document.getElementById("cmbTipoInforme").value ==11) 
                    valor = valor + "|" + document.getElementById("cmbProvinciaOtra").value;

                informeExistente.verificarInformeExistente(valor,OnSucceeded);
           }
        }

        if(document.getElementById("cmbTipoPropiedad").value == 3) // LE
        {
           if (document.getElementById("txtLegajo").value != "" && document.getElementById("txtFolio").value != "")
           {
               //valor = document.getElementById("cmbClientes").value + "|" + document.getElementById("cmbTipoInforme").value + "|" + document.getElementById("cmbTipoPropiedad").value + "|" + document.getElementById("txtLegajo").value + "|" + document.getElementById("txtFolio").value;
               valor = document.getElementById("hdIdCliente").value + "|" + document.getElementById("cmbTipoInforme").value + "|" + document.getElementById("cmbTipoPropiedad").value + "|" + document.getElementById("txtLegajo").value + "|" + document.getElementById("txtFolio").value;
                if(document.getElementById("cmbTipoInforme").value ==11) 
                    valor = valor + "|" + document.getElementById("cmbProvinciaOtra").value;

                informeExistente.verificarInformeExistente(valor,OnSucceeded);
           }
        }
        
        //document.getElementById("divProcesando").style.display='';
    }
    
    function cerrarSolicitudExistente()
    {
        document.getElementById("pnlInformeExistente").style.display='';
    }

    function OnSucceeded(result)
    {
        var tempPer = new Array();
        tempPer = result.split('|');
        
        if(tempPer.length > 0)
        {
            if(tempPer[0] != "")
            {
                varMessage = "Existen solicitudes realizadas por: <br>"; 
                for(i=0; i<tempPer.length; i++)
                {
                    var tempSolDetalle = new Array();
                    tempSolDetalle = tempPer[i].split(',');
                    varMessage = varMessage + "<br><a href='../InformePropiedad/Informe.aspx?id=" + tempSolDetalle[0] + "&IdTipo=1' class='link2'><b>" + tempSolDetalle[2] + "</b> el dia " + tempSolDetalle[1] + ", " + tempSolDetalle[3] + "</a>";
                    
                }
                document.getElementById("lblInformesSolicitados3").innerHTML = varMessage;
            }
            else
            {
                document.getElementById("lblInformesSolicitados3").innerHTML = "";
                return false;
            }
        }
		
		$( "#dialog-message" ).dialog({
		    width: 460,
			modal: true,
			buttons: {
				Ok: function() {
					$( this ).dialog( "close" );
				}
			}
		});

    }
    
    
    function asignarTextoReferencia(texto) {
        document.getElementById("txtReferencia").value = texto;
        document.getElementById("htxtReferencia").value = texto;
    }

    function verificarReferencia(campo) {
        if (campo.value != document.getElementById("htxtReferencia").value)
            document.getElementById("idReferencia").value = 0;

    }
    
    function setearReferencia(campo)
    {
        if (campo.value != "" && document.getElementById("txtReferencia").value == "")
        {
            var fecha=new Date();
            var dia=fecha.getDate();
            var mes=fecha.getMonth() +1 ;
            document.getElementById("txtReferencia").value = campo.value + " " + dia + "/" +mes;
            }
    }
    
    
    function asignarReferencia() {
        var item = document.forms[0].elements['raReferenciaAnterior'];
        //alert(document.forms[0].elements['raReferenciaAnterior'].length);
        for (i = 0; i < item.length; i++) {
            if (item[i].checked) {
                //alert(item[i].value);
                //document.getElementById("txtReferencia").value = item[i].value;
                document.getElementById("idReferencia").value = item[i].value;
            } 
        } 
    }
    
    function mpeSeleccionOnOk() {
    /*
        var ddlCiudades = document.getElementById("ddlCiudades");
        var ddlMeses = document.getElementById("ddlMeses");
        var ddlAnualidades = document.getElementById("ddlAnualidades");
        var txtSituacion = document.getElementById("txtSituacion");

        txtSituacion.value = ddlCiudades.options[ddlCiudades.selectedIndex].value + ", " +
        ddlMeses.options[ddlMeses.selectedIndex].value + " de " +
        ddlAnualidades.options[ddlAnualidades.selectedIndex].value;
        */
    }
    function mpeSeleccionOnCancel() {
    /*
        var txtSituacion = document.getElementById("txtSituacion");
        txtSituacion.value = "";
        txtSituacion.style.backgroundColor = "#FFFF99";
        */
    }    
</script>
    <script src="../Includes/entertab.js" type="text/javascript"></script>

    <link href="../CSS/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="../jquery/jquery.autocomplete.js" type="text/javascript"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             //alert(document.getElementById("txtCliente").value)
             $("#<%=txtCliente.ClientID%>").autocomplete("../services/Search.ashx", {
                 width: 480,
                 formatItem: function (data, i, n, value) {
                     //alert(value)
                     vRetorno = "<span style=\"font-size:15px;\">" + value.split(",")[1] + "</span><br>" + value.split(",")[2];
                     //alert(value.split(",")[3]);
                     if (value.split(",")[3] != '' && value.split(",")[3] != '.') {
                         var strMail = value.split(",")[3];
                         vRetorno += " &nbsp;<img src=\"../Img/mail.gif\" border=\"0\" title=\"" + strMail + "\">";
                     }
                     if (value.split(",")[4] != 0) {
                         var str = value.split(",")[4];
                         var n = replaceAll(str, "-", "\n");
                         vRetorno += " &nbsp;<img src=\"../Img/ico_user.gif\" border=\"0\" title=\"" + n + "\">";
                     }
                     return vRetorno;

                 },
                 formatResult: function (data, value) {
                     //alert(value.split(",")[0]);
                     //alert(value.split(",")[1]);
                     document.getElementById("hdIdCliente").value = value.split(",")[1];
                     return value.split(",")[1];
                 }
             });
         });



         function replaceAll(text, busca, reemplaza) {
             while (text.toString().indexOf(busca) != -1)
                 text = text.toString().replace(busca, reemplaza);
             return text;
         }

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
			function deshabilitarBotones(elemento)
			{
			    if (typeof(Page_ClientValidate) == 'function')
                    if (Page_ClientValidate())
                    {
                        elemento.disabled = true;
                        __doPostBack('Aceptar','');
                    }

                }
    </script>

</head>
<body leftMargin="0" topMargin="0">
<form id="Form1" method="post" runat="server">


<uc1:menu ID="Menu1" runat="server"></uc1:menu>


<asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
    <Services>
        <asp:ServiceReference  Path="../services/informeExistente.asmx" />
    </Services>
</asp:ScriptManager>

<div> 
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td width="15">
                &nbsp;</td>
            <td>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td class="title" width="100%">
                                Solicitud de Informe<br/>
                                <hr/>
                                <br/>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%">
                                <asp:Panel ID="pnTransferido" runat="server" Visible="false">
                                <div style=" background-color:#f0f0CC; padding:8px; margin-bottom:10px; width:466px;"><b>INFORME DE PROPIEDAD A TRANSFERIR</b>
                                <br />
                                El informe 
                                    <asp:Label ID="lblInformeTransferido" runat="server" Font-Bold="true"></asp:Label> 
                                    &nbsp;será transferido a un nuevo informe de propiedad.
                                </div>
                                </asp:Panel>
                                <table cellspacing="0" cellpadding="0" width="480" border="0">
                                    <tr>
                                        <td class="title" width="535" bgcolor="lightgrey" height="10">
                                            &nbsp;&nbsp;Datos Cliente</td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535">
                                            Cliente&nbsp;
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535" height="8">
                                        <asp:TextBox ID="txtCliente" runat="server" Style="text-transform: uppercase; font-size:16px; font-weight:300;" Width="100%" onClick="this.value='';"></asp:TextBox><asp:HiddenField ID="hdIdCliente" runat="server" />
                                            <asp:Label id="txtDireccion" runat="server" class="text"></asp:Label>
      </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535" style="padding:5px; background-color:#eee;"><h2>Estado de cuenta</h2><asp:HyperLink runat="server" ID="hlCuentaCliente" NavigateUrl="#" Font-Underline="false" Target="_blank">
                                        
                                        Saldo <asp:Label runat="server" ID="lblPendienteFavor" Text="pendiente"></asp:Label>&nbsp;anterior
                                                :&nbsp;<asp:Label ID="lblSaldoAnterior" runat="server" Text="" Font-Bold="true" Font-Size="16px"></asp:Label>
											    <br />
                                                Informes pendientes de cobro:&nbsp;<asp:Label ID="lblSaldoPendienteCobro" runat="server" Text="" Font-Bold="true" Font-Size="16px"></asp:Label>
											    <br />
                                                Total: <asp:Label ID="lblTotal" runat="server" Text="" Font-Bold="true" Font-Size="20px"></asp:Label>
                                        </asp:HyperLink><br /><br /></td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="text" width="50%">
                                                        Usuario</td>
                                                    <td class="text" width="50%">
                                                        Persona&nbsp;
                                                        <asp:RequiredFieldValidator ID="valPersona" runat="server" ControlToValidate="txtPersona"
                                                            ErrorMessage="Ingrese persona">*</asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td class="text" width="50%" height="8">
                                                        <asp:DropDownList ID="cmbUsuarios" runat="server" AutoPostBack="True" Width="100%"
                                                            OnSelectedIndexChanged="cmbUsuarios_SelectedIndexChanged">
                                                        </asp:DropDownList></td>
                                                    <td class="text" width="50%" height="8">
                                                        <asp:TextBox ID="txtPersona" runat="server" Style="text-transform: uppercase;" 
                                                            Width="100%" onprerender="txtPersona_PreRender"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535" height="10">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535">
                                            Tipo Informe</td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535">
                                            <asp:DropDownList ID="cmbTipoInforme" runat="server" AutoPostBack="True" Width="479px"
                                                OnSelectedIndexChanged="cmbTipoInforme_SelectedIndexChanged">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535" height="10">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535"><b>Referencia </b>
                                            <asp:RequiredFieldValidator ID="valReferencia" runat="server" 
                                                ControlToValidate="txtReferencia" ErrorMessage="Ingrese referencia">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535">
                                            <asp:TextBox ID="txtReferencia" runat="server" Width="300px" onprerender="txtReferencia_PreRender" MaxLength="50" Style="text-transform: uppercase;"></asp:TextBox>
                                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="#" CssClass="link"> Anteriores</asp:HyperLink><asp:HiddenField ID="htxtReferencia" runat="server" />
                                            <cc1:ModalPopupExtender ID="HyperLink2_ModalPopupExtender" runat="server" 
                                                DropShadow="True" TargetControlID="HyperLink2" 
                                                BackgroundCssClass="FondoAplicacion" CancelControlID="btnCancelar" 
                                                OkControlID="btnSeleccionar" PopupControlID="pnlReferencia" 
                                                onokscript="asignarReferencia()">
                                            </cc1:ModalPopupExtender>
                                            <br />
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535" height="10">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="100%">
                                            <asp:Panel ID="pnlTipoPersona" runat="server">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td class="text" width="535">
                                                            Tipo Persona:</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="100%">
                                                            <asp:DropDownList ID="cmbTipoPersona" runat="server" Width="100%" AutoPostBack="True"
                                                                OnSelectedIndexChanged="cmbTipoPersona_SelectedIndexChanged">
                                                                <asp:ListItem Value="1">Persona F&#237;sica</asp:ListItem>
                                                                <asp:ListItem Value="2">Persona Jur&#237;dica</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="535" height="10">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="100%">
                                            <asp:Panel ID="pnlParticulares" runat="server">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td class="title" width="535" bgcolor="lightgrey" colspan="3" height="10">
                                                            &nbsp;&nbsp;Datos Personales</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="535" colspan="3">
                                                            Apellido
                                                            <asp:RequiredFieldValidator ID="reqApellido" runat="server" ErrorMessage="Ingrese apellido"
                                                                ControlToValidate="Apellido">*</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="535" colspan="3">
                                                            <asp:TextBox ID="Apellido" runat="server" Width="100%" style="text-transform: uppercase;"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="535" colspan="3">
                                                            Nombre
                                                            <asp:RequiredFieldValidator ID="reqNombre" runat="server" ErrorMessage="Ingrese nombre"
                                                                ControlToValidate="Nombre">*</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="535" colspan="3">
                                                            <asp:TextBox ID="Nombre" runat="server" Width="100%" style="text-transform: uppercase;"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="100">
                                                            Tipo Documento</td>
                                                        <td class="text" width="235">
                                                            &nbsp;Documento&nbsp;
                                                            <asp:CompareValidator ID="cmpDocumento" runat="server" 
                                                                ErrorMessage="Documento no valido" ControlToValidate="Documento" Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
                                                        </td>
                                                        <td class="text" width="161">
                                                            <asp:Label ID="lblEstadoCivil" runat="server" Text="Estado Civil">Estado Civil</asp:Label>
                                                            <asp:Label ID="lblSexo" runat="server" Text="Sexo" Visible="false"></asp:Label>
                                                            </td>
                                                    </tr>
                                                    <tr>

                                                        <td class="text" width="25">
                                                            <asp:DropDownList ID="cmbTipoDocumento" runat="server" Width="167px">
                                                                <asp:ListItem Value="1" Selected="True">DNI</asp:ListItem>
                                                                <asp:ListItem Value="2">Libreta C&#237;vica</asp:ListItem>
                                                                <asp:ListItem Value="3">Libreta de enrolamiento</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td class="text" width="235">
                                                            &nbsp;<asp:TextBox ID="Documento" runat="server" Width="144px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                          <td class="text" width="161">
                                                            <asp:DropDownList ID="cmbEstadoCivil" runat="server" Width="161px">
                                                                <asp:ListItem Value="1">Soltero/a</asp:ListItem>
                                                                <asp:ListItem Value="2">Casado/a</asp:ListItem>
                                                                <asp:ListItem Value="3">Divorciado/a</asp:ListItem>
                                                                <asp:ListItem Value="4">Viudo/a</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:dropdownlist id="cmbSexo" runat="server" Width="161px" Visible="false">
                                                                <asp:ListItem Value="0" Selected="True">Seleccione sexo</asp:ListItem>
						                                        <asp:ListItem Value="1">Masculino</asp:ListItem>
						                                        <asp:ListItem Value="2">Femenino</asp:ListItem>
					                                        </asp:dropdownlist>
                                                            </td>                                                          
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="535" colspan="3" height="10">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="535" colspan="3" height="10">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="536">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="text" width="50%">
                                                        <asp:Panel ID="pnlAutomotor" runat="server">
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td width="536">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="title" width="100%" bgcolor="lightgrey" height="10">
                                                                                    &nbsp;&nbsp; Informe de Automotor</td>
                                                                                <td class="title" height="10">
                                                                                    <a onclick="javascript:mostrarFiltro(false, imgMasInfo);" href="#">
                                                                                        <img id="imgMasInfo" alt="Más Info" src="/img/Arrow.gif" border="0"></a></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="100%">
                                                                        Dominio&nbsp;
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese dominio"
                                                                            ControlToValidate="Dominio">*</asp:RequiredFieldValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="100%">
                                                                        <asp:TextBox ID="Dominio" runat="server" Width="100%" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr id="masInfo" style="display: none">
                                                                    <td class="text" width="100%">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="text" width="100%">
                                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                        <tr>
                                                                                            <td class="text" width="100%" colspan="4">
                                                                                                Registro donde está Inscripto</td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="text" width="100%" colspan="4">
                                                                                                <asp:TextBox ID="Registro" runat="server" Width="100%" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="text" width="70%">
                                                                                                Calle</td>
                                                                                            <td class="text" width="10%">
                                                                                                Nro.</td>
                                                                                            <td class="text" width="10%">
                                                                                                Dpto.</td>
                                                                                            <td class="text" width="10%">
                                                                                                Piso</td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="text" width="70%">
                                                                                                <asp:TextBox ID="CalleRegistro" runat="server" Width="320px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                            <td class="text" width="10%">
                                                                                                <asp:TextBox ID="NroRegistro" runat="server" Width="46px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                            <td class="text" width="10%">
                                                                                                <asp:TextBox ID="DptoRegistro" runat="server" Width="46px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                            <td class="text" width="10%">
                                                                                                <asp:TextBox ID="PisoRegistro" runat="server" Width="47px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="4">
                                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                    <tr>
                                                                                                        <td class="text" width="50%">
                                                                                                            Barrio</td>
                                                                                                        <td class="text" width="10%">
                                                                                                            Código Postal</td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="text" width="50%">
                                                                                                            <asp:TextBox ID="BarrioRegistro" runat="server" Width="320px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                                        <td class="text" width="10%">
                                                                                                            <asp:TextBox ID="CPRegistro" runat="server" Width="144px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="4">
                                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                    <tr>
                                                                                                        <td class="text" width="10%">
                                                                                                            Provincia</td>
                                                                                                        <td class="text" width="50%">
                                                                                                            Localidad</td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="text" width="10%">
                                                                                                            <asp:DropDownList ID="cmbProvinciaRegistro" runat="server" Width="240px" AutoPostBack="True"
                                                                                                                OnSelectedIndexChanged="cmbProvinciaRegistro_SelectedIndexChanged">
                                                                                                            </asp:DropDownList></td>
                                                                                                        <td class="text" width="50%">
                                                                                                            <asp:DropDownList ID="cmbLocalidadRegistro" runat="server" Width="240px">
                                                                                                            </asp:DropDownList></td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnlDomicilioParticular" runat="server">
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td width="536">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="title" width="100%" bgcolor="lightgrey" style="height: 10px">
                                                                                    &nbsp;&nbsp;
                                                                                    <asp:Label ID="lblDatosParticulares" runat="server" Text="Verificación Domicilio Particular"></asp:Label></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="536">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="text" width="70%">
                                                                                    Calle&nbsp;
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese calle"
                                                                                        ControlToValidate="Calle">*</asp:RequiredFieldValidator></td>
                                                                                <td class="text" width="10%">
                                                                                    Nro.
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese el Nro"
                                                                                        ControlToValidate="Nro">*</asp:RequiredFieldValidator></td>
                                                                                <td class="text" width="10%">
                                                                                    Dpto.</td>
                                                                                <td class="text" width="10%">
                                                                                    Piso</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text" width="70%">
                                                                                    <asp:TextBox ID="Calle" runat="server" Width="320px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                <td class="text" width="10%">
                                                                                    <asp:TextBox ID="Nro" runat="server" Width="46px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                <td class="text" width="10%">
                                                                                    <asp:TextBox ID="Dpto" runat="server" Width="46px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                <td class="text" width="10%">
                                                                                    <asp:TextBox ID="Piso" runat="server" Width="47px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="536">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="text" width="25%">Lote&nbsp;</td>
                                                                                <td class="text" width="25%">Manzana&nbsp;</td>
                                                                                <td class="text" width="25%">Complejo&nbsp;</td>
                                                                                <td class="text" width="25%">Torre&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text" width="25%"><asp:TextBox ID="Lote" runat="server" Width="110px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                <td class="text" width="25%"><asp:TextBox ID="Manzana" runat="server" Width="110px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                <td class="text" width="25%"><asp:TextBox ID="Complejo" runat="server" Width="110px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                <td class="text" width="25%"><asp:TextBox ID="Torre" runat="server" Width="110px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                                        
                                                                <tr>
                                                                    <td width="536">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
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
                                                                                    <asp:TextBox ID="barrio" runat="server" Width="320px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                <td class="text" width="10%">
                                                                                    <asp:TextBox ID="CP" runat="server" Width="144px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <asp:Panel ID="pnlAmbientalExtra" runat="server">
                                                                    <tr>
                                                                        <td width="536" colspan="4">
                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                <tr>
                                                                                    <td class="text" width="40%">
                                                                                        Tel&eacute;fono&nbsp;</td>
                                                                                    <td class="text">
                                                                                        Email&nbsp;</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="text">
                                                                                        <asp:TextBox ID="txtTelefonoAMB" runat="server" Width="180px" style="text-transform: uppercase;"></asp:TextBox>
                                                                                    </td>
                                                                                    <td class="text">
                                                                                        <asp:TextBox ID="txtEMailAMB" runat="server" Width="288px" style="text-transform: uppercase;"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </asp:Panel>
                                                                <tr>
                                                                    <td width="536">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="text" width="50%">
                                                                                    Provincia&nbsp;
                                                                                </td>
                                                                                <td class="text" width="10%">
                                                                                    Localidad&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text" width="10%">
                                                                                    <asp:DropDownList ID="cmbProvincia" runat="server" Width="240px" AutoPostBack="True"
                                                                                        OnSelectedIndexChanged="cmbProvincia_SelectedIndexChanged">
                                                                                    </asp:DropDownList></td>
                                                                                <td class="text" width="50%">
                                                                                    <asp:DropDownList ID="cmbLocalidad" runat="server" Width="240px">
                                                                                    </asp:DropDownList></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="535" height="10">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnlPropiedad" runat="server">
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td width="536">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="title" width="100%" bgcolor="lightgrey" height="10">
                                                                                    &nbsp;&nbsp; Informe de la Propiedad</td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="536">
                                                                    <asp:Panel ID="pnInformePropiedadOtraProvincia" runat="server" Width="100%" Visible="false">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="text" width="50%">
                                                                                    Provincia&nbsp;
                                                                                </td>
                                                                                <td class="text" width="10%">
                                                                                    Localidad&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text" width="10%">
                                                                                    <asp:DropDownList ID="cmbProvinciaOtra" runat="server" Width="240px" AutoPostBack="True"
                                                                                        OnSelectedIndexChanged="cmbProvinciaOtra_SelectedIndexChanged">
                                                                                    </asp:DropDownList></td>
                                                                                <td class="text" width="50%">
                                                                                    <asp:DropDownList ID="cmbLocalidadOtra" runat="server" Width="240px">
                                                                                    </asp:DropDownList></td>
                                                                            </tr>
                                                                        </table>
                                                                      </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="100%">
                                                                        Datos sobre la Propiedad</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="100%">
                                                                        <asp:DropDownList ID="cmbTipoPropiedad" runat="server" Width="100%" AutoPostBack="True"
                                                                            OnSelectedIndexChanged="cmbTipoPropiedad_SelectedIndexChanged">
                                                                            <asp:ListItem Value="1">Matricula</asp:ListItem>
                                                                            <asp:ListItem Value="2">Dominio</asp:ListItem>
                                                                            <asp:ListItem Value="3">Legajo Especial</asp:ListItem>
                                                                            <asp:ListItem Value="4">Planilla</asp:ListItem>
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
                                                                        <asp:TextBox ID="txtLegajo" runat="server" Width="100%" 
                                                                            style="text-transform: uppercase;" onprerender="txtLegajo_PreRender"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr><td>
                                                                <asp:Panel ID="pnlDominioLegEspecial" runat="server" Width="100%">
                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
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
                                                                                ControlToValidate="txtAno">*</asp:RequiredFieldValidator><asp:CompareValidator ID="cmpAnio" runat="server" ErrorMessage="Año no válido" 
                                                                            Operator="GreaterThan" Type="Integer" ValueToCompare="1900" ControlToValidate="txtAno">*</asp:CompareValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="text" width="175">
                                                                            <asp:TextBox ID="txtFolio" runat="server" Width="140px" style="text-transform: uppercase;" onprerender="txtFolio_PreRender"></asp:TextBox></td>
                                                                        <td class="text" width="33%">
                                                                            <asp:TextBox ID="txtTomo" runat="server" Width="140px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                        <td class="text" align="left" width="33%">
                                                                            <asp:TextBox ID="txtAno" runat="server" Width="140px" style="text-transform: uppercase;" onprerender="txtAno_PreRender"></asp:TextBox></td>
                                                                    </tr>
                                                                    </table></td></tr></table>
                                                                </asp:Panel>
                                                                </td></tr>

                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnlCatastral" runat="server" Width="100%">
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td width="536">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="title" width="100%" bgcolor="lightgrey" height="10">
                                                                                    &nbsp;&nbsp; Informe Catastral</td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="100%">
                                                                        Tipo Informe</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="100%">
                                                                        <asp:DropDownList ID="cmbTipoCatastral" runat="server" Width="100%" AutoPostBack="True"
                                                                            OnSelectedIndexChanged="cmbTipoCatastral_SelectedIndexChanged">
                                                                            <asp:ListItem Value="1">Seg&#250;n Nomenclatura</asp:ListItem>
                                                                            <asp:ListItem Value="2">Seg&#250;n Nro de Cuenta</asp:ListItem>
                                                                            <asp:ListItem Value="3">Seg&#250;n Direcci&#243;n</asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="536">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="text" width="50%">
                                                                                    Provincia&nbsp;
                                                                                </td>
                                                                                <td class="text" width="10%">
                                                                                    Localidad&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text" width="10%">
                                                                                    <asp:DropDownList ID="cmbProvinciaCatastro" runat="server" Width="240px" AutoPostBack="True"
                                                                                        OnSelectedIndexChanged="cmbProvinciaCatastro_SelectedIndexChanged">
                                                                                    </asp:DropDownList></td>
                                                                                <td class="text" width="50%">
                                                                                    <asp:DropDownList ID="cmbLocalidadCatastro" runat="server" Width="240px">
                                                                                    </asp:DropDownList></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="60%">
                                                                        <asp:Label ID="lblNumero" runat="server">Número</asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="100%">
                                                                        <asp:TextBox ID="NumeroCatastro" runat="server" Width="100%" style="text-transform: uppercase;" MaxLength="16"></asp:TextBox>
                                                                        <asp:CompareValidator ID="cmpNumeroCatastro" runat="server" ControlToValidate="NumeroCatastro" ErrorMessage="Sólo números" Text="*" Type="Double"></asp:CompareValidator>
                                                                        </td>
                                                                </tr>
                                                                <asp:Panel ID="pnlCatastralDireccion" runat="server">
                                                                    <tr>
                                                                        <td class="text" width="100%" colspan="3">
                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
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
                                                                                        Piso</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="text" width="70%">
                                                                                        <asp:TextBox ID="CatCalle" runat="server" Width="320px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                    <td class="text" width="10%">
                                                                                        <asp:TextBox ID="CatNro" runat="server" Width="46px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                    <td class="text" width="10%">
                                                                                        <asp:TextBox ID="CatDpto" runat="server" Width="46px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                    <td class="text" width="10%">
                                                                                        <asp:TextBox ID="CatPiso" runat="server" Width="47px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="536" colspan="4">
                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
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
                                                                                        <asp:TextBox ID="CatBarrio" runat="server" Width="320px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                    <td class="text" width="10%">
                                                                                        <asp:TextBox ID="CatCP" runat="server" Width="144px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </asp:Panel>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnlRegistroPublico" runat="server">
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td width="536" colspan="3">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="title" width="100%" bgcolor="lightgrey" height="10">
                                                                                    &nbsp;&nbsp; Informe Registro Público de Comercio</td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="33%">
                                                                        Folio&nbsp;
                                                                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator4" runat="server" ErrorMessage="Ingrese folio"
                                                                            ControlToValidate="Folio">*</asp:RequiredFieldValidator></td>
                                                                    <td class="text" width="33%">
                                                                        Tomo</td>
                                                                    <td class="text" width="33%">
                                                                        Año&nbsp;
                                                                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator5" runat="server" ErrorMessage="Ingrese año"
                                                                            ControlToValidate="Ano">*</asp:RequiredFieldValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="33%">
                                                                        <asp:TextBox ID="FolioRegPublico" runat="server" Width="150px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    <td class="text" width="33%">
                                                                        <asp:TextBox ID="TomoRegPublico" runat="server" Width="150px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    <td class="text" width="33%">
                                                                        <asp:TextBox ID="AnoRegPublico" runat="server" Width="160px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="535" colspan="3" height="10">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnlAmbiental" runat="server">
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td width="536" colspan="2">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="title" width="100%" bgcolor="lightgrey" height="10">
                                                                                    &nbsp;&nbsp;
                                                                                    <asp:Label class="title" ID="lblAmbiental" runat="server">Información Ambiental</asp:Label></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="282" colspan="2">
                                                                        <asp:Label ID="lblApellidoConyuge" runat="server">Apellido del Cónyugue / Concubino</asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="100%" colspan="2">
                                                                        <asp:TextBox ID="ambApellido" runat="server" Width="100%" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="60%" colspan="2">
                                                                        <asp:Label ID="lblNombreConyugue" runat="server">Nombre del Cónyugue / Concubino</asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="100%" colspan="2">
                                                                        <asp:TextBox ID="ambNombre" runat="server" Width="100%" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="50%">
                                                                        Tipo Documento</td>
                                                                    <td class="text" width="50%">
                                                                        Documento</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="50%">
                                                                        <asp:DropDownList ID="cmbAmbTipoDoc" runat="server" Width="220px">
                                                                            <asp:ListItem Value="1" Selected="True">DNI</asp:ListItem>
                                                                            <asp:ListItem Value="2">Libreta C&#237;vica</asp:ListItem>
                                                                            <asp:ListItem Value="3">Libreta de enrolamiento</asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                    <td class="text" width="50%">
                                                                        <asp:TextBox ID="ambDocumento" runat="server" Width="250px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnlDomComercial" runat="server">
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td width="536">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="title" width="100%" bgcolor="lightgrey" height="10">
                                                                                    &nbsp;&nbsp;
                                                                                    <asp:Label class="title" ID="lblInforme" runat="server">Persona Jurídica</asp:Label></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="text" width="50%">
                                                                                    Razón Social&nbsp;
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Ingrese razón social"
                                                                            ControlToValidate="RazonSocial">*</asp:RequiredFieldValidator></td></td>
                                                                                <td class="text" width="10%">
                                                                                    Cargo </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text" width="50%">
                                                                                    <asp:TextBox ID="RazonSocial" runat="server" Width="320px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                <td class="text" width="10%">
                                                                                    <asp:TextBox ID="Cargo" runat="server" Width="144px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                            </tr>
                                                                        </table>
                                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="text" width="50%">
                                                                                    Nombre de Fantasía</td>
                                                                                <td class="text" width="10%">
                                                                                    Teléfono</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text" width="50%">
                                                                                    <asp:TextBox ID="NombreFantasia" runat="server" Width="320px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                <td class="text" width="10%">
                                                                                    <asp:TextBox ID="Telefono" runat="server" Width="144px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="52">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="text" width="50%">
                                                                                    Rubro</td>
                                                                                <td class="text" width="10%">
                                                                                    Cuit&nbsp;
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Ingrese el Cuit"
                                                                                        ControlToValidate="Cuit">*</asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text" width="50%">
                                                                                    <asp:TextBox ID="Rubro" runat="server" Width="320px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                <td class="text" width="10%">
                                                                                    <asp:TextBox ID="Cuit" runat="server" Width="144px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="text" width="70%" height="14">
                                                                                    Calle&nbsp;
                                                                                    <asp:RequiredFieldValidator ID="reqCalleEmpresa" runat="server" ErrorMessage="Ingrese Calle"
                                                                                        ControlToValidate="CalleEmpresa">*</asp:RequiredFieldValidator></td>
                                                                                <td class="text" width="10%" height="14">
                                                                                    Nro.&nbsp;
                                                                                    <asp:RequiredFieldValidator ID="reqNroCalleEmpresa" runat="server" ErrorMessage="Ingrese el Nro"
                                                                                        ControlToValidate="NroEmpresa">*</asp:RequiredFieldValidator></td>
                                                                                <td class="text" width="10%" height="14">
                                                                                    Dpto.</td>
                                                                                <td class="text" width="10%" height="14">
                                                                                    Piso</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text" width="70%">
                                                                                    <asp:TextBox ID="CalleEmpresa" runat="server" Width="320px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                <td class="text" width="10%">
                                                                                    <asp:TextBox ID="NroEmpresa" runat="server" Width="46px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                <td class="text" width="10%">
                                                                                    <asp:TextBox ID="DptoEmpresa" runat="server" Width="46px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                <td class="text" width="10%">
                                                                                    <asp:TextBox ID="PisoEmpresa" runat="server" Width="47px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
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
                                                                                    <asp:TextBox ID="BarrioEmpresa" runat="server" Width="320px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                                <td class="text" width="10%">
                                                                                    <asp:TextBox ID="CPEmpresa" runat="server" Width="144px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="text" width="50%" height="14">
                                                                                    Provincia
                                                                                </td>
                                                                                <td class="text" width="10%" height="14">
                                                                                    Localidad&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="text" width="10%">
                                                                                    <asp:DropDownList ID="cmbProvinciaEmpresas" runat="server" Width="240px" AutoPostBack="True"
                                                                                        OnSelectedIndexChanged="cmbProvinciaEmpresas_SelectedIndexChanged">
                                                                                    </asp:DropDownList></td>
                                                                                <td class="text" width="50%">
                                                                                    <asp:DropDownList ID="cmbLocalidadEmpresas" runat="server" Width="240px">
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
                                                        <asp:Panel ID="pnlGravamenes" runat="server">
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td width="536" colspan="3">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td class="title" width="100%" bgcolor="lightgrey" height="10">
                                                                                    &nbsp;&nbsp; Informe de Gravámenes</td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="100%" colspan="3">
                                                                        Tipo de Gravamen</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="100%" colspan="3">
                                                                        <asp:DropDownList ID="cmbTipoGravamen" runat="server" Width="480px" AutoPostBack="True"
                                                                            OnSelectedIndexChanged="cmbTipoGravamen_SelectedIndexChanged_1">
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="33%">
                                                                        Folio&nbsp;
                                                                        <asp:RequiredFieldValidator ID="valFolio" runat="server" ErrorMessage="Ingrese folio"
                                                                            ControlToValidate="Folio">*</asp:RequiredFieldValidator></td>
                                                                    <td class="text" width="33%">
                                                                        Tomo</td>
                                                                    <td class="text" width="33%">
                                                                        Año&nbsp;
                                                                        <asp:RequiredFieldValidator ID="valAno" runat="server" ErrorMessage="Ingrese año"
                                                                            ControlToValidate="Ano">*</asp:RequiredFieldValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="33%">
                                                                        <asp:TextBox ID="Folio" runat="server" Width="150px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    <td class="text" width="33%">
                                                                        <asp:TextBox ID="Tomo" runat="server" Width="150px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    <td class="text" width="33%">
                                                                        <asp:TextBox ID="Ano" runat="server" Width="160px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>


                                                <tr>
                                        <td class="text" width="100%">
                                            <asp:Panel ID="pnlPartidas" runat="server">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td class="title" width="535" bgcolor="lightgrey" colspan="3" height="10">
                                                            &nbsp;&nbsp;Datos de fallecimiento</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" >
                                                            Fecha
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Ingrese apellido"
                                                                ControlToValidate="Apellido">*</asp:RequiredFieldValidator></td>
                                                                <td class="text" colspan="2">
                                                            Lugar de fallecimiento
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Ingrese nombre"
                                                                ControlToValidate="Nombre">*</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" >
                                                            <asp:TextBox ID="txtFechaFallecimiento" runat="server" Width="60" style="text-transform: uppercase;"></asp:TextBox></td>
                                                            <td class="text" colspan="2">
                                                            <asp:TextBox ID="txtLugarFallecido" runat="server" Width="100%" style="text-transform: uppercase;"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="100">
                                                            Acta</td>
                                                        <td class="text" width="235">
                                                            &nbsp;Tomo&nbsp;
                                                        </td>
                                                        <td class="text" width="161">
                                                            &nbsp;Folio&nbsp;
                                                            </td>
                                                    </tr>
                                                    <tr>

                                                        <td class="text" width="25">
                                                            &nbsp;<asp:TextBox ID="txtActaFallecido" runat="server" Width="144px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                            </td>
                                                        <td class="text" width="235">
                                                            &nbsp;<asp:TextBox ID="txtTomoFallecido" runat="server" Width="144px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                          <td class="text" width="161">
                                                            &nbsp;<asp:TextBox ID="txtFolioFallecido" runat="server" Width="144px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                            </td>                                                          
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="535" colspan="3" height="10">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text" width="535" colspan="3" height="10">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                            
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlTitulo" runat="server">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td width="536">
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td class="title" width="100%" bgcolor="lightgrey" height="10">
                                                                        &nbsp;&nbsp;
                                                                        <asp:Label ID="lblTitulo" runat="server" CssClass="Title">Domicilio Comercial</asp:Label></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlFoto" runat="server">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td class="text">
                                                            &nbsp;&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text">
                                                            <asp:Label ID="lblConFoto" runat="server" Font-Bold="True">Con foto</asp:Label>&nbsp;
                                                            <asp:RequiredFieldValidator ID="valConFoto" runat="server" ErrorMessage="¿Con o sin foto?"
                                                                ControlToValidate="raFoto">*</asp:RequiredFieldValidator>
                                                            <asp:RadioButtonList ID="raFoto" runat="server" Width="56px" CssClass="text" RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="1"> Si</asp:ListItem>
                                                                <asp:ListItem Value="0"> No</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlUrgencia" runat="server">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td class="text">
                                                            <strong>Carácter</strong></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text">
                                                            <asp:DropDownList ID="cmbCaracter" runat="server">
                                                            </asp:DropDownList>
                                                            <asp:CompareValidator ID="cmpCaracter" runat="server" 
                                                                ControlToValidate="cmbCaracter" ErrorMessage="Seleccione carácter de urgencia" 
                                                                Operator="NotEqual" ValueToCompare="0">*</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="535">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535">
                                            Observaciones&nbsp;
                                            <asp:RequiredFieldValidator ID="valObservaciones" runat="server" ControlToValidate="Observaciones"
                                                ErrorMessage="Ingrese observaciones">*</asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td class="text" width="535">
                                            <asp:TextBox ID="Observaciones" runat="server" Width="480px" style="text-transform: uppercase;" CssClass="Plano" TextMode="MultiLine"
                                                MaxLength="255" Rows="5" Height="79px"></asp:TextBox></td>
                                    </tr>

                                    <tr>
                                        <td><br />
                                            <asp:Panel ID="PnlRecomendado" runat="server" Visible="false" style="background-color:#e8e8e8; border:1px solid #555;"> 
                                                <table cellspacing="4" cellpadding="3" width="100%" border="0">
                                                    <tr>
                                                        <td class="text" align="center">
                                                            <h1><strong>Sugerencia </strong></h1>Los titulares y garantes para contratos de alquiler se recomienda:
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="text">
                                                            <asp:RadioButtonList ID="raRecomendado" runat="server" style="margin-left:5px;">
                                                            </asp:RadioButtonList>
                                                            <asp:HiddenField ID="hdRecomendadoAnterior" runat="server" />
                                                            <asp:RequiredFieldValidator ID="cmbRecomendado" runat="server" 
                                                                ControlToValidate="raRecomendado" ErrorMessage="¿Desea duplicar los datos del titular?">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td class="text" align="center">
                                                            <h2 style="color:#555;">¿Desea duplicar los datos del titular?</h2>
                                                            </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="535">
                                            <hr/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="535">
                                            <asp:ValidationSummary ID="VSBandejaEntrada" runat="server" CssClass="text" ShowSummary="False"
                                                ShowMessageBox="True"></asp:ValidationSummary>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="536">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="text" width="60%">
                                                        &nbsp;</td>
                                                    <td class="text" align="right" width="20%">
                                                        <asp:Button ID="Aceptar" runat="server" Width="80px" Text="Aceptar" OnClick="Aceptar_Click"
                                                            OnPreRender="Aceptar_PreRender" CausesValidation="False"></asp:Button>
                                                    </td>
                                                    <td class="text" align="right" width="20%">
                                                        <asp:Button ID="Cancelar" runat="server" Width="80px" CausesValidation="False" Text="Cancelar"
                                                            OnClick="Cancelar_Click"></asp:Button></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <input id="idReferencia" type="hidden" name="idReferencia" runat="server"/>
                    <asp:HiddenField ID="hIdTransferido" runat="server" />
            </td>
        </tr>
    </table>
    </div>
    
<asp:Panel ID="pnlReferencia" runat="server" Width="400" Height="200" 
        CssClass="CajaDialogo" EnableViewState="false">
        <div style="padding: 4px; background-color: #32528E; color: #FFFFFF; font-family: Arial, Helvetica, sans-serif; ">
        <asp:Label ID="Label4" runat="server" Text="Referencias existentes" />
    </div>
    <div style="overflow:scroll; height:130px; padding-left: 20px; text-align:left;">
        <asp:RadioButtonList ID="raReferenciaAnterior" runat="server" CellSpacing="2" 
            CellPadding="2">
        </asp:RadioButtonList>
    </div>
    <div align="center">
        <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" 
            CausesValidation="False" />
        &nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
            CausesValidation="False" onprerender="btnCancelar_PreRender" />
            </div>
</asp:Panel>

<asp:Panel ID="pnlInformeExistente" runat="server" Width="500" Height="215" 
        CssClass="CajaDialogo" EnableViewState="false" Visible="False">
    <div style="padding: 4px; background-color: #32528E; color: #FFFFFF; font-family: Arial, Helvetica, sans-serif; ">
        <asp:Label ID="Label1" runat="server" Text="Informes existentes" />
    </div>
	<div style="top:40px; height:80px; text-align: center;" id="divProcesando">
		<img src="/img/ajax-loader.gif" style="vertical-align: middle" 
            alt="Procesando" />
		Procesando ...
	</div>
    <asp:Label ID="lblInformesSolicitados" runat="server" style="padding: 20px;" ></asp:Label>
    <div style="height:80px; padding-left: 20px; text-align:left;">
        <div id="idDivError" class="caja" style="display:none;">
            <span style="color:Red"><strong>La persona no existe en la base de datos</strong></span>
        </div>
    </div>
    <div align="center" style="height:30px; padding-top:10px;">
        &nbsp;<asp:Button ID="btnCerrar" runat="server" Text="Cerrar" 
            CausesValidation="False" onprerender="btnCerrar_PreRender" />
            </div>
    </asp:Panel>
    
<div id="dialog-message" title="Informes existentes">
	<div id="lblInformesSolicitados3" style="margin-left:0px;padding:15px; line-height:1.2; font-size:12px;"></div>
</div>

</form>
</body>
</html>

