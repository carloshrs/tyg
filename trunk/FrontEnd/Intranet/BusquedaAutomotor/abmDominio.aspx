<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.BusquedaAutomotor.abmTitular" smartNavigation="False" CodeFile="abmDominio.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Carga de Dominios</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
		<base target="_self">
		<script>
		function validaTotalPorcentaje(source, args)
		{
//			try
			{
	   			if(isNaN(args.Value))
			    {
				  args.IsValid = false;
//   				  popMensaje.fPopMensaje(source,"Valor inválido",divMensaje);
   				}
				else if(100 >= ((parseFloat(Form1.totalPorcentaje.value)-parseFloat(Form1.itemPorcentaje.value))+parseFloat(args.Value)))
				{
				  args.IsValid = true;
				}
			    else
			    {
				  args.IsValid = false;
				  alert("La suma de los porcentajes no debe superar el 100%");
  // 				  popMensaje.fPopMensaje(source,"Valor inválido",divMensaje);
   				}

			}
//			catch(er)
			{
			//	args.IsValid = false;
	//			popMensaje.fPopMensaje(source,"Valor inválido",divMensaje);
			}
		}
		</script>
</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD width="100%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="480" border="0">
							<TR>
								<TD class="text" width="100%"></TD>
							</TR>
							<TR>
								<TD width="536" colSpan="4">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="text" width="50%">
												<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD width="536" colSpan="4">
															<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;Gestión 
																		sobre la verificación</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="text" width="175" colSpan="4">Dominio&nbsp;
															<asp:requiredfieldvalidator id="RequiredFieldValidator16" runat="server" ControlToValidate="txtDominio" ErrorMessage="Ingrese el dominio">*</asp:requiredfieldvalidator></TD>
													</TR>
													<TR>
														<TD class="text" width="100%" colSpan="4"><asp:textbox id="txtDominio" runat="server" Width="100%"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="text" width="175" colSpan="4"><BR>
															Registro donde esta radicado</TD>
													</TR>
													<TR>
														<TD class="text" width="100%" colSpan="4"><asp:textbox id="txtRegistro" runat="server" Width="100%" TextMode="MultiLine" Rows="5"></asp:textbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD width="536" colSpan="4">
									<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="text" width="60%">&nbsp;</TD>
											<TD class="text" align="right" width="20%"><asp:button id="Aceptar" runat="server" Width="80px" Text="Aceptar" onclick="Aceptar_Click"></asp:button></TD>
											<TD class="text" align="right" width="20%"><asp:button id="Cancelar" runat="server" Width="80px" Text="Cancelar" CausesValidation="False" onclick="Cancelar_Click"></asp:button></TD>
										</TR>
									</TABLE>
<asp:ValidationSummary id=VSVerifDomParticular runat="server" ShowSummary="False" ShowMessageBox="True" CssClass="text"></asp:ValidationSummary>
								</TD>
							</TR>
						</TABLE>
						<INPUT id="idDominio" type="hidden" name="idDominio" runat="server"> <INPUT id="idInforme" type="hidden" name="idInforme" runat="server">
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
