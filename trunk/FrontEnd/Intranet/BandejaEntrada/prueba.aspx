<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prueba.aspx.cs" Inherits="BandejaEntrada_prueba" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
</head>

<script>
            function GetServerTime(valor)
            {
                //limpiar();
                //document.getElementById("divProcesando").style.display='';
                //Samples.AspNet.ServerTime.GetServerTime(valor,OnSucceeded);
                alert("por aca");
            }

            // This is the callback function that
            // processes the Web Service return value.
            
            function OnSucceeded(result)
            {
                alert("hola")
            }
    </script>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
    <asp:ServiceReference  Path="../services/ServerTime.asmx" />
</Services>

        </asp:ScriptManager>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <cc1:ModalPopupExtender ID="Button1_ModalPopupExtender" runat="server" 
            TargetControlID="Button1">
        </cc1:ModalPopupExtender>
        <br />
    
    </div>
    </form>
</body>
</html>
