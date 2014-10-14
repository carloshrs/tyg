using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet
{
	/// <summary>
	/// Summary description for Menu1.
	/// </summary>
	public partial class Menu1 : Page
	{
		protected HtmlImage verificacionesSign;
		protected HtmlImage nuevoinformesSign;
		protected HyperLink Hyperlink5;
		protected HtmlImage informesSign;
		protected HyperLink Hyperlink8;
		protected HtmlImage Img2;
		protected Label lblEmpresa;
		protected System.Web.UI.HtmlControls.HtmlGenericControl nuevoinformes;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			// Put user code to initialize the page here
			UsuarioAutenticado Usuario = (UsuarioAutenticado) Context.User;
			if (Session["UsuarioAutenticado"] == null)
				Session.Add("UsuarioAutenticado", Usuario);
			//lblEmpresa.Text = Usuario.RazonSocial;
			lblNombre.Text = Usuario.NombreUsuario;
			lblNombre.ToolTip = Usuario.NombreUsuario + " - " + Usuario.RazonSocial;
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
