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

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.ambientalBancor
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
					CargarCampos(raTipoVivienda,13,-1);
					CargarCampos(raEstadoCons,18,-1);
					CargarCampos(raTipoConstruccion,14,-1);
					CargarCampos(raTipoZona,15,-1);
					CargarCampos(raDestino,12,-1);
					CargarCampos(raInteresado,16,-1);
                    CargarCampos(raResultado, 17, -1);
					LoadAmbientalBancor(int.Parse(idInforme.Value));
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

		private void LoadAmbientalBancor(int Id)
		{
			AmbientalBancorApp oAmbientalBancor = new AmbientalBancorApp();
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
			bool cargar = oAmbientalBancor.cargarAmbientalBancor(Id);
			if (cargar)
			{
				idReferencia.Value = (1).ToString();
				CargarTipoDocumento(-1);
				CargarForm(oAmbientalBancor);
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
			hypMasFotos.Attributes.Add("onClick", "window.open('/imagenes/lista.aspx?Tipo=ambientalbancor&idInforme=" + idInforme + "','','width=500,height=400')");
		}

		
		private void CargarEncabezado(EncabezadoApp oEncabezado)
		{
			idTipoPersona.Value = oEncabezado.IdTipoPersona.ToString();

			txtNombre.Text = oEncabezado.Nombre;
			txtApellido.Text = oEncabezado.Apellido;
			CargarComboProvincias(cmbProvincia, oEncabezado.Provincia);
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, oEncabezado.Localidad.ToString());
			CargarTipoDocumento(oEncabezado.TipoDocumento);
			txtDocumento.Text = oEncabezado.Documento;
			txtCalle.Text = oEncabezado.Calle;
			txtBarrio.Text = oEncabezado.Barrio;
			txtNro.Text = oEncabezado.Nro;
			txtPiso.Text = oEncabezado.Piso;
			txtDepto.Text = oEncabezado.Dpto;
            txtLote.Text = oEncabezado.Lote;
            txtManzana.Text = oEncabezado.Manzana;
			txtCP.Text = oEncabezado.CP;
            txtComplejo.Text = oEncabezado.Complejo;
            txtTorre.Text = oEncabezado.Torre;
			txtTelefono.Text = oEncabezado.TelefonoEmpresa;
			txtObservaciones.Text = oEncabezado.Observaciones;
			//hidConFoto.Value = oEncabezado.ConFoto.ToString();
			//mostrarFoto(oEncabezado.ConFoto);
			
		}


		private void CargarForm(AmbientalBancorApp oAmbientalBancor)
		{
			CultureInfo myInfo = new CultureInfo("es-AR");

			idInforme.Value= oAmbientalBancor.IdInforme.ToString();
			idTipoPersona.Value = oAmbientalBancor.IdTipoPersona.ToString();
			txtNombre.Text= oAmbientalBancor.Nombre;
			txtApellido.Text = oAmbientalBancor.Apellido;
			CargarTipoDocumento(oAmbientalBancor.TipoDocumento);
			txtDocumento.Text = oAmbientalBancor.Documento;
			txtCalle.Text= oAmbientalBancor.Calle;
			txtBarrio.Text= oAmbientalBancor.Barrio;
			txtNro.Text= oAmbientalBancor.Nro;
			txtPiso.Text= oAmbientalBancor.Piso;
			txtDepto.Text= oAmbientalBancor.Depto;
            txtLote.Text = oAmbientalBancor.Lote;
			txtCP.Text= oAmbientalBancor.CP;
            txtComplejo.Text = oAmbientalBancor.Complejo;
            txtTorre.Text = oAmbientalBancor.Torre;
			txtTelefono.Text= oAmbientalBancor.Telefono;
			CargarComboProvincias(cmbProvincia, oAmbientalBancor.IdProvincia);
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, oAmbientalBancor.IdLocalidad.ToString());
			if (oAmbientalBancor.Fecha != "")
				txtFecha.Text= DateTime.Parse(oAmbientalBancor.Fecha).ToString("dd/MM/yyyy",DateTimeFormatInfo.InvariantInfo);
			txtHabita.Text = oAmbientalBancor.Habita;
			txtAntiguedad.Text = oAmbientalBancor.Antiguedad;
			txtTelAlternativo.Text = oAmbientalBancor.TelAlternativo;
            txtEmail.Text = oAmbientalBancor.Email;
            txtRelacionTitular.Text = oAmbientalBancor.RelacionTitular;
			CargarCampos(raTipoVivienda,13,oAmbientalBancor.TipoVivienda);
			CargarCampos(raEstadoCons,18,oAmbientalBancor.EstadoCons);
			CargarCampos(raTipoConstruccion,14,oAmbientalBancor.TipoConstruccion);
			CargarCampos(raTipoZona,15,oAmbientalBancor.TipoZona);
			CargarCampos(raDestino,12,oAmbientalBancor.Destino);
			CargarCampos(raInteresado,16,oAmbientalBancor.Interesado);
            CargarCampos(raResultado, 17, oAmbientalBancor.Resultado);
			//txtAccesoDomicilio.Text = oAmbientalBancor.AccesoDomicilio;
			txtInformo.Text = oAmbientalBancor.Informo;
			txtRelacion.Text = oAmbientalBancor.Relacion;
			txtNombreVecino.Text = oAmbientalBancor.NombreVecino;
			txtDomicilioVecino.Text = oAmbientalBancor.DomicilioVecino;
			txtConoceVecino.Text = oAmbientalBancor.ConoceVecino;
            txtNombreVecino2.Text = oAmbientalBancor.NombreVecino2;
            txtDomicilioVecino2.Text = oAmbientalBancor.DomicilioVecino2;
            txtConoceVecino2.Text = oAmbientalBancor.ConoceVecino2;
			txtObservaciones.Text = oAmbientalBancor.Observaciones;
			txtPlanoA.Text = oAmbientalBancor.PlanoA;
			txtPlanoB.Text = oAmbientalBancor.PlanoB;
			txtPlanoC.Text = oAmbientalBancor.PlanoC;
			txtPlanoD.Text = oAmbientalBancor.PlanoD;
			//mostrarFoto(oAmbientalBancor.ConFoto);
			//hidConFoto.Value = oAmbientalBancor.ConFoto.ToString();


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
			
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=15");

		}

		protected void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=15");
		}

		protected void cmbProvincia_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, "");
            cmbProvincia.Focus();
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


		private void CargarCampos(RadioButtonList campo,int idTipo, int valor)
		{
			campo.Items.Clear();
			AmbientalBancorApp oAmbientalBancor = new AmbientalBancorApp();
			DataTable dtTraerCampo = oAmbientalBancor.TraerCampo(idTipo);
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
                strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=15&idInforme=" + idInforme.Value + "&Finalizar=1','','dialogWidth:400px;dialogHeight:250px');";
				strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=15'";
				strScript += "</script>";

				ActualizarInforme();
				Page.RegisterStartupScript("CambiarEstado", strScript);
			}
		}

		private void ActualizarInforme()
		{
			AmbientalBancorApp oAmbientalBancor = new AmbientalBancorApp();
			bool cargar = oAmbientalBancor.cargarAmbientalBancor(int.Parse(idInforme.Value));
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			oAmbientalBancor.IdCliente = Usuario.IdCliente;
			oAmbientalBancor.IdUsuario = Usuario.IdUsuario;
			
			oAmbientalBancor.IdInforme = int.Parse(idInforme.Value);
			oAmbientalBancor.IdTipoPersona = int.Parse(idTipoPersona.Value);
			oAmbientalBancor.Nombre = txtNombre.Text;
			oAmbientalBancor.Apellido = txtApellido.Text;
			oAmbientalBancor.TipoDocumento = int.Parse(cmbTipoDocumento.SelectedItem.Value);
			oAmbientalBancor.Documento = txtDocumento.Text;
			oAmbientalBancor.Calle = txtCalle.Text;
			oAmbientalBancor.Barrio = txtBarrio.Text;
			oAmbientalBancor.Nro = txtNro.Text;
			oAmbientalBancor.Piso = txtPiso.Text;
			oAmbientalBancor.Depto = txtDepto.Text;
			oAmbientalBancor.CP = txtCP.Text;
            oAmbientalBancor.Lote = txtLote.Text;
            oAmbientalBancor.Manzana = txtManzana.Text;
            oAmbientalBancor.Complejo = txtComplejo.Text;
            oAmbientalBancor.Torre = txtTorre.Text;
            oAmbientalBancor.Email = txtEmail.Text;
			oAmbientalBancor.Telefono = txtTelefono.Text;
			if (oAmbientalBancor.IdTipoPersona == 1)
			{
				oAmbientalBancor.IdProvincia = int.Parse(cmbProvincia.SelectedValue);
				oAmbientalBancor.IdLocalidad = int.Parse(cmbLocalidad.SelectedValue);
			}
			oAmbientalBancor.Fecha = txtFecha.Text;
			oAmbientalBancor.Habita = txtHabita.Text;
			oAmbientalBancor.Antiguedad = txtAntiguedad.Text;
			oAmbientalBancor.TelAlternativo = txtTelAlternativo.Text;
            oAmbientalBancor.RelacionTitular = txtRelacionTitular.Text;
			if (raTipoVivienda.SelectedValue != "")
			oAmbientalBancor.TipoVivienda = int.Parse(raTipoVivienda.SelectedValue);
			if (raEstadoCons.SelectedValue != "")
			oAmbientalBancor.EstadoCons = int.Parse(raEstadoCons.SelectedValue);
			if (raTipoConstruccion.SelectedValue != "")
			oAmbientalBancor.TipoConstruccion = int.Parse(raTipoConstruccion.SelectedValue);
			if (raTipoZona.SelectedValue != "")
			oAmbientalBancor.TipoZona = int.Parse(raTipoZona.SelectedValue);
			if (raDestino.SelectedValue != "")
			oAmbientalBancor.Destino = int.Parse(raDestino.SelectedValue);
			if (raInteresado.SelectedValue != "")
			oAmbientalBancor.Interesado = int.Parse(raInteresado.SelectedValue);
            oAmbientalBancor.AccesoDomicilio = ""; // txtAccesoDomicilio.Text;
			oAmbientalBancor.Informo = txtInformo.Text;
			oAmbientalBancor.Relacion = txtRelacion.Text;
			oAmbientalBancor.NombreVecino = txtNombreVecino.Text;
			oAmbientalBancor.DomicilioVecino = txtDomicilioVecino.Text;
			oAmbientalBancor.ConoceVecino = txtConoceVecino.Text;
            oAmbientalBancor.NombreVecino2 = txtNombreVecino2.Text;
            oAmbientalBancor.DomicilioVecino2 = txtDomicilioVecino2.Text;
            oAmbientalBancor.ConoceVecino2 = txtConoceVecino2.Text;
			oAmbientalBancor.Observaciones = txtObservaciones.Text;
			oAmbientalBancor.PlanoA = txtPlanoA.Text;
			oAmbientalBancor.PlanoB = txtPlanoB.Text;
			oAmbientalBancor.PlanoC = txtPlanoC.Text;
			oAmbientalBancor.PlanoD = txtPlanoD.Text;
			oAmbientalBancor.ConFoto = ((bool)ViewState["ConFoto"])? 1: 0;
            oAmbientalBancor.Resultado = int.Parse(raResultado.SelectedValue);

			if(int.Parse(idReferencia.Value) == 0)
				oAmbientalBancor.Crear();
			else
				oAmbientalBancor.Modificar(int.Parse(idInforme.Value));


            if (oAmbientalBancor.IdTipoPersona == 1)
            {
                PersonasAPP persona = new PersonasAPP();
                persona.Nombre = txtNombre.Text;
                persona.Apellido = txtApellido.Text;
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
}
}
