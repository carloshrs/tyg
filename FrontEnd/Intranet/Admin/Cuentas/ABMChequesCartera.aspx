<%@ Register TagPrefix="mnu" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas.ABMChequesCartera" CodeFile="ABMChequesCartera.aspx.cs" %>
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
								<td class="title" height="38">&nbsp; <STRONG>CAMBIO DE ESTADO DE CHEQUE EN CARTERA</STRONG>
									<HR>
									<BR>
								</td>
							</tr>
                            <tr>
                            <td>
                                <asp:Panel ID="pnlEncabezado" runat="server">
                                    <table cellSpacing="0" cellPadding="0" width="70%" border="0">
							            <tr>
								            <td class="title" style="width:150px;">Fecha cobro: </td><td class="title"> 
                                            <asp:Label ID="lblFechaCobro" runat="server" Font-Size="10pt"></asp:Label></td>
                                            <td class="title" style="width:150px;">Fecha emisión: </td><td class="title"> 
                                            <asp:Label ID="lblFechaEmision" runat="server" Font-Size="10pt"></asp:Label></td>
                                        </tr>
                                        <tr><td colspan="4"></td></tr>
                                        <tr>
                                        <td class="title">Banco: </td><td class="title">&nbsp;<asp:Label ID="lblBanco" runat="server" Font-Bold="True"></asp:Label></td>
								            
                                            <td class="title">Nro de cheque: </td><td class="title">&nbsp;<asp:Label ID="lblNroCheque" runat="server" Font-Bold="True"></asp:Label></td>
                                        </tr>
                                        <tr><td colspan="4"></td></tr>
                                        <tr>
								            <td class="title">Monto del cheque: </td><td class="title">$ <asp:Label ID="lblMontoCheque" runat="server" Font-Bold="True" Font-Size="18px"><asp:HiddenField runat="server" ID="hdMonto" /></asp:Label></td>
                                            <td class="title">&nbsp;</td><td class="title">
                                            &nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            
                            </td>
                            <tr><td>&nbsp;</td></tr>
                            </tr>
							<tr style="margin-top:30px;">
								<td>
									<table>
                                    <tr><td>Estado: </td><td><asp:DropDownList ID="cmbEstado" runat="server"></asp:DropDownList></td>
                                        </tr>
                                        
                                        
                                    </table>
								</td>
							</tr>
                            
							<tr>
								<td class="text" height="38" align="right">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                                <asp:HiddenField ID="hdIdChequeCartera" Value="" runat="server" />
									<asp:Button id="btnVolver" runat="server" Text="Volver" OnClientClick="javascript:history.back();"></asp:Button> 
                                    <asp:Button id="btnAgregar" runat="server" Text="Cambiar estado de cheque" 
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
