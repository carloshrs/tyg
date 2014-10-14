<%@ Page Language="C#" CodeFile="Default2.aspx.cs" Inherits="services_Default2" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"	Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void btnObtener_PreRender(object sender, EventArgs e)
    {
        btnObtener.Attributes.Add("onClick", "GetServerTime(document.getElementById('txtDNI').value)");        
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">

    <head id="Head1" runat="server">
    <link href="/CSS/Estilos.css" type="text/css" rel="stylesheet">
        <style type="text/css">
            body {  font: 11pt Trebuchet MS;
                    font-color: #000000;
                    padding-top: 72px;
                    text-align: center }

            .text { font: 8pt Trebuchet MS }
        </style>

        <title>Simple Web Service</title>
	<link href="cssUpdateProgress.css" rel="stylesheet" type="text/css" />
	<script src="../Inc/padron.js" type="text/javascript"></script>
	<script type="text/javascript" language="javascript">
		var ModalProgress = '<%= ModalProgress.ClientID %>';         
	</script>
	
            <script type="text/javascript">

            // This function calls the Web Service method.  
            function GetServerTime(valor)
            {
                Samples.AspNet.ServerTime.GetServerTime(valor,OnSucceeded);
            }

            // This is the callback function that
            // processes the Web Service return value.
            function OnSucceeded(result)
            {
                //var RsltElem = document.getElementById("Results");
                //RsltElem.innerHTML = result;
                //var RsltElem1 = document.getElementById("Results1");
                //RsltElem1.innerHTML = result;
                //var RsltElem2 = document.getElementById("Results2");
                //RsltElem2.innerHTML = result;
                
                
                 realizar(result);

            }

        </script>

<script>
/*
    var resultElement;

    function pageLoad()
    {
        resultElement = $get("ResultId");
    }

    // This function performs a GET Web request.
    function GetWebRequest()
    {
        alert("Performing Get Web request.");

        // Instantiate a WebRequest.
        var wRequest = new Sys.Net.WebRequest();

        // Set the request URL.      
        wRequest.set_url("getTarget.htm");
        alert("Target Url: getTarget.htm");

        // Set the request verb.
        wRequest.set_httpVerb("GET");

        // Set the request callback function.
        wRequest.add_completed(OnWebRequestCompleted);

        // Clear the results area.
        resultElement.innerHTML = "";

        // Execute the request.
        wRequest.invoke();  
    }

    // This function performs a POST Web request.
    function PostWebRequest()
    {
        alert("Performing Post Web request.");

        // Instantiate a WebRequest.
        var wRequest = new Sys.Net.WebRequest();

        // Set the request URL.      
        wRequest.set_url("postTarget.aspx");
        alert("Target Url: postTarget.aspx");

        // Set the request verb.
        wRequest.set_httpVerb("POST");

        // Set the request handler.
        wRequest.add_completed(OnWebRequestCompleted);

        // Set the body for he POST.
        var requestBody = 
            "Message=Hello! Do you hear me?";
        wRequest.set_body(requestBody);
        wRequest.get_headers()["Content-Length"] = 
            requestBody.length;

        // Clear the results area.
       resultElement.innerHTML = "";

        // Execute the request.
        wRequest.invoke();              
    }


    // This callback function processes the 
    // request return values. It is called asynchronously 
    // by the current executor.
    function OnWebRequestCompleted(executor, eventArgs) 
    {    
        if(executor.get_responseAvailable()) 
        {
            // Clear the previous results. 

           resultElement.innerHTML = "";

            // Display Web request status. 
           resultElement.innerHTML +=
              "Status: [" + executor.get_statusCode() + " " + 
                        executor.get_statusText() + "]" + "<br/>";

            // Display Web request headers.
           resultElement.innerHTML += 
                "Headers: ";

           resultElement.innerHTML += 
                executor.getAllResponseHeaders() + "<br/>";

            // Display Web request body.
           resultElement.innerHTML += 
                "Body:";

          if(document.all)
            resultElement.innerText += 
               executor.get_responseData();
          else
            resultElement.textContent += 
               executor.get_responseData();
        }

    }
    if (typeof(Sys) !== "undefined") Sys.Application.notifyScriptLoaded();


function DisableButtons()
{
//   var button1 = document.getElementById("Button1");
//    button1.disabled = true;
    
    var progress = document.getElementById("ProgressBar");
    progress.style.display = "";

    return false;
}
*/
</script>

    </head>

    <body>
        <form id="Form1" runat="server" onsubmit="DisableButtons()">
<script type="text/javascript" src="jsUpdateProgress.js"></script>		
         <asp:ScriptManager runat="server" ID="scriptManager">
                <Services>
                    <asp:ServiceReference path="ServerTime.asmx" />
                </Services>
            </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
                <fieldset>

        <div style="height: 187px; width: 526px">
                <h2>Verificación de Persona en Padrón<br />
                    DNI:
                    <asp:TextBox ID="txtDNI" runat="server"></asp:TextBox>
                    
                </h2>
                    <!--<input id="EchoButton" type="button" value="Obtener" onclick="GetServerTime(document.getElementById('txtDNI').value)" />-->
                <asp:Button ID="btnObtener" runat="server" Text="Obtener" 
                    onprerender="btnObtener_PreRender" />
                <ajaxToolkit:ModalPopupExtender ID="btnObtener_ModalPopupExtender" 
                    runat="server" PopupControlID="pnlPersonaPadron" TargetControlID="btnObtener">
                </ajaxToolkit:ModalPopupExtender>
                <br />
                <br />
                Nombre:
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                &nbsp;Apellido:
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            </div>
            <!--
            <div>
            <span id="Results"></span><br />
            <span id="Results1"></span><br />
            <span id="Results2"></span>
        </div>  --> 
            <asp:Panel ID="pnlPersonaPadron" runat="server" Width="400" Height="200" 
        CssClass="CajaDialogo" EnableViewState="false">
        <div style="padding: 4px; background-color: #32528E; color: #FFFFFF; font-family: Arial, Helvetica, sans-serif; ">
        <asp:Label ID="lblTitulo" runat="server" Text="Nombre de persona" />
    </div>
    <div style="overflow:scroll; height:130px; padding-left: 20px; text-align:left;">
        <div id="idDiv1" class="caja" style="display:none;" onmouseover="seleccionar(this);" onmouseout="deseleccionar(this);" onclick="seleccionarPersona(this, 1);">
        <span><strong>Apellido:</strong> </span><span id="Results11"></span>
        <span><strong>Nombre:</strong> </span><span id="Results12"></span>
        </div>
        <div id="idDiv2" class="caja" style="display:none;" onmouseover="seleccionar(this);" onmouseout="deseleccionar(this);" onclick="seleccionarPersona(this, 2);">
        <span><strong>Apellido:</strong> </span><span id="Results21"></span>
        <span><strong>Nombre:</strong> </span><span id="Results22"></span>
        </div>
    </div>
    <div align="center">
        &nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cerrar" 
            CausesValidation="False"/>
            </div>
    </asp:Panel>
      </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>

            
		<asp:Panel ID="panelUpdateProgress" runat="server" CssClass="updateProgress">
			<asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
				<ProgressTemplate>
					<div style="position: relative; top: 30%; text-align: center;">
						<img src="ajax-loader.gif" style="vertical-align: middle" alt="Processing" />
						Procesando ...
					</div>
				</ProgressTemplate>
			</asp:UpdateProgress>
		</asp:Panel>
		<modalpopupextender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
			BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
	
        </form>

        <hr/>

    </body>

</html>
