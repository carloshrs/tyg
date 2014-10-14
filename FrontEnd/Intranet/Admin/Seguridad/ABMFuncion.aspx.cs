using System;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Seguridad.Admin.Seguridad
{
	/// <summary>
	/// Summary description for ABMFuncion.
	/// </summary>
	public partial class ABMFuncion : System.Web.UI.Page
	{
		private int intIdFuncion;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				try
				{
					intIdFuncion = int.Parse(Request.QueryString["IdFuncion"]);
					CargarFuncion(intIdFuncion);

				}
				catch
				{
					intIdFuncion = -1;
				}
				ViewState["IdFuncion"] = intIdFuncion.ToString();
			}
			else
				intIdFuncion = int.Parse(ViewState["IdFuncion"].ToString());
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

		protected void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ListaFunciones.aspx");

		}

		protected void btnAceptar_Click(object sender, System.EventArgs e)
		{
			Funcion funcion = new Funcion();
			if (intIdFuncion != -1)
			{
				funcion.Cargar(intIdFuncion);
				funcion.Nombre = txtNombre.Text;
				funcion.UrlKey = txtUrl.Text;
				funcion.Modificar();

			}
			else
			{
				funcion.Nombre = txtNombre.Text;
				funcion.UrlKey = txtUrl.Text;
				funcion.Crear();

			}
			Response.Redirect("ListaFunciones.aspx");
		}

		private void CargarFuncion(int lIdFuncion)
		{
			Funcion funcion = new Funcion();
			funcion.Cargar(lIdFuncion);
			txtNombre.Text = funcion.Nombre;
			txtUrl.Text = funcion.UrlKey;

		}


	}
}
