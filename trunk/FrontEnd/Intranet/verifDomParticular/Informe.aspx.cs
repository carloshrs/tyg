using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Verificaciones.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.verifDomParticular
{
	/// <summary>
	/// Summary description for altaInforme.
	/// </summary>
	public partial class Informe : Page
	{
		protected TextBox Provincia;
		protected Image Image1;
		protected Image Image2;
		protected Image Image3;
		protected Image Image4;
		protected Label lblObservaciones;
		protected Button Cerrar;
		protected Label Label2;
		protected Label Label8;
		protected TextBox txtMovParticular;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidConFoto;
	
		protected void Page_Load(object sender, EventArgs e)
		{
			idInforme.Value = Request.QueryString["id"];

			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{	
					CargarCampos(raTipoVivienda,7,-1);
					CargarCampos(raEstadoCons,6,-1);
					CargarCampos(raTipoConstruccion,8,-1);
					CargarCampos(raTipoZona,9,-1);
					CargarCampos(raTipoCalle,10,-1);
					CargarCampos(raInteresado,11,-1);
					LoadVerifDomParticular(int.Parse(idInforme.Value));
				}
                txtBarrio_AutoCompleteExtender.ContextKey = cmbLocalidad.SelectedValue;

				//imgCheckPersona.Attributes.Add("onClick", "Javascript:ChequearPersona();return false;");
			}
			CargarImagen();

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

		private void LoadVerifDomParticular(int Id)
		{
			VerifDomParticularApp oVerifDom = new VerifDomParticularApp();
			EncabezadoApp oEncabezado = new EncabezadoApp();
			oEncabezado.cargarEncabezado(Id);
            CargarDatosContacto(oEncabezado);
			ViewState["ConFoto"] = true;
			if (oEncabezado.ConFoto == 1)
			{
				pnlImagenes.Visible = true;
				hypMasFotos.Attributes.Add("onClick", "javascript:mostrarImagenes('/Admin/Imagenes/AbmImagenes.aspx?Informe=" + oEncabezado.IdEncabezado.ToString() + "');");
				CargarImagen();
			}
			else
				pnlImagenes.Visible = false;
			bool cargar = oVerifDom.cargarVerifDomParticular(Id);
			if (cargar)
			{
				idReferencia.Value = (1).ToString();
				CargarTipoDocumento(-1);
				CargarEstadoCivil(-1);
				CargarForm(oVerifDom);
			}
			else
			{
				idReferencia.Value = (0).ToString();
				CargarEncabezado(oEncabezado);
			}
            if (oEncabezado.Leido == 0)
            {
                oEncabezado.Leido = 1;
                oEncabezado.CambiarLeido(Id);
            }
		}


		private void CargarMasFotos(int idInforme)
		{
			hypMasFotos.Attributes.Add("onClick", "window.open('/imagenes/lista.aspx?Tipo=verifParticular&idInforme=" + idInforme + "','','width=500,height=400')");
		}

		
		private void CargarEncabezado(EncabezadoApp oEncabezado)
		{
			idTipoPersona.Value = oEncabezado.IdTipoPersona.ToString();

			txtNombre.Text = oEncabezado.Nombre;
			txtApellido.Text = oEncabezado.Apellido;
			CargarComboProvincias(cmbProvincia, oEncabezado.Provincia);
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, oEncabezado.Localidad.ToString());
			CargarTipoDocumento(oEncabezado.TipoDocumento);
			CargarEstadoCivil(oEncabezado.EstadoCivil);
			txtDocumento.Text = oEncabezado.Documento;
			txtCalle.Text = oEncabezado.Calle;
			txtBarrio.Text = oEncabezado.Barrio;
			txtNro.Text = oEncabezado.Nro;
			txtPiso.Text = oEncabezado.Piso;
			txtDepto.Text = oEncabezado.Dpto;
			txtCP.Text = oEncabezado.CP;
            txtLote.Text = oEncabezado.Lote;
            txtManzana.Text = oEncabezado.Manzana;
            txtComplejo.Text = oEncabezado.Complejo;
            txtTorre.Text = oEncabezado.Torre;
			txtTelefono.Text = oEncabezado.TelefonoEmpresa;
			txtObservaciones.Text = oEncabezado.Observaciones;
			//hidConFoto.Value = oEncabezado.ConFoto.ToString();
			//mostrarFoto(oEncabezado.ConFoto);
			
			
			//EMPRESA
			RazonSocial.Text = oEncabezado.RazonSocial;
			NombreFantasia.Text = oEncabezado.NombreFantasia;
			Telefono.Text = oEncabezado.TelefonoEmpresa;
			Rubro.Text = oEncabezado.Rubro;
			Cuit.Text = oEncabezado.Cuit;
			CalleEmpresa.Text = oEncabezado.CalleEmpresa;
			NroEmpresa.Text = oEncabezado.NroEmpresa;
			DptoEmpresa.Text = oEncabezado.DptoEmpresa;
			PisoEmpresa.Text = oEncabezado.PisoEmpresa;
			BarrioEmpresa.Text = oEncabezado.BarrioEmpresa;
			CPEmpresa.Text = oEncabezado.CPEmpresa;
			// Empresas
			CargarComboProvincias(cmbProvinciaEmpresas, oEncabezado.ProvinciaEmpresa);
			CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, oEncabezado.LocalidadEmpresa.ToString());

			
			if (oEncabezado.IdTipoPersona == 1) 
			{
				pnlDomComercial.Visible = false;
				pnlFisica.Visible = true;
			} 
			else 
			{
				pnlDomComercial.Visible = true;
				pnlFisica.Visible = false;
			}

		}


		private void CargarForm(VerifDomParticularApp oVerifDom)
		{
			CultureInfo myInfo = new CultureInfo("es-AR");

			idInforme.Value= oVerifDom.IdInforme.ToString();
			idTipoPersona.Value = oVerifDom.IdTipoPersona.ToString();
			txtNombre.Text= oVerifDom.Nombre;
			txtApellido.Text = oVerifDom.Apellido;
			CargarTipoDocumento(oVerifDom.TipoDocumento);
			CargarEstadoCivil(oVerifDom.EstadoCivil);
			txtDocumento.Text = oVerifDom.Documento;
			txtCalle.Text= oVerifDom.Calle;
			txtBarrio.Text= oVerifDom.Barrio;
			txtNro.Text= oVerifDom.Nro;
			txtPiso.Text= oVerifDom.Piso;
			txtDepto.Text= oVerifDom.Depto;
			txtCP.Text= oVerifDom.CP;
            txtLote.Text = oVerifDom.Lote;
            txtManzana.Text = oVerifDom.Manzana;
            txtComplejo.Text = oVerifDom.Complejo;
            txtTorre.Text = oVerifDom.Torre;
			txtTelefono.Text= oVerifDom.Telefono;
			CargarComboProvincias(cmbProvincia, oVerifDom.IdProvincia);
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, oVerifDom.IdLocalidad.ToString());

			//EMPRESA
			RazonSocial.Text = oVerifDom.RazonSocial;
			NombreFantasia.Text = oVerifDom.NombreFantasia;
			Telefono.Text = oVerifDom.TelefonoEmpresa;
			Rubro.Text = oVerifDom.Rubro;
			Cuit.Text = oVerifDom.Cuit;
			CalleEmpresa.Text = oVerifDom.CalleEmpresa;
			NroEmpresa.Text = oVerifDom.NroEmpresa;
			DptoEmpresa.Text = oVerifDom.DptoEmpresa;
			PisoEmpresa.Text = oVerifDom.PisoEmpresa;
			BarrioEmpresa.Text = oVerifDom.BarrioEmpresa;
			CPEmpresa.Text = oVerifDom.CPEmpresa;
			// Empresas
			CargarComboProvincias(cmbProvinciaEmpresas, oVerifDom.ProvinciaEmpresa);
			CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, oVerifDom.LocalidadEmpresa.ToString());

			
			if (oVerifDom.Fecha != "")
				txtFecha.Text= DateTime.Parse(oVerifDom.Fecha).ToString("dd/MM/yyyy",DateTimeFormatInfo.InvariantInfo);
			txtHabita.Text = oVerifDom.Habita;
			txtAntiguedad.Text = oVerifDom.Antiguedad;
			txtMontoAlquiler.Text = oVerifDom.MontoAlquiler;
			if (oVerifDom.VtoContrato != "")
				txtVencimiento.Text = DateTime.Parse(oVerifDom.VtoContrato).ToString("dd/MM/yyyy",DateTimeFormatInfo.InvariantInfo);
			txtTelAlternativo.Text = oVerifDom.TelAlternativo;
			txtEnviar.Text = oVerifDom.Enviar;
			CargarCampos(raTipoVivienda,7,oVerifDom.TipoVivienda);
			CargarCampos(raEstadoCons,6,oVerifDom.EstadoCons);
			CargarCampos(raTipoConstruccion,8,oVerifDom.TipoConstruccion);
			CargarCampos(raTipoZona,9,oVerifDom.TipoZona);
			CargarCampos(raTipoCalle,10,oVerifDom.TipoCalle);
			CargarCampos(raInteresado,11,oVerifDom.Interesado);
			txtAccesoDomicilio.Text = oVerifDom.AccesoDomicilio;
			txtInformo.Text = oVerifDom.Informo;
			txtRelacion.Text = oVerifDom.Relacion;
			txtNombreVecino.Text = oVerifDom.NombreVecino;
			txtDomicilioVecino.Text = oVerifDom.DomicilioVecino;
			txtConoceVecino.Text = oVerifDom.ConoceVecino;
			txtObservaciones.Text = oVerifDom.Observaciones;
			txtPlanoA.Text = oVerifDom.PlanoA;
			txtPlanoB.Text = oVerifDom.PlanoB;
			txtPlanoC.Text = oVerifDom.PlanoC;
			txtPlanoD.Text = oVerifDom.PlanoD;
			//mostrarFoto(oVerifDom.ConFoto);
			//hidConFoto.Value = oVerifDom.ConFoto.ToString();


			if (oVerifDom.IdTipoPersona == 1) 
			{
				pnlDomComercial.Visible = false;
				pnlFisica.Visible = true;
			} 
			else 
			{
				pnlDomComercial.Visible = true;
				pnlFisica.Visible = false;
			}

		}

		private void mostrarFoto(int estado)
		{
			if(estado == 1)
			{
				imgFoto.Visible = true;
				hypMasFotos.Visible = true;
			}

		}


        #region void CargarDatosContacto(EncabezadoApp enc)

        private void CargarDatosContacto(EncabezadoApp enc)
        {
            lblEncTelefono.Text = enc.AMBTelefono;
            lblEncMail.Text = enc.AMBEMail;
            lblEncApeCon.Text = enc.ApellidoCony;
            lblEncNomCon.Text = enc.NombreCony;
            lblEncNroDocCon.Text = enc.AMBDocumento;
            TipoDocumentoApp objTipoDocumento = new TipoDocumentoApp();
            DataTable dtTipoDoc = objTipoDocumento.TraerDatos();
            foreach (DataRow myRow in dtTipoDoc.Rows)
            {
                if (enc.AMBTipoDoc == int.Parse(myRow[0].ToString()))
                {
                    lblEncTipoDocCon.Text = myRow[1].ToString();
                    break;
                }
            }
            lblEncObservaciones.Text = enc.Comentarios;
        }

        #endregion


		protected void Aceptar_Click(object sender, EventArgs e)
		{
			ActualizarInforme();
			
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=5");

		}

		protected void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=5");
		}

		protected void cmbProvincia_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, "");
            cmbProvincia.Focus();
		}


		protected void cmbProvinciaEmpresas_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, "");
            cmbProvinciaEmpresas.Focus();
		}


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
			


		private void CargarTipoDocumento(int idTipo)
		{
			cmbTipoDocumento.Items.Clear();
			TipoDocumentoApp objTipoDocumento = new TipoDocumentoApp();
			DataTable dtTipoDoc = objTipoDocumento.TraerDatos();
			ListItem myItem;

			foreach(DataRow myRow in dtTipoDoc.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(idTipo == int.Parse(myRow[0].ToString()))
				{
					cmbTipoDocumento.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbTipoDocumento.Items.Add(myItem);
			}
		}

		private void CargarEstadoCivil(int idEstado)
		{
			EstadoCivilApp objEstadoCivil = new EstadoCivilApp();
			DataTable dtEstadoCivil = objEstadoCivil.TraerDatos();
			ListItem myItem;

			foreach(DataRow myRow in dtEstadoCivil.Rows)
			{
				myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
				if(idEstado == int.Parse(myRow[0].ToString()))
				{
					cmbEstadoCivil.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbEstadoCivil.Items.Add(myItem);
			}
		}


		private void CargarCampos(RadioButtonList campo,int idTipo, int valor)
		{
			campo.Items.Clear();
			VerifDomParticularApp oVerifDom = new VerifDomParticularApp();
			DataTable dtTraerCampo = oVerifDom.TraerCampo(idTipo);
			ListItem myItem;

			foreach(DataRow myRow in dtTraerCampo.Rows)
			{
				myItem = new ListItem(" " + myRow[1].ToString(), myRow[0].ToString());
				if(valor == int.Parse(myRow[0].ToString()))
				{
					campo.SelectedIndex = -1;
					myItem.Selected = true;
				}
					campo.Items.Add(myItem);
			}
		}

		protected void AceptarFinalizar_Click(object sender, System.EventArgs e)
		{
			EncabezadoApp oEncabezado = new EncabezadoApp();
			oEncabezado.cargarEncabezado(int.Parse(idInforme.Value));
			if (oEncabezado.ConFoto == 1 && ImagenDal.NextImage(int.Parse(idInforme.Value)) == 1)
				lblMessage.Visible = true;
			else
			{
				string strScript;
				strScript = "<script languaje=\"Javascript\">";
                strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=5&idInforme=" + idInforme.Value + "&Finalizar=1','','dialogWidth:400px;dialogHeight:250px');";
				strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=5'";
				strScript += "</script>";

				ActualizarInforme();
				Page.RegisterStartupScript("CambiarEstado", strScript);
			}
		}

		private void ActualizarInforme()
		{
			VerifDomParticularApp oVerifDom = new VerifDomParticularApp();
			bool cargar = oVerifDom.cargarVerifDomParticular(int.Parse(idInforme.Value));
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			oVerifDom.IdCliente = Usuario.IdCliente;
			oVerifDom.IdUsuario = Usuario.IdUsuario;
			
			oVerifDom.IdInforme = int.Parse(idInforme.Value);
			oVerifDom.IdTipoPersona = int.Parse(idTipoPersona.Value);
			oVerifDom.Nombre = txtNombre.Text;
			oVerifDom.Apellido = txtApellido.Text;
			oVerifDom.TipoDocumento = int.Parse(cmbTipoDocumento.SelectedItem.Value);
			oVerifDom.Documento = txtDocumento.Text;
			oVerifDom.EstadoCivil = int.Parse(cmbEstadoCivil.SelectedValue);
			oVerifDom.Calle = txtCalle.Text;
			oVerifDom.Barrio = txtBarrio.Text;
			oVerifDom.Nro = txtNro.Text;
			oVerifDom.Piso = txtPiso.Text;
			oVerifDom.Depto = txtDepto.Text;
			oVerifDom.CP = txtCP.Text;
            oVerifDom.Lote = txtLote.Text;
            oVerifDom.Manzana = txtManzana.Text;
            oVerifDom.Complejo = txtComplejo.Text;
            oVerifDom.Torre = txtTorre.Text;
			oVerifDom.Telefono = txtTelefono.Text;
			if (oVerifDom.IdTipoPersona == 1)
			{
				oVerifDom.IdProvincia = int.Parse(cmbProvincia.SelectedValue);
				oVerifDom.IdLocalidad = int.Parse(cmbLocalidad.SelectedValue);
			}

			//EMPRESA
			oVerifDom.RazonSocial = RazonSocial.Text;
			oVerifDom.NombreFantasia = NombreFantasia.Text;
			oVerifDom.TelefonoEmpresa = Telefono.Text;
			oVerifDom.Rubro = Rubro.Text;
			oVerifDom.Cuit = Cuit.Text;
			oVerifDom.CalleEmpresa = CalleEmpresa.Text;
			oVerifDom.NroEmpresa = NroEmpresa.Text;
			oVerifDom.DptoEmpresa = DptoEmpresa.Text;
			oVerifDom.PisoEmpresa = PisoEmpresa.Text;
			oVerifDom.BarrioEmpresa = BarrioEmpresa.Text;
			oVerifDom.CPEmpresa = CPEmpresa.Text;
			if (oVerifDom.IdTipoPersona == 2)
			{
				oVerifDom.ProvinciaEmpresa = int.Parse(cmbProvinciaEmpresas.SelectedValue);
				oVerifDom.LocalidadEmpresa = int.Parse(cmbLocalidadEmpresas.SelectedValue);
			}

			oVerifDom.Fecha = txtFecha.Text;
			oVerifDom.Habita = txtHabita.Text;
			oVerifDom.Antiguedad = txtAntiguedad.Text;
			oVerifDom.MontoAlquiler = txtMontoAlquiler.Text;
			oVerifDom.VtoContrato = txtVencimiento.Text;
			oVerifDom.TelAlternativo = txtTelAlternativo.Text;
			oVerifDom.Enviar = txtEnviar.Text;
			if (raTipoVivienda.SelectedValue != "")
			oVerifDom.TipoVivienda = int.Parse(raTipoVivienda.SelectedValue);
			if (raEstadoCons.SelectedValue != "")
			oVerifDom.EstadoCons = int.Parse(raEstadoCons.SelectedValue);
			if (raTipoConstruccion.SelectedValue != "")
			oVerifDom.TipoConstruccion = int.Parse(raTipoConstruccion.SelectedValue);
			if (raTipoZona.SelectedValue != "")
			oVerifDom.TipoZona = int.Parse(raTipoZona.SelectedValue);
			if (raTipoCalle.SelectedValue != "")
			oVerifDom.TipoCalle = int.Parse(raTipoCalle.SelectedValue);
			if (raInteresado.SelectedValue != "")
			oVerifDom.Interesado = int.Parse(raInteresado.SelectedValue);
			oVerifDom.AccesoDomicilio = txtAccesoDomicilio.Text;
			oVerifDom.Informo = txtInformo.Text;
			oVerifDom.Relacion = txtRelacion.Text;
			oVerifDom.NombreVecino = txtNombreVecino.Text;
			oVerifDom.DomicilioVecino = txtDomicilioVecino.Text;
			oVerifDom.ConoceVecino = txtConoceVecino.Text;
			oVerifDom.Observaciones = txtObservaciones.Text;
			oVerifDom.PlanoA = txtPlanoA.Text;
			oVerifDom.PlanoB = txtPlanoB.Text;
			oVerifDom.PlanoC = txtPlanoC.Text;
			oVerifDom.PlanoD = txtPlanoD.Text;
			oVerifDom.ConFoto = ((bool)ViewState["ConFoto"])? 1: 0;

			if(int.Parse(idReferencia.Value) == 0)
				oVerifDom.Crear();
			else
				oVerifDom.Modificar(int.Parse(idInforme.Value));


            if (oVerifDom.IdTipoPersona == 1 && txtDocumento.Text != "")
            {
                PersonasAPP persona = new PersonasAPP();
                persona.Nombre = txtNombre.Text;
                persona.Apellido = txtApellido.Text;
                persona.EstadoCivil = int.Parse(cmbEstadoCivil.SelectedValue);
                persona.TipoDocumento = int.Parse(cmbTipoDocumento.SelectedItem.Value);
                persona.Documento = txtDocumento.Text;
                bool resultado = persona.Crear();
            }

		}

		private void CargarImagen()
		{
			string vImagen = "/img/shim.gif";
			ImagenDal imagen = new ImagenDal();
			imagen.Cargar(int.Parse(idInforme.Value));
			if(imagen.Path != "") 
				vImagen = imagen.Path;
			else
				imgFoto.BorderWidth = 0;
			imgFoto.ImageUrl = vImagen;
			imgFoto.ToolTip = imagen.Descripcion;
		}



        protected void btnObtener_PreRender(object sender, EventArgs e)
        {
            btnObtener.Attributes.Add("onClick", "GetServerTime(document.getElementById('txtDocumento').value)");        
        }
        protected void Rechazar_Click(object sender, EventArgs e)
        {
            string strScript;
            strScript = "<script languaje=\"Javascript\">";
            strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=5&idInforme=" + idInforme.Value + "&Rechazar=1','','dialogWidth:400px;dialogHeight:250px');";
            strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=5'";
            strScript += "</script>";

            Page.RegisterStartupScript("CambiarEstado", strScript);
        }
}
}
