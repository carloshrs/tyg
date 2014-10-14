using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Contactenos
{
	/// <summary>
	/// Summary description for AbmCliente.
	/// </summary>
    public partial class VerConsulta : Page
	{
		#region Elementos Web
		
		private bool bolFlagAlta;

		#endregion

		#region Page_Load(object sender, EventArgs e)

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
				{
					//Cargar Cliente
                    CargarConsulta(Convert.ToInt32(Request.QueryString["id"]), Convert.ToInt32(Request.QueryString["idTipo"]));
				}
			}
		}

		#endregion

		#region Web Form Designer generated code

		protected override void OnInit(EventArgs e)
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

		#region Métodos Privados

        #region CargarConsulta(int lIdConsulta, int idTipo)

        private void CargarConsulta(int lIdConsulta, int lidTpo)
		{
            UsuarioAutenticado Usuario = (UsuarioAutenticado) Session["UsuarioAutenticado"];
            ContactenosDal oContacto = new ContactenosDal();
            oContacto.Cargar(lIdConsulta, lidTpo);
            lblNombre.Text = oContacto.Nombre;
			lblEmpresa.Text = oContacto.Empresa;
            lblTelefono.Text = oContacto.Telefono;
            lblEmail.Text = oContacto.MailUsuario;
            lblAsunto.Text = oContacto.Servicio;
            lblFecha.Text = oContacto.Fecha;
            lblConsulta.Text = oContacto.Comentarios;
            if (oContacto.Leido == 0)
            {
                oContacto.Leido = 1;
                oContacto.IdUsuarioIntra = Usuario.IdUsuario;
                oContacto.UsuarioIntraLeido(lIdConsulta, lidTpo, Usuario.IdUsuario);
            }

            Usuario dalUsuario = new Usuario();
            dalUsuario.Cargar(oContacto.IdUsuarioIntra);
            lblUsuarioIntra.Text = dalUsuario.Nombre + " " + dalUsuario.Apellido;
		}

		#endregion



		
		#endregion

		#region Eventos
		

		#region btnCancelar_Click(object sender, EventArgs e)

		protected void btnCancelar_Click(object sender, EventArgs e)
		{

            Response.Redirect("ListaContactos.aspx");

		}

		#endregion


		#endregion																
	}
}