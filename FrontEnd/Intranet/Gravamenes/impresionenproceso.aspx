<%@ Page Language="C#" AutoEventWireup="true" CodeFile="impresionenproceso.aspx.cs" Inherits="InformeGravamenes_listadopendientes" %>

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
        <div style="width:100%; float:left; margin-bottom:20px; font-weight:bold; text-align:center; font-size:16px;">LISTADO DE INFORMES DE GRAVÁMENES - FORMULARIO TAZA</div>
        <div style="width:100%; float:left; border-bottom: solid 3px #000000; margin-bottom:10px;">
        <asp:Label ID="lblSUrgente" runat="server" Text="Super urgente" Font-Size="16px" Font-Bold="true"></asp:Label>
        <asp:DataList ID="dlSUrgente" runat="server" ShowFooter="False" 
            ShowHeader="False"  style="float:left; width:100%;" RepeatColumns="2">
            <ItemTemplate>
                <asp:Panel ID="pnSUrgente" runat="server" 
    style="width:100%; float:left; margin:0px; padding:0px;">
                        <div style="width:100%; float:left;">
                        Cliente:
                        <asp:Label ID="lblCliente" runat="server" Text='<%# Eval("Cliente")%>' Font-Bold="true"></asp:Label>
                    </div>
                    <div style="width:100%; float:left;">
                        Descripción:
                        <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("DescripcionInf")%>' Font-Bold="true"></asp:Label>
                    </div>
                    <div style="width:100%; float:left; border-bottom:#000000 1px solid; padding-bottom:35px;">
                        Observaciones:
                        <asp:Label ID="lblObservaciones" runat="server" Text='<%# Eval("comentarios")%>'></asp:Label>
                    </div>
                </asp:Panel>
            </ItemTemplate>
        </asp:DataList>
        </div>        
        <div style="width:100%; float:left; border-bottom: solid 3px #000000; margin-bottom:10px;">
        <asp:Label ID="lblUrgente" runat="server" Text="Urgente" Font-Size="16px" Font-Bold="true"></asp:Label>
        <asp:DataList ID="dlUrgente" runat="server" ShowFooter="False" 
            ShowHeader="False"  style="float:left; width:100%;" RepeatColumns="2">
            <ItemTemplate>
                <asp:Panel ID="pnUrgente" runat="server" 
    style="width:100%; float:left; margin:0px; padding:0px;">
                        <div style="width:100%; float:left;">
                        Cliente:
                        <asp:Label ID="lblCliente" runat="server" Text='<%# Eval("Cliente")%>' Font-Bold="true"></asp:Label>
                    </div>
                    <div style="width:100%; float:left;">
                        Descripción:
                        <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("DescripcionInf")%>' Font-Bold="true"></asp:Label>
                    </div>
                    <div style="width:100%; float:left; border-bottom:#000000 1px solid; padding-bottom:35px;">
                        Observaciones:
                        <asp:Label ID="lblObservaciones" runat="server" Text='<%# Eval("comentarios")%>'></asp:Label>
                    </div>
                </asp:Panel>
            </ItemTemplate>
        </asp:DataList>
        </div>
        <div style="width:100%; float:left; margin-bottom:10px;">
        <asp:Label ID="lblNormal" runat="server" Text="Normal" Font-Size="16px" Font-Bold="true"></asp:Label>
        <asp:DataList ID="dlNormal" runat="server" ShowFooter="False" 
            ShowHeader="False"  style="float:left; width:100%;" RepeatColumns="2">
            <ItemTemplate>
                <asp:Panel ID="pnNormal" runat="server" 
    style="width:100%; float:left; margin:0px; padding:0px;">
                    <div style="width:100%; float:left;">
                        Cliente:
                        <asp:Label ID="lblCliente" runat="server" Text='<%# Eval("Cliente")%>' Font-Bold="true"></asp:Label>
                    </div>
                    <div style="width:100%; float:left;">
                        Descripción:
                        <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("DescripcionInf")%>' Font-Bold="true"></asp:Label>
                    </div>
                    <div style="width:100%; float:left; border-bottom:#000000 1px solid; padding-bottom:35px;">
                        Observaciones:
                        <asp:Label ID="lblObservaciones" runat="server" Text='<%# Eval("comentarios")%>'></asp:Label>
                    </div>
                </asp:Panel>
            </ItemTemplate>
        </asp:DataList>
        </div>
        

        <div id="divBotones" style="text-align:right"><input id="Button1" type="button" value="Imprimir" onclick="imprimir();" /> 
            <asp:Button 
                ID="Button2" runat="server"
                Text="Aceptar" onclick="Button2_Click" /></div>
        
    </div>
    </form>
</body>
</html>
