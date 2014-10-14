
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.ComponentModel;

namespace WebControlLibrary
{
	/// <summary>
	/// Summary description for FiltroAlfabetico.
	/// </summary>
	[DefaultProperty("Text"), 
		ToolboxData("<{0}:FiltroAlfabetico runat=server></{0}:FiltroAlfabetico>")]
	public class FiltroAlfabetico : WebControl
	{
		#region Atributos
				
		private int arriba = 0;
		private int izquierda = 0;
		private string estilo = "";

		#endregion

		#region Propiedades

		[Category("Action"),Description("Raised when the filter is clicked")]
		public event EventHandler Click;

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
		public string Estilo 
		{
			get { return estilo; }
			set { estilo = value; }
		}
		
		#endregion

		/// <summary> 
		/// Render this control to the output parameter specified.
		/// </summary>
		/// <param name="output"> The HTML writer to write out to </param>
		protected override void Render(HtmlTextWriter output)
		{			
			this.Page.GetPostBackEventReference(this.Page);
           
			output.WriteLine("<table border='0' style='position:relative; width:220px; height:30px;'>");
			output.WriteLine("<tr>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','A');\">A</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','B');\">B</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','C');\">C</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','D');\">D</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','E');\">E</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','F');\">F</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','G');\">G</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','H');\">H</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','I');\">I</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','J');\">J</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','K');\">K</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','L');\">L</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','M');\">M</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','N');\">N</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','Ñ');\">&Ntilde;</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','O');\">O</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','P');\">P</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','Q');\">Q</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','R');\">R</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','S');\">S</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','T');\">T</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','U');\">U</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','V');\">V</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','W');\">W</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','X');\">X</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','Y');\">Y</a></td>");
			output.WriteLine("<td class=\""+estilo+"\"><a href='#' onclick=\"__doPostBack('" + this.UniqueID + "','Z');\">Z</a></td>");
			output.WriteLine("</tr>");
			output.WriteLine("</table>");									
		}

		#region Eventos

		protected virtual void OnClick(Object sender,EventArgs e)
		{
			if (Click != null) 
			{
				Click(this, e);
			}
		}

		public void RaisePostBackEvent(string eventArgument)
		{
			OnClick(this,EventArgs.Empty);
		}

		#endregion
	}
}
