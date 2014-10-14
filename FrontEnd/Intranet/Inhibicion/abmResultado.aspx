<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Inhibicion.abmResultado" smartNavigation="False" CodeFile="abmResultado.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >


<HTML>
  <HEAD>
		<title>Resultados de Inhibición</title>
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
        <style type="text/css">
            .style1
            {
                font-family: Arial, Verdana, Helvetica, Sans-Serif;
                font-size: 8pt;
                TEXT-DECORATION: none;
                COLOR: #000000;
            }
        </style>
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
																	<TD class="title" width="100%" bgColor="lightgrey" colSpan="3" height="10">&nbsp;&nbsp;Resultado de inhibición</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="text" width="100%" colSpan="4">
                                                            <table cellspacing="4" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td class="text" width="15%">
                                                                        Medida</td>
                                                                        <td class="text" width="12%">
                                                                            <asp:TextBox ID="txtMedida" runat="server" Width="40" Style="text-transform: uppercase;"></asp:TextBox>
                                                                        </td>
                                                                        <td class="text" width="12%" align="right">
                                                                        Diario</td>
                                                                        <td class="text" width="12%">
                                                                            <asp:TextBox ID="txtDiario" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td class="text" width="12%" align="right">
                                                                        Año</td>
                                                                        <td class="text" width="60">
                                                                            <asp:TextBox ID="txtAnio" runat="server" Width="40" MaxLength="4"></asp:TextBox>
                                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                                                ControlToValidate="txtAnio" ErrorMessage="El formato del año es incorrecto" 
                                                                                Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
                                                                        </td>
                                                                        <td class="text" width="12%" align="right">
                                                                        Fecha</td>
                                                                        <td class="text" width="12%">
                                                                            <asp:TextBox ID="txtFecha" runat="server" Width="60" MaxLength="10"></asp:TextBox>
                                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="100%" colspan="8">
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text">Tipo medida</td>
                                                                    <td colspan="7">
                                                                        <asp:TextBox ID="txtTipoMedida" runat="server" Width="180" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text">Ordenado por</td>
                                                                    <td colspan="7">
                                                                        <asp:TextBox ID="txtOrdenadoPor" runat="server" Width="180" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text">Secretaria</td>
                                                                    <td colspan="7">
                                                                        <asp:TextBox ID="txtSecretaria" runat="server" Width="180" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text">En autos</td>
                                                                    <td colspan="7">
                                                                        <asp:TextBox ID="txtEnAutos" runat="server" Width="350" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text">Tipo de búsqueda</td>
                                                                    <td colspan="7">
                                                                        <asp:TextBox ID="txtTipoBusqueda" runat="server" Width="350" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text">Inmuebles gravados</td>
                                                                    <td colspan="7">
                                                                        <asp:TextBox ID="txtInmueblesGravados" runat="server" Width="350" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text">Anotaciones definitivas</td>
                                                                    <td colspan="7">
                                                                        <asp:TextBox ID="txtAnotacionesDefinitivas" runat="server" Width="350" Style="text-transform: uppercase;"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="text" width="100%" colspan="8">
                                                                        &nbsp;</td>
                                                                </tr>

                                                            </table>
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
<asp:ValidationSummary id=VSInhibicion runat="server" ShowSummary="False" ShowMessageBox="True" CssClass="text"></asp:ValidationSummary>
								</TD>
							</TR>
						</TABLE>
						<INPUT id="idResultado" type="hidden" name="idMatricula" runat="server"> <INPUT id="idInforme" type="hidden" name="idInforme" runat="server">
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
