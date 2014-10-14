using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.BandejaEntrada
{
    /// <summary>
    /// Summary description for Principal.
    /// </summary>
    public partial class gravamenes_registro : Page
    {
        private int IdTipo;
        protected Button Button1;
        private int IdUsuario = 1; //VALOR QUE SE OBTENDRA DEL CONTEXTO
        private int intIndex = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListaBandeja(intIndex);
            }
        }

        #region Web Form Designer generated code

        protected override void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();

            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];
            IdUsuario = Usuario.IdUsuario;

            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //this.dgridEncabezados.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgridEncabezados_ItemCommand);

        }

        #endregion

        private void ListaBandeja(int idTab)
        {
            int idUser = -1;
            IdTipo = 3;
            string pFiltro = "";
            string Estados = "1,5";
            lblMensaje.Text = "";

            BandejaEntradaApp bandeja = new BandejaEntradaApp();
            //if (chkSoloMias.Checked) idUser = IdUsuario;

            dgridEnEsperaSUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 3, "", "", 100, false);
            dgridEnEsperaSUrgentes.DataBind();

            if (dgridEnEsperaSUrgentes.Items.Count == 0)
                pnEnEsperaSUrgentes.Visible = false;

            dgridEnEsperaUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 2, "", "", 100, false);
            dgridEnEsperaUrgentes.DataBind();

            if (dgridEnEsperaUrgentes.Items.Count == 0)
                pnEnEsperaUrgentes.Visible = false;

            dgridEnEsperaNormales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 1, "", "", 100, false);
            dgridEnEsperaNormales.DataBind();

            if (dgridEnEsperaNormales.Items.Count == 0)
                pnEnEsperaNormales.Visible = false;


            if ((dgridEnEsperaUrgentes.Items.Count == 0) && (dgridEnEsperaNormales.Items.Count == 0))
            {
                lblMensaje.Text = "No hay Informes de Gravámenes para generar el formulario taza.";
                lblMensaje.Visible = true;
                //btnImprimir.Visible = false;
            }

        }


        protected void dgridEnEsperaSUrgentes_PreRender(object sender, EventArgs e)
        {
            foreach (DataGridItem myItem in dgridEnEsperaSUrgentes.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
            }
        }

        protected void dgridEnEsperaUrgentes_PreRender(object sender, EventArgs e)
        {
            foreach (DataGridItem myItem in dgridEnEsperaUrgentes.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
            }
        }



        protected void dgridEnEsperaNormales_PreRender(object sender, EventArgs e)
        {
            foreach (DataGridItem myItem in dgridEnEsperaNormales.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
            }
        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            CheckBox chkSelSUrgente;
            CheckBox chkSelUrgente;
            CheckBox chkSelNormal;
            int intIdInforme;
            int intGrupo = 0;
            EncabezadoApp Encabezado = new EncabezadoApp();
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];

            if (dgridEnEsperaSUrgentes.Items.Count > 0 || dgridEnEsperaUrgentes.Items.Count > 0 || dgridEnEsperaNormales.Items.Count > 0)
                intGrupo = Encabezado.crearGrupoCambioEstado(Usuario.IdUsuario, 3);


            foreach (DataGridItem dgUrg in dgridEnEsperaSUrgentes.Items)
            {
                chkSelSUrgente = (CheckBox)dgUrg.FindControl("chkSUrgente");
                if (chkSelSUrgente.Checked)
                {
                    intIdInforme = int.Parse(dgUrg.Cells[0].Text);
                    Encabezado.cargarEncabezado(intIdInforme);
                    Encabezado.Estado = 2;
                    Encabezado.CambiarEstado(intIdInforme);
                    Encabezado.Leido = 1;
                    Encabezado.CambiarLeido(intIdInforme);
                    Encabezado.crearCambiosEstadoInformes(intGrupo, intIdInforme, 2);
                }
            }

            foreach (DataGridItem dgUrg in dgridEnEsperaUrgentes.Items)
            {
                chkSelUrgente = (CheckBox)dgUrg.FindControl("chkUrgente");
                if (chkSelUrgente.Checked)
                {
                    intIdInforme = int.Parse(dgUrg.Cells[0].Text);
                    Encabezado.cargarEncabezado(intIdInforme);
                    Encabezado.Estado = 2;
                    Encabezado.CambiarEstado(intIdInforme);
                    Encabezado.Leido = 1;
                    Encabezado.CambiarLeido(intIdInforme);
                    Encabezado.crearCambiosEstadoInformes(intGrupo, intIdInforme, 2);
                }
            }


            foreach (DataGridItem dgNorm in dgridEnEsperaNormales.Items)
            {
                chkSelNormal = (CheckBox)dgNorm.FindControl("chkNormal");
                if (chkSelNormal.Checked)
                {
                    intIdInforme = int.Parse(dgNorm.Cells[0].Text);
                    Encabezado.cargarEncabezado(intIdInforme);
                    Encabezado.Estado = 2;
                    Encabezado.CambiarEstado(intIdInforme);
                    Encabezado.Leido = 1;
                    Encabezado.CambiarLeido(intIdInforme);
                    Encabezado.crearCambiosEstadoInformes(intGrupo, intIdInforme, 2);
                }
            }
            Response.Redirect("impresionenproceso.aspx?idGrupo=" + intGrupo);
       }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BandejaEntrada/Principal.aspx?idTipo=3");
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ListaBandejaFiltro();
        }

        private void ListaBandejaFiltro()
        {
            int idUser = -1;
            string pFiltro = txtContengan.Text;
            if (chkSoloMias.Checked) idUser = IdUsuario;
            int idCliente = -1;
            string Estados = "1,5";
            int IdTipo = 1;


            BandejaEntradaApp bandeja = new BandejaEntradaApp();
            //if (chkSoloMias.Checked) idUser = IdUsuario;

            dgridEnEsperaSUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 3, "", "", 100, false);
            dgridEnEsperaSUrgentes.DataBind();

            if (dgridEnEsperaSUrgentes.Items.Count == 0)
                pnEnEsperaSUrgentes.Visible = false;

            dgridEnEsperaUrgentes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 2, "", "", 100, false);
            dgridEnEsperaUrgentes.DataBind();

            if (dgridEnEsperaUrgentes.Items.Count == 0)
                pnEnEsperaUrgentes.Visible = false;

            dgridEnEsperaNormales.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, idCliente, idUser, Estados, 1, "", "", 100, false);
            dgridEnEsperaNormales.DataBind();

            if (dgridEnEsperaNormales.Items.Count == 0)
                pnEnEsperaNormales.Visible = false;


            if ((dgridEnEsperaUrgentes.Items.Count == 0) && (dgridEnEsperaNormales.Items.Count == 0))
            {
                lblMensaje.Text = "No hay Informes de Gravámenes para generar el formulario taza.";
                lblMensaje.Visible = true;
                //btnImprimir.Visible = false;
            }

        }
        protected void btnImpresiones_Click(object sender, EventArgs e)
        {
            Response.Redirect("historialimpresiones.aspx?idTipo=3");
        }
}
}