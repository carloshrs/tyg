using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;


namespace ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class abmInformeIntra : Page
	{
		#region Elementos Web
		
		protected TextBox Provincia;
		private int IdInforme;
        private int IdTipo;
        private int idTransferido;
		protected Label txtNombre;
		protected Label txtApellido;
		protected Label txtEstadoCivil;
		protected Label txtTipoDoc;
		protected Label txtCalle;
		protected Label txtNro;
		protected Label txtDpto;
		protected Label txtPiso;
		protected Label txtBarrio;
		protected Label txtCP;
		protected Label txtProvincia;
		protected Label txtLocalidad;
		protected Image Image1;
		protected Image Image2;
		protected Image Image3;
		protected Image Image4;
		protected Button Cerrar;
		protected Label txtDocumento;

		#endregion

		#region Page_Load

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.QueryString["id"] != null)
				{
					IdInforme = int.Parse(Request.QueryString["id"]);
					LoadInforme(IdInforme);
				}

                // Informe transferido
                if (Request.QueryString["idTransferido"] != null && Request.QueryString["idTransferido"] != "")
                {
                    idTransferido = int.Parse(Request.QueryString["idTransferido"]);
                    cargarTransferido(idTransferido);
                }
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

		#region Mis Métodos
	
		#region LoadInforme (int Id)

		private void LoadInforme(int Id)
		{
			EncabezadoApp encabezado = new EncabezadoApp();
			encabezado.cargarEncabezado(Id);
			CargarForm(encabezado);
		}

		#endregion

		#region CargarForm (EncabezadoApp Encabezado)

		private void CargarForm(EncabezadoApp Encabezado)
		{
			CargarComboTipoInforme(Encabezado.IdTipoInforme);
			CambioPaneles(Encabezado.IdTipoInforme, Encabezado.IdTipoPersona);
			idEncabezado.Value = Encabezado.IdEncabezado.ToString();
            if (Encabezado.idReferencia.ToString() != null)
            {
                idReferencia.Value = Encabezado.idReferencia.ToString();
                txtReferencia.Text = Encabezado.NombreReferencia;
            }
            else idReferencia.Value = "0";
			//IdTipo = Encabezado.IdTipoInforme;
            if (Encabezado.Observaciones != "")
            {
                pnObservaciones.Visible = true;
                lblObserva.Text = Encabezado.Observaciones;
            }
			Observaciones.Text = Encabezado.Comentarios;
			cmbTipoPersona.SelectedValue = Encabezado.IdTipoPersona.ToString();
            ListaEstados(Encabezado.Estado);
			Nombre.Text = Encabezado.Nombre;
			Apellido.Text = Encabezado.Apellido;
			//Cargo Estado Civil
			LoadEstadoCivil(Encabezado.EstadoCivil);
			//Cargo Tipo DNI
			LoadTipoDNI(Encabezado.TipoDocumento, cmbTipoDocumento);
			Documento.Text = Encabezado.Documento;
			Calle.Text = Encabezado.Calle;
			Nro.Text = Encabezado.Nro;
			Dpto.Text = Encabezado.Dpto;
			Piso.Text = Encabezado.Piso;
			barrio.Text = Encabezado.Barrio;
			CP.Text = Encabezado.CP;
			// Domicilio Particular
			CargarComboProvincias(cmbProvincia, Encabezado.Provincia);
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, Encabezado.Localidad.ToString());
			//Foto y Caracter
			if (Encabezado.ConFoto == 1)
				raFoto.Items[0].Selected = true;
			else
				raFoto.Items[1].Selected = true;
			LoadCaracter(Encabezado.Caracter);
			// Automotores
			Dominio.Text = Encabezado.Dominio;
			Registro.Text = Encabezado.Registro;
			CalleRegistro.Text = Encabezado.CalleRegistro;
			NroRegistro.Text = Encabezado.NroRegistro;
			DptoRegistro.Text = Encabezado.DptoRegistro;
			PisoRegistro.Text = Encabezado.PisoRegistro;
			BarrioRegistro.Text = Encabezado.BarrioRegistro;
			CPRegistro.Text = Encabezado.CPRegistro;
			// Registro - Automotor
			CargarComboProvincias(cmbProvinciaRegistro, Encabezado.ProvinciaRegistro);
			CargarComboLocalidades(cmbProvinciaRegistro, cmbLocalidadRegistro, Encabezado.LocalidadRegistro.ToString());
			// GRAVAMENES
			LoadTipoGravamenes(Encabezado.idTipoGravamen);
			if (Encabezado.IdTipoInforme == 3) 
			{
				SelectGravamen(Encabezado.idTipoGravamen);
			}
			Folio.Text = Encabezado.Folio;
			Tomo.Text = Encabezado.Tomo;
			Ano.Text = Encabezado.Ano;
			//PROPIEDAD
            if (Encabezado.IdTipoInforme == 1 || Encabezado.IdTipoInforme == 11) 
			    LoadTipoPropiedad(Encabezado.PropTipo);
			txtLegajo.Text = Encabezado.Matricula;
			txtFolio.Text = Encabezado.PropFolio;
			txtTomo.Text = Encabezado.PropTomo;
			txtAno.Text = Encabezado.PropAno;
			//AMBIENTE
			ambNombre.Text = Encabezado.NombreCony;
			ambApellido.Text = Encabezado.ApellidoCony;
			//Cargo Tipo DNI
			LoadTipoDNI(Encabezado.AMBTipoDoc, cmbAmbTipoDoc);
			ambDocumento.Text = Encabezado.AMBDocumento;
            txtTelefonoAMB.Text = Encabezado.AMBTelefono;
            txtEMailAMB.Text = Encabezado.AMBEMail;
			//CATASTRO	
			LoadTipoCatastro(Encabezado.TipoCatastro);
			// Catastro
			CargarComboProvincias(cmbProvinciaCatastro, Encabezado.CatProvincia);
			CargarComboLocalidades(cmbProvinciaCatastro, cmbLocalidadCatastro, Encabezado.CatLocalidad.ToString());
			NumeroCatastro.Text = Encabezado.NumeroCatastro;
			CatBarrio.Text = Encabezado.CatBarrio;
			CatCalle.Text = Encabezado.CatCalle;
			CatCP.Text = Encabezado.CatCP;
			CatDpto.Text = Encabezado.CatDpto;
			CatNro.Text = Encabezado.CatNro;
			CatPiso.Text = Encabezado.CatPiso;
			//EMPRESA
			RazonSocial.Text = Encabezado.RazonSocial;
			NombreFantasia.Text = Encabezado.NombreFantasia;
            Cargo.Text = Encabezado.Cargo;
			Telefono.Text = Encabezado.TelefonoEmpresa;
			Rubro.Text = Encabezado.Rubro;
			Cuit.Text = Encabezado.Cuit;
			CalleEmpresa.Text = Encabezado.CalleEmpresa;
			NroEmpresa.Text = Encabezado.NroEmpresa;
			DptoEmpresa.Text = Encabezado.DptoEmpresa;
			PisoEmpresa.Text = Encabezado.PisoEmpresa;
			BarrioEmpresa.Text = Encabezado.BarrioEmpresa;
			CPEmpresa.Text = Encabezado.CPEmpresa;
			// Empresas
			CargarComboProvincias(cmbProvinciaEmpresas, Encabezado.ProvinciaEmpresa);
			CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, Encabezado.LocalidadEmpresa.ToString());

            // PROPIEDAD OTRAS PROVINCIAS
            CargarComboProvincias(cmbProvinciaOtra, Encabezado.ProvinciaOtra);
            CargarComboLocalidades(cmbProvinciaOtra, cmbLocalidadOtra, Encabezado.LocalidadOtra.ToString());

			// Registro Publico de Comercio
			FolioRegPublico.Text = Encabezado.RegPubFolio;
			TomoRegPublico.Text = Encabezado.RegPubTomo;
			AnoRegPublico.Text= Encabezado.RegPubAno ;

            // Referencias
            CargarReferencias(Encabezado.IdCliente, Encabezado.IdUsuario);

            // PARTIDAS DEFUNCIÓN
            if (Encabezado.Sexo.ToString() != "")
                cmbSexo.SelectedValue = Encabezado.Sexo.ToString();

            txtTomoFallecido.Text = Encabezado.TomoFallecido;
            txtFolioFallecido.Text = Encabezado.FolioFallecido;
            txtActaFallecido.Text = Encabezado.ActaFallecido;
            txtFechaFallecimiento.Text = Encabezado.FechaFallecido;
            txtLugarFallecido.Text = Encabezado.LugarFallecido;
		}

		#endregion

		#region CargarComboTipoInforme (int IdTipoInforme)

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

		#region LoadEstadoCivil (int EstadoCivil)

		private void LoadEstadoCivil(int EstadoCivil)
		{
			UtilesApp Tipos = new UtilesApp();

			cmbEstadoCivil.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerEstadoCivil();
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if (EstadoCivil.ToString() == myRow[0].ToString())
				{
					cmbEstadoCivil.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbEstadoCivil.Items.Add(myItem);
			}
		}

		#endregion

		#region LoadTipoDNI (int DNI, DropDownList cmbTipoDNI)

		private void LoadTipoDNI(int DNI, DropDownList cmbTipoDNI)
		{
			UtilesApp Tipos = new UtilesApp();

			cmbTipoDNI.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerTipoDocumento();
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if (DNI.ToString() == myRow[0].ToString())
				{
					cmbTipoDNI.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbTipoDNI.Items.Add(myItem);
			}
		}

		#endregion
		
		#region LoadTipoGravamenes (int idTipoGravamen)

		private void LoadTipoGravamenes(int idTipoGravamen)
		{
			UtilesApp Tipos = new UtilesApp();

			cmbTipoGravamen.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerTipoGravamen();
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if (idTipoGravamen.ToString() == myRow[0].ToString())
				{
					cmbTipoGravamen.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbTipoGravamen.Items.Add(myItem);
			}
		}

		#endregion

		#region LoadTipoPropiedad(int idTipoPropiedad)

		private void LoadTipoPropiedad(int idTipoPropiedad)
		{
			UtilesApp Tipos = new UtilesApp();
			cmbTipoPropiedad.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerTipoPropiedad();
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if (idTipoPropiedad.ToString() == myRow[0].ToString())
				{
					cmbTipoPropiedad.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbTipoPropiedad.Items.Add(myItem);
			}
			SelectTipoPropiedad(idTipoPropiedad);
		}

		#endregion

		#region LoadTipoCatastro(int idCatastro)

		private void LoadTipoCatastro(int idCatastro)
		{
			UtilesApp Tipos = new UtilesApp();
			cmbTipoCatastral.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerTipoCatastro();
			ListItem myItem;
			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if (idCatastro.ToString() == myRow[0].ToString())
				{
					cmbTipoCatastral.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbTipoCatastral.Items.Add(myItem);
			}
			pnlCatastralDireccion.Visible = (idCatastro == 2);
		}

		#endregion

		#region LoadCaracter(int idCaracter)

		private void LoadCaracter(int idCaracter)
		{
            if (Request.QueryString["IdTipo"] != null)
                IdTipo = int.Parse(Request.QueryString["IdTipo"]);

			UtilesApp Tipos = new UtilesApp();
			cmbCaracter.Items.Clear();
			DataTable myTb;
			myTb = Tipos.TraerCaracter();
			ListItem myItem;
            myItem = new ListItem("Seleccione Carácter", "0");
            cmbCaracter.Items.Add(myItem);

			foreach (DataRow myRow in myTb.Rows)
			{
                if (!((IdTipo == 13 || IdTipo == 16) && (int.Parse(myRow[0].ToString()) == 3 || int.Parse(myRow[0].ToString()) == 4)) && !((IdTipo == 1) && int.Parse(myRow[0].ToString()) == 4)) // SE QUITA SUPER URGENTE PARA INFORMES DE BUSQUEDA DE PROPIEDAD (13) E INHIBICION (16)
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

		#region SelectTipoPropiedad(int idTipo)

		private void SelectTipoPropiedad(int idTipo)
		{
			switch (idTipo)
			{
				case 1:
					pnlDominioLegEspecial.Visible = false;
					ValtxtFolio.Visible = false;
					ValMatricula.Visible = true;
                    RequiredFieldValidator10.Enabled = true;
					lblTipoPropiedad.Text = "Nro. de Matricula";
                    pnlUrgencia.Visible = false;
					break;
				case 2:
					lblTipoPropiedad.Text = "Dominio";
					ValtxtFolio.Visible = true;
					ValMatricula.Visible = false;
                    RequiredFieldValidator10.Enabled = true;
					pnlDominioLegEspecial.Visible = true;
                    pnlUrgencia.Visible = false;
					break;
				case 3:
					lblTipoPropiedad.Text = "Nro. de Legajo Especial";
					ValtxtFolio.Visible = true;
					ValMatricula.Visible = true;
                    RequiredFieldValidator10.Enabled = false;
					pnlDominioLegEspecial.Visible = true;
                    pnlUrgencia.Visible = true;
					break;
                case 4:
                    pnlDominioLegEspecial.Visible = false;
                    ValtxtFolio.Visible = false;
                    ValMatricula.Visible = true;
                    ValMatricula.ErrorMessage = "Ingrese planilla";
                    valAno.Enabled = true;
                    lblTipoPropiedad.Text = "Nro. de Planilla";
                    pnlUrgencia.Visible = true;
                    break;
			}
		}

		#endregion

		#region SelectTipoPersona(int idTipo)
		
		private void SelectTipoPersona(int idTipo)
		{
			if (idTipo == 1) 
			{
                lblInforme.Text = "Persona Física";
                //CambioPaneles(int.Parse(cmbTipoInforme.SelectedItem.Value), idTipo);
                pnlDomComercial.Visible = false;
				pnlParticulares.Visible = true;
			} 
			else 
			{
                lblInforme.Text = "Persona Jurídica";
                //CambioPaneles(int.Parse(cmbTipoInforme.SelectedItem.Value), idTipo);
                pnlDomComercial.Visible = true;
				pnlParticulares.Visible = false;
			}
		}

		#endregion

        #region CambioPaneles(int Informe, int IdTipoPersona)

        private void CambioPaneles(int Informe, int IdTipoPersona)
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
                    lblDomParticular.Text = "Datos Domiciliarios";
					pnlParticulares.Visible = true;
					pnlAmbiental.Visible = true;
                    pnlAmbientalExtra.Visible = true;
                    pnlDomicilioParticular.Visible = true;
                    pnlFoto.Visible = true;
					break;
				case 5: // Dom Particular
					//pnlDomicilioParticular.Visible = true;
					//pnlParticulares.Visible = true;
					pnlTipoPersona.Visible = true;
					pnlFoto.Visible = true;
                    if (IdTipoPersona == 1)
                    {
                        pnlDomicilioParticular.Visible = true;
                        pnlParticulares.Visible = true;
                    }
                    else
                        pnlDomComercial.Visible = true;
                    //SelectTipoPersona(IdTipoPersona);
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
                    if (IdTipoPersona == 1)
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
                    if (IdTipoPersona == 1)
                    {
                        pnlParticulares.Visible = true;
                        lblEstadoCivil.Enabled = false;
                        cmbEstadoCivil.Enabled = false;
                    }
                    else
                        pnlDomComercial.Visible = true;
					pnlUrgencia.Visible = true;
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
                    }
                    else
                        pnlDomComercial.Visible = true;
                    reqApellido.Enabled = true;
                    reqNombre.Enabled = true;
                    pnlUrgencia.Visible = true;
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
			}
		}

		#endregion

        #region CargarReferencias(int idCliente, int idUsuario)
        private void CargarReferencias(int idCliente, int idUsuario)
        {
            ListaReferencia(idCliente, idUsuario);
            DateTime ahora = DateTime.Now;
            Usuario nUsuario = new Usuario();
            nUsuario.Cargar(idUsuario);
            string nomUsuario = nUsuario.Apellido + ", " + nUsuario.Nombre + " " + ahora.Day + "/" + ahora.Month;
            if (txtReferencia.Text == "") // || nomUsuario != txtReferencia.Text
                txtReferencia.Text = nomUsuario;

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
                DateTime d = DateTime.Parse(myRow[2].ToString());
                d.ToString("dd/MM/yyyy");
                myItem = new ListItem(myRow[1].ToString() + " (" + d.ToString("dd/MM/yyyy") + ", " + myRow[3].ToString() + " " + myRow[4].ToString() + ")", myRow[0].ToString());
                myItem.Attributes.Add("onclick", "asignarTextoReferencia('" + myRow[1].ToString() + "')");
                if (idCliente == int.Parse(myRow[0].ToString()))
                {
                    raReferenciaAnterior.SelectedIndex = -1;
                    myItem.Selected = true;
                }

                raReferenciaAnterior.Items.Add(myItem);
            }
        }

        #endregion


        #endregion

        #region Eventos

        #region Aceptar

        protected void Aceptar_Click(object sender, EventArgs e)
		{
			EncabezadoApp Encabezado = new EncabezadoApp();
			Encabezado.cargarEncabezado(int.Parse(idEncabezado.Value));
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado) Session["UsuarioAutenticado"];
			Encabezado.IdUsuario = Usuario.IdUsuario;
            Encabezado.idReferencia = int.Parse(idReferencia.Value);
			//Encabezado.Estado = 5;
            Encabezado.Estado = int.Parse(cmbEstados.SelectedValue);
			Encabezado.Comentarios = Observaciones.Text.ToUpper();
			if (raFoto.Items[0].Selected) Encabezado.ConFoto = 1;
			else Encabezado.ConFoto = 0;
			//Encabezado.Caracter = int.Parse(cmbCaracter.SelectedValue);
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
            // PROPIEDAD OTRAS PROVINCIAS
            Encabezado.ProvinciaOtra = int.Parse(cmbProvinciaOtra.SelectedValue);
            Encabezado.LocalidadOtra = int.Parse(cmbLocalidadOtra.SelectedValue);

            if (hIdTransferido.Value != "")
                Encabezado.IdEncabezadoTransferido = int.Parse(hIdTransferido.Value);

            // VERIFICACION DE DEFUNCIÓN
            if (cmbSexo.SelectedValue != "")
                Encabezado.Sexo = int.Parse(cmbSexo.SelectedValue);

            // INFORMES PARTIDAS DEFUNCIÓN
            Encabezado.TomoFallecido = txtTomoFallecido.Text;
            Encabezado.FolioFallecido = txtFolioFallecido.Text;
            Encabezado.ActaFallecido = txtActaFallecido.Text;
            Encabezado.FechaFallecido = txtFechaFallecimiento.Text;
            Encabezado.LugarFallecido = txtLugarFallecido.Text;

			Encabezado.Modificar(int.Parse(idEncabezado.Value));

            if (Request.QueryString["desdeRef"] != null)
                Response.Redirect("/BandejaEntrada/Referencias/altaReferencia.aspx?IdReferencia=" + idReferencia.Value);
			//if (idReferencia.Value == "0")
            else
				Response.Redirect("Principal.aspx?idTipo=" + cmbTipoInforme.SelectedValue);
			
				
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
		}

		#endregion

		# region cmbTipoGravamen_SelectedIndexChanged

		protected void cmbTipoGravamen_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectGravamen(int.Parse(cmbTipoGravamen.SelectedValue));
            cmbTipoGravamen.Focus();
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
                pnlCatastralDireccion.Visible = false;
                cmbProvinciaCatastro.Enabled = true;
                cmbLocalidadCatastro.Enabled = true;
                NumeroCatastro.Visible = true;
                lblNumero.Visible = true;
            }
            cmbTipoCatastral.Focus();
		}

		#endregion

		#region DropDownList1_SelectedIndexChanged

		protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectTipoPropiedad(int.Parse(cmbTipoPropiedad.SelectedValue));
            cmbTipoPropiedad.Focus();
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

		#region cmbTipoPersona_SelectedIndexChanged

		protected void cmbTipoPersona_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SelectTipoPersona(int.Parse(cmbTipoPersona.SelectedValue));
            cmbTipoPersona.Focus();
		}

		#endregion

		#endregion		
        protected void txtReferencia_PreRender(object sender, EventArgs e)
        {
            txtReferencia.Attributes.Add("onblur", "verificarReferencia(this);");
        }
        protected void btnCancelar_PreRender(object sender, EventArgs e)
        {
            //btnCancelar.Attributes.Add("onClick", "document.forms[0].elements['txtReferencia'].value = ''; document.forms[0].elements['idReferencia'].value = '';");
        }

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

        private void ListaEstados(int Estado)
        {
            if (Estado == 1) { Estado = 5; }
            if (Estado == 4) { Estado = 5; }
            
            EncabezadoApp Estados = new EncabezadoApp();
            cmbEstados.Items.Clear();
            DataTable myTable = Estados.TraerEstados(true);
            ListItem myItem;
            foreach (DataRow myRow in myTable.Rows)
            {
                if ((Estado == 9 && int.Parse(myRow[0].ToString()) != 2) || (Estado == 2 && int.Parse(myRow[0].ToString()) != 9) || (Estado == 5) || (Estado == 10) || (Estado == 11))
                {
                    if (!(int.Parse(myRow[0].ToString()) == 1 || int.Parse(myRow[0].ToString()) == 3 || int.Parse(myRow[0].ToString()) == 4 || int.Parse(myRow[0].ToString()) == 6 || int.Parse(myRow[0].ToString()) == 7 || int.Parse(myRow[0].ToString()) == 8))
                    {
                        if (int.Parse(myRow[0].ToString()) == 5)
                        {
                            myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());

                            if (Estado.ToString() == myRow[0].ToString())
                            {
                                cmbEstados.SelectedIndex = -1;
                                myItem.Selected = true;
                            }
                            cmbEstados.Items.Add(myItem);
                        }

                        if ((Estado == 2 && int.Parse(myRow[0].ToString()) == 2) || (Estado == 9 && int.Parse(myRow[0].ToString()) == 9) || (Estado == 10 && int.Parse(myRow[0].ToString()) == 10) || (Estado == 11 && int.Parse(myRow[0].ToString()) == 11))
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
                }
            }
        }


        protected void cargarTransferido(int idInforme)
        {
            pnTransferido.Visible = true;

            EncabezadoApp transInforme = new EncabezadoApp();
            transInforme.cargarEncabezado(idInforme);
            lblInformeTransferido.Text = transInforme.TraerDescripcionInforme();
            Observaciones.Text = "Viene de " + transInforme.TraerDescripcionInforme().Replace("<B>", "").Replace("</B>", "");
            
            hIdTransferido.Value = idInforme.ToString();
            txtLegajo.Focus();
        }

    }
}