using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Informes.Dal;
using System.Globalization;
//using System.Globalization;
//using System.IO;


namespace ar.com.TiempoyGestion.FrontEnd.Intranet.defuncion
{
    /// <summary>
    /// Summary description for altaInforme.
    /// </summary>
    public partial class Informe : Page
    {
        //protected TextBox Provincia;
        



        protected void Page_Load(object sender, EventArgs e)
        {
            idInforme.Value = Request.QueryString["id"];
            pnlDetalle.Visible = false;
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    LoadPartidaDefuncion(int.Parse(idInforme.Value));
                }

            }

            if (rbFallecido.SelectedValue != "" && int.Parse(rbFallecido.SelectedValue) == 1)
                pnlDetalle.Visible = true;
            else
                pnlDetalle.Visible = false;

            
            
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

        private void LoadPartidaDefuncion(int Id)
        {
            InformeDefuncion oInfDefuncion = new InformeDefuncion();
            EncabezadoApp oEncabezado = new EncabezadoApp();
            oEncabezado.cargarEncabezado(Id);

            bool cargar = oInfDefuncion.Cargar(Id);
            if (cargar)
            {
                idReferencia.Value = (1).ToString();
                CargarForm(oInfDefuncion);
            }
            else
            {
                idReferencia.Value = (0).ToString();
                CargarEncabezado(oEncabezado);
                oEncabezado.Leido = 1;
                oEncabezado.CambiarLeido(Id);
            }
        }


        private void CargarEncabezado(EncabezadoApp oEncabezado)
        {
            //idReferencia.Value = oEncabezado.idReferencia.ToString();
            txtNombre.Text = oEncabezado.Nombre;
            txtApellido.Text = oEncabezado.Apellido;
            txtDNI.Text = oEncabezado.Documento;
            cmbSexo.SelectedValue = oEncabezado.Sexo.ToString();
        }


        private void CargarForm(InformeDefuncion oInfDefuncion)
        {
            CultureInfo myInfo = new CultureInfo("es-AR");

            idInforme.Value = oInfDefuncion.IdEncabezado.ToString();
            txtNombre.Text = oInfDefuncion.Nombre;
            txtApellido.Text = oInfDefuncion.Apellido;
            txtDNI.Text = oInfDefuncion.Documento.ToString();
            cmbSexo.SelectedValue = oInfDefuncion.Sexo.ToString();
            rbFallecido.SelectedValue = oInfDefuncion.Fallecido.ToString();
            
            //txtFechaFallece.Text = oInfDefuncion.FechaFallecido;
            if (!oInfDefuncion.FechaFallecido.Equals(""))
                txtFechaFallece.Text = DateTime.Parse(oInfDefuncion.FechaFallecido).ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            txtActa.Text = oInfDefuncion.Acta;
            txtTomo.Text = oInfDefuncion.Tomo;
            txtFolio.Text = oInfDefuncion.Folio;
            txtLugar.Text = oInfDefuncion.LugarFallecimiento;
            
            txtObservaciones.Text = oInfDefuncion.Observaciones;


        }

        protected void Aceptar_Click(object sender, EventArgs e)
        {
            ActualizarInforme();
            Response.Write("<script>alert('Los datos se guardaron exitosamente');</script>");
            //Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=4");
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/BandejaEntrada/Principal.aspx?idTipo=4");
        }

        

       


        protected void AceptarFinalizar_Click(object sender, System.EventArgs e)
        {
            //EncabezadoApp oEncabezado = new EncabezadoApp();
            //oEncabezado.cargarEncabezado(int.Parse(idInforme.Value));
            string strScript;
            strScript = "<script languaje=\"Javascript\">";
            strScript += "window.showModalDialog('/BandejaEntrada/PopUpCambioEstado.aspx?idTipo=19&idInforme=" + idInforme.Value + "&Finalizar=1','','dialogWidth:400px;dialogHeight:250px');";
            strScript += "document.location.href = '/BandejaEntrada/Principal.aspx?idTipo=19'";
            strScript += "</script>";
            ActualizarInforme();
            //Page.RegisterStartupScript("CambiarEstado", strScript);
            ClientScript.RegisterStartupScript(this.GetType(), "CambiarEstado", strScript);
        }

        private void ActualizarInforme()
        {
            bool estado = false;
            InformeDefuncion oInfDef = new InformeDefuncion();
            bool cargar = oInfDef.Cargar(int.Parse(idInforme.Value));
            // Usuario Logueado
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            oInfDef.IdCliente = Usuario.IdCliente;
            oInfDef.IdUsuario = Usuario.IdUsuario;
            oInfDef.IdEncabezado = int.Parse(idInforme.Value);
            oInfDef.Nombre = txtNombre.Text;
            oInfDef.Apellido = txtApellido.Text;
            oInfDef.Documento = txtDNI.Text;
            oInfDef.Sexo = int.Parse(cmbSexo.SelectedValue);
            oInfDef.Fallecido = int.Parse(rbFallecido.SelectedValue);
            oInfDef.FechaFallecido = txtFechaFallece.Text;     
            oInfDef.Acta = txtActa.Text;
            oInfDef.Tomo = txtTomo.Text;
            oInfDef.Folio = txtFolio.Text;
            oInfDef.LugarFallecimiento = txtLugar.Text;
            oInfDef.Observaciones = txtObservaciones.Text;

            if (int.Parse(idReferencia.Value) == 0)
            {
                estado = oInfDef.Crear();
                if (estado)
                    idReferencia.Value = (1).ToString();
                else
                    idReferencia.Value = (0).ToString();
            }
            else
                estado = oInfDef.Modificar(int.Parse(idInforme.Value));


        }

    }
}
