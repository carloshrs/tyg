<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Informes.abmInforme" CodeFile="abmInforme.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
	<title>Alta de Informe</title>
	<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	
	
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
	
	<script>
	
    function verificarInformeExistente() {
        if(document.getElementById("cmbTipoPropiedad").value == 1) // Matricula
        {
            if (document.getElementById("txtLegajo").value != "")
            {
                valor = document.getElementById("hidCliente").value + "|" + document.getElementById("cmbTipoInforme").value + "|" + document.getElementById("cmbTipoPropiedad").value + "|" + document.getElementById("txtLegajo").value;
                informeExistente.verificarInformeExistente(valor,OnSucceeded);
            }
        }
            
        if(document.getElementById("cmbTipoPropiedad").value == 2) //Dominio
        {
           if (document.getElementById("txtFolio").value != "" && document.getElementById("txtAno").value != "")
           {
               valor = document.getElementById("hidCliente").value + "|" + document.getElementById("cmbTipoInforme").value + "|" + document.getElementById("cmbTipoPropiedad").value + "|" + document.getElementById("txtFolio").value + "|" + document.getElementById("txtAno").value;
                informeExistente.verificarInformeExistente(valor,OnSucceeded);
           }
        }

        if(document.getElementById("cmbTipoPropiedad").value == 3) // LE
        {
           if (document.getElementById("txtLegajo").value != "" && document.getElementById("txtFolio").value != "")
           {
               valor = document.getElementById("hidCliente").value + "|" + document.getElementById("cmbTipoInforme").value + "|" + document.getElementById("cmbTipoPropiedad").value + "|" + document.getElementById("txtLegajo").value + "|" + document.getElementById("txtFolio").value;
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
        //alert(tempPer.length)
        //alert(tempPer[0])
        //alert(tempPer[1])
        //alert(tempPer[2])
        
        if(tempPer.length > 0)
        {
            if(tempPer[0] != "")
            {
                varMessage = "Existen solicitudes realizadas por: <br>"; 
                for(i=0; i<tempPer.length; i++)
                {
                    var tempSolDetalle = new Array();
                    tempSolDetalle = tempPer[i].split(',');
                    //alert(tempSolDetalle.length)
                    //alert(tempSolDetalle[0])
                    //alert(tempSolDetalle[1])
                    //alert(tempSolDetalle[2])
                    //alert(tempSolDetalle[3])
                    varMessage = varMessage + "<br><a href='../InformePropiedad/Informe.aspx?id=" + tempSolDetalle[0] + "&IdTipo=1' class='link2'><b>" + tempSolDetalle[2] + "</b> el dia " + tempSolDetalle[1] + ", " + tempSolDetalle[3] + "</a>";
                    
                }
                document.getElementById("lblInformesSolicitados3").innerHTML = varMessage;
            }
            else
            {
                document.getElementById("lblInformesSolicitados3").innerHTML = "";
                return false;
            }
            //document.getElementById("DivNombre2").innerHTML = "";
            //document.getElementById("DivNombres").style.display = "";
            /*

            var temp3 = new Array();
            temp3 = tempPer[0].split(',');
            var RsltElemNom1 = document.getElementById("DivNombre1");
            RsltElemNom1.innerHTML = temp3[1];

            var temp4 = new Array();
            temp4 = tempPer[1].split(',');
            var RsltElemNom2 = document.getElementById("DivNombre2");
            RsltElemNom2.innerHTML = temp4[1];

            parserTexto(tempPer[0]);
            */
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

function MostrarAyuda(tipo) {
    if (tipo == "infprop") {
        $('#dialog-alert').dialog('open');
        return true;
    }
}

$(document).ready(function() {
    $("#dialog:ui-dialog").dialog("destroy");

    $("#dialog-alert").dialog({
        modal: true,
        autoOpen: false,
        width: 350,
        height: 330,
        buttons: {
            Ok: function() {
                $(this).dialog("close");
            }
        }
    });
});

function validarMatricula(source, arguments) {
    var Valor = document.all.txtLegajo.value;
    if (Valor.indexOf("/") > 0) //es matricula con PH
    {
        Matricula = Valor.substring(0, Valor.indexOf("/"));
        if (!validarNumero(Matricula)) {
            arguments.IsValid = false;
            return;
        }
    }
    else {
        if (!validarNumero(Valor)) {
            arguments.IsValid = false;
            return;
        }
    }
    arguments.IsValid = true;
}

function validarNumero(c_numero) {
    if (c_numero.length == 0) {
        return false;
    }
    else {
        for (i = 0; i < c_numero.length; i++) {
            if (!((c_numero.charAt(i) >= "0") && (c_numero.charAt(i) <= "9")))
                return false;
        }
        return true;
    }
}

function validarCaracter(datos) {

    //alert("Desde el 27/12/2011 al 31/01/2012 el registro \n solo trabaja con solicitudes NORMALES debido a horarios reducidos.\n Disculpe las molestias ocacionadas. ")
    //datos.selectedIndex = 1;
}
	</script>
</HEAD>
<body>
<form id="Form1" method="post" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    <Services>
        <asp:ServiceReference  Path="../services/informeExistente.asmx" />
    </Services>
</asp:ScriptManager>

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
<tr>
	<td class="title" width="100%">Solicitud de Informe
        <HR>
        <asp:Panel ID="pnlMensaje" runat="server" CssClass="text">
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </asp:Panel>
        <br />
	</td>
</tr>
<tr><td>
    <asp:Panel ID="pnObservaciones" runat="server" Visible="false">
     <div class="text" style="width:480px; border:solid 1px #696969; background-color:#FFFFE1; padding:10px; margin-bottom:10px;">
         <asp:Label ID="lblObserva" runat="server"></asp:Label>
        </div>
    </asp:Panel>
</td></tr>

<tr>
	<td width="100%">
		<table cellSpacing="0" cellPadding="0" width="480" border="0">
		<TR>
			<TD class="text" width="535" colSpan="4">Tipo Informe</TD>
		</TR>
		<TR>
			<!--- EL TIPO DE INFORME --->
			<TD class="text" width="535" colSpan="4">
				<asp:dropdownlist id="cmbTipoInforme" runat="server" Width="479px" AutoPostBack="True" 
				Enabled="False"></asp:dropdownlist>
			</TD>
		</TR>
		<tr>
            <td class="text" width="535" height="10">
            </td>
        </tr>
        <tr>
            <td class="text" width="535"><b>Referencia </b></td>
        </tr>
        <tr>
            <td class="text" width="535">
                <asp:TextBox ID="txtReferencia" runat="server" Width="300px" MaxLength="50" Style="text-transform: uppercase;" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
		<tr>
			<td class="text" width="535" colspan="4" height="10"></td>
		</tr>
		<tr>
			<TD class="text" width="100%">
				<asp:panel id="pnlTipoPersona" runat="server">
            <table cellSpacing=0 cellPadding=0 width="100%" border=0>
              <TR>
                <TD class=text width=535>Tipo Persona:</TD></TR>
              <TR><!--- EL TIPO DE PERSONA --->
                <TD class=text width="100%">
<asp:DropDownList id=cmbTipoPersona runat="server" AutoPostBack="True" Width="100%" onselectedindexchanged="cmbTipoPersona_SelectedIndexChanged">
						<asp:ListItem Value="1">Persona F&#237;sica</asp:ListItem>
						<asp:ListItem Value="2">Persona Jur&#237;dica</asp:ListItem>
					</asp:DropDownList></TD></TR>
              <TR>
                <TD class=text width=535 
            height=10></TD></TR></table>
				</asp:panel>
			</TD>
		</TR>
		<TR>
			<TD class="text" width="100%">
				<!--- COMIENZO PANEL PARTICULARES --->
				<asp:panel id="pnlParticulares" runat="server">
            <table cellSpacing=0 cellPadding=0 width="100%" border=0 style="margin-top: 0px">
              <TR>
                <TD class=title width=535 bgColor=lightgrey colSpan=3 
                  height=10>&nbsp;&nbsp;Datos Personales </TD></TR>
              <TR>
                <TD class=text width=535 colSpan=3>Apellido 
<asp:requiredfieldvalidator id=reqApellido runat="server" ControlToValidate="Apellido" ErrorMessage="Ingrese el apellido">*</asp:requiredfieldvalidator></TD></TR>
              <TR>
                <TD class=text width=535 colSpan=3>
<asp:textbox id=Apellido runat="server" Width="100%"></asp:textbox></TD></TR>
              <TR>
                <TD class=text width=535 colSpan=3>Nombre 
<asp:requiredfieldvalidator id=reqNombre runat="server" ControlToValidate="Nombre" ErrorMessage="Ingrese el nombre">*</asp:requiredfieldvalidator></TD></TR>
              <TR>
                <TD class=text width=535 colSpan=3>
<asp:textbox id=Nombre runat="server" Width="100%"></asp:textbox></TD></TR>
              <TR>
                <TD class=text width=100>Tipo Documento</TD>
                <TD class=text width=235>&nbsp;Documento&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator7 runat="server" ControlToValidate="Documento" ErrorMessage="Ingrese el nro documento">*</asp:RequiredFieldValidator></TD>
                <TD class=text width=161>
                    <asp:Label ID="lblEstadoCivil" runat="server" Text="Estado Civil"></asp:Label></TD>
</TR>
              <TR>

                <TD class=text width=25>
<asp:dropdownlist id=cmbTipoDocumento runat="server" Width="167px">
							<asp:ListItem Value="1" Selected="True">DNI</asp:ListItem>
							<asp:ListItem Value="2">Libreta C&#237;vica</asp:ListItem>
							<asp:ListItem Value="3">Libreta de enrolamiento</asp:ListItem>
						</asp:dropdownlist></TD>
                <TD class=text width=235>
<asp:textbox id=Documento runat="server" Width="144px"></asp:textbox></TD>
                <TD class=text width=161>
<asp:dropdownlist id=cmbEstadoCivil runat="server" Width="161px">
							<asp:ListItem Value="1">Soltero/a</asp:ListItem>
							<asp:ListItem Value="2">Casado/a</asp:ListItem>
							<asp:ListItem Value="3">Divorciado/a</asp:ListItem>
							<asp:ListItem Value="4">Viudo/a</asp:ListItem>
						</asp:dropdownlist></TD>
</TR>
              <TR>
                <TD class=text width=535 colSpan=3 height=10></TD></TR>
              <TR>
                <TD class=text width=535 colSpan=3 
            height=10></TD></TR></table>
				</asp:panel>
				<!--- FIN PANEL PARTICULARES --->
				</TD>
			</TR>
			<TR>
				<td width="536" colSpan="4">
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="text" width="50%">
						<!--- COMIENZO PANEL AUTOMOTOR --->
						<asp:panel id="pnlAutomotor" runat="server">
                  <table cellSpacing=0 cellPadding=0 width="100%" border=0>
                    <TR>
                      <TD width=536>
                        <table cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=title width="100%" bgColor=lightgrey height=10>&nbsp;&nbsp; Informe de 
                              Automotor </TD>
                            <TD class=title height=10>
                                <a href="#" onclick="javascript:mostrarFiltro(false, imgMasInfo);">
                                <img id="imgMasInfo" alt="Más Info" border="0" src="/img/Arrow.gif"> 
                        </img></a></TD></TR></TABLE></TD></TR>
                    <TR>
                      <TD class=text width="100%">Dominio&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator1 runat="server" ControlToValidate="Dominio" ErrorMessage="Ingrese el dominio">*</asp:RequiredFieldValidator></TD></TR>
                    <TR>
                      <TD class=text width="100%">
<asp:TextBox id=Dominio runat="server" Width="100%"></asp:TextBox></TD></TR>
                    <TR id=masInfo style="DISPLAY: none">
                      <TD class=text width="100%">
                        <table cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="100%">
                              <table cellSpacing=0 cellPadding=0 width="100%" 
                              border=0>
                                <TR>
                                <TD class=text width="100%" colSpan=4>Registro 
                                donde está Inscripto </TD></TR>
                                <TR>
                                <TD class=text width="100%" colSpan=4>
<asp:TextBox id=Registro runat="server" Width="100%"></asp:TextBox></TD></TR>
                                <TR>
                                <TD class=text width="70%">Calle</TD>
                                <TD class=text width="10%">Nro.</TD>
                                <TD class=text width="10%">Dpto.</TD>
                                <TD class=text width="10%">Piso</TD></TR>
                                <TR>
                                <TD class=text width="70%">
<asp:TextBox id=CalleRegistro runat="server" Width="320px"></asp:TextBox></TD>
                                <TD class=text width="10%">
<asp:TextBox id=NroRegistro runat="server" Width="46px"></asp:TextBox></TD>
                                <TD class=text width="10%">
<asp:TextBox id=DptoRegistro runat="server" Width="46px"></asp:TextBox></TD>
                                <TD class=text width="10%">
<asp:TextBox id=PisoRegistro runat="server" Width="47px"></asp:TextBox></TD></TR>
                                <TR>
                                <TD colSpan=4>
                                <table cellSpacing=0 cellPadding=0 width="100%" 
                                border=0>
                                <TR>
                                <TD class=text width="50%">Barrio</TD>
                                <TD class=text width="10%">Código 
                                Postal</TD></TR>
                                <TR>
                                <TD class=text width="50%">
<asp:TextBox id=BarrioRegistro runat="server" Width="320px"></asp:TextBox></TD>
                                <TD class=text width="10%">
<asp:TextBox id=CPRegistro runat="server" Width="144px"></asp:TextBox></TD></TR></table></TD></TR>
                                <TR>
                                <TD colSpan=4>
                                <table cellSpacing=0 cellPadding=0 width="100%" 
                                border=0>
                                <TR>
                                <TD class=text width="10%">Provincia</TD>
                                <TD class=text width="50%">Localidad</TD></TR>
                                <TR>
                                <TD class=text width="10%">
<asp:dropdownlist id=cmbProvinciaRegistro runat="server" AutoPostBack="True" Width="240px" onselectedindexchanged="cmbProvinciaRegistro_SelectedIndexChanged"></asp:dropdownlist></TD>
                                <TD class=text width="50%">
<asp:dropdownlist id=cmbLocalidadRegistro runat="server" Width="240px"></asp:dropdownlist></TD></TR></table></TD></TR></table></TD></TR></table></TD></TR></table>
												</asp:panel><asp:panel id="pnlDomicilioParticular" runat="server">
                  <table cellSpacing=0 cellPadding=0 width="100%" border=0>
                    <TR>
                      <TD width=536>
                        <table cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=title width="100%" bgColor=lightgrey height=10>&nbsp;&nbsp;<asp:Label ID="lblDomParticular" runat="server" Text="Verificación Domicilio Particular"></asp:Label></TD></TR></table></TD></TR>
                    <TR>
                      <TD width=536>
                        <table cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="70%">Calle&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator2 runat="server" ControlToValidate="Calle" ErrorMessage="Ingrese la calle">*</asp:RequiredFieldValidator></TD>
                            <TD class=text width="10%">Nro. 
<asp:RequiredFieldValidator id=RequiredFieldValidator3 runat="server" ControlToValidate="Nro" ErrorMessage="Ingrese el Nro">*</asp:RequiredFieldValidator></TD>
                            <TD class=text width="10%">Dpto.</TD>
                            <TD class=text width="10%">Piso</TD></TR>
                          <TR>
                            <TD class=text width="70%">
<asp:textbox id=Calle runat="server" Width="320px"></asp:textbox></TD>
                            <TD class=text width="10%">
<asp:textbox id=Nro runat="server" Width="46px"></asp:textbox></TD>
                            <TD class=text width="10%">
<asp:textbox id=Dpto runat="server" Width="46px"></asp:textbox></TD>
                            <TD class=text width="10%">
<asp:textbox id=Piso runat="server" Width="47px"></asp:textbox></TD></TR></table></TD></TR>
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
                    <TR>
                      <TD width=536>
                        <table cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="50%">Barrio&nbsp; </TD>
                            <TD class=text width="10%">Código Postal&nbsp; 
                          </TD></TR>
                          <TR>
                            <TD class=text width="50%">
<asp:textbox id=barrio runat="server" Width="320px"></asp:textbox></TD>
                            <TD class=text width="10%">
<asp:textbox id=CP runat="server" Width="144px"></asp:textbox></TD></TR></table></TD></TR>
                    
                    <asp:panel id="pnlAmbientalExtra" runat="server">
                    <tr>
                      <td width="536" colSpan="4">
                          <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                          <tr>
                            <td class="text" width="40%">Tel&eacute;fono&nbsp;</td>
                            <td class="text">Email&nbsp;</td>
                          </tr>
                          <tr>
                            <td class="text">
                                <asp:textbox id="txtTelefonoAMB" runat="server" Width="180px"></asp:textbox>
                            </td>
                            <td class="text">
                                <asp:textbox id="txtEMailAMB" runat="server" Width="288px"></asp:textbox>
                            </td>
                          </tr>
                          </table>
                      </td>  
                    </tr>
                    </asp:panel>
                    
                    <TR>
                      <TD width=536>
                        <table cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="50%">Provincia&nbsp; </TD>
                            <TD class=text width="10%">Localidad&nbsp; </TD></TR>
                          <TR>
                            <TD class=text width="10%">
<asp:dropdownlist id=cmbProvincia runat="server" AutoPostBack="True" Width="240px"></asp:dropdownlist></TD>
                            <TD class=text width="50%">
<asp:dropdownlist id=cmbLocalidad runat="server" Width="240px"></asp:dropdownlist></TD></TR></table></TD></TR>
                    <TR>
                      <TD class=text width=535 
                    height=10></TD></TR></table>
												</asp:panel>
												<asp:panel id="pnlPropiedad" runat="server">
                  <table cellSpacing=0 cellPadding=0 width="100%" border=0>
                    <TR>
                      <TD width=536>
                        <table cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=title width="100%" bgColor=lightgrey height=10>&nbsp;&nbsp; Informe de la 
                              Propiedad</TD></TR></table></TD></TR>
                    <TR>
                      <TD class=text width="100%">Datos sobre la 
                        Propiedad</TD></TR>
                    <TR>
                      <TD class=text width="100%">
<asp:DropDownList id=cmbTipoPropiedad runat="server" AutoPostBack="True" Width="100%" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
																	<asp:ListItem Value="1">Matricula</asp:ListItem>
																	<asp:ListItem Value="2">Dominio</asp:ListItem>
																	<asp:ListItem Value="3">Legajo Especial</asp:ListItem>
																	<asp:ListItem Value="4">Planilla de subdivisión</asp:ListItem>
																</asp:DropDownList></TD></TR>
                                                                    <TR>
                                                                                          <TD class=text width=175>
                                                                    <asp:Label id=lblTipoPropiedad runat="server" Font-Bold="True">Nro de Matricula</asp:Label>&nbsp; 
                                                                    <asp:RequiredFieldValidator id=ValMatricula runat="server" ControlToValidate="txtLegajo" ErrorMessage="Ingrese matricula">*</asp:RequiredFieldValidator>
                                                                    <asp:CustomValidator ID="valCusMatricula" ControlToValidate="txtLegajo" ClientValidationFunction="validarMatricula" runat="server" ErrorMessage="Matricula no válida. Ver ejemplo." Text="*"></asp:CustomValidator>
                                                                    </TD></TR>
                                                                                        <TR>
                                                                                          <TD class=text width="100%">
                                                                    <asp:TextBox id="txtLegajo" runat="server" Width="95%" style="text-transform: uppercase;" onprerender="txtLegajo_PreRender" MaxLength="12"></asp:TextBox>
                                                                                              &nbsp;<a href="javascript:;" onclick="MostrarAyuda('infprop');"><img
                                                                        alt="" src="../Img/signo.jpg" width="16" height="16" border="0" /></a></TD></TR>
                                                                    <tr><td>
                                                                    <asp:panel id=pnlDominioLegEspecial runat="server" Width="100%">
                                                                    <table cellSpacing=0 cellPadding=0 width="100%" border=0>
                                                                                        <TR>
                                                                                          <TD class=text width=175>Folio&nbsp; 
                                                                    <asp:RequiredFieldValidator id=ValtxtFolio runat="server" ControlToValidate="txtFolio" ErrorMessage="Ingrese el folio">*</asp:RequiredFieldValidator></TD>
                                                                                          <TD class=text width="33%">Tomo</TD>
                                                                                          <TD class=text width="33%">Año 
                                                                    <asp:RequiredFieldValidator id=ValtxtAno runat="server" ControlToValidate="txtAno" ErrorMessage="Ingrese el año">*</asp:RequiredFieldValidator><asp:CompareValidator ID="cmpAnio" runat="server" ErrorMessage="Año no válido" 
                                                                                                                                                Operator="GreaterThan" Type="Integer" ValueToCompare="1900" ControlToValidate="txtAno">*</asp:CompareValidator></TD></TR>
                                                                                        <TR>
                                                                                          <TD class=text width=175>
                                                                    <asp:TextBox id=txtFolio runat="server" Width="140px" style="text-transform: uppercase;" onprerender="txtFolio_PreRender"></asp:TextBox></TD>
                                                                                          <TD class=text width="33%">
                                                                    <asp:TextBox id=txtTomo runat="server" Width="140px"></asp:TextBox></TD>
                                                                                          <TD class=text align=left width="33%">
                                                                    <asp:TextBox id=txtAno runat="server" Width="140px" style="text-transform: uppercase;" onprerender="txtAno_PreRender"></asp:TextBox></TD></TR>
                                                                    </table>
                                                                    </asp:panel>
                                                                    </td></tr>
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
</table>
												</asp:panel>
												<asp:panel id="pnlCatastral" runat="server" Width="100%">
                  <table cellSpacing=0 cellPadding=0 width="100%" border=0>
                    <TR>
                      <TD width=536>
                        <table cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=title width="100%" bgColor=lightgrey height=10>&nbsp;&nbsp; Informe 
                            Catastral</TD></TR></table></TD></TR>
                    <TR>
                      <TD class=text width="100%">Tipo Informe</TD></TR>
                    <TR>
                      <TD class=text width="100%">
<asp:DropDownList id=cmbTipoCatastral runat="server" AutoPostBack="True" Width="100%" onselectedindexchanged="cmbTipoCatastral_SelectedIndexChanged">
																	<asp:ListItem Value="1">Seg&#250;n Nomenclatura</asp:ListItem>
                                                                    <asp:ListItem Value="2">Seg&#250;n Nro de Cuenta</asp:ListItem>
                                                                    <asp:ListItem Value="3">Seg&#250;n Direcci&#243;n</asp:ListItem>
																</asp:DropDownList></TD></TR>
                    <TR>
                      <TD width=536>
                        <table cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="50%">Provincia&nbsp; </TD>
                            <TD class=text width="10%">Localidad&nbsp; </TD></TR>
                          <TR>
                            <TD class=text width="10%">
<asp:dropdownlist id=cmbProvinciaCatastro runat="server" AutoPostBack="True" Width="240px" onselectedindexchanged="cmbProvinciaCatastro_SelectedIndexChanged"></asp:dropdownlist></TD>
                            <TD class=text width="50%">
<asp:dropdownlist id=cmbLocalidadCatastro runat="server" Width="240px"></asp:dropdownlist></TD></TR></table></TD></TR>
                    <TR>
                      <TD class=text width="60%">
<asp:Label id=lblNumero runat="server">Número</asp:Label></TD></TR>
                    <TR>
                      <TD class=text width="100%">
<asp:TextBox id=NumeroCatastro runat="server" Width="100%"></asp:TextBox></TD></TR>
<asp:panel id=pnlCatastralDireccion runat="server">
                    <TR>
                      <TD class=text width="100%" colSpan=3>
                        <table cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="70%">Calle&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator19 runat="server" ControlToValidate="CatCalle" ErrorMessage="Ingrese la calle">*</asp:RequiredFieldValidator></TD>
                            <TD class=text width="10%">Nro.&nbsp; </TD>
                            <TD class=text width="10%">Dpto.</TD>
                            <TD class=text width="10%">Piso</TD></TR>
                          <TR>
                            <TD class=text width="70%">
<asp:textbox id=CatCalle runat="server" Width="320px"></asp:textbox></TD>
                            <TD class=text width="10%">
<asp:textbox id=CatNro runat="server" Width="46px"></asp:textbox></TD>
                            <TD class=text width="10%">
<asp:textbox id=CatDpto runat="server" Width="46px"></asp:textbox></TD>
                            <TD class=text width="10%">
<asp:textbox id=CatPiso runat="server" Width="47px"></asp:textbox></TD></TR></table></TD></TR>
                    <TR>
                      <TD width=536 colSpan=4>
                        <table cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="50%">Barrio&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator21 runat="server" ControlToValidate="CatBarrio" ErrorMessage="Ingrese el barrio">*</asp:RequiredFieldValidator></TD>
                            <TD class=text width="10%">Código Postal&nbsp; 
                          </TD></TR>
                          <TR>
                            <TD class=text width="50%">
<asp:textbox id=CatBarrio runat="server" Width="320px"></asp:textbox></TD>
                            <TD class=text width="10%">
<asp:textbox id=CatCP runat="server" Width="144px"></asp:textbox></TD></TR></table></TD></TR></asp:panel></table>
												</asp:panel>
												<asp:panel id="pnlAmbiental" runat="server">
                  <table cellSpacing=0 cellPadding=0 width="100%" border=0>
                    <TR>
                      <TD width=536 colSpan=2>
                        <table cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=title width="100%" bgColor=lightgrey height=10>&nbsp;&nbsp; Informe 
                            Ambiental</TD></TR></table></TD></TR>
                    <TR>
                      <TD class=text width=282 colSpan=2>Apellido del Cónyugue 
                        / Concubino</TD></TR>
                    <TR>
                      <TD class=text width="100%" colSpan=2>
<asp:TextBox id=ambApellido runat="server" Width="100%"></asp:TextBox></TD></TR>
                    <TR>
                      <TD class=text width="60%" colSpan=2>Nombre del Cónyugue 
                        / Concubino</TD></TR>
                    <TR>
                      <TD class=text width="100%" colSpan=2>
<asp:TextBox id=ambNombre runat="server" Width="100%"></asp:TextBox></TD></TR>
                    <TR>
                      <TD class=text width="50%">Tipo Documento</TD>
                      <TD class=text width="50%">Documento</TD></TR>
                    <TR>
                      <TD class=text width="50%">
<asp:DropDownList id=cmbAmbTipoDoc runat="server" Width="220px">
																	<asp:ListItem Value="1" Selected="True">DNI</asp:ListItem>
																	<asp:ListItem Value="2">Libreta C&#237;vica</asp:ListItem>
																	<asp:ListItem Value="3">Libreta de enrolamiento</asp:ListItem>
																</asp:DropDownList></TD>
                      <TD class=text width="50%">
<asp:TextBox id=ambDocumento runat="server" Width="250px"></asp:TextBox></TD></TR></table>
												</asp:panel><asp:panel id="pnlDomComercial" runat="server">
                  <table cellSpacing=0 cellPadding=0 width="100%" border=0>
                    <TR>
                      <TD width=536>
                        <table cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=title width="100%" bgColor=lightgrey height=10>&nbsp;&nbsp; 
<asp:label id=lblInforme runat="server" CssClass="Title">Persona Jurídica</asp:label></TD></TR></table></TD></TR>
                    <TR>
                      <TD class=text>
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
                      
                      </TD></TR>
                    <TR>
                      <TD>
                        <table cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="50%">Nombre de Fantasía</TD>
                            <TD class=text width="10%">Teléfono</TD></TR>
                          <TR>
                            <TD class=text width="50%">
<asp:TextBox id=NombreFantasia runat="server" Width="320px"></asp:TextBox></TD>
                            <TD class=text width="10%">
<asp:TextBox id=Telefono runat="server" Width="144px"></asp:TextBox></TD></TR></table></TD></TR>
                    <TR>
                      <TD>
                        <table cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="50%">Rubro</TD>
                            <TD class=text width="10%">Cuit&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator9 runat="server" ControlToValidate="Cuit" ErrorMessage="Ingrese el CUIT">*</asp:RequiredFieldValidator></TD></TR>
                          <TR>
                            <TD class=text width="50%">
<asp:TextBox id=Rubro runat="server" Width="320px"></asp:TextBox></TD>
                            <TD class=text width="10%">
<asp:TextBox id=Cuit runat="server" Width="144px"></asp:TextBox></TD></TR></table></TD></TR>
                    <TR>
                      <TD>
                        <table cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="70%" height=14>Calle&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator4 runat="server" ControlToValidate="CalleEmpresa" ErrorMessage="Ingrese la Calle">*</asp:RequiredFieldValidator></TD>
                            <TD class=text width="10%" height=14>Nro.&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator5 runat="server" ControlToValidate="NroEmpresa" ErrorMessage="Ingrese el Nro">*</asp:RequiredFieldValidator></TD>
                            <TD class=text width="10%" height=14>Dpto.</TD>
                            <TD class=text width="10%" height=14>Piso</TD></TR>
                          <TR>
                            <TD class=text width="70%">
<asp:TextBox id=CalleEmpresa runat="server" Width="320px"></asp:TextBox></TD>
                            <TD class=text width="10%">
<asp:TextBox id=NroEmpresa runat="server" Width="46px"></asp:TextBox></TD>
                            <TD class=text width="10%">
<asp:TextBox id=DptoEmpresa runat="server" Width="46px"></asp:TextBox></TD>
                            <TD class=text width="10%">
<asp:TextBox id=PisoEmpresa runat="server" Width="47px"></asp:TextBox></TD></TR></table></TD></TR>
                    <TR>
                      <TD>
                        <table cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="50%">Barrio&nbsp; </TD>
                            <TD class=text width="10%">Código Postal&nbsp; 
                          </TD></TR>
                          <TR>
                            <TD class=text width="50%">
<asp:TextBox id=BarrioEmpresa runat="server" Width="320px"></asp:TextBox></TD>
                            <TD class=text width="10%">
<asp:TextBox id=CPEmpresa runat="server" Width="144px"></asp:TextBox></TD></TR></table></TD></TR>
                    <TR>
                      <TD>
                        <table cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="50%" height=14>Provincia </TD>
                            <TD class=text width="10%" 
                              height=14>localidad&nbsp; </TD></TR>
                          <TR>
                            <TD class=text width="10%">
<asp:dropdownlist id=cmbProvinciaEmpresas runat="server" AutoPostBack="True" Width="240px" onselectedindexchanged="cmbProvinciaEmpresas_SelectedIndexChanged"></asp:dropdownlist></TD>
                            <TD class=text width="50%">
<asp:dropdownlist id=cmbLocalidadEmpresas runat="server" Width="240px"></asp:dropdownlist></TD></TR></table></TD></TR>
                    <TR>
                      <TD class=text>&nbsp;&nbsp;</TD></TR></table>
												</asp:panel>
												<asp:panel id="pnlGravamenes" runat="server">
                  <table cellSpacing=0 cellPadding=0 width="100%" border=0>
                    <TR>
                      <TD width=536 colSpan=3>
                        <table cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=title width="100%" bgColor=lightgrey height=10>&nbsp;&nbsp; Informe de 
                              Gravámenes</TD></TR></table></TD></TR>
                    <TR>
                      <TD class=text width="100%" colSpan=3>Tipo de 
                    Gravamen</TD></TR>
                    <TR>
                      <TD class=text width="100%" colSpan=3>
<asp:DropDownList id=cmbTipoGravamen runat="server" AutoPostBack="True" Width="480px" onselectedindexchanged="cmbTipoGravamen_SelectedIndexChanged"></asp:DropDownList></TD></TR>
                    <TR>
                      <TD class=text width="33%">Folio&nbsp; 
<asp:RequiredFieldValidator id=valFolio runat="server" ControlToValidate="Folio" ErrorMessage="Ingrese el folio">*</asp:RequiredFieldValidator></TD>
                      <TD class=text width="33%">Tomo</TD>
                      <TD class=text width="33%">Año&nbsp; 
<asp:RequiredFieldValidator id=valAno runat="server" ControlToValidate="Ano" ErrorMessage="Ingrese el año">*</asp:RequiredFieldValidator></TD></TR>
                    <TR>
                      <TD class=text width="33%">
<asp:TextBox id=Folio runat="server" Width="150px"></asp:TextBox></TD>
                      <TD class=text width="33%">
<asp:TextBox id=Tomo runat="server" Width="150px"></asp:TextBox></TD>
                      <TD class=text width="33%">
<asp:TextBox id=Ano runat="server" Width="160px"></asp:TextBox></TD></TR></table>
												</asp:panel>
											</TD>
										</TR>
									</table>
								</td>
							</TR>
							<TR>
								<TD>
									<asp:panel id="pnlTitulo" runat="server">
            <table cellSpacing=0 cellPadding=0 width="100%" border=0>
              <TR>
                <TD width=536>
                  <table cellSpacing=0 cellPadding=0 width="100%" border=0>
                    <TR>
                      <TD class=title width="100%" bgColor=lightgrey 
                      height=10>&nbsp;&nbsp; 
<asp:label id=lblTitulo runat="server" CssClass="Title">Domicilio Comercial</asp:label></TD></TR></table></TD></TR></table>
									</asp:panel>
								</TD>
							</TR>
							<TR>
								<TD>
									<asp:panel id="pnlFoto" runat="server">
            <table cellSpacing=0 cellPadding=0 width="100%" border=0>
              <TR>
                <TD class=text>&nbsp;&nbsp;</TD></TR>
              <TR>
                <TD class=text>&nbsp;&nbsp;</TD></TR>
              <TR>
                <TD class=text>
<asp:Label id=lblConFoto runat="server" Font-Bold="True">Con foto</asp:Label>&nbsp; 
<asp:RequiredFieldValidator id=valConFoto runat="server" ControlToValidate="raFoto" ErrorMessage="¿Con o sin foto?">*</asp:RequiredFieldValidator>
<asp:RadioButtonList id=raFoto runat="server" Width="56px" CssClass="text" RepeatDirection="Horizontal">
														<asp:ListItem Value="1"> Si</asp:ListItem>
														<asp:ListItem Value="0"> No</asp:ListItem>
													</asp:RadioButtonList></TD></TR></table>
									</asp:panel>
								</TD>
							</TR>
							<TR>
								<TD>
									<asp:panel id="pnlUrgencia" runat="server">
            <table cellSpacing=0 cellPadding=0 width="100%" border=0>
              <TR>
                <TD class=text><STRONG>Carácter</STRONG></TD></TR>
              <TR>
                <TD class=text>
<asp:DropDownList id=cmbCaracter runat="server" onload="cmbCaracter_Load"></asp:DropDownList>
<asp:CompareValidator ID="cmpCaracter" runat="server" ControlToValidate="cmbCaracter" 
                    ErrorMessage="Seleccione carácter de urgencia" Operator="NotEqual" 
                    ValueToCompare="0">*</asp:CompareValidator></TD></TR></table>
									</asp:panel>
								</TD>
							</TR>
							<TR>
								<td width="535" colSpan="4">&nbsp;</td>
							</TR>
							<TR>
								<td class="text" width="535" colSpan="4">Observaciones&nbsp;
									<asp:RequiredFieldValidator id="valObservaciones" runat="server" ErrorMessage="Ingrese observaciones" ControlToValidate="Observaciones">*</asp:RequiredFieldValidator></td>
							</TR>
							<TR>
								<td class="text" width="535" colSpan="4"><asp:textbox id="Observaciones" runat="server" Width="480px" CssClass="Plano" Height="79px" Rows="5"
										MaxLength="255" TextMode="MultiLine"></asp:textbox></td>
							</TR>
							<TR>
								<td width="535" colSpan="4">
									<hr>
									<asp:ValidationSummary id="VSBandejaEntrada" runat="server" CssClass="text" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
								</td>
							</TR>
							<TR>
								<td width="536" colSpan="4">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="text" width="60%">&nbsp;<asp:HiddenField ID="hidCliente" runat="server" /></TD>
											<TD class="text" align="right" width="20%"><asp:button id="Aceptar" runat="server" Width="80px" Text="Aceptar" onclick="Aceptar_Click"></asp:button></TD>
											<TD class="text" align="right" width="20%"><asp:button id="Cancelar" runat="server" Width="80px" Text="Cancelar" CausesValidation="False" onclick="Cancelar_Click"></asp:button></TD>
										</TR>
									</table>
								</td>
							</TR>
						</table>
					</td>
				</tr>
			</table>
			<input type="hidden" id="idEncabezado" runat="server" NAME="idEncabezado"> <input type="hidden" id="idReferencia" runat="server" NAME="idReferencia">
<div id="dialog-message" title="Informes existentes">
	<div id="lblInformesSolicitados3" style="margin-left:0px;padding:15px; line-height:1.2; font-size:12px;"></div>
</div>
<div id="dialog-alert" title="Ayuda">
	<div id="lblAyuda" style="margin-left:0px;padding:15px; line-height:1.2; font-size:12px;">
	Ejemplos de matrículas:<br /><br />
	- <b>1234567</b> (matricula simple)<br />
	- <b>1234567/78</b> (matricula con PH)<br />
	- <b>1234567/78-1</b> (matricula con PH)<br />
	- <b>1234567/78.A</b> (matricula con PH)<br />
	
	</div>
</div>
		</form>
	</body>
</HTML>
