using System;
using System.Data;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using System.Web.UI.HtmlControls;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.Informes
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class altaInforme : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Provincia;
		
		private int IdReferencia = 0;
		private int IdTipo = 1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            HtmlControl frImprimir = (HtmlControl)this.FindControl("idBody");
            frImprimir.Attributes["onload"] = "";

            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            hidCliente.Value = Usuario.IdCliente.ToString();

            lblDomParticular.Text = "Verificación Domicilio Particular";
            if(Request.QueryString["IdReferencia"] != null)
			{	
				IdReferencia = int.Parse(Request.QueryString["IdReferencia"]);
			}


			if(Request.QueryString["Id"] != null)
			{	
				IdTipo = int.Parse(Request.QueryString["Id"]);
			}
				

			if (!Page.IsPostBack) 
			{
                //Aceptar.Attributes["onclick"] = "MostrarAviso();";
                frImprimir.Attributes["onload"] = "MostrarAviso();";

				CargarTipoInforme(IdTipo);
                LoadCaracter(IdTipo);
                CambioPaneles(IdTipo, 1);

                if (Request.QueryString["IdReferencia"] != null)
                {
                    idReferencia.Value = Request.QueryString["IdReferencia"];
                    ReferenciasApp Referencia = new ReferenciasApp();
                    Referencia.Cargar(int.Parse(idReferencia.Value));
                    if (Referencia.IdUsuario != 0)
                    {
                        if (txtReferencia.Text == "")
                        {
                            DateTime ahora = DateTime.Now;
                            txtReferencia.Text = Usuario.NombreUsuario + " " + ahora.Day + "/" + ahora.Month;
                        }
                    }
                    else
                    {
                        txtReferencia.Text = Referencia.Descripcion;
                    }
                }
                else
                {
                    idReferencia.Value = "0";
                    DateTime ahora = DateTime.Now;
                    //Usuario nUsuario = new Usuario();
                    //nUsuario.Cargar(int.Parse(cmbUsuarios.SelectedValue));
                    string nomUsuario = Usuario.NombreUsuario + " " + ahora.Day + "/" + ahora.Month;
                    if (txtReferencia.Text == "" || nomUsuario != txtReferencia.Text)
                        txtReferencia.Text = nomUsuario;
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
            Aceptar.Attributes.Add("onclick", "javascript: deshabilitarBotones(" + Aceptar.ClientID + ");");
			CargarUtiles();
			// Domicilio Particular
			CargarComboProvincias(cmbProvincia, 2);
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, "1");
			// Registro - Automotor
			CargarComboProvincias(cmbProvinciaRegistro, 2);
			CargarComboLocalidades(cmbProvinciaRegistro, cmbLocalidadRegistro, "1");
			// Catastro
			CargarComboProvincias(cmbProvinciaCatastro, 2);
			CargarComboLocalidades(cmbProvinciaCatastro, cmbLocalidadCatastro, "1");
			// Empresas
			CargarComboProvincias(cmbProvinciaEmpresas, 2);
			CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, "1");
            // Informe Propiedad Otras provincias
            CargarComboProvincias(cmbProvinciaOtra, 3);
            CargarComboLocalidades(cmbProvinciaOtra, cmbLocalidadOtra, "24");
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


		protected void cmbTipoInforme_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			CambioPaneles(int.Parse(cmbTipoInforme.SelectedValue), int.Parse(cmbTipoPersona.SelectedValue));
            LoadCaracter(int.Parse(cmbTipoInforme.SelectedValue));
            /*
             //Mensaje de fuera de servicio 
            if (cmbTipoInforme.SelectedValue == "9" || cmbTipoInforme.SelectedValue == "12")
            {
                if (cmbTipoInforme.SelectedValue == "9")
                {
                    lblMensajeAlerta.Text = "El Registro Público de Comercio permanecerá cerrado durante el mes de enero de 2012, por lo tanto no se podrán solicitar informes por el momento. <br>Disculpe las molestias ocacionadas.";
                    lblMensajeAlerta.Visible = true;
                    Aceptar.Enabled = false;
                }

                if (cmbTipoInforme.SelectedValue == "12")
                {
                    lblMensajeAlerta.Text = "La Dirección de Catastro permanecerá cerrada durante el mes de enero de 2012, por lo tanto no se podrán solicitar informes por el momento. <br>Disculpe las molestias ocacionadas.";
                    lblMensajeAlerta.Visible = true;
                    Aceptar.Enabled = false;
                }
            }
            else
            {
                lblMensajeAlerta.Text = "";
                lblMensajeAlerta.Visible = false;
                Aceptar.Enabled = true;
            }
             */
		}

		protected void Aceptar_Click(object sender, System.EventArgs e)
		{
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];

            int idRef = int.Parse(idReferencia.Value);
            if (idRef == 0)
            {
                ReferenciasApp Referencia = new ReferenciasApp();
                Referencia.Descripcion = txtReferencia.Text;
                Referencia.Estado = 1;
                Referencia.Observaciones = "";
                Referencia.Path = "";
                Referencia.isFile = 0;
                Referencia.IdUsuario = Usuario.IdUsuario;
                Referencia.IdCliente = Usuario.IdCliente;
                idRef = Referencia.Crear();
            }

			EncabezadoApp Encabezado = new EncabezadoApp();
			Encabezado.IdTipoInforme = int.Parse(cmbTipoInforme.SelectedValue);
			// Usuario Logueado
			
			Encabezado.IdCliente = Usuario.IdCliente;
			Encabezado.IdUsuario = Usuario.IdUsuario;
			Encabezado.idReferencia = IdReferencia;
			Encabezado.Estado = 1;
			Encabezado.Comentarios = Observaciones.Text.ToString();
            Encabezado.idReferencia = idRef;

			if (raFoto.Items[0].Selected) Encabezado.ConFoto = 1;
			else Encabezado.ConFoto = 0;
            int idCaracter = int.Parse(cmbCaracter.SelectedValue);
            if (idCaracter == 0 && int.Parse(cmbTipoInforme.SelectedValue) != 1) idCaracter = 1;
            if (idCaracter == 0 && int.Parse(cmbTipoInforme.SelectedValue) == 1) idCaracter = 4;
            Encabezado.Caracter = idCaracter;

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
			Encabezado.Barrio = barrio.Text.ToString();
            Encabezado.Lote = Lote.Text.ToUpper();
            Encabezado.Manzana = Manzana.Text.ToUpper();
            Encabezado.Complejo = Complejo.Text.ToUpper();
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
			Encabezado.Matricula = txtLegajo.Text.ToUpper();
			Encabezado.PropTipo = int.Parse(cmbTipoPropiedad.SelectedValue);
			Encabezado.PropFolio = txtFolio.Text;
			Encabezado.PropTomo = txtTomo.Text;
			Encabezado.PropAno = txtAno.Text;
            // PROPIEDAD OTRAS PROVINCIAS
            Encabezado.ProvinciaOtra = int.Parse(cmbProvinciaOtra.SelectedValue);
            Encabezado.LocalidadOtra = int.Parse(cmbLocalidadOtra.SelectedValue);
			//AMBIENTE
			Encabezado.NombreCony = ambNombre.Text;
			Encabezado.ApellidoCony = ambApellido.Text;
			Encabezado.AMBTipoDoc = int.Parse(cmbAmbTipoDoc.SelectedValue);
			Encabezado.AMBDocumento = ambDocumento.Text;
            Encabezado.AMBTelefono = txtTelefonoAMB.Text;
            Encabezado.AMBEMail = txtEMailAMB.Text;
			//EMPRESA
            Encabezado.RazonSocial = RazonSocial.Text.ToUpper();
            Encabezado.NombreFantasia = NombreFantasia.Text.ToUpper();
            Encabezado.Cargo = Cargo.Text.ToUpper();
			Encabezado.TelefonoEmpresa = Telefono.Text;
			Encabezado.Rubro = Rubro.Text;
			Encabezado.Cuit = Cuit.Text;
            Encabezado.CalleEmpresa = CalleEmpresa.Text.ToUpper();
			Encabezado.NroEmpresa = NroEmpresa.Text;
			Encabezado.DptoEmpresa = DptoEmpresa.Text;
			Encabezado.PisoEmpresa = PisoEmpresa.Text;
            Encabezado.BarrioEmpresa = BarrioEmpresa.Text.ToUpper();
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
            // PARTIDAS DEFUNCIÓN
            Encabezado.Sexo = int.Parse(cmbSexo.SelectedValue);


			Encabezado.Crear();
			if (IdReferencia == 0)
			{
				Response.Redirect("ListaInformes.aspx");
			} 
			else
			{
				Response.Redirect("/Referencias/altaReferencia.aspx?IdReferencia=" + IdReferencia);
			}
			

		}

		protected void Cancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ListaInformes.aspx");
		}

		private void CargarTipoInforme(int idTipo)
		{

			BandejaEntradaDal Tipos = new BandejaEntradaDal();
			cmbTipoInforme.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerTiposInformes();
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[0].ToString(), myRow[1].ToString());
				if (IdTipo == int.Parse(myRow[1].ToString()))
				{
					cmbTipoInforme.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbTipoInforme.Items.Add(myItem);
			}
		}

		private void CargarUtiles()
		{
			UtilesApp Utiles = new UtilesApp();			
			cmbTipoDocumento.DataSource = Utiles.TraerTipoDocumento();
			cmbTipoDocumento.DataTextField = "Descripcion";
			cmbTipoDocumento.DataValueField = "idTipoDocumento";
			cmbTipoDocumento.DataBind();

			cmbAmbTipoDoc.DataSource = Utiles.TraerTipoDocumento();
			cmbAmbTipoDoc.DataTextField = "Descripcion";
			cmbAmbTipoDoc.DataValueField = "idTipoDocumento";
			cmbAmbTipoDoc.DataBind();

			cmbTipoGravamen.DataSource = Utiles.TraerTipoGravamen();
			cmbTipoGravamen.DataTextField = "Descripcion";
			cmbTipoGravamen.DataValueField = "idTipoGravamen";
			cmbTipoGravamen.DataBind();

			cmbEstadoCivil.DataSource = Utiles.TraerEstadoCivil();
			cmbEstadoCivil.DataTextField = "Descripcion";
			cmbEstadoCivil.DataValueField = "idEstadoCivil";
			cmbEstadoCivil.DataBind();
			
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
				//valFolio.Visible = false;
				//valAno.Visible = false;
			} 
			else 
			{
				pnlTipoPersona.Visible = false;
				pnlParticulares.Visible = false;
				pnlDomComercial.Visible = false;
				//valFolio.Visible = true;
				//valAno.Visible = true;
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
			//valObservaciones.Visible = false;
			//reqApellido.Enabled = true;
			//reqNombre.Enabled = true;
			pnlTipoPersona.Visible = false;
            pnlMensaje.Visible = false;
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
                    pnlAmbiental.Visible = true;
                    pnlAmbientalExtra.Visible = true;
                    pnlDomicilioParticular.Visible = true;
					pnlParticulares.Visible = true;
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
					pnlTipoPersona.Visible = true;
                    if (IdTipoPersona == 1)
                        pnlParticulares.Visible = true;
                    pnlDomComercial.Visible = true;
					pnlFoto.Visible = true;
					break;
				case 8:
					lblInforme.Text = "Verificación Especial";
					pnlDomComercial.Visible = true;
					pnlDomicilioParticular.Visible = true;
					pnlParticulares.Visible = true;
					break;
				case 9:
					lblTitulo.Text = "Registro Público de Comercio";
					pnlDomComercial.Visible = true;
					pnlTitulo.Visible = true;
					//valObservaciones.Visible = true;
					break;
				case 10: // Busqueda Automotor
					pnlTipoPersona.Visible = true;
                    if (cmbTipoPersona.SelectedItem.Value.Equals("1"))
                    {
                        pnlParticulares.Visible = true;
                    }
                    else
                    {

                        pnlDomComercial.Visible = true;
                    }
					break;
                case 11: // Informe Propiedad Otras Provincias
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
                    //reqCalleEmpresa.Enabled = false;
                    //reqNroCalleEmpresa.Enabled = false;
					break;
				case 14: // Informe Contractual
					pnlTipoPersona.Visible = true;
					pnlParticulares.Visible = true;
					//reqApellido.Enabled = false;
					//reqNombre.Enabled = false;
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
                    lblSexo.Visible = true;
                    cmbSexo.Visible = true;
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

		private void SelectTipoPropiedad(int idTipo){
			switch(idTipo)
			{
				case 1: 
					pnlDominioLegEspecial.Visible = false;
					ValtxtFolio.Visible = false;
					//ValMatricula.Visible = true;
					lblTipoPropiedad.Text = "Nro. de Matricula";
                    //ValMatricula.ErrorMessage = "Ingrese la matricula";
                    pnlUrgencia.Visible = false;
					break;
				case 2: 
					lblTipoPropiedad.Text = "Dominio";
					ValtxtFolio.Visible = true;
					//ValMatricula.Visible = false;
					pnlDominioLegEspecial.Visible = true;
                    pnlUrgencia.Visible = false;
					break;
				case 3: 
					lblTipoPropiedad.Text = "Nro. de Legajo Especial";
					ValtxtFolio.Visible = true;
					//ValMatricula.Visible = true;
					pnlDominioLegEspecial.Visible = true;
                    //ValMatricula.ErrorMessage = "Ingrese Nro de legajo especial";
                    RequiredFieldValidatortxtAno.Enabled = false;
                    pnlUrgencia.Visible = false;
					break;
                case 4:
                    pnlDominioLegEspecial.Visible = false;
                    ValtxtFolio.Visible = false;
                    //ValMatricula.Visible = true;
                    //ValMatricula.ErrorMessage = "Ingrese planilla";
                    RequiredFieldValidatortxtAno.Enabled = true;
                    lblTipoPropiedad.Text = "Nro. de Planilla";
                    pnlUrgencia.Visible = false;
                    break;
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

		private void LoadCaracter(int IdTipo)
		{
            if (Request.QueryString["IdTipo"] != null)
            {
                IdTipo = int.Parse(Request.QueryString["IdTipo"]);
                if (cmbTipoInforme.SelectedValue != "" && IdTipo != int.Parse(cmbTipoInforme.SelectedValue))
                    IdTipo = int.Parse(cmbTipoInforme.SelectedValue);
            }

			UtilesApp Tipos = new UtilesApp();
			cmbCaracter.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerCaracter();
			ListItem myItem;
			myItem = new ListItem("Seleccione Carácter","0");
			cmbCaracter.Items.Add(myItem);

			foreach(DataRow myRow in myTb.Rows)
			{
                if (!((IdTipo == 13 || IdTipo == 16 || IdTipo == 18) && (int.Parse(myRow[0].ToString()) == 3 || int.Parse(myRow[0].ToString()) == 4)) && !((IdTipo == 1) && int.Parse(myRow[0].ToString()) == 4)) // SE QUITA SUPER URGENTE PARA INFORMES DE BUSQUEDA DE PROPIEDAD (13) E INHIBICION (16)
                {
                    myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
                    cmbCaracter.Items.Add(myItem);
                }
			}
		}

		protected void cmbProvincia_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, "");
		}

        protected void cmbProvinciaOtra_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            CargarComboLocalidades(cmbProvinciaOtra, cmbLocalidadOtra, "");
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

		protected void Dropdownlist1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            CambioPaneles(int.Parse(cmbTipoInforme.SelectedValue), int.Parse(cmbTipoPersona.SelectedValue));
            /*
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
             */ 
		}

        protected void cmbEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        protected void cmbCaracter_Load(object sender, EventArgs e)
        {
            cmbCaracter.Attributes.Add("onChange", "validarCaracter(this)");
        }
}
}
