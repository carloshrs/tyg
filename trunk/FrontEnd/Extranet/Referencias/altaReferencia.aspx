<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Extranet.Informes.altaReferencia" CodeFile="altaReferencia.aspx.cs" %>
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
			</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%" colSpan="2">Alta de Grupo de informes<BR>
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
							<TR>
								<TD class="text" width="60%" colSpan="4">Nombre del Grupo de Informes&nbsp;
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
										Height="80px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="text" width="282" colSpan="4">&nbsp;</TD>
							</TR>
							<TR>
								<TD class="text" width="30%">&nbsp;
									<asp:checkbox id="chkFile" runat="server" AutoPostBack="True" Text=" Subir Archivo" oncheckedchanged="chkFile_CheckedChanged"></asp:checkbox></TD>
								<TD class="text" vAlign="middle" width="70%"><INPUT class="plano" id="txtArchivo" title="Buscar" style="WIDTH: 270pt" type="file" name="txtArchivo"
										runat="server">&nbsp;
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
									<TD class="title" width="100%" colSpan="2">Informes<BR>
										<HR>
									</TD>
								</TR>
								<TR>
									<TD class="text" width="100%">
										<asp:datagrid id="dgridEncabezados" runat="server" Width="100%" Font-Size="8pt" PageSize="20"
											CellPadding="3" BorderColor="#3657A6" BorderStyle="None" BorderWidth="1px" BackColor="White"
											GridLines="Vertical" AutoGenerateColumns="False" onprerender="dgridEncabezados_PreRender">
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
										<asp:button id="btnInforme" runat="server" Width="155px" Text="Nuevo Informe" onclick="btnInforme_Click"></asp:button></TD>
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
					<td colSpan="4">
						<table cellSpacing="0" cellPadding="0" width="480" border="0">
							<TR>
								<TD class="text" width="60%" style="height: 24px">&nbsp;</TD>
								<TD class="text" align="right" width="20%" style="height: 24px"><input type="button" onclick="javascript:location='ListaReferencias.aspx';" value="Cancelar"></TD>
								<TD class="text" align="right" width="20%" style="height: 24px"><asp:button id="Aceptar" runat="server" Width="80px" Text="Aceptar" onclick="Aceptar_Click" CausesValidation="False"></asp:button></TD>
							</TR>
						</table>
					</td>
				</TR>
			</table>
		</form>
	</body>
</HTML>
