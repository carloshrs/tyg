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

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.VerifDomComercial
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
		private int IdInforme;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{	
					IdInforme = int.Parse(Request.QueryString["id"]);
					LoadInforme(IdInforme);
					CargarCampos(lblCaractZona,1);
					CargarCampos(lblDocumentoVerificado,2);
					CargarCampos(lblUbicacion,3);
					CargarCampos(lblTamanio,4);
					CargarCampos(lblInmueble,5);
					CargarCampos(lblEstado,6);
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
			VerifDomComercialApp oInformeComercial = new VerifDomComercialApp();

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
            oEncabezado.Leido = 1;
            oEncabezado.CambiarLeido(Id);
            oEncabezado.Estado = 2;
            oEncabezado.CambiarEstado(Id);
		}

		private void CargarEncabezado(EncabezadoApp oInformeComercial)
		{
			lblNombre.Text = oInformeComercial.Nombre;
			lblApellido.Text = oInformeComercial.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oInformeComercial.TipoDocumento);
			lblDocumento.Text= oInformeComercial.Documento;
			lblTelefono.Text = oInformeComercial.TelefonoEmpresa;
			if(oInformeComercial.ConFoto == 1) lblConFoto.Visible = true;


			if (oInformeComercial.IdTipoPersona == 1) 
			{
				pnlDomComercial.Visible = false;
				pnlFisica.Visible = true;
				lblNombreFantasia.Text= oInformeComercial.NombreFantasia;
				lblRazonSocial.Text= oInformeComercial.RazonSocial;
				lblRubro.Text= oInformeComercial.Rubro;
				lblCuit.Text= oInformeComercial.Cuit;
                lblCalle.Text = oInformeComercial.CalleEmpresa;
                lblBarrio.Text = oInformeComercial.BarrioEmpresa;
                lblNro.Text = oInformeComercial.NroEmpresa;
                lblPiso.Text = oInformeComercial.PisoEmpresa;
                lblDepto.Text = oInformeComercial.DptoEmpresa;
                lblCP.Text = oInformeComercial.CPEmpresa;
                lblLocalidad.Text = CargarLocalidades(23, oInformeComercial.Localidad);
			} 
			else 
			{
				pnlDomComercial.Visible = true;
				pnlFisica.Visible = false;
				lblNombreFantasiaEmp.Text= oInformeComercial.NombreFantasia;
				lblRazonSocialEmp.Text= oInformeComercial.RazonSocial;
				lblRubroEmp.Text= oInformeComercial.Rubro;
				lblCuitEmp.Text= oInformeComercial.Cuit;
                lblCalleEmp.Text = oInformeComercial.CalleEmpresa;
                lblBarrioEmp.Text = oInformeComercial.BarrioEmpresa;
                lblNroEmp.Text = oInformeComercial.NroEmpresa;
                lblPisoEmp.Text = oInformeComercial.PisoEmpresa;
                lblDeptoEmp.Text = oInformeComercial.DptoEmpresa;
                lblCPEmp.Text = oInformeComercial.CPEmpresa;
                lblLocalidadEmp.Text = CargarLocalidades(23, oInformeComercial.Localidad);
			}

		}


		private void CargarForm(VerifDomComercialApp oInformeComercial)
		{
			lblNombre.Text = oInformeComercial.Nombre;
			lblApellido.Text = oInformeComercial.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oInformeComercial.TipoDocumento);
			lblDocumento.Text= oInformeComercial.Documento;
			lblNombreFantasia.Text= oInformeComercial.NombreFantasia;
			lblRazonSocial.Text= oInformeComercial.RazonSocial;
			lblRubro.Text= oInformeComercial.Rubro;
			lblCuit.Text= oInformeComercial.Cuit;
			lblCalle.Text = oInformeComercial.Calle;
			lblBarrio.Text = oInformeComercial.Barrio;
			lblProvincia.Text = CargarProvincias(oInformeComercial.IdProvincia);
			lblLocalidad.Text = CargarLocalidades(oInformeComercial.IdProvincia, oInformeComercial.IdLocalidad);


			lblNro.Text= oInformeComercial.Nro;
			lblPiso.Text= oInformeComercial.Piso;
			lblDepto.Text= oInformeComercial.Depto;
			lblCP.Text= oInformeComercial.CP;
			lblTelefono.Text= oInformeComercial.Telefono;
			lblProvinciaEmp.Text = CargarProvincias(oInformeComercial.ProvinciaEmpresa);
			lblLocalidadEmp.Text = CargarLocalidades(oInformeComercial.ProvinciaEmpresa, oInformeComercial.LocalidadEmpresa);
			lblFecha.Text= oInformeComercial.Fecha;
			lblOcupacion.Text = oInformeComercial.Ocupacion;
			lblCategoria.Text = oInformeComercial.Categoria;
			lblMovComercial.Text = oInformeComercial.MovComercial;
			lblActividad.Text = oInformeComercial.Actividad;
			lblRubros.Text = oInformeComercial.RubrosAdicionales;
			lblHorario.Text = oInformeComercial.Horario;
			lblAntiguedad.Text = oInformeComercial.Antiguedad;
			lblCantidad.Text = oInformeComercial.CantPersonal;
			lblPublicidad.Text = (oInformeComercial.Publicidad == 1) ? "Si tiene": "No tiene";
			lblVigilancia.Text = (oInformeComercial.Vigilancia == 1) ? "Si tiene": "No tiene";
			lblInicioActividades.Text = oInformeComercial.Actividad;
			lblIVA.Text = oInformeComercial.CatIVA;
			lblInformo.Text = oInformeComercial.Informo;
			lblCargo.Text = oInformeComercial.Cargo;
			lblNombreVecino.Text = oInformeComercial.NombreVecino;
			lblDomicilioVecino.Text = oInformeComercial.DomicilioVecino;
			lblConoce.Text = oInformeComercial.ConoceVecino;
			lblObservaciones.Text = oInformeComercial.Observaciones;
			lblPlanoA.Text = oInformeComercial.PlanoA;
			lblPlanoB.Text = oInformeComercial.PlanoB;
			lblPlanoC.Text = oInformeComercial.PlanoC;
			lblPlanoD.Text = oInformeComercial.PlanoD;

		}

		private void CargarCampos(Label campo,int idTipo)
		{
			//campo.Items.Clear();
			VerifDomParticularApp oVerifDom = new VerifDomParticularApp();
			DataTable dtTraerCampo = oVerifDom.TraerCampo(idTipo);
			string tabla = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"1\" class=\"text\">";

			foreach(DataRow myRow in dtTraerCampo.Rows)
			{
				tabla = tabla + "<tr><td><img src=\"/img/caja-check.gif\" border=\"0\"></td><td>&nbsp;" + myRow[1].ToString() + "</td></tr>";
			}
			tabla = tabla + "</table>";
			campo.Text = tabla;
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
