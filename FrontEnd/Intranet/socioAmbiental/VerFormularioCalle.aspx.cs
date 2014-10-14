using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Informes.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.socioAmbiental
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
            EncabezadoApp oEncabezado = new EncabezadoApp();
			oEncabezado.cargarEncabezado(Id);
			ClienteDal cliente = new ClienteDal();
			cliente.Cargar(oEncabezado.IdCliente);
			Usuario usuario = new Usuario();
			usuario.Cargar(oEncabezado.IdUsuario);
            lblNum.Text = Id.ToString();
            lblFec.Text = DateTime.Today.ToShortDateString();
            lblSolicitante.Text = cliente.RazonSocial;
            
            if (oEncabezado.idReferencia != 0)
                lblRef.Text = oEncabezado.NombreReferencia.ToUpper();
            else if (oEncabezado.UsuarioCliente != "")
                lblRef.Text = oEncabezado.UsuarioCliente.ToUpper();
            else
                lblRef.Text = usuario.Apellido.ToUpper() + ", " + usuario.Nombre.ToUpper();

            CargarEncabezado(oEncabezado);
            oEncabezado.Leido = 1;
            oEncabezado.CambiarLeido(Id);
		}


		private void CargarEncabezado(EncabezadoApp oVerifDom)
		{
			lblNombre.Text= oVerifDom.Nombre;
			lblApellido.Text = oVerifDom.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oVerifDom.TipoDocumento);
			lblEstadoCivil.Text = LoadEstadoCivil(oVerifDom.EstadoCivil);
			lblDocumento.Text = oVerifDom.Documento;
			lblCalle.Text= oVerifDom.Calle;
			lblBarrio.Text= oVerifDom.Barrio;
			lblNro.Text= oVerifDom.Nro;
			lblPiso.Text= oVerifDom.Piso;
			lblDepto.Text= oVerifDom.Dpto;
			lblCP.Text= oVerifDom.CP;
            lblTelefono.Text = oVerifDom.AMBTelefono;
            lblLocalidad.Text = CargarLocalidades(oVerifDom.Provincia, oVerifDom.Localidad);
            lblObsSolic.Text = oVerifDom.Comentarios;
            if( oVerifDom.AMBEMail != "" )
                lblObsEMail.Text = "(e-mail: " + oVerifDom.AMBEMail + ")";
		}


		private void CargarForm(InformeAmbiental oInfAmb)
		{
			/*lblNombre.Text= oInfAmb.Nombre;
			lblApellido.Text = oInfAmb.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oInfAmb.TipoDocumento);
			lblEstadoCivil.Text = LoadEstadoCivil(oInfAmb.EstadoCivil);
			lblDocumento.Text = oInfAmb.Documento;
			lblCalle.Text= oInfAmb.Calle;
			lblBarrio.Text= oInfAmb.Barrio;
			lblNro.Text= oInfAmb.Nro;
			lblPiso.Text= oInfAmb.Piso;
			lblDepto.Text= oInfAmb.Depto;
			lblCP.Text= oInfAmb.CP;
			lblTelefono.Text= oInfAmb.Telefono;
			lblLocalidad.Text = CargarLocalidades(35, oInfAmb.Localidad);*/

			//lblFecha.Text= oInfAmb.Fecha;
			//lblHabita.Text = oInfAmb.Habita;
			/*lblAntiguedad.Text = oInfAmb.Antiguedad;
			lblMonto.Text = oInfAmb.MontoAlquiler;
			lblVencimiento.Text = oInfAmb.Vencimiento;
			lblTelefonoAlt.Text = oInfAmb.TelAlt;*/
			//lblEnviar.Text = oInfAmb.Enviar;
			/*lblTipoVivienda.Text = CargarTipoCampo(int.Parse(oInfAmb.TipoVivienda), 7);
			lblEstadoConservacion.Text = CargarTipoCampo(int.Parse(oInfAmb.EstadoCons), 6);
			lblTipoConstruccion.Text = CargarTipoCampo(int.Parse(oInfAmb.TipoConstruccion), 8);
			lblTipoZona.Text = CargarTipoCampo(int.Parse(oInfAmb.TipoZona), 9);
			lblTipoCalle.Text = CargarTipoCampo(int.Parse(oInfAmb.TipoCalle), 10);
			lblInteresado.Text = CargarTipoCampo(int.Parse(oInfAmb.Interesado), 11);
			lblAccesoDomicilio.Text = oInfAmb.AccesoDomicilio;*/
			/*lblInformo.Text = oInfAmb.Informo;
			lblRelacion.Text = oInfAmb.Relacion;
			lblNombreVecino.Text = oInfAmb.NombreVecino;
			lblDomicilioVecino.Text = oInfAmb.DomicilioVecino;
			lblConoceVecino.Text = oInfAmb.ConoceVecino;*/
			/*lblObservaciones.Text = oInfAmb.Observaciones;
			lblPlanoA.Text = oInfAmb.PlanoA;
			lblPlanoB.Text = oInfAmb.PlanoB;
			lblPlanoC.Text = oInfAmb.PlanoC;
			lblPlanoD.Text = oInfAmb.PlanoD;*/
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
//			pnlDomParticular.Visible = false;
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
//				case 3: // Gravámenes
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
//					lblInforme.Text = "Verificación de Domicilio Laboral";
//					pnlParticulares.Visible = true;
//					pnlDomParticular.Visible = true;
//					pnlFoto.Visible = true;
//					break;
//				case 7:
//					lblInforme.Text = "Verificación de Domicilio Particular";
//					pnlParticulares.Visible = true;
//					pnlDomParticular.Visible = true;
//					pnlFoto.Visible = true;
//					break;
//				case 8:
//					lblInforme.Text = "Verificación Especial";
//					pnlDomParticular.Visible = true;
//					pnlParticulares.Visible = true;
//					break;
//				case 9:
//					lblTitulo.Text = "Registro Público de Comercio";
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
//				case 13: // Búsqueda Propiedad
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
            InformeAmbiental oInf = new InformeAmbiental();
			DataTable myTb;
			string TipoCampo = "";

			myTb = oInf.TraerCampo(idTipo);
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
