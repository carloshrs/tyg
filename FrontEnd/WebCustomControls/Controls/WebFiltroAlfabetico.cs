using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebCustomControls.EventArguments;

namespace WebCustomControls.Controls
{
	
	public delegate void FilterHandler (Object sender, FilterChangedEventArgs e);

	/// <summary>
	/// Summary description for WebFiltroAlfabetico.
	/// </summary>
	[DefaultProperty("MostrarOtros"), 
		ToolboxData("<{0}:WebFiltroAlfabetico runat=server></{0}:WebFiltroAlfabetico>")]
	public class WebFiltroAlfabetico : WebControl , IPostBackEventHandler
	{
		#region Atributos
				
		private int arriba = 0;
		private int izquierda = 0;
		private string estilo = "";
		private string mensajeAyuda="";
		private bool mostrarOtros= false;		
		
		#endregion

		#region Eventos

		[Category("Action"),Description("Raised when the filter is clicked")]
		public event FilterHandler FilterChange;
		
		#endregion

		#region Propiedades
		
		[Bindable(true),
			Category("Appearance"),
			DefaultValue("0")]
		public int Arriba
		{
			get { return arriba; }
			set { arriba = value; }
		}

		[Bindable(true),
			Category("Appearance"),
			DefaultValue("0")]
		public int Izquierda
		{
			get { return izquierda; }
			set { izquierda = value; }
		}

		[Bindable(true), 
			Category("Appearance"), 
			DefaultValue("")] 
		public string MensajeAyuda 
		{
			get { return mensajeAyuda; }
			set { mensajeAyuda = value; }
		}

		[Bindable(true), 
		Category("Appearance"), 
		DefaultValue("")] 
		public string Estilo 
		{
			get { return estilo; }
			set { estilo = value; }
		}

		[Bindable(true), 
			Category("Appearance"), 
			DefaultValue("false")] 

		public bool MostrarOtros
		{
			get { return mostrarOtros; }
			set { mostrarOtros = value; }
		}
		
		#endregion

		#region Contenido
		/// <summary> 
		/// Render this control to the output parameter specified.
		/// </summary>
		/// <param name="output"> The HTML writer to write out to </param>
		protected override void Render(HtmlTextWriter output)
		{			
			this.Page.GetPostBackEventReference(this.Page);
			output.WriteLine("<table border='0' style='position:relative; left:"+izquierda+"px; top:"+arriba+"px;'>");
			output.WriteLine("<tr>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con A' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','A');\">A</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con B' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','B');\">B</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con C' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','C');\">C</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con D' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','D');\">D</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con E' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','E');\">E</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con F' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','F');\">F</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con G' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','G');\">G</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con H' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','H');\">H</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con I' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','I');\">I</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con J' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','J');\">J</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con K' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','K');\">K</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con L' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','L');\">L</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con M' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','M');\">M</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con N' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','N');\">N</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con &Ntilde;' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','Ñ');\">&Ntilde;</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con O' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','O');\">O</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con P' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','P');\">P</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con Q' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','Q');\">Q</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con R' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','R');\">R</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con S' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','S');\">S</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con T' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','T');\">T</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con U' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','U');\">U</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con V' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','V');\">V</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con W' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','W');\">W</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con X' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','X');\">X</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con Y' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','Y');\">Y</a></td>");
			output.WriteLine("<td><a href='#' title='Mostrar "+mensajeAyuda+" comienza con Z' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','Z');\">Z</a></td>");
			if (mostrarOtros)
			{
				output.WriteLine("<td>-</td>");
				output.WriteLine("<td><a href='#' title='Mostrar Otros' class=\""+estilo+"\" onclick=\"__doPostBack('" + this.UniqueID + "','');\">Otros</a></td>");
			}
			output.WriteLine("</tr>");
			output.WriteLine("</table>");									
		}
		
		#endregion

		#region Manejadores Evento

		protected virtual void OnFilterChanged(Object sender, FilterChangedEventArgs e)
		{
			if (FilterChange != null) 
			{
				FilterChange(this, e);
			}
		}

		public void RaisePostBackEvent(string eventArgument)
		{						
			FilterChangedEventArgs args = new FilterChangedEventArgs();			
			args.Filter=eventArgument;
			OnFilterChanged(this,args);			
		}

		#endregion		
	}
}
