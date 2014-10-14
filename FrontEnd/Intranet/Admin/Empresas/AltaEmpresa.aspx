<%@ Register TagPrefix="uc1" TagName="menu" Src="../../Inc/menu.ascx" %>
<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Contratos.AltaEmpresa" CodeFile="AltaEmpresa.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Alta de Empresas</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
		<script src="/Includes/Funciones.js" type="text/javascript"></script>
  </HEAD>
	<body leftMargin="0" topMargin="0">
		<uc1:menu id="Menu1" runat="server"></uc1:menu>
		<FORM id="Tipos" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%">Alta&nbsp;de Empresas<BR>
						<HR>
						<BR>
					</td>
				</tr>
				<tr>
					<TD width="2%">&nbsp;</TD>
					<TD class="text" align="right" width="93%" colSpan="4">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<TD class="text" width="100%">&nbsp;</TD>
							</tr>
							<tr>
								<TD width="100%">
									<table cellSpacing="0" cellPadding="0" width="528" border="0">
										<TR>
											<TD class="text" width="100%">
												<asp:panel id="pnlDomComercial" runat="server">
                  <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0>
                    <TR>
                      <TD width=536 colSpan=4>
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=title width="100%" bgColor=lightgrey 
                            colSpan=3 height=10>&nbsp;&nbsp; 
                          Empresa</TD></TR></TABLE></TD></TR>
                    <TR>
                      <TD class=text width="100%">Razón Social&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator8 runat="server" ControlToValidate="RazonSocial" ErrorMessage="Ingrese la Razón Social ">*</asp:RequiredFieldValidator></TD></TR>
                    <TR>
                      <TD class=text width="100%">
<asp:TextBox id=RazonSocial onKeyPress="return validarString(event);" runat="server" Width="100%" MaxLength="255"></asp:TextBox></TD></TR>
                    <TR>
                      <TD colSpan=4>
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="50%">Nombre de Fantasía</TD>
                            <TD class=text width="10%">Teléfono</TD></TR>
                          <TR>
                            <TD class=text width="50%">
<asp:TextBox id=NombreFantasia runat="server" onKeyPress="return validarString(event);" Width="320px" MaxLength="255"></asp:TextBox></TD>
                            <TD class=text width="10%">
<asp:TextBox id=Telefono runat="server" onKeyPress="return validarString(event);" Width="144px" MaxLength="45"></asp:TextBox></TD></TR></TABLE></TD></TR>
                    <TR>
                      <TD colSpan=4>
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="50%">Rubro</TD>
                            <TD class=text width="10%">Cuit&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator9 runat="server" ControlToValidate="Cuit" ErrorMessage="Ingrese el Cuit">*</asp:RequiredFieldValidator></TD></TR>
                          <TR>
                            <TD class=text width="50%">
<asp:TextBox id=Rubro onKeyPress="return validarString(event);" runat="server" Width="320px" MaxLength="255"></asp:TextBox></TD>
                            <TD class=text width="10%">
<asp:TextBox id=Cuit onKeyPress="return validarString(event);" runat="server" Width="144px" MaxLength="45"></asp:TextBox></TD></TR></TABLE></TD></TR>
                    <TR>
                      <TD colSpan=4>
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="74%">Calle&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator10 runat="server" ControlToValidate="CalleEmpresa" ErrorMessage="Ingrese la Calle">*</asp:RequiredFieldValidator></TD>
                            <TD class=text width="10%">Nro.&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator11 runat="server" ControlToValidate="NroEmpresa" ErrorMessage="Ingrese el Nro.">*</asp:RequiredFieldValidator></TD>
                            <TD class=text width="10%">Dpto.</TD>
                            <TD class=text width="10%">Piso</TD></TR>
                          <TR>
                            <TD class=text width="70%">
<asp:TextBox onKeyPress="return validarString(event);" id=CalleEmpresa runat="server" Width="320px" MaxLength="255"></asp:TextBox></TD>
                            <TD class=text width="10%">
<asp:TextBox onKeyPress="return validarString(event);" id=NroEmpresa runat="server" Width="46px" MaxLength="10"></asp:TextBox></TD>
                            <TD class=text width="10%">
<asp:TextBox onKeyPress="return validarString(event);" id=DptoEmpresa runat="server" Width="46px" MaxLength="10"></asp:TextBox></TD>
                            <TD class=text width="10%">
<asp:TextBox onKeyPress="return validarString(event);" id=PisoEmpresa runat="server" Width="47px" MaxLength="10"></asp:TextBox></TD></TR></TABLE></TD></TR>
                    <TR>
                      <TD colSpan=4>
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="50%">Barrio&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator12 runat="server" ControlToValidate="BarrioEmpresa" ErrorMessage="Ingrese el Barrio">*</asp:RequiredFieldValidator></TD>
                            <TD class=text width="10%">Código Postal&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator15 runat="server" ControlToValidate="CPEmpresa" ErrorMessage="Ingrese el Código Postal">*</asp:RequiredFieldValidator></TD></TR>
                          <TR>
                            <TD class=text width="50%">
<asp:TextBox onKeyPress="return validarString(event);" id=BarrioEmpresa runat="server" Width="320px" MaxLength="255"></asp:TextBox></TD>
                            <TD class=text width="10%">
<asp:TextBox onKeyPress="return validarString(event);" id=CPEmpresa runat="server" Width="144px" MaxLength="45"></asp:TextBox></TD></TR></TABLE></TD></TR>
                    <TR>
                      <TD colSpan=4>
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="50%" height=14>Provincia </TD>
                            <TD class=text width="10%" 
                              height=14>Localidad&nbsp; </TD></TR>
                          <TR>
                            <TD class="text" width="55%">
<asp:dropdownlist id="cmbProvincia" runat="server" Width="250px" AutoPostBack="True" 
                          onselectedindexchanged="cmbProvincia_SelectedIndexChanged_1"></asp:dropdownlist></TD>
                            <TD class="text" width="55%">
<asp:dropdownlist id="cmbLocalidad" runat="server" Width="250px"></asp:dropdownlist></TD></TR></TABLE></TD></TR>
<tr><td colspan="4" class="text">Observaciones</td></tr>
<tr><td colspan="4"><asp:TextBox ID="txtObservaciones" runat="server" MaxLength="255" Width="100%" TextMode="MultiLine" Rows="5" Height="79px" CssClass="Plano"></asp:TextBox>
    </td></tr>

                    <TR>
                      <TD class=text 
                  colSpan=4>&nbsp;&nbsp;</TD></TR></TABLE>
												</asp:panel></TD>
										</TR>
										<TR>
											<td width="536" colSpan="4" height=82>
												<HR>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="text" width="60%">&nbsp;</TD>
														<TD class="text" align="right" width="20%"><asp:button style="Cursor:hand;" id="Aceptar" runat="server" Width="80px" Text="Aceptar" onclick="Aceptar_Click"></asp:button></TD>
														<TD class="text" align="right" width="20%"><asp:button style="Cursor:hand;" id="Cancelar" runat="server" Width="80px" Text="Cancelar" CausesValidation="False" onclick="Cancelar_Click"></asp:button></TD>
													</TR>
												</table>
<asp:ValidationSummary id=ValidationSummary1 runat="server" CssClass="text" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
											</td>
										</TR>
									</table>
								</TD>
							</tr>
						</TABLE>
					</TD>
					<TD width="5%">&nbsp;</TD>
				</tr>
			</TABLE>
		</FORM>
	</body>
</HTML>
