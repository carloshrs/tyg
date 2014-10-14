<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.socioAmbiental.Informe" CodeFile="Informe.aspx.cs" %>
<%@ Register TagPrefix="mnu" TagName="menu" Src="../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD runat="server">
		<title>Alta de Informe</title>
		<link href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
		<script src="../Inc/divBusqueda.js" type="text/javascript"></script>
			<script language="javascript">
	    function cargaInicial()
	    {
	         if( mostrarenc && mostrarenc == '1' )
	            mostrarFiltro(document.getElementById('imgSolicitud'));
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
		
		function AJAX_buscar( textRef, valor )
        {
            HTTP_response = request();
            if( HTTP_response == null )
	            return;
            HTTP_response.onreadystatechange = tomarRespuesta;
            HTTP_response.open('GET', '../inc/a_barrios.aspx?query='+valor+"&localidad="+document.Form1.cmbLocalidad.value, true);
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
		function marcarMenu()
		{
		    document.getElementById("td_menu_"+menu+"_1").style.backgroundColor = '#3557A1';
		}
		</script>
		<style>
		    .itemMenu 
		    {
		        background-color: #D3D3D3;
		        text-align: center;
		        color: #3557A1;
		        font-family: Arial, Verdana, Helvetica, Sans-Serif; 
		        font-size:10pt;
		        font-weight: bold;
		        width: 160px;
		    }
		    .itemMenuSelected
		    {
		        background-color: #FFFFFF;
		        font-style: italic;
		    }
		    .itemMenuHover
		    {
		        background-color: #EAEAEA;
		    }
		</style>
</HEAD>
<body leftmargin="0" topmargin="0" onload="marcarMenu(); cargaInicial(); mostrarInfoAdicional();">
<DIV id="divDateControl" style="Z-INDEX: 102; LEFT: -35px; VISIBILITY: hidden; POSITION: absolute; TOP: -170px">
	<IFRAME name="popFrame" src="/inc/calendar/calendar.htm" frameBorder="0" width="160" scrolling="no"	height="160"></IFRAME>
</DIV>
<div id="divBusqueda" style="top: 50px; left: 420px; width:auto; height: 100px; overflow-y:scroll; position:absolute; border-style:solid; border-width:1px; display:none; background-color: #F5F5F5;">
<table style="width:390px" cellpadding="1" cellspacing="0" onMouseOut="limpiarBSQ();"><tbody id="bsqCuerpo" style="font-family: Arial, Verdana, Helvetica, Sans-Serif; font-size:8pt;"></tbody></table>
</div>
<mnu:menu id="Menu" runat="server"></mnu:menu>
<table cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td width="10">&nbsp;</td>
	    <td>
		    <form id="Form1" method="post" runat="server">
		        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
					    <td class="title" width="100%"><br />Informe Socio Ambiental/Preocupacional</td>
					</tr>
					<tr>
					    <td>
					        <table width="100%" class="text" cellpadding="1" cellspacing="1">
					            <tr bgColor="#F3F3F3" class="text">
					                <td>
					                    <table cellpadding="0" cellspacing="0">
					                    <tr>
					                        <td><a href="javascript:mostrarFiltro(document.getElementById('imgSolicitud'));"><img height="14" alt="Mostrar datos de la solicitud" src="/img/Arrow.gif" width="14" border="0" name="imgSolicitud"></a></td>
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
					    <td>
					        <br />
				            <asp:Menu ID="menuTab" runat="server" Orientation="Horizontal" StaticHoverStyle-CssClass="itemMenuHover" StaticMenuItemStyle-CssClass="itemMenu" StaticSelectedStyle-CssClass="itemSelected" StaticMenuStyle-BackColor="#D3D3D3" Width="480" OnMenuItemClick="menuTab_MenuItemClick">
                                <Items>
                                    <asp:MenuItem Text="Personales" Value="0" Selectable="true"></asp:MenuItem>
                                    <asp:MenuItem Text="Generales" Value="1" Selectable="true"></asp:MenuItem>
                                    <asp:MenuItem Text="Vivienda" Value="2" Selectable="true"></asp:MenuItem>
                                </Items>
                            </asp:Menu>
                            <table cellpadding="0" cellspacing="0" width="480px">
                                <tr>
                                    <td id="td_menu_0_1" height="2px"></td>
                                    <td id="td_menu_1_1" height="2px"></td>
                                    <td id="td_menu_2_1" height="2px"></td>
                                </tr>
                            </table>
					    </td>
					</tr>
					<tr>
				        <td width="100%">
            <asp:MultiView ID="contenedor" runat="server" ActiveViewIndex="0">
                <asp:View ID="persDom" runat="server">
                		    <table cellSpacing="0" cellPadding="0" width="480" border="0">
							    <TR>
								    <TD class="text" width="260">&nbsp;</TD>
								</TR>
								<TR>
								    <td width="536">
									    <table cellSpacing="0" cellPadding="0" width="100%" border="0" id="pnlFisica">
										    <TR>
											    <TD class="text" width="50%">
												    <TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                        <TR>
                                                            <TD width="536" colSpan="4">
                                                                <TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                    <TR>
                                                                        <TD class="title" width="100%" bgColor="lightgrey" 
                                                height="10">&nbsp;&nbsp; Datos personales</TD>
                                                                    </TR>
                                                                </TABLE>
                                                                <br />
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                Nombre&nbsp; <asp:requiredfieldvalidator id=Requiredfieldvalidator2 runat="server" ControlToValidate="txtNombre" ErrorMessage="Ingrese el nombre">*</asp:requiredfieldvalidator>
                                                            </TD>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                Apellido&nbsp; <asp:requiredfieldvalidator id=Requiredfieldvalidator3 runat="server" ControlToValidate="txtApellido" ErrorMessage="Ingrese el apellido">*</asp:requiredfieldvalidator>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                <asp:textbox id=txtNombre runat="server" Width="230px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                <asp:textbox id=txtApellido runat="server" Width="100%" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">Tipo de documento</TD>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                Documento <asp:requiredfieldvalidator id=Requiredfieldvalidator4 runat="server" ControlToValidate="txtDocumento" ErrorMessage="Ingrese el nro de documento">*</asp:requiredfieldvalidator>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                <asp:dropdownlist id=cmbTipoDocumento runat="server" Width="230px"></asp:dropdownlist>
                                                            </TD>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                <asp:textbox id=txtDocumento runat="server" Width="216px" MaxLength="20"></asp:textbox>
                                                                &nbsp;
                                                                <asp:ImageButton id=imgCheckPersona runat="server" ImageUrl="/Img/getinfo.gif"></asp:ImageButton>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">Estado civil</TD>
                                                            <TD class="text" width="50%" colSpan="2"></TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                <asp:dropdownlist id=cmbEstadoCivil runat="server" Width="230px"></asp:dropdownlist>
                                                            </TD>
                                                            <TD class="text" width="50%" colSpan="2"></TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">&nbsp;</TD>
                                                            <TD class="text" width="50%" colSpan="2"></TD>
                                                        </TR>
                                                        <TR>
                                                            <TD width="536" colSpan="4">
                                                                <TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                    <TR>
                                                                        <TD class="title" width="100%" bgColor="lightgrey" 
                                                height="10">
                                                                            &nbsp;&nbsp; Domicilio Particular
                                                                        </TD>
                                                                    </TR>
                                                                </TABLE>
                                                                <br />
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                Calle&nbsp;<asp:requiredfieldvalidator id=Requiredfieldvalidator1 runat="server" ControlToValidate="txtCalle" ErrorMessage="Ingrese la calle">*</asp:requiredfieldvalidator>
                                                            </TD>
                                                            <TD class="text" width="50%" colSpan="2"></TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="4">
                                                                <asp:textbox id="txtCalle" runat="server" Width="480px" MaxLength="250"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="25%">
                                                                Nro <asp:requiredfieldvalidator id=Requiredfieldvalidator11 runat="server" ControlToValidate="txtNro" ErrorMessage="Ingrese el Nro">*</asp:requiredfieldvalidator>
                                                            </TD>
                                                            <TD class="text" width="25%">Piso</TD>
                                                            <TD class="text" width="25%">Depto.</TD>
                                                            <TD class="text" width="25%">C.P.</TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="25%">
                                                                <asp:textbox id="txtNro" runat="server" Width="105px" MaxLength="20"></asp:textbox>
                                                            </TD>
                                                            <TD class="text" width="25%">
                                                                <asp:textbox id=txtPiso runat="server" Width="105px" MaxLength="10"></asp:textbox>
                                                            </TD>
                                                            <TD class="text" align="left" width="25%">
                                                                <asp:textbox id=txtDepto runat="server" Width="105px" MaxLength="10"></asp:textbox>
                                                            </TD>
                                                            <TD class="text" align="left" width="25%">
                                                                <asp:textbox id=txtCP runat="server" Width="105px" MaxLength="10"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">Barrio&nbsp;</TD>
                                                            <TD class="text" width="50%" colSpan="2">Tel&eacute;fono&nbsp;</TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                <asp:textbox id=txtBarrio runat="server" Width="100%" MaxLength="250" onKeyUp="bsq_buscar_text(this);" onKeyDown="return bsq_tomarTecla(event);" style="width: 230px;text-transform:uppercase;" onBlur="cerrarBusqueda();"></asp:textbox>
                                                            </TD>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                <asp:textbox id=txtTelefono runat="server" Width="230px" MaxLength="100"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">Provincia </TD>
                                                            <TD class=text width="50%" colSpan="2">Localidad&nbsp; </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                <asp:dropdownlist id=cmbProvincia runat="server" AutoPostBack="True" onselectedindexchanged="cmbProvincia_SelectedIndexChanged"></asp:dropdownlist>
                                                            </TD>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                <asp:dropdownlist id=cmbLocalidad runat="server" onchange='actualizarBarrio();'></asp:dropdownlist>
                                                            </TD>
                                                        </TR>
                                                        <tr><td>&nbsp;</td></tr>
                                                        <TR>
                                                            <TD width="536" colSpan="4">
                                                                <TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                    <TR>
                                                                        <TD class="title" width="100%" bgColor="lightgrey" 
                                                height="10">
                                                                            &nbsp;&nbsp; Estructura familiar (Constitución y ambiente)
                                                                        </TD>
                                                                    </TR>
                                                                </TABLE>
                                                                <br />
                                                            </TD>
                                                        </TR>
                                                        <tr>
										                    <td colspan="4">
										                        <TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                    <TR>
                                                                        <TD class="text" width="50%">
                                                                            Tiene hijos
                                                                        </TD>
                                                                        <TD class="text">
                                                                            Personas a cargo
                                                                        </TD>
                                                                    </TR>
                                                                    <TR>
                                                                        <TD class="text">
                                                                            <asp:TextBox ID="txtTieneHijos" runat="server" MaxLength="10" Width="100px"></asp:TextBox></TD>
                                                                        <TD class="text">
                                                                            <asp:TextBox ID="txtPersACargo" runat="server" MaxLength="10" Width="100px"></asp:TextBox></TD>
                                                                    </TR>
                                                                </TABLE>
                                                            </td>
										                </tr>
										                <TR>
											                <TD class="text" width="535" colSpan="4">&nbsp;
											                </TD>
										                </TR>
										                <TR>
                                                            <TD width="536" colSpan="4">
                                                                <TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                    <TR>
                                                                        <TD class="title" width="100%" bgColor="lightgrey" 
                                                height="10">
                                                                            &nbsp;&nbsp; Nombre y Apellido de la/las personas
                                                                        </TD>
                                                                    </TR>
                                                                </TABLE>
                                                                <br />
                                                            </TD>
                                                        </TR>
                                                        <TR>
											                <TD class="text" width="535" colSpan="4">
												                Apellido y Nombre
												            </TD>
										                </TR>
                                                        <TR>
											                <TD class="text" width="535" colSpan="4">
												                <asp:textbox id="txtPersApe1" runat="server" Width="480px" MaxLength="250"></asp:textbox>
												            </TD>
										                </TR>
										                <TR>
											                <TD class="text" width="25%">
												                Parentezco
												            </TD>
												            <TD class="text" width="25%">
												                Edad
												            </TD>
												            <TD class="text" width="50%" colSpan="2">&nbsp;</TD>
										                </TR>
                                                        <TR>
											                <TD class="text">
                                                                <asp:DropDownList ID="cmbPersPar1" runat="server" Width="110px">
                                                                    <asp:ListItem Selected="True" Value="0">Ninguno</asp:ListItem>
                                                                    <asp:ListItem Value="1">Esposa/Concubina</asp:ListItem>
                                                                    <asp:ListItem Value="2">Padre</asp:ListItem>
                                                                    <asp:ListItem Value="3">Madre</asp:ListItem>
                                                                    <asp:ListItem Value="4">Hijo/a</asp:ListItem>
                                                                    <asp:ListItem Value="5">Abuelo/a</asp:ListItem>
                                                                    <asp:ListItem Value="6">Tio/a</asp:ListItem>
                                                                    <asp:ListItem Value="7">Otro</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
												            <TD class="text">
												                <asp:textbox id="txtPersEdad1" runat="server" Width="110px" MaxLength="10"></asp:textbox>
												            </TD>
												            <TD class="text" width="50%" colSpan="2">&nbsp;</TD>
										                </TR>
                                                        <tr><td colspan="4">
                                                            <hr /></td></tr>
                                                        <TR>
											                <TD class="text" width="535" colSpan="4">
												                Apellido y Nombre
												            </TD>
										                </TR>
                                                        <TR>
											                <TD class="text" width="535" colSpan="4">
												                <asp:textbox id="txtPersApe2" runat="server" Width="480px" MaxLength="250"></asp:textbox>
												            </TD>
										                </TR>
										                <TR>
											                <TD class="text" width="25%">
												                Parentezco
												            </TD>
												            <TD class="text" width="25%">
												                Edad
												            </TD>
												            <TD class="text" width="50%" colSpan="2">&nbsp;</TD>
										                </TR>
                                                        <TR>
											                <TD class="text">
                                                                <asp:DropDownList ID="cmbPersPar2" runat="server" Width="110px">
                                                                    <asp:ListItem Selected="True" Value="0">Ninguno</asp:ListItem>
                                                                    <asp:ListItem Value="1">Esposa/Concubina</asp:ListItem>
                                                                    <asp:ListItem Value="2">Padre</asp:ListItem>
                                                                    <asp:ListItem Value="3">Madre</asp:ListItem>
                                                                    <asp:ListItem Value="4">Hijo/a</asp:ListItem>
                                                                    <asp:ListItem Value="5">Abuelo/a</asp:ListItem>
                                                                    <asp:ListItem Value="6">Tio/a</asp:ListItem>
                                                                    <asp:ListItem Value="7">Otro</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
												            <TD class="text">
												                <asp:textbox id="txtPersEdad2" runat="server" Width="110px" MaxLength="10"></asp:textbox>
												            </TD>
												            <TD class="text" width="50%" colSpan="2">&nbsp;</TD>
										                </TR>
                                                        <tr><td colspan="4">
                                                            <hr /></td></tr>
                                                        <TR>
											                <TD class="text" width="535" colSpan="4">
												                Apellido y Nombre
												            </TD>
										                </TR>
                                                        <TR>
											                <TD class="text" width="535" colSpan="4">
												                <asp:textbox id="txtPersApe3" runat="server" Width="480px" MaxLength="250"></asp:textbox>
												            </TD>
										                </TR>
										                <TR>
											                <TD class="text" width="25%">
												                Parentezco
												            </TD>
												            <TD class="text" width="25%">
												                Edad
												            </TD>
												            <TD class="text" width="50%" colSpan="2">&nbsp;</TD>
										                </TR>
                                                        <TR>
											                <TD class="text">
                                                                <asp:DropDownList ID="cmbPersPar3" runat="server" Width="110px">
                                                                    <asp:ListItem Selected="True" Value="0">Ninguno</asp:ListItem>
                                                                    <asp:ListItem Value="1">Esposa/Concubina</asp:ListItem>
                                                                    <asp:ListItem Value="2">Padre</asp:ListItem>
                                                                    <asp:ListItem Value="3">Madre</asp:ListItem>
                                                                    <asp:ListItem Value="4">Hijo/a</asp:ListItem>
                                                                    <asp:ListItem Value="5">Abuelo/a</asp:ListItem>
                                                                    <asp:ListItem Value="6">Tio/a</asp:ListItem>
                                                                    <asp:ListItem Value="7">Otro</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
												            <TD class="text">
												                <asp:textbox id="txtPersEdad3" runat="server" Width="110px" MaxLength="10"></asp:textbox>
												            </TD>
												            <TD class="text" width="50%" colSpan="2">&nbsp;</TD>
										                </TR>
                                                        <tr><td colspan="4">
                                                            <hr /></td></tr>
                                                        <TR>
											                <TD class="text" width="535" colSpan="4">
												                Apellido y Nombre
												            </TD>
										                </TR>
                                                        <TR>
											                <TD class="text" width="535" colSpan="4">
												                <asp:textbox id="txtPersApe4" runat="server" Width="480px" MaxLength="250"></asp:textbox>
												            </TD>
										                </TR>
										                <TR>
											                <TD class="text" width="25%">
												                Parentezco
												            </TD>
												            <TD class="text" width="25%">
												                Edad
												            </TD>
												            <TD class="text" width="50%" colSpan="2">&nbsp;</TD>
										                </TR>
                                                        <TR>
											                <TD class="text">
                                                                <asp:DropDownList ID="cmbPersPar4" runat="server" Width="110px">
                                                                    <asp:ListItem Selected="True" Value="0">Ninguno</asp:ListItem>
                                                                    <asp:ListItem Value="1">Esposa/Concubina</asp:ListItem>
                                                                    <asp:ListItem Value="2">Padre</asp:ListItem>
                                                                    <asp:ListItem Value="3">Madre</asp:ListItem>
                                                                    <asp:ListItem Value="4">Hijo/a</asp:ListItem>
                                                                    <asp:ListItem Value="5">Abuelo/a</asp:ListItem>
                                                                    <asp:ListItem Value="6">Tio/a</asp:ListItem>
                                                                    <asp:ListItem Value="7">Otro</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
												            <TD class="text">
												                <asp:textbox id="txtPersEdad4" runat="server" Width="110px" MaxLength="10"></asp:textbox>
												            </TD>
												            <TD class="text" width="50%" colSpan="2">&nbsp;</TD>
										                </TR>
                                                        <tr><td colspan="4">
                                                            <hr /></td></tr>
                                                        <TR>
											                <TD class="text" width="535" colSpan="4">
												                Apellido y Nombre
												            </TD>
										                </TR>
                                                        <TR>
											                <TD class="text" width="535" colSpan="4">
												                <asp:textbox id="txtPersApe5" runat="server" Width="480px" MaxLength="250"></asp:textbox>
												            </TD>
										                </TR>
										                <TR>
											                <TD class="text" width="25%">
												                Parentezco
												            </TD>
												            <TD class="text" width="25%">
												                Edad
												            </TD>
												            <TD class="text" width="50%" colSpan="2">&nbsp;</TD>
										                </TR>
                                                        <TR>
											                <TD class="text" style="height: 24px">
                                                                <asp:DropDownList ID="cmbPersPar5" runat="server" Width="110px">
                                                                    <asp:ListItem Selected="True" Value="0">Ninguno</asp:ListItem>
                                                                    <asp:ListItem Value="1">Esposa/Concubina</asp:ListItem>
                                                                    <asp:ListItem Value="2">Padre</asp:ListItem>
                                                                    <asp:ListItem Value="3">Madre</asp:ListItem>
                                                                    <asp:ListItem Value="4">Hijo/a</asp:ListItem>
                                                                    <asp:ListItem Value="5">Abuelo/a</asp:ListItem>
                                                                    <asp:ListItem Value="6">Tio/a</asp:ListItem>
                                                                    <asp:ListItem Value="7">Otro</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
												            <TD class="text" style="height: 24px">
												                <asp:textbox id="txtPersEdad5" runat="server" Width="110px" MaxLength="10"></asp:textbox>
												            </TD>
												            <TD class="text" width="50%" colSpan="2" style="height: 24px">&nbsp;</TD>
										                </TR>
                                                        <tr><td colspan="4">
                                                            <hr /></td></tr>
                                                        <TR>
											                <TD class="text" width="175" colSpan="4">
                                                                <asp:label id="Label1" runat="server">Observaciones</asp:label>&nbsp;</TD>
										                </TR>
										                <TR>
											                <TD class="text" width="100%" colSpan="4">
                                                                <asp:textbox id="txtObservacionesPersonales" runat="server" Width="477px" TextMode="MultiLine" Rows="5"
													                CssClass="Plano"></asp:textbox></TD>
										                </TR>
										                <TR>
                                                            <TD width="536" colSpan="4">
                                                                <br />
                                                                <TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                    <TR>
                                                                        <TD class="title" width="100%" bgColor="lightgrey" 
                                                height="10">&nbsp;&nbsp; Movilidad</TD>
                                                                    </TR>
                                                                </TABLE>
                                                                <br />
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="25%">
                                                                Propia&nbsp;
                                                            </TD>
                                                            <TD class="text" width="25%">
                                                                Multas&nbsp;
                                                            </TD>
                                                            <TD class="text" width="25%">
                                                                Cuantas&nbsp;
                                                            </TD>
                                                            <td>&nbsp;</td>
                                                        </TR>
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButtonList ID="rbtMovPropia" runat="server" RepeatDirection="Horizontal" class="text">
                                                                    <asp:ListItem Value="2">&#160;Si</asp:ListItem>
                                                                    <asp:ListItem Value="1">&#160;No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rbtMovMultas" runat="server" RepeatDirection="Horizontal" class="text">
                                                                    <asp:ListItem Value="2">&#160;Si</asp:ListItem>
                                                                    <asp:ListItem Value="1">&#160;No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:textbox id="txtMovCuantas" runat="server" Width="110px" MaxLength="10"></asp:textbox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                         <tr>
                                                            <td colspan="4" height="5px"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4"><hr /></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" height="3px"></td>
                                                        </tr>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                Automovil/Moto&nbsp;
                                                            </TD>
                                                            <TD class="text" width="50%" colSpan="2"></TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="4">
                                                                <asp:textbox id="txtAutomoto" runat="server" Width="480px" MaxLength="250"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                Estado&nbsp;
                                                            </TD>
                                                            <TD class="text" width="50%" colSpan="2"></TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="4">
                                                                <asp:textbox id="txtEstadoAutomoto" runat="server" Width="480px" MaxLength="250"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>   
                                                            <td colspan="4">
                                                                <table width="100%" cellpadding="0" cellspacing="0" hspace="0" vspace="0">
                                                                    <tr>
                                                                        <TD class="text" width="50%">Modelo</TD>
                                                                        <TD class="text" width="25%">A&ntilde;o</TD>
                                                                        <TD class="text" width="25%">Patente</TD>
                                                                    </tr>
                                                                    <tr>
                                                                        <TD class="text">
                                                                            <asp:textbox id="txtModeloAuto" runat="server" Width="230px" MaxLength="100"></asp:textbox>
                                                                        </TD>
                                                                        <TD class="text">
                                                                            <asp:textbox id="txtAnioAuto" runat="server" Width="110px" MaxLength="10"></asp:textbox>
                                                                        </TD>
                                                                        <TD class="text" align="left" width="25%">
                                                                            <asp:textbox id="txtPatenteAuto" runat="server" Width="110px" MaxLength="10"></asp:textbox>
                                                                        </TD>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">Seguro</TD>
                                                            <TD class="text" width="50%" colSpan="2">Compa&ntilde;ia</TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                <asp:textbox id="txtSeguroAuto" runat="server" Width="230px" MaxLength="250"></asp:textbox>
                                                            </TD>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                <asp:textbox id="txtCompaniaAuto" runat="server" Width="230px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <tr>
                                                            <td colspan="4" height="5px"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4"><hr /></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" height="3px"></td>
                                                        </tr>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">Otros Medios de Transporte</TD>
                                                            <TD class="text" width="50%" colSpan="2">Calidad del Servicio</TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                <asp:textbox id="txtOtrosMedios" runat="server" Width="230px" MaxLength="250"></asp:textbox>
                                                            </TD>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                <asp:textbox id="txtCalidadMedios" runat="server" Width="230px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                    </TABLE>
												</TD>
											</TR>
										</table>
									</td>
								</TR>
								<TR>
								    <td class="text" width="535">&nbsp;</td>
								</TR>
								<TR>
									<td width="535"><hr></td>
								</TR>
								<TR>
									<td width="536">
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="text" align="right">
												    <asp:button id="Button11" runat="server" Width="75px" Text="Guardar" onclick="Aceptar_Click"></asp:button>
												    &nbsp;&nbsp;
												    <asp:button id="Button7" runat="server" Width="75px" Text="< Anterior" Enabled="false"></asp:button>
												    <asp:button id="sig0" runat="server" CausesValidation="False" Width="75px" Text="Siguiente >" OnClick="generales_Click"></asp:button>
													&nbsp;&nbsp;
													<asp:button id="Button9" runat="server" CausesValidation="False" Width="75px" Text="Cancelar" onclick="Cancelar_Click"></asp:button>

											    </TD>
											</TR>
										</table>
									</td>
								</TR>
							</table>
				</asp:View>
            
                <asp:View ID="generales" runat="server">
                            <table cellSpacing="0" cellPadding="0" width="480" border="0">
							    <TR>
								    <TD class="text" width="260">&nbsp;</TD>
								</TR>
								<TR>
								    <td width="536">
									    <table cellSpacing="0" cellPadding="0" width="100%" border="0" id="Table7">
										    <TR>
											    <TD class="text" width="50%">
												    <TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                        <TR>
                                                            <TD width="536" colSpan="4">
                                                                <TABLE id="Table12" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                    <TR>
                                                                        <TD class="title" width="100%" bgColor="lightgrey" 
                                                height="10">&nbsp;&nbsp; Estudios Cursados</TD>
                                                                    </TR>
                                                                </TABLE>
                                                                <br />
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                Primarios&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtEstPrimario" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                Escuela&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtEstabPrimario" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                T&iacute;tulo&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtTitPrimario" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <tr>
                                                            <td colspan="4"><hr /></td>
                                                        </tr>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                Secundarios&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtEstSecundario" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                Instituci&oacute;n&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtEstabSecundario" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                T&iacute;tulo&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtTitSecundario" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <tr>
                                                            <td colspan="4"><hr /></td>
                                                        </tr>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                Terciarios&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtEstTerciario" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                Instituci&oacute;n&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtEstabTerciario" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                T&iacute;tulo&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtTitTerciario" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <tr>
                                                            <td colspan="4"><hr /></td>
                                                        </tr>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                Universitarios&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtEstUniversitario" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                Instituci&oacute;n&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtEstabUniversitario" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                T&iacute;tulo&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtTitUniversitario" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <tr>
                                                            <td colspan="4"><hr /></td>
                                                        </tr>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                Otros cursos&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtOtrosCursos" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                Idiomas&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtIdiomas" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                Computaci&oacute;n&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtComputacion" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <tr><td colspan="4">&nbsp;</td></tr>
                                                        <TR>
                                                            <TD width="536" colSpan="4">
                                                                <TABLE id="Table13" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                    <TR>
                                                                        <TD class="title" width="100%" bgColor="lightgrey" 
                                                height="10">&nbsp;&nbsp; Trabajos Realizados</TD>
                                                                    </TR>
                                                                </TABLE>
                                                                <br />
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                Empresa&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtEmpresa1" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                Domicilio&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtDomEmpresa1" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="2" width="50%">
                                                                Tel&eacute;fonos&nbsp;
                                                            </TD>
                                                            <td class="text" width="25%">Ingreso</td>
                                                            <td class="text" width="25%">Egreso</td>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="2">
                                                                <asp:textbox id="txtTelEmpresa1" runat="server" Width="230px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                            <td class="text">
                                                                <asp:textbox id="txtFecIngEmpresa1" runat="server" Width="95px"></asp:textbox>&nbsp;<IMG id="imgfie1" style="CURSOR: hand" onclick="popFrame.fPopCalendar(imgfie1, txtFecIngEmpresa1, divDateControl);"	alt="Abrir Calendario" src="/img/fecha.gif">
                                                            </td>
                                                            <td class="text">
                                                                <asp:textbox id="txtFecEgEmpresa1" runat="server" Width="95px"></asp:textbox>&nbsp;<IMG id="imgfie2" style="CURSOR: hand" onclick="popFrame.fPopCalendar(imgfie2, txtFecEgEmpresa1, divDateControl);"	alt="Abrir Calendario" src="/img/fecha.gif">
                                                            </td>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="3" width="75%">
                                                                Cargo&nbsp;
                                                            </TD>
                                                            <td class="text" width="25%">Ult recibo de sueldo</td>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="3" width="75%">
                                                                <asp:textbox id="txtCargoEmpresa1" runat="server" Width="350px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                            <td class="text" width="25%">
                                                                <asp:textbox id="txtUltSueldoEmpresa1" runat="server" Width="120px" MaxLength="200"></asp:textbox>
                                                            </td>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                Motivo de desvinculaci&oacute;n&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtDesvEmpresa1" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                Contacto&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtContactoEmpresa1" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <tr><td colspan="4">
                                                            <hr /></td></tr>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                Empresa&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtEmpresa2" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                Domicilio&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtDomEmpresa2" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="2" width="50%">
                                                                Tel&eacute;fonos&nbsp;
                                                            </TD>
                                                            <td class="text" width="25%">Ingreso</td>
                                                            <td class="text" width="25%">Egreso</td>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="2">
                                                                <asp:textbox id="txtTelEmpresa2" runat="server" Width="230px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                            <td class="text">
                                                                <asp:textbox id="txtFecIngEmpresa2" runat="server" Width="95px"></asp:textbox>&nbsp;<IMG id="img3" style="CURSOR: hand" onclick="popFrame.fPopCalendar(img3, txtFecIngEmpresa2, divDateControl);"	alt="Abrir Calendario" src="/img/fecha.gif">
                                                            </td>
                                                            <td class="text">
                                                                <asp:textbox id="txtFecEgEmpresa2" runat="server" Width="95px"></asp:textbox>&nbsp;<IMG id="img4" style="CURSOR: hand" onclick="popFrame.fPopCalendar(img4, txtFecEgEmpresa2, divDateControl);"	alt="Abrir Calendario" src="/img/fecha.gif">
                                                            </td>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="3" width="75%">
                                                                Cargo&nbsp;
                                                            </TD>
                                                            <td class="text" width="25%">Ult recibo de sueldo</td>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="3" width="75%">
                                                                <asp:textbox id="txtCargoEmpresa2" runat="server" Width="350px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                            <td class="text" width="25%">
                                                                <asp:textbox id="txtUltSueldoEmpresa2" runat="server" Width="120px" MaxLength="200"></asp:textbox>
                                                            </td>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                Motivo de desvinculaci&oacute;n&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtDesvEmpresa2" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                Contacto&nbsp;
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtContactoEmpresa2" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <tr><td colspan="4">
                                                            <hr /></td></tr>
                                                        <TR>
											                <TD class="text" width="175" colSpan="4">Referencias obtenidas&nbsp;</TD>
										                </TR>
										                <TR>
											                <TD class="text" width="100%" colSpan="4">
                                                                <asp:textbox id="txtRefLaborales" runat="server" Width="477px" TextMode="MultiLine" Rows="5"
													                CssClass="Plano"></asp:textbox></TD>
										                </TR>
                                                        <tr><td colspan="4">&nbsp;</td></tr>
                                                        <TR>
                                                            <TD width="536" colSpan="4">
                                                                <TABLE id="Table14" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                    <TR>
                                                                        <TD class="title" width="100%" bgColor="lightgrey" 
                                                height="10">&nbsp;&nbsp; Aspectos Generales de la Persona</TD>
                                                                    </TR>
                                                                </TABLE>
                                                                <br />
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="25%">
                                                                Miembro de Club
                                                            </TD>
                                                            <TD class="text" width="75%" colspan="3">
                                                                Nombre del Club
                                                            </TD>
                                                        </TR>
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButtonList ID="rbtClub" runat="server" RepeatDirection="Horizontal" class="text">
                                                                    <asp:ListItem Value="2">&#160;Si</asp:ListItem>
                                                                    <asp:ListItem Value="1">&#160;No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <TD class="text" colSpan="3" width="75%">
                                                                <asp:textbox id="txtClub" runat="server" Width="350px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </tr>
                                                        <TR>
                                                            <TD class="text" width="75%" colspan="3">
                                                                Deportes que practica
                                                            </TD>
                                                            <TD class="text" width="25%">
                                                                Constantemente?
                                                            </TD>
                                                        </TR>
                                                        <tr>
                                                            <TD class="text" colSpan="3" width="75%">
                                                                <asp:textbox id="txtDeportes" runat="server" Width="350px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                            <td>
                                                                <asp:RadioButtonList ID="rbtConstante" runat="server" RepeatDirection="Horizontal" class="text">
                                                                    <asp:ListItem Value="2">&#160;Si</asp:ListItem>
                                                                    <asp:ListItem Value="1">&#160;No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">Ideolog&iacute;a Pol&iacute;tica</TD>
                                                            <TD class="text" width="50%" colSpan="2">Ideolog&iacute;a Religiosa</TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                <asp:textbox id="txtIPolitica" runat="server" Width="230px"></asp:textbox>
                                                            </TD>
                                                            <TD class="text" width="50%" colSpan="2">
                                                                <asp:textbox id="txtIReligiosa" runat="server" Width="230px"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" width="25%">
                                                                Miembro G. Social
                                                            </TD>
                                                            <TD class="text" width="25%">
                                                                Fuma
                                                            </TD>
                                                            <TD class="text" width="25%">
                                                                Bebe
                                                            </TD>
                                                            <TD class="text" width="25%">
                                                                Med. Fijo
                                                            </TD>
                                                        </TR>
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButtonList ID="rbtGSocial" runat="server" RepeatDirection="Horizontal" class="text">
                                                                    <asp:ListItem Value="2">&#160;Si</asp:ListItem>
                                                                    <asp:ListItem Value="1">&#160;No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rbtFuma" runat="server" RepeatDirection="Horizontal" class="text">
                                                                    <asp:ListItem Value="2">&#160;Si</asp:ListItem>
                                                                    <asp:ListItem Value="1">&#160;No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rbtBebe" runat="server" RepeatDirection="Horizontal" class="text">
                                                                    <asp:ListItem Value="2">&#160;Si</asp:ListItem>
                                                                    <asp:ListItem Value="1">&#160;No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rbtMedFijo" runat="server" RepeatDirection="Horizontal" class="text">
                                                                    <asp:ListItem Value="2">&#160;Si</asp:ListItem>
                                                                    <asp:ListItem Value="1">&#160;No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                         <TR>
                                                            <TD class="text" colSpan="4">
                                                                Enfermedades
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="text" colSpan="4">
                                                                <asp:textbox id="txtEnfermedades" runat="server" Width="480px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </TR>
                                                        <TR>
											                <TD class="text" width="175" colSpan="4">Antecedentes Policiales</TD>
										                </TR>
										                <TR>
											                <TD class="text" width="100%" colSpan="4">
                                                                <asp:textbox id="txtPoliciales" runat="server" Width="477px" TextMode="MultiLine" Rows="2"
													                CssClass="Plano"></asp:textbox></TD>
										                </TR>
										                <tr><td colspan="4">
                                                            <hr /></td></tr>
										                <tr>
										                    <td colspan="4" class="text">Qu&eacute; tipo de empresa busca?</td>
										                </tr>
										                <tr>
										                    <td colspan="4" class="text">
										                        <asp:RadioButtonList ID="rbtTipoEmpresa" runat="server" RepeatDirection="Horizontal" class="text">
                                                                    <asp:ListItem Value="1">&#160;Familiar</asp:ListItem>
                                                                    <asp:ListItem Value="2">&#160;Vertical</asp:ListItem>
                                                                    <asp:ListItem Value="3">&#160;Horizontal</asp:ListItem>
                                                                    <asp:ListItem Value="4">&#160;En equipo</asp:ListItem>
                                                                </asp:RadioButtonList>
										                    </td>
										                </tr>
										                <tr><td colspan="4">
                                                            <hr /></td></tr>
                                                        <TR>
											                <TD class="text" width="175" colSpan="4">Comentario Final</TD>
										                </TR>
										                <TR>
											                <TD class="text" width="100%" colSpan="4">
                                                                <asp:textbox id="txtComFinal" runat="server" Width="477px" TextMode="MultiLine" Rows="5"
													                CssClass="Plano"></asp:textbox></TD>
										                </TR>
										                <tr><td colspan="4">&nbsp;</td></tr>
                                                        <TR>
                                                            <TD width="536" colSpan="4">
                                                                <TABLE id="Table15" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                    <TR>
                                                                        <TD class="title" width="100%" bgColor="lightgrey" 
                                                height="10">&nbsp;&nbsp; Gesti&oacute;n de tiempo extra laboral</TD>
                                                                    </TR>
                                                                </TABLE>
                                                                <br />
                                                            </TD>
                                                        </TR> 
										                <TR>
                                                            <TD class="text" width="25%">
                                                                Ve televisi&oacute;n
                                                            </TD>
                                                            <TD class="text" width="75%" colspan="3">
                                                                Qu&eacute; programa?
                                                            </TD>
                                                        </TR>
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButtonList ID="rbtTelevision" runat="server" RepeatDirection="Horizontal" class="text">
                                                                    <asp:ListItem Value="2">&#160;Si</asp:ListItem>
                                                                    <asp:ListItem Value="1">&#160;No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <TD class="text" colSpan="3" width="75%">
                                                                <asp:textbox id="txtPrograma" runat="server" Width="350px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </tr>
                                                        <TR>
                                                            <TD class="text" width="25%">
                                                                Lee
                                                            </TD>
                                                            <TD class="text" width="75%" colspan="3">
                                                                Qu&eacute; lee?
                                                            </TD>
                                                        </TR>
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButtonList ID="rbtLee" runat="server" RepeatDirection="Horizontal" class="text">
                                                                    <asp:ListItem Value="2">&#160;Si</asp:ListItem>
                                                                    <asp:ListItem Value="1">&#160;No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <TD class="text" colSpan="3" width="75%">
                                                                <asp:textbox id="txtLee" runat="server" Width="350px" MaxLength="200"></asp:textbox>
                                                            </TD>
                                                        </tr>
										                <TR>
											                <TD class="text" width="175" colSpan="4">Qu&eacute; haces en tus tiempos libres?</TD>
										                </TR>
										                <TR>
											                <TD class="text" width="100%" colSpan="4">
                                                                <asp:textbox id="txtTiempoLibre" runat="server" Width="477px" TextMode="MultiLine" Rows="2"
													                CssClass="Plano"></asp:textbox></TD>
										                </TR>
										                <TR>
                                                            <TD class="text" width="50%" colspan="2">
                                                                Comparte tiempo con su familia
                                                            </TD>
                                                            <TD class="text" width="50%" colspan="2">
                                                                &nbsp;
                                                            </TD>
                                                        </TR>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:RadioButtonList ID="rbtTiempoFamilia" runat="server" RepeatDirection="Horizontal" class="text">
                                                                    <asp:ListItem Value="2">&#160;Si</asp:ListItem>
                                                                    <asp:ListItem Value="1">&#160;No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <TD class="text" colSpan="2">
                                                                &nbsp;
                                                            </TD>
                                                        </tr>
										                <TR>
											                <TD class="text" width="175" colSpan="4">Actividades con su familia</TD>
										                </TR>
										                <TR>
											                <TD class="text" width="100%" colSpan="4">
                                                                <asp:textbox id="txtActFamiliar" runat="server" Width="477px" TextMode="MultiLine" Rows="2"
													                CssClass="Plano"></asp:textbox></TD>
										                </TR>
										            </TABLE>
                                                </TD>
                                            </TR>
                                            
                                        </table>
                                    </td>
                                </TR>
                                <TR>
								    <td class="text" width="535">&nbsp;</td>
								</TR>
								<TR>
									<td width="535"><hr></td>
								</TR>
								<TR>
									<td width="536">
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="text" align="right">
												    <asp:button id="Button10" runat="server" Width="75px" Text="Guardar" onclick="Aceptar_Click"></asp:button>
												    &nbsp;&nbsp;
												    <asp:button id="Button4" runat="server" Width="75px" Text="< Anterior" onclick="personales_Click"></asp:button>
												    <asp:button id="Button5" runat="server" Width="75px" Text="Siguiente >" onclick="vivienda_Click"></asp:button>
													&nbsp;&nbsp;
													<asp:button id="Button6" runat="server" CausesValidation="False" Width="75px" Text="Cancelar" onclick="Cancelar_Click"></asp:button>
											    </TD>
											</TR>
										</table>
									</td>
								</TR>
                            </table>
                            <script type="text/javascript">
                            Form1.txtFecIngEmpresa1.readOnly = true;
                            Form1.txtFecEgEmpresa1.readOnly = true;
                            Form1.txtFecIngEmpresa2.readOnly = true;
                            Form1.txtFecEgEmpresa2.readOnly = true;
                            </script>           
                </asp:View>
                
                <asp:View ID="vivienda" runat="server">
                            <table cellSpacing="0" cellPadding="0" width="480" border="0">
							    <TR>
								    <TD class="text" width="260">&nbsp;</TD>
								</TR>
								<TR>
								    <td width="536">
									    <table cellSpacing="0" cellPadding="0" width="100%" border="0" id="Table1">
										    <TR>
											    <TD class="text" width="50%">
												    <TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
                
                
                                        <TR>
											<TD colSpan="2">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="title" width="100%" bgColor="lightgrey" height="10">&nbsp;&nbsp; 
															Datos de la vivienda y el entorno</TD>
													</TR>
												</TABLE>
												&nbsp;
											</TD>
										</TR>
										<TR>
											<td class="text" width="100%" colSpan="2">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="text" width="40%">Antiguedad</TD>
														<TD class="text" width="40%">M. alquiler</TD>
														<TD class="text" width="20%">Venc. de contrato</TD>
													</TR>
													<TR>
														<TD class="text"><asp:textbox id="txtAntiguedad" runat="server" Width="165px" MaxLength="200"></asp:textbox></TD>
														<TD class="text"><asp:textbox id="txtMontoAlquiler" runat="server" Width="165px" MaxLength="50"></asp:textbox>&nbsp;
															</TD>
														<TD class="text" valign="middle">
                                                            <asp:textbox id="txtVencimiento" runat="server" Width="60px"></asp:textbox>&nbsp;<IMG id="imgFechaVence" style="CURSOR: hand" onclick="popFrame.fPopCalendar(imgFechaVence, txtVencimiento, divDateControl);"
																alt="Abrir Calendario" src="/img/fecha.gif"></TD>
														
													</TR>
												</TABLE>
											</td>
										</TR>
										<TR>
											<td class="text" width="535" colSpan="2">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="text" width="40%">Tel. Alternativo</TD>
														<TD class="text" width="60%">Acceso al domicilio</TD>
													</TR>
													<TR>
														<TD class="text" style="height: 24px">
                                                            <asp:textbox id="txtTelAlt" runat="server" Width="150px" MaxLength="20"></asp:textbox></TD>
														<TD class="text" style="height: 24px">
                                                            <asp:textbox id="txtAccesoDomicilio" runat="server" Width="300px" MaxLength="250"></asp:textbox></TD>
													</TR>
												</TABLE>
											</td>
										</TR>
										<TR>
											<TD class="text" colSpan="2">
												<TABLE class="text" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD width="33%">&nbsp;</TD>
														<TD width="33%"></TD>
														<TD width="33%"></TD>
													</TR>
													<TR>
														<TD height="14">Vive en caracter de</TD>
														<TD>Estado de conservación</TD>
														<TD>Tipo de construcción</TD>
													</TR>
													<TR>
													    <TD vAlign="top"><asp:radiobuttonlist id="raInteresado" runat="server" CssClass="text"></asp:radiobuttonlist></TD>
														<TD vAlign="top"><asp:radiobuttonlist id="raEstadoCons" runat="server" CssClass="text"></asp:radiobuttonlist></TD>
														<TD vAlign="top">
                                                            <asp:radiobuttonlist id="raTipoConstruccion" runat="server" CssClass="text"></asp:radiobuttonlist></TD>
													</TR>
													<TR>
														<TD height="14"></TD>
														<TD height="14"></TD>
														<TD height="14"></TD>
													</TR>
													<TR>
														<TD height="14">Tipo de Zona</TD>
														<TD height="14">Tipo de calle</TD>
														<TD>Tipo de vivienda</TD>
													</TR>
													<TR>
														<TD vAlign="top"><asp:radiobuttonlist id="raTipoZona" runat="server" CssClass="text"></asp:radiobuttonlist></TD>
														<TD vAlign="top"><asp:radiobuttonlist id="raTipoCalle" runat="server" CssClass="text"></asp:radiobuttonlist></TD>
														<TD vAlign="top"><asp:radiobuttonlist id="raTipoVivienda" runat="server" CssClass="text"></asp:radiobuttonlist></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD class="text" width="261">&nbsp;</TD>
											<TD class="text" width="50%"></TD>
										</TR>
										<tr>
										    <td colspan="2" class="text">
										        <table width="100%">
										        <tr>
										            <td class="text">Cant. Tel.?</td>
										            <td class="text" colspan="2">Televisi&oacute;n</td>
										            <td class="text">Computadora</td>
										            <td class="text" colspan="2">Internet</td>
										        </tr>
										        <tr>
										            <td class="text"><asp:textbox id="txtCantTel" runat="server" Width="50px" MaxLength="5"></asp:textbox></td>
										            <td class="text" rowspan="2">
										                <asp:RadioButtonList ID="rbtTipoTele" runat="server" RepeatDirection="Vertical" class="text">
                                                            <asp:ListItem Value="2">&#160;Cable, cual?</asp:ListItem>
                                                            <asp:ListItem Value="1">&#160;Aire</asp:ListItem>
                                                        </asp:RadioButtonList>
										            </td>
										            <td class="text"><asp:textbox id="txtEmpresaCable" runat="server" Width="80px" MaxLength="100"></asp:textbox></td>
										            <td class="text" rowspan="2">
										                <asp:RadioButtonList ID="txtComputadora" runat="server" RepeatDirection="Vertical" class="text">
                                                            <asp:ListItem Value="2">&#160;Si</asp:ListItem>
                                                            <asp:ListItem Value="1">&#160;No</asp:ListItem>
                                                        </asp:RadioButtonList>
										            </td>
										            <td class="text" rowspan="2">
										                <asp:RadioButtonList ID="txtInternet" runat="server" RepeatDirection="Vertical" class="text">
                                                            <asp:ListItem Value="2">&#160;Si, cual?</asp:ListItem>
                                                            <asp:ListItem Value="1">&#160;No</asp:ListItem>
                                                        </asp:RadioButtonList>
										            </td>
										            <td class="text"><asp:textbox id="txtEmpresaInternet" runat="server" Width="80px" MaxLength="100"></asp:textbox></td>
										        </tr>
										        <tr>
										            <td class="text">&nbsp;</td>
										            <td class="text">&nbsp;</td>
										            <td class="text">&nbsp;</td>
										        </tr>
										        </table>
										    </td>
										</tr>
										<TR>
											<TD class="text" width="261">&nbsp;</TD>
											<TD class="text" width="50%"></TD>
										</TR>
										<TR>
											<TD class="text" width="261">&nbsp;</TD>
											<TD class="text" width="50%"></TD>
										</TR>
										<TR>
											<TD colSpan="2">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="title" width="100%" bgColor="lightgrey" height="10">&nbsp;&nbsp; 
															Referencia vecinal</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<tr>
											<td colSpan="2">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="text">Apellido y nombre</TD>
														<TD class="text">Domicilio</TD>
														<TD class="text">Conoce a la persona</TD>
													</TR>
													<TR>
														<TD class="text"><asp:textbox id="txtNombreVecino" runat="server" Width="170px" MaxLength="250"></asp:textbox></TD>
														<TD class="text"><asp:textbox id="txtDomicilioVecino" runat="server" Width="150px" MaxLength="250"></asp:textbox></TD>
														<TD class="text"><asp:textbox id="txtConoceVecino" runat="server" Width="150px" MaxLength="250"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="text"><asp:textbox id="txtNombreVecino2" runat="server" Width="170px" MaxLength="250"></asp:textbox></TD>
														<TD class="text"><asp:textbox id="txtDomicilioVecino2" runat="server" Width="150px" MaxLength="250"></asp:textbox></TD>
														<TD class="text"><asp:textbox id="txtConoceVecino2" runat="server" Width="150px" MaxLength="250"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="text"><asp:textbox id="txtNombreVecino3" runat="server" Width="170px" MaxLength="250"></asp:textbox></TD>
														<TD class="text"><asp:textbox id="txtDomicilioVecino3" runat="server" Width="150px" MaxLength="250"></asp:textbox></TD>
														<TD class="text"><asp:textbox id="txtConoceVecino3" runat="server" Width="150px" MaxLength="250"></asp:textbox></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<TR>
											<TD class="text" width="175" colSpan="2">Observaciones&nbsp;</TD>
										</TR>
										<TR>
											<TD class="text" width="100%" colSpan="2">
                                                <asp:textbox id="txtObservaciones" runat="server" Width="477px" TextMode="MultiLine" Rows="5"
													CssClass="Plano"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="text" align="center" width="50%">&nbsp;</TD>
											<TD vAlign="top" width="50%"></TD>
										</TR>
										<TR>
											<TD class="text" width="50%">Plano de&nbsp;ubicación</TD>
											<TD class="text" vAlign="top" width="50%"></TD>
										</TR>
										<TR>
											<TD class="text" align="center" width="50%">
												<P align="left"><IMG height="200" src="/img/plano.gif" width="200" border="1">&nbsp;<BR>
												</P>
											</TD>
											<td vAlign="top" width="50%">
												<TABLE class="text" cellSpacing="1" cellPadding="2">
													<TR>
														<TD>Ubicación <B>A</B></TD>
														<TD>
															<asp:textbox id="txtPlanoA" runat="server" Width="171px" MaxLength="200"></asp:textbox></TD>
													</TR>
													<TR>
														<TD>Ubicación <B>B</B></TD>
														<TD>
															<asp:textbox id="txtPlanoB" runat="server" Width="171px" MaxLength="200"></asp:textbox></TD>
													</TR>
													<TR>
														<TD>Ubicación <B>C</B></TD>
														<TD>
															<asp:textbox id="txtPlanoC" runat="server" Width="171px" MaxLength="200"></asp:textbox></TD>
													</TR>
													<TR>
														<TD>Ubicación <B>D</B></TD>
														<TD>
															<asp:textbox id="txtPlanoD" runat="server" Width="171px" MaxLength="200"></asp:textbox></TD>
													</TR>
												</TABLE>
											</td>
										</TR>
										<TR>
											<TD class="text" align="left" colSpan="2">
												<asp:Panel ID="pnlImagenes" Runat="server">
<asp:Image id=imgFoto runat="server" ImageUrl="/img/shim.gif" BorderWidth="1px" Width="250"></asp:Image>
                                                    <BR>
<asp:HyperLink id=hypMasFotos runat="server" CssClass="text" NavigateUrl="#">Agregar Imágenes...</asp:HyperLink>
												</asp:Panel></TD></TR></TABLE></TD></TR></table></td></TR>
								<TR><td class="text" width="535">&nbsp;</td></TR>
								<TR><td width="535"><hr></td>
								</TR>
								<TR><td width="536"><table cellSpacing="0" cellPadding="0" width="100%" border="0"><TR><TD class="text" align="right"><asp:Button 
                                        ID="Button8" runat="server" onclick="Aceptar_Click" Text="Guardar" Width="75px"></asp:Button>
												    &nbsp;&nbsp;
												    <asp:button id="Button1" runat="server" Width="75px" Text="< Anterior" onclick="generales_Click"></asp:button>
												    <asp:button id="Button2" runat="server" Text="Aceptar y Finalizar" onclick="AceptarFinalizar_Click"></asp:button>
													&nbsp;&nbsp;
													<asp:button id="Button3" runat="server" CausesValidation="False" Width="75px" Text="Cancelar" onclick="Cancelar_Click"></asp:button>
											    </TD>
											</TR>
										</table>
									</td>
								</TR>
							</table>
							<script type="text/javascript">
                            Form1.txtVencimiento.readOnly = true;
                            </script> 
                </asp:View>
            </asp:MultiView>
                        </td>
				    </tr>
                </TABLE>
				<input id="idInforme" type="hidden" name="idInforme" runat="server"> <input id="idReferencia" type="hidden" name="idReferencia" runat="server">
				<INPUT id="idTipoProp" type="hidden" name="idTipoProp" runat="server"><INPUT id="idTipoPersona" type="hidden" name="idTipoPersona" runat="server">
			</form>
		</td>
	</tr>
</table>
<table cellpadding="0" cellspacing="0" border="0">
   	<tr>
		<td width="10">&nbsp;</td>
	</tr>
</table>
</body>
</HTML>
