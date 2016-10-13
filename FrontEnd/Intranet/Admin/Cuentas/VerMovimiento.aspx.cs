using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.App;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.App;
using System.Data;
using ar.com.TiempoyGestion.BackEnd.ControlAcceso.App;
using System.Globalization;
using System.Web.UI.HtmlControls;

namespace ar.com.TiempoyGestion.FrontEnd.Intranet.Admin.Cuentas
{
    public partial class Admin_Cuentas_remitos : System.Web.UI.Page
    {
        int idCliente = 0;
        int nroMovimiento = 0;
        int idTipoDocumentacion = 0;
        //protected System.Web.UI.HtmlControls.HtmlGenericControl idImprimir;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                idTipoDocumentacion = int.Parse(Request.QueryString["idTipo"]);
                setTipoDocumentacion(idTipoDocumentacion);
                pnCliente.Visible = false;
                cargarRemito(idTipoDocumentacion);
                ListarServicios(idTipoDocumentacion);
            }
        }

        private void cargarRemito(int idTipoDocumentacion)
        {
            idCliente = int.Parse(Request.QueryString["idCliente"]);
            hIdCliente.Value = idCliente.ToString();
            nroMovimiento = int.Parse(Request.QueryString["nroMovimiento"]);
            HtmlControl frImprimir = (HtmlControl)this.FindControl("idImprimir");
            frImprimir.Attributes["src"] = "imprimirMovimientos.aspx?idTipo=" + idTipoDocumentacion + "&nroMovimiento=" + nroMovimiento + "&idCliente=" + idCliente;

            ClienteDal oCliente = new ClienteDal();
            oCliente.Cargar(idCliente);
            lblCliente.Text = oCliente.NombreFantasia;

            lblnroMovimiento.Text = nroMovimiento.ToString();
        }


        private void ListarServicios(int idTipoDocumento)
        {
            pnListadoInformes.Visible = true;
            pnCliente.Visible = true;

            GestorPreciosApp gp = new GestorPreciosApp();
            dgridRemitosMovimiento.DataSource = gp.ListaDetallesRemitosMovimiento(idTipoDocumento, nroMovimiento, idCliente);
            dgridRemitosMovimiento.DataBind();
        }



        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            StringBuilder cstext2 = new StringBuilder();
            String csname2 = "ButtonClickScript";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;

            cstext2.Append("<script type=\"text/javascript\"> ");
            cstext2.Append("iPrint(idImprimir); </");
            cstext2.Append("script>");
            cs.RegisterClientScriptBlock(cstype, csname2, cstext2.ToString(), false);


        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("recibosmensuales.aspx?idCliente=" + hIdCliente.Value);
        }

        private void setTipoDocumentacion(int idTipoDocumentacion)
        {
            if (idTipoDocumentacion == 1)
            {
                lblTipo.Text = "Resumen de Remitos";
                //btnAceptar.Text = "Finalizar remito";
            }
            else
            {
                lblTipo.Text = "Resumen de Partes de entrega";
                //btnAceptar.Text = "Finalizar parte de entrega";
            }
        }
    }
}