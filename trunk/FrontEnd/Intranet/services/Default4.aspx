<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="services_Default4" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
</head>

<script>
 function OnSucceeded(result)
            {

                var tempPer = new Array();
                tempPer = result.split('|');
                alert(tempPer.length)
                alert(tempPer[0])
                alert(tempPer[1])
/*
                if(tempPer.length == 1)
                    parserTexto(result);
                else
                {
                */
                }
</script>
<style>
.completionList {
    border:solid 1px #444444;
    margin:0px;
    padding:2px;
    height: 100px;
    overflow:auto;
    font-family: Arial, Verdana, Helvetica, Sans-Serif;
    font-size:11px;
}

.listItem {
    color: #000000;
}

.itemHighlighted {
    background-color: #3557A1;
    color: #FFFFFF;
} 

</style>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:TextBox ID="txtBuscar" runat="server" Width="202px"></asp:TextBox>
        <cc1:AutoCompleteExtender ID="txtBuscar_AutoCompleteExtender" runat="server" Enabled="true" 
            ServiceMethod="BuscarEmpresa" ServicePath="autocomplete.asmx" 
            MinimumPrefixLength="2" enablecaching="true" 
            TargetControlID="txtBuscar" UseContextKey="true" CompletionSetCount="10" 
            CompletionInterval="200" CompletionListCssClass="completionList" CompletionListHighlightedItemCssClass="itemHighlighted" CompletionListItemCssClass="listItem" >
        </cc1:AutoCompleteExtender>
        <asp:Button ID="Button1" runat="server" Text="Buscar" />
    
    </div>
    </form>
</body>
</html>
