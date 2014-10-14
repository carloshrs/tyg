<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Contratos.altaContrato" CodeFile="altaContrato.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Alta de Informe</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
			<script>
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
                        __doPostBack(elemento.name,'');
                    }

		    }
			</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="title" width="100%">Alta de Contrato<BR>
						<HR>
						<BR>
					</td>
				</tr>
				<tr>
					<td width="100%">
						<table cellSpacing="0" cellPadding="0" width="480" border="0">
							<TR>
								<TD class="text" width="535" colSpan="4">Tipo Contrato</TD>
							</TR>
							<TR>
								<TD class="text" width="535" colSpan="4"><asp:dropdownlist id="cmbTipoContrato" runat="server" Width="479px" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="text" width="535" colSpan="4" height="10"></TD>
							</TR>
							<TR>
								<TD class="text" width="100%">
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="title" width="535" bgColor="lightgrey" colSpan="4" height="10">&nbsp;&nbsp;Datos 
												Contrato</TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4">Número Contrato&nbsp;</TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4">
												<asp:textbox id="txtNumero" runat="server" Width="100%"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4"></TD>
										</TR>
										<TR>
											<TD class="text" width="161">Fecha Inicio
												<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtFechaInicio"></asp:RequiredFieldValidator></TD>
											<TD class="text" width="100">Fecha Fin
												<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtFechaFin"></asp:RequiredFieldValidator></TD>
										</TR>
										<TR>
											<TD class="text" align="left" width="10%">&nbsp;<asp:textbox id="txtFechaInicio" runat="server" Width="77px"></asp:textbox>&nbsp;
												<IMG id="imgFechaInicio" style="CURSOR: hand" onclick="popFrame.fPopCalendar(imgFechaInicio, txtFechaInicio, divDateControl);"
													alt="Abrir Calendario" src="/img/fecha.gif">
											</TD>
											<TD class="text" align="left" width="10%">&nbsp;&nbsp;<asp:textbox id="txtFechaFin" runat="server" Width="88px"></asp:textbox>&nbsp;
												<IMG id="imgFechaFinal" style="CURSOR: hand" onclick="popFrame.fPopCalendar(imgFechaFinal, txtFechaFin, divDateControl);"
													alt="Abrir Calendario" src="/img/fecha.gif">
											</TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4" height="10"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<td class="text" width="535" colSpan="4">Descripción
									<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="Observaciones"></asp:RequiredFieldValidator></td>
							</TR>
							<TR>
								<td class="text" width="535" colSpan="4"><asp:textbox id="Observaciones" runat="server" Width="480px" CssClass="Plano" Height="79px" Rows="5"
										MaxLength="255" TextMode="MultiLine"></asp:textbox></td>
							</TR>
							<TR>
								<td width="535" colSpan="4">
									<hr>
								</td>
							</TR>
							<TR>
								<td width="536" colSpan="4">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="text" width="60%">&nbsp;</TD>
											<TD class="text" align="right" width="20%"><input id="Cancelar" onclick="javascript:history.back();" type="button" size="" value="  Cancelar  "></TD>
											<TD class="text" align="right" width="20%">
												<asp:button id="Aceptar" runat="server" Width="80px" Text="Siguiente >>" onclick="Aceptar_Click" CausesValidation="False"></asp:button></TD>
										</TR>
									</table>
								</td>
							</TR>
						</table>
					</td>
				</tr>
			</TABLE>
		</form>
		<DIV id="divDateControl" style="Z-INDEX: 102; LEFT: -35px; VISIBILITY: hidden; POSITION: absolute; TOP: -150px"><IFRAME name="popFrame" src="../inc/calendar/calendar.htm" frameBorder="0" width="160" scrolling="no"
				height="160"></IFRAME></DIV>
	</body>
</HTML>
