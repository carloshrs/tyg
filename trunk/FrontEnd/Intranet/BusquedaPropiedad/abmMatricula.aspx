<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.BusquedaPropiedad.abmMatricula" smartNavigation="False" CodeFile="abmMatricula.aspx.cs" %>
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
														<TD class="text" width="100%" colSpan="4">
                                                        <asp:Panel ID="pnlPropiedad" runat="server">
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td class="text" width="100%">
                                                                        Datos sobre la Propiedad</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="100%">
                                                                        <asp:DropDownList ID="cmbTipoPropiedad" runat="server" Width="100%" AutoPostBack="True"
                                                                            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                                            <asp:ListItem Value="1">Matricula</asp:ListItem>
                                                                            <asp:ListItem Value="2">Dominio</asp:ListItem>
                                                                            <asp:ListItem Value="3">Legajo Especial</asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" >
                                                                        <asp:Label ID="lblTipoPropiedad" runat="server" Font-Bold="True">Nro de Matricula</asp:Label>&nbsp;
                                                                        <asp:RequiredFieldValidator ID="ValMatricula" runat="server" ErrorMessage="Ingrese matricula"
                                                                            ControlToValidate="txtLegajo">*</asp:RequiredFieldValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="100%">
                                                                        <asp:TextBox ID="txtLegajo" runat="server" Width="100%" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                                <asp:Panel ID="pnlDominioLegEspecial" runat="server" Width="100%">
                                                                <tr><td><table width="100%">
                                                                    <tr>
                                                                        <td class="text" width="175">
                                                                            Folio&nbsp;
                                                                            <asp:RequiredFieldValidator ID="ValtxtFolio" runat="server" ErrorMessage="Ingrese folio"
                                                                                ControlToValidate="txtFolio">*</asp:RequiredFieldValidator></td>
                                                                        <td class="text" width="33%">
                                                                            Tomo</td>
                                                                        <td class="text" width="33%">
                                                                            Año
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Ingrese el año"
                                                                                ControlToValidate="txtAno">*</asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="text" width="175">
                                                                            <asp:TextBox ID="txtFolio" runat="server" Width="140px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                        <td class="text" width="33%">
                                                                            <asp:TextBox ID="txtTomo" runat="server" Width="140px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                        <td class="text" align="left" width="33%">
                                                                            <asp:TextBox ID="txtAno" runat="server" Width="140px" style="text-transform: uppercase;"></asp:TextBox></td>
                                                                    </tr>
                                                                    </table></td></tr>
                                                                </asp:Panel>
                                                            </table>
                                                        </asp:Panel>
														</TD>
													</TR>
													<TR>
														<TD class="text" width="100%" colSpan="4">&nbsp;</TD>
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
						<INPUT id="idMatricula" type="hidden" name="idMatricula" runat="server"> <INPUT id="idInforme" type="hidden" name="idInforme" runat="server">
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
