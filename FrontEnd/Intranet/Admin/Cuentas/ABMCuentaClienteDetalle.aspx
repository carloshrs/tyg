<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas.ABMCuentaClienteDetalle" CodeFile="ABMCuentaClienteDetalle.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
		<title>Lista de cuenta cliente</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<form method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
                            EnablePartialRendering="true" EnableScriptGlobalization="True">
         </asp:ScriptManager>
			<table cellSpacing="0" cellPadding="2" width="98%" border="0">
				<tr>
					<td class="text" vAlign="top" width="5"></td>
					<td class="text" height="38">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="title" height="38">&nbsp; <STRONG>AGREGAR CONCEPTO A CUENTA CORRIENTE DE CLIENTE</STRONG>
									<HR>
									<BR>
								</td>
							</tr>
                            <tr>
                            <td>
                                <asp:Panel ID="pnlEncabezado" runat="server">
                                    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<TD class="text" align="left" width="100%">&nbsp;&nbsp; <asp:Label ID="lblCliente" runat="server" Text="" Font-Bold="true" Font-Size="16px"></asp:Label>
											</TD></tr>
                                            <tr>
											<TD class="text" align="left" width="100%">&nbsp;Saldo actual:&nbsp;<asp:Label ID="lblSaldo" runat="server" Text="" Font-Bold="true" Font-Size="16px"></asp:Label>
											</TD>
                                            <td></td>
										</tr>
										
									</TABLE>
                                </asp:Panel>
                            
                            </td>
                            <tr><td>&nbsp;</td></tr>
                            </tr>
							<tr style="margin-top:30px;">
								<td>
									<table>
                                    <tr><td>Tipo:</td><td><asp:DropDownList ID="cmbTipoIngreso" runat="server" 
                                            onselectedindexchanged="cmbTipoIngreso_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Text="ENTRADA" Value="1" Selected></asp:ListItem>
                                            <asp:ListItem Text="SALIDA" Value="0" ></asp:ListItem>
                                            </asp:DropDownList></td>
                                        </tr>
                                        <tr><td>Concepto:</td><td><asp:DropDownList ID="cmbConcepto" runat="server"></asp:DropDownList> &nbsp;&nbsp;&nbsp;Concepto adicional: <asp:TextBox ID="txtConceptoAdicional" style="text-transform:uppercase;"  runat="server" Width="300"></asp:TextBox></td>
                                        </tr>
                                        <tr><td>Forma de pago:</td><td>&nbsp;
                    <asp:DropDownList ID="cmbFormaPago" runat="server" 
                            OnSelectedIndexChanged="cmbFormaPago_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="0" Text="Seleccione forma de pago" />
                        <asp:ListItem  Value="1" Text="Efectivo"/>
                        <asp:ListItem Value="2" Text="Cheque"/>
                        <asp:ListItem Value="3" Text="Transferencia"/>
                        <asp:ListItem Value="4" Text="Depósito"/>
                    </asp:DropDownList><asp:RequiredFieldValidator runat="server" ID="rqValCmbFormaPago" ControlToValidate="cmbFormaPago" ErrorMessage="Seleccione forma de pago" Text="*" InitialValue="0"></asp:RequiredFieldValidator>

                    <asp:Panel ID="pnlCheque" runat="server" Visible="False">
                    <table width="400px">
                    <tr><th colspan="2"><b>Datos del cheque</b></th></tr>
                    <tr><td>Banco:</td><td><asp:TextBox runat="server" ID="txtBanco" Width="280px"></asp:TextBox></td></tr>
                    <tr><td>Número de cheque:</td><td><asp:TextBox runat="server" ID="txtNroCheque" 
                            Width="180px"></asp:TextBox></td></tr>
                    <tr><td>Fecha emisión:</td><td><asp:TextBox runat="server" ID="txtFechaEmision" 
                            Width="60px"></asp:TextBox><cc1:CalendarExtender ID="CEFechaEmision" runat="server" TargetControlID="txtFechaEmision" Enabled="True"></cc1:CalendarExtender></td></tr>
                    <tr><td>Fecha de cobro:</td><td><asp:TextBox runat="server" ID="txtFechaCobro" 
                            Width="60px"></asp:TextBox><cc1:CalendarExtender ID="CEFechaCobro" runat="server" TargetControlID="txtFechaCobro" Enabled="True"></cc1:CalendarExtender></td></tr>
                    </table>
                    </asp:Panel>
                    </td></tr>
                                        <tr><td>Monto $:</td><td>
                                            <asp:TextBox ID="txtMonto" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="valReqMonto" runat="server" ControlToValidate="txtMonto" Text="*" ErrorMessage="Ingrese monto"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="valComMonto" runat="server" ControlToValidate="txtMonto" 
                                                ErrorMessage="Monto debe ser numérico" Type="Currency" 
                                                Operator="DataTypeCheck">*</asp:CompareValidator>
                                            </td></tr>
                                        <tr><td>&nbsp;</td><td>
                                            &nbsp;</td></tr>
                                    </table>
								</td>
							</tr>
                            <tr style="margin-top:30px;">
								<td style="background-color:#EEE">
									<table>
                                    
                                        
                                        <tr><td>
                                            <br />
                                            <strong>Caja Diaria</strong><br />
                                            Ingresar monto en caja diaria: <asp:RadioButtonList ID="raIngresaCaja" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="SI" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="NO" Value="0"></asp:ListItem>
                                            </asp:RadioButtonList>&nbsp; &nbsp;</td><td>
                                            <asp:RequiredFieldValidator ID="valIngresoCaja" runat="server" ControlToValidate="raIngresaCaja" Text="*" ErrorMessage="¿Ingresa a caja?"></asp:RequiredFieldValidator>
                                                <br />
                                                <br />

                                            
                                            

                                            </td></tr>
                                            <tr><td colspan="2">
                                                <br />
                                                Observaciones para la caja<br />
                                            
                                            <asp:TextBox ID="txtObservaciones" runat="server" Rows="3" TextMode="MultiLine" Width="500"></asp:TextBox>
                                            </td></tr>
                                    </table>
								</td>
							</tr>
							<tr>
								<td class="text" height="38" align="right">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
                                <asp:HiddenField ID="hdIdCuentaCliente" Value="" runat="server" />
									<asp:Button id="btnVolver" runat="server" Text="Volver" OnClientClick="javascript:history.back();"></asp:Button> 
                                    <asp:Button id="btnAgregar" runat="server" Text="Agregar concepto" 
                                        onclick="btnAgregar_Click"></asp:Button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
