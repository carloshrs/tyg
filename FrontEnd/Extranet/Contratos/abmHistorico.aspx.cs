using System;
using System.Data;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Contratos.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.Contratos
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class abmHistorico : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Provincia;
		private int idContrato;
		private int id=0;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Request.QueryString["idContrato"] != null)
			{	
				idContrato = int.Parse(Request.QueryString["idContrato"]);
				if(Request.QueryString["id"] != null)
				{	
					id = int.Parse(Request.QueryString["id"]);
				}
				if (!Page.IsPostBack) 
				{
					if (id == 0) 
					{
						lblFecha.Text= DateTime.Today.ToShortDateString();
						Observaciones.Text = "";
					} 
					else 
					{
						ContratoAPP historico = new ContratoAPP();
						string fecha = "";
						string observaciones = "";
						historico.CargarHistorico(id, ref fecha, ref observaciones);
						lblFecha.Text= fecha;
						Observaciones.Text = observaciones;
					}
				}
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			// Put user code to initialize the page here
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


		protected void Aceptar_Click(object sender, System.EventArgs e)
		{
			ContratoAPP historico = new ContratoAPP();
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			if (id == 0) 
			{
				historico.CrearHistorico(Observaciones.Text.ToString(), idContrato, Usuario.IdUsuario);
			} 
			else {
				historico.ModificarHistorico(id, Observaciones.Text.ToString(), idContrato, Usuario.IdUsuario);
			}
			Page.RegisterClientScriptBlock("onClick", "<script>window.opener.location.href='Historial.aspx?Id=" + idContrato + "';window.close();</script>"); 

		}


	}
}
