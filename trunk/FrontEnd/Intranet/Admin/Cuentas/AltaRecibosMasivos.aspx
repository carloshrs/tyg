<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas.ABMCaja" CodeFile="AltaRecibosMasivos.aspx.cs" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD id="HEAD1" runat="server">
		<title>Administración de Funciones</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<form id="frmABMFuncion" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" EnableScriptGlobalization="True"></asp:ScriptManager>
			<table cellSpacing="0" cellPadding="0" border="0">
				<TBODY>
					<tr>
						<td width="30">&nbsp;&nbsp;&nbsp;&nbsp;</td>
						<td width="100%">
							<table cellSpacing="4" cellPadding="0" width="480" border="0">
								<TBODY>
									<TR>
										<TD class="title" width="100%" colspan="4">
											Generar recibos masivos
											<hr>
										</TD>
									</TR>
									<TR>
										<TD class="title" bgColor="lightgrey" height="10" colspan="4">&nbsp;&nbsp;Generar recibos de remitos y partes de entrega</TD>
									</TR>
									                                    
									<TR>
										<TD class="text" height="10" colspan="4">
                                        
                                        <table cellSpacing="0" cellPadding="0" width="70%" border="0">
										<tr>
											<TD class="text" align="left" width="10%">&nbsp;Fecha Desde:&nbsp;
											</TD>
											<TD class="text" align="left" width="10%">&nbsp;Fecha Hasta:&nbsp;
											</TD>
										</tr>
										<tr>
											<TD class="text" align="left" width="10%" style="height: 30px">&nbsp;<asp:textbox id="txtFechaInicio" runat="server" Width="77px"></asp:textbox>
                                                <cc1:CalendarExtender ID="txtFechaInicio_CalendarExtender" runat="server" 
                                                    TargetControlID="txtFechaInicio" PopupButtonID="imgFechaInicio" 
                                                    PopupPosition="BottomRight" Format="dd/MM/yyyy">
                                                </cc1:CalendarExtender>
                                                &nbsp;
												<IMG id="imgFechaInicio" style="CURSOR: hand" 
													alt="Abrir Calendario" src="/img/fecha.gif">
											</TD>
											<TD class="text" align="left" width="10%" style="height: 30px">&nbsp;&nbsp;<asp:textbox id="txtFechaFinal" runat="server" Width="88px"></asp:textbox>
                                                <cc1:CalendarExtender ID="txtFechaFinal_CalendarExtender" runat="server" 
                                                    TargetControlID="txtFechaFinal"
                                                    PopupButtonID="imgFechaFinal" 
                                                    PopupPosition="BottomRight"
                                                    Format="dd/MM/yyyy">
                                                </cc1:CalendarExtender>
                                                &nbsp;
												<IMG id="imgFechaFinal" style="CURSOR: hand" 
													alt="Abrir Calendario" src="/img/fecha.gif">
											</TD>
										</tr>
									</TABLE>
                                        </TD>
									</TR>

                                    <TR>
										<TD class="text" height="10" colspan="4"></TD>
									</TR>
									
									<TR>
										<td colspan="4">
											<table cellSpacing="2" cellPadding="5" width="100%" border="0">
												<TR>
													<TD class="text" align="right" width="100%">
                                                        <asp:button id="btnAceptar" runat="server" Text="Generar recibos" onclick="btnAceptar_Click" OnClientClick="return confirm('Se va a generar los recibos de remitos y partes de entrega en el rango determinado. ¿Desea continuar?');" ></asp:button>&nbsp;&nbsp;
														<asp:button id="btnCancelar" runat="server"  Text="Cancelar" CausesValidation="False" onclick="btnCancelar_Click"></asp:button>
													</TD>
												</TR>
											</table>
										</td>
									</TR>
								</TBODY>
							</table>
						</td>
					</tr>
				</TBODY>
			</table>
		</form>
	</body>
</HTML>
