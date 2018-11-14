<%@ Page Language="C#" AutoEventWireup="true" CodeFile="impresionpendientes.aspx.cs" Inherits="mensajeria_listadopendientes" %>

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
        <div style="width:100%; float:left; margin-bottom:20px; font-weight:bold; text-align:center; font-size:16px;">LISTADO DE MENSAJERIA A REALIZAR</div>

        <asp:DataList ID="dlMensajeria" runat="server" ShowFooter="False" 
            ShowHeader="False" Width="100%" OnItemDataBound="Item_Bound">
            <ItemTemplate>
                <asp:Panel ID="pnSolicitud" runat="server" 
    style="width:100%; float:left; border-bottom: solid 1px #000000; margin:0px; padding:10px; height:176px;">
                    <div style="width:50%; float:left;">
                        Solicitado por:
                        <asp:Label ID="lblCliente" runat="server" Font-Bold="True" Text='<%# Eval("Cliente") %>'></asp:Label>
                        <asp:Label ID="lblRow" runat="server" Text='<%# Eval("row_no") %>' Visible="false"></asp:Label>
                    </div>
                    <div style="width:50%; float:left;">
                        Fecha de solicitud:
                        <asp:Label ID="lblFecha" runat="server" Text='<%# Eval("FechaCarga") %>'></asp:Label> 
                    </div>
                    
                    <div style="width:50%; float:left; margin-top:7px;">
                    <b>Dirección de recolección</b><br />
                        Contacto / Empresa:
                        <asp:Label ID="lblContactoRetiro" runat="server" Text='<%# Eval("msn_retirocontacto")%>' Font-Size="Small"></asp:Label> / <asp:Label ID="lblEmpresaRetiro" runat="server" Text='<%# Eval("msn_retiroempresa")%>' Font-Size="Small"></asp:Label><br />
                        Domicilio retiro:
                        <asp:Label ID="lblCalleRetiro" runat="server" Text='<%# Eval("msn_retirocalle") %>' Font-Size="Small"></asp:Label> <asp:Label ID="lblNroRetiro" runat="server" Text='<%# Eval("msn_retironro") %>' Font-Size="Small"></asp:Label>, piso: <asp:Label ID="lblPisoRetiro" runat="server" Text='<%# Eval("msn_retiropiso") %>' Font-Size="Small"></asp:Label>, dpto: <asp:Label ID="lblDptoRetiro" runat="server" Text='<%# Eval("msn_retirodpto") %>' Font-Size="Small"></asp:Label><br />
                        Fecha y horario de retiro estimativo:
                        <asp:Label ID="lblFechaRetiro" runat="server" Text='<%# Bind("msn_retirodia", "{0:d}") %>' Font-Size="Small"></asp:Label>, entre las <asp:Label ID="lblHoraDesdeRetiro" runat="server" Text='<%# Eval("msn_retirohoradesde") %>' Font-Size="Small"></asp:Label> y <asp:Label ID="lblHoraHastaRetiro" runat="server" Text='<%# Eval("msn_retirohorahasta") %>' Font-Size="Small"></asp:Label><br /><br />
                        
                        Fecha: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Hora: <br />
                        Nombre completo:<br />
                        DNI:<br /><br />
                        Firma:<br />
                    </div>
                    <div style="width:50%; float:left;margin-top:7px;">
                        <b>Dirección de entrega</b><br />
                        Contacto / Empresa:
                        <asp:Label ID="lblContactoEnvio" runat="server" Text='<%# Eval("msn_Enviocontacto")%>' Font-Size="Small"></asp:Label> / <asp:Label ID="lblEmpresaEnvio" runat="server" Text='<%# Eval("msn_Envioempresa")%>' Font-Size="Small"></asp:Label><br />
                        Domicilio Envio:
                        <asp:Label ID="lblCalleEnvio" runat="server" Text='<%# Eval("msn_Enviocalle") %>' Font-Size="Small"></asp:Label> <asp:Label ID="lblNroEnvio" runat="server" Text='<%# Eval("msn_Envionro") %>' Font-Size="Small"></asp:Label>, piso: <asp:Label ID="lblPisoEnvio" runat="server" Text='<%# Eval("msn_Enviopiso") %>' Font-Size="Small"></asp:Label>, dpto: <asp:Label ID="lblDptoEnvio" runat="server" Text='<%# Eval("msn_Enviodpto") %>' Font-Size="Small"></asp:Label><br />
                        Fecha y horario de envio estimativo:
                        <asp:Label ID="lblFechaEnvio" runat="server" Text='<%# Bind("msn_Enviodia", "{0:d}") %>' Font-Size="Small"></asp:Label>, entre las <asp:Label ID="lblHoraDesdeEnvio" runat="server" Text='<%# Eval("msn_Enviohoradesde") %>' Font-Size="Small"></asp:Label> y <asp:Label ID="lblHoraHastaEnvio" runat="server" Text='<%# Eval("msn_Enviohorahasta") %>' Font-Size="Small"></asp:Label><br /><br />
                        Fecha: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Hora: <br />
                        Nombre completo:<br />
                        DNI:<br /><br />
                        Firma:<br />
                    </div>
                    
                    
                    
                        <div style="width:100%; float:left; margin-top:7px;">
                            Servicio: <asp:Label ID="lblServicio" runat="server" Text='<%# Eval("msn_servicio") %>'></asp:Label> - 
                            Pago: 
                             $<asp:Label ID="lblPago" runat="server" Text='<%# Eval("msn_pago") %>'></asp:Label> - 
                            Contenido a enviar:
                            <asp:Label ID="lblContenido" runat="server" Text='<%# Eval("msn_mensajeria") %>'></asp:Label><br />
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
