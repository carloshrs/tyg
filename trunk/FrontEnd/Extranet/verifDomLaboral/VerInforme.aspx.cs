using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.Dal;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Verificaciones.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Extranet.VerifDomLaboral
{
    /// <summary>
    /// Summary description for altaInforme.
    /// </summary>
    public partial class verInforme : Page
    {
        protected RequiredFieldValidator reqNombre;
        protected RequiredFieldValidator reqApellido;
        protected DropDownList cmbEstadoCivil;
        protected DropDownList cmbTipoDocumento;
        protected RequiredFieldValidator RequiredFieldValidator2;
        protected RequiredFieldValidator RequiredFieldValidator3;
        protected RequiredFieldValidator RequiredFieldValidator6;
        protected RequiredFieldValidator RequiredFieldValidator7;
        protected DropDownList cmbProvincia;
        protected DropDownList cmbLocalidad;
        private int IdInforme;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
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
            VerifDomLaboralApp oVerifDom = new VerifDomLaboralApp();

            EncabezadoApp oEncabezado = new EncabezadoApp();
            oEncabezado.cargarEncabezado(Id);
            ClienteDal cliente = new ClienteDal();
            cliente.Cargar(oEncabezado.IdCliente);
            Usuario usuario = new Usuario();
            usuario.Cargar(oEncabezado.IdUsuario);
            if (oEncabezado.ConFoto == 1)
            {
                pnFotos.Visible = true;
                CargarImagen(oEncabezado.IdEncabezado, 1);
                CargarImagen(oEncabezado.IdEncabezado, 2);
            }
            else
            {
                imgFoto.Visible = false;
                pnFotos.Visible = false;
                lblNroPagina1.Visible = false;
            }
            bool cargar = oVerifDom.cargarVerifDomLaboral(Id);

            if (cargar)
            {
                lblNum.Text = Id.ToString();
                lblTipoDocumentoPeriodo.Text = TipoDocumentoPeriodo(cliente.TipoDocumento, cliente.TipoPeriodo);
                //lblFec.Text = DateTime.Today.ToShortDateString();
                if (oEncabezado.FechaFin != "")
                    lblFec.Text = Convert.ToDateTime(oEncabezado.FechaFin).ToShortDateString();

                string solicitante = "";
                if (cliente.NombreFantasia != null && cliente.NombreFantasia != "")
                    solicitante = cliente.NombreFantasia;
                else
                    solicitante = cliente.RazonSocial;
                if (cliente.Sucursal != null && cliente.Sucursal != "")
                    solicitante = solicitante + " (" + cliente.Sucursal + ")";
                lblSolicitante.Text = solicitante;

                string direccion = "";
                direccion = cliente.Calle + " " + cliente.Numero;
                if (cliente.Piso != "")
                {
                    direccion = direccion + " Piso: " + cliente.Piso;
                    direccion = direccion + " Dpto/Of: " + cliente.Departamento;
                }
                direccion = direccion + ". " + cliente.Barrio;
                lblDireccionSolicitante.Text = direccion;

                if (oEncabezado.idReferencia != 0)
                    lblRef.Text = oEncabezado.NombreReferencia.ToUpper();
                else if (oEncabezado.UsuarioCliente != "")
                    lblRef.Text = oEncabezado.UsuarioCliente.ToUpper();
                else
                    lblRef.Text = usuario.Apellido.ToUpper() + ", " + usuario.Nombre.ToUpper();


                if (oEncabezado.ConFoto == 1)
                {
                    lblNumCopy.Text = lblNum.Text;
                    lblFecCopy.Text = lblFec.Text;
                    lblSolicitanteCopy.Text = lblSolicitante.Text;
                    lblDireccionSolicitanteCopy.Text = lblDireccionSolicitante.Text;
                    lblRefCopy.Text = lblRef.Text;
                    lblNroPagina1.Text = "Página 1 de 2";
                    lblNroPagina2.Text = "Página 2 de 2";
                }
                CargarForm(oVerifDom);
            }
            else
            {
                CargarEncabezado(oEncabezado);
            }

        }


        private void CargarEncabezado(EncabezadoApp oVerifDom)
        {
            lblNombre.Text = oVerifDom.Nombre;
            lblApellido.Text = oVerifDom.Apellido;
            lblTipoDocumento.Text = LoadTipoDNI(oVerifDom.TipoDocumento);
            lblDocumento.Text = oVerifDom.Documento;
            lblEstadoCivil.Text = LoadEstadoCivil(oVerifDom.EstadoCivil);
            lblNombreFantasia.Text = oVerifDom.NombreFantasia;
            lblRazonSocial.Text = oVerifDom.RazonSocial;
            lblRubro.Text = oVerifDom.Rubro;
            lblCUIT.Text = oVerifDom.Cuit;
            lblCalle.Text = oVerifDom.Calle;
            lblBarrio.Text = oVerifDom.Barrio;
            lblNro.Text = oVerifDom.Nro;
            lblPiso.Text = oVerifDom.Piso;
            lblDpto.Text = oVerifDom.Dpto;
            lblCP.Text = oVerifDom.CP;
        }


        private void CargarForm(VerifDomLaboralApp oVerifDom)
        {
            lblNombre.Text = oVerifDom.Nombre;
            lblApellido.Text = oVerifDom.Apellido;
            lblTipoDocumento.Text = LoadTipoDNI(oVerifDom.TipoDocumento);
            lblDocumento.Text = oVerifDom.Documento;
            lblEstadoCivil.Text = LoadEstadoCivil(oVerifDom.EstadoCivil);
            lblNombreFantasia.Text = oVerifDom.NombreFantasia;
            lblRazonSocial.Text = oVerifDom.RazonSocial;
            lblRubro.Text = oVerifDom.Rubro;
            lblCUIT.Text = oVerifDom.Cuit;
            lblCalle.Text = oVerifDom.Calle;
            lblBarrio.Text = oVerifDom.Barrio;
            lblNro.Text = oVerifDom.Nro;
            lblPiso.Text = oVerifDom.Piso;
            lblDpto.Text = oVerifDom.Depto;
            lblCP.Text = oVerifDom.CP;
            lblTelefono.Text = oVerifDom.Telefono;
            lblLocalidad.Text = CargarLocalidades(23, oVerifDom.IdLocalidad);
            if (oVerifDom.Fecha != "")
                lblFecha.Text = DateTime.Parse(oVerifDom.Fecha).ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            lblOcupacion.Text = oVerifDom.Ocupacion;
            lblCargo.Text = oVerifDom.Cargo;
            lblAntiguedad.Text = oVerifDom.Antiguedad;
            if (oVerifDom.FechaFinalizacion != "")
                lblFechaFinalizacion.Text = DateTime.Parse(oVerifDom.FechaFinalizacion).ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            lblSueldo.Text = oVerifDom.Sueldo;
            lblAFavor.Text = oVerifDom.AFavor;
            if (oVerifDom.TrabajaLugar == 0 || oVerifDom.TrabajaLugar == 1)
                lblLugarDeclarado.Text = (oVerifDom.TrabajaLugar == 1) ? "Si" : "No";
            if (oVerifDom.Permanente == 0 || oVerifDom.Permanente == 1)
                lblPermanente.Text = (oVerifDom.Permanente == 1) ? "Si" : "No";
            if (oVerifDom.Contratado == 0 || oVerifDom.Contratado == 1)
                lblContratado.Text = (oVerifDom.Contratado == 1) ? "Si" : "No";
            if (oVerifDom.Embargos == 0 || oVerifDom.Embargos == 1)
                lblEmbargos.Text = (oVerifDom.Embargos == 1) ? "Si" : "No";
            lblUbicacion.Text = CargarTipoCampo(oVerifDom.Ubicacion, 3);
            lblZona.Text = CargarTipoCampo(oVerifDom.Zona, 9);
            lblInformo.Text = oVerifDom.Informo;
            lblCargoInformo.Text = oVerifDom.CargoInformo;
            lblNombreVecino.Text = oVerifDom.NombreVecino;
            lblDomicilioVecino.Text = oVerifDom.DomicilioVecino;
            lblConoceVecino.Text = oVerifDom.ConoceVecino;
            lblInformesAnteriores.Text = oVerifDom.InformesAnteriores;
            lblObservaciones.Text = oVerifDom.Observaciones;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            //			if(idReferencia.Value != null) 
            //			{
            //				if (int.Parse(idReferencia.Value) > 0) Response.Redirect("/Extranet/Referencias/altaReferencia.aspx?IdReferencia=" + idReferencia.Value);
            //				else Response.Redirect("ListaInformes.aspx");
            //			} 				
            //			else Response.Redirect("ListaInformes.aspx");
            Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=" + Request.QueryString["idTipo"]);
        }


        private string LoadEstadoCivil(int EstadoCivil)
        {
            UtilesApp Tipos = new UtilesApp();
            string Estado = "";
            DataTable myTb;
            myTb = Tipos.TraerEstadoCivil();
            foreach (DataRow myRow in myTb.Rows)
            {
                if (EstadoCivil.ToString() == myRow[0].ToString())
                {
                    Estado = myRow[1].ToString();
                }
            }
            return Estado;
        }

        private string LoadTipoDNI(int DNI)
        {
            UtilesApp Tipos = new UtilesApp();
            string TipoDNI = "";
            DataTable myTb;
            myTb = Tipos.TraerTipoDocumento();
            foreach (DataRow myRow in myTb.Rows)
            {
                if (DNI.ToString() == myRow[0].ToString())
                {
                    TipoDNI = myRow[1].ToString();
                }
            }
            return TipoDNI;
        }


        private string LoadTipoPropiedad(int idTipoPropiedad)
        {
            UtilesApp Tipos = new UtilesApp();
            string TipoPropiedad = "";
            DataTable myTb;
            myTb = Tipos.TraerTipoPropiedad();
            foreach (DataRow myRow in myTb.Rows)
            {
                if (idTipoPropiedad.ToString() == myRow[0].ToString())
                {
                    TipoPropiedad = myRow[1].ToString();
                }
            }
            //SelectTipoPropiedad(idTipoPropiedad);	
            return TipoPropiedad;
        }


        private string CargarProvincias(int IdProvincia)
        {
            UtilesApp Tipos = new UtilesApp();
            string Provincia = "";
            DataTable myTb;
            myTb = Tipos.TraerProvincias();
            foreach (DataRow myRow in myTb.Rows)
            {
                if (IdProvincia == int.Parse(myRow[0].ToString()))
                {
                    Provincia = myRow[1].ToString();
                }
            }
            return Provincia;
        }

        private String CargarLocalidades(int idProvincia, int IdLocalidad)
        {
            UtilesApp Tipos = new UtilesApp();
            DataTable myTb;
            string Localidad = "";
            myTb = Tipos.TraerLocalidades(idProvincia);
            foreach (DataRow myRow in myTb.Rows)
            {
                if (IdLocalidad.ToString() == myRow[0].ToString())
                {
                    Localidad = myRow[1].ToString();
                }
            }
            return Localidad;
        }


        private String CargarTipoCampo(int id, int idTipo)
        {
            VerifDomComercialApp oVerif = new VerifDomComercialApp();
            DataTable myTb;
            string TipoCampo = "";

            myTb = oVerif.TraerCampo(idTipo);
            foreach (DataRow myRow in myTb.Rows)
            {
                if (id.ToString() == myRow[0].ToString())
                {
                    TipoCampo = myRow[1].ToString();
                }
            }
            return TipoCampo;
        }


        private void CargarImagen(int lIdInforme, int lNroImagen)
        {
            string vImagen = "/img/shim.gif";
            ImagenDal imagen = new ImagenDal();
            imagen.Cargar(lIdInforme, lNroImagen);
            if (imagen.Path != "")
                vImagen = imagen.Path;
            //else
            //imgFoto.BorderWidth = 0;
            if (lNroImagen == 1)
            {
                imgFoto.ImageUrl = vImagen;
                imgFoto.ToolTip = imagen.Descripcion;
            }
            if (lNroImagen == 2)
            {
                imgFoto2.ImageUrl = vImagen;
                imgFoto2.ToolTip = imagen.Descripcion;
            }
        }

        private string TipoDocumentoPeriodo(int TipoDocumento, int TipoPeriodo)
        {
            string cadena = "";
            if (TipoDocumento != 0 && TipoPeriodo != 0)
            {
                if (TipoDocumento == 1)
                    cadena = "<br>R";
                else
                    cadena = "<br>PE";

                if (TipoPeriodo == 1)
                    cadena = cadena + "D";
                else
                    cadena = cadena + "M";

            }
            return cadena;

        }

    }
}
