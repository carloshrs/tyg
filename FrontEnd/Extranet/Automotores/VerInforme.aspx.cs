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

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.Automotores
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class verInforme : Page
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
			AutomotoresApp oAuto = new AutomotoresApp();

			EncabezadoApp oEncabezado = new EncabezadoApp();
			oEncabezado.cargarEncabezado(Id);
			ClienteDal cliente = new ClienteDal();
			cliente.Cargar(oEncabezado.IdCliente);
			Usuario usuario = new Usuario();
			usuario.Cargar(oEncabezado.IdUsuario);

			bool cargar = oAuto.Cargar(Id);

			if (cargar)
			{
				lblNum.Text = Id.ToString();
				lblFec.Text = DateTime.Today.ToShortDateString();
				lblSolicitante.Text = cliente.RazonSocial;
				lblRef.Text = usuario.Apellido + ", " + usuario.Nombre;
				CargarForm(oAuto);
			}
			else
			{
				CargarEncabezado(oEncabezado);
			}

		}


		private void CargarEncabezado(EncabezadoApp oEncabezado)
		{
			lblNombre.Text= oEncabezado.Nombre;
			lblApellido.Text = oEncabezado.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oEncabezado.TipoDocumento);
			lblEstadoCivil.Text = LoadEstadoCivil(oEncabezado.EstadoCivil);
			lblDocumento.Text = oEncabezado.Documento;
			lblCalle.Text= oEncabezado.Calle;
			lblBarrio.Text= oEncabezado.Barrio;
			lblNro.Text= oEncabezado.Nro;
			lblPiso.Text= oEncabezado.Piso;
			lblDepto.Text= oEncabezado.Dpto;
			lblCP.Text= oEncabezado.CP;
		}


		private void CargarForm(AutomotoresApp oAuto)
		{
			lblNombre.Text= oAuto.Nombre;
			lblApellido.Text = oAuto.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oAuto.TipoDocumento);
			lblEstadoCivil.Text = LoadEstadoCivil(oAuto.EstadoCivil);
			lblDocumento.Text = oAuto.Documento;
			lblCalle.Text= oAuto.Calle;
			lblBarrio.Text= oAuto.Barrio;
			lblNro.Text= oAuto.Nro;
			lblPiso.Text= oAuto.Piso;
			lblDepto.Text= oAuto.Depto;
			lblCP.Text= oAuto.CP;
			lblProvincia.Text = CargarProvincias(oAuto.IdProvincia);
			lblLocalidad.Text = CargarLocalidades(oAuto.IdProvincia, oAuto.IdLocalidad);
			//EMPRESA
			lblNombreFantasia.Text = oAuto.NombreFantasia;
			lblRazonSocial.Text= oAuto.RazonSocial;
			lblRubro.Text= oAuto.Rubro;
			lblCUIT.Text= oAuto.Cuit;
			lblCalleEmpresa.Text= oAuto.CalleEmpresa;
			lblBarrioEmpresa.Text= oAuto.BarrioEmpresa;
			lblNroEmpresa.Text= oAuto.NroEmpresa;
			lblPisoEmpresa.Text= oAuto.PisoEmpresa;
			lblDeptoEmpresa.Text= oAuto.DptoEmpresa;
			lblCPEmpresa.Text= oAuto.CPEmpresa;
			lblTelefono.Text= oAuto.TelefonoEmpresa;
			lblLocalidadEmpresa.Text = CargarLocalidades(23, oAuto.LocalidadEmpresa);

			if (oAuto.IdTipoPersona == 1) 
			{
				pnlJuridica.Visible = false;
				pnlFisica.Visible = true;
			} 
			else 
			{
				pnlFisica.Visible = false;
				pnlJuridica.Visible = true;
			}

			// Automotores
			lblDominio.Text = oAuto.Dominio;
			lblRegistro.Text = oAuto.Registro;
			lblCalleRegistro.Text = oAuto.CalleRegistro;
			lblNroRegistro.Text = oAuto.NroRegistro;
			lblDptoRegistro.Text = oAuto.DptoRegistro;
			lblpisoRegistro.Text = oAuto.PisoRegistro;
			lblBarrioRegistro.Text = oAuto.BarrioRegistro;
			lblCPRegistro.Text = oAuto.CPRegistro;
			// Registro - Automotor
			lblProvinciaRegistro.Text = CargarProvincias(oAuto.ProvinciaRegistro);
			lblLocalidadRegistro.Text = CargarLocalidades(oAuto.ProvinciaRegistro, oAuto.LocalidadRegistro);

			// Datos Vehículo
			lblMarca.Text = oAuto.Marca;
			lblModelo.Text = oAuto.Modelo;
			lblAno.Text = oAuto.Ano;
			lblNroChasis.Text = oAuto.NroChasis;
			lblNroMotor.Text = oAuto.NroMotor;

			lblObservaciones.Text = oAuto.Observaciones;
			lblGravamenes.Text = oAuto.Gravamenes;
			lblDatosNegativos.Text = oAuto.DatosNegativos;
			lblResultados.Text = oAuto.Resultado;
		}

		private void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=2");
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

		protected void dgTitulares_PreRender(object sender, System.EventArgs e)
		{
			foreach(DataGridItem myItem in dgTitulares.Items)
			{
				if (int.Parse(myItem.Cells[1].Text) == 2)
				{
					myItem.Cells[2].Text = "J";
					myItem.Cells[3].Text = myItem.Cells[8].Text + " de " + myItem.Cells[9].Text;
					myItem.Cells[4].Text = myItem.Cells[11].Text;
					myItem.Cells[5].Text = myItem.Cells[10].Text;
				}
				else
				{
					myItem.Cells[2].Text = "F";
				}
				myItem.Cells[6].Text = myItem.Cells[6].Text + " %";
			}
		}


	}
}
