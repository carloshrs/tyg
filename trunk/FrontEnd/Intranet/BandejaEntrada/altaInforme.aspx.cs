using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Services;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.FrontEnd.Intranet.Inc;
using ar.com.TiempoyGestion.BackEnd.Cobranzas.App;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class altaInformeIntra : Page
	{
		#region Elementos Web
		
		protected TextBox Provincia;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		private int IdTipo;
        private int idTransferido;

		#endregion
				
		#region Page_Load

		protected void Page_Load(object sender, EventArgs e)
		{
            if (Request.QueryString["IdReferencia"] != null)
            {
                idReferencia.Value = Request.QueryString["IdReferencia"];
                ReferenciasApp Referencia = new ReferenciasApp();
                Referencia.Cargar(int.Parse(idReferencia.Value));
                ListaClientes(Referencia.IdCliente);
                ListaUsuarios(Referencia.IdCliente, Referencia.IdUsuario);
                txtPersona.Text = Referencia.UsuarioCliente;
                
                hdIdCliente.Value = Referencia.IdCliente.ToString();
                txtCliente.ReadOnly = true;
                if (Referencia.IdUsuario != 0)
                {
                    ListaReferencia(Referencia.IdCliente, Referencia.IdUsuario);
                    if (txtReferencia.Text == "")
                    {
                        DateTime ahora = DateTime.Now;
                        Usuario nUsuario = new Usuario();
                        nUsuario.Cargar(Referencia.IdUsuario);
                        txtReferencia.Text = nUsuario.Apellido + ", " + nUsuario.Nombre + " " + ahora.Day + "/" + ahora.Month;
                    }
                }
                else
                {
                    txtReferencia.Text = Referencia.Descripcion;
                }
            }
            else
                idReferencia.Value = "0";

			if (Request.QueryString["IdTipo"] != null)
				IdTipo = int.Parse(Request.QueryString["IdTipo"]);
			else IdTipo = 1;

            //LoadCaracter();
            // Si no viene de un PostBack...

            if (!Page.IsPostBack)
			{				
				CambioPaneles(IdTipo);
				CargarTipoInforme(IdTipo);
                CargarRecomendado();
                if (Request.QueryString["IdReferencia"] == null)
                    ListaClientes(0);

                // Informe transferido
                if (Request.QueryString["idTransferido"] != null && Request.QueryString["idTransferido"] != "")
                {
                    idTransferido = int.Parse(Request.QueryString["idTransferido"]);
                    cargarTransferido(idTransferido);
                }

			}

            if (Request.Form["__EVENTTARGET"] == "SelectCliente")
            {
                //call your button click function, and pass the button to it (can pass null as the EventArgs)
                //Button1_Click(Button1, null);
                //SelectCliente
                SubcmbClientes(hdIdCliente.Value);
            }
		}

		#endregion

		#region Web Form Designer generated code

		protected override void OnInit(EventArgs e)
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
		
		#region Aceptar

		protected void Aceptar_Click(object sender, EventArgs e)
		{
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];

            // Crear la referencia cuando se genera una nueva solicitud.
            // Tambien sirve de bandera para identificar si se crea o modifica un informe.
            int idRef = int.Parse(idReferencia.Value);
            if (idRef == 0)
            {
                ReferenciasApp Referencia = new ReferenciasApp();
                Referencia.Descripcion = txtReferencia.Text;
                Referencia.Estado = 1;
                Referencia.Observaciones = "";
                Referencia.Path = "";
                Referencia.isFile = 0;
                //Referencia.IdUsuario = Usuario.IdUsuario;
                if (cmbUsuarios.SelectedValue != "") Referencia.IdUsuario = int.Parse(cmbUsuarios.SelectedValue);
                else Referencia.UsuarioCliente = txtPersona.Text.ToUpper();
                Referencia.IdCliente = int.Parse(hdIdCliente.Value); // int.Parse(cmbClientes.SelectedValue);
                idRef = Referencia.Crear();
            }

			EncabezadoApp Encabezado = new EncabezadoApp();
			Encabezado.IdTipoInforme = int.Parse(cmbTipoInforme.SelectedValue);
			// Usuario Logueado
			Encabezado.IdUsuario = Usuario.IdUsuario;
            Encabezado.IdCliente = int.Parse(hdIdCliente.Value); //int.Parse(cmbClientes.SelectedValue);
            if (cmbUsuarios.SelectedValue.ToString() != "") Encabezado.UsuarioCliente = cmbUsuarios.SelectedValue.ToString();
			else Encabezado.UsuarioCliente = txtPersona.Text.ToUpper();
            Encabezado.idReferencia = idRef;
			Encabezado.Estado = 1;
            Encabezado.Comentarios = Observaciones.Text.ToUpper();
			if (raFoto.Items[0].Selected) Encabezado.ConFoto = 1;
			else Encabezado.ConFoto = 0;
            int idCaracter = int.Parse(cmbCaracter.SelectedValue);
            if (idCaracter == 0 && int.Parse(cmbTipoInforme.SelectedValue) != 1) idCaracter = 1;
            if (idCaracter == 0 && int.Parse(cmbTipoInforme.SelectedValue) == 1) idCaracter = 4;
            Encabezado.Caracter = idCaracter;
			Encabezado.IdTipoPersona= int.Parse(cmbTipoPersona.SelectedValue);
            Encabezado.Nombre = Nombre.Text.ToUpper();
            Encabezado.Apellido = Apellido.Text.ToUpper();
			Encabezado.EstadoCivil = int.Parse(cmbEstadoCivil.SelectedValue);
			Encabezado.TipoDocumento = int.Parse(cmbTipoDocumento.SelectedValue);
			Encabezado.txtTipoDocumento = cmbTipoDocumento.SelectedItem.ToString();
            Encabezado.Documento = Documento.Text.ToUpper();
            Encabezado.Calle = Calle.Text.ToUpper();
            Encabezado.Nro = Nro.Text.ToUpper();
			Encabezado.Dpto = Dpto.Text.ToUpper();
            Encabezado.Piso = Piso.Text.ToUpper();
            Encabezado.Barrio = barrio.Text.ToUpper();
            Encabezado.Lote = Lote.Text.ToUpper();
            Encabezado.Manzana = Manzana.Text.ToUpper();
            Encabezado.Complejo = Complejo.Text.ToUpper();
            Encabezado.Torre = Torre.Text.ToUpper();
            Encabezado.CP = CP.Text.ToUpper();
			Encabezado.Localidad = int.Parse(cmbLocalidad.SelectedValue);
			Encabezado.Provincia = int.Parse(cmbProvincia.SelectedValue);
			// Automotores
            Encabezado.Dominio = Dominio.Text.ToUpper();
            Encabezado.Registro = Registro.Text.ToUpper();
            Encabezado.CalleRegistro = CalleRegistro.Text.ToUpper();
            Encabezado.NroRegistro = NroRegistro.Text.ToUpper();
            Encabezado.DptoRegistro = DptoRegistro.Text.ToUpper();
            Encabezado.PisoRegistro = PisoRegistro.Text.ToUpper();
            Encabezado.BarrioRegistro = BarrioRegistro.Text.ToUpper();
            Encabezado.CPRegistro = CPRegistro.Text.ToUpper();
			Encabezado.LocalidadRegistro = int.Parse(cmbLocalidadRegistro.SelectedValue);
			Encabezado.ProvinciaRegistro = int.Parse(cmbProvinciaRegistro.SelectedValue);
			// GRAVAMENES
			Encabezado.idTipoGravamen = int.Parse(cmbTipoGravamen.SelectedValue);
            Encabezado.Folio = Folio.Text.ToUpper();
            Encabezado.Tomo = Tomo.Text.ToUpper();
            Encabezado.Ano = Ano.Text.ToUpper();
			//PROPIEDAD
            Encabezado.Matricula = txtLegajo.Text.ToUpper();
			Encabezado.PropTipo = int.Parse(cmbTipoPropiedad.SelectedValue);
            Encabezado.PropFolio = txtFolio.Text.ToUpper();
            Encabezado.PropTomo = txtTomo.Text.ToUpper();
            Encabezado.PropAno = txtAno.Text.ToUpper();
            // PROPIEDAD OTRAS PROVINCIAS
            Encabezado.ProvinciaOtra = int.Parse(cmbProvinciaOtra.SelectedValue);
            Encabezado.LocalidadOtra = int.Parse(cmbLocalidadOtra.SelectedValue);
			//AMBIENTE
            Encabezado.NombreCony = ambNombre.Text.ToUpper();
            Encabezado.ApellidoCony = ambApellido.Text.ToUpper();
			Encabezado.AMBTipoDoc = int.Parse(cmbAmbTipoDoc.SelectedValue);
            Encabezado.AMBDocumento = ambDocumento.Text.ToUpper();
            Encabezado.AMBTelefono = txtTelefonoAMB.Text.ToUpper();
            Encabezado.AMBEMail = txtEMailAMB.Text.ToUpper();
			//EMPRESA							
            Encabezado.RazonSocial = RazonSocial.Text.ToUpper();
            Encabezado.NombreFantasia = NombreFantasia.Text.ToUpper();
            Encabezado.Cargo = Cargo.Text.ToUpper();
            Encabezado.TelefonoEmpresa = Telefono.Text.ToUpper();
            Encabezado.Rubro = Rubro.Text.ToUpper();
            Encabezado.Cuit = Cuit.Text.ToUpper();
            Encabezado.CalleEmpresa = CalleEmpresa.Text.ToUpper();
            Encabezado.NroEmpresa = NroEmpresa.Text.ToUpper();
            Encabezado.DptoEmpresa = DptoEmpresa.Text.ToUpper();
            Encabezado.PisoEmpresa = PisoEmpresa.Text.ToUpper();
            Encabezado.BarrioEmpresa = BarrioEmpresa.Text.ToUpper();
            Encabezado.CPEmpresa = CPEmpresa.Text.ToUpper();
			Encabezado.LocalidadEmpresa = int.Parse(cmbLocalidadEmpresas.SelectedValue);
			Encabezado.ProvinciaEmpresa = int.Parse(cmbProvinciaEmpresas.SelectedValue);				
			//CATASTRO
			Encabezado.TipoCatastro = int.Parse(cmbTipoCatastral.SelectedValue);
            Encabezado.NumeroCatastro = NumeroCatastro.Text.ToUpper();
            Encabezado.CatCalle = CatCalle.Text.ToUpper();
            Encabezado.CatNro = CatNro.Text.ToUpper();
            Encabezado.CatDpto = CatDpto.Text.ToUpper();
            Encabezado.CatPiso = CatPiso.Text.ToUpper();
            Encabezado.CatBarrio = CatBarrio.Text.ToUpper();
            Encabezado.CatCP = CatCP.Text.ToUpper();
			Encabezado.CatLocalidad = int.Parse(cmbLocalidadCatastro.SelectedValue);
			Encabezado.CatProvincia = int.Parse(cmbProvinciaCatastro.SelectedValue);
            Encabezado.RegPubFolio = FolioRegPublico.Text.ToUpper();
            Encabezado.RegPubTomo = TomoRegPublico.Text.ToUpper();
            Encabezado.RegPubAno = AnoRegPublico.Text.ToUpper();
            // VERIFICACION DE DEFUNCIÓN
            Encabezado.Sexo = int.Parse(cmbSexo.SelectedValue);
            // INFORMES PARTIDAS DEFUNCIÓN
            Encabezado.TomoFallecido = txtTomoFallecido.Text;
            Encabezado.FolioFallecido = txtFolioFallecido.Text;
            Encabezado.ActaFallecido = txtActaFallecido.Text;
            Encabezado.FechaFallecido = txtFechaFallecimiento.Text;
            Encabezado.LugarFallecido = txtLugarFallecido.Text;




            if (hIdTransferido.Value != "")
                Encabezado.IdEncabezadoTransferido = int.Parse(hIdTransferido.Value);


			Encabezado.Crear();

			//if (idReferencia.Value == "0")
            if (Request.QueryString["desdeRef"] != null)
            {
                if (raRecomendado.SelectedValue != "0" && raRecomendado.SelectedValue != "")
                    redireccionarRecomendado();
                else
                    Response.Redirect("/BandejaEntrada/Referencias/altaReferencia.aspx?IdReferencia=" + idReferencia.Value);
            }
            else
            {
                if (raRecomendado.SelectedValue != "0" && raRecomendado.SelectedValue != "")
                    redireccionarRecomendado();
                else
                    Response.Redirect("Principal.aspx?idTipo=" + cmbTipoInforme.SelectedValue);
            }
		}

		#endregion

		#region Cancelar

		protected void Cancelar_Click(object sender, EventArgs e)
		{
			//if (idReferencia.Value == "0")
            if (Request.QueryString["desdeRef"] != null)
                Response.Redirect("/BandejaEntrada/Referencias/altaReferencia.aspx?IdReferencia=" + idReferencia.Value);
            else
				Response.Redirect("Principal.aspx?idTipo=" + cmbTipoInforme.SelectedValue);
			//else
			//	Response.Redirect("/BandejaEntrada/Referencias/altaReferencia.aspx?IdReferencia=" + idReferencia.Value);
		}

		#endregion
						
		#region CargarTipoInforme(int idTipo)

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
				if (idTipo == int.Parse(myRow[1].ToString()))
				{
					cmbTipoInforme.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbTipoInforme.Items.Add(myItem);
			}
		}

		#endregion

		#region CargarUtiles

		private void CargarUtiles()
		{
			UtilesApp Utiles = new UtilesApp();
			cmbTipoDocumento.DataSource = Utiles.TraerTipoDocumento();
			cmbTipoDocumento.DataTextField = "Descripcion";
			cmbTipoDocumento.DataValueField = "idTipoDocumento";
			cmbTipoDocumento.DataBind();

			cmbTipoGravamen.DataSource = Utiles.TraerTipoGravamen();
			cmbTipoGravamen.DataTextField = "Descripcion";
			cmbTipoGravamen.DataValueField = "idTipoGravamen";
			cmbTipoGravamen.DataBind();

			cmbEstadoCivil.DataSource = Utiles.TraerEstadoCivil();
			cmbEstadoCivil.DataTextField = "Descripcion";
			cmbEstadoCivil.DataValueField = "idEstadoCivil";
			cmbEstadoCivil.DataBind();

			LoadCaracter();
		}

		#endregion
		
		#region SelectGravamen(int idTipo)

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

		#endregion

		#region CambioPaneles(int Informe)
	
		private void CambioPaneles(int Informe)
		{
			pnlTitulo.Visible = false;
			pnlParticulares.Visible = false;
			pnlAutomotor.Visible = false;
			pnlGravamenes.Visible = false;
			pnlPropiedad.Visible = false;
			pnlAmbiental.Visible = false;
            pnlAmbientalExtra.Visible = false;
			pnlDomComercial.Visible = false;
			pnlDomicilioParticular.Visible = false;
			pnlParticulares.Visible = false;
			pnlCatastral.Visible = false;
			pnlFoto.Visible = false;
			pnlUrgencia.Visible = false;			
			valObservaciones.Visible = false;
			pnlRegistroPublico.Visible = false;
			reqApellido.Enabled = true;
			reqNombre.Enabled = true;
			pnlTipoPersona.Visible = false;
            pnlPartidas.Visible = false;
			switch (Informe)
			{
				case 1: // Propiedad
					pnlPropiedad.Visible = true;
					pnlUrgencia.Visible = false;
					SelectTipoPropiedad(int.Parse(cmbTipoPropiedad.SelectedValue));
					break;
				case 2: // Automotor
					pnlAutomotor.Visible = true;
					break;
				case 3: // Gravámenes
					pnlGravamenes.Visible = true;
                    pnlUrgencia.Visible = true;
					break;
				case 4: // Ambiental
					lblDatosParticulares.Text = "Datos Domiciliarios";
                    pnlParticulares.Visible = true;
                    pnlAmbiental.Visible = true;
                    pnlAmbientalExtra.Visible = true;
                    pnlDomicilioParticular.Visible = true;
                    pnlFoto.Visible = true;
                    break;
				case 5: // Dom Particular
					pnlTipoPersona.Visible = true;
                    pnlFoto.Visible = true;
                    if (cmbTipoPersona.SelectedItem.Value.Equals("1"))
                    {
                        pnlDomicilioParticular.Visible = true;
                        pnlParticulares.Visible = true;
                    }
                    else
                        pnlDomComercial.Visible = true;
                    break;
				case 6: // Verificación Domicilio Laboral
					lblInforme.Text = "Verificación de Domicilio Laboral";
                    pnlParticulares.Visible = true;					
					pnlDomComercial.Visible = true;
					pnlFoto.Visible = true;
					break;
				case 7:
					lblInforme.Text = "Verificación de Domicilio Comercial";
                    //lblDatosParticulares.Text = "Verificación de Domicilio Comercial";
                    pnlTipoPersona.Visible = true;
                    if (cmbTipoPersona.SelectedItem.Value.Equals("1"))
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
				case 9: // Registro Publico de Comercio
					pnlRegistroPublico.Visible = true;
					pnlDomComercial.Visible = true;
					valObservaciones.Visible = true;
					break;
				case 10: // Busqueda Automotor
					pnlTipoPersona.Visible = true;
                    if (cmbTipoPersona.SelectedItem.Value.Equals("1"))
                    {
                        pnlParticulares.Visible = true;
                        lblEstadoCivil.Enabled = false;
                        cmbEstadoCivil.Enabled = false;
                    }
                    else
                        pnlDomComercial.Visible = true;
                    reqCalleEmpresa.Enabled = false;
                    reqNroCalleEmpresa.Enabled = false;
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
                    reqCalleEmpresa.Enabled = false;
                    reqNroCalleEmpresa.Enabled = false;
					break;
				case 14: // Informe Contractual
					pnlTipoPersona.Visible = true;
					pnlParticulares.Visible = true;
					reqApellido.Enabled = false;
					reqNombre.Enabled = false;
					break;
                case 15: // Relevamiento ambiental BANCOR
                    //pnlTipoPersona.Visible = true;
                    pnlFoto.Visible = true;
                    pnlDomicilioParticular.Visible = true;
                    pnlParticulares.Visible = true;
                    //lblDatosParticulares.Text = "Relevamiento ambiental BANCOR";
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
                    reqApellido.Enabled = true;
                    reqNombre.Enabled = true;
                   
                    reqCalleEmpresa.Enabled = false;
                    reqNroCalleEmpresa.Enabled = false;
                    break;
                case 17: // Informe de Morosidad
                    pnlTipoPersona.Visible = true;
                    reqCalleEmpresa.Enabled = false;
                    reqNroCalleEmpresa.Enabled = false;
                    if (cmbTipoPersona.SelectedItem.Value.Equals("1"))
                        pnlParticulares.Visible = true;
                    else
                        pnlDomComercial.Visible = true;
                    break;
                case 18: // Gravamenes DIR
                    pnlTipoPersona.Visible = true;
                    reqCalleEmpresa.Enabled = false;
                    reqNroCalleEmpresa.Enabled = false;
                    pnlUrgencia.Visible = true;
                    if (cmbTipoPersona.SelectedItem.Value.Equals("1"))
                        pnlParticulares.Visible = true;
                    else
                        pnlDomComercial.Visible = true;
                    break;
                case 19: // Verificación de defunción
                    pnlTipoPersona.Visible = false;
                    pnlParticulares.Visible = true;
                    lblEstadoCivil.Visible = false;
                    cmbEstadoCivil.Visible = false;
                    lblSexo.Visible = true;
                    cmbSexo.Visible = true;
                    pnlUrgencia.Visible = false;
                    break;
                case 20: // Informe de partidas de defunción
                    pnlTipoPersona.Visible = false;
                    pnlParticulares.Visible = true;
                    pnlPartidas.Visible = true;
                    lblEstadoCivil.Visible = false;
                    cmbEstadoCivil.Visible = false;
                    lblSexo.Visible = true;
                    cmbSexo.Visible = true;
                    pnlUrgencia.Visible = false;
                    break;
                case 21: // Inspección Socio Ambiental BANCOR
                    //pnlTipoPersona.Visible = true;
                    pnlFoto.Visible = true;
                    pnlDomicilioParticular.Visible = true;
                    pnlParticulares.Visible = true;
                    pnlAmbientalExtra.Visible = true;
                    //lblDatosParticulares.Text = "Relevamiento ambiental BANCOR";
                    pnlFoto.Visible = true;
                    break;
			}
		}

		#endregion

		#region cmbTipoCatastral_SelectedIndexChanged

		protected void cmbTipoCatastral_SelectedIndexChanged(object sender, EventArgs e)
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
                if (int.Parse(cmbTipoCatastral.SelectedValue) == 1)
                    NumeroCatastro.MaxLength = 15;
                else
                    NumeroCatastro.MaxLength = 12;
				pnlCatastralDireccion.Visible = false;
				cmbProvinciaCatastro.Enabled = true;
				cmbLocalidadCatastro.Enabled = true;
				NumeroCatastro.Visible = true;
				lblNumero.Visible = true;
			}
            cmbTipoCatastral.Focus();
		}

		#endregion

        #region cmbTipoInforme_SelectedIndexChanged

        protected void cmbTipoInforme_SelectedIndexChanged(object sender, EventArgs e)
        {
            CambioPaneles(int.Parse(cmbTipoInforme.SelectedValue));
            cmbTipoInforme.Focus();
            LoadCaracter();

            if (Request.QueryString["IdReferencia"] != null)
                SubcmbClientes(hdIdCliente.Value);
            PanelRecomendaciones(int.Parse(cmbTipoInforme.SelectedValue));
        }

        #endregion

        #region cmbTipoPropiedad_SelectedIndexChanged

        protected void cmbTipoPropiedad_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectTipoPropiedad(int.Parse(cmbTipoPropiedad.SelectedValue));
            cmbTipoPropiedad.Focus();
		}

		#endregion

		#region SelectTipoPropiedad(int idTipo)

		private void SelectTipoPropiedad(int idTipo)
		{
			switch (idTipo)
			{
				case 1:
					pnlDominioLegEspecial.Visible = false;
					ValtxtFolio.Visible = false;
					ValMatricula.Visible = true;
                    RequiredFieldValidator6.Enabled = true;
					lblTipoPropiedad.Text = "Nro. de Matricula";
                    pnlUrgencia.Visible = false;
					break;
				case 2:
					lblTipoPropiedad.Text = "Dominio";
					ValtxtFolio.Visible = true;
					ValMatricula.Visible = false;
					pnlDominioLegEspecial.Visible = true;
                    RequiredFieldValidator6.Enabled = true;
                    pnlUrgencia.Visible = false;
					break;
				case 3:
					lblTipoPropiedad.Text = "Nro. de Legajo Especial";
					ValtxtFolio.Visible = true;
                    RequiredFieldValidator6.Enabled = false;
                    ValMatricula.Visible = true;
					pnlDominioLegEspecial.Visible = true;
                    pnlUrgencia.Visible = false;
					break;
                case 4:
                    pnlDominioLegEspecial.Visible = false;
                    ValtxtFolio.Visible = false;
                    ValMatricula.Visible = true;
                    ValMatricula.ErrorMessage = "Ingrese planilla";
                    RequiredFieldValidator6.Enabled = true;
                    lblTipoPropiedad.Text = "Nro. de Planilla";
                    pnlUrgencia.Visible = false;
                    break;
			}
		}

		#endregion

		#region CargarComboProvincias(DropDownList comboProvincia, int IdProvincia)

		private void CargarComboProvincias(DropDownList comboProvincia, int IdProvincia)
		{
			UtilesApp Tipos = new UtilesApp();
			comboProvincia.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerProvincias();
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if (IdProvincia == int.Parse(myRow[0].ToString()))
				{
					comboProvincia.SelectedIndex = -1;
					myItem.Selected = true;
				}
				comboProvincia.Items.Add(myItem);
			}
		}

		#endregion

		#region CargarComboLocalidades(DropDownList comboProvincias, DropDownList comboLocalidades, string IdLocalidad)

		private void CargarComboLocalidades(DropDownList comboProvincias, DropDownList comboLocalidades, string IdLocalidad)
		{
			UtilesApp Tipos = new UtilesApp();
			comboLocalidades.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerLocalidades(int.Parse(comboProvincias.SelectedItem.Value));
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if (IdLocalidad == myRow[0].ToString())
				{
					comboLocalidades.SelectedIndex = -1;
					myItem.Selected = true;
				}
				comboLocalidades.Items.Add(myItem);
			}
		}

		#endregion

		#region LoadCaracter()

		private void LoadCaracter()
		{
            if (Request.QueryString["IdTipo"] != null)
            {
                IdTipo = int.Parse(Request.QueryString["IdTipo"]);
                if (cmbTipoInforme.SelectedValue != "" && IdTipo != int.Parse(cmbTipoInforme.SelectedValue))
                    IdTipo = int.Parse(cmbTipoInforme.SelectedValue); 
            }
             if (!string.IsNullOrEmpty(cmbTipoInforme.Text))
                 IdTipo = int.Parse(cmbTipoInforme.Text);

			UtilesApp Tipos = new UtilesApp();
			cmbCaracter.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerCaracter();
			ListItem myItem;
            myItem = new ListItem("Seleccione Carácter", "0");
            cmbCaracter.Items.Add(myItem);

			foreach (DataRow myRow in myTb.Rows)
			{
                if (!((IdTipo == 13 || IdTipo == 16 || IdTipo == 18) && (int.Parse(myRow[0].ToString()) == 3 || int.Parse(myRow[0].ToString()) == 4)) && !((IdTipo == 1) && int.Parse(myRow[0].ToString()) == 4)) // SE QUITA SUPER URGENTE PARA INFORMES DE BUSQUEDA DE PROPIEDAD (13) E INHIBICION (16) GRAVAMENES DIR(18)
                {
                    myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
                    cmbCaracter.Items.Add(myItem);
                }
			}
		}

		#endregion

		#region cmbProvincia_SelectedIndexChanged

		protected void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
		{
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, "");
            cmbProvincia.Focus();
		}

		#endregion

        #region cmbProvinciaOtra_SelectedIndexChanged

        protected void cmbProvinciaOtra_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboLocalidades(cmbProvinciaOtra, cmbLocalidadOtra, "");
            cmbProvinciaOtra.Focus();
        }

        #endregion

		#region cmbProvinciaRegistro_SelectedIndexChanged

		protected void cmbProvinciaRegistro_SelectedIndexChanged(object sender, EventArgs e)
		{
			CargarComboLocalidades(cmbProvinciaRegistro, cmbLocalidadRegistro, "");
            cmbProvinciaRegistro.Focus();
		}
		
		#endregion

		#region cmbProvinciaCatastro_SelectedIndexChanged

		protected void cmbProvinciaCatastro_SelectedIndexChanged(object sender, EventArgs e)
		{
			CargarComboLocalidades(cmbProvinciaCatastro, cmbLocalidadCatastro, "");
            cmbProvinciaCatastro.Focus();
		}

		#endregion

		#region cmbProvinciaEmpresas_SelectedIndexChanged
	
		protected void cmbProvinciaEmpresas_SelectedIndexChanged(object sender, EventArgs e)
		{
			CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, "");
            cmbProvinciaEmpresas.Focus();
		}

		#endregion

        /*#region ListaClientes()

		private void ListaClientes()
		{
			ClienteDal Clientes = new ClienteDal();
			cmbClientes.Items.Clear();
			DataTable myTable = Clientes.CargarDatos();
			cmbClientes.Items.Add("Seleccione un Cliente");
			ListItem myItem;
			foreach (DataRow myRow in myTable.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				cmbClientes.Items.Add(myItem);
			}
		}

		#endregion
         */
        
        /*
		#region cmbClientes_SelectedIndexChanged

		protected void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (cmbClientes.SelectedValue != "")
            {
                if (cmbUsuarios.SelectedValue != "")
                    ListaUsuarios(int.Parse(cmbClientes.SelectedValue), int.Parse(cmbUsuarios.SelectedValue));
                else
                    ListaUsuarios(int.Parse(cmbClientes.SelectedValue), 0);
            }
            cmbClientes.Focus();
		}

		#endregion
        */


        #region SubcmbClientes
        protected void SubcmbClientes(string IdCliente)
		{
            if (IdCliente != "")
            {
                if (cmbUsuarios.SelectedValue != "")
                    ListaUsuarios(int.Parse(IdCliente), int.Parse(cmbUsuarios.SelectedValue));
                else
                    ListaUsuarios(int.Parse(IdCliente), 0);
            }
            //cmbClientes.Focus();
            string direccion = "";
            ClienteDal dCliente = new ClienteDal();
            dCliente.Cargar(int.Parse(IdCliente));
            direccion = dCliente.Calle + " " + dCliente.Numero;
            if (dCliente.Piso != "")
                direccion = direccion + " Piso:" + dCliente.Piso;
            if (dCliente.Departamento != "")
                direccion = direccion + " Dpto:" + dCliente.Departamento;
            txtDireccion.Text = direccion;

            CuentaCorrienteApp oCobranzas = new CuentaCorrienteApp();
            int idCC = oCobranzas.ObtenerNroClienteCC(int.Parse(IdCliente));
            float saldoActual = oCobranzas.ObtenerSaldoClienteCC(idCC);
            lblSaldo.Text = "Saldo:" + saldoActual;

            VisualizarRecomendado();

		}

        #endregion

        /*
        [WebMethod]
        public static string SelectCliente(string IdCliente)
        {
            altaInformeIntra vListar = new altaInformeIntra();

            if (IdCliente != "")
            {
                if ((vListar.cmbUsuarios != null) && (vListar.cmbUsuarios.SelectedValue != null) && vListar.cmbUsuarios.SelectedValue != "")
                    vListar.ListaUsuarios(int.Parse(IdCliente), int.Parse(vListar.cmbUsuarios.SelectedValue));
                else
                    vListar.ListaUsuarios(int.Parse(IdCliente), 0);
            }
            return IdCliente;
        }
        */
        
        /*
		#region ListaUsuarios(int idCliente)

		private void ListaUsuarios(int idCliente)
		{
			Usuario Usuarios = new Usuario();
			cmbUsuarios.Items.Clear();
			DataTable myTable = Usuarios.Listar("", idCliente);
			cmbUsuarios.Items.Add("Seleccione un Usuario");
			ListItem myItem;
			foreach (DataRow myRow in myTable.Rows)
			{
				if(myRow[2].ToString() != "")
                    myItem = new ListItem(myRow[3].ToString() + ", " + myRow[2].ToString(), myRow[0].ToString());
                else
                    myItem = new ListItem(myRow[3].ToString(), myRow[0].ToString());
				cmbUsuarios.Items.Add(myItem);
			}
		}

		#endregion
        */
        /*
        #region ListaClientes(int idCliente)

        private void ListaClientes(int idCliente)
        {
            ClienteDal Clientes = new ClienteDal();
            cmbClientes.Items.Clear();
            DataTable myTable = Clientes.CargarDatos();
            ListItem vSeleccione = new ListItem("Seleccione un Cliente","");
            cmbClientes.Items.Add(vSeleccione);
            ListItem myItem;
            string nombreEmpresa = "";
            foreach (DataRow myRow in myTable.Rows)
            {
                if (myRow[2].ToString() != "")
                {
                    nombreEmpresa = myRow[2].ToString();
                    if (myRow[3].ToString() != "")
                        nombreEmpresa = nombreEmpresa + " (" + myRow[3].ToString() + ")";
                }
                else
                    nombreEmpresa = myRow[1].ToString();

                myItem = new ListItem(nombreEmpresa.Trim(), myRow[0].ToString());
                if (idCliente == int.Parse(myRow[0].ToString()))
                {
                    cmbClientes.SelectedIndex = -1;
                    myItem.Selected = true;
                }

                cmbClientes.Items.Add(myItem);
            }
        }

        #endregion
         */
        #region ListaClientes(int idCliente)

        private void ListaClientes(int idCliente)
        {
            ClienteDal Clientes = new ClienteDal();
            Clientes.Cargar(idCliente);
            
            string nombreEmpresa = "";
            string direccionEmpresa = "";

            if (Clientes.Sucursal != null && Clientes.Sucursal != "")
                nombreEmpresa = Clientes.NombreFantasia + " (" + Clientes.Sucursal + ")";
            else
                nombreEmpresa = Clientes.NombreFantasia;

            txtCliente.Text = nombreEmpresa;
            direccionEmpresa = Clientes.Calle + " " + Clientes.Numero;
            if (Clientes.Piso != "")
                direccionEmpresa = direccionEmpresa + " Piso: " + Clientes.Piso + " Of.: " + Clientes.Departamento;
            
            txtDireccion.Text = direccionEmpresa;
        }

        #endregion


        #region ListaUsuarios(int idCliente, int idUsuario)

        private void ListaUsuarios(int idCliente, int idUsuario)
        {
            Usuario Usuarios = new Usuario();
            cmbUsuarios.Items.Clear();
            DataTable myTable = Usuarios.Listar("", idCliente);
            ListItem vSeleccione = new ListItem("Seleccione un Usuario", "");
            cmbUsuarios.Items.Add(vSeleccione);
            ListItem myItem;
            foreach (DataRow myRow in myTable.Rows)
            {
                if (myRow[2].ToString() != "")
                    myItem = new ListItem(myRow[3].ToString() + ", " + myRow[2].ToString(), myRow[0].ToString());
                else
                    myItem = new ListItem(myRow[3].ToString(), myRow[0].ToString());

                if (idUsuario == int.Parse(myRow[0].ToString()))
                {
                    cmbUsuarios.SelectedIndex = -1;
                    myItem.Selected = true;
                }

                cmbUsuarios.Items.Add(myItem);
            }
        }

        #endregion


        #region ListaReferencia(int idCliente, int idUsuario)

        private void ListaReferencia(int idCliente, int idUsuario)
        {
            ReferenciasApp Referencia = new ReferenciasApp();
            //cmbReferencia.Items.Clear();
            DataTable myTable = Referencia.CargarDatosReferencias(idCliente);
            //raReferenciaAnterior.Items.Add("Nueva referencia");
            ListItem myItem;
            DateTime ahora = DateTime.Now;
            Usuario nUsuario = new Usuario();
            nUsuario.Cargar(idUsuario);
            myItem = new ListItem(nUsuario.Apellido + ", " + nUsuario.Nombre + " " + ahora.Day + "/" + ahora.Month + " (nuevo)", "0");
            myItem.Attributes.Add("onclick", "asignarTextoReferencia('" + nUsuario.Apellido + ", " + nUsuario.Nombre + " " + ahora.Day + "/" + ahora.Month + "')");
            raReferenciaAnterior.Items.Add(myItem);

            //myItem.Attributes.AddAttributes("style.Add("onclick", "asignarTextoReferencia('Nueva referencia')");
            foreach (DataRow myRow in myTable.Rows)
            {
                DateTime d=DateTime.Parse(myRow[2].ToString());
                d.ToString("dd/MM/yyyy");
                myItem = new ListItem(myRow[1].ToString()+" (" + d.ToString("dd/MM/yyyy") + ", " + myRow[3].ToString() + " " + myRow[4].ToString() + ")", myRow[0].ToString());
                myItem.Attributes.Add("onclick", "asignarTextoReferencia('" + myRow[1].ToString().Replace("'","") + "')");
                if (idCliente == int.Parse(myRow[0].ToString()))
                {
                    raReferenciaAnterior.SelectedIndex = -1;
                    myItem.Selected = true;
                }

                raReferenciaAnterior.Items.Add(myItem);
            }
        }

        #endregion

		#region cmbUsuarios_SelectedIndexChanged

		protected void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbUsuarios.SelectedValue != "")
			{
				valPersona.Visible = false;
				txtPersona.Enabled = false;
				txtPersona.Text = "";
                //ListaReferencia(int.Parse(cmbClientes.SelectedValue), int.Parse(cmbUsuarios.SelectedValue));
                ListaReferencia(int.Parse(hdIdCliente.Value), int.Parse(cmbUsuarios.SelectedValue));
                DateTime ahora = DateTime.Now;
                Usuario nUsuario = new Usuario();
                nUsuario.Cargar(int.Parse(cmbUsuarios.SelectedValue));
                string nomUsuario = nUsuario.Apellido + ", " + nUsuario.Nombre + " " + ahora.Day + "/" + ahora.Month;
                if (txtReferencia.Text == "" || nomUsuario != txtReferencia.Text)
                    txtReferencia.Text = nomUsuario;
			}
			else
			{
				valPersona.Visible = true;
				txtPersona.Enabled = true;
			}
            cmbUsuarios.Focus();
    	}

		#endregion

		#region cmbTipoPersona_SelectedIndexChanged

		protected void cmbTipoPersona_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmbTipoPersona.SelectedIndex == 0) 
			{
				lblInforme.Text = "Persona Física";
                CambioPaneles(int.Parse(cmbTipoInforme.SelectedItem.Value));
        	} 
			else 
			{
				lblInforme.Text = "Persona Jurídica";
                CambioPaneles(int.Parse(cmbTipoInforme.SelectedItem.Value));
			}
            cmbTipoPersona.Focus();
		}

		#endregion

		#region cmbTipoGravamen_SelectedIndexChanged_1

		protected void cmbTipoGravamen_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			SelectGravamen(int.Parse(cmbTipoGravamen.SelectedValue));
            cmbTipoGravamen.Focus();
		}

		#endregion				
        protected void Aceptar_PreRender(object sender, EventArgs e)
        {
            //Aceptar.Attributes.Add("onclick", "ShowMyModalPopup();");
           /* Aceptar.Attributes.Add("onClick", "this.disabled=true;" ClientScript.RegisterOnSubmitStatement(  );
            Aceptar.Attributes.Add("onLoad", "this.disabled=false;");*/
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }
        protected void btnCancelar_PreRender(object sender, EventArgs e)
        {
            btnCancelar.Attributes.Add("onClick", "document.forms[0].elements['txtReferencia'].value = ''; document.forms[0].elements['idReferencia'].value = '';");
        }
        protected void htxtReferencia_PreRender(object sender, EventArgs e)
        {
            
        }
        protected void txtReferencia_PreRender(object sender, EventArgs e)
        {
            txtReferencia.Attributes.Add("onblur", "verificarReferencia(this);");
        }
        protected void txtPersona_PreRender(object sender, EventArgs e)
        {
            txtPersona.Attributes.Add("onblur", "setearReferencia(this);");
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

        protected void btnCerrar_PreRender(object sender, EventArgs e)
        {
            btnCancelar.Attributes.Add("onClick", "cerrarSolicitudExistente();");
        }


        protected void cargarTransferido(int idInforme)
        {
            pnTransferido.Visible = true;

            EncabezadoApp transInforme = new EncabezadoApp();
            transInforme.cargarEncabezado(idInforme);
            lblInformeTransferido.Text = transInforme.TraerDescripcionInforme();
            Observaciones.Text = "Viene de " + transInforme.TraerDescripcionInforme().Replace("<B>", "").Replace("</B>", "");
            ListaClientes(transInforme.IdCliente);
            hdIdCliente.Value = transInforme.IdCliente.ToString();

            if (transInforme.UsuarioCliente != "")
            {
                if (IsNumeric(transInforme.UsuarioCliente))
                {
                    ListaUsuarios(transInforme.IdCliente, transInforme.IdUsuario);
                    valPersona.Enabled = false;
                }
                else
                {
                    ListaUsuarios(transInforme.IdCliente, 0);
                    txtPersona.Text = transInforme.UsuarioCliente;
                }
            }
            else
                ListaUsuarios(transInforme.IdCliente, 0);

            htxtReferencia.Value = transInforme.idReferencia.ToString();
            txtReferencia.Text = transInforme.NombreReferencia;
            cmbTipoInforme.SelectedValue = "1";
            hIdTransferido.Value = idInforme.ToString();
            txtLegajo.Focus();
        }


        public bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        protected void PanelRecomendaciones(int idTipoInforme)
        {
            //if (idReferencia.Value != "")
            //{
                if (idTipoInforme == 6 || idTipoInforme == 17)
                {
                    PnlRecomendado.Visible = true;
                }
            //}
        }


        protected void redireccionarRecomendado() {

            int tempIdTipo = 0;
            if (int.Parse(cmbTipoInforme.SelectedValue) == 6)
                tempIdTipo = 17;
            if (int.Parse(cmbTipoInforme.SelectedValue) == 17)
                tempIdTipo = 6;

            CambioPaneles(tempIdTipo);
            CargarTipoInforme(tempIdTipo);
            PnlRecomendado.Visible = false;
            raRecomendado.SelectedValue = "0";
            //Response.Redirect("altaInforme.aspx?idTipo=" + tempIdTipo + "&recViene=" + cmbTipoInforme.SelectedValue + "&recAnterior=" + hdRecomendadoAnterior.Value + "&nombre=" + Nombre.Text + "&apellido=" + Apellido.Text);
            
        }

        protected void CargarRecomendado() {

            if (raRecomendado.SelectedValue != "0")
            {
                if (Request.QueryString["idTipo"] != null && Request.QueryString["idTipo"] != "")
                {
                    hdRecomendadoAnterior.Value = Request.QueryString["recViene"];
                    int IdTipo = int.Parse(Request.QueryString["idTipo"]);
                    CambioPaneles(IdTipo);
                    CargarTipoInforme(IdTipo);
                    Apellido.Text = Request.QueryString["apellido"];
                    Nombre.Text = Request.QueryString["nombre"];

                }
            }
            else
                Response.Redirect("Principal.aspx?idTipo=" + cmbTipoInforme.SelectedValue);

        }


        protected void VisualizarRecomendado() {

            if (cmbTipoInforme.SelectedValue == "6" || cmbTipoInforme.SelectedValue == "17")
            {
                PnlRecomendado.Visible = true;
                ListItem myItem=null;
                raRecomendado.Items.Clear();
                if (cmbTipoInforme.SelectedValue == "6")
                    myItem = new ListItem("Informe de morosidad", "17");
                if (cmbTipoInforme.SelectedValue == "17")
                    myItem = new ListItem("Verificación laboral", "6");

                raRecomendado.Items.Add(myItem);
                myItem = new ListItem("No deseo otro informe", "0");
                raRecomendado.Items.Add(myItem);
            }
            else
                PnlRecomendado.Visible = false;
        }
    }
}