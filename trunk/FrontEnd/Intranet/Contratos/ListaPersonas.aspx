<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Contratos.ListaPersonas" CodeFile="ListaPersonas.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="menu" Src="../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Alta de Informe</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
			<script>
			function ToggleImg(name, src, alt)
			{
				name.src = "/img/" + src;
				name.alt = alt
			}

			function mostrarFiltro(First, name)
			{
				if (masInfo.style.display == "none") 
				{
					masInfo.style.display = "list-item";
					ToggleImg(name, 'Cerrar.gif', 'Cerrar Más Info');
				} 
				else 
				{
					masInfo.style.display = "none";
					ToggleImg(name, 'Arrow.gif', 'Más Info');
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
	<body leftMargin="0" topMargin="0">
		<uc1:menu id="Menu1" runat="server"></uc1:menu>
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="text" vAlign="top"><img src="/img/shim.gif" width="5" height="1"></td>
					<td class="title" width="100%">Alta de Contrato<BR>
						<HR>
						<BR>
					</td>
				</tr>
				<tr>
					<td class="text" vAlign="top"><img src="/img/shim.gif" width="5" height="1"></td>
					<td width="100%">
						<table cellSpacing="0" cellPadding="0" width="528" border="0">
							<TR>
								<TD class="text" width="100%">
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="title" width="535" bgColor="lightgrey" colSpan="4" height="10">&nbsp;&nbsp;Datos 
												Contrato</TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4" height="5"></TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4" height="15">Tipo Contrato:
												<asp:Label id="txtTipoContrato" runat="server" Font-Bold="True"></asp:Label></TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4"></TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4" height="15">Número Contrato:&nbsp;
												<asp:Label id="txtNumero" runat="server" Font-Bold="True"></asp:Label></TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4"></TD>
										</TR>
										<TR>
											<TD class="text" width="150">Fecha Inicio:
												<asp:Label id="txtFechaInicio" runat="server" Font-Bold="True"></asp:Label></TD>
											<TD class="text" width="150">Fecha Fin:
												<asp:Label id="txtFechaFin" runat="server" Font-Bold="True"></asp:Label></TD>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4"></TD>
										</TR>
										<TR>
											<td class="text" width="535" colSpan="4">Descripción:&nbsp;&nbsp;
												<asp:Label id="txtDescripcion" runat="server" Font-Bold="True"></asp:Label></td>
										</TR>
										<TR>
											<TD class="text" width="535" colSpan="4" height="20"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<td width="535" colSpan="4">
									<asp:datagrid id="dgridContratos" runat="server" Width="560px" Font-Size="8pt" PageSize="20" CellPadding="3"
										BorderColor="#3657A6" BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="dgridContratos_PreRender">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#FBFBFB"></AlternatingItemStyle>
										<ItemStyle Font-Size="8pt" Font-Names="Arial" ForeColor="Black" BackColor="#F3F3F3"></ItemStyle>
										<HeaderStyle Font-Names="Arial" Font-Bold="True" ForeColor="#3756A6" BackColor="#DFE7F4"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="idPersona" HeaderText="C&#243;digo">
												<HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Tipo" HeaderText="Tipo">
												<HeaderStyle Width="80px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Actor"></asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="Nombre" HeaderText="Nombre">
												<HeaderStyle Width="200px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Apellido" HeaderText="Apellido">
												<HeaderStyle Width="200px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Cuit" HeaderText="Cuit"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="RazonSocial" HeaderText="RazonSocial"></asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="10px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Editar" runat="server" Width="16px" ToolTip="Editar" CommandName="Editar" ImageUrl="/img/modificar_general.gif"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="10px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Cancelar" runat="server" Width="16px" ToolTip="Eliminar" CommandName="Cancelar"
														ImageUrl="\Img\Cruz.gif"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="10px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:ImageButton id="Ver" runat="server" Width="16px" ToolTip="Visualizar Persona" CommandName="Ver"
														ImageUrl="\Img\Lupita.gif"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="idTipoPersona" HeaderText="idTipoPersona"></asp:BoundColumn>
										</Columns>
										<PagerStyle NextPageText="Siguiente" PrevPageText="Anterior" HorizontalAlign="Center" ForeColor="Black"
											BackColor="#999999"></PagerStyle>
									</asp:datagrid>
								</td>
							</TR>
							<TR>
								<TD class="text" width="535" colSpan="4" height="5"></TD>
							</TR>
							<tr>
								<td align="right"><asp:button id="btnPersonas" runat="server" Width="155px" Text="Nueva Persona" onclick="btnPersonas_Click"></asp:button></td>
							</tr>
							<TR>
								<TD class="text" width="620" colSpan="5" height="20"><BR>
									<HR>
								</TD>
							</TR>
							<TR>
								<td width="536" colSpan="4">
									<table cellSpacing="0" cellPadding="0" width="560" border="0" height="19">
										<TR>
											<TD class="text" width="60%" style="height: 24px">&nbsp;</TD>
											<TD class="text" align="right" width="20%" style="height: 24px"></TD>
											<TD class="text" align="right" width="20%" style="height: 24px">
												<asp:button id="Aceptar" runat="server" Width="80px" Text="Finalizar" onclick="Aceptar_Click" CausesValidation="False"></asp:button></TD>
										</TR>
									</table>
								</td>
							</TR>
						</table>
					</td>
				</tr>
			</TABLE>
		</form>
		<DIV id="divDateControl" style="Z-INDEX: 102; LEFT: -35px; VISIBILITY: hidden; POSITION: absolute; TOP: -150px"><IFRAME name="popFrame" src="../inc/calendar/calendar.htm" frameBorder="0" width="160" scrolling="no"
				height="160"></IFRAME></DIV>
	</body>
</HTML>
