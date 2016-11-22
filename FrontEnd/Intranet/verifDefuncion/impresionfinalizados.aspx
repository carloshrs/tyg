<%@ Page Language="C#" AutoEventWireup="true" CodeFile="impresionfinalizados.aspx.cs" Inherits="InformePartidasDefuncion_listadopendientes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <link href="../CSS/Estilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            text-align: center;
            font-weight: bold;
        }
    </style>
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
    <img src="/Img/logo-20-anios.png" width="264" height="99" />
        <div style="float:right;"><asp:Label ID="lblFechaActual" runat="server" Font-Bold="True" Text="06/01/2011"></asp:Label></div>
        <div style="width:100%; float:left; margin-bottom:20px; font-size:14px;" 
            class="style1">
            GESTIÓN DE VERIFICACIONES DE DEFUNCIÓN</div>
        <div style="width:100%; float:left; margin-bottom:10px;">
            <asp:datagrid id="gvFinalizados" runat="server" Width="100%" 
                                        Font-Size="8pt" PageSize="15"
										CellPadding="3" BorderColor="#3657A6" BorderStyle="Solid" BorderWidth="1px" BackColor="White" GridLines="Vertical"
										AutoGenerateColumns="False" onprerender="gvFinalizados_PreRender">
                <Columns>
                    <asp:BoundColumn DataField="idEncabezado" HeaderText="ID" />
                    <asp:BoundColumn DataField="Sexo" HeaderText="Sexo" Visible="false" />
                    <asp:TemplateColumn HeaderText="Sexo">
                        <HeaderStyle Width="80px">
                        </HeaderStyle>
                        <ItemTemplate>
                        <asp:Label id="lblSexo" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="Documento" HeaderText="DNI" />
                    <asp:BoundColumn DataField="Apellido" HeaderText="Apellido" Visible="false" />
                    <asp:BoundColumn DataField="Nombre" HeaderText="Nombre"  Visible="false"/>
                    <asp:TemplateColumn HeaderText="Apellido, Nombre">
                        <HeaderStyle Width="180px">
                        </HeaderStyle>
                        <ItemTemplate>
                        <asp:Label id="lblNombre" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="Fallecido" HeaderText="Fallecido" Visible="false" />
                    <asp:BoundColumn DataField="FechaFallecido" HeaderText="FechaFallecido" Visible="false" />
                    <asp:BoundColumn DataField="Acta" HeaderText="Acta" Visible="false" />
                    <asp:BoundColumn DataField="Tomo" HeaderText="Tomo" Visible="false" />
                    <asp:BoundColumn DataField="Folio" HeaderText="Folio" Visible="false" />
                    <asp:TemplateColumn HeaderText="Resultado">
                        <HeaderStyle Width="280px">
                        </HeaderStyle>
                        <ItemTemplate>
                        <asp:Label id="lblResultado" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="LugarFallecimiento" HeaderText="Lugar de fallecimiento" />
                    <asp:BoundColumn DataField="Observaciones" HeaderText="Partida defunción" />
                </Columns>
            </asp:datagrid>
        </div>
        
        
        

        <div id="divBotones" style="text-align:right"><input id="Button1" type="button" value="Imprimir" onclick="imprimir();" /> 
            <asp:Button 
                ID="Button2" runat="server"
                Text="Aceptar" onclick="Button2_Click" /></div>
        
    </div>
    </form>
</body>
</html>
