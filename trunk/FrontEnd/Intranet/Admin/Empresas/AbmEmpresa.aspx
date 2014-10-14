<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Contratos.AbmEmpresa" CodeFile="AbmEmpresa.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="menu" Src="../../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Alta Personas</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
		<script src="/Includes/Funciones.js" type="text/javascript"></script>
</HEAD>
	<body leftMargin="0" topMargin="0">
		<uc1:menu id="Menu1" runat="server"></uc1:menu>
		<FORM id="Tipos" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%">Edición&nbsp;de Empresas<BR>
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
<asp:RequiredFieldValidator id=RequiredFieldValidator8 runat="server" ErrorMessage="Ingrese la Razón Social" ControlToValidate="RazonSocial">*</asp:RequiredFieldValidator></TD></TR>
                    <TR>
                      <TD class=text width="100%">
<asp:TextBox onkeypress="return validarString(event);" id=RazonSocial runat="server" Width="100%" MaxLength="255"></asp:TextBox></TD></TR>
                    <TR>
                      <TD colSpan=4>
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="50%">Nombre de Fantasía</TD>
                            <TD class=text width="10%">Teléfono</TD></TR>
                          <TR>
                            <TD class=text width="50%">
<asp:TextBox onkeypress="return validarString(event);" id=NombreFantasia runat="server" Width="320px" MaxLength="255"></asp:TextBox></TD>
                            <TD class=text width="10%">
<asp:TextBox onkeypress="return validarString(event);" id=Telefono runat="server" Width="144px" MaxLength="45"></asp:TextBox></TD></TR></TABLE></TD></TR>
                    <TR>
                      <TD colSpan=4>
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="50%">Rubro</TD>
                            <TD class=text width="10%">Cuit&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator9 runat="server" ErrorMessage="Ingrese el Cuit" ControlToValidate="Cuit">*</asp:RequiredFieldValidator></TD></TR>
                          <TR>
                            <TD class=text width="50%">
<asp:TextBox onkeypress="return validarString(event);" id=Rubro runat="server" Width="320px" MaxLength="255"></asp:TextBox></TD>
                            <TD class=text width="10%">
<asp:TextBox onkeypress="return validarString(event);" id=Cuit runat="server" Width="144px" MaxLength="45"></asp:TextBox></TD></TR></TABLE></TD></TR>
                    <TR>
                      <TD colSpan=4>
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="70%">Calle&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator10 runat="server" ErrorMessage="Ingrese la Calle" ControlToValidate="CalleEmpresa">*</asp:RequiredFieldValidator></TD>
                            <TD class=text width="10%">Nro.&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator11 runat="server" ErrorMessage="Ingrese el Nro." ControlToValidate="NroEmpresa">*</asp:RequiredFieldValidator></TD>
                            <TD class=text width="10%">Dpto.</TD>
                            <TD class=text width="10%">Piso</TD></TR>
                          <TR>
                            <TD class=text width="74%">
<asp:TextBox onkeypress="return validarString(event);" id=CalleEmpresa runat="server" Width="320px" MaxLength="255"></asp:TextBox></TD>
                            <TD class=text width="10%">
<asp:TextBox onkeypress="return validarString(event);" id=NroEmpresa runat="server" Width="46px" MaxLength="10"></asp:TextBox></TD>
                            <TD class=text width="10%">
<asp:TextBox onkeypress="return validarString(event);" id=DptoEmpresa runat="server" Width="46px" MaxLength="10"></asp:TextBox></TD>
                            <TD class=text width="10%">
<asp:TextBox onkeypress="return validarString(event);" id=PisoEmpresa runat="server" Width="47px" MaxLength="10"></asp:TextBox></TD></TR></TABLE></TD></TR>
                    <TR>
                      <TD colSpan=4>
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="50%">Barrio&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator12 runat="server" ErrorMessage="Ingrese el Barrio" ControlToValidate="BarrioEmpresa">*</asp:RequiredFieldValidator></TD>
                            <TD class=text width="10%">Código Postal&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator15 runat="server" ErrorMessage="Ingrese el Código Postal" ControlToValidate="CPEmpresa">*</asp:RequiredFieldValidator></TD></TR>
                          <TR>
                            <TD class=text width="50%">
<asp:TextBox onkeypress="return validarString(event);" id=BarrioEmpresa runat="server" Width="320px" MaxLength="255"></asp:TextBox></TD>
                            <TD class=text width="10%">
<asp:TextBox onkeypress="return validarString(event);" id=CPEmpresa runat="server" Width="144px" MaxLength="45"></asp:TextBox></TD></TR></TABLE></TD></TR>
                    <TR>
                      <TD colSpan=4>
                        <TABLE cellSpacing=0 cellPadding=0 width="100%" 
border=0>
                          <TR>
                            <TD class=text width="55%" height=14>Provincia </TD>
                            <TD class=text width="45%" 
                              height=14>Localidad&nbsp; </TD></TR>
                          <TR>
                            <TD class=text width="55%">
<asp:dropdownlist id=cmbProvincia runat="server" Width="250px" AutoPostBack="True" onselectedindexchanged="cmbProvincia_SelectedIndexChanged_1"></asp:dropdownlist></TD>
                            <TD class=text width="55%">
<asp:dropdownlist id=cmbLocalidad runat="server" Width="250px"></asp:dropdownlist></TD></TR></TABLE></TD></TR>
<tr><td colspan="4" class="text">Observaciones</td></tr>
<tr><td colspan="4"><asp:TextBox ID="txtObservaciones" runat="server" MaxLength="255" Width="100%" TextMode="MultiLine" Rows="5" Height="79px" CssClass="Plano"></asp:TextBox>
    </td></tr>
                    <TR>
                      <TD class=text 
                  colSpan=4>&nbsp;&nbsp;</TD></TR></TABLE>
												</asp:panel></TD>
										</TR>
										<TR>
											<td width="536" colSpan="4">
												<HR>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="text" width="60%">&nbsp;</TD>
														<TD class="text" align="right" width="20%"><asp:button id="Aceptar" style="CURSOR:hand" runat="server" Width="80px" Text="Aceptar" onclick="Aceptar_Click"></asp:button></TD>
														<TD class="text" align="right" width="20%"><input id="Cancelar" style="CURSOR:hand" onclick="javascript:window.location.href='ListaEmpresas.aspx';" type="button"
																size="20" value="  Cancelar  "></TD>
													</TR>
												</table>
												<asp:ValidationSummary id="ValidationSummary1" runat="server" CssClass="text"></asp:ValidationSummary>
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
