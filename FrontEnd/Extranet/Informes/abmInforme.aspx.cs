using System;
using System.Data;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.Informes
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class abmInforme : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Provincia;
		private int IdInforme;
		protected System.Web.UI.WebControls.Label txtNombre;
		protected System.Web.UI.WebControls.Label txtApellido;
		protected System.Web.UI.WebControls.Label txtEstadoCivil;
		protected System.Web.UI.WebControls.Label txtTipoDoc;
		protected System.Web.UI.WebControls.Label txtCalle;
		protected System.Web.UI.WebControls.Label txtNro;
		protected System.Web.UI.WebControls.Label txtDpto;
		protected System.Web.UI.WebControls.Label txtPiso;
		protected System.Web.UI.WebControls.Label txtBarrio;
		protected System.Web.UI.WebControls.Label txtCP;
		protected System.Web.UI.WebControls.Label txtProvincia;
		protected System.Web.UI.WebControls.Label txtLocalidad;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Image Image3;
		protected System.Web.UI.WebControls.Image Image4;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.Button Cerrar;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist1;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Label txtDocumento;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            hidCliente.Value = Usuario.IdCliente.ToString();

			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{
                    lblDomParticular.Text = "Verificación Domicilio Particular";
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
			EncabezadoApp encabezado = new EncabezadoApp();
			encabezado.cargarEncabezado(Id);
			CargarForm(encabezado);
		}

		private void CargarForm(EncabezadoApp Encabezado)
		{
			CargarComboTipoInforme(Encabezado.IdTipoInforme);
			CambioPaneles(Encabezado.IdTipoInforme, Encabezado.IdTipoPersona);
			idEncabezado.Value= Encabezado.IdEncabezado.ToString();
			idReferencia.Value= Encabezado.idReferencia.ToString();

            if (Encabezado.idReferencia != 0)
            {
                ReferenciasApp Referencia = new ReferenciasApp();
                Referencia.Cargar(Encabezado.idReferencia);
                txtReferencia.Text = Referencia.Descripcion;
            }

			//IdTipo = Encabezado.IdTipoInforme;
            if (Encabezado.Observaciones != "")
            {
                pnObservaciones.Visible = true;
                lblObserva.Text = Encabezado.Observaciones;
            }

			Observaciones.Text= Encabezado.Comentarios;
			cmbTipoPersona.SelectedValue = Encabezado.IdTipoPersona.ToString();
			Nombre.Text = Encabezado.Nombre;
			Apellido.Text= Encabezado.Apellido;
			//Cargo Estado Civil
			LoadEstadoCivil(Encabezado.EstadoCivil);
			//Cargo Tipo DNI
			LoadTipoDNI(Encabezado.TipoDocumento, cmbTipoDocumento);
			Documento.Text= Encabezado.Documento;
			Calle.Text= Encabezado.Calle;
			Nro.Text= Encabezado.Nro;
			Dpto.Text= Encabezado.Dpto;
			Piso.Text= Encabezado.Piso;
			barrio.Text= Encabezado.Barrio;
			CP.Text= Encabezado.CP;
            Lote.Text = Encabezado.Lote;
            Manzana.Text = Encabezado.Manzana;
            Complejo.Text = Encabezado.Complejo;
            Torre.Text = Encabezado.Torre;

			// Domicilio Particular
			CargarComboProvincias(cmbProvincia, Encabezado.Provincia);
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, Encabezado.Localidad.ToString());
			//Foto y Caracter
			raFoto.Items[0].Selected = (Encabezado.ConFoto == 1);
			raFoto.Items[1].Selected = (Encabezado.ConFoto == 0);

			LoadCaracter(Encabezado.Caracter, Encabezado.IdTipoInforme);
			// Automotores
			Dominio.Text= Encabezado.Dominio;
			Registro.Text= Encabezado.Registro;
			CalleRegistro.Text= Encabezado.CalleRegistro;
			NroRegistro.Text= Encabezado.NroRegistro;
			DptoRegistro.Text= Encabezado.DptoRegistro;
			PisoRegistro.Text= Encabezado.PisoRegistro;
			BarrioRegistro.Text= Encabezado.BarrioRegistro;
			CPRegistro.Text= Encabezado.CPRegistro;
			// Registro - Automotor
			CargarComboProvincias(cmbProvinciaRegistro, Encabezado.ProvinciaRegistro);
			CargarComboLocalidades(cmbProvinciaRegistro, cmbLocalidadRegistro, Encabezado.LocalidadRegistro.ToString());
			// GRAVAMENES
			LoadTipoGravamenes(Encabezado.idTipoGravamen);
			if (Encabezado.IdTipoInforme == 3) 
			{
				SelectGravamen(Encabezado.idTipoGravamen);
			}
			Folio.Text= Encabezado.Folio;
			Tomo.Text= Encabezado.Tomo;
			Ano.Text= Encabezado.Ano ;

			//PROPIEDAD
			LoadTipoPropiedad(Encabezado.PropTipo);
            txtLegajo.Text = Encabezado.Matricula.ToUpper();
			txtFolio.Text= Encabezado.PropFolio;
			txtTomo.Text= Encabezado.PropTomo;
			txtAno.Text= Encabezado.PropAno;
			//AMBIENTE
			ambNombre.Text= Encabezado.NombreCony;
			ambApellido.Text= Encabezado.ApellidoCony;
			//Cargo Tipo DNI
			LoadTipoDNI(Encabezado.AMBTipoDoc, cmbAmbTipoDoc);
			ambDocumento.Text= Encabezado.AMBDocumento;
            txtTelefonoAMB.Text = Encabezado.AMBTelefono;
            txtEMailAMB.Text = Encabezado.AMBEMail;
			//CATASTRO	
			LoadTipoCatastro(Encabezado.TipoCatastro);
			// Catastro
			CargarComboProvincias(cmbProvinciaCatastro, Encabezado.CatProvincia);
			CargarComboLocalidades(cmbProvinciaCatastro, cmbLocalidadCatastro, Encabezado.CatLocalidad.ToString());
			NumeroCatastro.Text = Encabezado.NumeroCatastro;
			CatBarrio.Text= Encabezado.CatBarrio;
			CatCalle.Text= Encabezado.CatCalle;
			CatCP.Text= Encabezado.CatCP;
			CatDpto.Text= Encabezado.CatDpto;
			CatNro.Text= Encabezado.CatNro;
			CatPiso.Text= Encabezado.CatPiso;

			//EMPRESA
			RazonSocial.Text= Encabezado.RazonSocial;
			NombreFantasia.Text= Encabezado.NombreFantasia;
            Cargo.Text = Encabezado.Cargo;
			Telefono.Text= Encabezado.TelefonoEmpresa;
			Rubro.Text= Encabezado.Rubro;
			Cuit.Text= Encabezado.Cuit;
			CalleEmpresa.Text= Encabezado.CalleEmpresa ;
			NroEmpresa.Text= Encabezado.NroEmpresa;
			DptoEmpresa.Text= Encabezado.DptoEmpresa;
			PisoEmpresa.Text= Encabezado.PisoEmpresa;
			BarrioEmpresa.Text= Encabezado.BarrioEmpresa;
			CPEmpresa.Text= Encabezado.CPEmpresa;
			// Empresas
			CargarComboProvincias(cmbProvinciaEmpresas, Encabezado.ProvinciaEmpresa);
			CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, Encabezado.LocalidadEmpresa.ToString());

            // PROPIEDAD OTRAS PROVINCIAS
            CargarComboProvincias(cmbProvinciaOtra, Encabezado.ProvinciaOtra);
            CargarComboLocalidades(cmbProvinciaOtra, cmbLocalidadOtra, Encabezado.LocalidadOtra.ToString());

            // Registro Publico de Comercio
            //FolioRegPublico.Text = Encabezado.RegPubFolio;
            //TomoRegPublico.Text = Encabezado.RegPubTomo;
            //AnoRegPublico.Text = Encabezado.RegPubAno;

			idReferencia.Value = Encabezado.idReferencia.ToString();

		}


		protected void Aceptar_Click(object sender, System.EventArgs e)
		{
			EncabezadoApp Encabezado = new EncabezadoApp();
			Encabezado.cargarEncabezado(int.Parse(idEncabezado.Value));
			Encabezado.IdTipoInforme = int.Parse(cmbTipoInforme.SelectedValue);
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			Encabezado.IdCliente = Usuario.IdCliente;
			Encabezado.IdUsuario = Usuario.IdUsuario;

			if(idReferencia.Value != null) Encabezado.idReferencia = int.Parse(idReferencia.Value);
			else Encabezado.idReferencia = 0;
			
			Encabezado.Estado = 5;
			Encabezado.Comentarios = Observaciones.Text.ToString();

			if (raFoto.Items[0].Selected) Encabezado.ConFoto = 1;
			else Encabezado.ConFoto = 0;

			Encabezado.Caracter = int.Parse(cmbCaracter.SelectedValue);

			Encabezado.IdTipoPersona= int.Parse(cmbTipoPersona.SelectedValue);

            Encabezado.Nombre = Nombre.Text.ToString().ToUpper();
            Encabezado.Apellido = Apellido.Text.ToString().ToUpper();
			Encabezado.EstadoCivil = int.Parse(cmbEstadoCivil.SelectedValue);
			Encabezado.TipoDocumento = int.Parse(cmbTipoDocumento.SelectedValue);
			Encabezado.txtTipoDocumento = cmbTipoDocumento.SelectedItem.ToString();

			Encabezado.Documento = Documento.Text;
            Encabezado.Calle = Calle.Text.ToString().ToUpper();
			Encabezado.Nro = Nro.Text;
			Encabezado.Dpto = Dpto.Text.ToString();
            Encabezado.Piso = Piso.Text.ToString().ToUpper();
            Encabezado.Barrio = barrio.Text.ToString().ToUpper();
            Encabezado.Lote = Lote.Text.ToUpper();
            Encabezado.Manzana = Manzana.Text.ToUpper();
            Encabezado.Complejo = Complejo.Text.ToUpper().ToUpper();
            Encabezado.Torre = Torre.Text.ToUpper();
			Encabezado.CP = CP.Text.ToString();
			Encabezado.Localidad = int.Parse(cmbLocalidad.SelectedValue);
			Encabezado.Provincia = int.Parse(cmbProvincia.SelectedValue);
			// Automotores
			Encabezado.Dominio = Dominio.Text;
			Encabezado.Registro = Registro.Text;
			Encabezado.CalleRegistro = CalleRegistro.Text.ToString();
			Encabezado.NroRegistro = NroRegistro.Text;
			Encabezado.DptoRegistro = DptoRegistro.Text.ToString();
			Encabezado.PisoRegistro = PisoRegistro.Text.ToString();
			Encabezado.BarrioRegistro = BarrioRegistro.Text.ToString();
			Encabezado.CPRegistro = CPRegistro.Text.ToString();
			Encabezado.LocalidadRegistro = int.Parse(cmbLocalidadRegistro.SelectedValue);
			Encabezado.ProvinciaRegistro = int.Parse(cmbProvinciaRegistro.SelectedValue);
			// GRAVAMENES
			Encabezado.idTipoGravamen = int.Parse(cmbTipoGravamen.SelectedValue);
			Encabezado.Folio = Folio.Text;
			Encabezado.Tomo = Tomo.Text;
			Encabezado.Ano = Ano.Text;
			//PROPIEDAD
			Encabezado.Matricula = txtLegajo.Text;
			Encabezado.PropTipo = int.Parse(cmbTipoPropiedad.SelectedValue);
			Encabezado.PropFolio = txtFolio.Text;
			Encabezado.PropTomo = txtTomo.Text;
			Encabezado.PropAno = txtAno.Text;
			//AMBIENTE
			Encabezado.NombreCony = ambNombre.Text;
			Encabezado.ApellidoCony = ambApellido.Text;
			Encabezado.AMBTipoDoc = int.Parse(cmbAmbTipoDoc.SelectedValue);
			Encabezado.AMBDocumento = ambDocumento.Text;
            Encabezado.AMBTelefono = txtTelefonoAMB.Text;
            Encabezado.AMBEMail = txtEMailAMB.Text;
			//EMPRESA
			Encabezado.RazonSocial = RazonSocial.Text;
			Encabezado.NombreFantasia = NombreFantasia.Text;
            Encabezado.Cargo = Cargo.Text;
			Encabezado.TelefonoEmpresa = Telefono.Text;
			Encabezado.Rubro = Rubro.Text;
			Encabezado.Cuit = Cuit.Text;
			Encabezado.CalleEmpresa = CalleEmpresa.Text;
			Encabezado.NroEmpresa = NroEmpresa.Text;
			Encabezado.DptoEmpresa = DptoEmpresa.Text;
			Encabezado.PisoEmpresa = PisoEmpresa.Text;
			Encabezado.BarrioEmpresa = BarrioEmpresa.Text;
			Encabezado.CPEmpresa = CPEmpresa.Text;
			Encabezado.LocalidadEmpresa = int.Parse(cmbLocalidadEmpresas.SelectedValue);
			Encabezado.ProvinciaEmpresa = int.Parse(cmbProvinciaEmpresas.SelectedValue);
			//CATASTRO
			Encabezado.TipoCatastro = int.Parse(cmbTipoCatastral.SelectedValue);
			Encabezado.NumeroCatastro= NumeroCatastro.Text.ToString();
			Encabezado.CatCalle = CatCalle.Text.ToString();
			Encabezado.CatNro = CatNro.Text;
			Encabezado.CatDpto = CatDpto.Text.ToString();
			Encabezado.CatPiso = CatPiso.Text.ToString();
			Encabezado.CatBarrio = CatBarrio.Text.ToString();
			Encabezado.CatCP = CatCP.Text.ToString();
			Encabezado.CatLocalidad = int.Parse(cmbLocalidadCatastro.SelectedValue);
			Encabezado.CatProvincia = int.Parse(cmbProvinciaCatastro.SelectedValue);
            // PROPIEDAD OTRAS PROVINCIAS
            Encabezado.ProvinciaOtra = int.Parse(cmbProvinciaOtra.SelectedValue);
            Encabezado.LocalidadOtra = int.Parse(cmbLocalidadOtra.SelectedValue);

			Encabezado.Modificar(int.Parse(idEncabezado.Value));
			//if(idReferencia.Value != null)
            if (Request.QueryString["desdeRef"] != null)
			{
				if (int.Parse(idReferencia.Value) > 0) Response.Redirect("/Referencias/altaReferencia.aspx?IdReferencia=" + idReferencia.Value);
				else Response.Redirect("ListaInformes.aspx");
			} 				
			else Response.Redirect("ListaInformes.aspx");

		}

		protected void Cancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ListaInformes.aspx");
		}

		private void CargarComboTipoInforme(int IdTipoInforme)
		{
			BandejaEntradaDal Tipos = new BandejaEntradaDal();

			cmbTipoInforme.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerTiposInformes();
			ListItem myItem;
			foreach(DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[0].ToString(), myRow[1].ToString());
				if(IdTipoInforme.ToString() == myRow[1].ToString())
				{
					cmbTipoInforme.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbTipoInforme.Items.Add(myItem);
			}
		}

		protected void cmbTipoGravamen_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SelectGravamen(int.Parse(cmbTipoGravamen.SelectedValue));
		}

		private void SelectGravamen(int idTipo)
		{
			if (idTipo == 3) 
			{
				pnlTipoPersona.Visible = true;
				if (cmbTipoPersona.SelectedIndex == 0) 
				{
					pnlDomComercial.Visible = false;
					pnlParticulares.Visible = true;
				} 
				else 
				{
					pnlDomComercial.Visible = true;
					pnlParticulares.Visible = false;
				}
				valFolio.Visible = false;
				valAno.Visible = false;
			} 
			else 
			{
				pnlTipoPersona.Visible = false;
				pnlParticulares.Visible = false;
				pnlDomComercial.Visible = false;
				valFolio.Visible = true;
				valAno.Visible = true;
			} 

		}

        private void CambioPaneles(int Informe, int IdTipoPersona) 
		{
			pnlTitulo.Visible = false;
			pnlParticulares.Visible= false;
			pnlAutomotor.Visible = false;
			pnlGravamenes.Visible = false;
			pnlPropiedad.Visible= false;
			pnlAmbiental.Visible = false;
            pnlAmbientalExtra.Visible = false;
			pnlDomComercial.Visible = false;
			pnlDomicilioParticular.Visible = false;
			pnlParticulares.Visible = false;
			pnlCatastral.Visible = false;
			pnlFoto.Visible = false;
			pnlUrgencia.Visible= false;
			valObservaciones.Visible = false;
			reqApellido.Enabled = true;
			reqNombre.Enabled = true;
			pnlTipoPersona.Visible = false;
			switch(Informe)
			{
				case 1: // Propiedad
					pnlPropiedad.Visible= true;
					pnlUrgencia.Visible= false;
					SelectTipoPropiedad(int.Parse(cmbTipoPropiedad.SelectedValue));
                    pnlMensaje.Visible = true;
                    lblMensaje.Text = "Los informes de propiedad corresponden a todas las localidades de la provincia de Córdoba.<br>En caso de solicitar para otras provincias seleccione el tipo de informe <b>\"Informe propiedad otras Provincias\"</b>.";
					break;
				case 2: // Automotor
					pnlAutomotor.Visible = true;
					break;
				case 3: // Gravámenes
					pnlGravamenes.Visible = true;
                    pnlUrgencia.Visible = true;
					break;
				case 4: // Ambiental
                    lblDomParticular.Text = "Datos Domiciliarios";
					pnlParticulares.Visible = true;
                    pnlDomicilioParticular.Visible = true;
                    pnlAmbientalExtra.Visible = true;
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
                    if (IdTipoPersona == 1)
                        pnlParticulares.Visible = true;
					pnlTipoPersona.Visible = true;
					pnlDomComercial.Visible = true;
					pnlFoto.Visible = true;
                    //SelectTipoPersona(IdTipoPersona);
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
					valObservaciones.Visible = true;
					break;
				case 10: // Busqueda Automotor
					pnlParticulares.Visible = true;
					pnlTipoPersona.Visible = true;
					break;
				case 11: // Informe Propiedad Otras Provincias
					//lblTitulo.Text = "Informe Propiedad Otras Provincias";
					//pnlTitulo.Visible = true;
					//valObservaciones.Visible = true;
					//break;
                    pnlPropiedad.Visible = true;
                    pnlUrgencia.Visible = true;
                    //pnlTitulo.Visible = true;
                    lblTipoPropiedad.Text = "Nº de Inscripción";
                    lblTitulo.Text = "Informe Propiedad Otras Provincias";
                    SelectTipoPropiedad(int.Parse(cmbTipoPropiedad.SelectedValue));
                    pnInformePropiedadOtraProvincia.Visible = true;
                    break;
				case 12: // Informe Catastral
					pnlCatastralDireccion.Visible = (int.Parse(cmbTipoCatastral.SelectedValue) == 3);
					//valObservaciones.Visible = true;
					pnlCatastral.Visible = true;
					break;
				case 13: // Búsqueda Propiedad
                    pnlTipoPersona.Visible = true;
                    if (IdTipoPersona == 1)
                    {
                        pnlParticulares.Visible = true;
                        lblEstadoCivil.Enabled = false;
                        cmbEstadoCivil.Enabled = false;
                        pnlUrgencia.Visible = false;
                    }
                    else
                    {
                        pnlDomComercial.Visible = true;
                        pnlUrgencia.Visible = true;
                    }
                    //reqCalleEmpresa.Enabled = false;
                    //reqNroCalleEmpresa.Enabled = false;
					break;
				case 14: // Informe Contractual
					pnlTipoPersona.Visible = true;
					pnlParticulares.Visible = true;
					reqApellido.Enabled = false;
					reqNombre.Enabled = false;
					break;
                case 15: // Relevamiento Ambiental BANCOR
                    pnlParticulares.Visible = true;
                    pnlDomicilioParticular.Visible = true;
                    pnlFoto.Visible = true;
                    break;
                case 16: // Informe Inhibición
                    pnlTipoPersona.Visible = true;
                    if (cmbTipoPersona.SelectedItem.Value.Equals("1"))
                    {
                        pnlParticulares.Visible = true;
                        lblEstadoCivil.Enabled = false;
                        cmbEstadoCivil.Enabled = false;
                        pnlUrgencia.Visible = false;
                    }
                    else
                    {
                        pnlDomComercial.Visible = true;
                        pnlUrgencia.Visible = true;
                    }
                    //reqApellido.Enabled = true;
                    //reqNombre.Enabled = true;
                    
                    break;
                case 17: // Informe de Morosidad
                    pnlTipoPersona.Visible = true;
                    if (cmbTipoPersona.SelectedItem.Value.Equals("1"))
                        pnlParticulares.Visible = true;
                    else
                        pnlDomComercial.Visible = true;
                    break;
                case 18: // Gravamenes DIR
                    pnlTipoPersona.Visible = true;
                    pnlUrgencia.Visible = true;
                    if (cmbTipoPersona.SelectedItem.Value.Equals("1"))
                        pnlParticulares.Visible = true;
                    else
                        pnlDomComercial.Visible = true;
                    break;
                case 19: // Partidas de defunción
                    pnlTipoPersona.Visible = false;
                    pnlParticulares.Visible = true;
                    lblEstadoCivil.Visible = false;
                    cmbEstadoCivil.Visible = false;
                    //lblSexo.Visible = true;
                    //cmbSexo.Visible = true;
                    pnlUrgencia.Visible = false;
                    break;
                case 21: // Inspección Socio Ambiental BANCOR
                    pnlParticulares.Visible = true;
                    pnlDomicilioParticular.Visible = true;
                    pnlFoto.Visible = true;
                    break;
			}
		}

		protected void cmbTipoCatastral_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (int.Parse(cmbTipoCatastral.SelectedValue) == 3)
            {
                pnlCatastralDireccion.Visible = true;
                cmbProvinciaCatastro.Enabled = false;
                cmbLocalidadCatastro.Enabled = false;
                NumeroCatastro.Visible = false;
                lblNumero.Visible = false;
            }
            else
            {
                pnlCatastralDireccion.Visible = false;
                cmbProvinciaCatastro.Enabled = true;
                cmbLocalidadCatastro.Enabled = true;
                NumeroCatastro.Visible = true;
                lblNumero.Visible = true;
            }
            cmbTipoCatastral.Focus();
		}

		protected void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SelectTipoPropiedad(int.Parse(cmbTipoPropiedad.SelectedValue));
		}

		private void SelectTipoPropiedad(int idTipo)
		{
			switch(idTipo)
			{
				case 1: 
					pnlDominioLegEspecial.Visible = false;
					ValtxtFolio.Visible = false;
					ValMatricula.Visible = true;
					lblTipoPropiedad.Text = "Nro. de Matricula";
                    pnlUrgencia.Visible = false;
					break;
				case 2: 
					lblTipoPropiedad.Text = "Dominio";
					ValtxtFolio.Visible = true;
					ValMatricula.Visible = false;
					pnlDominioLegEspecial.Visible = true;
                    pnlUrgencia.Visible = false;
					break;
				case 3: 
					lblTipoPropiedad.Text = "Nro. de Legajo Especial";
					ValtxtFolio.Visible = true;
					ValMatricula.Visible = true;
					pnlDominioLegEspecial.Visible = true;
                    pnlUrgencia.Visible = false;
					break;
                case 4:
                    pnlDominioLegEspecial.Visible = false;
                    ValtxtFolio.Visible = false;
                    ValMatricula.Visible = true;
                    ValMatricula.ErrorMessage = "Ingrese planilla";
                    ValtxtAno.Enabled = true;
                    lblTipoPropiedad.Text = "Nro. de Planilla";
                    pnlUrgencia.Visible = false;
                    break;
			}
		}

		private void LoadEstadoCivil(int EstadoCivil)
		{
			UtilesApp Tipos = new UtilesApp();

			cmbEstadoCivil.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerEstadoCivil();
			ListItem myItem;
			foreach(DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(EstadoCivil.ToString() == myRow[0].ToString())
				{
					cmbEstadoCivil.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbEstadoCivil.Items.Add(myItem);
			}
		}

		private void LoadTipoDNI(int DNI, DropDownList cmbTipoDNI)
		{
			UtilesApp Tipos = new UtilesApp();

			cmbTipoDNI.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerTipoDocumento();
			ListItem myItem;
			foreach(DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(DNI.ToString() == myRow[0].ToString())
				{
					cmbTipoDNI.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbTipoDNI.Items.Add(myItem);
			}
		}

		private void LoadTipoGravamenes(int idTipoGravamen)
		{
			UtilesApp Tipos = new UtilesApp();

			cmbTipoGravamen.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerTipoGravamen();
			ListItem myItem;
			foreach(DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(idTipoGravamen.ToString() == myRow[0].ToString())
				{
					cmbTipoGravamen.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbTipoGravamen.Items.Add(myItem);
			}
		}

		private void LoadTipoPropiedad(int idTipoPropiedad)
		{
			UtilesApp Tipos = new UtilesApp();
			cmbTipoPropiedad.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerTipoPropiedad();
			ListItem myItem;
			foreach(DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(idTipoPropiedad.ToString() == myRow[0].ToString())
				{
					cmbTipoPropiedad.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbTipoPropiedad.Items.Add(myItem);
			}
			SelectTipoPropiedad(idTipoPropiedad);	
		}

		private void LoadTipoCatastro(int idCatastro)
		{
			UtilesApp Tipos = new UtilesApp();
			cmbTipoCatastral.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerTipoCatastro();
			ListItem myItem;
			foreach(DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(idCatastro.ToString() == myRow[0].ToString())
				{
					cmbTipoCatastral.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbTipoCatastral.Items.Add(myItem);
			}
			pnlCatastralDireccion.Visible = (idCatastro == 2);
		}

		private void LoadCaracter(int idCaracter, int IdTipo)
		{
			UtilesApp Tipos = new UtilesApp();
			cmbCaracter.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerCaracter();
			ListItem myItem;
            myItem = new ListItem("Seleccione Carácter", "0");
            cmbCaracter.Items.Add(myItem);

			foreach(DataRow myRow in myTb.Rows)
			{
                //if (!((IdTipo == 13 || IdTipo == 16 || IdTipo == 18) && int.Parse(myRow[0].ToString()) == 3)) // SE QUITA SUPER URGENTE PARA INFORMES DE BUSQUEDA DE PROPIEDAD (13) E INHIBICION (16)
                if (!((IdTipo == 13 || IdTipo == 16 || IdTipo == 18) && (int.Parse(myRow[0].ToString()) == 3 || int.Parse(myRow[0].ToString()) == 4)) && !((IdTipo == 1) && int.Parse(myRow[0].ToString()) == 4)) // SE QUITA SUPER URGENTE PARA INFORMES DE BUSQUEDA DE PROPIEDAD (13) E INHIBICION (16)
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
		}

		private void CargarComboProvincias(DropDownList comboProvincia, int IdProvincia)
		{
			UtilesApp Tipos = new UtilesApp();
			comboProvincia.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerProvincias();
			ListItem myItem;
			foreach(DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(IdProvincia == int.Parse(myRow[0].ToString()))
				{
					comboProvincia.SelectedIndex = -1;
					myItem.Selected = true;
				}
				comboProvincia.Items.Add(myItem);
			}
		}

		private void CargarComboLocalidades(DropDownList comboProvincias, DropDownList comboLocalidades, string IdLocalidad)
		{
			UtilesApp Tipos = new UtilesApp();
			comboLocalidades.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerLocalidades(int.Parse(comboProvincias.SelectedItem.Value));
			ListItem myItem;
			foreach(DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(IdLocalidad == myRow[0].ToString())
				{
					comboLocalidades.SelectedIndex = -1;
					myItem.Selected = true;
				}
				comboLocalidades.Items.Add(myItem);
			}
		}

		protected void cmbProvinciaRegistro_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CargarComboLocalidades(cmbProvinciaRegistro, cmbLocalidadRegistro, "");
		}

		protected void cmbProvinciaCatastro_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CargarComboLocalidades(cmbProvinciaCatastro, cmbLocalidadCatastro, "");
		}

		protected void cmbProvinciaEmpresas_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, "");
		}

        protected void cmbProvinciaOtra_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboLocalidades(cmbProvinciaOtra, cmbLocalidadOtra, "");
            cmbProvinciaOtra.Focus();
        }

		protected void cmbTipoPersona_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//SelectTipoPersona(int.Parse(cmbTipoPersona.SelectedValue)); 
            CambioPaneles(int.Parse(cmbTipoInforme.SelectedValue), int.Parse(cmbTipoPersona.SelectedValue));
		}

        protected void txtLegajo_PreRender(object sender, EventArgs e)
        {
            txtLegajo.Attributes.Add("onblur", "verificarInformeExistente()");
        }

        protected void txtFolio_PreRender(object sender, EventArgs e)
        {
            txtFolio.Attributes.Add("onblur", "verificarInformeExistente()");
        }

        protected void txtAno_PreRender(object sender, EventArgs e)
        {
            txtAno.Attributes.Add("onblur", "verificarInformeExistente()");
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
				lblInforme.Text = "Persona Jurídica";
				pnlDomComercial.Visible = true;
				pnlParticulares.Visible = false;
			}
		}


        protected void cmbCaracter_Load(object sender, EventArgs e)
        {
            cmbCaracter.Attributes.Add("onChange", "validarCaracter(this)");
        }
}
}
