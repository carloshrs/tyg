using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Automotores.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Automotores
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class verInformeCalle : Page
	{
		protected RequiredFieldValidator reqNombre;
		protected RequiredFieldValidator reqApellido;
		protected DropDownList cmbEstadoCivil;
		protected DropDownList cmbTipoDocumento;
		protected RequiredFieldValidator RequiredFieldValidator2;
		protected RequiredFieldValidator RequiredFieldValidator3;
		protected RequiredFieldValidator RequiredFieldValidator6;
		protected RequiredFieldValidator RequiredFieldValidator7;
		protected DropDownList cmbProvincia;
		protected DropDownList cmbLocalidad;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.Label lblHabita;
		protected System.Web.UI.WebControls.Label lblAntiguedad;
		protected System.Web.UI.WebControls.Label lblTelefonoAlt;
		protected System.Web.UI.WebControls.Label lblMonto;
		protected System.Web.UI.WebControls.Label lblVencimiento;
		protected System.Web.UI.WebControls.Label lblEnviar;
		protected System.Web.UI.WebControls.Label lblTipoVivienda;
		protected System.Web.UI.WebControls.Label lblEstadoConservacion;
		protected System.Web.UI.WebControls.Label lblTipoConstruccion;
		protected System.Web.UI.WebControls.Label lblTipoZona;
		protected System.Web.UI.WebControls.Label lblTipoCalle;
		protected System.Web.UI.WebControls.Label lblInteresado;
		protected System.Web.UI.WebControls.Label lblAccesoDomicilio;
		protected System.Web.UI.WebControls.Label lblInformo;
		protected System.Web.UI.WebControls.Label lblRelacion;
		protected System.Web.UI.WebControls.Label lblNombreVecino;
		protected System.Web.UI.WebControls.Label lblDomicilioVecino;
		protected System.Web.UI.WebControls.Label lblConoceVecino;
		protected System.Web.UI.WebControls.Label lblPlanoA;
		protected System.Web.UI.WebControls.Label lblPlanoB;
		protected System.Web.UI.WebControls.Label lblPlanoC;
		protected System.Web.UI.WebControls.Label lblPlanoD;
		private int IdInforme;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{	
					IdInforme = int.Parse(Request.QueryString["id"]);
					LoadInforme(IdInforme);
					ListarTitulares(int.Parse(Request.QueryString["id"]));
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

		private void LoadInforme(int Id)
		{
			EncabezadoApp oEncabezado = new EncabezadoApp();
			oEncabezado.cargarEncabezado(Id);
			ClienteDal cliente = new ClienteDal();
			cliente.Cargar(oEncabezado.IdCliente);
			Usuario usuario = new Usuario();
			usuario.Cargar(oEncabezado.IdUsuario);

			lblNum.Text = Id.ToString();
			lblFec.Text = DateTime.Today.ToShortDateString();
			lblSolicitante.Text = cliente.RazonSocial;
			lblRef.Text = usuario.Apellido + ", " + usuario.Nombre;
			CargarEncabezado(oEncabezado);

		}


		private void CargarEncabezado(EncabezadoApp oEncabezado)
		{
			// Automotores
			lblDominio.Text = oEncabezado.Dominio;
			lblRegistro.Text = oEncabezado.Registro;
			lblCalleRegistro.Text = oEncabezado.CalleRegistro;
			lblNroRegistro.Text = oEncabezado.NroRegistro;
			lblDptoRegistro.Text = oEncabezado.DptoRegistro;
			lblpisoRegistro.Text = oEncabezado.PisoRegistro;
			lblBarrioRegistro.Text = oEncabezado.BarrioRegistro;
			lblCPRegistro.Text = oEncabezado.CPRegistro;
			// Registro - Automotor
			if (oEncabezado.Registro != "") 
			{
				lblProvinciaRegistro.Text = CargarProvincias(oEncabezado.ProvinciaRegistro);
				lblLocalidadRegistro.Text = CargarLocalidades(oEncabezado.ProvinciaRegistro, oEncabezado.LocalidadRegistro);
			}
			lblObservaciones.Text = oEncabezado.Observaciones;
		}


		private void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=2");
		}



		private string CargarProvincias(int IdProvincia)
		{
			UtilesApp Tipos = new UtilesApp();
			string Provincia= "";
			DataTable myTb;
			myTb = Tipos.TraerProvincias();
			foreach(DataRow myRow in myTb.Rows)
			{
				if(IdProvincia == int.Parse(myRow[0].ToString()))
				{
					Provincia = myRow[1].ToString();
				}
			}
			return Provincia;
		}

		private String CargarLocalidades(int idProvincia, int IdLocalidad)
		{
			UtilesApp Tipos = new UtilesApp();
			DataTable myTb;
			string Localidad = "";
			myTb = Tipos.TraerLocalidades(idProvincia);
			foreach(DataRow myRow in myTb.Rows)
			{
				if(IdLocalidad.ToString() == myRow[0].ToString())
				{
					Localidad = myRow[1].ToString();
				}
			}
			return Localidad;
		}

		private void ListarTitulares(int idInforme)
		{
			AutomotoresApp objAutomotores = new AutomotoresApp();
			dgTitulares.DataSource = objAutomotores.TraerTitulares(idInforme);
			dgTitulares.DataBind();
		}


	}
}
