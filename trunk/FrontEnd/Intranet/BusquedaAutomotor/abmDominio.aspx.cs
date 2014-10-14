using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.Busquedas.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.BusquedaAutomotor
{
	/// <summary>
	/// Summary description for abmTitular.
	/// </summary>
	public partial class abmTitular : Page
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				idInforme.Value = Request.QueryString["idInforme"];
				if(Request.QueryString["idDominio"] != null)
				{
					idDominio.Value = Request.QueryString["idDominio"];
					CargarDominio(int.Parse(Request.QueryString["idDominio"]));
				}
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

		private void CargarDominio(int idDominio)
		{
			BusquedaAutomotorApp objBusquedaAutomotor = new BusquedaAutomotorApp();
			objBusquedaAutomotor.cargarDominio(idDominio);
			txtDominio.Text = objBusquedaAutomotor.Dominio;
			txtRegistro.Text = objBusquedaAutomotor.Registro;
		}

		protected void Aceptar_Click(object sender, EventArgs e)
		{
			BusquedaAutomotorApp objBusquedaAutomotor = new BusquedaAutomotorApp();
			//bool cargar = oInformePropiedad.cargarTitular(int.Parse(idTitularInmueble.Value));

            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            objBusquedaAutomotor.IdCliente = Usuario.IdCliente;
            objBusquedaAutomotor.IdUsuario = Usuario.IdUsuario;
			objBusquedaAutomotor.IdInforme = int.Parse(idInforme.Value);
			objBusquedaAutomotor.Dominio = txtDominio.Text;
			objBusquedaAutomotor.Registro = txtRegistro.Text;
			
			if(Request.QueryString["idDominio"] != null)
				objBusquedaAutomotor.ModificarDominio(int.Parse(Request.QueryString["idDominio"]));
			else
				objBusquedaAutomotor.CrearDominio();

			Page.RegisterClientScriptBlock("cerrar", "<script>window.close();</script>");
		}


		protected void Cancelar_Click(object sender, EventArgs e)
		{
			Page.RegisterClientScriptBlock("cerrar", "<script>window.close();</script>");
		}

		

	}
}
