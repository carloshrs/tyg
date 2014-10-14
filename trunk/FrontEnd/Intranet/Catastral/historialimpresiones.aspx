<%@ Page language="c#" Inherits="ar.com.TiempoyGestion.FrontEnd.Intranet.Catastral.historialimpresiones" CodeFile="historialimpresiones.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="menu" Src="../Inc/menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD id="HEAD1" runat="server">
		<title>Bandeja de Entrada</title>
		<LINK href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
			<style>
		    .itemMenu 
		    {
		        background-color: #D3D3D3;
		        text-align: center;
		        color: #3557A1;
		        font-family: Arial, Verdana, Helvetica, Sans-Serif; 
		        font-size:10pt;
		        font-weight: bold;
		        width: 160px;
		    }
		    .itemMenuSelected
		    {
		        background-color: #FFFFFF;
		        font-style: italic;
		    }
		    .itemMenuHover
		    {
		        background-color: #EAEAEA;
		    }
		</style>
</HEAD>
	<body leftMargin="0" topMargin="0"> <!--  onload="javascript:mostrarFiltro(true, '');"-->
		<uc1:menu id="Menu1" runat="server"></uc1:menu>
		<FORM id="Tipos" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD width="2%">&nbsp;</TD>
					<td class="title" width="100%">
                        Historial de Informes enviados al
                        Registro&nbsp;de la Propiedad
						<BR>
						<HR>
						<BR>
                        <asp:Repeater ID="rpHistorial" runat="server">
                         <ItemTemplate>
                         <div style="margin:16px;"><div style="float:left;"><img src="/Img/left.jpg" width="14" height="14" border="0" /></div>
                             <div style="width:700px; margin-top:5px;"><a href="impresionenproceso.aspx?estado=-1&idGrupo=<%#Eval("id")%>" class="link">
                               <%#Eval("fecha")%> generado por <%#Eval("nombre")%> <%#Eval("apellido")%> (total <%#Eval("total")%>)
                              </a></div>
                              </div>
                         </ItemTemplate>
                        </asp:Repeater>
					</td>
				</tr>
				<tr>
					<TD width="2%">&nbsp;</TD>
					<TD class="text" width="93%" colSpan="4" align="center">
                            
                            
                         
                           <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="8"
                                        Visible="False" style="margin-top:25px;"></asp:Label>

                        &nbsp;&nbsp;<br /><br />
                        <input type="button" value="Volver" onclick="history.back();" />
                        
                        
                        
                    </TD>
					<TD width="5%">&nbsp;</TD>
				</tr>
			</TABLE>
		</FORM>
		<DIV id="divDateControl" style="Z-INDEX: 102; LEFT: -35px; VISIBILITY: hidden; POSITION: absolute; TOP: -150px"><IFRAME name="popFrame" src="../inc/calendar/calendar.htm" frameBorder="0" width="160" scrolling="no"
				height="160"></IFRAME></DIV>
	</body>
</HTML>
