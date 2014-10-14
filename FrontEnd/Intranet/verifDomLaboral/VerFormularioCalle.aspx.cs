using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Verificaciones.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.VerifDomLaboral
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class VerFormularioCalle : Page
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
		private int IdInforme;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{	
					IdInforme = int.Parse(Request.QueryString["id"]);
					LoadInforme(IdInforme);
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
			VerifDomLaboralApp oVerifDom = new VerifDomLaboralApp();

			EncabezadoApp oEncabezado = new EncabezadoApp();
			oEncabezado.cargarEncabezado(Id);
			ClienteDal cliente = new ClienteDal();
			cliente.Cargar(oEncabezado.IdCliente);
			Usuario usuario = new Usuario();
			usuario.Cargar(oEncabezado.IdUsuario);
			bool cargar = oVerifDom.cargarVerifDomLaboral(Id);

			if (cargar)
			{
				lblNum.Text = Id.ToString();
				lblFec.Text = DateTime.Today.ToShortDateString();
				lblSolicitante.Text = cliente.RazonSocial;
				lblRef.Text = usuario.Apellido + ", " + usuario.Nombre;
				CargarForm(oVerifDom);
			}
			else
			{
				CargarEncabezado(oEncabezado);
			}

		}


		private void CargarEncabezado(EncabezadoApp oVerifDom)
		{
			lblNombre.Text= oVerifDom.Nombre;
			lblApellido.Text = oVerifDom.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oVerifDom.TipoDocumento);
			lblDocumento.Text = oVerifDom.Documento;
			lblEstadoCivil.Text = LoadEstadoCivil(oVerifDom.EstadoCivil);
			lblNombreFantasia.Text = oVerifDom.NombreFantasia;
			lblRazonSocial.Text= oVerifDom.RazonSocial;
			lblRubro.Text= oVerifDom.Rubro;
			lblCUIT.Text= oVerifDom.Cuit;
			lblCalle.Text= oVerifDom.Calle;
			lblBarrio.Text= oVerifDom.Barrio;
			lblNro.Text= oVerifDom.Nro;
			lblPiso.Text= oVerifDom.Piso;
			lblDpto.Text= oVerifDom.Dpto;
			lblCP.Text= oVerifDom.CP;
		}


		private void CargarForm(VerifDomLaboralApp oVerifDom)
		{
			lblNombre.Text= oVerifDom.Nombre;
			lblApellido.Text = oVerifDom.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oVerifDom.TipoDocumento);
			lblDocumento.Text = oVerifDom.Documento;
			lblEstadoCivil.Text = LoadEstadoCivil(oVerifDom.EstadoCivil);
			lblNombreFantasia.Text = oVerifDom.NombreFantasia;
			lblRazonSocial.Text= oVerifDom.RazonSocial;
			lblRubro.Text= oVerifDom.Rubro;
			lblCUIT.Text= oVerifDom.Cuit;
			lblCalle.Text= oVerifDom.Calle;
			lblBarrio.Text= oVerifDom.Barrio;
			lblNro.Text= oVerifDom.Nro;
			lblPiso.Text= oVerifDom.Piso;
			lblDpto.Text= oVerifDom.Depto;
			lblCP.Text= oVerifDom.CP;
			lblTelefono.Text= oVerifDom.Telefono;
			lblLocalidad.Text = CargarLocalidades(35, oVerifDom.IdLocalidad);
			lblFecha.Text= oVerifDom.Fecha;
			lblOcupacion.Text = oVerifDom.Ocupacion;
			lblCargoInformo.Text = oVerifDom.Cargo;
			lblAntiguedad.Text = oVerifDom.Antiguedad;
			lblFechaFinalizacion.Text = oVerifDom.FechaFinalizacion;
			lblSueldo.Text = oVerifDom.Sueldo;
			lblAFavor.Text = oVerifDom.AFavor;
			lblLugarDeclarado.Text = (oVerifDom.TrabajaLugar == 1)?  "Si" : "No";
			lblPermanente.Text = (oVerifDom.Permanente == 1)?  "Si" : "No";
			lblContratado.Text = (oVerifDom.Contratado == 1)?  "Si" : "No";
			lblEmbargos.Text = (oVerifDom.Embargos == 1)?  "Si" : "No";
			lblUbicacion.Text = CargarTipoCampo(oVerifDom.Ubicacion, 3);
			lblZona.Text = CargarTipoCampo(oVerifDom.Zona, 9);
			lblInformo.Text = oVerifDom.Informo;
			lblCargo.Text = oVerifDom.Cargo;
			lblNombreVecino.Text = oVerifDom.NombreVecino;
			lblDomicilioVecino.Text = oVerifDom.DomicilioVecino;
			lblConoceVecino.Text = oVerifDom.ConoceVecino;
			lblObservaciones.Text = oVerifDom.Observaciones;
		}

		private void Cancelar_Click(object sender, EventArgs e)
		{
//			if(idReferencia.Value != null) 
//			{
//				if (int.Parse(idReferencia.Value) > 0) Response.Redirect("/Extranet/Referencias/altaReferencia.aspx?IdReferencia=" + idReferencia.Value);
//				else Response.Redirect("ListaInformes.aspx");
//			} 				
//			else Response.Redirect("ListaInformes.aspx");
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=" + Request.QueryString["idTipo"]);
		}




//		private void CambioPaneles(int Informe) 
//		{
//			pnlTitulo.Visible = false;
//			pnlParticulares.Visible= false;
//			pnlAutomotor.Visible = false;
//			pnlGravamenes.Visible = false;
//			pnlPropiedad.Visible= false;
//			pnlAmbiental.Visible = false;
//			pnlDomLaboral.Visible = false;
//			pnlDomicilioParticular.Visible = false;
//			pnlParticulares.Visible = false;
//			pnlCatastral.Visible = false;
//			pnlFoto.Visible = false;
//			pnlUrgencia.Visible= false;
//			switch(Informe)
//			{
//				case 1: // Propiedad
//					pnlPropiedad.Visible= true;
//					pnlUrgencia.Visible= true;
//					break;
//				case 2: // Automotor
//					pnlAutomotor.Visible = true;
//					break;
//				case 3: // Grav�menes
//					pnlGravamenes.Visible = true;
//					break;
//				case 4: // Ambiental
//					pnlParticulares.Visible = true;
//					pnlAmbiental.Visible = true;
//					break;
//				case 5: // Dom Particular
//					pnlParticulares.Visible = true;
//					pnlDomicilioParticular.Visible = true;
//					pnlFoto.Visible = true;
//					break;
//				case 6:
//					lblInforme.Text = "Verificaci�n de Domicilio Laboral";
//					pnlParticulares.Visible = true;
//					pnlDomLaboral.Visible = true;
//					pnlFoto.Visible = true;
//					break;
//				case 7:
//					lblInforme.Text = "Verificaci�n de Domicilio Laboral";
//					pnlParticulares.Visible = true;
//					pnlDomLaboral.Visible = true;
//					pnlFoto.Visible = true;
//					break;
//				case 8:
//					lblInforme.Text = "Verificaci�n Especial";
//					pnlDomLaboral.Visible = true;
//					pnlParticulares.Visible = true;
//					break;
//				case 9:
//					lblTitulo.Text = "Registro P�blico de Comercio";
//					pnlTitulo.Visible = true;
//					break;
//				case 10: // Busqueda Automotor
//					pnlParticulares.Visible = true;
//					break;
//				case 11: // Informe Propiedad Otras Provincias
//					lblTitulo.Text = "Informe Propiedad Otras Provincias";
//					pnlTitulo.Visible = true;
//					break;
//				case 12: // Informe Catastral
//					pnlCatastral.Visible = true;
//					break;
//				case 13: // B�squeda Propiedad
//					pnlParticulares.Visible = true;
//					pnlUrgencia.Visible= true;
//					break;
//			}
//		}

//		private void SelectTipoPropiedad(int idTipo)
//		{
//			switch(idTipo)
//			{
//				case 1: 
//					pnlDominioLegEspecial.Visible = false;
//					lblTipoPropiedad.Text = "Nro. de Matricula";
//					break;
//				case 2: 
//					lblTipoPropiedad.Text = "Dominio";
//					pnlDominioLegEspecial.Visible = true;
//					break;
//				case 3: 
//					lblTipoPropiedad.Text = "Nro. de Legajo Especial";
//					pnlDominioLegEspecial.Visible = true;
//					break;
//			}
//		}

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


		private string LoadTipoPropiedad(int idTipoPropiedad)
		{
			UtilesApp Tipos = new UtilesApp();
			string TipoPropiedad= "";
			DataTable myTb;
			myTb = Tipos.TraerTipoPropiedad();
			foreach(DataRow myRow in myTb.Rows)
			{
				if(idTipoPropiedad.ToString() == myRow[0].ToString())
				{
					TipoPropiedad = myRow[1].ToString();
				}
			}
			//SelectTipoPropiedad(idTipoPropiedad);	
			return TipoPropiedad;
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


		private String CargarTipoCampo(int id, int idTipo)
		{
			VerifDomComercialApp oVerif = new VerifDomComercialApp();
			DataTable myTb;
			string TipoCampo = "";

			myTb = oVerif.TraerCampo(idTipo);
			foreach(DataRow myRow in myTb.Rows)
			{
				if(id.ToString() == myRow[0].ToString())
				{
					TipoCampo = myRow[1].ToString();
				}
			}
			return TipoCampo;
		}

	}
}
