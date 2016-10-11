using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas
{
    /// <summary>
    /// Summary description for Principal.
    /// </summary>
    public partial class mensualesmasivos : Page
    {
        protected Button Button1;
        private int IdUsuario = 1; //VALOR QUE SE OBTENDRA DEL CONTEXTO

        protected void Page_Load(object sender, EventArgs e)
        {
            //rpHistorial.ItemDataBound +=new DataListItemEventHandler(this.Item_Bound);

            if (!Page.IsPostBack)
            {
                int idGrupo = int.Parse(Request.QueryString["idGrupo"]);
                ListarHistorial(idGrupo);
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

        private void ListarHistorial(int idGrupo)
        {

            lblMensaje.Text = "";


            BandejaEntradaApp listado = new BandejaEntradaApp();
            //if (chkSoloMias.Checked) idUser = IdUsuario;
            rpHistorial.DataSource = listado.ListarGruposClientesMasivos(idGrupo);
            rpHistorial.DataBind();


            if (rpHistorial.Items.Count == 0)
            {
                lblMensaje.Text = "No hay historial de documentos masivos.";
                lblMensaje.Visible = true;
            }

        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("listadoGruposDocumentosMasivo.aspx");
        }


        /*

        protected void Item_Bound(Object sender, DataListItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string strTexto = ((DateTime)((DataRowView)e.Item.DataItem).Row.ItemArray[0]).ToShortDateString() + " " +
                    ((DateTime)((DataRowView)e.Item.DataItem).Row.ItemArray[0]).ToShortTimeString() +
                    " generado por " + ((DateTime)((DataRowView)e.Item.DataItem).Row.ItemArray[3]).ToString() +
                    ((DateTime)((DataRowView)e.Item.DataItem).Row.ItemArray[4]).ToString() +
                    "(total " + ((DateTime)((DataRowView)e.Item.DataItem).Row.ItemArray[5]).ToString() + ")";

                ((Label)e.Item.FindControl("lblItem")).Text = strTexto;

            }

        }
         */

    }
}