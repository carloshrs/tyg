<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas.ListaCajaDetalles" CodeFile="VerCajaDetalle.aspx.cs" %>
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
                            
                            </td></tr>
                            <tr><td>&nbsp;</td></tr>

                            <tr><td>&nbsp;</td></tr>
							<tr style="margin-top:30px;">
								<td>
									<table width="500">
                                    <tr><td style="width:80px;" ><strong>Fecha:</strong> <asp:Label ID="lblFecha" runat="server" Text=""></asp:Label></td></tr>
                                    <tr><td ><strong>Tipo:</strong> <asp:Label ID="lblTipo" runat="server" Text=""></asp:Label></td></tr>
                                    <tr><td><strong>1 - Forma de pago:</strong> <asp:Label ID="lblFormaPago1" runat="server" Text=""></asp:Label></td><td><strong>Monto:</strong> $<asp:Label ID="lblMonto1" runat="server" Text=""></asp:Label></td></tr>
                                    <tr><td><strong>2 - Forma de pago:</strong> <asp:Label ID="lblFormaPago2" runat="server" Text=""></asp:Label></td><td><strong>Monto:</strong> $<asp:Label ID="lblMonto2" runat="server" Text=""></asp:Label></td></tr>
                                    <tr><td><strong>3 - Forma de pago:</strong> <asp:Label ID="lblFormaPago3" runat="server" Text=""></asp:Label></td><td><strong>Monto:</strong> $<asp:Label ID="lblMonto3" runat="server" Text=""></asp:Label></td></tr>
                                    <tr><td colspan="2"></td><td>&nbsp;</td></tr>
                                    <tr><td colspan="4" ><strong>Concepto:</strong> <asp:Label ID="lblConcepto" runat="server" Text=""></asp:Label></td></tr>
                                    
                                        
                                    </table>
								</td>
							</tr>
                            <tr><td>
                                <br />
                                <strong>Observaciones</strong></td><td>&nbsp;</td></tr>
                            <tr><td>  <asp:Label ID="lblObservaciones" runat="server" Text=""></asp:Label></td></tr>
							<tr>
								<td class="text" height="38" align="right">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                                <asp:HiddenField ID="hdIdCajaDetalle" Value="" runat="server" />
									<asp:Button id="btnVolver" runat="server" Text="Volver" OnClientClick="javascript:history.back();"></asp:Button> 
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
