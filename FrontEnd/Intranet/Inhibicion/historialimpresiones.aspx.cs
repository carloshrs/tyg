using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Inhibicion
{
    /// <summary>
    /// Summary description for Principal.
    /// </summary>
    public partial class historialimpresiones : Page
    {
        protected Button Button1;
        private int IdUsuario = 1; //VALOR QUE SE OBTENDRA DEL CONTEXTO

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int idTipo = int.Parse(Request.QueryString["idTipo"]);
                ListarHistorial(idTipo);
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

        private void ListarHistorial(int idTipo)
        {

            lblMensaje.Text = "";


            BandejaEntradaApp listado = new BandejaEntradaApp();
            //if (chkSoloMias.Checked) idUser = IdUsuario;
            rpHistorial.DataSource = listado.ListarHistorialInformesEnviados(idTipo);
            rpHistorial.DataBind();


            if (rpHistorial.Items.Count == 0)
            {
                lblMensaje.Text = "No hay historial de Informes de Inhibición.";
                lblMensaje.Visible = true;
            }

        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("inhibicion_registro.aspx");
        }

    }
}