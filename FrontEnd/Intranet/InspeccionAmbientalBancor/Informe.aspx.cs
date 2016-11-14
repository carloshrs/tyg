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

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.InspeccionAmbientalBancor
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
					
					LoadInspeccionAmbientalBancor(int.Parse(idInforme.Value));
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

        private void LoadInspeccionAmbientalBancor(int Id)
		{
            InspeccionAmbientalBancorApp oInspeccionAmbientalBancor = new InspeccionAmbientalBancorApp();
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
            bool cargar = oInspeccionAmbientalBancor.cargarInspeccionAmbientalBancor(Id);
			if (cargar)
			{
				idReferencia.Value = (1).ToString();
				CargarTipoDocumento(-1);
                CargarForm(oInspeccionAmbientalBancor);
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
			hypMasFotos.Attributes.Add("onClick", "window.open('/imagenes/lista.aspx?Tipo=inspeccionAmbientalbancor&idInforme=" + idInforme + "','','width=500,height=400')");
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


		private void CargarForm(InspeccionAmbientalBancorApp oInspeccionAmbientalBancor)
		{
			CultureInfo myInfo = new CultureInfo("es-AR");

			idInforme.Value= oInspeccionAmbientalBancor.IdInforme.ToString();
			idTipoPersona.Value = oInspeccionAmbientalBancor.IdTipoPersona.ToString();
			txtNombre.Text= oInspeccionAmbientalBancor.Nombre;
			txtApellido.Text = oInspeccionAmbientalBancor.Apellido;
			CargarTipoDocumento(oInspeccionAmbientalBancor.TipoDocumento);
			txtDocumento.Text = oInspeccionAmbientalBancor.Documento;
			txtCalle.Text= oInspeccionAmbientalBancor.Calle;
			txtBarrio.Text= oInspeccionAmbientalBancor.Barrio;
			txtNro.Text= oInspeccionAmbientalBancor.Nro;
			txtPiso.Text= oInspeccionAmbientalBancor.Piso;
			txtDepto.Text= oInspeccionAmbientalBancor.Depto;
            txtLote.Text = oInspeccionAmbientalBancor.Lote;
			txtCP.Text= oInspeccionAmbientalBancor.CP;
            txtComplejo.Text = oInspeccionAmbientalBancor.Complejo;
            txtTorre.Text = oInspeccionAmbientalBancor.Torre;
			txtTelefono.Text= oInspeccionAmbientalBancor.Telefono;
			CargarComboProvincias(cmbProvincia, oInspeccionAmbientalBancor.IdProvincia);
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, oInspeccionAmbientalBancor.IdLocalidad.ToString());
			if (oInspeccionAmbientalBancor.Fecha != "")
				txtFecha.Text= DateTime.Parse(oInspeccionAmbientalBancor.Fecha).ToString("dd/MM/yyyy",DateTimeFormatInfo.InvariantInfo);

            if (oInspeccionAmbientalBancor.IdHabita == 1)
                raHabitaSI.Checked = true;
            else
                raHabitaNO.Checked = true;

			txtCalidadDe.Text = oInspeccionAmbientalBancor.SICantidadIntegranGrupo;
			txtQuienHabita.Text = oInspeccionAmbientalBancor.NOQuienHabita;
			txtCalidadDe.Text = oInspeccionAmbientalBancor.NOCalidadDe;

            if (oInspeccionAmbientalBancor.IdAmpliaciones == 1)
                raAmpliacionesSI.Checked = true;
            else
                raAmpliacionesNO.Checked = true;

            txtAmpliacionesCuales.Text = oInspeccionAmbientalBancor.SICuales;

            if (oInspeccionAmbientalBancor.IdDepIndep == 1)
                raIndependiente.Checked = true;
            else
                raDependiente.Checked = true;

            txtEmpresa.Text = oInspeccionAmbientalBancor.DEPEmpresa;
            txtDireccion.Text = oInspeccionAmbientalBancor.DEPDireccion;
            txtIngresosMensuales.Text = oInspeccionAmbientalBancor.DEPIngresosMensuales;
            txtBanco.Text = oInspeccionAmbientalBancor.DEPBanco;
            txtActividad.Text = oInspeccionAmbientalBancor.INDEPActividad;
            txtDondeDesarrolla.Text = oInspeccionAmbientalBancor.INDEPDesarrolla;
            txtIngresosNetosFamiliares.Text = oInspeccionAmbientalBancor.Ingresos;
			
            if (oInspeccionAmbientalBancor.IdServicios == 1)
                raImpuestosSI.Checked = true;
            else
                raImpuestosNO.Checked = true;

            //CargarCampos(raResultado, 17, oInspeccionAmbientalBancor.Resultado);
			//txtAccesoDomicilio.Text = oInspeccionAmbientalBancor.AccesoDomicilio;
			txtInformo.Text = oInspeccionAmbientalBancor.Informo;
			txtRelacion.Text = oInspeccionAmbientalBancor.Relacion;
			txtNombreVecino.Text = oInspeccionAmbientalBancor.NombreVecino;
			txtDomicilioVecino.Text = oInspeccionAmbientalBancor.DomicilioVecino;
			txtConoceVecino.Text = oInspeccionAmbientalBancor.ConoceVecino;
            txtNombreVecino2.Text = oInspeccionAmbientalBancor.NombreVecino2;
            txtDomicilioVecino2.Text = oInspeccionAmbientalBancor.DomicilioVecino2;
            txtConoceVecino2.Text = oInspeccionAmbientalBancor.ConoceVecino2;
			txtObservaciones.Text = oInspeccionAmbientalBancor.Observaciones;
			txtPlanoA.Text = oInspeccionAmbientalBancor.PlanoA;
			txtPlanoB.Text = oInspeccionAmbientalBancor.PlanoB;
			txtPlanoC.Text = oInspeccionAmbientalBancor.PlanoC;
			txtPlanoD.Text = oInspeccionAmbientalBancor.PlanoD;
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
			
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=21");

		}

		protected void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=21");
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
                strScript = "<script  type=\"text/javascript\">";
                strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=21&idInforme=" + idInforme.Value + "&Finalizar=1','','dialogWidth:400px;dialogHeight:250px');";
				strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=21'";
				strScript += "</script>";

				ActualizarInforme();
				//Page.RegisterStartupScript("CambiarEstado", strScript);
                // Define the name and type of the client script on the page.
                String csName = "ButtonClickScript";
                Type csType = this.GetType();

                // Get a ClientScriptManager reference from the Page class.
                ClientScriptManager cs = Page.ClientScript;

                // Check to see if the client script is already registered.
                if (!cs.IsClientScriptBlockRegistered(csType, csName))
                {
                    //StringBuilder csText = new StringBuilder();
                    //csText.Append("<script type=\"text/javascript\"> function DoClick() {");
                    //csText.Append("Form1.Message.value='Text from client script.'} </");
                    //csText.Append("script>");
                    cs.RegisterClientScriptBlock(csType, csName, strScript);
                }
			}
		}

		private void ActualizarInforme()
		{
            InspeccionAmbientalBancorApp oInspeccionAmbientalBancor = new InspeccionAmbientalBancorApp();
            bool cargar = oInspeccionAmbientalBancor.cargarInspeccionAmbientalBancor(int.Parse(idInforme.Value));
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			oInspeccionAmbientalBancor.IdCliente = Usuario.IdCliente;
			oInspeccionAmbientalBancor.IdUsuario = Usuario.IdUsuario;
			
			oInspeccionAmbientalBancor.IdInforme = int.Parse(idInforme.Value);
			oInspeccionAmbientalBancor.IdTipoPersona = int.Parse(idTipoPersona.Value);
			oInspeccionAmbientalBancor.Nombre = txtNombre.Text;
			oInspeccionAmbientalBancor.Apellido = txtApellido.Text;
			oInspeccionAmbientalBancor.TipoDocumento = int.Parse(cmbTipoDocumento.SelectedItem.Value);
			oInspeccionAmbientalBancor.Documento = txtDocumento.Text;
			oInspeccionAmbientalBancor.Calle = txtCalle.Text;
			oInspeccionAmbientalBancor.Barrio = txtBarrio.Text;
			oInspeccionAmbientalBancor.Nro = txtNro.Text;
			oInspeccionAmbientalBancor.Piso = txtPiso.Text;
			oInspeccionAmbientalBancor.Depto = txtDepto.Text;
			oInspeccionAmbientalBancor.CP = txtCP.Text;
            oInspeccionAmbientalBancor.Lote = txtLote.Text;
            oInspeccionAmbientalBancor.Manzana = txtManzana.Text;
            oInspeccionAmbientalBancor.Complejo = txtComplejo.Text;
            oInspeccionAmbientalBancor.Torre = txtTorre.Text;
            
			oInspeccionAmbientalBancor.Telefono = txtTelefono.Text;
			if (oInspeccionAmbientalBancor.IdTipoPersona == 1)
			{
				oInspeccionAmbientalBancor.IdProvincia = int.Parse(cmbProvincia.SelectedValue);
				oInspeccionAmbientalBancor.IdLocalidad = int.Parse(cmbLocalidad.SelectedValue);
			}
			oInspeccionAmbientalBancor.Fecha = txtFecha.Text;


            if (raHabitaSI.Checked)
                oInspeccionAmbientalBancor.IdHabita = 1;
            else
                oInspeccionAmbientalBancor.IdHabita = 0;

            oInspeccionAmbientalBancor.SICantidadIntegranGrupo = txtCantidadIntegran.Text;
            oInspeccionAmbientalBancor.NOQuienHabita = txtQuienHabita.Text;
            oInspeccionAmbientalBancor.NOCalidadDe = txtCalidadDe.Text;

            if (raAmpliacionesSI.Checked)
                oInspeccionAmbientalBancor.IdAmpliaciones = 1;
            else
                oInspeccionAmbientalBancor.IdAmpliaciones = 0;

            oInspeccionAmbientalBancor.SICuales = txtAmpliacionesCuales.Text;

            if (raIndependiente.Checked)
                oInspeccionAmbientalBancor.IdDepIndep = 1;
            else
                oInspeccionAmbientalBancor.IdDepIndep = 2;

            oInspeccionAmbientalBancor.DEPEmpresa = txtEmpresa.Text;
            oInspeccionAmbientalBancor.DEPDireccion = txtDireccion.Text;
            oInspeccionAmbientalBancor.DEPIngresosMensuales = txtIngresosMensuales.Text;
            oInspeccionAmbientalBancor.DEPBanco = txtBanco.Text;
            oInspeccionAmbientalBancor.INDEPActividad = txtActividad.Text;
            oInspeccionAmbientalBancor.INDEPDesarrolla = txtDondeDesarrolla.Text;
            oInspeccionAmbientalBancor.Ingresos = txtIngresosNetosFamiliares.Text;

            if (raImpuestosSI.Checked)
                oInspeccionAmbientalBancor.IdServicios = 1;
            else
                oInspeccionAmbientalBancor.IdServicios = 0;


			oInspeccionAmbientalBancor.Informo = txtInformo.Text;
			oInspeccionAmbientalBancor.Relacion = txtRelacion.Text;
			oInspeccionAmbientalBancor.NombreVecino = txtNombreVecino.Text;
			oInspeccionAmbientalBancor.DomicilioVecino = txtDomicilioVecino.Text;
			oInspeccionAmbientalBancor.ConoceVecino = txtConoceVecino.Text;
            oInspeccionAmbientalBancor.NombreVecino2 = txtNombreVecino2.Text;
            oInspeccionAmbientalBancor.DomicilioVecino2 = txtDomicilioVecino2.Text;
            oInspeccionAmbientalBancor.ConoceVecino2 = txtConoceVecino2.Text;
			oInspeccionAmbientalBancor.Observaciones = txtObservaciones.Text;
			oInspeccionAmbientalBancor.PlanoA = txtPlanoA.Text;
			oInspeccionAmbientalBancor.PlanoB = txtPlanoB.Text;
			oInspeccionAmbientalBancor.PlanoC = txtPlanoC.Text;
			oInspeccionAmbientalBancor.PlanoD = txtPlanoD.Text;
			oInspeccionAmbientalBancor.ConFoto = ((bool)ViewState["ConFoto"])? 1: 0;
            //oInspeccionAmbientalBancor.Resultado = int.Parse(raResultado.SelectedValue);

			if(int.Parse(idReferencia.Value) == 0)
				oInspeccionAmbientalBancor.Crear();
			else
				oInspeccionAmbientalBancor.Modificar(int.Parse(idInforme.Value));


            if (oInspeccionAmbientalBancor.IdTipoPersona == 1)
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
