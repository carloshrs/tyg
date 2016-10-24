<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas.ListaCajaDetalles" CodeFile="ABMCajaDetalle.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Lista de Caja</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" topmargin="0">
		<mnu:menu id="Menu" runat="server"></mnu:menu>
		<form method="post" runat="server">
			<table cellSpacing="0" cellPadding="2" width="98%" border="0">
				<tr>
					<td class="text" vAlign="top" width="5"></td>
					<td class="text" height="38">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="title" height="38">&nbsp; <STRONG>AGREGAR CONCEPTO A CAJA DIARIA</STRONG>
									<HR>
									<BR>
								</td>
							</tr>
                            <tr>
                            <td>
                                <asp:Panel ID="pnlEncabezado" runat="server">
                                    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
							            <tr>
								            <td class="title" style="width:200px;">Fecha apertura: </td><td class="title"> <asp:Label ID="lblFechaApertura" runat="server" Text="" Font-Size="10"></asp:Label></td>
                                            <td class="title">Fecha cierre: </td><td class="title"> <asp:Label ID="lblFechaCierre" runat="server" Text="" Font-Size="10"></asp:Label></td>
                                        </tr>
                                        <tr>
								            <td class="title">Saldo efectivo: </td><td class="title">$ <asp:Label ID="lblSaldoEfectivo" runat="server" Text="" Font-Bold="true"></asp:Label></td>
                                            <td class="title" style="background:#EEE;">Monto efectivo inicial: </td><td class="title" style="background:#EEE;">$ <asp:Label ID="lblEfectivoInicial" runat="server" Text="" Font-Bold="true"></asp:Label></td>
                                        </tr>
                                        <tr>
                                        <td class="title">Saldo cheque: </td><td class="title">$ <asp:Label ID="lblSaldoCheque" runat="server" Text="" Font-Bold="true"></asp:Label></td>
								            
                                            <td class="title" style="background:#EEE;">Monto cheque inicial: </td><td class="title" style="background:#EEE;">$ <asp:Label ID="lblChequeInicial" runat="server" Text="" Font-Bold="true"></asp:Label></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            
                            </td>
                            <tr><td>&nbsp;</td></tr>
                            </tr>
							<tr style="margin-top:30px;">
								<td>
									<table>
                                    <tr><td>Tipo:</td><td><asp:DropDownList ID="cmbTipoIngreso" runat="server" 
                                            onselectedindexchanged="cmbTipoIngreso_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Text="ENTRADA" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="SALIDA" Value="0" Selected></asp:ListItem>
                                            </asp:DropDownList></td>
                                        </tr>
                                        <tr><td>Concepto:</td><td><asp:DropDownList ID="cmbConcepto" runat="server">
                                            </asp:DropDownList></td>
                                        </tr>
                                        <tr><td></td><td>&nbsp;</td></tr>
                                        <tr><td>Monto $:</td><td>
                                            <asp:TextBox ID="txtMonto" runat="server"></asp:TextBox>
                                            <asp:CompareValidator ID="valMonto" runat="server" ControlToValidate="txtMonto" 
                                                ErrorMessage="Monto debe ser numérico" Type="Currency" 
                                                Operator="DataTypeCheck">*</asp:CompareValidator>
                                            </td></tr>
                                    </table>
								</td>
							</tr>
							<tr>
								<td class="text" height="38" align="right">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                                <asp:HiddenField ID="hdIdCaja" Value="" runat="server" />
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
