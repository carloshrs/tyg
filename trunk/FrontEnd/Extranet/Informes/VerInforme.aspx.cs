using System;
using System.Data;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.Informes
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class verInforme : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RequiredFieldValidator reqNombre;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqApellido;
		protected System.Web.UI.WebControls.DropDownList cmbEstadoCivil;
		protected System.Web.UI.WebControls.DropDownList cmbTipoDocumento;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator6;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator7;
		protected System.Web.UI.WebControls.DropDownList cmbProvincia;
		protected System.Web.UI.WebControls.DropDownList cmbLocalidad;
		private int IdInforme;
	
		protected void Page_Load(object sender, System.EventArgs e)
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
			EncabezadoApp encabezado = new EncabezadoApp();
			encabezado.cargarEncabezado(Id);
			CargarForm(encabezado);
		}

		private void CargarForm(EncabezadoApp Encabezado)
		{
			CargarComboTipoInforme(Encabezado.IdTipoInforme);
            CambioPaneles(Encabezado.IdTipoInforme, Encabezado.IdTipoPersona);
			idEncabezado.Value= Encabezado.IdEncabezado.ToString();
			idReferencia.Value= "0";
			if(Encabezado.idReferencia.ToString() != null) idReferencia.Value= Encabezado.idReferencia.ToString();
			//IdTipo = Encabezado.IdTipoInforme;
			lblObservaciones.Text= Encabezado.Observaciones;

			cmbTipoPersona.SelectedValue = Encabezado.IdTipoPersona.ToString();
			//SelectTipoPersona(Encabezado.IdTipoPersona);

			txtNombre.Text = Encabezado.Nombre;
			txtApellido.Text= Encabezado.Apellido;
			//Cargo Estado Civil
			txtEstadoCivil.Text= LoadEstadoCivil(Encabezado.EstadoCivil);
			//Cargo Tipo DNI
			txtTipoDoc.Text= LoadTipoDNI(Encabezado.TipoDocumento);
			txtDocumento.Text= Encabezado.Documento;
			txtCalle.Text= Encabezado.Calle;
			txtNro.Text= Encabezado.Nro;
			txtDepto.Text= Encabezado.Dpto;
			txtPiso.Text= Encabezado.Piso;
			txtBarrio.Text= Encabezado.Barrio;
			txtCP.Text= Encabezado.CP;
            txtLote.Text = Encabezado.Lote;
            txtManzana.Text = Encabezado.Manzana;
            txtComplejo.Text = Encabezado.Complejo;
            txtTorre.Text = Encabezado.Torre;
			// Domicilio Particular
			txtProvincia.Text= CargarComboProvincias(Encabezado.Provincia);
			txtLocalidad.Text= CargarComboLocalidades(Encabezado.Provincia, Encabezado.Localidad);
			//Foto y Caracter
			chkFoto.Checked = (Encabezado.ConFoto == 1);
			LoadCaracter(Encabezado.Caracter);
			// Automotores
			txtDominio.Text= Encabezado.Dominio;
			txtRegistro.Text= Encabezado.Registro;
			txtCalleRegistro.Text= Encabezado.CalleRegistro;
			txtNroRegistro.Text= Encabezado.NroRegistro;
			txtDptoRegistro.Text= Encabezado.DptoRegistro;
			txtPisoRegistro.Text= Encabezado.PisoRegistro;
			txtBarrioRegistro.Text= Encabezado.BarrioRegistro;
			txtCPRegistro.Text= Encabezado.CPRegistro;
			// Registro - Automotor
			txtProvinciaRegistro.Text = CargarComboProvincias(Encabezado.ProvinciaRegistro);
			txtLocalidadRegistro.Text= CargarComboLocalidades(Encabezado.ProvinciaRegistro, Encabezado.LocalidadRegistro);
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
			txtLegajo.Text= Encabezado.Matricula;
			txtFolio.Text= Encabezado.PropFolio;
			txtTomo.Text= Encabezado.PropTomo;
			txtAno.Text= Encabezado.PropAno;
            // PROPIEDAD OTRAS PROVINCIAS
            txtProvinciaOtra.Text = CargarComboProvincias(Encabezado.ProvinciaOtra);
            txtLocalidadOtra.Text = CargarComboLocalidades(Encabezado.ProvinciaOtra, Encabezado.LocalidadOtra);
			//AMBIENTE
			txtNombreAmb.Text= Encabezado.NombreCony;
			txtApellidoAmb.Text= Encabezado.ApellidoCony;
			//Cargo Tipo DNI
			txtTipoDocumentoAmb.Text= LoadTipoDNI(Encabezado.AMBTipoDoc);
			txtDocumentoAmb.Text= Encabezado.AMBDocumento;
			//CATASTRO	
			txtTipoCatastro.Text= LoadTipoCatastro(Encabezado.TipoCatastro);
			// Catastro
			numeroCatastro.Text= Encabezado.NumeroCatastro;
			txtProvinciaCatastro.Text= CargarComboProvincias(Encabezado.CatProvincia);
			txtLocalidadCatastro.Text= CargarComboLocalidades(Encabezado.CatProvincia, Encabezado.CatLocalidad);
			txtBarrioCatastro.Text= Encabezado.CatBarrio;
			txtCalleCatastro.Text= Encabezado.CatCalle;
			txtCPCatastro.Text= Encabezado.CatCP;
			txtDptoCatastro.Text= Encabezado.CatDpto;
			txtNroCatastro.Text= Encabezado.CatNro;
			txtPisoCatastro.Text= Encabezado.CatPiso;

			//EMPRESA
			txtRazonSocial.Text= Encabezado.RazonSocial;
			txtFantasia.Text= Encabezado.NombreFantasia;
			txtTelefono.Text= Encabezado.TelefonoEmpresa;
			txtRubro.Text= Encabezado.Rubro;
			txtCuit.Text= Encabezado.Cuit;
			txtCalleEmpresa.Text= Encabezado.CalleEmpresa ;
			txtNroEmpresa.Text= Encabezado.NroEmpresa;
			txtDptoEmpresa.Text= Encabezado.DptoEmpresa;
			txtPisoEmpresa.Text= Encabezado.PisoEmpresa;
			txtBarrioEmpresa.Text= Encabezado.BarrioEmpresa;
			txtCPEmpresa.Text= Encabezado.CPEmpresa;
			// Empresas
			txtProvinciaEmpresa.Text= CargarComboProvincias(Encabezado.ProvinciaEmpresa);
			txtLocalidadEmpresa.Text= CargarComboLocalidades(Encabezado.ProvinciaEmpresa, Encabezado.LocalidadEmpresa);

            if (Encabezado.FechaFin != "")
                lblFechaFin.Text = "Fecha finalizado: " + Encabezado.FechaFin;
		}

		protected void Cancelar_Click(object sender, System.EventArgs e)
		{
			//if(idReferencia.Value != null) 
			//{
			//	if (int.Parse(idReferencia.Value) > 0) Response.Redirect("/Referencias/altaReferencia.aspx?IdReferencia=" + idReferencia.Value);
			//	else Response.Redirect("ListaInformes.aspx");
			//} 				
			//else Response.Redirect("ListaInformes.aspx");

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



        private void CambioPaneles(int idTipoInforme, int idTipoPersona) 
		{
			pnlTitulo.Visible = false;
			pnlParticulares.Visible= false;
			pnlAutomotor.Visible = false;
			pnlGravamenes.Visible = false;
			pnlPropiedad.Visible= false;
			pnlAmbiental.Visible = false;
			pnlDomComercial.Visible = false;
			pnlDomicilioParticular.Visible = false;
			pnlCatastral.Visible = false;
			pnlFoto.Visible = false;
			pnlUrgencia.Visible= false;
			pnlTipoPersona.Visible = false;
            pnlInformePropiedadProvincias.Visible = false;
            switch (idTipoInforme)
			{
				case 1: // Propiedad
					pnlPropiedad.Visible= true;
					pnlUrgencia.Visible= true;
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
                    if (idTipoPersona == 1)
                    {
                        pnlParticulares.Visible = true;
                        pnlDomicilioParticular.Visible = true;
                    }
                    else
                        pnlDomComercial.Visible = true;
					
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
                    if (idTipoPersona == 1)
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
                    lblInformePropiedad.Text = "Informe Propiedad Otras Provincias";
					//pnlTitulo.Visible = true;
                    pnlPropiedad.Visible = true;
                    pnlUrgencia.Visible = true;
                    pnlInformePropiedadProvincias.Visible = true;
					break;
				case 12: // Informe Catastral
					pnlCatastral.Visible = true;
					break;
				case 13: // Búsqueda Propiedad
					pnlParticulares.Visible = true;
					pnlUrgencia.Visible= true;
					break;
				case 14: // Contractuales
					pnlParticulares.Visible = true;
					break;
                case 15: // Relevamiento Ambiental Bancor
                    pnlParticulares.Visible = true;
                    pnlDomicilioParticular.Visible = true;
                    pnlFoto.Visible = true;
                    break;
                case 16: // Informe Inhibición
                    if (idTipoPersona == 1)
                        pnlParticulares.Visible = true;
                    else
                        pnlDomComercial.Visible = true;
                    break;
                case 17: // Morosidad
                    if (idTipoPersona == 1)
                        pnlParticulares.Visible = true;
                    else
                        pnlDomComercial.Visible = true;
                    break;
			}
		}

		private void SelectTipoPropiedad(int idTipo)
		{
			switch(idTipo)
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
			SelectTipoPropiedad(idTipoPropiedad);	
			return TipoPropiedad;
		}

		private string LoadTipoCatastro(int idCatastro)
		{
			UtilesApp Tipos = new UtilesApp();
			string Catastro = "";
			DataTable myTb;
			myTb = Tipos.TraerTipoCatastro();
			foreach(DataRow myRow in myTb.Rows)
			{
				if(idCatastro.ToString() == myRow[0].ToString())
				{
					Catastro = myRow[1].ToString();
				}
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
			foreach(DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(idCaracter.ToString() == myRow[0].ToString())
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

		private String CargarComboLocalidades(int idProvincia, int IdLocalidad)
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
