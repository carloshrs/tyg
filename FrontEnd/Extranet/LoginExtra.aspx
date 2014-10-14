<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.LoginExtra" CodeFile="/LoginExtra.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Tiempo y Gestión - Extranet</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
  
        <script type="text/javascript" src="site/javascripts/jquery.min.js"></script>

      <link rel="stylesheet" type="text/css" href="site/javascripts/lightbox/themes/default/jquery.lightbox.css" />
      <!--[if IE 6]><link rel="stylesheet" type="text/css" href="javascript/lightbox/themes/default/jquery.lightbox.ie6.css" /><![endif]-->
      <script type="text/javascript" src="site/javascripts/lightbox/jquery.lightbox.js"></script>
      <script type="text/javascript">
          jQuery(document).ready(function () {
              jQuery('.lbRecuperaClave').lightbox();
          });
      </script>
  </HEAD>

	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD width="100%" class="text" colspan="2">&nbsp;
						<table border="0" bordercolor="#333333" align="center" style="WIDTH: 430px; HEIGHT: 173px">
							<tr>
								<td>
                                <table><tr><td>
									<table width="100%" cellpadding="4" border="0">
										<tr>
											<td class="title">
												<div style="font-size:16px; font-weight:bold; margin-bottom:15px;">Ingresá a tu area de Cliente</div>
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
											<td class="text"><img src="/Img/tit_password.gif" border="0"></td>
										</tr>
										<tr>
											<td class="text">
												<INPUT id="txtPassword" style="WIDTH: 240px; HEIGHT: 18px" type="password" size="34" runat="server"
													NAME="txtPassword">
											</td>
										</tr>
										<tr>
											<td align="right" style="height:40px;">
												<br />
												<asp:Button id="btnLogin" runat="server" Text="Login" Width="70px" onclick="btnLogin_Click" PostBackUrl="/LoginExtra.aspx"></asp:Button>&nbsp;&nbsp;
												<asp:Button id="btnCancelar" runat="server" Text="Cancelar" Width="70px" onclick="btnCancelar_Click" CausesValidation="false"  PostBackUrl="/Login.aspx"></asp:Button>
											</td>
										</tr>
                                        <tr><td style="font-size:8pt; font-weight:bold;"><a href="/recuperaClave.aspx?lightbox[width]=300&lightbox[height]=260&lightbox[modal]=true" class="lightbox" style="color:#3399CC">Olvide mi contraseña</a></td></tr>
									</table>
                                    </td>
                                    <td valign="top"><div style="margin-left:20px; font-size:9pt; padding:10px; background-color:#EDEDED; width:200px;">
                                    <span class="title">¿Aún no sos cliente?</span><br />
                                        <br />Conocé la herramienta y los servicios gratuitos que ponemos a tu disposición.<br />
                                    <b><a href="/nuevoUsuario.aspx?lightbox[width]=300&lightbox[height]=360&lightbox[modal]=true" class="lightbox" style="color:#3399CC">Registrate GRATIS</a></b>
                                    </div></td>
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