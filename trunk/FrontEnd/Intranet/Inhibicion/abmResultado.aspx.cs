using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.Gravamenes.Dal;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Inhibicion
{
	/// <summary>
	/// Summary description for abmResultado
	/// </summary>
    public partial class abmResultado : Page
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				idInforme.Value = Request.QueryString["idInforme"];
                if (Request.QueryString["idResultado"] != null)
				{
                    idResultado.Value = Request.QueryString["idResultado"];
                    CargarResultado(int.Parse(Request.QueryString["idResultado"]));
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

        private void CargarResultado(int idResultado)
		{
            InhibicionesDal oInhibicion = new InhibicionesDal();
            oInhibicion.cargarResultado(idResultado);
            txtMedida.Text = oInhibicion.Medida;
            txtDiario.Text = oInhibicion.Diario;
            txtAnio.Text = oInhibicion.Ano;
            txtFecha.Text = oInhibicion.Fecha;
            txtTipoMedida.Text = oInhibicion.TipoMedida;
            txtOrdenadoPor.Text = oInhibicion.OrdenadoPor;
            txtSecretaria.Text = oInhibicion.Secretaria;
            txtEnAutos.Text = oInhibicion.EnAutos;
            txtTipoBusqueda.Text = oInhibicion.TipoBusqueda;
            txtInmueblesGravados.Text = oInhibicion.InmueblesGravados;
            txtAnotacionesDefinitivas.Text = oInhibicion.AnotacionesDefinitivas;



		}

		protected void Aceptar_Click(object sender, EventArgs e)
		{
            InhibicionesDal oInhibicion = new InhibicionesDal();
			//bool cargar = oInformePropiedad.cargarTitular(int.Parse(idTitularInmueble.Value));

            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            oInhibicion.IdCliente = Usuario.IdCliente;
            oInhibicion.IdUsuario = Usuario.IdUsuario;
            oInhibicion.IdInforme = int.Parse(idInforme.Value);

            oInhibicion.Medida = txtMedida.Text.ToUpper();
            oInhibicion.Diario = txtDiario.Text.ToUpper();
            oInhibicion.Ano = txtAnio.Text;
            oInhibicion.Fecha = txtFecha.Text;
            oInhibicion.TipoMedida = txtTipoMedida.Text.ToUpper();
            oInhibicion.OrdenadoPor = txtOrdenadoPor.Text.ToUpper();
            oInhibicion.Secretaria = txtSecretaria.Text.ToUpper();
            oInhibicion.EnAutos = txtEnAutos.Text.ToUpper();
            oInhibicion.TipoBusqueda = txtTipoBusqueda.Text.ToUpper();
            oInhibicion.InmueblesGravados = txtInmueblesGravados.Text.ToUpper();
            oInhibicion.AnotacionesDefinitivas = txtAnotacionesDefinitivas.Text.ToUpper();


			if(Request.QueryString["idResultado"] != null)
                oInhibicion.ModificarResultado(int.Parse(Request.QueryString["idResultado"]));
			else
                oInhibicion.CrearResultado();

			Page.RegisterClientScriptBlock("cerrar", "<script>window.close();</script>");
		}


		protected void Cancelar_Click(object sender, EventArgs e)
		{
			Page.RegisterClientScriptBlock("cerrar", "<script>window.close();</script>");
		}

    }
}
