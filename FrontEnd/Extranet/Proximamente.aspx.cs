using System;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet
{
	/// <summary>
	/// Summary description for Proximamente.
	/// </summary>
    public partial class Proximamente : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
            int id = int.Parse(Request.QueryString["Id"]);

            if (id == 1)
            {
                lblMensaje.Text = "Novedoso servicio que le permitirá mediante un archivo virtual, registrar datos de inquilinos y garantes para evaluar su comportamiento.";
                imgLogoServicio.ImageUrl = "Img/ico-contratos.jpg";
            }
            else
            {
                lblMensaje.Text = "Novedoso servicio que le permitirá analizar y tomar decisiones sobre su futuro inquilino y sus garantes mediante verificaciones, constataciones de domicilios y referencias.";
                imgLogoServicio.ImageUrl = "/Img/img-inquilinoleal.jpg";
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
