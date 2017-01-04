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

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.InformePropiedad
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
			InformePropiedadApp oInformePropiedad = new InformePropiedadApp();

			EncabezadoApp oEncabezado = new EncabezadoApp();
			oEncabezado.cargarEncabezado(Id);
			ClienteDal cliente = new ClienteDal();
			cliente.Cargar(oEncabezado.IdCliente);
			Usuario usuario = new Usuario();
			usuario.Cargar(oEncabezado.IdUsuario);
			bool cargar = oInformePropiedad.cargarInformePropiedad(Id);
			if (cargar)
			{
				idReferencia.Value = (1).ToString();
				lblNum.Text = Id.ToString();
				lblFec.Text = DateTime.Today.ToShortDateString();
				lblSolicitante.Text = cliente.RazonSocial;
				//lblRef.Text = usuario.Apellido + ", " + usuario.Nombre;
                if (oEncabezado.idReferencia != 0)
                    lblRef.Text = oEncabezado.NombreReferencia.ToUpper();
                else if (oEncabezado.UsuarioCliente != "")
                    lblRef.Text = oEncabezado.UsuarioCliente.ToUpper();
                else
                    lblRef.Text = usuario.Apellido.ToUpper() + ", " + usuario.Nombre.ToUpper();

				CargarForm(oInformePropiedad);
			}
			else
			{
				CargarEncabezado(oEncabezado);
			}

		}

		private void CargarEncabezado(EncabezadoApp oEncabezado)
		{
			//Visualiza el icono de traer mas datos
			
			lblMatricula.Text= oEncabezado.Matricula;
			lblFolio.Text = oEncabezado.Folio;
			lblTomo.Text = oEncabezado.Tomo;
			lblAnio.Text = oEncabezado.Ano;

			lblProvincia.Text = CargarProvincias(oEncabezado.Provincia);
			lblLocalidad.Text = CargarLocalidades(oEncabezado.Provincia, oEncabezado.Localidad);
		}


		private void CargarForm(InformePropiedadApp oInformePropiedad)
		{
			lblMatricula.Text= oInformePropiedad.Matricula;
			//idTipoProp.Value = oInformePropiedad.TipoProp.ToString();
			lblFolio.Text = oInformePropiedad.Folio;
			lblTomo.Text = oInformePropiedad.Tomo;
			lblAnio.Text = oInformePropiedad.Ano;
			SelectTipoPropiedad(oInformePropiedad.TipoProp);
			lblBarrio.Text= oInformePropiedad.Barrio;
			lblPedania.Text= oInformePropiedad.Pedania;
			lblProvincia.Text = CargarProvincias(oInformePropiedad.IdProvincia);
			lblLocalidad.Text = CargarLocalidades(oInformePropiedad.IdProvincia, oInformePropiedad.IdLocalidad);
			lblDepartamento.Text= oInformePropiedad.Departamento;
			lblPH.Text = oInformePropiedad.PH;
			lblLote.Text = oInformePropiedad.Lote;
			lblManzana.Text = oInformePropiedad.Manzana;
			lblSuperficie.Text = oInformePropiedad.Superficie;
			lblProporcion.Text = oInformePropiedad.Proporcion;
			lblGravamenes.Text = oInformePropiedad.Gravamenes;
			lblObservaciones.Text = oInformePropiedad.Observaciones;
			lblMorosidad.Text = oInformePropiedad.Morosidad;
			lblResultado.Text = oInformePropiedad.Resultado;
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
//			pnlDomComercial.Visible = false;
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
//					pnlDomComercial.Visible = true;
//					pnlFoto.Visible = true;
//					break;
//				case 7:
//					lblInforme.Text = "Verificación de Domicilio Comercial";
//					pnlParticulares.Visible = true;
//					pnlDomComercial.Visible = true;
//					pnlFoto.Visible = true;
//					break;
//				case 8:
//					lblInforme.Text = "Verificación Especial";
//					pnlDomComercial.Visible = true;
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

		private void SelectTipoPropiedad(int idTipo)
		{
			switch(idTipo)
			{
				case 1: 
					lblTipoPropiedad.Text = "Nro. de Matricula";
					trMatricula.Visible = false;
					break;
				case 2: 
					lblTipoPropiedad.Text = "Dominio";
					trMatricula.Visible = true;
					break;
				case 3: 
					lblTipoPropiedad.Text = "Nro. de Legajo Especial";
					trMatricula.Visible = true;
					break;
			}
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


		private void ListarTitulares(int idInforme)
		{
			InformePropiedadApp objInformePropiedad = new InformePropiedadApp();
			dgTitulares.DataSource = objInformePropiedad.TraerTitulares(idInforme);
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
