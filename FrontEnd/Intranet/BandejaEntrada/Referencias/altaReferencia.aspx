<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada.Referencia.altaReferencia" CodeFile="altaReferencia.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="menu" Src="../../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Alta de Informe</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
		<script>
		function Archivo()
		{
			if (chkFile.checked) 
			{
				txtArchivo.style.display = "list-item";
			} else {
				txtArchivo.style.display = "none";
			
			}
		}
		function deshabilitarBotones(elemento)
		{
		    if (typeof(Page_ClientValidate) == 'function')
                if (Page_ClientValidate())
                {
                    elemento.disabled = true;
                    __doPostBack(elemento.name,'');
                }

		}	
		
		
        function setearReferencia(campo)
        {
            if (campo.value != "" && document.getElementById("txtDescripcion").value == "")
            {
                var fecha=new Date();
                var dia=fecha.getDate();
                var mes=fecha.getMonth() +1 ;
                document.getElementById("txtDescripcion").value = campo.value + " " + dia + "/" +mes;
                }
        }

		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form2" method="post" runat="server">
			<uc1:menu id="Menu1" runat="server"></uc1:menu>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%" colSpan="2"><BR>
						Alta de grupo de informes<BR>
						<HR>
					</td>
				</tr>
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%">
						<table cellSpacing="0" cellPadding="0" width="480" border="0">
							
							<TR>
								<TD class="text" colSpan="4" height="10"></TD>
							</TR>
							<tr>
                                <td class="text" width="535" colspan="4">
                                    Cliente&nbsp;
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="NotEqual" ValueToCompare="Seleccione un Cliente"
                                        ControlToValidate="cmbClientes" ErrorMessage="Seleccione un cliente">*</asp:CompareValidator></td>
                            </tr>
                            <tr>
                                <td class="text" width="535" colspan="4" style="height: 8px">
                                    <asp:DropDownList ID="cmbClientes" runat="server" AutoPostBack="True" Width="479px"
                                        OnSelectedIndexChanged="cmbClientes_SelectedIndexChanged">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td class="text" width="535" colspan="4">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td class="text" width="50%">
                                                Usuario</td>
                                            <td class="text" width="50%">
                                                Persona&nbsp;
                                                <asp:RequiredFieldValidator ID="valPersona" runat="server" ControlToValidate="txtPersona"
                                                    ErrorMessage="Ingrese persona">*</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td class="text" width="50%" height="8">
                                                <asp:DropDownList ID="cmbUsuarios" runat="server" AutoPostBack="True" Width="100%"
                                                    OnSelectedIndexChanged="cmbUsuarios_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                            <td class="text" width="50%" height="8">
                                                <asp:TextBox ID="txtPersona" runat="server" Style="text-transform: uppercase;" 
                                                    Width="100%" onprerender="txtPersona_PreRender"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
							<TR>
								<TD class="text" width="60%" colSpan="4">Descripción&nbsp;
									<asp:requiredfieldvalidator id="reqNombre" runat="server" ErrorMessage="*" ControlToValidate="txtDescripcion"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD class="text" width="100%" colSpan="4"><asp:textbox id="txtDescripcion" runat="server" Width="100%" Style="text-transform: uppercase;"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="text" width="282" colSpan="4">Observaciones&nbsp;</TD>
							</TR>
							<TR>
								<TD class="text" width="100%" colSpan="2"><asp:textbox id="txtObservaciones" runat="server" Width="100%" CssClass="Plano" TextMode="MultiLine"
										Height="80px" Style="text-transform: uppercase;"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="text" width="282" colSpan="4">&nbsp;</TD>
							</TR>
							<TR>
								<TD class="text" width="30%">&nbsp;
									<asp:checkbox id="chkFile" runat="server" AutoPostBack="True" Text=" Subir Archivo"></asp:checkbox></TD>
								<TD class="text" vAlign="middle" width="70%"><INPUT class="plano" id="txtArchivo" title="Buscar" style="WIDTH: 270pt" type="file" name="txtArchivo" runat="server">&nbsp;
									<asp:Label id="lblFile" runat="server">Label</asp:Label></TD>
							</TR>
						</table>
					</td>
				</tr>
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%">
				<TR>
					<td colSpan="2"><asp:panel id="pnlInformes" runat="server">
					    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="title" width="100%">Informes<BR>
									<HR>
								</TD>
							</TR>
							<TR>
								<TD class="text" width="100%">
									<asp:datagrid id="dgridEncabezados" runat="server" Width="100%" Font-Size="8pt" PageSize="20"
										CellPadding="3" BorderColor="#3657A6" BorderStyle="Solid" BorderWidth="1px" BackColor="White"
										GridLines="Vertical" AutoGenerateColumns="False">
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="idEncabezado" HeaderText="C&#243;digo">
												<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FechaCarga" HeaderText="Fecha"></asp:BoundColumn>
											<asp:BoundColumn DataField="Descripcion" HeaderText="Tipo Informe">
												<HeaderStyle Width="80px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DescripcionInf" HeaderText="Descripci&#243;n">
												<HeaderStyle Width="120px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Comentarios" HeaderText="Observaciones">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="NombreEstado" HeaderText="Estado">
												<HeaderStyle Width="15px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Estado"></asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Editar" runat="server" Width="16px" ImageUrl="/img/modificar_general.gif" CommandName="Editar"
														ToolTip="Editar"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Cancelar" runat="server" Width="16px" ToolTip="Cancelar Informe" CommandName="Cancelar"
														ImageUrl="\Img\Cruz.gif"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="Estado"></asp:BoundColumn>
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999"></PagerStyle>
									</asp:datagrid>&nbsp;
								</TD>
							</TR>
							<TR>
								<TD align="right" width="100%">
									<asp:button id="btnInforme" runat="server" Width="155px" Text="Nuevo Informe"></asp:button></TD>
							</TR>
						</TABLE>
						</asp:panel></td>
				</TR>
				<TR>
					<td colSpan="4"><BR>
						<HR>
					</td>
				</TR>
				<TR>
					<td colSpan="4" align="center">
						<table cellSpacing="0" cellPadding="0" border="0">
							<TR>
								<TD class="text"><input type="button" onclick="javascript:location='ListaReferencias.aspx';" value="Cancelar">&nbsp; <asp:button id="Aceptar" runat="server" Width="80px" Text="Aceptar" CausesValidation="False"></asp:button></TD>
							</TR>
						</table>
					</td>
				</TR>
			</table>
		</form>
	</body>
</HTML>
