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
    public partial class pendientes : Page
    {
        private int IdTipo;
        protected Button Button1;
        private int IdUsuario = 1; //VALOR QUE SE OBTENDRA DEL CONTEXTO

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListaBandeja();
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

        private void ListaBandeja()
        {
            int idUser = -1;
            IdTipo = 6;
            string pFiltro = "";
            string Estados = "1,5";
            BandejaEntradaApp bandeja = new BandejaEntradaApp();
            //if (chkSoloMias.Checked) idUser = IdUsuario;
            dgLaboralesPendientes.DataSource = bandeja.ListaEncabezados(IdTipo, pFiltro, -1, idUser, Estados, 1, "", "", 100, false);
            dgLaboralesPendientes.DataBind();
            if (dgLaboralesPendientes.Items.Count == 0)
            {
                dgLaboralesPendientes.Visible = false;
                //lblTitSUrgentes.Visible = false;
            }


            if (dgLaboralesPendientes.Items.Count == 0)
            {
                lblMensaje.Text = "No hay verificaciones laborales para procesar";
                lblMensaje.Visible = true;
                //btnImprimir.Visible = false;
            }

        }


        protected void dgLaboralesPendientes_PreRender(object sender, EventArgs e)
        {
            string strDescripcion = "";
            foreach (DataGridItem myItem in dgLaboralesPendientes.Items)
            {
                ((Label)myItem.FindControl("lblFecha")).Text = DateTime.Parse(myItem.Cells[2].Text).ToShortDateString() + " " + DateTime.Parse(myItem.Cells[2].Text).ToShortTimeString();
            }
        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            CheckBox chkSelSUrgente;
            int intIdInforme;
            int intGrupo = 0;
            EncabezadoApp Encabezado = new EncabezadoApp();
            UsuarioAutenticado Usuario = (UsuarioAutenticado)Session["UsuarioAutenticado"];

            if (dgLaboralesPendientes.Items.Count > 0)
                intGrupo = Encabezado.crearGrupoCambioEstado(Usuario.IdUsuario, 6);

			foreach(DataGridItem dgSUrg in dgLaboralesPendientes.Items)
			{
				chkSelSUrgente = (CheckBox)dgSUrg.FindControl("chkSUrgente");
				if(chkSelSUrgente.Checked)
				{
                    intIdInforme = int.Parse(dgSUrg.Cells[0].Text);
                    Encabezado.cargarEncabezado(intIdInforme);
                    Encabezado.Estado = 2;
                    Encabezado.Leido = 1;
                    Encabezado.CambiarEstado(intIdInforme);
                    Encabezado.CambiarLeido(intIdInforme);
                    Encabezado.crearCambiosEstadoInformes(intGrupo, intIdInforme, 2);
				}
			}
            Response.Redirect("impresionpendientes.aspx?idGrupo=" + intGrupo);
       }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../BandejaEntrada/Principal.aspx?idTipo=6");
        }

/*
        protected int crearGrupoCambioEstado()
        {
        
        }
*/
        protected void btnImpresiones_Click(object sender, EventArgs e)
        {
            Response.Redirect("historialimpresiones.aspx?idTipo=6");
        }
}
}