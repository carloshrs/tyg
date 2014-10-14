using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public class verInformeIntra : Page
	{
		protected RequiredFieldValidator reqNombre;
		protected RequiredFieldValidator reqApellido;
		protected Label lblInforme;
		protected Panel pnlAutomotor;
		protected Panel pnlGravamenes;
		protected Panel pnlPropiedad;
		protected Panel pnlAmbiental;
		protected Panel pnlDomComercial;
		protected DropDownList cmbEstadoCivil;
		protected DropDownList cmbEstados;
		protected DropDownList cmbTipoDocumento;
		protected DropDownList cmbTipoInforme;
		protected CheckBox chkFoto;
		protected Panel pnlDomicilioParticular;
		protected Panel pnlParticulares;
		protected Panel pnlTitulo;
		protected Panel pnlFoto;
		protected Label lblTitulo;
		protected Panel pnlUrgencia;
		protected DropDownList cmbCaracter;
		protected Panel pnlCatastralDireccion;
		protected Panel pnlCatastral;
		protected Label lblTipoPropiedad;
		protected Panel pnlDominioLegEspecial;
		protected RequiredFieldValidator RequiredFieldValidator2;
		protected RequiredFieldValidator RequiredFieldValidator3;
		protected RequiredFieldValidator RequiredFieldValidator6;
		protected RequiredFieldValidator RequiredFieldValidator7;
		protected DropDownList cmbProvincia;
		protected DropDownList cmbLocalidad;
		protected HtmlInputHidden idEncabezado;
		protected TextBox txtObservaciones;
		protected Label txtNombre;
		protected Image Image3;
		protected Label txtApellido;
		protected Image Image4;
		protected Label txtEstadoCivil;
		protected Label txtTipoDoc;
		protected Label txtDocumento;
		protected Label txtCalle;
		protected Label txtNro;
		protected Label txtDpto;
		protected Label txtPiso;
		protected Image Image1;
		protected Label txtBarrio;
		protected Label txtCP;
		protected Image Image2;
		protected Label txtProvincia;
		protected Label txtLocalidad;
		protected Label lblObservaciones;
		protected Button Cerrar;
		protected Label txtDominio;
		protected Label txtRegistro;
		protected Label txtCalleRegistro;
		protected Label txtNroRegistro;
		protected Label txtDptoRegistro;
		protected Label txtPisoRegistro;
		protected Label txtBarrioRegistro;
		protected Label txtProvinciaRegistro;
		protected Label txtCPRegistro;
		protected Label txtTipoGravamen;
		protected Label txtFolioGravamen;
		protected Label txtTomoGravamen;
		protected Label txtAnoGravamen;
		protected Label txtLegajo;
		protected Label txtFolio;
		protected Label txtTomo;
		protected Label txtAno;
		protected Label txtTipoPropiedad;
		protected Label txtTipoCatastro;
		protected Label txtProvinciaCatastro;
		protected Label txtLocalidadCatastro;
		protected Label txtCalleCatastro;
		protected Label txtDptoCatastro;
		protected Label txtPisoCatastro;
		protected Label txtBarrioCatastro;
		protected Label txtCPCatastro;
		protected Label txtNroCatastro;
		protected Label txtNombreAmb;
		protected Label txtApellidoAmb;
		protected Label txtTipoDocumentoAmb;
		protected Label txtDocumentoAmb;
		protected Label txtRazonSocial;
		protected Label txtFantasia;
		protected Label txtTelefono;
		protected Label txtRubro;
		protected Label txtCuit;
		protected Label txtBarrioEmpresa;
		protected Label txtCalleEmpresa;
		protected Label txtProvinciaEmpresa;
		protected Label txtNroEmpresa;
		protected Label txtDptoEmpresa;
		protected Label txtPisoEmpresa;
		protected Label txtCPEmpresa;
		protected Label txtLocalidadEmpresa;
		protected Label numeroCatastro;
		protected Image Image23;
		protected Image Image22;
		protected Image Image10;
		protected Image Image11;
		protected Image Image12;
		protected Image Image16;
		protected Image Image13;
		protected Image Image24;
		protected Image Image14;
		protected Image Image15;
		protected Image Image25;
		protected Image Image26;
		protected Image Image17;
		protected Image Image18;
		protected Image Image19;
		protected Image Image20;
		protected Image Image21;
		protected Image Image5;
		protected Image Image6;
		protected Image Image7;
		protected Image Image8;
		protected Image Image9;
		protected Button btnCambioEstado;
		protected HtmlForm Form1;
		protected Label txtLocalidadRegistro;
		private int IdInforme;
		private int Ref = 0;

		private void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.QueryString["id"] != null)
				{
					IdInforme = int.Parse(Request.QueryString["id"]);
					LoadInforme(IdInforme);
				}
				if (Request.QueryString["idReferencia"] != null)
					Ref = int.Parse(Request.QueryString["idReferencia"]);
			}
		}

		#region Web Form Designer generated code

		protected override void OnInit(EventArgs e)
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
			this.btnCambioEstado.Click += new EventHandler(this.btnCambioEstado_Click);
			this.Cerrar.Click += new EventHandler(this.Cancelar_Click);
			this.Load += new EventHandler(this.Page_Load);

		}

		#endregion

		private void LoadInforme(int Id)
		{
			EncabezadoApp encabezado = new EncabezadoApp();
			encabezado.cargarEncabezado(Id);
			CargarForm(encabezado);
		}

		private void CargarForm(EncabezadoApp Encabezado)
		{
			CargarComboTipoInforme(Encabezado.IdTipoInforme);
			CambioPaneles(Encabezado.IdTipoInforme);
			idEncabezado.Value = Encabezado.IdEncabezado.ToString();
			//IdTipo = Encabezado.IdTipoInforme;
			lblObservaciones.Text = Encabezado.Comentarios;

			cmbTipoPersona.SelectedValue = Encabezado.IdTipoPersona.ToString();
			SelectTipoPersona(Encabezado.IdTipoPersona);
			
			txtNombre.Text = Encabezado.Nombre;
			txtApellido.Text = Encabezado.Apellido;
			ListaEstados(Encabezado.Estado);
			//Cargo Estado Civil
			txtEstadoCivil.Text = LoadEstadoCivil(Encabezado.EstadoCivil);
			//Cargo Tipo DNI
			txtTipoDoc.Text = LoadTipoDNI(Encabezado.TipoDocumento);
			txtDocumento.Text = Encabezado.Documento;
			txtCalle.Text = Encabezado.Calle;
			txtNro.Text = Encabezado.Nro;
			txtDpto.Text = Encabezado.Dpto;
			txtPiso.Text = Encabezado.Piso;
			txtBarrio.Text = Encabezado.Barrio;
			txtCP.Text = Encabezado.CP;
			// Domicilio Particular
			txtProvincia.Text = CargarComboProvincias(Encabezado.Provincia);
			txtLocalidad.Text = CargarComboLocalidades(Encabezado.Provincia, Encabezado.Localidad);
			//Foto y Caracter
			chkFoto.Checked = (Encabezado.ConFoto == 1);
			LoadCaracter(Encabezado.Caracter);
			// Automotores
			txtDominio.Text = Encabezado.Dominio;
			txtRegistro.Text = Encabezado.Registro;
			txtCalleRegistro.Text = Encabezado.CalleRegistro;
			txtNroRegistro.Text = Encabezado.NroRegistro;
			txtDptoRegistro.Text = Encabezado.DptoRegistro;
			txtPisoRegistro.Text = Encabezado.PisoRegistro;
			txtBarrioRegistro.Text = Encabezado.BarrioRegistro;
			txtCPRegistro.Text = Encabezado.CPRegistro;
			// Registro - Automotor
			txtProvinciaRegistro.Text = CargarComboProvincias(Encabezado.ProvinciaRegistro);
			txtLocalidadRegistro.Text = CargarComboLocalidades(Encabezado.ProvinciaRegistro, Encabezado.LocalidadRegistro);
			// GRAVAMENES
			if (Encabezado.IdTipoInforme == 3) 
			{
				txtTipoGravamen.Text= LoadTipoGravamenes(Encabezado.idTipoGravamen, Encabezado.IdTipoPersona);
				txtFolioGravamen.Text= Encabezado.Folio;
				txtTomoGravamen.Text= Encabezado.Tomo;
				txtAnoGravamen.Text= Encabezado.Ano ;
			}
			//PROPIEDAD
			txtTipoPropiedad.Text = LoadTipoPropiedad(Encabezado.PropTipo);
			txtLegajo.Text = Encabezado.Matricula;
			txtFolio.Text = Encabezado.PropFolio;
			txtTomo.Text = Encabezado.PropTomo;
			txtAno.Text = Encabezado.PropAno;
			//AMBIENTE
			txtNombreAmb.Text = Encabezado.NombreCony;
			txtApellidoAmb.Text = Encabezado.ApellidoCony;
			//Cargo Tipo DNI
			txtTipoDocumentoAmb.Text = LoadTipoDNI(Encabezado.AMBTipoDoc);
			txtDocumentoAmb.Text = Encabezado.AMBDocumento;
			//CATASTRO	
			txtTipoCatastro.Text = LoadTipoCatastro(Encabezado.TipoCatastro);
			// Catastro
			numeroCatastro.Text = Encabezado.NumeroCatastro;
			txtProvinciaCatastro.Text = CargarComboProvincias(Encabezado.CatProvincia);
			txtLocalidadCatastro.Text = CargarComboLocalidades(Encabezado.CatProvincia, Encabezado.CatLocalidad);
			txtBarrioCatastro.Text = Encabezado.CatBarrio;
			txtCalleCatastro.Text = Encabezado.CatCalle;
			txtCPCatastro.Text = Encabezado.CatCP;
			txtDptoCatastro.Text = Encabezado.CatDpto;
			txtNroCatastro.Text = Encabezado.CatNro;
			txtPisoCatastro.Text = Encabezado.CatPiso;

			//EMPRESA
			txtRazonSocial.Text = Encabezado.RazonSocial;
			txtFantasia.Text = Encabezado.NombreFantasia;
			txtTelefono.Text = Encabezado.TelefonoEmpresa;
			txtRubro.Text = Encabezado.Rubro;
			txtCuit.Text = Encabezado.Cuit;
			txtCalleEmpresa.Text = Encabezado.CalleEmpresa;
			txtNroEmpresa.Text = Encabezado.NroEmpresa;
			txtDptoEmpresa.Text = Encabezado.DptoEmpresa;
			txtPisoEmpresa.Text = Encabezado.PisoEmpresa;
			txtBarrioEmpresa.Text = Encabezado.BarrioEmpresa;
			txtCPEmpresa.Text = Encabezado.CPEmpresa;
			// Empresas
			txtProvinciaEmpresa.Text = CargarComboProvincias(Encabezado.ProvinciaEmpresa);
			txtLocalidadEmpresa.Text = CargarComboLocalidades(Encabezado.ProvinciaEmpresa, Encabezado.LocalidadEmpresa);
			txtObservaciones.Text = Encabezado.Observaciones;

		}

		private void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("Principal.aspx?idTipo=" + cmbTipoInforme.SelectedValue);
		}

		private void CargarComboTipoInforme(int IdTipoInforme)
		{
			BandejaEntradaDal Tipos = new BandejaEntradaDal();

			cmbTipoInforme.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerTiposInformes();
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[0].ToString(), myRow[1].ToString());
				if (IdTipoInforme.ToString() == myRow[1].ToString())
				{
					cmbTipoInforme.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbTipoInforme.Items.Add(myItem);
			}
		}


		private void CambioPaneles(int Informe)
		{
			pnlTitulo.Visible = false;
			pnlParticulares.Visible = false;
			pnlAutomotor.Visible = false;
			pnlGravamenes.Visible = false;
			pnlPropiedad.Visible = false;
			pnlAmbiental.Visible = false;
			pnlDomComercial.Visible = false;
			pnlDomicilioParticular.Visible = false;
			pnlParticulares.Visible = false;
			pnlCatastral.Visible = false;
			pnlFoto.Visible = false;
			pnlUrgencia.Visible = false;
			pnlTipoPersona.Visible = false;
			switch (Informe)
			{
				case 1: // Propiedad
					pnlPropiedad.Visible = true;
					pnlUrgencia.Visible = true;
					break;
				case 2: // Automotor
					pnlAutomotor.Visible = true;
					break;
				case 3: // Gravámenes
					pnlGravamenes.Visible = true;
					break;
				case 4: // Ambiental
					pnlParticulares.Visible = true;
					pnlAmbiental.Visible = true;
					break;
				case 5: // Dom Particular
					pnlParticulares.Visible = true;
					pnlDomicilioParticular.Visible = true;
					pnlFoto.Visible = true;
					break;
				case 6:
					lblInforme.Text = "Verificación de Domicilio Laboral";
					pnlParticulares.Visible = true;
					pnlDomComercial.Visible = true;
					pnlFoto.Visible = true;
					break;
				case 7:
					lblInforme.Text = "Verificación de Domicilio Comercial";
					pnlParticulares.Visible = true;
					pnlDomComercial.Visible = true;
					pnlFoto.Visible = true;
					break;
				case 8:
					lblInforme.Text = "Verificación Especial";
					pnlDomComercial.Visible = true;
					pnlParticulares.Visible = true;
					pnlDomicilioParticular.Visible = true;
					break;
				case 9:
					lblTitulo.Text = "Registro Público de Comercio";
					pnlTitulo.Visible = true;
					break;
				case 10: // Busqueda Automotor
					pnlParticulares.Visible = true;
					pnlTipoPersona.Visible = true;
					break;
				case 11: // Informe Propiedad Otras Provincias
					lblTitulo.Text = "Informe Propiedad Otras Provincias";
					pnlTitulo.Visible = true;
					break;
				case 12: // Informe Catastral
					pnlCatastral.Visible = true;
					break;
				case 13: // Búsqueda Propiedad
					pnlParticulares.Visible = true;
					pnlUrgencia.Visible= true;
					break;
				case 14: // Informe Contractual
					pnlParticulares.Visible = true;
					break;
			}
		}

		private void SelectTipoPropiedad(int idTipo)
		{
			switch (idTipo)
			{
				case 1:
					pnlDominioLegEspecial.Visible = false;
					lblTipoPropiedad.Text = "Nro. de Matricula";
					break;
				case 2:
					lblTipoPropiedad.Text = "Dominio";
					pnlDominioLegEspecial.Visible = true;
					break;
				case 3:
					lblTipoPropiedad.Text = "Nro. de Legajo Especial";
					pnlDominioLegEspecial.Visible = true;
					break;
			}
		}

		private string LoadEstadoCivil(int EstadoCivil)
		{
			UtilesApp Tipos = new UtilesApp();
			string Estado = "";
			DataTable myTb;
			myTb = Tipos.TraerEstadoCivil();
			foreach (DataRow myRow in myTb.Rows)
			{
				if (EstadoCivil.ToString() == myRow[0].ToString())
					Estado = myRow[1].ToString();
			}
			return Estado;
		}

		private string LoadTipoDNI(int DNI)
		{
			UtilesApp Tipos = new UtilesApp();
			string TipoDNI = "";
			DataTable myTb;
			myTb = Tipos.TraerTipoDocumento();
			foreach (DataRow myRow in myTb.Rows)
			{
				if (DNI.ToString() == myRow[0].ToString())
					TipoDNI = myRow[1].ToString();
			}
			return TipoDNI;
		}

		private string LoadTipoGravamenes(int idTipoGravamen, int TipoPersona)
		{
			UtilesApp Tipos = new UtilesApp();
			string TipoGravamen= "";
			DataTable myTb;
			myTb = Tipos.TraerTipoGravamen();
			foreach(DataRow myRow in myTb.Rows)
			{
				if(idTipoGravamen.ToString() == myRow[0].ToString())
				{
					TipoGravamen = myRow[1].ToString();
				}
			}
			if (idTipoGravamen == 3) 
			{
				if (TipoPersona == 1) 
				{
					pnlDomComercial.Visible = false;
					pnlParticulares.Visible = true;
				} 
				else 
				{
					pnlDomComercial.Visible = true;
					pnlParticulares.Visible = false;
				}
			} 
			else 
			{
				pnlTipoPersona.Visible = false;
				pnlParticulares.Visible = false;
				pnlDomComercial.Visible = false;
			} 
			return TipoGravamen;
		}

		private string LoadTipoPropiedad(int idTipoPropiedad)
		{
			UtilesApp Tipos = new UtilesApp();
			string TipoPropiedad = "";
			DataTable myTb;
			myTb = Tipos.TraerTipoPropiedad();
			foreach (DataRow myRow in myTb.Rows)
			{
				if (idTipoPropiedad.ToString() == myRow[0].ToString())
					TipoPropiedad = myRow[1].ToString();
			}
			SelectTipoPropiedad(idTipoPropiedad);
			return TipoPropiedad;
		}

		private string LoadTipoCatastro(int idCatastro)
		{
			UtilesApp Tipos = new UtilesApp();
			string Catastro = "";
			DataTable myTb;
			myTb = Tipos.TraerTipoCatastro();
			foreach (DataRow myRow in myTb.Rows)
			{
				if (idCatastro.ToString() == myRow[0].ToString())
					Catastro = myRow[1].ToString();
			}
			pnlCatastralDireccion.Visible = (idCatastro == 2);
			return Catastro;
		}

		private void LoadCaracter(int idCaracter)
		{
			UtilesApp Tipos = new UtilesApp();
			cmbCaracter.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerCaracter();
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if (idCaracter.ToString() == myRow[0].ToString())
				{
					cmbCaracter.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbCaracter.Items.Add(myItem);
			}
		}

		private string CargarComboProvincias(int IdProvincia)
		{
			UtilesApp Tipos = new UtilesApp();
			string Provincia = "";
			DataTable myTb;
			myTb = Tipos.TraerProvincias();
			foreach (DataRow myRow in myTb.Rows)
			{
				if (IdProvincia == int.Parse(myRow[0].ToString()))
					Provincia = myRow[1].ToString();
			}
			return Provincia;
		}

		private String CargarComboLocalidades(int idProvincia, int IdLocalidad)
		{
			UtilesApp Tipos = new UtilesApp();
			DataTable myTb;
			string Localidad = "";
			myTb = Tipos.TraerLocalidades(idProvincia);
			foreach (DataRow myRow in myTb.Rows)
			{
				if (IdLocalidad.ToString() == myRow[0].ToString())
					Localidad = myRow[1].ToString();
			}
			return Localidad;
		}


		private void ListaEstados(int Estado)
		{
			EncabezadoApp Estados = new EncabezadoApp();
			cmbEstados.Items.Clear();
			DataTable myTable = Estados.TraerEstados(true);
			cmbEstados.Items.Add("Todos los Estados");
			ListItem myItem;
			foreach (DataRow myRow in myTable.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if (Estado.ToString() == myRow[0].ToString())
				{
					cmbEstados.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbEstados.Items.Add(myItem);
			}

		}

		private void btnCambioEstado_Click(object sender, EventArgs e)
		{
			EncabezadoApp Encabezado = new EncabezadoApp();
			IdInforme = int.Parse(idEncabezado.Value);
			Encabezado.cargarEncabezado(IdInforme);

			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado) Session["UsuarioAutenticado"];
			Encabezado.IdUsuario = Usuario.IdUsuario;

			Encabezado.Estado = int.Parse(cmbEstados.SelectedValue);
			Encabezado.Observaciones = txtObservaciones.Text;
			Encabezado.CambiarEstado(IdInforme);
			if (Ref == 0)
				Response.Redirect("Principal.aspx?IdTipo=" + Encabezado.IdTipoInforme.ToString());
			else
				Response.Redirect("Referencias/VerReferencia.aspx?IdReferencia=" + Ref.ToString());
		}

		private void SelectTipoPersona(int idTipo)
		{
			if (idTipo == 1) 
			{
				pnlDomComercial.Visible = false;
				pnlParticulares.Visible = true;
			} 
			else 
			{
				pnlDomComercial.Visible = true;
				pnlParticulares.Visible = false;
			}
		}

	}
}