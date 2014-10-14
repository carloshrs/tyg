using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Seguridad.Admin.Seguridad
{
	/// <summary>
	/// Summary description for ABMRol.
	/// </summary>
	public partial class ABMRol : Page
	{
		private int intIdRol;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				try
				{
					intIdRol = int.Parse(Request.QueryString["IdRol"]);
					CargarRol(intIdRol);

				}
				catch
				{
					intIdRol = -1;
				}
				ViewState["IdRol"] = intIdRol.ToString();
			}
			else
				intIdRol = int.Parse(ViewState["IdRol"].ToString());		
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

		protected void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("ListaRoles.aspx");

		}

		protected void btnAceptar_Click(object sender, EventArgs e)
		{
			Rol rol = new Rol();
			if (intIdRol != -1)
			{
				rol.Cargar(intIdRol);
				rol.Nombre = txtNombre.Text;
				rol.Descripcion = txtDescripcion.Text;
				rol.Automatico = chkAutomatico.Checked;
				rol.Extranet = chkExtranet.Checked;
				rol.Modificar();

			}
			else
			{
				rol.Nombre = txtNombre.Text;
				rol.Descripcion = txtDescripcion.Text;
				rol.Automatico = chkAutomatico.Checked;
				rol.Extranet = chkExtranet.Checked;
				rol.Crear();

			}
			if (((Button)sender).Text == "Aceptar")
				Response.Redirect("ListaRoles.aspx");
			else
				Response.Redirect("FuncionAddRol.aspx?IdRol=" + rol.Id.ToString()+ "&From=abm");
		}

		private void CargarRol(int lIdRol)
		{
			Rol rol = new Rol();
			rol.Cargar(lIdRol);
			txtNombre.Text = rol.Nombre;
			txtDescripcion.Text = rol.Descripcion;
			chkAutomatico.Checked = rol.Automatico;
			chkExtranet.Checked = rol.Extranet;

		}

	}
}
