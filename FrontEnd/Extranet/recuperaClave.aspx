<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.recuperaClave" CodeFile="recuperaClave.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Tiempo y Gestión - Extranet</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
  </HEAD>

	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD width="100%" class="text" colspan="2">&nbsp;
						<table border="0" bordercolor="#333333" align="center" style="width: 290px; height: 173px">
							<tr>
								<td>
                                <table><tr><td>
									<table width="100%" cellpadding="4" border="0">
										<tr>
											<td class="title">
												<div style="font-size:16px; font-weight:bold; margin-bottom:15px;">¿Olvidó su clave?</div>
											</td>
										</tr>
										<tr>
											<td class="text"><img src="/Img/tit_usuario.gif" border="0"></td>
										</tr>
										<tr>
											<td class="text">
												<asp:TextBox id="txtUserName" runat="server" Width="239px" class="planotext"></asp:TextBox>
												<asp:RequiredFieldValidator id="UserNameRequired" runat="server" ErrorMessage="Debe Ingresar el Nombre de Usuario"
													ControlToValidate="txtUserName" BackColor="Transparent">*</asp:RequiredFieldValidator>
											</td>
										</tr>
										<tr>
											<td class="text"><img src="/Img/tit_email.gif" border="0"></td>
										</tr>
										<tr>
											<td class="text">
												<asp:TextBox id="txtEmail" runat="server" Width="239px" class="planotext"></asp:TextBox>
												<asp:RequiredFieldValidator id="UserNameRequired0" runat="server" ErrorMessage="Debe Ingresar el email"
													ControlToValidate="txtEmail" BackColor="Transparent">*</asp:RequiredFieldValidator>
											</td>
										</tr>
										<tr>
											<td align="right" style="height:40px;">
												<br />
												<asp:Button id="btnLogin" runat="server" Text="Enviar" Width="70px" onclick="btnLogin_Click" PostBackUrl="/recuperaClave.aspx"></asp:Button>&nbsp;&nbsp;
												<asp:Button id="btnCancelar" runat="server" Text="Cancelar" Width="70px" onclick="btnCancelar_Click" CausesValidation="false"  PostBackUrl="/Login.aspx?lightbox[width]=500&lightbox[height]=260&lightbox[modal]=true"></asp:Button>
											</td>
										</tr>
									</table>
                                    </td>
                                    
                                    </tr></table>
                                    <asp:ValidationSummary ID="valLogueo" runat="server" ShowMessageBox="true" ShowSummary="false" />

									<asp:Label id="lblLogueo" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="8pt"></asp:Label>
                                    <br />
                                    <asp:Label id="lblErrorPermisos" runat="server" Visible="False" Font-Size="8pt" class="title">El Usuario no tiene privilegios suficientes.</asp:Label>
								</td>
							</tr>
						</table>
					</TD>
				</TR>
				
			</TABLE>
		</form>
		</body>
</HTML>
