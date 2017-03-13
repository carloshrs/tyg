<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Login" CodeFile="Login.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Tiempo y Gestión - Intranet</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
  </HEAD>
<style>  
  #contenedor_pie {  position:absolute; bottom: 0px; height: 30px;  margin-top:-40px; 	margin-bottom:0px; background-color:#E3E2DE; margin: 0 auto;  width: 100%; max-width: 100%; text-align: center; padding-top:10px;  }
</style>

	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD width="100%" class="text" bgcolor="#32528e"><IMG src="/img/logo.gif"></TD>
					<TD width="100%" class="text" bgcolor="#32528e"></TD>
				</TR>
				<TR>
					<TD width="100%" class="text" colspan="2" bgcolor="#f1f1f1"><IMG src="/img/shim.gif" width="1" height="1"></TD>
				</TR>
				<TR>
					<TD width="100%" class="text" colspan="2"><BR>
						<BR>
						<BR>
					</TD>
				</TR>
				<TR>
					<TD width="100%" class="text" colspan="2">&nbsp;
						<table width="479" height="173" border="0" bordercolor="#333333" align="center" style="WIDTH: 600px; HEIGHT: 173px">
							<tr>
								<td align="center">
									<table width="100%" cellpadding="4" border="0">
										<tr>
											<td class="title" align="center" colspan="3">
												<asp:Label id="lblErrorPermisos" runat="server" Visible="False">Por favor ingrese un Usuario y Password con privilegios suficientes...</asp:Label>
												<br>
											</td>
										</tr>
										<tr>
											<td width="110">&nbsp;</td>
											<td class="text" colspan="2"><img src="/Img/tit.usuario.png" border="0"></td>
										</tr>
										<tr>
											<td width="110">&nbsp;</td>
											<td class="text" colspan="2">
												<asp:TextBox id="txtUserName" runat="server" Width="239px" class="planotext"></asp:TextBox>
												<asp:RequiredFieldValidator id="UserNameRequired" runat="server" ErrorMessage="Debe Ingresar el Nombre de Usuario"
													ControlToValidate="txtUserName" BackColor="Transparent">*</asp:RequiredFieldValidator>
											</td>
										</tr>
										<tr>
											<td width="110">&nbsp;</td>
											<td class="text" colspan="2"><img src="/Img/tit.clave.png" border="0"></td>
										</tr>
										<tr>
											<td width="110">&nbsp;</td>
											<td class="text" colspan="2">
												<INPUT id="txtPassword" style="WIDTH: 240px; HEIGHT: 18px" type="password" size="34" runat="server"
													NAME="txtPassword">
											</td>
										</tr>
										<tr>
											<td width="110">&nbsp;</td>
											<td align="right" width="245">
												
												<asp:Button id="btnCancelar" runat="server" Text="Cancelar" Width="70px" onclick="btnCancelar_Click"></asp:Button>&nbsp;&nbsp;
                                                <asp:Button id="btnLogin" runat="server" Text="Ingresar" Width="70px" onclick="btnLogin_Click"></asp:Button>
											</td>
											<td width="90">&nbsp;</td>
										</tr>
									</table>
									<asp:Label id="lblLogueo" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="8pt"></asp:Label>
								</td>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
		</form>
			<div id="contenedor_pie">Todos los derechos reservados - Tiempo &amp; Gestión - Servicio Empresarial</div> 
	</body>
</HTML>
