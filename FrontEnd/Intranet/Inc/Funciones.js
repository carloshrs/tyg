
// Funci�n JS para Expander y Contraer el Men�.
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

