function limpiar()
{
    document.getElementById("Results11").innerHTML = "";
    document.getElementById("Results12").innerHTML = "";
    document.getElementById("Results21").innerHTML = "";
    document.getElementById("Results22").innerHTML = "";
    document.getElementById("idDivError").style.display = "none";
    document.getElementById("idDiv1").style.display = "none";
    document.getElementById("idDiv2").style.display = "none";

}

function realizar(texto)
{
    //alert(document.getElementById("idDiv").style);
    document.getElementById("idDiv1").style.display = "";
    document.getElementById("idDiv2").style.display = "";
    result = texto;//"prueba de texto"

    var temp2 = new Array();
    temp2 = result.split(',');

    if(temp2.length > 2)
    {
        document.getElementById("idDiv2").style.display = "none";
        var RsltElem11 = document.getElementById("Results11");
        RsltElem11.innerHTML = temp2[1];
        var RsltElem12 = document.getElementById("Results12");
        RsltElem12.innerHTML = temp2[2];
    }
    else
    {
        var temp = new Array();
        temp = temp2[1].split(' ');

        /*
        for (i=0;i<temp.length;i++){
	        alert("Posición " + i + " del array: " + temp[i])
        } 
        */
        if (texto == "") return false;
        if (temp.length == 2) {document.getElementById("idDiv2").style.display = "none";} // SOLO TRAE 2 VALORES
        
        if(temp.length < 2)
        {
	        if(temp[0] != "")
	        {
                var RsltElem11 = document.getElementById("Results11");
                RsltElem11.innerHTML = temp[0];
	        }
        }
        else if(temp.length < 3)
        {
	        if(temp[0] != "")
	        {
                var RsltElem11 = document.getElementById("Results11");
                RsltElem11.innerHTML = temp[0];
	        }

	        if(temp[1] != "")
	        {
                var RsltElem12 = document.getElementById("Results12");
                RsltElem12.innerHTML = temp[1];
	        }
        }
        else
        {
	        if(temp[0] != "")
	        {
                var RsltElem11 = document.getElementById("Results11");
                RsltElem11.innerHTML = temp[0];

		        var RsltElem21 = document.getElementById("Results21");
                RsltElem21.innerHTML = temp[0] + " " + temp[1];
	        }
        	
	        if(temp[2] != "")
	        {
		        tempName = "";
		        for(j=2; j<temp.length; j++)
		        {
			        tempName = tempName + temp[j] + " ";
		        }
        		
		        var RsltElem12 = document.getElementById("Results12");
                RsltElem12.innerHTML = temp[1] + " " + tempName;

		        var RsltElem22 = document.getElementById("Results22");
                RsltElem22.innerHTML = tempName;
	        }
        }
    }
}
	  
function seleccionar(objDiv)
{
  objDiv.style.backgroundColor='#CEE3FB';
  objDiv.style.color='#32528E';
  objDiv.style.cursor='hand';
}
  
function deseleccionar(objDiv)
{
  objDiv.style.backgroundColor='#DDDDDD';
  objDiv.style.color='#000000';
}

function deseleccionar2(objDiv)
{
  objDiv.style.backgroundColor='#B3B3B3';
  objDiv.style.color='#000000';
}

function seleccionarPersona(objDiv, nro)
{
	//alert(document.forms[0].txtApellido.value);
	//return false;
	if(nro == 1)
	{
		document.forms[0].txtApellido.value = document.getElementById("Results11").innerHTML;
		document.forms[0].txtNombre.value = document.getElementById("Results12").innerHTML;
	}
	else
	{
		document.forms[0].txtApellido.value = document.getElementById("Results21").innerHTML;
		document.forms[0].txtNombre.value = document.getElementById("Results22").innerHTML;
	}
}


function parserTexto(result)
{
    var temp = new Array();
    temp = result.split(',');
    
    if(temp[0] == 1)
    {
        var RsltElem = document.getElementById("Results");
        //RsltElem.innerHTML = result;
        if(temp[1] != "Persona no existe en la base")
        {
            realizar(result);
            document.getElementById("divProcesando").style.display='none';
        }
        else
        {
            document.getElementById("divProcesando").style.display='none';
            document.getElementById("idDivError").style.display = "";
        }
    }
    else
    {
            var RsltElem = document.Form1.txtBarrio.value;
            RsltElem.innerHTML = result;
    }
}