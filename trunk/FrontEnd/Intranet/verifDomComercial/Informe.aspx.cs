using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Verificaciones.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.VerifDomComercial
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
	
		protected void Page_Load(object sender, EventArgs e)
		{
			idInforme.Value = Request.QueryString["id"];

			if (!Page.IsPostBack)
			{
				if(Request.QueryString["id"] != null)
				{	
					CargarCampos(raCaractZona,1,-1);
					CargarCampos(raDocumentoVerificado,2,-1);
					CargarCampos(raUbicacion,3,-1);
					CargarCampos(raTamanio,4,-1);
					CargarCampos(raInmueble,5,-1);
					CargarCampos(raEstado,6,-1);
					LoadVerifDomComercial(int.Parse(idInforme.Value));
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

		private void LoadVerifDomComercial(int Id)
		{
			VerifDomComercialApp oVerifDom = new VerifDomComercialApp();
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

			bool cargar = oVerifDom.cargarVerifDomComercial(Id);
			if (cargar)
			{
				idReferencia.Value = (1).ToString();
				CargarTipoDocumento(-1);
				CargarForm(oVerifDom);
			}
			else
			{
				idReferencia.Value = (0).ToString();
				CargarEncabezado(oEncabezado);
			}
		}

		private void CargarMasFotos(int idInforme)
		{
			hypMasFotos.Attributes.Add("onClick", "window.open('/imagenes/lista.aspx?Tipo=verifParticular&idInforme=" + idInforme + "','','width=500,height=400')");
		}

		
		private void CargarEncabezado(EncabezadoApp oEncabezado)
		{
			idTipoPersona.Value = oEncabezado.IdTipoPersona.ToString();
			RazonSocialPers.Text = oEncabezado.RazonSocial;
			txtNombre.Text = oEncabezado.Nombre;
			txtApellido.Text = oEncabezado.Apellido;
			CargarTipoDocumento(oEncabezado.TipoDocumento);
			CargarComboProvincias(cmbProvincia, oEncabezado.Provincia);
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, oEncabezado.Localidad.ToString());
			txtDocumento.Text = oEncabezado.Documento;
			NombreFantasiaPers.Text = oEncabezado.NombreFantasia;
			txtTelefono.Text = oEncabezado.TelefonoEmpresa;
			RubroPers.Text = oEncabezado.Rubro;
			CuitPers.Text = oEncabezado.Cuit;
			txtCalle.Text = oEncabezado.CalleEmpresa;
			txtNro.Text = oEncabezado.NroEmpresa;
			txtDepto.Text = oEncabezado.DptoEmpresa;
			txtPiso.Text = oEncabezado.PisoEmpresa;
			txtBarrio.Text = oEncabezado.BarrioEmpresa;
			txtCP.Text = oEncabezado.CPEmpresa;

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
			//CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidadEmpresas, oEncabezado.LocalidadEmpresa.ToString());
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


		private void CargarForm(VerifDomComercialApp oVerifDom)
		{
			idInforme.Value= oVerifDom.IdInforme.ToString();
			idTipoPersona.Value = oVerifDom.IdTipoPersona.ToString();
			txtNombre.Text= oVerifDom.Nombre;
			txtApellido.Text = oVerifDom.Apellido;
			CargarTipoDocumento(oVerifDom.TipoDocumento);
			txtDocumento.Text = oVerifDom.Documento;
			
			if(oVerifDom.IdTipoPersona == 1)
			{
				NombreFantasiaPers.Text = oVerifDom.NombreFantasia;
				RazonSocialPers.Text= oVerifDom.RazonSocial;
				RubroPers.Text= oVerifDom.Rubro;
				CuitPers.Text= oVerifDom.Cuit;
			}
			else
			{
				NombreFantasia.Text = oVerifDom.NombreFantasia;
				RazonSocial.Text= oVerifDom.RazonSocial;
				Rubro.Text= oVerifDom.Rubro;
				Cuit.Text= oVerifDom.Cuit;
			}
			txtCalle.Text= oVerifDom.Calle;
			txtBarrio.Text= oVerifDom.Barrio;
			txtNro.Text= oVerifDom.Nro;
			txtPiso.Text= oVerifDom.Piso;
			txtDepto.Text= oVerifDom.Depto;
			txtCP.Text= oVerifDom.CP;
			txtTelefono.Text= oVerifDom.Telefono;
			CargarComboProvincias(cmbProvincia, oVerifDom.IdProvincia);
			CargarComboLocalidades(cmbProvincia, cmbLocalidad, oVerifDom.IdLocalidad.ToString());

			//CargarComboProvincias(cmbProvinciaEmpresas, oVerifDom.ProvinciaEmpresa);
			//CargarComboLocalidades(cmbProvinciaEmpresas, cmbLocalidad, oVerifDom.IdLocalidad.ToString());

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
			txtOcupacion.Text = oVerifDom.Ocupacion;
			txtCategoria.Text = oVerifDom.Categoria;
			txtMovComercial.Text = oVerifDom.MovComercial;
			txtActividad.Text = oVerifDom.Actividad;
			txtRubros.Text = oVerifDom.RubrosAdicionales;
			txtHorario.Text = oVerifDom.Horario;
			txtAntiguedad.Text = oVerifDom.Antiguedad;
			txtCantPersonal.Text = oVerifDom.CantPersonal;
			CargarCampos(raCaractZona,1,oVerifDom.CaractZona);
			CargarCampos(raDocumentoVerificado,2,oVerifDom.DocVerificado);
			CargarCampos(raUbicacion,3,oVerifDom.Ubicacion);
			CargarCampos(raTamanio,4,oVerifDom.TamLocal);
			CargarCampos(raInmueble,5,oVerifDom.Inmueble);
			CargarCampos(raEstado,6,oVerifDom.Estado);
			if(oVerifDom.Publicidad == 1)chkPubicidad.Checked = true;
			if(oVerifDom.Vigilancia == 1)chkVigilancia.Checked = true;
			if (oVerifDom.FechaInicio != "")
				txtInicio.Text= DateTime.Parse(oVerifDom.FechaInicio).ToString("dd/MM/yyyy",DateTimeFormatInfo.InvariantInfo);
			txtCategoriaIVA.Text = oVerifDom.CatIVA;
			txtInformo.Text = oVerifDom.Informo;
			txtCargo.Text = oVerifDom.Cargo;
			txtNombreVecino.Text = oVerifDom.NombreVecino;
			txtDomicilioVecino.Text = oVerifDom.DomicilioVecino;
			txtConoceVecino.Text = oVerifDom.ConoceVecino;
			txtObservaciones.Text = oVerifDom.Observaciones;
			txtPlanoA.Text = oVerifDom.PlanoA;
			txtPlanoB.Text = oVerifDom.PlanoB;
			txtPlanoC.Text = oVerifDom.PlanoC;
			txtPlanoD.Text = oVerifDom.PlanoD;

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

			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=7");

		}

		protected void Cancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=7");
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


		private void CargarCampos(RadioButtonList campo,int idTipo, int valor)
		{
			campo.Items.Clear();
			VerifDomComercialApp oVerifDom = new VerifDomComercialApp();
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
			string strScript;
			strScript = "<script languaje=\"Javascript\">";
            strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=7&idInforme=" + idInforme.Value + "&Finalizar=1','','dialogWidth:400px;dialogHeight:250px');";
			strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=7'";
			strScript += "</script>";

			ActualizarInforme();
			Page.RegisterStartupScript("CambiarEstado", strScript);
		}

		private void ActualizarInforme()
		{
			VerifDomComercialApp oVerifDom = new VerifDomComercialApp();
			bool cargar = oVerifDom.cargarVerifDomComercial(int.Parse(idInforme.Value));
			// Usuario Logueado
			UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
			oVerifDom.IdCliente = Usuario.IdCliente;
			oVerifDom.IdUsuario = Usuario.IdUsuario;
			
			oVerifDom.IdTipoPersona = int.Parse(idTipoPersona.Value);
			oVerifDom.IdInforme = int.Parse(idInforme.Value);
			oVerifDom.Nombre = txtNombre.Text;
			oVerifDom.Apellido = txtApellido.Text;
			oVerifDom.TipoDocumento = int.Parse(cmbTipoDocumento.SelectedItem.Value);
			oVerifDom.Documento = txtDocumento.Text;
			if (int.Parse(idTipoPersona.Value) == 1)
			{
				oVerifDom.NombreFantasia = NombreFantasiaPers.Text;
				oVerifDom.RazonSocial = RazonSocialPers.Text;
				oVerifDom.Rubro = RubroPers.Text;
				oVerifDom.Cuit = CuitPers.Text;
			}
			else
			{
				oVerifDom.NombreFantasia = NombreFantasia.Text;
				oVerifDom.RazonSocial = RazonSocial.Text;
				oVerifDom.Rubro = Rubro.Text;
				oVerifDom.Cuit = Cuit.Text;
			}
			oVerifDom.Calle = txtCalle.Text;
			oVerifDom.Barrio = txtBarrio.Text;
			oVerifDom.Nro = txtNro.Text;
			oVerifDom.Piso = txtPiso.Text;
			oVerifDom.Depto = txtDepto.Text;
			oVerifDom.CP = txtCP.Text;
			oVerifDom.Telefono = txtTelefono.Text;

			oVerifDom.IdProvincia = int.Parse(cmbProvincia.SelectedValue);
			oVerifDom.IdLocalidad = int.Parse(cmbLocalidad.SelectedValue);
			
			//EMPRESA
			oVerifDom.TelefonoEmpresa = Telefono.Text;
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
			oVerifDom.Ocupacion = txtOcupacion.Text;
			oVerifDom.Categoria = txtCategoria.Text;
			oVerifDom.MovComercial = txtMovComercial.Text;
			oVerifDom.Actividad = txtActividad.Text;
			oVerifDom.RubrosAdicionales = txtRubros.Text;
			oVerifDom.Horario = txtHorario.Text;
			oVerifDom.Antiguedad = txtAntiguedad.Text;
			oVerifDom.CantPersonal = txtCantPersonal.Text;
			if (raCaractZona.SelectedItem != null)
			oVerifDom.CaractZona = int.Parse(raCaractZona.SelectedItem.Value);
			if (raDocumentoVerificado.SelectedItem != null)
			oVerifDom.DocVerificado = int.Parse(raDocumentoVerificado.SelectedItem.Value);
			if (raUbicacion.SelectedItem != null)
			oVerifDom.Ubicacion = int.Parse(raUbicacion.SelectedItem.Value);
			if (raTamanio.SelectedItem != null)
			oVerifDom.TamLocal = int.Parse(raTamanio.SelectedItem.Value);
			if (raInmueble.SelectedItem != null)
			oVerifDom.Inmueble = int.Parse(raInmueble.SelectedItem.Value);
			if (raEstado.SelectedItem != null)
			oVerifDom.Estado = int.Parse(raEstado.SelectedItem.Value);
			oVerifDom.Publicidad = (chkPubicidad.Checked) ? 1:0;
			oVerifDom.Vigilancia = (chkVigilancia.Checked) ? 1:0;
			oVerifDom.FechaInicio = txtInicio.Text;
			oVerifDom.CatIVA = txtCategoriaIVA.Text;
			oVerifDom.Informo = txtInformo.Text;
			oVerifDom.Cargo = txtCargo.Text;
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


            if (oVerifDom.IdTipoPersona == 1)
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


        protected void Rechazar_Click(object sender, EventArgs e)
        {
            string strScript;
            strScript = "<script languaje=\"Javascript\">";
            strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=7&idInforme=" + idInforme.Value + "&Rechazar=1','','dialogWidth:400px;dialogHeight:250px');";
            strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=7'";
            strScript += "</script>";

            Page.RegisterStartupScript("CambiarEstado", strScript);
        }
}
}
