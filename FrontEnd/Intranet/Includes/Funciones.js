// Para incluir este archivo en cualquier página hay que agregar:
//<script src="/Includes/Funciones.js" type="text/javascript"></script>


// Function validarString(evt):
// Impide que en un campo se ingrese el caracter "'"
// para evitar errores en las consultas a la BD

// Para que valide un input hay que agregar:
// onKeyPress="return validarString(event);"
function validarString(evt)
{
	//39='		
	var charCode = (evt.charCode) ? evt.charCode : ((evt.which) ? evt.which : evt.keyCode);	
	if (charCode!= 39)	
		return true;
	else
		return false;
}

/*
jQuery(document).ready(function () {
    // binds form submission and fields to the validation engine
    jQuery("#Form1").validationEngine();
});
*/
