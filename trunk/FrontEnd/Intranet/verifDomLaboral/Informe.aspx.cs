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

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.verifDomLaboral
{
    /// <summary>
    /// Summary description for altaInforme.
    /// </summary>
    public partial class Informe : Page
    {
        #region Elementos Web

        protected TextBox Provincia;
        protected Image Image1;
        protected Image Image2;
        protected Image Image3;
        protected Image Image4;
        protected Label lblObservaciones;
        protected Button Cerrar;
        protected Label Label2;
        protected Label Label8;
        protected TextBox txtMovLaboral;

        #endregion

        #region Page_Load(object sender, EventArgs e)

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write("<script>var menu = 0;</script>");
            //Response.Write("<script>var mostrarenc = " + hdEncAbierto.Value + ";</script>");

            // Si no viene de un postBack			
            if (!Page.IsPostBack)
            {
                idInforme.Value = Request.QueryString["id"];

                if (Request.QueryString["R"] != null)
                {
                    this.idInforme.Value = Session["IdInforme"].ToString();
                    Session.Remove("IdInforme");
                    //CargarComboEmpresas(0);
                    CargarCampos(raUbicacion, 3, -1);
                    CargarCampos(raCaractZona, 9, -1);
                    LoadVerifDomLaboral(int.Parse(idInforme.Value));
                    this.txtNombre.Text = Session["Nombre"].ToString();
                    Session.Remove("Nombre");
                    this.txtApellido.Text = Session["Apellido"].ToString();
                    Session.Remove("Apellido");
                    this.cmbTipoDocumento.SelectedValue = Session["TipoDocumento"].ToString();
                    Session.Remove("TipoDocumento");
                    this.txtDocumento.Text = Session["Documento"].ToString();
                    Session.Remove("Documento");
                    this.cmbEstadoCivil.SelectedValue = Session["EstadoCivil"].ToString();
                    Session.Remove("EstadoCivil");

                    this.hEmpresas.Value = Session["Empresa"].ToString();
                    ActualizarDatosEmpresa();
                    Session.Remove("Empresa");

                    this.txtOcupacion.Text = Session["Ocupacion"].ToString();
                    Session.Remove("Ocupacion");
                    this.txtCargo.Text = Session["Cargo"].ToString();
                    Session.Remove("Cargo");
                    this.txtFecha.Text = Session["Fecha"].ToString();
                    Session.Remove("Fecha");
                    this.txtAntiguedad.Text = Session["Antiguedad"].ToString();
                    Session.Remove("Antiguedad");
                    this.txtFechaFinalizacion.Text = Session["FechaFin"].ToString();
                    Session.Remove("FechaFin");

                    if (Session["EmpleadoPermanente"].ToString() != "")
                        this.raPermanente.SelectedValue = Session["EmpleadoPermanente"].ToString();
                    Session.Remove("EmpleadoPermanente");

                    if (Session["Contratado"].ToString() != "")
                        this.raContratado.SelectedValue = Session["Contratado"].ToString();
                    Session.Remove("Contratado");

                    if (Session["TrabajaLugar"].ToString() != "")
                        this.raTrabajaLugar.SelectedValue = Session["TrabajaLugar"].ToString();
                    Session.Remove("TrabajaLugar");

                    this.txtSueldo.Text = Session["Sueldo"].ToString();
                    Session.Remove("Sueldo");
                    this.txtAFavor.Text = Session["AFavorde"].ToString();
                    Session.Remove("AFavorde");

                    if (Session["Embargos"].ToString() != "")
                        this.raEmbargos.SelectedValue = Session["Embargos"].ToString();
                    Session.Remove("Embargos");

                    this.txtInformo.Text = Session["Informo"].ToString();
                    Session.Remove("Informo");
                    this.txtCargoInformo.Text = Session["CargoInformo"].ToString();
                    Session.Remove("CargoInformo");

                    if (Session["Ubicacion"].ToString() != "")
                        this.raUbicacion.SelectedValue = Session["Ubicacion"].ToString();
                    Session.Remove("Ubicacion");

                    if (Session["CaractZona"].ToString() != "")
                        this.raCaractZona.SelectedValue = Session["CaractZona"].ToString();
                    Session.Remove("CaractZona");

                    this.txtNombreVecino.Text = Session["NombreVecino"].ToString();
                    Session.Remove("NombreVecino");
                    this.txtDomicilioVecino.Text = Session["DomicilioVecino"].ToString();
                    Session.Remove("DomicilioVecino");
                    this.txtConoceVecino.Text = Session["ConoceVecino"].ToString();
                    Session.Remove("ConoceVecino");
                    this.txtObservaciones.Text = Session["Observaciones"].ToString();
                    Session.Remove("Observaciones");
                }

                if (Request.QueryString["id"] != null)
                {
                    //CargarComboEmpresas(0);			
                    CargarCampos(raUbicacion, 3, -1);
                    CargarCampos(raCaractZona, 9, -1);
                    LoadVerifDomLaboral(int.Parse(idInforme.Value));

                }

                //imgCheckPersona.Attributes.Add("onClick", "Javascript:ChequearPersona();return false;");				

                if (this.idInforme.Value != "")
                    CargarImagen();
            }
        }

        #endregion

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
            this.ImgbtnEmpresa.Click += new System.Web.UI.ImageClickEventHandler(this.ImgbtnEmpresa_Click);

        }

        #endregion

        #region Métodos Privados

        #region ActualizarDatosEmpresa ()

        private void ActualizarDatosEmpresa()
        {
            if (hEmpresas.Value != "0")
            {
                int idEmpresa = int.Parse(hEmpresas.Value);
                EmpresasAPP empresaSeleccionada = new EmpresasAPP();
                empresaSeleccionada.Cargar(idEmpresa);
                txtRazonSocial.Text = empresaSeleccionada.RazonSocial;
                hEmpresasNombre.Value = empresaSeleccionada.RazonSocial;
                txtNombreFantasia.Text = empresaSeleccionada.NombreFantasia;
                hEmpresasFantasia.Value = empresaSeleccionada.NombreFantasia;
                txtTelefono.Text = empresaSeleccionada.TelefonoEmpresa;
                txtRubro.Text = empresaSeleccionada.Rubro;
                txtCuit.Text = empresaSeleccionada.Cuit;
                txtCalle.Text = empresaSeleccionada.CalleEmpresa;
                txtNro.Text = empresaSeleccionada.NroEmpresa;
                txtDepto.Text = empresaSeleccionada.DptoEmpresa;
                txtPiso.Text = empresaSeleccionada.PisoEmpresa;
                txtBarrio.Text = empresaSeleccionada.BarrioEmpresa;
                txtCP.Text = empresaSeleccionada.CPEmpresa;
                CargarComboLocalidades(cmbLocalidad, empresaSeleccionada.LocalidadEmpresa);
            }
            else
            {
                txtRazonSocial.Text = "";
                hEmpresasNombre.Value = "";
                txtNombreFantasia.Text = "";
                hEmpresasFantasia.Value = "";
                txtTelefono.Text = "";
                txtRubro.Text = "";
                txtCuit.Text = "";
                txtCalle.Text = "";
                txtNro.Text = "";
                txtDepto.Text = "";
                txtPiso.Text = "";
                txtBarrio.Text = "";
                txtCP.Text = "";
                CargarComboLocalidades(cmbLocalidad, 0);
            }
        }

        #endregion

        #region ActualizarInforme()

        private void ActualizarInforme()
        {
            VerifDomLaboralApp oVerifDom = new VerifDomLaboralApp();
            bool cargar = oVerifDom.cargarVerifDomLaboral(int.Parse(idInforme.Value));
            // Usuario Logueado
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            oVerifDom.IdCliente = Usuario.IdCliente;
            oVerifDom.IdUsuario = Usuario.IdUsuario;

            oVerifDom.IdInforme = int.Parse(idInforme.Value);
            oVerifDom.Nombre = txtNombre.Text.ToUpper();
            oVerifDom.Apellido = txtApellido.Text.ToUpper();
            oVerifDom.TipoDocumento = int.Parse(cmbTipoDocumento.SelectedItem.Value);
            oVerifDom.Documento = txtDocumento.Text.ToUpper();
            oVerifDom.EstadoCivil = int.Parse(cmbEstadoCivil.SelectedValue);
            oVerifDom.NombreFantasia = txtNombreFantasia.Text.ToUpper();
            oVerifDom.RazonSocial = txtRazonSocial.Text.ToUpper();
            oVerifDom.Rubro = txtRubro.Text.ToUpper();
            oVerifDom.Cuit = txtCuit.Text.ToUpper();
            oVerifDom.Calle = txtCalle.Text.ToUpper();
            oVerifDom.Barrio = txtBarrio.Text.ToUpper();
            oVerifDom.Nro = txtNro.Text.ToUpper();
            oVerifDom.Piso = txtPiso.Text.ToUpper();
            oVerifDom.Depto = txtDepto.Text.ToUpper();
            oVerifDom.CP = txtCP.Text.ToUpper();
            oVerifDom.Telefono = txtTelefono.Text.ToUpper();
            cmbLocalidad.FindControl("cmbLocalidad");
            if ( cmbLocalidad.SelectedIndex != -1 && cmbLocalidad.SelectedItem.Value != "")
                oVerifDom.IdLocalidad = int.Parse(cmbLocalidad.SelectedItem.Value);
            oVerifDom.Fecha = txtFecha.Text.ToUpper();
            oVerifDom.Ocupacion = txtOcupacion.Text.ToUpper();
            oVerifDom.Cargo = txtCargo.Text.ToUpper();
            oVerifDom.CargoInformo = txtCargoInformo.Text.ToUpper();
            oVerifDom.Antiguedad = txtAntiguedad.Text.ToUpper();
            oVerifDom.FechaFinalizacion = txtFechaFinalizacion.Text.ToUpper();
            oVerifDom.Sueldo = txtSueldo.Text.ToUpper();
            oVerifDom.AFavor = txtAFavor.Text.ToUpper();

            if (raTrabajaLugar.SelectedItem != null)
                oVerifDom.TrabajaLugar = int.Parse(raTrabajaLugar.SelectedItem.Value);
            else
                oVerifDom.TrabajaLugar = -1;

            if (raPermanente.SelectedItem != null)
                oVerifDom.Permanente = int.Parse(raPermanente.SelectedItem.Value);
            else
                oVerifDom.Permanente = -1;

            if (raContratado.SelectedItem != null)
                oVerifDom.Contratado = int.Parse(raContratado.SelectedItem.Value);
            else
                oVerifDom.Contratado = -1;

            if (raEmbargos.SelectedItem != null)
                oVerifDom.Embargos = int.Parse(raEmbargos.SelectedItem.Value);
            else
                oVerifDom.Embargos = -1;

            if (raUbicacion.SelectedItem != null)
                oVerifDom.Ubicacion = int.Parse(raUbicacion.SelectedItem.Value);
            else
                oVerifDom.Ubicacion = -1;

            if (raCaractZona.SelectedItem != null)
                oVerifDom.Zona = int.Parse(raCaractZona.SelectedItem.Value);
            else
                oVerifDom.Zona = -1;

            oVerifDom.Informo = txtInformo.Text.ToUpper();
            oVerifDom.CargoInformo = txtCargoInformo.Text.ToUpper();
            oVerifDom.NombreVecino = txtNombreVecino.Text.ToUpper();
            oVerifDom.DomicilioVecino = txtDomicilioVecino.Text.ToUpper();
            oVerifDom.ConoceVecino = txtConoceVecino.Text.ToUpper();
            oVerifDom.InformesAnteriores = txtInformesAnteriores.Text.ToUpper();
            oVerifDom.Observaciones = txtObservaciones.Text.ToUpper();

            if (int.Parse(idReferencia.Value) == 0)
                oVerifDom.Crear();
            else
                oVerifDom.Modificar(int.Parse(idInforme.Value));


            PersonasAPP persona = new PersonasAPP();
            persona.Nombre = txtNombre.Text;
            persona.Apellido = txtApellido.Text;
            persona.EstadoCivil = int.Parse(cmbEstadoCivil.SelectedValue);
            persona.TipoDocumento = int.Parse(cmbTipoDocumento.SelectedItem.Value);
            persona.Documento = txtDocumento.Text;
            bool resultado = persona.Crear();

        }

        #endregion

        #region CargarCampos(RadioButtonList campo,int idTipo, int valor)

        private void CargarCampos(RadioButtonList campo, int idTipo, int valor)
        {
            campo.Items.Clear();
            VerifDomLaboralApp oVerifDom = new VerifDomLaboralApp();
            DataTable dtTraerCampo = oVerifDom.TraerCampo(idTipo);
            ListItem myItem;

            foreach (DataRow myRow in dtTraerCampo.Rows)
            {
                myItem = new ListItem(" " + myRow[1].ToString(), myRow[0].ToString());
                if (valor == int.Parse(myRow[0].ToString()))
                {
                    campo.SelectedIndex = -1;
                    myItem.Selected = true;
                }
                campo.Items.Add(myItem);
            }
        }

        #endregion

        #region CargarComboEmpresas(int idEmpresa)

        /*private void CargarComboEmpresas (int idEmpresa)
		{
			EmpresasAPP ManejadorEmpresas = new EmpresasAPP();
			cmbEmpresas.Items.Clear();
			DataTable myTb;
			myTb = ManejadorEmpresas.listarEmpresasPorNombre();
			ListItem myItem;

			myItem= new ListItem("Seleccione una Empresa","0");
			cmbEmpresas.Items.Add(myItem);			

			foreach (DataRow myRow in myTb.Rows)
			{
				myItem = new ListItem(myRow[0].ToString(), myRow[1].ToString());
				if (idEmpresa == int.Parse(myRow[1].ToString()))
				{
					cmbEmpresas.SelectedIndex = -1;
					myItem.Selected = true;
				}
				cmbEmpresas.Items.Add(myItem);
			}
		}*/

        #endregion

        #region CargarComboLocalidades(DropDownList comboLocalidades, int IdLocalidad)

        private void CargarComboLocalidades(DropDownList comboLocalidades, int IdLocalidad)
        {
            if (IdLocalidad == 0)
            {
                comboLocalidades.Items.Clear();
            }
            else
            {
                UtilesApp Tipos = new UtilesApp();
                comboLocalidades.Items.Clear();
                DataTable myTb;
                myTb = Tipos.TraerLocalidades(2);
                ListItem myItem;
                if (IdLocalidad == -1) { IdLocalidad = 1; }
                foreach (DataRow myRow in myTb.Rows)
                {
                    myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
                    if (IdLocalidad == int.Parse(myRow[0].ToString()))
                    {
                        comboLocalidades.SelectedIndex = -1;
                        myItem.Selected = true;
                    }
                    comboLocalidades.Items.Add(myItem);
                }
            }
        }

        #endregion

        #region CargarEncabezado(EncabezadoApp oEncabezado)

        private void CargarEncabezado(EncabezadoApp oEncabezado)
        {

            txtNombre.Text = oEncabezado.Nombre;
            txtApellido.Text = oEncabezado.Apellido;
            CargarTipoDocumento(oEncabezado.TipoDocumento);
            txtDocumento.Text = oEncabezado.Documento;
            CargarEstadoCivil(oEncabezado.EstadoCivil);
            txtCargo.Text = oEncabezado.Cargo;

            //CargarComboLocalidades(cmbLocalidad, oEncabezado.Localidad);
            //txtRazonSocial.Text = oEncabezado.RazonSocial;
            //txtNombreFantasia.Text = oEncabezado.NombreFantasia;
            //txtTelefono.Text = oEncabezado.TelefonoEmpresa;
            //txtRubro.Text = oEncabezado.Rubro;
            //txtCuit.Text = oEncabezado.Cuit;
            //txtCalle.Text = oEncabezado.CalleEmpresa;
            //txtNro.Text = oEncabezado.NroEmpresa;
            //txtDepto.Text = oEncabezado.DptoEmpresa;
            //txtPiso.Text = oEncabezado.PisoEmpresa;
            //txtBarrio.Text = oEncabezado.BarrioEmpresa;
            //txtCP.Text = oEncabezado.CPEmpresa;
        }

        #endregion

        #region CargarEstadoCivil(int idEstado)

        private void CargarEstadoCivil(int idEstado)
        {
            EstadoCivilApp objEstadoCivil = new EstadoCivilApp();
            DataTable dtEstadoCivil = objEstadoCivil.TraerDatos();
            ListItem myItem;

            foreach (DataRow myRow in dtEstadoCivil.Rows)
            {
                myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
                if (idEstado == int.Parse(myRow[0].ToString()))
                {
                    cmbEstadoCivil.SelectedIndex = -1;
                    myItem.Selected = true;
                }
                cmbEstadoCivil.Items.Add(myItem);
            }
        }

        #endregion

        #region CargarForm(VerifDomLaboralApp oVerifDom)

        private void CargarForm(VerifDomLaboralApp oVerifDom)
        {
            idInforme.Value = oVerifDom.IdInforme.ToString();
            txtNombre.Text = oVerifDom.Nombre;
            txtApellido.Text = oVerifDom.Apellido;
            CargarTipoDocumento(oVerifDom.TipoDocumento);
            txtDocumento.Text = oVerifDom.Documento;
            CargarEstadoCivil(oVerifDom.EstadoCivil);
            /*ListItem item=cmbEmpresas.Items.FindByText(oVerifDom.RazonSocial);
            if (item.Text!="")
            {
                cmbEmpresas.SelectedValue=item.Value;
                ActualizarDatosEmpresa();
            }*/

            txtRazonSocial.Text = oVerifDom.RazonSocial;
            hEmpresasNombre.Value = oVerifDom.RazonSocial;
            txtNombreFantasia.Text = oVerifDom.NombreFantasia;
            hEmpresasFantasia.Value = oVerifDom.NombreFantasia;
            txtRubro.Text = oVerifDom.Rubro;
            txtCuit.Text = oVerifDom.Cuit;
            txtCalle.Text = oVerifDom.Calle;
            txtBarrio.Text = oVerifDom.Barrio;
            txtNro.Text = oVerifDom.Nro;
            txtPiso.Text = oVerifDom.Piso;
            txtDepto.Text = oVerifDom.Depto;
            txtCP.Text = oVerifDom.CP;
            txtTelefono.Text = oVerifDom.Telefono;
            CargarComboLocalidades(cmbLocalidad, oVerifDom.IdLocalidad);
            if (oVerifDom.Fecha != "")
                txtFecha.Text = DateTime.Parse(oVerifDom.Fecha).ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            txtOcupacion.Text = oVerifDom.Ocupacion;
            txtCargoInformo.Text = oVerifDom.Cargo;
            txtAntiguedad.Text = oVerifDom.Antiguedad;
            if (oVerifDom.FechaFinalizacion != "")
                txtFechaFinalizacion.Text = DateTime.Parse(oVerifDom.FechaFinalizacion).ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            txtSueldo.Text = oVerifDom.Sueldo;
            txtAFavor.Text = oVerifDom.AFavor;
            if (oVerifDom.TrabajaLugar == 0 || oVerifDom.TrabajaLugar == 1)
                raTrabajaLugar.SelectedValue = (oVerifDom.TrabajaLugar == 1) ? (1).ToString() : (0).ToString();
            if (oVerifDom.Permanente == 0 || oVerifDom.Permanente == 1)
                raPermanente.SelectedValue = (oVerifDom.Permanente == 1) ? (1).ToString() : (0).ToString();
            if (oVerifDom.Contratado == 0 || oVerifDom.Contratado == 1)
                raContratado.SelectedValue = (oVerifDom.Contratado == 1) ? (1).ToString() : (0).ToString();
            if (oVerifDom.Embargos == 0 || oVerifDom.Embargos == 1)
                raEmbargos.SelectedValue = (oVerifDom.Embargos == 1) ? (1).ToString() : (0).ToString();
            CargarCampos(raUbicacion, 3, oVerifDom.Ubicacion);
            CargarCampos(raCaractZona, 9, oVerifDom.Zona);
            txtInformo.Text = oVerifDom.Informo;
            txtCargo.Text = oVerifDom.Cargo;
            txtNombreVecino.Text = oVerifDom.NombreVecino;
            txtDomicilioVecino.Text = oVerifDom.DomicilioVecino;
            txtConoceVecino.Text = oVerifDom.ConoceVecino;
            txtInformesAnteriores.Text = oVerifDom.InformesAnteriores;
            txtObservaciones.Text = oVerifDom.Observaciones;
        }

        #endregion

        #region CargarImagen()

        private void CargarImagen()
        {
            string vImagen = "/img/shim.gif";
            ImagenDal imagen = new ImagenDal();
            imagen.Cargar(int.Parse(idInforme.Value));
            if (imagen.Path != "")
                vImagen = imagen.Path;
            else
                imgFoto.BorderWidth = 0;
            imgFoto.ImageUrl = vImagen;
            imgFoto.ToolTip = imagen.Descripcion;
        }

        #endregion

        #region CargarMasFotos(int idInforme) // No usado

        private void CargarMasFotos(int idInforme)
        {
            hypMasFotos.Attributes.Add("onClick", "window.open('/imagenes/lista.aspx?Tipo=verifParticular&idInforme=" + idInforme + "','','width=500,height=400')");
        }

        #endregion

        #region CargarTipoDocumento(int idTipo)

        private void CargarTipoDocumento(int idTipo)
        {
            cmbTipoDocumento.Items.Clear();
            TipoDocumentoApp objTipoDocumento = new TipoDocumentoApp();
            DataTable dtTipoDoc = objTipoDocumento.TraerDatos();
            ListItem myItem;

            foreach (DataRow myRow in dtTipoDoc.Rows)
            {
                myItem = new ListItem(myRow[1].ToString(), myRow[0].ToString());
                if (idTipo == int.Parse(myRow[0].ToString()))
                {
                    cmbTipoDocumento.SelectedIndex = -1;
                    myItem.Selected = true;
                }
                cmbTipoDocumento.Items.Add(myItem);
            }
        }

        #endregion

        #region LoadVerifDomLaboral(int Id)

        private void LoadVerifDomLaboral(int Id)
        {
            VerifDomLaboralApp oVerifDom = new VerifDomLaboralApp();
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

            bool cargar = oVerifDom.cargarVerifDomLaboral(Id);
            if (cargar)
            {
                idReferencia.Value = (1).ToString();
                CargarTipoDocumento(-1);
                CargarForm(oVerifDom);
                if (oVerifDom.Documento.Length > 6)
                    ControlarSolicitudesDNI(Id, oVerifDom.Documento);
            }
            else
            {
                idReferencia.Value = (0).ToString();
                CargarEncabezado(oEncabezado);
                if (oEncabezado.Documento.Length > 6)
                    ControlarSolicitudesDNI(Id, oEncabezado.Documento);
            }
        }

        #endregion

        #region mostrarFoto(int estado) // No usado

        private void mostrarFoto(int estado)
        {
            if (estado == 1)
            {
                imgFoto.Visible = true;
                hypMasFotos.Visible = true;
            }

        }

        #endregion


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
            /*
            if (enc.Comentarios != "")
            {
                string strAbrirVentana = "<script>dv_solicitud.style.display = 'list-item';" +
                "ToggleImg(name, 'Cerrar.gif', 'Ocultar datos de la solicitud');" +
                "document.getElementById('hdEncAbierto').value = '1';</script>";
                Response.Write(strAbrirVentana);
            }
             */
        }


        #endregion

        #region Eventos

        #region Aceptar_Click(object sender, EventArgs e)

        protected void Aceptar_Click(object sender, EventArgs e)
        {

            ActualizarInforme();
            Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=6");
        }

        #endregion

        #region AceptarFinalizar_Click(object sender, System.EventArgs e)

        protected void AceptarFinalizar_Click(object sender, System.EventArgs e)
        {
            string strScript;
            strScript = "<script languaje=\"Javascript\">";
            strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=6&idInforme=" + idInforme.Value + "&Finalizar=1','','dialogWidth:400px;dialogHeight:250px');";
            strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=6'";
            strScript += "</script>";

            ActualizarInforme();
            Page.RegisterStartupScript("CambiarEstado", strScript);
        }

        #endregion

        #region Cancelar_Click(object sender, EventArgs e)

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=6");
        }

        #endregion

        #region ImgbtnEmpresa_Click (object sender, System.Web.UI.ImageClickEventArgs e)

        private void ImgbtnEmpresa_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            // Guardo los datos en sesión...
            Session.Add("IdInforme", this.idInforme.Value.Trim());
            Session.Add("Nombre", txtNombre.Text.Trim());
            Session.Add("Apellido", txtApellido.Text.Trim());
            Session.Add("TipoDocumento", cmbTipoDocumento.SelectedValue.Trim());
            Session.Add("Documento", txtDocumento.Text.Trim());
            Session.Add("EstadoCivil", cmbEstadoCivil.SelectedValue);
            Session.Add("Empresa", hEmpresas.Value);
            Session.Add("Ocupacion", txtOcupacion.Text.Trim());
            Session.Add("Cargo", txtCargo.Text.Trim());
            Session.Add("Fecha", txtFecha.Text.Trim());
            Session.Add("Antiguedad", txtAntiguedad.Text.Trim());
            Session.Add("FechaFin", txtFechaFinalizacion.Text.Trim());
            Session.Add("EmpleadoPermanente", raPermanente.SelectedValue);
            Session.Add("Contratado", raContratado.SelectedValue);
            Session.Add("TrabajaLugar", raTrabajaLugar.SelectedValue);
            Session.Add("Sueldo", txtSueldo.Text.Trim());
            Session.Add("AFavorde", txtAFavor.Text.Trim());
            Session.Add("Embargos", raEmbargos.SelectedValue);
            Session.Add("Informo", txtInformo.Text.Trim());
            Session.Add("CargoInformo", txtCargoInformo.Text.Trim());
            Session.Add("Ubicacion", raUbicacion.SelectedValue);
            Session.Add("CaractZona", raCaractZona.SelectedValue);
            Session.Add("NombreVecino", txtNombreVecino.Text.Trim());
            Session.Add("DomicilioVecino", txtDomicilioVecino.Text.Trim());
            Session.Add("ConoceVecino", txtConoceVecino.Text.Trim());
            Session.Add("Observaciones", txtObservaciones.Text.Trim());

            this.Page.Response.Redirect("/Admin/Empresas/AltaEmpresa.aspx?retornarA=/VerifDomLaboral/Informe.aspx?R=1");
        }

        #endregion

        #region hEmpresas_ValueChanged(object sender, System.EventArgs e)

        protected void hEmpresas_ValueChanged(object sender, EventArgs e)
        {
            ActualizarDatosEmpresa();
        }

        #endregion

        #region ControlarSolicitudesDNI(int id, string dni)
        private void ControlarSolicitudesDNI(int id, string dni)
        {
            // Si no están anotadas las solicitudes anteriores...
            //if (txtInformesAnteriores.Text.StartsWith("MATRICULA SOLICITADA ANTERIORMENTE:") == false)
            if (txtInformesAnteriores.Text == "")
            {
                // Busco las solicitudes anteriores por el DNI de la persona...
                string mensaje = "";//"VERIFICACION SOLICITADA ANTERIORMENTE: \r";

                DataTable solicitudes = null;
                solicitudes = ControlVerifLaboralDal.ControlarSolicitudesDNI(id, dni);

                if (solicitudes != null && solicitudes.Rows.Count != 0)
                {
                    int idCliente = -1;
                    mensaje += "FUE CONSULTADO POR: ";
                    foreach (DataRow solicitud in solicitudes.Rows)
                    {
                        bool cambio = false;
                        if (idCliente == -1)
                        {
                            mensaje += solicitud[1].ToString() + " EL/LOS DÍA/S: ";
                            idCliente = int.Parse(solicitud[2].ToString());
                            cambio = true;
                        }
                        if (idCliente != int.Parse(solicitud[2].ToString()))
                        {
                            //mensaje += "\r";
                            mensaje += "; ";
                            mensaje += solicitud[1].ToString() + " EL/LOS DÍA/S: ";
                            idCliente = int.Parse(solicitud[2].ToString());
                            cambio = true;
                        }
                        if (!cambio) mensaje += ", ";
                        mensaje += (solicitud[0].ToString()).Substring(0, 10);
                    }
                    txtInformesAnteriores.Text = mensaje += "\r" + txtInformesAnteriores.Text;
                }
            }
            txtInformesAnteriores.Text = esVacio(txtInformesAnteriores.Text);
        }
        #endregion

        protected void btnObtener_PreRender(object sender, EventArgs e)
        {
            btnObtener.Attributes.Add("onClick", "GetServerTime(document.getElementById('txtDocumento').value)");
        }

        public string esVacio(string txt)
        {
            if (txt == "")
            { return "NO REGISTRA"; }
            else
            { return txt; }
        }

        #endregion



        protected void Rechazar_Click(object sender, EventArgs e)
        {
            string strScript;
            strScript = "<script languaje=\"Javascript\">";
            strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=6&idInforme=" + idInforme.Value + "&Rechazar=1','','dialogWidth:400px;dialogHeight:250px');";
            strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=6'";
            strScript += "</script>";

            Page.RegisterStartupScript("CambiarEstado", strScript);
        }
}
}
