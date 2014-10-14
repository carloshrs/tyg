<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Contactenos" CodeFile="Contactenos.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Contáctenos</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td width="100%" class="title" colspan="2">Contáctenos<BR>
						<HR>
					</td>
				</tr>
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td width="100%" class="title" colspan="2">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="480" border="0">
							<TR>
								<TD class="text" colSpan="4" height="10">&nbsp;Usuario</TD>
							</TR>
							<TR>
								<TD class="text" width="60%" colSpan="4">&nbsp;
									<asp:Label id="lblUsuario" runat="server" CssClass="txtlabel">Label</asp:Label></TD>
							</TR>
							<TR>
								<TD class="text" width="60%" colSpan="4">&nbsp;Asunto&nbsp;</TD>
							</TR>
							<TR>
								<TD class="text" width="100%" colSpan="4">
									<asp:DropDownList id="cmbTipoContacto" runat="server" Width="512px">
										<asp:ListItem Value="Comentario">Comentario</asp:ListItem>
										<asp:ListItem Value="Sugerencia">Sugerencia</asp:ListItem>
										<asp:ListItem Value="Queja">Queja</asp:ListItem>
										<asp:ListItem Value="Opinion">Opini&#243;n</asp:ListItem>
									</asp:DropDownList></TD>
							</TR>
							<TR>
								<TD class="text" width="282" colSpan="4">&nbsp;Comentario&nbsp;</TD>
							</TR>
							<TR>
								<TD class="text" width="100%" colSpan="2">
									<asp:TextBox id="txtObservaciones" runat="server" Width="100%" Height="80px" TextMode="MultiLine"
										CssClass="Plano"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD class="text" width="282" colSpan="4">&nbsp;</TD>
							</TR>
							<TR>
								<TD colSpan="4">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD colSpan="4">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="text" width="60%">&nbsp;</TD>
											<TD class="text" align="right" width="20%">
												<asp:button id="Aceptar" runat="server" Width="80px" Text="Aceptar" onclick="Aceptar_Click"></asp:button></TD>
											<TD class="text" align="right" width="20%">
												<asp:button id="Cancelar" runat="server" Width="80px" Text="Cancelar" onclick="Cancelar_Click"></asp:button></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
