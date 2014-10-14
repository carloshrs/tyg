using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.Busquedas.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.Verificaciones.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.BusquedaAutomotor
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
		protected System.Web.UI.WebControls.Label lblOcupacion;
		protected System.Web.UI.WebControls.Label lblCargo;
		private int IdInforme;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{	
					IdInforme = int.Parse(Request.QueryString["id"]);
					LoadVerifBusqueda(int.Parse(Request.QueryString["id"]));
					ListarDominios(int.Parse(Request.QueryString["id"]));
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

		private void LoadVerifBusqueda(int Id)
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

			idReferencia.Value = (0).ToString();
			oEncabezado.cargarEncabezado(Id);
			CargarEncabezado(oEncabezado);

		}


		private void CargarEncabezado(EncabezadoApp oVerif)
		{
			lblNombre.Text= oVerif.Nombre;
			lblApellido.Text = oVerif.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oVerif.TipoDocumento);
			lblEstadoCivil.Text = LoadEstadoCivil(oVerif.EstadoCivil);
			lblDocumento.Text = oVerif.Documento;
			//EMPRESA
			lblNombreFantasia.Text = oVerif.NombreFantasia;
			lblRazonSocial.Text= oVerif.RazonSocial;
			lblRubro.Text= oVerif.Rubro;
			lblCUIT.Text= oVerif.Cuit;
			lblCalle.Text= oVerif.CalleEmpresa;
			lblBarrio.Text= oVerif.BarrioEmpresa;
			lblNro.Text= oVerif.NroEmpresa;
			lblPiso.Text= oVerif.PisoEmpresa;
			lblDpto.Text= oVerif.DptoEmpresa;
			lblCP.Text= oVerif.CPEmpresa;
			lblTelefono.Text= oVerif.TelefonoEmpresa;
			lblLocalidad.Text = CargarLocalidades(23, oVerif.LocalidadEmpresa);

			if (oVerif.IdTipoPersona == 1) 
			{
				pnlJuridica.Visible = false;
				pnlFisica.Visible = true;
			} 
			else 
			{
				pnlFisica.Visible = false;
				pnlJuridica.Visible = true;
			}

		}


		private void CargarForm(BusquedaAutomotorApp oBusquedaAuto)
		{
			CultureInfo myInfo = new CultureInfo("es-AR");

			lblNombre.Text= oBusquedaAuto.Nombre;
			lblApellido.Text = oBusquedaAuto.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oBusquedaAuto.IdTipoDoc);
			lblEstadoCivil.Text = LoadEstadoCivil(oBusquedaAuto.EstadoCivil);
			lblDocumento.Text = oBusquedaAuto.NroDoc.ToString();
			lblObservaciones.Text = oBusquedaAuto.Observaciones;
			lblResultado.Text = oBusquedaAuto.Resultado;
			//EMPRESA
			lblNombreFantasia.Text = oBusquedaAuto.NombreFantasia;
			lblRazonSocial.Text= oBusquedaAuto.RazonSocial;
			lblRubro.Text= oBusquedaAuto.Rubro;
			lblCUIT.Text= oBusquedaAuto.Cuit;
			lblCalle.Text= oBusquedaAuto.CalleEmpresa;
			lblBarrio.Text= oBusquedaAuto.BarrioEmpresa;
			lblNro.Text= oBusquedaAuto.NroEmpresa;
			lblPiso.Text= oBusquedaAuto.PisoEmpresa;
			lblDpto.Text= oBusquedaAuto.DptoEmpresa;
			lblCP.Text= oBusquedaAuto.CPEmpresa;
			lblTelefono.Text= oBusquedaAuto.TelefonoEmpresa;
			lblLocalidad.Text = CargarLocalidades(23, oBusquedaAuto.LocalidadEmpresa);

			if (oBusquedaAuto.IdTipoPersona == 1) 
			{
				pnlJuridica.Visible = false;
				pnlFisica.Visible = true;
			} 
			else {
				pnlFisica.Visible = false;
				pnlJuridica.Visible = true;
			}
		}


		private void ListarDominios(int idInforme)
		{
			BusquedaAutomotorApp objBusquedaAutomotor = new BusquedaAutomotorApp();
			dgDominios.DataSource = objBusquedaAutomotor.TraerDominios(idInforme);
			dgDominios.DataBind();
		}

		private void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=" + Request.QueryString["idTipo"]);
		}





		private string LoadEstadoCivil(int EstadoCivil)
		{
			UtilesApp Tipos = new UtilesApp();
			string Estado = "";
			DataTable myTb;
			myTb = Tipos.TraerEstadoCivil();
			foreach(DataRow myRow in myTb.Rows)
			{
				if(EstadoCivil.ToString() == myRow[0].ToString())
				{
					Estado= myRow[1].ToString();			
				}
			}
			return Estado;
		}

		private string LoadTipoDNI(int DNI)
		{
			UtilesApp Tipos = new UtilesApp();
			string TipoDNI="";
			DataTable myTb;
			myTb = Tipos.TraerTipoDocumento();
			foreach(DataRow myRow in myTb.Rows)
			{
				if(DNI.ToString() == myRow[0].ToString())
				{
					TipoDNI= myRow[1].ToString();			
				}
			}
			return TipoDNI;
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


	}
}
