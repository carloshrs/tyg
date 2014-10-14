//Variables de entorno
var HTTP_response = null;
var bsq_articulos = null;
var bsq_criterio = null;
var bsq_txt = null;
var bsq_timer = null;
var bsq_element = null;
//Configuración
var bsq_fondo = '#F5F5F5';
var bsq_ctxt = '#000000';
var bsq_fondo_sel = '#3557A1';
var bsq_ctxt_sel = '#FFFFFF';
var bsq_disparadorBusqueda = 3;
function request()
{
	var http_request = null;
	if (window.XMLHttpRequest) 
	{ 
		http_request = new XMLHttpRequest();
		if (http_request.overrideMimeType) 
		{
			http_request.overrideMimeType('text/plain');
		}
	} 
	else if (window.ActiveXObject) 
	{ 
		try 
		{
			http_request = new ActiveXObject("Msxml2.XMLHTTP");
		} catch (e) 
		{
			try 
			{
				http_request = new ActiveXObject("Microsoft.XMLHTTP");
			} catch (e) {}
		}
	}
	if (!http_request)
	{
		alert('No se logro cargar el control ActiveX');
		return false;
	}
	return http_request;
}

function bsq_buscar_text(text)
{
	if( bsq_element != null && bsq_element != text )
	{
	    HTTP_response = null;
	    cerrarBusqueda();
	}
	bsq_element = text;
	if( !bsq_teclaReservada )
	{
		cancelarCierre();
		if( text.value.length > (bsq_disparadorBusqueda-1) )
		{
			bsq_buscar( text.value );
		}
		else
		{
			cerrarBusqueda();	
		}
		posicionarDiv(text);
		var pos = getXY(text);
	}
}

function cancelarCierre()
{
	if( bsq_timer != null )
		clearTimeout(bsq_timer);	
}
function cerrarBusqueda()
{
	document.getElementById('divBusqueda').style.display = 'none';
}

function cerrarBusquedaD()
{
	bsq_timer = setTimeout("cerrarBusqueda();", 100);
}

function bsq_buscar( valor )
{
	bsq_txt = valor;
	var crit = valor.substring(0,bsq_disparadorBusqueda);
	if( crit != bsq_criterio )
	{
		bsq_articulos = null;
		AJAX_buscar(bsq_element, crit);
		bsq_criterio = crit;
	}
	else
	{
		generarListado();
	}
}

function posicionarDiv( obj )
{
	var pos = getXY(obj);
	var ycor = pos.y + 17;
	document.getElementById('divBusqueda').style.top = ycor + "px";
	document.getElementById('divBusqueda').style.left = pos.x + "px";
}

function getXY(element) 
{
  if (typeof element == "string")
    element = document.getElementById(element)
    
  if (!element) return { top:0,left:0 };
  
  var top = 0;
  var left = 0;
  while (element.offsetParent) {
    left += element.offsetLeft;
    top += element.offsetTop;
    element = element.offsetParent;
  }
  return {y:top,x:left};
}

function tomarRespuesta()
{
	if ( HTTP_response != null && HTTP_response.readyState == 4) 
	{
		if (HTTP_response.status == 200) 
		{
			var text = HTTP_response.responseText;
			text = text.replace("<META NAME=\"ColdFusionMXEdition\" CONTENT=\"ColdFusion DevNet Edition - Not for Production Use.\">","");
			if( text != "" )
			{
				bsq_articulos = text.split("^");
				generarListado();
			}
			else
			{
				noResultado();
			}
		} 	
		else 
		{
			alert('Error al solicitar Información al Servidor.\n\nReintente nuevamente.');
		}
	}
}

function generarListado()
{
	bsq_posTeclado = -1;
	if( bsq_articulos != null )
	{
		var cuerpo = document.getElementById('bsqCuerpo');
		var filas = cuerpo.rows.length;
		for(var j=0; j < filas; j++)
			cuerpo.deleteRow(0);
		var hayResultados = false;
		for(var i=0; i < bsq_articulos.length; i++)
		{
			var data = bsq_articulos[i].split('|');
			var id = data[0];
			var descripcion = bsq_filtro( data[1] );
			
			if( descripcion != "" )
			{
				hayResultados = true;
				var fila = document.createElement("TR");
				fila.id = id;
				fila.onmouseover = function(){pintarFilaBSQ(this.id);};		
				fila.style.backgroundColor = bsq_fondo;
				fila.style.color = bsq_ctxt;
				var celda = document.createElement("TD");
				celda.valign = "middle";
				celda.style.cursor = "pointer";
				celda.onclick = function(){filaClick(this.parentNode.id);};
				celda.innerHTML = descripcion;
				fila.appendChild( celda );
				cuerpo.appendChild( fila );
			}
		}
		if( !hayResultados )
			noResultado();
		else
			document.getElementById('divBusqueda').style.display = 'block';		
	}
	else
		if( bsq_txt.length > 2 && bsq_txt != '' )
			noResultado();
		else
			cerrarBusqueda();
}

function noResultado()
{
	var cuerpo = document.getElementById('bsqCuerpo');
	var filas = cuerpo.rows.length;
	for(var j=0; j < filas; j++)
		cuerpo.deleteRow(0);
	var fila = document.createElement("TR");
	fila.id = -1;
	fila.style.backgroundColor = bsq_fondo;
	fila.style.color = bsq_ctxt;
	var celda = document.createElement("TD");
	celda.valign = "middle";
	celda.style.cursor = "default";
	celda.innerHTML = "NO SE ENCONTRARON RESULTADOS CON '<b>"+bsq_txt.toUpperCase()+"</b>'";
	fila.appendChild( celda );
	cuerpo.appendChild( fila );
	document.getElementById('divBusqueda').style.display = 'block';	
}

function bsq_filtro(valor)
{
	if( valor.indexOf(bsq_txt.toUpperCase()) == 0 )
	{
		valor = valor.replace(bsq_txt.toUpperCase(),"<b>"+bsq_txt.toUpperCase()+"</b>");	
		return valor;	
	}
	return "";
}

function filaClick(valor)
{
	setRetornoBusqueda(bsq_element, valor);	
}


var posAnteriorBSQ=0;
var posSelectBSQ=0;
function limpiarBSQ ()
{
	if (posAnteriorBSQ!=0 && posAnteriorBSQ!=posSelectBSQ)
		if (document.getElementById(posAnteriorBSQ)!=null)
		{
			document.getElementById(posAnteriorBSQ).style.background = bsq_fondo;	
			document.getElementById(posAnteriorBSQ).style.color = bsq_ctxt;	
			posAnteriorBSQ = 0;
		}
}

function pintarFilaBSQ (pos)
{	
	// Cambio el color de fondo de la fila seleccionada...
	if (posAnteriorBSQ!=0 && posAnteriorBSQ!=posSelectBSQ)
	{
		var obj = document.getElementById(posAnteriorBSQ);
		if(obj)
		{
			obj.style.background = bsq_fondo;			
			obj.style.color = bsq_ctxt;
		}
	}
	
	//si usaron teclas
	var cuerpo = document.getElementById("bsqCuerpo");
	if( bsq_posTeclado != -1 )
	{
		cuerpo.rows[bsq_posTeclado].style.background = bsq_fondo;
		cuerpo.rows[bsq_posTeclado].style.color = bsq_ctxt;
		bsq_posTeclado = -1;
	}
	
	document.getElementById(pos).style.background = bsq_fondo_sel;		
	document.getElementById(pos).style.color = bsq_ctxt_sel;
	if (posAnteriorBSQ!=pos)
		posAnteriorBSQ=pos;							
}

//manejo de seleccion por teclado
var bsq_posTeclado = -1;
var bsq_teclaReservada = false;
var bsq_nav4 = window.Event ? true : false;
function bsq_tomarTecla( evt )
{
	var key = bsq_nav4 ? evt.which : evt.keyCode;	
	limpiarBSQ();
	switch(key)
	{
		case 13: selRow();//enter
				 bsq_teclaReservada = true;
				 return false;
		case 40: downRow();//flecha abajo
		         bsq_teclaReservada = true;
				 return false;
		case 38: upRow();//flecha arriba
				 bsq_teclaReservada = true;
				 return false;
	}
	bsq_teclaReservada = false;
	return true;
}
function upRow()
{
	var cuerpo = document.getElementById("bsqCuerpo");
	if( cuerpo.rows.length != 0 && cuerpo.rows[0].id != -1)
	{
		if( bsq_posTeclado != -1 )
		{
			cuerpo.rows[bsq_posTeclado].style.background = bsq_fondo;
			cuerpo.rows[bsq_posTeclado].style.color = bsq_ctxt;
		}
		if( bsq_posTeclado == -1 || bsq_posTeclado == 0 )	
			bsq_posTeclado = cuerpo.rows.length - 1;
		else
			bsq_posTeclado--;
		cuerpo.rows[bsq_posTeclado].style.background = bsq_fondo_sel;
		cuerpo.rows[bsq_posTeclado].style.color = bsq_ctxt_sel;
		document.getElementById('divBusqueda').scrollTop = cuerpo.rows[bsq_posTeclado].offsetTop;
	}
}
function downRow()
{
	var cuerpo = document.getElementById("bsqCuerpo");
	if( cuerpo.rows.length != 0 && cuerpo.rows[0].id != -1)
	{
		if( bsq_posTeclado != -1 )
		{
			cuerpo.rows[bsq_posTeclado].style.background = bsq_fondo;
			cuerpo.rows[bsq_posTeclado].style.color = bsq_ctxt;
		}
		if( bsq_posTeclado == (cuerpo.rows.length - 1) )	
			bsq_posTeclado = 0;
		else
			bsq_posTeclado++;
		cuerpo.rows[bsq_posTeclado].style.background = bsq_fondo_sel;
		cuerpo.rows[bsq_posTeclado].style.color = bsq_ctxt_sel;
		document.getElementById('divBusqueda').scrollTop = cuerpo.rows[bsq_posTeclado].offsetTop - 97 + cuerpo.rows[bsq_posTeclado].offsetHeight;
	}
}
function selRow()
{
	var cuerpo = document.getElementById("bsqCuerpo");
	if( cuerpo.rows.length != 0 && cuerpo.rows[0].id != -1)
	{
		if( bsq_posTeclado != -1 )
		{
			var id = cuerpo.rows[bsq_posTeclado].id;
			filaClick( id );
		}
	}
}