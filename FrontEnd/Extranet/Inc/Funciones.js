
// Función JS para Expander y Contraer el Menú.
function expandTab(div) {
		var el = document.getElementById(div);
		if (!el) return;
		if (el.style.display == "none")
		{
			el.style.display = "block";
			if (document.getElementById(div + "Sign"))
				document.getElementById(div + "Sign").src = "/img/folderOpen.gif";
		}
		else
		{
			el.style.display = "none";
			if (document.getElementById(div + "Sign"))
				document.getElementById(div + "Sign").src = "/img/folderClosed.gif";
		}
}


function validarString(evt)
{
	//39='		
	var charCode = (evt.charCode) ? evt.charCode : ((evt.which) ? evt.which : evt.keyCode);	
	if (charCode!= 39)	
		return true;
	else
		return false;
}
