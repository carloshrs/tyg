using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Imagenes
{
	/// <summary>
	/// Summary description for VerImagen.
	/// </summary>
	public partial class VerImagen : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			lblTools.Text = "<input onclick=\"panel.style.visibility='hidden';window.print();panel.style.visibility='visible';\" type=\"image\" src=\"/img/imprimir-2.gif\"> " +
				"<input onclick=\"window.close();\" type=\"image\" src=\"/img/log_off.gif\"> ";

			try
			{
				imgFoto.ImageUrl = Request.QueryString["Path"];
				imgFoto.ToolTip = Request.QueryString["Desc"];
				imgFoto.AlternateText = Request.QueryString["Desc"];
			}
			catch
			{
				string strScript = "<script languaje=\"Javascript\">";
				strScript += "window.close();";
				strScript += "</script>";

				Page.RegisterStartupScript("Cerrar", strScript);
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
	}
}
