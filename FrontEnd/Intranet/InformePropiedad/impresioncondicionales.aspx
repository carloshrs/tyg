<%@ Page Language="C#" AutoEventWireup="true" CodeFile="impresioncondicionales.aspx.cs" Inherits="InformePropiedad_listadocondicionales" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <link href="../CSS/Estilos.css" rel="stylesheet" type="text/css" />
</head>

<script type="text/javascript">
function imprimir() {
    document.getElementById("divBotones").style.display = 'none';
    window.print();
    document.getElementById("divBotones").style.display = 'block';
}
</script>



<body onload="imprimir();">
    <form id="form1" runat="server">
    <div>
        <div style="float:right;"><asp:Label ID="lblFechaActual" runat="server" Font-Bold="True" Text="06/01/2011"></asp:Label></div>
        <div style="width:100%; float:left; margin-bottom:20px; font-weight:bold; text-align:center; font-size:16px;">LISTADO DE INFORMES DE PROPIEDAD CONDICIONALES</div>
        <asp:Panel ID="pnEnSeguimiento" runat="server">
        <asp:Label ID="lblSeguimiento" runat="server" Text="Condicionales en seguimiento" Font-Size="18px" Font-Bold="true"></asp:Label>
        
        <asp:Panel ID="pnSUrgenteSeg" runat="server" style="width:100%; float:left; margin:0px; padding:0px;">
        <div style="width:100%; float:left; border-bottom: solid 3px #000000; margin-bottom:10px;">
        <asp:Label ID="lblSUrgenteSeg" runat="server" Text="Super urgente" Font-Size="16px" Font-Bold="true"></asp:Label>
        <asp:DataList ID="dlSUrgenteSeg" runat="server" ShowFooter="False" 
            ShowHeader="False" style="float:left; width:100%;" RepeatColumns="2">
            <ItemTemplate>
                <div style="width:50%; float:left;">
                    Cliente:
                    <asp:Label ID="lblCliente" runat="server" Text='<%# Eval("Cliente")%>' Font-Bold="true"></asp:Label> - <asp:Label ID="lblUsuario" runat="server" Text='<%# Eval("UsuarioCliente")%>' Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblRow" runat="server" Text='<%# Eval("row_no") %>' Visible="false"></asp:Label>
                </div>
                <div style="width:50%; float:left;">
                    Fecha solicitud:
                    <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaCarga", "{0:d}") %>'></asp:Label>
                </div>
                <div style="width:100%; float:left;">
                    Descripción:
                    <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("DescripcionInf")%>' Font-Bold="true" Font-Size="Small"></asp:Label>
                </div>
                <div style="width:100%; float:left; border-bottom:#000000 1px solid; padding-bottom:36px;">
                    Tipo envío: <%# Eval("TipoEnvio")%> <br /><br />
                    Observaciones:
                    <asp:Label ID="lblObservaciones" runat="server" Text='<%# Eval("comentarios")%>'></asp:Label>
                </div>
            </ItemTemplate>
        </asp:DataList>
        </div>
        </asp:Panel>
        
        <asp:Panel ID="pnUrgenteSeg" runat="server" style="width:100%; float:left; margin:0px; padding:0px;">
        <div style="width:100%; float:left; border-bottom: solid 3px #000000; margin-bottom:10px;">
        <asp:Label ID="lblUrgenteSeg" runat="server" Text="Urgente" Font-Size="16px" Font-Bold="true"></asp:Label>
        <asp:DataList ID="dlUrgenteSeg" runat="server" ShowFooter="False" ShowHeader="False"  style="float:left; width:100%;" RepeatColumns="2">
            <ItemTemplate>
                    <div style="width:50%; float:left;">
                    Cliente:
                    <asp:Label ID="lblCliente" runat="server" Text='<%# Eval("Cliente")%>' Font-Bold="true"></asp:Label> - <asp:Label ID="lblUsuario" runat="server" Text='<%# Eval("UsuarioCliente")%>' Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblRow" runat="server" Text='<%# Eval("row_no") %>' Visible="false"></asp:Label>
                </div>
                <div style="width:50%; float:left;">
                    Fecha solicitud:
                    <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaCarga", "{0:d}") %>'></asp:Label>
                </div>
                <div style="width:100%; float:left;">
                    Descripción:
                    <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("DescripcionInf")%>' Font-Bold="true" Font-Size="Small"></asp:Label>
                </div>
                <div style="width:100%; float:left; border-bottom:#000000 1px solid; padding-bottom:35px;">
                    Tipo envío: <%# Eval("TipoEnvio")%> <br /><br />
                    Observaciones:
                    <asp:Label ID="lblObservaciones" runat="server" Text='<%# Eval("comentarios")%>'></asp:Label>
                </div>
            </ItemTemplate>
        </asp:DataList>
        </div>
        </asp:Panel>
        
        <asp:Panel ID="pnNormalSeg" runat="server" style="width:100%; float:left; margin:0px; padding:0px;">
        <div style="width:100%; float:left; margin-bottom:10px;">
        <asp:Label ID="lblNormalSeg" runat="server" Text="Normal" Font-Size="16px" Font-Bold="true"></asp:Label>
        <asp:DataList ID="dlNormalSeg" runat="server" ShowFooter="False" ShowHeader="False"  style="float:left; width:100%;" RepeatColumns="2">
            <ItemTemplate>
                <div style="width:50%; float:left;">
                    Cliente:
                    <asp:Label ID="lblCliente" runat="server" Text='<%# Eval("Cliente")%>' Font-Bold="true"></asp:Label> - <asp:Label ID="lblUsuario" runat="server" Text='<%# Eval("UsuarioCliente")%>' Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblRow" runat="server" Text='<%# Eval("row_no") %>' Visible="false"></asp:Label>
                </div>
                <div style="width:50%; float:left;">
                    Fecha solicitud:
                    <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaCarga", "{0:d}") %>'></asp:Label>
                </div>
                <div style="width:100%; float:left;">
                    Descripción:
                    <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("DescripcionInf")%>' Font-Bold="true" Font-Size="Small"></asp:Label>
                </div>
                <div style="width:100%; float:left; border-bottom:#000000 1px solid; padding-bottom:35px;">
                    Tipo envío: <%# Eval("TipoEnvio")%> <br /><br />
                    Observaciones:
                    <asp:Label ID="lblObservaciones" runat="server" Text='<%# Eval("comentarios")%>'></asp:Label>
                </div>
            </ItemTemplate>
        </asp:DataList>
        </div>
        </asp:Panel>
        
        </asp:Panel>

        <asp:Panel ID="pnPendiente" runat="server">
        <asp:Label ID="lblPendientes" runat="server" Text="Condicionales pendientes de confirmación" Font-Size="18px" Font-Bold="true"></asp:Label>
        
        <asp:Panel ID="pnSUrgentePen" runat="server" style="width:100%; float:left; margin:0px; padding:0px;">
        <div style="width:100%; float:left; border-bottom: solid 3px #000000; margin-bottom:10px;">
        <asp:Label ID="lblSUrgentePen" runat="server" Text="Super urgente" Font-Size="16px" Font-Bold="true"></asp:Label>
        <asp:DataList ID="dlSUrgentePen" runat="server" ShowFooter="False" 
            ShowHeader="False" style="float:left; width:100%;" RepeatColumns="2">
            <ItemTemplate>
                <div style="width:50%; float:left;">
                    Cliente:
                    <asp:Label ID="lblCliente" runat="server" Text='<%# Eval("Cliente")%>' Font-Bold="true"></asp:Label> - <asp:Label ID="lblUsuario" runat="server" Text='<%# Eval("UsuarioCliente")%>' Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblRow" runat="server" Text='<%# Eval("row_no") %>' Visible="false"></asp:Label>
                </div>
                <div style="width:50%; float:left;">
                    Fecha solicitud:
                    <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaCarga", "{0:d}") %>'></asp:Label>
                </div>
                <div style="width:100%; float:left;">
                    Descripción:
                    <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("DescripcionInf")%>' Font-Bold="true" Font-Size="Small"></asp:Label>
                </div>
                <div style="width:100%; float:left; border-bottom:#000000 1px solid; padding-bottom:36px;">
                    Tipo envío: <%# Eval("TipoEnvio")%> <br /><br />
                    Observaciones:
                    <asp:Label ID="lblObservaciones" runat="server" Text='<%# Eval("comentarios")%>'></asp:Label>
                </div>
            </ItemTemplate>
        </asp:DataList>
        </div>
        </asp:Panel>
        
        <asp:Panel ID="pnUrgentePen" runat="server" style="width:100%; float:left; margin:0px; padding:0px;">
        <div style="width:100%; float:left; border-bottom: solid 3px #000000; margin-bottom:10px;">
        <asp:Label ID="lblUrgentePen" runat="server" Text="Urgente" Font-Size="16px" Font-Bold="true"></asp:Label>
        <asp:DataList ID="dlUrgentePen" runat="server" ShowFooter="False" ShowHeader="False"  style="float:left; width:100%;" RepeatColumns="2">
            <ItemTemplate>
                    <div style="width:50%; float:left;">
                    Cliente:
                    <asp:Label ID="lblCliente" runat="server" Text='<%# Eval("Cliente")%>' Font-Bold="true"></asp:Label> - <asp:Label ID="lblUsuario" runat="server" Text='<%# Eval("UsuarioCliente")%>' Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblRow" runat="server" Text='<%# Eval("row_no") %>' Visible="false"></asp:Label>
                </div>
                <div style="width:50%; float:left;">
                    Fecha solicitud:
                    <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaCarga", "{0:d}") %>'></asp:Label>
                </div>
                <div style="width:100%; float:left;">
                    Descripción:
                    <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("DescripcionInf")%>' Font-Bold="true" Font-Size="Small"></asp:Label>
                </div>
                <div style="width:100%; float:left; border-bottom:#000000 1px solid; padding-bottom:35px;">
                    Tipo envío: <%# Eval("TipoEnvio")%> <br /><br />
                    Observaciones:
                    <asp:Label ID="lblObservaciones" runat="server" Text='<%# Eval("comentarios")%>'></asp:Label>
                </div>
            </ItemTemplate>
        </asp:DataList>
        </div>
        </asp:Panel>
        
        <asp:Panel ID="pnNormalPen" runat="server" style="width:100%; float:left; margin:0px; padding:0px;">
        <div style="width:100%; float:left; margin-bottom:10px;">
        <asp:Label ID="lblNormalPen" runat="server" Text="Normal" Font-Size="16px" Font-Bold="true"></asp:Label>
        <asp:DataList ID="dlNormalPen" runat="server" ShowFooter="False" ShowHeader="False"  style="float:left; width:100%;" RepeatColumns="2">
            <ItemTemplate>
                <div style="width:50%; float:left;">
                    Cliente:
                    <asp:Label ID="lblCliente" runat="server" Text='<%# Eval("Cliente")%>' Font-Bold="true"></asp:Label> - <asp:Label ID="lblUsuario" runat="server" Text='<%# Eval("UsuarioCliente")%>' Font-Bold="true"></asp:Label>
                    <asp:Label ID="lblRow" runat="server" Text='<%# Eval("row_no") %>' Visible="false"></asp:Label>
                </div>
                <div style="width:50%; float:left;">
                    Fecha solicitud:
                    <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaCarga", "{0:d}") %>'></asp:Label>
                </div>
                <div style="width:100%; float:left;">
                    Descripción:
                    <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("DescripcionInf")%>' Font-Bold="true" Font-Size="Small"></asp:Label>
                </div>
                <div style="width:100%; float:left; border-bottom:#000000 1px solid; padding-bottom:35px;">
                    Tipo envío: <%# Eval("TipoEnvio")%> <br /><br />
                    Observaciones:
                    <asp:Label ID="lblObservaciones" runat="server" Text='<%# Eval("comentarios")%>'></asp:Label>
                </div>
            </ItemTemplate>
        </asp:DataList>
        </div>
        </asp:Panel>
        
        </asp:Panel>
        <div id="divBotones" style="text-align:right;"><input id="Button1" type="button" value="Imprimir" onclick="imprimir();" /> 
            <asp:Button 
                ID="Button2" runat="server"
                Text="Aceptar" onclick="Button2_Click" /></div>
        
    </div>
    </form>
</body>
</html>
