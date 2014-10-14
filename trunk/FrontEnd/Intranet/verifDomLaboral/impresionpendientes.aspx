<%@ Page Language="C#" AutoEventWireup="true" CodeFile="impresionpendientes.aspx.cs" Inherits="verifDomLaboral_listadopendientes" %>

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
        <div style="float:right;"><asp:Label ID="lblFechaActual" runat="server" Font-Bold="True"></asp:Label><br /><asp:Label ID="lblCantPagina" runat="server" Font-Bold="True"></asp:Label></div>
        <div style="width:100%; float:left; margin-bottom:20px; font-weight:bold; text-align:center; font-size:16px;">LISTADO DE VERIFICACIONES LABORALES</div>

        <asp:DataList ID="dlVerificaciones" runat="server" ShowFooter="False" 
            ShowHeader="False" Width="100%" OnItemDataBound="Item_Bound">
            <ItemTemplate>
                <asp:Panel ID="pnSolicitud" runat="server" 
    style="width:100%; float:left; border-bottom: solid 1px #000000; margin:0px; padding:10px; height:210px;">
                    <div style="width:50%; float:left;">
                        Solicitado por:
                        <asp:Label ID="lblCliente" runat="server" Font-Bold="True" Text='<%# Eval("Cliente") %>'></asp:Label>
                        <asp:Label ID="lblRow" runat="server" Text='<%# Eval("row_no") %>' Visible="false"></asp:Label>
                    </div>
                    <div style="width:50%; float:left;">
                        Fecha:
                        <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("FechaCarga", "{0:d}") %>'></asp:Label>
                    </div>
                    <div style="width:50%; float:left;">
                        Nombre:
                        <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("nombre")%>'></asp:Label>
                    </div>
                    <div style="width:50%; float:left;">
                        DNI:
                        <asp:Label ID="lblDNI" runat="server" Text='<%# Eval("documento") %>'></asp:Label>
                    </div>
                    <div style="width:50%; float:left;">
                        Empresa:
                        <asp:Label ID="lblEmpresa" runat="server" Text='<%# Eval("razonsocial") %>'></asp:Label>
                    </div>
                    <div style="width:50%; float:left;">
                        Cargo:
                        <asp:Label ID="lblCargo" runat="server" Text='<%# Eval("cargo") %>'></asp:Label>
                    </div>
                    <div style="width:50%; float:left;">
                        CUIT:
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("cuit") %>'></asp:Label>
                    </div>
                    <div style="width:50%; float:left;">
                        Dirección:
                        <asp:Label ID="lblDireccion" runat="server" Text='<%# Eval("direccion") %>'></asp:Label>
                    </div>
                    <div style="width:50%; float:left;">
                        Telefono:
                        <asp:Label ID="lblTelefono" runat="server" Text='<%# Eval("telefono") %>'></asp:Label>
                    </div>
                    <div style="width:50%; float:left;">
                        Provincia:
                        <asp:Label ID="lblProvincia" runat="server" Text='<%# Eval("provincia") %>'></asp:Label>
                    </div>
                    <div style="width:50%; float:left;">
                        Localidad:
                        <asp:Label ID="lblLocalidad" runat="server" Text='<%# Eval("localidad") %>'></asp:Label>
                    </div>
                    <div style="width:100%; float:left;">
                        Observaciones:
                        <asp:Label ID="lblObservaciones" runat="server" Text='<%# Eval("comentarios") %>'></asp:Label>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnSaltoPagina" runat="server" Visible="false"><h1 class="SaltoDePagina"></h1></asp:Panel>
            </ItemTemplate>
        </asp:DataList>

        <div id="divBotones" style="text-align:right"><input id="Button1" type="button" value="Imprimir" onclick="imprimir();" /> 
            <asp:Button 
                ID="Button2" runat="server"
                Text="Aceptar" onclick="Button2_Click" /></div>
        
    </div>
    </form>
</body>
</html>
