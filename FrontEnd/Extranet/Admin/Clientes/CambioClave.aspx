<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Admin.Clientes.AbmUsuario" CodeFile="CambioClave.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administración de Usuarios</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	
	    <link rel="stylesheet" href="../../jquery/themes/base/jquery.ui.all.css"/>
	    <script src="../../jquery/jquery-1.4.4.js" type="text/javascript"></script>
	    <script src="../../jquery/external/jquery.bgiframe-2.1.2.js" type="text/javascript"></script>
	    <script src="../../jquery/ui/jquery.ui.core.js" type="text/javascript"></script>
	    <script src="../../jquery/ui/jquery.ui.widget.js" type="text/javascript"></script>
	    <script src="../../jquery/ui/jquery.ui.mouse.js" type="text/javascript"></script>
	    <script src="../../jquery/ui/jquery.ui.draggable.js" type="text/javascript"></script>
	    <script src="../../jquery/ui/jquery.ui.position.js" type="text/javascript"></script>
	    <script src="../../jquery/ui/jquery.ui.resizable.js" type="text/javascript"></script>
	    <script src="../../jquery/ui/jquery.ui.dialog.js" type="text/javascript"></script>
	    
	    <script type="text/javascript">
	    
	    function Bienvenida()
	    {
	        document.getElementById("dialog-message").style.display ='block';
	        $( "#dialog-message" ).dialog({
		        width: 550,
		        height: 400,
			    modal: true,
			    buttons: {
				    Ok: function() {
					    $( this ).dialog( "close" );
				    }
			    }
		    });
		}
	    </script>
	    
</HEAD>
	<body topMargin="0" leftMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE  cellSpacing="0" cellPadding="0" border="0">
				<TR vAlign="top">
					<TD height="15"></TD>
					<TD></TD>
				</TR>
				<TR vAlign="top">
					<TD ></TD>
					<TD>
						<table cellSpacing="0" cellPadding="0" border="0" id="TABLE1">
							<tr>
								<td>&nbsp;&nbsp;&nbsp;</td>
								<td>
									<table cellSpacing="0" cellPadding="0" width="480" border="0">
										
										<TR>
											<TD class="title" width="60%" colSpan="4">
												Administración de&nbsp;Usuario
												<hr>
											</TD>
										</TR>
										<TR>
											<TD class="title" bgColor="lightgrey" colSpan="4" height="10">&nbsp;&nbsp;Datos del 
												Usuario</TD>
										</TR>
										<TR>
											<TD class="text" width="60%" colSpan="4">Nombre de Inicio de Sesión&nbsp;
												<asp:requiredfieldvalidator id="reqRazonSocial" runat="server" ControlToValidate="txtLoginName" ErrorMessage="El nombre de inicio de sesión no puede estar vacio...">*</asp:requiredfieldvalidator></TD>
										</TR>
										<TR>
											<TD class="text" width="100%" colSpan="4"><asp:textbox id="txtLoginName" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
										</TR>
										<asp:Panel id="panPassword" runat="server">
											<TR>
												<TD class="text" width="60%" colSpan="4">
													<asp:Label id="lblPassword" runat="server">Contraseña</asp:Label>&nbsp;
													<asp:requiredfieldvalidator id="reqPassword" runat="server" ErrorMessage="Debe Ingresar la Contraseña" ControlToValidate="txtPassword">*</asp:requiredfieldvalidator>&nbsp;
													<asp:CompareValidator id="compPassword" runat="server" ErrorMessage="Las Password no coinciden..." ControlToValidate="txtPassword"
														ControlToCompare="txtRePassword" Font-Bold="True">!</asp:CompareValidator></TD>
											</TR>
											<TR>
												<TD class="text" width="100%" colSpan="4"><INPUT class="plano" id="txtPassword" type="password" maxLength="128" size="100" name="txtPassword"
														runat="server">
												</TD>
											</TR>
											<TR>
												<TD class="text" width="60%" colSpan="4">
													<asp:Label id="lblRePassword" runat="server">Reingrese Contraseña</asp:Label>&nbsp;
													<asp:requiredfieldvalidator id="reqRePassword" runat="server" ErrorMessage="Debe Reingresar la Contraseña" ControlToValidate="txtRePassword">*</asp:requiredfieldvalidator></TD>
											</TR>
											<TR>
												<TD class="text" width="100%" colSpan="4"><INPUT class="plano" id="txtRePassword" type="password" maxLength="128" size="100" runat="server"></TD>
											</TR>
										</asp:Panel>
										
										
										<TR>
											<TD class="text" colSpan="4" height="10"></TD>
										</TR>
										<TR>
											<TD class="title" bgColor="lightgrey" colSpan="4" height="10">&nbsp;&nbsp;Cambio de contraseña</TD>
										</TR>
										<TR>
											<td colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<TD class="text">Contraseña anterior</TD>
													</tr>
													<TR>
														<TD class="text" style="height: 24px"><asp:textbox id="pwdAnterior" runat="server" Width="320px" TextMode="Password"></asp:textbox></TD>
													</TR>
													<tr>
														<TD class="text">Nueva contraseña</TD>
													</tr>
													<TR>
														<TD class="text"><asp:textbox id="pwdNuevo" runat="server" Width="320px" TextMode="Password"></asp:textbox></TD>
													</TR>
													<tr>
														<TD class="text">Reingrese nueva contraseña<asp:CompareValidator ID="CVPass" runat="server"
                                                                ErrorMessage="Las claves no coinciden" ControlToCompare="pwdNuevo" ControlToValidate="pwdNuevo2" SetFocusOnError="True">*</asp:CompareValidator></TD>
													</tr>
													<TR>
														<TD class="text" style="height: 24px"><asp:textbox id="pwdNuevo2" runat="server" Width="320px" TextMode="Password"></asp:textbox></TD>
													</TR>
												</table>
											</td>
										</TR>
										<TR>
											<TD class="text" colSpan="4" height="10">
                                                <asp:ValidationSummary ID="VSCambioUsuario" runat="server" CssClass="text" Height="26px"
                                                    ShowMessageBox="True" Width="414px" />
                                            </TD>
										</TR>
										<TR>
											<td colSpan="4">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="text" align="right" width="100%">
															<asp:button id="btnAceptar" runat="server" Width="56px" Text="Aceptar" ToolTip="Aceptar los Cambios" onclick="btnAceptar_Click"></asp:button>&nbsp;&nbsp;
															<asp:button id="btnCancelar" runat="server" Width="56px" Text="Cancelar" ToolTip="Cancelar los Cambios"
																CausesValidation="False" onclick="btnCancelar_Click"></asp:button>&nbsp;&nbsp;
															</TD>
													</TR>
												</table>
											</td>
										</TR>
									</table>
								</td>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
			<div id="dialog-message" title="¡Bienvenido!" style="display:none;">
	<div style="margin:15px; line-height:1.2; font-size:12px;">
	<h4 style="color:#024B90">Bienvenido al sistema de Gestión de Informes y Verificaciones de Tiempo & Gestión</h4>
	Ud. podrá realizar solicitudes de Informes y llevar un seguimiento de los mismos.<br />
	<br />
	Por unica vez, le solicitamos completar la carga de sus datos personales y empresa en el siguiente formulario.
	
	</div>
</div>

		</form>
	</body>
</HTML>
