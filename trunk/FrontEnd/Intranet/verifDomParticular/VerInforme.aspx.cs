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

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.VerifDomParticular
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
			VerifDomParticularApp oVerifDom = new VerifDomParticularApp();

			EncabezadoApp oEncabezado = new EncabezadoApp();
			oEncabezado.cargarEncabezado(Id);
			ClienteDal cliente = new ClienteDal();
			cliente.Cargar(oEncabezado.IdCliente);
			Usuario usuario = new Usuario();
			usuario.Cargar(oEncabezado.IdUsuario);
            if (oEncabezado.ConFoto == 1)
            {
                pnFotos.Visible = true;
                CargarImagen(oEncabezado.IdEncabezado, 1);
                CargarImagen(oEncabezado.IdEncabezado, 2);
            }
            else
            {
                imgFoto.Visible = false;
                pnFotos.Visible = false;
                lblNroPagina1.Visible = false;
            }

			bool cargar = oVerifDom.cargarVerifDomParticular(Id);

			if (cargar)
			{
				lblNum.Text = Id.ToString();
				//lblFec.Text = DateTime.Today.ToShortDateString();
                if (oEncabezado.FechaFin != "")
                    lblFec.Text = Convert.ToDateTime(oEncabezado.FechaFin).ToShortDateString();

                string solicitante = "";
                if (cliente.NombreFantasia != null && cliente.NombreFantasia != "")
                    solicitante = cliente.NombreFantasia;
                else
                    solicitante = cliente.RazonSocial;
                if (cliente.Sucursal != null && cliente.Sucursal != "")
                    solicitante = solicitante + " (" + cliente.Sucursal + ")";
                lblSolicitante.Text = solicitante;

                string direccion = "";
                direccion = cliente.Calle + " " + cliente.Numero;
                if (cliente.Piso != "")
                {
                    direccion = direccion + " Piso: " + cliente.Piso;
                    direccion = direccion + " Dpto/Of: " + cliente.Departamento;
                }
                direccion = direccion + ". " + cliente.Barrio;
                lblDireccionSolicitante.Text = direccion;

                if (oEncabezado.idReferencia != 0)
                    lblRef.Text = oEncabezado.NombreReferencia.ToUpper();
                else if (oEncabezado.UsuarioCliente != "")
                    lblRef.Text = oEncabezado.UsuarioCliente.ToUpper();
                else
                    lblRef.Text = usuario.Apellido.ToUpper() + ", " + usuario.Nombre.ToUpper();


                if (oEncabezado.ConFoto == 1)
                {
                    lblNumCopy.Text = lblNum.Text;
                    lblFecCopy.Text = lblFec.Text;
                    lblSolicitanteCopy.Text = lblSolicitante.Text;
                    lblDireccionSolicitanteCopy.Text = lblDireccionSolicitante.Text;
                    lblRefCopy.Text = lblRef.Text;
                    lblNroPagina1.Text = "Página 1 de 2";
                    lblNroPagina2.Text = "Página 2 de 2";
                }

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
			lblEstadoCivil.Text = LoadEstadoCivil(oVerifDom.EstadoCivil);
			lblDocumento.Text = oVerifDom.Documento;
			lblCalle.Text= oVerifDom.Calle;
			lblBarrio.Text= oVerifDom.Barrio;
			lblNro.Text= oVerifDom.Nro;
			lblPiso.Text= oVerifDom.Piso;
			lblDepto.Text= oVerifDom.Dpto;
            lblCP.Text = oVerifDom.CP;
			lblLote.Text= oVerifDom.Lote;
            lblManzana.Text = oVerifDom.Manzana;
            lblComplejo.Text = oVerifDom.Complejo;
            lblTorre.Text = oVerifDom.Torre;
		}


		private void CargarForm(VerifDomParticularApp oVerifDom)
		{
			lblNombre.Text= oVerifDom.Nombre;
			lblApellido.Text = oVerifDom.Apellido;

            if (oVerifDom.Documento != "")
                lblTipoDocumento.Text = LoadTipoDNI(oVerifDom.TipoDocumento);
            else
                lblTipoDocumento.Text = "";

			lblEstadoCivil.Text = LoadEstadoCivil(oVerifDom.EstadoCivil);
			lblDocumento.Text = oVerifDom.Documento;
			lblCalle.Text= oVerifDom.Calle;
			lblBarrio.Text= oVerifDom.Barrio;
			lblNro.Text= oVerifDom.Nro;
			lblPiso.Text= oVerifDom.Piso;
			lblDepto.Text= oVerifDom.Depto;
			lblCP.Text= oVerifDom.CP;
            lblLote.Text = oVerifDom.Lote;
            lblManzana.Text = oVerifDom.Manzana;
            lblComplejo.Text = oVerifDom.Complejo;
            lblTorre.Text = oVerifDom.Torre;
			lblTelefono.Text= oVerifDom.Telefono;
			lblProvincia.Text = CargarProvincias(oVerifDom.IdProvincia);
			lblLocalidad.Text = CargarLocalidades(oVerifDom.IdProvincia, oVerifDom.IdLocalidad);

			//EMPRESA
			lblNombreFantasia.Text = oVerifDom.NombreFantasia;
			lblRazonSocial.Text= oVerifDom.RazonSocial;
			lblRubro.Text= oVerifDom.Rubro;
			lblCUIT.Text= oVerifDom.Cuit;
			lblCalleEmpresa.Text= oVerifDom.CalleEmpresa;
			lblBarrioEmpresa.Text= oVerifDom.BarrioEmpresa;
			lblNroEmpresa.Text= oVerifDom.NroEmpresa;
			lblPisoEmpresa.Text= oVerifDom.PisoEmpresa;
			lblDeptoEmpresa.Text= oVerifDom.DptoEmpresa;
			lblCPEmpresa.Text= oVerifDom.CPEmpresa;
			lblTelefonoEmpresa.Text= oVerifDom.TelefonoEmpresa;
			lblProvinciaEmpresa.Text = CargarProvincias(oVerifDom.ProvinciaEmpresa);
			lblLocalidadEmpresa.Text = CargarLocalidades(oVerifDom.ProvinciaEmpresa, oVerifDom.LocalidadEmpresa);

			if (oVerifDom.IdTipoPersona == 1) 
			{
				pnlJuridica.Visible = false;
				pnlFisica.Visible = true;
			} 
			else 
			{
				pnlFisica.Visible = false;
				pnlJuridica.Visible = true;
			}

			if(oVerifDom.Fecha != "")
				lblFecha.Text= DateTime.Parse(oVerifDom.Fecha).ToString("dd/MM/yyyy",DateTimeFormatInfo.InvariantInfo);
			lblHabita.Text = oVerifDom.Habita;
			lblAntiguedad.Text = oVerifDom.Antiguedad;
			lblMonto.Text = oVerifDom.MontoAlquiler;
			if(oVerifDom.VtoContrato != "")
				lblVencimiento.Text = DateTime.Parse(oVerifDom.VtoContrato).ToString("dd/MM/yyyy",DateTimeFormatInfo.InvariantInfo);
			lblTelefonoAlt.Text = oVerifDom.TelAlternativo;
			lblEnviar.Text = oVerifDom.Enviar;
			lblTipoVivienda.Text = CargarTipoCampo(oVerifDom.TipoVivienda, 7);
			lblEstadoConservacion.Text = CargarTipoCampo(oVerifDom.EstadoCons, 6);
			lblTipoConstruccion.Text = CargarTipoCampo(oVerifDom.TipoConstruccion, 8);
			lblTipoZona.Text = CargarTipoCampo(oVerifDom.TipoZona, 9);
			lblTipoCalle.Text = CargarTipoCampo(oVerifDom.TipoCalle, 10);
			lblInteresado.Text = CargarTipoCampo(oVerifDom.Interesado, 11);
			lblAccesoDomicilio.Text = oVerifDom.AccesoDomicilio;
			lblInformo.Text = oVerifDom.Informo;
			lblRelacion.Text = oVerifDom.Relacion;
			lblNombreVecino.Text = oVerifDom.NombreVecino;
			lblDomicilioVecino.Text = oVerifDom.DomicilioVecino;
			lblConoceVecino.Text = oVerifDom.ConoceVecino;
			lblObservaciones.Text = oVerifDom.Observaciones;
			lblPlanoA.Text = oVerifDom.PlanoA;
			lblPlanoB.Text = oVerifDom.PlanoB;
			lblPlanoC.Text = oVerifDom.PlanoC;
			lblPlanoD.Text = oVerifDom.PlanoD;
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

        private void CargarImagen(int lIdInforme, int lNroImagen)
		{
			string vImagen = "/img/shim.gif";
			ImagenDal imagen = new ImagenDal();
            imagen.Cargar(lIdInforme, lNroImagen);
			if(imagen.Path != "") 
				vImagen = imagen.Path;
			//else
				//imgFoto.BorderWidth = 0;
            if (lNroImagen == 1)
            {
                imgFoto.ImageUrl = vImagen;
                imgFoto.ToolTip = imagen.Descripcion;
            }
            if (lNroImagen == 2)
            {
                imgFoto2.ImageUrl = vImagen;
                imgFoto2.ToolTip = imagen.Descripcion;
            }
		}


	}
}
