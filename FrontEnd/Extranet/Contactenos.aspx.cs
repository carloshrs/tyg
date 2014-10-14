using System;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet
{
	/// <summary>
	/// Summary description for Contactenos.
	/// </summary>
	public partial class Contactenos : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];

			lblUsuario.Text= Usuario.NombreUsuario;
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

		protected void Cancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/Informes/ListaInformes.aspx");
		}

		protected void Aceptar_Click(object sender, System.EventArgs e)
		{
			ContactenosDal Contactenos = new ContactenosDal();
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];

			Contactenos.IdCliente= Usuario.IdCliente;
            Contactenos.IdUsuario = Usuario.IdUsuario;
			Contactenos.Servicio = cmbTipoContacto.SelectedValue;
			Contactenos.Comentarios = txtObservaciones.Text;
			Contactenos.MailUsuario = Usuario.EmailUsuario;
			Contactenos.Crear();
			Response.Redirect("/Informes/ListaInformes.aspx");
		}
	}
}
