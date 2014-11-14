<%@ Page Language="C#" AutoEventWireup="true" CodeFile="impresionenproceso.aspx.cs" Inherits="InformePartidasDefuncion_listadopendientes" %>

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
    <img src="/Img/logo-20-anios.png" width="264" height="99" />
        <div style="float:right;"><asp:Label ID="lblFechaActual" runat="server" Font-Bold="True" Text="06/01/2011"></asp:Label></div>
        <div style="width:100%; float:left; margin-bottom:20px; font-size:14px;">
        Sres. Tribunales Federales de Córdoba<br />
        S.............................../...........................D<br />
            <br />
            <br />
            <br />

       &emsp;&emsp;&emsp; Quien suscribe, Alejandro Daniel Sariago, DNI. 22792467, con domicilio en calle 25 de Mayo 66 Piso Nº 2 Of. 11 de Córdoba Capital, en su carácter de Martillero Judicial MP. 01-1376, solicita a Ud. le expida  información mediante formulario Nº 5 sobre las personas de sexo <asp:Label ID="lblSexo" runat="server"></asp:Label> que se detallan a continuación:
</div>
        <div style="width:100%; float:left; margin-bottom:10px;">
            <asp:Label ID="lblSUrgente" runat="server" Text="Super urgente" Font-Size="16px" Font-Bold="true" Visible="false"></asp:Label>
        <asp:DataList ID="dlSUrgente" runat="server" ShowFooter="False" 
            ShowHeader="False" style="float:left; width:100%; margin-left:100px;">
            <ItemTemplate>
                <asp:Panel ID="pnSUrgente" runat="server" style="width:100%; float:left; margin:0px; padding:0px;">
                    <div style="width:100%; float:left;">
                        <asp:Label ID="lblRow" runat="server" Text='<%# Eval("row_no") %>' Visible="false"></asp:Label>
                    </div>
                    <div style="width:100%; float:left;">
                        <%# Eval("row_no") %>) - 
                        <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("DescripcionInf")%>' Font-Bold="true" Font-Size="Small"></asp:Label>
                    </div>
                </asp:Panel>
            </ItemTemplate>
        </asp:DataList>
        </div>
        <div style="width:100%; float:left; margin-top:30px; margin-bottom:20px; font-size:14px;">
        &emsp;&emsp;&emsp; Se deja constancia que se solicita la presente con el objeto de ser tener la información necesaria para solicitar las partidas de defunción y presentar las en entidad bancaria de esta Provincia.
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;
        &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;Firma y sello.

</div>
        
        
        

        <div id="divBotones" style="text-align:right"><asp:button runat="server" ID="btnVolver" 
                Text="Volver" onclick="btnVolver_Click"/>&nbsp; <input id="Button1" type="button" value="Imprimir" onclick="imprimir();" /> 
            <asp:Button 
                ID="Button2" runat="server"
                Text="Aceptar" onclick="Button2_Click" /></div>
        
    </div>
    </form>
</body>
</html>
