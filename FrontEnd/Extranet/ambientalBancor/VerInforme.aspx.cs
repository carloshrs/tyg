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
using ar.com.TiempoyGestion.BackEnd.Verificaciones.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.ambientalBancor
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
				//lblTools.Text = "<input onclick=\"panel.style.visibility='hidden';window.print();panel.style.visibility='visible';\" type=\"image\" src=\"/img/imprimir-2.gif\"> " +
				//	"<input onclick=\"window.close();\" type=\"image\" src=\"/img/log_off.gif\"> " +
				//	"<img src=\"/img/Eterno.gif\"> <input onclick=\"window.showModalDialog('/Admin/Imagenes/VerImagenes.aspx?Informe=" + IdInforme.ToString() + "', '', 'dialogWidth:640px;dialogHeight:480px');\" type=\"image\" src=\"/img/Imagenes.gif\" title=\"Ver más imágenes...\"> ";

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
			AmbientalBancorApp oAmbientalBancor = new AmbientalBancorApp();

			EncabezadoApp oEncabezado = new EncabezadoApp();
			oEncabezado.cargarEncabezado(Id);
			ClienteDal cliente = new ClienteDal();
			cliente.Cargar(oEncabezado.IdCliente);
			Usuario usuario = new Usuario();
			usuario.Cargar(oEncabezado.IdUsuario);
			if (oEncabezado.ConFoto == 1)
				CargarImagen(oEncabezado.IdEncabezado);
			else
				imgFoto.Visible = false;

			bool cargar = oAmbientalBancor.cargarAmbientalBancor(Id);

			if (cargar)
			{
				lblNum.Text = Id.ToString();
				lblFec.Text = DateTime.Today.ToShortDateString();
				lblSolicitante.Text = cliente.RazonSocial;

                if (oEncabezado.idReferencia != 0)
                    lblRef.Text = oEncabezado.NombreReferencia.ToUpper();
                else if (oEncabezado.UsuarioCliente != "")
                    lblRef.Text = oEncabezado.UsuarioCliente.ToUpper();
                else
                    lblRef.Text = usuario.Apellido.ToUpper() + ", " + usuario.Nombre.ToUpper();

				CargarForm(oAmbientalBancor);
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
			lblDocumento.Text = oEncabezado.Documento;
			lblCalle.Text= oEncabezado.Calle;
			lblBarrio.Text= oEncabezado.Barrio;
			lblNro.Text= oEncabezado.Nro;
			lblPiso.Text= oEncabezado.Piso;
			lblDepto.Text= oEncabezado.Dpto;
			lblCP.Text= oEncabezado.CP;
            lblLote.Text = oEncabezado.Lote;
            lblManzana.Text = oEncabezado.Manzana;
            lblComplejo.Text = oEncabezado.Complejo;
            lblTorre.Text = oEncabezado.Torre;
		}


		private void CargarForm(AmbientalBancorApp oAmbientalBancor)
		{
			lblNombre.Text= oAmbientalBancor.Nombre;
			lblApellido.Text = oAmbientalBancor.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oAmbientalBancor.TipoDocumento);
			lblDocumento.Text = oAmbientalBancor.Documento;
			lblCalle.Text= oAmbientalBancor.Calle;
			lblBarrio.Text= oAmbientalBancor.Barrio;
			lblNro.Text= oAmbientalBancor.Nro;
			lblPiso.Text= oAmbientalBancor.Piso;
			lblDepto.Text= oAmbientalBancor.Depto;
			lblCP.Text= oAmbientalBancor.CP;
            lblLote.Text = oAmbientalBancor.Lote;
            lblManzana.Text = oAmbientalBancor.Manzana;
            lblComplejo.Text = oAmbientalBancor.Complejo;
            lblTorre.Text = oAmbientalBancor.Torre;
            lblEmail.Text = oAmbientalBancor.Email;
			lblTelefono.Text= oAmbientalBancor.Telefono;
			lblProvincia.Text = CargarProvincias(oAmbientalBancor.IdProvincia);
			lblLocalidad.Text = CargarLocalidades(oAmbientalBancor.IdProvincia, oAmbientalBancor.IdLocalidad);

			if(oAmbientalBancor.Fecha != "")
				lblFecha.Text= DateTime.Parse(oAmbientalBancor.Fecha).ToString("dd/MM/yyyy",DateTimeFormatInfo.InvariantInfo);
			lblHabita.Text = oAmbientalBancor.Habita;
			lblAntiguedad.Text = oAmbientalBancor.Antiguedad;
			lblTelefonoAlt.Text = oAmbientalBancor.TelAlternativo;
            lblRelacionTitular.Text = oAmbientalBancor.RelacionTitular;
			lblTipoVivienda.Text = CargarTipoCampo(oAmbientalBancor.TipoVivienda, 13);
			lblEstadoConservacion.Text = CargarTipoCampo(oAmbientalBancor.EstadoCons, 6);
			lblTipoConstruccion.Text = CargarTipoCampo(oAmbientalBancor.TipoConstruccion, 14);
			lblTipoZona.Text = CargarTipoCampo(oAmbientalBancor.TipoZona, 15);
			lblDestino.Text = CargarTipoCampo(oAmbientalBancor.Destino, 12);
			lblInteresado.Text = CargarTipoCampo(oAmbientalBancor.Interesado, 16);
			lblAccesoDomicilio.Text = oAmbientalBancor.AccesoDomicilio;
			lblInformo.Text = oAmbientalBancor.Informo;
			lblRelacion.Text = oAmbientalBancor.Relacion;
			lblNombreVecino.Text = oAmbientalBancor.NombreVecino;
			lblDomicilioVecino.Text = oAmbientalBancor.DomicilioVecino;
			lblConoceVecino.Text = oAmbientalBancor.ConoceVecino;
			lblObservaciones.Text = oAmbientalBancor.Observaciones;
			lblPlanoA.Text = oAmbientalBancor.PlanoA;
			lblPlanoB.Text = oAmbientalBancor.PlanoB;
			lblPlanoC.Text = oAmbientalBancor.PlanoC;
			lblPlanoD.Text = oAmbientalBancor.PlanoD;
            lblResultado.Text = CargarTipoCampo(oAmbientalBancor.Resultado, 17);
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

		private void CargarImagen(int lIdInforme)
		{
			string vImagen = "/img/shim.gif";
			ImagenDal imagen = new ImagenDal();
			imagen.Cargar(lIdInforme);
			if(imagen.Path != "") 
				vImagen = imagen.Path;
			else
				imgFoto.BorderWidth = 0;
			imgFoto.ImageUrl = vImagen;
			imgFoto.ToolTip = imagen.Descripcion;
		}


	}
}
