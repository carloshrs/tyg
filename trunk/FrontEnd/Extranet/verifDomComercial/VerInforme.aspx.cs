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

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.VerifDomComercial
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
				lblTools.Text = "<input onclick=\"panel.style.visibility='hidden';window.print();panel.style.visibility='visible';\" type=\"image\" src=\"/img/imprimir-2.gif\"> " +
					"<input onclick=\"window.close();\" type=\"image\" src=\"/img/log_off.gif\"> " +
					"<img src=\"/img/Eterno.gif\"> <input onclick=\"window.showModalDialog('/Imagenes/VerImagenes.aspx?Informe=" + IdInforme.ToString() + "', '', 'dialogWidth:640px;dialogHeight:480px');\" type=\"image\" src=\"/img/Imagenes.gif\" title=\"Ver más imágenes...\"> ";
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
			bool cargar = oInformeComercial.cargarVerifDomComercial(Id);
			if (cargar)
			{
				lblNum.Text = Id.ToString();
				lblFec.Text = DateTime.Today.ToShortDateString();
				lblSolicitante.Text = cliente.RazonSocial;
				lblRef.Text = usuario.Apellido + ", " + usuario.Nombre;
				CargarForm(oInformeComercial);
			}
			else
			{
				CargarEncabezado(oEncabezado);
			}

		}

		private void CargarEncabezado(EncabezadoApp oInformeComercial)
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

			lblNro.Text= oInformeComercial.Nro;
			lblPiso.Text= oInformeComercial.Piso;
			lblDepto.Text= oInformeComercial.Dpto;
			lblCP.Text= oInformeComercial.CP;
		}


		private void CargarForm(VerifDomComercialApp oInformeComercial)
		{
			lblNombre.Text = oInformeComercial.Nombre;
			lblApellido.Text = oInformeComercial.Apellido;
			lblTipoDocumento.Text = LoadTipoDNI(oInformeComercial.TipoDocumento);
			lblDocumento.Text= oInformeComercial.Documento;
			lblCalle.Text = oInformeComercial.Calle;
			lblBarrio.Text = oInformeComercial.Barrio;

			if (oInformeComercial.IdTipoPersona == 1) 
			{
				pnlDomComercial.Visible = false;
				pnlFisica.Visible = true;
				lblNombreFantasia.Text= oInformeComercial.NombreFantasia;
				lblRazonSocial.Text= oInformeComercial.RazonSocial;
				lblRubro.Text= oInformeComercial.Rubro;
				lblCuit.Text= oInformeComercial.Cuit;
				lblProvincia.Text = CargarProvincias(oInformeComercial.IdProvincia);
				lblLocalidad.Text = CargarLocalidades(35, oInformeComercial.IdLocalidad);

			} 
			else 
			{
				pnlDomComercial.Visible = true;
				pnlFisica.Visible = false;
				lblNombreFantasiaEmp.Text= oInformeComercial.NombreFantasia;
				lblRazonSocialEmp.Text= oInformeComercial.RazonSocial;
				lblRubroEmp.Text= oInformeComercial.Rubro;
				lblCuitEmp.Text= oInformeComercial.Cuit;
			}

			lblNro.Text= oInformeComercial.Nro;
			lblPiso.Text= oInformeComercial.Piso;
			lblDepto.Text= oInformeComercial.Depto;
			lblCP.Text= oInformeComercial.CP;
			lblTelefono.Text= oInformeComercial.Telefono;
			lblProvinciaEmp.Text = CargarProvincias(oInformeComercial.ProvinciaEmpresa);
			lblLocalidadEmp.Text = CargarLocalidades(oInformeComercial.ProvinciaEmpresa, oInformeComercial.LocalidadEmpresa);
			if(oInformeComercial.Fecha != "")
				lblFecha.Text= DateTime.Parse(oInformeComercial.Fecha).ToString("dd/MM/yyyy",DateTimeFormatInfo.InvariantInfo);
			lblOcupacion.Text = oInformeComercial.Ocupacion;
			lblCategoria.Text = oInformeComercial.Categoria;
			lblMovComercial.Text = oInformeComercial.MovComercial;
			lblActividad.Text = oInformeComercial.Actividad;
			lblRubros.Text = oInformeComercial.RubrosAdicionales;
			lblHorario.Text = oInformeComercial.Horario;
			lblAntiguedad.Text = oInformeComercial.Antiguedad;
			lblCantidad.Text = oInformeComercial.CantPersonal;
			lblCaractZona.Text = CargarTipoCampo(oInformeComercial.CaractZona, 1);
			lblDocVerificado.Text = CargarTipoCampo(oInformeComercial.DocVerificado, 2);
			lblUbicacion.Text = CargarTipoCampo(oInformeComercial.Ubicacion, 3);
			lblTamLocal.Text = CargarTipoCampo(oInformeComercial.TamLocal, 4);
			lblInmueble.Text = CargarTipoCampo(oInformeComercial.Inmueble, 5);
			lblEstadoCons.Text = CargarTipoCampo(oInformeComercial.Estado, 6);
			lblPublicidad.Text = (oInformeComercial.Publicidad == 1) ? "Si tiene": "No tiene";
			lblVigilancia.Text = (oInformeComercial.Vigilancia == 1) ? "Si tiene": "No tiene";
			if(oInformeComercial.FechaInicio != "")
				lblInicioActividades.Text= DateTime.Parse(oInformeComercial.FechaInicio).ToString("dd/MM/yyyy",DateTimeFormatInfo.InvariantInfo);
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
		
		private void CargarImagen(int lIdInforme)
		{
			ImagenDal imagen = new ImagenDal();
			imagen.Cargar(lIdInforme);
			imgFoto.ImageUrl = imagen.Path;
			imgFoto.ToolTip = imagen.Descripcion;
		}
	}
}
